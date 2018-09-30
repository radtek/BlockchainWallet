using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Controllers.v1.Transaction
{
    /// <summary>
    /// 交易信息
    /// </summary>
    public class TransactionInfo
    {
        /// <summary>
        /// 单号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 支付人ID
        /// </summary>
        public int PayUserId { get; set; }
        /// <summary>
        /// 收款人ID
        /// </summary>
        public int PayeeUserId { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        public string TransactionTime { get; set; }
        /// <summary>
        /// 交易类型：00购物 01交易 02转账 03产币 04分润
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 执行回调  int:0 成功 -1失败  1 可用余额不足
        /// </summary>
        public Action<string> ExectionedAction;
        /// <summary>
        /// 借款交易
        /// </summary>
        public List<BorrowTransaction> BorrowTransactions = new List<BorrowTransaction>();
        /// <summary>
        /// 贷款交易
        /// </summary>
        public List<LoansTransaction> LoansTransactions = new List<LoansTransaction>();
    }
    /// <summary>
    /// 借款交易
    /// </summary>
    public class BorrowTransaction
    {
        public int CurrencyId { get; set; }

        public decimal Amount { get; set; }
    }
    /// <summary>
    /// 贷款交易
    /// </summary>
    public class LoansTransaction
    {
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
    }
}