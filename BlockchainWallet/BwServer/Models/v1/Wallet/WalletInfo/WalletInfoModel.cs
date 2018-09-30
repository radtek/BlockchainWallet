using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BwServer.Models.v1.Wallet.WalletInfo
{
    public class WalletInfoModelGet
    {
        public int UserId { get; set; }
    }
    public class WalletInfoModelResult
    {
        public int Id { get; set; }
        public int UId { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyCaption { get; set; }
        public decimal AllAmount { get; set; }
        public decimal CanUseAmount { get; set; }
        public decimal FrozenAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public string WalletAddress { get; set; }
    }

}