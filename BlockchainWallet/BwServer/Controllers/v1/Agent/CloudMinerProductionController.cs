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
using BwServer.Models.v1.Commodity.UserCloudMiner;
using BwServer.Models.v1.Transaction;

namespace BwServer.Controllers.v1.Agent
{
    public class CloudMinerProductionController : ApiController
    {
        private readonly CloudMinerProductionDal _cloudMinerProductionDal = new CloudMinerProductionDal();
        public IHttpActionResult QueryUserCloudMinerProductionRecord(CloudMinerProductionRecordModelGet modelGet)
        {
            DataSet dataSet = _cloudMinerProductionDal.QueryCloudMinerProductionRecord(modelGet.UserId, modelGet.DataPagingModel);
            IList<CloudMinerProductionRecordModelResult> cloudMinerProductionModelResult = ModelConvertHelper<CloudMinerProductionRecordModelResult>.ConvertToModel(dataSet.Tables[0]);
            string orderIds = "";
            foreach (var item in cloudMinerProductionModelResult)
            {
                orderIds += orderIds == "" ? item.Id.ToString() : "," + item.Id;
            }
            if (orderIds != "")
            {
                DataTable dataTable = _cloudMinerProductionDal.QueryCloudMinerProductionDetail(orderIds);
                IList<CloudMinerProductionDetailModelResult> transactionP2PDetailModelResults = ModelConvertHelper<CloudMinerProductionDetailModelResult>.ConvertToModel(dataTable);
                foreach (var productionModel in cloudMinerProductionModelResult)
                {
                    var list = transactionP2PDetailModelResults.Where(n => n.OrderId == productionModel.Id);
                    foreach (var model in list)
                    {
                        PayCurrencyModel payCurrencyModel = new PayCurrencyModel();
                        payCurrencyModel.CurrencyId = model.CurrencyId;
                        payCurrencyModel.Amount = model.Amount;
                        productionModel.ProductionDetails.Add(payCurrencyModel);
                    }
                }
            }

            return Json(new ResultDataModel<IList<CloudMinerProductionRecordModelResult>>
            {
                Data = cloudMinerProductionModelResult,
                DataPagingResult = new DataPagingModelResult
                {
                    TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0])
                }
            });
        }
    }
}