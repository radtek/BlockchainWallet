using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.WalletMgmt;

namespace BwServerSal.ServiceApi.Wallet
{
    public class WalletInfoApi
    {
        public List<QueryWalletInfoModelGet> QueryUserWallet(QueryWalletInfoModelSend queryWalletInfoModelSend, out DataPagingModelGet dataPagingModel)
        {
            HeadModelGet<List<QueryWalletInfoModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<QueryWalletInfoModelGet>>>.PostMsg(
                ApiAddress.QueryUserWallet, queryWalletInfoModelSend);
            dataPagingModel = headModelGet.DataPagingResult;
            return headModelGet.Data ?? new List<QueryWalletInfoModelGet>();
        }
    }
}
