using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.System
{
    public class AppVersionDal
    {
        public DataTable QueryAppVersion(string appType)
        {
            string sqlStr = string.Format("SELECT Id,AppType,VersionNo,ForcedUpdate,Remark,Url FROM app_version  WHERE AppType={0} ORDER BY Id DESC ", appType);
            return MySqlHelper.Single.ExecuteDataTable(sqlStr);
        }
    }
}
