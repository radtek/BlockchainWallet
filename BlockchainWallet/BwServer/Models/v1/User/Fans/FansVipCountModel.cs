using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.User.Fans
{
    public class FansVipCountModelGet
    {
        public int UserId { set; get; }
    }

    public class FansVipCountModelResult
    {
        public long FansCount { get; set; }
        public int VipId { get; set; }
        public int Rank { get; set; }
        public string VipCaption { get; set; }
    }

    public class AllFansVipCountModelResult
    {
        public long FansCount { get; set; }
        public int VipId { get; set; }
        public int Rank { get; set; }
        public string VipCaption { get; set; }
    }
}