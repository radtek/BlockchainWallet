using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Commodity.UserCloudMiner
{
    public class UserCloudMinerModelGet
    {
        public int UserId { get; set; }
    }
    public class UserCloudMinerInfoModelGet
    {
        public int Id { get; set; }
    }
    public class UserCloudMinerModelResult
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
        /// 交易号
        /// </summary>
        public string TransactionNo { get; set; }

        /// <summary>
        /// 拥有者ID
        /// </summary>
        public int UserId { get; set; }
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
        /// 产币数量
        /// </summary>
        public string DisplayImage { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 购买时间
        /// </summary>
        public string BuyTime { get; set; }
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
        public decimal ProductionedCount
        {
            get
            {
                int a = (DateTime.Now.Date - Convert.ToDateTime(BuyTime).Date).Days;
                return Math.Round(a * (ProductionAmount / ProductionCycle), 8);
            }
        }
        /// <summary>
        /// 状态：0正在运行 1已停止
        /// </summary>
        public string State { get; set; }
    }

    public class UserCloudMinerOverviewModelResult
    {
        public decimal ProductionAmount { get; set; }
        public decimal NetProductionAmount { get; set; }
        public long CloudMinerCount { get; set; }
    }
}