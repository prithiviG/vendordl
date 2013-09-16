using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vendor.BusinessLayer;

namespace Vendor
{
    public partial class frmBranch : Form
    {
        public DataTable m_tCity;
        DataTable m_tBranch;

        StringBuilder sb = null;
        int m_lBranchId = 0;
        int m_lVendorId = 0;
        bool m_bOK = false;
        Vendor.BusinessLayer.CityBL m_oCity;
        Vendor.BusinessLayer.BranchBL m_oBranch;
        frmMain frm;
        DataTable dtContact;
        public frmBranch()
        {
            InitializeComponent();
            m_oCity = new Vendor.BusinessLayer.CityBL();
            m_oBranch = new Vendor.BusinessLayer.BranchBL();
        }

        public bool Execute(int argBranchId,DataTable argBranch,DataTable argCity,int argVendorId,frmMain _frm)
        {
            m_lBranchId = argBranchId;
            m_tBranch = argBranch;
            m_tCity = argCity;
            m_lVendorId = argVendorId;
            frm = _frm;
            this.ShowDialog ();
            return m_bOK;
        }

        private void cmdAddCity_Click(object sender, EventArgs e)
        {
            int lCityId = 0;
            if (cboCity.ItemIndex >= 0) { lCityId = Convert.ToInt32(cboCity.EditValue); }
            frmCityMaster CityMaster = new frmCityMaster();
            CityMaster.Execute(this,frm);
            PopulateCity();
            if (lCityId != 0){cboCity.EditValue = lCityId;}
        }

        private void PopulateCity()
        {
            m_tCity = m_oCity.GetCityList();
            
            DataRow dr;
            DataView dv = new DataView(m_tCity);
            dv.RowFilter = "CityId=0";
            if (dv.ToTable().Rows.Count > 0) { }
            else
            {
                dr = m_tCity.NewRow();
                dr["CityName"] = "None";
                dr["CityId"] = 0;
                dr["StateName"] = "None";
                dr["CountryName"] = "None";
                dr["CountryId"] = 0;
                dr["StateId"] = 0;
                m_tCity.Rows.InsertAt(dr, 0);
            }

            cboCity.Properties.DataSource = m_tCity;
            cboCity.Properties.ForceInitialize();
            cboCity.Properties.PopulateColumns();
            cboCity.Properties.DisplayMember = "CityName";
            cboCity.Properties.ValueMember = "CityId";
            cboCity.Properties.ShowFooter = false;
            cboCity.Properties.ShowHeader = false;
            cboCity.Properties.Columns["CityId"].Visible = false;
            cboCity.Properties.Columns["StateName"].Visible = false;
            cboCity.Properties.Columns["CountryName"].Visible = false;
            cboCity.Properties.Columns["CountryId"].Visible = false;
            cboCity.Properties.Columns["StateId"].Visible = false;
            cboCity.ItemIndex = -1;

            if (m_tCity.Rows.Count > 0) { cboCity.ItemIndex = 0; }
        }

        private void PopulateData()
        {
            if (m_tBranch.Rows.Count > 0)
            {
                int lCityId = 0;
                txtBranchName.Text = m_tBranch.Rows[0]["BranchName"].ToString();
                txtAddress.Text = m_tBranch.Rows[0]["Address"].ToString();
                lCityId = Convert.ToInt32(m_tBranch.Rows[0]["CityId"].ToString());
                txtTINNo.Text = m_tBranch.Rows[0]["TINNo"].ToString();
                cboCity.EditValue = lCityId;
                txtPhone.Text = m_tBranch.Rows[0]["Phone"].ToString();
                txtCheque.Text = m_tBranch.Rows[0]["ChequeNo"].ToString();
                
            }

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        public void frmBranch_Load(object sender, EventArgs e)
        {
            PopulateCity();
            PopulateContact();
            if (m_lBranchId != 0) { PopulateData(); }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            m_bOK = false;
            this.Close();
        }

        private void cboCity_KeyUp(object sender, KeyEventArgs e)
        {
           if (m_tCity.Rows.Count <= 0)
           return;
           //clsStatic.AutoComplete(cboCity, e);
        }


        private bool Validation()
        {
            bool valid = true;
            sb = new StringBuilder();

            if (cboCity.ItemIndex < 0)
            {
                valid = false;
                sb.Append(" * Select City" + Environment.NewLine);
                errorProvider1.SetError(cboCity, "Select City");
            }
            else
            {
                errorProvider1.SetError(cboCity, "");
            }

            return valid;
        }

        private void PopulateContact()
        {
            dtContact = new DataTable();
            dtContact = BranchBL.GetContact(m_lBranchId);
            grdContact.DataSource = dtContact;
            ContactView.Columns["BranchTransId"].Visible = false;
            ContactView.Columns["BranchId"].Visible = false;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            bool bAns = false;
            try
            {
                if (Validation() == true)
                {
                    ContactView.FocusedRowHandle = ContactView.FocusedRowHandle + 1;
                    m_oBranch.BranchId = m_lBranchId;
                    m_oBranch.VendorId = m_lVendorId;
                    m_oBranch.BranchName = txtBranchName.Text;
                    m_oBranch.BranchAddress = txtAddress.Text;
                    m_oBranch.CityId = Convert.ToInt32(cboCity.EditValue);
                    m_oBranch.TINNo = txtTINNo.Text;
                    m_oBranch.Phone = txtPhone.Text;
                    m_oBranch.ChequeNo = txtCheque.Text;

                    if (m_lBranchId != 0) { m_oBranch.UpdateBranch(m_oBranch,dtContact); }
                    else { m_oBranch.InsertBranch(m_oBranch,dtContact); }
                    bAns = true;
                }
            }
            catch (Exception Excep)
            {
                throw Excep;
            }
            if (bAns == true)
            {
                m_bOK = true;
                this.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

      
    }
}
