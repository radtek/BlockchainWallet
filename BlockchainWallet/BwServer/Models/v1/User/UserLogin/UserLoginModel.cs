using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.User.UserLogin
{
    public class UserLoginModelGet
    {
        /// <summary>
        /// 手机号/账号/身份证
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 为手机登录时必填
        /// </summary>
        public string PhoneAreaId { get; set; }
        /// <summary>
        /// 1手机号 2账号 3身份证
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Password { get; set; }
    }
}