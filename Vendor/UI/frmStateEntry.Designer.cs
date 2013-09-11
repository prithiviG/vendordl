namespace Vendor
{
    partial class frmStateEntry
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
            this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmdAddCountry = new DevExpress.XtraEditors.SimpleButton();
            this.txtState = new DevExpress.XtraEditors.TextEdit();
            this.cboCountry = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCountry = new DevExpress.XtraEditors.LabelControl();
            this.lblState = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCountry.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmdCancel);
            this.panelControl1.Controls.Add(this.cmdOK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 81);
            this.panelControl1.LookAndFeel.SkinName = "Money Twins";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(284, 42);
            this.panelControl1.TabIndex = 4;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Appearance.Options.UseFont = true;
            this.cmdCancel.Location = new System.Drawing.Point(157, 13);
            this.cmdCancel.LookAndFeel.SkinName = "Money Twins";
            this.cmdCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(61, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdOK.Appearance.Options.UseFont = true;
            this.cmdOK.Location = new System.Drawing.Point(79, 13);
            this.cmdOK.LookAndFeel.SkinName = "Money Twins";
            this.cmdOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(61, 23);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "Ok";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cmdAddCountry);
            this.panelControl2.Controls.Add(this.txtState);
            this.panelControl2.Controls.Add(this.cboCountry);
            this.panelControl2.Controls.Add(this.lblCountry);
            this.panelControl2.Controls.Add(this.lblState);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.LookAndFeel.SkinName = "Money Twins";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(284, 123);
            this.panelControl2.TabIndex = 5;
            // 
            // cmdAddCountry
            // 
            this.cmdAddCountry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdAddCountry.Appearance.Options.UseFont = true;
            this.cmdAddCountry.Location = new System.Drawing.Point(246, 46);
            this.cmdAddCountry.LookAndFeel.SkinName = "Money Twins";
            this.cmdAddCountry.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdAddCountry.Name = "cmdAddCountry";
            this.cmdAddCountry.Size = new System.Drawing.Size(26, 19);
            this.cmdAddCountry.TabIndex = 4;
            this.cmdAddCountry.Text = "...";
            this.cmdAddCountry.Click += new System.EventHandler(this.cmdAddCountry_Click);
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(70, 11);
            this.txtState.Name = "txtState";
            this.txtState.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtState.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtState.Size = new System.Drawing.Size(202, 20);
            this.txtState.TabIndex = 3;
            // 
            // cboCountry
            // 
            this.cboCountry.Location = new System.Drawing.Point(70, 46);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCountry.Properties.LookAndFeel.SkinName = "Money Twins";
            this.cboCountry.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboCountry.Properties.NullText = "";
            this.cboCountry.Size = new System.Drawing.Size(170, 20);
            this.cboCountry.TabIndex = 2;
            this.cboCountry.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboCountry_KeyUp);
            // 
            // lblCountry
            // 
            this.lblCountry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCountry.Appearance.Options.UseFont = true;
            this.lblCountry.Location = new System.Drawing.Point(12, 49);
            this.lblCountry.LookAndFeel.SkinName = "Money Twins";
            this.lblCountry.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(45, 13);
            this.lblCountry.TabIndex = 1;
            this.lblCountry.Text = "Country";
            // 
            // lblState
            // 
            this.lblState.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblState.Appearance.Options.UseFont = true;
            this.lblState.Location = new System.Drawing.Point(12, 14);
            this.lblState.LookAndFeel.SkinName = "Money Twins";
            this.lblState.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(31, 13);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "State";
            // 
            // frmStateEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 123);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmStateEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "State Entry";
            this.Load += new System.EventHandler(this.frmStateEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCountry.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton cmdOK;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton cmdAddCountry;
        private DevExpress.XtraEditors.TextEdit txtState;
        private DevExpress.XtraEditors.LookUpEdit cboCountry;
        private DevExpress.XtraEditors.LabelControl lblCountry;
        private DevExpress.XtraEditors.LabelControl lblState;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
    }
}