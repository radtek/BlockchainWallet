using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.Agent;
using BwBackModel.Agent.CloudMinerProduction;

namespace BwServerSal.ServiceApi.Agent
{
    public class CloudMinerProductionApi
    {
        public List<CloudMinerProductionModelGet> QueryCloudMinerProductionRecord(CloudMinerProductionModelSend cloudMinerProductionModelSend, out DataPagingModelGet dataPagingModelGet)
        {
            HeadModelGet<List<CloudMinerProductionModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<CloudMinerProductionModelGet>>>.PostMsg(
                ApiAddress.QueryCloudMinerProductionRecord, cloudMinerProductionModelSend);
            dataPagingModelGet = headModelGet.DataPagingResult ?? new DataPagingModelGet();
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
        public List<UserCloudMinerProductionModelGet> QueryUserCloudMinerProductionRecord(UserCloudMinerProductionModelSend userCloudMinerProductionModelSend, out DataPagingModelGet dataPagingModelGet)
        {
            HeadModelGet<List<UserCloudMinerProductionModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<UserCloudMinerProductionModelGet>>>.PostMsg(
                ApiAddress.QueryUserCloudMinerProductionRecord, userCloudMinerProductionModelSend);
            dataPagingModelGet = headModelGet.DataPagingResult ?? new DataPagingModelGet();
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
    }
}
