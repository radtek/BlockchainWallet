using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;
using BwCommon.Cache;
using BwCommon.ContentConvert;
using BwCommon.EncryptionDecryption;
using BwDal.System;
using BwServer.Models;

namespace BwServer.Controllers
{
    /// <summary>
    /// 自定义此特性用于接口的身份验证
    /// </summary>
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {
        //重写基类的验证方式，加入我们自定义的Ticket验证
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (SystemMaintenance.CheckServerMaintain)
            {
                HandleUnauthorizedRequest(actionContext);
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
            string url = actionContext.Request.RequestUri.LocalPath;
            if (url.IndexOf("User/UserLogin/UserLogin") <= 0 && url.IndexOf("User/UserInfo/RegisterUserInfo") <= 0 && url.IndexOf("Employee/EmployeeLogin/Login") <= 0
            && url.IndexOf("System/PhoneVerification/SendPhoneVerification") <= 0 && url.IndexOf("User/UserInfo/RetrieveLoginPassword") <= 0)
            {
                HttpCookieCollection httpCookieCollection = HttpContext.Current.Request.Cookies;
                try
                {
                    object token = httpCookieCollection["Token"].Value;
                    object userId = httpCookieCollection["UserId"].Value;
                    object type = httpCookieCollection["Type"].Value;
                    if (ValidateToken(userId.ToString(), type.ToString(), token.ToString()))
                    {
                        base.IsAuthorized(actionContext);
                        return;
                    }
                }
                catch (Exception)
                {

                }
                HandleUnauthorizedRequest(actionContext);
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
            base.IsAuthorized(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actioncontext)
        {
            base.HandleUnauthorizedRequest(actioncontext);
            var response = actioncontext.Response = actioncontext.Response ?? new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            var content = JsonConvertHelper.ConvertToJson(new ResultDataModel<NullReferenceException>() { Code = 4002, Messages = "登录令牌失效" });
            if (SystemMaintenance.CheckServerMaintain)
            {
                content = JsonConvertHelper.ConvertToJson(new ResultDataModel<NullReferenceException>() { Code = 4004, Messages = "服务器正在维护中" });
            }
            //content = AesHelper.AesEncrypt(content, "Jlfc_QQh.2018@11!~^$#GRqB++(())1");
            response.Content = new StringContent(content, Encoding.UTF8, "application/json");
        }

        //校验Token
        private bool ValidateToken(string userId, string type, string token)
        {
            try
            {
                object objTkoen = WebCacheHelper.GetCache(userId + "_" + type);
                if (objTkoen == null) return false;
                return token == objTkoen.ToString();
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

    public class SystemMaintenance
    {
        private static readonly SystemMaintenanceDal_ SystemMaintenanceDal = new SystemMaintenanceDal_();
        public static IList<SystemMaintenanceModel> SystemMaintenanceModels;

        static SystemMaintenance()
        {

        }

        public class SystemMaintenanceModel
        {
            public DateTime MaintenanceTimeBegin { get; set; }
            public DateTime MaintenanceTimeEnd { get; set; }
        }

        public static bool CheckServerMaintain
        {
            get
            {
                HttpCookieCollection httpCookieCollection = HttpContext.Current.Request.Cookies;
                try
                {
                    if (httpCookieCollection.AllKeys.Contains("UserId"))
                    {
                        object userId = httpCookieCollection["UserId"].Value;
                        if (Convert.ToInt32(userId) == 6 || Convert.ToInt32(userId) == 1)
                        {
                            return false;
                        }
                    }
                }
                catch
                {

                }
                if (SystemMaintenanceModels == null) Refresh();
                return SystemMaintenanceModels.Count(n => n.MaintenanceTimeBegin <= DateTime.Now && n.MaintenanceTimeEnd >= DateTime.Now) > 0;
            }
        }

        public static void Add(DateTime maintenanceTimeBegin, DateTime maintenanceTimeEnd)
        {
            if (SystemMaintenanceModels == null)
            {
                Refresh();
            }
            else
            {
                SystemMaintenanceModels.Add(new SystemMaintenanceModel { MaintenanceTimeBegin = maintenanceTimeBegin, MaintenanceTimeEnd = maintenanceTimeEnd });
            }
        }

        public static void Refresh()
        {
            SystemMaintenanceModels = ModelConvertHelper<SystemMaintenanceModel>.ConvertToModel(SystemMaintenanceDal.QuerySystemMaintenance()); ;
        }

    }
}