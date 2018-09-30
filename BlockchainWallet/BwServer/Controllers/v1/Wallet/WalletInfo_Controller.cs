using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal;
using BwDal.Wallet;
using BwServer.Models;
using BwServer.Models.v1.Wallet.Currency;
using BwServer.Models.v1.Wallet.WalletInfo;

namespace BwServer.Controllers.v1.Wallet
{
    public class WalletInfo_Controller : ApiController
    {
        private readonly WalletInfoDal_ _walletInfoDal = new WalletInfoDal_();
        /// <summary>
        /// 查询用户钱包
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryUserWallet(QueryWalletInfoModelGet_ modelGet)
        {
            DataSet dataSet = _walletInfoDal.QueryUserWallet(modelGet.DataPagingModel);
            IList<QueryWalletInfoModelResult_> cloudMinerProductionModelResult = ModelConvertHelper<QueryWalletInfoModelResult_>.ConvertToModel(dataSet.Tables[0]);
            return Json(new ResultDataModel<IList<QueryWalletInfoModelResult_>> { Data = cloudMinerProductionModelResult, DataPagingResult = new DataPagingModelResult { TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]) } });
        }
    }
}