using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BwBackModel;
using BwBackModel.UserMgmt.User;
using BwBackModel.WalletMgmt;
using BwServerSal;
using BwServerSal.ServiceApi.User;
using BwServerSal.ServiceApi.Wallet;
using DevExpress.XtraEditors;

namespace BwBackMgmt.PassCardMgmt
{
    public partial class FormQQX : FormBase
    {
        private readonly CurrencyInfoApi _currencyInfoApi = SalApiFactory<CurrencyInfoApi>.GetSalApi();
        private List<CurrencyPriceRecordModelGet> _userInfoQueryModelGets = new List<CurrencyPriceRecordModelGet>();
        private readonly DataPagingModelSend _dataPagingModelSend = null;
        private readonly CurrencyPriceRecordModelSend _currencyPriceRecordModelSend = null;
        private DataPagingModelGet _dataPagingModelGet;
        public FormQQX()
        {
            InitializeComponent();
            _currencyPriceRecordModelSend = new CurrencyPriceRecordModelSend();
            _dataPagingModelSend = new DataPagingModelSend();
            _currencyPriceRecordModelSend.DataPagingModel = _dataPagingModelSend;
        }
        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _dataPagingModelSend.StartSize = 0;
            BindDgvData();
            dnStoreOrder.CustomButtons[0].Enabled = false;
            dnStoreOrder.CustomButtons[1].Enabled = false;
            dnStoreOrder.CustomButtons[2].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
            dnStoreOrder.CustomButtons[3].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindDgvData()
        {
            _userInfoQueryModelGets = _currencyInfoApi.QueryCurrencyPriceRecord(_currencyPriceRecordModelSend, out _dataPagingModelGet);
            dnStoreOrder.DataSource = _userInfoQueryModelGets;
            dgvRecord.DataSource = _userInfoQueryModelGets;
            gvRecord.RefreshData();
            dnStoreOrder.TextStringFormat = string.Format("当前行数{0}至{1}  总行数{2}，当前页数{3} 总页数{4} ", _userInfoQueryModelGets.Count == 0 ? 0 : _dataPagingModelSend.StartSize,
                _dataPagingModelSend.StartSize - 1 + _userInfoQueryModelGets.Count, _dataPagingModelGet.TotalCount, _userInfoQueryModelGets.Count <= 0 ? 1 : (_dataPagingModelSend.StartSize / _dataPagingModelSend.PageCount + 1), (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount) == 0 ? 1 : (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount + (_dataPagingModelGet.TotalCount % _dataPagingModelSend.PageCount > 0 ? 1 : 0)));
        }

        /// <summary>
        /// 全局变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dnOrder_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            switch (e.Button.Tag.ToString())
            {
                case "0"://第一页 
                    _dataPagingModelSend.StartSize = 1;
                    dnStoreOrder.CustomButtons[0].Enabled = false;
                    dnStoreOrder.CustomButtons[1].Enabled = false;
                    dnStoreOrder.CustomButtons[2].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
                    dnStoreOrder.CustomButtons[3].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
                    break;
                case "1": //上一页
                    _dataPagingModelSend.StartSize = _dataPagingModelSend.StartSize - _dataPagingModelSend.PageCount;
                    dnStoreOrder.CustomButtons[0].Enabled = _dataPagingModelSend.StartSize > 1;
                    dnStoreOrder.CustomButtons[1].Enabled = _dataPagingModelSend.StartSize > 1;
                    dnStoreOrder.CustomButtons[2].Enabled = true;
                    dnStoreOrder.CustomButtons[3].Enabled = true;
                    break;
                case "2": //下一页
                    _dataPagingModelSend.StartSize = _dataPagingModelSend.StartSize + _dataPagingModelSend.PageCount;
                    dnStoreOrder.CustomButtons[0].Enabled = true;
                    dnStoreOrder.CustomButtons[1].Enabled = true;
                    dnStoreOrder.CustomButtons[2].Enabled = _dataPagingModelGet.TotalCount - _dataPagingModelSend.StartSize > _dataPagingModelSend.PageCount;
                    dnStoreOrder.CustomButtons[3].Enabled = _dataPagingModelGet.TotalCount - _dataPagingModelSend.StartSize > _dataPagingModelSend.PageCount;
                    break;
                case "3": //最后一页
                    _dataPagingModelSend.StartSize = _dataPagingModelGet.TotalCount - (_dataPagingModelGet.TotalCount % _dataPagingModelSend.PageCount <= 1 ? _dataPagingModelSend.PageCount : _dataPagingModelGet.TotalCount % _dataPagingModelSend.PageCount) + 1;
                    dnStoreOrder.CustomButtons[0].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
                    dnStoreOrder.CustomButtons[1].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
                    dnStoreOrder.CustomButtons[2].Enabled = false;
                    dnStoreOrder.CustomButtons[3].Enabled = false;
                    break;
            }
            BindDgvData();
        }

        private void gvRecord_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (e.RowHandle == 0)
                {
                    XtraMessageBox.Show("不能更改最新日志记录，如需修改价格请至通证管理修改");
                    return;
                }

                CurrencyPriceRecordModelGet currencyPriceRecordModelGet = gvRecord.GetFocusedRow() as CurrencyPriceRecordModelGet;
                if (currencyPriceRecordModelGet != null)
                {
                    SubFormPassCardCurrentAmount subFormPassCardCurrentAmount = new SubFormPassCardCurrentAmount();
                    subFormPassCardCurrentAmount.SubformType = SubformType.Edit;
                    CurrencyPriceRecordModelSend currencyPriceRecordModelSend = new CurrencyPriceRecordModelSend();
                    currencyPriceRecordModelSend.Id = currencyPriceRecordModelGet.Id;
                    currencyPriceRecordModelSend.Price = currencyPriceRecordModelGet.Price;
                    currencyPriceRecordModelSend.UpdateEmployeeId = LoginedUserInfo.Id;
                    subFormPassCardCurrentAmount.CurrencyPriceRecordModelSend = currencyPriceRecordModelSend;
                    if (subFormPassCardCurrentAmount.ShowDialog() == DialogResult.OK)
                    {
                        currencyPriceRecordModelGet.Price = currencyPriceRecordModelSend.Price;
                        gvRecord.RefreshData();
                    }
                }
            }
        }
    }
}
