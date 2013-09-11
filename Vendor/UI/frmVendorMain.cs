using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.Utils.Paint;
using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraGrid.Views.Grid;
using Vendor.BusinessLayer;

namespace Vendor
{
    public partial class frmVendorMain : Form
    {
        #region Variables

        bool m_bAns = false;
        public string option = "";
        bool m_bAdd = false;
        DataTable m_tVendor;
        DataTable m_tSupplyGrade;
        DataTable m_tContractGrade;
        DataTable m_tServiceGrade;
        int m_iRowId = 0;
        int m_iVendorId = 0;
        string VendorName = "";
        Vendor.BusinessLayer.VendorBL m_oVendor;
        Vendor.BusinessLayer.RegisterBL m_oRegister;
        Vendor.BusinessLayer.CheckListBL m_oCheckList;
        string m_sSelectionFormula = "";
        public static GridView m_oGridMasterView = new GridView();
        public static Telerik.WinControls.UI.Docking.DocumentWindow m_oDW = new Telerik.WinControls.UI.Docking.DocumentWindow();
        public static int iRowId = 0;
        int iId = 0;
        #endregion

        #region FormEvents

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmVendorMain_Load(object sender, EventArgs e)
        {
            iId = frmMain.iPRowId;
            SetMyGraphics();
            m_bAns = false;
            lblVendor.Text = "";
            toolStripFilter.EditValue = "ALL";
            PopulateSType();
            //cboSType.Visible = false;
            PopulateVendor();
            if (iId == 0)
            {
                VendorView.FocusedRowHandle = 0;
                VendorView.FocusedColumn = VendorView.VisibleColumns[0];
            }
            else
            {
                VendorView.FocusedRowHandle = iId;
            }
            m_bAns = true;
            if (VendorView == null) { btnNext.Visible = false; } else { btnNext.Visible = true; }
            if (VendorView != null) { if (VendorView.RowCount <= 0) { btnNext.Visible = false; } else { btnNext.Visible = true; } }
        }

