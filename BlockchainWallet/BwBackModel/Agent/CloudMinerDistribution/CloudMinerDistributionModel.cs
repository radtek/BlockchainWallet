using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.Agent.CloudMinerDistribution
{
    public class CloudMinerDistributionModelSend : HeadDataBaseModelSend
    {
        public int UserId { get; set; }
        public string DistributionDate { get; set; }
    }
    public class CloudMinerDistributionModelGet
    {
        public int Id { get; set; }
        public string DistributionTime { get; set; }
        /// <summary>
        /// 矿机编号
        /// </summary>
        public int UcmId { get; set; }
        /// <summary>
        /// 矿机名称
        /// </summary>
        public string CommodityName { get; set; }
        public string BuyTime { get; set; }
        public int FansUserId { get; set; }
        public string FansNickname { get; set; }
        public string FansPhoneAreaId { get; set; }
        public string FansPhone { get; set; }
        public string FansName { get; set; }
        public decimal Amount { get; set; }
        public decimal QQX { get; set; }
        public decimal QQY { get; set; }
        public decimal QQL { get; set; }
    }
}
