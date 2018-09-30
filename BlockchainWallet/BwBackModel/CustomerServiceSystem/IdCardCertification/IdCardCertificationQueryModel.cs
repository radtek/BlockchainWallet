using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.CustomerServiceSystem.IdCardCertification
{
    public class IdCardCertificationModelSend
    {
        public int Id { get; set; }
    }
    public class IdCardCertificationModelGet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string IdCard { get; set; }
        public string FrontImage { get; set; }
        public string ReverseImage { get; set; }
        public string SubmitTime { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DisposeTime { get; set; }
        /// <summary>
        /// 处理结果 0等待中 1通过 2不通过
        /// </summary>
        public string State { get; set; }

        public string StateCaption
        {
            get
            {
                switch (State)
                {
                    case "0":
                        return "待处理";
                    case "1":
                        return "通过";
                }
                return "不通过";
            }
        }

        public string Remark { get; set; }
    }
}
