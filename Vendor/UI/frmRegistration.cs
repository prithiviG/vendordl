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
    public partial class frmRegistration : Form
    {
        private Rectangle _V;
        int m_lVendorId;
        int m_lRegisterId;
        string m_sVendorName;
        DataTable m_tSupplyGrade;
        DataTable m_tContractGrade;
        DataTable m_tServiceGrade; 
        BsfGlobal.VoucherType oVType;
        StringBuilder sb = null;
        DateTime m_dOldDate;
        Vendor.BusinessLayer.RegisterBL m_oRegister;
        Vendor.BusinessLayer.RegUpdateBL m_oRegUpdate;
       // DataTable dtType;

        public frmRegistration()
        {
            InitializeComponent();
            m_oRegister = new Vendor.BusinessLayer.RegisterBL();
            m_oRegUpdate = new Vendor.BusinessLayer.RegUpdateBL();
            oVType = new BsfGlobal.VoucherType();
        }

        public void Execute(int argVendorId,string argVendorName)
        {
            m_lVendorId = argVendorId;
            m_sVendorName = argVendorName;
            this.Show();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {          
            SetDefault();
            PopulateData();
            GetGradeDetails();
        }
        private void GetGradeDetails()
        {
            m_tSupplyGrade = new DataTable();
            m_tContractGrade = new DataTable();
            m_tServiceGrade = new DataTable();
            m_tSupplyGrade = m_oRegister.GetGradeName(m_lVendorId, "S");
            m_tContractGrade = m_oRegister.GetGradeName(m_lVendorId, "C");
            m_tServiceGrade = m_oRegister.GetGradeName(m_lVendorId, "H");
            if (m_tSupplyGrade != null)
            {
                if (m_tSupplyGrade.Rows.Count > 0)
                {
                    txtSGradeName.Text = m_tSupplyGrade.Rows[0][1].ToString();
                    txtSGradeName.Tag = m_tSupplyGrade.Rows[0][0].ToString();
                }
                else
                {
                    txtSGradeName.Text = "";
                    txtSGradeName.Tag = 0;
                }
            }
            else
            {
                txtSGradeName.Text = "";
                txtSGradeName.Tag = 0;
            }
            if (m_tContractGrade != null)
            {
                if (m_tContractGrade.Rows.Count > 0)
                {
                    txtCGradeName.Text = m_tContractGrade.Rows[0][1].ToString();
                    txtCGradeName.Tag = m_tContractGrade.Rows[0][0].ToString();
                }
                else
                {
                    txtSGradeName.Text = "";
                    txtSGradeName.Tag = 0;
                }
            }
            else
            {
                txtCGradeName.Text = "";
                txtCGradeName.Tag = 0;
            }
            if (m_tServiceGrade != null)
            {
                if (m_tServiceGrade.Rows.Count > 0)
                {
                    txtHGradeName.Text = m_tServiceGrade.Rows[0][1].ToString();
                    txtHGradeName.Tag = m_tServiceGrade.Rows[0][0].ToString();
                }
                else
                {
                    txtSGradeName.Text = "";
                    txtSGradeName.Tag = 0;
                }
            }
            else
            {
                 txtHGradeName.Text = "";
                 txtHGradeName.Tag = 0;
            }
        }
        private void PopulateData()
        {
            DataTable dt;
            dt = new DataTable();
            dt = m_oRegister.GetRegistration(m_lVendorId);
            if (dt.Rows.Count > 0)
            {
                m_lRegisterId = Convert.ToInt32(dt.Rows[0]["RegisterId"].ToString());
                dtpDate.Value = Convert.ToDateTime(dt.Rows[0]["RegDate"].ToString());
                m_dOldDate = Convert.ToDateTime(dt.Rows[0]["RegDate"].ToString());
                txtRegNo.Text = dt.Rows[0]["RegNo"].ToString();
                if (Convert.ToBoolean(dt.Rows[0]["Supply"].ToString()) == true)
                {
                    chkSupply.Checked = true;
                    dtpSFDate.Value = Convert.ToDateTime(dt.Rows[0]["SFDate"].ToString());
                    dtpSTDate.Value = Convert.ToDateTime(dt.Rows[0]["STDate"].ToString());
                    if (Convert.ToBoolean(dt.Rows[0]["SLifeTime"].ToString()) == true) { chkSLife.Checked = true;  }
                    //txtSGradeName.Text = dt.Rows[0]["SGrade"].ToString();
                    //txtSGradeName.Tag = dt.Rows[0]["SGradeID"].ToString();

                }

                if (Convert.ToBoolean(dt.Rows[0]["Contract"].ToString()) == true)
                {
                    chkContract.Checked = true;
                    dtpCFDate.Value = Convert.ToDateTime(dt.Rows[0]["CFDate"].ToString());
                    dtpCTDate.Value = Convert.ToDateTime(dt.Rows[0]["CTDate"].ToString());
                    if (Convert.ToBoolean(dt.Rows[0]["CLifeTime"].ToString()) == true) { chkCLife.Checked = true; }
                    //txtCGradeName.Text = dt.Rows[0]["CGrade"].ToString();
                    //txtCGradeName.Tag = dt.Rows[0]["CGradeID"].ToString();
                }

                if (Convert.ToBoolean(dt.Rows[0]["Service"].ToString()) == true)
                {
                    chkService.Checked = true;
                    dtpHFDate.Value = Convert.ToDateTime(dt.Rows[0]["HFDate"].ToString());
                    dtpHTDate.Value = Convert.ToDateTime(dt.Rows[0]["HTDate"].ToString());
                    if (Convert.ToBoolean(dt.Rows[0]["HLifeTime"].ToString()) == true) { chkHLife.Checked = true; }
                    //txtHGradeName.Text = dt.Rows[0]["HGrade"].ToString();
                    //txtHGradeName.Tag = dt.Rows[0]["HGradeID"].ToString();
                }
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();

    
            }
            if (m_lRegisterId != 0)
            {
                if (m_oRegister.CheckRegTrans(m_lVendorId) == true) 
                { 
                    cmdRemove.Visible = false;
                    cmdOK.Enabled = false;
                }
                else 
                {
                    cmdRemove.Visible= true;
                    cmdOK.Enabled = true;
                }
            }

            UpdateRegNo();
        }


        //private string GetRegNo()
        //{
        //    string sRegNo = "";
        //    string sVNo = "";
        //    int iLen = 0;
        //    string sPre = "";
        //    if (dtType.Rows.Count > 0)
        //    {
        //        if (Convert.ToBoolean(dtType.Rows[0]["GenType"].ToString()) == true)
        //        {
        //            if (Convert.ToInt32(dtType.Rows[0]["StartNo"].ToString()) > Convert.ToInt32(dtType.Rows[0]["MaxNo"].ToString()))
        //            {
        //                sVNo = dtType.Rows[0]["StartNo"].ToString().Trim();
        //            }
        //            else
        //            {
        //                sVNo = Convert.ToString(Convert.ToInt32(dtType.Rows[0]["StartNo"].ToString()) + 1).Trim();
        //            }
        //            iLen = Convert.ToInt32(dtType.Rows[0]["Width"].ToString()) - sVNo.Length;

        //            for (int lCount = 0; lCount < iLen; lCount++)
        //            {
        //                sPre = sPre + "0";
        //            }
        //            sRegNo = dtType.Rows[0]["Prefix"].ToString().Trim() + sPre + sVNo + dtType.Rows[0]["Suffix"].ToString().Trim();
        //        }
        //    }
        //    return sRegNo;
        //}

        private void SetDefault()
        {

            m_lRegisterId = 0;
            dtpDate.Value = DateTime.Now.Date;
            txtRegNo.Text = "";
            txtVendorName.Text="";
            chkSupply.Checked = false;
            chkContract.Checked = false;
            chkService.Checked = false;
            dtpSFDate.Value = DateTime.Now.Date;
            dtpSTDate.Value = DateTime.Now.Date;
            dtpCFDate.Value = DateTime.Now.Date;
            dtpCTDate.Value = DateTime.Now.Date;
            dtpHFDate.Value = DateTime.Now.Date;
            dtpHTDate.Value = DateTime.Now.Date;
            chkSLife.Checked = false;
            chkCLife.Checked = false;
            chkHLife.Checked = false;
            txtSGradeName.Text="";
            txtCGradeName.Text = "";
            txtHGradeName.Text = "";
            txtSGradeName.Tag = 0;
            txtCGradeName.Tag = 0;
            txtHGradeName.Tag = 0;

            txtRemarks.Text = "";

            dtpSFDate.Enabled=false;
            dtpSTDate.Enabled = false;
            dtpCFDate.Enabled = false;
            dtpCTDate.Enabled = false;
            dtpHFDate.Enabled = false;
            dtpHTDate.Enabled = false;
            chkSLife.Enabled = false;
            chkCLife.Enabled = false;
            chkHLife.Enabled = false;
            cmdRemove.Visible = false;
 
            txtVendorName.Text = m_sVendorName;

            DataTable dtt;
            dtt = new DataTable();
            dtt = m_oRegister.GetGradeTrans(m_lVendorId);
            if (dtt.Rows.Count > 0)
            {
                txtSGradeName.Text = dtt.Rows[0]["SGrade"].ToString();
                txtSGradeName.Tag = dtt.Rows[0]["SGradeID"].ToString();

                txtCGradeName.Text = dtt.Rows[0]["CGrade"].ToString();
                txtCGradeName.Tag = dtt.Rows[0]["CGradeID"].ToString();

                txtHGradeName.Text = dtt.Rows[0]["HGrade"].ToString();
                txtHGradeName.Tag = dtt.Rows[0]["HGradeID"].ToString();
            }

        }

        private void UpdateRegNo()
        {
            oVType = new BsfGlobal.VoucherType();
            //oVType = BsfGlobal.GetVoucherNo(17, Convert.ToDateTime(dtpDate.Text), 0, 0);
            oVType = BsfGlobal.GetVoucherNo(17, Convert.ToDateTime(dtpDate.Value), 0, 0);
            if (oVType.GenType == true)
            {
                if (m_lRegisterId == 0)
                {
                    txtRegNo.Text = oVType.VoucherNo;
                }
                txtRegNo.Enabled = false;
            }

            else
            {
                txtRegNo.Enabled = true;
            }

            //dtType = new DataTable();
            //dtType = m_oType.GetTypeSetup(1);
            //if (dtType.Rows.Count > 0)
            //{
            //    if (Convert.ToBoolean(dtType.Rows[0]["GenType"].ToString()) == true)
            //    {
            //        txtRegNo.Enabled = false;
            //        if (m_lRegisterId == 0) { txtRegNo.Text = GetRegNo(); }
            //    }
            //    else { txtRegNo.Enabled = true; }
            //}
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkSupply_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupply.Checked == true)
            {
                dtpSFDate.Enabled = true;
                dtpSTDate.Enabled = true;
                chkSLife.Enabled = true;
                dtpSTDate.Value = dtpSFDate.Value.AddYears(1);
                GetGradeDetails();
            }
            else
            {
                dtpSFDate.Enabled = false;
                dtpSTDate.Enabled = false;
                chkSLife.Enabled = false;
            }
        }

        private void chkContract_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContract.Checked == true)
            {
                dtpCFDate.Enabled = true;
                dtpCTDate.Enabled = true;
                chkCLife.Enabled = true;
                dtpCTDate.Value = dtpCFDate.Value.AddYears(1);
                GetGradeDetails();
            }
            else
            {
                dtpCFDate.Enabled = false;
                dtpCTDate.Enabled = false;
                chkCLife.Enabled = false;
            }
        }

        private void chkService_CheckedChanged(object sender, EventArgs e)
        {
            if (chkService.Checked == true)
            {
                dtpHFDate.Enabled = true;
                dtpHTDate.Enabled = true;
                chkHLife.Enabled = true;
                dtpHTDate.Value = dtpHFDate.Value.AddYears(1);
                GetGradeDetails();
            }
            else
            {
                dtpHFDate.Enabled = false;
                dtpHTDate.Enabled = false;
                chkHLife.Enabled = false;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            bool bChange = false;
            if (Validation() == true)
            {
                if (m_lRegisterId == 0) { UpdateRegNo(); }
                else
                {
                    if (m_dOldDate != Convert.ToDateTime(dtpDate.Value))
                    {
                        if (oVType.PeriodWise == true)
                        {
                            if (BsfGlobal.CheckPeriodChange(m_dOldDate, Convert.ToDateTime(dtpDate.Value)))
                            {
                                oVType = new BsfGlobal.VoucherType();
                                oVType = BsfGlobal.GetVoucherNo(17, Convert.ToDateTime(dtpDate.Value), 0, 0);
                                txtRegNo.Text = oVType.VoucherNo;
                                bChange = true;
                            }
                        }
                    }
                }

                if (CheckRegNo() == true)
                {
                    m_oRegister.RegisterId = m_lRegisterId;
                    m_oRegister.RegDate = dtpDate.Value;
                    m_oRegister.RegNo = txtRegNo.Text;
                    m_oRegister.VendorId = m_lVendorId;

                    m_oRegister.Supply = chkSupply.Checked;
                    m_oRegister.SFDate = dtpSFDate.Value;
                    m_oRegister.STDate = dtpSTDate.Value;
                    m_oRegister.SLife = chkSLife.Checked;
                    m_oRegister.SGradeId = Convert.ToInt32(txtSGradeName.Tag);

                    m_oRegister.Contract = chkContract.Checked;
                    m_oRegister.CFDate = dtpCFDate.Value;
                    m_oRegister.CTDate = dtpCTDate.Value;
                    m_oRegister.CLife = chkCLife.Checked;
                    m_oRegister.CGradeId = Convert.ToInt32(txtCGradeName.Tag);


                    m_oRegister.Service = chkService.Checked;
                    m_oRegister.HFDate = dtpHFDate.Value;
                    m_oRegister.HTDate = dtpHTDate.Value;
                    m_oRegister.HLife = chkHLife.Checked;
                    m_oRegister.HGradeId = Convert.ToInt32(txtHGradeName.Tag);

                    m_oRegister.Remarks = txtRemarks.Text;

                    if (m_lRegisterId == 0) 
                    { 
                        m_oRegister.InsertRegistration(m_oRegister);
                        BsfGlobal.UpdateMaxNo(17, oVType, 0, 0);
                        BsfGlobal.InsertAlert("Vendor-Register", "" + txtVendorName.Text + " - Registered Successfully", 0, BsfGlobal.g_sVendorDBName);
                        PopulateData();
                        MessageBox.Show("Registered Successfully!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    { 
                        m_oRegister.UpdateRegistration(m_oRegister);
                        if (bChange == true)
                        {
                            BsfGlobal.UpdateMaxNo(17, oVType, 0, 0);
                        }
                        MessageBox.Show("Registration Updated Successfully!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    m_oRegUpdate.UpdateRegistration(m_lVendorId);
                    //this.Close();
                }
            }
        }

        private bool Validation()
        {
            bool valid = true;
            sb = new StringBuilder();

            if (txtRegNo.Text.Trim() == string.Empty)
            {
                valid = false;
                sb.Append(" * Reg No not Empty" + Environment.NewLine);
                errorProvider1.SetError(txtRegNo, "Reg No not Empty");
            }
            else
            {
                errorProvider1.SetError(txtRegNo, "");
            }

            if (chkSupply.Checked == false & chkContract.Checked == false & chkService.Checked == false)
            {
                valid = false;
                sb.Append(" * Type not Selected" + Environment.NewLine);
                errorProvider1.SetError(chkSupply, "Type not Selected");
            }
            else
            {
                errorProvider1.SetError(chkSupply, "");
            }
     
            return valid;
        }

        private bool CheckRegNo()
        {
            bool valid = true;
            sb = new StringBuilder();

            if (m_oRegister.CheckRegNo(m_lRegisterId, txtRegNo.Text) == true)
            {
                valid = false;
                sb.Append(" * Reg No already Exists" + Environment.NewLine);
                errorProvider1.SetError(txtRegNo, "Reg No already Exists");
            }
            else
            {
                errorProvider1.SetError(txtRegNo, "");
            }
            return valid;
        }

        private void frmRegistration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { SendKeys.Send("{tab}"); }
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { e.Handled = true; }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                m_oRegister.DeleteRegistration(m_lRegisterId);
                m_lRegisterId = 0;
                SetDefault();
            }
        }

        private void dtpDate_Validated(object sender, EventArgs e)
        {
            if (m_lRegisterId == 0)
            {
                if (oVType.PeriodWise == true)
                {
                    oVType = new BsfGlobal.VoucherType();
                    oVType = BsfGlobal.GetVoucherNo(17, Convert.ToDateTime(dtpDate.Value), 0, 0);
                    txtRegNo.Text = oVType.VoucherNo;
                }
            }
        }

        private void dtpSFDate_ValueChanged(object sender, EventArgs e)
        {
           
            if (dtpSFDate.Value > dtpSTDate.Value)
            {
                MessageBox.Show("Valid From Date is Greater than Valid Upto Date!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpSFDate.Value = dtpSTDate.Value;
                return;
            }
            //if (dtpSFDate.Value > DateTime.Now)
            //{
            //    MessageBox.Show("Enter Valid Date!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    dtpSFDate.Value = DateTime.Now;
            //    return;
            //}

        }

   


  

        private void chkSLife_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSLife.Checked == true)
            {
                dtpSFDate.Enabled = false;
                dtpSTDate.Enabled = false;
            }
            else
            {
                dtpSFDate.Enabled = true;
                dtpSTDate.Enabled = true;
            }

        }

        private void chkCLife_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCLife.Checked == true)
            {
                dtpCFDate.Enabled = false;
                dtpCTDate.Enabled = false;
            }
            else
            {
                dtpCFDate.Enabled = true;
                dtpCTDate.Enabled = true;
            }
        }

        private void chkHLife_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHLife.Checked == true)
            {
                dtpHFDate.Enabled = false;
                dtpHTDate.Enabled = false;
            }
            else
            {
                dtpHFDate.Enabled = true;
                dtpHTDate.Enabled = true;
            }
        }
  
      
    }

}

