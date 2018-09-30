using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;

namespace BwServer.Models.v1.Wallet.Currency
{
    public class CurrencyPriceRecordModelGet_ : HeadModelGet
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public decimal Price { get; set; }
        public int UpdateEmployeeId { get; set; }
    }
    public class CurrencyPriceRecordModelResult_
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCaption { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Price { get; set; }
        public string UpdateTime { get; set; }
        public int UpdateEmployeeId { get; set; }
        public string UpdateEmployeeName { get; set; }
        /// <summary>
        /// 类型0 员工 1 用户
        /// </summary>
        public string Type { get; set; }
    }
}