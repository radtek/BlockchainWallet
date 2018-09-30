using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace BwServer
{
    public class VersionControllerSelector : DefaultHttpControllerSelector
    {
        private readonly HttpConfiguration _config;
        IDictionary<string, HttpControllerDescriptor> _controllers = null;//缓存用
        public VersionControllerSelector(HttpConfiguration config)
            : base(config)
        {
            _config = config;
        }

        //设计就是返回HttpControllerDesriptor的过程
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //获取所有的controller键值集合
            if (_controllers.Keys.Count <= 0)
            {
                GetControllerMapping();
            }
            //获取路由数据
            var routeData = request.GetRouteData();
            //从路由中获取当前controller的名称
            var controllerName = (string)routeData.Values["controller"];
            //从url路径
            string[] paths = request.RequestUri.PathAndQuery.Split('/');

            string key = string.Empty;//获取Personv2
            switch (paths.Length)
            {
                case 4:
                    key = ("BwServer.Controllers." + controllerName).ToLower();
                    break;
                default:
                    if (paths.Length > 4)
                    {
                        string path = "";
                        for (int i = 0; i < paths.Length - 4; i++)
                        {
                            path += paths[i + 2] + ".";
                        }
                        key = ("BwServer.Controllers." + path + controllerName).ToLower();
                    }
                    else
                    {
                        return null;
                    }
                    break;
            }
            if (_controllers.ContainsKey(key))//获取HttpControllerDescriptor
            {
                return _controllers[key];
            }
            else
            {
                return null;
            }
        }

        public override IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            Dictionary<string, HttpControllerDescriptor> dict
                = new Dictionary<string, HttpControllerDescriptor>();
            foreach (var asm in _config.Services.GetAssembliesResolver().GetAssemblies())
            {
                //获取所有继承自ApiController的非抽象类
                var controllerTypes = asm.GetTypes()
                    .Where(t => !t.IsAbstract && typeof(ApiController).IsAssignableFrom(t)).ToArray();
                foreach (var ctrlType in controllerTypes)
                {
                    //从namespace中提取出版本号
                    if (ctrlType.Namespace.Contains("BwServer.Controllers"))
                    {
                        //string verNum = ctrlType.Namespace.Equals("BwServer.Controllers") ? "" : ctrlType.Namespace.Replace("BwServer.Controllers.", "");//获取版本号
                        string ctrlName = Regex.Match(ctrlType.Name, "(.+)Controller").Groups[1].Value;//从PersonController中拿到Person
                        string key = (ctrlType.Namespace + "." + ctrlName).ToLower();//Personv2为key
                        if (dict.ContainsKey(key))
                        {
                            throw new Exception("存在重复的控制器");
                        }
                        dict[key] = new HttpControllerDescriptor(_config, ctrlName, ctrlType);
                    }
                }
            }
            _controllers = dict;//因为项目启动的时候就会调用GetControllerMapping这个方法，这个方法主要是就获取所有的控制器，所以既然项目开始启动的时候就已经调用过这个方法了，已经获取到了所有的控制器了，为了避免我们在重新SelectController方法的时候二次调用，这里把已经取到的控制器字典缓存起来。
            return dict;
        }
    }
}