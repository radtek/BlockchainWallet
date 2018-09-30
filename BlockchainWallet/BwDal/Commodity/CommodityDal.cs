                                                                                                                                                                          using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.Commodity
{
    public class CommodityDal
    {
        /// <summary>
        /// 商品基本信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCommodityInfo(string state, string type)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT c.ID,c.`Name`,date_format(c.PutawayTime, '%Y-%m-%d %H:%i:%s') PutawayTime,date_format(c.SoldOutTime, '%Y-%m-%d %H:%i:%s') SoldOutTime,c.State,c.Type FROM  commodity c  WHERE 1=1 ");
            if (state != "-1")
            {
                SqlHelper.AppendAndWhereEqual("c.State", state, ref stringBuilder);
            }
            if (type != "-1")
            {
                SqlHelper.AppendAndWhereEqual("c.Type", type, ref stringBuilder);
            }
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }

        /// <summary>
        /// 购买价格明细
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPriceDetail()
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT * FROM price_detail");
            return MySqlHelper.Single.ExecuteDataTable(stringBuilder.ToString());
        }




    }
}
