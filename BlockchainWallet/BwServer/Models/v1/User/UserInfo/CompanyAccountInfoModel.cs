using System.Collections.Generic;
using BwServer.Models.v1.Wallet.WalletInfo;

namespace BwServer.Models.v1.User.UserInfo
{
    public class CompanyAccountInfoModelGet
    {

    }
    public class CompanyAccountInfoModelResult
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
        /// 账户状态：0删除 1正常 2冻结
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 钱包信息
        /// </summary>
        public IList<WalletInfoModelResult> WalletInfoModelResults = new List<WalletInfoModelResult>();
    }
}