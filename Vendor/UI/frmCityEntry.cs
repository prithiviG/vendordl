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
    public partial class frmCityEntry : Form
    {
        Vendor.BusinessLayer.CityBL m_oCity;
        Vendor.BusinessLayer.CountryBL m_oCountry;
        Vendor.BusinessLayer.StateBL m_oState;
        DataTable m_tState =  new DataTable();
        DataTable m_tCity = new DataTable();
        DataTable m_tCountry = new DataTable();
        bool m_bOk = false;
        StringBuilder sb = null;
        int m_lCityId =0;
       
        public frmCityEntry()
        {
           
            InitializeComponent();
            m_oCity = new Vendor.BusinessLayer.CityBL();
            m_oCountry = new Vendor.BusinessLayer.CountryBL();
            m_oState = new Vendor.BusinessLayer.StateBL();
        }
        public bool Execute(int argID,DataTable argCity)
        {
            m_lCityId = argID;
            m_tCity = argCity;
            this.ShowDialog();
            return m_bOk;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        public void frmCityEntry_Load(object sender, EventArgs e)
        {
            PopulateCountry();
            if (m_lCityId != 0) {PopulateData();}
        }

        private void PopulateData()
        {
            DataView dv;
            DataTable dt;

            dv = new DataView(m_tCity);
            dv.RowFilter = "CityId = " + m_lCityId;
            dt = dv.ToTable();
            if (dt.Rows.Count > 0)
            {
                txtCity.Text = dt.Rows[0]["CityName"].ToString();
                cboCountry.EditValue = Convert.ToInt32(dt.Rows[0]["CountryID"].ToString());
                cboState.EditValue = Convert.ToInt32(dt.Rows[0]["StateId"].ToString());
            }
        }

       
        private void cboCountry_KeyUp(object sender, KeyEventArgs e)
        {
            if (m_tCountry.Rows.Count <= 0)
                return;
        }

        private void cboState_KeyUp(object sender, KeyEventArgs e)
        {
            if (m_tState.Rows.Count <= 0)
                return;
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
            cboCountry.ItemIndex = -1;
            cboCountry.Properties.Columns["CountryId"].Visible = false;
            cboCountry.Properties.ShowHeader = false;
            cboCountry.Properties.ShowFooter = false;
        }
            
        private void cmdAddCountry_Click(object sender, EventArgs e)
        {
            int lCountry = 0;
            if (m_tCountry.Rows.Count >= 0) { lCountry = Convert.ToInt32(cboCountry.EditValue); }
            frmCountryMaster CountryMaster = new frmCountryMaster();
            CountryMaster.Execute();
            PopulateCountry();
            if (lCountry != 0){cboCountry.EditValue = lCountry;}
        }

        private void cmdAddState_Click(object sender, EventArgs e)
        {
            int lState = 0;
            if (m_tState.Rows.Count >= 0) { lState = Convert.ToInt32(cboState.EditValue); }
            frmStateMaster StateMaster = new frmStateMaster();
            StateMaster.Execute();
            PopulateState(Convert.ToInt32(cboCountry.EditValue));
            if (lState != 0) { cboState.EditValue = lState; }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {

            if (Validation() == true)
            {
                m_oCity.CityName = txtCity.Text;
                m_oCity.StateId = Convert.ToInt32(cboState.EditValue);
                m_oCity.CountryId = Convert.ToInt32(cboCountry.EditValue);
                if (m_lCityId != 0)
                {
                    m_oCity.CityId = m_lCityId;
                    m_oCity.UpdateCity(m_oCity);
                }
                else
                {
                    m_oCity.InsertCity(m_oCity);
                }
                m_bOk = true;
                this.Close();
            }
        }

     

        private bool Validation()
        {
            bool valid = true;
            sb = new StringBuilder();

            if (txtCity.Text.Trim() == string.Empty)
            {
                valid = false;
                sb.Append(" * City Name not Empty" + Environment.NewLine);
                errorProvider1.SetError(txtCity, "City Name not Empty");
            }
            else
            {
                errorProvider1.SetError(txtCity, "");
            }

            if (cboState.ItemIndex < 0)
            {
                valid = false;
                sb.Append(" * Select State" + Environment.NewLine);
                errorProvider1.SetError(cboState, "Select State");
            }
            else
            {
                errorProvider1.SetError(cboState, "");
            }


            if (cboCountry.ItemIndex < 0)
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

        private void PopulateState(int argCountryId)
        {
            m_tState = new DataTable();
            m_tState = m_oState.GetStateList();

            cboState.Properties.DataSource = null;
            DataView dv;
            dv = new DataView(m_tState);
            dv.RowFilter = "CountryId = " + argCountryId;
            cboState.Properties.DataSource = dv.ToTable();
            cboState.Properties.ForceInitialize();
            cboState.Properties.PopulateColumns();
            cboState.Properties.DisplayMember = "StateName";
            cboState.Properties.ValueMember = "StateId";
            cboState.Properties.Columns["StateId"].Visible = false;
            cboState.Properties.Columns["CountryName"].Visible = false;
            cboState.Properties.Columns["CountryId"].Visible = false;
            cboState.Properties.ShowHeader = false;
            cboState.Properties.ShowFooter = false;
        }


        private void barExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_bOk = false;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            m_bOk = false;
            this.Close();
        }
        
        private void cboCountry_EditValueChanged(object sender, EventArgs e)
        {
            int lCountryId = Convert.ToInt32(cboCountry.EditValue);
            PopulateState(lCountryId);
        }

        private void cboState_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
