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
    public partial class frmExperience : Form
    {
        bool m_bOk = false;
        int m_lVendorId = 0;
        int m_lExpId = 0;
        StringBuilder sb = null;
        DataTable m_tExp = new DataTable();
        Vendor.BusinessLayer.ExperienceBL m_oExp;

        public frmExperience()
        {
            InitializeComponent();
            m_oExp = new Vendor.BusinessLayer.ExperienceBL();
        }

        public bool Execute(int argExpId, int argVendorId, DataTable argDt)
        {
            m_lExpId = argExpId;
            m_lVendorId = argVendorId;
            m_tExp = argDt;
            this.ShowDialog();
            return m_bOk;
        }     
        private void barExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_bOk = false;
            this.Close();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmExperience_Load(object sender, EventArgs e)
        {
            txtWork.Text = "";
            txtClient.Text = "";
            txtValue.Text = "";
            txtPeriod.Text = "";
            txtType.Text = "";
            if (m_lExpId != 0) { PopulateData(); }
        }

        private void PopulateData()
        {
            if (m_tExp != null)
            {
                if (m_tExp.Rows.Count != 0)
                {
                    txtWork.Text = m_tExp.Rows[0]["WorkDescription"].ToString();
                    txtClient.Text = m_tExp.Rows[0]["ClientName"].ToString();
                    txtValue.Text = clsStatic.FormatNum(m_tExp.Rows[0]["Value"].ToString(), clsStatic.g_iCurrencyDigit);
                    txtPeriod.Text = m_tExp.Rows[0]["Period"].ToString();
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            bool bAns = false;
            try
            {
                if (Validation() == true)
                {
                    m_oExp.ExperienceId = m_lExpId;
                    m_oExp.VendorId = m_lVendorId;
                    m_oExp.WorkDescription = txtWork.Text;
                    m_oExp.ClientName = txtClient.Text;
                    m_oExp.Value = txtValue.Text == string.Empty ? 0 : Convert.ToDecimal(txtValue.Text);
                    m_oExp.Period = txtPeriod.Text;
                    m_oExp.Type = txtType.Text;
                    if (m_oExp.ExperienceId != 0) { m_oExp.UpdateExperience(m_oExp); }
                    else { m_oExp.InsertExperience(m_oExp); }
                    bAns = true;
                }
            }
            catch (Exception Excep)
            {
                throw Excep;
            }
            if (bAns == true)
            {
                m_bOk = true;
                this.Close();
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
                e.Handled = true;
            else e.Handled = false;
            if (e.KeyChar == 8)
                e.Handled = false;

            if (e.KeyChar == '.')
            {
                char[] c = (((System.Windows.Forms.TextBoxBase)(sender))).Text.ToString().ToCharArray();
                int cnt = 1;
                foreach (char b in c)
                {
                    if (b == '.')
                    {
                        cnt += 1;
                    }
                }
                if (cnt > 1)
                {
                    e.Handled = true;
                }
                else { e.Handled = false; }
            }
        }

        private void txtValue_Validated(object sender, EventArgs e)
        {
            txtValue.Text = clsStatic.FormatNum(txtValue.Text, clsStatic.g_iCurrencyDigit);
        }

        private void frmExperience_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13){SendKeys.Send("{tab}");}
        }

        private bool Validation()
        {
            bool valid = true;
            sb = new StringBuilder();

            if (txtWork.Text.Trim() == string.Empty)
            {
                valid = false;
                sb.Append(" * Name of Work not Empty" + Environment.NewLine);
                errorProvider1.SetError(txtWork, "Name of Work not Empty");
            }
            else
            {
                errorProvider1.SetError(txtWork, "");
            }


            if (txtValue.Text.Trim() == string.Empty)
            {
                valid = false;
                sb.Append(" * Value not Empty" + Environment.NewLine);
                errorProvider1.SetError(txtValue, "Value not Empty");
            }
            else
            {
                errorProvider1.SetError(txtValue, "");
            }

            return valid;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            m_bOk = false;
            this.Close();
        }

    }
}
