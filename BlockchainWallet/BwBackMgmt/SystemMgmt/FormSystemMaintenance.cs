using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BwBackMgmt.PassCardMgmt;
using BwBackModel;
using BwBackModel.SystemMgmt;
using BwBackModel.WalletMgmt;
using BwServerSal;
using BwServerSal.ServiceApi.System;
using BwServerSal.ServiceApi.Wallet;
using DevExpress.XtraEditors;

namespace BwBackMgmt.SystemMgmt
{
    public partial class FormSystemMaintenance : FormBase
    {

        private readonly SystemMaintenanceApi _systemMaintenanceApi = SalApiFactory<SystemMaintenanceApi>.GetSalApi();
        private List<SystemMaintenanceModelGet> _systemMaintenanceModelGets = new List<SystemMaintenanceModelGet>();
        private readonly DataPagingModelSend _dataPagingModelSend = null;
        private readonly SystemMaintenanceModelSend _systemMaintenanceModelSend = null;
        private DataPagingModelGet _dataPagingModelGet;

        public FormSystemMaintenance()
        {
            InitializeComponent();
            _systemMaintenanceModelSend = new SystemMaintenanceModelSend();
            _dataPagingModelSend = new DataPagingModelSend();
            _systemMaintenanceModelSend.DataPagingModel = _dataPagingModelSend;
        }
        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDgvData();
            dnStoreOrder.CustomButtons[0].Enabled = false;
            dnStoreOrder.CustomButtons[1].Enabled = false;
            dnStoreOrder.CustomButtons[2].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
            dnStoreOrder.CustomButtons[3].Enabled = _dataPagingModelGet.TotalCount > _dataPagingModelSend.PageCount;
            gvRecord_FocusedRowChanged(null, null);
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindDgvData()
        {
            _systemMaintenanceModelGets = _systemMaintenanceApi.QuerySystemMaintenanceRecord(_systemMaintenanceModelSend, out _dataPagingModelGet);
            dnStoreOrder.DataSource = _systemMaintenanceModelGets;
            dgvRecord.DataSource = _systemMaintenanceModelGets;
            gvRecord.RefreshData();
            dnStoreOrder.TextStringFormat = string.Format("当前行数{0}至{1}  总行数{2}，当前页数{3} 总页数{4} ", _systemMaintenanceModelGets.Count == 0 ? 0 : _dataPagingModelSend.StartSize,
                _dataPagingModelSend.StartSize - 1 + _systemMaintenanceModelGets.Count, _dataPagingModelGet.TotalCount, _systemMaintenanceModelGets.Count <= 0 ? 1 : (_dataPagingModelSend.StartSize / _dataPagingModelSend.PageCount + 1), (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount) == 0 ? 1 : (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount + (_dataPagingModelGet.TotalCount % _dataPagingModelSend.PageCount > 0 ? 1 : 0)));
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SystemMaintenanceModelGet systemMaintenanceModelGet = gvRecord.GetFocusedRow() as SystemMaintenanceModelGet;
            if (systemMaintenanceModelGet != null)
            {
                SystemMaintenanceModelSend systemMaintenanceModelSend = new SystemMaintenanceModelSend();
                systemMaintenanceModelSend.Id = systemMaintenanceModelGet.Id;
                systemMaintenanceModelSend.EmployeeId = LoginedUserInfo.Id;
                bool result = _systemMaintenanceApi.UpdateSystemMaintenanceRecord(systemMaintenanceModelSend);
                if (!result)
                {
                    XtraMessageBox.Show("操作失败");
                    return;
                }
                btnDelete.Enabled = false;
                systemMaintenanceModelGet.State = "1";
                systemMaintenanceModelGet.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                systemMaintenanceModelGet.UpdateEmployeeAccountId = LoginedUserInfo.AccountId;
                systemMaintenanceModelGet.UpdateEmployeeNickname = LoginedUserInfo.Name;
                gvRecord.RefreshData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SubformSystemMaintenance subformSystemMaintenance = new SubformSystemMaintenance();
            if (subformSystemMaintenance.ShowDialog() == DialogResult.OK)
            {
                btnSearch_Click(null, null);
            }
        }

        private void gvRecord_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SystemMaintenanceModelGet systemMaintenanceModelGet = gvRecord.GetFocusedRow() as SystemMaintenanceModelGet;
            if (systemMaintenanceModelGet != null)
            {
                if (systemMaintenanceModelGet.State == "0")
                {
                    btnDelete.Enabled = true;
                    return;
                }
            }
            btnDelete.Enabled = false;
        }
    }
}
