using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.Agent
{
    public class CloudMinerDistributionDal_
    {
        public DataSet QueryCloudMinerDistribution(int userId, string distributionDate, DataPagingModelGet dataPagingModelGet)
        {
            StringBuilder sbWhere = new StringBuilder();
            if (userId > 0)
            {
                sbWhere.Append(string.Format(" AND r.DistributionId ={0} ", userId));
            }
            if (!string.IsNullOrEmpty(distributionDate))
            {
                sbWhere.Append(string.Format(" AND r.DistributionTime >= '{0}' AND r.DistributionTime<'{1}' ", Convert.ToDateTime(distributionDate).ToString("yyyy-MM-dd"), Convert.ToDateTime(distributionDate).AddDays(1).ToString("yyyy-MM-dd")));
            }
            string sqlStr =
                string.Format(
                    @"SELECT SQL_CALC_FOUND_ROWS date_format(r.DistributionTime, '%Y-%m-%d') DistributionTime,r.Id,ucm.Id UcmId,c.`Name` CommodityName, date_format(ucm.BuyTime , '%Y-%m-%d') BuyTime ,cd.Amount ,cd.QQX ,cd.QQY ,cd.QQL,ucm.UserId FansUserId,f.Nickname FansNickname,f.PhoneAreaId FansPhoneAreaId,f.Phone FansPhone,f.Name FansName
									FROM cloud_miner_distribution_record  r 
									LEFT JOIN commodity as c ON r.CommodityId =c.Id
									LEFT JOIN user_cloud_miner as ucm ON  ucm.id=r.UcmId 
									LEFT JOIN user_info as f ON f.id=ucm.UserId
									LEFT JOIN 
									(
									SELECT d.OrderId,
											SUM(d.Amount) Amount,
											SUM(CASE WHEN d.CurrencyID=0 THEN
											d.Amount ELSE 0 END )QQX, 
											SUM(CASE WHEN d.CurrencyID=1 THEN
											d.Amount ELSE 0 END) QQY,
											SUM(case WHEN d.CurrencyID=2 THEN
											d.Amount ELSE 0 END) QQL
									FROM cloud_miner_distribution_detail d
									GROUP BY d.OrderId
									) cd ON cd.OrderId=r.id
                                    where 1=1 {0}
									Order by r.DistributionTime DESC,ucm.UserId ASC " + dataPagingModelGet.LimitString(), sbWhere);
            return MySqlHelper.Single.ExecuteDataSet(sqlStr);
        }

        public DataSet QueryUserCloudMinerDistribution(DataPagingModelGet dataPagingModelGet)
        {
            string sqlStr =
                string.Format(
                    @"SELECT SQL_CALC_FOUND_ROWS date_format(r.DistributionTime, '%Y-%m-%d') DistributionTime,sum(cd.Amount) Amount ,sum(cd.QQX) QQX,sum(cd.QQY) QQY,sum(cd.QQL) QQL,r.DistributionId UserId,u.Nickname,u.PhoneAreaId,u.Phone,u.Name
                        FROM cloud_miner_distribution_record  r 
                        LEFT JOIN commodity as c ON r.CommodityId =c.Id
                        LEFT JOIN user_cloud_miner as ucm ON  ucm.id=r.UcmId 
                        LEFT JOIN user_info as u ON u.id = r.DistributionId
                        LEFT JOIN 
                        (
                        SELECT d.OrderId,
		                        SUM(d.Amount) Amount,
		                        SUM(CASE WHEN d.CurrencyID=0 THEN
		                        d.Amount ELSE 0 END )QQX, 
		                        SUM(CASE WHEN d.CurrencyID=1 THEN
		                        d.Amount ELSE 0 END) QQY,
		                        SUM(case WHEN d.CurrencyID=2 THEN
		                        d.Amount ELSE 0 END) QQL
                        FROM cloud_miner_distribution_detail d
                        GROUP BY d.OrderId
                        ) cd ON cd.OrderId=r.id
                        GROUP BY date_format(r.DistributionTime, '%Y-%m-%d'),r.DistributionId,u.Nickname,u.PhoneAreaId,u.Phone
                        Order by r.DistributionTime DESC,ucm.UserId ASC " + dataPagingModelGet.LimitString());
            return MySqlHelper.Single.ExecuteDataSet(sqlStr);
        }
    }
}
