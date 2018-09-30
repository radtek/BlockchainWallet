using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.Commodity
{
    public class CloudMinerDal
    {
        /// <summary>
        /// 查询云矿机列表
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCloudMiner()
        {
            string strSql = string.Format("SELECT c.Id,c.`Name`,c.Amount,c.VipId,v.Rank,v.`Name` VipRankName,cms.ProductionCycle,cms.ProductionAmount,date_format(c.PutawayTime, '%Y-%m-%d %H:%i:%s') PutawayTime,date_format(c.SoldOutTime, '%Y-%m-%d %H:%i:%s') SoldOutTime,c.State,c.DisplayImage FROM commodity c LEFT JOIN cloud_miner_specification as cms on c.Id=cms.CommodityId LEFT JOIN vip_rank_info as v on c.VipId =v.Id WHERE c.Type='0' AND C.STATE='0'");
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 查询云矿机详细信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCloudMinerInfo(int id)
        {
            string strSql = string.Format("SELECT c.Id,c.`Name`,c.Amount,c.VipId,v.Rank,v.`Name` VipRankName,cms.ProductionCycle,cms.ProductionAmount,date_format(c.PutawayTime, '%Y-%m-%d %H:%i:%s') PutawayTime,date_format(c.SoldOutTime, '%Y-%m-%d %H:%i:%s') SoldOutTime,c.State,c.DisplayImage,c.PurchaseRestrictionCount FROM commodity c LEFT JOIN cloud_miner_specification as cms on c.Id=cms.CommodityId LEFT JOIN vip_rank_info as v on c.VipId =v.Id WHERE c.Type='0' AND C.STATE='0' AND c.Id ={0}", id);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 云矿机规格
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCloudMinerSpecification()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT c.Id,c.CommodityId,c.ProductionAmount,c.ProductionCycle  FROM cloud_miner_specification c");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }

        /// <summary>
        /// 云矿机规格
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCloudMinerSpecification(int commodityId)
        {
            string strSql =
                string.Format(
                    "SELECT c.Id,c.CommodityId,c.ProductionAmount,c.ProductionCycle  FROM cloud_miner_specification c WHERE c.CommodityId={0}",
                    commodityId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 云矿机产币数量
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCloudMinerManufacture()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT c.Id,c.CommodityId,c.CurrencyId,c.Amount,ci.`Code` CurrencyCode,ci.Caption CurrencyCaption FROM cloud_miner_manufacture c  LEFT JOIN  currency_info as ci ON c.CurrencyId=ci.Id");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }

        /// <summary>
        /// 云矿机产币数量
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCloudMinerManufacture(int commodityId)
        {
            string strSql =
                string.Format(
                    "SELECT c.Id,c.CommodityId,c.CurrencyId,c.Amount,ci.`Code` CurrencyCode,ci.Caption CurrencyCaption FROM cloud_miner_manufacture c  LEFT JOIN  currency_info as ci ON c.CurrencyId=ci.Id WHERE c.CommodityId={0}",
                    commodityId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 购买限制之直推粉丝各会员等级人数
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBuyCommodityRuleFansVip()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT b.Id,b.CommodityId,b.VipId,v.Rank,b.Count FROM buy_commodity_rule_fans_vip b  LEFT JOIN vip_rank_info as v ON b.VipId=v.Id");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }

        /// <summary>
        /// 购买限制之直推粉丝各会员等级人数
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBuyCommodityRuleFansVip(int commodityId)
        {
            string strSql =
                string.Format(
                    "SELECT b.Id,b.CommodityId,b.VipId,v.Rank,b.Count FROM buy_commodity_rule_fans_vip b  LEFT JOIN vip_rank_info as v ON b.VipId=v.Id WHERE b.CommodityId={0}",
                    commodityId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 购买限制之各代粉丝人数
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBuyCommodityRuleFansGeneration()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT Id,CommodityId,GenerationId,GenerationCount FROM buy_commodity_rule_fans_generation");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }

        /// <summary>
        /// 购买限制之各代粉丝人数
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBuyCommodityRuleFansGeneration(int commodityId)
        {
            string strSql =
                string.Format(
                    "SELECT Id,CommodityId,GenerationId,GenerationCount FROM buy_commodity_rule_fans_generation WHERE CommodityId={0}",
                    commodityId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 支付明细
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCommodityPriceDetail()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT c.Id,c.CommodityId,c.CurrencyId,c.MinAmount,c.MaxAmount,ci.`Code` CurrencyCode,ci.Caption CurrencyCaption FROM cloud_miner_price_detail c INNER JOIN currency_info as ci on c.CurrencyId =ci.Id");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }

        /// <summary>
        /// 支付明细
        /// </summary>
        /// <param name="commodityId"></param>
        /// <returns></returns>
        public DataTable QueryCommodityPriceDetail(int commodityId)
        {
            string strSql = string.Format("SELECT c.Id,c.CommodityId,c.CurrencyId,c.MinAmount,c.MaxAmount,ci.`Code` CurrencyCode,ci.Caption CurrencyCaption FROM cloud_miner_price_detail c INNER JOIN currency_info as ci on c.CurrencyId =ci.Id  WHERE c.CommodityId={0}",
                commodityId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }


    }
}
