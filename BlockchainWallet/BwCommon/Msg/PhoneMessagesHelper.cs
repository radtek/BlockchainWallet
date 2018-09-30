using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BwCommon.EncryptionDecryption;
using BwCommon.Log;

namespace BwCommon.Msg
{
    public class PhoneMessagesHelper
    {
        public static void SendDdMessages(List<string> phoneList, string content)
        {
            //手机号  可以多个手机号
            string phones = string.Empty;
            if (phoneList == null) return;
            foreach (string phone in phoneList)
            {
                phones += string.IsNullOrEmpty(phones) ? phone : "," + phone;
            }

            SendDdMessages(phones, content);
        }

        public static bool SendDdMessages(string phones, string content)
        {
            //立即发送不需要定时
            string postData = string.Format("type=send&username={0}&password={1}&gwid={2}&mobile={3}&message={4}", "5696572", Md5Helper.Md5Encrypt("zy5696572"), "bbe7cc8", phones, content);

            Encoding encode = Encoding.GetEncoding("GBK");
            byte[] data = encode.GetBytes(postData);
            Uri url = new Uri("http://jk.106api.cn/smsGBK.aspx?");
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.Method = "POST";
            req.KeepAlive = true;
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = data.Length;
            req.AllowAutoRedirect = true;
            Stream outStream = req.GetRequestStream();
            outStream.Write(data, 0, data.Length);
            outStream.Close();
            outStream.Dispose();
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            Stream inStream = res.GetResponseStream();
            StreamReader sr = new StreamReader(inStream, encode);
            string result = sr.ReadToEnd();
            sr.Close();
            if (result.Length > 0)
            {
                //返回XML信息判断成功与否，
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(result);
                XmlNode rootNode = xmlDoc.SelectSingleNode("returnsms/code");
                switch (rootNode.InnerText)
                {
                    case "0":
                        //发送成功，放回taskid
                        string taskid = xmlDoc.SelectSingleNode("returnsms/taskID").InnerText;
                        break;
                    case "-1":
                    case "-2":
                    case "-3":
                    case "-4":
                        //............................
                        //发送失败，返回错误信息
                        string errorinfo = xmlDoc.SelectSingleNode("returnsms/remark").InnerText;
                        return false;
                }
            }
            return true;
        }
    }
}
