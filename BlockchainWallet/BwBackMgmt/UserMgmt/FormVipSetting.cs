using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BwBackModel.UserMgmt.User;
using BwServerSal;
using BwServerSal.ServiceApi.User;
using DevExpress.XtraEditors;

namespace BwBackMgmt.UserMgmt
{
    public partial class FormVipSetting : FormBase
    {
        private List<VipSettingQueryModelGet> _vipSettingQueryModelGets;
        private readonly UserInfoApi _userInfoApi = SalApiFactory<UserInfoApi>.GetSalApi();
        public FormVipSetting()
        {
            InitializeComponent();
        }
        private void FormVipSetting_Load(object sender, EventArgs e)
        {
            QueryVipSetting();

        }

        private void QueryVipSetting()
        {
            VipSettingQueryModelSend vipSettingQueryModelSend = new VipSettingQueryModelSend();
            _vipSettingQueryModelGets = _userInfoApi.QueryVipSetting(vipSettingQueryModelSend);
            dgvVipInfo.DataSource = _vipSettingQueryModelGets;
            gvVipInfo.RefreshData();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryVipSetting();
        }

        private void gvVipInfo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            VipSettingQueryModelGet vipSettingQueryModelGet = gvVipInfo.GetFocusedRow() as VipSettingQueryModelGet;
            if (vipSettingQueryModelGet != null)
            {
                dgvVipUrFans.DataSource = vipSettingQueryModelGet.VipUrFanses;
                gvVipUrFans.RefreshData();

                dgvVipUrCloudminer.DataSource = vipSettingQueryModelGet.VipUrCloudmineres;
                gvVipUrCloudminer.RefreshData();
            }
        }

