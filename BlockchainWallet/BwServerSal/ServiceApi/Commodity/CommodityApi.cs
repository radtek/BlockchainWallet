using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.CommodityMgmt;

namespace BwServerSal.ServiceApi.Commodity
{
    public class CommodityApi
    {
        public List<CommodityInfoQueryModelGet> QueryCommodityInfo(CommodityInfoQueryModelSend commodityInfoQueryModelSend)
        {
            HeadModelGet<List<CommodityInfoQueryModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<CommodityInfoQueryModelGet>>>.PostMsg(
                ApiAddress.QueryCommodityInfo, commodityInfoQueryModelSend);
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
    }
}
