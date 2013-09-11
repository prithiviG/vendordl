namespace Vendor
{
    partial class frmVehicle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehicle));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnVehicleAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnVehicleEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnVehicleDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barExit = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblNetTotal = new DevExpress.XtraEditors.TextEdit();
            this.cboVehicleRegNo = new DevExpress.XtraEditors.LookUpEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtTSMinQ = new DevExpress.XtraEditors.TextEdit();
            this.txtTSMinH = new DevExpress.XtraEditors.TextEdit();
            this.txtTSMinB = new DevExpress.XtraEditors.TextEdit();
            this.txtTSMinL = new DevExpress.XtraEditors.TextEdit();
            this.lblTSMN = new DevExpress.XtraEditors.LabelControl();
            this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.txtPercentage = new DevExpress.XtraEditors.TextEdit();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.txtTSMQ = new DevExpress.XtraEditors.TextEdit();
            this.txtTSMH = new DevExpress.XtraEditors.TextEdit();
            this.txtTSML = new DevExpress.XtraEditors.TextEdit();
            this.txtTSMB = new DevExpress.XtraEditors.TextEdit();
            this.txtBLMQ = new DevExpress.XtraEditors.TextEdit();
            this.txtBLMH = new DevExpress.XtraEditors.TextEdit();
            this.txtBLMB = new DevExpress.XtraEditors.TextEdit();
            this.txtBLMLen = new DevExpress.XtraEditors.TextEdit();
            this.lblQty = new DevExpress.XtraEditors.LabelControl();
            this.lblHeight = new DevExpress.XtraEditors.LabelControl();
            this.lblLength = new DevExpress.XtraEditors.LabelControl();
            this.lblBreadth = new DevExpress.XtraEditors.LabelControl();
            this.lblRemarks = new DevExpress.XtraEditors.LabelControl();
            this.lblNet = new DevExpress.XtraEditors.LabelControl();
            this.lblPercentage = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblTSM = new DevExpress.XtraEditors.LabelControl();
            this.lblBLM = new DevExpress.XtraEditors.LabelControl();
            this.lblVehicleRegNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNetTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVehicleRegNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMinQ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMinH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMinB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMinL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMQ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSML.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLMQ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLMH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLMB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLMLen.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.barExit,
            this.btnVehicleAdd,
            this.btnVehicleEdit,
            this.btnVehicleDelete});
            this.barManager1.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnVehicleAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnVehicleEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnVehicleDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barExit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnVehicleAdd
            // 
            this.btnVehicleAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnVehicleAdd.Appearance.Options.UseFont = true;
            this.btnVehicleAdd.Caption = "Add";
            this.btnVehicleAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVehicleAdd.Glyph")));
            this.btnVehicleAdd.Id = 1;
            this.btnVehicleAdd.Name = "btnVehicleAdd";
            this.btnVehicleAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVehicleAdd_ItemClick);
            // 
            // btnVehicleEdit
            // 
            this.btnVehicleEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnVehicleEdit.Appearance.Options.UseFont = true;
            this.btnVehicleEdit.Caption = "Edit";
            this.btnVehicleEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVehicleEdit.Glyph")));
            this.btnVehicleEdit.Id = 2;
            this.btnVehicleEdit.Name = "btnVehicleEdit";
            this.btnVehicleEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVehicleEdit_ItemClick);
            // 
            // btnVehicleDelete
            // 
            this.btnVehicleDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnVehicleDelete.Appearance.Options.UseFont = true;
            this.btnVehicleDelete.Caption = "Delete";
            this.btnVehicleDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVehicleDelete.Glyph")));
            this.btnVehicleDelete.Id = 3;
            this.btnVehicleDelete.Name = "btnVehicleDelete";
            // 
            // barExit
            // 
            this.barExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.barExit.Appearance.Options.UseFont = true;
            this.barExit.Caption = "Exit";
            this.barExit.Glyph = ((System.Drawing.Image)(resources.GetObject("barExit.Glyph")));
            this.barExit.Id = 0;
            this.barExit.Name = "barExit";
            this.barExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barExit_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(764, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 430);
            this.barDockControlBottom.Size = new System.Drawing.Size(764, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 404);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(764, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 404);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblNetTotal);
            this.panelControl1.Controls.Add(this.cboVehicleRegNo);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.txtTSMinQ);
            this.panelControl1.Controls.Add(this.txtTSMinH);
            this.panelControl1.Controls.Add(this.txtTSMinB);
            this.panelControl1.Controls.Add(this.txtTSMinL);
            this.panelControl1.Controls.Add(this.lblTSMN);
            this.panelControl1.Controls.Add(this.txtRemarks);
            this.panelControl1.Controls.Add(this.txtPercentage);
            this.panelControl1.Controls.Add(this.txtTotal);
            this.panelControl1.Controls.Add(this.txtTSMQ);
            this.panelControl1.Controls.Add(this.txtTSMH);
            this.panelControl1.Controls.Add(this.txtTSML);
            this.panelControl1.Controls.Add(this.txtTSMB);
            this.panelControl1.Controls.Add(this.txtBLMQ);
            this.panelControl1.Controls.Add(this.txtBLMH);
            this.panelControl1.Controls.Add(this.txtBLMB);
            this.panelControl1.Controls.Add(this.txtBLMLen);
            this.panelControl1.Controls.Add(this.lblQty);
            this.panelControl1.Controls.Add(this.lblHeight);
            this.panelControl1.Controls.Add(this.lblLength);
            this.panelControl1.Controls.Add(this.lblBreadth);
            this.panelControl1.Controls.Add(this.lblRemarks);
            this.panelControl1.Controls.Add(this.lblNet);
            this.panelControl1.Controls.Add(this.lblPercentage);
            this.panelControl1.Controls.Add(this.lblTotal);
            this.panelControl1.Controls.Add(this.lblTSM);
            this.panelControl1.Controls.Add(this.lblBLM);
            this.panelControl1.Controls.Add(this.lblVehicleRegNo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.LookAndFeel.SkinName = "Money Twins";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(764, 404);
            this.panelControl1.TabIndex = 4;
            // 
            // lblNetTotal
            // 
            this.lblNetTotal.Enabled = false;
            this.lblNetTotal.Location = new System.Drawing.Point(550, 241);
            this.lblNetTotal.MenuManager = this.barManager1;
            this.lblNetTotal.Name = "lblNetTotal";
            this.lblNetTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.lblNetTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblNetTotal.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblNetTotal.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.lblNetTotal.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblNetTotal.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.lblNetTotal.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.lblNetTotal.Properties.LookAndFeel.SkinName = "Money Twins";
            this.lblNetTotal.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblNetTotal.Properties.Mask.EditMask = "#########################.00000";
            this.lblNetTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.lblNetTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.lblNetTotal.Size = new System.Drawing.Size(191, 20);
            this.lblNetTotal.TabIndex = 32;
            // 
            // cboVehicleRegNo
            // 
            this.cboVehicleRegNo.Location = new System.Drawing.Point(130, 23);
            this.cboVehicleRegNo.MenuManager = this.barManager1;
            this.cboVehicleRegNo.Name = "cboVehicleRegNo";
            this.cboVehicleRegNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVehicleRegNo.Properties.LookAndFeel.SkinName = "Money Twins";
            this.cboVehicleRegNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboVehicleRegNo.Properties.NullText = "";
            this.cboVehicleRegNo.Size = new System.Drawing.Size(252, 20);
            this.cboVehicleRegNo.TabIndex = 0;
            this.cboVehicleRegNo.EditValueChanged += new System.EventHandler(this.cboVehicleRegNo_EditValueChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(3, 358);
            this.panelControl2.LookAndFeel.SkinName = "Money Twins";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(758, 43);
            this.panelControl2.TabIndex = 31;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(393, 11);
            this.btnCancel.LookAndFeel.SkinName = "Money Twins";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(312, 12);
            this.btnOK.LookAndFeel.SkinName = "Money Twins";
            this.btnOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Ok";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTSMinQ
            // 
            this.txtTSMinQ.Enabled = false;
            this.txtTSMinQ.Location = new System.Drawing.Point(655, 140);
            this.txtTSMinQ.MenuManager = this.barManager1;
            this.txtTSMinQ.Name = "txtTSMinQ";
            this.txtTSMinQ.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTSMinQ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTSMinQ.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTSMinQ.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtTSMinQ.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTSMinQ.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtTSMinQ.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTSMinQ.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtTSMinQ.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTSMinQ.Properties.Mask.EditMask = "#########################.00000";
            this.txtTSMinQ.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTSMinQ.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTSMinQ.Size = new System.Drawing.Size(86, 20);
            this.txtTSMinQ.TabIndex = 30;
            // 
            // txtTSMinH
            // 
            this.txtTSMinH.Location = new System.Drawing.Point(538, 140);
            this.txtTSMinH.MenuManager = this.barManager1;
            this.txtTSMinH.Name = "txtTSMinH";
            this.txtTSMinH.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTSMinH.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTSMinH.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTSMinH.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtTSMinH.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTSMinH.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtTSMinH.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTSMinH.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtTSMinH.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTSMinH.Properties.Mask.EditMask = "#########################.00000";
            this.txtTSMinH.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTSMinH.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTSMinH.Size = new System.Drawing.Size(86, 20);
            this.txtTSMinH.TabIndex = 9;
            this.txtTSMinH.EditValueChanged += new System.EventHandler(this.txtTSMinH_EditValueChanged);
            // 
            // txtTSMinB
            // 
            this.txtTSMinB.Location = new System.Drawing.Point(415, 140);
            this.txtTSMinB.MenuManager = this.barManager1;
            this.txtTSMinB.Name = "txtTSMinB";
            this.txtTSMinB.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTSMinB.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTSMinB.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTSMinB.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtTSMinB.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTSMinB.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtTSMinB.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTSMinB.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtTSMinB.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTSMinB.Properties.Mask.EditMask = "#########################.00000";
            this.txtTSMinB.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTSMinB.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTSMinB.Size = new System.Drawing.Size(86, 20);
            this.txtTSMinB.TabIndex = 8;
            this.txtTSMinB.EditValueChanged += new System.EventHandler(this.txtTSMinB_EditValueChanged);
            // 
            // txtTSMinL
            // 
            this.txtTSMinL.Location = new System.Drawing.Point(296, 140);
            this.txtTSMinL.MenuManager = this.barManager1;
            this.txtTSMinL.Name = "txtTSMinL";
            this.txtTSMinL.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTSMinL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTSMinL.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTSMinL.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtTSMinL.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTSMinL.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtTSMinL.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTSMinL.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtTSMinL.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTSMinL.Properties.Mask.EditMask = "#########################.00000";
            this.txtTSMinL.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTSMinL.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTSMinL.Size = new System.Drawing.Size(86, 20);
            this.txtTSMinL.TabIndex = 7;
            this.txtTSMinL.EditValueChanged += new System.EventHandler(this.txtTSMinL_EditValueChanged);
            // 
            // lblTSMN
            // 
            this.lblTSMN.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTSMN.Location = new System.Drawing.Point(28, 143);
            this.lblTSMN.LookAndFeel.SkinName = "Money Twins";
            this.lblTSMN.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblTSMN.Name = "lblTSMN";
            this.lblTSMN.Size = new System.Drawing.Size(132, 13);
            this.lblTSMN.TabIndex = 26;
            this.lblTSMN.Text = "c)Tapper Size Minimum";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(100, 275);
            this.txtRemarks.MenuManager = this.barManager1;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtRemarks.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtRemarks.Size = new System.Drawing.Size(524, 66);
            this.txtRemarks.TabIndex = 10;
            // 
            // txtPercentage
            // 
            this.txtPercentage.Enabled = false;
            this.txtPercentage.Location = new System.Drawing.Point(655, 207);
            this.txtPercentage.MenuManager = this.barManager1;
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPercentage.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPercentage.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtPercentage.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtPercentage.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPercentage.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtPercentage.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtPercentage.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtPercentage.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPercentage.Properties.Mask.EditMask = "#########################.00000";
            this.txtPercentage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPercentage.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPercentage.Size = new System.Drawing.Size(86, 20);
            this.txtPercentage.TabIndex = 23;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(655, 174);
            this.txtTotal.MenuManager = this.barManager1;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotal.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTotal.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotal.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotal.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtTotal.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTotal.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtTotal.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTotal.Properties.Mask.EditMask = "#########################.00000";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotal.Size = new System.Drawing.Size(86, 20);
            this.txtTotal.TabIndex = 22;
            // 
            // txtTSMQ
            // 
            this.txtTSMQ.Enabled = false;
            this.txtTSMQ.Location = new System.Drawing.Point(655, 109);
            this.txtTSMQ.MenuManager = this.barManager1;
            this.txtTSMQ.Name = "txtTSMQ";
            this.txtTSMQ.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTSMQ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTSMQ.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTSMQ.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtTSMQ.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTSMQ.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtTSMQ.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTSMQ.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtTSMQ.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTSMQ.Properties.Mask.EditMask = "#########################.00000";
            this.txtTSMQ.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTSMQ.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTSMQ.Size = new System.Drawing.Size(86, 20);
            this.txtTSMQ.TabIndex = 21;
            // 
            // txtTSMH
            // 
            this.txtTSMH.Location = new System.Drawing.Point(538, 109);
            this.txtTSMH.MenuManager = this.barManager1;
            this.txtTSMH.Name = "txtTSMH";
            this.txtTSMH.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTSMH.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTSMH.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTSMH.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtTSMH.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTSMH.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtTSMH.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTSMH.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtTSMH.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTSMH.Properties.Mask.EditMask = "#########################.00000";
            this.txtTSMH.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTSMH.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTSMH.Size = new System.Drawing.Size(86, 20);
            this.txtTSMH.TabIndex = 6;
            this.txtTSMH.EditValueChanged += new System.EventHandler(this.txtTSMH_EditValueChanged);
            // 
            // txtTSML
            // 
            this.txtTSML.Location = new System.Drawing.Point(296, 109);
            this.txtTSML.MenuManager = this.barManager1;
            this.txtTSML.Name = "txtTSML";
            this.txtTSML.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTSML.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTSML.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTSML.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtTSML.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTSML.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtTSML.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTSML.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtTSML.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTSML.Properties.Mask.EditMask = "#########################.00000";
            this.txtTSML.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTSML.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTSML.Size = new System.Drawing.Size(86, 20);
            this.txtTSML.TabIndex = 4;
            this.txtTSML.EditValueChanged += new System.EventHandler(this.txtTSML_EditValueChanged);
            // 
            // txtTSMB
            // 
            this.txtTSMB.Location = new System.Drawing.Point(415, 109);
            this.txtTSMB.MenuManager = this.barManager1;
            this.txtTSMB.Name = "txtTSMB";
            this.txtTSMB.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTSMB.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTSMB.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtTSMB.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtTSMB.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTSMB.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtTSMB.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTSMB.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtTSMB.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTSMB.Properties.Mask.EditMask = "#########################.00000";
            this.txtTSMB.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTSMB.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTSMB.Size = new System.Drawing.Size(86, 20);
            this.txtTSMB.TabIndex = 5;
            this.txtTSMB.EditValueChanged += new System.EventHandler(this.txtTSMB_EditValueChanged);
            // 
            // txtBLMQ
            // 
            this.txtBLMQ.Enabled = false;
            this.txtBLMQ.Location = new System.Drawing.Point(655, 77);
            this.txtBLMQ.MenuManager = this.barManager1;
            this.txtBLMQ.Name = "txtBLMQ";
            this.txtBLMQ.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBLMQ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtBLMQ.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtBLMQ.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtBLMQ.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBLMQ.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtBLMQ.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtBLMQ.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtBLMQ.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtBLMQ.Properties.Mask.EditMask = "#########################.00000";
            this.txtBLMQ.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBLMQ.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBLMQ.Size = new System.Drawing.Size(86, 20);
            this.txtBLMQ.TabIndex = 17;
            // 
            // txtBLMH
            // 
            this.txtBLMH.Location = new System.Drawing.Point(538, 77);
            this.txtBLMH.MenuManager = this.barManager1;
            this.txtBLMH.Name = "txtBLMH";
            this.txtBLMH.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBLMH.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtBLMH.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtBLMH.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtBLMH.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBLMH.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtBLMH.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtBLMH.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtBLMH.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtBLMH.Properties.Mask.EditMask = "#########################.00000";
            this.txtBLMH.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBLMH.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBLMH.Size = new System.Drawing.Size(86, 20);
            this.txtBLMH.TabIndex = 3;
            this.txtBLMH.EditValueChanged += new System.EventHandler(this.txtBLMH_EditValueChanged);
            // 
            // txtBLMB
            // 
            this.txtBLMB.Location = new System.Drawing.Point(415, 77);
            this.txtBLMB.MenuManager = this.barManager1;
            this.txtBLMB.Name = "txtBLMB";
            this.txtBLMB.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBLMB.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtBLMB.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtBLMB.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtBLMB.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBLMB.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtBLMB.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtBLMB.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtBLMB.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtBLMB.Properties.Mask.EditMask = "#########################.00000";
            this.txtBLMB.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBLMB.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBLMB.Size = new System.Drawing.Size(86, 20);
            this.txtBLMB.TabIndex = 2;
            this.txtBLMB.EditValueChanged += new System.EventHandler(this.txtBLMB_EditValueChanged);
            // 
            // txtBLMLen
            // 
            this.txtBLMLen.Location = new System.Drawing.Point(296, 77);
            this.txtBLMLen.MenuManager = this.barManager1;
            this.txtBLMLen.Name = "txtBLMLen";
            this.txtBLMLen.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBLMLen.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtBLMLen.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtBLMLen.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtBLMLen.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBLMLen.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtBLMLen.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtBLMLen.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtBLMLen.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtBLMLen.Properties.Mask.EditMask = "#########################.00000";
            this.txtBLMLen.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBLMLen.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBLMLen.Size = new System.Drawing.Size(86, 20);
            this.txtBLMLen.TabIndex = 1;
            this.txtBLMLen.EditValueChanged += new System.EventHandler(this.txtBLMLen_EditValueChanged);
            // 
            // lblQty
            // 
            this.lblQty.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblQty.Location = new System.Drawing.Point(655, 55);
            this.lblQty.LookAndFeel.SkinName = "Money Twins";
            this.lblQty.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(20, 13);
            this.lblQty.TabIndex = 13;
            this.lblQty.Text = "Qty";
            // 
            // lblHeight
            // 
            this.lblHeight.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblHeight.Location = new System.Drawing.Point(538, 55);
            this.lblHeight.LookAndFeel.SkinName = "Money Twins";
            this.lblHeight.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(37, 13);
            this.lblHeight.TabIndex = 12;
            this.lblHeight.Text = "Height";
            // 
            // lblLength
            // 
            this.lblLength.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblLength.Location = new System.Drawing.Point(296, 55);
            this.lblLength.LookAndFeel.SkinName = "Money Twins";
            this.lblLength.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(39, 13);
            this.lblLength.TabIndex = 11;
            this.lblLength.Text = "Length";
            // 
            // lblBreadth
            // 
            this.lblBreadth.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBreadth.Location = new System.Drawing.Point(415, 55);
            this.lblBreadth.LookAndFeel.SkinName = "Money Twins";
            this.lblBreadth.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblBreadth.Name = "lblBreadth";
            this.lblBreadth.Size = new System.Drawing.Size(45, 13);
            this.lblBreadth.TabIndex = 10;
            this.lblBreadth.Text = "Breadth";
            // 
            // lblRemarks
            // 
            this.lblRemarks.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblRemarks.Location = new System.Drawing.Point(28, 277);
            this.lblRemarks.LookAndFeel.SkinName = "Money Twins";
            this.lblRemarks.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(51, 13);
            this.lblRemarks.TabIndex = 7;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblNet
            // 
            this.lblNet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNet.Location = new System.Drawing.Point(28, 244);
            this.lblNet.LookAndFeel.SkinName = "Money Twins";
            this.lblNet.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(188, 13);
            this.lblNet.TabIndex = 6;
            this.lblNet.Text = "f)Net Quantity For This Trip (a+e)";
            // 
            // lblPercentage
            // 
            this.lblPercentage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPercentage.Location = new System.Drawing.Point(28, 210);
            this.lblPercentage.LookAndFeel.SkinName = "Money Twins";
            this.lblPercentage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(162, 13);
            this.lblPercentage.TabIndex = 5;
            this.lblPercentage.Text = "e)50% Of Above(d) Quantity";
            // 
            // lblTotal
            // 
            this.lblTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(28, 177);
            this.lblTotal.LookAndFeel.SkinName = "Money Twins";
            this.lblTotal.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(73, 13);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "d)Total(b+c)";
            // 
            // lblTSM
            // 
            this.lblTSM.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTSM.Location = new System.Drawing.Point(28, 112);
            this.lblTSM.LookAndFeel.SkinName = "Money Twins";
            this.lblTSM.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblTSM.Name = "lblTSM";
            this.lblTSM.Size = new System.Drawing.Size(137, 13);
            this.lblTSM.TabIndex = 3;
            this.lblTSM.Text = "b)Tapper Size Maximum";
            // 
            // lblBLM
            // 
            this.lblBLM.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBLM.Location = new System.Drawing.Point(28, 80);
            this.lblBLM.LookAndFeel.SkinName = "Money Twins";
            this.lblBLM.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblBLM.Name = "lblBLM";
            this.lblBLM.Size = new System.Drawing.Size(258, 13);
            this.lblBLM.TabIndex = 2;
            this.lblBLM.Text = "a)Body Level Measurement Above Body Level";
            // 
            // lblVehicleRegNo
            // 
            this.lblVehicleRegNo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblVehicleRegNo.Location = new System.Drawing.Point(28, 26);
            this.lblVehicleRegNo.LookAndFeel.SkinName = "Money Twins";
            this.lblVehicleRegNo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblVehicleRegNo.Name = "lblVehicleRegNo";
            this.lblVehicleRegNo.Size = new System.Drawing.Size(88, 13);
            this.lblVehicleRegNo.TabIndex = 0;
            this.lblVehicleRegNo.Text = "Vehicle Reg. No.";
            // 
            // frmVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(764, 430);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle Master";
            this.Load += new System.EventHandler(this.frmVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNetTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVehicleRegNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMinQ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMinH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMinB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMinL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMQ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSML.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSMB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLMQ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLMH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLMB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBLMLen.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barExit;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblRemarks;
        private DevExpress.XtraEditors.LabelControl lblNet;
        private DevExpress.XtraEditors.LabelControl lblPercentage;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraEditors.LabelControl lblTSM;
        private DevExpress.XtraEditors.LabelControl lblBLM;
        private DevExpress.XtraEditors.LabelControl lblVehicleRegNo;
        private DevExpress.XtraEditors.LabelControl lblQty;
        private DevExpress.XtraEditors.LabelControl lblHeight;
        private DevExpress.XtraEditors.LabelControl lblLength;
        private DevExpress.XtraEditors.LabelControl lblBreadth;
        private DevExpress.XtraEditors.TextEdit txtBLMQ;
        private DevExpress.XtraEditors.TextEdit txtBLMH;
        private DevExpress.XtraEditors.TextEdit txtBLMB;
        private DevExpress.XtraEditors.TextEdit txtBLMLen;
        private DevExpress.XtraEditors.MemoEdit txtRemarks;
        private DevExpress.XtraEditors.TextEdit txtPercentage;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.TextEdit txtTSMQ;
        private DevExpress.XtraEditors.TextEdit txtTSMH;
        private DevExpress.XtraEditors.TextEdit txtTSML;
        private DevExpress.XtraEditors.TextEdit txtTSMB;
        private DevExpress.XtraEditors.LabelControl lblTSMN;
        private DevExpress.XtraEditors.TextEdit txtTSMinQ;
        private DevExpress.XtraEditors.TextEdit txtTSMinH;
        private DevExpress.XtraEditors.TextEdit txtTSMinB;
        private DevExpress.XtraEditors.TextEdit txtTSMinL;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraBars.BarButtonItem btnVehicleAdd;
        private DevExpress.XtraBars.BarButtonItem btnVehicleEdit;
        private DevExpress.XtraBars.BarButtonItem btnVehicleDelete;
        private DevExpress.XtraEditors.LookUpEdit cboVehicleRegNo;
        private DevExpress.XtraEditors.TextEdit lblNetTotal;

    }
}