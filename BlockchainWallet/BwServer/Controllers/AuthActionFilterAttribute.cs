using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BwServer.Controllers
{
    /// <summary>
    /// 请求成功后触发
    /// </summary>
    public class AuthActionFilterAttribute : ActionFilterAttribute
    {
        //private PortLogBLL portlogbll = new PortLogBLL();
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //action 请求之后触发<br>            //日志记录 访问量记录等等
            //portlogbll.SaveForm(new PortLogEntity()
            //{
            //    PortName = actionExecutedContext.Request.RequestUri.AbsolutePath,//获得调用接口,
            //    RequestType = actionExecutedContext.Request.Method.ToString(),
            //    StatusCode = Convert.ToInt32(new HttpResponseMessage(HttpStatusCode.OK).StatusCode),//设置状态码
            //    ClientIp = GetClientIp(),
            //    ParameterList = actionExecutedContext.ActionContext.ActionArguments.ToJson(),//获得参数值
            //    Success = true
            //});
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

        }
    }
}