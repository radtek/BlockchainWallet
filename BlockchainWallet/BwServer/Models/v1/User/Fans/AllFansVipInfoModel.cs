using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.User.Fans
{
    public class AllFansVipInfoModelGet
    {
        public int FansId { get; set; }
    }
    /// <summary>
    /// 所有粉丝和粉丝等级信息
    /// </summary>
    public class AllFansVipInfoModelResult
    {
        public uint Id { get; set; }
        public int ParentId { get; set; }
        public int VipId { get; set; }
        public int Rank { get; set; }
        public string VipCaption { get; set; }
    }




}