using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.SystemMgmt
{
    public class AnnouncementInfoModelSend
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int PublishEmployeeId { get; set; }
        public string Content { get; set; }
        public string PublishTime { get; set; }
        public string DisplayTime { get; set; }
        public int UpdateEmployeeId { get; set; }
    }

    public class AnnouncementInfoModelGet
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int PublishEmployeeId { get; set; }
        public string PublishEmployeeName { get; set; }
        public string Content { get; set; }
        public string PublishTime { get; set; }
        public string DisplayTime { get; set; }
        public int UpdateEmployeeId { get; set; }
        public string UpdateTime { get; set; }


    }
}
