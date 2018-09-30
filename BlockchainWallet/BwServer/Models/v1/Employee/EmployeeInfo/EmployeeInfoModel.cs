using System;

namespace BwServer.Models.v1.Employee.EmployeeInfo
{
    public class EmployeeInfoModelGet
    {

    }
    public class EmployeeInfoModelResult
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
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
        /// 生日
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 用户类型：0管理员 1客服
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 账户状态：0删除 1正常 2冻结
        /// </summary>
        public string State { get; set; }
    }
}