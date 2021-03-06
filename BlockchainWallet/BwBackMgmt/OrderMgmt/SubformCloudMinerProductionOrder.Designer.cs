﻿namespace BwBackMgmt.OrderMgmt
{
    partial class SubformCloudMinerProductionOrder
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
            this.dgvCloudMinerProductionRecord = new DevExpress.XtraGrid.GridControl();
            this.gvCloudMinerProductionRecord = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCloudMinerProductionRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCloudMinerProductionRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCloudMinerProductionRecord
            // 
            this.dgvCloudMinerProductionRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCloudMinerProductionRecord.Location = new System.Drawing.Point(0, 27);
            this.dgvCloudMinerProductionRecord.MainView = this.gvCloudMinerProductionRecord;
            this.dgvCloudMinerProductionRecord.Name = "dgvCloudMinerProductionRecord";
            this.dgvCloudMinerProductionRecord.Size = new System.Drawing.Size(1194, 603);
            this.dgvCloudMinerProductionRecord.TabIndex = 9;
            this.dgvCloudMinerProductionRecord.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCloudMinerProductionRecord});
            // 
            // gvCloudMinerProductionRecord
            // 
            this.gvCloudMinerProductionRecord.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn12,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn15,
            this.gridColumn16});
            this.gvCloudMinerProductionRecord.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvCloudMinerProductionRecord.GridControl = this.dgvCloudMinerProductionRecord;
            this.gvCloudMinerProductionRecord.Name = "gvCloudMinerProductionRecord";
            this.gvCloudMinerProductionRecord.OptionsBehavior.Editable = false;
            this.gvCloudMinerProductionRecord.OptionsBehavior.ReadOnly = true;
            this.gvCloudMinerProductionRecord.OptionsCustomization.AllowColumnMoving = false;
            this.gvCloudMinerProductionRecord.OptionsCustomization.AllowFilter = false;
            this.gvCloudMinerProductionRecord.OptionsCustomization.AllowSort = false;
            this.gvCloudMinerProductionRecord.OptionsMenu.EnableColumnMenu = false;
            this.gvCloudMinerProductionRecord.OptionsMenu.EnableFooterMenu = false;
            this.gvCloudMinerProductionRecord.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gvCloudMinerProductionRecord.OptionsView.ShowFooter = true;
            this.gvCloudMinerProductionRecord.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "流水编号";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 67;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "商品编号";
            this.gridColumn2.FieldName = "CommodityId";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "商品名称";
            this.gridColumn3.FieldName = "CommodityName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 79;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "购买时间";
            this.gridColumn6.FieldName = "BuyTime";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 153;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "产通证时间";
            this.gridColumn7.FieldName = "ProductionTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 137;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "生产次数";
            this.gridColumn8.FieldName = "ProductionCount";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 73;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "总数量";
            this.gridColumn12.FieldName = "Amount";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "合计：{0:0.##}")});
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 5;
            this.gridColumn12.Width = 139;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "QQX";
            this.gridColumn9.FieldName = "QQX";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QQX", "合计：{0:0.##}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 149;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "QQY";
            this.gridColumn10.FieldName = "QQY";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QQY", "合计：{0:0.##}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 134;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "QQL";
            this.gridColumn11.FieldName = "QQL";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QQL", "合计：{0:0.##}")});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 146;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "拥有者ID";
            this.gridColumn13.FieldName = "UserId";
            this.gridColumn13.Name = "gridColumn13";
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "昵称";
            this.gridColumn14.FieldName = "UserNickname";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 95;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "手机区号";
            this.gridColumn5.FieldName = "UserPhoneAreaId";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 99;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "手机号";
            this.gridColumn4.FieldName = "UserPhone";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 72;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "状态";
            this.gridColumn15.FieldName = "State";
            this.gridColumn15.Name = "gridColumn15";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "状态";
            this.gridColumn16.FieldName = "StateCaption";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 9;
            this.gridColumn16.Width = 45;
            // 
            // SubformCloudMinerProductionOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 630);
            this.Controls.Add(this.dgvCloudMinerProductionRecord);
            this.Name = "SubformCloudMinerProductionOrder";
            this.Text = "用户产币明细";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.dgvCloudMinerProductionRecord, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCloudMinerProductionRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCloudMinerProductionRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgvCloudMinerProductionRecord;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCloudMinerProductionRecord;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
    }
}