using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal.User;
using BwDal.Wallet;
using BwServer.Models;
using BwServer.Models.v1.User.UserInfo;
using BwServer.Models.v1.Wallet.WalletInfo;

namespace BwServer.Controllers.v1.User
{
    public class CompanyAccountInfoController : ApiController
    {
        private readonly CompanyAccountInfoDal _companyAccountInfoDal = new CompanyAccountInfoDal();
        private readonly WalletInfoDal _walletInfoDal = new WalletInfoDal();
        public IHttpActionResult QueryCompanyAccountInfo(CompanyAccountInfoModelGet companyAccountInfoModelGet)
        {
            DataTable dtCompanyAccountInfo = _companyAccountInfoDal.QueryCompanyAccountInfo();
            IList<CompanyAccountInfoModelResult> list = ModelConvertHelper<CompanyAccountInfoModelResult>.ConvertToModel(dtCompanyAccountInfo);
            DataTable dtCompanyWalletInfo = _walletInfoDal.QueryCompanyWalletInfo();
            IList<WalletInfoModelResult> listCompanyWalletInfo = ModelConvertHelper<WalletInfoModelResult>.ConvertToModel(dtCompanyWalletInfo);
            foreach (var item in list)
            {
                item.WalletInfoModelResults = listCompanyWalletInfo.Where(n => n.UId == item.Id).ToList();
            }
            return Json(new ResultDataModel<IList<CompanyAccountInfoModelResult>> { Data = list });
        }

    }
}