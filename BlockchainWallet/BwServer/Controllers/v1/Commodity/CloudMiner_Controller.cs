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

namespace BwServer.Controllers.v1.Commodity
{
    public class CloudMiner_Controller : ApiController
    {
        private readonly CloudMinerDal _cloudMinerDal = new CloudMinerDal();
        public IHttpActionResult QueryCloudMiner(CloudMinerInfoModelGet modelGet)
        {
            DataTable dtDataTable = _cloudMinerDal.QueryCloudMiner();
            IList<CloudMinerInfoModelResult> list =
                ModelConvertHelper<CloudMinerInfoModelResult>.ConvertToModel(dtDataTable);

            DataTable dtRuleFansVip = _cloudMinerDal.QueryBuyCommodityRuleFansVip();
            IList<BuyCommodityRuleFansVipModelResult> buyCommodityRuleFansVipModelResults =
                ModelConvertHelper<BuyCommodityRuleFansVipModelResult>.ConvertToModel(dtRuleFansVip);

            //DataTable dtRuleFansGeneration = _cloudMinerDal.QueryBuyCommodityRuleFansVip();
            //IList<BuyCommodityRuleFansGenerationModelResult> buyCommodityRuleFansGenerationModelResults =
            //    ModelConvertHelper<BuyCommodityRuleFansGenerationModelResult>.ConvertToModel(dtRuleFansVip);

            DataTable dtPriceDetail = _cloudMinerDal.QueryCommodityPriceDetail();
            IList<CloudMinerPriceDetailModelResult> cloudMinerPriceDetailModelResult =
                ModelConvertHelper<CloudMinerPriceDetailModelResult>.ConvertToModel(dtPriceDetail);

            DataTable dtCloudMiner = _cloudMinerDal.QueryCloudMinerManufacture();
            IList<CloudMinerManufactureModelResult> cloudMinerManufactureModelResult =
                ModelConvertHelper<CloudMinerManufactureModelResult>.ConvertToModel(dtCloudMiner);

            foreach (var model in list)
            {
                model.BuyCommodityRuleFansModel.BuyCommodityRuleFansVipModelResults = buyCommodityRuleFansVipModelResults
                    .Where(n => n.CommodityId == model.Id).ToList();

                //model.BuyCommodityRuleFansGenerationModelResults = buyCommodityRuleFansGenerationModelResults.Where(n => n.CommodityId == model.Id).ToList();

                model.CloudMinerPriceDetailModelResults = cloudMinerPriceDetailModelResult
                    .Where(n => n.CommodityId == model.Id).ToList();

                model.CloudMinerManufactureModelResults = cloudMinerManufactureModelResult
                    .Where(n => n.CommodityId == model.Id).ToList();
            }

            return Json(new ResultDataModel<IList<CloudMinerInfoModelResult>> { Data = list });
        }
    }
}