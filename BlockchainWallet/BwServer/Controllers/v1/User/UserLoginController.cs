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
using BwServer.Common;
using BwServer.Models;
using BwServer.Models.v1.User.UserInfo;
using BwServer.Models.v1.User.UserLogin;

namespace BwServer.Controllers.v1.User
{
    public class UserLoginController : ApiController
    {
        private readonly UserInfoDal _userInfoDal = new UserInfoDal();
        [AllowAnonymous]
        public IHttpActionResult UserLogin(UserLoginModelGet userLoginModelGet)
        {
            try
            {
                DataTable dtUserInfo = _userInfoDal.LoginUser(userLoginModelGet.Account, userLoginModelGet.PhoneAreaId, userLoginModelGet.Type, userLoginModelGet.Password);
                if (dtUserInfo.Rows.Count != 1)
                {
                    return Json(new ResultDataModel<UserInfoModelResult> { Code = -1, Messages = "用户名或密码错误" });
                }
                IList<UserInfoModelResult> list = ModelConvertHelper<UserInfoModelResult>.ConvertToModel(dtUserInfo);
                var model = list.First();
                model.Token = ServerHelper.GetToken;
                model.RealRank = _userInfoDal.CheckUserVipRank(model.Id);
                WebCacheHelper.SetCache(model.Id + "_" + 1, model.Token);
                return Json(new ResultDataModel<UserInfoModelResult> { Data = model });
            }
            catch (Exception exception)
            {
                LogHelper.error(exception.ToString());
                return Json(new ResultDataModel<UserInfoModelResult> { Code = 4001, Messages = "服务器繁忙，请稍后重试" });
            }
        }
    }
}