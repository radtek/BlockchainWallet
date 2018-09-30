using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwBackModel.WalletMgmt;

namespace BwBackModel.UserMgmt.User
{
    public class CompanyAccountInfoQueryModelSend
    {

    }
    public class CompanyAccountInfoQueryModelGet
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
        /// 账户状态 0删除 1正常 2冻结
        /// </summary>
        public string State { get; set; }
        public string StateCaption
        {
            get
            {
                if (State == "0")
                {
                    return "已删除";
                }
                if (State == "1")
                {
                    return "正常";
                }
                if (State == "2")
                {
                    return "冻结";
                }
                return "无法获取";
            }
        }
        /// <summary>
        /// 钱包信息
        /// </summary>
        public IList<WalletInfoModelGet> WalletInfoModelResults = new List<WalletInfoModelGet>();
    }
}
