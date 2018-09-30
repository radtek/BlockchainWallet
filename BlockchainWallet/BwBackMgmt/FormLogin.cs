using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BwBackModel.UserMgmt.Login;
using BwCommon.Log;
using BwServerSal;
using BwServerSal.ServiceApi;
using BwServerSal.ServiceApi.Employee;
using DevExpress.XtraEditors;

namespace BwBackMgmt
{
    public partial class FormLogin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private LoginApi _loginApi = SalApiFactory<LoginApi>.GetSalApi();
        public FormLogin()
        {
            InitializeComponent();
#if DEBUG
            txtAccount.Text = "admin";
            txtPassword.Text = "admin";
#endif
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lbErrorMessages.Visible = false;
            if (string.IsNullOrEmpty(txtAccount.Text))
            {
                lbAccountNullError.Visible = true;
                return;
            }
            lbAccountNullError.Visible = false;
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lbPasswordNullError.Visible = true;
                return;
            }
            lbPasswordNullError.Visible = false;
            LoginModelSend loginModelSend = new LoginModelSend();
            loginModelSend.AccountId = txtAccount.Text;
            loginModelSend.LoginPassword = txtPassword.Text;
            LoginModelGet loginModelGet = _loginApi.Login(loginModelSend);
            if (loginModelGet != null)
            {
                LoginedUserInfo.AccountId = loginModelGet.AccountId;
                LoginedUserInfo.Name = loginModelGet.Nickname;
                LoginedUserInfo.Token = loginModelGet.Token;
                LoginedUserInfo.Id = loginModelGet.Id;
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                lbErrorMessages.Visible = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
