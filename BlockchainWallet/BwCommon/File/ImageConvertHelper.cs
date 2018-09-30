using System;
using System.Drawing;
using System.IO;

namespace BwCommon.File
{
    public class ImageConvertHelper
    {
        public static Bitmap ConvertBase64ToBitmap(string base64String)
        {
            base64String = base64String.Replace("data:image/jpeg;base64,", "");
            byte[] b = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(b);
            Bitmap bitmap = new Bitmap(ms);
            return bitmap;
        }
        public static string ConvertImageFileToBase64(string imagefile)
        {
            string strbaser64 = "";
            try
            {
                Bitmap bmp = new Bitmap(imagefile);
                strbaser64 = ConvertImageToBase64(bmp);
            }
            catch (Exception)
            {
                throw new Exception("Something wrong during convert!");
            }
            return strbaser64;
        }
        public static string ConvertImageToBase64(Bitmap bmp)
        {
            string strbaser64 = "";
            try
            {
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                strbaser64 = Convert.ToBase64String(arr);
            }
            catch (Exception)
            {
                throw new Exception("Something wrong during convert!");
            }
            return strbaser64;
        }
    }
}
