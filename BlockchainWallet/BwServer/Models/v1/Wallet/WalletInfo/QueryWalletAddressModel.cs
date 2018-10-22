using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Wallet.WalletInfo
{
    public class QueryWalletAddressModelGet
    {
        public int UserId { get; set; }
    }
    public class QueryWalletAddressModelResult
    {
        public string WalletAddress { get; set; }
    }
}