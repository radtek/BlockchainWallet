using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using BwCommon.ContentConvert;
using BwCommon.Log;
using BwDal.Agent;
using BwDal.Commodity;
using BwDal.DistributionMechanism;
using BwDal.Transaction;
using BwDal.User;
using BwDal.Wallet;
using BwServer.Controllers.v1.Transaction;
using BwServer.Models.v1.Commodity.CloudMinerInfo;
using Timer = System.Timers.Timer;

namespace BwServer.Controllers.v1.Agent
{
    /// <summary>
    /// 云矿机运行服务
    /// </summary>
    public class CloudMinerServer
    {
        #region 单利模式获取对象
        private static CloudMinerServer _cloudMinerServer;
        private CloudMinerServer() { }

        public static CloudMinerServer Single
        {
            get { return _cloudMinerServer ?? (_cloudMinerServer = new CloudMinerServer()); }
        }
        #endregion
        /// <summary>
        /// 矿机运行状态 ：0 未运行 1 矿机运行中   2 正常结束  其他 错误异常信息
        /// </summary>
        public string State = "0";
        private readonly CloudMinerDal _cloudMinerDal = new CloudMinerDal();
        private readonly UserCloudMinerDal _userCloudMinerDal = new UserCloudMinerDal();
        private readonly CloudMinerDistributionMechanismDal _cloudMinerDistributionMechanismDal = new CloudMinerDistributionMechanismDal();
        private readonly CloudMinerProductionDal_ _cloudMinerProductionDal = new CloudMinerProductionDal_();
        private readonly VipInfoDal _vipInfoDal = new VipInfoDal();
        private readonly FansDal _fansDal = new FansDal();
        //private Timer _timer = null;
        private static readonly object _objLock = new object();

        //private static bool _runState = false;
        //public void StartListenServer()
        //{
        //    if (_timer != null) return;
        //    _timer = new Timer();
        //    _timer.Interval = 3000;
        //    _timer.Elapsed += (sender, e) =>
        //    {
        //        DateTime dtDateTime = DateTime.Now;
        //        _timer.Interval = 3000;
        //        if (dtDateTime.Hour == 3 && dtDateTime.Minute == 0 && dtDateTime.Second > 1 &&
        //            dtDateTime.Second < 5)
        //        {
        //            lock (_objLock)
        //            {
        //                if (_runState)
        //                {
        //                    return;
        //                }
        //                _runState = true;
        //                _timer.Interval = (DateTime.Now.AddDays(1) - DateTime.Now).TotalMilliseconds - 30 * 60 * 1000;
        //            }
        //            LogHelper.info("矿机开始运行:" + dtDateTime.ToString("yyyy-MM-dd HH:mm:ss:ffff"));
        //            try
        //            {
        //                RunCloudMinerServer();
        //            }
        //            catch (Exception exception)
        //            {
        //                LogHelper.error("矿机运行时出现未知错误：" + exception.Message);
        //            }
        //            _runState = false;
        //            LogHelper.info("矿机结束运行:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"));
        //        }
        //    };
        //    _timer.Enabled = true;
        //    _timer.AutoReset = true;
        //    _timer.Start();
        //    LogHelper.info("开启矿机服务：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //}

        public async void StartListenServer()
        {
            LogHelper.info("矿机开始运行:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"));
            try
            {
                State = "1";
                await Task.Factory.StartNew(RunCloudMinerServer);
            }
            catch (Exception e)
            {
                LogHelper.error(e.Message);
                State = e.Message;
            }

