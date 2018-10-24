using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BwCommon.Log;
using MySql.Data.MySqlClient;
using MySqlHelper = BwDal.Helper.MySqlHelper;

namespace BwDal.Transaction
{
    public class TransactionServerDal
    {
        private static readonly string[] ServiceChargeTypes =
        {
            "01",//交易
            "02"//转账
        };
        public string RunTransaction(string no, int orderId, int payUserId, int payeeUserId, List<PayCurrencyEntity> borrowInfoEntities, List<PayCurrencyEntity> loansInfoEntities, string type)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(MySqlHelper.Single.ConnectionString))
            {
                mySqlConnection.Open();
                MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction();
                try
                {
                    //新增订单交易记录
                    string strSqlTransaction =
                        string.Format("INSERT INTO Transaction_Record (`No`,PayUserId,PayeeUserId,TransactionTime,Type,State,OrderId) VALUES ('{0}',{1},{2},NOW(),'{3}','1',{4}); SELECT LAST_INSERT_ID() as Id;", no, payUserId, payeeUserId, type, orderId);

                    int transactionId = Convert.ToInt32(MySqlHelper.Single.ExecuteScalar(mySqlTransaction, CommandType.Text, strSqlTransaction));
                    if (transactionId <= 0)
                    {
                        throw new Exception("添加订单交易记录失败 SQL：" + strSqlTransaction);
                    }
                    #region 借方记录相关
                    //新增借方数据
                    foreach (var borrowInfoEntity in borrowInfoEntities)
                    {
                        //新增借方交易记录
                        string strSqlBorrow =
                            string.Format("INSERT INTO transaction_borrow_money_detail (TransactionId,BorrowUserId,CurrencyID,Amount) VALUES ({0},{1},{2},{3})", transactionId, payeeUserId, borrowInfoEntity.CurrencyId, borrowInfoEntity.Amount);
                        int borrowRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSqlBorrow);
                        if (borrowRows != 1)
                        {
                            throw new Exception("添加借方数据失败 SQL：" + strSqlBorrow);
                        }

                        //修改金额
                        strSqlBorrow =
                            string.Format("UPDATE wallet_info SET AllAmount=AllAmount+{0} ,CanUseAmount=CanUseAmount+{0} WHERE UId={1} AND CurrencyID={2}", borrowInfoEntity.Amount, payeeUserId, borrowInfoEntity.CurrencyId);
                        int borrowUpdateRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSqlBorrow);
                        if (borrowUpdateRows != 1)
                        {
                            throw new Exception("修改借方钱包数据失败  SQL：" + strSqlBorrow);
                        }
                    }
                    #endregion

                    #region 贷方记录相关
                    //新增贷方数据
                    foreach (var loansInfoEntity in loansInfoEntities)
                    {
                        string strSqlLoans =
                            string.Format("INSERT INTO transaction_loans_money_detail (TransactionId,LoansUserId,CurrencyID,Amount) VALUES ({0},{1},{2},{3})", transactionId, payUserId, loansInfoEntity.CurrencyId, loansInfoEntity.Amount);
                        int loansRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSqlLoans);
                        if (loansRows != 1)
                        {
                            throw new Exception("添加贷方数据失败：" + payUserId);
                        }
                        #region 手续费相关
                        decimal serviceChargeBorrowAmount = 0M;
                        //新增手续费的借方记录
                        if (ServiceChargeTypes.Contains(type))
                        {

                            int serviceChargeBorrowUserId = 0;
                            decimal taxRate = 0M; //手续费税率
                            switch (type)
                            {
                                case "01": //新增交易手续费贷方记录
                                    taxRate = 0.15M;
                                    serviceChargeBorrowAmount = loansInfoEntity.Amount * taxRate;
                                    serviceChargeBorrowUserId = 6;
                                    break;
                                case "02"://新增转账手续费贷方记录
                                    taxRate = 0.1M;
                                    serviceChargeBorrowAmount = loansInfoEntity.Amount * taxRate;
                                    serviceChargeBorrowUserId = 6;
                                    break;
                                default:
                                    throw new Exception("新增手续费的借方记录时出现异常交易类型 Type：" + type);
                            }
                            //新增手续费借方记录
                            string strInsertBorrowServiceCharge =
                                string.Format(
                                    "INSERT INTO transaction_service_charge_borrow_money_detail (TransactionId,Amount,BorrowUserId,TaxRate)VALUES({0},{1},{2},{3})", transactionId, serviceChargeBorrowAmount, serviceChargeBorrowUserId, taxRate);
                            int serviceChargeBorrowRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strInsertBorrowServiceCharge);
                            if (serviceChargeBorrowRows != 1)
                            {
                                throw new Exception("新增手续费的借方记录出现异常 SQL:" + strInsertBorrowServiceCharge);
                            }

