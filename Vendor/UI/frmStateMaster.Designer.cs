﻿namespace Vendor
{
    partial class frmStateMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStateMaster));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.toolStripAdd = new DevExpress.XtraBars.BarButtonItem();
            this.toolStripEdit = new DevExpress.XtraBars.BarButtonItem();
            this.toolStripDelete = new DevExpress.XtraBars.BarButtonItem();
            this.toolStripExit = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grdTrans = new DevExpress.XtraGrid.GridControl();
            this.TransView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransView)).BeginInit();
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
            this.toolStripAdd,
            this.toolStripEdit,
            this.toolStripDelete,
            this.toolStripExit});
            this.barManager1.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.toolStripAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.toolStripEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.toolStripDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.toolStripExit, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // toolStripAdd
            // 
            this.toolStripAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripAdd.Appearance.Options.UseFont = true;
            this.toolStripAdd.Caption = "Add";
            this.toolStripAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("toolStripAdd.Glyph")));
            this.toolStripAdd.Id = 1;
            this.toolStripAdd.Name = "toolStripAdd";
            this.toolStripAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolStripAdd_ItemClick);
            // 
            // toolStripEdit
            // 
            this.toolStripEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripEdit.Appearance.Options.UseFont = true;
            this.toolStripEdit.Caption = "Edit";
            this.toolStripEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("toolStripEdit.Glyph")));
            this.toolStripEdit.Id = 2;
            this.toolStripEdit.Name = "toolStripEdit";
            this.toolStripEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolStripEdit_ItemClick);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripDelete.Appearance.Options.UseFont = true;
            this.toolStripDelete.Caption = "Delete";
            this.toolStripDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("toolStripDelete.Glyph")));
            this.toolStripDelete.Id = 3;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolStripDelete_ItemClick);
            // 
            // toolStripExit
            // 
            this.toolStripExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.toolStripExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripExit.Appearance.Options.UseFont = true;
            this.toolStripExit.Caption = "Exit";
            this.toolStripExit.Glyph = ((System.Drawing.Image)(resources.GetObject("toolStripExit.Glyph")));
            this.toolStripExit.Id = 4;
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
            this.barDockControlTop.Size = new System.Drawing.Size(393, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 270);
            this.barDockControlBottom.Size = new System.Drawing.Size(393, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 244);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(393, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 244);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grdTrans);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.LookAndFeel.SkinName = "Money Twins";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(393, 244);
            this.panelControl1.TabIndex = 4;
            // 
            // grdTrans
            // 
            this.grdTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTrans.Location = new System.Drawing.Point(3, 3);
            this.grdTrans.LookAndFeel.SkinName = "Money Twins";
            this.grdTrans.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdTrans.MainView = this.TransView;
            this.grdTrans.MenuManager = this.barManager1;
            this.grdTrans.Name = "grdTrans";
            this.grdTrans.Size = new System.Drawing.Size(387, 238);
            this.grdTrans.TabIndex = 0;
            this.grdTrans.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.TransView});
            // 
            // TransView
            // 
            this.TransView.GridControl = this.grdTrans;
            this.TransView.Name = "TransView";
            this.TransView.OptionsBehavior.Editable = false;
            this.TransView.OptionsBehavior.ReadOnly = true;
            this.TransView.OptionsView.ShowGroupPanel = false;
            // 
            // frmStateMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(393, 270);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmStateMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "State Master";
            this.Load += new System.EventHandler(this.frmStateMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem toolStripAdd;
        private DevExpress.XtraBars.BarButtonItem toolStripEdit;
        private DevExpress.XtraBars.BarButtonItem toolStripDelete;
        private DevExpress.XtraBars.BarButtonItem toolStripExit;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdTrans;
        private DevExpress.XtraGrid.Views.Grid.GridView TransView;

    }
}