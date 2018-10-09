using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwCommon.Log;
using BwDal.Commodity;
using BwDal.System;
using BwServer.Common;
using BwServer.Controllers.v1.Agent;
using BwServer.Models;
using BwServer.Models.v1.Commodity.CloudMinerInfo;

namespace BwServer.Controllers.v1.Commodity
{
    public class CloudMiner_Controller : ApiController
    {
        private readonly CloudMinerDal _cloudMinerDal = new CloudMinerDal();
        private readonly SystemMaintenanceDal_ _systemMaintenanceDal = new SystemMaintenanceDal_();
        private static int SystemMaintenanceId = 0;
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

        public IHttpActionResult RunCloudMiner(RunCloudMinerModelGet_ modelGet)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                string dtBegin = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                string dtEnd = dateTime.AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss");
                SystemMaintenanceId = _systemMaintenanceDal.InsertSystemMaintenance(dtBegin, dtEnd, modelGet.EmployeeId);
                SystemMaintenance.Add(dateTime, dateTime.AddMinutes(30));
                CloudMinerServer.Single.StartListenServer();
                return Json(new ResultDataModel<IList<CloudMinerInfoModelResult>> { Code = 0 });
            }
            catch (Exception e)
            {
                if (SystemMaintenanceId != 0)
                {
                    _systemMaintenanceDal.UpdateSystemMaintenance(SystemMaintenanceId, modelGet.EmployeeId);
                }
                return Json(new ResultDataModel<IList<CloudMinerInfoModelResult>> { Code = -1, Messages = e.Message });
            }
        }

        /// <summary>
        /// 检查云矿机运行结果
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult CheckCloudMiner(RunCloudMinerModelGet_ modelGet)
        {
            try
            {
                IHttpActionResult iHttpActionResult =
                    Json(new ResultDataModel<object> { Code = 0, Messages = CloudMinerServer.Single.State });
                if (CloudMinerServer.Single.State != "1")
                {
                    CloudMinerServer.Single.State = "0";
                    if (SystemMaintenanceId != 0)
                    {
                        _systemMaintenanceDal.UpdateSystemMaintenance(modelGet.EmployeeId, SystemMaintenanceId);
                    }
                    SystemMaintenance.Refresh();
                }
                return iHttpActionResult;
            }
            catch (Exception e)
            {
                LogHelper.error(e.Message);
                return Json(new ResultDataModel<object> { Code = -1, Messages = e.Message });
            }
        }

    }
}