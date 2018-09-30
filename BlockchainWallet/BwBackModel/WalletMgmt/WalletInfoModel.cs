using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.WalletMgmt
{
    public class WalletInfoModelSend
    {

    }

    public class WalletInfoModelGet
    {
        public int Id { get; set; }
        public int UId { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyCaption { get; set; }
        public decimal AllAmount { get; set; }
        public decimal CanUseAmount { get; set; }
        public decimal FrozenAmount { get; set; }
    }
}
