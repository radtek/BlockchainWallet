using System;
using System.IO;
using System.Net;
using System.Text;
using BwCommon.ContentConvert;
using BwCommon.EncryptionDecryption;

namespace BwServerSal
{
    public class BwHttpApiAccess<TG> where TG : class
    {
        #region 共有变量
        public static EncryptDecryptType EncryptType = EncryptDecryptType.None;
        private static readonly Encoding _encoding;
        #endregion

        #region 静态构造函数
        static BwHttpApiAccess()
        {
            _encoding = Encoding.GetEncoding("utf-8");
            AsHttpAccess.Single.OutTime = 60 * 1000;
        }
        #endregion

        #region 加密类型
        public enum EncryptDecryptType
        {
            Aes,
            Rsa,
            None
        }
        #endregion

        #region Cookie
        public static void AddCookie(Cookie cookie, string url)
        {
            CookieCollection cookieCollection = new CookieCollection { cookie };
            AsHttpAccess.Single.AddCookies(cookieCollection, url);
        }
        public static void ClearCookie()
        {
            AsHttpAccess.Single.ClearCookies();
        }
        #endregion

        #region 获取加密后的数据
        private static byte[] GetByteMsg(string msg)
        {
            byte[] msgBytes = null;
            switch (EncryptType)
            {
                case EncryptDecryptType.Aes:
                    msgBytes = AesHelper.AesEncrypt(_encoding.GetBytes(msg),
                        "Jlfc_QQh.2018@11!~^$#GRqB++(())1");
                    break;
                case EncryptDecryptType.Rsa:
                    //msgBytes = RsaHelper.RsaEncryptToBytes(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["RsaPublicKey"]), msg);
                    break;

                case EncryptDecryptType.None:
                    msgBytes = _encoding.GetBytes(msg);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return msgBytes;
        }
        #endregion

        #region Post请求获取返回实体对象
        public static TG PostMsg<TS>(string uri, TS msgJson)
        {
            TG modelGet = null;
            HttpWebResponse response = null;
            Stream stream = null;
            try
            {
                string msg = JsonConvertHelper.ConvertToJson(msgJson);
                byte[] msgBytes = GetByteMsg(msg);
                byte[] htmlBytes = AsHttpAccess.Single.Post(uri, msgBytes);
                string html;
                try
                {
                    //byte[] htmlDecryptBytes = AesHelper.AesDecrypt(htmlBytes, "Jlfc_QQh.2018@11!~^$#GRqB++(())1");

                    html = _encoding.GetString(htmlBytes);
                }
                catch (Exception)
                {
                    html = "";
                }
                modelGet = JsonConvertHelper.ConvertToObject<TG>(html);
            }
            catch (System.Exception)
            {

            }
            finally
            {
                if (stream != null) stream.Close();
                if (response != null) response.Close();
            }
            return modelGet;
        }
        #endregion
    }
}
