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
    public partial class frmRegTrans : Form
    {
        #region Variables 

        int m_lRegTransId;
        int m_lVendorId;
        string m_sVendorName;
        string m_sRegNo;
        DataTable dtReg;
        //DataTable dtType;
        StringBuilder sb = null;
        DateTime m_dOldDate;
        BsfGlobal.VoucherType oVType;
        Vendor.BusinessLayer.RegisterBL m_oRegister;
        Vendor.BusinessLayer.RegUpdateBL m_oRegUpdate;
        bool m_bAns = false;

        #endregion

        #region Constructor

        public frmRegTrans()
        {
            InitializeComponent();
            m_oRegister = new Vendor.BusinessLayer.RegisterBL();
            m_oRegUpdate = new Vendor.BusinessLayer.RegUpdateBL();
            oVType = new BsfGlobal.VoucherType();
        }


        public void Execute(int argRegTransId, int argVendorId, string argVendorName,string argRegNo)
        {
            m_lRegTransId = argRegTransId;
            m_lVendorId = argVendorId;
            m_sVendorName = argVendorName;
            m_sRegNo = argRegNo;
            this.ShowDialog();

        }

        #endregion

        #region ButtonEvents

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            int iTypeId = 0;
            if (optStatusType.SelectedIndex == 0) { iTypeId = 18; }
            else if (optStatusType.SelectedIndex == 1) { iTypeId = 19; }
            else if (optStatusType.SelectedIndex == 2) { iTypeId = 20; }
            
            bool bChange = false;
            if (Validation() == true)
            {
                if (m_lRegTransId == 0) { UpdateRegNo(); }
                else
                {
                    if (m_dOldDate != Convert.ToDateTime(dtpDate.Text))
                    {
                        if (oVType.PeriodWise == true)
                        {
                            if (BsfGlobal.CheckPeriodChange(m_dOldDate, Convert.ToDateTime(dtpDate.Text)))
                            {
                                oVType = new BsfGlobal.VoucherType();
                                oVType = BsfGlobal.GetVoucherNo(iTypeId, Convert.ToDateTime(dtpDate.Text), 0, 0);
                                txtRefNo.Text = oVType.VoucherNo;
                                bChange = true;
                            }
                        }
                    }
                }

                
                    m_oRegister.RegTransId = m_lRegTransId;
                    m_oRegister.RegisterId = Convert.ToInt32(cboReg.EditValue);
                    m_oRegister.RegDate = Convert.ToDateTime(dtpDate.EditValue);
                    m_oRegister.RegNo = txtRefNo.Text;
                    m_oRegister.VendorId = Convert.ToInt32(txtVendorName.Tag);
                    if (optStatusType.SelectedIndex == 0) { m_oRegister.StatusType = "R"; }
                    else if (optStatusType.SelectedIndex == 1) { m_oRegister.StatusType = "S"; }
                    else if (optStatusType.SelectedIndex == 2) { m_oRegister.StatusType = "B"; }

                    m_oRegister.Supply = chkSupply.Checked;
                    m_oRegister.SFDate = Convert.ToDateTime(dtpSFDate.EditValue);
                    m_oRegister.STDate = Convert.ToDateTime(dtpSTDate.EditValue);
                    m_oRegister.SLife = chkSLife.Checked;
                    m_oRegister.SGradeId = Convert.ToInt32(txtSGradeName.Tag);

                    m_oRegister.Contract = chkContract.Checked;
                    m_oRegister.CFDate = Convert.ToDateTime(dtpCFDate.EditValue);
                    m_oRegister.CTDate = Convert.ToDateTime(dtpCTDate.EditValue);
                    m_oRegister.CLife = chkCLife.Checked;
                    m_oRegister.CGradeId = Convert.ToInt32(txtCGradeName.Tag);


                    m_oRegister.Service = chkService.Checked;
                    m_oRegister.HFDate = Convert.ToDateTime(dtpHFDate.EditValue);
                    m_oRegister.HTDate = Convert.ToDateTime(dtpHTDate.EditValue);
                    m_oRegister.HLife = chkHLife.Checked;
                    m_oRegister.HGradeId = Convert.ToInt32(txtHGradeName.Tag);

                    m_oRegister.Remarks = txtRemarks.Text;


                    if (m_lRegTransId == 0) 
                    {
                        m_oRegister.InsertRegTrans(m_oRegister,iTypeId);
                        BsfGlobal.UpdateMaxNo(iTypeId, oVType, 0, 0);
                        if (optStatusType.SelectedIndex == 0) 
                        {
                            BsfGlobal.InsertAlert("Vendor-Renewal", "" + cboReg.Text + " - Renewed Successfully", 0, BsfGlobal.g_sVendorDBName);

                        }
                        else if (optStatusType.SelectedIndex == 1) 
                        {
                            BsfGlobal.InsertAlert("Vendor-BlackList", "" + cboReg.Text + " - Blocked", 0, BsfGlobal.g_sVendorDBName);
                        }
                        else if (optStatusType.SelectedIndex == 2) 
                        {
                            BsfGlobal.InsertAlert("Vendor-Suspend", "" + cboReg.Text + " - Suspended", 0, BsfGlobal.g_sVendorDBName);

                        }
                    }
                    else 
                    { 
                        m_oRegister.UpdateRegTrans(m_oRegister);
                        if (bChange == true)
                        {
                            BsfGlobal.UpdateMaxNo(iTypeId, oVType, 0, 0);
                        }
                    }
                    m_oRegUpdate.UpdateRegistration(Convert.ToInt32(txtVendorName.Tag));
                    this.Close();
            }
        }

        private void optRenewal_CheckedChanged(object sender, EventArgs e)
        {
            //if (optRenewal.Checked == true)
            //{
            //    chkSupply.Visible = true;
            //    chkContract.Visible = true;
            //    chkService.Visible = true;

            //    lblFrom.Visible = true;
            //    lblUpto.Visible = true;
            //    lblLife.Visible = true;
            //    lblGrade.Visible = true;

            //    dtpSFDate.Visible = true;
            //    dtpCFDate.Visible = true;
            //    dtpHFDate.Visible = true;

            //    dtpSTDate.Visible = true;
            //    dtpCTDate.Visible = true;
            //    dtpHTDate.Visible = true;

            //    chkSLife.Visible = true;
            //    chkCLife.Visible = true;
            //    chkHLife.Visible = true;

            //    txtSGradeName.Visible = true;
            //    txtCGradeName.Visible = true;
            //    txtHGradeName.Visible = true;
            //    SetDefault();
            //}
        }

        private void optSuspend_CheckedChanged(object sender, EventArgs e)
        {
            //if (optSuspend.Checked == true)
            //{

            //    chkSupply.Visible = true;
            //    chkContract.Visible = true;
            //    chkService.Visible = true;

            //    lblFrom.Visible = true;
            //    lblUpto.Visible = true;
            //    lblLife.Visible = false;
            //    lblGrade.Visible = false;

            //    dtpSFDate.Visible = true;
            //    dtpCFDate.Visible = true;
            //    dtpHFDate.Visible = true;

            //    dtpSTDate.Visible = true;
            //    dtpCTDate.Visible = true;
            //    dtpHTDate.Visible = true;

            //    chkSLife.Visible = false;
            //    chkCLife.Visible = false;
            //    chkHLife.Visible = false;

            //    txtSGradeName.Visible = false;
            //    txtCGradeName.Visible = false;
            //    txtHGradeName.Visible = false;
            //    SetDefault();
            //}
        }

        private void optBlock_CheckedChanged(object sender, EventArgs e)
        {

            //chkSupply.Visible = true;
            //chkContract.Visible = true;
            //chkService.Visible = true;

            //lblFrom.Visible = false;
            //lblUpto.Visible = false;
            //lblLife.Visible = false;
            //lblGrade.Visible = false;

            //dtpSFDate.Visible = false;
            //dtpCFDate.Visible = false;
            //dtpHFDate.Visible = false;

            //dtpSTDate.Visible = false;
            //dtpCTDate.Visible = false;
            //dtpHTDate.Visible = false;

            //chkSLife.Visible = false;
            //chkCLife.Visible = false;
            //chkHLife.Visible = false;

            //txtSGradeName.Visible = false;
            //txtCGradeName.Visible = false;
            //txtHGradeName.Visible = false;
            //SetDefault();
        }

        private void cboReg_KeyUp(object sender, KeyEventArgs e)
        {
            if (dtReg.Rows.Count <= 0)
                return;
            //clsStatic.AutoComplete(cboReg, e);
        }

        private void cboReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboReg.EditValue) >= 0 & m_bAns == true)
            {
                DataRowView dv = cboReg.Properties.GetDataSourceRowByKeyValue(cboReg.EditValue) as DataRowView;
                //txtVendorName.Text = ((System.Data.DataRowView)(cboReg.SelectedItem)).Row["VendorName"].ToString();
                //txtVendorName.Tag = ((System.Data.DataRowView)(cboReg.SelectedItem)).Row["VendorId"].ToString();
                txtVendorName.Text = dv["RegNo"].ToString();
                txtVendorName.Tag = dv["VendorId"].ToString();
                if (optStatusType.SelectedIndex == 0) { CheckRegistration(); }
                else if (optStatusType.SelectedIndex == 1) { CheckSuspendRegistration(); }
                else if (optStatusType.SelectedIndex == 2) { CheckBlackListRegistration(); }


                DataTable dtt;
                dtt = new DataTable();
                dtt = m_oRegister.GetGradeTrans(Convert.ToInt32(txtVendorName.Tag));
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
        }

        private void chkSupply_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupply.Checked == true)
            {
                dtpSFDate.Enabled = true;
                dtpSTDate.Enabled = true;
                chkSLife.Enabled = true;
                dtpSTDate.EditValue = dtpSFDate.EditValue;

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
                DateTime dtCFDate = Convert.ToDateTime(dtpCFDate.EditValue);
                dtpCFDate.Enabled = true;
                dtpCTDate.Enabled = true;
                chkCLife.Enabled = true;
                //dtpCTDate.EditValue = dtpCFDate.EditValue.AddYears(1);
                dtpCTDate.EditValue = dtCFDate.AddYears(1);

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
                DateTime dtHFDate = Convert.ToDateTime(dtpHFDate.EditValue);
                dtpHFDate.Enabled = true;
                dtpHTDate.Enabled = true;
                chkHLife.Enabled = true;
                //dtpHTDate.EditValue = dtpHFDate.EditValue.AddYears(1);
                dtpHTDate.EditValue = dtHFDate.AddYears(1);
            }
            else
            {
                dtpHFDate.Enabled = false;
                dtpHTDate.Enabled = false;
                chkHLife.Enabled = false;
            }
        }

        private void dtpSFDate_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dtpSTDate.EditValue), Convert.ToDateTime(dtpSFDate.EditValue)) < 0)
            {
                MessageBox.Show("Invalid Date");
                dtpSFDate.EditValue = dtpSTDate.EditValue;
                if (dtpSFDate.Enabled == true) { dtpSFDate.Focus(); }
            }
        }

        private void dtpSTDate_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dtpSTDate.EditValue), Convert.ToDateTime(dtpSFDate.EditValue)) < 0)
            {
                MessageBox.Show("Invalid Date");
                dtpSTDate.EditValue = dtpSFDate.EditValue;
                if (dtpSTDate.Enabled == true) { dtpSTDate.Focus(); }
            }
        }

        private void dtpCFDate_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dtpCTDate.EditValue), Convert.ToDateTime(dtpCFDate.EditValue)) < 0)
            {
                MessageBox.Show("Invalid Date");
                dtpCFDate.EditValue = dtpCTDate.EditValue;
                if (dtpCFDate.Enabled == true) { dtpCFDate.Focus(); }
            }

        }

        private void dtpHFDate_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dtpHTDate.EditValue), Convert.ToDateTime(dtpHFDate.EditValue)) < 0)
            {
                MessageBox.Show("Invalid Date");
                dtpHFDate.EditValue = dtpHTDate.EditValue;
                if (dtpHFDate.Enabled == true) { dtpHFDate.Focus(); }
            }

        }

        private void dtpCTDate_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dtpCTDate.EditValue), Convert.ToDateTime(dtpCFDate.EditValue)) < 0)
            {
                MessageBox.Show("Invalid Date");
                dtpCTDate.EditValue = dtpCFDate.EditValue;
                if (dtpCTDate.Enabled == true) { dtpCTDate.Focus(); }
            }
        }

        private void dtpHTDate_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dtpHTDate.EditValue), Convert.ToDateTime(dtpHFDate.EditValue)) < 0)
            {
                MessageBox.Show("Invalid Date");
                dtpHTDate.EditValue = dtpHFDate.EditValue;
                if (dtpHTDate.Enabled == true) { dtpHTDate.Focus(); }
            }
        }

        private void optStatusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optStatusType.SelectedIndex == 0)
            {
                chkSupply.Visible = true;
                chkContract.Visible = true;
                chkService.Visible = true;

                lblFrom.Visible = true;
                lblUpto.Visible = true;
                lblLife.Visible = true;
                lblGrade.Visible = true;

                dtpSFDate.Visible = true;
                dtpCFDate.Visible = true;
                dtpHFDate.Visible = true;

                dtpSTDate.Visible = true;
                dtpCTDate.Visible = true;
                dtpHTDate.Visible = true;

                chkSLife.Visible = true;
                chkCLife.Visible = true;
                chkHLife.Visible = true;

                txtSGradeName.Visible = true;
                txtCGradeName.Visible = true;
                txtHGradeName.Visible = true;
                SetDefault();
            }
            else if (optStatusType.SelectedIndex == 1)
            {
                chkSupply.Visible = true;
                chkContract.Visible = true;
                chkService.Visible = true;

                lblFrom.Visible = true;
                lblUpto.Visible = true;
                lblLife.Visible = false;
                lblGrade.Visible = false;

                dtpSFDate.Visible = true;
                dtpCFDate.Visible = true;
                dtpHFDate.Visible = true;

                dtpSTDate.Visible = true;
                dtpCTDate.Visible = true;
                dtpHTDate.Visible = true;

                chkSLife.Visible = false;
                chkCLife.Visible = false;
                chkHLife.Visible = false;

                txtSGradeName.Visible = false;
                txtCGradeName.Visible = false;
                txtHGradeName.Visible = false;
                SetDefault();
            }
            else if (optStatusType.SelectedIndex == 2)
            {
                chkSupply.Visible = true;
                chkContract.Visible = true;
                chkService.Visible = true;

                lblFrom.Visible = false;
                lblUpto.Visible = false;
                lblLife.Visible = false;
                lblGrade.Visible = false;

                dtpSFDate.Visible = false;
                dtpCFDate.Visible = false;
                dtpHFDate.Visible = false;

                dtpSTDate.Visible = false;
                dtpCTDate.Visible = false;
                dtpHTDate.Visible = false;

                chkSLife.Visible = false;
                chkCLife.Visible = false;
                chkHLife.Visible = false;

                txtSGradeName.Visible = false;
                txtCGradeName.Visible = false;
                txtHGradeName.Visible = false;
                SetDefault();
            }
        }

        private void barExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void dtpDate_Validated(object sender, EventArgs e)
        {
            if (m_lRegTransId == 0)
            {
                int iTypeId = 0;
                if (optStatusType.SelectedIndex == 0) { iTypeId = 18; }
                else if (optStatusType.SelectedIndex == 1) { iTypeId = 19; }
                else if (optStatusType.SelectedIndex == 2) { iTypeId = 20; }
                if (oVType.PeriodWise == true)
                {
                    oVType = new BsfGlobal.VoucherType();
                    oVType = BsfGlobal.GetVoucherNo(iTypeId, Convert.ToDateTime(dtpDate.Text), 0, 0);
                    txtRefNo.Text = oVType.VoucherNo;
                }
            }
        }
        #endregion

        #region FormEvents

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmRegTrans_Load(object sender, EventArgs e)
        {
            PopulateReg();
            //optRenewal.Checked = true;
            optStatusType.SelectedIndex = 0;
            optStatusType_SelectedIndexChanged(sender,e);
            PopulateData();
        }

        #endregion

        #region Functions

        private void PopulateReg()
        {
            m_bAns = false;
            dtReg = new DataTable();
            dtReg = m_oRegister.GetRegNo();

            cboReg.Properties.DataSource = dtReg;
            cboReg.Properties.ForceInitialize();
            cboReg.Properties.PopulateColumns();
            cboReg.Properties.DisplayMember = "VendorName";
            cboReg.Properties.ValueMember = "RegisterId";
            cboReg.Properties.ShowHeader = false;
            cboReg.Properties.ShowFooter = false;
            cboReg.Properties.Columns["RegisterId"].Visible = false;
            cboReg.Properties.Columns["RegNo"].Visible = false;
            cboReg.Properties.Columns["VendorId"].Visible = false;
            cboReg.ItemIndex = -1;
            m_bAns = true;
            //if (cboReg.Items.Count > 0) { cboReg.SelectedIndex = 0; }
        }

        private void SetDefault()
        {
            dtpDate.EditValue = DateTime.Now.Date;
            txtVendorName.Text = "";
            chkSupply.Checked = false;
            chkContract.Checked = false;
            chkService.Checked = false;
            if (DateTime.Compare(dtpSFDate.Properties.MinValue, DateTime.Now.Date) < 0) { dtpSFDate.EditValue = DateTime.Now.Date; }
            dtpSTDate.EditValue = DateTime.Now.Date;

            if (DateTime.Compare(dtpCFDate.Properties.MinValue, DateTime.Now.Date) < 0) { dtpCFDate.EditValue = DateTime.Now.Date; }
            //dtpCFDate.Value = DateTime.Now.Date;
            dtpCTDate.EditValue = DateTime.Now.Date;
            if (DateTime.Compare(dtpHFDate.Properties.MinValue, DateTime.Now.Date) < 0) { dtpHFDate.EditValue = DateTime.Now.Date; }
            //dtpHFDate.Value = DateTime.Now.Date;
            dtpHTDate.EditValue = DateTime.Now.Date;
            chkSLife.Checked = false;
            chkCLife.Checked = false;
            chkHLife.Checked = false;
            txtSGradeName.Text = "";
            txtCGradeName.Text = "";
            txtHGradeName.Text = "";
            txtSGradeName.Tag = 0;
            txtCGradeName.Tag = 0;
            txtHGradeName.Tag = 0;

            txtRemarks.Text = "";

            dtpSFDate.Enabled = false;
            dtpSTDate.Enabled = false;
            dtpCFDate.Enabled = false;
            dtpCTDate.Enabled = false;
            dtpHFDate.Enabled = false;
            dtpHTDate.Enabled = false;
            chkSLife.Enabled = false;
            chkCLife.Enabled = false;
            chkHLife.Enabled = false;


            DataTable dtt;
            dtt = new DataTable();
            dtt = m_oRegister.GetGradeTrans(Convert.ToInt32(txtVendorName.Tag));
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

        private void PopulateData()
        {

            

            DataTable dt;
            dt = new DataTable();

            dt = m_oRegister.GetRegTrans(m_lVendorId);


            DataView dv = new DataView(dt);
            dv.RowFilter = "RegTransId = " + m_lRegTransId;
            DataTable dtt = new DataTable();
            dtt = dv.ToTable();
            if (dtt.Rows.Count > 0)
            {
                int lRegId = Convert.ToInt32(dtt.Rows[0]["RegId"].ToString());

                if (lRegId != 0)
                {
                    for (int lCount = 0; lCount < dtReg.Rows.Count; lCount++)
                    {
                        cboReg.ItemIndex = lCount;
                        if (Convert.ToInt32(cboReg.EditValue) == lRegId) { break; }
                    }
                }
                cboReg.Enabled = false;
                txtRefNo.Text = dtt.Rows[0]["RefNo"].ToString();

                dtpDate.EditValue = Convert.ToDateTime(dtt.Rows[0]["RDate"].ToString());
                m_dOldDate = Convert.ToDateTime(dtt.Rows[0]["RDate"].ToString());
                if (dtt.Rows[0]["StatusType"].ToString() == "R") { optStatusType.SelectedIndex = 0; }
                else if (dtt.Rows[0]["StatusType"].ToString() == "S") { optStatusType.SelectedIndex = 1; }
                else if (dtt.Rows[0]["StatusType"].ToString() == "B") { optStatusType.SelectedIndex = 2; }
                grdpStatusType.Enabled = false;

                if (Convert.ToBoolean(dtt.Rows[0]["Supply"].ToString()) == true)
                {
                    chkSupply.Checked = true;
                    dtpSFDate.EditValue = Convert.ToDateTime(dtt.Rows[0]["SFDate"].ToString());
                    dtpSTDate.EditValue = Convert.ToDateTime(dtt.Rows[0]["STDate"].ToString());
                    if (Convert.ToBoolean(dtt.Rows[0]["SLifeTime"].ToString()) == true) { chkSLife.Checked = true; }
                    txtSGradeName.Text = dtt.Rows[0]["SGrade"].ToString();
                    txtSGradeName.Tag = dtt.Rows[0]["SGradeID"].ToString();

                }

                if (Convert.ToBoolean(dtt.Rows[0]["Contract"].ToString()) == true)
                {
                    chkContract.Checked = true;
                    dtpCFDate.EditValue = Convert.ToDateTime(dtt.Rows[0]["CFDate"].ToString());
                    dtpCTDate.EditValue = Convert.ToDateTime(dtt.Rows[0]["CTDate"].ToString());
                    if (Convert.ToBoolean(dtt.Rows[0]["CLifeTime"].ToString()) == true) { chkCLife.Checked = true; }
                    txtCGradeName.Text = dtt.Rows[0]["CGrade"].ToString();
                    txtCGradeName.Tag = dtt.Rows[0]["CGradeID"].ToString();
                }

                if (Convert.ToBoolean(dtt.Rows[0]["Service"].ToString()) == true)
                {
                    chkService.Checked = true;
                    dtpHFDate.EditValue = Convert.ToDateTime(dtt.Rows[0]["HFDate"].ToString());
                    dtpHTDate.EditValue = Convert.ToDateTime(dtt.Rows[0]["HTDate"].ToString());
                    if (Convert.ToBoolean(dtt.Rows[0]["HLifeTime"].ToString()) == true) { chkHLife.Checked = true; }
                    txtHGradeName.Text = dtt.Rows[0]["HGrade"].ToString();
                    txtHGradeName.Tag = dtt.Rows[0]["HGradeID"].ToString();
                }
                txtRemarks.Text = dtt.Rows[0]["Remarks"].ToString();
            }

            if (m_lRegTransId != 0)
            {
                if (m_lRegTransId != m_oRegister.GetMaxRegTransId(m_lVendorId)) { cmdOK.Enabled = false; }
                else { cmdOK.Enabled = true; }
            }


            UpdateRegNo();
            txtVendorName.Text = m_sRegNo;
            txtVendorName.Tag = m_lVendorId;
            txtVendorName.Enabled = false;
        }

        private void UpdateRegNo()
        {

            int iTypeId = 0;
            if (optStatusType.SelectedIndex == 0) { iTypeId = 18; }
            else if (optStatusType.SelectedIndex == 1) { iTypeId = 19; }
            else if (optStatusType.SelectedIndex == 2) { iTypeId = 20; }

            oVType = new BsfGlobal.VoucherType();
            oVType = BsfGlobal.GetVoucherNo(iTypeId, Convert.ToDateTime(dtpDate.Text), 0, 0);
            if (oVType.GenType == true)
            {
                if (m_lRegTransId == 0)
                {
                    txtRefNo.Text = oVType.VoucherNo;
                }
                txtRefNo.Enabled = false;
            }

            else
            {
                txtRefNo.Enabled = true;
            }

        }

        public void CheckRegistration()
        {

            chkSupply.Enabled = true;
            chkContract.Enabled = true;
            chkService.Enabled = true;


            DataTable dt = new DataTable();
            DataTable dtt;
            DataView dv;
            bool bSCheck;
            bool bCCheck;
            bool bHCheck;


            bool bRSCheck;
            bool bRCCheck;
            bool bRHCheck;


            int lCount = 0;
            dt = m_oRegister.GetRegTrans(Convert.ToInt32(txtVendorName.Tag));
            dv = new DataView(dt);
            if (m_lRegTransId != 0) { dv.RowFilter = "StatusType = 'B' and RegTransID < " + m_lRegTransId; }
            else { dv.RowFilter = "StatusType = 'B'"; }

            dtt = new DataTable();
            dtt = dv.ToTable();

            for (lCount = 0; lCount < dtt.Rows.Count; lCount++)
            {
                if (Convert.ToBoolean(dtt.Rows[lCount]["Supply"].ToString()) == true)
                {
                    chkSupply.Checked = false;
                    chkSupply.Enabled = false;
                }

                if (Convert.ToBoolean(dtt.Rows[lCount]["Contract"].ToString()) == true)
                {
                    chkContract.Checked = false;
                    chkContract.Enabled = false;
                }

                if (Convert.ToBoolean(dtt.Rows[lCount]["Service"].ToString()) == true)
                {
                    chkService.Checked = false;
                    chkService.Enabled = false;
                }

            }
            dv = new DataView(dt);
            if (m_lRegTransId != 0) { dv.RowFilter = "StatusType = 'S' and RegTransID < " + m_lRegTransId; }
            else { dv.RowFilter = "StatusType = 'S'"; }
            dtt = new DataTable();
            dtt = dv.ToTable();
            bSCheck = false;
            bCCheck = false;
            bHCheck = false;
            for (lCount = 0; lCount < dtt.Rows.Count; lCount++)
            {
                if (Convert.ToBoolean(dtt.Rows[lCount]["Supply"].ToString()) == true & bSCheck == false)
                {
                    dtpSFDate.Properties.MinValue = Convert.ToDateTime(dtt.Rows[lCount]["STDate"].ToString()).AddDays(1);
                    bSCheck = true;
                }

                if (Convert.ToBoolean(dtt.Rows[lCount]["Contract"].ToString()) == true & bCCheck == false)
                {
                    dtpCFDate.Properties.MinValue = Convert.ToDateTime(dtt.Rows[lCount]["CTDate"].ToString()).AddDays(1);
                    bCCheck = true;
                }

                if (Convert.ToBoolean(dtt.Rows[lCount]["Service"].ToString()) == true & bHCheck == false)
                {
                    dtpHFDate.Properties.MinValue = Convert.ToDateTime(dtt.Rows[lCount]["HTDate"].ToString()).AddDays(1);
                    bHCheck = true;
                }
            }

            dv = new DataView(dt);
            if (m_lRegTransId != 0) { dv.RowFilter = "StatusType = 'R' and RegTransID < " + m_lRegTransId; }
            else { dv.RowFilter = "StatusType = 'R'"; }
            dtt = new DataTable();
            dtt = dv.ToTable();
            bRSCheck = false;
            bRCCheck = false;
            bRHCheck = false;
            for (lCount = 0; lCount < dtt.Rows.Count; lCount++)
            {
                if (Convert.ToBoolean(dtt.Rows[lCount]["Supply"].ToString()) == true & bRSCheck == false)
                {
                    if (dtpSFDate.Properties.MinValue < Convert.ToDateTime(dtt.Rows[lCount]["STDate"].ToString()).AddDays(1))
                    {
                        dtpSFDate.Properties.MinValue = Convert.ToDateTime(dtt.Rows[lCount]["STDate"].ToString()).AddDays(1);
                        bRSCheck = true;
                    }
                }

                if (Convert.ToBoolean(dtt.Rows[lCount]["Contract"].ToString()) == true & bRCCheck == false)
                {
                    if (dtpCFDate.Properties.MinValue < Convert.ToDateTime(dtt.Rows[lCount]["CTDate"].ToString()).AddDays(1))
                    {
                        dtpCFDate.Properties.MinValue = Convert.ToDateTime(dtt.Rows[lCount]["CTDate"].ToString()).AddDays(1);
                        bRCCheck = true;
                    }
                }

                if (Convert.ToBoolean(dtt.Rows[lCount]["Service"].ToString()) == true & bRHCheck == false)
                {
                    if (dtpHFDate.Properties.MinValue < Convert.ToDateTime(dtt.Rows[lCount]["HTDate"].ToString()).AddDays(1))
                    {
                        dtpHFDate.Properties.MinValue = Convert.ToDateTime(dtt.Rows[lCount]["HTDate"].ToString()).AddDays(1);
                        bRHCheck = true;
                    }
                }
            }

            if ((bSCheck == false & bRSCheck == false) | (bCCheck == false & bRCCheck == false) | (bHCheck == false & bRHCheck == false))
            {
                DataTable dtM = new DataTable();
                dtM = m_oRegister.GetRegistration(Convert.ToInt32(txtVendorName.Tag));
                if (dtM.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtM.Rows[0]["Supply"].ToString()) == true)
                    {
                        if (bSCheck == false & bRSCheck == false)
                        {
                            dtpSFDate.Properties.MinValue = Convert.ToDateTime(dtM.Rows[0]["STDate"].ToString()).AddDays(1);
                        }
                    }

                    if (Convert.ToBoolean(dtM.Rows[0]["Contract"].ToString()) == true)
                    {
                        if (bCCheck == false & bRCCheck == false)
                        {
                            dtpCFDate.Properties.MinValue = Convert.ToDateTime(dtM.Rows[0]["CTDate"].ToString()).AddDays(1);
                        }
                    }

                    if (Convert.ToBoolean(dtM.Rows[0]["Service"].ToString()) == true)
                    {
                        if (bHCheck == false & bRHCheck == false)
                        {
                            dtpHFDate.Properties.MinValue = Convert.ToDateTime(dtM.Rows[0]["HTDate"].ToString()).AddDays(1);
                        }
                    }
                }
            }
        }

        public void CheckBlackListRegistration()
        {
            chkSupply.Enabled = false;
            chkContract.Enabled = false;
            chkService.Enabled = false;

            DataTable dt = new DataTable();
            DataTable dtt;
            DataView dv;

            int lCount = 0;
            dt = m_oRegister.GetRegTrans(Convert.ToInt32(txtVendorName.Tag));
            dv = new DataView(dt);

            dv = new DataView(dt);
            if (m_lRegTransId != 0)
            {
                dv.RowFilter = "StatusType = 'R' and RegTransID = " + m_lRegTransId;
                dtt = new DataTable();
                dtt = dv.ToTable();
                for (lCount = 0; lCount < dtt.Rows.Count; lCount++)
                {
                    if (Convert.ToBoolean(dtt.Rows[lCount]["Supply"].ToString()) == true) { chkSupply.Enabled = true; }
                    if (Convert.ToBoolean(dtt.Rows[lCount]["Contract"].ToString()) == true) { chkContract.Enabled = true; }
                    if (Convert.ToBoolean(dtt.Rows[lCount]["Service"].ToString()) == true) { chkService.Enabled = true; }
                }
            }


            dv = new DataView(dt);
            if (m_lRegTransId != 0) { dv.RowFilter = "StatusType = 'R' and RegTransID < " + m_lRegTransId; }
            else { dv.RowFilter = "StatusType = 'R'"; }

            dtt = new DataTable();
            dtt = dv.ToTable();
            for (lCount = 0; lCount < dtt.Rows.Count; lCount++)
            {
                if (Convert.ToBoolean(dtt.Rows[lCount]["Supply"].ToString()) == true) { chkSupply.Enabled = true; }
                if (Convert.ToBoolean(dtt.Rows[lCount]["Contract"].ToString()) == true) { chkContract.Enabled = true; }
                if (Convert.ToBoolean(dtt.Rows[lCount]["Service"].ToString()) == true) { chkService.Enabled = true; }
            }

            DataTable dtM = new DataTable();
            dtM = m_oRegister.GetRegistration(Convert.ToInt32(txtVendorName.Tag));
            if (dtM.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtM.Rows[0]["Supply"].ToString()) == true) { chkSupply.Enabled = true; }
                if (Convert.ToBoolean(dtM.Rows[0]["Contract"].ToString()) == true) { chkContract.Enabled = true; }
                if (Convert.ToBoolean(dtM.Rows[0]["Service"].ToString()) == true) { chkService.Enabled = true; }
            }
        }

        public void CheckSuspendRegistration()
        {
            chkSupply.Enabled = false;
            chkContract.Enabled = false;
            chkService.Enabled = false;

            DataTable dt = new DataTable();
            DataTable dtt;
            DataView dv;

            int lCount = 0;
            dt = m_oRegister.GetRegTrans(Convert.ToInt32(txtVendorName.Tag));
            dv = new DataView(dt);

            dv = new DataView(dt);
            if (m_lRegTransId != 0)
            {
                dv.RowFilter = "StatusType = 'S' and RegTransID = " + m_lRegTransId;
                dtt = new DataTable();
                dtt = dv.ToTable();
                for (lCount = 0; lCount < dtt.Rows.Count; lCount++)
                {
                    if (Convert.ToBoolean(dtt.Rows[lCount]["Supply"].ToString()) == true) { chkSupply.Enabled = true; }
                    if (Convert.ToBoolean(dtt.Rows[lCount]["Contract"].ToString()) == true) { chkContract.Enabled = true; }
                    if (Convert.ToBoolean(dtt.Rows[lCount]["Service"].ToString()) == true) { chkService.Enabled = true; }
                }
            }


            dv = new DataView(dt);
            if (m_lRegTransId != 0) { dv.RowFilter = "StatusType = 'S' and RegTransID < " + m_lRegTransId; }
            else { dv.RowFilter = "StatusType = 'S'"; }

            dtt = new DataTable();
            dtt = dv.ToTable();
            for (lCount = 0; lCount < dtt.Rows.Count; lCount++)
            {
                if (Convert.ToBoolean(dtt.Rows[lCount]["Supply"].ToString()) == true) { chkSupply.Enabled = true; }
                if (Convert.ToBoolean(dtt.Rows[lCount]["Contract"].ToString()) == true) { chkContract.Enabled = true; }
                if (Convert.ToBoolean(dtt.Rows[lCount]["Service"].ToString()) == true) { chkService.Enabled = true; }
            }

            DataTable dtM = new DataTable();
            dtM = m_oRegister.GetRegistration(Convert.ToInt32(txtVendorName.Tag));
            if (dtM.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtM.Rows[0]["Supply"].ToString()) == true) { chkSupply.Enabled = true; }
                if (Convert.ToBoolean(dtM.Rows[0]["Contract"].ToString()) == true) { chkContract.Enabled = true; }
                if (Convert.ToBoolean(dtM.Rows[0]["Service"].ToString()) == true) { chkService.Enabled = true; }
            }
        }

        private bool Validation()
        {
            bool valid = true;
            sb = new StringBuilder();

            if (txtRefNo.Text == "")
            {
                valid = false;
                sb.Append(" * Enter Ref No" + Environment.NewLine);
                errorProvider1.SetError(txtRefNo, "Enter Ref No");
            }
            else
            {
                errorProvider1.SetError(txtRefNo, "");
            }



            if (cboReg.ItemIndex < 0)
            {
                valid = false;
                sb.Append(" * Select Registration No" + Environment.NewLine);
                errorProvider1.SetError(cboReg, "Select Registration No");
            }
            else
            {
                errorProvider1.SetError(cboReg, "");
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

        #endregion

    }
}
