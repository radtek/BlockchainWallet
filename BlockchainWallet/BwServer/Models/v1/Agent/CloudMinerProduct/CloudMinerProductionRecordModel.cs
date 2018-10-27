using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;
using BwDal.Transaction;
using BwServer.Models.v1.Agent.CloudMinerProduct;
using BwServer.Models.v1.Transaction;

namespace BwServer.Models.v1.Commodity.UserCloudMiner
{
    public class CloudMinerProductionRecordModelGet : HeadModelGet
    {
        public int UserId { get; set; }
    }
    public class CloudMinerProductionRecordModelResult
    {
        public int Id { get; set; }
        public string CommodityName { get; set; }
        public string ProductionTime { get; set; }
        public List<PayCurrencyModel> ProductionDetails = new List<PayCurrencyModel>();
    }
    public class CloudMinerProductionDetailModelResult
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
    }
}