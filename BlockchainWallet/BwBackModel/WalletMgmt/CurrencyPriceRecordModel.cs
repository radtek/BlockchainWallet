using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.WalletMgmt
{
    public class CurrencyPriceRecordModelSend : HeadDataBaseModelSend
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public decimal Price { get; set; }
        public int UpdateEmployeeId { get; set; }
    }
    public class CurrencyPriceRecordModelGet
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCaption { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Price { get; set; }
        public string UpdateTime { get; set; }
        public int UpdateEmployeeId { get; set; }
        public string UpdateEmployeeName { get; set; }
        public string Type { get; set; }
        public string TypeCaption
        {
            get
            {
                return Type == "0" ? "员工修改" : "用户修改";
            }
        }
    }
}
