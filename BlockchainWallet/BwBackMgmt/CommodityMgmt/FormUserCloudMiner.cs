﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BwBackMgmt.OrderMgmt;
using BwBackModel;
using BwBackModel.Agent.CloudMinerDistribution;
using BwBackModel.CommodityMgmt;
using BwServerSal;
using BwServerSal.ServiceApi.Commodity;

namespace BwBackMgmt.CommodityMgmt
{
    public partial class FormUserCloudMiner : FormBase
    {
        private readonly UserCloudMinerApi _userCloudMinerApi = SalApiFactory<UserCloudMinerApi>.GetSalApi();
        private List<UserCloudMinerModelGet> _userCloudMinerModelGets = new List<UserCloudMinerModelGet>();
        private readonly DataPagingModelSend _dataPagingModelSend = null;
        private readonly UserCloudMinerModelSend _userCloudMinerModelSend = null;
        private DataPagingModelGet _dataPagingModelGet;

        public FormUserCloudMiner()
        {
            InitializeComponent();
            _userCloudMinerModelSend = new UserCloudMinerModelSend();
            _dataPagingModelSend = new DataPagingModelSend();
            _userCloudMinerModelSend.DataPagingModel = _dataPagingModelSend;
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
            _userCloudMinerModelGets = _userCloudMinerApi.QueryUserCloudMiner(_userCloudMinerModelSend, out _dataPagingModelGet);
            dnStoreOrder.DataSource = _userCloudMinerModelGets;
            dgvRecord.DataSource = _userCloudMinerModelGets;
            gvRecord.RefreshData();
            dnStoreOrder.TextStringFormat = string.Format("当前行数{0}至{1}  总行数{2}，当前页数{3} 总页数{4} ", _userCloudMinerModelGets.Count == 0 ? 0 : _dataPagingModelSend.StartSize,
                _dataPagingModelSend.StartSize - 1 + _userCloudMinerModelGets.Count, _dataPagingModelGet.TotalCount, _userCloudMinerModelGets.Count <= 0 ? 1 : (_dataPagingModelSend.StartSize / _dataPagingModelSend.PageCount + 1), (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount) == 0 ? 1 : (_dataPagingModelGet.TotalCount / _dataPagingModelSend.PageCount + (_dataPagingModelGet.TotalCount % _dataPagingModelSend.PageCount > 0 ? 1 : 0)));
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
            UserCloudMinerDistributionModelGet userCloudMinerDistributionModelGet = gvRecord.GetFocusedRow() as UserCloudMinerDistributionModelGet;
            if (userCloudMinerDistributionModelGet != null && e.Clicks == 2)
            {
                SubformCloudMinerDistributionOrder subformCloudMinerProductionOrder = new SubformCloudMinerDistributionOrder();
                subformCloudMinerProductionOrder.CloudMinerDistributionModelSend.UserId =
                    userCloudMinerDistributionModelGet.UserId;
                subformCloudMinerProductionOrder.CloudMinerDistributionModelSend.DistributionDate =
                    userCloudMinerDistributionModelGet.DistributionTime;
                subformCloudMinerProductionOrder.SubformType = SubformType.Show;
                subformCloudMinerProductionOrder.ShowDialog();
            }
        }
    }
}
