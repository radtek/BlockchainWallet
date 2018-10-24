using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwCommon.Log;
using BwDal.Helper;
using MySql.Data.MySqlClient;
using MySqlHelper = BwDal.Helper.MySqlHelper;

namespace BwDal.Transaction
{
    public class TransactionInfoDal
    {
        /// <summary>
        /// 查询转账订单记录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dataPagingModelGet"></param>
        /// <returns></returns>
        public DataSet QueryTransactionP2PRecord(int userId, DataPagingModelGet dataPagingModelGet)
        {
            string strSql = string.Format(@"SELECT SQL_CALC_FOUND_ROWS tr.Id,tr.OrderNo,tr.TransactionTime,
                                            (SELECT WalletAddress FROM wallet_info WHERE UId=tr.PayeeUserId LIMIT 1) PayeeWalletAddress,
                                            tr.State,tr.Remark
                                            FROM transaction_p2p_record  tr
                                            WHERE tr.PayUserId ={0}
                                            ORDER BY tr.TransactionTime DESC" + dataPagingModelGet.LimitString(), userId);
            return MySqlHelper.Single.ExecuteDataSet(strSql);
        }
        /// <summary>
        /// 查询转账订单明细
        /// </summary>
        /// <param name="orderIds"></param>
        /// <returns></returns>
        public DataTable QueryTransactionP2PDetail(string orderIds)
        {
            string strSql = string.Format(@"SELECT td.ID,td.OrderId,td.CurrencyId,td.Amount,td.ServiceCharge 
                                            FROM transaction_p2p_detail td 
                                            WHERE td.OrderId in ({0})", orderIds);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }
        /// <summary>
        /// 创建转转账订单
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="payUserId"></param>
        /// <param name="payeeUserId"></param>
        /// <param name="remark"></param>
        /// <param name="payCurrencyEntities"></param>
        /// <returns></returns>
        public int CreateTransactionP2P(string orderNo, int payUserId, int payeeUserId, string remark, List<TransactionServerDal.PayCurrencyEntity> payCurrencyEntities)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(MySqlHelper.Single.ConnectionString))
            {
                mySqlConnection.Open();
                MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction();
                try
                {
                    string sqlStr =
                        string.Format(
                            "INSERT INTO " +
                            "Transaction_P2P_Record" +
                            " (OrderNo,PayUserId,PayeeUserId,TransactionTime,State,Remark) VALUES('{0}',{1}, {2},NOW(),'0','{3}');SELECT LAST_INSERT_ID() as Id;", orderNo, payUserId, payeeUserId, remark);
                    int id = Convert.ToInt32(MySqlHelper.Single.ExecuteScalar(sqlStr));

                    if (id <= 0)
                    {
                        LogHelper.error("创建P2P订单出现错误：新增P2P订单失败 SQL:" + sqlStr);
                        mySqlTransaction.Rollback();
                        return -1;
                    }
                    foreach (var entity in payCurrencyEntities)
                    {
                        sqlStr =
                            string.Format(
                                "INSERT INTO transaction_p2p_detail(OrderId,CurrencyId,Amount,ServiceCharge)VALUES({0},{1},{2},{3});", id, entity.CurrencyId, entity.Amount, entity.Amount * 0.1M);
                        int row = Convert.ToInt32(MySqlHelper.Single.ExecuteNonQuery(sqlStr));
                        if (row != 1)
                        {
                            LogHelper.error("创建P2P订单出现错误：新增P2P订单明细失败 SQL:" + sqlStr);
                            mySqlTransaction.Rollback();
                            return -1;
                        }
                    }
                    mySqlTransaction.Commit();
                    return id;
                }
                catch (Exception e)
                {
                    LogHelper.error("创建P2P订单出现错误：" + e.Message);
                    mySqlTransaction.Rollback();
                    return -1;
                }

            }
        }

        public bool UpdateTransactionP2P(int orderId, string state)
        {
            string sqlStr =
                string.Format(
                    "UPDATE transaction_p2p_record SET State='{0}' WHERE Id={1}", state, orderId);
            int row = MySqlHelper.Single.ExecuteNonQuery(sqlStr);
            return row == 1;
        }

        public string TransactionP2PCheck(int payUserId, int orderId)
        {
            string sqlStr =
                string.Format(
                    "SELECT State FROM transaction_p2p_record WHERE PayUserId ={0} and Id ={1}", payUserId, orderId);
            object obj = MySqlHelper.Single.ExecuteScalar(sqlStr);
            return obj == null ? "" : obj.ToString();
        }
    }
}
