using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.User.UserInfo
{
    public class UpdateLoginPasswordModelGet
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 新手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 国家区号
        /// </summary>
        public string PhoneAreaId { get; set; }
        /// <summary>
        /// 旧手机验证码
        /// </summary>
        public string OldLoginPassword { get; set; }
        /// <summary>
        /// 新手机验证码
        /// </summary>
        public string LoginPassword { get; set; }

    }

    public class RetrieveLoginPasswordModelGet
    {
        /// <summary>
        /// 新手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 国家区号
        /// </summary>
        public string PhoneAreaId { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerificationCode { get; set; }
        /// <summary>
        /// 新手机验证码
        /// </summary>
        public string LoginPassword { get; set; }

    }
}