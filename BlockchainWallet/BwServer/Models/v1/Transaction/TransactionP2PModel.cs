using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Transaction
{
    public class TransactionP2PModelGet
    {
        public int PayUserId { get; set; }
        public string PayeeWalletAddress { get; set; }
        public string PayPassword { get; set; }
        public List<TransactionCurrencyModel> PayCurrencyList = new List<TransactionCurrencyModel>();
        public string Remark { get; set; }
    }
    public class TransactionP2PModelResult
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public string OrderTime { get; set; }
    }
}