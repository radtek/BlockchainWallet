using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BwBackMgmt.Properties;

namespace BwBackMgmt
{
    public partial class FormIndex : FormBase
    {
        public FormIndex()
        {
            InitializeComponent();
        }

        private void FormIndex_Load(object sender, EventArgs e)
        {
            DataTable dtAccount = new DataTable();
            dtAccount.Columns.Add("Data", typeof(string));
            dtAccount.Columns.Add("Count", typeof(int));
            Random random = new Random();
            for (int i = -30; i < 0; i++)
            {
                var array = new object[] { DateTime.Now.AddDays(i).ToString("MM.d"), random.Next(100, 999) };
                dtAccount.Rows.Add(array);
            }
            ccAccount.Series[0].ArgumentDataMember = "Data";
            ccAccount.Series[0].ValueDataMembers[0] = "Count";
            ccAccount.DataSource = dtAccount;
            ccAccount.RefreshData();

            DataTable dtPassCard = new DataTable();
            dtPassCard.Columns.Add("Data", typeof(string));
            dtPassCard.Columns.Add("QQHX", typeof(int));
            dtPassCard.Columns.Add("QQHY", typeof(int));
            dtPassCard.Columns.Add("QQHL", typeof(int));
            for (int i = -30; i < 0; i++)
            {
                var array = new object[] { DateTime.Now.AddDays(i).ToString("MM.d"), random.Next(8999999, 9999999), random.Next(5999999, 9999999), random.Next(199999, 999999) };
                dtPassCard.Rows.Add(array);
            }
            ccPassCard.Series[0].ArgumentDataMember = "Data";
            ccPassCard.Series[0].ValueDataMembers[0] = "QQHX";
            ccPassCard.Series[1].ArgumentDataMember = "Data";
            ccPassCard.Series[1].ValueDataMembers[0] = "QQHY";
            ccPassCard.Series[2].ArgumentDataMember = "Data";
            ccPassCard.Series[2].ValueDataMembers[0] = "QQHL";
            ccPassCard.DataSource = dtPassCard;
            ccPassCard.RefreshData();
        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams paras = base.CreateParams;
        //        paras.ExStyle |= 0x02000000;
        //        return paras;
        //    }
        //}



    }
}
