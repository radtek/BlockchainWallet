using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using BwDal.User;
using BwServer.Models;
using BwServer.Models.v1.User.VipInfo;

namespace BwServer.Controllers.v1.User
{
    public class VipInfoController : ApiController
    {
        private readonly VipInfoDal _vipInfoDal = new VipInfoDal();
        public IHttpActionResult QueryVipInfo(VipSettingModelGet vipSettingModelGet)
        {
            DataTable dtVipInfo = _vipInfoDal.QueryVipInfo();
            DataTable dtVipUrCloudMiner = _vipInfoDal.QueryVipUrCloudminer();
            DataTable dtVipUrFans = _vipInfoDal.QueryVipUrFans();
            IList<VipSettingModelResult> list = new List<VipSettingModelResult>();
            foreach (DataRow dr in dtVipInfo.Rows)
            {
                VipSettingModelResult vipSettingModelResult = new VipSettingModelResult();
                vipSettingModelResult.Id = Convert.ToUInt32(dr["Id"]);
                vipSettingModelResult.Name = dr["Name"].ToString();
                vipSettingModelResult.Rank = Convert.ToInt32(dr["Rank"]);
                foreach (DataRow dr1 in dtVipUrCloudMiner.Rows)
                {
                    if (vipSettingModelResult.Id != Convert.ToUInt32(dr1["VipID"])) continue;
                    VipUrCloudminer vipUrCloudMiner = new VipUrCloudminer();
                    vipUrCloudMiner.Id = Convert.ToUInt32(dr1["Id"]);
                    vipUrCloudMiner.CloudMinerCount = Convert.ToInt32(dr1["CloudMinerCount"]);
                    vipUrCloudMiner.CommodityId = Convert.ToInt32(dr1["CommodityId"]);
                    vipUrCloudMiner.CommodityName = dr1["CommodityName"].ToString();
                    vipSettingModelResult.VipUrCloudmineres.Add(vipUrCloudMiner);
                }
                foreach (DataRow dr2 in dtVipUrFans.Rows)
                {
                    if (vipSettingModelResult.Id != Convert.ToUInt32(dr2["VipID"])) continue;
                    VipUrFans vipUrFans = new VipUrFans();
                    vipUrFans.Id = Convert.ToUInt32(dr2["Id"]);
                    vipUrFans.FansCount = Convert.ToInt32(dr2["FansCount"]);
                    vipUrFans.FansVipId = Convert.ToInt32(dr2["FansVipId"]);
                    vipUrFans.VipName = dr2["VipName"].ToString();
                    vipSettingModelResult.VipUrFanses.Add(vipUrFans);
                }
                list.Add(vipSettingModelResult);
            }
            return Json(new ResultDataModel<IList<VipSettingModelResult>> { Data = list });
        }

        public IHttpActionResult InsertVipUrFans(VipUrFansGet vipUrFansGet)
        {
            int rows = _vipInfoDal.InsertVipUrFans(vipUrFansGet.VipId, vipUrFansGet.FansVipId, vipUrFansGet.FansCount);
            return Json(new ResultDataModel<VipUrFans> { Code = rows == 1 ? 0 : -1 });
        }
        public IHttpActionResult UpdateVipUrFans(VipUrFansGet vipUrFansGet)
        {
            int rows = _vipInfoDal.UpdateVipUrFans(vipUrFansGet.Id, vipUrFansGet.VipId, vipUrFansGet.FansVipId, vipUrFansGet.FansCount);
            return Json(new ResultDataModel<VipUrFans> { Code = rows == 1 ? 0 : -1 });
        }
        public IHttpActionResult RemoveVipUrFans(VipUrFansGet vipUrFansGet)
        {
            int rows = _vipInfoDal.DeleteVipUrFans(vipUrFansGet.Id);
            return Json(new ResultDataModel<VipUrFans> { Code = rows > 0 ? 0 : -1 });
        }
        public IHttpActionResult InsertVipUrCloudMiner(VipUrCloudminerGet vipUrCloudMinerGet)
        {
            int rows = _vipInfoDal.InsertVipUrCloudminer(vipUrCloudMinerGet.VipId, vipUrCloudMinerGet.CommodityId, vipUrCloudMinerGet.CloudMinerCount);
            return Json(new ResultDataModel<VipSettingModelResult> { Code = rows == 1 ? 0 : -1 });
        }
        public IHttpActionResult UpdateVipUrCloudMiner(VipUrCloudminerGet vipUrCloudMinerGet)
        {
            int rows = _vipInfoDal.UpdateVipUrCloudminer(vipUrCloudMinerGet.Id, vipUrCloudMinerGet.VipId, vipUrCloudMinerGet.CommodityId, vipUrCloudMinerGet.CloudMinerCount);
            return Json(new ResultDataModel<VipSettingModelResult> { Code = rows == 1 ? 0 : -1 });
        }
        public IHttpActionResult RemoveVipUrCloudMiner(VipUrCloudminerGet vipUrCloudMinerGet)
        {
            int rows = _vipInfoDal.DeleteVipUrCloudminer(vipUrCloudMinerGet.Id);
            return Json(new ResultDataModel<VipSettingModelResult> { Code = rows > 0 ? 0 : -1 });
        }
    }
}