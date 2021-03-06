﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Commodity.StoreOrder
{
    public class CreateGaveCommodityStoreOrderModelGet
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 收货人ID
        /// </summary>
        public int ConsignorUserId { get; set; }

        /// <summary>
        /// 类型 00：用户消费 01：赠送
        /// </summary>
        public string Type { get; set; }
    }

    public class CreateGaveCommodityStoreOrderModelResult
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
    }
}