        #region 粉丝操作
        private void gvVipUrFans_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                VipSettingQueryModelGet vipSettingQueryModelGet = gvVipInfo.GetFocusedRow() as VipSettingQueryModelGet;
                VipUrFans vipUrFans = gvVipUrFans.GetFocusedRow() as VipUrFans;
                if (vipSettingQueryModelGet != null && vipUrFans != null)
                {
                    SubformVipUrFans subformVipUrFans = new SubformVipUrFans();
                    subformVipUrFans.SubformType = SubformType.Show;
                    VipUrFansModelSend vipUrFansModelSend = new VipUrFansModelSend();
                    vipUrFansModelSend.Id = vipUrFans.Id;
                    vipUrFansModelSend.FansVipId = vipUrFans.FansVipId;
                    vipUrFansModelSend.FansCount = vipUrFans.FansCount;
                    vipUrFansModelSend.VipId = vipSettingQueryModelGet.Id;
                    subformVipUrFans.VipUrFansModelSend = vipUrFansModelSend;
                    subformVipUrFans._vipSettingQueryModelGets = _vipSettingQueryModelGets;
                    subformVipUrFans.ShowDialog();
                }
            }
        }
        private void btnAddVipUrFans_Click(object sender, EventArgs e)
        {
            VipSettingQueryModelGet vipSettingQueryModelGet = gvVipInfo.GetFocusedRow() as VipSettingQueryModelGet;
            if (vipSettingQueryModelGet != null)
            {
                SubformVipUrFans subformVipUrFans = new SubformVipUrFans();
                subformVipUrFans.SubformType = SubformType.Insert;
                VipUrFansModelSend vipUrFansModelSend = new VipUrFansModelSend();
                vipUrFansModelSend.VipId = vipSettingQueryModelGet.Id;
                subformVipUrFans.VipUrFansModelSend = vipUrFansModelSend;
                subformVipUrFans._vipSettingQueryModelGets = _vipSettingQueryModelGets;
                if (subformVipUrFans.ShowDialog() == DialogResult.OK)
                {
                    QueryVipSetting();
                    gvVipInfo.FocusedRowHandle = _vipSettingQueryModelGets.IndexOf(_vipSettingQueryModelGets.First(n => n.Id == vipSettingQueryModelGet.Id));
                    gvVipInfo_FocusedRowChanged(null, null);
                }
            }
        }
        private void btnUpdateVipUrFans_Click(object sender, EventArgs e)
        {
            VipSettingQueryModelGet vipSettingQueryModelGet = gvVipInfo.GetFocusedRow() as VipSettingQueryModelGet;
            VipUrFans vipUrFans = gvVipUrFans.GetFocusedRow() as VipUrFans;
            if (vipSettingQueryModelGet != null && vipUrFans != null)
            {
                SubformVipUrFans subformVipUrFans = new SubformVipUrFans();
                subformVipUrFans.SubformType = SubformType.Edit;
                VipUrFansModelSend vipUrFansModelSend = new VipUrFansModelSend();
                vipUrFansModelSend.Id = vipUrFans.Id;
                vipUrFansModelSend.FansVipId = vipUrFans.FansVipId;
                vipUrFansModelSend.FansCount = vipUrFans.FansCount;
                vipUrFansModelSend.VipId = vipSettingQueryModelGet.Id;
                subformVipUrFans.VipUrFansModelSend = vipUrFansModelSend;
                subformVipUrFans._vipSettingQueryModelGets = _vipSettingQueryModelGets;
                if (subformVipUrFans.ShowDialog() == DialogResult.OK)
                {
                    QueryVipSetting();
                    gvVipInfo.FocusedRowHandle = _vipSettingQueryModelGets.IndexOf(vipSettingQueryModelGet);
                    gvVipInfo_FocusedRowChanged(null, null);
                }
            }
        }

        private void btnDeleteVipUrFans_Click(object sender, EventArgs e)
        {
            VipSettingQueryModelGet vipSettingQueryModelGet = gvVipInfo.GetFocusedRow() as VipSettingQueryModelGet;
            VipUrFans vipUrFans = gvVipUrFans.GetFocusedRow() as VipUrFans;
            if (vipSettingQueryModelGet != null && vipUrFans != null)
            {
                VipUrFansModelSend vipUrFansModelSend = new VipUrFansModelSend();
                vipUrFansModelSend.Id = vipUrFans.Id;
                bool b = _userInfoApi.DeleteVipUrFans(vipUrFansModelSend);
                if (b)
                {
                    XtraMessageBox.Show("删除成功");
                    vipSettingQueryModelGet.VipUrFanses.Remove(vipUrFans);
                    gvVipInfo_FocusedRowChanged(null, null);
                }
                else
                {
                    XtraMessageBox.Show("删除失败");
                }
            }
        }
        #endregion

        private void btnInsertVipUrCloudminer_Click(object sender, EventArgs e)
        {
            VipSettingQueryModelGet vipSettingQueryModelGet = gvVipInfo.GetFocusedRow() as VipSettingQueryModelGet;
            if (vipSettingQueryModelGet != null)
            {
                SubformVipUrCloudminer subformVipUrCloudminer = new SubformVipUrCloudminer();
                subformVipUrCloudminer.SubformType = SubformType.Insert;
                VipUrCloudminerModelSend vipUrCloudminerModelSend = new VipUrCloudminerModelSend();
                vipUrCloudminerModelSend.VipId = vipSettingQueryModelGet.Id;
                subformVipUrCloudminer.VipUrCloudminerModelSend = vipUrCloudminerModelSend;
                subformVipUrCloudminer.VipSettingQueryModelGets = _vipSettingQueryModelGets;
                if (subformVipUrCloudminer.ShowDialog() == DialogResult.OK)
                {
                    QueryVipSetting();
                    gvVipInfo.FocusedRowHandle = _vipSettingQueryModelGets.IndexOf(_vipSettingQueryModelGets.First(n => n.Id == vipSettingQueryModelGet.Id));
                    gvVipInfo_FocusedRowChanged(null, null);
                }
            }
        }

        private void btnDeleteVipUrCloudminer_Click(object sender, EventArgs e)
        {
            VipSettingQueryModelGet vipSettingQueryModelGet = gvVipInfo.GetFocusedRow() as VipSettingQueryModelGet;
            VipUrCloudminer vipUrCloudminer = gvVipUrCloudminer.GetFocusedRow() as VipUrCloudminer;
            if (vipSettingQueryModelGet != null && vipUrCloudminer != null)
            {
                VipUrCloudminerModelSend vipUrCloudminerModelSend = new VipUrCloudminerModelSend();
                vipUrCloudminerModelSend.Id = vipUrCloudminer.Id;
                bool b = _userInfoApi.DeleteVipUrCloudminer(vipUrCloudminerModelSend);
                if (b)
                {
                    XtraMessageBox.Show("删除成功");
                    vipSettingQueryModelGet.VipUrCloudmineres.Remove(vipUrCloudminer);
                    gvVipInfo_FocusedRowChanged(null, null);
                }
                else
                {
                    XtraMessageBox.Show("删除失败");
                }
            }
        }

        private void gvVipUrCloudminer_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                VipSettingQueryModelGet vipSettingQueryModelGet = gvVipInfo.GetFocusedRow() as VipSettingQueryModelGet;
                VipUrCloudminer vipUrCloudminer = gvVipUrCloudminer.GetFocusedRow() as VipUrCloudminer;
                if (vipSettingQueryModelGet != null && vipUrCloudminer != null)
                {
                    SubformVipUrCloudminer subformVipUrCloudminer = new SubformVipUrCloudminer();
                    subformVipUrCloudminer.SubformType = SubformType.Show;
                    VipUrCloudminerModelSend vipUrCloudminerModelSend = new VipUrCloudminerModelSend();
                    vipUrCloudminerModelSend.Id = vipUrCloudminer.Id;
                    vipUrCloudminerModelSend.CloudMinerCount = vipUrCloudminer.CloudMinerCount;
                    vipUrCloudminerModelSend.CommodityId = vipUrCloudminer.CommodityId;
                    vipUrCloudminerModelSend.VipId = vipSettingQueryModelGet.Id;
                    subformVipUrCloudminer.VipUrCloudminerModelSend = vipUrCloudminerModelSend;
                    subformVipUrCloudminer.VipSettingQueryModelGets = _vipSettingQueryModelGets;
                    subformVipUrCloudminer.ShowDialog();
                }
            }
        }

        private void btnUpdateVipUrCloudminer_Click(object sender, EventArgs e)
        {
            VipSettingQueryModelGet vipSettingQueryModelGet = gvVipInfo.GetFocusedRow() as VipSettingQueryModelGet;
            VipUrCloudminer vipUrCloudminer = gvVipUrCloudminer.GetFocusedRow() as VipUrCloudminer;
            if (vipSettingQueryModelGet != null && vipUrCloudminer != null)
            {
                SubformVipUrCloudminer subformVipUrCloudminer = new SubformVipUrCloudminer();
                subformVipUrCloudminer.SubformType = SubformType.Edit;
                VipUrCloudminerModelSend vipUrCloudminerModelSend = new VipUrCloudminerModelSend();
                vipUrCloudminerModelSend.Id = vipUrCloudminer.Id;
                vipUrCloudminerModelSend.CloudMinerCount = vipUrCloudminer.CloudMinerCount;
                vipUrCloudminerModelSend.CommodityId = vipUrCloudminer.CommodityId;
                vipUrCloudminerModelSend.VipId = vipSettingQueryModelGet.Id;
                subformVipUrCloudminer.VipUrCloudminerModelSend = vipUrCloudminerModelSend;
                subformVipUrCloudminer.VipSettingQueryModelGets = _vipSettingQueryModelGets;
                if (subformVipUrCloudminer.ShowDialog() == DialogResult.OK)
                {
                    QueryVipSetting();
                    gvVipInfo.FocusedRowHandle = _vipSettingQueryModelGets.IndexOf(vipSettingQueryModelGet);
                    gvVipInfo_FocusedRowChanged(null, null);
                }
            }
        }






    }
}
