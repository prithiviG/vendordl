namespace Vendor
{
    partial class frmService
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
            this.panelService = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddGroup = new DevExpress.XtraEditors.SimpleButton();
            this.cboUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.cboServiceGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSName = new DevExpress.XtraEditors.MemoEdit();
            this.txtSCode = new DevExpress.XtraEditors.TextEdit();
            this.lblUnit = new DevExpress.XtraEditors.LabelControl();
            this.lblSGroup = new DevExpress.XtraEditors.LabelControl();
            this.lblSName = new DevExpress.XtraEditors.LabelControl();
            this.lblSCode = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelService)).BeginInit();
            this.panelService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboServiceGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelService
            // 
            this.panelService.Controls.Add(this.panelControl1);
            this.panelService.Controls.Add(this.btnAddGroup);
            this.panelService.Controls.Add(this.cboUnit);
            this.panelService.Controls.Add(this.cboServiceGroup);
            this.panelService.Controls.Add(this.txtSName);
            this.panelService.Controls.Add(this.txtSCode);
            this.panelService.Controls.Add(this.lblUnit);
            this.panelService.Controls.Add(this.lblSGroup);
            this.panelService.Controls.Add(this.lblSName);
            this.panelService.Controls.Add(this.lblSCode);
            this.panelService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelService.Location = new System.Drawing.Point(0, 0);
            this.panelService.LookAndFeel.SkinName = "Money Twins";
            this.panelService.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelService.Name = "panelService";
            this.panelService.Size = new System.Drawing.Size(326, 269);
            this.panelService.TabIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnOk);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(3, 227);
            this.panelControl1.LookAndFeel.SkinName = "Money Twins";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(320, 39);
            this.panelControl1.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(159, 9);
            this.btnCancel.LookAndFeel.SkinName = "Money Twins";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 21);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.Location = new System.Drawing.Point(89, 9);
            this.btnOk.LookAndFeel.SkinName = "Money Twins";
            this.btnOk.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(64, 21);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddGroup.Appearance.Options.UseFont = true;
            this.btnAddGroup.Location = new System.Drawing.Point(289, 144);
            this.btnAddGroup.LookAndFeel.SkinName = "Money Twins";
            this.btnAddGroup.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(27, 20);
            this.btnAddGroup.TabIndex = 8;
            this.btnAddGroup.Text = "...";
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // cboUnit
            // 
            this.cboUnit.Location = new System.Drawing.Point(100, 188);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUnit.Properties.LookAndFeel.SkinName = "Money Twins";
            this.cboUnit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboUnit.Properties.NullText = "--- Select  ---";
            this.cboUnit.Size = new System.Drawing.Size(216, 20);
            this.cboUnit.TabIndex = 7;
            // 
            // cboServiceGroup
            // 
            this.cboServiceGroup.Location = new System.Drawing.Point(100, 144);
            this.cboServiceGroup.Name = "cboServiceGroup";
            this.cboServiceGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboServiceGroup.Properties.LookAndFeel.SkinName = "Money Twins";
            this.cboServiceGroup.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboServiceGroup.Properties.NullText = "--- Select ---";
            this.cboServiceGroup.Size = new System.Drawing.Size(185, 20);
            this.cboServiceGroup.TabIndex = 6;
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(100, 56);
            this.txtSName.Name = "txtSName";
            this.txtSName.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtSName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSName.Size = new System.Drawing.Size(216, 70);
            this.txtSName.TabIndex = 5;
            // 
            // txtSCode
            // 
            this.txtSCode.Location = new System.Drawing.Point(100, 15);
            this.txtSCode.Name = "txtSCode";
            this.txtSCode.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtSCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSCode.Size = new System.Drawing.Size(216, 20);
            this.txtSCode.TabIndex = 4;
            // 
            // lblUnit
            // 
            this.lblUnit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblUnit.Location = new System.Drawing.Point(15, 191);
            this.lblUnit.LookAndFeel.SkinName = "Money Twins";
            this.lblUnit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(23, 13);
            this.lblUnit.TabIndex = 3;
            this.lblUnit.Text = "Unit";
            // 
            // lblSGroup
            // 
            this.lblSGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSGroup.Location = new System.Drawing.Point(15, 144);
            this.lblSGroup.LookAndFeel.SkinName = "Money Twins";
            this.lblSGroup.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblSGroup.Name = "lblSGroup";
            this.lblSGroup.Size = new System.Drawing.Size(79, 13);
            this.lblSGroup.TabIndex = 2;
            this.lblSGroup.Text = "Service Group";
            // 
            // lblSName
            // 
            this.lblSName.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSName.Location = new System.Drawing.Point(15, 59);
            this.lblSName.LookAndFeel.SkinName = "Money Twins";
            this.lblSName.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblSName.Name = "lblSName";
            this.lblSName.Size = new System.Drawing.Size(77, 13);
            this.lblSName.TabIndex = 1;
            this.lblSName.Text = "Service Name";
            // 
            // lblSCode
            // 
            this.lblSCode.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSCode.Location = new System.Drawing.Point(15, 15);
            this.lblSCode.LookAndFeel.SkinName = "Money Twins";
            this.lblSCode.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblSCode.Name = "lblSCode";
            this.lblSCode.Size = new System.Drawing.Size(73, 13);
            this.lblSCode.TabIndex = 0;
            this.lblSCode.Text = "Service Code";
            // 
            // frmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 269);
            this.ControlBox = false;
            this.Controls.Add(this.panelService);
            this.Name = "frmService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Service";
            this.Load += new System.EventHandler(this.frmService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelService)).EndInit();
            this.panelService.ResumeLayout(false);
            this.panelService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboServiceGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelService;
        private DevExpress.XtraEditors.LookUpEdit cboUnit;
        private DevExpress.XtraEditors.LookUpEdit cboServiceGroup;
        private DevExpress.XtraEditors.MemoEdit txtSName;
        private DevExpress.XtraEditors.TextEdit txtSCode;
        private DevExpress.XtraEditors.LabelControl lblUnit;
        private DevExpress.XtraEditors.LabelControl lblSGroup;
        private DevExpress.XtraEditors.LabelControl lblSName;
        private DevExpress.XtraEditors.LabelControl lblSCode;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAddGroup;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}