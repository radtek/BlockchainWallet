using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BwBackModel;
using BwBackModel.Agent.CloudMinerProduction;
using BwBackModel.CommodityMgmt;
using BwBackModel.UserMgmt.User;
using BwServerSal;
using BwServerSal.ServiceApi.Agent;
using BwServerSal.ServiceApi.Commodity;
using BwServerSal.ServiceApi.User;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

namespace BwBackMgmt.UserMgmt
{
    public partial class FormCompanyAccount : FormBase
    {
        private List<CompanyAccountInfoQueryModelGet> _listCompanyAccountInfoQueryModelGets;
        private readonly UserInfoApi _userInfoApi = SalApiFactory<UserInfoApi>.GetSalApi();
        private DataPagingModelGet _dataPagingModelGet = new DataPagingModelGet();
        private DataPagingModelSend _dataPagingModelSend = new DataPagingModelSend();
        public FormCompanyAccount()
        {
            InitializeComponent();
            _queryGaveCommodityStoreOrderModelSend.DataPagingModel = _dataPagingModelSend;
        }

        private void FormCompanyAccount_Load(object sender, EventArgs e)
        {
            QueryCompanyAccountInfo();
        }

        public void QueryCompanyAccountInfo()
        {
            CompanyAccountInfoQueryModelSend companyAccountInfoQueryModelSend = new CompanyAccountInfoQueryModelSend();
            _listCompanyAccountInfoQueryModelGets = _userInfoApi.QueryCompanyAccountInfo(companyAccountInfoQueryModelSend);
            dgvCompayAccount.DataSource = _listCompanyAccountInfoQueryModelGets;
            gvCompayAccount.RefreshData();
        }

        private void gvCompayAccount_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            foreach (var item in pnlButtons.Controls)
            {
                if (item is SimpleButton)
                {
                    ((SimpleButton)item).Enabled = false;
                }
            }
            CompanyAccountInfoQueryModelGet companyAccountInfoQueryModelGet = gvCompayAccount.GetFocusedRow() as CompanyAccountInfoQueryModelGet;
            if (companyAccountInfoQueryModelGet != null)
            {
                dgvWalletInfo.DataSource = companyAccountInfoQueryModelGet.WalletInfoModelResults;
                gvWalletInfo.RefreshData();
                switch (companyAccountInfoQueryModelGet.Id)
                {
                    case 84:
                        btnCommanyTransfer.Enabled = true;
                        break;
                    case 1:
                        btnGaveCommodity.Enabled = true;
                        BindGaveCommodity();
                        break;
                    case 4:
                        btnTransferUser.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                dgvWalletInfo.DataSource = null;
                gvWalletInfo.RefreshData();
            }

        }

        /// <summary>
        /// 筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _dataPagingModelSend.StartSize = 0;
            CompanyAccountInfoQueryModelGet companyAccountInfoQueryModelGet = gvCompayAccount.GetFocusedRow() as CompanyAccountInfoQueryModelGet;
            if (companyAccountInfoQueryModelGet != null)
            {
                switch (companyAccountInfoQueryModelGet.Id)
                {
                    case 84:

                        break;
                    case 1:
                        BindGaveCommodityStoreOrder();
                        break;
                    case 4:

                        break;
                    default:
                        break;
                }
            }
            else
            {

            }

            dnStoreOrder.CustomButtons[0].Enabled = false;
            dnStoreOrder.CustomButtons[1].Enabled = false;
            dnStoreOrder.CustomButtons[2].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
            dnStoreOrder.CustomButtons[3].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
        }

