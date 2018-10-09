using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BwBackMgmt.AgentMgmt;
using BwBackMgmt.CommodityMgmt;
using BwBackMgmt.CustomerServiceSystem;
using BwBackMgmt.OrderMgmt;
using BwBackMgmt.PassCardMgmt;
using BwBackMgmt.SystemMgmt;
using BwBackMgmt.UserMgmt;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;

namespace BwBackMgmt
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Hashtable _cacheTabPage = null;

        public MainForm()
        {
            InitializeComponent();
            _cacheTabPage = new Hashtable();
            ShowTabPage<FormIndex>(this.Name);
            InitForm();
        }

        /// <summary>
        ///初始化窗体
        /// </summary>
        private void InitForm()
        {
            lbLoginUser.Caption = "欢迎您：" + LoginedUserInfo.Name;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                lbLocalTime.Caption = "当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            };
            timer.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK != XtraMessageBox.Show("是否退出程序", "操作提示", MessageBoxButtons.OKCancel))
            {
                e.Cancel = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ShowTabPage<T>(string tabPageName)
        {
            if (!_cacheTabPage.Contains(tabPageName))
            {
                XtraTabPage xtraTabPage = new XtraTabPage();
                FormBase formBase = Assembly.GetExecutingAssembly().CreateInstance(typeof(T).FullName, true) as FormBase;
                xtraTabPage.Controls.Add(formBase);
                xtraTabPage.Controls[0].Show();
                xtraTabPage.Text = formBase.Text;
                if (tabPageName == "MainForm")
                {
                    xtraTabPage.ShowCloseButton = DefaultBoolean.False;
                }
                tcMain.TabPages.Add(xtraTabPage);
                _cacheTabPage.Add(tabPageName, xtraTabPage);
            }
            if (!tcMain.TabPages.Contains(_cacheTabPage[tabPageName]))
            {
                tcMain.TabPages.Add(_cacheTabPage[tabPageName] as XtraTabPage);
            }
            tcMain.TabPages[tcMain.TabPages.IndexOf(_cacheTabPage[tabPageName] as XtraTabPage)].Show();
        }

        #region 用户管理
        private void btnVipAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormUserAccount>(e.Item.Name);
        }

        private void btnCompanyAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormCompanyAccount>(e.Item.Name);
        }
        private void btnInternalAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormEmployeeAccount>(e.Item.Name);
        }
        private void btnVipSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormVipSetting>(e.Item.Name);
        }
        #endregion

        #region 代理管理
        private void btnAgentMgmt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormAgentMgmt>(e.Item.Name);
        }

        private void btnDistributionMechanism_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormDistributionMechanism>(e.Item.Name);
        }
        #endregion

        #region 商品管理
        private void btnCommodityMgmt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormCommodityMgmt>(e.Item.Name);
        }

        private void btnCloudMiner_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormCloudMiner>(e.Item.Name);
        }

        private void btnUserCloudMiner_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormUserCloudMiner>(e.Item.Name);
        }
        #endregion

        #region 通证管理
        private void btnPassCardMgmt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormPassCardMgmt>(e.Item.Name);
        }
        private void btnQQHX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormQQX>(e.Item.Name);
        }

        private void btnQQHY_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormQQY>(e.Item.Name);
        }

        private void btnQQHL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormQQL>(e.Item.Name);
        }

        private void btnWalletMgmt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormWalletMgmt>(e.Item.Name);
        }
        #endregion

        #region 订单管理
        private void btnCommodityOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormStoreOrder>(e.Item.Name);
        }

        private void btnUserOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormUserOrder>(e.Item.Name);
        }
        private void btnProduceCoinsOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormCloudMinerProductionOrder>(e.Item.Name);
        }
        private void btnUserCloudMinerProductionOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormUserCloudMinerProductionOrder>(e.Item.Name);
        }
        private void btnUserDistributionOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormUserCloudMinerDistributionOrder>(e.Item.Name);
        }

        #endregion

        #region 客服系统
        private void btnIdCardCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormIdCardCheck>(e.Item.Name);
        }
        #endregion

        #region 系统管理
        private void btnAnnouncementMgmt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormAnnouncementMgmt>(e.Item.Name);
        }
        private void btnSystemMaintenance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowTabPage<FormSystemMaintenance>(e.Item.Name);
        }
        #endregion

        private void tcMain_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs EArg = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;
            string name = EArg.Page.Text;//得到关闭的选项卡的text
            foreach (XtraTabPage page in tcMain.TabPages)//遍历得到和关闭的选项卡一样的Text
            {
                if (page.Text == name)
                {
                    tcMain.TabPages.Remove(page);
                    return;
                }
            }
        }


    }
}
