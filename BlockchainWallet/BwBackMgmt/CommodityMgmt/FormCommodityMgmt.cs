using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BwBackModel.CommodityMgmt;
using BwServerSal;
using BwServerSal.ServiceApi.Commodity;

namespace BwBackMgmt.CommodityMgmt
{
    public partial class FormCommodityMgmt : FormBase
    {
        private readonly CommodityApi _commodityApi = SalApiFactory<CommodityApi>.GetSalApi();
        private List<CommodityInfoQueryModelGet> _listCommodityInfoQueryModelGets = null;
        public FormCommodityMgmt()
        {
            InitializeComponent();
        }
        private void FormCommodityMgmt_Load(object sender, EventArgs e)
        {
            QueryCommodityInfo();
        }

        private void QueryCommodityInfo()
        {
            CommodityInfoQueryModelSend commodityInfoQueryModelSend = new CommodityInfoQueryModelSend();
            commodityInfoQueryModelSend.State = "-1";
            commodityInfoQueryModelSend.Type = "-1";
            _listCommodityInfoQueryModelGets = _commodityApi.QueryCommodityInfo(commodityInfoQueryModelSend);
            dgvCommodityInfo.DataSource = _listCommodityInfoQueryModelGets;
            gvCommodityInfo.RefreshData();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryCommodityInfo();
        }
    }
}
