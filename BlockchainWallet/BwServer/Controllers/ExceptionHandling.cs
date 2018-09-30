using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;
using BwCommon.ContentConvert;
using BwCommon.Log;
using BwServer.Models;
using Newtonsoft.Json;

namespace BwServer.Controllers
{
    /// <summary>
    /// 接口发生异常过滤器
    /// </summary>
    public class ExceptionHandling : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var code = new HttpResponseMessage(HttpStatusCode.InternalServerError).StatusCode;//设置错误代码：例如：500 404
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            string msg = JsonConvert.SerializeObject(new BaseResult() { success = false, message = actionExecutedContext.Exception.Message });//返回异常错误提示
            //写入错误日志相关实现
            var portLogEntity = new PortLogEntity
            {
                PortName = actionExecutedContext.Request.RequestUri.AbsolutePath,
                RequestType = actionExecutedContext.Request.Method.ToString(),
                //StatusCode = Convert.ToInt32(code),
                ClientIp = GetClientIp(),
                ParameterList = JsonConvertHelper.ConvertToJson(actionExecutedContext.ActionContext.ActionArguments),
                Success = false,
                ErrorMessage = msg
            };
            LogHelper.error("服务器错误信息：\r\n" + JsonConvertHelper.ConvertToJson(portLogEntity));
            //result
            msg = JsonConvertHelper.ConvertToJson(
                new ResultDataModel<BaseResult> { Code = 4003, Messages = "全局接口异常捕捉到的错误，请联系研发人员处理" });
            actionExecutedContext.Response.Content = new StringContent(msg, Encoding.UTF8);
        }
        /// <summary>
        /// 获取调用接口者ip地址
        /// </summary>
        /// <returns></returns>
        private string GetClientIp()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                return "0.0.0.0";
            }
            return result;
        }
    }
    public class BaseResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }
    }

    public class PortLogEntity
    {
        public string PortName { get; set; }
        public string RequestType { get; set; }
        public int StatusCode { get; set; }
        public string ClientIp { get; set; }
        public string ParameterList { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}