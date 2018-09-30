using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.Wallet
{
    public class WalletInfoDal_
    {
        public DataSet QueryUserWallet(DataPagingModelGet dataPagingModelGet)
        {
            string sqlStr = string.Format(@"SELECT SQL_CALC_FOUND_ROWS W.UID ID,U.`NAME`,U.PHONEAREAID,U.PHONE,W.ALLAMOUNTQQX,W.FROZENAMOUNTQQX,W.CANUSEAMOUNTQQX,W.ALLAMOUNTQQY,W.FROZENAMOUNTQQY,W.CANUSEAMOUNTQQY,W.ALLAMOUNTQQL,W.FROZENAMOUNTQQL,W.CANUSEAMOUNTQQL
                FROM USER_INFO U 
                LEFT JOIN 
                (
                SELECT UID,
                CASE CURRENCYID WHEN 0 THEN SUM(ALLAMOUNT)ELSE 0 END ALLAMOUNTQQX,
                CASE CURRENCYID WHEN 0 THEN SUM(FROZENAMOUNT)ELSE 0 END FROZENAMOUNTQQX,
                CASE CURRENCYID WHEN 0 THEN SUM(CANUSEAMOUNT)ELSE 0 END CANUSEAMOUNTQQX,
                CASE CURRENCYID WHEN 1 THEN SUM(ALLAMOUNT)ELSE 0 END ALLAMOUNTQQY,
                CASE CURRENCYID WHEN 1 THEN SUM(FROZENAMOUNT)ELSE 0 END FROZENAMOUNTQQY,
                CASE CURRENCYID WHEN 1 THEN SUM(CANUSEAMOUNT)ELSE 0 END CANUSEAMOUNTQQY,
                CASE CURRENCYID WHEN 2 THEN SUM(ALLAMOUNT)ELSE 0 END ALLAMOUNTQQL,
                CASE CURRENCYID WHEN 2 THEN SUM(FROZENAMOUNT)ELSE 0 END FROZENAMOUNTQQL,
                CASE CURRENCYID WHEN 2 THEN SUM(CANUSEAMOUNT)ELSE 0 END CANUSEAMOUNTQQL
                FROM WALLET_INFO 
                GROUP BY UID
                ) W ON W.UID=U.ID
                WHERE U.Type!='3' ");
            return MySqlHelper.Single.ExecuteDataSet(sqlStr + dataPagingModelGet.LimitString());
        }
    }
}
