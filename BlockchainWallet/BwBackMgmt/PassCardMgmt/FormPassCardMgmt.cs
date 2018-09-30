using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BwBackModel.WalletMgmt;
using BwServerSal;
using BwServerSal.ServiceApi.Wallet;

namespace BwBackMgmt.PassCardMgmt
{
    public partial class FormPassCardMgmt : FormBase
    {
        private List<CurrencyInfoModelGet> _currencyInfoModelGets;
        private readonly CurrencyInfoApi _currencyInfoApi = SalApiFactory<CurrencyInfoApi>.GetSalApi();
        public FormPassCardMgmt()
        {
            InitializeComponent();
        }

        private void QueryCurrency()
        {
            CurrencyInfoModelSend currencyInfoModelSend = new CurrencyInfoModelSend();
            _currencyInfoModelGets = _currencyInfoApi.QueryCurrency(currencyInfoModelSend);
            dgvPassCard.DataSource = _currencyInfoModelGets;
            gvPassCard.RefreshData();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryCurrency();
        }

        private void FormPassCardMgmt_Load(object sender, EventArgs e)
        {
            QueryCurrency();
        }

        private void btnUpdateCurrentAmount_Click(object sender, EventArgs e)
        {
            CurrencyInfoModelGet currencyInfoModelGet = gvPassCard.GetFocusedRow() as CurrencyInfoModelGet;
            if (currencyInfoModelGet != null && currencyInfoModelGet.Id == 0)
            {
                SubFormPassCardCurrentAmount subFormPassCardCurrentAmount = new SubFormPassCardCurrentAmount();
                subFormPassCardCurrentAmount.SubformType = SubformType.Insert;
                subFormPassCardCurrentAmount.CurrencyInfoModelGet = currencyInfoModelGet;
                if (subFormPassCardCurrentAmount.ShowDialog() == DialogResult.OK)
                {
                    QueryCurrency();
                }
            }
        }


    }
}
