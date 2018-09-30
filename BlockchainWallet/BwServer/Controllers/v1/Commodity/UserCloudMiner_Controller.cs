using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal;
using BwDal.Commodity;
using BwServer.Models;
using BwServer.Models.v1.Agent.CloudMinerProduct;
using BwServer.Models.v1.Commodity.UserCloudMiner;

namespace BwServer.Controllers.v1.Commodity
{
    public class UserCloudMiner_Controller : ApiController
    {
        private readonly UserCloudMinerDal_ _userCloudMinerDal = new UserCloudMinerDal_();
        public IHttpActionResult QueryUserCloudMiner(UserCloudMinerModelGet_ modelGet)
        {
            DataSet dataSet = _userCloudMinerDal.QueryUserCloudMiner(modelGet.DataPagingModel);
            IList<UserCloudMinerModelResult_> userCloudMinerModelResult = ModelConvertHelper<UserCloudMinerModelResult_>.ConvertToModel(dataSet.Tables[0]);
            return Json(new ResultDataModel<IList<UserCloudMinerModelResult_>> { Data = userCloudMinerModelResult, DataPagingResult = new DataPagingModelResult() { TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]) } });
        }
    }
}