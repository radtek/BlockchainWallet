using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.Agent
{
    public class CloudMinerProductionDal
    {
        /// <summary>
        /// 查询转账订单记录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dataPagingModelGet"></param>
        /// <returns></returns>
        public DataSet QueryCloudMinerProductionRecord(int userId, DataPagingModelGet dataPagingModelGet)
        {
            string strSql = string.Format(@"SELECT SQL_CALC_FOUND_ROWS cmd.Id,date_format(cmd.ProductionTime, '%Y-%m-%d') ProductionTime,ui.Nickname UserNickname,c.`Name` CommodityName
                                            FROM cloud_miner_production_record cmd
                                            LEFT JOIN user_cloud_miner as ucm ON cmd.ucmId=ucm.id
                                            LEFT JOIN commodity as c ON c.id=ucm.commodityId
                                            LEFT JOIN user_info as ui ON ucm.UserId=ui.id
											WHERE cmd.UserId={0}
                                            ORDER BY cmd.ProductionTime DESC" + dataPagingModelGet.LimitString(), userId);
            return MySqlHelper.Single.ExecuteDataSet(strSql);
        }

        /// <summary>
        /// 查询转账订单明细
        /// </summary>
        /// <param name="orderIds"></param>
        /// <returns></returns>
        public DataTable QueryCloudMinerProductionDetail(string orderIds)
        {
            string strSql = string.Format(@"SELECT Id,OrderId,CurrencyId,Amount 
                                            FROM cloud_miner_production_detail 
                                            WHERE OrderId in ({0})", orderIds);
            return MySqlHelper.Single.ExecuteDataTable(strSql);
        }
    }
}
