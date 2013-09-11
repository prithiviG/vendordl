namespace Vendor
{
    partial class frmCityEntry
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
            this.cmdAddCountry = new DevExpress.XtraEditors.SimpleButton();
            this.lblCountry = new DevExpress.XtraEditors.LabelControl();
            this.cboCountry = new DevExpress.XtraEditors.LookUpEdit();
            this.cmdAddState = new DevExpress.XtraEditors.SimpleButton();
            this.cboState = new DevExpress.XtraEditors.LookUpEdit();
            this.lblState = new DevExpress.XtraEditors.LabelControl();
            this.txtCity = new DevExpress.XtraEditors.TextEdit();
            this.lblCity = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmdAddCountry);
            this.panelControl1.Controls.Add(this.lblCountry);
            this.panelControl1.Controls.Add(this.cboCountry);
            this.panelControl1.Controls.Add(this.cmdAddState);
            this.panelControl1.Controls.Add(this.cboState);
            this.panelControl1.Controls.Add(this.lblState);
            this.panelControl1.Controls.Add(this.txtCity);
            this.panelControl1.Controls.Add(this.lblCity);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "Money Twins";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(284, 160);
            this.panelControl1.TabIndex = 9;
            // 
            // cmdAddCountry
            // 
            this.cmdAddCountry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdAddCountry.Appearance.Options.UseFont = true;
            this.cmdAddCountry.Location = new System.Drawing.Point(244, 51);
            this.cmdAddCountry.LookAndFeel.SkinName = "Money Twins";
            this.cmdAddCountry.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdAddCountry.Name = "cmdAddCountry";
            this.cmdAddCountry.Size = new System.Drawing.Size(24, 21);
            this.cmdAddCountry.TabIndex = 3;
            this.cmdAddCountry.Text = "...";
            this.cmdAddCountry.Click += new System.EventHandler(this.cmdAddCountry_Click);
            // 
            // lblCountry
            // 
            this.lblCountry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCountry.Location = new System.Drawing.Point(12, 55);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(45, 13);
            this.lblCountry.TabIndex = 11;
            this.lblCountry.Text = "Country";
            // 
            // cboCountry
            // 
            this.cboCountry.Location = new System.Drawing.Point(65, 52);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCountry.Properties.LookAndFeel.SkinName = "Money Twins";
            this.cboCountry.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboCountry.Properties.NullText = "";
            this.cboCountry.Size = new System.Drawing.Size(177, 20);
            this.cboCountry.TabIndex = 2;
            this.cboCountry.EditValueChanged += new System.EventHandler(this.cboCountry_EditValueChanged);
            // 
            // cmdAddState
            // 
            this.cmdAddState.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdAddState.Appearance.Options.UseFont = true;
            this.cmdAddState.Location = new System.Drawing.Point(244, 85);
            this.cmdAddState.LookAndFeel.SkinName = "Money Twins";
            this.cmdAddState.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdAddState.Name = "cmdAddState";
            this.cmdAddState.Size = new System.Drawing.Size(24, 21);
            this.cmdAddState.TabIndex = 5;
            this.cmdAddState.Text = "...";
            this.cmdAddState.Click += new System.EventHandler(this.cmdAddState_Click);
            // 
            // cboState
            // 
            this.cboState.Location = new System.Drawing.Point(65, 86);
            this.cboState.Name = "cboState";
            this.cboState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboState.Properties.LookAndFeel.SkinName = "Money Twins";
            this.cboState.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboState.Properties.NullText = "";
            this.cboState.Size = new System.Drawing.Size(177, 20);
            this.cboState.TabIndex = 4;
            this.cboState.EditValueChanged += new System.EventHandler(this.cboState_EditValueChanged);
            // 
            // lblState
            // 
            this.lblState.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblState.Location = new System.Drawing.Point(12, 89);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(31, 13);
            this.lblState.TabIndex = 6;
            this.lblState.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(65, 17);
            this.txtCity.Name = "txtCity";
            this.txtCity.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtCity.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtCity.Size = new System.Drawing.Size(201, 20);
            this.txtCity.TabIndex = 1;
            // 
            // lblCity
            // 
            this.lblCity.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCity.Location = new System.Drawing.Point(12, 20);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(22, 13);
            this.lblCity.TabIndex = 2;
            this.lblCity.Text = "City";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cmdCancel);
            this.panelControl2.Controls.Add(this.simpleButton3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(3, 124);
            this.panelControl2.LookAndFeel.SkinName = "Money Twins";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(278, 33);
            this.panelControl2.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Appearance.Options.UseFont = true;
            this.cmdCancel.Location = new System.Drawing.Point(142, 6);
            this.cmdCancel.LookAndFeel.SkinName = "Money Twins";
            this.cmdCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(58, 21);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new System.Drawing.Point(78, 6);
            this.simpleButton3.LookAndFeel.SkinName = "Money Twins";
            this.simpleButton3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(58, 21);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "Ok";
            this.simpleButton3.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmCityEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 160);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCityEntry";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "City Entry";
            this.Load += new System.EventHandler(this.frmCityEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblCity;
        private DevExpress.XtraEditors.TextEdit txtCity;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
        private DevExpress.XtraEditors.SimpleButton cmdAddState;
        private DevExpress.XtraEditors.LookUpEdit cboState;
        private DevExpress.XtraEditors.LabelControl lblState;
        private DevExpress.XtraEditors.SimpleButton cmdAddCountry;
        private DevExpress.XtraEditors.LabelControl lblCountry;
        private DevExpress.XtraEditors.LookUpEdit cboCountry;
    }
}