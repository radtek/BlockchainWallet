using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.UserMgmt.User
{
    public class UserInfoQueryModelSend : HeadDataBaseModelSend
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name { get; set; }
    }
    public class UserInfoQueryModelGet
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
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
        public string SexCaption
        {
            get
            {
                if (Sex == "0")
                {
                    return "男";
                }
                if (Sex == "1")
                {
                    return "女";
                }
                return "无性别";
            }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 用户类型 1会员 2股东用户 3公司账号
        /// </summary>
        public string Type { get; set; }
        public string TypeCaption
        {
            get
            {
                if (Type == "0")
                {
                    return "会员";
                }
                if (Type == "1")
                {
                    return "股东用户";
                }
                if (Type == "2")
                {
                    return "公司账号";
                }
                return "异常";
            }
        }
        /// <summary>
        /// 账户状态 0删除 1正常 2冻结
        /// </summary>
        public string State { get; set; }
        public string StateCaption
        {
            get
            {
                if (State == "0")
                {
                    return "正常";
                }
                if (State == "1")
                {
                    return "已删除";
                }
                if (State == "2")
                {
                    return "冻结";
                }
                return "异常";
            }
        }
    }

}
