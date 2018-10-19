using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwCommon.Log;
using BwDal.Transaction;
using BwDal.Wallet;
using MySql.Data.MySqlClient;
using MySqlHelper = BwDal.Helper.MySqlHelper;

namespace BwDal.DistributionMechanism
{
    public class CloudMinerDistributionMechanismDal
    {
        /// <summary>
        /// 查询分销机制
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDistributionMechanism()
        {
            StringBuilder sbSql = new StringBuilder("SELECT g.ID,g.Generation,g.Proportion,g.VipId,v.Rank FROM cloud_miner_distribution_mechanism g LEFT JOIN vip_rank_info as v ON v.id=g.VipId ORDER BY g.Generation ");
            return MySqlHelper.Single.ExecuteDataTable(sbSql.ToString());
        }

        /// <summary>
        /// 新增云矿机分润记录
        /// </summary>
        /// <param name="ucmId"></param>
        /// <param name="commodityId"></param>
        /// <param name="userId"></param>
        /// <param name="borrowInfoEntities"></param>
        /// <returns></returns>
        public int InsertCloudMinerDistributionRecord(int ucmId, int commodityId, int userId, List<TransactionServerDal.PayCurrencyEntity> borrowInfoEntities)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(MySqlHelper.Single.ConnectionString))
            {
                mySqlConnection.Open();
                MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction();
                try
                {
                    string strSql = string.Format("INSERT INTO Cloud_Miner_Distribution_Record(UcmId,CommodityId,DistributionTime,DistributionId,State,Reamrk)VALUES({0},{1},NOW(),{2},'0','');SELECT LAST_INSERT_ID() as Id;", ucmId, commodityId, userId);
                    object objId = MySqlHelper.Single.ExecuteScalar(strSql);
                    int id = 0;
                    try
                    {
                        id = Convert.ToInt32(objId);
                    }
                    catch (Exception e)
                    {
                        LogHelper.error("云矿机分润：新增分润记录出错" + e.Message);
                        mySqlTransaction.Rollback();
                        return -1;
                    }
                    foreach (var borrowInfoEntity in borrowInfoEntities)
                    {
                        strSql = string.Format("INSERT INTO Cloud_Miner_Distribution_Detail(OrderId,CurrencyId,Amount) VALUES({0},{1},{2})", id, borrowInfoEntity.CurrencyId, borrowInfoEntity.Amount);
                        int rows = MySqlHelper.Single.ExecuteNonQuery(strSql);
                        if (rows != 1)
                        {
                            LogHelper.error("云矿机分润：新增分润记录明细时出错  sql-" + strSql);
                            mySqlTransaction.Rollback();
                            return -1;
                        }
                    }
                    mySqlTransaction.Commit();
                    return id;
                }
                catch (Exception e)
                {
                    LogHelper.error("云矿机分润：新增产币记录明细时出错" + e.Message);
                    mySqlTransaction.Rollback();
                    return -1;
                }
            }
        }
        /// <summary>
        /// 修改云矿机分润记录状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateCloudMinerDistributionRecord(int id, string state)
        {
            try
            {
                string strSql = string.Format("UPDATE Cloud_Miner_Distribution_Record SET State ='{0}' WHERE ID={1}", state, id);
                int row = MySqlHelper.Single.ExecuteNonQuery(strSql);
                return row == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
