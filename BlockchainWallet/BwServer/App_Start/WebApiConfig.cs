using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using BwCommon.Log;
using BwServer.Controllers;
using BwServer.Controllers.v1.Agent;
using BwServer.Controllers.v1.Transaction;

namespace BwServer
{
    public static class WebApiConfig
    {
        public static bool TransactionServerRun = false;
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new RequestAuthorizeAttribute());
            config.Filters.Add(new ExceptionHandling());
            config.Filters.Add(new AuthActionFilterAttribute());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiv1",
                routeTemplate: "api/v1/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Employee_v1",
                routeTemplate: "api/v1/Employee/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "User_v1",
                routeTemplate: "api/v1/User/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Commodity_v1",
                routeTemplate: "api/v1/Commodity/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "System_v1",
                routeTemplate: "api/v1/System/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "CustomerServiceSystem_v1",
                routeTemplate: "api/v1/CustomerServiceSystem/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Wallet_v1",
                routeTemplate: "api/v1/Wallet/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Agent_v1",
                routeTemplate: "api/v1/Agent/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Services.Replace(typeof(IHttpControllerSelector), new VersionControllerSelector(config));
            if (!TransactionServerRun)
            {
                TransactionServerRun = true;
                LogHelper.info("TransactionServerRun...");
                TransactionSystem.Single.RunTransactionServer(1);
                LogHelper.info("StartListenServer...");
                CloudMinerServer.Single.StartListenServer();
            }
        }
    }
}
