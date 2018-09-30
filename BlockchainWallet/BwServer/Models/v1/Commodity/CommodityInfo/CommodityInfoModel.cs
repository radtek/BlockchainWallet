namespace BwServer.Models.v1.Commodity.CommodityInfo
{
    public class CommodityInfoModelGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PutawayTime { get; set; }
        public string SoldOutTime { get; set; }
        /// <summary>
        /// 商品状态：0正常 1下架
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 商品类型： -1全部 1 云矿机
        /// </summary>
        public string Type { get; set; }
    }

    public class CommodityInfoModelResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
        /// 商品类型： -1全部
        /// </summary>
        public string Type { get; set; }
    }
}