using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BwBackModel.UserMgmt.EmployeeInfo;
using BwServerSal;
using BwServerSal.ServiceApi.Employee;

namespace BwBackMgmt.UserMgmt
{
    public partial class FormEmployeeAccount : FormBase
    {
        private readonly EmployeeInfoApi _employeeInfoApi = SalApiFactory<EmployeeInfoApi>.GetSalApi();
        private List<EmployeeInfoQueryModelGet> _listEmployeeInfoModelGets = null;
        public FormEmployeeAccount()
        {
            InitializeComponent();
        }
        private void FormEmployeeAccount_Load(object sender, EventArgs e)
        {
            QueryEmployeeInfo();
        }

        private void QueryEmployeeInfo()
        {
            EmployeeInfoQueryModelSend employeeInfoModelSend = new EmployeeInfoQueryModelSend();
            _listEmployeeInfoModelGets = _employeeInfoApi.QuerEmployeeInfoModel(employeeInfoModelSend);
            dgvEmployee.DataSource = _listEmployeeInfoModelGets;
            gvEmployee.RefreshData();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryEmployeeInfo();
        }
    }
}
