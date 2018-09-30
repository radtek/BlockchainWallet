namespace BwBackMgmt.CustomerServiceSystem
{
    partial class FormIdCardCheck
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
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.dgvIdCardCheck = new DevExpress.XtraGrid.GridControl();
            this.gvIdCardCheck = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.dgvIdCardChecked = new DevExpress.XtraGrid.GridControl();
            this.gvIdCardChecked = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdCardCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIdCardCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdCardChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIdCardChecked)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnQuery);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(0, 80);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "查询条件";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(23, 36);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(53, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "刷新";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvIdCardCheck
            // 
            this.dgvIdCardCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIdCardCheck.Location = new System.Drawing.Point(1, 21);
            this.dgvIdCardCheck.MainView = this.gvIdCardCheck;
            this.dgvIdCardCheck.Name = "dgvIdCardCheck";
            this.dgvIdCardCheck.Size = new System.Drawing.Size(0, 205);
            this.dgvIdCardCheck.TabIndex = 3;
            this.dgvIdCardCheck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvIdCardCheck});
            // 
            // gvIdCardCheck
            // 
            this.gvIdCardCheck.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gvIdCardCheck.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvIdCardCheck.GridControl = this.dgvIdCardCheck;
            this.gvIdCardCheck.Name = "gvIdCardCheck";
            this.gvIdCardCheck.OptionsBehavior.Editable = false;
            this.gvIdCardCheck.OptionsBehavior.ReadOnly = true;
            this.gvIdCardCheck.OptionsCustomization.AllowColumnMoving = false;
            this.gvIdCardCheck.OptionsCustomization.AllowFilter = false;
            this.gvIdCardCheck.OptionsCustomization.AllowSort = false;
            this.gvIdCardCheck.OptionsView.ShowGroupPanel = false;
            this.gvIdCardCheck.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvIdCardCheck_RowCellClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "编号";
            this.gridColumn2.FieldName = "Id";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "用户编号";
            this.gridColumn1.FieldName = "UserId";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "用户昵称";
            this.gridColumn3.FieldName = "UserName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 137;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "真实姓名";
            this.gridColumn5.FieldName = "Name";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 156;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "身份证号";
            this.gridColumn4.FieldName = "IdCard";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 243;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "提交时间";
            this.gridColumn6.FieldName = "SubmitTime";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 231;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "处理人ID";
            this.gridColumn7.FieldName = "EmployeeId";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "处理人名称";
            this.gridColumn8.FieldName = "EmployeeName";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "处理时间";
            this.gridColumn9.FieldName = "DisposeTime";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "状态ID";
            this.gridColumn10.FieldName = "State";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "状态";
            this.gridColumn11.FieldName = "StateCaption";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 4;
            this.gridColumn11.Width = 549;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "备注";
            this.gridColumn12.FieldName = "Remark";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgvIdCardCheck);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 80);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(0, 228);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "待处理";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.dgvIdCardChecked);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 308);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(0, 0);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "历史记录";
            // 
            // dgvIdCardChecked
            // 
            this.dgvIdCardChecked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIdCardChecked.Location = new System.Drawing.Point(0, 20);
            this.dgvIdCardChecked.MainView = this.gvIdCardChecked;
            this.dgvIdCardChecked.Name = "dgvIdCardChecked";
            this.dgvIdCardChecked.Size = new System.Drawing.Size(0, 0);
            this.dgvIdCardChecked.TabIndex = 4;
            this.dgvIdCardChecked.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvIdCardChecked});
            // 
            // gvIdCardChecked
            // 
            this.gvIdCardChecked.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24});
            this.gvIdCardChecked.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvIdCardChecked.GridControl = this.dgvIdCardChecked;
            this.gvIdCardChecked.Name = "gvIdCardChecked";
            this.gvIdCardChecked.OptionsBehavior.Editable = false;
            this.gvIdCardChecked.OptionsBehavior.ReadOnly = true;
            this.gvIdCardChecked.OptionsCustomization.AllowColumnMoving = false;
            this.gvIdCardChecked.OptionsCustomization.AllowFilter = false;
            this.gvIdCardChecked.OptionsCustomization.AllowSort = false;
            this.gvIdCardChecked.OptionsView.ShowGroupPanel = false;
            this.gvIdCardChecked.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvIdCardChecked_RowCellClick);
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "编号";
            this.gridColumn13.FieldName = "Id";
            this.gridColumn13.Name = "gridColumn13";
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "用户编号";
            this.gridColumn14.FieldName = "UserId";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 80;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "用户昵称";
            this.gridColumn15.FieldName = "UserName";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "真实姓名";
            this.gridColumn16.FieldName = "Name";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            this.gridColumn16.Width = 100;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "身份证号";
            this.gridColumn17.FieldName = "IdCard";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 2;
            this.gridColumn17.Width = 100;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "提交时间";
            this.gridColumn18.FieldName = "SubmitTime";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 3;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "处理人ID";
            this.gridColumn19.FieldName = "EmployeeId";
            this.gridColumn19.Name = "gridColumn19";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "处理人名称";
            this.gridColumn20.FieldName = "EmployeeName";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 4;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "处理时间";
            this.gridColumn21.FieldName = "DisposeTime";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 5;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "状态ID";
            this.gridColumn22.FieldName = "State";
            this.gridColumn22.Name = "gridColumn22";
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "状态";
            this.gridColumn23.FieldName = "StateCaption";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 6;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "备注";
            this.gridColumn24.FieldName = "Remark";
            this.gridColumn24.Name = "gridColumn24";
            // 
            // FormIdCardCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FormIdCardCheck";
            this.Text = "实名审核";
            this.Load += new System.EventHandler(this.FormIdCardCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdCardCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIdCardCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdCardChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIdCardChecked)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dgvIdCardCheck;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIdCardCheck;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl dgvIdCardChecked;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIdCardChecked;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
    }
}