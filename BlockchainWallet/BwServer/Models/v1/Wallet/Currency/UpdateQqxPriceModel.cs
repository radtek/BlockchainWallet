using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Wallet.Currency
{
    public class UpdateQqxPriceModelGet
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 通证ID
        /// </summary>
        public int CurrencyId { get; set; }
        /// <summary>
        /// 通证价格
        /// </summary>
        public decimal Price { get; set; }
    }
    public class UpdateQqxPriceModelResult
    {

    }
}