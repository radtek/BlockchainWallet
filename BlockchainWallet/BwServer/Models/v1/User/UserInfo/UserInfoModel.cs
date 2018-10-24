using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BwDal;

namespace BwServer.Models.v1.User.UserInfo
{
    public class UserInfoModelGet : HeadModelGet
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name { get; set; }
    }

    public class UserInfoModelResult
    {
        /// <summary>
        /// 编号
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 国家区号
        /// </summary>
        public string PhoneAreaId { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否设置支付密码
        /// </summary>
        public string IsSetPayPassword { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 用户类型 0基础用户 1会员 2股东用户 3公司账号
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 账户状态： 0正常 1删除 2冻结
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 推广码
        /// </summary>
        public string PromotionCode { get; set; }
        public int VipId { get; set; }
        public int Rank { get; set; }
        public string VipName { get; set; }
        public int RealRank { get; set; }

    }
}