using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;
using MySql.Data.MySqlClient;
using MySqlHelper = BwDal.Helper.MySqlHelper;

namespace BwDal.Wallet
{
    public class CurrencyInfoDal
    {
        public DataTable QueryCurrency()
        {
            string sqlStr = string.Format("select Id,Code,Caption,ContractAddress,TotalAmount,CurrentAmount from Currency_Info");
            return MySqlHelper.Single.ExecuteDataTable(sqlStr);
        }
        public DataSet QueryCurrencyPriceRecord(DataPagingModelGet dataPagingModelGet)
        {
            string sqlStr = string.Format(@" 
                                           SELECT SQL_CALC_FOUND_ROWS cpr.Id,ci.`Code` CurrencyCode,cpr.CurrencyId,ci.Caption CurrencyCaption,cpr.Price,cpr.UpdateEmployeeId,date_format(cpr.UpdateTime,'%Y-%m-%d %H:%i:%s') UpdateTime,cpr.Type,
CASE cpr.Type
	WHEN '0' THEN
		(select Nickname FROM employee_info WHERE ID= cpr.UpdateEmployeeId LIMIT 1 )
	ELSE
		 (select Nickname FROM user_info WHERE ID= cpr.UpdateEmployeeId LIMIT 1 )
END UpdateEmployeeName
FROM currency_price_record cpr
LEFT JOIN currency_info as ci on ci.Id=cpr.CurrencyId
ORDER BY cpr.UpdateTime DESC
                                            ");
            return MySqlHelper.Single.ExecuteDataSet(sqlStr + dataPagingModelGet.LimitString());
        }
        public int UpdateCurrencyPrice(int currencyId, decimal price, int updateEmployeeId, string type)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(MySqlHelper.Single.ConnectionString))
            {
                mySqlConnection.Open();
                MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction();
                try
                {
                    string sqlStr =
                        string.Format(
                            "insert into currency_price_record (CurrencyId,Price,UpdateTime,UpdateEmployeeId,type)values({0},{1},Now(),{2},{3});", currencyId, price, updateEmployeeId, type);
                    int row = MySqlHelper.Single.ExecuteNonQuery(sqlStr);
                    if (row != 1)
                    {
                        mySqlTransaction.Rollback();
                        return -1;
                    }
                    sqlStr =
                       string.Format(
                           "update currency_info set CurrentAmount={0} where Id={1} ", price, currencyId);
                    row = MySqlHelper.Single.ExecuteNonQuery(sqlStr);
                    if (row != 1)
                    {
                        mySqlTransaction.Rollback();
                        return -1;
                    }
                    mySqlTransaction.Commit();
                    return 1;
                }
                catch
                {
                    mySqlTransaction.Rollback();
                    return -1;
                }
            }
        }
        public int UpdateCurrencyPriceRecord(int id, decimal price)
        {
            string sqlStr =
                 string.Format(
                     "update currency_price_record set Price={0} where Id={1} ", price, id);
            return MySqlHelper.Single.ExecuteNonQuery(sqlStr);
        }


    }
}
