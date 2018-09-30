using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BwBackModel.UserMgmt.User;
using BwServerSal;
using BwServerSal.ServiceApi.User;
using DevExpress.XtraEditors;

namespace BwBackMgmt.UserMgmt
{
    public partial class SubformVipUrFans : SubformBase
    {
        private UserInfoApi _userInfoApi = SalApiFactory<UserInfoApi>.GetSalApi();
        public VipUrFansModelSend VipUrFansModelSend;
        public List<VipSettingQueryModelGet> _vipSettingQueryModelGets = null;
        public SubformVipUrFans()
        {
            InitializeComponent();
            Titel = "会员升级规则--粉丝";
        }

        private void SubformVipUrFans_Load(object sender, EventArgs e)
        {
            cmbVipInfo.Properties.DataSource = _vipSettingQueryModelGets;
            this.cmbVipInfo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "等级名称"));
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            switch (SubformType)
            {
                case SubformType.Show:
                    this.DialogResult = DialogResult.OK;
                    Close();
                    break;
                case SubformType.Insert:
                    if (!CheckNull()) return;
                    VipUrFansModelSend.FansCount = Convert.ToInt32(txtCount.EditValue);
                    VipUrFansModelSend.FansVipId = Convert.ToInt32(cmbVipInfo.EditValue);
                    bool b = _userInfoApi.InsertVipUrFans(VipUrFansModelSend);
                    if (b)
                    {
                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("新增失败");
                    }
                    break;
                case SubformType.Edit:
                    if (!CheckNull()) return;
                    VipUrFansModelSend.FansCount = Convert.ToInt32(txtCount.EditValue);
                    VipUrFansModelSend.FansVipId = Convert.ToInt32(cmbVipInfo.EditValue);
                    b = _userInfoApi.UpdateVipUrFans(VipUrFansModelSend);
                    if (b)
                    {
                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("修改失败");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void BindData()
        {
            txtCount.EditValue = VipUrFansModelSend.FansCount;
            cmbVipInfo.EditValue = VipUrFansModelSend.FansVipId;
        }

        public override void SetEnable(bool enable)
        {
            txtCount.ReadOnly = !enable;
            cmbVipInfo.Properties.ReadOnly = !enable;
        }

        public override bool CheckNull()
        {
            if (cmbVipInfo.EditValue == null)
            {
                XtraMessageBox.Show("请选择VIP等级");
                return false;
            }
            try
            {
                int a = Convert.ToInt32(txtCount.EditValue);
                if (a < 1)
                {
                    throw new Exception();
                }
            }
            catch
            {
                XtraMessageBox.Show("请输入正确的数量");
                return false;
            }
            return true;
        }
    }
}
