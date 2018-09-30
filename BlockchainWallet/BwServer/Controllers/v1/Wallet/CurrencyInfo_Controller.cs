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
using BwServer.Models.v1.Wallet;
using BwServer.Models.v1.Wallet.Currency;

namespace BwServer.Controllers.v1.Wallet
{
    public class CurrencyInfo_Controller : ApiController
    {
        private readonly CurrencyInfoDal _currencyInfoDal = new CurrencyInfoDal();
        /// <summary>
        /// 查询通证列表
        /// </summary>
        /// <param name="currencyInfoModelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryCurrency(CurrencyInfoModelGet currencyInfoModelGet)
        {
            DataTable dt = _currencyInfoDal.QueryCurrency();
            IList<CurrencyInfoModelResult> currencyInfoModelResults =
                ModelConvertHelper<CurrencyInfoModelResult>.ConvertToModel(dt);
            return Json(new ResultDataModel<IList<CurrencyInfoModelResult>> { Data = currencyInfoModelResults });
        }

        /// <summary>
        /// 查询通证价格修改记录
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult QueryCurrencyPriceRecord(CurrencyPriceRecordModelGet_ modelGet)
        {
            DataSet ds = _currencyInfoDal.QueryCurrencyPriceRecord(modelGet.DataPagingModel);
            IList<CurrencyPriceRecordModelResult_> currencyInfoModelResults =
                ModelConvertHelper<CurrencyPriceRecordModelResult_>.ConvertToModel(ds.Tables[0]);
            return Json(new ResultDataModel<IList<CurrencyPriceRecordModelResult_>> { Data = currencyInfoModelResults, DataPagingResult = new DataPagingModelResult { TotalCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]) } });
        }

        /// <summary>
        /// 修改当前价格
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult UpdateCurrencyPrice(CurrencyPriceRecordModelGet_ modelGet)
        {
            int rows = _currencyInfoDal.UpdateCurrencyPrice(modelGet.CurrencyId, modelGet.Price, modelGet.UpdateEmployeeId, "0");
            return Json(new ResultDataModel<IList<CurrencyPriceRecordModelResult_>> { Code = rows == 1 ? 0 : -1 });
        }

        /// <summary>
        /// 修改通证修改的日志
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult UpdateCurrencyPriceRecord(CurrencyPriceRecordModelGet_ modelGet)
        {
            int rows = _currencyInfoDal.UpdateCurrencyPriceRecord(modelGet.Id, modelGet.Price);
            return Json(new ResultDataModel<IList<CurrencyPriceRecordModelResult_>> { Code = rows == 1 ? 0 : -1 });
        }

    }
}