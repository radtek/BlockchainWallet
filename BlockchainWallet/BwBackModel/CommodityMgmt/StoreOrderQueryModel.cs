using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.CommodityMgmt
{
    public class StoreOrderQueryModelSend : HeadDataBaseModelSend
    {
        public StoreOrderQueryModelSend()
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
        /// 购买人ID
        /// </summary>
        public int BuyUserId { get; set; }
        /// <summary>
        /// 收货人ID
        /// </summary>
        public int ConsignorUserId { get; set; }
    }

    public class StoreOrderQueryModelGet
    {
        public StoreOrderQueryModelGet()
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
        public decimal Amount
        {
            get { return QQX + QQY + QQL; }
        }
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

        public string TypeCaption
        {
            get
            {
                switch (Type)
                {
                    case "00":
                        return "消费";
                    default:
                        return "赠送";
                }
            }
        }
        /// <summary>
        /// 状态：0待支付 1已支付 2超时 3余额不足 4支付中 5支付失败
        /// </summary>
        public string State { get; set; }
        public string StateCaption
        {
            get
            {
                switch (State)
                {
                    case "0":
                        return "待支付";
                    case "1":
                        return "已支付";
                    case "2":
                        return "超时";
                    case "3":
                        return "余额不足";
                    case "4":
                        return "支付中";
                    case "5":
                        return "支付失败";
                    case "6":
                        return "审核失败";
                    default:
                        return "状态异常";
                }
            }
        }
    }
}
