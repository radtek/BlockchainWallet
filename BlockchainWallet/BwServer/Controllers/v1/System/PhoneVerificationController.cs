using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.Cache;
using BwCommon.Log;
using BwCommon.Msg;
using BwDal.User;
using BwServer.Models;
using BwServer.Models.v1.System;

namespace BwServer.Controllers.v1.System
{
    public class PhoneVerificationController : ApiController
    {
        private UserInfoDal _userInfoDal = new UserInfoDal();
        public const int OutTime = 600;
        [AllowAnonymous]
        public IHttpActionResult SendPhoneVerification(PhoneVerificationModelGet phoneVerificationModelGet)
        {
            try
            {
                if (phoneVerificationModelGet.PhoneAreaId != "86")
                {
                    return Json(new ResultDataModel<PhoneVerificationModelGet>() { Code = 0, Messages = "检测您当前地点为中国大陆境内，非中国大陆手机号接收验证可能会存在延迟" });
                }
                switch (phoneVerificationModelGet.Type)
                {
                    case "1":
                    case "3":
                        bool exisit = _userInfoDal.ExisitPhone(phoneVerificationModelGet.PhoneAreaId,
                            phoneVerificationModelGet.Phone);
                        if (exisit)
                        {
                            return Json(new ResultDataModel<PhoneVerificationModelGet> { Code = 4101, Messages = "手机号已绑定账号" });
                        }
                        break;
                    case "5":
                        exisit = _userInfoDal.ExisitPhone(phoneVerificationModelGet.PhoneAreaId,
                            phoneVerificationModelGet.Phone);
                        if (!exisit)
                        {
                            return Json(new ResultDataModel<PhoneVerificationModelGet> { Code = 4105, Messages = "手机号未绑定账号" });
                        }
                        break;
                }
                int verificationNo = 666666;
#if DEBUG

#else
                Random random = new Random();
                verificationNo= random.Next(100000, 999999);
                string msg = string.Format("【QQH】您的验证码为{0},有效期10分钟，如非本人操作，请勿回复此短信", verificationNo);
                  if (!PhoneMessagesHelper.SendDdMessages(phoneVerificationModelGet.Phone, msg))
                {
                    LogHelper.error("调用短信发送API失败");
                    throw new Exception();
                }
#endif
                PhoneVerificationCacheHelper.SetCache(phoneVerificationModelGet.PhoneAreaId, phoneVerificationModelGet.Phone, OutTime, phoneVerificationModelGet.Type, verificationNo.ToString());
                return Json(new ResultDataModel<PhoneVerificationModelGet>());
            }
            catch (Exception exception)
            {
                LogHelper.error("短信发送失败" + exception);
                return Json(new ResultDataModel<PhoneVerificationModelGet> { Code = -1, Messages = "短信发送失败" });
            }
        }

        public IHttpActionResult CheckPhoneVerification(CheckPhoneVerificationModelGet checkPhoneVerificationModelGet)
        {
            bool exisit = PhoneVerificationCacheHelper.CheckVerification(checkPhoneVerificationModelGet.PhoneAreaId, checkPhoneVerificationModelGet.Phone, checkPhoneVerificationModelGet.Type, checkPhoneVerificationModelGet.VerificationCode);
            return Json(new ResultDataModel<PhoneVerificationModelGet> { Code = exisit ? 0 : -1, Messages = exisit ? "" : "验证码不存在或不匹配" });
        }
    }
}