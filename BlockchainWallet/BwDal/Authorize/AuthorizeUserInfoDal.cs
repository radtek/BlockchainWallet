using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.Authorize
{
    /// <summary>
    /// 用户授权绑定类
    /// </summary>
    public class AuthorizeUserInfoDal
    {
        /// <summary>
        /// 商品基本信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCommodityInfo(int appId, string openUserId)
        {
            string strSql =
                string.Format(
                    "SELECT Id,AppId,UserId,ExternalUserId,OpenUserId,AuthorizaTime,State FROM authorize_user_info WHERE AppId={0} and OpenUserId='{1}'",
                    appId, openUserId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

    }
}
