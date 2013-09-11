namespace Vendor
{
    partial class frmAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlert));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.toolStripNext = new DevExpress.XtraBars.BarStaticItem();
            this.toolStripADays = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.toolStripDays = new DevExpress.XtraBars.BarStaticItem();
            this.toolStripRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.toolStripPrint = new DevExpress.XtraBars.BarButtonItem();
            this.toolStripExit = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grdAlert = new DevExpress.XtraGrid.GridControl();
            this.AlertView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.AllowShowToolbarsPopup = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.toolStripNext,
            this.toolStripDays,
            this.toolStripRefresh,
            this.toolStripExit,
            this.toolStripPrint,
            this.toolStripADays});
            this.barManager1.MaxItemId = 8;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.toolStripNext),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolStripADays),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolStripDays),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.toolStripRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.toolStripPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.toolStripExit, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 2";
            // 
            // toolStripNext
            // 
            this.toolStripNext.Caption = "Next";
            this.toolStripNext.Id = 1;
            this.toolStripNext.Name = "toolStripNext";
            this.toolStripNext.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // toolStripADays
            // 
            this.toolStripADays.Caption = "barEditItem1";
            this.toolStripADays.Edit = this.repositoryItemTextEdit2;
            this.toolStripADays.Id = 7;
            this.toolStripADays.Name = "toolStripADays";
            this.toolStripADays.ShowingEditor += new DevExpress.XtraBars.ItemCancelEventHandler(this.toolStripADays_ShowingEditor);
            this.toolStripADays.ItemPress += new DevExpress.XtraBars.ItemClickEventHandler(this.toolStripADays_ItemPress);
            this.toolStripADays.EditValueChanged += new System.EventHandler(this.toolStripADays_TextChanged);
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.Mask.EditMask = "##########";
            this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // toolStripDays
            // 
            this.toolStripDays.Caption = "Days";
            this.toolStripDays.Id = 3;
            this.toolStripDays.Name = "toolStripDays";
            this.toolStripDays.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // toolStripRefresh
            // 
            this.toolStripRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripRefresh.Appearance.Options.UseFont = true;
            this.toolStripRefresh.Caption = "Refresh";
            this.toolStripRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("toolStripRefresh.Glyph")));
            this.toolStripRefresh.Id = 4;
            this.toolStripRefresh.Name = "toolStripRefresh";
            this.toolStripRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolStripRefresh_ItemClick);
            // 
            // toolStripPrint
            // 
            this.toolStripPrint.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.toolStripPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripPrint.Appearance.Options.UseFont = true;
            this.toolStripPrint.Caption = "Print";
            this.toolStripPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("toolStripPrint.Glyph")));
            this.toolStripPrint.Id = 6;
            this.toolStripPrint.Name = "toolStripPrint";
            this.toolStripPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolStripPrint_ItemClick);
            // 
            // toolStripExit
            // 
            this.toolStripExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.toolStripExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripExit.Appearance.Options.UseFont = true;
            this.toolStripExit.Caption = "Exit";
            this.toolStripExit.Glyph = ((System.Drawing.Image)(resources.GetObject("toolStripExit.Glyph")));
            this.toolStripExit.Id = 5;
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolStripExit_ItemClick);
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.LookAndFeel.SkinName = "Money Twins";
            this.barAndDockingController1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(706, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 405);
            this.barDockControlBottom.Size = new System.Drawing.Size(706, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 377);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(706, 28);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 377);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grdAlert);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 28);
            this.panelControl1.LookAndFeel.SkinName = "Money Twins";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(706, 377);
            this.panelControl1.TabIndex = 4;
            // 
            // grdAlert
            // 
            this.grdAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAlert.Location = new System.Drawing.Point(3, 3);
            this.grdAlert.LookAndFeel.SkinName = "Money Twins";
            this.grdAlert.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdAlert.MainView = this.AlertView;
            this.grdAlert.MenuManager = this.barManager1;
            this.grdAlert.Name = "grdAlert";
            this.grdAlert.Size = new System.Drawing.Size(700, 371);
            this.grdAlert.TabIndex = 0;
            this.grdAlert.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.AlertView,
            this.gridView2});
            // 
            // AlertView
            // 
            this.AlertView.GridControl = this.grdAlert;
            this.AlertView.Name = "AlertView";
            this.AlertView.OptionsBehavior.Editable = false;
            this.AlertView.OptionsView.ShowGroupPanel = false;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdAlert;
            this.gridView2.Name = "gridView2";
            // 
            // frmAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(706, 405);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAlert";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alert";
            this.Load += new System.EventHandler(this.frmAlert_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAlert_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem toolStripNext;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarStaticItem toolStripDays;
        private DevExpress.XtraBars.BarButtonItem toolStripRefresh;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdAlert;
        private DevExpress.XtraGrid.Views.Grid.GridView AlertView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraBars.BarButtonItem toolStripPrint;
        private DevExpress.XtraBars.BarButtonItem toolStripExit;
        private DevExpress.XtraBars.BarEditItem toolStripADays;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;

    }
}