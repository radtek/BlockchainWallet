using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwServer.Models.v1.Transaction;

namespace BwServer.Models.v1.Authorize
{
    public class AuthorizeUserInfoModelGet
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 应用编号
        /// </summary>
        public int AppId { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// 外部账号
        /// </summary>
        public string ExternalUserId { get; set; }
        /// <summary>
        /// 用户公开ID
        /// </summary>
        public string OpenUserId { get; set; }
        /// <summary>
        /// 授权时间
        /// </summary>
        public string AuthorizaTime { get; set; }
        /// <summary>
        /// 状态：0 正常 1取消
        /// </summary>
        public string State { get; set; }


    }
    public class AuthorizeUserInfoModelResult
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
    }
}