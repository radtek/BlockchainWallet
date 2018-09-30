using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.User.Fans
{
    public class FansModelGet
    {
        public int Id { get; set; }
    }
    public class FansModelResult
    {
        public int FansId { get; set; }
        public int UId { get; set; }
        public int PromotionId { get; set; }
        public string PromotionTime { get; set; }
        public string FansName { get; set; }
        public long FansCount { get; set; }
    }
}