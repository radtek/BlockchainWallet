using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwServer.Models.v1.User.Fans;

namespace BwServer.Models.v1.Commodity.CommodityInfo
{
    public class BuyQualificationInfoModelGet
    {
        public int UserId { get; set; }
    }

    /// <summary>
    ///  购买资格信息
    /// </summary>
    public class BuyQualificationInfoModelResult
    {
        /// <summary>
        /// 各代推荐人数
        /// </summary>
        //public IList<FansGenerationCountModelResult> FansGenerationCountModelResults = new List<FansGenerationCountModelResult>();
        /// <summary>
        /// 直推人数中每个等级的人数
        /// </summary>
        public IList<FansVipCountModelResult> FansVipCountModelResults = new List<FansVipCountModelResult>();
    }
}