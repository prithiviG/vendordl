namespace Vendor
{
    partial class frmServiceMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceMaster));
            this.panelSMaster = new DevExpress.XtraEditors.PanelControl();
            this.grdSMaster = new DevExpress.XtraGrid.GridControl();
            this.SMView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnSAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnSEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelSMaster)).BeginInit();
            this.panelSMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSMaster
            // 
            this.panelSMaster.Controls.Add(this.grdSMaster);
            this.panelSMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSMaster.Location = new System.Drawing.Point(0, 26);
            this.panelSMaster.LookAndFeel.SkinName = "Money Twins";
            this.panelSMaster.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelSMaster.Name = "panelSMaster";
            this.panelSMaster.Size = new System.Drawing.Size(412, 257);
            this.panelSMaster.TabIndex = 0;
            // 
            // grdSMaster
            // 
            this.grdSMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSMaster.Location = new System.Drawing.Point(3, 3);
            this.grdSMaster.LookAndFeel.SkinName = "Money Twins";
            this.grdSMaster.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdSMaster.MainView = this.SMView;
            this.grdSMaster.Name = "grdSMaster";
            this.grdSMaster.Size = new System.Drawing.Size(406, 251);
            this.grdSMaster.TabIndex = 0;
            this.grdSMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.SMView});
            // 
            // SMView
            // 
            this.SMView.GridControl = this.grdSMaster;
            this.SMView.Name = "SMView";
            this.SMView.OptionsBehavior.Editable = false;
            this.SMView.OptionsBehavior.ReadOnly = true;
            this.SMView.OptionsView.ShowGroupPanel = false;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSAdd,
            this.btnSEdit,
            this.btnExit,
            this.btnDelete});
            this.barManager1.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnSAdd
            // 
            this.btnSAdd.Caption = "Add";
            this.btnSAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSAdd.Glyph")));
            this.btnSAdd.Id = 0;
            this.btnSAdd.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSAdd.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSAdd.Name = "btnSAdd";
            this.btnSAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSAdd_ItemClick);
            // 
            // btnSEdit
            // 
            this.btnSEdit.Caption = "Edit";
            this.btnSEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSEdit.Glyph")));
            this.btnSEdit.Id = 1;
            this.btnSEdit.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSEdit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSEdit.Name = "btnSEdit";
            this.btnSEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSEdit_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDelete.Glyph")));
            this.btnDelete.Id = 3;
            this.btnDelete.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "Exit";
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 2;
            this.btnExit.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.LookAndFeel.SkinName = "Money Twins";
            this.barAndDockingController1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(412, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 283);
            this.barDockControlBottom.Size = new System.Drawing.Size(412, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 257);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(412, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 257);
            // 
            // frmServiceMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 283);
            this.ControlBox = false;
            this.Controls.Add(this.panelSMaster);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmServiceMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Service Master";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmServiceMaster_FormClosed);
            this.Load += new System.EventHandler(this.frmServiceMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelSMaster)).EndInit();
            this.panelSMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSMaster;
        private DevExpress.XtraGrid.GridControl grdSMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView SMView;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnSAdd;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnSEdit;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
    }
}