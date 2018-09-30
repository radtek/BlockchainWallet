using System.Collections.Generic;

namespace BwServer.Models.v1.User.VipInfo
{
    public class VipSettingModelGet
    {

    }

    public class VipSettingModelResult
    {
        public uint Id { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }

        public List<VipUrCloudminer> VipUrCloudmineres = new List<VipUrCloudminer>();
        public List<VipUrFans> VipUrFanses = new List<VipUrFans>();
    }

    public class VipUrCloudminer
    {
        public uint Id { get; set; }
        public int CloudMinerCount { get; set; }
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
    }

    public class VipUrFans
    {
        public uint Id { get; set; }
        public int FansCount { get; set; }
        public int FansVipId { get; set; }
        public string VipName { get; set; }
    }

    public class VipUrFansGet
    {
        public uint Id { get; set; }
        public uint VipId { get; set; }
        public int FansCount { get; set; }
        public int FansVipId { get; set; }
    }

    public class VipUrCloudminerGet
    {
        public uint Id { get; set; }
        public uint VipId { get; set; }
        public int CloudMinerCount { get; set; }
        public int CommodityId { get; set; }

    }

}