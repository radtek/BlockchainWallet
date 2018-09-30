using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.CommodityMgmt;

namespace BwServerSal.ServiceApi.Commodity
{
    public class CloudMinerApi
    {
        public List<CloudMinerInfoModelGet> QueryCommodityInfo(CloudMinerInfoModelSend cloudMinerInfoModelSend)
        {
            HeadModelGet<List<CloudMinerInfoModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<CloudMinerInfoModelGet>>>.PostMsg(
                ApiAddress.QueryCloudMiner, cloudMinerInfoModelSend);
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
    }
}
