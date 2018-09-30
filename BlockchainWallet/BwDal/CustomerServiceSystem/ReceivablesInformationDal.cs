using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.CustomerServiceSystem
{
    public class ReceivablesInformationDal
    {
        public DataTable QueryBankCodeInfo(int userId)
        {
            string strSql = string.Format("SELECT Id,UserId,`Name`,BankCode,OpeningBank,Address,date_format(SubmitTime, '%Y-%m-%d %H:%i:%s') SubmitTime,State FROM bank_code_info WHERE UserId={0} Order by SubmitTime desc LIMIT 1", userId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        public int InsertBankCodeInfo(int userId, string name, string bankCode, string openingBank, string address)
        {
            string strSql = string.Format("INSERT INTO bank_code_info(UserId,`Name`,BankCode,OpeningBank,Address,SubmitTime,State)VALUES({0},'{1}','{2}','{3}','{4}',NOW(),'1')", userId, name, bankCode, openingBank, address);
            return MySqlHelper.Single.ExecuteNonQuery(strSql);
        }

        /// <summary>
        /// 查询第三方账户信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryThirdCollectionInfo(int userId, string accountType)
        {
            string strSql = string.Format("SELECT Id,UserId,Account,`Name`,CollectionCodeImage,AccountType,date_format(SubmitTime, '%Y-%m-%d %H:%i:%s') SubmitTime,EmployeeId,date_format(DisposeTime, '%Y-%m-%d %H:%i:%s') DisposeTime,State,Remark FROM Third_Collection_Info WHERE UserId={0} And AccountType='{1}' ORDER BY Id DESC LIMIT 1", userId, accountType);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }
        /// <summary>
        /// 添加第三方账账户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="account"></param>
        /// <param name="collectionCodeImage"></param>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public int InsertThirdCollectionInfo(int userId, string name, string account, string collectionCodeImage, string accountType)
        {
            string strSql = string.Format("INSERT INTO Third_Collection_Info(UserId,Account,`Name`,CollectionCodeImage,AccountType,SubmitTime,State)VALUES({0},'{1}','{2}','{3}','{4}',NOW(),'1')", userId, account, name, collectionCodeImage, accountType);
            return MySqlHelper.Single.ExecuteNonQuery(strSql);
        }
    }
}
