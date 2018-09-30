namespace BwBackMgmt.PassCardMgmt
{
    partial class FormQQX
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQQX));
            this.dgvRecord = new DevExpress.XtraGrid.GridControl();
            this.gvRecord = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.dnStoreOrder = new DevExpress.XtraEditors.DataNavigator();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRecord
            // 
            this.dgvRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecord.Location = new System.Drawing.Point(0, 65);
            this.dgvRecord.MainView = this.gvRecord;
            this.dgvRecord.Name = "dgvRecord";
            this.dgvRecord.Size = new System.Drawing.Size(1130, 478);
            this.dgvRecord.TabIndex = 13;
            this.dgvRecord.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRecord});
            // 
            // gvRecord
            // 
            this.gvRecord.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn9,
            this.gridColumn10});
            this.gvRecord.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvRecord.GridControl = this.dgvRecord;
            this.gvRecord.Name = "gvRecord";
            this.gvRecord.OptionsBehavior.Editable = false;
            this.gvRecord.OptionsBehavior.ReadOnly = true;
            this.gvRecord.OptionsCustomization.AllowSort = false;
            this.gvRecord.OptionsView.ColumnAutoWidth = false;
            this.gvRecord.OptionsView.ShowGroupPanel = false;
            this.gvRecord.OptionsView.ShowViewCaption = true;
            this.gvRecord.ViewCaption = "QQHL修改记录";
            this.gvRecord.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvRecord_RowClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "编号";
            this.gridColumn3.FieldName = "Id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "通证编号";
            this.gridColumn4.FieldName = "CurrencyId";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "通证代码";
            this.gridColumn7.FieldName = "CurrencyCode";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 100;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "通证名称";
            this.gridColumn8.FieldName = "CurrencyCaption";
            this.gridColumn8.ImageAlignment = System.Drawing.StringAlignment.Far;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 150;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "价格";
            this.gridColumn1.DisplayFormat.FormatString = "n3";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "Price";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "修改时间";
            this.gridColumn2.FieldName = "UpdateTime";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 171;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "修改人";
            this.gridColumn5.FieldName = "UpdateUserId";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "修改人姓名";
            this.gridColumn6.FieldName = "UpdateEmployeeName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 500;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1130, 65);
            this.panelControl1.TabIndex = 14;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 36);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("doublefirst_16x16.png", "office2013/arrows/doublefirst_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/arrows/doublefirst_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "doublefirst_16x16.png");
            this.imageCollection1.InsertGalleryImage("doubleprev_16x16.png", "office2013/arrows/doubleprev_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/arrows/doubleprev_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "doubleprev_16x16.png");
            this.imageCollection1.InsertGalleryImage("prev_16x16.png", "office2013/arrows/prev_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/arrows/prev_16x16.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "prev_16x16.png");
            this.imageCollection1.InsertGalleryImage("next_16x16.png", "office2013/arrows/next_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/arrows/next_16x16.png"), 3);
            this.imageCollection1.Images.SetKeyName(3, "next_16x16.png");
            this.imageCollection1.InsertGalleryImage("doublenext_16x16.png", "office2013/arrows/doublenext_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/arrows/doublenext_16x16.png"), 4);
            this.imageCollection1.Images.SetKeyName(4, "doublenext_16x16.png");
            this.imageCollection1.InsertGalleryImage("doublelast_16x16.png", "office2013/arrows/doublelast_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/arrows/doublelast_16x16.png"), 5);
            this.imageCollection1.Images.SetKeyName(5, "doublelast_16x16.png");
            // 
            // dnStoreOrder
            // 
            this.dnStoreOrder.Buttons.Append.Visible = false;
            this.dnStoreOrder.Buttons.AutoRepeatDelay = 500;
            this.dnStoreOrder.Buttons.CancelEdit.Visible = false;
            this.dnStoreOrder.Buttons.EndEdit.Visible = false;
            this.dnStoreOrder.Buttons.First.ImageIndex = 0;
            this.dnStoreOrder.Buttons.First.Visible = false;
            this.dnStoreOrder.Buttons.ImageList = this.imageCollection1;
            this.dnStoreOrder.Buttons.Last.ImageIndex = 5;
            this.dnStoreOrder.Buttons.Last.Visible = false;
            this.dnStoreOrder.Buttons.Next.ImageIndex = 3;
            this.dnStoreOrder.Buttons.Next.Visible = false;
            this.dnStoreOrder.Buttons.NextPage.ImageIndex = 4;
            this.dnStoreOrder.Buttons.NextPage.Visible = false;
            this.dnStoreOrder.Buttons.Prev.ImageIndex = 2;
            this.dnStoreOrder.Buttons.Prev.Visible = false;
            this.dnStoreOrder.Buttons.PrevPage.ImageIndex = 1;
            this.dnStoreOrder.Buttons.PrevPage.Visible = false;
            this.dnStoreOrder.Buttons.Remove.Visible = false;
            this.dnStoreOrder.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(0, 0, true, true, "", "0"),
            new DevExpress.XtraEditors.NavigatorCustomButton(1, 2, true, true, "", "1"),
            new DevExpress.XtraEditors.NavigatorCustomButton(2, 3, true, true, "", "2"),
            new DevExpress.XtraEditors.NavigatorCustomButton(3, 5, true, true, "", "3")});
            this.dnStoreOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dnStoreOrder.Location = new System.Drawing.Point(0, 543);
            this.dnStoreOrder.Name = "dnStoreOrder";
            this.dnStoreOrder.Size = new System.Drawing.Size(1130, 24);
            this.dnStoreOrder.TabIndex = 22;
            this.dnStoreOrder.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
            this.dnStoreOrder.TextStringFormat = "";
            this.dnStoreOrder.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dnOrder_ButtonClick);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "类型";
            this.gridColumn9.FieldName = "Type";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "修改人类型";
            this.gridColumn10.FieldName = "TypeCaption";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            // 
            // FormQQX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 567);
            this.Controls.Add(this.dgvRecord);
            this.Controls.Add(this.dnStoreOrder);
            this.Controls.Add(this.panelControl1);
            this.Name = "FormQQX";
            this.Text = "现货通证QQHX";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgvRecord;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRecord;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.DataNavigator dnStoreOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}