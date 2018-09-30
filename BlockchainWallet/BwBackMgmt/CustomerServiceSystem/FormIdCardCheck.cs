using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BwBackModel.CustomerServiceSystem.IdCardCertification;
using BwServerSal;
using BwServerSal.ServiceApi.CustomerServiceSystem;

namespace BwBackMgmt.CustomerServiceSystem
{
    public partial class FormIdCardCheck : FormBase
    {
        private List<IdCardCertificationModelGet> idCardCertificationModelGets;
        private IdCardCertificationApi _idCardCertificationApi = SalApiFactory<IdCardCertificationApi>.GetSalApi();
        public FormIdCardCheck()
        {
            InitializeComponent();
        }

        public void QueryIdCard()
        {
            idCardCertificationModelGets =
                _idCardCertificationApi.QueryIdCardCertification(new IdCardCertificationModelSend());
            dgvIdCardCheck.DataSource = idCardCertificationModelGets.Where(n => n.State == "0").ToList();
            gvIdCardCheck.RefreshData();
            dgvIdCardChecked.DataSource = idCardCertificationModelGets.Where(n => n.State != "0").ToList();
            gvIdCardChecked.RefreshData();
        }

        private void gvIdCardCheck_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                IdCardCertificationModelGet idCardCertificationModelGet =
                    gvIdCardCheck.GetFocusedRow() as IdCardCertificationModelGet;
                if (idCardCertificationModelGet != null)
                {
                    SubformIdCardCertification subformIdCardCertification = new SubformIdCardCertification();
                    subformIdCardCertification.IdCardCertificationModelGet = idCardCertificationModelGet;
                    subformIdCardCertification.SubformType = SubformType.Edit;
                    if (subformIdCardCertification.ShowDialog() == DialogResult.Yes)
                    {
                        dgvIdCardCheck.DataSource = idCardCertificationModelGets.Where(n => n.State == "0").ToList();
                        gvIdCardCheck.RefreshData();
                        dgvIdCardChecked.DataSource = idCardCertificationModelGets.Where(n => n.State != "0").ToList();
                        gvIdCardChecked.RefreshData();
                    }
                }
            }
        }

        private void gvIdCardChecked_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                IdCardCertificationModelGet idCardCertificationModelGet =
                    gvIdCardChecked.GetFocusedRow() as IdCardCertificationModelGet;
                if (idCardCertificationModelGet != null)
                {
                    SubformIdCardCertification subformIdCardCertification = new SubformIdCardCertification();
                    subformIdCardCertification.IdCardCertificationModelGet = idCardCertificationModelGet;
                    subformIdCardCertification.SubformType = SubformType.Show;
                    subformIdCardCertification.ShowDialog();
                }
            }
        }

        private void FormIdCardCheck_Load(object sender, EventArgs e)
        {
            QueryIdCard();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryIdCard();
        }
    }
}
