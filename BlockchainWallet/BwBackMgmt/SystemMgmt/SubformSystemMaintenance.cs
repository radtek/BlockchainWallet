using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BwBackModel.SystemMgmt;
using BwServerSal;
using BwServerSal.ServiceApi.System;
using DevExpress.XtraEditors;

namespace BwBackMgmt.SystemMgmt
{
    public partial class SubformSystemMaintenance : SubformBase
    {
        private readonly SystemMaintenanceApi _systemMaintenanceApi = SalApiFactory<SystemMaintenanceApi>.GetSalApi();
        public SubformSystemMaintenance()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (dtS.EditValue == null)
            {
                XtraMessageBox.Show("开始维护时间不能为空");
                return;
            }

            if (dtE.EditValue == null)
            {
                XtraMessageBox.Show("结束维护时间不能为空");
                return;
            }

            if (Convert.ToDateTime(dtS.EditValue) >= Convert.ToDateTime(dtE.EditValue))
            {
                XtraMessageBox.Show("开始维护时间不能大于等于结束维护时间");
                return;
            }

            SystemMaintenanceModelSend systemMaintenanceModelSend = new SystemMaintenanceModelSend();
            systemMaintenanceModelSend.EmployeeId = LoginedUserInfo.Id;
            systemMaintenanceModelSend.MaintenanceTimeBegin = Convert.ToDateTime(dtS.EditValue).ToString("yyyy-MM-dd HH:mm:ss");
            systemMaintenanceModelSend.MaintenanceTimeEnd = Convert.ToDateTime(dtE.EditValue).ToString("yyyy-MM-dd HH:mm:ss");
            bool result = _systemMaintenanceApi.InsertSystemMaintenanceRecord(systemMaintenanceModelSend);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
