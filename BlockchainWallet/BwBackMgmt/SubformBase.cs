using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BwBackMgmt
{
    public partial class SubformBase : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public SubformType SubformType { get; set; }
        public string Titel { get; set; }
        public SubformBase()
        {
            InitializeComponent();
        }

        private void SubformBase_Load(object sender, EventArgs e)
        {
            BindData();
            switch (SubformType)
            {
                case SubformType.Show:
                    Text = "查看" + Titel;
                    SetEnable(false);
                    break;
                case SubformType.Insert:
                    Text = "新增" + Titel;
                    SetEnable(true);
                    break;
                case SubformType.Edit:
                    Text = "修改" + Titel;
                    SetEnable(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public virtual void BindData()
        {

        }

        public virtual void SetEnable(bool enable)
        {

        }

        public virtual bool CheckNull()
        {
            return false;
        }
    }

    public enum SubformType
    {
        Show,
        Insert,
        Edit
    }
}
