using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.Commodity
{
    public class StoreOrderDal_
    {
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        public DataSet QueryStoreOrder_(DataPagingModelGet dataPagingModelGet)
        {
            string strSql = string.Format(@"SELECT SQL_CALC_FOUND_ROWS s.Id,s.OrderNo,s.CommodityId,c.`Name` CommodityName,s.Count,s.UnitPrice,s.TotalPrice,pd.QQX,pd.QQY,pd.QQL,date_format(s.OrderTime, '%Y-%m-%d %H:%i:%s') OrderTime,date_format(s.BuyTime, '%Y-%m-%d %H:%i:%s') BuyTime,s.BuyUserId,bu.Nickname BuyUserNickname,bu.PhoneAreaId BuyUserPhoneAreaId,bu.Phone BuyUserPhone,bu.Name BuyUserName,s.ConsignorUserId,cu.Nickname ConsignorUserNickname,cu.PhoneAreaId ConsignorUserPhoneAreaId,cu.Phone ConsignorUserPhone,cu.Name ConsignorUserName,s.Type,IF(s.State=0 and TIMESTAMPDIFF(SECOND,s.OrderTime,NOW())>24*60*60,'2',s.State) State
                FROM store_order s 
		                LEFT JOIN commodity as c ON c.Id =s.CommodityId 
                LEFT JOIN user_info as bu ON s.BuyUserId=bu.Id 
                LEFT JOIN user_info as cu ON cu.Id =s.ConsignorUserId 
                LEFT JOIN
                (
		                SELECT d.OrderId,
                SUM(CASE WHEN d.CurrencyID=0 THEN
                d.Amount ELSE 0 END )QQX, 
                SUM(CASE WHEN d.CurrencyID=1 THEN
                d.Amount ELSE 0 END) QQY,
                SUM(case WHEN d.CurrencyID=2 THEN
                d.Amount ELSE 0 END) QQL
		                FROM store_order_pay_detail d
                GROUP BY d.OrderId
		                ) pd ON pd.OrderId =s.Id
                ORDER BY s.OrderTime DESC  " + dataPagingModelGet.LimitString());
            return MySqlHelper.Single.ExecuteDataSet(strSql);
        }

        /// <summary>
        /// 查询支付明细
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPayDetail_(string orderIds)
        {
            string strSql = string.Format("SELECT p.Id,p.OrderId,p.CurrencyId,c.`Code` CurrencyCode,c.Caption CurrencyCaption,p.Amount FROM store_order_pay_detail p LEFT JOIN currency_info as c ON p.CurrencyId=c.Id WHERE p.OrderId IN ({0})", orderIds);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }
    }
}
