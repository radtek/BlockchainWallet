using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.Agent.CloudMinerDistribution;

namespace BwServerSal.ServiceApi.Agent
{
    public class CloudMinerDistributionApi
    {
        public List<CloudMinerDistributionModelGet> QueryCloudMinerProductionRecord(CloudMinerDistributionModelSend cloudMinerDistributionModelSend, out DataPagingModelGet dataPagingModelGet)
        {
            HeadModelGet<List<CloudMinerDistributionModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<CloudMinerDistributionModelGet>>>.PostMsg(
                ApiAddress.QueryCloudMinerDistributionRecord, cloudMinerDistributionModelSend);
            dataPagingModelGet = headModelGet.DataPagingResult ?? new DataPagingModelGet();
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
        public List<UserCloudMinerDistributionModelGet> QueryUserCloudMinerProductionRecord(UserCloudMinerDistributionModelSend userCloudMinerDistributionModelSend, out DataPagingModelGet dataPagingModelGet)
        {
            HeadModelGet<List<UserCloudMinerDistributionModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<UserCloudMinerDistributionModelGet>>>.PostMsg(
                ApiAddress.QueryUserCloudMinerDistributionRecord, userCloudMinerDistributionModelSend);
            dataPagingModelGet = headModelGet.DataPagingResult ?? new DataPagingModelGet();
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
    }
}
