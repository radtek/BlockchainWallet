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
using DevExpress.XtraEditors;

namespace BwBackMgmt.PassCardMgmt
{
    public partial class SubFormPassCardCurrentAmount : SubformBase
    {
        private readonly CurrencyInfoApi _currencyInfoApi = SalApiFactory<CurrencyInfoApi>.GetSalApi();
        public CurrencyInfoModelGet CurrencyInfoModelGet;
        public CurrencyPriceRecordModelSend CurrencyPriceRecordModelSend;
        public SubFormPassCardCurrentAmount()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            switch (SubformType)
            {
                case SubformType.Show:
                    break;
                case SubformType.Insert:
                    CurrencyPriceRecordModelSend = new CurrencyPriceRecordModelSend();
                    CurrencyPriceRecordModelSend.CurrencyId = CurrencyInfoModelGet.Id;
                    CurrencyPriceRecordModelSend.Price = txtAmount.Value;
                    CurrencyPriceRecordModelSend.UpdateEmployeeId = LoginedUserInfo.Id;
                    bool result = _currencyInfoApi.AddCurrencyPriceRecord(CurrencyPriceRecordModelSend);
                    if (result)
                    {
                        CurrencyInfoModelGet.CurrentAmount = CurrencyPriceRecordModelSend.Price;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("修改失败");
                        return;
                    }
                    break;
                case SubformType.Edit:
                    CurrencyPriceRecordModelSend.Price = txtAmount.Value;
                    result = _currencyInfoApi.UpdateCurrencyPriceRecord(CurrencyPriceRecordModelSend);
                    if (result)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("修改失败");
                        return;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SubFormPassCardCurrentAmount_Load(object sender, EventArgs e)
        {
            switch (SubformType)
            {
                case SubformType.Show:
                    break;
                case SubformType.Insert:
                    break;
                case SubformType.Edit:
                    txtAmount.Value = CurrencyPriceRecordModelSend.Price;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
