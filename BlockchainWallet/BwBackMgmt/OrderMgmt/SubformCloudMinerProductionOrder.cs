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
    public partial class SubformCloudMinerProductionOrder : SubformBase
    {
        private readonly CloudMinerProductionApi _cloudMinerProductionApi = SalApiFactory<CloudMinerProductionApi>.GetSalApi();
        private List<CloudMinerProductionModelGet> _cloudMinerProductionModelGets = new List<CloudMinerProductionModelGet>();
        private readonly DataPagingModelSend _dataPagingModelSend = null;
        public readonly CloudMinerProductionModelSend CloudMinerProductionModelSend = null;
        private DataPagingModelGet _dataPagingModelGet;

        /// <summary>
        /// 
        /// </summary>
        public SubformCloudMinerProductionOrder()
        {
            InitializeComponent();
            CloudMinerProductionModelSend = new CloudMinerProductionModelSend();
            _dataPagingModelSend = new DataPagingModelSend();
            CloudMinerProductionModelSend.DataPagingModel = _dataPagingModelSend;
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
            _cloudMinerProductionModelGets = _cloudMinerProductionApi.QueryCloudMinerProductionRecord(CloudMinerProductionModelSend, out _dataPagingModelGet);
            dgvCloudMinerProductionRecord.DataSource = _cloudMinerProductionModelGets;
            gvCloudMinerProductionRecord.RefreshData();
        }
    }
}
