using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal;
using BwDal.Agent;
using BwServer.Models;
using BwServer.Models.v1.Agent.CloudMinerDistribution;

namespace BwServer.Controllers.v1.Agent
{
    public class CloudMinerDistribution_Controller : ApiController
    {
        private readonly CloudMinerDistributionDal_ _cloudMinerProductionDal = new CloudMinerDistributionDal_();
        /// <summary>
        /// 查询云矿机分销记录
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryCloudMinerDistributionRecord(CloudMinerDistributionModelGet_ modelGet)
        {
            DataSet dataSet = _cloudMinerProductionDal.QueryCloudMinerDistribution(modelGet.UserId, modelGet.DistributionDate, modelGet.DataPagingModel);
            IList<CloudMinerDistributionModelResult_> cloudMinerProductionModelResult = ModelConvertHelper<CloudMinerDistributionModelResult_>.ConvertToModel(dataSet.Tables[0]);
            return Json(new ResultDataModel<IList<CloudMinerDistributionModelResult_>> { Data = cloudMinerProductionModelResult, DataPagingResult = new DataPagingModelResult { TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]) } });
        }
        /// <summary>
        /// 查询用户每天分销记录
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryUserCloudMinerDistributionRecord(UserCloudMinerDistributionModelGet_ modelGet)
        {
            DataSet dataSet = _cloudMinerProductionDal.QueryUserCloudMinerDistribution(modelGet.DataPagingModel);
            IList<UserCloudMinerDistributionModelResult_> cloudMinerProductionModelResult = ModelConvertHelper<UserCloudMinerDistributionModelResult_>.ConvertToModel(dataSet.Tables[0]);
            return Json(new ResultDataModel<IList<UserCloudMinerDistributionModelResult_>> { Data = cloudMinerProductionModelResult, DataPagingResult = new DataPagingModelResult { TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]) } });
        }
    }
}