using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.System
{
    public class BugDal
    {
        public int SubmitBug(int userId, string content, string type)
        {
            string sql = string.Format("Insert INTO BUG_RECORD(SubmitUserId,Content,Type,SubmitTime,State)VALUES({0},'{1}','{2}',now(),'0') ", userId, content, type);
            return MySqlHelper.Single.ExecuteNonQuery(sql);
        }
    }
}
