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
    public partial class frmStateEntry : Form
    {
        int m_lStateId;
        Vendor.BusinessLayer.StateBL m_oState;
        Vendor.BusinessLayer.CountryBL m_oCountry;
        StringBuilder sb = null;
        DataTable m_tCountry;
        bool m_bOk = false;
        public frmStateEntry()
        {
            InitializeComponent();
            m_oState = new Vendor.BusinessLayer.StateBL();
            m_oCountry = new Vendor.BusinessLayer.CountryBL();
        }

        public bool Execute(int argID)
        {
            m_lStateId = argID;
            this.ShowDialog();
            return m_bOk;
        }

        private void cmdAddCountry_Click(object sender, EventArgs e)
        {
            int lCountry = 0;
            if (m_tCountry.Rows.Count >= 0) { lCountry = Convert.ToInt32(cboCountry.EditValue); }
            frmCountryMaster CountryMaster = new frmCountryMaster();
            CountryMaster.Execute();
            PopulateCountry();
            if (lCountry != 0) { cboCountry.EditValue = lCountry; }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmStateEntry_Load(object sender, EventArgs e)
        {
            PopulateCountry();
            if (m_lStateId != 0) {PopulateData();}
         }
        private void PopulateCountry()
        {
            m_tCountry = new DataTable();
            m_tCountry = m_oCountry.GetCountryList();
            cboCountry.Properties.DataSource = m_tCountry;
            cboCountry.Properties.ForceInitialize();
            cboCountry.Properties.PopulateColumns();
            cboCountry.Properties.DisplayMember = "CountryName";
            cboCountry.Properties.ValueMember = "CountryId";
            cboCountry.Properties.ShowHeader = false;
            cboCountry.Properties.ShowFooter = false;
            cboCountry.Properties.Columns["CountryId"].Visible = false;
        }


        private void PopulateData()
        {
            DataTable dt;
            int lCountryId = 0;
            dt = m_oState.GetStateData(m_lStateId);
            if (dt.Rows.Count > 0)
            {
                txtState.Text = dt.Rows[0]["StateName"].ToString();
                lCountryId = Convert.ToInt32(dt.Rows[0]["CountryId"].ToString());
                cboCountry.EditValue = lCountryId;
            }
        }


        private void cboCountry_KeyUp(object sender, KeyEventArgs e)
        {
            if (m_tCountry.Rows.Count <= 0)
                return;
            //clsStatic.AutoComplete(cboCountry, e);
        }
       
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                m_oState.StateName = txtState.Text;
                m_oState.CountryId = Convert.ToInt32(cboCountry.EditValue);
                if (m_lStateId != 0)
                {
                    m_oState.StateId = m_lStateId;
                    m_oState.UpdateState(m_oState);
                }
                else
                {
                    m_oState.InsertState(m_oState);
                }
                m_bOk = true;
                this.Close();
            }
        }


        public bool Validation()
        {
            bool valid = true;
            sb = new StringBuilder();

            if (txtState.Text.Trim() == string.Empty)
            {
                valid = false;
                sb.Append(" * State Name not Empty" + Environment.NewLine);
                errorProvider1.SetError(txtState, "State Name not Empty");
            }
            else
            {
                errorProvider1.SetError(txtState, "");
            }


            if (cboCountry.ItemIndex < 0 )
            {
                valid = false;
                sb.Append(" * Select Country" + Environment.NewLine);
                errorProvider1.SetError(cboCountry, "Select Country");
            }
            else
            {
                errorProvider1.SetError(cboCountry, "");
            }

            return valid;
        }

        private void barExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            m_bOk = false;
            this.Close();
        }

        
    }
}
