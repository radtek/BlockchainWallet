using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Transaction
{
    public class TransactionP2PModelGet
    {
        public int PayUserId { get; set; }
        public int PayeeUserId { get; set; }
        public string PayPassword { get; set; }
        public List<CurrencyModel> PayCurrencyList = new List<CurrencyModel>();
        public string Remark { get; set; }
    }
    public class TransactionP2PModelResult
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public string OrderTime { get; set; }
    }
}