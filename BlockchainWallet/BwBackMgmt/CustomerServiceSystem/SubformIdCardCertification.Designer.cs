namespace BwBackMgmt.CustomerServiceSystem
{
    partial class SubformIdCardCertification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubformIdCardCertification));
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnPass = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnPass = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.pnlFrontImage = new System.Windows.Forms.Panel();
            this.pnlReverseImage = new System.Windows.Forms.Panel();
            this.txtIdCard = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(42, 56);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "真实姓名：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(261, 56);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "身份证号：";
            // 
            // btnPass
            // 
            this.btnPass.Location = new System.Drawing.Point(300, 533);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(75, 23);
            this.btnPass.TabIndex = 9;
            this.btnPass.Text = "通过";
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnUnPass
            // 
            this.btnUnPass.Location = new System.Drawing.Point(420, 533);
            this.btnUnPass.Name = "btnUnPass";
            this.btnUnPass.Size = new System.Drawing.Size(75, 23);
            this.btnUnPass.TabIndex = 10;
            this.btnUnPass.Text = "不通过";
            this.btnUnPass.Click += new System.EventHandler(this.btnUnPass_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(44, 127);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "正面照";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(420, 127);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 14);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "反面照";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 412);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "备注：";
            // 
            // txtRemark
            // 
            this.txtRemark.EditValue = "审核失败：上传的照片不清晰或真实人照片和身份证中的照片不一致";
            this.txtRemark.Location = new System.Drawing.Point(86, 410);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(658, 103);
            this.txtRemark.TabIndex = 18;
            // 
            // pnlFrontImage
            // 
            this.pnlFrontImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlFrontImage.BackgroundImage")));
            this.pnlFrontImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlFrontImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlFrontImage.Location = new System.Drawing.Point(86, 127);
            this.pnlFrontImage.Name = "pnlFrontImage";
            this.pnlFrontImage.Size = new System.Drawing.Size(289, 249);
            this.pnlFrontImage.TabIndex = 19;
            this.pnlFrontImage.Tag = "1";
            this.pnlFrontImage.Click += new System.EventHandler(this.pnlFrontImage_Click);
            // 
            // pnlReverseImage
            // 
            this.pnlReverseImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlReverseImage.BackgroundImage")));
            this.pnlReverseImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlReverseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlReverseImage.Location = new System.Drawing.Point(462, 127);
            this.pnlReverseImage.Name = "pnlReverseImage";
            this.pnlReverseImage.Size = new System.Drawing.Size(289, 249);
            this.pnlReverseImage.TabIndex = 19;
            this.pnlReverseImage.Tag = "1";
            this.pnlReverseImage.Click += new System.EventHandler(this.pnlReverseImage_Click);
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(326, 53);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtIdCard.Properties.ReadOnly = true;
            this.txtIdCard.Size = new System.Drawing.Size(195, 18);
            this.txtIdCard.TabIndex = 20;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(108, 53);
            this.txtName.Name = "txtName";
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtName.Properties.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(121, 18);
            this.txtName.TabIndex = 21;
            // 
            // SubformIdCardCertification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 578);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtIdCard);
            this.Controls.Add(this.pnlReverseImage);
            this.Controls.Add(this.pnlFrontImage);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.btnUnPass);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Name = "SubformIdCardCertification";
            this.Text = "实名审核";
            this.Load += new System.EventHandler(this.SubformIdCardCertification_Load);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.btnPass, 0);
            this.Controls.SetChildIndex(this.btnUnPass, 0);
            this.Controls.SetChildIndex(this.labelControl5, 0);
            this.Controls.SetChildIndex(this.labelControl6, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.Controls.SetChildIndex(this.pnlFrontImage, 0);
            this.Controls.SetChildIndex(this.pnlReverseImage, 0);
            this.Controls.SetChildIndex(this.txtIdCard, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnPass;
        private DevExpress.XtraEditors.SimpleButton btnUnPass;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private System.Windows.Forms.Panel pnlFrontImage;
        private System.Windows.Forms.Panel pnlReverseImage;
        private DevExpress.XtraEditors.TextEdit txtIdCard;
        private DevExpress.XtraEditors.TextEdit txtName;
    }
}