using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;

namespace BwServer.Models.v1.System
{
    public class SystemMaintenanceModelGet_ : HeadModelGet
    {
        public int Id { get; set; }
        public string MaintenanceTimeBegin { get; set; }
        public string MaintenanceTimeEnd { get; set; }
        public int EmployeeId { get; set; }
    }
    public class SystemMaintenanceModelResult_
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
    }
}