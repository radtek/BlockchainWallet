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
            if (modelGet.PayUserId <= 0 || modelGet.PayeeUserId <= 0 || string.IsNullOrEmpty(modelGet.PayPassword) || modelGet.PayCurrencyList.Count <= 0)
            {
                return Json(new ResultDataModel<TransactionP2PModelResult> { Code = 4010, Messages = "数据参数有误", });
            }
            if (modelGet.PayCurrencyList.Count(n => n.Amount <= 0) > 0)
            {
                return Json(new ResultDataModel<TransactionP2PModelResult> { Code = -1, Messages = "转账通证金额不能小于等于0", });
            }
            string idCard = _userInfoDal.CheckBindIdCard(modelGet.PayUserId);
            if (string.IsNullOrEmpty(idCard))
            {
                return Json(new ResultDataModel<TransactionP2PModelResult> { Code = 4204, Messages = "该账号未实名认证，请先提交实名认证", });
            }
            bool checkPayPassowrd = _userInfoDal.CheckPayPassowrd(modelGet.PayUserId, modelGet.PayPassword);
            if (!checkPayPassowrd)
                return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4106, Messages = "支付密码错误" });

            DataTable dtWalletInfo = _walletInfoDal.QueryWalletInfo(modelGet.PayUserId);
            IList<WalletInfoModelResult> currencyInfoModelResults =
                ModelConvertHelper<WalletInfoModelResult>.ConvertToModel(dtWalletInfo);
            if (currencyInfoModelResults.Count <= 0)
            {
                LogHelper.error("支付商城订单失败：用户金额有误");
                throw new Exception();
            }
            foreach (var item in modelGet.PayCurrencyList)
            {
                decimal amount = currencyInfoModelResults.FirstOrDefault(n => n.CurrencyId == item.CurrencyId).CanUseAmount;
                if (amount < item.Amount)
                {
                    return Json(new ResultDataModel<StoreOrderModelResult> { Code = 4302, Messages = "余额不足" });
                }
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

                TransactionPayDetail transactionPayDetail = new TransactionPayDetail();
            }
            //添加P2P交易订单
            int orderId = _transactionInfoDal.CreateTransactionP2P(orderNo, modelGet.PayUserId, modelGet.PayeeUserId, modelGet.Remark, payCurrencyEntities);
            if (orderId > 0)
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
            bool reslut = TransactionService.AddTransactionP2P("02", modelGet.PayUserId, modelGet.PayeeUserId, orderId, transactionPayDetails);
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
        /// 个人对个人交易
        /// </summary>
        /// <param name="modelGet"></param>
        /// <returns></returns>
        public IHttpActionResult TransactionP2PCheck(TransactionP2PCheckModelGet modelGet)
        {
            string result = _transactionInfoDal.TransactionP2PCheck(modelGet.UserId, modelGet.OrderNo);

            return Json(new TransactionP2PCheckModelResult()
            {
                State = result
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