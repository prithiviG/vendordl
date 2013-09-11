namespace Vendor
{
    partial class frmRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistration));
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpRemarks = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.grpReg = new System.Windows.Forms.GroupBox();
            this.txtHGradeName = new System.Windows.Forms.TextBox();
            this.txtCGradeName = new System.Windows.Forms.TextBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtSGradeName = new System.Windows.Forms.TextBox();
            this.chkService = new System.Windows.Forms.CheckBox();
            this.chkHLife = new System.Windows.Forms.CheckBox();
            this.dtpHFDate = new System.Windows.Forms.DateTimePicker();
            this.dtpHTDate = new System.Windows.Forms.DateTimePicker();
            this.chkContract = new System.Windows.Forms.CheckBox();
            this.chkCLife = new System.Windows.Forms.CheckBox();
            this.dtpCFDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCTDate = new System.Windows.Forms.DateTimePicker();
            this.lblLife = new System.Windows.Forms.Label();
            this.chkSupply = new System.Windows.Forms.CheckBox();
            this.chkSLife = new System.Windows.Forms.CheckBox();
            this.dtpSFDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSTDate = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.txtRegNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblRefDate = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.grpRemarks.SuspendLayout();
            this.grpReg.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.grpRemarks);
            this.panel1.Controls.Add(this.grpReg);
            this.panel1.Controls.Add(this.lblVendor);
            this.panel1.Controls.Add(this.txtVendorName);
            this.panel1.Controls.Add(this.txtRegNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.lblRefDate);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 400);
            this.panel1.TabIndex = 0;
            // 
            // grpRemarks
            // 
            this.grpRemarks.Controls.Add(this.txtRemarks);
            this.grpRemarks.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRemarks.Location = new System.Drawing.Point(12, 285);
            this.grpRemarks.Name = "grpRemarks";
            this.grpRemarks.Size = new System.Drawing.Size(501, 70);
            this.grpRemarks.TabIndex = 4;
            this.grpRemarks.TabStop = false;
            this.grpRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Location = new System.Drawing.Point(3, 17);
            this.txtRemarks.MaxLength = 255;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(495, 50);
            this.txtRemarks.TabIndex = 0;
            this.txtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarks_KeyPress);
            // 
            // grpReg
            // 
            this.grpReg.Controls.Add(this.txtHGradeName);
            this.grpReg.Controls.Add(this.txtCGradeName);
            this.grpReg.Controls.Add(this.lblGrade);
            this.grpReg.Controls.Add(this.txtSGradeName);
            this.grpReg.Controls.Add(this.chkService);
            this.grpReg.Controls.Add(this.chkHLife);
            this.grpReg.Controls.Add(this.dtpHFDate);
            this.grpReg.Controls.Add(this.dtpHTDate);
            this.grpReg.Controls.Add(this.chkContract);
            this.grpReg.Controls.Add(this.chkCLife);
            this.grpReg.Controls.Add(this.dtpCFDate);
            this.grpReg.Controls.Add(this.dtpCTDate);
            this.grpReg.Controls.Add(this.lblLife);
            this.grpReg.Controls.Add(this.chkSupply);
            this.grpReg.Controls.Add(this.chkSLife);
            this.grpReg.Controls.Add(this.dtpSFDate);
            this.grpReg.Controls.Add(this.label3);
            this.grpReg.Controls.Add(this.dtpSTDate);
            this.grpReg.Controls.Add(this.lblFrom);
            this.grpReg.Location = new System.Drawing.Point(12, 118);
            this.grpReg.Name = "grpReg";
            this.grpReg.Size = new System.Drawing.Size(501, 161);
            this.grpReg.TabIndex = 3;
            this.grpReg.TabStop = false;
            // 
            // txtHGradeName
            // 
            this.txtHGradeName.Enabled = false;
            this.txtHGradeName.Location = new System.Drawing.Point(408, 120);
            this.txtHGradeName.Name = "txtHGradeName";
            this.txtHGradeName.Size = new System.Drawing.Size(86, 21);
            this.txtHGradeName.TabIndex = 14;
            // 
            // txtCGradeName
            // 
            this.txtCGradeName.Enabled = false;
            this.txtCGradeName.Location = new System.Drawing.Point(408, 81);
            this.txtCGradeName.Name = "txtCGradeName";
            this.txtCGradeName.Size = new System.Drawing.Size(86, 21);
            this.txtCGradeName.TabIndex = 9;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.Location = new System.Drawing.Point(434, 17);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(35, 13);
            this.lblGrade.TabIndex = 92;
            this.lblGrade.Text = "Grade";
            // 
            // txtSGradeName
            // 
            this.txtSGradeName.Enabled = false;
            this.txtSGradeName.Location = new System.Drawing.Point(408, 42);
            this.txtSGradeName.Name = "txtSGradeName";
            this.txtSGradeName.Size = new System.Drawing.Size(86, 21);
            this.txtSGradeName.TabIndex = 4;
            // 
            // chkService
            // 
            this.chkService.AutoSize = true;
            this.chkService.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkService.Location = new System.Drawing.Point(13, 122);
            this.chkService.Name = "chkService";
            this.chkService.Size = new System.Drawing.Size(60, 17);
            this.chkService.TabIndex = 10;
            this.chkService.Text = "Service";
            this.chkService.UseVisualStyleBackColor = true;
            this.chkService.CheckedChanged += new System.EventHandler(this.chkService_CheckedChanged);
            // 
            // chkHLife
            // 
            this.chkHLife.AutoSize = true;
            this.chkHLife.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHLife.Location = new System.Drawing.Point(368, 123);
            this.chkHLife.Name = "chkHLife";
            this.chkHLife.Size = new System.Drawing.Size(15, 14);
            this.chkHLife.TabIndex = 13;
            this.chkHLife.UseVisualStyleBackColor = true;
            this.chkHLife.CheckedChanged += new System.EventHandler(this.chkHLife_CheckedChanged);
            // 
            // dtpHFDate
            // 
            this.dtpHFDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHFDate.Location = new System.Drawing.Point(101, 120);
            this.dtpHFDate.Name = "dtpHFDate";
            this.dtpHFDate.Size = new System.Drawing.Size(105, 21);
            this.dtpHFDate.TabIndex = 11;
            // 
            // dtpHTDate
            // 
            this.dtpHTDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHTDate.Location = new System.Drawing.Point(231, 120);
            this.dtpHTDate.Name = "dtpHTDate";
            this.dtpHTDate.Size = new System.Drawing.Size(112, 21);
            this.dtpHTDate.TabIndex = 12;
            // 
            // chkContract
            // 
            this.chkContract.AutoSize = true;
            this.chkContract.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkContract.Location = new System.Drawing.Point(13, 83);
            this.chkContract.Name = "chkContract";
            this.chkContract.Size = new System.Drawing.Size(66, 17);
            this.chkContract.TabIndex = 5;
            this.chkContract.Text = "Contract";
            this.chkContract.UseVisualStyleBackColor = true;
            this.chkContract.CheckedChanged += new System.EventHandler(this.chkContract_CheckedChanged);
            // 
            // chkCLife
            // 
            this.chkCLife.AutoSize = true;
            this.chkCLife.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCLife.Location = new System.Drawing.Point(368, 84);
            this.chkCLife.Name = "chkCLife";
            this.chkCLife.Size = new System.Drawing.Size(15, 14);
            this.chkCLife.TabIndex = 8;
            this.chkCLife.UseVisualStyleBackColor = true;
            this.chkCLife.CheckedChanged += new System.EventHandler(this.chkCLife_CheckedChanged);
            // 
            // dtpCFDate
            // 
            this.dtpCFDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCFDate.Location = new System.Drawing.Point(101, 81);
            this.dtpCFDate.Name = "dtpCFDate";
            this.dtpCFDate.Size = new System.Drawing.Size(105, 21);
            this.dtpCFDate.TabIndex = 6;
            // 
            // dtpCTDate
            // 
            this.dtpCTDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCTDate.Location = new System.Drawing.Point(231, 81);
            this.dtpCTDate.Name = "dtpCTDate";
            this.dtpCTDate.Size = new System.Drawing.Size(112, 21);
            this.dtpCTDate.TabIndex = 7;
            // 
            // lblLife
            // 
            this.lblLife.AutoSize = true;
            this.lblLife.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLife.Location = new System.Drawing.Point(351, 17);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(49, 13);
            this.lblLife.TabIndex = 83;
            this.lblLife.Text = "Life Time";
            // 
            // chkSupply
            // 
            this.chkSupply.AutoSize = true;
            this.chkSupply.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSupply.Location = new System.Drawing.Point(13, 44);
            this.chkSupply.Name = "chkSupply";
            this.chkSupply.Size = new System.Drawing.Size(57, 17);
            this.chkSupply.TabIndex = 0;
            this.chkSupply.Text = "Supply";
            this.chkSupply.UseVisualStyleBackColor = true;
            this.chkSupply.CheckedChanged += new System.EventHandler(this.chkSupply_CheckedChanged);
            // 
            // chkSLife
            // 
            this.chkSLife.AutoSize = true;
            this.chkSLife.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSLife.Location = new System.Drawing.Point(368, 45);
            this.chkSLife.Name = "chkSLife";
            this.chkSLife.Size = new System.Drawing.Size(15, 14);
            this.chkSLife.TabIndex = 3;
            this.chkSLife.UseVisualStyleBackColor = true;
            this.chkSLife.CheckedChanged += new System.EventHandler(this.chkSLife_CheckedChanged);
            // 
            // dtpSFDate
            // 
            this.dtpSFDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSFDate.Location = new System.Drawing.Point(101, 42);
            this.dtpSFDate.Name = "dtpSFDate";
            this.dtpSFDate.Size = new System.Drawing.Size(105, 21);
            this.dtpSFDate.TabIndex = 1;
            this.dtpSFDate.ValueChanged += new System.EventHandler(this.dtpSFDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "Valid Upto";
            // 
            // dtpSTDate
            // 
            this.dtpSTDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSTDate.Location = new System.Drawing.Point(231, 42);
            this.dtpSTDate.Name = "dtpSTDate";
            this.dtpSTDate.Size = new System.Drawing.Size(112, 21);
            this.dtpSTDate.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(125, 17);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(56, 13);
            this.lblFrom.TabIndex = 81;
            this.lblFrom.Text = "Valid From";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendor.Location = new System.Drawing.Point(12, 90);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(70, 13);
            this.lblVendor.TabIndex = 14;
            this.lblVendor.Text = "Vendor Name";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Enabled = false;
            this.txtVendorName.Location = new System.Drawing.Point(83, 86);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(430, 21);
            this.txtVendorName.TabIndex = 2;
            // 
            // txtRegNo
            // 
            this.txtRegNo.Location = new System.Drawing.Point(83, 49);
            this.txtRegNo.Name = "txtRegNo";
            this.txtRegNo.Size = new System.Drawing.Size(169, 21);
            this.txtRegNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Reg No";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(83, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(112, 21);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.Validated += new System.EventHandler(this.dtpDate_Validated);
            // 
            // lblRefDate
            // 
            this.lblRefDate.AutoSize = true;
            this.lblRefDate.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefDate.Location = new System.Drawing.Point(12, 16);
            this.lblRefDate.Name = "lblRefDate";
            this.lblRefDate.Size = new System.Drawing.Size(29, 13);
            this.lblRefDate.TabIndex = 9;
            this.lblRefDate.Text = "Date";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmdRemove);
            this.panel2.Controls.Add(this.cmdCancel);
            this.panel2.Controls.Add(this.cmdOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 363);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 37);
            this.panel2.TabIndex = 5;
            // 
            // cmdRemove
            // 
            this.cmdRemove.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemove.Image = ((System.Drawing.Image)(resources.GetObject("cmdRemove.Image")));
            this.cmdRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemove.Location = new System.Drawing.Point(2, 5);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(88, 27);
            this.cmdRemove.TabIndex = 2;
            this.cmdRemove.Text = "    UnRegister";
            this.cmdRemove.UseVisualStyleBackColor = false;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(439, 5);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(66, 27);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Visible = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(370, 5);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(66, 27);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(518, 400);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmRegistration";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.frmRegistration_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmRegistration_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpRemarks.ResumeLayout(false);
            this.grpRemarks.PerformLayout();
            this.grpReg.ResumeLayout(false);
            this.grpReg.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TextBox txtRegNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblRefDate;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.CheckBox chkSupply;
        private System.Windows.Forms.GroupBox grpReg;
        private System.Windows.Forms.Label lblLife;
        private System.Windows.Forms.CheckBox chkSLife;
        private System.Windows.Forms.DateTimePicker dtpSFDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpSTDate;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.CheckBox chkService;
        private System.Windows.Forms.CheckBox chkHLife;
        private System.Windows.Forms.DateTimePicker dtpHFDate;
        private System.Windows.Forms.DateTimePicker dtpHTDate;
        private System.Windows.Forms.CheckBox chkContract;
        private System.Windows.Forms.CheckBox chkCLife;
        private System.Windows.Forms.DateTimePicker dtpCFDate;
        private System.Windows.Forms.DateTimePicker dtpCTDate;
        private System.Windows.Forms.GroupBox grpRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtHGradeName;
        private System.Windows.Forms.TextBox txtCGradeName;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.TextBox txtSGradeName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button cmdRemove;
    }
}