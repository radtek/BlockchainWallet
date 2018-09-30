using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal.Wallet;
using BwServer.Models;
using BwServer.Models.v1.Wallet.WalletInfo;

namespace BwServer.Controllers.v1.Wallet
{
    public class WalletInfoController : ApiController
    {
        private readonly WalletInfoDal _walletInfoDal = new WalletInfoDal();
        public IHttpActionResult QueryWalletInfo(WalletInfoModelGet modelGet)
        {
            DataTable dt = _walletInfoDal.QueryWalletInfo(modelGet.UserId);
            IList<WalletInfoModelResult> currencyInfoModelResults = ModelConvertHelper<WalletInfoModelResult>.ConvertToModel(dt);
            return Json(new ResultDataModel<IList<WalletInfoModelResult>> { Data = currencyInfoModelResults });
        }
    }
}