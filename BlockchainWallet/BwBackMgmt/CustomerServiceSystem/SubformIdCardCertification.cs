using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BwBackMgmt.Properties;
using BwBackModel.CustomerServiceSystem.IdCardCertification;
using BwCommon.File;
using BwServerSal;
using BwServerSal.ServiceApi.CustomerServiceSystem;
using DevExpress.XtraEditors;

namespace BwBackMgmt.CustomerServiceSystem
{
    public partial class SubformIdCardCertification : SubformBase
    {
        public IdCardCertificationModelGet IdCardCertificationModelGet;
        private IdCardCertificationApi _idCardCertificationApi = SalApiFactory<IdCardCertificationApi>.GetSalApi();
        private readonly string _filePath = Path.Combine(Path.GetTempPath(), "BlockchainWallet", "IdCard");
        public SubformIdCardCertification()
        {
            InitializeComponent();
        }

        private void QueryIdCardCertificationInfo()
        {
            IdCardCertificationModelSend idCardCertificationModelSend = new IdCardCertificationModelSend();
            idCardCertificationModelSend.Id = IdCardCertificationModelGet.Id;
            IdCardCertificationModelGet idCardCertificationModelGet = _idCardCertificationApi.QueryIdCardCertificationInfo(idCardCertificationModelSend);
            IdCardCertificationModelGet.Remark = idCardCertificationModelGet.Remark;
            IdCardCertificationModelGet.FrontImage = idCardCertificationModelGet.FrontImage;
            IdCardCertificationModelGet.ReverseImage = idCardCertificationModelGet.ReverseImage;
            BindFormData();
        }

        private void BindFormData()
        {
            txtRemark.Text = IdCardCertificationModelGet.Remark;
            txtName.Text = IdCardCertificationModelGet.Name;
            txtIdCard.Text = IdCardCertificationModelGet.IdCard;
            Task.Factory.StartNew(() =>
            {
                try
                {
                    BeginInvoke(new Action(() =>
                    {
                        pnlFrontImage.BackgroundImage = Image.FromStream(WebRequest.Create(ApiAddress.LocalHost + "/" + IdCardCertificationModelGet.FrontImage).GetResponse().GetResponseStream());
                        SaveImage(pnlFrontImage.BackgroundImage, "FrontImage" + txtIdCard.Text + ".jpg");
                    }));
                    pnlFrontImage.Tag = "0";
                }
                catch
                {
                    pnlFrontImage.BackgroundImage = Resources.ImageLoadDefeat;
                }
            });
            Task.Factory.StartNew(() =>
            {
                try
                {
                    pnlReverseImage.BackgroundImage = Image.FromStream(WebRequest.Create(ApiAddress.LocalHost + "/" + IdCardCertificationModelGet.ReverseImage).GetResponse().GetResponseStream());
                    SaveImage(pnlReverseImage.BackgroundImage, "ReverseImage" + txtIdCard.Text + ".jpg");
                    pnlReverseImage.Tag = "0";
                }
                catch
                {
                    pnlReverseImage.BackgroundImage = Resources.ImageLoadDefeat;
                }
            });
        }

        private void SaveImage(Image image, string fileName)
        {
            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }
            image.Save(Path.Combine(_filePath, fileName));
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            IdCardCheckModelSend idCardCheckModelSend = new IdCardCheckModelSend();
            idCardCheckModelSend.Id = IdCardCertificationModelGet.Id;
            idCardCheckModelSend.EmployeeId = LoginedUserInfo.Id;
            idCardCheckModelSend.Remark = txtRemark.Text;
            idCardCheckModelSend.State = "1";
            idCardCheckModelSend.Name = IdCardCertificationModelGet.Name;
            idCardCheckModelSend.UserId = IdCardCertificationModelGet.UserId;
            idCardCheckModelSend.IdCard = IdCardCertificationModelGet.IdCard;
            bool b = _idCardCertificationApi.CheckIdCard(idCardCheckModelSend);
            if (b)
            {
                IdCardCertificationModelGet.Remark = idCardCheckModelSend.Remark;
                IdCardCertificationModelGet.EmployeeId = LoginedUserInfo.Id;
                IdCardCertificationModelGet.EmployeeName = LoginedUserInfo.Name;
                IdCardCertificationModelGet.State = idCardCheckModelSend.State;
                IdCardCertificationModelGet.DisposeTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.DialogResult = DialogResult.Yes;
                Close();
            }
            else
            {
                XtraMessageBox.Show("操作失败");
            }
        }

        private void btnUnPass_Click(object sender, EventArgs e)
        {
            IdCardCheckModelSend idCardCheckModelSend = new IdCardCheckModelSend();
            idCardCheckModelSend.Id = IdCardCertificationModelGet.Id;
            idCardCheckModelSend.EmployeeId = LoginedUserInfo.Id;
            idCardCheckModelSend.Remark = txtRemark.Text;
            idCardCheckModelSend.State = "2";
            bool b = _idCardCertificationApi.CheckIdCard(idCardCheckModelSend);
            if (b)
            {
                IdCardCertificationModelGet.Remark = idCardCheckModelSend.Remark;
                IdCardCertificationModelGet.EmployeeId = LoginedUserInfo.Id;
                IdCardCertificationModelGet.EmployeeName = LoginedUserInfo.Name;
                IdCardCertificationModelGet.State = idCardCheckModelSend.State;
                IdCardCertificationModelGet.DisposeTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.DialogResult = DialogResult.Yes;
                Close();
            }
            else
            {
                XtraMessageBox.Show("操作失败");
            }
        }

        private void SubformIdCardCertification_Load(object sender, EventArgs e)
        {
            if (SubformType == SubformType.Show)
            {
                btnPass.Visible = false;
                btnUnPass.Visible = false;
                txtRemark.ReadOnly = true;
            }
            else
            {
                btnPass.Visible = true;
                btnUnPass.Visible = true;
                txtRemark.ReadOnly = false;
            }
            if (string.IsNullOrEmpty(IdCardCertificationModelGet.FrontImage) && string.IsNullOrEmpty(IdCardCertificationModelGet.ReverseImage))
            {
                QueryIdCardCertificationInfo();
            }
            else
            {
                BindFormData();
            }
        }

        private void pnlFrontImage_Click(object sender, EventArgs e)
        {
            if (pnlFrontImage.BackgroundImage != null && (string)pnlFrontImage.Tag == "0")
            {
                Process.Start(Path.Combine(_filePath, "FrontImage" + txtIdCard.Text + ".jpg"));
            }
        }

        private void pnlReverseImage_Click(object sender, EventArgs e)
        {
            if (pnlReverseImage.BackgroundImage != null && (string)pnlReverseImage.Tag == "0")
            {
                Process.Start(Path.Combine(_filePath, "ReverseImage" + txtIdCard.Text + ".jpg"));
            }
        }
    }
}
