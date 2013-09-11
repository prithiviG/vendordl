namespace Vendor
{
    partial class frmStatusEntry
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpRemarks = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.grpValid = new System.Windows.Forms.GroupBox();
            this.chkLifTime = new System.Windows.Forms.CheckBox();
            this.dtpTDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.VendorType = new System.Windows.Forms.GroupBox();
            this.optService = new System.Windows.Forms.RadioButton();
            this.optContract = new System.Windows.Forms.RadioButton();
            this.optSupply = new System.Windows.Forms.RadioButton();
            this.lblRegNo = new System.Windows.Forms.Label();
            this.grdpStatusType = new System.Windows.Forms.GroupBox();
            this.optCancel = new System.Windows.Forms.RadioButton();
            this.optBlock = new System.Windows.Forms.RadioButton();
            this.optSuspend = new System.Windows.Forms.RadioButton();
            this.optRenewal = new System.Windows.Forms.RadioButton();
            this.cboVendor = new System.Windows.Forms.ComboBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblRefDate = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.grpRemarks.SuspendLayout();
            this.grpValid.SuspendLayout();
            this.VendorType.SuspendLayout();
            this.grdpStatusType.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.grpRemarks);
            this.panel1.Controls.Add(this.grpValid);
            this.panel1.Controls.Add(this.VendorType);
            this.panel1.Controls.Add(this.grdpStatusType);
            this.panel1.Controls.Add(this.cboVendor);
            this.panel1.Controls.Add(this.lblVendor);
            this.panel1.Controls.Add(this.txtRefNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.lblRefDate);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 399);
            this.panel1.TabIndex = 0;
            // 
            // grpRemarks
            // 
            this.grpRemarks.Controls.Add(this.txtRemarks);
            this.grpRemarks.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRemarks.Location = new System.Drawing.Point(24, 273);
            this.grpRemarks.Name = "grpRemarks";
            this.grpRemarks.Size = new System.Drawing.Size(407, 70);
            this.grpRemarks.TabIndex = 17;
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
            this.txtRemarks.Size = new System.Drawing.Size(401, 50);
            this.txtRemarks.TabIndex = 18;
            // 
            // grpValid
            // 
            this.grpValid.Controls.Add(this.chkLifTime);
            this.grpValid.Controls.Add(this.dtpTDate);
            this.grpValid.Controls.Add(this.dtpFDate);
            this.grpValid.Controls.Add(this.label3);
            this.grpValid.Controls.Add(this.lblFrom);
            this.grpValid.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpValid.Location = new System.Drawing.Point(24, 217);
            this.grpValid.Name = "grpValid";
            this.grpValid.Size = new System.Drawing.Size(407, 50);
            this.grpValid.TabIndex = 0;
            this.grpValid.TabStop = false;
            this.grpValid.Text = "Validity";
            // 
            // chkLifTime
            // 
            this.chkLifTime.AutoSize = true;
            this.chkLifTime.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLifTime.Location = new System.Drawing.Point(333, 20);
            this.chkLifTime.Name = "chkLifTime";
            this.chkLifTime.Size = new System.Drawing.Size(68, 17);
            this.chkLifTime.TabIndex = 16;
            this.chkLifTime.Text = "Life Time";
            this.chkLifTime.UseVisualStyleBackColor = true;
            // 
            // dtpTDate
            // 
            this.dtpTDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTDate.Location = new System.Drawing.Point(200, 20);
            this.dtpTDate.Name = "dtpTDate";
            this.dtpTDate.Size = new System.Drawing.Size(112, 21);
            this.dtpTDate.TabIndex = 15;
            // 
            // dtpFDate
            // 
            this.dtpFDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFDate.Location = new System.Drawing.Point(48, 20);
            this.dtpFDate.Name = "dtpFDate";
            this.dtpFDate.Size = new System.Drawing.Size(105, 21);
            this.dtpFDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(177, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(11, 24);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(31, 13);
            this.lblFrom.TabIndex = 76;
            this.lblFrom.Text = "From";
            // 
            // VendorType
            // 
            this.VendorType.Controls.Add(this.optService);
            this.VendorType.Controls.Add(this.optContract);
            this.VendorType.Controls.Add(this.optSupply);
            this.VendorType.Controls.Add(this.lblRegNo);
            this.VendorType.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VendorType.Location = new System.Drawing.Point(24, 140);
            this.VendorType.Name = "VendorType";
            this.VendorType.Size = new System.Drawing.Size(407, 71);
            this.VendorType.TabIndex = 4;
            this.VendorType.TabStop = false;
            this.VendorType.Text = "Vendor Type";
            // 
            // optService
            // 
            this.optService.AutoSize = true;
            this.optService.Location = new System.Drawing.Point(238, 20);
            this.optService.Name = "optService";
            this.optService.Size = new System.Drawing.Size(101, 17);
            this.optService.TabIndex = 2;
            this.optService.Text = "Service Provider";
            this.optService.UseVisualStyleBackColor = true;
            // 
            // optContract
            // 
            this.optContract.AutoSize = true;
            this.optContract.Location = new System.Drawing.Point(148, 20);
            this.optContract.Name = "optContract";
            this.optContract.Size = new System.Drawing.Size(75, 17);
            this.optContract.TabIndex = 1;
            this.optContract.Text = "Contractor";
            this.optContract.UseVisualStyleBackColor = true;
            // 
            // optSupply
            // 
            this.optSupply.AutoSize = true;
            this.optSupply.Location = new System.Drawing.Point(68, 20);
            this.optSupply.Name = "optSupply";
            this.optSupply.Size = new System.Drawing.Size(64, 17);
            this.optSupply.TabIndex = 0;
            this.optSupply.Text = "Supplier";
            this.optSupply.UseVisualStyleBackColor = true;
            // 
            // lblRegNo
            // 
            this.lblRegNo.AutoSize = true;
            this.lblRegNo.Location = new System.Drawing.Point(73, 47);
            this.lblRegNo.Name = "lblRegNo";
            this.lblRegNo.Size = new System.Drawing.Size(196, 13);
            this.lblRegNo.TabIndex = 75;
            this.lblRegNo.Text = "Reg No ___________  dated  _____________";
            // 
            // grdpStatusType
            // 
            this.grdpStatusType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.grdpStatusType.Controls.Add(this.optCancel);
            this.grdpStatusType.Controls.Add(this.optBlock);
            this.grdpStatusType.Controls.Add(this.optSuspend);
            this.grdpStatusType.Controls.Add(this.optRenewal);
            this.grdpStatusType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdpStatusType.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdpStatusType.Location = new System.Drawing.Point(0, 0);
            this.grdpStatusType.Name = "grdpStatusType";
            this.grdpStatusType.Size = new System.Drawing.Size(449, 45);
            this.grdpStatusType.TabIndex = 0;
            this.grdpStatusType.TabStop = false;
            this.grdpStatusType.Text = "Stauts Type";
            // 
            // optCancel
            // 
            this.optCancel.AutoSize = true;
            this.optCancel.Location = new System.Drawing.Point(319, 20);
            this.optCancel.Name = "optCancel";
            this.optCancel.Size = new System.Drawing.Size(82, 17);
            this.optCancel.TabIndex = 3;
            this.optCancel.TabStop = true;
            this.optCancel.Text = "Cancellation";
            this.optCancel.UseVisualStyleBackColor = true;
            // 
            // optBlock
            // 
            this.optBlock.AutoSize = true;
            this.optBlock.Location = new System.Drawing.Point(224, 20);
            this.optBlock.Name = "optBlock";
            this.optBlock.Size = new System.Drawing.Size(65, 17);
            this.optBlock.TabIndex = 2;
            this.optBlock.TabStop = true;
            this.optBlock.Text = "BlackList";
            this.optBlock.UseVisualStyleBackColor = true;
            // 
            // optSuspend
            // 
            this.optSuspend.AutoSize = true;
            this.optSuspend.Location = new System.Drawing.Point(129, 20);
            this.optSuspend.Name = "optSuspend";
            this.optSuspend.Size = new System.Drawing.Size(64, 17);
            this.optSuspend.TabIndex = 1;
            this.optSuspend.TabStop = true;
            this.optSuspend.Text = "Suspend";
            this.optSuspend.UseVisualStyleBackColor = true;
            // 
            // optRenewal
            // 
            this.optRenewal.AutoSize = true;
            this.optRenewal.Location = new System.Drawing.Point(38, 20);
            this.optRenewal.Name = "optRenewal";
            this.optRenewal.Size = new System.Drawing.Size(65, 17);
            this.optRenewal.TabIndex = 0;
            this.optRenewal.TabStop = true;
            this.optRenewal.Text = "Renewal";
            this.optRenewal.UseVisualStyleBackColor = true;
            // 
            // cboVendor
            // 
            this.cboVendor.FormattingEnabled = true;
            this.cboVendor.Location = new System.Drawing.Point(92, 104);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.Size = new System.Drawing.Size(339, 21);
            this.cboVendor.TabIndex = 9;
            this.cboVendor.SelectedIndexChanged += new System.EventHandler(this.cboVendor_SelectedIndexChanged);
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendor.Location = new System.Drawing.Point(21, 107);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(70, 13);
            this.lblVendor.TabIndex = 8;
            this.lblVendor.Text = "Vendor Name";
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(262, 62);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(169, 21);
            this.txtRefNo.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ref No";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(92, 64);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(112, 21);
            this.dtpDate.TabIndex = 5;
            // 
            // lblRefDate
            // 
            this.lblRefDate.AutoSize = true;
            this.lblRefDate.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefDate.Location = new System.Drawing.Point(21, 70);
            this.lblRefDate.Name = "lblRefDate";
            this.lblRefDate.Size = new System.Drawing.Size(29, 13);
            this.lblRefDate.TabIndex = 4;
            this.lblRefDate.Text = "Date";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmdCancel);
            this.panel2.Controls.Add(this.cmdOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 349);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(449, 50);
            this.panel2.TabIndex = 7;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(223, 10);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(71, 27);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(130, 10);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(71, 27);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmStatusEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(449, 399);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmStatusEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status Entry";
            this.Load += new System.EventHandler(this.frmStatusEntry_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpRemarks.ResumeLayout(false);
            this.grpRemarks.PerformLayout();
            this.grpValid.ResumeLayout(false);
            this.grpValid.PerformLayout();
            this.VendorType.ResumeLayout(false);
            this.VendorType.PerformLayout();
            this.grdpStatusType.ResumeLayout(false);
            this.grdpStatusType.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblRefDate;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.ComboBox cboVendor;
        private System.Windows.Forms.GroupBox grdpStatusType;
        private System.Windows.Forms.RadioButton optSuspend;
        private System.Windows.Forms.RadioButton optRenewal;
        private System.Windows.Forms.GroupBox VendorType;
        private System.Windows.Forms.RadioButton optBlock;
        private System.Windows.Forms.Label lblRegNo;
        private System.Windows.Forms.GroupBox grpRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.GroupBox grpValid;
        private System.Windows.Forms.CheckBox chkLifTime;
        private System.Windows.Forms.DateTimePicker dtpTDate;
        private System.Windows.Forms.DateTimePicker dtpFDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.RadioButton optCancel;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.RadioButton optService;
        private System.Windows.Forms.RadioButton optContract;
        private System.Windows.Forms.RadioButton optSupply;
    }
}