            LogHelper.info("矿机结束运行:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"));
        }

        /// <summary>
        /// 矿机产币和分润 
        /// </summary>
        private void RunCloudMinerServer()
        {
            //处查询矿机产币比例
            DataTable dtCloudMinerManufacture = _cloudMinerDal.QueryCloudMinerManufacture();
            IList<CloudMinerManufactureModelResult> cloudMinerManufactureModelResults =
                ModelConvertHelper<CloudMinerManufactureModelResult>.ConvertToModel(dtCloudMinerManufacture);
            //查询运行中的矿机
            DataTable dtRuningCloudMiner = _userCloudMinerDal.QueryRuningCloudMiner();
            if (dtRuningCloudMiner.Rows.Count <= 0)
            {
                LogHelper.warn("云矿机运行：矿机数量为空" + DateTime.Now);
                return;
            }
            IList<RunCloudMinerModel> runCloudMinerModels = ModelConvertHelper<RunCloudMinerModel>.ConvertToModel(dtRuningCloudMiner);
            //获取VIP等级
            DataTable dt = _vipInfoDal.QueryVipUrCloudminerDistribution();
            IList<VipUrCloudminerDistribution> vipUrCloudminerDistributions =
                ModelConvertHelper<VipUrCloudminerDistribution>.ConvertToModel(dt);
            //查询每代分销比例
            DataTable dtDistributionMechanism = _cloudMinerDistributionMechanismDal.QueryDistributionMechanism();
            IList<DistributionMechanismCloudMinerModel> distributionMechanismCloudMinerModels = ModelConvertHelper<DistributionMechanismCloudMinerModel>.ConvertToModel(dtDistributionMechanism);
            //收款信息
            List<TransactionPayDetail> borrowTransactions = new List<TransactionPayDetail>();
            List<TransactionServerDal.PayCurrencyEntity> borrowInfoEntities = new List<TransactionServerDal.PayCurrencyEntity>();
            List<TransactionPayDetail> dBorrowTransactions = new List<TransactionPayDetail>();
            List<TransactionServerDal.PayCurrencyEntity> dBorrowInfoEntities = new List<TransactionServerDal.PayCurrencyEntity>();
            //循环遍历在运行的云矿机
            foreach (RunCloudMinerModel runCloudMinerModel in runCloudMinerModels)
            {
                _userCloudMinerDal.RunUserCloudMiner(runCloudMinerModel.Id);
                if (runCloudMinerModel.ProductionCount == 149)
                {
                    _userCloudMinerDal.UpdateUserCloudMinerState(runCloudMinerModel.Id, "1");
                }

                DateTime buyDateTime;
                try
                {
                    buyDateTime = Convert.ToDateTime(runCloudMinerModel.BuyTime);
                }
                catch (Exception)
                {
                    continue;
                }
                int runDays = (DateTime.Now.Date - buyDateTime.Date).Days;
                if (runCloudMinerModel.ProductionCycle == runDays + 1)
                {
                    _userCloudMinerDal.UpdateUserCloudMinerState(runCloudMinerModel.Id, "1");
                }
                if (runCloudMinerModel.ProductionCycle <= runDays)
                {
                    _userCloudMinerDal.UpdateUserCloudMinerState(runCloudMinerModel.Id, "1");
                    continue;
                }

                #region 产币
                borrowTransactions.Clear();
                borrowInfoEntities.Clear();
                //循环遍历云矿机产币比例（针对拥有者）
                foreach (var cloudMinerModel in cloudMinerManufactureModelResults.Where(n => n.CommodityId == runCloudMinerModel.CommodityId))
                {
                    if (cloudMinerModel.Amount <= 0) continue;

                    TransactionPayDetail borrowTransaction = new TransactionPayDetail();
                    borrowTransaction.CurrencyId = cloudMinerModel.CurrencyId;
                    // ReSharper disable once PossibleLossOfFraction
                    borrowTransaction.Amount = cloudMinerModel.Amount * (runCloudMinerModel.ProductionAmount / runCloudMinerModel.ProductionCycle);
                    borrowTransactions.Add(borrowTransaction);

                    TransactionServerDal.PayCurrencyEntity borrowInfoEntity = new TransactionServerDal.PayCurrencyEntity();
                    borrowInfoEntity.CurrencyId = borrowTransaction.CurrencyId;
                    borrowInfoEntity.Amount = borrowTransaction.Amount;
                    borrowInfoEntities.Add(borrowInfoEntity);
                }
                int recordId = _cloudMinerProductionDal.InsertCloudMinerProductionRecord(runCloudMinerModel.Id, runCloudMinerModel.CommodityId, runCloudMinerModel.UserId, borrowInfoEntities, runCloudMinerModel.ProductionCount + 1);
                TransactionService.AddCloudMinerProduce("03", runCloudMinerModel.UserId, recordId, borrowTransactions);
                #endregion

                #region 分销
                int fansId = runCloudMinerModel.UserId;
                //循环遍历云矿机拨出比例（针对分销者）
                foreach (var distributionMechanismModel in distributionMechanismCloudMinerModels)
                {
                    try
                    {
                        try
                        {
                            dBorrowTransactions.Clear();
                            dBorrowInfoEntities.Clear();
                            fansId = Convert.ToInt32(_fansDal.QueryParent(fansId));
                            if (fansId <= 0) break;

                            #region 判断用户当前真实等级是否满足分销等级
                            RunCloudMinerModel parentRunCloudMinerModel = runCloudMinerModels.FirstOrDefault(n => n.UserId == fansId);
                            if (parentRunCloudMinerModel == null) continue;
                            int userRealRank = -1;
                            foreach (var item in vipUrCloudminerDistributions)
                            {
                                if (item.CommodityId == parentRunCloudMinerModel.CommodityId)
                                {
                                    userRealRank = item.Rank;
                                    break;
                                }
                            }
                            if (userRealRank == -1) continue;
                            if (distributionMechanismModel.Rank > userRealRank) continue;
                            #endregion

                            foreach (var borrowTransaction in borrowTransactions)
                            {
                                TransactionPayDetail dBorrowTransaction = new TransactionPayDetail();
                                dBorrowTransaction.CurrencyId = borrowTransaction.CurrencyId;
                                dBorrowTransaction.Amount = borrowTransaction.Amount * distributionMechanismModel.Proportion;
                                dBorrowTransactions.Add(dBorrowTransaction);

                                TransactionServerDal.PayCurrencyEntity tempBorrowInfoEntity = new TransactionServerDal.PayCurrencyEntity();
                                tempBorrowInfoEntity.CurrencyId = borrowTransaction.CurrencyId;
                                tempBorrowInfoEntity.Amount = borrowTransaction.Amount * distributionMechanismModel.Proportion;
                                dBorrowInfoEntities.Add(tempBorrowInfoEntity);
                            }
                            int cmdrId = _cloudMinerDistributionMechanismDal.InsertCloudMinerDistributionRecord(runCloudMinerModel.Id, runCloudMinerModel.CommodityId, fansId, dBorrowInfoEntities);
                            TransactionService.AddCloudMinerProduceDistribution("04", fansId, cmdrId, dBorrowTransactions);

                        }
                        catch (Exception exception)
                        {
                            LogHelper.error(exception.Message);
                            break;
                        }
                    }
                    catch (Exception exception)
                    {
                        LogHelper.error(exception.Message);
                        break;
                    }
                }
                #endregion
            }
            State = "2";
        }

        public class RunCloudMinerModel
        {
            public int Id { get; set; }

            /// <summary>
            /// 商品编号
            /// </summary>
            public int CommodityId { get; set; }

            /// <summary>
            /// 用户编号
            /// </summary>
            public int UserId { get; set; }

            /// <summary>
            /// 购买时间
            /// </summary>
            public string BuyTime { get; set; }

            /// <summary>
            /// 产币周期
            /// </summary>
            public int ProductionCycle { get; set; }

            /// <summary>
            /// 生产数量
            /// </summary>
            public decimal ProductionAmount { get; set; }

            public int ProductionCount { get; set; }
        }

        public class DistributionMechanismCloudMinerModel
        {
            public int Id { get; set; }
            public int Generation { get; set; }
            public decimal Proportion { get; set; }
            public int VipId { get; set; }
            public int Rank { get; set; }

        }

        public class VipUrCloudminerDistribution
        {
            public int Id { get; set; }
            public int Rank { get; set; }
            public string VipName { get; set; }
            public int CommodityId { get; set; }
            public int CloudMinerCount { get; set; }
        }
    }
}