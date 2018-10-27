using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Transaction
{
    public class TransactionB2CModelGet
    {
        /// <summary>
        /// 支付人公开ID
        /// </summary>
        public string PayOpenId { get; set; }
        /// <summary>
        /// 收款人公开ID
        /// </summary>
        public string PayeeOpenId { get; set; }
        /// <summary>
        /// 收款人公开ID
        /// </summary>
        public int AppId { get; set; }
        /// <summary>
        /// 支付密码
        /// </summary>
        public string PayPassword { get; set; }
        /// <summary>
        /// 外补订单号
        /// </summary>
        public string ExternalOrderNo { get; set; }
        /// <summary>
        /// 外部订单名称
        /// </summary>
        public string ExternalOrderName { get; set; }
        /// <summary>
        /// 外部订单类型 1：商城购物 2：日常消费 3：退款 4：其他
        /// </summary>
        public string ExternalOrderType { get; set; }
        public List<TransactionCurrencyModel> PayCurrencyList = new List<TransactionCurrencyModel>();
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
    public class TransactionB2CModelResult
    {

    }
}