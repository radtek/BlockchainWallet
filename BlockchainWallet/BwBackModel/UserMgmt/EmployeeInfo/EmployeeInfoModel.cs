using System;

namespace BwBackModel.UserMgmt.EmployeeInfo
{

    public class EmployeeInfoQueryModelSend
    {

    }

    public class EmployeeInfoQueryModelGet
    {
        /// <summary>
        /// 编号
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 账号 6至18位数字和字母
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
        /// 手机区号
        /// </summary>
        public string PhoneAreaId { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 0男 1女 2无性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 0男 1女 2无性别
        /// </summary>
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

        public string Birthday { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday1
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(Birthday);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 用户类型：0管理员 1客服
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 用户类型：0管理员 1客服 
        /// </summary>
        public string TypeCaption
        {
            get
            {
                if (Type == "0")
                {
                    return "管理员";
                }
                if (Type == "1")
                {
                    return "客服";
                }
                return "管理员";
            }
        }
        /// <summary>
        /// 账户状态：0正常 1删除 2冻结
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
                    return "删除";
                }
                return "冻结";
            }
        }
    }
}
