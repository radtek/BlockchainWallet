using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal.Commodity;
using BwServer.Models;
using BwServer.Models.v1.Commodity.UserCloudMiner;

namespace BwServer.Controllers.v1.Commodity
{
    public class UserCloudMinerController : ApiController
    {
        private UserCloudMinerDal _userCloudMinerDal = new UserCloudMinerDal();
        /// <summary>
        /// 查询矿机列表
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryUserCloudMiner(UserCloudMinerModelGet modelGet)
        {
            DataTable dt = _userCloudMinerDal.QueryUserCloudMiner(modelGet.UserId);
            IList<UserCloudMinerModelResult> userCloudMinerModelResults =
                ModelConvertHelper<UserCloudMinerModelResult>.ConvertToModel(dt);
            return Json(new ResultDataModel<IList<UserCloudMinerModelResult>>() { Data = userCloudMinerModelResults });
        }

        /// <summary>
        ///查询矿机信息
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryUserCloudMinerInfo(UserCloudMinerInfoModelGet modelGet)
        {
            DataTable dt = _userCloudMinerDal.QueryUserCloudMinerInfo(modelGet.Id);
            IList<UserCloudMinerModelResult> userCloudMinerModelResults =
                ModelConvertHelper<UserCloudMinerModelResult>.ConvertToModel(dt);
            return Json(new ResultDataModel<UserCloudMinerModelResult>() { Data = userCloudMinerModelResults.FirstOrDefault() });
        }

        /// <summary>
        /// 查询矿机总览
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryUserCloudMinerOverview(UserCloudMinerModelGet modelGet)
        {
            DataTable dt = _userCloudMinerDal.QueryUserCloudMinerOverview(modelGet.UserId);
            IList<UserCloudMinerOverviewModelResult> userCloudMinerModelResults =
                ModelConvertHelper<UserCloudMinerOverviewModelResult>.ConvertToModel(dt);
            return Json(new ResultDataModel<UserCloudMinerOverviewModelResult>() { Data = userCloudMinerModelResults.FirstOrDefault() });
        } 
    }
}