namespace BwBackMgmt.UserMgmt
{
    partial class FormVipSetting
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAddVipInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgvVipUrFans = new DevExpress.XtraGrid.GridControl();
            this.gvVipUrFans = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnUpdateVipUrFans = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteVipUrFans = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddVipUrFans = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgvVipUrCloudminer = new DevExpress.XtraGrid.GridControl();
            this.gvVipUrCloudminer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnUpdateVipUrCloudminer = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteVipUrCloudminer = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsertVipUrCloudminer = new DevExpress.XtraEditors.SimpleButton();
            this.gpVipList = new DevExpress.XtraEditors.GroupControl();
            this.dgvVipInfo = new DevExpress.XtraGrid.GridControl();
            this.gvVipInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVipUrFans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVipUrFans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVipUrCloudminer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVipUrCloudminer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpVipList)).BeginInit();
            this.gpVipList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVipInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVipInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnAddVipInfo);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnQuery);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1219, 36);
            this.panelControl1.TabIndex = 3;
            // 
            // btnAddVipInfo
            // 
            this.btnAddVipInfo.Enabled = false;
            this.btnAddVipInfo.Location = new System.Drawing.Point(79, 7);
            this.btnAddVipInfo.Name = "btnAddVipInfo";
            this.btnAddVipInfo.Size = new System.Drawing.Size(49, 23);
            this.btnAddVipInfo.TabIndex = 2;
            this.btnAddVipInfo.Text = "修改";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(152, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(12, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(49, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "刷新";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dgvVipUrFans);
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 21);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(846, 263);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "粉丝设置";
            // 
            // dgvVipUrFans
            // 
            this.dgvVipUrFans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVipUrFans.Location = new System.Drawing.Point(2, 58);
            this.dgvVipUrFans.MainView = this.gvVipUrFans;
            this.dgvVipUrFans.Name = "dgvVipUrFans";
            this.dgvVipUrFans.Size = new System.Drawing.Size(842, 203);
            this.dgvVipUrFans.TabIndex = 4;
            this.dgvVipUrFans.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVipUrFans});
            // 
            // gvVipUrFans
            // 
            this.gvVipUrFans.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gvVipUrFans.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvVipUrFans.GridControl = this.dgvVipUrFans;
            this.gvVipUrFans.Name = "gvVipUrFans";
            this.gvVipUrFans.OptionsBehavior.Editable = false;
            this.gvVipUrFans.OptionsBehavior.ReadOnly = true;
            this.gvVipUrFans.OptionsCustomization.AllowSort = false;
            this.gvVipUrFans.OptionsView.ShowGroupPanel = false;
            this.gvVipUrFans.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvVipUrFans_RowCellClick);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "编号";
            this.gridColumn4.FieldName = "Id";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "会员等级";
            this.gridColumn5.FieldName = "VipName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "数量";
            this.gridColumn6.FieldName = "FansCount";
            this.gridColumn6.ImageAlignment = System.Drawing.StringAlignment.Far;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 840;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnUpdateVipUrFans);
            this.panelControl2.Controls.Add(this.btnDeleteVipUrFans);
            this.panelControl2.Controls.Add(this.btnAddVipUrFans);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 21);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(842, 37);
            this.panelControl2.TabIndex = 0;
            // 
            // btnUpdateVipUrFans
            // 
            this.btnUpdateVipUrFans.Enabled = false;
            this.btnUpdateVipUrFans.Location = new System.Drawing.Point(84, 6);
            this.btnUpdateVipUrFans.Name = "btnUpdateVipUrFans";
            this.btnUpdateVipUrFans.Size = new System.Drawing.Size(50, 23);
            this.btnUpdateVipUrFans.TabIndex = 5;
            this.btnUpdateVipUrFans.Text = "修改";
            this.btnUpdateVipUrFans.Click += new System.EventHandler(this.btnUpdateVipUrFans_Click);
            // 
            // btnDeleteVipUrFans
            // 
            this.btnDeleteVipUrFans.Enabled = false;
            this.btnDeleteVipUrFans.Location = new System.Drawing.Point(147, 6);
            this.btnDeleteVipUrFans.Name = "btnDeleteVipUrFans";
            this.btnDeleteVipUrFans.Size = new System.Drawing.Size(50, 23);
            this.btnDeleteVipUrFans.TabIndex = 1;
            this.btnDeleteVipUrFans.Text = "删除";
            this.btnDeleteVipUrFans.Click += new System.EventHandler(this.btnDeleteVipUrFans_Click);
            // 
            // btnAddVipUrFans
            // 
            this.btnAddVipUrFans.Enabled = false;
            this.btnAddVipUrFans.Location = new System.Drawing.Point(16, 6);
            this.btnAddVipUrFans.Name = "btnAddVipUrFans";
            this.btnAddVipUrFans.Size = new System.Drawing.Size(50, 23);
            this.btnAddVipUrFans.TabIndex = 0;
            this.btnAddVipUrFans.Text = "新增";
            this.btnAddVipUrFans.Click += new System.EventHandler(this.btnAddVipUrFans_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgvVipUrCloudminer);
            this.groupControl2.Controls.Add(this.panelControl3);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 284);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(846, 348);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "云矿机";
            // 
            // dgvVipUrCloudminer
            // 
            this.dgvVipUrCloudminer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVipUrCloudminer.Location = new System.Drawing.Point(2, 58);
            this.dgvVipUrCloudminer.MainView = this.gvVipUrCloudminer;
            this.dgvVipUrCloudminer.Name = "dgvVipUrCloudminer";
            this.dgvVipUrCloudminer.Size = new System.Drawing.Size(842, 288);
            this.dgvVipUrCloudminer.TabIndex = 5;
            this.dgvVipUrCloudminer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVipUrCloudminer});
            // 
            // gvVipUrCloudminer
            // 
            this.gvVipUrCloudminer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gvVipUrCloudminer.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvVipUrCloudminer.GridControl = this.dgvVipUrCloudminer;
            this.gvVipUrCloudminer.Name = "gvVipUrCloudminer";
            this.gvVipUrCloudminer.OptionsBehavior.Editable = false;
            this.gvVipUrCloudminer.OptionsBehavior.ReadOnly = true;
            this.gvVipUrCloudminer.OptionsCustomization.AllowSort = false;
            this.gvVipUrCloudminer.OptionsView.ShowGroupPanel = false;
            this.gvVipUrCloudminer.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvVipUrCloudminer_RowCellClick);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "编号";
            this.gridColumn7.FieldName = "Id";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "云矿机型号";
            this.gridColumn8.FieldName = "CommodityName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 100;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "数量";
            this.gridColumn9.FieldName = "CloudMinerCount";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 840;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.btnUpdateVipUrCloudminer);
            this.panelControl3.Controls.Add(this.btnDeleteVipUrCloudminer);
            this.panelControl3.Controls.Add(this.btnInsertVipUrCloudminer);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 21);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(842, 37);
            this.panelControl3.TabIndex = 1;
            // 
            // btnUpdateVipUrCloudminer
            // 
            this.btnUpdateVipUrCloudminer.Enabled = false;
            this.btnUpdateVipUrCloudminer.Location = new System.Drawing.Point(84, 8);
            this.btnUpdateVipUrCloudminer.Name = "btnUpdateVipUrCloudminer";
            this.btnUpdateVipUrCloudminer.Size = new System.Drawing.Size(50, 23);
            this.btnUpdateVipUrCloudminer.TabIndex = 4;
            this.btnUpdateVipUrCloudminer.Text = "修改";
            this.btnUpdateVipUrCloudminer.Click += new System.EventHandler(this.btnUpdateVipUrCloudminer_Click);
            // 
            // btnDeleteVipUrCloudminer
            // 
            this.btnDeleteVipUrCloudminer.Enabled = false;
            this.btnDeleteVipUrCloudminer.Location = new System.Drawing.Point(147, 8);
            this.btnDeleteVipUrCloudminer.Name = "btnDeleteVipUrCloudminer";
            this.btnDeleteVipUrCloudminer.Size = new System.Drawing.Size(50, 23);
            this.btnDeleteVipUrCloudminer.TabIndex = 3;
            this.btnDeleteVipUrCloudminer.Text = "删除";
            this.btnDeleteVipUrCloudminer.Click += new System.EventHandler(this.btnDeleteVipUrCloudminer_Click);
            // 
            // btnInsertVipUrCloudminer
            // 
            this.btnInsertVipUrCloudminer.Enabled = false;
            this.btnInsertVipUrCloudminer.Location = new System.Drawing.Point(16, 8);
            this.btnInsertVipUrCloudminer.Name = "btnInsertVipUrCloudminer";
            this.btnInsertVipUrCloudminer.Size = new System.Drawing.Size(50, 23);
            this.btnInsertVipUrCloudminer.TabIndex = 2;
            this.btnInsertVipUrCloudminer.Text = "新增";
            this.btnInsertVipUrCloudminer.Click += new System.EventHandler(this.btnInsertVipUrCloudminer_Click);
            // 
            // gpVipList
            // 
            this.gpVipList.Controls.Add(this.dgvVipInfo);
            this.gpVipList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gpVipList.Location = new System.Drawing.Point(0, 36);
            this.gpVipList.Name = "gpVipList";
            this.gpVipList.Size = new System.Drawing.Size(369, 634);
            this.gpVipList.TabIndex = 6;
            this.gpVipList.Text = "会员列表";
            // 
            // dgvVipInfo
            // 
            this.dgvVipInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVipInfo.Location = new System.Drawing.Point(2, 21);
            this.dgvVipInfo.MainView = this.gvVipInfo;
            this.dgvVipInfo.Name = "dgvVipInfo";
            this.dgvVipInfo.Size = new System.Drawing.Size(365, 611);
            this.dgvVipInfo.TabIndex = 3;
            this.dgvVipInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVipInfo});
            // 
            // gvVipInfo
            // 
            this.gvVipInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvVipInfo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvVipInfo.GridControl = this.dgvVipInfo;
            this.gvVipInfo.Name = "gvVipInfo";
            this.gvVipInfo.OptionsBehavior.Editable = false;
            this.gvVipInfo.OptionsBehavior.ReadOnly = true;
            this.gvVipInfo.OptionsCustomization.AllowSort = false;
            this.gvVipInfo.OptionsView.ShowGroupPanel = false;
            this.gvVipInfo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvVipInfo_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "会员等级";
            this.gridColumn2.FieldName = "Rank";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "会员名称";
            this.gridColumn3.FieldName = "Name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.groupControl2);
            this.groupControl3.Controls.Add(this.groupControl1);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(369, 36);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(850, 634);
            this.groupControl3.TabIndex = 7;
            this.groupControl3.Text = "会员升级规则";
            // 
            // FormVipSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 670);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.gpVipList);
            this.Controls.Add(this.panelControl1);
            this.Name = "FormVipSetting";
            this.Text = "会员设置";
            this.Load += new System.EventHandler(this.FormVipSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVipUrFans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVipUrFans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVipUrCloudminer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVipUrCloudminer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpVipList)).EndInit();
            this.gpVipList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVipInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVipInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl gpVipList;
        private DevExpress.XtraGrid.GridControl dgvVipInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVipInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl dgvVipUrFans;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVipUrFans;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl dgvVipUrCloudminer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVipUrCloudminer;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SimpleButton btnAddVipUrFans;
        private DevExpress.XtraEditors.SimpleButton btnDeleteVipUrFans;
        private DevExpress.XtraEditors.SimpleButton btnDeleteVipUrCloudminer;
        private DevExpress.XtraEditors.SimpleButton btnInsertVipUrCloudminer;
        private DevExpress.XtraEditors.SimpleButton btnAddVipInfo;
        private DevExpress.XtraEditors.SimpleButton btnUpdateVipUrFans;
        private DevExpress.XtraEditors.SimpleButton btnUpdateVipUrCloudminer;

    }
}