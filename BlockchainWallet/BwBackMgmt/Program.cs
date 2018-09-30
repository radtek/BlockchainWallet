using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BwCommon.Log;
using DevExpress.XtraEditors.Controls;

namespace BwBackMgmt
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DevExpress.XtraEditors.Controls.Localizer.Active = new MessboxClass();
                Application.Run(new FormLogin());
            }
            catch (Exception exception)
            {
                LogHelper.error(exception.ToString());
            }

        }
    }
    public class MessboxClass : Localizer
    {
        public override string GetLocalizedString(DevExpress.XtraEditors.Controls.StringId id)
        {
            switch (id)
            {
                case StringId.XtraMessageBoxCancelButtonText:
                    return "取消";
                case StringId.XtraMessageBoxOkButtonText:
                    return "确定";
                case StringId.XtraMessageBoxYesButtonText:
                    return "是";
                case StringId.XtraMessageBoxNoButtonText:
                    return "否";
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
}
