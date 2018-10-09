namespace BwBackMgmt.PassCardMgmt
{
    partial class FormWalletMgmt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWalletMgmt));
            this.dnStoreOrder = new DevExpress.XtraEditors.DataNavigator();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.dgvRecord = new DevExpress.XtraGrid.GridControl();
            this.gvRecord = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.qqx = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.AllAmountQQX = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.dnStoreOrder.Location = new System.Drawing.Point(0, 526);
            this.dnStoreOrder.Name = "dnStoreOrder";
            this.dnStoreOrder.Size = new System.Drawing.Size(1325, 24);
            this.dnStoreOrder.TabIndex = 26;
            this.dnStoreOrder.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
            this.dnStoreOrder.TextStringFormat = "";
            this.dnStoreOrder.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dnOrder_ButtonClick);
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
            // dgvRecord
            // 
            this.dgvRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecord.Location = new System.Drawing.Point(0, 101);
            this.dgvRecord.MainView = this.gvRecord;
            this.dgvRecord.Name = "dgvRecord";
            this.dgvRecord.Size = new System.Drawing.Size(1325, 425);
            this.dgvRecord.TabIndex = 25;
            this.dgvRecord.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRecord});
            // 
            // gvRecord
            // 
            this.gvRecord.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.qqx,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4});
            this.gvRecord.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.AllAmountQQX,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gvRecord.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvRecord.GridControl = this.dgvRecord;
            this.gvRecord.Name = "gvRecord";
            this.gvRecord.OptionsBehavior.Editable = false;
            this.gvRecord.OptionsBehavior.ReadOnly = true;
            this.gvRecord.OptionsCustomization.AllowColumnMoving = false;
            this.gvRecord.OptionsCustomization.AllowFilter = false;
            this.gvRecord.OptionsCustomization.AllowSort = false;
            this.gvRecord.OptionsMenu.EnableColumnMenu = false;
            this.gvRecord.OptionsMenu.EnableFooterMenu = false;
            this.gvRecord.OptionsView.ColumnAutoWidth = false;
            this.gvRecord.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "用户信息";
            this.gridBand1.Columns.Add(this.gridColumn1);
            this.gridBand1.Columns.Add(this.gridColumn2);
            this.gridBand1.Columns.Add(this.gridColumn3);
            this.gridBand1.Columns.Add(this.gridColumn4);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 218;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "姓名";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.Width = 92;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "手机区号";
            this.gridColumn3.FieldName = "PhoneAreaId";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "手机号";
            this.gridColumn4.FieldName = "Phone";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.Width = 126;
            // 
            // qqx
            // 
            this.qqx.Caption = "总金额";
            this.qqx.Columns.Add(this.AllAmountQQX);
            this.qqx.Columns.Add(this.gridColumn8);
            this.qqx.Columns.Add(this.gridColumn11);
            this.qqx.Name = "qqx";
            this.qqx.VisibleIndex = 1;
            this.qqx.Width = 600;
            // 
            // AllAmountQQX
            // 
            this.AllAmountQQX.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.AllAmountQQX.AppearanceCell.Options.UseBackColor = true;
            this.AllAmountQQX.Caption = "现货通证";
            this.AllAmountQQX.FieldName = "AllAmountQQX";
            this.AllAmountQQX.Name = "AllAmountQQX";
            this.AllAmountQQX.Visible = true;
            this.AllAmountQQX.Width = 200;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gridColumn8.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn8.Caption = "易货通证";
            this.gridColumn8.FieldName = "AllAmountQQY";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.Width = 200;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gridColumn11.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn11.Caption = "理财通证";
            this.gridColumn11.FieldName = "AllAmountQQL";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.Width = 200;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "现货通证";
            this.gridBand2.Columns.Add(this.gridColumn6);
            this.gridBand2.Columns.Add(this.gridColumn7);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 400;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn6.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn6.Caption = "冻结金额";
            this.gridColumn6.FieldName = "FrozenAmountQQX";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.Width = 200;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn7.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn7.Caption = "可用金额";
            this.gridColumn7.FieldName = "CanuseAmountQQX";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.Width = 200;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "易货通证";
            this.gridBand3.Columns.Add(this.gridColumn9);
            this.gridBand3.Columns.Add(this.gridColumn10);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 3;
            this.gridBand3.Width = 400;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn9.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn9.Caption = "冻结金额";
            this.gridColumn9.FieldName = "FrozenAmountQQY";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.Width = 200;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn10.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn10.Caption = "可用金额";
            this.gridColumn10.FieldName = "CanuseAmountQQY";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.Width = 200;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "理财通证";
            this.gridBand4.Columns.Add(this.gridColumn12);
            this.gridBand4.Columns.Add(this.gridColumn13);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 4;
            this.gridBand4.Width = 400;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridColumn12.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn12.Caption = "冻结金额";
            this.gridColumn12.FieldName = "FrozenAmountQQL";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.Width = 200;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridColumn13.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn13.Caption = "可用金额";
            this.gridColumn13.FieldName = "CanuseAmountQQL";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.Width = 200;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.comboBoxEdit2);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.comboBoxEdit1);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.textEdit4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.textEdit3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.textEdit2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1325, 101);
            this.groupControl1.TabIndex = 24;
            this.groupControl1.Text = "查询条件";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(212, 73);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 22;
            this.labelControl6.Text = "用户类型";
            // 
            // comboBoxEdit2
            // 
            this.comboBoxEdit2.Location = new System.Drawing.Point(274, 70);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit2.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEdit2.TabIndex = 21;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(47, 73);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 14);
            this.labelControl5.TabIndex = 20;
            this.labelControl5.Text = "部门";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(85, 70);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEdit1.TabIndex = 19;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(587, 37);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "身份证";
            // 
            // textEdit4
            // 
            this.textEdit4.Location = new System.Drawing.Point(629, 34);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new System.Drawing.Size(100, 20);
            this.textEdit4.TabIndex = 17;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(408, 37);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "手机号";
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(459, 34);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(100, 20);
            this.textEdit3.TabIndex = 15;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(212, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "员工账号";
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(274, 34);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(100, 20);
            this.textEdit2.TabIndex = 13;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "员工编号";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(85, 34);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(798, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormWalletMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 550);
            this.Controls.Add(this.dgvRecord);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.dnStoreOrder);
            this.Name = "FormWalletMgmt";
            this.Text = "钱包管理";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DataNavigator dnStoreOrder;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.GridControl dgvRecord;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvRecord;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn AllAmountQQX;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn13;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand qqx;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
    }
}