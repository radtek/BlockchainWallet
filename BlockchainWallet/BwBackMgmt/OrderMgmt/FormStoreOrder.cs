using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BwBackModel;
using BwBackModel.CommodityMgmt;
using BwServerSal;
using BwServerSal.ServiceApi.Commodity;

namespace BwBackMgmt.OrderMgmt
{
    public partial class FormStoreOrder : FormBase
    {
        private readonly StoreOrderApi _storeOrderApi = SalApiFactory<StoreOrderApi>.GetSalApi();
        private List<StoreOrderQueryModelGet> _storeOrderQueryModelGets = new List<StoreOrderQueryModelGet>();
        private readonly DataPagingModelSend _dataPagingModelSend = null;
        private readonly StoreOrderQueryModelSend _storeOrderQueryModelSend = null;
        private DataPagingModelGet _dataPagingModelGet;
        public FormStoreOrder()
        {
            InitializeComponent();
            _storeOrderQueryModelSend = new StoreOrderQueryModelSend();
            _dataPagingModelSend = new DataPagingModelSend();
            _storeOrderQueryModelSend.DataPagingModel = _dataPagingModelSend;
        }

        public void BindDgvData()
        {
            _storeOrderQueryModelGets = _storeOrderApi.QueryStoreOrder(_storeOrderQueryModelSend, out _dataPagingModelGet);
            dnStoreOrder.DataSource = _storeOrderQueryModelGets;
            dgvStoreOrder.DataSource = _storeOrderQueryModelGets;
            gvStoreOrder.RefreshData();
            dnStoreOrder.TextStringFormat = string.Format("当前行数{0}至{1}  总行数{2}，当前页数{3} 总页数{4} ", _storeOrderQueryModelGets.Count == 0 ? 0 : _dataPagingModelSend.StartSize,
                _dataPagingModelSend.StartSize - 1 + _storeOrderQueryModelGets.Count, _dataPagingModelGet.TotalCount, _storeOrderQueryModelGets.Count <= 0 ? 1 : _dataPagingModelSend.StartSize / _dataPagingModelSend.PageCount + 1, (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount) == 0 ? 1 : _dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount + (_dataPagingModelGet.TotalCount % _dataPagingModelSend.PageCount > 0 ? 1 : 0));
        }

        private void dnStoreOrder_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
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

        /// <summary>
        /// 筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _dataPagingModelSend.StartSize = 0;
            BindDgvData();
            dnStoreOrder.CustomButtons[0].Enabled = false;
            dnStoreOrder.CustomButtons[1].Enabled = false;
            dnStoreOrder.CustomButtons[2].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
            dnStoreOrder.CustomButtons[3].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
        }

        private void FormStoreOrder_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }
    }
}
