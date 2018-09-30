using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using BwCommon.Log;
using BwDal.Agent;
using BwDal.Commodity;
using BwDal.User;
using BwServer.Models.v1.Commodity.StoreOrder;

namespace BwServer.Controllers.v1.Transaction
{
    /// <summary>
    /// 交易服务
    /// </summary>
    public class TransactionService
    {
        private static readonly TransactionQueue TransactionQueue = new TransactionQueue();
        private static readonly StoreOrderDal StoreOrderDal = new StoreOrderDal();
        private static readonly UserCloudMinerDal UserCloudMinerDal = new UserCloudMinerDal();
        private static readonly UserInfoDal UserInfoDal = new UserInfoDal();
        private static readonly VipInfoDal VipInfoDal = new VipInfoDal();
        /// <summary>
        /// 添加商城自营交易
        /// </summary>
        /// <param name="payDetailModelGet"></param>
        /// <returns></returns>
        public static bool AddStoreOrder(PayDetailModelGet payDetailModelGet)
        {
            try
            {
                TransactionInfo transactionInfo = new TransactionInfo();
                transactionInfo.PayeeUserId = 5;
                DataTable dt = StoreOrderDal.QueryStoreOrderInfo(payDetailModelGet.OrderNo);
                if (dt.Rows.Count != 1) return false;
                decimal amount = Convert.ToDecimal(dt.Rows[0]["TotalPrice"]);
                if (amount != payDetailModelGet.PayDetailModels.Sum(n => n.Amount))
                {
                    StoreOrderDal.UpdateStoreOrderState(transactionInfo.OrderId, "5");
                    return false;
                }
                transactionInfo.PayUserId = Convert.ToInt32(dt.Rows[0]["BuyUserId"]);
                int consignorUserId = Convert.ToInt32(dt.Rows[0]["ConsignorUserId"]);
                transactionInfo.Type = "00";

                transactionInfo.OrderId = Convert.ToInt32(dt.Rows[0]["Id"]);
                int commodityId = Convert.ToInt32(dt.Rows[0]["CommodityId"]);
                int count = Convert.ToInt32(dt.Rows[0]["Count"]);
                if (count < 1)
                {
                    throw new Exception("订单中云矿机数量有误 OrderId：" + transactionInfo.OrderId);
                }

                transactionInfo.No = GetTransactionNo(transactionInfo.Type, payDetailModelGet.UserId);
                transactionInfo.ExectionedAction += (state) =>
                {
                    StoreOrderDal.UpdateStoreOrderState(transactionInfo.OrderId, state);
                    if (state == "1")
                    {
                        UserCloudMinerDal.InsertUserCloudMiner(transactionInfo.OrderId, payDetailModelGet.OrderNo,
                            transactionInfo.No, consignorUserId, commodityId, count);
                        foreach (var item in payDetailModelGet.PayDetailModels)
                        {
                            StoreOrderDal.InsertPayDetail(transactionInfo.OrderId, item.CurrencyId, item.Amount);
                        }
                        DataTable dtUserVipInfo = UserInfoDal.QueryUserVipInfo(consignorUserId);
                        if (dtUserVipInfo.Rows.Count == 1)
                        {
                            //用户当前的VIP等级
                            int userRank = Convert.ToInt32(dtUserVipInfo.Rows[0]["Rank"]);
                            DataTable dtVipUrCloudminerInfo = VipInfoDal.QueryVipUrCloudminerUpgrade(commodityId);
                            if (dtVipUrCloudminerInfo.Rows.Count <= 0) return;
                            int commodityUrRank = Convert.ToInt32(dtVipUrCloudminerInfo.Rows[0]["Rank"]);

                            if (userRank < commodityUrRank)
                            {
                                int commodityUrVipId = Convert.ToInt32(dtVipUrCloudminerInfo.Rows[0]["Id"]);
                                UserInfoDal.UpdateUserVip(consignorUserId, commodityUrVipId);
                            }
                        }
                    }
                };

                foreach (var item in payDetailModelGet.PayDetailModels)
                {
                    LoansTransaction loansTransaction = new LoansTransaction();
                    loansTransaction.CurrencyId = item.CurrencyId;
                    loansTransaction.Amount = item.Amount;
                    transactionInfo.LoansTransactions.Add(loansTransaction);
                    BorrowTransaction borrowTransaction = new BorrowTransaction();
                    borrowTransaction.CurrencyId = item.CurrencyId;
                    borrowTransaction.Amount = item.Amount;
                    transactionInfo.BorrowTransactions.Add(borrowTransaction);
                }
                if (TransactionQueue.AddQueue(transactionInfo))
                {
                    StoreOrderDal.UpdateStoreOrderState(transactionInfo.OrderId, "4");
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                LogHelper.error("添加支付订单时错误：" + exception.Message);
                return false;
            }
        }

        private static readonly CloudMinerProductionDal_ CloudMinerProductionDal = new CloudMinerProductionDal_();
        /// <summary>
        /// 添加矿机运行个人产币拨款
        /// </summary>
        public static bool AddCloudMinerProduce(string type, int userId, int orderId, List<BorrowTransaction> borrowTransactions)
        {
            TransactionInfo transactionInfo = new TransactionInfo();
            transactionInfo.No = GetTransactionNo(type, userId);
            transactionInfo.Type = type;
            transactionInfo.PayUserId = 2;
            transactionInfo.PayeeUserId = userId;
            transactionInfo.OrderId = orderId;

            //借方进账明细
            foreach (var item in borrowTransactions)
            {
                BorrowTransaction borrowTransaction = new BorrowTransaction();
                borrowTransaction.Amount = item.Amount;
                borrowTransaction.CurrencyId = item.CurrencyId;
                transactionInfo.BorrowTransactions.Add(borrowTransaction);
            }
            //贷方支付明细
            foreach (var borrowTransaction in borrowTransactions)
            {
                LoansTransaction loansTransaction = new LoansTransaction();
                loansTransaction.Amount = borrowTransaction.Amount;
                loansTransaction.CurrencyId = borrowTransaction.CurrencyId;
                //loansTransaction.LoansUserId = 2;
                transactionInfo.LoansTransactions.Add(loansTransaction);
            }

            transactionInfo.ExectionedAction = state =>
            {
                CloudMinerProductionDal.UpdateCloudMinerProductionRecord(orderId, state);
            };
            while (true)
            {
                if (TransactionQueue.AddQueue(transactionInfo)) break;
                Thread.Sleep(100);
            }
            return true;
        }

        /// <summary>
        /// 添加矿机运行分销拨款
        /// </summary>
        /// <param name="type"></param>
        public static bool AddCloudMinerProduceDistribution(string type, int userId, int orderId, List<BorrowTransaction> borrowTransactions)
        {
            TransactionInfo transactionInfo = new TransactionInfo();
            transactionInfo.No = GetTransactionNo(type, userId);
            transactionInfo.Type = type;
            transactionInfo.PayUserId = 3;
            transactionInfo.PayeeUserId = userId;
            transactionInfo.OrderId = orderId;
            //借方进账明细
            foreach (var item in borrowTransactions)
            {
                BorrowTransaction borrowTransaction = new BorrowTransaction();
                borrowTransaction.Amount = item.Amount;
                borrowTransaction.CurrencyId = item.CurrencyId;
                transactionInfo.BorrowTransactions.Add(borrowTransaction);
            }
            //贷方支付明细
            foreach (var borrowTransaction in borrowTransactions)
            {
                LoansTransaction loansTransaction = new LoansTransaction();
                loansTransaction.Amount = borrowTransaction.Amount;
                loansTransaction.CurrencyId = borrowTransaction.CurrencyId;
                //loansTransaction.LoansUserId = 3;
                transactionInfo.LoansTransactions.Add(loansTransaction);
            }

            transactionInfo.ExectionedAction = state =>
            {
                CloudMinerProductionDal.UpdateCloudMinerProductionRecord(orderId, state);
            };

            while (true)
            {
                if (TransactionQueue.AddQueue(transactionInfo)) break;
                Thread.Sleep(100);
            }
            return true;
        }

        #region 订单号
        private static readonly object _objNoLock = new object();
        private static string _lastNo = string.Empty;
        static readonly Random Random = new Random((int)DateTime.Now.Ticks);
        private static string GetTransactionNo(string type, int userId)
        {
            try
            {
                lock (_objNoLock)
                {
                    while (true)
                    {
                        Thread.Sleep(5);
                        DateTime dateTime = DateTime.Now;
                        string tLastNo = "10" + Random.Next(10, 99) + dateTime.ToString("yyyyMMdd") + type + dateTime.ToString("HHmmssffff") + Random.Next(10, 99) + userId;
                        if (tLastNo != _lastNo)
                        {
                            _lastNo = tLastNo;
                            break;
                        }
                    }
                    return _lastNo;
                }
            }
            catch (Exception exception)
            {
                LogHelper.error("获取订单号出错：" + exception.Message);
                throw exception;
            }
        }
        #endregion
    }
}