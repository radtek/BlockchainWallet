namespace BwBackMgmt.PassCardMgmt
{
    partial class FormPassCardMgmt
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnUpdateCurrentAmount = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.dgvPassCard = new DevExpress.XtraGrid.GridControl();
            this.gvPassCard = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPassCard)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnUpdateCurrentAmount);
            this.groupControl1.Controls.Add(this.btnQuery);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1199, 86);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "查询条件";
            // 
            // btnUpdateCurrentAmount
            // 
            this.btnUpdateCurrentAmount.Location = new System.Drawing.Point(87, 57);
            this.btnUpdateCurrentAmount.Name = "btnUpdateCurrentAmount";
            this.btnUpdateCurrentAmount.Size = new System.Drawing.Size(97, 23);
            this.btnUpdateCurrentAmount.TabIndex = 4;
            this.btnUpdateCurrentAmount.Text = "修改当前价格";
            this.btnUpdateCurrentAmount.Click += new System.EventHandler(this.btnUpdateCurrentAmount_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(12, 57);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(57, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvPassCard
            // 
            this.dgvPassCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPassCard.Location = new System.Drawing.Point(0, 86);
            this.dgvPassCard.MainView = this.gvPassCard;
            this.dgvPassCard.Name = "dgvPassCard";
            this.dgvPassCard.Size = new System.Drawing.Size(1199, 564);
            this.dgvPassCard.TabIndex = 11;
            this.dgvPassCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPassCard});
            // 
            // gvPassCard
            // 
            this.gvPassCard.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn4});
            this.gvPassCard.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvPassCard.GridControl = this.dgvPassCard;
            this.gvPassCard.Name = "gvPassCard";
            this.gvPassCard.OptionsBehavior.Editable = false;
            this.gvPassCard.OptionsBehavior.ReadOnly = true;
            this.gvPassCard.OptionsCustomization.AllowSort = false;
            this.gvPassCard.OptionsView.ColumnAutoWidth = false;
            this.gvPassCard.OptionsView.ShowGroupPanel = false;
            this.gvPassCard.OptionsView.ShowViewCaption = true;
            this.gvPassCard.ViewCaption = "云矿机规格";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "编号";
            this.gridColumn3.FieldName = "Id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "通证代码";
            this.gridColumn7.FieldName = "Code";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 64;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "通证名称";
            this.gridColumn8.FieldName = "Caption";
            this.gridColumn8.ImageAlignment = System.Drawing.StringAlignment.Far;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 98;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "发行总量";
            this.gridColumn2.FieldName = "TotalAmount";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 181;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "合约地址";
            this.gridColumn1.FieldName = "ContractAddress";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 640;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "当前价格";
            this.gridColumn4.FieldName = "CurrentAmount";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 68;
            // 
            // FormPassCardMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 650);
            this.Controls.Add(this.dgvPassCard);
            this.Controls.Add(this.groupControl1);
            this.Name = "FormPassCardMgmt";
            this.Text = "通证管理";
            this.Load += new System.EventHandler(this.FormPassCardMgmt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPassCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dgvPassCard;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPassCard;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton btnUpdateCurrentAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;

    }
}