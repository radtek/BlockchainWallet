namespace BwBackMgmt.SystemMgmt
{
    partial class FormAnnouncementMgmt
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
            this.txtTitel = new DevExpress.XtraEditors.TextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtPublishTime = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtContent = new DevExpress.XtraEditors.MemoEdit();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.dgvAnnouncementInfo = new DevExpress.XtraGrid.GridControl();
            this.gvAnnouncementInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsert = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtPublishTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPublishTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnouncementInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAnnouncementInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.txtTitel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(881, 45);
            this.panelControl1.TabIndex = 2;
            // 
            // txtTitel
            // 
            this.txtTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitel.Location = new System.Drawing.Point(19, 12);
            this.txtTitel.Name = "txtTitel";
            this.txtTitel.Properties.NullValuePrompt = "请输入文章标题";
            this.txtTitel.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtTitel.Properties.ReadOnly = true;
            this.txtTitel.Size = new System.Drawing.Size(842, 20);
            this.txtTitel.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.panelControl2);
            this.panelControl3.Controls.Add(this.txtContent);
            this.panelControl3.Controls.Add(this.panelControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(456, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(881, 692);
            this.panelControl3.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.dtPublishTime);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 641);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(881, 51);
            this.panelControl2.TabIndex = 4;
            // 
            // dtPublishTime
            // 
            this.dtPublishTime.EditValue = null;
            this.dtPublishTime.Location = new System.Drawing.Point(133, 15);
            this.dtPublishTime.Name = "dtPublishTime";
            this.dtPublishTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPublishTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPublishTime.Properties.DisplayFormat.FormatString = "G";
            this.dtPublishTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPublishTime.Properties.EditFormat.FormatString = "G";
            this.dtPublishTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPublishTime.Properties.Mask.EditMask = "G";
            this.dtPublishTime.Properties.ReadOnly = true;
            this.dtPublishTime.Size = new System.Drawing.Size(189, 20);
            this.dtPublishTime.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(43, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "定时发布时间：";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(786, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(19, 55);
            this.txtContent.Name = "txtContent";
            this.txtContent.Properties.NullValuePrompt = "请输入文章内容";
            this.txtContent.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtContent.Properties.ReadOnly = true;
            this.txtContent.Size = new System.Drawing.Size(842, 568);
            this.txtContent.TabIndex = 3;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.dgvAnnouncementInfo);
            this.panelControl4.Controls.Add(this.panelControl5);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(456, 692);
            this.panelControl4.TabIndex = 5;
            // 
            // dgvAnnouncementInfo
            // 
            this.dgvAnnouncementInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnnouncementInfo.Location = new System.Drawing.Point(0, 45);
            this.dgvAnnouncementInfo.MainView = this.gvAnnouncementInfo;
            this.dgvAnnouncementInfo.Name = "dgvAnnouncementInfo";
            this.dgvAnnouncementInfo.Size = new System.Drawing.Size(456, 647);
            this.dgvAnnouncementInfo.TabIndex = 2;
            this.dgvAnnouncementInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAnnouncementInfo});
            // 
            // gvAnnouncementInfo
            // 
            this.gvAnnouncementInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn4});
            this.gvAnnouncementInfo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvAnnouncementInfo.GridControl = this.dgvAnnouncementInfo;
            this.gvAnnouncementInfo.Name = "gvAnnouncementInfo";
            this.gvAnnouncementInfo.OptionsBehavior.Editable = false;
            this.gvAnnouncementInfo.OptionsBehavior.ReadOnly = true;
            this.gvAnnouncementInfo.OptionsCustomization.AllowColumnMoving = false;
            this.gvAnnouncementInfo.OptionsCustomization.AllowFilter = false;
            this.gvAnnouncementInfo.OptionsCustomization.AllowSort = false;
            this.gvAnnouncementInfo.OptionsPrint.AutoWidth = false;
            this.gvAnnouncementInfo.OptionsView.ColumnAutoWidth = false;
            this.gvAnnouncementInfo.OptionsView.ShowGroupPanel = false;
            this.gvAnnouncementInfo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvAnnouncementInfo_FocusedRowChanged);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "编号";
            this.gridColumn2.FieldName = "Id";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "标题";
            this.gridColumn1.FieldName = "Titel";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 183;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "发布人ID";
            this.gridColumn3.FieldName = "EmployeeId";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "发布时间";
            this.gridColumn5.FieldName = "DisplayTime";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 154;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "发布人名称";
            this.gridColumn4.FieldName = "PublishEmployeeName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 100;
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Controls.Add(this.btnRefresh);
            this.panelControl5.Controls.Add(this.btnUpdate);
            this.panelControl5.Controls.Add(this.btnDelete);
            this.panelControl5.Controls.Add(this.btnInsert);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl5.Location = new System.Drawing.Point(0, 0);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(456, 45);
            this.panelControl5.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(7, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(50, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(131, 11);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(185, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(52, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(68, 11);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(50, 23);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "新增";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // FormAnnouncementMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 692);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl4);
            this.Name = "FormAnnouncementMgmt";
            this.Text = "公告管理";
            this.Load += new System.EventHandler(this.FormAnnouncementMgmt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtPublishTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPublishTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnouncementInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAnnouncementInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.TextEdit txtTitel;
        private DevExpress.XtraEditors.MemoEdit txtContent;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraGrid.GridControl dgvAnnouncementInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAnnouncementInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnInsert;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtPublishTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}