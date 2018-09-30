using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwCommon.EncryptionDecryption;
using BwCommon.File;
using BwDal.CustomerServiceSystem;
using BwDal.User;
using BwServer.Models;
using BwServer.Models.v1.CustomerServiceSystem.IdCardCertification;
using BwServer.Models.v1.CustomerServiceSystem.ReceivablesInformation;

namespace BwServer.Controllers.v1.CustomerServiceSystem
{
    public class ReceivablesInformationController : ApiController
    {
        private static string _tempImages = "Resource/CollectionCodeImage/";
        private readonly ReceivablesInformationDal _receivablesInformationDal = new ReceivablesInformationDal();
        private readonly UserInfoDal _userInfoDal = new UserInfoDal();
        /// <summary>
        /// 上传银行卡信息
        /// </summary>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        public IHttpActionResult UploadBankCodeInfo(UploadBankCodeInfoModelGet bankCode)
        {
            if (string.IsNullOrEmpty(bankCode.PayPassowrd))
            {
                return Json(new ResultDataModel<IList<BankCodeInfoModelResult>> { Code = 4010, Messages = "数据不完整或存在空数据" });
            }

            if (!_userInfoDal.CheckPayPassowrd(bankCode.UserId, bankCode.PayPassowrd))
            {
                return Json(new ResultDataModel<IList<BankCodeInfoModelResult>> { Code = 4106, Messages = "支付密码错误" });
            }

            int rows = _receivablesInformationDal.InsertBankCodeInfo(bankCode.UserId, bankCode.Name, bankCode.BankCode,
                 bankCode.OpeningBank, bankCode.Address);
            return Json(new ResultDataModel<IList<BankCodeInfoModelResult>> { Code = rows == 1 ? 0 : -1 });
        }

        /// <summary>
        /// 查询银行收款信息
        /// </summary>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        public IHttpActionResult QueryBankCodeInfo(BankCodeInfoModelGet bankCode)
        {
            DataTable dtBankCodeInfo = _receivablesInformationDal.QueryBankCodeInfo(bankCode.UserId);
            IList<BankCodeInfoModelResult> bankCodeInfoModelResults =
                ModelConvertHelper<BankCodeInfoModelResult>.ConvertToModel(dtBankCodeInfo);
            return Json(new ResultDataModel<BankCodeInfoModelResult> { Data = bankCodeInfoModelResults.FirstOrDefault() });
        }

        /// <summary>
        /// 查询第三方收款信息
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryThirdCollectionInfo(ThirdCollectionInfoModelGet modelGet)
        {
            DataTable dtBankCodeInfo = _receivablesInformationDal.QueryThirdCollectionInfo(modelGet.UserId, modelGet.AccountType);
            IList<ThirdCollectionInfoModelResult> thirdCollectionInfoModelResults =
                ModelConvertHelper<ThirdCollectionInfoModelResult>.ConvertToModel(dtBankCodeInfo);
            return Json(new ResultDataModel<ThirdCollectionInfoModelResult> { Data = thirdCollectionInfoModelResults.FirstOrDefault() });
        }

        /// <summary>
        /// 上传第三方收款信息
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult UploadThirdCollectionInfo(UploadThirdCollectionInfoModelGet modelGet)
        {
            if (string.IsNullOrEmpty(modelGet.PayPassowrd))
            {
                return Json(new ResultDataModel<BankCodeInfoModelResult> { Code = 4010, Messages = "数据不完整或存在空数据" });
            }
            if (!_userInfoDal.CheckPayPassowrd(modelGet.UserId, modelGet.PayPassowrd))
            {
                return Json(new ResultDataModel<BankCodeInfoModelResult> { Code = 4106, Messages = "支付密码错误" });
            }
            string urlCollectionCodeImage;
            try
            {
                Bitmap collectionCodeImage = ImageConvertHelper.ConvertBase64ToBitmap(modelGet.CollectionCodeImage);
                urlCollectionCodeImage = Path.Combine(_tempImages, Md5Helper.Md5Encrypt16(modelGet.Account, Encoding.UTF8) + Guid.NewGuid() + ".jpg");
                string tempImages = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _tempImages);
                if (!Directory.Exists(tempImages))
                    Directory.CreateDirectory(tempImages);
                collectionCodeImage.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, urlCollectionCodeImage));
            }
            catch (Exception)
            {
                return Json(new ResultDataModel<BankCodeInfoModelResult> { Code = -1, Messages = "图片有误" });
            }
            int rows = _receivablesInformationDal.InsertThirdCollectionInfo(modelGet.UserId, modelGet.Name, modelGet.Account,
                urlCollectionCodeImage, modelGet.AccountType);
            return Json(new ResultDataModel<UploadThirdCollectionInfoModelGet> { Code = rows == 1 ? 0 : -1 });
        }
    }
}