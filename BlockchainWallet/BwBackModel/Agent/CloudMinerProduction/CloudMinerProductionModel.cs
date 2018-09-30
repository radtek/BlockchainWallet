namespace BwBackModel.Agent.CloudMinerProduction
{
    public class CloudMinerProductionModelSend : HeadDataBaseModelSend
    {
        public int UserId { get; set; }
        public string ProductionDate { get; set; }
    }

    public class CloudMinerProductionModelGet
    {
        public int Id { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 产币时间
        /// </summary>
        public string ProductionTime { get; set; }
        /// <summary>
        /// 购买时间
        /// </summary>
        public string BuyTime { get; set; }
        /// <summary>
        /// 产币次数
        /// </summary>
        public int ProductionCount { get; set; }
        /// <summary>
        /// 产币量
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 现货通证数量
        /// </summary>
        public decimal QQX { get; set; }
        /// <summary>
        /// 易货通证数量
        /// </summary>
        public decimal QQY { get; set; }
        /// <summary>
        /// 理财通证数量
        /// </summary>
        public decimal QQL { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string UserNickname { get; set; }
        /// <summary>
        /// 手机区号
        /// </summary>
        public string UserPhoneAreaId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string UserPhone { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 状态：0产币中 1成功 2失败
        /// </summary>
        public string State { get; set; }

        public string StateCaption
        {
            get
            {
                switch (State)
                {
                    case "0":
                        return "产币中";
                    case "1":
                        return "成功";
                    default:
                        return "失败";
                }
            }
        }
    }
}
