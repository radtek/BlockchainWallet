namespace BwBackMgmt.PassCardMgmt
{
    partial class SubFormPassCardCurrentAmount
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
            this.txtAmount = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(153, 204);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "确定";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtAmount.Location = new System.Drawing.Point(122, 105);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.Increment = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.txtAmount.Properties.Mask.EditMask = "n3";
            this.txtAmount.Size = new System.Drawing.Size(155, 20);
            this.txtAmount.TabIndex = 8;
            // 
            // SubFormPassCardCurrentAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 270);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnCheck);
            this.Name = "SubFormPassCardCurrentAmount";
            this.Text = "价格";
            this.Load += new System.EventHandler(this.SubFormPassCardCurrentAmount_Load);
            this.Controls.SetChildIndex(this.btnCheck, 0);
            this.Controls.SetChildIndex(this.txtAmount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCheck;
        private DevExpress.XtraEditors.SpinEdit txtAmount;
    }
}