namespace BwServer.Models.v1.Employee.EmployeeLogin
{
    public class EmployeeLoginModelGet
    {
        public string AccountId { get; set; }
        public string LoginPassword { get; set; }
    }
    public class EmployeeLoginModelResult
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
        /// Token
        /// </summary>
        public string Token { get; set; }
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
        /// 用户类型：0管理员 1客服
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 账户状态：0删除 1正常 2冻结
        /// </summary>
        public string State { get; set; }
    }
}