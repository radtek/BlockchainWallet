using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Transaction
{
    /// <summary>
    /// 通证模型
    /// </summary>
    public class CurrencyModel
    {
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
    }
}