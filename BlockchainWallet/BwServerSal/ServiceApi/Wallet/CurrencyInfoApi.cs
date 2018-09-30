using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel;
using BwBackModel.Agent.CloudMinerProduction;
using BwBackModel.WalletMgmt;

namespace BwServerSal.ServiceApi.Wallet
{
    public class CurrencyInfoApi
    {
        public List<CurrencyInfoModelGet> QueryCurrency(CurrencyInfoModelSend currencyInfoModelSend)
        {
            HeadModelGet<List<CurrencyInfoModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<CurrencyInfoModelGet>>>.PostMsg(
                ApiAddress.QueryCurrency, currencyInfoModelSend);
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
        public List<CurrencyPriceRecordModelGet> QueryCurrencyPriceRecord(CurrencyPriceRecordModelSend currencyPriceRecordModel, out DataPagingModelGet dataPagingModelGet)
        {
            HeadModelGet<List<CurrencyPriceRecordModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<CurrencyPriceRecordModelGet>>>.PostMsg(
                ApiAddress.QueryCurrencyPriceRecord, currencyPriceRecordModel);
            dataPagingModelGet = headModelGet.DataPagingResult ?? new DataPagingModelGet();
            return headModelGet.Code == 0 ? headModelGet.Data : null;
        }
        public bool UpdateCurrencyPriceRecord(CurrencyPriceRecordModelSend currencyPriceRecordModelSend)
        {
            HeadModelGet<List<CurrencyPriceRecordModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<CurrencyPriceRecordModelGet>>>.PostMsg(
                ApiAddress.UpdateCurrencyPriceRecord, currencyPriceRecordModelSend);
            return headModelGet.Code == 0;
        }
        public bool AddCurrencyPriceRecord(CurrencyPriceRecordModelSend currencyPriceRecordModelSend)
        {
            HeadModelGet<List<CurrencyPriceRecordModelGet>> headModelGet = BwHttpApiAccess<HeadModelGet<List<CurrencyPriceRecordModelGet>>>.PostMsg(
                ApiAddress.UpdateCurrencyPrice, currencyPriceRecordModelSend);
            return headModelGet.Code == 0;
        }
    }
}
