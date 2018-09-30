using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.System
{
    public class PhoneVerificationModelGet
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
        /// 验证码类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 附加信息
        /// </summary>
        public string Remark { get; set; }

    }
    public class CheckPhoneVerificationModelGet
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
        /// 验证码类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 附加信息
        /// </summary>
        public string VerificationCode { get; set; }
    }
}