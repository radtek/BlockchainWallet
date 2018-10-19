using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwCommon.Log;
using MySql.Data.MySqlClient;
using MySqlHelper = BwDal.Helper.MySqlHelper;

namespace BwDal.Transaction
{
    public class TransactionInfoDal
    {
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
                            "INSERT INTO Transaction_P2P_Record (OrderNo,PayUserId,PayeeUserId,TransactionTime,State,Remark) VALUES('{0}',{1}, {2},NOW(),'1','{3}');SELECT LAST_INSERT_ID() as Id;", orderNo, payUserId, payeeUserId, remark);
                    int id = Convert.ToInt32(MySqlHelper.Single.ExecuteScalar(sqlStr));
                    if (id <= 0)
                    {
                        LogHelper.error("创建P2P订单出现错误：创建订单返回值错误 SQL:" + sqlStr);
                        mySqlTransaction.Rollback();
                        return -1;
                    }
                    foreach (var entity in payCurrencyEntities)
                    {
                        sqlStr =
                            string.Format(
                                "INSERT INTO transaction_p2p_detail(OrderId,CurrencyId,Amount)VALUES({0},{1},{2});", id, entity.CurrencyId, entity.Amount);
                        int row = Convert.ToInt32(MySqlHelper.Single.ExecuteNonQuery(sqlStr));
                        if (row != 1)
                        {
                            LogHelper.error("创建P2P订单出现错误：创建订单返回值错误 SQL:" + sqlStr);
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

        public string TransactionP2PCheck(int payUserId, string orderNo)
        {
            string sqlStr =
                string.Format(
                    "SELECT State FROM transaction_p2p_record WHERE PayUserId ={0} and OrderNo ='{1}'", payUserId, orderNo);
            object obj = MySqlHelper.Single.ExecuteScalar(sqlStr);
            return obj == null ? "" : obj.ToString();
        }
    }
}
