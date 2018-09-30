using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwCommon.Log;
using BwDal;
using BwDal.Agent;
using BwServer.Models;
using BwServer.Models.v1.Agent.CloudMinerProduct;
using BwServer.Models.v1.Commodity.StoreOrder;

namespace BwServer.Controllers.v1.Agent
{
    public class CloudMinerProduction_Controller : ApiController
    {
        private readonly CloudMinerProductionDal_ _cloudMinerProductionDal = new CloudMinerProductionDal_();
        public IHttpActionResult QueryCloudMinerProductionRecord(CloudMinerProductionModelGet_ modelGet)
        {
            DataSet dataSet = _cloudMinerProductionDal.QueryCloudMinerProductionRecord(modelGet.UserId, modelGet.ProductionDate, modelGet.DataPagingModel);
            IList<CloudMinerProductionModelResult_> cloudMinerProductionModelResult = ModelConvertHelper<CloudMinerProductionModelResult_>.ConvertToModel(dataSet.Tables[0]);
            return Json(new ResultDataModel<IList<CloudMinerProductionModelResult_>> { Data = cloudMinerProductionModelResult, DataPagingResult = new DataPagingModelResult() { TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]) } });
        }

        public IHttpActionResult QueryUserCloudMinerProductionRecord(UserCloudMinerProductionModelGet_ modelGet)
        {
            DataSet dataSet = _cloudMinerProductionDal.QueryUserCloudMinerProductionRecord(modelGet.DataPagingModel);
            IList<UserCloudMinerProductionModelResult_> cloudMinerProductionModelResult = ModelConvertHelper<UserCloudMinerProductionModelResult_>.ConvertToModel(dataSet.Tables[0]);
            return Json(new ResultDataModel<IList<UserCloudMinerProductionModelResult_>> { Data = cloudMinerProductionModelResult, DataPagingResult = new DataPagingModelResult() { TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]) } });
        }
    }
}