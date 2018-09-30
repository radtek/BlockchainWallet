using System;
using System.Security.Cryptography;
using System.Text;

namespace BwCommon.EncryptionDecryption
{
    public class AesHelper
    {
        /// <summary>
        ///  AES 加密
        /// </summary>
        /// <param name="str">明文（待加密）</param>
        /// <param name="key">密文32位</param>
        /// <returns></returns>
        public static string AesEncrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);
            byte[] resultBytes = AesEncrypt(toEncryptArray, key);
            return Convert.ToBase64String(resultBytes, 0, resultBytes.Length);
        }

        public static byte[] AesEncrypt(byte[] bytes, string key)
        {
            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(bytes, 0, bytes.Length);
            return resultArray;
        }

        /// <summary>
        ///  AES 解密
        /// </summary>
        /// <param name="str">明文（待解密）</param>
        /// <param name="key">密文32位</param>
        /// <returns></returns>
        public static string AesDecrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Convert.FromBase64String(str);

            return Encoding.UTF8.GetString(AesDecrypt(toEncryptArray, key));
        }

        public static byte[] AesDecrypt(byte[] bytes, string key)
        {

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(bytes, 0, bytes.Length);
            return resultArray;
        }
    }
}
