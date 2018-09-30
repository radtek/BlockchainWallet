using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwCommon.Log;
using BwDal;
using BwDal.Commodity;
using BwDal.User;
using BwDal.Wallet;
using BwServer.Controllers.v1.Transaction;
using BwServer.Controllers.v1.User;
using BwServer.Models;
using BwServer.Models.v1.Commodity.CloudMinerInfo;
using BwServer.Models.v1.Commodity.CommodityInfo;
using BwServer.Models.v1.Commodity.StoreOrder;
using BwServer.Models.v1.User.Fans;
using BwServer.Models.v1.Wallet.WalletInfo;

namespace BwServer.Controllers.v1.Commodity
{
    public class StoreOrderController : ApiController
    {
        private readonly CloudMinerDal _cloudMinerDal = new CloudMinerDal();
        private readonly StoreOrderDal _storeOrderDal = new StoreOrderDal();
        private readonly UserInfoDal _userInfoDal = new UserInfoDal();
        private readonly WalletInfoDal _walletInfoDal = new WalletInfoDal();
        public IHttpActionResult QueryStoreOrder(StoreOrderModelGet modelGet)
        {
            if (modelGet.DataPagingModel == null)
            {
                return Json(new ResultDataModel<IList<StoreOrderModelResult>> { Code = 4011, Messages = "分页数据有误" });
            }
            DataSet dsStoreOrder = _storeOrderDal.QueryStoreOrder(modelGet.BuyUserId, modelGet.DataPagingModel);
            IList<StoreOrderModelResult> storeOrderModelResults = ModelConvertHelper<StoreOrderModelResult>.ConvertToModel(dsStoreOrder.Tables[0]);
            return Json(new ResultDataModel<IList<StoreOrderModelResult>> { Data = storeOrderModelResults, DataPagingResult = new DataPagingModelResult() { TotalCount = Convert.ToInt32(dsStoreOrder.Tables[1].Rows[0][0]) } });
        }

        public IHttpActionResult QueryStoreOrderInfo(StoreOrderModelGet modelGet)
        {
            DataTable dtStoreOrder = _storeOrderDal.QueryStoreOrderInfo(modelGet.Id);
            StoreOrderModelResult storeOrderModelResult = ModelConvertHelper<StoreOrderModelResult>.ConvertToModel(dtStoreOrder).FirstOrDefault();
            if (storeOrderModelResult != null)
            {
                DataTable dtPayDetail = _storeOrderDal.QueryPayDetail(modelGet.Id);
                storeOrderModelResult.PayDetailModelResults = ModelConvertHelper<StoreOrderPayDetailModel>.ConvertToModel(dtPayDetail);
            }
            return Json(new ResultDataModel<StoreOrderModelResult> { Data = storeOrderModelResult });
        }

