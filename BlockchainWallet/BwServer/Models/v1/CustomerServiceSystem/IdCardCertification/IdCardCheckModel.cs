using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.CustomerServiceSystem.IdCardCertification
{
    /// <summary>
    /// 实名审核
    /// </summary>
    public class IdCardCheckModelGet
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string State { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string IdCard { get; set; }
        public string Remark { get; set; }

    }
}