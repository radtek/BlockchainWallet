using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.Cache;
using BwCommon.ContentConvert;
using BwCommon.Log;
using BwDal.User;
using BwServer.Models;
using BwServer.Models.v1.User.UserInfo;

namespace BwServer.Controllers.v1.User
{
    public class UserInfoController : ApiController
    {

        private readonly FansDal _fansDal = new FansDal();

        private readonly UserInfoDal _accountInfoDal = new UserInfoDal();
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult RegisterUserInfo(UserInfoRegisterModelGet userInfoRegisterModelGet)
        {
            try
            {
                bool exisit = PhoneVerificationCacheHelper.CheckVerification(userInfoRegisterModelGet.PhoneAreaId, userInfoRegisterModelGet.Phone, "1", userInfoRegisterModelGet.VerificationCode);
                if (!exisit) return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = 4102, Messages = "手机和验证码不匹配" });
                DataTable dtPromotionInfo = _fansDal.QueryPromotionInfo(userInfoRegisterModelGet.PromotionCode);
                if (dtPromotionInfo.Rows.Count < 1) return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = 4103, Messages = "推广码不存在" });
                bool isExisit = _accountInfoDal.CheckPhone(userInfoRegisterModelGet.Phone, userInfoRegisterModelGet.PhoneAreaId);
                if (isExisit)
                {
                    return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = -1, Messages = "手机号已注册，请直接登录" });
                }
                int registered = _accountInfoDal.RegisterUserInfo(userInfoRegisterModelGet.Phone, userInfoRegisterModelGet.PhoneAreaId, userInfoRegisterModelGet.Password, Convert.ToInt32(dtPromotionInfo.Rows[0]["UId"]), Convert.ToInt32(dtPromotionInfo.Rows[0]["Id"]));
                if (registered == -2)
                {
                    return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = -1, Messages = "该手机号已注册" });
                }
                return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = registered == 1 ? 0 : -1, Messages = registered == 1 ? "" : "注册失败" });
            }
            catch (Exception exception)
            {
                LogHelper.error(exception.Message);
                return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = -1, Messages = "服务器内部出现错误" });
            }
        }

        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult UpdatePhone(UpdatePhoneModelGet modelGet)
        {
            int rows = _accountInfoDal.UpdatePhone(modelGet.Id, modelGet.PhoneAreaId, modelGet.Phone);
            return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = rows == 1 ? 0 : -1 });
        }

        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult UpdateLoginPassword(UpdateLoginPasswordModelGet updateLoginPasswordModelGet)
        {
            int rows = _accountInfoDal.UpdateLoginPassword(updateLoginPasswordModelGet.Id, updateLoginPasswordModelGet.OldLoginPassword, updateLoginPasswordModelGet.LoginPassword);
            return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = rows == 1 ? 0 : -1 });
        }

        /// <summary>
        /// 找回登录密码
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult RetrieveLoginPassword(RetrieveLoginPasswordModelGet modelGet)
        {
            bool exisit = PhoneVerificationCacheHelper.CheckVerification(modelGet.PhoneAreaId, modelGet.Phone, "5", modelGet.VerificationCode);
            if (!exisit) return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = 4102, Messages = "手机和验证码不匹配" });
            int rows = _accountInfoDal.RetrieveLoginPassword(modelGet.PhoneAreaId, modelGet.Phone, modelGet.LoginPassword);
            return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = rows == 1 ? 0 : -1 });
        }

        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="updatePayPasswordModel"></param>
        /// <returns></returns>
        public IHttpActionResult UpdatePayPassword(UpdatePayPasswordModel updatePayPasswordModel)
        {
            bool exisit = PhoneVerificationCacheHelper.CheckVerification(updatePayPasswordModel.PhoneAreaId,
                 updatePayPasswordModel.Phone, "4", updatePayPasswordModel.VerificationCode);
            if (!exisit) return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = 4102, Messages = "手机和验证码不匹配" });
            int rows = _accountInfoDal.UpdatePayPassword(updatePayPasswordModel.Id, updatePayPasswordModel.PayPassword);
            return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = rows == 1 ? 0 : -1 });
        }

        /// <summary>
        /// 修改昵称
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult UpdateNickname(UpdateNicknameModelGet updateNicknameModelGet)
        {
            int rows = _accountInfoDal.UpdateNickname(updateNicknameModelGet.Id, updateNicknameModelGet.Nickname);
            return Json(new ResultDataModel<CompanyAccountInfoModelResult> { Code = rows == 1 ? 0 : -1 });
        }

        /// <summary>
        /// 修改性别
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult UpdateSex(UpdateSexModelGet updateSexModelGet)
        {
            int rows = _accountInfoDal.UpdateSex(updateSexModelGet.Id, updateSexModelGet.Sex);
            return Json(new ResultDataModel<UpdateSexModelResult> { Code = rows == 1 ? 0 : -1 });
        }

        /// <summary>
        /// 绑定外部账号
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult BindExternalUser(BindExternalUserModelGet modelGet)
        {
            string openUserId = _accountInfoDal.BindExternalUser(modelGet.UserId, modelGet.ExternalUserId, modelGet.AppId);
            return Json(new ResultDataModel<BindExternalUserModelResult> { Code = (openUserId != "-1" && openUserId != " -2") ? 0 : -1, Messages = openUserId == "-2" ? "用户已绑定" : "", Data = new BindExternalUserModelResult() { OpenUserId = (openUserId != "-1" && openUserId != " -2") ? openUserId : "" } });
        }

        /// <summary>
        /// 检查第三方程序用户绑定状态
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult CheckBindExternalUserState(CheckBindExternalUserStateModelGet modelGet)
        {
            string result = _accountInfoDal.CheckBindExternalUserState(modelGet.UserId, modelGet.AppId);
            return Json(new ResultDataModel<CheckBindExternalUserStateModelResult>
            {
                Code = 0,
                Data = new CheckBindExternalUserStateModelResult()
                {
                    OpenUserId = result
                }
            });
        }

        /// <summary>
        /// 检查第三方程序用户绑定状态（对外开放接口）
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult CheckBindExternalUserState3(CheckBindExternalUserStateModelGet modelGet)
        {
            string result = _accountInfoDal.CheckBindExternalUserState3(modelGet.ExternalUserId, modelGet.AppId);
            return Json(new ResultDataModel<CheckBindExternalUserStateModelResult>
            {
                Code = 0,
                Data = new CheckBindExternalUserStateModelResult()
                {
                    OpenUserId = result
                }
            });
        }
    }
}