        public IHttpActionResult CreateStoreOrder(StoreOrderModelGet modelGet)
        {
            try
            {
                if (modelGet.CommodityId < 0 || modelGet.BuyUserId < 0 || modelGet.Count < 1 || modelGet.UnitPrice < 0 || string.IsNullOrEmpty(modelGet.Type))
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4010, Messages = "数据参数有误", });
                }
                DataTable dtDataTable = _cloudMinerDal.QueryCloudMinerInfo(modelGet.CommodityId);
                CloudMinerInfoModelResult cloudMinerInfoModelResult = ModelConvertHelper<CloudMinerInfoModelResult>.ConvertToModel(dtDataTable).FirstOrDefault();
                if (cloudMinerInfoModelResult == null)
                {
                    LogHelper.error(string.Format("创建订单失败：商品已下架或不存在当前商品\n\r商品编号：{0} \n\r时间：{1:yyyy-MM-dd HH:mm:ss}", modelGet.CommodityId, DateTime.Now));
                    throw new Exception();
                }
                if (cloudMinerInfoModelResult.Amount != modelGet.UnitPrice)
                {
                    LogHelper.error(string.Format("创建订单失败：订单金额与商品当前价格不一致\n\r商品编号：{0} \n\r时间：{1:yyyy-MM-dd HH:mm:ss}", modelGet.CommodityId, DateTime.Now));
                    throw new Exception();
                }
                DataTable dtUserVipInfo = _userInfoDal.QueryUserVipInfo(modelGet.BuyUserId);
                if (dtUserVipInfo.Rows.Count <= 0)
                {
                    LogHelper.error(string.Format("创建订单失败：用户VIP信息不存在\n\r用户编号：{0} \n\r时间：{1:yyyy-MM-dd HH:mm:ss}", modelGet.BuyUserId, DateTime.Now));
                    throw new Exception();
                }
                if (cloudMinerInfoModelResult.Rank > Convert.ToInt32(dtUserVipInfo.Rows[0]["Rank"]))
                {
                    LogHelper.error(string.Format("创建订单失败：用户等级不足，不能购买此商品\n\r用户编号：{0} \n\r时间：{1:yyyy-MM-dd HH:mm:ss}", modelGet.BuyUserId, DateTime.Now));
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4301, Messages = "不符合购买条件，请详阅产品购买规则" });
                }
                UserCloudMinerDal userCloudMinerDal = new UserCloudMinerDal();
                int userRunningCoun = userCloudMinerDal.QueryRunningCloudMinerCount(modelGet.BuyUserId, modelGet.CommodityId);
                if (cloudMinerInfoModelResult.PurchaseRestrictionCount < userRunningCoun + modelGet.Count)
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "已超出购买数量限制" });
                }
                //获取商品粉丝直推粉丝各等级人数限制
                IList<BuyCommodityRuleFansVipModelResult> buyCommodityRuleFansModelResults = ModelConvertHelper<BuyCommodityRuleFansVipModelResult>.ConvertToModel(_cloudMinerDal.QueryBuyCommodityRuleFansVip(modelGet.CommodityId));
                FansController fansController = new FansController();
                //获取用户直推粉丝各等级人数
                IList<FansVipCountModelResult> fansVipCountModelResults =
                    fansController.QueryFirstFansVipCount(modelGet.BuyUserId);
                foreach (var item in buyCommodityRuleFansModelResults)
                {
                    if (item.Count > fansVipCountModelResults.Where(n => n.Rank >= item.Rank).Sum(s => s.FansCount))
                    {
                        return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4301, Messages = "不符合购买条件，请详阅产品购买规则" });
                    }
                }

                ////获取商品粉丝直推粉丝各等级人数限制
                //IList<BuyCommodityRuleFansGenerationModelResult> buyCommodityRuleFansGenerationModelResults = ModelConvertHelper<BuyCommodityRuleFansGenerationModelResult>.ConvertToModel(_cloudMinerDal.QueryBuyCommodityRuleFansGeneration(modelGet.CommodityId));

                //IList<FansGenerationCountModelResult> fansGenerationCountModelResults =
                //    fansController.QueryAllFansVipInfo(modelGet.BuyUserId);
                //foreach (var item in buyCommodityRuleFansGenerationModelResults)
                //{
                //    if (item.GenerationCount > fansGenerationCountModelResults.Where(n => n.GenerationId >= item.GenerationId).Sum(s => s.GenerationCount))
                //    {
                //        return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4301, Messages = "不符合购买条件，请详阅产品购买规则" });
                //    }
                //}

                DateTime dtNow = DateTime.Now;
                modelGet.TotalPrice = modelGet.UnitPrice * modelGet.Count;
                string orderNo = GetTransactionNo(modelGet.Type, modelGet.BuyUserId);

                int rows = _storeOrderDal.InsertStoreOrderInfo(orderNo, modelGet.CommodityId, modelGet.Count,
                     modelGet.UnitPrice, modelGet.TotalPrice, "00", dtNow.ToString("yyyy-MM-dd HH:mm:ss"), modelGet.BuyUserId, modelGet.BuyUserId);
                StoreOrderModelResult storeOrderModelResult = new StoreOrderModelResult();
                storeOrderModelResult.OrderNo = orderNo;
                storeOrderModelResult.TotalPrice = modelGet.TotalPrice;
                storeOrderModelResult.OrderTime = dtNow.ToString("yyyy-MM-dd HH:mm:ss");
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = rows > 1 ? 0 : -1, Messages = rows == 1 ? "" : "创建订单失败", Data = storeOrderModelResult });
            }
            catch (Exception)
            {
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4001, Messages = "服务器内部出现错误" });
            }
        }

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
                        string tLastNo = "0086" + dateTime.ToString("yyyyMMdd") + Random.Next(10, 99) + type + dateTime.ToString("HHmmssffff") + +userId;
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

        public IHttpActionResult PayStoreOrder(PayDetailModelGet payDetailModelGet)
        {
            try
            {
                if (string.IsNullOrEmpty(payDetailModelGet.PayPassword))
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "支付密码不能为空" });
                }
                DataTable dt = _storeOrderDal.QueryStoreOrderInfo(payDetailModelGet.OrderNo);
                if (dt.Rows.Count <= 0)
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "订单不存在" });
                }
                UserCloudMinerDal userCloudMinerDal = new UserCloudMinerDal();
                int userRunningCount = userCloudMinerDal.QueryRunningCloudMinerCount(payDetailModelGet.UserId, Convert.ToInt32(dt.Rows[0]["CommodityId"]));
                if (Convert.ToInt32(dt.Rows[0]["PurchaseRestrictionCount"]) < userRunningCount + Convert.ToInt32(dt.Rows[0]["Count"]))
                {
                    _storeOrderDal.UpdateStoreOrderState(payDetailModelGet.OrderNo, "5");
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "已超出购买数量限制" });
                }
                bool checkPayPassowrd = _userInfoDal.CheckPayPassowrd(payDetailModelGet.UserId, payDetailModelGet.PayPassword);
                if (!checkPayPassowrd)
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4106, Messages = "支付密码错误" });
                if (payDetailModelGet.PayDetailModels == null)
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "支付金额信息有误" });
                }
                if (payDetailModelGet.PayDetailModels.Count < 1 || payDetailModelGet.PayDetailModels.Count > 2)
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "支付金额信息有误" });
                }
                if (payDetailModelGet.PayDetailModels.Count(n => n.CurrencyId == 0) != 1)
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "支付金额信息有误" });
                }
                if (payDetailModelGet.PayDetailModels.Count == 2)
                {
                    try
                    {
                        if (payDetailModelGet.PayDetailModels.Where(n => n.CurrencyId == 0).ToList()[0].Amount < payDetailModelGet.PayDetailModels.Where(n => n.CurrencyId == 2).ToList()[0].Amount)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "支付金额信息有误" });
                    }
                }
                DataTable dtWalletInfo = _walletInfoDal.QueryWalletInfo(payDetailModelGet.UserId);
                IList<WalletInfoModelResult> currencyInfoModelResults =
                    ModelConvertHelper<WalletInfoModelResult>.ConvertToModel(dtWalletInfo);
                if (currencyInfoModelResults.Count <= 0)
                {
                    LogHelper.error("支付商城订单失败：用户金额有误");
                    throw new Exception();
                }

                foreach (var item in payDetailModelGet.PayDetailModels)
                {
                    decimal amount = currencyInfoModelResults.FirstOrDefault(n => n.CurrencyId == item.CurrencyId).CanUseAmount;
                    if (amount < item.Amount)
                    {
                        return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4302, Messages = "余额不足" });
                    }
                }

                bool b = TransactionService.AddStoreOrder(payDetailModelGet);
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = b ? 0 : -1, Messages = "" });
            }
            catch (Exception)
            {
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4001, Messages = "服务器内部出现错误" });
            }
        }
        public IHttpActionResult QueryGaveCommodityStoreOrder(GaveCommodityStoreOrderModelGet modelGet)
        {
            if (!_userInfoDal.CheckIsShareholder(modelGet.UserId))
            {
                LogHelper.warn("非法账户请求股东接口，非法账户：" + modelGet.UserId);
                return Json(new ResultDataModel<IList<StoreOrderModelResult>> { Code = 4108, Messages = "非法账户，该操作已被记录，并提交给客服人员" });
            }
            DataSet dsStoreOrder = _storeOrderDal.QueryStoreOrder(1, modelGet.DataPagingModel);
            IList<GaveCommodityStoreOrderModelResult> storeOrderModelResults = ModelConvertHelper<GaveCommodityStoreOrderModelResult>.ConvertToModel(dsStoreOrder.Tables[0]);
            return Json(new ResultDataModel<IList<GaveCommodityStoreOrderModelResult>> { Data = storeOrderModelResults, DataPagingResult = new DataPagingModelResult { TotalCount = Convert.ToInt32(dsStoreOrder.Tables[1].Rows[0][0]) } });
        }

        /// <summary>
        /// 审核赠送商品订单
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult AuditGaveCommodityStoreOrder(AuditGaveCommodityStoreOrderModelGet modelGet)
        {
            try
            {
                if (modelGet.OrderId <= 0 || modelGet.UserId <= 0)
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "参数有误" });
                }
                if (!_userInfoDal.CheckIsShareholder(modelGet.UserId))
                {
                    LogHelper.warn("非法账户请求股东接口，非法账户：" + modelGet.UserId);
                    return Json(new ResultDataModel<IList<StoreOrderModelResult>> { Code = 4108, Messages = "非法账户，该操作已被记录，并提交给客服人员" });
                }
                DataTable dt = _storeOrderDal.QueryStoreOrderInfo(modelGet.OrderId);
                if (dt.Rows.Count <= 0)
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "订单不存在" });
                }
                UserCloudMinerDal userCloudMinerDal = new UserCloudMinerDal();
                int userRunningCount = userCloudMinerDal.QueryRunningCloudMinerCount(Convert.ToInt32(dt.Rows[0]["ConsignorUserId"]), Convert.ToInt32(dt.Rows[0]["CommodityId"]));
                if (Convert.ToInt32(dt.Rows[0]["PurchaseRestrictionCount"]) < userRunningCount + Convert.ToInt32(dt.Rows[0]["Count"]))
                {
                    _storeOrderDal.UpdateStoreOrderState(modelGet.OrderId, "5");
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "已超出购买数量限制" });
                }
                if (modelGet.State != "0")
                {
                    _storeOrderDal.UpdateStoreOrderState(modelGet.OrderId, "6");
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = 0 });
                }
                DataTable dtWalletInfo = _walletInfoDal.QueryCompanyWalletInfo(1);
                IList<WalletInfoModelResult> currencyInfoModelResults =
                    ModelConvertHelper<WalletInfoModelResult>.ConvertToModel(dtWalletInfo);
                if (currencyInfoModelResults.Count <= 0)
                {
                    LogHelper.error("审核赠送商品订单失败：公司金额金额有误");
                    throw new Exception();
                }
                decimal amount = currencyInfoModelResults.First(n => n.CurrencyId == 0).CanUseAmount;
                if (amount < Convert.ToDecimal(dt.Rows[0]["TotalPrice"]))
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "审核赠送商品订单失败：公司账户通证数量不足" });
                }
                PayDetailModelGet payDetailModelGet = new PayDetailModelGet();
                payDetailModelGet.OrderNo = Convert.ToString(dt.Rows[0]["OrderNo"]);
                payDetailModelGet.UserId = Convert.ToInt32(dt.Rows[0]["BuyUserId"]);
                payDetailModelGet.PayDetailModels.Add(new StoreOrderPayDetailModel { CurrencyId = 0, OrderNo = payDetailModelGet.OrderNo, Amount = Convert.ToDecimal(dt.Rows[0]["TotalPrice"]) });
                bool b = TransactionService.AddStoreOrder(payDetailModelGet);
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = b ? 0 : -1, Messages = "" });
            }
            catch (Exception)
            {
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4001, Messages = "服务器内部出现错误" });
            }
        }


        public IHttpActionResult CheckStoreOrderPayState(PayDetailModelGet payDetailModelGet)
        {
            DataTable dtStoreOrderState = _storeOrderDal.CheckStoreOrderState(payDetailModelGet.OrderNo);
            if (dtStoreOrderState.Rows.Count != 1)
            {
                return Json(new ResultDataModel<StoreOrderPayStateModelResult> { Code = -1, Messages = "订单号不存在" });
            }
            IList<StoreOrderPayStateModelResult> storeOrderPayStateModelResults =
                ModelConvertHelper<StoreOrderPayStateModelResult>.ConvertToModel(dtStoreOrderState);
            var model = storeOrderPayStateModelResults.FirstOrDefault();
            model.RealRank = _userInfoDal.CheckUserVipRank(Convert.ToUInt32(payDetailModelGet.UserId));
            return Json(new ResultDataModel<StoreOrderPayStateModelResult> { Code = 0, Data = model });
        }
    }
}