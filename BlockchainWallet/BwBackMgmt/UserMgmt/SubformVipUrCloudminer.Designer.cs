namespace BwBackMgmt.UserMgmt
{
    partial class SubformVipUrCloudminer
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
            this.txtCount = new DevExpress.XtraEditors.SpinEdit();
            this.cmbCommodity = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCheck = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCommodity.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCount
            // 
            this.txtCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCount.Location = new System.Drawing.Point(145, 117);
            this.txtCount.Name = "txtCount";
            this.txtCount.Properties.Mask.EditMask = "d";
            this.txtCount.Size = new System.Drawing.Size(120, 20);
            this.txtCount.TabIndex = 11;
            // 
            // cmbCommodity
            // 
            this.cmbCommodity.Location = new System.Drawing.Point(145, 62);
            this.cmbCommodity.Name = "cmbCommodity";
            this.cmbCommodity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCommodity.Properties.DisplayMember = "Name";
            this.cmbCommodity.Properties.ValueMember = "Id";
            this.cmbCommodity.Size = new System.Drawing.Size(120, 20);
            this.cmbCommodity.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(62, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "云矿机型号";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(98, 117);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "数量";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(126, 164);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 7;
            this.btnCheck.Text = "确定";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // SubformVipUrCloudminer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 222);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.cmbCommodity);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCheck);
            this.Name = "SubformVipUrCloudminer";
            this.Text = "会员升级规则--云矿机";
            this.Load += new System.EventHandler(this.SubformVipUrCloudminer_Load);
            this.Controls.SetChildIndex(this.btnCheck, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.cmbCommodity, 0);
            this.Controls.SetChildIndex(this.txtCount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCommodity.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit txtCount;
        private DevExpress.XtraEditors.LookUpEdit cmbCommodity;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCheck;

    }
}