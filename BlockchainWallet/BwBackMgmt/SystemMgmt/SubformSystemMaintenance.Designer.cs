namespace BwBackMgmt.SystemMgmt
{
    partial class SubformSystemMaintenance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtS = new DevExpress.XtraEditors.DateEdit();
            this.btnCheck = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtE = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dtS.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtE.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtS
            // 
            this.dtS.EditValue = null;
            this.dtS.Location = new System.Drawing.Point(124, 81);
            this.dtS.Name = "dtS";
            this.dtS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtS.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtS.Properties.DisplayFormat.FormatString = "G";
            this.dtS.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtS.Properties.EditFormat.FormatString = "G";
            this.dtS.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtS.Properties.Mask.EditMask = "G";
            this.dtS.Size = new System.Drawing.Size(202, 20);
            this.dtS.TabIndex = 1;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(151, 204);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "确定";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 84);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "开始时间";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(56, 137);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "结束时间";
            // 
            // dtE
            // 
            this.dtE.EditValue = null;
            this.dtE.Location = new System.Drawing.Point(124, 134);
            this.dtE.Name = "dtE";
            this.dtE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtE.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dtE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtE.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dtE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtE.Properties.Mask.EditMask = "G";
            this.dtE.Size = new System.Drawing.Size(202, 20);
            this.dtE.TabIndex = 4;
            // 
            // SubformSystemMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 267);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.dtE);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.dtS);
            this.Name = "SubformSystemMaintenance";
            this.Text = "维护信息";
            this.Controls.SetChildIndex(this.dtS, 0);
            this.Controls.SetChildIndex(this.btnCheck, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.dtE, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtS.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtE.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtS;
        private DevExpress.XtraEditors.SimpleButton btnCheck;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtE;
    }
}