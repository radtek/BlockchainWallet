using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BwBackMgmt
{
    /// <summary>
    /// 登录的用户信息
    /// </summary>
    public static class LoginedUserInfo
    {
        public static int Id { get; set; }
        public static string AccountId { get; set; }
        public static string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public static string Name { get; set; }
        public static string Token { get; set; }
    }
}
