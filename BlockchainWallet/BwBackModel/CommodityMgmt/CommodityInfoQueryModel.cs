namespace BwBackModel.CommodityMgmt
{
    public class CommodityInfoQueryModelSend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PutawayTime { get; set; }
        public string SoldOutTime { get; set; }
        /// <summary>
        /// 商品状态：-1全部 0正常 1下架
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 商品类型：-1全部 
        /// </summary>
        public string Type { get; set; }
    }
    public class CommodityInfoQueryModelGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PutawayTime { get; set; }
        public string SoldOutTime { get; set; }
        /// <summary>
        /// 商品状态：-1全部 0正常 1下架
        /// </summary>
        public string State { get; set; }

        public string StateCaption
        {
            get { return State == "0" ? "正常" : "下架"; }
        }

        /// <summary>
        /// 商品类型：-1全部 
        /// </summary>
        public string Type { get; set; }
        public string TypeCapiton
        {
            get { return Type == "0" ? "云矿机" : "其他"; }
        }
    }
}
