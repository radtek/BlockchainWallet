using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using BwCommon.Log;
using BwDal.Transaction;
using BwDal.Wallet;

namespace BwServer.Controllers.v1.Transaction
{
    /// <summary>
    /// 交易系统
    /// </summary>
    public class TransactionSystem
    {
        #region 单利模式获取对象
        private static TransactionSystem _transactionSystem;

        private TransactionSystem()
        {

        }
        public static TransactionSystem Single
        {
            get { return _transactionSystem ?? (_transactionSystem = new TransactionSystem()); }
        }
        #endregion

        private readonly TransactionQueue _transactionQueue = new TransactionQueue();
        private bool _isRun = false;
        private readonly TransactionServerDal _transactionServerDal = new TransactionServerDal();
        /// <summary>
        /// 开始运行交易服务
        /// </summary>
        /// <param name="taskCount">线程数量</param>
        public void RunTransactionServer(int taskCount)
        {
            if (_isRun) return;
            _isRun = true;
            for (int i = 0; i < taskCount; i++)
            {
                Task.Factory.StartNew(Transaction);
            }
        }
        /// <summary>
        /// 交易
        /// </summary>
        public void Transaction()
        {
            try
            {
                while (true)
                {
                    TransactionInfo transactionInfo = _transactionQueue.ReadQueue();
                    if (transactionInfo == null)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    List<TransactionServerDal.PayCurrencyEntity> borrowInfoList = new List<TransactionServerDal.PayCurrencyEntity>();
                    List<TransactionServerDal.PayCurrencyEntity> loansInfoEntities = new List<TransactionServerDal.PayCurrencyEntity>();
                    foreach (var borrowTransaction in transactionInfo.BorrowTransactions)
                    {
                        TransactionServerDal.PayCurrencyEntity borrowInfoEntity = new TransactionServerDal.PayCurrencyEntity();
                        borrowInfoEntity.CurrencyId = borrowTransaction.CurrencyId;
                        borrowInfoEntity.Amount = borrowTransaction.Amount;
                        borrowInfoList.Add(borrowInfoEntity);
                    }
                    foreach (var loansTransaction in transactionInfo.LoansTransactions)
                    {
                        TransactionServerDal.PayCurrencyEntity loansInfoEntity = new TransactionServerDal.PayCurrencyEntity();
                        loansInfoEntity.CurrencyId = loansTransaction.CurrencyId;
                        loansInfoEntity.Amount = loansTransaction.Amount;
                        loansInfoEntities.Add(loansInfoEntity);
                    }
                    string transactioned = _transactionServerDal.RunTransaction(transactionInfo.No, transactionInfo.OrderId, transactionInfo.PayUserId,
                        transactionInfo.PayeeUserId, borrowInfoList, loansInfoEntities, transactionInfo.Type);
                    //LogHelper.info("交易记录:" + transactionInfo.OrderId + "                     交易结果：" + transactioned);
                    transactionInfo.ExectionedAction(transactioned);
                }
            }
            catch (Exception exception)
            {
                LogHelper.error("交易服务出现异常：" + exception);
            }
        }
    }

}