using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;

namespace BwServer.Models.v1.Commodity.UserCloudMiner
{
    public class UserCloudMinerModelGet_ : HeadModelGet
    {
    }
    public class UserCloudMinerModelResult_
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 拥有者ID
        /// </summary>
        public int UserId { get; set; }
        public string PhoneAreaId { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 产币周期
        /// </summary>
        public int ProductionCycle { get; set; }
        /// <summary>
        /// 产币数量
        /// </summary>
        public decimal ProductionAmount { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 购买时间
        /// </summary>
        public string BuyTime { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public string ExpireTime
        {
            get
            {
                DateTime dt = Convert.ToDateTime(BuyTime).AddDays(ProductionCycle);
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// 剩余周期
        /// </summary>
        public int ResidueCycle
        {
            get
            {
                int a = (DateTime.Now.Date - Convert.ToDateTime(BuyTime).Date).Days;
                return ProductionCycle - a;
            }
        }
        /// <summary>
        /// 已产币量
        /// </summary>
        public decimal ProductionedAmount
        {
            get
            {
                int a = (DateTime.Now.Date - Convert.ToDateTime(BuyTime).Date).Days;
                return Math.Round(a * (ProductionAmount / ProductionCycle), 8);
            }
        }
        /// <summary>
        /// 已产币次数
        /// </summary>
        public int ProductionCount { get; set; }

        /// <summary>
        /// 状态：0正在运行 1已停止
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 类型：00消费  01赠送
        /// </summary>
        public string Type { get; set; }
    }
}