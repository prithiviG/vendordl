using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.ReportSource;
using System.Collections;
using DevExpress.XtraEditors;
using Telerik.WinControls.UI;
using Telerik.Collections;
using DevExpress.XtraGrid.Repository;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Persistent;
using DevExpress.XtraGrid.Views.Grid.Customization;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using System.Reflection;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using System.Management;
using System.Text.RegularExpressions;
using DevExpress.XtraTreeList.Nodes;
using Vendor.BusinessLayer;
using DevExpress.Data;

namespace Vendor
{
    public partial class frmMain : Form
    {
        #region Variables

        public int m_lVendorId = 0;
        DataTable m_tCity;
        DataTable m_tVendorMasterInfo;
        DataTable m_tVendorContactInfo;
        DataTable m_tVendorStatutoryInfo;
        DataTable m_tVendorBranch;
        DataTable m_tTurnOver;
        DataTable m_tTurnOverSub;
        DataTable m_tExperience;
        DataTable m_tWorkGroup;
        DataTable m_tTechPersons;
        DataTable m_tTechPersonSub;
        DataTable m_tTerms;
        DataTable m_tService;
        DataTable m_tManPower;
        DataTable m_tManPowerSub;
        DataTable m_tMachinery;
        DataTable m_tMachinerySub;
        DataTable m_tLocation;
        DataTable m_tVWorkGroup;
        DataTable m_tVService;
        DataTable m_tCertificate;
        DataTable m_tCertificateTrans;
        DataTable m_tActivity;
        DataTable m_tActivtyTrans;
        DataTable m_tHireMachinery;
        DataTable m_tHireMachineryTrans;
        DataTable m_tMaterialGroup;
        DataTable m_tMaterialGroupTrans;
        DataTable m_tMaterialTrans;
        DataTable m_tLogistics;
        DataTable m_tTransportMode;
        DataTable m_tHistory;
        DataTable m_tCheckList;
        DataTable m_tGrade;
        DataSet m_dsMaterial;
        DataTable m_tSupplyGrade;
        DataTable m_tContractGrade;
        DataTable m_tServiceGrade;
        DataTable dtMaterial;
        DataTable dtEnclosure;
        DataTable dtSType;
        DataTable m_tTransport;
        DataTable dtTransport;
        //bool m_bWorkFlow;
        TextBox txtASup;     
        bool m_bFilter = false;
        bool m_bMaterialCheck = false;
        ArrayList m_aLocation = new ArrayList();
        ArrayList m_aTransport = new ArrayList();
       bool m_bAns = false;
        //public static bool m_bInsertMode = false;
        //public static bool m_bEditMode = false;
        StringBuilder sb = null;     
        bool _skipCheckEvents;
        int m_lMaterialId = 0;
        public string m_sVendorName = "";
        int m_lMaterialLevel = 0;
        public DevExpress.XtraEditors.PanelControl panelMain { get; set; }
        Vendor.BusinessLayer.VendorBL m_oVendor;
        Vendor.BusinessLayer.CityBL m_oCity;
        Vendor.BusinessLayer.ContactBL m_oContact;
        Vendor.BusinessLayer.StatutoryBL m_oStatutory;
        Vendor.BusinessLayer.BranchBL m_oBranch;
        Vendor.BusinessLayer.ExperienceBL m_oExperience;
        Vendor.BusinessLayer.CapabilityBL m_oCapability;
        Vendor.BusinessLayer.TermsBL m_oTerms;
        Vendor.BusinessLayer.CertificateBL m_oCer;
        Vendor.BusinessLayer.SupplyBL m_oSupply;
        Vendor.BusinessLayer.LogisticsBL m_oLogistics;
        Vendor.BusinessLayer.HistoryBL m_oHistory;
        Vendor.BusinessLayer.CheckListBL m_oCheckList;
        Vendor.BusinessLayer.GradeBL m_oGrade;
        Vendor.BusinessLayer.RegisterBL m_oRegister;
        Vendor.BusinessLayer.ServiceBL m_oService;
        public static int iPRowId = 0;
        string sLink = "";
        string m_sVTransId = "";
        bool m_bChange = false;
        double m_iMaxApply = 0;
        bool m_bAManualCode = false;
        int m_iMaxN = 0;

        #endregion

        #region Constructor

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        public frmMain()
        {
            InitializeComponent();
            m_oVendor = new Vendor.BusinessLayer.VendorBL();
            m_oCity = new Vendor.BusinessLayer.CityBL();
            m_oContact = new Vendor.BusinessLayer.ContactBL();
            m_oStatutory = new Vendor.BusinessLayer.StatutoryBL();
            m_oBranch = new Vendor.BusinessLayer.BranchBL();
            m_oExperience = new Vendor.BusinessLayer.ExperienceBL();
            m_oCapability = new Vendor.BusinessLayer.CapabilityBL();
            m_oTerms = new Vendor.BusinessLayer.TermsBL();
            m_oCer = new Vendor.BusinessLayer.CertificateBL();
            m_oSupply = new Vendor.BusinessLayer.SupplyBL();
            m_oLogistics = new Vendor.BusinessLayer.LogisticsBL();
            m_oHistory = new Vendor.BusinessLayer.HistoryBL();
            m_oCheckList = new Vendor.BusinessLayer.CheckListBL();
            m_oGrade = new Vendor.BusinessLayer.GradeBL();
            m_oRegister = new Vendor.BusinessLayer.RegisterBL();
            m_oService = new Vendor.BusinessLayer.ServiceBL();
        }

        public void Execute()
        {
            if (BsfGlobal.g_bWorkFlowDialog == false) { this.Show(); }
            else { this.ShowDialog(); }
        }

        #endregion

        #region Form Events

        public void frmMain_Load(object sender, EventArgs e)
        {
            barStaticItem10.Caption = "";
            barStaticItem10.Caption =  m_sVendorName.ToString();
            m_bAns = false;
            clsStatic.g_bTypeSelection = m_oCheckList.GetTypeSetup();
            if (clsStatic.g_bTypeSelection == true)
            {
                chkSupplier.Enabled = false;
                chkContractor.Enabled = false;
                chkService.Enabled = false;
            }
            else
            {
                chkSupplier.Enabled = true;
                chkContractor.Enabled = true;
                chkService.Enabled = true;
            }
            PopulateVendorIntialData();
            //cboSType.Visible = false;
            PopulateServiceType();
            GetManualCode();
            if (m_lVendorId != 0)
            {
                PopulateData();
                MenuShow();
                GetGradeDetails();                
                PopualateVendorContact(m_lVendorId);
                BsfGlobal.InsertUserUsage("Vendor-Master-Edit", m_lVendorId, BsfGlobal.g_sVendorDBName);
            }
            else
            {
                MenuHide();
            }
            iPRowId =frmVendorMain.iRowId;
            PopulateCity();
            DocVisible();
            m_bAns = true;
        }

        private void GetManualCode()
        {
            DataTable dtMaxNo;
            TxtCode.Text = "";
            string codeP = "";
            string codeS = "";

            DataTable dtAssICode = new DataTable();
            dtAssICode = m_oCheckList.GetVendorCodeTypeSetup();

            if (dtAssICode.Rows.Count > 0)
            {
                m_bAManualCode = Convert.ToBoolean(dtAssICode.Rows[0]["CodeType"].ToString());
                if (m_bAManualCode == false)
                {
                    TxtCode.Enabled = true;
                }
                else
                {
                    TxtCode.Enabled = false;
                }
            }
            if (m_bAManualCode == true)
            {
                dtMaxNo = new DataTable();
                dtMaxNo = m_oCheckList.GetVendorCodeTypeSetup();
                if (dtMaxNo.Rows.Count > 0)
                {
                    codeP = dtMaxNo.Rows[0]["CodePrefix"].ToString().Trim();
                    codeS = dtMaxNo.Rows[0]["Suffix"].ToString().Trim();
                    m_iMaxN = Convert.ToInt32(dtMaxNo.Rows[0]["MaxNo"].ToString());
                    if (codeP != "")
                    {
                        m_iMaxN = m_iMaxN + 1;
                        if (codeS != "")
                        {
                            TxtCode.Text = codeP + codeS + "000" + m_iMaxN;
                        }
                        else
                        {
                            TxtCode.Text = codeP + "000" + m_iMaxN;
                        }
                        TxtCode.Enabled = false;
                    }
                }

            }

        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BsfGlobal.g_bWorkFlow == true)
            {
                if (BsfGlobal.g_bWorkFlowDialog == false)
                {
                    try { this.Parent.Controls.Owner.Hide(); }
                    catch { }
                    Vendor.frmVendorMain frm = new Vendor.frmVendorMain();
                    BsfGlobal.ShowForm(frm, "Vendor");
                }
            }         
        }

        #endregion

        #region Functions

        private void GetGradeDetails()
        {
            m_tSupplyGrade = m_oRegister.GetGradeName(m_lVendorId, "S");
            m_tContractGrade = m_oRegister.GetGradeName(m_lVendorId, "C");
            m_tServiceGrade = m_oRegister.GetGradeName(m_lVendorId, "H");
            if (m_tSupplyGrade != null)
            {
                if (m_tSupplyGrade.Rows.Count > 0)
                {
                    txtASupply.Tag = m_tSupplyGrade.Rows[0][0].ToString();
                    txtASupply.Text = m_tSupplyGrade.Rows[0][1].ToString();
                }
            }
            if (m_tContractGrade != null)
            {
                if (m_tContractGrade.Rows.Count > 0)
                {
                    txtAContract.Tag = m_tContractGrade.Rows[0][0].ToString();
                    txtAContract.Text = m_tContractGrade.Rows[0][1].ToString();
                }
            }
            if (m_tServiceGrade != null)
            {
                if (m_tServiceGrade.Rows.Count > 0)
                {
                    txtAService.Tag = m_tServiceGrade.Rows[0][0].ToString();
                    txtAService.Text = m_tServiceGrade.Rows[0][1].ToString();
                }
            }
        }

        private void PopulateCity()
        {
            cboCity.Properties.DataSource = m_tCity;
            cboCity.Properties.DisplayMember = "CityName";
            cboCity.Properties.ValueMember = "CityId";
            cboCity.Properties.ForceInitialize();
            cboCity.Properties.PopulateColumns();
            cboCity.Properties.Columns["CityId"].Visible = false;
            cboCity.Properties.Columns["StateName"].Visible = false;
            cboCity.Properties.Columns["CountryName"].Visible = false;
            cboCity.Properties.Columns["CountryId"].Visible = false;
            cboCity.Properties.Columns["StateId"].Visible = false;
        }

        public void PopulateVendorIntialData()
        {

            DataSet ds = new DataSet();

            m_tCity = new DataTable();
            m_tVendorMasterInfo = new DataTable();
            m_tVendorContactInfo = new DataTable();
            m_tVendorStatutoryInfo = new DataTable();
            m_tTurnOver = new DataTable();
            m_tVendorBranch = new DataTable();
            m_tExperience = new DataTable();
            m_tTechPersons = new DataTable();
            m_tTerms = new DataTable();
            m_tWorkGroup = new DataTable();
            m_tService = new DataTable();
            m_tManPower = new DataTable();
            m_tMachinery = new DataTable();
            m_tLocation = new DataTable();
            m_tVWorkGroup = new DataTable();
            m_tVService = new DataTable();
            m_tCertificate = new DataTable();
            m_tCertificateTrans = new DataTable();
            m_tActivity = new DataTable();
            m_tActivtyTrans = new DataTable();
            m_tHireMachinery = new DataTable();
            m_tHireMachineryTrans = new DataTable();
            m_tMaterialGroup = new DataTable();
            m_tMaterialGroupTrans = new DataTable();
            m_tMaterialTrans = new DataTable();
            m_tLogistics = new DataTable();
            m_tTransportMode = new DataTable();
            dtSType = new DataTable();
            m_tTransport = new DataTable();
            dtTransport = new DataTable();


            ds = m_oVendor.GetVendorInfo(m_lVendorId);
            m_tCity = ds.Tables[0];
            m_tVendorMasterInfo = ds.Tables[1];
            m_tVendorContactInfo = ds.Tables[2];
            m_tVendorStatutoryInfo = ds.Tables[3];
            m_tTurnOver = ds.Tables[4];
            m_tVendorBranch = ds.Tables[5];
            m_tExperience = ds.Tables[6];
            m_tTechPersons = ds.Tables[7];
            m_tTerms = ds.Tables[8];
            m_tWorkGroup = ds.Tables[9];
            m_tService = ds.Tables[25];
            m_tManPower = ds.Tables[10];
            m_tMachinery = ds.Tables[11];
            m_tLocation = ds.Tables[12];
            m_tVWorkGroup = ds.Tables[13];
            m_tVService = ds.Tables[14];
            m_tCertificate = ds.Tables[15];
            m_tCertificateTrans = ds.Tables[16];
            m_tActivity = ds.Tables[17];
            m_tActivtyTrans = ds.Tables[18];
            m_tHireMachinery = ds.Tables[19];
            m_tHireMachineryTrans = ds.Tables[20];
            m_tMaterialGroupTrans = ds.Tables[21];
            m_tMaterialTrans = ds.Tables[22];
            m_tLogistics = ds.Tables[23];
            m_tTransportMode = ds.Tables[24];
            dtSType = ds.Tables["ServiceType"];
            m_tTransport = ds.Tables["Transport"];
            dtTransport = ds.Tables["VendorTransport"];
            ds = null;

            m_dsMaterial = new DataSet();
            m_dsMaterial = m_oCapability.GetMaterials();

            m_dsMaterial.Relations.Add("RGroup", m_dsMaterial.Tables[0].Columns["Resource_Group_ID"], m_dsMaterial.Tables[1].Columns["Resource_Group_ID"], false);

           
        }

        private void PopulateMasterInfo(int argVendorId)
        {
            DataView dv;
            DataTable dt;
            int lCityId = 0;
            if (m_tVendorMasterInfo != null)
            {
                dv = new DataView(m_tVendorMasterInfo);
                dv.RowFilter = "VendorId = " + argVendorId;
                dt = dv.ToTable();
                SetDefaultValue();
                if (dt.Rows.Count > 0)
                {
                  
                    txtName.Text = dt.Rows[0]["VendorName"].ToString();
                    TxtCode.Text = dt.Rows[0]["Code"].ToString();
                    chkSupplier.Checked = Convert.ToBoolean(dt.Rows[0]["Supply"].ToString());
                    chkContractor.Checked = Convert.ToBoolean(dt.Rows[0]["Contract"].ToString());
                    chkService.Checked = Convert.ToBoolean(dt.Rows[0]["Service"].ToString());
                    txtAddress1.Text = dt.Rows[0]["RegAddress"].ToString();
                    lCityId = Convert.ToInt32(dt.Rows[0]["CityId"].ToString());
                    txtPin.Text = dt.Rows[0]["PinCode"].ToString();
                    cboCity.EditValue = lCityId;
                    if (chkSupplier.Checked == true) { chkSupplier.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold); }
                    else { chkSupplier.Font = new System.Drawing.Font("Calibri", 8, FontStyle.Regular); }

                    if (chkContractor.Checked == true) { chkContractor.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold); }
                    else { chkContractor.Font = new System.Drawing.Font("Calibri", 8, FontStyle.Regular); }

                    if (chkService.Checked == true) { chkService.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold); }
                    else { chkService.Font = new System.Drawing.Font("Calibri", 8, FontStyle.Regular); }


