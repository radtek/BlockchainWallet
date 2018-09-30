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
using BwServer.Models.v1.Commodity.CloudMinerInfo;
using BwServer.Models.v1.Commodity.CommodityInfo;

namespace BwServer.Controllers.v1.Commodity
{

    public class CloudMinerController : ApiController
    {
        private readonly CloudMinerDal _cloudMinerDal = new CloudMinerDal();

        public IHttpActionResult QueryCloudMiner()
        {
            DataTable dtDataTable = _cloudMinerDal.QueryCloudMiner();
            IList<CloudMinerInfoModelResult> list =
                ModelConvertHelper<CloudMinerInfoModelResult>.ConvertToModel(dtDataTable);
            return Json(new ResultDataModel<IList<CloudMinerInfoModelResult>> { Data = list });
        }

        public IHttpActionResult QueryCloudMinerInfo(CloudMinerInfoModelGet modelGet)
        {
            DataTable dtDataTable = _cloudMinerDal.QueryCloudMinerInfo(modelGet.Id);
            IList<CloudMinerInfoModelResult> list =
                ModelConvertHelper<CloudMinerInfoModelResult>.ConvertToModel(dtDataTable);
            CloudMinerInfoModelResult cloudMinerInfoModelResult = list.FirstOrDefault();
            if (cloudMinerInfoModelResult != null)
            {
                cloudMinerInfoModelResult.RunningCount = new UserCloudMinerDal().QueryRunningCloudMinerCount(modelGet.UserId, modelGet.Id);
                cloudMinerInfoModelResult.BuyCommodityRuleFansModel.BuyCommodityRuleFansVipModelResults = ModelConvertHelper<BuyCommodityRuleFansVipModelResult>.ConvertToModel(_cloudMinerDal.QueryBuyCommodityRuleFansVip(modelGet.Id));
                // cloudMinerInfoModelResult.BuyCommodityRuleFansGenerationModelResults = ModelConvertHelper<BuyCommodityRuleFansGenerationModelResult>.ConvertToModel(_cloudMinerDal.QueryBuyCommodityRuleFansGeneration(modelGet.Id));
                cloudMinerInfoModelResult.CloudMinerPriceDetailModelResults = ModelConvertHelper<CloudMinerPriceDetailModelResult>.ConvertToModel(_cloudMinerDal.QueryCommodityPriceDetail(modelGet.Id));
                cloudMinerInfoModelResult.CloudMinerManufactureModelResults = ModelConvertHelper<CloudMinerManufactureModelResult>.ConvertToModel(_cloudMinerDal.QueryCloudMinerManufacture(modelGet.Id));
            }
            return Json(new ResultDataModel<CloudMinerInfoModelResult> { Data = cloudMinerInfoModelResult });
        }
    }
}