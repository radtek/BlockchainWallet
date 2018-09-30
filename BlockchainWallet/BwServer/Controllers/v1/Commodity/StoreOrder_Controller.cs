using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwCommon.Log;
using BwDal;
using BwDal.Commodity;
using BwDal.User;
using BwServer.Controllers.v1.User;
using BwServer.Models;
using BwServer.Models.v1.Commodity.CloudMinerInfo;
using BwServer.Models.v1.Commodity.StoreOrder;
using BwServer.Models.v1.User.Fans;

namespace BwServer.Controllers.v1.Commodity
{
    public class StoreOrder_Controller : ApiController
    {
        private readonly StoreOrderDal_ _storeOrderDal = new StoreOrderDal_();
        public IHttpActionResult QueryStoreOrder(StoreOrderModelGet_ modelGet)
        {
            DataSet dtStoreOrder = _storeOrderDal.QueryStoreOrder_(modelGet.DataPagingModel);
            IList<StoreOrderModelResult_> storeOrderModelResults = ModelConvertHelper<StoreOrderModelResult_>.ConvertToModel(dtStoreOrder.Tables[0]);
            //if (dtStoreOrder.Tables[0].Rows.Count > 0)
            //{
            //    string orderIds = string.Empty;
            //    foreach (var item in storeOrderModelResults)
            //    {
            //        orderIds += string.IsNullOrEmpty(orderIds) ? item.Id.ToString() : "," + item.Id;
            //    }
            //    DataTable dtPayDetail = _storeOrderDal.QueryPayDetail_(orderIds);
            //    IList<StoreOrderPayDetailModel> storeOrderPayDetailModels = ModelConvertHelper<StoreOrderPayDetailModel>.ConvertToModel(dtPayDetail);
            //    foreach (var item in storeOrderModelResults)
            //    {
            //        item.PayDetailModels = storeOrderPayDetailModels.Where(n => n.OrderNo == item.OrderNo).ToList();
            //    }
            //}
            return Json(new ResultDataModel<IList<StoreOrderModelResult_>> { Data = storeOrderModelResults, DataPagingResult = new DataPagingModelResult() { TotalCount = Convert.ToInt32(dtStoreOrder.Tables[1].Rows[0][0]) } });
        }

        readonly CloudMinerDal _cloudMinerDal = new CloudMinerDal();
        readonly UserInfoDal _userInfoDal = new UserInfoDal();
        public IHttpActionResult GaveCommodityStoreOrder(StoreOrderModelGet_ modelGet)
        {
            try
            {
                if (modelGet.CommodityId < 0 || modelGet.Count < 1 || modelGet.ConsignorUserId < 0)
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4010, Messages = "数据参数有误", });
                }
                modelGet.BuyUserId = 1;
                DataTable dtDataTable = _cloudMinerDal.QueryCloudMinerInfo(modelGet.CommodityId);
                CloudMinerInfoModelResult cloudMinerInfoModelResult = ModelConvertHelper<CloudMinerInfoModelResult>.ConvertToModel(dtDataTable).FirstOrDefault();
                if (cloudMinerInfoModelResult == null)
                {
                    LogHelper.error(string.Format("创建订单失败：商品已下架或不存在当前商品\n\r商品编号：{0} \n\r时间：{1:yyyy-MM-dd HH:mm:ss}", modelGet.CommodityId, DateTime.Now));
                    throw new Exception();
                }
                //if (cloudMinerInfoModelResult.Amount != modelGet.UnitPrice)
                //{
                //    LogHelper.error(string.Format("创建订单失败：订单金额与商品当前价格不一致\n\r商品编号：{0} \n\r时间：{1:yyyy-MM-dd HH:mm:ss}", modelGet.CommodityId, DateTime.Now));
                //    throw new Exception();
                //}