        /// <summary>
        /// 全局变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dnStoreOrder_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
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
            CompanyAccountInfoQueryModelGet companyAccountInfoQueryModelGet = gvCompayAccount.GetFocusedRow() as CompanyAccountInfoQueryModelGet;
            if (companyAccountInfoQueryModelGet != null)
            {
                switch (companyAccountInfoQueryModelGet.Id)
                {
                    case 84:

                        break;
                    case 1:
                        BindGaveCommodityStoreOrder();
                        break;
                    case 4:

                        break;
                    default:
                        break;
                }
            }
            else
            {

            }
        }

        #region 赠送
        private void BindGaveCommodity()
        {
            gvCompanyTransaction.Columns.Clear();
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "编号", FieldName = "Id", Visible = false, VisibleIndex = 0, Width = 60 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "订单号", FieldName = "OrderNo", Visible = true, Width = 185 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "商品编号", FieldName = "CommodityId", Visible = false });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "商品名称", FieldName = "CommodityName", Visible = true, Width = 80 });
            //gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "展示图片", FieldName = "DisplayImage", Visible = true });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "商品数量", FieldName = "Count", Visible = true, Width = 70 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "收货人ID", FieldName = "ConsignorUserId", Visible = false });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "收货人手机区号", FieldName = "ConsignorPhoneAreaId", Visible = false, Width = 100 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "收货人手机号", FieldName = "ConsignorPhone", Visible = true, Width = 90 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "收货人姓名", FieldName = "ConsignorName", Visible = true, Width = 90 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "单价", FieldName = "UnitPrice", Visible = true, Width = 100 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "数量", FieldName = "Count", Visible = true, Width = 35 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "折后通证数量", FieldName = "TotalPrice", Visible = true, Width = 110 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "订单时间", FieldName = "OrderTime", Visible = true, Width = 126 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "购买时间", FieldName = "BuyTime", Visible = true, Width = 126 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "类型", FieldName = "Type", Visible = false });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "类型", FieldName = "TypeCaption", Visible = true, Width = 70 });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "状态", FieldName = "State", Visible = false });
            gvCompanyTransaction.Columns.Add(new GridColumn() { Caption = "状态", FieldName = "StateCaption", Visible = true, Width = 70 });
            gvCompanyTransaction.BestFitColumns();
        }

        private void BindGaveCommodityStoreOrder()
        {
            _queryGaveCommodityStoreOrderModelGets = _storeOrderApi.QueryGaveCommodityStoreOrder(_queryGaveCommodityStoreOrderModelSend, out _dataPagingModelGet);
            dnStoreOrder.DataSource = _queryGaveCommodityStoreOrderModelGets;
            dgvCompanyTransaction.DataSource = _queryGaveCommodityStoreOrderModelGets;
            gvCompanyTransaction.RefreshData();
            dnStoreOrder.TextStringFormat = string.Format("当前行数{0}至{1}  总行数{2}，当前页数{3} 总页数{4} ", _queryGaveCommodityStoreOrderModelGets.Count == 0 ? 0 : _dataPagingModelSend.StartSize,
                _dataPagingModelSend.StartSize - 1 + _queryGaveCommodityStoreOrderModelGets.Count, _dataPagingModelGet.TotalCount, _queryGaveCommodityStoreOrderModelGets.Count <= 0 ? 1 : (_dataPagingModelSend.StartSize / _dataPagingModelSend.PageCount + 1), (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount) == 0 ? 1 : (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount + (_dataPagingModelGet.TotalCount % _dataPagingModelSend.PageCount > 0 ? 1 : 0)));
        }

        private List<QueryGaveCommodityStoreOrderModelGet> _queryGaveCommodityStoreOrderModelGets = new List<QueryGaveCommodityStoreOrderModelGet>();
        private StoreOrderApi _storeOrderApi = SalApiFactory<StoreOrderApi>.GetSalApi();
        private QueryGaveCommodityStoreOrderModelSend _queryGaveCommodityStoreOrderModelSend = new QueryGaveCommodityStoreOrderModelSend();


        private void btnGaveCommodity_Click(object sender, EventArgs e)
        {
            SubformGaveCommodity subformGaveCommodity = new SubformGaveCommodity();
            subformGaveCommodity.ShowDialog();
            btnSearch_Click(null, null);
        }
        #endregion

        private void btnCommanyTransfer_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            QueryCompanyAccountInfo();
        }


    }
}
