using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwBackModel.WalletMgmt
{
    public class QueryWalletInfoModelSend : HeadDataBaseModelSend
    {

    }
    public class QueryWalletInfoModelGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phoneareaid { get; set; }
        public string Phone { get; set; }
        public decimal AllAmountQQX { get; set; }
        public decimal FrozenAmountQQX { get; set; }
        public decimal CanuseAmountQQX { get; set; }
        public decimal AllAmountQQY { get; set; }
        public decimal FrozenAmountQQY { get; set; }
        public decimal CanuseAmountQQY { get; set; }
        public decimal AllAmountQQL { get; set; }
        public decimal FrozenAmountQQL { get; set; }
        public decimal CanuseAmountQQL { get; set; }
    }
}
