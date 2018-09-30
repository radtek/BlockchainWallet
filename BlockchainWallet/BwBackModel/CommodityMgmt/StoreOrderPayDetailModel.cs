using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.CommodityMgmt
{
    public class StoreOrderPayDetailModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 通证ID
        /// </summary>
        public int CurrencyId { get; set; }
        /// <summary>
        /// 通证代码
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// 通证名称
        /// </summary>
        public string CurrencyCaption { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Amount { get; set; }
    }
}
