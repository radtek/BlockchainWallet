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
    public class WalletInfoDal
    {
        /// <summary>
        /// 查询非公司账户钱包信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable QueryWalletInfo(int userId)
        {
            string strSql = string.Format("SELECT w.Id,w.UId,w.CurrencyID,c.`Code` as CurrencyCode,c.Caption CurrencyCaption,w.AllAmount,w.CanUseAmount,w.FrozenAmount,c.CurrentAmount,w.WalletAddress FROM wallet_info w LEFT JOIN user_info as u ON u.Id=w.UId LEFT JOIN currency_info as c ON w.CurrencyID=c.Id where u.Type!='3' AND w.UId={0}", userId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 查询公司账户钱包信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable QueryCompanyWalletInfo(int userId)
        {
            string strSql = string.Format("SELECT  w.Id,w.UId,w.CurrencyID,c.`Code` as CurrencyCode,c.Caption CurrencyCaption,w.AllAmount,w.CanUseAmount,w.FrozenAmount FROM wallet_info w LEFT JOIN user_info as u ON u.Id=w.UId LEFT JOIN currency_info as c ON w.CurrencyID=c.Id where u.Type='3' AND w.UId={0}", userId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }
        /// <summary>
        /// 查询公司账户钱包信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCompanyWalletInfo()
        {
            string strSql = string.Format("SELECT  w.Id,w.UId,w.CurrencyID,c.`Code` as CurrencyCode,c.Caption CurrencyCaption,w.AllAmount,w.CanUseAmount,w.FrozenAmount FROM wallet_info w LEFT JOIN user_info as u ON u.Id=w.UId LEFT JOIN currency_info as c ON w.CurrencyID=c.Id where u.Type='3'");
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }
        private static readonly object LockWalletAddress = new object();
        /// <summary>
        /// 获取钱包地址
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string QueryWalletAddress(int userId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(MySqlHelper.Single.ConnectionString))
            {
                mySqlConnection.Open();
                MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction();
                try
                {
                    lock (LockWalletAddress)
                    {
                        string walletAddress = string.Empty;

                        #region 检查钱包地址是否存在
                        string strSql = string.Format("SELECT w.WalletAddress FROM wallet_info w Where w.UId={0} LIMIT 1", userId);
                        object objWalletAddress = MySqlHelper.Single.ExecuteScalar(strSql);
                        try
                        {
                            walletAddress = Convert.ToString(objWalletAddress);
                            if (!string.IsNullOrEmpty(walletAddress))
                            {
                                mySqlTransaction.Rollback();
                                return walletAddress; //钱包地址已存在
                            }
                        }
                        catch (Exception e)
                        {
                            LogHelper.error("获取钱包地址：查询钱包地址时出错" + e.Message);
                            mySqlTransaction.Rollback();
                            return "";
                        }
                        #endregion

                        try
                        {
                            walletAddress = ("0x" + Guid.NewGuid().ToString().Replace("-", ""));
                            string updateWalletAddress = string.Format("UPDATE wallet_info SET WalletAddress='{0}' WHERE UId ={1}", walletAddress, userId);
                            int rows = MySqlHelper.Single.ExecuteNonQuery(updateWalletAddress);
                            if (rows != 3)
                            {
                                LogHelper.error("获取钱包地址：修改钱包地址失败 sql:" + updateWalletAddress);
                                mySqlTransaction.Rollback();
                                return "";
                            }
                        }
                        catch (Exception e)
                        {
                            LogHelper.error("获取钱包地址：修改钱包地址出错 " + e.Message);
                            mySqlTransaction.Rollback();
                            return "";
                        }
                        mySqlTransaction.Commit();
                        return walletAddress;
                    }
                }
                catch (Exception e)
                {
                    LogHelper.error("获取钱包地址：添加钱包地址时失败" + e.Message);
                    mySqlTransaction.Rollback();
                    return "";
                }
            }
        }

    }
}
