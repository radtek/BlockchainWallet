using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BwCommon.EncryptionDecryption;
using BwCommon.Msg;

namespace EncryptionTools
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnEncryption_Click(object sender, EventArgs e)
        {
            if (txt1.Text.Length > 0 && txtKey.Text.Length == 32)
            {
                txt2.Text = AesHelper.AesEncrypt(txt1.Text, txtKey.Text);
            }
        }

        private void btnDecryption_Click(object sender, EventArgs e)
        {
            if (txt1.Text.Length > 0 && txtKey.Text.Length == 32)
            {
                txt2.Text = AesHelper.AesDecrypt(txt1.Text, txtKey.Text);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            string str = "a".GetType().Name;
            float a = 1.1f;
            string str1 = a.GetType().Name;
            decimal b = 1.11m;
            string str2 = b.GetType().Name;
            double c = 1.11;
            string str3 = c.GetType().Name;
            DateTime dt = DateTime.Now;
            string str44 = dt.GetType().Name;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            decimal a = 800M;
            int b = 150;
            decimal c = a / b;

            simpleButton1.Text = c.ToString();

            //Random random = new Random();
            //int verificationNo = random.Next(100000, 999999);
            ////int verificationNo = 123456;
            //string msg = string.Format("【QQH】您的验证码为{0},有效期10分钟，如非本人操作，请勿回复此短信", verificationNo);
            //PhoneMessagesHelper.SendDdMessages("13686847531", msg);
        }
    }
}
