using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwDal.Helper;

namespace BwDal.System
{
    public class SystemMaintenanceDal_
    {
        public DataSet QuerySystemMaintenance(DataPagingModelGet dataPagingModelGet)
        {
            string sqlStr =
                string.Format(
                    @"SELECT SQL_CALC_FOUND_ROWS s.Id,date_format(s.MaintenanceTimeBegin, '%Y-%m-%d %H:%i:%s') MaintenanceTimeBegin,date_format(s.MaintenanceTimeEnd, '%Y-%m-%d %H:%i:%s') MaintenanceTimeEnd,
                    s.InsertEmployeeId,ie.AccountId InsertEmployeeAccountId,ie.Nickname InsertEmployeeNickname,date_format(s.InsertTime, '%Y-%m-%d %H:%i:%s') InsertTime,
                    s.UpdateEmployeeId,ue.AccountId UpdateEmployeeAccountId,ue.Nickname UpdateEmployeeNickname,date_format(s.UpdateTime, '%Y-%m-%d %H:%i:%s') UpdateTime ,s.State
                    FROM system_maintenance s
                    LEFT JOIN employee_info as ie ON s.InsertEmployeeId=ie.ID
                    LEFT JOIN employee_info as ue ON s.UpdateEmployeeId=ue.ID where s.InsertEmployeeId!=6 order by s.InsertTime desc" + dataPagingModelGet.LimitString());
            return MySqlHelper.Single.ExecuteDataSet(sqlStr);
        }

        public DataTable QuerySystemMaintenance()
        {
            string sqlStr = @"SELECT MaintenanceTimeBegin,MaintenanceTimeEnd FROM system_maintenance WHERE MaintenanceTimeEnd>NOW() AND State='0'";
            return MySqlHelper.Single.ExecuteDataTable(sqlStr);
        }

        public int InsertSystemMaintenance(string maintenanceTimeBegin, string maintenanceTimeEnd, int employeeId)
        {
            string sqlStr = string.Format(@"INSERT INTO system_maintenance (MaintenanceTimeBegin,MaintenanceTimeEnd,InsertEmployeeId,InsertTime,State)VALUE('{0}','{1}','{2}',NOW(),'0');SELECT LAST_INSERT_ID() as Id;", maintenanceTimeBegin, maintenanceTimeEnd, employeeId);
            return Convert.ToInt32(MySqlHelper.Single.ExecuteScalar(sqlStr));
        }

        public int UpdateSystemMaintenance(int employeeId, int id)
        {
            string sqlStr = string.Format(@"update system_maintenance SET UpdateEmployeeId={0},UpdateTime=NOW(),State='1' WHERE id={1}", employeeId, id);
            return MySqlHelper.Single.ExecuteNonQuery(sqlStr);
        }
    }
}