                            //新增手续费贷方记录
                            string strInsertLoansServiceCharge =
                                string.Format(
                                    "INSERT INTO transaction_service_charge_loans_money_detail (TransactionId,Amount,LoansUserId,TaxRate)VALUES({0},{1},{2},{3})", transactionId, serviceChargeBorrowAmount, payUserId, taxRate);
                            int serviceChargeLoansRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strInsertLoansServiceCharge);
                            if (serviceChargeLoansRows != 1)
                            {
                                throw new Exception("新增手续费的贷方记录出现异常 SQL:" + strInsertLoansServiceCharge);
                            }

                            //修改手续费借方钱包金额
                            string strUpdateBorrowServiceCharge =
                                string.Format("UPDATE wallet_info SET AllAmount=AllAmount-{0} ,CanUseAmount=CanUseAmount-{0} WHERE UId={1} AND CurrencyID={2}", serviceChargeBorrowAmount, serviceChargeBorrowUserId, loansInfoEntity.CurrencyId);
                            int updateServiceChargeBorrowRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strUpdateBorrowServiceCharge);
                            if (updateServiceChargeBorrowRows != 1)
                            {
                                throw new Exception("修改手续费借方钱包金额 SQL:" + strUpdateBorrowServiceCharge);
                            }

                            //修改手续费贷方钱包金额
                            string strUpdateLoansServiceCharge =
                                    string.Format("UPDATE wallet_info SET AllAmount=AllAmount-{0} ,CanUseAmount=CanUseAmount-{0} WHERE UId={1} AND CurrencyID={2}", serviceChargeBorrowAmount, payUserId, loansInfoEntity.CurrencyId);
                            int updateServiceChargeLoansRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strUpdateLoansServiceCharge);
                            if (updateServiceChargeLoansRows != 1)
                            {
                                throw new Exception("修改手续费贷方钱包金额 SQL:" + strUpdateLoansServiceCharge);
                            }

                        }
                        #endregion

                        //获取可用金额
                        string strCanUserAmount =
                            string.Format("SELECT CanUseAmount FROM wallet_info  WHERE UId={0} AND CurrencyID={1}",
                                payUserId, loansInfoEntity.CurrencyId);
                        object objCanUserAmount = MySqlHelper.Single.ExecuteScalar(mySqlTransaction, CommandType.Text, strCanUserAmount);
                        decimal canUserAmount = Convert.ToDecimal(objCanUserAmount);
                        //判断可用金额是否大于贷出额度
                        if (canUserAmount < loansInfoEntity.Amount + serviceChargeBorrowAmount)
                        {
                            mySqlTransaction.Rollback();
                            return "3";
                        }

                        //修改贷方金额金额
                        strSqlLoans =
                            string.Format("UPDATE wallet_info SET AllAmount=AllAmount-{0} ,CanUseAmount=CanUseAmount-{0} WHERE UId={1} AND CurrencyID={2}", loansInfoEntity.Amount, payUserId, loansInfoEntity.CurrencyId);

                        int borrowUpdateRows = MySqlHelper.Single.ExecuteNonQuery(mySqlTransaction, CommandType.Text, strSqlLoans);
                        if (borrowUpdateRows != 1)
                        {
                            throw new Exception("修改贷方钱包数据失败：" + payUserId);
                        }
                    }
                    #endregion
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
        public class PayCurrencyEntity
        {
            public int CurrencyId { get; set; }

            public decimal Amount { get; set; }

        }
    }
}
