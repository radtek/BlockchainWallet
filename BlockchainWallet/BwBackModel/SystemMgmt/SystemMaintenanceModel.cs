using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.SystemMgmt
{
    public class SystemMaintenanceModelSend : HeadDataBaseModelSend
    {
        public int Id { get; set; }
        public string MaintenanceTimeBegin { get; set; }
        public string MaintenanceTimeEnd { get; set; }
        public int EmployeeId { get; set; }
    }
    public class SystemMaintenanceModelGet
    {
        public int Id { get; set; }
        public string MaintenanceTimeBegin { get; set; }
        public string MaintenanceTimeEnd { get; set; }
        public int InsertEmployeeId { get; set; }
        public string InsertEmployeeAccountId { get; set; }
        public string InsertEmployeeNickname { get; set; }
        public string InsertTime { get; set; }
        public int UpdateEmployeeId { get; set; }
        public string UpdateEmployeeAccountId { get; set; }
        public string UpdateEmployeeNickname { get; set; }
        public string UpdateTime { get; set; }
        public string State { get; set; }

        public string StateCaption
        {
            get
            {
                switch (State)
                {
                    case "0":
                        return "维护";
                    case "1":
                        return "撤销";
                    default:
                        return "状态异常";
                }
            }
        }
    }
}
