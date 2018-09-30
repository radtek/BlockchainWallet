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
using BwBackModel.Agent;
using BwBackModel.Agent.CloudMinerProduction;
using BwServerSal;
using BwServerSal.ServiceApi.Agent;

namespace BwBackMgmt.OrderMgmt
{
    public partial class FormUserCloudMinerProductionOrder : FormBase
    {
        private readonly CloudMinerProductionApi _cloudMinerProductionApi = SalApiFactory<CloudMinerProductionApi>.GetSalApi();
        private List<UserCloudMinerProductionModelGet> _userCloudMinerProductionModelGets = new List<UserCloudMinerProductionModelGet>();
        private readonly DataPagingModelSend _dataPagingModelSend = null;
        private readonly UserCloudMinerProductionModelSend _userCloudMinerProductionModelSend = null;
        private DataPagingModelGet _dataPagingModelGet;
        public FormUserCloudMinerProductionOrder()
        {
            InitializeComponent();
            _userCloudMinerProductionModelSend = new UserCloudMinerProductionModelSend();
            _dataPagingModelSend = new DataPagingModelSend();
            _userCloudMinerProductionModelSend.DataPagingModel = _dataPagingModelSend;
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

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindDgvData()
        {
            _userCloudMinerProductionModelGets = _cloudMinerProductionApi.QueryUserCloudMinerProductionRecord(_userCloudMinerProductionModelSend, out _dataPagingModelGet);
            dnStoreOrder.DataSource = _userCloudMinerProductionModelGets;
            dgvUserCloudMinerProductionRecord.DataSource = _userCloudMinerProductionModelGets;
            gvUserCloudMinerProductionRecord.RefreshData();
            dnStoreOrder.TextStringFormat = string.Format("当前行数{0}至{1}  总行数{2}，当前页数{3} 总页数{4} ", _userCloudMinerProductionModelGets.Count == 0 ? 0 : _dataPagingModelSend.StartSize,
                _dataPagingModelSend.StartSize - 1 + _userCloudMinerProductionModelGets.Count, _dataPagingModelGet.TotalCount, _userCloudMinerProductionModelGets.Count <= 0 ? 1 : (_dataPagingModelSend.StartSize / _dataPagingModelSend.PageCount + 1), (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount) == 0 ? 1 : (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount + (_dataPagingModelGet.TotalCount % _dataPagingModelSend.PageCount > 0 ? 1 : 0)));
        }

        /// <summary>
        /// 全局变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void gvUserCloudMinerProductionRecord_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            UserCloudMinerProductionModelGet userCloudMinerProductionModelGet = gvUserCloudMinerProductionRecord.GetFocusedRow() as UserCloudMinerProductionModelGet;
            if (userCloudMinerProductionModelGet != null && e.Clicks == 2)
            {
                SubformCloudMinerProductionOrder subformCloudMinerProductionOrder = new SubformCloudMinerProductionOrder();
                subformCloudMinerProductionOrder.CloudMinerProductionModelSend.UserId =
                    userCloudMinerProductionModelGet.UserId;
                subformCloudMinerProductionOrder.CloudMinerProductionModelSend.ProductionDate =
                    userCloudMinerProductionModelGet.ProductionTime;
                subformCloudMinerProductionOrder.SubformType = SubformType.Show;
                subformCloudMinerProductionOrder.ShowDialog();
            }
        }

    }
}
