using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.Commodity
{
    public class UserCloudMinerDal_
    {
        /// <summary>
        /// 查询用户云矿机
        /// </summary>
        /// <returns></returns>
        public DataSet QueryUserCloudMiner(DataPagingModelGet dataPagingModel)
        {
            string strSql =
                string.Format(
                    @"SELECT SQL_CALC_FOUND_ROWS ucm.Id,ucm.OrderId,ucm.OrderNo,ucm.UserId,u.PhoneAreaId,u.Phone,u.`Name` UserName,ucm.CommodityId,c.`Name` CommodityName,cms.ProductionCycle,cms.ProductionAmount,c.Amount,date_format(ucm.BuyTime,'%Y-%m-%d %H:%m:%s') BuyTime,ucm.ProductionCount,o.Type,ucm.State
                        FROM user_cloud_miner ucm 
                        LEFT JOIN user_info as u ON ucm.UserId =u.id
                        LEFT JOIN commodity AS c ON ucm.CommodityId=c.Id
                        LEFT JOIN store_order as o ON o.id=ucm.OrderId
                        LEFT JOIN cloud_miner_specification as cms ON c.Id=cms.CommodityId 
                        ORDER BY ucm.BuyTime DESC,ucm.UserId 
                         " + dataPagingModel.LimitString());
            return MySqlHelper.Single.ExecuteDataSet(strSql);
        }
    }
}
