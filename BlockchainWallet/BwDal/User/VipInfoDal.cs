using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.User
{
    public class VipInfoDal
    {
        public DataTable QueryVipInfo()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT vri.ID,vri.`Name`,vri.Rank FROM vip_rank_info vri WHERE 1=1 ");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }
        /// <summary>
        /// 查询会员信息详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable QueryVipInfo(int id)
        {
            string strSql = string.Format("SELECT vri.ID,vri.`Name`,vri.Rank FROM vip_rank_info vri WHERE vri.ID={0} ", id);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 会员升级之粉丝
        /// </summary>
        /// <returns></returns>
        public DataTable QueryVipUrFans()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT vur.Id, vur.VipID,vur.FansVipId,vur.FansCount,vri.`Name` VipName FROM vip_ur_fans vur LEFT JOIN vip_rank_info AS vri ON vur.FansVipID=vri.ID WHERE 1=1 ");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }

        /// <summary>
        /// 查询会员升级规则之云矿机
        /// </summary>
        /// <returns></returns>
        public DataTable QueryVipUrCloudminer()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT vuc.Id, vuc.VipID,vuc.CloudMinerCount,vuc.CommodityId,ct.`Name` CommodityName FROM vip_ur_cloudminer vuc LEFT JOIN commodity AS ct ON vuc.CommodityId=ct.ID ");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }

        /// <summary>
        /// 查询会员升级规则之云矿机 升级用
        /// </summary>
        /// <returns></returns>
        public DataTable QueryVipUrCloudminerUpgrade(int commodityId)
        {
            string strSql =
                string.Format(
                    "SELECT i.Id,i.`Name` VipName,i.Rank,c.CommodityId,c.CloudMinerCount FROM vip_rank_info i LEFT JOIN vip_ur_cloudminer as c ON i.Id=c.VipId WHERE c.CommodityId={0} ", commodityId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 查询会员升级规则之云矿机  分销用
        /// </summary>
        /// <returns></returns>
        public DataTable QueryVipUrCloudminerDistribution()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT i.Id,i.`Name` VipName,i.Rank,c.CommodityId,c.CloudMinerCount FROM vip_rank_info i LEFT JOIN vip_ur_cloudminer as c ON i.Id=c.VipId ORDER BY i.Rank DESC ");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }


        public int InsertVipUrFans(uint vipId, int fansVipId, int fansCount)
        {
            StringBuilder stringBuilder = new StringBuilder(string.Format("INSERT INTO vip_ur_fans VALUES(null,{0},{1},{2})", vipId, fansVipId, fansCount));
            return MySqlHelper.Single.ExecuteNonQuery(stringBuilder.ToString());
        }

        public int UpdateVipUrFans(uint id, uint vipId, int fansVipId, int fansCount)
        {
            StringBuilder stringBuilder = new StringBuilder(string.Format("UPDATE vip_ur_fans SET VipId={0},FansVipId={1},FansCount={2} WHERE Id={3}", vipId, fansVipId, fansCount, id));
            return MySqlHelper.Single.ExecuteNonQuery(stringBuilder.ToString());
        }

        public int DeleteVipUrFans(uint id)
        {
            StringBuilder stringBuilder = new StringBuilder(string.Format("DELETE FROM vip_ur_fans  WHERE Id={0}", id));
            return MySqlHelper.Single.ExecuteNonQuery(stringBuilder.ToString());
        }

        public int InsertVipUrCloudminer(uint vipId, int commodityId, int cloudMinerCount)
        {
            StringBuilder stringBuilder = new StringBuilder(string.Format("INSERT INTO vip_ur_cloudminer VALUES(null,{0},{1},{2})", vipId, commodityId, cloudMinerCount));
            return MySqlHelper.Single.ExecuteNonQuery(stringBuilder.ToString());
        }

        public int UpdateVipUrCloudminer(uint id, uint vipId, int commodityId, int cloudMinerCount)
        {
            StringBuilder stringBuilder = new StringBuilder(string.Format("UPDATE vip_ur_cloudminer SET VipId={0},CommodityId={1},CloudMinerCount={2} WHERE Id={3}", vipId, commodityId, cloudMinerCount, id));
            return MySqlHelper.Single.ExecuteNonQuery(stringBuilder.ToString());
        }

        public int DeleteVipUrCloudminer(uint id)
        {
            StringBuilder stringBuilder = new StringBuilder(string.Format("DELETE FROM vip_ur_cloudminer  WHERE Id={0}", id));
            return MySqlHelper.Single.ExecuteNonQuery(stringBuilder.ToString());
        }
    }
}
