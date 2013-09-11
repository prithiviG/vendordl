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
using DevExpress.XtraEditors;

namespace Vendor
{
    public partial class frmVendorFilter : Form
    {
        DataTable m_tCity;
        DataTable m_tCertificate;
        DataTable m_tMaterial;
        DataTable m_tMaterialGroup;
        DataTable m_tWorkGroup;
        DataTable m_tActivity;
        DataTable m_tService;
        DataTable m_tMachinery;
        DataTable m_tGrade;
        string m_sSql = "";
        Vendor.BusinessLayer.VendorBL m_oVendor;
        public frmVendorFilter()
        {
            InitializeComponent();
            m_oVendor = new Vendor.BusinessLayer.VendorBL();
        }
        public string Execute()
        {
            this.ShowDialog();
            return m_sSql;
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            m_sSql = "";
            this.Close();
        }   
        private void chkType_CheckedChanged(object sender, EventArgs e)
        {
            if (chkType.Checked == true)
            {
                chkSupplier.Enabled = true;
                chkService.Enabled = true;
                chkContract.Enabled = true;
            }
            else
            {
                chkSupplier.Enabled = false;
                chkService.Enabled = false;
                chkContract.Enabled = false;
                chkSupplier.Checked = false;
                chkService.Checked = false;
                chkContract.Checked = false;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmVendorFilter_Load(object sender, EventArgs e)
        {
            chkSupplier.Enabled = false;
            chkService.Enabled = false;
            chkContract.Enabled = false;
            chklbCityList.Enabled = false;
            chklbLocation.Enabled = false;
            chklbCertificate.Enabled = false;
            chklbMaterial.Enabled = false;
            chklbMaterialGroup.Enabled = false;
            chklbWorkGroup.Enabled = false;
            chklbActivityGroup.Enabled = false;
            chklbService.Enabled = false;
            chklbMachinary.Enabled = false;
            chklbGrade.Enabled = false;
            PopulateData();
            PopulateCity();
            PopulateLocation();
            PopulateCertificate();
            PopulateMaterial();
            PopulateMaterialGP();
            PopulateWorkGP();
            PopulateActivityGP();
            PopulateService();
            PopulateMachinary();
            PopulateGrade();
        }    
        private void PopulateData()
        {
            DataSet ds = new DataSet();
            m_tCity = new DataTable();
            m_tCertificate = new DataTable();
            m_tMaterial = new DataTable();
            m_tMaterialGroup = new DataTable();
            m_tWorkGroup = new DataTable();
            m_tActivity = new DataTable();
            m_tService = new DataTable();
            m_tMachinery = new DataTable();
            m_tGrade = new DataTable();       
            ds = m_oVendor.GetFilterInfo();
            m_tCity = ds.Tables[0];
            m_tCertificate = ds.Tables[1];
            m_tMaterial = ds.Tables[2];
            m_tMaterialGroup = ds.Tables[3];
            m_tWorkGroup = ds.Tables[4];
            m_tActivity = ds.Tables[5];
            m_tService = ds.Tables[8];
            m_tMachinery = ds.Tables[6];
            m_tGrade = ds.Tables[7];
            ds = null;          
        }
        private void PopulateCity()
        {
            chklbCityList.DataSource = null;
            chklbCityList.DataSource = m_tCity;
            chklbCityList.DisplayMember = "CityName";
            chklbCityList.ValueMember = "CityId";
        }
        private void PopulateLocation()
        {
            chklbLocation.DataSource = null;
            chklbLocation.DataSource = m_tCity;
            chklbLocation.DisplayMember = "CityName";
            chklbLocation.ValueMember = "CityId";
        }
        private void PopulateCertificate()
        {
            chklbCertificate.DataSource = null;
            chklbCertificate.DataSource = m_tCertificate;
            chklbCertificate.DisplayMember = "CerDescription";
            chklbCertificate.ValueMember = "CertificateId";
        }
        private void PopulateMaterial()
        {
            chklbMaterial.DataSource = null;
            chklbMaterial.DataSource = m_tMaterial;
            chklbMaterial.DisplayMember = "Resource_Name";
            chklbMaterial.ValueMember = "Resource_Id";
        }
        private void PopulateMaterialGP()
        {
            chklbMaterialGroup.DataSource = null;
            chklbMaterialGroup.DataSource = m_tMaterialGroup;
            chklbMaterialGroup.DisplayMember = "Resource_Group_Name";
            chklbMaterialGroup.ValueMember = "Resource_Group_Id";
        }
        private void PopulateWorkGP()
        {
            chklbWorkGroup.DataSource = null;
            chklbWorkGroup.DataSource = m_tWorkGroup;
            chklbWorkGroup.DisplayMember = "Work_Group_Name";
            chklbWorkGroup.ValueMember = "Work_Group_Id";
        }
        private void PopulateActivityGP()
        {
            chklbActivityGroup.DataSource = null;
            chklbActivityGroup.DataSource = m_tActivity;
            chklbActivityGroup.DisplayMember = "Resource_Group_Name";
            chklbActivityGroup.ValueMember = "Resource_Group_Id";
        }
        private void PopulateService()
        {
            chklbService.DataSource = null;
            chklbService.DataSource = m_tService;
            chklbService.DisplayMember = "ServiceName";
            chklbService.ValueMember = "ServiceId";
        }

        private void PopulateMachinary()
        {
            chklbMachinary.DataSource = null;
            chklbMachinary.DataSource = m_tMachinery;
            chklbMachinary.DisplayMember = "Resource_Name";
            chklbMachinary.ValueMember = "Resource_Id";
        }
        private void PopulateGrade()
        {
            chklbGrade.DataSource = null;
            chklbGrade.DataSource = m_tGrade;
            chklbGrade.DisplayMember = "GradeName";
            chklbGrade.ValueMember = "GradeId";
        }
        private void chkCity_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCity.Checked == true)
            {
                chklbCityList.Enabled = true;
            }
            else
            {
                chklbCityList.Enabled = false;
                for (int i = 0; i <= chklbCityList.Items.Count - 1; i++)
                {
                    if (chklbCityList.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbCityList.SetItemChecked(i, false);
                    }
                }    
            }

        }

