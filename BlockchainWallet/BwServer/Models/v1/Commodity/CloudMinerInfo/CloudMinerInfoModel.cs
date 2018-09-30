using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Commodity.CloudMinerInfo
{
    public class CloudMinerInfoModelGet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }

    public class CloudMinerInfoModelResult
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 购买会员等级限制
        /// </summary>
        public string VipRankName { get; set; }
        public int VipId { get; set; }
        public int Rank { get; set; }
        /// <summary>
        /// 总价格
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 产币总数量
        /// </summary>
        public decimal ProductionAmount { get; set; }
        public string PutawayTime { get; set; }
        public string SoldOutTime { get; set; }
        /// <summary>
        /// 展示图片
        /// </summary>
        public string DisplayImage { get; set; }
        /// <summary>
        /// 商品状态：-1全部 0正常 1下架
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 生产周期	单位1天
        /// </summary>
        public int ProductionCycle { get; set; }
        /// <summary>
        /// 限购数量
        /// </summary>
        public int PurchaseRestrictionCount { get; set; }
        /// <summary>
        /// 运行中的数量
        /// </summary>
        public int RunningCount { get; set; }

        public IList<CloudMinerManufactureModelResult> CloudMinerManufactureModelResults = new List<CloudMinerManufactureModelResult>();

        public BuyCommodityRuleFansModel BuyCommodityRuleFansModel = new BuyCommodityRuleFansModel();

        public IList<CloudMinerPriceDetailModelResult> CloudMinerPriceDetailModelResults = new List<CloudMinerPriceDetailModelResult>();
    }

    /// <summary>
    /// 云矿机产币
    /// </summary>
    public class CloudMinerManufactureModelResult
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        public int CommodityId { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCaption { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }

    public class BuyCommodityRuleFansModel
    {
        /// <summary>
        /// 购买会员等级限制
        /// </summary>
        public string VipRankName { get; set; }
        public int VipId { get; set; }
        public int Rank { get; set; }

        public IList<BuyCommodityRuleFansVipModelResult> BuyCommodityRuleFansVipModelResults = new List<BuyCommodityRuleFansVipModelResult>();

        //public IList<BuyCommodityRuleFansGenerationModelResult> BuyCommodityRuleFansGenerationModelResults = new List<BuyCommodityRuleFansGenerationModelResult>();
    }

    /// <summary>
    /// 购买规则之粉丝
    /// </summary>
    public class BuyCommodityRuleFansVipModelResult
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        public int CommodityId { get; set; }
        public int VipId { get; set; }
        public int Rank { get; set; }
        public string VipRankName { get; set; }
        public int Count { get; set; }
    }
    /// <summary>
    /// 购买规则之粉丝各代人数
    /// </summary>
    public class BuyCommodityRuleFansGenerationModelResult
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        public int CommodityId { get; set; }
        /// <summary>
        /// 代数
        /// </summary>
        public int GenerationId { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        public int GenerationCount { get; set; }
    }

    /// <summary>
    /// 购买支付规则
    /// </summary>
    public class CloudMinerPriceDetailModelResult
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        public int CommodityId { get; set; }
        /// <summary>
        /// 通证编号
        /// </summary>
        public int CurrencyId { get; set; }
        public string CurrencyCaption { get; set; }
        public string CurrencyCode { get; set; }
        public float MinAmount { get; set; }
        public float MaxAmount { get; set; }
    }


}