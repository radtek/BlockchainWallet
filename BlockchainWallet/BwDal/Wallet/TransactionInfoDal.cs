using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwCommon.Log;
using MySql.Data.MySqlClient;
using MySqlHelper = BwDal.Helper.MySqlHelper;

namespace BwDal.Wallet
{
    public class TransactionInfoDal
    {
        public string RunTransaction(string no, int orderId, int payUserId, int payeeUserId, List<BorrowInfoEntity> borrowInfoEntities, List<LoansInfoEntity> loansInfoEntities, string type)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(MySqlHelper.Single.ConnectionString))
            {
                mySqlConnection.Open();
                MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction();
                try
                {
                    decimal amount = borrowInfoEntities.Sum(n => n.Amount);
                    string strSqlTransaction =
                        string.Format("INSERT INTO Transaction_Record (`No`,PayUserId,Amount,PayeeUserId,TransactionTime,Type,State,OrderId) VALUES ('{0}',{1},{2},{3},NOW(),'{4}','1',{5}); SELECT LAST_INSERT_ID() as Id;", no, payUserId, amount, payeeUserId, type, orderId);

                    int transactionId = Convert.ToInt32(MySqlHelper.Single.ExecuteScalar(mySqlTransaction, CommandType.Text, strSqlTransaction));

                    foreach (var borrowInfoEntity in borrowInfoEntities)
                    {
                        string strSqlBorrow =
                            string.Format("INSERT INTO transaction_borrow_money_detail (TransactionId,BorrowUserId,CurrencyID,Amount) VALUES ({0},{1},{2},{3})", transactionId, payeeUserId, borrowInfoEntity.CurrencyId, borrowInfoEntity.Amount);
                        int borrowRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSqlBorrow);
                        if (borrowRows != 1)
                        {
                            throw new Exception("添加借方数据失败：" + payeeUserId);
                        }
                        strSqlBorrow =
                            string.Format("UPDATE wallet_info SET AllAmount=AllAmount+{0} ,CanUseAmount=CanUseAmount+{0} WHERE UId={1} AND CurrencyID={2}", borrowInfoEntity.Amount, payeeUserId, borrowInfoEntity.CurrencyId);
                        int borrowUpdateRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSqlBorrow);
                        if (borrowUpdateRows != 1)
                        {
                            throw new Exception("修改借方钱包数据失败：" + payeeUserId);
                        }
                    }

                    foreach (var loansInfoEntity in loansInfoEntities)
                    {
                        string strSqlLoans =
                            string.Format("INSERT INTO transaction_loans_money_detail (TransactionId,LoansUserId,CurrencyID,Amount) VALUES ({0},{1},{2},{3})", transactionId, payUserId, loansInfoEntity.CurrencyId, loansInfoEntity.Amount);
                        int loansRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSqlLoans);
                        if (loansRows != 1)
                        {
                            throw new Exception("添加贷方数据失败：" + payUserId);
                        }
                        //获取可用金额
                        string strCanUserAmount =
                            string.Format("SELECT CanUseAmount FROM wallet_info  WHERE UId={0} AND CurrencyID={1}",
                                payUserId, loansInfoEntity.CurrencyId);
                        object objCanUserAmount = MySqlHelper.Single.ExecuteScalar(mySqlTransaction, CommandType.Text, strCanUserAmount);
                        decimal canUserAmount = Convert.ToDecimal(objCanUserAmount);
                        //判断可用金额是否大于贷出额度
                        if (canUserAmount < loansInfoEntity.Amount)
                        {
                            mySqlTransaction.Rollback();
                            return "3";
                        }
                        strSqlLoans =
                            string.Format("UPDATE wallet_info SET AllAmount=AllAmount-{0} ,CanUseAmount=CanUseAmount-{0} WHERE UId={1} AND CurrencyID={2}", loansInfoEntity.Amount, payUserId, loansInfoEntity.CurrencyId);
                        int borrowUpdateRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSqlLoans);
                        if (borrowUpdateRows != 1)
                        {
                            throw new Exception("修改贷方钱包数据失败：" + payUserId);
                        }
                    }
                    mySqlTransaction.Commit();
                    return "1";
                }
                catch (Exception e)
                {
                    LogHelper.error("交易系统错误：" + e.Message);
                    mySqlTransaction.Rollback();
                    return "0";
                }

            }
        }
        public class BorrowInfoEntity
        {
            public int CurrencyId { get; set; }

            public decimal Amount { get; set; }

        }
        public class LoansInfoEntity
        {
            public int CurrencyId { get; set; }

            public decimal Amount { get; set; }

        }
    }
}
