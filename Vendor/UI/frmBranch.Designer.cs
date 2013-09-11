namespace Vendor
{
    partial class frmBranch
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.grpCDetails = new DevExpress.XtraEditors.GroupControl();
            this.grdContact = new DevExpress.XtraGrid.GridControl();
            this.ContactView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmdAddCity = new DevExpress.XtraEditors.SimpleButton();
            this.cboCity = new DevExpress.XtraEditors.LookUpEdit();
            this.txtAddress = new DevExpress.XtraEditors.MemoEdit();
            this.txtTINNo = new DevExpress.XtraEditors.TextEdit();
            this.txtBranchName = new DevExpress.XtraEditors.TextEdit();
            this.lblTIN = new DevExpress.XtraEditors.LabelControl();
            this.lblCity = new DevExpress.XtraEditors.LabelControl();
            this.lblAddress = new DevExpress.XtraEditors.LabelControl();
            this.lblBranchName = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtCheque = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCDetails)).BeginInit();
            this.grpCDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTINNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheque.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.txtCheque);
            this.panelControl1.Controls.Add(this.txtPhone);
            this.panelControl1.Controls.Add(this.lblPhone);
            this.panelControl1.Controls.Add(this.grpCDetails);
            this.panelControl1.Controls.Add(this.cmdAddCity);
            this.panelControl1.Controls.Add(this.cboCity);
            this.panelControl1.Controls.Add(this.txtAddress);
            this.panelControl1.Controls.Add(this.txtTINNo);
            this.panelControl1.Controls.Add(this.txtBranchName);
            this.panelControl1.Controls.Add(this.lblTIN);
            this.panelControl1.Controls.Add(this.lblCity);
            this.panelControl1.Controls.Add(this.lblAddress);
            this.panelControl1.Controls.Add(this.lblBranchName);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "Money Twins";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(613, 358);
            this.panelControl1.TabIndex = 0;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(93, 91);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtPhone.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPhone.Size = new System.Drawing.Size(224, 20);
            this.txtPhone.TabIndex = 8;
            // 
            // lblPhone
            // 
            this.lblPhone.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPhone.Location = new System.Drawing.Point(13, 94);
            this.lblPhone.LookAndFeel.SkinName = "Money Twins";
            this.lblPhone.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(55, 13);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "Phone No.";
            // 
            // grpCDetails
            // 
            this.grpCDetails.Controls.Add(this.grdContact);
            this.grpCDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCDetails.Location = new System.Drawing.Point(3, 122);
            this.grpCDetails.LookAndFeel.SkinName = "Money Twins";
            this.grpCDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCDetails.Name = "grpCDetails";
            this.grpCDetails.Size = new System.Drawing.Size(607, 199);
            this.grpCDetails.TabIndex = 6;
            this.grpCDetails.Text = "Contact Details";
            // 
            // grdContact
            // 
            this.grdContact.Location = new System.Drawing.Point(5, 25);
            this.grdContact.LookAndFeel.SkinName = "Money Twins";
            this.grdContact.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdContact.MainView = this.ContactView;
            this.grdContact.Name = "grdContact";
            this.grdContact.Size = new System.Drawing.Size(584, 155);
            this.grdContact.TabIndex = 7;
            this.grdContact.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ContactView});
            // 
            // ContactView
            // 
            this.ContactView.GridControl = this.grdContact;
            this.ContactView.Name = "ContactView";
            this.ContactView.OptionsNavigation.EnterMoveNextColumn = true;
            this.ContactView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.ContactView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.ContactView.OptionsView.ShowGroupPanel = false;
            // 
            // cmdAddCity
            // 
            this.cmdAddCity.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdAddCity.Appearance.Options.UseFont = true;
            this.cmdAddCity.Location = new System.Drawing.Point(293, 34);
            this.cmdAddCity.LookAndFeel.SkinName = "Money Twins";
            this.cmdAddCity.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdAddCity.Name = "cmdAddCity";
            this.cmdAddCity.Size = new System.Drawing.Size(24, 20);
            this.cmdAddCity.TabIndex = 4;
            this.cmdAddCity.Text = "...";
            this.cmdAddCity.Click += new System.EventHandler(this.cmdAddCity_Click);
            // 
            // cboCity
            // 
            this.cboCity.Location = new System.Drawing.Point(93, 34);
            this.cboCity.Name = "cboCity";
            this.cboCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCity.Properties.LookAndFeel.SkinName = "Money Twins";
            this.cboCity.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboCity.Properties.NullText = "";
            this.cboCity.Size = new System.Drawing.Size(196, 20);
            this.cboCity.TabIndex = 3;
            this.cboCity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboCity_KeyUp);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(382, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtAddress.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtAddress.Size = new System.Drawing.Size(224, 77);
            this.txtAddress.TabIndex = 2;
            // 
            // txtTINNo
            // 
            this.txtTINNo.Location = new System.Drawing.Point(93, 61);
            this.txtTINNo.Name = "txtTINNo";
            this.txtTINNo.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtTINNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTINNo.Size = new System.Drawing.Size(224, 20);
            this.txtTINNo.TabIndex = 5;
            // 
            // txtBranchName
            // 
            this.txtBranchName.Location = new System.Drawing.Point(93, 6);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtBranchName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtBranchName.Size = new System.Drawing.Size(224, 20);
            this.txtBranchName.TabIndex = 1;
            // 
            // lblTIN
            // 
            this.lblTIN.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTIN.Location = new System.Drawing.Point(13, 64);
            this.lblTIN.LookAndFeel.SkinName = "Money Twins";
            this.lblTIN.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblTIN.Name = "lblTIN";
            this.lblTIN.Size = new System.Drawing.Size(36, 13);
            this.lblTIN.TabIndex = 4;
            this.lblTIN.Text = "TIN No";
            // 
            // lblCity
            // 
            this.lblCity.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCity.Location = new System.Drawing.Point(12, 37);
            this.lblCity.LookAndFeel.SkinName = "Money Twins";
            this.lblCity.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(22, 13);
            this.lblCity.TabIndex = 3;
            this.lblCity.Text = "City";
            // 
            // lblAddress
            // 
            this.lblAddress.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAddress.Location = new System.Drawing.Point(328, 9);
            this.lblAddress.LookAndFeel.SkinName = "Money Twins";
            this.lblAddress.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(46, 13);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address";
            // 
            // lblBranchName
            // 
            this.lblBranchName.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBranchName.Location = new System.Drawing.Point(13, 10);
            this.lblBranchName.LookAndFeel.SkinName = "Money Twins";
            this.lblBranchName.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(74, 13);
            this.lblBranchName.TabIndex = 1;
            this.lblBranchName.Text = "Branch Name";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cmdCancel);
            this.panelControl2.Controls.Add(this.cmdOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(3, 321);
            this.panelControl2.LookAndFeel.SkinName = "Money Twins";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(607, 34);
            this.panelControl2.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Appearance.Options.UseFont = true;
            this.cmdCancel.Location = new System.Drawing.Point(302, 6);
            this.cmdCancel.LookAndFeel.SkinName = "Money Twins";
            this.cmdCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdOK.Appearance.Options.UseFont = true;
            this.cmdOK.Location = new System.Drawing.Point(221, 6);
            this.cmdOK.LookAndFeel.SkinName = "Money Twins";
            this.cmdOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "Ok";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtCheque
            // 
            this.txtCheque.EnterMoveNextControl = true;
            this.txtCheque.Location = new System.Drawing.Point(382, 91);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtCheque.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCheque.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtCheque.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCheque.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtCheque.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtCheque.Size = new System.Drawing.Size(224, 20);
            this.txtCheque.TabIndex = 32;
            this.txtCheque.ToolTip = "Name";
            this.txtCheque.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Location = new System.Drawing.Point(328, 94);
            this.labelControl10.LookAndFeel.SkinName = "Money Twins";
            this.labelControl10.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(42, 13);
            this.labelControl10.TabIndex = 33;
            this.labelControl10.Text = "Cheque";
            // 
            // frmBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(613, 358);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branch Entry";
            this.Load += new System.EventHandler(this.frmBranch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCDetails)).EndInit();
            this.grpCDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTINNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCheque.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboCity;
        private DevExpress.XtraEditors.MemoEdit txtAddress;
        private DevExpress.XtraEditors.TextEdit txtTINNo;
        private DevExpress.XtraEditors.TextEdit txtBranchName;
        private DevExpress.XtraEditors.LabelControl lblTIN;
        private DevExpress.XtraEditors.LabelControl lblCity;
        private DevExpress.XtraEditors.LabelControl lblAddress;
        private DevExpress.XtraEditors.LabelControl lblBranchName;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton cmdAddCity;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
        private DevExpress.XtraEditors.SimpleButton cmdOK;
        private DevExpress.XtraEditors.GroupControl grpCDetails;
        private DevExpress.XtraGrid.GridControl grdContact;
        private DevExpress.XtraGrid.Views.Grid.GridView ContactView;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private DevExpress.XtraEditors.TextEdit txtCheque;
        private DevExpress.XtraEditors.LabelControl labelControl10;
    }
}