                    if (dt.Rows[0]["SupplyType"].ToString() != " ")
                    {
                        bool bSuppChk = false;
                        if (dt.Rows[0]["SupplyType"].ToString() == "S") { comboBoxEdit1.Text = "Distributor"; bSuppChk = VendorBL.IsChkSupplierValid(argVendorId, "S"); }
                        if (dt.Rows[0]["SupplyType"].ToString() == "D") { comboBoxEdit1.Text = "Dealer"; bSuppChk = VendorBL.IsChkSupplierValid(argVendorId, "D"); }
                        if (dt.Rows[0]["SupplyType"].ToString() == "M") { comboBoxEdit1.Text = "Manufacturer"; bSuppChk = VendorBL.IsChkSupplierValid(argVendorId, "M"); }
                        if (bSuppChk == true) { comboBoxEdit1.Enabled = false; } else { comboBoxEdit1.Enabled = true; }
                        
                    }
                    txtCheque.Text = dt.Rows[0]["ChequeNo"].ToString();
                    cboSType.EditValue = Convert.ToInt32(clsStatic.IsNullCheck(dt.Rows[0]["ServiceTypeId"], clsStatic.datatypes.vartypenumeric));
                    if (Convert.ToBoolean(clsStatic.IsNullCheck(dt.Rows[0]["Company"], clsStatic.datatypes.varTypeBoolean)) == true) rgIsCompany.SelectedIndex = 0; else rgIsCompany.SelectedIndex = 1;
                }
            }
            m_bChange = false;
        }

        private void SetDefaultStatutory()
        {
            txtFirm.Text = "";
            txtYear.Text = "";
            txtPANNo.Text = "";
            txtTANNo.Text = "";
            txtTINNo.Text = "";
            txtCSTNo.Text = "";
            txtSTaxNo.Text = "";
            txtTNGST.Text = "";
            txtAccountNo.Text = "";
            cboAccType.SelectedIndex = 0;
            txtBankName.Text = "";
            txtBranch.Text = "";
            txtBranchCode.Text = "";
            txtMICR.Text = "";
            txtIFSC.Text = "";
            grdTurnOver.DataSource = null;
        }

        private void cboCity_EditValueChanged(object sender, EventArgs e)
        {
            DataView dv;
            DataTable dt;
            int lCityId = 0;
            if (cboCity.EditValue == null) { return; }
            if ((m_tCity.Rows.Count > 0 ))
            {
                lCityId = Convert.ToInt32(cboCity.EditValue.ToString());
                dv = new DataView(m_tCity);
                dv.RowFilter = "CityId = " + lCityId;
                dt = dv.ToTable();
                if (dt.Rows.Count > 0)
                {
                    txtState.Text = dt.Rows[0]["StateName"].ToString();
                    txtCountry.Text = dt.Rows[0]["CountryName"].ToString();
                }                    
            }
            m_bChange = true;
        }
      
        private void PopulateInfo()
        {
            if (m_lVendorId != 0)
            {
                //if (documentTabStrip1.ActiveWindow.Text == "") return;

                if (documentTabStrip1.ActiveWindow.Text == "Contact Information"){ PopualateVendorContact(m_lVendorId);}
                else if (documentTabStrip1.ActiveWindow.Text == "Branch Details") { PopulateBranch(m_lVendorId); }
                else if (documentTabStrip1.ActiveWindow.Text == "Statutory Info") { PopualateVendorStatutory(m_lVendorId); }
                else if (documentTabStrip1.ActiveWindow.Text == "Experience") { PopulateExperience(m_lVendorId); }
                else if (documentTabStrip1.ActiveWindow.Text == "Capability") { PopulateCapability(); }
                else if (documentTabStrip1.ActiveWindow.Text == "Terms and Conditions") { PopualateTerms(m_lVendorId); }
                else if (documentTabStrip1.ActiveWindow.Text == "Assessment") { PopualateRegistration(m_lVendorId); }
                else if (documentTabStrip1.ActiveWindow.Text == "Registration") { PopulateReg(); };
               


            }
        }

        private void SetDefaultContact()
        {
            txtCAddress.Text = "";
            txtPhone1.Text = "";
            txtPhone2.Text = "";
            txtFax1.Text = "";
            txtFax2.Text = "";
            txtMobile1.Text = "";
            txtMobile2.Text = "";
            txtCPerson.Text = "";
            txtAPerson.Text = "";
            txtCDesignation.Text = "";
            txtADesignation.Text = "";
            txtCContact.Text = "";
            txtAContactNo.Text = "";
            txtEMail1.Text = "";
            txtEMail2.Text = "";
            txtWeb.Text = "";
        }

        private void PopualateVendorContact(int argVendorID)
        {
            DataView dv;
            DataTable dt;
            if (m_tVendorContactInfo != null)
            {
                dv = new DataView(m_tVendorContactInfo);
                dv.RowFilter = "VendorId = " + argVendorID;
                dt = dv.ToTable();
                SetDefaultContact();
                if (dt.Rows.Count > 0)
                {
                    txtCAddress.Text = dt.Rows[0]["CAddress"].ToString();
                    txtPhone1.Text = dt.Rows[0]["Phone1"].ToString();
                    txtPhone2.Text = dt.Rows[0]["Phone2"].ToString();
                    txtFax1.Text = dt.Rows[0]["Fax1"].ToString();
                    txtFax2.Text = dt.Rows[0]["Fax2"].ToString();
                    txtMobile1.Text = dt.Rows[0]["Mobile1"].ToString();
                    txtMobile2.Text = dt.Rows[0]["Mobile2"].ToString();
                    txtCPerson.Text = dt.Rows[0]["CPerson1"].ToString();
                    txtAPerson.Text = dt.Rows[0]["CPerson2"].ToString();
                    txtCDesignation.Text = dt.Rows[0]["CDesignation1"].ToString();
                    txtADesignation.Text = dt.Rows[0]["CDesignation2"].ToString();
                    txtCContact.Text = dt.Rows[0]["ContactNo1"].ToString();
                    txtAContactNo.Text = dt.Rows[0]["ContactNo2"].ToString();
                    txtEMail1.Text = dt.Rows[0]["Email1"].ToString();
                    txtEMail2.Text = dt.Rows[0]["Email2"].ToString();
                    txtWeb.Text = dt.Rows[0]["WebName"].ToString();
                }
            }
            m_bChange = false;
        }

        private void SetDefaultValue()
        {
            txtName.Text = "";
            chkSupplier.Checked = false;
            chkContractor.Checked = false;
            chkService.Checked = false;
            txtAddress1.Text = "";
            //cboCity.EditValue= -1;
            //cboCity.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            txtPin.Text = "";
        }

        private void PopulateBranch(int argVendorId)
        {
            DataView dv;
            DataTable dt;
            if (m_tVendorBranch != null)
            {
                dv = new DataView(m_tVendorBranch);
                dv.RowFilter = "VendorId = " + argVendorId;
                dt = dv.ToTable();
                grdBranch.DataSource = dt;

                BranchView.Columns["BranchId"].Visible = false;
                BranchView.Columns["VendorId"].Visible = false;
                BranchView.Columns["BranchName"].Width = 150;
                BranchView.Columns["Address"].Width = 250;
                BranchView.Columns["CityName"].Width = 100;
                BranchView.Columns["TINNo"].Width = 100;
                BranchView.Columns["CityId"].Visible = false;
                BranchView.Columns["ChequeNo"].Visible = false;
                BranchView.Columns["BranchName"].Caption = "Branch Name";
                BranchView.Columns["Address"].Caption = "Address";
                BranchView.Columns["CityName"].Caption = "City";
                BranchView.Columns["TINNo"].Caption = "TIN No";                

            }
            m_bChange = false;
        }

        private void PopualateVendorStatutory(int argVendorID)
        {

            SetDefaultStatutory();
            DataView dv;
            DataTable dt;
            m_tTurnOverSub = new DataTable();
            if (m_tVendorStatutoryInfo != null)
            {
                dv = new DataView(m_tVendorStatutoryInfo);
                dv.RowFilter = "VendorId = " + argVendorID;
                dt = dv.ToTable();
                if (dt.Rows.Count > 0)
                {
                    txtFirm.Text = dt.Rows[0]["FirmType"].ToString();
                    txtYear.Text = dt.Rows[0]["EYear"].ToString();
                    txtPANNo.Text = dt.Rows[0]["PANNo"].ToString();
                    txtTANNo.Text = dt.Rows[0]["TANNo"].ToString();
                    txtCSTNo.Text = dt.Rows[0]["CSTNo"].ToString();
                    txtTINNo.Text = dt.Rows[0]["TINNo"].ToString();
                    txtAccountNo.Text = dt.Rows[0]["BankAccountNo"].ToString();
                    cboAccType.SelectedIndex  = (dt.Rows[0]["AccountType"].ToString() == "C" ? 0 : 1);
                    txtBankName.Text = dt.Rows[0]["BankName"].ToString();
                    txtBranch.Text = dt.Rows[0]["BranchName"].ToString();
                    txtBranchCode.Text = dt.Rows[0]["BranchCode"].ToString();
                    txtSTaxNo.Text = dt.Rows[0]["ServiceTaxNo"].ToString();
                    txtTNGST.Text = dt.Rows[0]["TNGSTNo"].ToString();
                    txtMICR.Text = dt.Rows[0]["MICRCode"].ToString();
                    txtIFSC.Text = dt.Rows[0]["IFSCCode"].ToString();

                    //SSIREGDNo,ServiceTaxCir,EPFNo,ESINo,ExciseVendor,ExciseRegNo,Excisedivision,ExciseRange,ECCno
                    txtSSIREGD.Text = dt.Rows[0]["SSIREGDNo"].ToString();
                    txtServiceTaxC.Text = dt.Rows[0]["ServiceTaxCir"].ToString();
                    txtEPFNo.Text = dt.Rows[0]["EPFNo"].ToString();
                    txtESINo.Text = dt.Rows[0]["ESINo"].ToString();
                    if (Convert.ToBoolean(clsStatic.IsNullCheck(dt.Rows[0]["ExciseVendor"], clsStatic.datatypes.varTypeBoolean)) == true) radioExciseV.SelectedIndex = 0; else radioExciseV.SelectedIndex = 1;                   
                    txtExciseRegNo.Text = dt.Rows[0]["ExciseRegNo"].ToString();
                    txtExcisedivision.Text = dt.Rows[0]["Excisedivision"].ToString();
                    txtExciseRange.Text = dt.Rows[0]["ExciseRange"].ToString();
                    txtECCno.Text = dt.Rows[0]["ECCno"].ToString();
                }
            }
            m_bChange = false;
        }

        private void PopulateExperience(int argVendorId)
        {
            DataView dv;
            DataTable dt;
            if (m_tExperience != null)
            {
                dv = new DataView(m_tExperience);
                dv.RowFilter = "VendorId = " + argVendorId;
                dt = dv.ToTable();
                grdExperience.DataSource = dt;

                ExpView.Columns["ExperienceId"].Visible = false;
                ExpView.Columns["VendorId"].Visible = false;
                ExpView.Columns["WorkDescription"].Width = 250;
                ExpView.Columns["ClientName"].Width = 150;
                ExpView.Columns["Value"].Width = 100;
                ExpView.Columns["Period"].Width = 100;
                ExpView.Columns["Type"].Width = 100;
                ExpView.Columns["Value"].ColumnEdit = txtValue; 
                //grdExperience.Columns["Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //grdExperience.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
            }
            m_bChange = false;
        }

        private void PopulateCapability()
        {    
            if (documentTabStrip3.ActiveWindow.Text == "Resource") { PopulateResource(); }
            else if (documentTabStrip3.ActiveWindow.Text == "Financial") { PopulateTurnOver(); }
            else if (documentTabStrip3.ActiveWindow.Text == "Others") { PopulateCertificate(); }

            else if (documentTabStrip3.ActiveWindow.Text == "Supply")
            {
                m_bMaterialCheck = false;
                PopulateMaterialGroup();
                PopulateLogistics();
                PopulateMaterial();                  
                //clsStatic.PopulateAutoComplete(txtTransMode, m_tTransportMode, "TransportMode");
                m_bMaterialCheck = true;
            }
            else if (documentTabStrip3.ActiveWindow.Text == "Works")
            {
                PopulateWorkGroup();
                PopulateActivity();
            }
            else if (documentTabStrip3.ActiveWindow.Text == "Service")
            {
                PopulateService();
                PopulateHireMachinery();
            }
            else if (documentTabStrip3.ActiveWindow.Text == "Manufacture")
            {
                PopulateSupplierManuFactureGrid();
            }
            else if (documentTabStrip3.ActiveWindow.Text == "Distributor")
            {
                PopulateSupplierDistributorGrid();
            }
            else if (documentTabStrip3.ActiveWindow.Text == "Dealer")
            {
                PopulateSupplierDealerGrid();
            }
            if (comboBoxEdit1.Text == "Distributor") 
            {
                dwDistributor.Hide();
                dwManufacture.Show();
                dwDelarL.Show();               
            }
            else if (comboBoxEdit1.Text == "Dealer") 
            {
                dwDelarL.Hide();
                dwManufacture.Show();
                dwDistributor.Show();               
            }
            else if (comboBoxEdit1.Text == "Manufacturer")
            {
                dwManufacture.Hide();
                dwDistributor.Show();
                dwDelarL.Show();            
            }
            else
            {
                dwManufacture.Hide();
                dwDelarL.Hide();
                dwDistributor.Hide();
            }

            dwGeneral.Hide();
            m_bChange = false;
        }

        private void PopulateMatCertificate(int argResId)
        {
            DataTable dtCer = new DataTable();
            dtCer = m_oCapability.PopulateMatCertificate(argResId);
            grdMatCertificate.DataSource = dtCer;
            MatCerView.Columns["CertificateId"].Visible = false;
            MatCerView.Columns["Sel"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            MatCerView.Columns["Sel"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //MatCerView.Columns["ResourceId"].Visible = false;
        }

        private void PopulateHireMachinery()
        {
            chkHire.DataSource = null;
            chkHire.DataSource = m_tHireMachinery;
            chkHire.DisplayMember = "Resource_Name";
            chkHire.ValueMember = "Resource_Id";

            DataView dv;
            DataTable dt;
            int lWId;
            if (m_tHireMachineryTrans != null)
            {
                dv = new DataView(m_tHireMachineryTrans);
                dv.RowFilter = "VendorId = " + m_lVendorId;
                dt = dv.ToTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lWId = Convert.ToInt32(dt.Rows[i]["Resource_ID"].ToString());

                    for (int j = 0; j < chkHire.ItemCount; j++)
                    {
                        chkHire.SetSelected(j, true);
                        if (lWId == Convert.ToInt32(((System.Data.DataRowView)(chkHire.SelectedItem)).Row.ItemArray[0]))
                        {
                            chkHire.SetItemChecked(j, true);
                            break;
                        }
                    }
                }
            }

        }

        private void PopulateService()
        {
            chkServiceGroup.DataSource = null;
            chkServiceGroup.DataSource = m_tService;
            chkServiceGroup.DisplayMember = "ServiceName";
            chkServiceGroup.ValueMember = "ServiceId";


            DataView dv;
            DataTable dt;
            int lWId;
            if (m_tVService != null)
            {
                dv = new DataView(m_tVService);
                dv.RowFilter = "VendorId = " + m_lVendorId;
                dt = dv.ToTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lWId = Convert.ToInt32(dt.Rows[i]["ServiceId"].ToString());

                    for (int j = 0; j < chkServiceGroup.ItemCount; j++)
                    {
                        chkServiceGroup.SetSelected(j, true);
                        if (lWId == Convert.ToInt32(chkServiceGroup.SelectedValue))
                        {
                            chkServiceGroup.SetItemChecked(j, true);
                            break;
                        }
                    }
                }
            }

        }

        private void PopulateActivity()
        {
            chkActivity.DataSource = null;
            chkActivity.DataSource = m_tActivity;
            chkActivity.DisplayMember = "Resource_Group_Name";
            chkActivity.ValueMember = "Resource_Group_Id";

            DataView dv;
            DataTable dt;
            int lWId;
            if (m_tActivtyTrans != null)
            {
                dv = new DataView(m_tActivtyTrans);
                dv.RowFilter = "VendorId = " + m_lVendorId;
                dt = dv.ToTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lWId = Convert.ToInt32(dt.Rows[i]["Resource_Group_ID"].ToString());

                    for (int j = 0; j < chkActivity.ItemCount; j++)
                    {
                        chkActivity.SetSelected(j, true);
                        if (lWId == Convert.ToInt32(((System.Data.DataRowView)(chkActivity.SelectedItem)).Row.ItemArray[0]))
                        {
                            chkActivity.SetItemChecked(j, true);
                            break;
                        }
                    }
                }
            }

        }

        private void PopulateWorkGroup()
        {
            chkIWorkGroup.DataSource = null;
            chkIWorkGroup.DataSource = m_tWorkGroup;
            chkIWorkGroup.DisplayMember = "Work_Group_Name";
            chkIWorkGroup.ValueMember = "Work_Group_Id";

            DataView dv;
            DataTable dt;
            int lWId;
            if (m_tVWorkGroup != null)
            {
                dv = new DataView(m_tVWorkGroup);
                dv.RowFilter = "VendorId = " + m_lVendorId;
                dt = dv.ToTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lWId = Convert.ToInt32(dt.Rows[i]["Work_Group_ID"].ToString());

                    for (int j = 0; j < chkIWorkGroup.ItemCount; j++)
                    {
                        chkIWorkGroup.SetSelected(j, true);
                        if (lWId == Convert.ToInt32(chkIWorkGroup.SelectedValue))
                        {
                            chkIWorkGroup.SetItemChecked(j, true);
                            break;
                        }
                    }
                }
            }

        }

        private void PopulateLogistics()
        {
            cboTrans.SelectedIndex = -1;
            txtTransMode.Text = "";
            cboDelivery.SelectedIndex = -1;
            cboInsurance.Text = "No";
            cboUnload.Text = "No";

            DataView dv;
            DataTable dt;
            dt = new DataTable();
            dv = new DataView(m_tLogistics);
            dv.RowFilter = "VendorId = " + m_lVendorId;
            dt = dv.ToTable();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["TransportArrange"].ToString() == "O") { cboTrans.Text = "Own"; }
                else if (dt.Rows[0]["TransportArrange"].ToString() == "T") { cboTrans.Text = "Third Party"; }
                else if (dt.Rows[0]["TransportArrange"].ToString() == "U") { cboTrans.Text = "Arranged by Us"; }

                txtTransMode.Text = dt.Rows[0]["TransportMode"].ToString();

                if (dt.Rows[0]["Delivery"].ToString() == "D") { cboDelivery.Text = "Delivery Address"; }
                else if (dt.Rows[0]["Delivery"].ToString() == "S") { cboDelivery.Text = "Specific Location"; }

                if (dt.Rows[0]["Insurance"].ToString() == "Y") { cboInsurance.Text = "Yes"; }
                else if (dt.Rows[0]["Insurance"].ToString() == "N") { cboInsurance.Text = "No"; }

                if (dt.Rows[0]["Unload"].ToString() == "Y") { cboUnload.Text = "Yes"; }
                else if (dt.Rows[0]["Unload"].ToString() == "N") { cboUnload.Text = "No"; }
            }
            m_bChange = false;
        }

        private void PopulateMaterialGroup()
        {

            ////tvMaterial.Nodes.Clear();
            ////tvMaterial.Nodes.Add("Material Group");

            ////if (m_dsMaterial != null)
            ////{
            ////    RadTreeNode Node1;
            ////    RadTreeNode Node2;
            ////    RadTreeNode rNode;
            ////    tvMaterial.Tag = 0;
            ////    rNode = tvMaterial.TopNode;
            ////    if (rNode == null)
            ////    {
            ////        return;
            ////    }
            ////    foreach (DataRow dr in m_dsMaterial.Tables[0].Rows)
            ////    {
            ////        Node1 = new RadTreeNode();
            ////        Node1.Text = dr["Resource_Group_Name"].ToString();
            ////        Node1.Tag = dr["Resource_Group_Id"].ToString();
            ////        rNode.Nodes.Add(Node1);
            ////        foreach (DataRow drChild in dr.GetChildRows("RGroup"))
            ////        {
            ////            Node2 = new RadTreeNode();
            ////            Node2.Text = drChild["Resource_Name"].ToString();
            ////            Node2.Tag = drChild["Resource_Id"].ToString();
            ////            Node1.Nodes.Add(Node2);
            ////        }
            ////    }
            //tvMaterial.Nodes.Clear();
            //    DataView dv;
            //    DataTable dtMG = new DataTable();
            //    DataTable dtM = new DataTable();
            //    dv = new DataView(m_tMaterialGroupTrans);
            //    dv.RowFilter = "VendorId = " + m_lVendorId;
            //    dtMG = dv.ToTable();
            //    //tvMaterial.ExpandAll();

            //    dv = new DataView(m_tMaterialTrans);
            //    dv.RowFilter = "VendorId = " + m_lVendorId;
            //    dtM = dv.ToTable();
            //    int id = 0;
            //    DataTable dt = null;
            //   // rNode = tvMaterial.TopNode;

            ////    foreach (RadTreeNode Tnode in rNode.Nodes)
            ////    {
            ////        id = Convert.ToInt32(Tnode.Tag);
            ////        dt = new DataTable();
            ////        dv = new DataView(dtMG);
            ////        dv.RowFilter = "Resource_Group_Id = " + id;
            ////        dt = dv.ToTable();
            ////        if (dt.Rows.Count > 0) { Tnode.Checked = true; }
            ////        foreach (RadTreeNode Cnode in Tnode.Nodes)
            ////        {
            ////            id = Convert.ToInt32(Cnode.Tag);
            ////            dt = new DataTable();
            ////            dv = new DataView(dtM);
            ////            dv.RowFilter = "Resource_Id = " + id;
            ////            dt = dv.ToTable();
            ////            if (dt.Rows.Count > 0) { Cnode.Checked = true; }
            ////        }
            ////    }
            ////}
            //int iCtr = 0;
            //int iNodeId = 0;
            //int iChild = 0;
            //string iResourceName = "";
            //tvMaterial.BeginUpdate();
            //tvMaterial.Columns.Add();
            //tvMaterial.Columns[0].Caption = "Material";
            //tvMaterial.Columns[0].VisibleIndex = 0;
            //tvMaterial.Columns[0].Width = 100;
            //tvMaterial.Columns.Add();
            //tvMaterial.Columns[1].Caption = "ResourceGroupId";
            //tvMaterial.Columns[1].VisibleIndex = 1;
            //tvMaterial.Columns.Add();
            //tvMaterial.Columns[2].Caption = "ContactPerson";
            //tvMaterial.Columns[2].VisibleIndex = 2;
            //tvMaterial.Columns[2].Width = 10;
            //tvMaterial.Columns.Add();
            //tvMaterial.Columns[3].Caption = "ContactNo";
            //tvMaterial.Columns[3].VisibleIndex = 3;
            //tvMaterial.Columns[3].Width = 10;
            //tvMaterial.EndUpdate();
           

            //tvMaterial.Columns[1].Visible = false;
            //tvMaterial.Columns[0].OptionsColumn.AllowEdit = false;
            //TreeListNode ParentForRootNodes = null;
            //TreeListNode rootNode = tvMaterial.AppendNode(new object[] { "Material Group" }, ParentForRootNodes);
            //for (iCtr = 0; iCtr < m_dsMaterial.Tables[0].Rows.Count; iCtr++)
            //{
            //    iNodeId = Convert.ToInt16(m_dsMaterial.Tables[0].Rows[iCtr]["Resource_Group_ID"].ToString());
            //    TreeListNode rootNode1 = tvMaterial.AppendNode(new object[] {m_dsMaterial.Tables[0].Rows[iCtr]["Resource_Group_Name"].ToString(), m_dsMaterial.Tables[0].Rows[iCtr]["Resource_Group_ID"].ToString(),"",""  }, rootNode);
            //    iChild = Convert.ToInt16(m_dsMaterial.Tables[0].Rows[iCtr]["Resource_Group_ID"].ToString());
                
            //    if (iChild > 0) AChild(rootNode1, iNodeId);
            //    if (m_tMaterialGroupTrans.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < m_tMaterialGroupTrans.Rows.Count; i++)
            //        {
            //            if (iNodeId.ToString() == m_tMaterialGroupTrans.Rows[i]["Resource_Group_Id"].ToString())
            //            {
            //                rootNode1.Checked = true;
            //                rootNode1.CheckState = CheckState.Checked;
            //                foreach (TreeListNode node in rootNode1.Nodes)
            //                    node.CheckState = rootNode1.CheckState;
            //            }
            //        }
            //    }
               
            //}
            //tvMaterial.EndUnboundLoad();         

        }

        private void AChild(TreeListNode argNode, int ParentId)
        {
            //int iCtr = 0;
            //DataView dvDataNew = null;
            //DataTable dtDataNew = null;
            //string argCPerson = "";
            //string argCNo = "";
       
            //dvDataNew = new DataView(m_dsMaterial.Tables[1]);
            //dvDataNew.RowFilter = "Resource_Group_ID='" + ParentId + "'";
            //dtDataNew = dvDataNew.ToTable();
            //for (iCtr = 0; iCtr < dtDataNew.Rows.Count; iCtr++)
            //{
            //    argCPerson = "";
            //    argCNo = "";
            //    tvMaterial.AppendNode(new object[] { dtDataNew.Rows[iCtr]["Resource_Name"].ToString(), dtDataNew.Rows[iCtr]["Resource_ID"].ToString(), dtDataNew.Rows[iCtr]["ContactPerson"].ToString(), dtDataNew.Rows[iCtr]["ContactNo"].ToString() }, argNode);
            //    if (m_tMaterialTrans.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < m_tMaterialTrans.Rows.Count; i++)
            //        {
            //            if (dtDataNew.Rows[iCtr]["Resource_ID"].ToString() == m_tMaterialTrans.Rows[i]["Resource_Id"].ToString())
            //            {
                          
            //                SetCheckedChildNodes(argNode, CheckState.Checked);
                                                  
                         
            //                //argNode.Checked = true;
            //                //argNode.CheckState = CheckState.Checked;
            //                SetCheckedParentNodes(argNode, argNode.CheckState);

                           
            //            }
            //        }
            //    }
            //}
           

        }

        private static void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
            
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        private static void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        private void PopulateCertificate()
        {
            PopulateCertificateTrans();
            PopulateLocation();
            PopulateEnclosure();
            PopulateTransport();
        }

        private void PopulateLocation()
        {
            chkLocation.DataSource = null;
            chkLocation.DataSource = m_tCity;
            chkLocation.DisplayMember = "CityName"; ;
            chkLocation.ValueMember = "CityId"; ;

            DataView dv;
            DataTable dt;
            int lCityId;
            if (m_tLocation != null)
            {
                dv = new DataView(m_tLocation);
                dv.RowFilter = "VendorId = " + m_lVendorId;
                dt = dv.ToTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lCityId = Convert.ToInt32(dt.Rows[i]["CityID"].ToString());

                    for (int j = 0; j < chkLocation.ItemCount; j++)
                    {
                        chkLocation.SetSelected(j, true);
                        if (lCityId == Convert.ToInt32(chkLocation.SelectedValue))
                        {
                            chkLocation.SetItemChecked(j, true);
                            break;
                        }
                    }
                }
            }
        }

        private void PopulateTransport()
        {
            m_tTransport = TransportBL.PopulateTransport();
            chkTransport.DataSource = null;
            chkTransport.DataSource = m_tTransport;
            chkTransport.DisplayMember = "TransportName"; ;
            chkTransport.ValueMember = "TransportId"; ;

            DataView dv;
            DataTable dt;
            int iTransId;
            if (m_tLocation != null)
            {
                dtTransport = TransportBL.GetVendorTransport(m_lVendorId);
                dv = new DataView(dtTransport);
                dv.RowFilter = "VendorId = " + m_lVendorId;
                dt = dv.ToTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    iTransId = Convert.ToInt32(dt.Rows[i]["TransportId"].ToString());

                    for (int j = 0; j < chkTransport.ItemCount; j++)
                    {
                        chkTransport.SetSelected(j, true);
                        if (iTransId == Convert.ToInt32(chkTransport.SelectedValue))
                        {
                            chkTransport.SetItemChecked(j, true);
                            break;
                        }
                    }
                }
            }
        }

        private void PopulateCertificateTrans()
        {

            chkCertificate.DataSource = null;
            chkCertificate.DataSource = m_tCertificate;
            chkCertificate.DisplayMember = "CerDescription"; ;
            chkCertificate.ValueMember = "CertificateId"; ;

            DataView dv;
            DataTable dt;
            int lCerId;
            if (m_tCertificateTrans != null)
            {
                dv = new DataView(m_tCertificateTrans);
                dv.RowFilter = "VendorId = " + m_lVendorId;
                dt = dv.ToTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lCerId = Convert.ToInt32(dt.Rows[i]["CertificateId"].ToString());

                    for (int j = 0; j < chkCertificate.ItemCount; j++)
                    {
                        chkCertificate.SetSelected(j, true);
                        if (lCerId == Convert.ToInt32(chkCertificate.SelectedValue))
                        {
                            chkCertificate.SetItemChecked(j, true);
                            break;
                        }
                    }
                }
            }
        }

        private void PopulateTurnOver()
        {

            if (m_tTurnOver != null)
            {
                DataView dv;
                dv = new DataView(m_tTurnOver);
                dv.RowFilter = "VendorId = " + m_lVendorId;
                m_tTurnOverSub = dv.ToTable();
                grdTurnOver.DataSource = m_tTurnOverSub;

                TOView.Columns["TurnOverId"].Visible = false;
                TOView.Columns["VendorId"].Visible = false;
                TOView.Columns["FYear"].Width = 250;
                TOView.Columns["Value"].Width = 120;
                TOView.Columns["FYear"].Caption = "Financial Year";
                TOView.Columns["Value"].Caption = "Value";

                m_tTurnOverSub.AcceptChanges();
            }

        }

        private void PopulateResource()
        {
            PopulateManPower();
            PopulateTechPersons();
            PopulateMachinery();
        }

        private void PopulateManPower()
        {
            DataView dv;
            if (m_tManPower != null)
            {
                dv = new DataView(m_tManPower);
                dv.RowFilter = "VendorId = " + m_lVendorId;
                m_tManPowerSub = dv.ToTable();
                grdManPower.DataSource = m_tManPowerSub;

                MPView.Columns["ManPowerTransId"].Visible = false;
                MPView.Columns["Resource_ID"].Visible = false;
                MPView.Columns["VendorId"].Visible = false;
                MPView.Columns["Resource_Name"].Width = 120;
                MPView.Columns["Unit_Name"].Width = 60;
                MPView.Columns["Qty"].Width = 80;

                MPView.Columns["Resource_Name"].Caption = "Description";
                MPView.Columns["Unit_Name"].Caption = "Unit";

                MPView.Columns["Resource_Name"].OptionsColumn.AllowEdit = false ;
                MPView.Columns["Unit_Name"].OptionsColumn.AllowEdit = false;

                //grdManPower.Columns["Unit_Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                //grdManPower.Columns["Qty"].SortMode = DataGridViewColumnSortMode.NotSortable;
               // grdManPower.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //grdManPower.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);

                m_tManPowerSub.AcceptChanges();
            }
        }

        private void PopulateTechPersons()
        {
            if (m_tTechPersons != null)
            {
                DataView dv;
                dv = new DataView(m_tTechPersons);
                dv.RowFilter = "VendorId = " + m_lVendorId;
                m_tTechPersonSub = dv.ToTable();
                grdTechPerson.DataSource = m_tTechPersonSub;

                TPView.Columns["TechPersonId"].Visible = false;
                TPView.Columns["VendorId"].Visible = false;
                TPView.Columns["PersonName"].Width = 250;

                TPView.Columns["Qualification"].Width = 120;
                TPView.Columns["Experience"].Width = 120;
                TPView.Columns["Designation"].Width = 120;


                TPView.Columns["PersonName"].Caption = "Person Name";
                TPView.Columns["Qualification"].Caption = "Qualification";
                TPView.Columns["Experience"].Caption = "Experience (Years)";
                TPView.Columns["Designation"].Caption = "Designation";


                //grdTechPerson.Columns["PersonName"].SortMode = DataGridViewColumnSortMode.NotSortable;
                //grdTechPerson.Columns["Qualification"].SortMode = DataGridViewColumnSortMode.NotSortable;
                //grdTechPerson.Columns["Experience"].SortMode = DataGridViewColumnSortMode.NotSortable;
                //grdTechPerson.Columns["Designation"].SortMode = DataGridViewColumnSortMode.NotSortable;


                //grdTechPerson.Columns["Experience"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //grdTechPerson.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);

                m_tTechPersonSub.AcceptChanges();
            }



        }

        private void PopulateMachinery()
        {
            DataView dv;
            if (m_tMachinery != null)
            {
                dv = new DataView(m_tMachinery);
                dv.RowFilter = "VendorId = " + m_lVendorId;
                m_tMachinerySub = dv.ToTable();
                grdMachinery.DataSource = m_tMachinerySub;

                MachView.Columns["MachineryTransId"].Visible = false;
                MachView.Columns["Resource_ID"].Visible = false;
                MachView.Columns["VendorId"].Visible = false;
                MachView.Columns["Resource_Name"].Width = 120;
                MachView.Columns["Unit_Name"].Width = 60;
                MachView.Columns["Qty"].Width = 80;
                MachView.Columns["Capacity"].Width = 100;

                MachView.Columns["Resource_Name"].Caption = "Description";
                MachView.Columns["Unit_Name"].Caption = "Unit";

                MachView.Columns["Resource_Name"].OptionsColumn.AllowEdit = true;

                MachView.Columns["Unit_Name"].OptionsColumn.AllowEdit = true;

                //grdMachinery.Columns["Unit_Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                //grdMachinery.Columns["Qty"].SortMode = DataGridViewColumnSortMode.NotSortable;
                //grdMachinery.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //grdMachinery.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);

                m_tMachinerySub.AcceptChanges();
            }
        }

        private void PopualateTerms(int argVendorID)
        {
            DataView dv;
            DataTable dt;
            if (m_tTerms != null)
            {
                dv = new DataView(m_tTerms);
                dv.RowFilter = "VendorId = " + argVendorID;
                dt = dv.ToTable();
                SetDefaultContact();
                if (dt.Rows.Count > 0)
                {
                    txtCredit.Text = dt.Rows[0]["CreditDays"].ToString();
                    txtMaxLeadTime.Text = dt.Rows[0]["MaxLeadTime"].ToString();
                    txtTerms.Text = dt.Rows[0]["TermsAndCondition"].ToString();
                }
            }
            m_bChange = false;
        }

        private void PopualateRegistration(int argVendorId)
        {
            txtASupply.Tag = 0;
            txtAContract.Tag = 0;
            txtAService.Tag = 0;

            txtASupply.Text = "";
            txtAContract.Text = "";
            txtAService.Text = "";

            PopulateCheckList();
            GetGradeDetails();
            m_bChange = false;
        }

        private void PopulateCheckList()
        {
            DataTable dtCheck = new DataTable();
            DataTable dtC = new DataTable();
            DataView dvC;
            dtCheck = m_oRegister.GetCheckListTrans(m_lVendorId);

            m_tCheckList = new DataTable();
            m_tCheckList = m_oCheckList.GetCheckListMastert();
            int lCount;
            int lId = 0;

            DataView dv;
            DataTable dt = new DataTable();
            dv = new DataView(m_tCheckList);
            dv.RowFilter = "Supply = true";
            dt = dv.ToTable();

            DataTable dtSupply=new DataTable();
            DataTable dtContract = new DataTable();
            DataTable dtService = new DataTable();

            dtSupply.Columns.Add("ID");
            dtSupply.Columns.Add("Sel",typeof(Boolean));
            dtSupply.Columns.Add("Description");
            dtSupply.Columns.Add("MaxPoints");
            dtSupply.Columns.Add("Points");
            
            for (lCount = 0; lCount < dt.Rows.Count; lCount++)
            {
                lId = Convert.ToInt32(dt.Rows[lCount]["CheckListId"].ToString());
                dtC = new DataTable();
                dvC = new DataView(dtCheck);
                dvC.RowFilter = "CheckListId = " + lId + " and RegType ='S'";
                dtC = dvC.ToTable();
                if (dtC.Rows.Count > 0)
                {
                    dtSupply.Columns["Sel"].DefaultValue = true;
                    dtSupply.Columns["Points"].DefaultValue = dtC.Rows[0]["Points"].ToString();
                }
                else
                {
                    dtSupply.Columns["Sel"].DefaultValue = false;
                    dtSupply.Columns["Points"].DefaultValue = 0;
                }
                dtSupply.Columns["ID"].DefaultValue = lId;
                dtSupply.Columns["Description"].DefaultValue = dt.Rows[lCount]["Description"].ToString();
                dtSupply.Columns["MaxPoints"].DefaultValue = dt.Rows[lCount]["MaxPoint"].ToString();
                dtSupply.Rows.Add();
            }

            grdASupply.DataSource = dtSupply;
      
            ASupplyView.Columns[0].Visible = false;
            ASupplyView.Columns[1].Width = 50;
            ASupplyView.Columns[2].Width = 200;
            ASupplyView.Columns[3].Width = 80;
            ASupplyView.Columns[4].Width = 80;
            ASupplyView.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ASupplyView.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ASupplyView.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            ASupplyView.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            ASupplyView.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            ASupplyView.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtASupply = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ASupplyView.Columns[4].ColumnEdit = txtASupply;
            txtASupply.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtASupply.Validating += new CancelEventHandler(txtASupply_Validating);

            ASupplyView.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            ASupplyView.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;

            ASupplyView.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            ASupplyView.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            
            ASupplyView.BestFitColumns();

            dt = new DataTable();
            dv = new DataView(m_tCheckList);
            dv.RowFilter = "Contract = true";
            dt = dv.ToTable();
            
  
            dtContract.Columns.Add("ID");
            dtContract.Columns.Add("Sel",typeof(Boolean));
            dtContract.Columns.Add("Description");
            dtContract.Columns.Add("MaxPoints");
            dtContract.Columns.Add("Points");
           
            for (lCount = 0; lCount < dt.Rows.Count; lCount++)
            {
                lId = Convert.ToInt32(dt.Rows[lCount]["CheckListId"].ToString());
                dtContract.Columns["ID"].DefaultValue = lId;
                dtC = new DataTable();
                dvC = new DataView(dtCheck);
                dvC.RowFilter = "CheckListId = " + lId + " and RegType ='C'";
                dtC = dvC.ToTable();
                if (dtC.Rows.Count > 0)
                {
                    dtContract.Columns["Sel"].DefaultValue = true;
                    dtContract.Columns["Points"].DefaultValue = dtC.Rows[0]["Points"].ToString();
                }
                else
                {
                    dtContract.Columns["Sel"].DefaultValue = false;
                    dtContract.Columns["Points"].DefaultValue = 0;
                }
                dtContract.Columns["Description"].DefaultValue = dt.Rows[lCount]["Description"].ToString();
                dtContract.Columns["MaxPoints"].DefaultValue = dt.Rows[lCount]["MaxPoint"].ToString();
                dtContract.Rows.Add();
            }
            grdAContract.DataSource = dtContract;
            
            AContractView.Columns[0].Visible = false;
            AContractView.Columns[1].Width = 50;
            AContractView.Columns[2].Width = 200;
            AContractView.Columns[3].Width = 80;
            AContractView.Columns[4].Width = 80;
            AContractView.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            AContractView.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            AContractView.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            AContractView.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            AContractView.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            AContractView.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtAContract = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            AContractView.Columns[4].ColumnEdit = txtAContract;
            txtAContract.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtAContract.Validating += new CancelEventHandler(txtAContract_Validating);

            AContractView.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            AContractView.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;

            AContractView.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            AContractView.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
          
            AContractView.BestFitColumns();
            

            dt = new DataTable();
            dv = new DataView(m_tCheckList);
            dv.RowFilter = "Service = true";
            dt = dv.ToTable();

            dtService.Columns.Add("ID");
            dtService.Columns.Add("Sel",typeof(Boolean));
            dtService.Columns.Add("Description");
            dtService.Columns.Add("MaxPoints");
            dtService.Columns.Add("Points");
      
            for (lCount = 0; lCount < dt.Rows.Count; lCount++)
            {
                lId = Convert.ToInt32(dt.Rows[lCount]["CheckListId"].ToString());
                dtService.Columns["ID"].DefaultValue = lId;
                dtC = new DataTable();
                dvC = new DataView(dtCheck);
                dvC.RowFilter = "CheckListId = " + lId + " and RegType ='H'";
                dtC = dvC.ToTable();
                if (dtC.Rows.Count > 0)
                {
                    dtService.Columns["Sel"].DefaultValue = true;
                    dtService.Columns["Points"].DefaultValue = dtC.Rows[0]["Points"].ToString();
                }
                else
                {
                    dtService.Columns["Sel"].DefaultValue = false;
                    dtService.Columns["Points"].DefaultValue = "";
                }
                dtService.Columns["Description"].DefaultValue = dt.Rows[lCount]["Description"].ToString();
                dtService.Columns["MaxPoints"].DefaultValue = dt.Rows[lCount]["MaxPoint"].ToString();
                dtService.Rows.Add();
            }
            grdAService.DataSource = dtService;
           
            AServiceView.Columns[0].Visible = false;
            AServiceView.Columns[1].Width = 50;
            AServiceView.Columns[2].Width = 200;
            AServiceView.Columns[3].Width = 80;
            AServiceView.Columns[4].Width = 80;
            AServiceView.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            AServiceView.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            AServiceView.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            AServiceView.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            AServiceView.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            AServiceView.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtAService = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            AServiceView.Columns[4].ColumnEdit = txtAService;
            txtAService.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtAService.Validating += new CancelEventHandler(txtAService_Validating);

            AServiceView.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            AServiceView.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;

            AServiceView.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            AServiceView.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            AServiceView.BestFitColumns();

        }

        private void CalculateContractGrid()
        {
            double dMax = 0;
            double dPoint = 0;
            double dPer = 0;
            for (int lCount = 0; lCount < AContractView.RowCount; lCount++)
            {
                System.Data.DataRow dr = AContractView.GetDataRow(lCount);
                String SelVal = dr[1].ToString();
                String MPVal = dr[3].ToString();
                String PVal = dr[4].ToString();
                if (Convert.ToBoolean(SelVal) == true)
                {
                    dMax = dMax + Convert.ToDouble(MPVal);
                    dPoint = dPoint + Convert.ToDouble(PVal);
                }
            }

            //grdAContractTotal.Columns["cTMaxPoints"].HeaderText = Convert.ToString(dMax);
            //grdAContractTotal.Columns["cTPoints"].HeaderText = Convert.ToString(dPoint);

            if (dMax != 0) { dPer = (dPoint / dMax) * 100; }

            GetGrade(dPer, "C");
        }

        private void CalculateServiceGrid()
        {
            double dMax = 0;
            double dPoint = 0;
            double dPer = 0;
            for (int lCount = 0; lCount < AServiceView.RowCount; lCount++)
            {
                System.Data.DataRow dr = AServiceView.GetDataRow(lCount);
                String SelVal = dr[1].ToString();
                String MPVal = dr[3].ToString();
                String PVal = dr[4].ToString();
                if (Convert.ToBoolean(SelVal) == true)
                {
                    dMax = dMax + Convert.ToDouble(MPVal);
                    dPoint = dPoint + Convert.ToDouble(PVal);
                }
            }

            //grdAServiceTotal.Columns["sTMaxPoints"].HeaderText = Convert.ToString(dMax);
            //grdAServiceTotal.Columns["sTPoints"].HeaderText = Convert.ToString(dPoint);

            if (dMax != 0) { dPer = (dPoint / dMax) * 100; }

            GetGrade(dPer, "H");
        }

        private void GetGrade(double argValue, string argType)
        {
            m_tGrade = new DataTable();
            m_tGrade = m_oGrade.GetGradeMaster();
            string sGradeName = "Nil";
            int lGradeId = 0;
            double dFValue = 0;
            double dTValue = 0;
            for (int lCount = 0; lCount < m_tGrade.Rows.Count; lCount++)
            {
                dFValue = Convert.ToDouble(m_tGrade.Rows[lCount]["FValue"].ToString());
                dTValue = Convert.ToDouble(m_tGrade.Rows[lCount]["TValue"].ToString());

                if ((argValue > dFValue) & (argValue <= dTValue | dTValue == 0))
                {
                    lGradeId = Convert.ToInt32(m_tGrade.Rows[lCount]["GradeId"].ToString());
                    sGradeName = m_tGrade.Rows[lCount]["GradeName"].ToString();
                    break;
                }

            }
            if (argType == "S") { txtASupply.Text = sGradeName; txtASupply.Tag = lGradeId; }
            if (argType == "C") { txtAContract.Text = sGradeName; txtAContract.Tag = lGradeId; }
            if (argType == "H") { txtAService.Text = sGradeName; txtAService.Tag = lGradeId; }

        }

        private void PopulateData()
        {
            PopulateMasterInfo(m_lVendorId);
            PopulateInfo();
        }

        private void AssignState(RadTreeNode nd, int state)
        {
            bool ck = state == 0;
            bool stateInvalid = nd.ImageIndex != state;
            if (stateInvalid) nd.ImageIndex = state;
            if (nd.Checked != ck)
            {
                nd.Checked = ck;

                if (ck == true)
                {
                    InsertMaterialGroup(Convert.ToInt32(nd.Tag), Convert.ToInt32(nd.Level), "", "");
                }
            }
            else if (stateInvalid)
            {
                InsertMaterialGroup(Convert.ToInt32(nd.Tag), Convert.ToInt32(nd.Level), "", "");
                //this.Invalidate(GetCheckRect(nd));
            }
        }

        private void InheritCheckstate(RadTreeNode nd, int state)
        {
            AssignState(nd, state);
            foreach (RadTreeNode ndChild in nd.Nodes)
            {
                InheritCheckstate(ndChild, state);
            }
        }

        private void InsertMaterialGroup(int argId, int argLevel, string CPerson, string CNo)
        {
            if (m_bMaterialCheck == false) { return; }
            m_oSupply.VendorId = m_lVendorId;
            m_oSupply.MaterialGroupId = argId;
            m_oSupply.MaterialId = argId;
            m_oSupply.Priority = "";
            m_oSupply.SupplyType = "";
            m_oSupply.LeadTime = txtLeadTime.Text == string.Empty ? 0 : Convert.ToInt32(txtLeadTime.Text);
            m_oSupply.CreditDays = txtMCredit.Text == string.Empty ? 0 : Convert.ToInt32(txtMCredit.Text);
            if (argLevel == 1)
            {
                m_oCapability.UpdateMaterialGroupTrans(m_oSupply);
                m_tMaterialGroupTrans = new DataTable();
                m_tMaterialGroupTrans = m_oCapability.GetMaterialGroupTrans(m_lVendorId);
            }
            else
            {
                m_oSupply.ContactPerson = CPerson.ToString();
                m_oSupply.ContactNo = CNo.ToString();
                m_oCapability.UpdateMaterialTrans(m_oSupply);
                m_tMaterialTrans = new DataTable();
                m_tMaterialTrans = m_oCapability.GetMaterialTrans(m_lVendorId);

            }
        }

        private void InsertMaterialTrans(int argResId)
        {
            if (m_bMaterialCheck == false) { return; }
            string pType = "";
            string sType = "";
            m_oSupply.VendorId = m_lVendorId;
            m_oSupply.MaterialId = argResId;
            if (cboPriority.Text == "High") { pType = "H"; }
            else if (cboPriority.Text == "Medium") { pType = "M"; }
            else if (cboPriority.Text == "Low") { pType = "L"; }
            if (cboSupplyType.Text == "Distributor") { sType = "S"; }
            else if (cboSupplyType.Text == "Dealer") { sType = "D"; }
            else if (cboSupplyType.Text == "Manufacturer") { sType = "M"; }
            m_oSupply.Priority = pType;
            m_oSupply.SupplyType = sType;
            m_oSupply.LeadTime = txtLeadTime.Text == string.Empty ? 0 : Convert.ToInt32(txtLeadTime.Text);
            m_oSupply.CreditDays = txtMCredit.Text == string.Empty ? 0 : Convert.ToInt32(txtMCredit.Text);
            m_oSupply.ContactPerson = txtCPerson.Text;
            m_oSupply.ContactNo = txtMCNo.Text;
            m_oSupply.Email = txtMEmail.Text;
            m_oCapability.UpdateMaterialTrans(m_oSupply);
            m_tMaterialTrans = m_oCapability.GetMaterialTrans(m_lVendorId);
            PopulateMaterial();
        }

        private void DeleteMaterialGroup(int argId, int argLevel)
        {
            if (m_bMaterialCheck == false) { return; }
            m_oSupply.VendorId = m_lVendorId;
            m_oSupply.MaterialGroupId = argId;
            m_oSupply.MaterialId = argId;
            m_oSupply.Priority = "";
            m_oSupply.SupplyType = "";
            m_oSupply.LeadTime = txtLeadTime.Text == string.Empty ? 0 : Convert.ToInt32(txtLeadTime.Text);
            m_oSupply.CreditDays = txtMCredit.Text == string.Empty ? 0 : Convert.ToInt32(txtMCredit.Text);
            if (argLevel == 1)
            {
                m_oCapability.DeleteMaterialGroupTrans(m_lVendorId, argId);
                //m_tMaterialGroupTrans = new DataTable();
                //m_tMaterialGroupTrans = m_oCapability.GetMaterialGroupTrans(m_lVendorId);
            }
            else
            {
                m_oCapability.DeleteMaterialTrans(m_lVendorId, argId);
                // m_tMaterialTrans = new DataTable();
                //m_tMaterialTrans = m_oCapability.GetMaterialTrans(m_lVendorId);

            }
        }

        private bool Validation()
        {
            bool valid = true;



            sb = new StringBuilder();

            if (txtName.Text.Trim() == string.Empty)
            {

                valid = false;
                sb.Append(" * Vendor Name not Empty" + Environment.NewLine);
                errorProvider1.SetError(txtName, "Vendor Name not Empty");
            }
            else
            {
                errorProvider1.SetError(txtName, "");
            }

            if (txtName.Text.Trim() != string.Empty)
            {
                string sVendorNameI = BsfGlobal.Insert_SingleQuot(txtName.Text);
                if (m_oVendor.CheckVendorName(m_lVendorId, sVendorNameI) == true)               
                {
                    MessageBox.Show("Vendor Name Already Found");
                    valid = false;
                }
            }

            //if (cboCity.SelectedIndex < 0)
            //{
            //    valid = false;
            //    sb.Append(" * Select City" + Environment.NewLine);
            //    errorProvider1.SetError(cboCity, "Select City");
            //}
            //else
            //{
            //    errorProvider1.SetError(cboCity, "");
            //}

            //if  (chkSupplier.Checked==false & chkContract.Checked==false & chkService.Checked==false)
            //{
            //    valid = false;
            //    sb.Append(" * Select Type" + Environment.NewLine);
            //    errorProvider1.SetError(lblType, "Select Type");
            //}

            //else
            //{
            //    errorProvider1.SetError(lblType, "");
            //}

            return valid;

        }

        private void panelContact_Validated(object sender, EventArgs e)
        {

            UpdateVendorContact(m_lVendorId);
        }

        private void UpdateVendorContact(int argVendorID)
        {
            if (m_bChange == false) { return; }

            m_oContact.VendorId = argVendorID;
            m_oContact.Address = txtCAddress.Text;
            m_oContact.Phone1 = txtPhone1.Text;
            m_oContact.Phone2 = txtPhone2.Text;
            m_oContact.Fax1 = txtFax1.Text;
            m_oContact.Fax2 = txtFax2.Text;
            m_oContact.Mobile1 = txtMobile1.Text;
            m_oContact.Mobile2 = txtMobile2.Text;
            m_oContact.CPerson1 = txtCPerson.Text;
            m_oContact.CPerson2 = txtAPerson.Text;
            m_oContact.CDesignation1 = txtCDesignation.Text;
            m_oContact.CDesignation2 = txtADesignation.Text;
            m_oContact.ContactNo1 = txtCContact.Text;
            m_oContact.ContactNo2 = txtAContactNo.Text;
            m_oContact.Email1 = txtEMail1.Text;
            m_oContact.Email2 = txtEMail2.Text;
            m_oContact.Web = txtWeb.Text;
            m_oContact.InsertVendorContact(m_oContact);
            string sVendorNameI = BsfGlobal.Insert_SingleQuot(m_oVendor.VendorName);
            BsfGlobal.InsertLog(DateTime.Now, "Vendor-Master-Edit", "E", sVendorNameI, argVendorID, 0, 0, BsfGlobal.g_sVendorDBName, sVendorNameI, BsfGlobal.g_lUserId);

            m_bChange = false;

            m_tVendorContactInfo = new DataTable();
            m_tVendorContactInfo = m_oContact.GetVendorContactInfo(m_lVendorId);
        }

        private void UpdateWorkGroup()
        {
            object sstr;
            ArrayList aWG = new ArrayList();
            for (int i = 0; i <= chkIWorkGroup.ItemCount - 1; i++)
            {
                if (chkIWorkGroup.GetItemCheckState(i) == CheckState.Checked)
                {
                    chkIWorkGroup.SetSelected(i, true);
                    sstr = chkIWorkGroup.SelectedValue;
                    //sstr=((System.Data.DataRowView)(chkIWorkGroup.SelectedItem)).Row.ItemArray[0];
                    aWG.Add(sstr);
                }
            }
            if (aWG.Count > 0)
            {
                m_oCapability.UpdateWorkGroup(aWG, m_lVendorId);

                m_tVWorkGroup = new DataTable();
                m_tVWorkGroup = m_oCapability.GetVWorkGroup(m_lVendorId);
            }
        }

        private void UpdateActivity()
        {
            object sstr;
            ArrayList aWG = new ArrayList();
            for (int i = 0; i <= chkActivity.ItemCount - 1; i++)
            {
                if (chkActivity.GetItemCheckState(i) == CheckState.Checked)
                {
                    chkActivity.SetSelected(i, true);
                    //sstr = chkActivity.SelectedValue;
                    sstr = ((System.Data.DataRowView)(chkActivity.SelectedItem)).Row.ItemArray[0];
                    aWG.Add(sstr);
                }
            }
            if (aWG.Count > 0)
            {
                m_oCapability.UpdateActivity(aWG, m_lVendorId);
                m_tActivtyTrans = new DataTable();
                m_tActivtyTrans = m_oCapability.GetActivityTrans(m_lVendorId);
            }
        }

        private void UpdateService()
        {
            object sstr;
            ArrayList aWG = new ArrayList();
            for (int i = 0; i <= chkServiceGroup.ItemCount - 1; i++)
            {
                if (chkServiceGroup.GetItemCheckState(i) == CheckState.Checked)
                {
                    chkServiceGroup.SetSelected(i, true);
                    sstr = chkServiceGroup.SelectedValue;
                    aWG.Add(sstr);
                }
            }
            if (aWG.Count > 0)
            {
                m_oCapability.UpdateService(aWG, m_lVendorId);


                m_tVService = new DataTable();
                m_tVService = m_oCapability.GetServiceTrans(m_lVendorId);
            }

        }

        private void UpdateHireMachinery()
        {
            object sstr;
            ArrayList aWG = new ArrayList();
            for (int i = 0; i <= chkHire.ItemCount - 1; i++)
            {
                if (chkHire.GetItemCheckState(i) == CheckState.Checked)
                {
                    chkHire.SetSelected(i, true);
                    //sstr = chkHire.SelectedValue;
                    sstr = ((System.Data.DataRowView)(chkHire.SelectedItem)).Row.ItemArray[0];
                    aWG.Add(sstr);
                }
            }
            if (aWG.Count > 0)
            {
                m_oCapability.UpdateHireMachinery(aWG, m_lVendorId);


                m_tHireMachineryTrans = new DataTable();
                m_tHireMachineryTrans = m_oCapability.GetHireMachineryTrans(m_lVendorId);
            }
        }

        private void UpdateCertificate()
        {
            object sstr;
            ArrayList aWG = new ArrayList();
            for (int i = 0; i <= chkCertificate.ItemCount - 1; i++)
            {
                if (chkCertificate.GetItemCheckState(i) == CheckState.Checked)
                {
                    chkCertificate.SetSelected(i, true);
                    sstr = chkCertificate.SelectedValue;
                    aWG.Add(sstr);
                }
            }
            if (aWG.Count > 0)
            {
                m_oCapability.UpdateCertificate(aWG, m_lVendorId);

                m_tCertificateTrans = new DataTable();
                m_tCertificateTrans = m_oCapability.GetCertificateTrans(m_lVendorId);
            }
        }

        private void UpdateLocation()
        {
            object sstr;
            m_aLocation = new ArrayList();
            for (int i = 0; i <= chkLocation.ItemCount - 1; i++)
            {
                if (chkLocation.GetItemCheckState(i) == CheckState.Checked)
                {
                    chkLocation.SetSelected(i, true);
                    sstr = chkLocation.SelectedValue;
                    m_aLocation.Add(sstr);
                }
            }
            if (m_aLocation.Count > 0)
            {
                m_oCapability.UpdateLocation(m_aLocation, m_lVendorId);

                m_tLocation = new DataTable();
                m_tLocation = m_oCapability.GetLocation(m_lVendorId);

            }
        }

        private void UpdateTransport()
        {
            object sstr;
            m_aTransport = new ArrayList();
            for (int i = 0; i <= chkTransport.ItemCount - 1; i++)
            {
                if (chkTransport.GetItemCheckState(i) == CheckState.Checked)
                {
                    chkTransport.SetSelected(i, true);
                    sstr = chkTransport.SelectedValue;
                    m_aTransport.Add(sstr);
                }
            }
            if (m_aTransport.Count > 0)
            {
                m_oCapability.UpdateTransport(m_aTransport, m_lVendorId);

                m_tTransport = new DataTable();
                m_tTransport = m_oCapability.GetTransport(m_lVendorId);

            }
        }

        private void UpdateTerms()
        {
            if (m_bChange == false) { return; }
            m_oTerms.VendorId = m_lVendorId;
            m_oTerms.CreditDays = txtCredit.Text == string.Empty ? 0 : Convert.ToInt32(txtCredit.Text);
            m_oTerms.MaxLeadTime = txtMaxLeadTime.Text == String.Empty ? 0 : Convert.ToInt32(txtMaxLeadTime.Text);
            m_oTerms.Terms = txtTerms.Text;

            m_oTerms.InsertTerms(m_oTerms);
            string sVendorNameI = BsfGlobal.Insert_SingleQuot(m_oVendor.VendorName);
            BsfGlobal.InsertLog(DateTime.Now, "Vendor-Master-Edit", "E", sVendorNameI, m_lVendorId, 0, 0, BsfGlobal.g_sVendorDBName, sVendorNameI, BsfGlobal.g_lUserId);
            m_bChange = false;

            m_tTerms = new DataTable();
            m_tTerms = m_oTerms.GetTerms(m_lVendorId);

        }

        private void UpdateVendorStatutory(int argVendorID)
        {
            if (m_bChange == false) { return; }

            m_oStatutory.VendorId = argVendorID;
            m_oStatutory.FirmType = txtFirm.Text;
            m_oStatutory.EYear = txtYear.Text == string.Empty ? 0 : Convert.ToInt32(txtYear.Text);
            m_oStatutory.PANNo = txtPANNo.Text;
            m_oStatutory.TANNo = txtTANNo.Text;
            m_oStatutory.CSTNo = txtCSTNo.Text;
            m_oStatutory.TINNo = txtTINNo.Text;
            m_oStatutory.BankAccountNo = txtAccountNo.Text;
            m_oStatutory.AccountType = (cboAccType.Text == "Current A/c" ? "C" : "S");
            m_oStatutory.BankName = txtBankName.Text;
            m_oStatutory.BranchName = txtBranch.Text;
            m_oStatutory.BranchCode = txtBranchCode.Text;
            m_oStatutory.ServiceTaxNo = txtSTaxNo.Text;
            m_oStatutory.TNGSTNo = txtTNGST.Text;
            m_oStatutory.MICRCode = txtMICR.Text;
            m_oStatutory.IFSCCode = txtIFSC.Text;

            //SSIREGDNo,ServiceTaxCir,EPFNo,ESINo,ExciseVendor,ExciseRegNo,Excisedivision,ExciseRange,ECCno
            m_oStatutory.SSIREGDNo = txtSSIREGD.Text;
            m_oStatutory.ServiceTaxCir = txtServiceTaxC.Text;
            m_oStatutory.EPFNo = txtEPFNo.Text;
            m_oStatutory.ESINo = txtESINo.Text;
            if (radioExciseV.SelectedIndex == 0) m_oStatutory.ExciseVendor = 1; else m_oStatutory.ExciseVendor = 0;          
            m_oStatutory.ExciseRegNo = txtExciseRegNo.Text;
            m_oStatutory.Excisedivision = txtExcisedivision.Text;
            m_oStatutory.ExciseRange = txtExciseRange.Text;
            m_oStatutory.ECCno = txtECCno.Text;


            m_oStatutory.InsertVendorStatutory(m_oStatutory);
           
            string sVendorNameI = BsfGlobal.Insert_SingleQuot(m_oVendor.VendorName);
            BsfGlobal.InsertLog(DateTime.Now, "Vendor-Master-Edit", "E", sVendorNameI, argVendorID, 0, 0, BsfGlobal.g_sVendorDBName, sVendorNameI, BsfGlobal.g_lUserId);
            m_bChange = false;

            m_tVendorStatutoryInfo = new DataTable();
            m_tVendorStatutoryInfo = m_oStatutory.GetVendorStatutory(m_lVendorId);

        }

        private void DocVisible()
        {
            if (m_lVendorId == 0)
            {
                dwGeneral.Show();
                dwContact.Hide();
            }
            else
            {
                dwContact.Show();
                dwGeneral.Hide();
            }

            dwBranch.Hide();
            dwStatutory.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();

        }

        private void MenuHide()
        {
            cmdSave.Visible = true;
            cmdGNext.Enabled = false;
            radMenuItem2.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            radMenuItem3.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            radMenuItem4.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            radMenuItem5.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            radMenuItem6.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            radMenuItem7.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            radMenuItem8.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            radMenuItem10.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            radMenuItem9.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
        }

        private void MenuShow()
        {
            cmdSave.Visible = false;
            cmdGNext.Enabled = true;
            radMenuItem2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            radMenuItem3.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            radMenuItem4.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            radMenuItem5.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            radMenuItem6.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            radMenuItem7.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            radMenuItem8.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            radMenuItem10.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            radMenuItem9.Visibility = Telerik.WinControls.ElementVisibility.Visible;
        }

        private void PopulateReg()
        {
            if (m_lVendorId == 0) { return; }
            frmRegistration frm = new frmRegistration();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            panelReg.Controls.Clear();
            panelReg.Controls.Add(frm);
            frm.Execute(m_lVendorId, txtName.Text);
        }

        private void PopulateMaterial()
        {
            dtMaterial = new DataTable();
            dtMaterial = m_oCapability.PopulateMaterial(m_lVendorId);
            grdMaterial.DataSource = dtMaterial;
            MatView.Columns["Code"].Width = 30;
            MatView.Columns["ResourceName"].Width = 70;
            MatView.Columns["Resource_ID"].Visible = false;
            MatView.Columns["ContactPerson"].Visible = false;
            MatView.Columns["Priority"].Visible = false;
            MatView.Columns["SupplyType"].Visible = false;
            MatView.Columns["LeadTime"].Visible = false;
            MatView.Columns["CreditDays"].Visible = false;
            MatView.Columns["ContactPerson"].Visible = false;
            MatView.Columns["ContactNo"].Visible = false;
            MatView.Columns["Email"].Visible = false;

        }

        private void MaterialSelect()
        {
            if (MatView.RowCount > 0)
            {
                if (MatView == null) { return; }
                if (MatView.GetFocusedRowCellValue("Resource_ID") == null) { return; }
                if (MatView.GetFocusedRowCellValue("Resource_ID").ToString() == "") { return; }
                PopulateMatCertificate(Convert.ToInt32(MatView.GetFocusedRowCellValue("Resource_ID")));
                cboPriority.Text = "---Select---";
                cboSupplyType.Text = "---Select---";
                txtLeadTime.Text = "0";
                txtCredit.Text = "0";
                txtMCPerson.Text = "";
                txtMCNo.Text = "";
                txtMEmail.Text = "";

                if (MatView.GetFocusedRowCellValue("Priority").ToString() != " ")
                {
                    if (MatView.GetFocusedRowCellValue("Priority").ToString() == "H") { cboPriority.Text = "High"; }
                    if (MatView.GetFocusedRowCellValue("Priority").ToString() == "M") { cboPriority.Text = "Medium"; }
                    if (MatView.GetFocusedRowCellValue("Priority").ToString() == "L") { cboPriority.Text = "Low"; }
                }

                if (MatView.GetFocusedRowCellValue("SupplyType").ToString() != " ")
                {
                    if (MatView.GetFocusedRowCellValue("SupplyType").ToString() == "S") { cboSupplyType.Text = "Distributor"; }
                    if (MatView.GetFocusedRowCellValue("SupplyType").ToString() == "D") { cboSupplyType.Text = "Dealer"; }
                    if (MatView.GetFocusedRowCellValue("SupplyType").ToString() == "M") { cboSupplyType.Text = "Manufacturer"; }

                }

                if (MatView.GetFocusedRowCellValue("LeadTime").ToString() != "")
                    txtLeadTime.Text = MatView.GetFocusedRowCellValue("LeadTime").ToString();

                if (MatView.GetFocusedRowCellValue("CreditDays").ToString() != "")
                    txtMCredit.Text = MatView.GetFocusedRowCellValue("CreditDays").ToString();

                if (MatView.GetFocusedRowCellValue("ContactPerson").ToString() != "")
                    txtMCPerson.Text = MatView.GetFocusedRowCellValue("ContactPerson").ToString();

                if (MatView.GetFocusedRowCellValue("ContactNo").ToString() != "")
                    txtMCNo.Text = MatView.GetFocusedRowCellValue("ContactNo").ToString();

                if (MatView.GetFocusedRowCellValue("Email").ToString() != "")
                    txtMEmail.Text = MatView.GetFocusedRowCellValue("Email").ToString();


            }
        }

        private void PopulateEnclosure()
        {
            dtEnclosure = new DataTable();
            dtEnclosure = m_oCapability.PopulateEnclosure(m_lVendorId);
            grdEnclosure.DataSource = dtEnclosure;
            EncView.Columns["EnclosureId"].Visible = false;
        }

        private void PopulateServiceType()
        {
            cboSType.Properties.DataSource = dtSType;
            cboSType.Properties.ForceInitialize();
            cboSType.Properties.PopulateColumns();
            cboSType.Properties.ValueMember = "ServiceTypeId";
            cboSType.Properties.DisplayMember = "ServiceType";
            cboSType.Properties.Columns["ServiceTypeId"].Visible = false;
            cboSType.Properties.ShowHeader = false;
            cboSType.Properties.ShowFooter = false;
            cboSType.EditValue = 0;
        }
        #endregion

        #region ButtonEvents

        void txtAService_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txtA = (DevExpress.XtraEditors.TextEdit)sender;

            if (Convert.ToDecimal(AServiceView.GetRowCellValue(AServiceView.FocusedRowHandle, "MaxPoints").ToString()) < Convert.ToDecimal(txtA.Text))
            {
                AServiceView.SetRowCellValue(AServiceView.FocusedRowHandle, "Points", AServiceView.GetRowCellValue(AServiceView.FocusedRowHandle, "MaxPoints").ToString());
            }
            else
            {
                AServiceView.SetRowCellValue(AServiceView.FocusedRowHandle, "Points", txtA.Text);
            }

            AServiceView.FocusedRowHandle = AContractView.FocusedRowHandle + 1;
        }
        
        void txtAContract_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txtA = (DevExpress.XtraEditors.TextEdit)sender;

            if (Convert.ToDecimal(AContractView.GetRowCellValue(AContractView.FocusedRowHandle, "MaxPoints").ToString()) < Convert.ToDecimal(txtA.Text))
            {
                AContractView.SetRowCellValue(AContractView.FocusedRowHandle, "Points", AContractView.GetRowCellValue(AContractView.FocusedRowHandle, "MaxPoints").ToString());
            }
            else
            {
                AContractView.SetRowCellValue(AContractView.FocusedRowHandle, "Points", txtA.Text);
            }

            AContractView.FocusedRowHandle = AContractView.FocusedRowHandle + 1;
        }
      
        void txtASupply_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txtA = (DevExpress.XtraEditors.TextEdit)sender;

            if (Convert.ToDecimal(ASupplyView.GetRowCellValue(ASupplyView.FocusedRowHandle, "MaxPoints").ToString()) < Convert.ToDecimal(txtA.Text))
            {
                ASupplyView.SetRowCellValue(ASupplyView.FocusedRowHandle, "Points", ASupplyView.GetRowCellValue(ASupplyView.FocusedRowHandle, "MaxPoints").ToString());
            }
            else
            {
                ASupplyView.SetRowCellValue(ASupplyView.FocusedRowHandle, "Points", txtA.Text);
            }

            ASupplyView.FocusedRowHandle = ASupplyView.FocusedRowHandle + 1;
        }

        //private void CalculateSupplyGrid()
        //{
        //    double dMax = 0;
        //    double dPoint = 0;
        //    double dPer = 0;
        //    for (int lCount = 0; lCount < ASupplyView.RowCount; lCount++)
        //    {
        //        System.Data.DataRow dr = ASupplyView.GetDataRow(lCount);
        //        String SeLVal = dr[1].ToString();
        //        String MpVal = dr[3].ToString();
        //        String PVal = dr[4].ToString();
        //        if (PVal == "")
        //        {
        //            PVal = "0";
        //        }
        //        if (Convert.ToBoolean(SeLVal) == true)
        //        {
        //            dMax = dMax + Convert.ToDouble(MpVal);
        //            dPoint = dPoint + Convert.ToDouble(PVal);
        //        }
        //    }

            //grdASupplyTotal.Columns["MaxPoints"].HeaderText = Convert.ToString(dMax);
        //    //grdASupplyTotal.Columns["Point"].HeaderText = Convert.ToString(dPoint);

        //    if (dMax != 0) { dPer = (dPoint / dMax) * 100; }

        //    GetGrade(dPer, "S");
        //}

        private void documentTabStrip3_Click(object sender, EventArgs e)
        {
            PopulateCapability();

        }

        private void tvMaterial_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {

            //m_lMaterialId = 0;
            //m_lMaterialLevel = 0;

            //cboPriority.SelectedIndex = -1;
            //cboSupplyType.SelectedIndex = -1;
            //txtLeadTime.Text = "";
            //txtMCredit.Text = "";


            //if (tvMaterial.SelectedNode != null)
            //{
            //    grpMaterial.Text = tvMaterial.SelectedNode.Text;
            //    if (tvMaterial.SelectedNode.Checked == true)
            //    {
            //        grpMaterial.Enabled = true;
            //        m_lMaterialId = Convert.ToInt32(tvMaterial.SelectedNode.Tag);
            //        m_lMaterialLevel = tvMaterial.SelectedNode.Level;
            //        DataView dv;
            //        DataTable dt = null;
            //        if (tvMaterial.SelectedNode.Level == 1)
            //        {

            //            if (m_tMaterialGroupTrans != null)
            //            {
            //                dv = new DataView(m_tMaterialGroupTrans);
            //                dv.RowFilter = "VendorId = " + m_lVendorId + " and Resource_Group_ID = " + m_lMaterialId;
            //                dt = dv.ToTable();
            //            }
            //        }
            //        else if (tvMaterial.SelectedNode.Level == 2)
            //        {
            //            if (m_tMaterialTrans != null)
            //            {
            //                dv = new DataView(m_tMaterialTrans);
            //                dv.RowFilter = "VendorId = " + m_lVendorId + " and Resource_ID = " + m_lMaterialId;
            //                dt = dv.ToTable();
            //            }



            //            if (dt.Rows.Count > 0)
            //            {
            //                if (dt.Rows[0]["Priority"].ToString() == "H") { cboPriority.Text = "High"; }
            //                else if (dt.Rows[0]["Priority"].ToString() == "M") { cboPriority.Text = "Medium"; }
            //                else if (dt.Rows[0]["Priority"].ToString() == "L") { cboPriority.Text = "Low"; }

            //                if (dt.Rows[0]["SupplyType"].ToString() == "S") { cboSupplyType.Text = "Distributor"; }
            //                else if (dt.Rows[0]["SupplyType"].ToString() == "D") { cboSupplyType.Text = "Dealer"; }
            //                else if (dt.Rows[0]["SupplyType"].ToString() == "M") { cboSupplyType.Text = "Manufacturer"; }

            //                txtLeadTime.Text = dt.Rows[0]["LeadTime"].ToString();
            //                txtMCredit.Text = dt.Rows[0]["CreditDays"].ToString();
            //            }
            //        }
            //    }
            //    else
            //    {
            //       // grpMaterial.Enabled = false;
            //        //cboPriority.SelectedIndex = -1;
            //        //cboSupplyType.SelectedIndex = -1;
            //        //txtLeadTime.Text = "";
            //        //txtMCredit.Text = "";
            //    }
            //}        
        }

        private void nbSupply_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            HistoryView.Columns.Clear();
            m_tHistory = new DataTable();
            m_tHistory = m_oHistory.GetSupplyDetails(m_lVendorId);
            DataView dv;
            dv = new DataView(m_tHistory);
            grdHistory.DataSource = dv.ToTable();
            //DataGridViewCellStyle d = new DataGridViewCellStyle();
            //d.Alignment = DataGridViewContentAlignment.TopRight;
            //d.Format = "F2";
            //grdHistory.Columns[5].DefaultCellStyle = d;  
            HistoryView.Columns[0].Width = 70;
            HistoryView.Columns[1].Width = 82;
            HistoryView.Columns[2].Width = 92;
            HistoryView.Columns[3].Width = 82;
            HistoryView.Columns[4].Width = 145;
            HistoryView.Columns[5].Width = 90;
            HistoryView.Columns[5].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[5].DisplayFormat.FormatString = "F2";

        }

        private void nbOrder_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            HistoryView.Columns.Clear();
            m_tHistory = new DataTable();
            m_tHistory = m_oHistory.GetOrderDetails(m_lVendorId);
            //DataView dv;
            //dv = new DataView(m_tHistory);
            grdHistory.DataSource = m_tHistory;
            //DataGridViewCellStyle d = new DataGridViewCellStyle();
            //d.Alignment = DataGridViewContentAlignment.TopRight;
            //d.Format = "F2";
            //grdHistory.Columns[3].DefaultCellStyle = d; 
            HistoryView.Columns[0].Width = 90;
            HistoryView.Columns[1].Width = 100;
            HistoryView.Columns[2].Width = 232;
            HistoryView.Columns[3].Width = 140;
            HistoryView.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[3].DisplayFormat.FormatString = "F2";

        }

        private void nbPendingOrders_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            HistoryView.Columns.Clear();
            m_tHistory = new DataTable();
            m_tHistory = m_oHistory.GetPendingDetails(m_lVendorId);
            sLink = "PendingOrder";
            //DataView dv;
            //dv = new DataView(m_tHistory);
            grdHistory.DataSource = m_tHistory;
            HistoryView.Columns[8].Visible = false;
            HistoryView.Columns[9].Visible = false;
            HistoryView.Columns[10].Visible = false;
            //DataGridViewCellStyle d = new DataGridViewCellStyle();
            // d.Alignment = DataGridViewContentAlignment.TopRight;
            //d.Format = "F2";
            //grdHistory.Columns[5].DefaultCellStyle = d;
            //grdHistory.Columns[6].DefaultCellStyle = d;
            //grdHistory.Columns[7].DefaultCellStyle = d;
            HistoryView.Columns[0].Width = 70;
            HistoryView.Columns[1].Width = 80;
            HistoryView.Columns[2].Width = 140;
            HistoryView.Columns[3].Width = 180;
            HistoryView.Columns[4].Width = 70;
            HistoryView.Columns[5].Width = 90;
            HistoryView.Columns[6].Width = 90;
            HistoryView.Columns[7].Width = 90;
            HistoryView.Columns[5].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[6].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[7].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[5].DisplayFormat.FormatString = "F2";
            HistoryView.Columns[6].DisplayFormat.FormatString = "F2";
            HistoryView.Columns[7].DisplayFormat.FormatString = "F2";

        }

        private void nbPendingBills_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            HistoryView.Columns.Clear();
            m_tHistory = new DataTable();
            m_tHistory = m_oHistory.GetPendingBills(m_lVendorId);
            //DataView dv;
            //dv = new DataView(m_tHistory);
            grdHistory.DataSource = m_tHistory;
            //DataGridViewCellStyle d = new DataGridViewCellStyle();
            //d.Alignment = DataGridViewContentAlignment.TopRight;
            //d.Format = "F2";
            //grdHistory.Columns[5].DefaultCellStyle = d;
            //grdHistory.Columns[6].DefaultCellStyle = d;
            //grdHistory.Columns[7].DefaultCellStyle = d;
            HistoryView.Columns[0].Width = 70;
            HistoryView.Columns[1].Width = 80;
            HistoryView.Columns[2].Width = 70;
            HistoryView.Columns[3].Width = 80;
            HistoryView.Columns[4].Width = 180;
            HistoryView.Columns[5].Width = 95;
            HistoryView.Columns[6].Width = 95;
            HistoryView.Columns[7].Width = 100;
            HistoryView.Columns[5].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[6].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[7].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[5].DisplayFormat.FormatString = "F2";
            HistoryView.Columns[6].DisplayFormat.FormatString = "F2";
            HistoryView.Columns[7].DisplayFormat.FormatString = "F2";
        }

        private void nbRejected_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            HistoryView.Columns.Clear();
            m_tHistory = new DataTable();
            m_tHistory = m_oHistory.GetRejected(m_lVendorId);
            //DataView dv;
            //dv = new DataView(m_tHistory);
            grdHistory.DataSource = m_tHistory;
            //    DataGridViewCellStyle d = new DataGridViewCellStyle();
            //    d.Alignment = DataGridViewContentAlignment.TopRight;
            //    d.Format = "F2";
            //    grdHistory.Columns[4].DefaultCellStyle = d;
            HistoryView.Columns[0].Width = 90;
            HistoryView.Columns[1].Width = 90;
            HistoryView.Columns[2].Width = 180;
            HistoryView.Columns[3].Width = 180;
            HistoryView.Columns[4].Width = 100;
            //HistoryView.Columns[5].Width = 85;
            HistoryView.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[4].DisplayFormat.FormatString = "F2";
        }

        private void nbReturns_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            HistoryView.Columns.Clear();
            m_tHistory = new DataTable();
            m_tHistory = m_oHistory.GetReturns(m_lVendorId);
            //DataView dv;
            //dv = new DataView(m_tHistory);
            grdHistory.DataSource = m_tHistory;
            //DataGridViewCellStyle d = new DataGridViewCellStyle();
            //d.Alignment = DataGridViewContentAlignment.TopRight;
            //d.Format = "F2";
            //grdHistory.Columns[5].DefaultCellStyle = d;
            HistoryView.Columns[0].Width = 70;
            HistoryView.Columns[1].Width = 80;
            HistoryView.Columns[2].Width = 80;
            HistoryView.Columns[3].Width = 80;
            HistoryView.Columns[4].Width = 180;
            HistoryView.Columns[5].Width = 100;
            HistoryView.Columns[5].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[5].DisplayFormat.FormatString = "F2";
        }

        private void toolStripExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BsfGlobal.ClearUserUsage("Vendor-Master-Edit", m_lVendorId, BsfGlobal.g_sVendorDBName);
            this.Close();
            //frmvm.option = "fMain";
            //frmvm.PopulateVendor();
            //clsStatic.DW2.Hide();
            //clsStatic.DW1.Show();     

        }

        private void cmdAddCity_Click(object sender, EventArgs e)
        {
            int lCityId = 0;
            if (m_tCity.Rows.Count >= 0) { lCityId = Convert.ToInt32(cboCity.EditValue); }
            frmCityMaster CityMaster = new frmCityMaster();
            CityMaster.ShowDialog();
            PopulateVendorIntialData();
            PopulateCity();
            if (lCityId != 0) { cboCity.EditValue = lCityId; }
        }

        private void panelMaster_Validated(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }
            if (m_bChange == false) { return; }
            if (Validation() == true)
            {
                if (m_lVendorId != 0)
                {
                    //if (Convert.ToInt32(clsStatic.IsNullCheck(cboCity.EditValue, clsStatic.datatypes.vartypenumeric)) == 0 || Convert.ToInt32(clsStatic.IsNullCheck(cboCity.EditValue, clsStatic.datatypes.vartypenumeric)) == -1)
                    //{
                    //    MessageBox.Show("Select City!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    string sTypeM="";
                    m_oVendor.VendorId = m_lVendorId;
                    
                    m_oVendor.VendorName = txtName.Text;
                    m_oVendor.Supply = chkSupplier.Checked;
                    m_oVendor.Contract = chkContractor.Checked;
                    m_oVendor.Service = chkService.Checked;
                    m_oVendor.RegAddress = txtAddress1.Text;
                    m_oVendor.CityId = Convert.ToInt32(cboCity.EditValue);
                    m_oVendor.PinNo = txtPin.Text;
                    m_oVendor.STypeId = Convert.ToInt32(clsStatic.IsNullCheck(cboSType.EditValue, clsStatic.datatypes.vartypenumeric));
                    if (chkSupplier.Checked == true && chkContractor.Checked == false && chkService.Checked == false)
                    {
                        m_oVendor.STypeId = 0;
                    }
                    if (chkSupplier.Checked == true)
                    {
                        if (comboBoxEdit1.Text == "Distributor") { sTypeM = "S"; }
                        else if (comboBoxEdit1.Text == "Dealer") { sTypeM = "D"; }
                        else if (comboBoxEdit1.Text == "Manufacturer") { sTypeM = "M"; }
                    }
                    m_oVendor.SuppTypeId = sTypeM;
                    m_oVendor.ChequeNo = txtCheque.Text;
                    m_oVendor.Code = TxtCode.Text.Trim();
                    if (rgIsCompany.SelectedIndex == 0) m_oVendor.iCompany = 1; else m_oVendor.iCompany = 0;
                    m_oVendor.UpdateVendorMaster(m_oVendor);
                    string sVendorNameI = BsfGlobal.Insert_SingleQuot(m_oVendor.VendorName);
                    BsfGlobal.InsertLog(DateTime.Now, "Vendor-Master-Edit", "E", sVendorNameI, m_lVendorId, 0, 0, BsfGlobal.g_sVendorDBName, sVendorNameI, BsfGlobal.g_lUserId);
                    m_bChange = false;

                    m_tVendorMasterInfo = new DataTable();
                    m_tVendorMasterInfo = m_oVendor.GetVendorMasterInfo(m_lVendorId);

                }
            }
        }

        private void toolStripFind_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVendorFilter Filter = new frmVendorFilter();
            if (Filter.Execute() != "")
            {
                m_bFilter = true;
            }
        }

        private void toolStripPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sValue = "";
            string sValue1 = "''";
            if (m_bFilter == true)
            {

                ////for (lCount = 0; lCount <= VendorView.RowCount - 1; lCount++)
                ////{
                ////    System.Data.DataRow dr = VendorView.GetDataRow(lCount);
                ////    String drVal1 = dr[1].ToString();
                ////    object value = drVal1.ToString().Trim();
                ////    sValue = sValue + "''" + value + "''" + ",";
                ////}
                sValue1 = sValue.TrimEnd(',');
                sValue1 = "'" + sValue1 + "'";
            }
            frmReport objReport = new frmReport();
            string strReportPath = Application.StartupPath + "\\VendorDetails.Rpt";
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(strReportPath);
            cryRpt.SetParameterValue("@VName", sValue1);
            string[] DataFiles = new string[] { BsfGlobal.g_sVendorDBName };
            objReport.ReportConvert(cryRpt, DataFiles);
            objReport.rptViewer.ReportSource = null;
            objReport.rptViewer.ReportSource = cryRpt;
            objReport.rptViewer.Refresh();
            objReport.Show();
        }

        private void toolStripAlerts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAlert Alert = new frmAlert();
            Alert.Execute();
        }

        private void toolStripCheckList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCheckList CheckList = new frmCheckList();
            CheckList.Execute();
        }

        private void toolStripGrade_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGrade Grade = new frmGrade();
            Grade.Execute();
        }

        public void cmdBranchAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int lBranchId = 0;
            DataTable dt = null;
            frmBranch Branch = new frmBranch();
            if (Branch.Execute(lBranchId, dt, m_tCity, m_lVendorId, this) == true)
            {
                m_tVendorBranch = new DataTable();
                m_tVendorBranch = m_oBranch.GetBrachList(m_lVendorId);
                PopulateBranch(m_lVendorId);
            }
        }

        private void cmdBranchEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BranchView.GetFocusedRow() != null)
            {
                if (BranchView.FocusedRowHandle >= 0)
                {
                    System.Data.DataRow dr = BranchView.GetDataRow(BranchView.FocusedRowHandle);
                    String BranchVal = dr["BranchID"].ToString();
                    int lBranchId = Convert.ToInt32(BranchVal.ToString());

                    DataView dv;
                    DataTable dt;
                    if (m_tVendorBranch != null)
                    {
                        dv = new DataView(m_tVendorBranch);
                        dv.RowFilter = "BranchId = " + lBranchId;
                        dt = dv.ToTable();

                        frmBranch Branch = new frmBranch();
                        if (Branch.Execute(lBranchId, dt, m_tCity, m_lVendorId, this) == true)
                        {
                            m_tVendorBranch = new DataTable();
                            m_tVendorBranch = m_oBranch.GetBrachList(m_lVendorId);
                            PopulateBranch(m_lVendorId);
                        }
                    }

                }
            }
        }

        private void cmdBranchDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BranchView.GetFocusedRow() != null)
            {
                if (BranchView.FocusedRowHandle >= 0)
                {
                    DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (reply == DialogResult.Yes)
                    {
                        System.Data.DataRow dr = BranchView.GetDataRow(BranchView.FocusedRowHandle);
                        String BranchVal = dr["BranchId"].ToString();
                        int Id = 0;
                        Id = Convert.ToInt32(BranchVal.ToString());
                        m_oBranch.DeleteBranch(Id);
                        //grdBranch.Rows.RemoveAt(grdBranch.CurrentRow.Index);
                        BranchView.DeleteRow(BranchView.FocusedRowHandle);
                        m_tVendorBranch = new DataTable();
                        m_tVendorBranch = m_oBranch.GetBrachList(m_lVendorId);

                    }
                }
            }
        }

        private void cmdEAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int lExpId = 0;
            DataTable dt = null;
            frmExperience Exp = new frmExperience();
            if (Exp.Execute(lExpId, m_lVendorId, dt) == true)
            {
                m_tExperience = new DataTable();
                m_tExperience = m_oExperience.GetExperience(m_lVendorId);
                PopulateExperience(m_lVendorId);
            }
        }

        private void cmdEEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ExpView.GetFocusedRow() != null)
            {
                if (ExpView.FocusedRowHandle >= 0)
                {
                    System.Data.DataRow dr = ExpView.GetDataRow(ExpView.FocusedRowHandle);
                    String ExpVal = dr["ExperienceID"].ToString();
                    int lExpId = Convert.ToInt32(ExpVal.ToString());
                    DataView dv;
                    DataTable dt;
                    if (m_tExperience != null)
                    {
                        dv = new DataView(m_tExperience);
                        dv.RowFilter = "ExperienceID = " + lExpId;
                        dt = dv.ToTable();

                        frmExperience Exp = new frmExperience();
                        if (Exp.Execute(lExpId, m_lVendorId, dt) == true)
                        {
                            m_tExperience = new DataTable();
                            m_tExperience = m_oExperience.GetExperience(m_lVendorId);
                            PopulateExperience(m_lVendorId);
                        }
                    }
                }
            }
        }

        private void cmdEDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ExpView.GetFocusedRow() != null)
            {
                if (ExpView.FocusedRowHandle >= 0)
                {
                    DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (reply == DialogResult.Yes)
                    {
                        System.Data.DataRow dr = ExpView.GetDataRow(ExpView.FocusedRowHandle);
                        String ExpVal = dr["ExperienceID"].ToString();
                        int Id = 0;
                        Id = Convert.ToInt32(ExpVal.ToString());
                        m_oExperience.DeleteExperience(Id);
                        //grdExperience.Rows.RemoveAt(grdExperience.CurrentRow.Index);
                        ExpView.DeleteRow(ExpView.FocusedRowHandle);
                        m_tExperience = new DataTable();
                        m_tExperience = m_oExperience.GetExperience(m_lVendorId);

                    }
                }
            }
        }

        private void toolStripMachineAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            frmResource Resource = new frmResource();
            dt = Resource.Execute("A");
            if (dt != null)
            {
                DataRow dr;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = m_tMachinerySub.NewRow();
                    dr["Resource_ID"] = dt.Rows[i]["Resource_ID"].ToString();
                    dr["VendorID"] = m_lVendorId;
                    dr["Resource_Name"] = dt.Rows[i]["Resource_Name"].ToString();
                    dr["Unit_Name"] = dt.Rows[i]["Unit_Name"].ToString();
                    dr["Qty"] = "0";
                    dr["Capacity"] = "";
                    m_tMachinerySub.Rows.Add(dr);
                }
            }
        }

        private void toolStripMachineDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MachView.GetFocusedRow() != null)
            {
                int hrow = MachView.FocusedRowHandle;
                if (MachView.IsNewItemRow(hrow) == true) { return; }
                //if (grdMachinery.CurrentRow.IsNewRow == true) { return; }
                System.Data.DataRow dr = MachView.GetDataRow(MachView.FocusedRowHandle);
                String MachVal = dr["MachineryTransId"].ToString();
                int Id = 0;
                if (MachVal != "")
                {
                    Id = Convert.ToInt32(MachVal.ToString());
                }
                if (MachView.FocusedRowHandle >= 0)
                {
                    if (Id != 0)
                    {
                        DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (reply == DialogResult.Yes)
                        {


                            m_oCapability.DeleteMachinery(Id);
                            //grdMachinery.Rows.RemoveAt(grdMachinery.CurrentRow.Index);
                            MachView.DeleteRow(MachView.FocusedRowHandle);
                            m_tMachinery = new DataTable();
                            m_tMachinery = m_oCapability.GetMachinery(m_lVendorId);

                        }
                    }
                    else
                        MachView.DeleteRow(MachView.FocusedRowHandle);
                }
            }
        }

        private void toolStripTechDell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TPView.GetFocusedRow() != null)
            {
                int hrow = TPView.FocusedRowHandle;
                if (TPView.IsNewItemRow(hrow) == true) { return; }
                //if (grdTechPerson.CurrentRow.IsNewRow == true) { return; }
                if (TPView.FocusedRowHandle >= 0)
                {
                    DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (reply == DialogResult.Yes)
                    {
                        System.Data.DataRow dr = TPView.GetDataRow(TPView.FocusedRowHandle);
                        String TPVal = dr["TechPersonId"].ToString();
                        int Id = 0;
                        Id = Convert.ToInt32(TPVal.ToString());

                        m_oCapability.DeleteTechPerson(Id);
                        //grdTechPerson.Rows.RemoveAt(grdTechPerson.CurrentRow.Index);
                        TPView.DeleteRow(TPView.FocusedRowHandle);
                        m_tTechPersons = new DataTable();
                        m_tTechPersons = m_oCapability.GetTechPersons(m_lVendorId);

                    }
                }
            }
        }

        private void cmdSDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TOView.GetFocusedRow() != null)
            {
                int hrow = TOView.FocusedRowHandle;
                if (TOView.IsNewItemRow(hrow) == true) { return; }
                //if (grdTurnOver.CurrentRow.IsNewRow == true) { return; }
                if (TOView.FocusedRowHandle >= 0)
                {
                    DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (reply == DialogResult.Yes)
                    {
                        System.Data.DataRow dr = TOView.GetDataRow(TOView.FocusedRowHandle);
                        String TOVal = dr["TurnOverID"].ToString();
                        int Id = 0;
                        Id = Convert.ToInt32(TOVal.ToString());

                        m_oCapability.DeleteTurnOver(Id);
                        //grdTurnOver.Rows.RemoveAt(grdTurnOver.CurrentRow.Index);
                        TOView.DeleteRow(TOView.FocusedRowHandle);

                        m_tTurnOver = new DataTable();
                        m_tTurnOver = m_oCapability.GetTurnOver(m_lVendorId);

                    }
                }
            }
        }

        private void toolStripCer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCertificate Cer = new frmCertificate();
            Cer.Execute();

            m_tCertificate = new DataTable();
            m_tCertificate = m_oCer.GetCertificate();

            PopulateCertificateTrans();
        }

        private void toolStripLocation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCityMaster CityMaster = new frmCityMaster();
            CityMaster.ShowDialog();
            PopulateLocation();
        }

        private void dwCContract_Validated(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }
            UpdateWorkGroup();
            UpdateActivity();
        }

        private void dwCService_Validated(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }
            UpdateService();
            UpdateHireMachinery();
        }

        private void dwCertificate_Validated(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }
            UpdateCertificate();
            UpdateLocation();
            UpdateTransport();
        }

        private void dwFinancial_Validated(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }
            if (m_tTurnOverSub.GetChanges() != null)
            {
                m_oCapability.m_oVendorId = m_lVendorId;
                m_oCapability.UpdateTurnOver(m_tTurnOverSub);

                m_tTurnOver = new DataTable();
                m_tTurnOver = m_oCapability.GetTurnOver(m_lVendorId);

            }
        }

        private void dwResource_Validated(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }

            if (m_tManPowerSub != null)
            {
                if (m_tManPowerSub.GetChanges() != null)
                {
                    m_oCapability.UpdateManPower(m_tManPowerSub);

                    m_tManPower = new DataTable();
                    m_tManPower = m_oCapability.GetManPower(m_lVendorId);
                }
            }
            if (m_tMachinerySub != null)
            {
                if (m_tMachinerySub.GetChanges() != null)
                {
                    m_oCapability.UpdateMachinery(m_tMachinerySub);

                    m_tMachinery = new DataTable();
                    m_tMachinery = m_oCapability.GetMachinery(m_lVendorId);

                }
            }
            if (m_tTechPersonSub != null)
            {
                if (m_tTechPersonSub.GetChanges() != null)
                {
                    m_oCapability.m_oVendorId = m_lVendorId;
                    m_oCapability.UpdateTechPerson(m_tTechPersonSub);

                    m_tTechPersons = new DataTable();
                    m_tTechPersons = m_oCapability.GetTechPersons(m_lVendorId);
                }
            }
        }

        private void dwRegistration_Validated(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }

            if (ASupplyView.RowCount > 0 || AServiceView.RowCount > 0 || AContractView.RowCount > 0)
            {
                m_oRegister.VendorId = m_lVendorId;
                //m_oRegister.Registered = chkRegister.Checked;
                //m_oRegister.RegDate = dtpRegDate.Value;
                //m_oRegister.RegNo = txtRegNo.Text;
                m_oRegister.SGradeId = Convert.ToInt32(txtASupply.Tag);
                m_oRegister.CGradeId = Convert.ToInt32(txtAContract.Tag);
                m_oRegister.HGradeId = Convert.ToInt32(txtAService.Tag);
                //m_oRegister.UpdateGradeTrans(m_oRegister);
                m_oRegister.DeleteCheckListTrans(m_lVendorId);
            }


            for (int lCount = 0; lCount < ASupplyView.RowCount; lCount++)
            {
                System.Data.DataRow dr = ASupplyView.GetDataRow(lCount);
                String IDVal = dr["ID"].ToString();
                String PointsVal = dr["Points"].ToString();
                if (Convert.ToBoolean(dr["Sel"]) == true)
                {
                    m_oCheckList.VendorId = m_lVendorId;
                    m_oCheckList.CheckListId = Convert.ToInt32(IDVal);
                    m_oCheckList.RegType = "S";
                    m_oCheckList.Points = Convert.ToDouble(PointsVal);

                    m_oRegister.InsertCheckListTrans(m_oCheckList);

                }
            }

            for (int lCount = 0; lCount < AContractView.RowCount; lCount++)
            {
                System.Data.DataRow dr = AContractView.GetDataRow(lCount);
                String cSelVal = dr["Sel"].ToString();
                String cIDVal = dr["ID"].ToString();
                String cPointsVal = dr["Points"].ToString();
                if (cPointsVal == "")
                {
                    cPointsVal = "0";
                }
                if (Convert.ToBoolean(cSelVal) == true)
                {
                    m_oCheckList.VendorId = m_lVendorId;
                    m_oCheckList.CheckListId = Convert.ToInt32(cIDVal);
                    m_oCheckList.RegType = "C";
                    m_oCheckList.Points = Convert.ToDouble(cPointsVal);

                    m_oRegister.InsertCheckListTrans(m_oCheckList);

                }
            }

            for (int lCount = 0; lCount < AServiceView.RowCount; lCount++)
            {
                System.Data.DataRow dr = AServiceView.GetDataRow(lCount);
                String sSelVal = dr["Sel"].ToString();
                String sIDVal = dr["ID"].ToString();
                String sPointsVal = dr["Points"].ToString();
                if (sPointsVal == "")
                {
                    sPointsVal = "0";
                }
                if (Convert.ToBoolean(sSelVal) == true)
                {
                    m_oCheckList.VendorId = m_lVendorId;
                    m_oCheckList.CheckListId = Convert.ToInt32(sIDVal);
                    m_oCheckList.RegType = "H";
                    m_oCheckList.Points = Convert.ToDouble(sPointsVal);

                    m_oRegister.InsertCheckListTrans(m_oCheckList);

                }
            }
            if (ASupplyView.RowCount > 0)
            {
                m_oRegister.SupplyMaxPoint = Convert.ToDouble(clsStatic.IsNullCheck(ASupplyView.Columns["MaxPoints"].SummaryText,clsStatic.datatypes.vartypenumeric));
                m_oRegister.SupplyPoints = Convert.ToDouble(clsStatic.IsNullCheck(ASupplyView.Columns["Points"].SummaryText,clsStatic.datatypes.vartypenumeric));
                m_oRegister.ContractMaxPoint = 0;
                m_oRegister.ContractPoints = 0;
                m_oRegister.ServiceMaxPoint = 0;
                m_oRegister.ServicePoints = 0;
                m_oRegister.InsertAssessment(m_oRegister);
            }
            if (AContractView.RowCount > 0)
            {
                m_oRegister.SupplyMaxPoint = 0;
                m_oRegister.SupplyPoints = 0;
                m_oRegister.ContractMaxPoint = Convert.ToDouble(clsStatic.IsNullCheck(AContractView.Columns["MaxPoints"].SummaryText,clsStatic.datatypes.vartypenumeric));
                m_oRegister.ContractPoints = Convert.ToDouble(clsStatic.IsNullCheck(AContractView.Columns["Points"].SummaryText,clsStatic.datatypes.vartypenumeric));
                m_oRegister.ServiceMaxPoint = 0;
                m_oRegister.ServicePoints = 0;
                m_oRegister.InsertAssessment(m_oRegister);
            }
            if (AServiceView.RowCount > 0)
            {
                m_oRegister.SupplyMaxPoint = 0;
                m_oRegister.SupplyPoints = 0;
                m_oRegister.ContractMaxPoint = 0;
                m_oRegister.ContractPoints = 0;
                m_oRegister.ServiceMaxPoint = Convert.ToDouble(clsStatic.IsNullCheck(AServiceView.Columns["MaxPoints"].SummaryText,clsStatic.datatypes.vartypenumeric));
                m_oRegister.ServicePoints = Convert.ToDouble(clsStatic.IsNullCheck(AServiceView.Columns["Points"].SummaryText,clsStatic.datatypes.vartypenumeric));
                m_oRegister.InsertAssessment(m_oRegister);
            }
        }

        private void dwTerms_Validated(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }
            UpdateTerms();
        }

        private void PanelStatutory_Validated(object sender, EventArgs e)
        {
            UpdateVendorStatutory(m_lVendorId);
        }

        private void documentTabStrip3_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCapability();
        }

        private void grpLogistics_Validated(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }
            if (m_bChange == false) { return; }
            m_oLogistics.TransportMode = "";
            m_oLogistics.TransportArrange = "";
            m_oLogistics.Delivery = "";


            m_oLogistics.VendorId = m_lVendorId;

            if (cboTrans.Text == "Own") { m_oLogistics.TransportArrange = "O"; }
            else if (cboTrans.Text == "Third Party") { m_oLogistics.TransportArrange = "T"; }
            else if (cboTrans.Text == "Arranged by Us") { m_oLogistics.TransportArrange = "U"; }

            m_oLogistics.TransportMode = txtTransMode.Text;

            if (cboDelivery.Text == "Delivery Address") { m_oLogistics.Delivery = "D"; }
            else if (cboDelivery.Text == "Specific Location") { m_oLogistics.Delivery = "S"; }

            if (cboInsurance.Text == "Yes") { m_oLogistics.Insurance = "Y"; }
            else { m_oLogistics.Insurance = "N"; }

            if (cboUnload.Text == "Yes") { m_oLogistics.Unload = "Y"; }
            else { m_oLogistics.Unload = "N"; }

            m_oLogistics.InsertLogistics(m_oLogistics);
            m_bChange = false;

            m_tLogistics = new DataTable();
            m_tLogistics = m_oLogistics.GetLogistics(m_lVendorId);
        }

        private void tvMaterial_NodeCheckedChanged(object sender, RadTreeViewEventArgs e)
        {
            if (_skipCheckEvents) return;/* changing any Treenodes .Checked-Property will raise 
                                     another Before- and After-Check. Skip'em */
            _skipCheckEvents = true;
            try
            {
                RadTreeNode nd = e.Node;

                if (nd.Level == 0)
                {
                    nd.Checked = false;
                    return;
                }

                RadTreeNode pr;
                pr = nd.Parent;

                if (pr.Checked == true)
                {
                    nd.Checked = true;
                    return;
                }


                int state = nd.ImageIndex == 0 ? -1 : 0;
                if ((state == 0) != nd.Checked)
                {
                    if (nd.Checked == true) { InsertMaterialGroup(Convert.ToInt32(nd.Tag), Convert.ToInt32(nd.Level), "", ""); }
                    else if (nd.Checked == true)
                    {
                        if (Convert.ToInt32(nd.Level) == 1) { m_oCapability.DeleteMaterialGroupTrans(m_lVendorId, Convert.ToInt32(nd.Tag)); }
                        else if (Convert.ToInt32(nd.Level) == 2) { m_oCapability.DeleteMaterialTrans(m_lVendorId, Convert.ToInt32(nd.Tag)); }
                    }

                    return;
                }
                InheritCheckstate(nd, state);
                nd = nd.Parent;


                while (nd != null)
                {
                    if (state != 1)
                    {
                        foreach (RadTreeNode ndChild in nd.Nodes)
                        {
                            if (ndChild.ImageIndex != state)
                            {
                                state = 1;
                                break;
                            }
                        }
                    }
                    AssignState(nd, state);
                    nd = nd.Parent;
                }
            }
            finally { _skipCheckEvents = false; }

        }

        private void grpMaterial_Validated(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }
            if (m_bChange == false) { return; }
            if (MatView == null) { return; }
            if (MatView.RowCount <= 0) { return; }
            if (MatView == null || MatView.GetFocusedRowCellValue("Resource_ID").ToString() == "") { return; }
            //if (m_lMaterialId == 0 || m_lMaterialLevel == 0) { return; }
            string pType = "";
            string sType = "";
            if (cboPriority.Text == "High") { pType = "H"; }
            else if (cboPriority.Text == "Medium") { pType = "M"; }
            else if (cboPriority.Text == "Low") { pType = "L"; }

            if (cboSupplyType.Text == "Distributor") { sType = "S"; }
            else if (cboSupplyType.Text == "Dealer") { sType = "D"; }
            else if (cboSupplyType.Text == "Manufacturer") { sType = "M"; }
            m_lMaterialId = Convert.ToInt32(MatView.GetFocusedRowCellValue("Resource_ID"));
            m_oSupply.VendorId = m_lVendorId;
            m_oSupply.MaterialGroupId = m_lMaterialId;
            m_oSupply.MaterialId = m_lMaterialId;
            m_oSupply.Priority = pType;
            m_oSupply.SupplyType = sType;
            m_oSupply.LeadTime = txtLeadTime.Text == string.Empty ? 0 : Convert.ToInt32(txtLeadTime.Text);
            m_oSupply.CreditDays = txtMCredit.Text == string.Empty ? 0 : Convert.ToInt32(txtMCredit.Text);
            m_oSupply.ContactPerson = txtMCPerson.Text;
            m_oSupply.ContactNo = txtMCNo.Text;
            m_oSupply.Email = txtMEmail.Text;
            //if (m_lMaterialLevel == 1)
            //{
            //    m_oCapability.UpdateMaterialGroupTrans(m_oSupply);
            //    m_tMaterialGroupTrans = new DataTable();
            //    m_tMaterialGroupTrans = m_oCapability.GetMaterialGroupTrans(m_lVendorId);
            //}
            //else
            //{
            m_oCapability.UpdateMaterialTrans(m_oSupply);
            m_bChange = false;
            m_tMaterialTrans = new DataTable();
            m_tMaterialTrans = m_oCapability.GetMaterialTrans(m_lVendorId);
            PopulateMaterial();
            //}
        }

        private void documentTabStrip1_Click(object sender, EventArgs e)
        {
            PopulateInfo();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            dwGeneral.Show();
            dwContact.Hide();
            dwBranch.Hide();
            dwStatutory.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            dwContact.Show();
            dwGeneral.Hide();
            dwBranch.Hide();
            dwStatutory.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            dwBranch.Show();
            dwContact.Hide();
            dwGeneral.Hide();
            dwStatutory.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            dwStatutory.Show();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();

        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {

            dwAssessment.Show();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwCapability.Hide();
            dwExperience.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();

        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {

            dwExperience.Show();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwAssessment.Hide();
            dwCapability.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();

        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {

            dwCapability.Show();
            dwAssessment.Hide();
            dwExperience.Hide();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();

        }

        private void radMenuItem8_Click(object sender, EventArgs e)
        {
            dwTerms.Show();
            dwAssessment.Hide();
            dwCapability.Hide();
            dwExperience.Hide();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();


        }

        private void radMenuItem9_Click(object sender, EventArgs e)
        {
            dwHistory.Show();
            dwTerms.Hide();
            dwAssessment.Hide();
            dwCapability.Hide();
            dwExperience.Hide();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwRegistration.Hide();
            PopulateInfo();

        }

        private void radMenuItem10_Click(object sender, EventArgs e)
        {
            dwRegistration.Show();
            dwHistory.Hide();
            dwTerms.Hide();
            dwAssessment.Hide();
            dwCapability.Hide();
            dwExperience.Hide();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            PopulateInfo();
        }

        private void radMenu1_Click(object sender, EventArgs e)
        {
            PopulateInfo();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            dwContact.Show();
            dwGeneral.Hide();
            dwBranch.Hide();
            dwStatutory.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            dwGeneral.Show();
            dwContact.Hide();
            dwBranch.Hide();
            dwStatutory.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            dwBranch.Show();
            dwContact.Hide();
            dwGeneral.Hide();
            dwStatutory.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            dwContact.Show();
            dwGeneral.Hide();
            dwBranch.Hide();
            dwStatutory.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            dwStatutory.Show();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            dwExperience.Show();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            dwBranch.Show();
            dwContact.Hide();
            dwGeneral.Hide();
            dwStatutory.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            dwTerms.Show();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwExperience.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            dwRegistration.Show();
            dwHistory.Hide();
            dwCapability.Hide();
            dwExperience.Hide();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            PopulateInfo();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            dwStatutory.Show();
            dwExperience.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwCapability.Hide();
            dwAssessment.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            dwCapability.Show();
            dwAssessment.Hide();
            dwExperience.Hide();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            dwExperience.Show();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwAssessment.Hide();
            dwCapability.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            dwTerms.Show();
            dwAssessment.Hide();
            dwCapability.Hide();
            dwExperience.Hide();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dwCapability.Show();
            dwAssessment.Hide();
            dwExperience.Hide();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            dwAssessment.Show();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwCapability.Hide();
            dwExperience.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            dwRegistration.Show();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwCapability.Hide();
            dwExperience.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwAssessment.Hide();
            PopulateInfo();
        }

        private void btnRegPrev_Click(object sender, EventArgs e)
        {
            dwAssessment.Show();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwCapability.Hide();
            dwExperience.Hide();
            dwTerms.Hide();
            dwHistory.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void btnRegNext_Click(object sender, EventArgs e)
        {
            dwHistory.Show();
            dwStatutory.Hide();
            dwBranch.Hide();
            dwContact.Hide();
            dwGeneral.Hide();
            dwCapability.Hide();
            dwExperience.Hide();
            dwTerms.Hide();
            dwAssessment.Hide();
            dwRegistration.Hide();
            PopulateInfo();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (m_lVendorId != 0) { return; }
           
            if (Validation() == true)
            {
                if (TxtCode.Text.Trim() == "")
                {
                    MessageBox.Show("Provide Code", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    TxtCode.Focus();
                    return;
                }
                if (Convert.ToInt32(clsStatic.IsNullCheck(cboCity.EditValue, clsStatic.datatypes.vartypenumeric)) == 0 || Convert.ToInt32(clsStatic.IsNullCheck(cboCity.EditValue, clsStatic.datatypes.vartypenumeric)) == -1)
                {
                    MessageBox.Show("Select City!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
               
                int lVendorId;
                string sTypeM = "";
               

                m_oVendor.VendorName = txtName.Text;
                m_oVendor.Supply = chkSupplier.Checked;
                m_oVendor.Contract = chkContractor.Checked;
                m_oVendor.Service = chkService.Checked;
                m_oVendor.RegAddress = txtAddress1.Text;
                m_oVendor.CityId = Convert.ToInt32(cboCity.EditValue);
                m_oVendor.PinNo = txtPin.Text;
                m_oVendor.STypeId = Convert.ToInt32(clsStatic.IsNullCheck(cboSType.EditValue, clsStatic.datatypes.vartypenumeric));
                if (chkSupplier.Checked == true && chkContractor.Checked == false && chkService.Checked == false)
                {
                    m_oVendor.STypeId = 0;
                }
                if (chkSupplier.Checked == true)
                {
                    if (comboBoxEdit1.Text == "Distributor") { sTypeM = "S"; }
                    else if (comboBoxEdit1.Text == "Dealer") { sTypeM = "D"; }
                    else if (comboBoxEdit1.Text == "Manufacturer") { sTypeM = "M"; }
                }
                m_oVendor.SuppTypeId = sTypeM;
                m_oVendor.ChequeNo = txtCheque.Text;
                m_oVendor.Code = TxtCode.Text.Trim();

                if (rgIsCompany.SelectedIndex == 0) m_oVendor.iCompany = 1; else m_oVendor.iCompany = 0;
                lVendorId = m_oVendor.InsertVendorMaster(m_oVendor);
                if (m_bAManualCode == true)
                {
                    m_oVendor.MaxVendorUpdate(m_iMaxN);
                }
                string sVendorNameI = BsfGlobal.Insert_SingleQuot(m_oVendor.VendorName);
                BsfGlobal.InsertLog(DateTime.Now, "Vendor-Master-Add", "N", sVendorNameI, lVendorId, 0, 0, BsfGlobal.g_sVendorDBName, sVendorNameI, BsfGlobal.g_lUserId);
                m_lVendorId = lVendorId;
                m_tVendorMasterInfo = new DataTable();
                m_tVendorMasterInfo = m_oVendor.GetVendorMasterInfo(m_lVendorId);
                MenuShow();
                cmdGNext.Focus();
            }
        }

        private void cmdRegistration_Click(object sender, EventArgs e)
        {
            PopulateReg();
        }

        private void toolStripLabourAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            frmResource Resource = new frmResource();
            dt = Resource.Execute("L");
            if (dt != null)
            {
                DataRow dr;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = m_tManPowerSub.NewRow();
                    dr["Resource_ID"] = dt.Rows[i]["Resource_ID"].ToString();
                    dr["VendorID"] = m_lVendorId;
                    dr["Resource_Name"] = dt.Rows[i]["Resource_Name"].ToString();
                    dr["Unit_Name"] = dt.Rows[i]["Unit_Name"].ToString();
                    dr["Qty"] = "0";
                    m_tManPowerSub.Rows.Add(dr);
                }
            }
        }

        private void toolStripLabourDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (MPView.GetFocusedRow() != null)
            //{
            //    int hrow = MPView.FocusedRowHandle;
            //    if (MPView.IsNewItemRow(hrow) == true) { return; }
            //    //if (grdMachinery.CurrentRow.IsNewRow == true) { return; }
            //    if (MPView.FocusedRowHandle >= 0)
            //    {

            //        System.Data.DataRow dr = MPView.GetDataRow(MPView.FocusedRowHandle);
            //        string MachVal = dr["ManPowerTransId"].ToString();
            //        int Id = 0;
            //        if (MachVal != "")
            //        {
            //            Id = Convert.ToInt32(MachVal.ToString());
            //        }
            //        if (Id != 0)
            //        {
            //            DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //            if (reply == DialogResult.Yes)
            //            {
            //                m_oCapability.DeleteManPower(Id);
            //                //grdMachinery.Rows.RemoveAt(grdMachinery.CurrentRow.Index);
            //                MPView.DeleteRow(MPView.FocusedRowHandle);
            //                m_tManPower = new DataTable();
            //                m_tManPower = m_oCapability.GetManPower(m_lVendorId);
            //            }                        
            //        }

            //    }
            //}


            if (MPView.GetFocusedRow() != null)
            {
                int hrow = MPView.FocusedRowHandle;
                if (MPView.IsNewItemRow(hrow) == true) { return; }
                //if (grdMachinery.CurrentRow.IsNewRow == true) { return; }
                if (MPView.FocusedRowHandle >= 0)
                {

                    System.Data.DataRow dr = MPView.GetDataRow(MPView.FocusedRowHandle);
                    string MachVal = dr["ManPowerTransId"].ToString();
                    int Id = 0;
                    if (MachVal != "")
                    {
                        Id = Convert.ToInt32(MachVal.ToString());
                    }
                    if (Id != 0)
                    {
                        DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (reply == DialogResult.Yes)
                        {
                            m_oCapability.DeleteManPower(Id);
                            //grdMachinery.Rows.RemoveAt(grdMachinery.CurrentRow.Index);
                            MPView.DeleteRow(MPView.FocusedRowHandle);
                            m_tManPower = new DataTable();
                            m_tManPower = m_oCapability.GetManPower(m_lVendorId);
                        }
                    }
                    else
                        MPView.DeleteRow(MPView.FocusedRowHandle);

                }
            }

        }

        private void txtEMail1_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" +
               @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
               @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            System.Text.RegularExpressions.Match match = Regex.Match(txtEMail1.Text.Trim(), pattern, RegexOptions.IgnoreCase);
            if (match.Success == false)
            {
                MessageBox.Show("Enter the Valid Email Id!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEMail1.Text = "";
            }
        }

        private void txtEMail2_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" +
              @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
              @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            System.Text.RegularExpressions.Match match = Regex.Match(txtEMail1.Text.Trim(), pattern, RegexOptions.IgnoreCase);
            if (match.Success == false)
            {
                MessageBox.Show("Enter the Valid Email Id!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEMail1.Text = "";
            }
        }

        private void btnCerTDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                m_oCapability.DeleteCertifyTrans(m_lVendorId, Convert.ToInt32(chkCertificate.SelectedValue));
                PopulateVendorIntialData();
                PopulateCertificate();
                PopulateCertificateTrans();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmServiceMaster frm = new frmServiceMaster();
            frm.ShowDialog();
            PopulateVendorIntialData();
            PopulateCapability();
            PopulateService();
        }

        private void btnMAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {          
            DataTable dt = new DataTable();
            frmResource Resource = new frmResource();
            dt = Resource.Execute("M");
            if (dt != null)
            {
                DataRow dr;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dtMaterial.NewRow();
                    dr["Code"] = dt.Rows[i]["Code"].ToString();
                    dr["Resource_ID"] = dt.Rows[i]["Resource_ID"].ToString();
                    dr["ResourceName"] = dt.Rows[i]["Resource_Name"].ToString();

                    dtMaterial.Rows.Add(dr);

                    InsertMaterialTrans(Convert.ToInt32(dt.Rows[i]["Resource_ID"].ToString()));
                }
            }
            PopulateMaterial();
        }

        private void btnMDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Do You Want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_oCapability.DeleteMaterialTrans(m_lVendorId, Convert.ToInt32(MatView.GetFocusedRowCellValue("Resource_ID")));
                MatView.DeleteRow(MatView.FocusedRowHandle);
            }
        }

        private void btnAddEnclosure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEnclosure frm = new frmEnclosure();
            frm.Execute(m_lVendorId, "A", 0);
            PopulateEnclosure();
        }

        private void btnEditEnclosure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEnclosure frm = new frmEnclosure();
            frm.Execute(m_lVendorId, "E", Convert.ToInt32(EncView.GetFocusedRowCellValue("EnclosureId")));
            PopulateEnclosure();
        }

        private void btnDeleteEnclosure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Do You Want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_oCapability.DeleteEnclosure(m_lVendorId, Convert.ToInt32(EncView.GetFocusedRowCellValue("EnclosureId")));
                EncView.DeleteRow(EncView.FocusedRowHandle);
            }
        }

        private void radMenuItem11_Click(object sender, EventArgs e)
        {

        }

        private void btnVehicle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVehicle frm = new frmVehicle();
            frm.Execute(0, m_lVendorId);
        }

        private void chkService_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkService.Checked == true) cboSType.Visible = true; else cboSType.Visible = false;
            m_bChange = true;
        }
        #endregion

        #region GridEvents

        private void ASupplyView_ShownEditor(object sender, EventArgs e)
        {
            if (ASupplyView.FocusedColumn.FieldName == "Sel")
            {
                GridView view = (GridView)sender;
                CheckEdit te = (CheckEdit)view.ActiveEditor;
                te.MouseClick += new MouseEventHandler(te_Click);
            }
        }

        private void te_Click(object sender, MouseEventArgs e)
        {
            if (ASupplyView.FocusedRowHandle < 0) { return; }
            System.Data.DataRow dr = ASupplyView.GetDataRow(ASupplyView.FocusedRowHandle);
            String SelVal = dr["Sel"].ToString();
            if (ASupplyView.FocusedColumn.FieldName == "Sel")
            {
                if (Convert.ToBoolean(SelVal) == true)
                {
                    dr["Sel"] = false;
                    ASupplyView.SetRowCellValue(ASupplyView.FocusedRowHandle, "Points", 0);
                }
                else
                {
                    dr["Sel"] = true;
                    
                }
            }
        }

        private void ASupplyView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (ASupplyView.FocusedColumn.FieldName == "Points")
            //{
            //    System.Data.DataRow dr = ASupplyView.GetDataRow(ASupplyView.FocusedRowHandle);
            //    String MPVal = dr["MaxPoints"].ToString();
            //    if (txtASup.Text != string.Empty)
            //    {
            //        if (Convert.ToDouble(txtASup.Text) > Convert.ToDouble(MPVal))
            //        {
            //            dr["Points"] = MPVal;
            //        }
            //    }
            //   // grdASupply.EndEdit();
            //    CalculateSupplyGrid();
            //}
            txtASupply.Validating += new CancelEventHandler(txtASupply_Validating);
        }

        private void AContractView_ShownEditor(object sender, EventArgs e)
        {
            if (AContractView.FocusedColumn.FieldName == "Sel")
            {
                GridView view = (GridView)sender;
                CheckEdit te = (CheckEdit)view.ActiveEditor;
                te.MouseClick += new MouseEventHandler(Contractor_Click);
            }

        }

        private void Contractor_Click(object sender, MouseEventArgs e)
        {
            if (AContractView.FocusedRowHandle < 0) { return; }
            System.Data.DataRow dr = ASupplyView.GetDataRow(ASupplyView.FocusedRowHandle);
            String SelVal = dr["Sel"].ToString();
            if (AContractView.FocusedColumn.FieldName == "cSel")
            {

                if (Convert.ToBoolean(SelVal) == true)
                {
                    dr["Sel"] = false;
                    AContractView.SetRowCellValue(AContractView.FocusedRowHandle, "Points", 0);
                }
                else
                {
                    dr["Sel"] = true;
                }
            }
        }

        private void AContractView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (AContractView.FocusedColumn.FieldName == "Points")
            //{
            //    if (txtASup.Text != string.Empty)
            //    {
            //        System.Data.DataRow dr = AContractView.GetDataRow(AContractView.FocusedRowHandle);
            //        String MPVal = dr["MaxPoints"].ToString();
            //        if (Convert.ToDouble(txtASup.Text) > Convert.ToDouble(MPVal))
            //        {
            //            dr["Points"] = MPVal;
            //        }
            //    }
            //    //grdAContract.EndEdit();
            //    CalculateContractGrid();
            //}
        }

        private void AServiceView_ShownEditor(object sender, EventArgs e)
        {
            if (AServiceView.FocusedColumn.FieldName == "Sel")
            {
                GridView view = (GridView)sender;
                CheckEdit te = (CheckEdit)view.ActiveEditor;
                te.MouseClick += new MouseEventHandler(Service_Click);
            }
        }

        private void Service_Click(object sender, MouseEventArgs e)
        {
            if (AServiceView.FocusedRowHandle < 0) { return; }
            System.Data.DataRow dr = AServiceView.GetDataRow(AServiceView.FocusedRowHandle);
            String SelVal = dr["Sel"].ToString();
            if (AServiceView.FocusedColumn.FieldName == "sSel")
            {
                if (Convert.ToBoolean(SelVal) == true)
                {
                    dr["Sel"] = false;
                    AServiceView.SetRowCellValue(AServiceView.FocusedRowHandle, "Points", 0);
                }
                else
                {
                    dr["Sel"] = true;
                }
            }
        }

        private void AServiceView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (AServiceView.FocusedColumn.FieldName == "sPoints")
            //{
            //    System.Data.DataRow dr = AServiceView.GetDataRow(AServiceView.FocusedRowHandle);
            //    String MPVal = dr["MaxPoints"].ToString();
            //    if (txtASup.Text != string.Empty)
            //    {
            //        if (Convert.ToDouble(txtASup.Text) > Convert.ToDouble(MPVal))
            //        {
            //            dr["Points"] = MPVal;
            //        }
            //    }
            //    //grdAService.EndEdit();
            //    CalculateServiceGrid();
            //}

        }

        private void MPView_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName != "Qty") { e.Cancel = true; }
        }

        private void MachView_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "Resource_Name" || view.FocusedColumn.FieldName == "Unit_Name") { e.Cancel = true; }
        }

        private void ASupplyView_ShowingEditor(object sender, CancelEventArgs e)
        {

            if (ASupplyView.FocusedColumn.FieldName == "Sel")
            {
                e.Cancel = false;
            }
            else if (ASupplyView.FocusedColumn.FieldName == "Points" & Convert.ToBoolean(ASupplyView.GetRowCellValue(ASupplyView.FocusedRowHandle, "Sel")) == true)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void AContractView_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (AContractView.FocusedColumn.FieldName == "Sel")
            {
                e.Cancel = false;
            }
            else if (AContractView.FocusedColumn.FieldName == "Points" & Convert.ToBoolean(AContractView.GetRowCellValue(AContractView.FocusedRowHandle, "Sel")) == true)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void AServiceView_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (AServiceView.FocusedColumn.FieldName == "Sel")
            {
                e.Cancel = false;
            }
            else if (AServiceView.FocusedColumn.FieldName == "Points" & Convert.ToBoolean(AServiceView.GetRowCellValue(AServiceView.FocusedRowHandle, "Sel")) == true)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void grdASupply_Click(object sender, EventArgs e)
        {

        }

        private void MatView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            MaterialSelect();
        }

        private void MatCerView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (MatView == null || MatView.GetFocusedRowCellValue("Resource_ID").ToString() == "") { return; }

            int CerId = 0;
            int ResId = 0;
            bool Mode = false;
            if (Convert.ToBoolean(MatCerView.GetFocusedRowCellValue("Sel")) == true) Mode = true; else Mode = false;

            CerId = Convert.ToInt32(MatCerView.GetFocusedRowCellValue("CertificateId").ToString());
            ResId = Convert.ToInt32(MatView.GetFocusedRowCellValue("Resource_ID").ToString());
            m_oCapability.MatCerTransaction(CerId, ResId, Mode);
            PopulateMatCertificate(ResId);
        }

        private void MatView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            MaterialSelect();
        }


        #endregion

        #region TreeEvents

        private void tvMaterial_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
            Cursor.Current = Cursors.Default;
            if (e.Node.ParentNode != null)
            {
                if (e.Node.Level == 1)
                {
                    if (e.Node.Checked == true)
                    {
                        foreach (TreeListNode node in e.Node.Nodes)
                            node.CheckState = e.Node.CheckState;
                        InsertMaterialGroup(Convert.ToInt32(e.Node.GetValue(1)), e.Node.Level, e.Node.GetValue(2).ToString(), e.Node.GetValue(3).ToString());
                    }
                    else
                    {
                        foreach (TreeListNode node in e.Node.Nodes)
                            node.CheckState = e.Node.CheckState;
                        DeleteMaterialGroup(Convert.ToInt32(e.Node.GetValue(1)), e.Node.Level);
                    }

                }
                if (e.Node.Checked == true)
                {
                    InsertMaterialGroup(Convert.ToInt32(e.Node.GetValue(1)), e.Node.Level, e.Node.GetValue(2).ToString(), e.Node.GetValue(3).ToString());
                }
                else
                {
                    DeleteMaterialGroup(Convert.ToInt32(e.Node.GetValue(1)), e.Node.Level);
                }
            }
        }

        private void tvMaterial_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Node.Level > 1 && e.Node.Checked == true)
            {
                tvMaterial_AfterCheckNode(sender, e);
            }
        }

        private void tvMaterial_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void tvMaterial_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {
            //if (m_bMaterialCheck == false) return;
            //if (Convert.ToInt32(e.Node.GetValue(0).ToString()) > 0)
            //{
            //    e.Node.CheckState = CheckState.Checked;
            //    Cursor.Current = Cursors.WaitCursor;
            //    SetCheckedChildNodes(e.Node, e.Node.CheckState);
            //    SetCheckedParentNodes(e.Node, e.Node.CheckState);
            //    Cursor.Current = Cursors.Default;

            //}
        }
        #endregion

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            frmVendorFilter frm = new frmVendorFilter();
            frm.Execute();
        }

        private void btnTransAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTransportMaster frm = new frmTransportMaster();
            frm.ShowDialog();
            PopulateTransport();
        }

        private void simpleButton2_Click_2(object sender, EventArgs e)
        {
            frmVendorFilter frm = new frmVendorFilter();
            frm.ShowDialog();
        }

        private void ncContract_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView4.Columns.Clear();
            m_tHistory = new DataTable();
            m_tHistory = m_oHistory.GetContractWorkBillDetails(m_lVendorId);
            DataView dv;
            dv = new DataView(m_tHistory);
            gridControl4.DataSource = dv.ToTable();
            
            gridView4.Columns[0].Width = 80;
            gridView4.Columns[1].Width = 82;
            
            gridView4.Columns[2].Width = 200;
            gridView4.Columns[3].Width = 90;
            gridView4.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView4.Columns[3].DisplayFormat.FormatString = "F2";
        }

        private void ncOrder_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView4.Columns.Clear();
            m_tHistory = new DataTable();
            m_tHistory = m_oHistory.GetContractWorkOrderDetails(m_lVendorId);           
            gridControl4.DataSource = m_tHistory;
            //DataGridViewCellStyle d = new DataGridViewCellStyle();
            //d.Alignment = DataGridViewContentAlignment.TopRight;
            //d.Format = "F2";
            //grdHistory.Columns[3].DefaultCellStyle = d; 
            gridView4.Columns[0].Width = 90;
            gridView4.Columns[1].Width = 100;
            gridView4.Columns[2].Width = 232;
            gridView4.Columns[3].Width = 140;
            gridView4.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView4.Columns[3].DisplayFormat.FormatString = "F2";
        }

        private void ncPendingOrders_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView4.Columns.Clear();
        }

        private void ncPendingBills_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView4.Columns.Clear();
            m_tHistory = new DataTable();
            m_tHistory = m_oHistory.GetContractWorkPendingBillDetails(m_lVendorId);
            gridControl4.DataSource = m_tHistory;
            //DataGridViewCellStyle d = new DataGridViewCellStyle();
            //d.Alignment = DataGridViewContentAlignment.TopRight;
            //d.Format = "F2";
            //grdHistory.Columns[3].DefaultCellStyle = d; 
            gridView4.Columns[0].Width = 80;
            gridView4.Columns[1].Width = 70;
            gridView4.Columns[2].Width = 100;
            gridView4.Columns[3].Width = 140;
            gridView4.Columns[4].Width = 70;
            gridView4.Columns[5].Width = 140;
            gridView4.Columns[6].Width = 70;
            gridView4.Columns[7].Width = 80;
            gridView4.Columns[8].Width = 80;
            gridView4.Columns[9].Width = 80;
            gridView4.Columns[10].Width = 80;
            gridView4.Columns[11].Width = 100;
            gridView4.Columns[12].Width = 100;
            gridView4.Columns[13].Visible = false;

            
            gridView4.Columns[7].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView4.Columns[7].DisplayFormat.FormatString = "F2";
            gridView4.Columns[8].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView4.Columns[8].DisplayFormat.FormatString = "F2";
            gridView4.Columns[9].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView4.Columns[9].DisplayFormat.FormatString = "F2";
            gridView4.Columns[10].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView4.Columns[10].DisplayFormat.FormatString = "F2";
            gridView4.Columns[11].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView4.Columns[11].DisplayFormat.FormatString = "F2";
            gridView4.Columns[12].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView4.Columns[12].DisplayFormat.FormatString = "F2";
        }

        private void nsServiceDet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView5.Columns.Clear();
            m_tHistory = new DataTable();
            m_tHistory = m_oHistory.GetServiceBillDetails(m_lVendorId);
            DataView dv;
            dv = new DataView(m_tHistory);
            gridControl5.DataSource = dv.ToTable();
            
            gridView5.Columns[0].Width = 80;
            gridView5.Columns[1].Width = 82;
            gridView5.Columns[2].Width = 80;
            gridView5.Columns[3].Width = 82;
            gridView5.Columns[4].Width = 200;
            gridView5.Columns[5].Width = 90;
            gridView5.Columns[6].Width = 90;
            gridView5.Columns[5].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView5.Columns[5].DisplayFormat.FormatString = "F2";
            gridView5.Columns[6].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView5.Columns[6].DisplayFormat.FormatString = "F2";
        }

        private void nsOrder_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView5.Columns.Clear();
            m_tHistory = new DataTable();
            m_tHistory = m_oHistory.GetServiceOrderDetails(m_lVendorId);
            DataView dv;
            dv = new DataView(m_tHistory);
            gridControl5.DataSource = dv.ToTable();
            
            gridView5.Columns[0].Width = 80;
            gridView5.Columns[1].Width = 82;
            gridView5.Columns[2].Width = 80;
            gridView5.Columns[3].Width = 82;
            gridView5.Columns[4].Width = 200;
            gridView5.Columns[5].Width = 90;
            gridView5.Columns[6].Width = 90;
            gridView5.Columns[5].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView5.Columns[5].DisplayFormat.FormatString = "F2";
            gridView5.Columns[6].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView5.Columns[6].DisplayFormat.FormatString = "F2";
        }

        private void nsPendingOrders_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView5.Columns.Clear();
        }

        private void nsPendingBills_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView5.Columns.Clear();
        }

        private void nbPendMIN_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            HistoryView.Columns.Clear();
            m_tHistory = new DataTable();
            sLink = "PendingMIN";
            m_tHistory = m_oHistory.GetPendingMINDet(m_lVendorId);  
            grdHistory.DataSource = m_tHistory;
            HistoryView.Columns[14].Visible = false;
            HistoryView.Columns[15].Visible = false;
            HistoryView.Columns[16].Visible = false;

            HistoryView.Columns[0].Width = 70;
            HistoryView.Columns[1].Width = 80;
            HistoryView.Columns[2].Width = 70;
            HistoryView.Columns[3].Width = 150;
            HistoryView.Columns[4].Width = 80;
            HistoryView.Columns[5].Width = 150;
            HistoryView.Columns[6].Width = 70;
            HistoryView.Columns[7].Width = 70;
            HistoryView.Columns[8].Width = 70;
            HistoryView.Columns[9].Width = 70;
            HistoryView.Columns[10].Width = 70;
            HistoryView.Columns[11].Width = 70;
            HistoryView.Columns[12].Width = 70;
            HistoryView.Columns[13].Width = 70;

            HistoryView.Columns[7].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[8].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[9].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[10].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[11].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[12].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            HistoryView.Columns[13].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            HistoryView.Columns[7].DisplayFormat.FormatString = "F2";
            HistoryView.Columns[8].DisplayFormat.FormatString = "F2";
            HistoryView.Columns[9].DisplayFormat.FormatString = "F2";
            HistoryView.Columns[10].DisplayFormat.FormatString = "F2";
            HistoryView.Columns[11].DisplayFormat.FormatString = "F2";
            HistoryView.Columns[12].DisplayFormat.FormatString = "F2";
            HistoryView.Columns[13].DisplayFormat.FormatString = "F2";
            
        }

       
        private void chkSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupplier.Checked == true)
            {
                comboBoxEdit1.Text = "---Select---";
                comboBoxEdit1.Enabled = true;
            }
            else
            {
                comboBoxEdit1.Text = "---Select---";
                comboBoxEdit1.Enabled = false;
            }
            m_bChange = true;
        }

        private void btnManuAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_lVendorId == 0) { return; }
            m_sVTransId = "";
            if (WHView.RowCount > 0)
            {
                for (int i = 0; i < WHView.RowCount; i++)
                {
                    m_sVTransId = String.Format("{0}{1},", m_sVTransId, WHView.GetRowCellValue(i, "SupplierVendorId"));
                }
            }
            if (m_sVTransId != "")
            {
                m_sVTransId = m_sVTransId.Substring(0, m_sVTransId.Length - 1);
            }

            DataTable dt = new DataTable();
            frmSupplierVenPickList frm = new frmSupplierVenPickList();
            dt = frm.Execute(m_lVendorId, "M", m_sVTransId);
            if (dt != null)
            {
                VendorBL.InsertVendorSupplierDet(m_lVendorId, "M", dt);
                PopulateSupplierManuFactureGrid();
            }
        }

        private void btnManuDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (WHView.FocusedRowHandle < 0) { return; }
            if (WHView.RowCount > 0)
            {
                int i_SuppVId = 0;
                i_SuppVId = Convert.ToInt32(clsStatic.IsNullCheck(WHView.GetRowCellValue(WHView.FocusedRowHandle, "SupplierVendorId"), clsStatic.datatypes.vartypenumeric));
                if (MessageBox.Show("Do you want to delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (VendorBL.DelVendorSupplierDet(m_lVendorId, i_SuppVId, "M") == true)
                        WHView.DeleteRow(WHView.FocusedRowHandle);
                    
                }
            }
        }

        private void btnDistriAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_lVendorId == 0) { return; }
            m_sVTransId = "";
            if (gridView7.RowCount > 0)
            {
                for (int i = 0; i < gridView7.RowCount; i++)
                {
                    m_sVTransId = String.Format("{0}{1},", m_sVTransId, gridView7.GetRowCellValue(i, "SupplierVendorId"));
                }
            }
            if (m_sVTransId != "")
            {
                m_sVTransId = m_sVTransId.Substring(0, m_sVTransId.Length - 1);
            }

            DataTable dt = new DataTable();
            frmSupplierVenPickList frm = new frmSupplierVenPickList();
            dt = frm.Execute(m_lVendorId, "S", m_sVTransId);
            if (dt != null)
            {
                VendorBL.InsertVendorSupplierDet(m_lVendorId, "S", dt);
                PopulateSupplierDistributorGrid();
            }
        }

        private void PopulateSupplierManuFactureGrid()
        {
            try
            {
                string m_sSuppType = "M";
                DataTable dtPop = new DataTable();
                dtPop = VendorBL.FillSuppVendorDetList(m_lVendorId, m_sSuppType);
                grdWH.DataSource = dtPop;
                
                WHView.Columns["SupplierVendorId"].Visible = false;
                WHView.Columns["VendorId"].Visible = false;
                WHView.Columns["VendorName"].OptionsColumn.AllowEdit = false;
                WHView.Columns["VendorName"].Width = 240;                
                WHView.OptionsView.ColumnAutoWidth = true;
                WHView.Appearance.HeaderPanel.Font = new Font(WHView.Appearance.HeaderPanel.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
        }

        private void PopulateSupplierDistributorGrid()
        {
            try
            {
                string m_sSuppType = "S";
                DataTable dtPop = new DataTable();
                dtPop = VendorBL.FillSuppVendorDetList(m_lVendorId, m_sSuppType);
                gridControl6.DataSource = dtPop;
                
                gridView7.Columns["SupplierVendorId"].Visible = false;
                gridView7.Columns["VendorId"].Visible = false;
                gridView7.Columns["VendorName"].OptionsColumn.AllowEdit = false;
                gridView7.Columns["VendorName"].Width = 240;
                gridView7.OptionsView.ColumnAutoWidth = true;
                gridView7.Appearance.HeaderPanel.Font = new Font(WHView.Appearance.HeaderPanel.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
        }

        private void PopulateSupplierDealerGrid()
        {
            try
            {
                string m_sSuppType = "D";
                DataTable dtPop = new DataTable();
                dtPop = VendorBL.FillSuppVendorDetList(m_lVendorId, m_sSuppType);
                gridControl7.DataSource = dtPop;

                gridView8.Columns["SupplierVendorId"].Visible = false;
                gridView8.Columns["VendorId"].Visible = false;
                gridView8.Columns["VendorName"].OptionsColumn.AllowEdit = false;
                gridView8.Columns["VendorName"].Width = 240;
                gridView8.OptionsView.ColumnAutoWidth = true;
                gridView8.Appearance.HeaderPanel.Font = new Font(WHView.Appearance.HeaderPanel.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
        }

        private void btnDistriDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView7.FocusedRowHandle < 0) { return; }
            if (gridView7.RowCount > 0)
            {
                int i_SuppVId = 0;
                i_SuppVId = Convert.ToInt32(clsStatic.IsNullCheck(gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "SupplierVendorId"), clsStatic.datatypes.vartypenumeric));
                if (MessageBox.Show("Do you want to delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (VendorBL.DelVendorSupplierDet(m_lVendorId, i_SuppVId, "S") == true)
                        gridView7.DeleteRow(gridView7.FocusedRowHandle);

                }
            }
        }

        private void btnDealerAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_lVendorId == 0) { return; }
            m_sVTransId = "";
            if (gridView8.RowCount > 0)
            {
                for (int i = 0; i < gridView8.RowCount; i++)
                {
                    m_sVTransId = String.Format("{0}{1},", m_sVTransId, gridView8.GetRowCellValue(i, "SupplierVendorId"));
                }
            }
            if (m_sVTransId != "")
            {
                m_sVTransId = m_sVTransId.Substring(0, m_sVTransId.Length - 1);
            }

            DataTable dt = new DataTable();
            frmSupplierVenPickList frm = new frmSupplierVenPickList();
            dt = frm.Execute(m_lVendorId, "D", m_sVTransId);
            if (dt != null)
            {
                VendorBL.InsertVendorSupplierDet(m_lVendorId, "D", dt);
                PopulateSupplierDealerGrid();
            }
        }

        private void btnDealerDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView8.FocusedRowHandle < 0) { return; }
            if (gridView8.RowCount > 0)
            {
                int i_SuppVId = 0;
                i_SuppVId = Convert.ToInt32(clsStatic.IsNullCheck(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, "SupplierVendorId"), clsStatic.datatypes.vartypenumeric));
                if (MessageBox.Show("Do you want to delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (VendorBL.DelVendorSupplierDet(m_lVendorId, i_SuppVId, "D") == true)
                        gridView8.DeleteRow(gridView8.FocusedRowHandle);

                }
            }
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void chkContractor_CheckedChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void cboSType_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtAddress1_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtState_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtPin_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void rgIsCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtCheque_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtCAddress_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtPhone1_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtPhone2_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtFax1_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtFax2_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtMobile1_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtMobile2_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtCPerson_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtCDesignation_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtCContact_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtAPerson_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtADesignation_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtAContactNo_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtEMail1_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtEMail2_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtWeb_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtFirm_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtYear_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtPANNo_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtTANNo_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtCSTNo_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtTINNo_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtSTaxNo_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtTNGST_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtAccountNo_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void cboAccType_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtBankName_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtBranch_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtBranchCode_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtMICR_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtIFSC_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void cboPriority_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void cboSupplyType_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtLeadTime_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtMCredit_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtMCPerson_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtMCNo_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtMEmail_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtTransMode_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void cboTrans_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void cboDelivery_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void cboUnload_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void cboInsurance_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtCredit_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtMaxLeadTime_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtTerms_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void btnMGroupAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dtGrMat = new DataTable();
            dtGrMat.Columns.Add("Resource_Group_ID");
            dtGrMat.Columns.Add("Resource_Group_Name", typeof(string));
            DataTable dt = new DataTable();
            frmResourceGroup Resource = new frmResourceGroup();
            dt = Resource.Execute("R", m_lVendorId);
            if (dt != null)
            {
                DataRow dr;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dtGrMat.NewRow();                  
                    dr["Resource_Group_ID"] = dt.Rows[i]["Resource_Group_ID"].ToString();
                    dr["Resource_Group_Name"] = dt.Rows[i]["Resource_Group_Name"].ToString();

                    dtGrMat.Rows.Add(dr);    
                }
                CapabilityBL.UpdateVendorResGroup(m_lVendorId, dtGrMat);
            }          
        }

        private void HistoryView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (sLink == "PendingMIN")
            {
                int iCRegId = 0;
                int iPRegId = 0;
                int iCResId = 0;
                int iPResId = 0;
                int iCItemId = 0;
                int iPItemId = 0;

                iCRegId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle, "RegisterId"), clsStatic.datatypes.vartypenumeric));
                iCResId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle, "ResourceID"), clsStatic.datatypes.vartypenumeric));
                iCItemId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle, "CostCentreId"), clsStatic.datatypes.vartypenumeric));

                if (e.RowHandle > 0)
                {
                    iPRegId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle - 1, "RegisterId"), clsStatic.datatypes.vartypenumeric));
                    iPResId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle - 1, "ResourceID"), clsStatic.datatypes.vartypenumeric));
                    iPItemId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle - 1, "CostCentreId"), clsStatic.datatypes.vartypenumeric));
                }
                if (iCRegId == iPRegId && e.RowHandle > 0)
                {
                    if (e.Column.FieldName == "MIN No") e.DisplayText = "";
                    if (e.Column.FieldName == "MIN Date") e.DisplayText = "";
                    if (e.Column.FieldName == "Site MIN No") e.DisplayText = "";
                    if (e.Column.FieldName == "CostCentre") e.DisplayText = "";
                    if (iCResId == iPResId && iCItemId == iPItemId)
                    {
                        if (e.Column.FieldName == "Code") e.DisplayText = "";
                        if (e.Column.FieldName == "Resource") e.DisplayText = "";
                        if (e.Column.FieldName == "Unit") e.DisplayText = "";
                    }

                }
            }
            if (sLink == "PendingOrder")
            {
                int iCRegId = 0;
                int iPRegId = 0;
                int iCResId = 0;
                int iPResId = 0;
                int iCItemId = 0;
                int iPItemId = 0;

                iCRegId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle, "PORegisterId"), clsStatic.datatypes.vartypenumeric));
                iCResId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle, "Resource_Id"), clsStatic.datatypes.vartypenumeric));
                iCItemId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle, "CostcentreId"), clsStatic.datatypes.vartypenumeric));

                if (e.RowHandle > 0)
                {
                    iPRegId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle - 1, "PORegisterId"), clsStatic.datatypes.vartypenumeric));
                    iPResId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle - 1, "Resource_Id"), clsStatic.datatypes.vartypenumeric));
                    iPItemId = Convert.ToInt32(clsStatic.IsNullCheck(HistoryView.GetRowCellValue(e.RowHandle - 1, "CostcentreId"), clsStatic.datatypes.vartypenumeric));
                }
                if (iCRegId == iPRegId && e.RowHandle > 0)
                {
                    if (e.Column.FieldName == "PONo") e.DisplayText = "";
                    if (e.Column.FieldName == "PoDate") e.DisplayText = "";
                    if (e.Column.FieldName == "CostCentreName") e.DisplayText = "";
                    if (iCResId == iPResId && iCItemId == iPItemId)
                    {
                        if (e.Column.FieldName == "ResourceName") e.DisplayText = "";
                        if (e.Column.FieldName == "UnitName") e.DisplayText = "";
                    }

                }
            }
        }

        private void ASupplyView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            // Code Modified By Jayanthi I-Tracker Ref No 3739.
            switch (e.SummaryProcess)
            {
                case CustomSummaryProcess.Start:
                    m_iMaxApply = 0;
                    break;
                case CustomSummaryProcess.Calculate:
                    if (Convert.ToBoolean(clsStatic.IsNullCheck(ASupplyView.GetRowCellValue(e.RowHandle, "Sel"), clsStatic.datatypes.varTypeBoolean)) == true)
                        m_iMaxApply += Convert.ToDouble(clsStatic.IsNullCheck(ASupplyView.GetRowCellValue(e.RowHandle, "MaxPoints"), clsStatic.datatypes.vartypenumeric));
                    break;
                case CustomSummaryProcess.Finalize:
                    if ((e.Item as GridSummaryItem).FieldName == "MaxPoints")
                        e.TotalValue = m_iMaxApply;
                    break;
            }
            //End
        }

        private void txtSSIREGD_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtServiceTaxC_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtEPFNo_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtESINo_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void radioExciseV_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtExciseRegNo_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtExcisedivision_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtExciseRange_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void txtECCno_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

        private void TxtCode_EditValueChanged(object sender, EventArgs e)
        {
            m_bChange = true;
        }

    }
}
