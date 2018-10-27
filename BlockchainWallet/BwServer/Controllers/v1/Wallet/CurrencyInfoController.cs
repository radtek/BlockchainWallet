using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwCommon.Log;
using BwDal;
using BwDal.User;
using BwDal.Wallet;
using BwServer.Models;
using BwServer.Models.v1.Commodity.StoreOrder;
using BwServer.Models.v1.Wallet.Currency;

namespace BwServer.Controllers.v1.Wallet
{
    public class CurrencyInfoController : ApiController
    {
        private readonly CurrencyInfoDal _currencyInfoDal = new CurrencyInfoDal();
        private readonly UserInfoDal _userInfoDal = new UserInfoDal();

        /// <summary>
        /// 修改当前价格
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult UpdateQqxPrice(UpdateQqxPriceModelGet modelGet)
        {
            if (!_userInfoDal.CheckIsShareholder(modelGet.UserId))
            {
                LogHelper.error("非股东用户操作数据,操作人：" + modelGet.UserId);
                return Json(new ResultDataModel<IList<UpdateQqxPriceModelResult>> { Code = -1, Messages = "非股东用户操作数据,该记录已被记录" });
            }
            int rows = _currencyInfoDal.UpdateCurrencyPrice(modelGet.CurrencyId, modelGet.Price, modelGet.UserId, "1");
            return Json(new ResultDataModel<IList<UpdateQqxPriceModelResult>> { Code = rows == 1 ? 0 : -1, Messages = rows == 1 ? "" : "修改失败" });
        }

        /// <summary>
        /// 查询通证价格修改记录
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryCurrencyPriceRecord(CurrencyPriceRecordModelGet_ modelGet)
        {
            if (modelGet.DataPagingModel == null)
            {
                return Json(new ResultDataModel<IList<StoreOrderModelResult>> { Code = 4011, Messages = "分页数据有误" });
            }
            DataSet dsStoreOrder = _currencyInfoDal.QueryCurrencyPriceRecord(modelGet.DataPagingModel);
            IList<CurrencyPriceRecordModelResult_> storeOrderModelResults = ModelConvertHelper<CurrencyPriceRecordModelResult_>.ConvertToModel(dsStoreOrder.Tables[0]);
            return Json(new ResultDataModel<IList<CurrencyPriceRecordModelResult_>> { Data = storeOrderModelResults, DataPagingResult = new DataPagingModelResult() { TotalCount = Convert.ToInt32(dsStoreOrder.Tables[1].Rows[0][0]) } });
        }

    }
}