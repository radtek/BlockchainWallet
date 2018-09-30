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
    public partial class FormCloudMiner : FormBase
    {
        private CloudMinerApi _cloudMinerApi = SalApiFactory<CloudMinerApi>.GetSalApi();
        private List<CloudMinerInfoModelGet> _listCloudMinerInfoModelGets;
        public FormCloudMiner()
        {
            InitializeComponent();
        }

        private void QueryCloudMiner()
        {
            CloudMinerInfoModelSend cloudMinerInfoModelSend = new CloudMinerInfoModelSend();
            cloudMinerInfoModelSend.Id = -1;
            _listCloudMinerInfoModelGets = _cloudMinerApi.QueryCommodityInfo(cloudMinerInfoModelSend);
            dgvCloudMiner.DataSource = _listCloudMinerInfoModelGets;
            gvCloudMiner.RefreshData();
        }

        private void gvCloudMiner_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CloudMinerInfoModelGet model = gvCloudMiner.GetFocusedRow() as CloudMinerInfoModelGet;
            if (model != null)
            {
                dgvCloudMinerManufacture.DataSource = model.CloudMinerManufactureModelResults;
                gvCloudMinerManufacture.RefreshData();

                dgvVipUrFans.DataSource = model.BuyCommodityRuleFansModelResults;
                gvVipUrFans.RefreshData();

                List<CloudMinerInfoModelGet> list = new List<CloudMinerInfoModelGet>();
                list.Add(model);
                dgvVip.DataSource = list;

                dgvPriceDetail.DataSource = model.CloudMinerPriceDetailModelResults;
                gvPriceDetail.RefreshData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryCloudMiner();
        }

        private void FormCloudMiner_Load(object sender, EventArgs e)
        {
            QueryCloudMiner();
        }
    }
}
