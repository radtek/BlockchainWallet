using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BwCommon.ContentConvert;
using BwDal.System;
using BwServer.Models;
using BwServer.Models.v1.User.Fans;

namespace BwServer.Controllers.v1.System
{
    public class AppVersionController : ApiController
    {
        private readonly AppVersionDal _appVersionDal = new AppVersionDal();
        public IHttpActionResult QueryVersion(VersionModelGet modelGet)
        {
            DataTable dt = _appVersionDal.QueryAppVersion(modelGet.AppType);
            IList<VersionModelResult> versionModelResults = ModelConvertHelper<VersionModelResult>.ConvertToModel(dt);
            return Json(new ResultDataModel<VersionModelResult> { Data = versionModelResults.FirstOrDefault() });
        }
    }
    public class VersionModelGet
    {
        public int Id { get; set; }
        /// <summary>
        /// 软件类型 0AndroidAPP 1苹果APP 2WindowsApp
        /// </summary>
        public string AppType { get; set; }
    }

    public class VersionModelResult
    {
        public int Id { get; set; }
        /// <summary>
        /// 软件类型 0AndroidAPP 1苹果APP 2WindowsApp
        /// </summary>
        public string AppType { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string VersionNo { get; set; }
        /// <summary>
        /// 强制更新 0强制 1不强制
        /// </summary>
        public string ForcedUpdate { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 下载更新地址URL
        /// </summary>
        public string Url { get; set; }
    }
}