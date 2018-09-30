using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using BwDal;

namespace BwServer.Models.v1.Commodity.StoreOrder
{
    public class StoreOrderModelGet_ : HeadModelGet
    {
        public StoreOrderModelGet_()
        {

        }
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
        /// 数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 折后数量
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 购买人ID
        /// </summary>
        public int BuyUserId { get; set; }
        /// <summary>
        /// 收货人ID
        /// </summary>
        public int ConsignorUserId { get; set; }

        /// <summary>
        /// 类型 00：用户消费 01：赠送
        /// </summary>
        public string Type { get; set; }

    }
    public class StoreOrderModelResult_ : HeadModelResult
    {
        public StoreOrderModelResult_()
        {

        }
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
        public string CommodityName { get; set; }
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
        public decimal QQX { get; set; }
        public decimal QQY { get; set; }
        public decimal QQL { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        /// 购买时间
        /// </summary>
        public string BuyTime { get; set; }
        /// <summary>
        /// 购买人ID
        /// </summary>
        public int BuyUserId { get; set; }
        /// <summary>
        /// 购买人昵称
        /// </summary>
        public string BuyUserNickname { get; set; }
        /// <summary>
        /// 购买人手机区号
        /// </summary>
        public string BuyUserPhoneAreaId { get; set; }
        /// <summary>
        /// 购买人手机号
        /// </summary>
        public string BuyUserPhone { get; set; }
        public string BuyUserName { get; set; }
        /// <summary>
        /// 收货人ID
        /// </summary>
        public int ConsignorUserId { get; set; }
        /// <summary>
        /// 收货人昵称
        /// </summary>
        public string ConsignorUserNickname { get; set; }
        /// <summary>
        /// 收货人手机号
        /// </summary>
        public string ConsignorUserPhone { get; set; }
        /// <summary>
        /// 收货人手机区号
        /// </summary>
        public string ConsignorUserPhoneAreaId { get; set; }
        public string ConsignorUserName { get; set; }
        /// <summary>
        /// 类型 00：用户消费 01：赠送
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 状态：0待支付 1已支付 2超时 3余额不足 4支付中 5支付失败
        /// </summary>
        public string State { get; set; }
    }
}