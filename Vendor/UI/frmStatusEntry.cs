using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vendor
{
    public partial class frmStatusEntry : Form
    {
        string SType = "";
        string RType = "";
        DataTable m_tVendorName;
        int VenId;
        //bool m_bOk = false;
        Vendor.BusinessLayer.StatusBL m_oStatus;
        public frmStatusEntry()
        {
            InitializeComponent();
            m_oStatus = new Vendor.BusinessLayer.StatusBL();
        }

        public void Execute()
        {
            this.ShowDialog();
           
        }
        public void ExecuteEdit(DataSet ds)
        {
            PopulateVendorName();
            m_oStatus.StatusId=Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
            ds.Tables[0].Rows[0].ItemArray[2].ToString();
            if (ds.Tables[0].Rows[0].ItemArray[2].ToString() == "R")
            {
                optRenewal.Checked = true;
            }
            if (ds.Tables[0].Rows[0].ItemArray[2].ToString() == "S")
            {
                optSuspend.Checked = true;
            }
            if (ds.Tables[0].Rows[0].ItemArray[2].ToString() == "B")
            {
                optBlock.Checked = true;
            }
            if (ds.Tables[0].Rows[0].ItemArray[2].ToString() == "C")
            {
                optCancel.Checked = true;
            }
            ds.Tables[0].Rows[0].ItemArray[6].ToString();
            dtpDate.Text  = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            txtRefNo.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            cboVendor.SelectedValue = ds.Tables[0].Rows[0].ItemArray[1];
            if (ds.Tables[0].Rows[0].ItemArray[3].ToString() == "S")
            {
                optSupply.Checked = true;
            }
            if (ds.Tables[0].Rows[0].ItemArray[3].ToString() == "C")
            {
                optContract.Checked = true;
            }
            if (ds.Tables[0].Rows[0].ItemArray[3].ToString() == "H")
            {
                optService.Checked = true;
            }
            dtpFDate.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            dtpTDate.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            if (Convert.ToBoolean(ds.Tables[0].Rows[0].ItemArray[9]) == false)
            {
                chkLifTime.Checked = false;
            }
            else
            {
                chkLifTime.Checked = true;
            }
            this.ShowDialog();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //m_bOk = false;
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            
            m_oStatus.VendorId = VenId;
            if (optRenewal.Checked == true)
            {
                SType = "R";
            }
            if (optSuspend.Checked == true)
            {
                SType = "S";
            }
            if (optBlock.Checked == true)
            {
                SType = "B";
            }
            if (optCancel.Checked == true)
            {
                SType = "C";
            }
            m_oStatus.StatusType = SType;
            if (optSupply.Checked == true)
            {
                RType = "S";
            }
            if (optContract.Checked == true)
            {
                RType = "C";
            }
            if (optService.Checked == true)
            {
                RType = "H";
            }
            m_oStatus.RefNo = txtRefNo.Text;
            m_oStatus.RegType = RType;
            m_oStatus.SDate = dtpDate.Value;
            m_oStatus.ValidFrom = dtpFDate.Value;
            m_oStatus.ValidTo = dtpTDate.Value;
            if (chkLifTime.Checked == true)
            {
                m_oStatus.LifTime = 1;
            }
            else
            {
                m_oStatus.LifTime = 0;
            }
            if (m_oStatus.StatusId == 0)
            {
                m_oStatus.InsertStatusEntry(m_oStatus);
            }
            else
            {
                m_oStatus.UpdateStatusEntry(m_oStatus);  
            }
            //m_bOk = true;
            this.Close();
        }
        private void PopulateVendorName()
        {
            DataTable dt = new DataTable();
            m_tVendorName = new DataTable();
            dt = m_oStatus.GetVendorName();
            m_tVendorName = dt;
            cboVendor.DataSource = m_tVendorName;
            cboVendor.DisplayMember = "VendorName";
            cboVendor.ValueMember = "VendorId";
            cboVendor.SelectedIndex = 0;
            VenId = Convert.ToInt32(cboVendor.SelectedValue);          
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmStatusEntry_Load(object sender, EventArgs e)
        {
            if (VenId == 0)
            {
                PopulateVendorName();
            }
        }

        private void cboVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVendor.SelectedIndex >= 0 & cboVendor.ValueMember !="")
            {
                VenId = Convert.ToInt32(cboVendor.SelectedValue);
            }           
        }

       
    }
}
