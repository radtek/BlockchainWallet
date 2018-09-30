using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

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
            string strSql = string.Format("SELECT  w.Id,w.UId,w.CurrencyID,c.`Code` as CurrencyCode,c.Caption CurrencyCaption,w.AllAmount,w.CanUseAmount,w.FrozenAmount,c.CurrentAmount,w.WalletAddress FROM wallet_info w LEFT JOIN user_info as u ON u.Id=w.UId LEFT JOIN currency_info as c ON w.CurrencyID=c.Id where u.Type!='3' AND w.UId={0}", userId);
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

    }
}
