using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;

namespace BwServer.Models.v1.Commodity.StoreOrder
{
    /// <summary>
    /// 获取支付订单
    /// </summary>
    public class GaveCommodityStoreOrderModelGet : HeadModelGet
    {
        public int UserId { get; set; }
        public int Id { get; set; }
    }
    /// <summary>
    /// 返回订单信息
    /// </summary>
    public class GaveCommodityStoreOrderModelResult
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string DisplayImage { get; set; }
        public int ConsignorUserId { get; set; }
        public string ConsignorPhoneAreaId { get; set; }
        public string ConsignorPhone { get; set; }
        public string ConsignorName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 折后数量
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 订单时间
        /// </summary>
        public string OrderTime { get; set; }
        public string BuyTime { get; set; }
        /// <summary>
        /// 类型 00：用户消费 01：赠送
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 状态：0待支付 1已支付 2超时 3余额不足 4支付中 5支付失败 6审核失败
        /// </summary>
        public string State { get; set; }
    }
}