using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.CustomerServiceSystem.ReceivablesInformation
{
    public class BankCodeInfoModelGet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }

    public class BankCodeInfoModelResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string BankCode { get; set; }
        public string OpeningBank { get; set; }
        public string Address { get; set; }
        public string SubmitTime { get; set; }
        public string EmployeeId { get; set; }
        public string DisposeTime { get; set; }
        /// <summary>
        /// 处理结果:0等待中 1通过 2不通过
        /// </summary>
        public string State { get; set; }
        public string Remark { get; set; }

    }
    public class UploadBankCodeInfoModelGet
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string BankCode { get; set; }
        public string OpeningBank { get; set; }
        public string Address { get; set; }
        public string PayPassowrd { get; set; }
    }
}