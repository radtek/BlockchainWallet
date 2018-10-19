using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.User.UserInfo
{
    public class BindExternalUserModelGet
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 外部账号
        /// </summary>
        public string ExternalUserId { get; set; }
        /// <summary>
        /// 应用编号
        /// </summary>
        public int AppId { get; set; }
    }
    public class BindExternalUserModelResult
    {
        public string OpenUserId { get; set; }
    }
}