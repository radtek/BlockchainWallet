using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.CommodityMgmt
{
    public class UserCloudMinerModelSend : HeadDataBaseModelSend
    {
    }
    public class UserCloudMinerModelGet
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
        public string ExpireTime { get; set; }
        /// <summary>
        /// 剩余周期
        /// </summary>
        public int ResidueCycle { get; set; }
        /// <summary>
        /// 已产币量
        /// </summary>
        public decimal ProductionedAmount { get; set; }
        /// <summary>
        /// 已产币次数
        /// </summary>
        public int ProductionCount { get; set; }

        /// <summary>
        /// 状态：0正在运行 1已停止
        /// </summary>
        public string State { get; set; }

        public string StateCaption
        {
            get
            {
                switch (State)
                {
                    case "0":
                        return "正常";
                    case "1":
                        return "停止";
                }
                return "异常";
            }
        }

        /// <summary>
        /// 类型：00消费  01赠送
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
                    case "01":
                        return "赠送";
                }
                return "异常";
            }
        }
    }
}
