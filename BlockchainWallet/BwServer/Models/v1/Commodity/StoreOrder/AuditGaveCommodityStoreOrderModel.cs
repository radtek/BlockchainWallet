using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Commodity.StoreOrder
{
    public class AuditGaveCommodityStoreOrderModelGet
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 状态 0:通过 1：不通过
        /// </summary>
        public string State { get; set; }
    }
    public class AuditGaveCommodityStoreOrderModelResult
    {

    }
}