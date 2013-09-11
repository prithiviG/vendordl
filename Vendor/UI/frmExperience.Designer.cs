namespace Vendor
{
    partial class frmExperience
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
            this.txtType = new DevExpress.XtraEditors.TextEdit();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.txtWork = new DevExpress.XtraEditors.MemoEdit();
            this.txtPeriod = new DevExpress.XtraEditors.TextEdit();
            this.txtValue = new DevExpress.XtraEditors.TextEdit();
            this.txtClient = new DevExpress.XtraEditors.TextEdit();
            this.lblPeriod = new DevExpress.XtraEditors.LabelControl();
            this.lblValue = new DevExpress.XtraEditors.LabelControl();
            this.lblClient = new DevExpress.XtraEditors.LabelControl();
            this.lblWork = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWork.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient.Properties)).BeginInit();
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
            this.panelControl1.Controls.Add(this.txtType);
            this.panelControl1.Controls.Add(this.lblType);
            this.panelControl1.Controls.Add(this.txtWork);
            this.panelControl1.Controls.Add(this.txtPeriod);
            this.panelControl1.Controls.Add(this.txtValue);
            this.panelControl1.Controls.Add(this.txtClient);
            this.panelControl1.Controls.Add(this.lblPeriod);
            this.panelControl1.Controls.Add(this.lblValue);
            this.panelControl1.Controls.Add(this.lblClient);
            this.panelControl1.Controls.Add(this.lblWork);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "Money Twins";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(408, 283);
            this.panelControl1.TabIndex = 4;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(124, 214);
            this.txtType.Name = "txtType";
            this.txtType.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtType.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtType.Size = new System.Drawing.Size(255, 20);
            this.txtType.TabIndex = 5;
            // 
            // lblType
            // 
            this.lblType.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblType.Location = new System.Drawing.Point(27, 217);
            this.lblType.LookAndFeel.SkinName = "Money Twins";
            this.lblType.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(28, 13);
            this.lblType.TabIndex = 9;
            this.lblType.Text = "Type";
            // 
            // txtWork
            // 
            this.txtWork.Location = new System.Drawing.Point(124, 6);
            this.txtWork.Name = "txtWork";
            this.txtWork.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtWork.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtWork.Size = new System.Drawing.Size(255, 56);
            this.txtWork.TabIndex = 1;
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(124, 173);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtPeriod.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPeriod.Size = new System.Drawing.Size(255, 20);
            this.txtPeriod.TabIndex = 4;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(124, 130);
            this.txtValue.Name = "txtValue";
            this.txtValue.Properties.Appearance.Options.UseTextOptions = true;
            this.txtValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValue.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtValue.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtValue.Properties.Mask.EditMask = "####################.00";
            this.txtValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtValue.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtValue.Properties.MaxLength = 20;
            this.txtValue.Size = new System.Drawing.Size(255, 20);
            this.txtValue.TabIndex = 3;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            this.txtValue.Validated += new System.EventHandler(this.txtValue_Validated);
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(124, 83);
            this.txtClient.Name = "txtClient";
            this.txtClient.Properties.LookAndFeel.SkinName = "Money Twins";
            this.txtClient.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtClient.Size = new System.Drawing.Size(255, 20);
            this.txtClient.TabIndex = 2;
            // 
            // lblPeriod
            // 
            this.lblPeriod.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPeriod.Location = new System.Drawing.Point(27, 176);
            this.lblPeriod.LookAndFeel.SkinName = "Money Twins";
            this.lblPeriod.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(36, 13);
            this.lblPeriod.TabIndex = 4;
            this.lblPeriod.Text = "Period";
            // 
            // lblValue
            // 
            this.lblValue.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblValue.Location = new System.Drawing.Point(27, 133);
            this.lblValue.LookAndFeel.SkinName = "Money Twins";
            this.lblValue.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(31, 13);
            this.lblValue.TabIndex = 3;
            this.lblValue.Text = "Value";
            // 
            // lblClient
            // 
            this.lblClient.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblClient.Location = new System.Drawing.Point(25, 86);
            this.lblClient.LookAndFeel.SkinName = "Money Twins";
            this.lblClient.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(81, 13);
            this.lblClient.TabIndex = 2;
            this.lblClient.Text = "Name of Client";
            // 
            // lblWork
            // 
            this.lblWork.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblWork.Location = new System.Drawing.Point(27, 12);
            this.lblWork.LookAndFeel.SkinName = "Money Twins";
            this.lblWork.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblWork.Name = "lblWork";
            this.lblWork.Size = new System.Drawing.Size(79, 13);
            this.lblWork.TabIndex = 1;
            this.lblWork.Text = "Name of Work";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cmdCancel);
            this.panelControl2.Controls.Add(this.cmdOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(3, 243);
            this.panelControl2.LookAndFeel.SkinName = "Money Twins";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(402, 37);
            this.panelControl2.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Appearance.Options.UseFont = true;
            this.cmdCancel.Location = new System.Drawing.Point(241, 8);
            this.cmdCancel.LookAndFeel.SkinName = "Money Twins";
            this.cmdCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdOK.Appearance.Options.UseFont = true;
            this.cmdOK.Location = new System.Drawing.Point(153, 8);
            this.cmdOK.LookAndFeel.SkinName = "Money Twins";
            this.cmdOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "Ok";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmExperience
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(408, 283);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmExperience";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Experience Entry";
            this.Load += new System.EventHandler(this.frmExperience_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmExperience_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWork.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.MemoEdit txtWork;
        private DevExpress.XtraEditors.TextEdit txtPeriod;
        private DevExpress.XtraEditors.TextEdit txtValue;
        private DevExpress.XtraEditors.TextEdit txtClient;
        private DevExpress.XtraEditors.LabelControl lblPeriod;
        private DevExpress.XtraEditors.LabelControl lblValue;
        private DevExpress.XtraEditors.LabelControl lblClient;
        private DevExpress.XtraEditors.LabelControl lblWork;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton cmdOK;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
        private DevExpress.XtraEditors.TextEdit txtType;
        private DevExpress.XtraEditors.LabelControl lblType;


    }
}