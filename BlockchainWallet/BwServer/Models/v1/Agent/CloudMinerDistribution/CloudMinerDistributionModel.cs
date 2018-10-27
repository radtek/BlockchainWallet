using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;
using BwServer.Models.v1.Transaction;

namespace BwServer.Models.v1.Agent.CloudMinerDistribution
{
    public class CloudMinerDistributionRecordModelGet : HeadModelGet
    {
        public int UserId { get; set; }
    }
    public class CloudMinerDistributionRecordModelResult
    {
        public int Id { get; set; }
        public string UserNickname { get; set; }
        public string CommodityName { get; set; }
        public string DistributionTime { get; set; }
        public List<PayCurrencyModel> DistributionDetails = new List<PayCurrencyModel>();
    }

    public class CloudMinerDistributionDetailModelResult
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
    }
}