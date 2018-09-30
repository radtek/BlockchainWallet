using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.Commodity
{
    public class StoreOrderDal
    {
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        //        public DataSet QueryStoreOrder(int userId, DataPagingModelGet dataPagingModelGet)
        //        {
        //            string strSql = string.Format(@"SELECT SQL_CALC_FOUND_ROWS s.Id,s.OrderNo,s.CommodityId,c.`Name` CommodityName,s.Count,s.UnitPrice,s.TotalPrice,date_format(s.OrderTime, '%Y-%m-%d %H:%i:%s') OrderTime,s.State,s.Type,c.DisplayImage 
        //                FROM store_order s 
        //                LEFT JOIN commodity as c on s.CommodityId=c.Id 
        //                WHERE s.BuyUserId={0} 
        //                Order BY s.OrderTime Desc " + dataPagingModelGet.LimitString(), userId);
        //            return MySqlHelper.Single.ExecuteDataSet(strSql);
        //        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        public DataSet QueryStoreOrder(int userId, DataPagingModelGet dataPagingModelGet)
        {
            string strSql = string.Format(@"SELECT SQL_CALC_FOUND_ROWS s.Id,s.OrderNo,s.CommodityId,c.`Name` CommodityName,s.Count,s.UnitPrice,s.TotalPrice,date_format(s.OrderTime, '%Y-%m-%d %H:%i:%s') OrderTime,date_format(s.BuyTime, '%Y-%m-%d %H:%i:%s') BuyTime,IF(s.State=0 and TIMESTAMPDIFF(SECOND,s.OrderTime,NOW())>24*60*60,'2',s.State) State,s.Type,c.DisplayImage,s.ConsignorUserId,u.PhoneAreaId ConsignorPhoneAreaId ,u.Phone ConsignorPhone,u.`Name` ConsignorName
                FROM store_order s 
                LEFT JOIN commodity as c on s.CommodityId=c.Id 
                LEFT JOIN user_info as u ON s.ConsignorUserId=u.id
                WHERE s.BuyUserId={0}
                Order BY s.OrderTime Desc " + dataPagingModelGet.LimitString(), userId);
            return MySqlHelper.Single.ExecuteDataSet(strSql);
        }

        /// <summary>
        /// 查询订单详情
        /// </summary>
        /// <returns></returns>
        public DataTable QueryStoreOrderInfo(int id)
        {
            string strSql =
                string.Format(
                    "SELECT s.Id,s.OrderNo,s.CommodityId,s.BuyUserId,c.`Name` CommodityName,s.Count,s.UnitPrice,s.TotalPrice,date_format(s.OrderTime, '%Y-%m-%d %H:%i:%s') OrderTime,IF(s.State=0 and TIMESTAMPDIFF(SECOND,s.OrderTime,NOW())>24*60*60,'2',s.State) State,s.Type,c.DisplayImage,c.PurchaseRestrictionCount,s.ConsignorUserId FROM store_order s LEFT JOIN commodity as c on s.CommodityId=c.Id WHERE s.Id ={0}",
                    id);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 查询订单详情
        /// </summary>
        /// <returns></returns>
        public DataTable QueryStoreOrderInfo(string orderNo)
        {
            string strSql =
                string.Format(
                    "SELECT s.Id,s.OrderNo,s.CommodityId,c.`Name` CommodityName,s.BuyUserId,s.Count,s.UnitPrice,s.TotalPrice,date_format(s.OrderTime, '%Y-%m-%d %H:%i:%s') OrderTime,IF(s.State=0 and TIMESTAMPDIFF(SECOND,s.OrderTime,NOW())>24*60*60,'2',s.State) State,s.Type,c.DisplayImage,c.PurchaseRestrictionCount,s.ConsignorUserId FROM store_order s LEFT JOIN commodity as c on s.CommodityId=c.Id WHERE s.OrderNo ='{0}'",
                    orderNo);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 查询支付明细
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPayDetail()
        {
            string strSql = "SELECT p.Id,p.OrderId,p.CurrencyId,c.`Code` CurrencyCode,c.Caption CurrencyCaption,p.Amount FROM store_order_pay_detail p LEFT JOIN currency_info as c ON p.CurrencyId=c.Id";
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 查询支付明细
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public DataTable QueryPayDetail(int orderId)
        {
            string strSql =
                string.Format(
                    "SELECT p.Id,p.OrderId,p.CurrencyId,c.`Code` CurrencyCode,c.Caption CurrencyCaption,p.Amount FROM store_order_pay_detail p LEFT JOIN currency_info as c ON p.CurrencyId=c.Id WHERE p.OrderId ={0}", orderId);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <returns></returns>
        public int InsertStoreOrderInfo(string orderNo, int commodityId, decimal amount, decimal unitPrice, decimal totalPrice, string type, string orderTime, int buyUserId, int consignorUserId)
        {
            string strSql = string.Format("INSERT INTO store_order(OrderNo,CommodityId,Count,UnitPrice,TotalPrice,OrderTime,State,Type,BuyUserId,ConsignorUserId) VALUES('{0}',{1},{2},{3},{4},'{5}','0','{6}',{7},{8}); SELECT LAST_INSERT_ID() as Id;", orderNo, commodityId, amount, unitPrice, totalPrice, orderTime, type, buyUserId, consignorUserId);
            return Convert.ToInt32(MySqlHelper.Single.ExecuteScalar(strSql));
        }

        /// <summary>
        /// 检查订单状态
        /// </summary>
        /// <returns></returns>
        public DataTable CheckStoreOrderState(string orderNo)
        {
            var strSql = string.Format("select IF(o.State=0 and TIMESTAMPDIFF(SECOND,o.OrderTime,NOW())>24*60*60,'2',o.State) State,u.VipId,v.Rank,v.`Name` VipName from store_order o  LEFT JOIN user_info as u ON o.BuyUserId =u.Id LEFT JOIN vip_rank_info as v ON v.Id =u.VipId WHERE o.OrderNo='{0}'", orderNo);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateStoreOrderState(int orderId, string state)
        {
            var strSql = string.Format("update store_order set state ='{0}' ,buyTime=now() where Id={1}", state, orderId);
            var obj = MySqlHelper.Single.ExecuteNonQuery(strSql);
            return obj == 1;
        }
        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateStoreOrderState(string orderNo, string state)
        {
            var strSql = string.Format("update store_order set state ='{0}' ,buyTime=now() where OrderNo='{1}'", state, orderNo);
            var obj = MySqlHelper.Single.ExecuteNonQuery(strSql);
            return obj == 1;
        }

        public bool InsertPayDetail(int orderId, int currencyId, decimal amount)
        {
            var strSql = string.Format("insert into store_order_pay_detail(OrderId,CurrencyId,Amount)values({0},{1},{2})", orderId, currencyId, amount);
            var obj = MySqlHelper.Single.ExecuteNonQuery(strSql);
            return obj == 1;
        }
    }
}
