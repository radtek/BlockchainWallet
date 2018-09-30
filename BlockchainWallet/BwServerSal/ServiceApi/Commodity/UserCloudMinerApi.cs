using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.CommodityMgmt;

namespace BwServerSal.ServiceApi.Commodity
{
    public class UserCloudMinerApi
    {
        public List<UserCloudMinerModelGet> QueryUserCloudMiner(UserCloudMinerModelSend userCloudMinerModelSend, out DataPagingModelGet dataPagingModelGet)
        {
            HeadModelGet<List<UserCloudMinerModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<UserCloudMinerModelGet>>>.PostMsg(
                ApiAddress.QueryUserCloudMiner, userCloudMinerModelSend);
            dataPagingModelGet = headModelGet.DataPagingResult ?? new DataPagingModelGet();
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
    }
}
