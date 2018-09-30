using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.User.UserInfo
{
    public class UserInfoRegisterModelGet
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 国家区号
        /// </summary>
        public string PhoneAreaId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 推荐号
        /// </summary>
        public string PromotionCode { get; set; }
        /// <summary>
        /// 手机验证码
        /// </summary>
        public string VerificationCode { get; set; }
    }
}