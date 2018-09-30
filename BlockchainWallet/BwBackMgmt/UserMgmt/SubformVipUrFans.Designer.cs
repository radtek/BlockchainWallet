namespace BwBackMgmt.UserMgmt
{
    partial class SubformVipUrFans
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
            this.btnCheck = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbVipInfo = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCount = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVipInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(113, 164);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "确定";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(85, 117);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "数量";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(61, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "会员等级";
            // 
            // cmbVipInfo
            // 
            this.cmbVipInfo.Location = new System.Drawing.Point(132, 62);
            this.cmbVipInfo.Name = "cmbVipInfo";
            this.cmbVipInfo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbVipInfo.Properties.DisplayMember = "Name";
            this.cmbVipInfo.Properties.ValueMember = "Id";
            this.cmbVipInfo.Size = new System.Drawing.Size(120, 20);
            this.cmbVipInfo.TabIndex = 5;
            // 
            // txtCount
            // 
            this.txtCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCount.Location = new System.Drawing.Point(132, 117);
            this.txtCount.Name = "txtCount";
            this.txtCount.Properties.IsFloatValue = false;
            this.txtCount.Properties.Mask.EditMask = "d";
            this.txtCount.Size = new System.Drawing.Size(120, 20);
            this.txtCount.TabIndex = 6;
            // 
            // SubformVipUrFans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 222);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.cmbVipInfo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCheck);
            this.Name = "SubformVipUrFans";
            this.Text = "会员升级规则--粉丝";
            this.Load += new System.EventHandler(this.SubformVipUrFans_Load);
            this.Controls.SetChildIndex(this.btnCheck, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.cmbVipInfo, 0);
            this.Controls.SetChildIndex(this.txtCount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cmbVipInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCheck;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cmbVipInfo;
        private DevExpress.XtraEditors.SpinEdit txtCount;

    }
}