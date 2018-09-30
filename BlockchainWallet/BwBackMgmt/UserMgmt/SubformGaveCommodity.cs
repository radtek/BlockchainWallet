using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BwBackModel;
using BwBackModel.CommodityMgmt;
using BwBackModel.UserMgmt.User;
using BwServerSal;
using BwServerSal.ServiceApi.Commodity;
using BwServerSal.ServiceApi.User;
using DevExpress.XtraEditors;

namespace BwBackMgmt.UserMgmt
{
    public partial class SubformGaveCommodity : SubformBase
    {
        private readonly UserInfoApi _userInfoApi = SalApiFactory<UserInfoApi>.GetSalApi();
        private List<UserInfoQueryModelGet> _userInfoQueryModelGets = new List<UserInfoQueryModelGet>();
        private readonly DataPagingModelSend _dataPagingModelSend = null;
        private readonly UserInfoQueryModelSend _userInfoQueryModelSend = null;
        private DataPagingModelGet _dataPagingModelGet;

        private readonly CloudMinerApi _cloudMinerApi = SalApiFactory<CloudMinerApi>.GetSalApi();
        private List<CloudMinerInfoModelGet> _cloudMinerInfoModelGets = null;

        private StoreOrderApi _storeOrderApi = SalApiFactory<StoreOrderApi>.GetSalApi();
        private readonly CreateGaveCommodityStoreOrderModelSend _createGaveCommodityStoreOrderModelSend = new CreateGaveCommodityStoreOrderModelSend();
        public int OrderId { get; set; }

        public SubformGaveCommodity()
        {
            InitializeComponent();
            _userInfoQueryModelSend = new UserInfoQueryModelSend();
            _dataPagingModelSend = new DataPagingModelSend();
            _userInfoQueryModelSend.DataPagingModel = _dataPagingModelSend;
            btnSearch_Click(null, null);
        }
        private void SubformGaveCommodity_Load(object sender, EventArgs e)
        {
            _cloudMinerInfoModelGets = _cloudMinerApi.QueryCommodityInfo(new CloudMinerInfoModelSend() { });
            cmdCommodity.Properties.DataSource = _cloudMinerInfoModelGets;
            cmdCommodity.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "商品名称"));
            //cmdCommodity.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurchaseRestrictionCount", "限购数量"));
            cmdCommodity.ItemIndex = 0;
            gvRecord.FocusedRowHandle = 0;
        }

        private void BindCloudMiner()
        {

        }

        /// <summary>
        /// 筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _dataPagingModelSend.StartSize = 0;
            _userInfoQueryModelSend.Phone = txtPhone.Text;
            _userInfoQueryModelSend.Name = txtName.Text;
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
            _userInfoQueryModelGets = _userInfoApi.QueryUserInfo(_userInfoQueryModelSend, out _dataPagingModelGet);
            dnStoreOrder.DataSource = _userInfoQueryModelGets;
            dgvRecord.DataSource = _userInfoQueryModelGets;
            gvRecord.RefreshData();
            dnStoreOrder.TextStringFormat = string.Format("当前行数{0}至{1}  总行数{2}，当前页数{3} 总页数{4} ", _userInfoQueryModelGets.Count == 0 ? 0 : _dataPagingModelSend.StartSize,
                _dataPagingModelSend.StartSize - 1 + _userInfoQueryModelGets.Count, _dataPagingModelGet.TotalCount, _userInfoQueryModelGets.Count <= 0 ? 1 : (_dataPagingModelSend.StartSize / _dataPagingModelSend.PageCount + 1), (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount) == 0 ? 1 : (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount + (_dataPagingModelGet.TotalCount % _dataPagingModelSend.PageCount > 0 ? 1 : 0)));
            gvRecord_RowClick(null, null);
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

        /// <summary>
        /// 行选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvRecord_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            UserInfoQueryModelGet userInfoQueryModelGet = gvRecord.GetFocusedRow() as UserInfoQueryModelGet;
            if (userInfoQueryModelGet != null)
            {
                if (!string.IsNullOrEmpty(userInfoQueryModelGet.Name))
                {
                    lbUserName.Text = userInfoQueryModelGet.Name;
                    lbUserName.ForeColor = Color.Black;
                    _createGaveCommodityStoreOrderModelSend.ConsignorUserId = userInfoQueryModelGet.Id;
                }
                else
                {
                    lbUserName.Text = "未实名认证";
                    lbUserName.ForeColor = Color.Red;
                    _createGaveCommodityStoreOrderModelSend.ConsignorUserId = -1;
                }
            }
            else
            {
                lbUserName.Text = "";
                _createGaveCommodityStoreOrderModelSend.ConsignorUserId = -1;
            }
        }

        /// <summary>
        /// 赠送商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGave_Click(object sender, EventArgs e)
        {
            if (cmdCommodity.EditValue == null)
            {
                XtraMessageBox.Show("请选择赠送的商品");
                return;
            }

            if (txtCount.Value <= 0)
            {
                XtraMessageBox.Show("赠送数量不能小于1");
                return;
            }
            if (txtCount.Value > 3)
            {
                XtraMessageBox.Show("赠送数量不能大于3");
                return;
            }
            UserInfoQueryModelGet userInfoQueryModelGet = gvRecord.GetFocusedRow() as UserInfoQueryModelGet;
            if (userInfoQueryModelGet == null)
            {
                XtraMessageBox.Show("请选择收货送人");
                return;
            }
            if (string.IsNullOrEmpty(userInfoQueryModelGet.Name))
            {
                XtraMessageBox.Show("此账号未实名认证");
                return;
            }
            _createGaveCommodityStoreOrderModelSend.CommodityId = Convert.ToInt32(cmdCommodity.EditValue);
            _createGaveCommodityStoreOrderModelSend.Count = txtCount.Value;
            string messages = string.Empty;
            bool reslut = _storeOrderApi.CreateGaveCommodityStoreOrder(_createGaveCommodityStoreOrderModelSend, out messages);
            if (reslut)
            {
                //this.DialogResult = DialogResult.OK;
                XtraMessageBox.Show("赠送成功");
            }
            else
            {
                XtraMessageBox.Show(string.Format("赠送失败:{0}", messages));
            }
        }


    }
}
