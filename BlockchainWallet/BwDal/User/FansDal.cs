using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.User
{
    public class FansDal
    {
        public DataTable QueryPromotionInfo(string promotionCode)
        {
            string strSql = string.Format("Select Id, UId,PromotionCode from Promotion where PromotionCode='{0}'", promotionCode);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }
        public DataTable QueryPromotionInfo(int uId)
        {
            string strSql = string.Format("Select UId,PromotionCode,PromotionTime,FansId from Promotion where UId={0}", uId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        public DataTable QueryFans(int uId)
        {
            string strSql = string.Format("SELECT f.UId,f.FansId,u.Nickname FansName,f.PromotionId,date_format(f.PromotionTime, '%Y-%m-%d %H:%i:%s') PromotionTime,(SELECT Count(0) FROM fans f1 WHERE f1.UId=u.ID) FansCount FROM fans f LEFT JOIN user_info as u ON f.FansId=u.ID WHERE f.UId={0}", uId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        public DataTable QueryAllFansVipInfo(int fansId)
        {
            string strSql = string.Format("SELECT u.Id,f.UId ParentId,u.VipId,v.Rank,v.`Name` VipCaption FROM	fans f INNER JOIN user_info AS u ON f.FansId=u.ID LEFT JOIN vip_rank_info as v ON u.VipId=v.Id WHERE FIND_IN_SET(f.FansId,getFansInfo({0}))  ORDER BY u.Id ;", fansId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        public DataTable QueryFirstFansVipCount(int userId)
        {
            string strSql = string.Format("SELECT u.VipId,v.`Name` VipCaption,v.Rank,Count(0) FansCount  FROM fans f LEFT JOIN user_info as u ON f.FansId =u.Id LEFT JOIN vip_rank_info as v ON v.Id =u.VipId  WHERE UId ={0} GROUP BY u.VipId", userId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }
        public object QueryParent(int userId)
        {
            string strSql = string.Format("SELECT f.UId ParentId  FROM fans f  WHERE FansId ={0} ", userId);
            return MySqlHelper.Single.ExecuteScalar(strSql);
        }

    }
}
