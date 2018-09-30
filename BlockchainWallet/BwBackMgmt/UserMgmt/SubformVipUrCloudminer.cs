using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BwBackModel.CommodityMgmt;
using BwBackModel.UserMgmt.User;
using BwServerSal;
using BwServerSal.ServiceApi.Commodity;
using BwServerSal.ServiceApi.User;
using DevExpress.XtraEditors;

namespace BwBackMgmt.UserMgmt
{
    public partial class SubformVipUrCloudminer : SubformBase
    {
        private UserInfoApi _userInfoApi = SalApiFactory<UserInfoApi>.GetSalApi();
        public VipUrCloudminerModelSend VipUrCloudminerModelSend;
        public List<VipSettingQueryModelGet> VipSettingQueryModelGets = null;
        private CommodityApi _commodityApi = SalApiFactory<CommodityApi>.GetSalApi();
        public SubformVipUrCloudminer()
        {
            InitializeComponent();
            Titel = "会员升级规则--云矿机";
        }

        private void SubformVipUrCloudminer_Load(object sender, EventArgs e)
        {
            CommodityInfoQueryModelSend commodityInfoQueryModelSend = new CommodityInfoQueryModelSend();
            commodityInfoQueryModelSend.State = "0";
            commodityInfoQueryModelSend.Type = "0";
            cmbCommodity.Properties.DataSource = _commodityApi.QueryCommodityInfo(commodityInfoQueryModelSend);
            this.cmbCommodity.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "商品名称"));
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
                    VipUrCloudminerModelSend.CloudMinerCount = Convert.ToInt32(txtCount.EditValue);
                    VipUrCloudminerModelSend.CommodityId = Convert.ToInt32(cmbCommodity.EditValue);
                    bool b = _userInfoApi.InsertVipUrCloudminer(VipUrCloudminerModelSend);
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
                    VipUrCloudminerModelSend.CloudMinerCount = Convert.ToInt32(txtCount.EditValue);
                    VipUrCloudminerModelSend.CommodityId = Convert.ToInt32(cmbCommodity.EditValue);
                    b = _userInfoApi.UpdateVipUrCloudminer(VipUrCloudminerModelSend);
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
            txtCount.EditValue = VipUrCloudminerModelSend.CloudMinerCount;
            cmbCommodity.EditValue = VipUrCloudminerModelSend.CommodityId;
        }

        public override void SetEnable(bool enable)
        {
            txtCount.ReadOnly = !enable;
            cmbCommodity.ReadOnly = !enable;
        }

        public override bool CheckNull()
        {
            if (cmbCommodity.EditValue == null)
            {
                XtraMessageBox.Show("请选择云矿机");
                return false;
            }
            try
            {
                int a = Convert.ToInt32(txtCount.EditValue);
                if (a < 1) throw new Exception();
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
