using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal;
using BwDal.User;
using BwServer.Models;
using BwServer.Models.v1.User.UserInfo;

namespace BwServer.Controllers.v1.User
{
    public class User_Controller : ApiController
    {
        private readonly UserInfoDal _accountInfoDal = new UserInfoDal();

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult QueryUser(UserInfoModelGet userInfoModelGet)
        {
            DataSet dsQueryUser = _accountInfoDal.QueryUser(userInfoModelGet.Phone, userInfoModelGet.Name, userInfoModelGet.DataPagingModel);
            IList<UserInfoModelResult> list = ModelConvertHelper<UserInfoModelResult>.ConvertToModel(dsQueryUser.Tables[0]);
            return Json(new ResultDataModel<IList<UserInfoModelResult>> { Data = list, DataPagingResult = new DataPagingModelResult { TotalCount = Convert.ToInt32(dsQueryUser.Tables[1].Rows[0][0]) } });
        }
    }
}