        private void chkLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLocation.Checked == true)
            {
                chklbLocation.Enabled = true;
            }
            else
            {
                chklbLocation.Enabled = false;
                for (int i = 0; i <= chklbLocation.Items.Count - 1; i++)
                {
                    if (chklbLocation.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbLocation.SetItemChecked(i, false);
                    }
                }
            }

        }
        private void chkCertificate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCertificate.Checked == true)
            {
                chklbCertificate.Enabled = true;
            }
            else
            {
                chklbCertificate.Enabled = false;
                for (int i = 0; i <= chklbCertificate.Items.Count - 1; i++)
                {
                    if (chklbCertificate.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbCertificate.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void chkMaterial_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaterial.Checked == true)
            {
                chklbMaterial.Enabled = true;
            }
            else
            {      
                chklbMaterial.Enabled = false;
                for (int i = 0; i <= chklbMaterial.Items.Count - 1; i++)
                {
                    if (chklbMaterial.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbMaterial.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void chkMaterialGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaterialGroup.Checked == true)
            {
                chklbMaterialGroup.Enabled = true;
            }
            else
            {
                chklbMaterialGroup.Enabled = false;
                for (int i = 0; i <= chklbMaterialGroup.Items.Count - 1; i++)
                {
                    if (chklbMaterialGroup.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbMaterialGroup.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void chkWorkGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWorkGroup.Checked == true)
            {
                chklbWorkGroup.Enabled = true;
            }
            else
            {
                chklbWorkGroup.Enabled = false;
                for (int i = 0; i <= chklbWorkGroup.Items.Count - 1; i++)
                {
                    if (chklbWorkGroup.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbWorkGroup.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void chkActivityGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivityGroup.Checked == true)
            {
                chklbActivityGroup.Enabled = true;
            }
            else
            {
                chklbActivityGroup.Enabled = false;
                for (int i = 0; i <= chklbActivityGroup.Items.Count - 1; i++)
                {
                    if (chklbActivityGroup.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbActivityGroup.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void chkServicee_CheckedChanged(object sender, EventArgs e)
        {
            if (chkServicee.Checked == true)
            {
                chklbService.Enabled = true;
            }
            else
            {
                chklbService.Enabled = false;
                for (int i = 0; i <= chklbService.Items.Count - 1; i++)
                {
                    if (chklbService.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbService.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void chkMachinary_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMachinary.Checked == true)
            {
                chklbMachinary.Enabled = true;
            }
            else
            {
                chklbMachinary.Enabled = false;
                for (int i = 0; i <= chklbMachinary.Items.Count - 1; i++)
                {
                    if (chklbMachinary.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbMachinary.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void chkGrade_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGrade.Checked == true)
            {
                chklbGrade.Enabled = true;
            }
            else
            {
                chklbGrade.Enabled = false;
                for (int i = 0; i <= chklbGrade.Items.Count - 1; i++)
                {
                    if (chklbGrade.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbGrade.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            string sFilter = "Filtered By ";
            string sSql = "";
            string sStr = "";
           // ,VendorName,Supply,Contract,Service
            sSql = "Select VendorId from VendorMaster where 1=1";
            if (chkType.Checked == true)
            {
                sFilter = sFilter + "[Type- ";
                if (chkSupplier.Checked == true)
                {
                    sSql = sSql + " and Supply=1";
                    sFilter = sFilter + "Supplier ";
                }
                if (chkContract.Checked == true)
                {
                    sSql = sSql + " and Contract=1";
                    if(chkSupplier.Checked == true)
                        sFilter = sFilter + ",Contractor ";
                    else
                        sFilter = sFilter + "Contractor ";
                }
                if (chkService.Checked == true)
                {
                    sSql = sSql + " and Service=1";
                    if(chkSupplier.Checked == true || chkContract.Checked == true)
                        sFilter = sFilter + ",Service Provider ";
                    else
                        sFilter = sFilter + "Service Provider ";
                }
                sFilter = sFilter + "]";
            }
            if (chkCity.Checked == true)
            {
                sFilter = sFilter + "[City- ";
                sStr = "";
                for (int i = 0; i <= chklbCityList.Items.Count - 1; i++)
                {
                    if (chklbCityList.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbCityList.SetSelected(i, true);
                        sStr = sStr + chklbCityList.SelectedValue.ToString().Trim() + ",";
                        sFilter = sFilter + chklbCityList.Text + ",";
                    }
                }
                sFilter = sFilter.TrimEnd(',');
                sFilter = sFilter + "]";
                if (!string.IsNullOrEmpty(sStr))
                {
                    sStr = sStr.Substring(0, sStr.Length - 1);
                    sSql = sSql + " and CityId IN (" + sStr + ")";
                }
            }
            if (chkLocation.Checked == true)
            {
                sFilter = sFilter + "[Location- ";
                sStr = "";
                for (int i = 0; i <= chklbLocation.Items.Count - 1; i++)
                {
                    if (chklbLocation.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbLocation.SetSelected(i, true);
                        sStr = sStr + chklbLocation.SelectedValue.ToString().Trim() + ",";
                        sFilter = sFilter + chklbLocation.Text + ",";
                    }
                }
                sFilter = sFilter.TrimEnd(',');
                sFilter = sFilter + "]";
                if (!string.IsNullOrEmpty(sStr))
                {
                    sStr = sStr.Substring(0, sStr.Length - 1);
                    sSql = sSql + " and VendorID IN (Select VendorId from VendorLocation where CityId IN (" + sStr + "))";
                }
            }
            if (chkCertificate.Checked == true)
            {
                sFilter = sFilter + "Certificate- ";
                sStr = "";
                for (int i = 0; i <= chklbCertificate.Items.Count - 1; i++)
                {
                    if (chklbCertificate.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbCertificate.SetSelected(i, true);
                        sStr = sStr + chklbCertificate.SelectedValue.ToString().Trim() + ",";
                        sFilter=sFilter + chklbCertificate.Text + ",";
                    }
                }
                sFilter = sFilter.TrimEnd(',');
                sFilter = sFilter + "]";
                if (!string.IsNullOrEmpty(sStr))
                {
                    sStr = sStr.Substring(0, sStr.Length - 1);
                    sSql = sSql + " and VendorID IN (Select VendorId from CertificateTrans where CertificateId IN (" + sStr + "))";
                }
            }

            if (chkMaterial.Checked == true)
            {
                sFilter = sFilter + "[Material- ";
                sStr = "";
                for (int i = 0; i <= chklbMaterial.Items.Count - 1; i++)
                {
                    if (chklbMaterial.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbMaterial.SetSelected(i, true);
                        sStr = sStr + chklbMaterial.SelectedValue.ToString().Trim() + ",";
                        sFilter = sFilter + chklbMaterial.Text + ",";
                    }
                }
                sFilter = sFilter.TrimEnd(',');
                sFilter = sFilter + "]";
                if (!string.IsNullOrEmpty(sStr))
                {
                    sStr = sStr.Substring(0, sStr.Length - 1);
                    sSql = sSql + " and VendorID IN (Select VendorId from MaterialTrans where Resource_Id IN (" + sStr + "))";
                }
            }

            if (chkMaterialGroup.Checked == true)
            {
                sFilter = sFilter + "[Material Group- ";
                sStr = "";
                for (int i = 0; i <= chklbMaterialGroup.Items.Count - 1; i++)
                {
                    if (chklbMaterialGroup.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbMaterialGroup.SetSelected(i, true);
                        sStr = sStr + chklbMaterialGroup.SelectedValue.ToString().Trim() + ",";
                        sFilter = sFilter  +  chklbMaterialGroup.Text + ",";
                    }
                }
                sFilter = sFilter.TrimEnd(',');
                sFilter = sFilter + "]";
                if (!string.IsNullOrEmpty(sStr))
                {
                    sStr = sStr.Substring(0, sStr.Length - 1);
                    sSql = sSql + " and VendorID IN (Select VendorId from MaterialGroupTrans where Resource_Group_Id IN (" + sStr + "))";
                }
            }
            if (chkWorkGroup.Checked == true)
            {
                sStr = "";
                sFilter = sFilter + "[Work Group- ";
                for (int i = 0; i <= chklbWorkGroup.Items.Count - 1; i++)
                {
                    if (chklbWorkGroup.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbWorkGroup.SetSelected(i, true);
                        sStr = sStr + chklbWorkGroup.SelectedValue.ToString().Trim() + ",";
                        sFilter = sFilter + chklbWorkGroup.Text + ",";
                    }
                }
                sFilter = sFilter.TrimEnd(',');
                sFilter = sFilter + "]";
                if (!string.IsNullOrEmpty(sStr))
                {
                    sStr = sStr.Substring(0, sStr.Length - 1);
                    sSql = sSql + " and VendorID IN (Select VendorId from WorkGroup where Work_Group_Id IN (" + sStr + "))";
                }
            }
            if (chkActivityGroup.Checked == true)
            {
                sFilter = sFilter + "[Activity Group- ";
                sStr = "";
                for (int i = 0; i <= chklbActivityGroup.Items.Count - 1; i++)
                {
                    if (chklbActivityGroup.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbActivityGroup.SetSelected(i, true);
                        sStr = sStr + chklbActivityGroup.SelectedValue.ToString().Trim() + ",";
                        sFilter = sFilter + chklbActivityGroup.Text + ",";
                    }
                }
                sFilter = sFilter.TrimEnd(',');
                sFilter = sFilter + "]";
                if (!string.IsNullOrEmpty(sStr))
                {
                    sStr = sStr.Substring(0, sStr.Length - 1);
                    sSql = sSql + " and VendorID IN (Select VendorId from ActivityTrans where Resource_Group_Id IN (" + sStr + "))";
                }
            }
            if (chkServicee.Checked == true)
            {
                sFilter = sFilter + "[Service- ";
                sStr = "";
                for (int i = 0; i <= chklbService.Items.Count - 1; i++)
                {
                    if (chklbService.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbService.SetSelected(i, true);
                        sStr = sStr + chklbService.SelectedValue.ToString().Trim() + ",";
                        sFilter = sFilter + chklbService.Text + ",";
                    }
                }
                sFilter = sFilter.TrimEnd(',');
                sFilter = sFilter + "]";
                if (!string.IsNullOrEmpty(sStr))
                {
                    sStr = sStr.Substring(0, sStr.Length - 1);
                    sSql = sSql + " and VendorID IN (Select VendorId from ServiceTrans where ServiceId IN (" + sStr + "))";
                }
            }
            if (chkMachinary.Checked == true)
            {
                sFilter = sFilter + "[Machinery- ";
                sStr = "";
                for (int i = 0; i <= chklbMachinary.Items.Count - 1; i++)
                {
                    if (chklbMachinary.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbMachinary.SetSelected(i, true);
                        sStr = sStr + chklbMachinary.SelectedValue.ToString().Trim() + ",";
                        sFilter = sFilter + chklbMachinary.Text + ",";
                    }
                }
                sFilter = sFilter.TrimEnd(',');
                sFilter = sFilter + "]";
                if (!string.IsNullOrEmpty(sStr))
                {
                    sStr = sStr.Substring(0, sStr.Length - 1);
                    sSql = sSql + " and VendorID IN (Select VendorId from HireMachineryTrans where Resource_Id IN (" + sStr + "))";
                }
            }
            if (chkGrade.Checked == true)
            {
                sFilter = sFilter + "[Grader- ";
                sStr = "";
                for (int i = 0; i <= chklbGrade.Items.Count - 1; i++)
                {
                    if (chklbGrade.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chklbGrade.SetSelected(i, true);
                        sStr = sStr + chklbGrade.SelectedValue.ToString().Trim() + ",";
                        sFilter = sFilter + chklbGrade.Text + ",";
                    }
                }
                sFilter = sFilter.TrimEnd(',');
                sFilter = sFilter + "]";
                if (!string.IsNullOrEmpty(sStr))
                {
                    sStr = sStr.Substring(0, sStr.Length - 1);
                    sSql = sSql + " and VendorID IN (Select VendorId from GradeTrans where CGradeId IN ("+ sStr +") Or SGradeId IN ("+ sStr +") Or HGradeId IN ("+ sStr +") )  ";
                }
            }
            if (chkRegistration.Checked == true)
            {
                sFilter = sFilter + "[Registration- ";
            }
            if ((chkStatusType.Text == "Registered") && (chkStatusType.Text!=""))
            {
                sStr = "";
                sFilter = sFilter + "Registered ";
                sSql = sSql + " and VendorID IN (Select VendorId from RegTrans Where StatusType = 'R') ";
            }
            else if ((chkStatusType.Text == "Suspend") && (chkStatusType.Text != ""))
            {
                sFilter = sFilter + "Suspend ";
                sStr = "";
                sSql = sSql + " and VendorID IN (Select VendorId from RegTrans Where StatusType = 'S') ";
            }
            else if ((chkStatusType.Text == "BlockList") && (chkStatusType.Text != ""))
            {
                sFilter = sFilter + "BlockList ";
                sStr = "";
                sSql = sSql + " and VendorID IN (Select VendorId from RegTrans Where StatusType = 'B') ";

            }
            if (chkRegistration.Checked == true)
            {
                sFilter = sFilter + "]";
            }
            
            m_sSql = sSql;
            m_oVendor.InsertVendorTemp(sSql);

            frmReport objReport = new frmReport();
            string strReportPath = Application.StartupPath + "\\VendorFilterDetails.rpt";
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(strReportPath);
            string[] Datafiles = new string[] { BsfGlobal.g_sVendorDBName };
            objReport.ReportConvert(cryRpt, Datafiles);
            //if (SelectionFormula.Length > 0)
            // cryRpt.RecordSelectionFormula = SelectionFormula;
            objReport.rptViewer.ReportSource = null;
            objReport.rptViewer.ReportSource = cryRpt;
            cryRpt.DataDefinition.FormulaFields["Filter"].Text = " '" + sFilter.ToString() + "'";
            objReport.rptViewer.Refresh();
            objReport.Dock = DockStyle.Fill;
            objReport.Show();

        }

        private void chkStatusType_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (e.State != CheckState.Checked) return;
            CheckedListBoxControl lb = sender as CheckedListBoxControl;
            for (int i = 0; i < lb.ItemCount; i++)
            {
                if (i != e.Index)
                    lb.SetItemChecked(i, false);
            }
        }

        private void chkRegistration_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegistration.Checked == true)
            {
                chkStatusType.Enabled = true;
            }
            else
            {
                chkStatusType.Enabled = false;
            }
        }

     

      

    }
}