                DataTable dtUserVipInfo = _userInfoDal.QueryUserVipInfo(modelGet.ConsignorUserId);
                if (dtUserVipInfo.Rows.Count <= 0)
                {
                    LogHelper.error(string.Format("创建订单失败：用户VIP信息不存在\n\r用户编号：{0} \n\r时间：{1:yyyy-MM-dd HH:mm:ss}", modelGet.BuyUserId + "赠送给：" + modelGet.ConsignorUserId, DateTime.Now));
                    throw new Exception();
                }
                if (cloudMinerInfoModelResult.Rank > Convert.ToInt32(dtUserVipInfo.Rows[0]["Rank"]))
                {
                    LogHelper.error(string.Format("创建订单失败：用户等级不足，不能购买此商品\n\r用户编号：{0} \n\r时间：{1:yyyy-MM-dd HH:mm:ss}", modelGet.BuyUserId + "赠送给：" + modelGet.ConsignorUserId, DateTime.Now));
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4301, Messages = "不符合购买条件，请详阅产品购买规则" });
                }
                UserCloudMinerDal userCloudMinerDal = new UserCloudMinerDal();
                int userRunningCoun = userCloudMinerDal.QueryRunningCloudMinerCount(modelGet.ConsignorUserId, modelGet.CommodityId);
                if (cloudMinerInfoModelResult.PurchaseRestrictionCount < userRunningCoun + modelGet.Count)
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = -1, Messages = "已超出购买数量限制" });
                }
                //获取商品粉丝直推粉丝各等级人数限制
                IList<BuyCommodityRuleFansVipModelResult> buyCommodityRuleFansModelResults = ModelConvertHelper<BuyCommodityRuleFansVipModelResult>.ConvertToModel(_cloudMinerDal.QueryBuyCommodityRuleFansVip(modelGet.CommodityId));
                FansController fansController = new FansController();
                //获取用户直推粉丝各等级人数
                IList<FansVipCountModelResult> fansVipCountModelResults =
                    fansController.QueryFirstFansVipCount(modelGet.ConsignorUserId);
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
                modelGet.TotalPrice = cloudMinerInfoModelResult.Amount * modelGet.Count;
                modelGet.UnitPrice = cloudMinerInfoModelResult.Amount;
                string orderNo = GetTransactionNo(modelGet.Type, modelGet.BuyUserId);

                int orderId = new StoreOrderDal().InsertStoreOrderInfo(orderNo, modelGet.CommodityId, modelGet.Count,
                    modelGet.UnitPrice, modelGet.TotalPrice, "01", dtNow.ToString("yyyy-MM-dd HH:mm:ss"), modelGet.BuyUserId, modelGet.ConsignorUserId);
                CreateGaveCommodityStoreOrderModelResult result = new CreateGaveCommodityStoreOrderModelResult();
                result.OrderNo = orderNo;
                result.OrderId = orderId;
                return Json(new ResultDataModel<CreateGaveCommodityStoreOrderModelResult> { Code = orderId > 0 ? 0 : -1, Messages = orderId > 0 ? "" : "创建订单失败", Data = result });
            }
            catch (Exception)
            {
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4001, Messages = "服务器内部出现错误" });
            }
        }

        //public IHttpActionResult QueryGaveCommodityStoreOrder(GaveCommodityStoreOrderModelGet modelGet)
        //{
        //    if (!_userInfoDal.CheckIsShareholder(modelGet.UserId))
        //    {
        //        LogHelper.warn("非法账户请求股东接口，非法账户：" + modelGet.UserId);
        //        return Json(new ResultDataModel<IList<StoreOrderModelResult>> { Code = 4108, Messages = "非法账户，该操作已被记录，并提交给客服人员" });
        //    }
        //    DataSet dsStoreOrder = _storeOrderDal.QueryStoreOrder(1, modelGet.DataPagingModel);
        //    IList<GaveCommodityStoreOrderModelResult> storeOrderModelResults = ModelConvertHelper<GaveCommodityStoreOrderModelResult>.ConvertToModel(dsStoreOrder.Tables[0]);
        //    return Json(new ResultDataModel<IList<GaveCommodityStoreOrderModelResult>> { Data = storeOrderModelResults, DataPagingResult = new DataPagingModelResult { TotalCount = Convert.ToInt32(dsStoreOrder.Tables[1].Rows[0][0]) } });
        //}

        public IHttpActionResult QueryGaveCommodityStoreOrder(GaveCommodityStoreOrderModelGet modelGet)
        {
            DataSet dsStoreOrder = new StoreOrderDal().QueryStoreOrder(1, modelGet.DataPagingModel);
            IList<GaveCommodityStoreOrderModelResult> storeOrderModelResults = ModelConvertHelper<GaveCommodityStoreOrderModelResult>.ConvertToModel(dsStoreOrder.Tables[0]);
            return Json(new ResultDataModel<IList<GaveCommodityStoreOrderModelResult>> { Data = storeOrderModelResults, DataPagingResult = new DataPagingModelResult { TotalCount = Convert.ToInt32(dsStoreOrder.Tables[1].Rows[0][0]) } });
        }

        #region 获取订单号
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
        #endregion


    }
}