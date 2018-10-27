using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal;
using BwDal.Agent;
using BwServer.Models;
using BwServer.Models.v1.Agent.CloudMinerDistribution;
using BwServer.Models.v1.Commodity.UserCloudMiner;
using BwServer.Models.v1.Transaction;

namespace BwServer.Controllers.v1.Agent
{
    public class CloudMinerDistributionController : ApiController
    {
        private readonly CloudMinerDistributionDal _cloudMinerDistributionDal = new CloudMinerDistributionDal();
        public IHttpActionResult QueryUserCloudMinerDistributionRecord(CloudMinerDistributionRecordModelGet modelGet)
        {
            DataSet dataSet = _cloudMinerDistributionDal.QueryCloudMinerDistributionRecord(modelGet.UserId, modelGet.DataPagingModel);
            IList<CloudMinerDistributionRecordModelResult> cloudMinerDistributionModelResult = ModelConvertHelper<CloudMinerDistributionRecordModelResult>.ConvertToModel(dataSet.Tables[0]);
            string orderIds = "";
            foreach (var item in cloudMinerDistributionModelResult)
            {
                orderIds += orderIds == "" ? item.Id.ToString() : "," + item.Id;
            }
            if (orderIds != "")
            {
                DataTable dataTable = _cloudMinerDistributionDal.QueryCloudMinerDistributionDetail(orderIds);
                IList<CloudMinerDistributionDetailModelResult> transactionP2PDetailModelResults = ModelConvertHelper<CloudMinerDistributionDetailModelResult>.ConvertToModel(dataTable);
                foreach (var distributionModel in cloudMinerDistributionModelResult)
                {
                    var list = transactionP2PDetailModelResults.Where(n => n.OrderId == distributionModel.Id);
                    foreach (var model in list)
                    {
                        PayCurrencyModel payCurrencyModel = new PayCurrencyModel();
                        payCurrencyModel.CurrencyId = model.CurrencyId;
                        payCurrencyModel.Amount = model.Amount;
                        distributionModel.DistributionDetails.Add(payCurrencyModel);
                    }
                }
            }

            return Json(new ResultDataModel<IList<CloudMinerDistributionRecordModelResult>>
            {
                Data = cloudMinerDistributionModelResult,
                DataPagingResult = new DataPagingModelResult
                {
                    TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0])
                }
            });
        }

    }
}