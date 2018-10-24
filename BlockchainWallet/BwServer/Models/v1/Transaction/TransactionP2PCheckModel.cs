using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Transaction
{
    public class TransactionP2PCheckModelGet
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
    }
    public class TransactionP2PCheckModelResult
    {
        /// <summary>
        /// 0：正在交易 1：交易成功 2：交易失败 3:余额不足
        /// </summary>
        public string State { get; set; }
    }
}