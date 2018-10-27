using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Transaction
{
    /// <summary>
    /// 通证模型
    /// </summary>
    public class TransactionCurrencyModel
    {
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
    /// <summary>
    /// 通证模型
    /// </summary>
    public class PayCurrencyModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int CurrencyId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

    }
}