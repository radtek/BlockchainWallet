using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.User
{
    public class CompanyAccountInfoDal
    {
        public DataTable QueryCompanyAccountInfo()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT ID,AccountId,Nickname,State FROM user_info WHERE type='3' ORDER BY ID ");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }
    }
}
