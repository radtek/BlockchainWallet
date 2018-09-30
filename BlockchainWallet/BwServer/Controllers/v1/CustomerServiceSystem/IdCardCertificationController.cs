using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwCommon.EncryptionDecryption;
using BwCommon.File;
using BwCommon.Log;
using BwDal.CustomerServiceSystem;
using BwServer.Models;
using BwServer.Models.v1.CustomerServiceSystem.IdCardCertification;

namespace BwServer.Controllers.v1.CustomerServiceSystem
{
    public class IdCardCertificationController : ApiController
    {
        private static string _tempImages = "Resource/TempImages/";
        private static string _idCardPassImages = "Resource/IdCardImages/Pass/";
        private static string _idCardUnPassImages = "Resource/IdCardImages/UnPass/";
        readonly IdCardCertificationDal _idCardCertificationDal = new IdCardCertificationDal();

        /// <summary>
        /// 查询实名认证信息
        /// </summary>
        /// <param name="idCardCertificationModelGet"></param>
        /// <returns></returns>

        public IHttpActionResult QueryIdCardCertification(IdCardCertificationModelGet idCardCertificationModelGet)
        {
            DataTable dtDataTable = _idCardCertificationDal.QueryIdCardCertification();
            IList<IdCardCertificationModelResult> list =
                ModelConvertHelper<IdCardCertificationModelResult>.ConvertToModel(dtDataTable);
            return Json(new ResultDataModel<IList<IdCardCertificationModelResult>> { Data = list });
        }

        /// <summary>
        /// 实名审核
        /// </summary>
        /// <param name="idCardCheckModelGet"></param>
        /// <returns></returns>
        public IHttpActionResult CheckIdCard(IdCardCheckModelGet idCardCheckModelGet)
        {
            DataTable dt = _idCardCertificationDal.QueryIdCardCertificationInfo(idCardCheckModelGet.Id, 0);
            if (dt == null) Json(new ResultDataModel<IdCardCertificationModelResult> { Code = -1, Messages = "审核失败，数据不存在" });
            string frontImage = dt.Rows[0]["FrontImage"].ToString();
            string reverseImage = dt.Rows[0]["ReverseImage"].ToString();
            string tempFrontImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, frontImage);
            string tempReverseImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reverseImage);
            string frontFileName;
            string reverseFileName;
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _idCardPassImages)))
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _idCardPassImages));
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _idCardUnPassImages)))
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _idCardUnPassImages));

            if (idCardCheckModelGet.State == "1")
            {
                frontFileName = Path.Combine(_idCardPassImages, Guid.NewGuid() + ".Jpg");
                reverseFileName = Path.Combine(_idCardPassImages, Guid.NewGuid() + ".Jpg");

                string newFrontImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, frontFileName);
                string newReverseImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reverseFileName);
                File.Copy(tempFrontImage, newFrontImage, true);
                File.Copy(tempReverseImage, newReverseImage, true);

            }
            else
            {
                frontFileName = Path.Combine(_idCardUnPassImages, Guid.NewGuid() + ".Jpg");
                reverseFileName = Path.Combine(_idCardUnPassImages, Guid.NewGuid() + ".Jpg");
                string newFrontImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, frontFileName);
                string newReverseImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reverseFileName);
                File.Copy(tempFrontImage, newFrontImage, true);
                File.Copy(tempReverseImage, newReverseImage, true);
            }
            bool b = _idCardCertificationDal.CheckIdCard(idCardCheckModelGet.Id, idCardCheckModelGet.EmployeeId, idCardCheckModelGet.State, idCardCheckModelGet.Remark, idCardCheckModelGet.UserId, idCardCheckModelGet.Name, idCardCheckModelGet.IdCard, frontFileName, reverseFileName);
            if (b)
            {
                File.Delete(tempFrontImage);
                File.Delete(tempReverseImage);
            }
            return Json(new ResultDataModel<IdCardCertificationModelResult> { Code = b ? 0 : -1 });
        }

        /// <summary>
        /// 通过ID获取实名认证信息
        /// </summary>
        /// <param name="idCardCertificationModelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryIdCardCertificationInfo(IdCardCertificationModelGet idCardCertificationModelGet)
        {
            DataTable dtDataTable = _idCardCertificationDal.QueryIdCardCertificationInfo(idCardCertificationModelGet.Id, idCardCertificationModelGet.UserId);
            IList<IdCardCertificationModelResult> list =
                ModelConvertHelper<IdCardCertificationModelResult>.ConvertToModel(dtDataTable);
            return Json(new ResultDataModel<IdCardCertificationModelResult> { Data = list.FirstOrDefault() });
        }

        /// <summary>
        /// 上传实名认证信息
        /// </summary>
        /// <param name="uploadIdCard"></param>
        /// <returns></returns>
        public IHttpActionResult UploadIdCardCertificationInfo(UploadIdCardCertificationInfoModelGet uploadIdCard)
        {
            string urlFrontImage;
            string urlReverseImage;
            try
            {
                if (string.IsNullOrEmpty(uploadIdCard.FrontImage) || string.IsNullOrEmpty(uploadIdCard.ReverseImage))
                    throw new Exception();
                object userId = _idCardCertificationDal.CheckIdCardExisit(uploadIdCard.IdCard);
                if (userId != null)
                {
                    if (Convert.ToInt32(userId) != uploadIdCard.UserId)
                    {
                        return Json(new ResultDataModel<IdCardCertificationModelResult> { Code = 4202, Messages = "身份证已被其他账号绑定" });
                    }
                    return Json(new ResultDataModel<IdCardCertificationModelResult> { Code = 4203, Messages = "身份证已提交申请，请勿重复提交" });
                }
                Bitmap frontImage = ImageConvertHelper.ConvertBase64ToBitmap(uploadIdCard.FrontImage);
                urlFrontImage = Md5Helper.Md5Encrypt16(uploadIdCard.IdCard, Encoding.UTF8) + Guid.NewGuid() + ".jpg";

                Bitmap reverseImage = ImageConvertHelper.ConvertBase64ToBitmap(uploadIdCard.ReverseImage);
                urlReverseImage = Md5Helper.Md5Encrypt16(uploadIdCard.IdCard, Encoding.UTF8) + Guid.NewGuid() + ".jpg";

                string tempImages = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _tempImages);
                if (!Directory.Exists(tempImages))
                    Directory.CreateDirectory(tempImages);

                frontImage.Save(tempImages + urlFrontImage, ImageFormat.Jpeg);
                frontImage.Dispose();
                urlFrontImage = _tempImages + urlFrontImage;
                reverseImage.Save(tempImages + urlReverseImage, ImageFormat.Jpeg);
                reverseImage.Dispose();
                urlReverseImage = _tempImages + urlReverseImage;
            }
            catch (Exception e)
            {
                LogHelper.error("上传实名认证信息" + e);
                return Json(new ResultDataModel<IdCardCertificationModelResult> { Code = 4201, Messages = "上传图片有误" });
            }
            int rows = _idCardCertificationDal.InsertIdCardCertificationInfo(uploadIdCard.UserId, uploadIdCard.Name, uploadIdCard.IdCard, urlFrontImage, urlReverseImage);
            return Json(new ResultDataModel<IdCardCertificationModelResult> { Code = rows == 1 ? 0 : -1 });
        }
    }
}