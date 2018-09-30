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
using BwBackModel.Agent.CloudMinerDistribution;
using BwServerSal;
using BwServerSal.ServiceApi.Agent;

namespace BwBackMgmt.OrderMgmt
{
    public partial class SubformCloudMinerDistributionOrder : SubformBase
    {

        private readonly CloudMinerDistributionApi _cloudMinerDistributionApi = SalApiFactory<CloudMinerDistributionApi>.GetSalApi();
        private List<CloudMinerDistributionModelGet> _cloudMinerDistributionModelGets = new List<CloudMinerDistributionModelGet>();
        private readonly DataPagingModelSend _dataPagingModelSend = null;
        public readonly CloudMinerDistributionModelSend CloudMinerDistributionModelSend = null;
        private DataPagingModelGet _dataPagingModelGet;

        public SubformCloudMinerDistributionOrder()
        {
            InitializeComponent();
            CloudMinerDistributionModelSend = new CloudMinerDistributionModelSend();
            _dataPagingModelSend = new DataPagingModelSend();
            CloudMinerDistributionModelSend.DataPagingModel = _dataPagingModelSend;
        }

        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            _dataPagingModelSend.StartSize = 0;
            _dataPagingModelSend.PageCount = 10000;
            _cloudMinerDistributionModelGets = _cloudMinerDistributionApi.QueryCloudMinerProductionRecord(CloudMinerDistributionModelSend, out _dataPagingModelGet);
            dgvCloudMinerProductionRecord.DataSource = _cloudMinerDistributionModelGets;
            gvCloudMinerProductionRecord.RefreshData();
        }

    }
}
