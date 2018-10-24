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
using BwDal.Transaction;
using BwDal.User;
using BwDal.Wallet;
using BwServer.Controllers.v1.Commodity;
using BwServer.Models;
using BwServer.Models.v1.Commodity.StoreOrder;
using BwServer.Models.v1.Transaction;
using BwServer.Models.v1.Wallet.WalletInfo;

namespace BwServer.Controllers.v1.Transaction
{
    /// <summary>
    /// 交易服务
    /// </summary>
    public class TransactionController : ApiController
    {
        private TransactionInfoDal _transactionInfoDal = new TransactionInfoDal();
        private UserInfoDal _userInfoDal = new UserInfoDal();
        private readonly WalletInfoDal _walletInfoDal = new WalletInfoDal();
        /// <summary>
        /// 商户对个人交易
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult TransactionB2C(TransactionB2CModelGet modelGet)
        {
            if (string.IsNullOrEmpty(modelGet.PayOpenId) || string.IsNullOrEmpty(modelGet.PayeeOpenId) || string.IsNullOrEmpty(modelGet.ExternalOrderNo) ||
                string.IsNullOrEmpty(modelGet.ExternalOrderName) || string.IsNullOrEmpty(modelGet.ExternalOrderType))
            {
                return Json(new ResultDataModel<TransactionP2PModelResult> { Code = 4010, Messages = "数据参数有误", });
            }
            if (modelGet.PayCurrencyList.Count(n => n.Amount <= 0) > 0)
            {
                return Json(new ResultDataModel<TransactionP2PModelResult> { Code = -1, Messages = "交易金额有误，通证数量不能小于等于0", });
            }
            if (modelGet.PayCurrencyList.Count(n => n.Amount * 0.1M != n.ServiceCharge) > 0)
            {
                return Json(new ResultDataModel<TransactionP2PModelResult> { Code = -1, Messages = "转账通证数量不能小于等于0", });
            }
            //检查账号是否存在

            //string idCard = _userInfoDal.CheckBindIdCard(modelGet.PayUserId);
            //if (string.IsNullOrEmpty(idCard))
            //{
            //    return Json(new ResultDataModel<TransactionP2PModelResult> { Code = 4204, Messages = "该账号未实名认证，请先提交实名认证", });
            //}
            return Json(new object());
        }

        /// <summary>
        /// 商城对个人交易结果检查
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult TransactionB2CCheck(TransactionB2CCheckModelGet modelGet)
        {

            return Json(new object());
        }

        /// <summary>
        /// 商城对个人交易结果检查（对外开放接口）
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult TransactionB2CCheck3(TransactionB2CCheckModelGet modelGet)
        {

            return Json(new object());
        }