        private void frmVendorMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BsfGlobal.g_bWorkFlow == true)
            {
                if (BsfGlobal.g_bWorkFlowDialog == false) { try { this.Parent.Controls.Owner.Hide(); } catch { } }
            }
        }

        private void frmVendorMain_Activated(object sender, EventArgs e)
        {
            if (m_bAdd == true)
            {
                m_bAdd = false;
                PopulateVendor();
                VendorView.FocusedRowHandle = m_iRowId;
                if (VendorView.FocusedRowHandle < 0) { return; }
                int iVendorId = Convert.ToInt32(VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorId").ToString());
                lblVendor.Text = VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorName").ToString();
                PopulateRegDetails(iVendorId);
                VendorView.FocusedColumn = VendorView.VisibleColumns[0];
            }
        }
        #endregion

        #region ButtonEvents

        private void barExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void toolStripFilter_EditValueChanged(object sender, EventArgs e)
        {
            if (m_bAns == true)
            {
                PopulateVendor();

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            m_iVendorId = Convert.ToInt32(VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorId").ToString());
            lblVendor.Text = VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorName").ToString();
            EditVendor();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGrade frm = new frmGrade();
            frm.Execute();
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCheckList frm = new frmCheckList();
            frm.ShowDialog();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string Type = "";
            frmReport objReport = new frmReport();
            string strReportPath = Application.StartupPath + "\\VendorPrint.Rpt";
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(strReportPath);

            if (toolStripFilter.EditValue.ToString() == "Supplier")
            {
                m_sSelectionFormula = "{Command.Supply} = true ";
            }
            else if (toolStripFilter.EditValue.ToString() == "Sub Contractor")
            {
                m_sSelectionFormula = "{Command.Contract} = true ";
            }
            else if (toolStripFilter.EditValue.ToString() == "Service Provider")
            {
                m_sSelectionFormula = "{Command.Service} = true ";
            }

            string[] DataFiles = new string[] 
            {
                BsfGlobal.g_sVendorDBName
            };
            cryRpt.SetParameterValue("WFDb", BsfGlobal.g_sWorkFlowDBName);
            objReport.ReportConvert(cryRpt, DataFiles);
            if (m_sSelectionFormula.Length > 0)
                cryRpt.RecordSelectionFormula = m_sSelectionFormula;
            objReport.rptViewer.ReportSource = null;
            objReport.rptViewer.ReportSource = cryRpt;
            if (toolStripFilter.EditValue.ToString() == "Supplier") Type = "- Supplier";
            else if (toolStripFilter.EditValue.ToString() == "Sub Contractor") Type = "- Sub Contractor";
            else if (toolStripFilter.EditValue.ToString() == "Service Provider") Type = "- Service Provider";
            else Type = "- Consolidated";
            cryRpt.DataDefinition.FormulaFields["Type"].Text = " '" + Type + "'";
            objReport.rptViewer.Refresh();
            objReport.Show();
        }

        private void btnVenDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BsfGlobal.FindPermission("Vendor-Delete") == false)
            {
                MessageBox.Show("No Rights to Delete Vendor", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void toolStripVAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (BsfGlobal.FindPermission("Vendor-Master-Add") == false)
            {
                MessageBox.Show("No Rights to Vendor-Master-Add");
                return;
            }

            if (BsfGlobal.g_bWorkFlow == true)
            {

                try { this.Parent.Controls.Owner.Hide(); }
                catch { }

                BsfGlobal.g_bWorkFlow = true;
                frmMain frm = new frmMain();
                DevExpress.XtraEditors.PanelControl oPanel = new DevExpress.XtraEditors.PanelControl();
                oPanel = BsfGlobal.GetPanel(frm, "Vendor Details");
                if (oPanel != null)
                {
                    oPanel.Controls.Clear();
                    iRowId =0;
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    oPanel.Controls.Add(frm);
                    frm.m_lVendorId = 0;
                    frm.m_sVendorName = "";
                    frm.Execute();
                    oPanel.Visible = true;
                    Cursor.Current = Cursors.Default;
                }


                //Cursor.Current = Cursors.WaitCursor;
                //BsfGlobal.g_bTrans = true;
                //BsfGlobal.g_oWindow.Hide();
                //frmMain frm = new frmMain();

                //BsfGlobal.g_oPanelTrans.Controls.Clear();
                //BsfGlobal.g_oWindowTrans.Text = "Vendor Details";
                //frm.TopLevel = false;
                //frm.FormBorderStyle = FormBorderStyle.None;
                //frm.Dock = DockStyle.Fill;
                //BsfGlobal.g_oPanelTrans.Controls.Add(frm);
                //frm.Execute(0);
                //BsfGlobal.g_oWindowTrans.Show();
                //Cursor.Current = Cursors.Default;


            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                frmMain frm = new frmMain();
                frm.m_lVendorId = 0;
                frm.m_sVendorName = "";
                frm.Execute();
                Cursor.Current = Cursors.Default;
                PopulateVendor();
            }
            m_bAdd = true;
            m_iRowId = 0;
        }
        #endregion

        #region Functions
        public frmVendorMain()
        {
            //objfrm = _objfrm;
            InitializeComponent();
            m_oVendor = new Vendor.BusinessLayer.VendorBL();
            m_oRegister = new Vendor.BusinessLayer.RegisterBL();
            m_oCheckList = new Vendor.BusinessLayer.CheckListBL();
        }

        public void PopulateVendor()
        {
            try
            {
                m_bAns = false;
                m_tVendor = new DataTable();
                if (option == "fMain")
                {
                    grdVendor.DataSource = null;
                    VendorView.Columns.Clear();
                }

                m_tVendor = m_oVendor.GetVendorList();
                DataView dv;
                dv = new DataView(m_tVendor);
                if (toolStripFilter.EditValue != null)
                {
                    if (toolStripFilter.EditValue.ToString() == "Supplier") { dv.RowFilter = "Supply = 1"; }
                    if (toolStripFilter.EditValue.ToString() == "Sub Contractor") { dv.RowFilter = "Contract = true"; }
                    if (toolStripFilter.EditValue.ToString() == "Service Provider") { dv.RowFilter = "Service = 1"; }
                }
                grdVendor.DataSource = dv.ToTable();
                DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit txtVendor = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
                VendorView.PopulateColumns();
                VendorView.Columns[0].Visible = false;
                VendorView.Columns[1].Width = 230;
                VendorView.Columns[1].Caption = "Vendor Name";
                VendorView.Columns[2].Visible = false;
                VendorView.Columns[3].Visible = false;
                VendorView.Columns[4].Visible = false;
                //VendorView.Columns[1].ColumnEdit = txtVendor;
                //VendorView.OptionsView.RowAutoHeight = true;
                m_bAns = true;


            }
            catch
            {
            }
            //if (grdVendor.RowCount <= 0) { panel3.Visible = false; }
            //else { grdVendor.Rows[0].Selected = true; }
        }

        private void PopulateRegDetails(int argVendorId)
        {

            txtRegNo.Text = "";
            txtRegDate.Text = "";
            //txtST.Text = "";
            //txtCT.Text = "";
            //txtHT.Text = "";
            //txtSStatus.Text = "";
            //txtCStatus.Text = "";
            //txtHStatus.Text = "";

            DataTable dt = new DataTable();
            dt = m_oRegister.GetRegTransLatest(argVendorId);
            if (dt.Rows.Count > 0)
            {
                txtRegNo.Text = dt.Rows[0]["RegNo"].ToString();


                txtRegDate.Text = dt.Rows[0]["RegDate"].ToString();

                if (Convert.ToBoolean(dt.Rows[0]["Supply"].ToString()) == true)
                {
                    if (Convert.ToBoolean(dt.Rows[0]["SBlackList"].ToString()) == true)
                    {
                        //txtST.Text = "Nil";
                        //txtSStatus.Text = "BlackList";
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["SSuspend"].ToString()) == true)
                    {
                        //txtST.Text = "Nil";
                        //txtSStatus.Text = "Suspend";
                    }
                    else
                    {
                        //txtST.Text = dt.Rows[0]["STDate"].ToString();
                        //txtSStatus.Text = dt.Rows[0]["SGrade"].ToString();
                    }
                }


                if (Convert.ToBoolean(dt.Rows[0]["Contract"].ToString()) == true)
                {
                    if (Convert.ToBoolean(dt.Rows[0]["CBlackList"].ToString()) == true)
                    {
                        //txtCT.Text = "Nil";
                        //txtCStatus.Text = "BlackList";
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["CSuspend"].ToString()) == true)
                    {
                        //txtCT.Text = "Nil";
                        //txtCStatus.Text = "Suspend";
                    }
                    else
                    {
                        //txtCT.Text = dt.Rows[0]["CTDate"].ToString();
                        //txtCStatus.Text = dt.Rows[0]["CGrade"].ToString();
                    }
                }

                if (Convert.ToBoolean(dt.Rows[0]["Service"].ToString()) == true)
                {
                    if (Convert.ToBoolean(dt.Rows[0]["HBlackList"].ToString()) == true)
                    {
                        //txtHT.Text = "Nil";
                        //txtHStatus.Text = "BlackList";
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["HSuspend"].ToString()) == true)
                    {
                        //txtHT.Text = "Nil";
                        //txtHStatus.Text = "Suspend";
                    }
                    else
                    {
                        //txtHT.Text = dt.Rows[0]["HTDate"].ToString();
                        //txtHStatus.Text = dt.Rows[0]["HGrade"].ToString();
                    }
                }
            }
        }

        private void GetGradeDetails()
        {
            m_iVendorId = Convert.ToInt32(VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorId").ToString());
            m_tSupplyGrade = new DataTable();
            m_tContractGrade = new DataTable();
            m_tServiceGrade = new DataTable();
            m_tSupplyGrade = m_oRegister.GetGradeName(m_iVendorId, "S");
            m_tContractGrade = m_oRegister.GetGradeName(m_iVendorId, "C");
            m_tServiceGrade = m_oRegister.GetGradeName(m_iVendorId, "H");
            if (m_tSupplyGrade != null)
            {
                if (m_tSupplyGrade.Rows.Count > 0)
                    txtGSupplier.Text = m_tSupplyGrade.Rows[0][1].ToString();
                else
                    txtGSupplier.Text = "";
            }
            else
            {
                txtGSupplier.Text = "";
            }
            if (m_tContractGrade != null)
            {
                if (m_tContractGrade.Rows.Count > 0)
                    txtGContractor.Text = m_tContractGrade.Rows[0][1].ToString();
                else
                    txtGContractor.Text = "";
            }
            else
            {
                txtGContractor.Text = "";
            }
            if (m_tServiceGrade != null)
            {
                if (m_tServiceGrade.Rows.Count > 0)
                    txtGService.Text = m_tServiceGrade.Rows[0][1].ToString();
                else
                    txtGService.Text = "";
            }
            else
            {
                txtGService.Text = "";
            }
        }

        private void SetMyGraphics()
        {
            FieldInfo fi = typeof(XPaint).GetField("graphics", BindingFlags.Static | BindingFlags.NonPublic);
            fi.SetValue(null, new MyXPaint());
        }

        public class MyXPaint : XPaint
        {
            public override void DrawFocusRectangle(Graphics g, Rectangle r, Color foreColor, Color backColor)
            {
                if (!CanDraw(r)) return;
                Brush hb = Brushes.Red;
                g.FillRectangle(hb, new Rectangle(r.X, r.Y, 2, r.Height - 2)); // left
                g.FillRectangle(hb, new Rectangle(r.X, r.Y, r.Width - 2, 2)); // top
                g.FillRectangle(hb, new Rectangle(r.Right - 2, r.Y, 2, r.Height - 2)); // right
                g.FillRectangle(hb, new Rectangle(r.X, r.Bottom - 2, r.Width, 2)); // bottom
            }
        }

        private void GetValidToDate()
        {
            DataTable dtValid = new DataTable();
            m_iVendorId = Convert.ToInt32(VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorId").ToString());
            if (m_iVendorId > 0)
            {
                dtValid = m_oVendor.GetValidToDate(m_iVendorId);
                if (dtValid.Rows.Count > 0)
                {
                    txtVSupplier.Text = dtValid.Rows[0][0].ToString();
                    txtVContractor.Text = dtValid.Rows[0][1].ToString();
                    txtVService.Text = dtValid.Rows[0][2].ToString();
                }
                else
                {
                    txtVSupplier.Text = "";
                    txtVContractor.Text = "";
                    txtVService.Text = "";
                }
            }
            else
            {
                txtVSupplier.Text = "";
                txtVContractor.Text = "";
                txtVService.Text = "";
            }
        }

        private void EditVendor()
        {
            if (BsfGlobal.FindPermission("Vendor-Master-Edit") == false)
            {
                MessageBox.Show("No Rights to Vendor-Master-Edit");
                return;
            }

            if (VendorView.FocusedRowHandle < 0) { return; }
            int iVendorId = Convert.ToInt32(VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorId").ToString());
            VendorName = VendorView.GetFocusedRowCellValue("VendorName").ToString();
            int i = VendorView.RowCount - 1;
           
            if (BsfGlobal.g_bWorkFlow == true)
            {
                //try { this.Parent.Controls.Owner.Hide(); }
                //catch { }
                m_oGridMasterView = VendorView;
                m_oGridMasterView.FocusedRowHandle = VendorView.FocusedRowHandle;
                iRowId = VendorView.FocusedRowHandle;
                BsfGlobal.g_bWorkFlow = true;
                frmMain frm = new frmMain();
                frm.m_lVendorId = iVendorId;
                frm.m_sVendorName = VendorName;
                m_oDW = (Telerik.WinControls.UI.Docking.DocumentWindow)BsfGlobal.g_oDock.ActiveWindow;
                m_oDW.Hide();
                DevExpress.XtraEditors.PanelControl oPanel = new DevExpress.XtraEditors.PanelControl();
                oPanel = BsfGlobal.GetPanel(frm, "Vendor Details");
                if (oPanel != null)
                {
                    oPanel.Controls.Clear();
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    oPanel.Controls.Add(frm);
                    frm.Execute();

                    oPanel.Visible = true;
                    Cursor.Current = Cursors.Default;
                }

            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                frmMain frm = new frmMain();
                frm.m_lVendorId = iVendorId;
                frm.m_sVendorName = VendorName;
                frm.Execute();
                Cursor.Current = Cursors.Default;
            }
            m_bAdd = true;
            m_iRowId = VendorView.FocusedRowHandle;      
        }

        private void PopulateVendorGeneral(int argVendorId)
        {
            DataTable dtGeneral = new DataTable();
            dtGeneral = m_oVendor.GetVendorGeneralInfo(argVendorId);
            if (dtGeneral.Rows.Count > 0)
            {
                chkSupplier.Checked = Convert.ToBoolean(dtGeneral.Rows[0]["Supply"].ToString());
                chkContractor.Checked = Convert.ToBoolean(dtGeneral.Rows[0]["Contract"].ToString());
                chkService.Checked = Convert.ToBoolean(dtGeneral.Rows[0]["Service"].ToString());
                txtAddress1.Text = dtGeneral.Rows[0]["RegAddress"].ToString();
                txtCity.Text = dtGeneral.Rows[0]["CityName"].ToString();
                txtState.Text = dtGeneral.Rows[0]["StateName"].ToString();
                TxtCode.Text = clsStatic.IsNullCheck(dtGeneral.Rows[0]["Code"], clsStatic.datatypes.vartypestring).ToString();
                txtCountry.Text = dtGeneral.Rows[0]["CountryName"].ToString();
                txtPin.Text = dtGeneral.Rows[0]["PinCode"].ToString();
                cboSType.EditValue = Convert.ToInt32(clsStatic.IsNullCheck(dtGeneral.Rows[0]["ServiceTypeId"].ToString(), clsStatic.datatypes.vartypenumeric));

                if (chkSupplier.Checked == true) { chkSupplier.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold); }
                else { chkSupplier.Font = new System.Drawing.Font("Calibri", 8, FontStyle.Regular); }

                if (chkContractor.Checked == true) { chkContractor.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold); }
                else { chkContractor.Font = new System.Drawing.Font("Calibri", 8, FontStyle.Regular); }

                if (chkService.Checked == true) { chkService.Font = new System.Drawing.Font("Calibri", 10, FontStyle.Bold); }
                else { chkService.Font = new System.Drawing.Font("Calibri", 8, FontStyle.Regular); }
                
                //if (chkService.Checked == true) cboSType.Visible = true; else cboSType.Visible = false;
                txtPhone1.Text = dtGeneral.Rows[0]["Phone1"].ToString();
                txtPhone2.Text = dtGeneral.Rows[0]["Phone2"].ToString();
                txtFax1.Text = dtGeneral.Rows[0]["Fax1"].ToString();
                txtFax2.Text= dtGeneral.Rows[0]["Fax2"].ToString();
                txtCPerson.Text = dtGeneral.Rows[0]["CPerson1"].ToString();
                txtCDesignation.Text = dtGeneral.Rows[0]["CDesignation1"].ToString();
                txtCContact.Text = dtGeneral.Rows[0]["ContactNo1"].ToString();
                txtEMail1.Text = dtGeneral.Rows[0]["Email1"].ToString();
                txtEMail2.Text = dtGeneral.Rows[0]["Email2"].ToString();
                txtWeb.Text = dtGeneral.Rows[0]["WebName"].ToString();

            }
            else
            {
                chkSupplier.Checked = false;
                chkContractor.Checked = false;
                chkService.Checked = false;
                TxtCode.Text = "";
                txtAddress1.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
                txtCountry.Text = "";
                txtPin.Text = "";
                cboSType.EditValue = 0;
                //if (chkService.Checked == true) cboSType.Visible = true; else cboSType.Visible = false;
                txtPhone1.Text = "";
                txtPhone2.Text = "";
                txtFax1.Text = "";
                txtFax2.Text = "";
                txtCPerson.Text = "";
                txtCDesignation.Text = "";
                txtCContact.Text = "";
                txtEMail1.Text = "";
                txtEMail2.Text = "";
                txtWeb.Text = "";

            }
        }

        private void PopulateSType()
        {
            DataTable dtSType = new DataTable();
            dtSType = VendorBL.PopulateSType();
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

        #region GridEvents

        private void grdVendor_DoubleClick(object sender, EventArgs e)
        {


            //frmMain.m_lVendorId = Convert.ToInt32(VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorId"));
            //frmMain.m_bEditMode = true;
            //frmMain.m_bInsertMode = false;
            ////clsStatic.DW1.Hide();
            //frmMain mScreen = new frmMain(this);
            //mScreen.TopLevel = false;
            ////panelControl1.Controls.Clear();
            //mScreen.Dock = DockStyle.Fill;
            //mScreen.panelMain = panelVendorMain;
            ////panelControl1.Controls.Add(mScreen);
            ////clsStatic.DW2.Show();
            ////clsStatic.DW2.Text = "Vendor Details";
            //mScreen.Show();
        }

        private void VendorView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) { return; }
            int iVendorId = Convert.ToInt32(VendorView.GetRowCellValue(e.FocusedRowHandle, "VendorId").ToString());
           
            lblVendor.Text = VendorView.GetRowCellValue(e.FocusedRowHandle, "VendorName").ToString();
            VendorName = VendorView.GetFocusedRowCellValue("VendorName").ToString();
            PopulateRegDetails(iVendorId);
            GetGradeDetails();
            GetValidToDate();
            PopulateVendorGeneral(iVendorId);
            BsfGlobal.ClearUserUsage("Vendor-Master-Edit", iVendorId, BsfGlobal.g_sVendorDBName);
            //GetGradeDetails();
            //if (m_tSupplyGrade == null) txtGSupplier.Text = "";
            //if (m_tContractGrade == null) txtGContractor.Text = "";
            //if (m_tServiceGrade == null) txtGService.Text = "";
        }

        private void VendorView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (VendorView.FocusedRowHandle < 0) { return; }
            if (VendorView.RowCount == 1)
            {
                int iVendorId = Convert.ToInt32(VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorId").ToString());
                
                lblVendor.Text = VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorName").ToString();
                VendorName = VendorView.GetFocusedRowCellValue("VendorName").ToString();
                PopulateRegDetails(iVendorId);
                GetGradeDetails();
                GetValidToDate();
                PopulateVendorGeneral(iVendorId);
               
            }
        }

        private void VendorView_DoubleClick(object sender, EventArgs e)
        {

            EditVendor();
        }

        private void VendorView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnNext_Click(sender, e);
        }

        #endregion

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVendorImport frm = new frmVendorImport();
            frm.ShowDialog();
            PopulateVendor();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmRegisterStatus frm = new frmRegisterStatus();
            frm.ShowDialog();
        }

        private void btnDelVen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            VendorBL.DeleteVendorDetailsWithoutMaster();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VendorView.FocusedRowHandle < 0) { return; }
            if (BsfGlobal.g_bAdminDB == true)
            {
                int m_iVenId = Convert.ToInt32(clsStatic.IsNullCheck(VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorId"), clsStatic.datatypes.vartypenumeric));
                string m_sVenName = (clsStatic.IsNullCheck(VendorView.GetRowCellValue(VendorView.FocusedRowHandle, "VendorName"), clsStatic.datatypes.vartypestring)).ToString();

                DMS.frmDocument frm = new DMS.frmDocument();
                frm.Exe(19, m_iVenId, BsfGlobal.g_sVendorDBName, m_sVenName);
            }
        }

        private void barButtonItem3_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (BsfGlobal.FindPermission("Vendor-Master-Type-Setup") == false)
            //{
            //    MessageBox.Show("No Rights to Vendor-Master-Type-Setup");
            //    return;
            //}

            frmVendorCodeSetup frm = new frmVendorCodeSetup();
            frm.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool m_bAManualCode = false;
             DataTable dtAssICode = new DataTable();
            dtAssICode = m_oCheckList.GetVendorCodeTypeSetup();
            if (dtAssICode.Rows.Count > 0)
            {
                m_bAManualCode = Convert.ToBoolean(dtAssICode.Rows[0]["CodeType"].ToString());
            }
            if (m_bAManualCode == true)
            {
                m_oVendor.MaxVendorMasterUpdate();
                DataTable dtComp = new DataTable();
                dtComp = VendorBL.GetVendorCodeRegen();
                if (dtComp.Rows.Count > 0)
                {
                    for (int i = 0; i < dtComp.Rows.Count; i++)
                    {
                        int iVendId = Convert.ToInt32(clsStatic.IsNullCheck(dtComp.Rows[i]["VendorId"], clsStatic.datatypes.vartypenumeric));
                        string s_Code = "";
                        s_Code = VendorBL.GetCodeCheckVendor();
                        VendorBL.MaxIncVendorMasterUpdate(iVendId, s_Code);
                    }
                }
                MessageBox.Show("Code Regeneration Successfully");
            }
        }

    }
}
