using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BwCommon.Log;
using BwDal.Helper;
using BwDal.Transaction;
using BwDal.Wallet;
using MySql.Data.MySqlClient;
using MySqlHelper = BwDal.Helper.MySqlHelper;

namespace BwDal.Agent
{
    public class CloudMinerProductionDal_
    {
        /// <summary>
        /// 新增云矿机产币记录和明细
        /// </summary>
        /// <param name="ucmId"></param>
        /// <param name="commodityId"></param>
        /// <param name="borrowInfoEntities"></param>
        /// <param name="productionCount"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int InsertCloudMinerProductionRecord(int ucmId, int commodityId, int userId, List<TransactionServerDal.PayCurrencyEntity> borrowInfoEntities, int productionCount)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(MySqlHelper.Single.ConnectionString))
            {
                mySqlConnection.Open();
                MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction();
                try
                {
                    string strSql = string.Format("INSERT INTO cloud_miner_production_record(UcmId,CommodityId,ProductionTime,UserId,State,Reamrk,ProductionCount)VALUES({0},{1},NOW(),{2},'0','',{3});SELECT LAST_INSERT_ID() as Id;", ucmId, commodityId, userId, productionCount);
                    object objId = MySqlHelper.Single.ExecuteScalar(strSql);
                    int id = 0;
                    try
                    {
                        id = Convert.ToInt32(objId);
                    }
                    catch (Exception e)
                    {
                        LogHelper.error("云矿机产币：新增产币记录出错" + e.Message);
                        mySqlTransaction.Rollback();
                        return -1;
                    }
                    foreach (var borrowInfoEntity in borrowInfoEntities)
                    {
                        strSql = string.Format("INSERT INTO cloud_miner_production_detail(OrderId,CurrencyId,Amount) VALUES({0},{1},{2})", id, borrowInfoEntity.CurrencyId, borrowInfoEntity.Amount);
                        int rows = MySqlHelper.Single.ExecuteNonQuery(strSql);
                        if (rows != 1)
                        {
                            LogHelper.error("云矿机产币：新增产币记录明细时出错  sql-" + strSql);
                            mySqlTransaction.Rollback();
                            return -1;
                        }
                    }
                    mySqlTransaction.Commit();
                    return id;
                }
                catch (Exception e)
                {
                    LogHelper.error("云矿机产币：新增产币记录明细时出错" + e.Message);
                    mySqlTransaction.Rollback();
                    return -1;
                }
            }
        }
        /// <summary>
        /// 修改云矿机产币记录状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateCloudMinerProductionRecord(int id, string state)
        {
            try
            {
                string strSql = string.Format("UPDATE cloud_miner_production_record SET State ='{0}' WHERE ID={1}", state, id);
                int row = MySqlHelper.Single.ExecuteNonQuery(strSql);
                return row == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 查询云矿机产币记录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productionDate"></param>
        /// <param name="dataPagingModelGet"></param>
        /// <returns></returns>
        public DataSet QueryCloudMinerProductionRecord(int userId, string productionDate, DataPagingModelGet dataPagingModelGet)
        {
            StringBuilder whereStr = new StringBuilder();
            if (userId > 0)
            {
                whereStr.Append(" AND r.UserId = " + userId);
            }
            if (!string.IsNullOrEmpty(productionDate))
            {
                whereStr.Append(string.Format(" AND r.ProductionTime >= '{0}' AND r.ProductionTime<'{1}' ", Convert.ToDateTime(productionDate).ToString("yyyy-MM-dd"), Convert.ToDateTime(productionDate).AddDays(1).ToString("yyyy-MM-dd")));
            }
            string sqlStr =
                string.Format(
                    @"SELECT SQL_CALC_FOUND_ROWS r.Id,r.CommodityId,c.`Name` CommodityName,date_format( ucm.BuyTime, '%Y-%m-%d %H:%i:%s') BuyTime,date_format( r.ProductionTime, '%Y-%m-%d %H:%i:%s') ProductionTime,r.ProductionCount,pd.Amount,pd.QQX,pd.QQY,pd.QQL,r.UserId,u.Nickname UserNickname,u.PhoneAreaId UserPhoneAreaId,u.Phone UserPhone,u.Name UserName,r.State
                    FROM cloud_miner_production_record r 
                    LEFT JOIN user_info as u ON r.UserId=u.Id
                    LEFT JOIN user_cloud_miner as ucm ON ucm.Id =r.UcmId
                    LEFT JOIN commodity as c ON r.CommodityId=c.Id
                    LEFT JOIN (
                        SELECT d.OrderId ,
                    SUM(d.Amount) Amount,
                    SUM(
                        CASE WHEN d.CurrencyID=0 THEN
                    d.Amount ELSE 0 END )QQX, 
                    SUM(CASE WHEN d.CurrencyID=1 THEN
                    d.Amount ELSE 0 END) QQY,
                    SUM(case WHEN d.CurrencyID=2 THEN
                    d.Amount ELSE 0 END) QQL
                        FROM cloud_miner_production_detail d GROUP BY d.OrderId
                        )  as pd ON r.Id=pd.OrderId
                    where 1=1 {0} 
                    Order by r.ProductionTime DESC ,r.UserId ASC ", whereStr);
            return MySqlHelper.Single.ExecuteDataSet(sqlStr + dataPagingModelGet.LimitString());
        }

        public DataSet QueryUserCloudMinerProductionRecord(DataPagingModelGet dataPagingModelGet)
        {
            string sqlStr =
                string.Format(
                    @"SELECT SQL_CALC_FOUND_ROWS date_format(r.ProductionTime, '%Y-%m-%d') ProductionTime,sum(pd.Amount) Amount ,sum(pd.QQX) QQX,sum(pd.QQY) QQY,sum(pd.QQL) QQL,r.UserId,u.Nickname,u.PhoneAreaId ,u.Phone,u.Name
                        FROM cloud_miner_production_record r 
		                        LEFT JOIN user_info as u ON r.UserId=u.Id
                        LEFT JOIN user_cloud_miner as ucm ON ucm.Id =r.UcmId
                        LEFT JOIN (
		                        SELECT d.OrderId ,
                                        SUM(d.Amount) Amount,
                                        SUM(
		                                        CASE WHEN d.CurrencyID=0 THEN
                                        d.Amount ELSE 0 END )QQX, 
                                        SUM(CASE WHEN d.CurrencyID=1 THEN
                                        d.Amount ELSE 0 END) QQY,
                                        SUM(case WHEN d.CurrencyID=2 THEN
                                        d.Amount ELSE 0 END) QQL
		                        FROM cloud_miner_production_detail d GROUP BY d.OrderId
		                        )  as pd ON r.Id=pd.OrderId
                        WHERE r.State='1'
                        GROUP BY date_format(r.ProductionTime, '%Y-%m-%d'),r.UserId,u.Nickname,u.PhoneAreaId,u.Phone
                        Order by r.ProductionTime DESC,r.UserId ASC " + dataPagingModelGet.LimitString());
            return MySqlHelper.Single.ExecuteDataSet(sqlStr);
        }
    }
}
