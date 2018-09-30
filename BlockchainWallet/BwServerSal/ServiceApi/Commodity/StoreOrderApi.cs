using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.CommodityMgmt;

namespace BwServerSal.ServiceApi.Commodity
{
    public class StoreOrderApi
    {

        public List<StoreOrderQueryModelGet> QueryStoreOrder(StoreOrderQueryModelSend storeOrderQueryModelSend, out DataPagingModelGet dataPagingModelGet)
        {
            HeadModelGet<List<StoreOrderQueryModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<StoreOrderQueryModelGet>>>.PostMsg(
                ApiAddress.QueryStoreOrder, storeOrderQueryModelSend);
            dataPagingModelGet = headModelGet.DataPagingResult ?? new DataPagingModelGet();
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }

        public bool CreateGaveCommodityStoreOrder(CreateGaveCommodityStoreOrderModelSend gaveCommodityStoreOrderModelSend, out string messages)
        {
            HeadModelGet<CreateGaveCommodityStoreOrderModelGet> headModelGet = BwHttpApiAccess<HeadModelGet<CreateGaveCommodityStoreOrderModelGet>>.PostMsg(
                ApiAddress.GaveCommodityStoreOrder, gaveCommodityStoreOrderModelSend);
            messages = headModelGet.Messages;
            return headModelGet.Code == 0;
        }

        public List<QueryGaveCommodityStoreOrderModelGet> QueryGaveCommodityStoreOrder(QueryGaveCommodityStoreOrderModelSend queryGaveCommodityStoreOrderModelSend, out DataPagingModelGet dataPagingModelGet)
        {
            HeadModelGet<List<QueryGaveCommodityStoreOrderModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<QueryGaveCommodityStoreOrderModelGet>>>.PostMsg(
                ApiAddress.QueryGaveCommodityStoreOrder, queryGaveCommodityStoreOrderModelSend);
            dataPagingModelGet = headModelGet.DataPagingResult ?? new DataPagingModelGet();
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }

    }
}
