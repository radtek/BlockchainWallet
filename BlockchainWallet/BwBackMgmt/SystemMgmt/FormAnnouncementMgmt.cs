using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BwBackModel.SystemMgmt;
using BwBackModel.UserMgmt.User;
using BwServerSal;
using BwServerSal.ServiceApi.System;
using DevExpress.XtraEditors;

namespace BwBackMgmt.SystemMgmt
{
    public partial class FormAnnouncementMgmt : FormBase
    {
        private AnnouncementApi _announcementApi = SalApiFactory<AnnouncementApi>.GetSalApi();
        private List<AnnouncementInfoModelGet> _announcementInfoModelGets;
        private AnnouncementInfoModelSend _announcementInfoModelSend;
        private SubformType _subformType;
        public FormAnnouncementMgmt()
        {
            InitializeComponent();
            _subformType = SubformType.Show;
        }
        private void FormAnnouncementMgmt_Load(object sender, EventArgs e)
        {
            QueryAnnouncementInfo();
        }
        private void QueryAnnouncementInfo()
        {
            AnnouncementInfoModelSend announcementInfoModelSend = new AnnouncementInfoModelSend();
            _announcementInfoModelGets = _announcementApi.QueryAnnouncementInfo(announcementInfoModelSend);
            dgvAnnouncementInfo.DataSource = _announcementInfoModelGets;
            gvAnnouncementInfo.RefreshData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SetEnable(true);
            _subformType = SubformType.Insert;
            _announcementInfoModelSend = new AnnouncementInfoModelSend();
            txtContent.Text = _announcementInfoModelSend.Content;
            txtTitel.Text = _announcementInfoModelSend.Titel;
            dtPublishTime.EditValue = DateTime.Now;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AnnouncementInfoModelGet announcementInfoModelGet = gvAnnouncementInfo.GetFocusedRow() as AnnouncementInfoModelGet;
            if (announcementInfoModelGet != null)
            {
                if (XtraMessageBox.Show("删除数据不可恢复，是否删除", "操作提示", MessageBoxButtons.YesNo) == DialogResult.No) return;

                AnnouncementInfoModelSend announcementInfoModelSend = new AnnouncementInfoModelSend();
                announcementInfoModelSend.Id = announcementInfoModelGet.Id;
                bool b = _announcementApi.DeleteAnnouncementInfo(announcementInfoModelSend);
                if (b)
                {
                    XtraMessageBox.Show("删除成功");
                    txtContent.Text = txtTitel.Text = "";
                    dtPublishTime.EditValue = null;
                    SetEnable(false);
                    _announcementInfoModelGets.Remove(announcementInfoModelGet);
                    dgvAnnouncementInfo.DataSource = _announcementInfoModelGets;
                    gvAnnouncementInfo.RefreshData();
                }
                else
                {
                    XtraMessageBox.Show("删除失败");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_subformType == SubformType.Insert)
            {
                _announcementInfoModelSend.Content = txtContent.Text;
                _announcementInfoModelSend.Titel = txtTitel.Text;
                _announcementInfoModelSend.DisplayTime = dtPublishTime.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
                _announcementInfoModelSend.PublishEmployeeId = LoginedUserInfo.Id;
                bool b = _announcementApi.InsertAnnouncementInfo(_announcementInfoModelSend);
                if (b)
                {
                    XtraMessageBox.Show("新增成功");
                    QueryAnnouncementInfo();
                    SetEnable(false);
                }
                else
                {
                    XtraMessageBox.Show("新增失败");
                }
            }
            else if (_subformType == SubformType.Edit)
            {
                _announcementInfoModelSend.Content = txtContent.Text;
                _announcementInfoModelSend.Titel = txtTitel.Text;
                _announcementInfoModelSend.DisplayTime = dtPublishTime.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
                _announcementInfoModelSend.UpdateEmployeeId = LoginedUserInfo.Id;
                bool b = _announcementApi.UpdateAnnouncementInfo(_announcementInfoModelSend);
                if (b)
                {
                    XtraMessageBox.Show("修改成功");
                    SetEnable(false);
                    AnnouncementInfoModelGet announcementInfoModelGet = gvAnnouncementInfo.GetFocusedRow() as AnnouncementInfoModelGet;
                    if (announcementInfoModelGet != null)
                    {
                        announcementInfoModelGet.DisplayTime = _announcementInfoModelSend.DisplayTime;
                        announcementInfoModelGet.Content = _announcementInfoModelSend.Content;
                        announcementInfoModelGet.Titel = _announcementInfoModelSend.Titel;
                        announcementInfoModelGet.UpdateEmployeeId = _announcementInfoModelSend.UpdateEmployeeId;
                        announcementInfoModelGet.PublishEmployeeName = LoginedUserInfo.Name;
                        _announcementInfoModelGets.Add(announcementInfoModelGet);
                    }
                }
                else
                {
                    XtraMessageBox.Show("修改失败");
                }
            }
        }

        private void gvAnnouncementInfo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            AnnouncementInfoModelGet announcementInfoModelGet = gvAnnouncementInfo.GetFocusedRow() as AnnouncementInfoModelGet;
            if (announcementInfoModelGet != null)
            {
                SetEnable(false);
                txtContent.Text = announcementInfoModelGet.Content;
                txtTitel.Text = announcementInfoModelGet.Titel;
                dtPublishTime.EditValue = Convert.ToDateTime(announcementInfoModelGet.DisplayTime);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AnnouncementInfoModelGet announcementInfoModelGet = gvAnnouncementInfo.GetFocusedRow() as AnnouncementInfoModelGet;
            if (announcementInfoModelGet != null)
            {
                SetEnable(true);
                _subformType = SubformType.Edit;
                _announcementInfoModelSend = new AnnouncementInfoModelSend();
                _announcementInfoModelSend.Id = announcementInfoModelGet.Id;
            }
        }

        private void SetEnable(bool enable)
        {
            txtTitel.ReadOnly = !enable;
            txtContent.ReadOnly = !enable;
            dtPublishTime.ReadOnly = !enable;
            btnSave.Enabled = enable;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            QueryAnnouncementInfo();
        }

    }
}
