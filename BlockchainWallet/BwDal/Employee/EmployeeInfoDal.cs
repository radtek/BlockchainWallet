using System.Data;
using System.Text;
using BwDal.Helper;

namespace BwDal.Employee
{
    public class EmployeeInfoDal
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DataRow Login(string accountId, string password)
        {
            StringBuilder sbSql = new StringBuilder("SELECT ID,AccountId,Nickname,Phone,PhoneAreaId,Type,State FROM employee_info WHERE State!='1'");
            SqlHelper.AppendAndWhereEqual("AccountId", accountId, ref sbSql);
            SqlHelper.AppendAndWhereEqual("LoginPassword", password, ref sbSql);
            return MySqlHelper.Single.ExecuteDataRow(sbSql.ToString());
        }

        public DataTable QueryEmployeeInfo()
        {

            StringBuilder sbSql = new StringBuilder("SELECT ID,AccountId,Nickname,Phone,PhoneAreaId,IdCard,Email,LoginPassword,Sex,date_format(Birthday, '%Y-%m-%d %H:%i:%s') Birthday,Type,State FROM employee_info WHERE 1=1");
            //SqlHelper.AppendAndWhereEqual("AccountId", accountId, ref sbSql);
            //SqlHelper.AppendAndWhereEqual("LoginPassword", password, ref sbSql);
            return MySqlHelper.Single.ExecuteDataTable(sbSql.ToString());
        }

        public int CreateAccount(string phone, string phoneAreaId, string name)
        {
            return 0;
        }
    }
}
