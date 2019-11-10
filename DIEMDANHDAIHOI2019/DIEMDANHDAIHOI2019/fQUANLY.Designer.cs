namespace DIEMDANHDAIHOI2019
{
    partial class fQUANLY
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fQUANLY));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnStatistic = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnCamera = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteAll = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOLOT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTINHTRANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHUDE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnAdd,
            this.btnDelete,
            this.btnRefresh,
            this.btnStatistic,
            this.btnPrint,
            this.btnCamera,
            this.btnDeleteAll});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(995, 146);
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "THÊM";
            this.btnAdd.Id = 1;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.LargeImage")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "XÓA";
            this.btnDelete.Id = 2;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.LargeImage")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "TẢI LẠI";
            this.btnRefresh.Id = 3;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.LargeImage")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnStatistic
            // 
            this.btnStatistic.Caption = "IN THỐNG KÊ";
            this.btnStatistic.Id = 4;
            this.btnStatistic.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStatistic.ImageOptions.Image")));
            this.btnStatistic.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStatistic.ImageOptions.LargeImage")));
            this.btnStatistic.LargeWidth = 80;
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStatistic_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "IN THẺ";
            this.btnPrint.Id = 5;
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            this.btnPrint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.LargeImage")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnCamera
            // 
            this.btnCamera.Caption = "ĐIỂM DANH";
            this.btnCamera.Id = 6;
            this.btnCamera.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCamera.ImageOptions.SvgImage")));
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCamera_ItemClick);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Caption = "XÓA ĐOÀN VIÊN";
            this.btnDeleteAll.Id = 7;
            this.btnDeleteAll.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDeleteAll.ImageOptions.SvgImage")));
            this.btnDeleteAll.LargeWidth = 95;
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeleteAll_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Quản Lý Đại Hội";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDeleteAll);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnStatistic);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPrint);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCamera);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl2);
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 146);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(995, 546);
            this.panelControl1.TabIndex = 2;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(500, 2);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.MenuManager = this.ribbon;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(493, 542);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT1,
            this.colHOLOT,
            this.colTEN,
            this.colTINHTRANG,
            this.colHINH});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.GroupPanelText = "DANH SÁCH ĐOÀN VIÊN THAM DỰ ĐẠI HỘI";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.RowHeight = 30;
            // 
            // colSTT1
            // 
            this.colSTT1.AppearanceCell.Options.UseTextOptions = true;
            this.colSTT1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT1.AppearanceHeader.Options.UseTextOptions = true;
            this.colSTT1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT1.Caption = "STT";
            this.colSTT1.FieldName = "colSTT1";
            this.colSTT1.MaxWidth = 100;
            this.colSTT1.Name = "colSTT1";
            this.colSTT1.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSTT1.Visible = true;
            this.colSTT1.VisibleIndex = 0;
            this.colSTT1.Width = 40;
            // 
            // colHOLOT
            // 
            this.colHOLOT.AppearanceHeader.Options.UseTextOptions = true;
            this.colHOLOT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHOLOT.Caption = "HỌ LÓT";
            this.colHOLOT.FieldName = "colHOLOT";
            this.colHOLOT.Name = "colHOLOT";
            this.colHOLOT.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colHOLOT.Visible = true;
            this.colHOLOT.VisibleIndex = 1;
            this.colHOLOT.Width = 111;
            // 
            // colTEN
            // 
            this.colTEN.AppearanceCell.Options.UseTextOptions = true;
            this.colTEN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTEN.AppearanceHeader.Options.UseTextOptions = true;
            this.colTEN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTEN.Caption = "TÊN";
            this.colTEN.FieldName = "colTEN";
            this.colTEN.MaxWidth = 240;
            this.colTEN.Name = "colTEN";
            this.colTEN.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTEN.Visible = true;
            this.colTEN.VisibleIndex = 2;
            this.colTEN.Width = 111;
            // 
            // colTINHTRANG
            // 
            this.colTINHTRANG.AppearanceCell.Options.UseTextOptions = true;
            this.colTINHTRANG.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTINHTRANG.AppearanceHeader.Options.UseTextOptions = true;
            this.colTINHTRANG.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTINHTRANG.Caption = "ĐIỂM DANH";
            this.colTINHTRANG.FieldName = "colTINHTRANG";
            this.colTINHTRANG.MaxWidth = 200;
            this.colTINHTRANG.Name = "colTINHTRANG";
            this.colTINHTRANG.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTINHTRANG.Visible = true;
            this.colTINHTRANG.VisibleIndex = 3;
            this.colTINHTRANG.Width = 100;
            // 
            // colHINH
            // 
            this.colHINH.AppearanceCell.Options.UseTextOptions = true;
            this.colHINH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHINH.AppearanceHeader.Options.UseTextOptions = true;
            this.colHINH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHINH.Caption = "HÌNH ẢNH";
            this.colHINH.FieldName = "colHINH";
            this.colHINH.MaxWidth = 400;
            this.colHINH.Name = "colHINH";
            this.colHINH.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colHINH.Visible = true;
            this.colHINH.VisibleIndex = 4;
            this.colHINH.Width = 140;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(498, 542);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colCHUDE,
            this.colNGAY,
            this.colGIO,
            this.colSOLUONG});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "DANH SÁCH ĐẠI HỘI";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsPrint.AllowMultilineHeaders = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colSTT
            // 
            this.colSTT.AppearanceCell.Options.UseTextOptions = true;
            this.colSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "colSTT";
            this.colSTT.MaxWidth = 40;
            this.colSTT.Name = "colSTT";
            this.colSTT.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 1;
            this.colSTT.Width = 40;
            // 
            // colCHUDE
            // 
            this.colCHUDE.AppearanceCell.Options.UseTextOptions = true;
            this.colCHUDE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCHUDE.AppearanceHeader.Options.UseTextOptions = true;
            this.colCHUDE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCHUDE.Caption = "CHỦ ĐỀ ĐẠI HỘI";
            this.colCHUDE.FieldName = "colCHUDE";
            this.colCHUDE.Name = "colCHUDE";
            this.colCHUDE.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCHUDE.Visible = true;
            this.colCHUDE.VisibleIndex = 2;
            this.colCHUDE.Width = 109;
            // 
            // colNGAY
            // 
            this.colNGAY.AppearanceCell.Options.UseTextOptions = true;
            this.colNGAY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNGAY.AppearanceHeader.Options.UseTextOptions = true;
            this.colNGAY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNGAY.Caption = "NGÀY ĐẠI HỘI";
            this.colNGAY.FieldName = "colNGAY";
            this.colNGAY.MaxWidth = 100;
            this.colNGAY.Name = "colNGAY";
            this.colNGAY.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colNGAY.Visible = true;
            this.colNGAY.VisibleIndex = 3;
            this.colNGAY.Width = 100;
            // 
            // colGIO
            // 
            this.colGIO.AppearanceCell.Options.UseTextOptions = true;
            this.colGIO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGIO.AppearanceHeader.Options.UseTextOptions = true;
            this.colGIO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGIO.Caption = "GIỜ ĐẠI HỘI";
            this.colGIO.FieldName = "colGIO";
            this.colGIO.Name = "colGIO";
            this.colGIO.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colGIO.Visible = true;
            this.colGIO.VisibleIndex = 4;
            // 
            // colSOLUONG
            // 
            this.colSOLUONG.AppearanceCell.Options.UseTextOptions = true;
            this.colSOLUONG.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSOLUONG.AppearanceHeader.Options.UseTextOptions = true;
            this.colSOLUONG.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSOLUONG.Caption = "SỐ LƯỢNG";
            this.colSOLUONG.FieldName = "colSOLUONG";
            this.colSOLUONG.MaxWidth = 70;
            this.colSOLUONG.Name = "colSOLUONG";
            this.colSOLUONG.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSOLUONG.Visible = true;
            this.colSOLUONG.VisibleIndex = 5;
            this.colSOLUONG.Width = 70;
            // 
            // fQUANLY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 692);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Name = "fQUANLY";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHẦN MỀM QUẢN LÝ ĐẠI HỘI";
            this.Load += new System.EventHandler(this.fQUANLY_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnStatistic;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnCamera;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colCHUDE;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT1;
        private DevExpress.XtraGrid.Columns.GridColumn colHOLOT;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colTINHTRANG;
        private DevExpress.XtraGrid.Columns.GridColumn colHINH;
        private DevExpress.XtraGrid.Columns.GridColumn colGIO;
        private DevExpress.XtraBars.BarButtonItem btnDeleteAll;
    }
}