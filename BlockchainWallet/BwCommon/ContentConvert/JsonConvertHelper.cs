using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace BwCommon.ContentConvert
{
    public class JsonConvertHelper
    {
        /// <summary>
        /// 生成json
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ConvertToJson<T>(T t)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            using (var stream = new System.IO.MemoryStream())
            {
                js.WriteObject(stream, t);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// 解析对象
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T ConvertToObject<T>(string jsonString)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            using (var s = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T)js.ReadObject(s);
            }

        }

        /// <summary>
        /// 解析对象
        /// </summary>
        /// <param name="jsonStream"></param>
        /// <returns></returns>
        public static object ConvertToObject<T>(System.IO.Stream jsonStream)
        {
            using (StreamReader sr = new StreamReader(jsonStream))
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
                var s = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(sr.ReadToEnd()));
                return js.ReadObject(s);
            }
        }
    }
}
