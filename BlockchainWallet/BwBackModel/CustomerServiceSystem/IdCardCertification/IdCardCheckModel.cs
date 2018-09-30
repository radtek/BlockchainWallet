using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.CustomerServiceSystem.IdCardCertification
{
    public class IdCardCheckModelSend
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
