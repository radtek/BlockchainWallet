using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Transaction
{
    public class TransactionB2CCheckModelGet
    {
        /// <summary>
        /// 外部订单号
        /// </summary>
        public string ExternalOrderNo { get; set; }
        /// <summary>
        /// 内部订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
    }
    public class TransactionB2CCheckModelResult
    {

    }
}