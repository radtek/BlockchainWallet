using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;

namespace BwServer.Models.v1.Agent.CloudMinerDistribution
{
    public class UserCloudMinerDistributionModelGet_ : HeadModelGet
    {
    }
    public class UserCloudMinerDistributionModelResult_
    {
        public string DistributionTime { get; set; }
        public int UserId { get; set; }
        public string Nickname { get; set; }
        public string PhoneAreaId { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal QQX { get; set; }
        public decimal QQY { get; set; }
        public decimal QQL { get; set; }
    }
}