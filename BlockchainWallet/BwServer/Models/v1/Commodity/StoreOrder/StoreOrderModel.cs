using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;

namespace BwServer.Models.v1.Commodity.StoreOrder
{
    public class StoreOrderModelGet:HeadModelGet
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
        /// 购买人ID
        /// </summary>
        public int BuyUserId { get; set; }
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
        /// 下单时间
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        /// 收货人ID
        /// </summary>
        public int ConsignorUserId { get; set; }
        /// <summary>
        /// 类型 00：用户消费 01：赠送
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 支付明细
        /// </summary>
        public List<StoreOrderPayDetailModel> PayDetailModelGets = new List<StoreOrderPayDetailModel>();
    }
    public class StoreOrderModelResult
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
        /// <summary>
        /// 类型 00：用户消费 01：赠送
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 状态：0待支付 1已支付 2取消
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 支付明细
        /// </summary>
        public IList<StoreOrderPayDetailModel> PayDetailModelResults = new List<StoreOrderPayDetailModel>();
    }

    public class StoreOrderPayStateModelResult
    {
        public string State { get; set; }
        public int VipId { get; set; }
        public int Rank { get; set; }
        public string VipName { get; set; }
        public int RealRank { get; set; }
    }

    public class PayDetailModelGet
    {
        public int UserId { get; set; }
        public string PayPassword { get; set; }
        public string OrderNo { get; set; }

        public List<StoreOrderPayDetailModel> PayDetailModels = new List<StoreOrderPayDetailModel>();
    }





}