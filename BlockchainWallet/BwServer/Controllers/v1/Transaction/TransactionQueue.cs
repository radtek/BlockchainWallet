using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using BwDal.Commodity;

namespace BwServer.Controllers.v1.Transaction
{
    public class TransactionQueue
    {
        private static readonly ConcurrentQueue<TransactionInfo> ConcurrentQueue = new ConcurrentQueue<TransactionInfo>();
        //private StoreOrderDal _storeOrderDal = new StoreOrderDal();
        /// <summary>
        /// 添加序列
        /// </summary>
        /// <returns></returns>
        public bool AddQueue(TransactionInfo transactionInfo)
        {
            ConcurrentQueue.Enqueue(transactionInfo);
            return true;
        }
        /// <summary>
        /// 读取开始处一行数据并移除
        /// </summary>
        /// <returns></returns>
        public TransactionInfo ReadQueue()
        {
            TransactionInfo transactionInfo;
            while (true)
            {
                bool b = ConcurrentQueue.TryDequeue(out transactionInfo);
                if (b) break;
                Thread.Sleep(100);
            }
            return transactionInfo;
        }
    }

}