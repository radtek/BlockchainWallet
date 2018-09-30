using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;

namespace BwServer.Models.v1.Agent.CloudMinerDistribution
{

    public class CloudMinerDistributionModelGet_ : HeadModelGet
    {
        public int UserId { get; set; }
        public string DistributionDate { get; set; }
    }
    public class CloudMinerDistributionModelResult_
    {
        public int Id { get; set; }
        public string DistributionTime { get; set; }
        public string CommodityName { get; set; }
        public int UcmId { get; set; }

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