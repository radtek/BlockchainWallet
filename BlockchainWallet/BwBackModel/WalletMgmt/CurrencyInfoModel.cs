using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.WalletMgmt
{
    public class CurrencyInfoModelSend
    {
    }
    public class CurrencyInfoModelGet
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 币名称
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 合约地址
        /// </summary>
        public string ContractAddress { get; set; }
        /// <summary>
        /// 发行总量
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 当前价格
        /// </summary>
        public decimal CurrentAmount { get; set; }


    }
}
