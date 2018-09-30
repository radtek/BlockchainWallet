using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.Commodity
{
    /// <summary>
    /// 
    /// </summary>
    public class UserCloudMinerDal
    {
        /// <summary>
        /// 查询用户云矿机
        /// </summary>
        /// <returns></returns>
        public DataTable QueryUserCloudMiner(int userId)
        {
            string strSql =
                string.Format(
                    "SELECT ucm.Id,c.`Name` CommodityName,date_format(ucm.BuyTime, '%Y-%m-%d %H:%i:%s') BuyTime,cms.ProductionCycle,cms.ProductionAmount,c.Amount,ucm.State,c.DisplayImage  FROM user_cloud_miner ucm LEFT JOIN user_info as u ON ucm.UserId=u.Id LEFT JOIN commodity as c ON ucm.CommodityId=c.Id LEFT JOIN cloud_miner_specification as cms ON c.Id=cms.CommodityId WHERE ucm.UserId={0} Order By ucm.BuyTime desc ",
                    userId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 查询用户云矿机明细
        /// </summary>
        /// <returns></returns>
        public DataTable QueryUserCloudMinerInfo(int id)
        {
            string strSql =
                string.Format(
                    "SELECT ucm.Id,c.`Name`,ucm.OrderId,ucm.OrderNo,ucm.TransactionNo,date_format(ucm.BuyTime, '%Y-%m-%d %H:%i:%s') BuyTime,cms.ProductionCycle,cms.ProductionAmount,c.Amount,ucm.State,c.DisplayImage FROM user_cloud_miner ucm LEFT JOIN user_info as u ON ucm.UserId=u.Id LEFT JOIN commodity as c ON ucm.CommodityId=c.Id LEFT JOIN cloud_miner_specification as cms ON c.Id=cms.CommodityId WHERE ucm.ID={0}",
                    id);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 查询矿机总览
        /// </summary>
        /// <returns></returns>
        public DataTable QueryUserCloudMinerOverview(int userId)
        {
            string strSql =
                string.Format(
                    "SELECT (SELECT Count(0) CloudMinerCount FROM user_cloud_miner ucm WHERE ucm.State='0' AND ucm.UserId={0}) CloudMinerCount,(SELECT SUM(cms.ProductionAmount) ProductionAmount FROM user_cloud_miner ucm LEFT JOIN cloud_miner_specification as cms ON ucm.CommodityId=cms.CommodityId WHERE ucm.State='0' AND ucm.UserId={0}) ProductionAmount,(SELECT SUM(cms.ProductionAmount) ProductionAmount FROM user_cloud_miner ucm LEFT JOIN cloud_miner_specification as cms ON ucm.CommodityId=cms.CommodityId WHERE ucm.State='0') NetProductionAmount ", userId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 添加矿机
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderNo"></param>
        /// <param name="transactionNo"></param>
        /// <param name="userId"></param>
        /// <param name="commodityId"></param>
        /// <returns></returns>
        public bool InsertUserCloudMiner(int orderId, string orderNo, string transactionNo, int userId, int commodityId, int productionCount)
        {
            int rowCount = 0;
            for (int i = 0; i < productionCount; i++)
            {
                string strSql =
                    string.Format("INSERT INTO user_cloud_miner (OrderId,OrderNo,TransactionNo,UserId,CommodityId,BuyTime,State,ProductionCount)VALUES({0},'{1}','{2}',{3},{4},NOW(),'0',0)", orderId, orderNo, transactionNo, userId, commodityId);
                int rows = MySqlHelper.Single.ExecuteNonQuery(strSql);
                rowCount += rows;
            }
            return rowCount == productionCount;
        }
        /// <summary>
        /// 查询昨天以前的运行中的云矿机
        /// </summary>
        /// <returns></returns>
        public DataTable QueryRuningCloudMiner()
        {
            string strSql = "SELECT ucm.Id,ucm.CommodityId,ucm.UserId,date_format(ucm.BuyTime, '%Y-%m-%d %H:%i:%s') BuyTime,cms.ProductionCycle,cms.ProductionAmount,ucm.ProductionCount FROM user_cloud_miner ucm JOIN commodity as c ON ucm.CommodityId=c.ID JOIN cloud_miner_specification as cms ON c.id=cms.CommodityId WHERE ucm.State='0' AND ucm.BuyTime<DATE(NOW()) AND  ucm.ProductionCount<150 ";
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 修改用户矿机状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateUserCloudMinerState(int id, string state)
        {
            string strSql = string.Format("update user_cloud_miner SET State='{0}' WHERE ID={1}", state, id);
            return MySqlHelper.Single.ExecuteNonQuery(strSql) == 1;
        }

        /// <summary>
        /// 修改用户矿机状态
        /// </summary>
        /// <returns></returns>
        public bool RunUserCloudMiner(int id)
        {
            string strSql = string.Format("update user_cloud_miner SET ProductionCount=ProductionCount+1 WHERE ID={0}", id);
            return MySqlHelper.Single.ExecuteNonQuery(strSql) == 1;
        }

        /// <summary>
        /// 查询用户当前运行的矿机数量
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="commodityId"></param>
        /// <returns></returns>
        public int QueryRunningCloudMinerCount(int userId, int commodityId)
        {
            string strSql = string.Format("SELECT SUM(Count) Count FROM(SELECT Count(0) Count FROM user_cloud_miner WHERE State ='0' AND UserId={0} AND CommodityId={1} UNION ALL select SUM(Count) Count FROM store_order WHERE State ='4' AND BuyUserId={0} AND CommodityId={1} GROUP BY BuyUserId,CommodityId) t  ", userId, commodityId);
            return Convert.ToInt32(MySqlHelper.Single.ExecuteScalar(strSql));
        }


    }
}