        /// <summary>
        /// 个人对个人交易
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult TransactionP2P(TransactionP2PModelGet modelGet)
        {
            if (modelGet.PayUserId <= 0 || string.IsNullOrEmpty(modelGet.PayeeWalletAddress) || string.IsNullOrEmpty(modelGet.PayPassword) || modelGet.PayCurrencyList.Count <= 0)
            {
                return Json(new ResultDataModel<TransactionP2PModelResult> { Code = 4010, Messages = "数据参数有误", });
            }
            if (modelGet.PayCurrencyList.Count(n => n.Amount <= 0) > 0)
            {
                return Json(new ResultDataModel<TransactionP2PModelResult> { Code = -1, Messages = "转账通证数量不能小于等于0", });
            }
            if (modelGet.PayCurrencyList.Count(n => n.ServiceCharge <= 0) > 0)
            {
                return Json(new ResultDataModel<TransactionP2PModelResult> { Code = -1, Messages = "转账手续费通证数量有误" });
            }
            if (modelGet.PayCurrencyList.Count(n => n.Amount * 0.1M != n.ServiceCharge) > 0)
            {
                return Json(new ResultDataModel<TransactionP2PModelResult> { Code = -1, Messages = "转账通证数量不能小于等于0", });
            }
            string idCard = _userInfoDal.CheckBindIdCard(modelGet.PayUserId);
            if (string.IsNullOrEmpty(idCard))
            {
                return Json(new ResultDataModel<TransactionP2PModelResult> { Code = 4204, Messages = "该账号未实名认证，请先提交实名认证", });
            }
            bool checkPayPassowrd = _userInfoDal.CheckPayPassowrd(modelGet.PayUserId, modelGet.PayPassword);
            if (!checkPayPassowrd)
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4106, Messages = "支付密码错误" });
            int payeeUserId = _userInfoDal.QueryUserIdByWalletAddress(modelGet.PayeeWalletAddress);
            if (payeeUserId == 0)
            {
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4304, Messages = "钱包地址不存在" });
            }
            if (payeeUserId < 0)
            {
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4001, Messages = "服务器繁忙，请稍后再试" });
            }
            DataTable dtWalletInfo = _walletInfoDal.QueryWalletInfo(modelGet.PayUserId);
            IList<WalletInfoModelResult> currencyInfoModelResults =
                ModelConvertHelper<WalletInfoModelResult>.ConvertToModel(dtWalletInfo);
            if (currencyInfoModelResults.Count <= 0)
            {
                LogHelper.error("支付商城订单失败：用户通证数量有误");
                throw new Exception();
            }
            foreach (var item in modelGet.PayCurrencyList)
            {
                decimal amount = currencyInfoModelResults.FirstOrDefault(n => n.CurrencyId == item.CurrencyId).CanUseAmount;
                if (amount < item.Amount + item.Amount)
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4302, Messages = "余额不足" });
                }
            }
            if (currencyInfoModelResults.First().WalletAddress == modelGet.PayeeWalletAddress)
            {
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4303, Messages = "不能转账给自己" });
            }
            string orderNo = GetTransactionNo("02", modelGet.PayUserId);
            List<TransactionServerDal.PayCurrencyEntity> payCurrencyEntities = new List<TransactionServerDal.PayCurrencyEntity>();
            List<TransactionPayDetail> transactionPayDetails = new List<TransactionPayDetail>();
            foreach (var model in modelGet.PayCurrencyList)
            {
                TransactionServerDal.PayCurrencyEntity payCurrencyEntity = new TransactionServerDal.PayCurrencyEntity();
                payCurrencyEntity.Amount = model.Amount;
                payCurrencyEntity.CurrencyId = model.CurrencyId;
                payCurrencyEntities.Add(payCurrencyEntity);
                //TransactionPayDetail transactionPayDetail = new TransactionPayDetail();

                TransactionPayDetail transactionPayDetail = new TransactionPayDetail();
                transactionPayDetail.Amount = model.Amount;
                transactionPayDetail.CurrencyId = model.CurrencyId;
                transactionPayDetails.Add(transactionPayDetail);
            }

            //添加P2P交易订单
            int orderId = _transactionInfoDal.CreateTransactionP2P(orderNo, modelGet.PayUserId, payeeUserId, modelGet.Remark, payCurrencyEntities);
            if (orderId <= 0)
            {
                return Json(new ResultDataModel<TransactionP2PModelResult>()
                {
                    Code = -1,
                    Messages = "当前服务器繁忙，请您稍后再试！",
                    Data = new TransactionP2PModelResult()
                    {
                        OrderNo = ""
                    }
                });
            }

            //将订单添加到交易服务并执行交易
            bool reslut = TransactionService.AddTransactionP2P("02", modelGet.PayUserId, payeeUserId, orderId, transactionPayDetails);
            return Json(new ResultDataModel<TransactionP2PModelResult>()
            {
                Code = reslut ? 0 : -1,
                Messages = reslut ? "" : "当前服务器繁忙，请您稍后再试！",
                Data = new TransactionP2PModelResult()
                {
                    OrderId = orderId,
                    OrderNo = orderNo,
                    OrderTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                }
            });
        }

        /// <summary>
        /// 检查个人对个人交易结果
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult TransactionP2PCheck(TransactionP2PCheckModelGet modelGet)
        {
            string result = _transactionInfoDal.TransactionP2PCheck(modelGet.UserId, modelGet.OrderId);

            return Json(new ResultDataModel<TransactionP2PCheckModelResult>
            {
                Code = string.IsNullOrEmpty(result) ? -1 : 0,
                Messages = string.IsNullOrEmpty(result) ? "服务器繁忙，请转至转账记录中查询" : "",
                Data = new TransactionP2PCheckModelResult
                {
                    State = result
                }
            });
        }

        public IHttpActionResult QueryTransactionP2PRecord(QueryTransactionP2PRecordModelGet modelGet)
        {
            DataSet dataSet = _transactionInfoDal.QueryTransactionP2PRecord(modelGet.UserId, modelGet.DataPagingModel);
            IList<QueryTransactionP2PRecordModelResult> cloudMinerProductionModelResult = ModelConvertHelper<QueryTransactionP2PRecordModelResult>.ConvertToModel(dataSet.Tables[0]);
            string orderIds = "";
            foreach (var item in cloudMinerProductionModelResult)
            {
                orderIds += item.OrderNo == "" ? item.Id.ToString() : "," + item.Id;
            }
            if (orderIds != "")
            {
                DataTable dataTable = _transactionInfoDal.QueryTransactionP2PDetail(orderIds);
                IList<TransactionP2PDetailModelResult> transactionP2PDetailModelResults = ModelConvertHelper<TransactionP2PDetailModelResult>.ConvertToModel(dataTable);
                foreach (var item in cloudMinerProductionModelResult)
                {
                    TransactionCurrencyModel transactionCurrencyModel = new TransactionCurrencyModel();
                    var model = transactionP2PDetailModelResults.FirstOrDefault(n => n.OrderId == item.Id);
                    if (model != null)
                    {
                        transactionCurrencyModel.CurrencyId = model.CurrencyId;
                        transactionCurrencyModel.Amount = model.Amount;
                        transactionCurrencyModel.ServiceCharge = model.ServiceCharge;
                    }
                    item.PayCurrencyList.Add(transactionCurrencyModel);
                }
            }

            return Json(new ResultDataModel<IList<QueryTransactionP2PRecordModelResult>>
            {
                Data = cloudMinerProductionModelResult,
                DataPagingResult = new DataPagingModelResult
                {
                    TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0])
                }
            });
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