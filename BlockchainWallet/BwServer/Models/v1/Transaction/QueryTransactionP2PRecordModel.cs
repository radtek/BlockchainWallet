using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;

namespace BwServer.Models.v1.Transaction
{
    public class QueryTransactionP2PRecordModelGet : HeadModelGet
    {
        public int UserId { get; set; }
    }
    public class QueryTransactionP2PRecordModelResult
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string OrderTime { get; set; }
        /// <summary>
        /// 收款钱包地址
        /// </summary>
        public string PayeeWalletAddress { get; set; }
        public List<TransactionCurrencyModel> PayCurrencyList = new List<TransactionCurrencyModel>();
        /// <summary>
        /// 0未支付 1支付成功 2支付失败 3余额不足
        /// </summary>
        public string State { get; set; }
        public string Remark { get; set; }
    }
    /// <summary>
    /// 通证模型
    /// </summary>
    public class TransactionP2PDetailModelResult
    {
        public int OrderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CurrencyId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        public decimal ServiceCharge { get; set; }

    }
}