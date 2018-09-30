using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BwBackMgmt
{
    public partial class FormBase : XtraForm
    {
        public FormBase()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            TopLevel = false;
        }
    }
}
