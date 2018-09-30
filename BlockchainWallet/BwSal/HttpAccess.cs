using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace BwSal
{
    public class HttpAccess : ServiceAccess, IIpServer
    {
        #region 全局变量
        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port
        {
            get { return _port; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("端口号不能小于0");
                }
                _port = value;
            }
        }
        /// <summary>
        /// 服务器地址
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// 需要传输的Cookie集合的容器
        /// </summary>
        public CookieContainer CookieContainer = new CookieContainer();
        /// <summary>
        /// 请求数据编码格式（默认UTF-8）
        /// </summary>
        public Encoding RequestEncoding = Encoding.UTF8;
        /// <summary>
        /// 标头（备选：application/x-www-form-urlencoded）
        /// </summary>
        public string ContentType = "application/json; charset=UTF-8";
        public string UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        /// <summary>
        /// 设置超时时间
        /// </summary>
        public int OutTime
        {
            get { return _outTime; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception();
                }
                _outTime = value;
            }
        }

        #endregion

        #region 全局私有变量
        private int _port = 0; //端口号
        private int _outTime = 100000;//设置超时时间
        #endregion

        #region Cookie
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="cookieCollection">cookie集合</param>
        /// <param name="url">作用域</param>
        public void AddCookies(CookieCollection cookieCollection, string url)
        {
            CookieContainer.Add(new Uri(url), cookieCollection);
        }
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="cookieCollection">cookie集合</param>
        /// <param name="url">作用域</param>
        public void ClearCookies()
        {
            CookieContainer = new CookieContainer();
        }
        #endregion

        #region Post请求
        /// <summary>
        /// 发起Post请求
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="bytesPostMsg">发送的byte数组数据</param>
        /// <returns>返回网络流</returns>
        public byte[] Post(string url, byte[] bytesPostMsg)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (RequestEncoding == null)
            {
                throw new ArgumentNullException("" + "RequestEncoding" + "");
            }
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            Stream responseStream = null;
            try
            {

                if (url.ToLower().StartsWith("https"))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                        new RemoteCertificateValidationCallback(CheckValidationResult);
                    httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                    httpWebRequest.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                }
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = OutTime;
                httpWebRequest.CookieContainer = CookieContainer;
                httpWebRequest.ContentType = ContentType;
                httpWebRequest.UserAgent = UserAgent;
                httpWebRequest.Proxy = null;
                httpWebRequest.KeepAlive = false;
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.ServicePoint.Expect100Continue = false;
                if (bytesPostMsg == null)
                {
                    httpWebRequest.ContentLength = 0;
                }
                if (bytesPostMsg != null && bytesPostMsg.Length > 0)
                {
                    using (Stream stream = httpWebRequest.GetRequestStream())
                    {
                        stream.Write(bytesPostMsg, 0, bytesPostMsg.Length);
                    }
                }
                try
                {
                    httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                }
                catch (Exception e)
                {
                    byte[] bytesResult = null;
                    BeforError(ErrorType.ServerError, e);
                    bool isReturn = false;
                    bytesResult = ServerError(e, out isReturn);
                    AfterError(ErrorType.ServerError, e);
                    return isReturn ? bytesResult : null;
                }
                responseStream = httpWebResponse.GetResponseStream();
                byte[] htmlBytes = NetStreamToBytes(responseStream, 1024, 512);
                return htmlBytes;
            }
            catch (Exception e)
            {
                byte[] bytesResult = null;
                BeforError(ErrorType.ServiceError, e);
                bool isReturn = false;
                bytesResult = LocalError(e, out isReturn);
                AfterError(ErrorType.ServiceError, e);
                return isReturn ? bytesResult : null;
            }
            finally
            {
                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                    httpWebRequest = null;
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream = null;
                }
                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                    httpWebResponse = null;
                }
            }
        }
        #endregion

        #region Get请求

        /// <summary>
        /// 创建Http请求
        /// </summary>
        /// <param name="url">服务地址和参数</param>
        /// <returns></returns>
        public byte[] Get(string url)
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            Stream responseStream = null;
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    throw new ArgumentNullException("url");
                }
                if (url.ToLower().StartsWith("https"))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                        new RemoteCertificateValidationCallback(CheckValidationResult);
                    httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                    httpWebRequest.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                }
                httpWebRequest.Method = "GET";
                httpWebRequest.Timeout = OutTime;
                httpWebRequest.UserAgent = UserAgent;
                httpWebRequest.CookieContainer = CookieContainer;
                httpWebRequest.KeepAlive = false;
                httpWebRequest.Proxy = null;
                httpWebRequest.AllowAutoRedirect = true;
                httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                responseStream = httpWebResponse.GetResponseStream();
                byte[] htmlBytes = NetStreamToBytes(responseStream, 1024, 512);
                return htmlBytes;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                    httpWebRequest = null;
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream = null;
                }
                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                    httpWebResponse = null;
                }
            }
        }


        #endregion

        #region Https请求时认证
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {

            return true; //总是接受  
        }
        #endregion

        #region 测试接口连接状态
        /// <summary>
        /// 测试IP和端口是否打开
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public bool TestConnect(Uri uri)
        {
            return TestConnect(uri.Host, uri.Port);
        }
        /// <summary>
        ///  测试IP和端口是否打开
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        /// <returns></returns>
        public bool TestConnect(string ip, int port)
        {
            return TestConnect(ip, port, 10);
        }

        /// <summary>
        ///  测试IP和端口是否打开
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        /// <param name="outTime">超时时间</param>
        /// <returns></returns>
        public bool TestConnect(string ip, int port, int outTime)
        {
            TcpClient tcpClient = new TcpClient();
            try
            {
                DateTime dtS = DateTime.Now;
                bool isConnect = false;
                tcpClient.BeginConnect(ip, port, t =>
                {
                    tcpClient.EndConnect(t);
                    isConnect = true;
                }, isConnect);
                while (!isConnect)
                {
                    if ((DateTime.Now - dtS).TotalSeconds > outTime)
                    {
                        return false;
                    }
                    Thread.Sleep(100);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (tcpClient.Connected)
                {
                    tcpClient.Close();
                }
            }
        }
        /// <summary>
        /// 服务测试
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="msg">传输数据</param>
        /// <returns></returns>
        public bool TestConnect(string url, string msg)
        {
            try
            {
                HttpAccess httpAccess = new HttpAccess();
                httpAccess.OutTime = 10000;
                byte[] htmlBytes = httpAccess.Get(url);
                string html = Encoding.UTF8.GetString(htmlBytes);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 错误处理
        /// <summary>
        ///  本地错误处理
        /// </summary>
        /// <param name="e"></param>
        public virtual byte[] LocalError(Exception e, out bool isUseReturn)
        {
            isUseReturn = false;
            return null;
        }
        /// <summary>
        /// 服务访问错误处理
        /// </summary>
        /// <param name="e"></param>
        public virtual byte[] ServerError(Exception e, out bool isUseReturn)
        {
            isUseReturn = false;
            return null;
        }

        /// <summary>
        /// 服务自定义错误处理
        /// </summary>
        /// <param name="o"></param>
        public virtual void ServiceError(object o)
        {

        }
        /// <summary>
        /// 错误类型
        /// </summary>
        public enum ErrorType
        {
            /// <summary>
            /// 本地错误
            /// </summary>
            LocalError,
            /// <summary>
            /// 服务器错误
            /// </summary>
            ServerError,
            /// <summary>
            /// 服务内部错误
            /// </summary>
            ServiceError
        }
        /// <summary>
        /// 错误处理之前执行
        /// </summary>
        /// <param name="errorType">错误类型</param>
        /// <param name="o">错误信息</param>
        public virtual void BeforError(ErrorType errorType, object o)
        {

        }
        /// <summary>
        /// 错误处理之后执行
        /// </summary>
        /// <param name="errorType">错误类型</param>
        /// <param name="o">错误信息</param>
        public virtual void AfterError(ErrorType errorType, object o)
        {

        }
        #endregion

        #region 私有方法
        #region 将流转化成Byte数组
        /// <summary>
        /// 将流转化成Byte数组（主要解决网络流无法获取流长度）
        /// </summary>
        /// <param name="stream">流对象</param>
        /// <param name="bufferLenght">首次读取长度</param>
        /// <param name="addBufferLenght">每次添加的长度</param>
        /// <returns></returns>
        private static byte[] NetStreamToBytes(Stream stream, int bufferLenght, int addBufferLenght)
        {
            int count = 0;
            int block;
            byte[] bytesBuffer = new byte[bufferLenght];
            while ((block = stream.Read(bytesBuffer, count, bytesBuffer.Length - count)) > 0)
            {
                count += block;
                if (count == bytesBuffer.Length)
                {
                    int nextByte = stream.ReadByte();
                    if (nextByte == -1)
                    {
                        break;
                    }
                    bufferLenght += addBufferLenght;
                    byte[] newBytes = new byte[bufferLenght];
                    Array.Copy(bytesBuffer, newBytes, bytesBuffer.Length);
                    bytesBuffer = newBytes;
                    Buffer.SetByte(bytesBuffer, count, (byte)nextByte);
                    count++;
                }
            }
            byte[] bytes = new byte[count];
            Array.Copy(bytesBuffer, bytes, count);
            return bytes;
        }
        #endregion
        #endregion
    }
}
