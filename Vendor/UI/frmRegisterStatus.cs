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
    public partial class frmRegisterStatus : Form
    {
        DataTable m_tStatus;
        bool m_bAns = false;
        Vendor.BusinessLayer.StatusBL m_oStatus;
        Vendor.BusinessLayer.RegisterBL m_oRegister;
        Vendor.BusinessLayer.RegUpdateBL m_oRegUpdate;

        public frmRegisterStatus()
        {
            InitializeComponent();
            m_oStatus = new Vendor.BusinessLayer.StatusBL();
            m_oRegister = new Vendor.BusinessLayer.RegisterBL();
            m_oRegUpdate = new Vendor.BusinessLayer.RegUpdateBL();
        }

        public void Execute()
        {
            this.ShowDialog();
        }
        private void toolStripAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRegTrans Status = new frmRegTrans();
            Status.Execute(0, 0, "","");
            PopulateGrid();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmRegisterStatus_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
             m_bAns = false;
             toolStripFilter.EditValue = "ALL";
             toolStripType.EditValue = "ALL";
            //toolStripFilter.SelectedIndex = 0;
            //toolStripType.SelectedIndex = 0;
            PopulateVendor();
            
            PopulateGrid();
           
            m_bAns = true;
            this.ResumeLayout();
        }

        private void PopulateGrid()
        {
            m_tStatus = new DataTable();
            m_tStatus = m_oStatus.GetStatusRegister();
            string sFilter = "1=1";
            if (toolStripFilter.EditValue.ToString() != "ALL")
            {
                sFilter = sFilter + " and Status = '" + toolStripFilter.EditValue + "'";
            }
            

            if (toolStripType.EditValue.ToString() != "ALL")
            {
                if (toolStripType.EditValue.ToString() == "Supply") { sFilter = sFilter + " and Supply = true"; }
                else if (toolStripType.EditValue.ToString() == "Contract") { sFilter = sFilter + " and Contract = true"; }
                else if (toolStripType.EditValue.ToString() == "Service") { sFilter = sFilter + " and Service = true"; }
            }
            if (Convert.ToInt32(toolStripVendor.EditValue) > 0)
            {
                sFilter = sFilter + " and VendorId = " + Convert.ToInt32(toolStripVendor.EditValue);
            }

            DataView dv;
            DataTable dt;
            dv = new DataView(m_tStatus);
            dv.RowFilter = sFilter;
            dt = dv.ToTable();
            grdTrans.DataSource = dt;
            TransView.Columns["RegTransID"].Visible = false;
            TransView.Columns["VendorId"].Visible = false;
            TransView.Columns["RDate"].Width = 100;
            TransView.Columns["RefNo"].Width = 100;
            TransView.Columns["RegNo"].Width = 100;
            TransView.Columns["VendorName"].Width = 200;
            TransView.Columns["Status"].Width = 100;
            TransView.Columns["Supply"].Width = 50;
            TransView.Columns["Contract"].Width = 50;
            TransView.Columns["Service"].Width = 50;
            TransView.Columns["RDate"].Caption = "Date";
            TransView.Columns["RefNo"].Caption = "Ref No";
            TransView.Columns["RegNo"].Caption = "Reg No";
            TransView.Columns["VendorName"].Caption = "Vendor Name";
            TransView.Columns["Status"].Caption = "Status";

            //grdTrans.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
        }

        private void toolStripEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TransView.RowCount > 0)
            {
                if (TransView.FocusedRowHandle >= 0)
                {
                    if (TransView.GetRowCellValue(TransView.FocusedRowHandle, "Status").ToString() == "Register")
                    {
                        MessageBox.Show("Registration Not Edit");
                        return;
                    }
                    int lRegTransId = Convert.ToInt32(TransView.GetRowCellValue(TransView.FocusedRowHandle, "RegTransID"));
                    int lVendorId = Convert.ToInt32(TransView.GetRowCellValue(TransView.FocusedRowHandle, "VendorId"));
                    string sVendorName = TransView.GetRowCellValue(TransView.FocusedRowHandle, "VendorName").ToString();
                    string sRegNo = TransView.GetRowCellValue(TransView.FocusedRowHandle, "RegNo").ToString();
                    frmRegTrans sts = new frmRegTrans();
                    sts.Execute(lRegTransId, lVendorId, sVendorName,sRegNo);
                    PopulateGrid();
                }
            }
        }

        private void toolStripDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TransView.RowCount > 0)
            {
                if (TransView.FocusedRowHandle >= 0)
                {
                    if (TransView.GetRowCellValue(TransView.FocusedRowHandle, "Status").ToString() == "Register")
                    {
                        MessageBox.Show("Registration Not Delete");
                        return;
                    }

                    int Id = Convert.ToInt32(TransView.GetRowCellValue(TransView.FocusedRowHandle, "RegTransID"));
                    int lVendorId = Convert.ToInt32(TransView.GetRowCellValue(TransView.FocusedRowHandle, "VendorId"));
                    if (Id != m_oRegister.GetMaxRegTransId(lVendorId))
                    {
                        MessageBox.Show("Do Not Delete!");
                        return;
                    }
                    DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (reply == DialogResult.Yes)
                    {
                        m_oRegister.DeleteRegTrans(Id);
                        TransView.DeleteRow(TransView.FocusedRowHandle);
                        //grdTrans.Rows.RemoveAt(grdTrans.CurrentRow.Index);
                        m_oRegUpdate.UpdateRegistration(lVendorId);
                    }
                }
            }
        }     
        private void toolStripFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }
            PopulateGrid();
        }

        private void toolStripType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }
            PopulateGrid();
        }

        private void PopulateVendor()
        {
	        DataTable dt = new DataTable();
            dt = m_oRegister.GetRegVendorList();
            DataTable dtt = new DataTable();
            dtt = clsStatic.AddSelectToDataTable(dt);
            //toolStripVendor.ComboBox.DataSource = dtt;
            //toolStripVendor.ComboBox.DisplayMember = "VendorName";
            //toolStripVendor.ComboBox.ValueMember = "VendorId";
            //toolStripVendor.ComboBox.SelectedIndex = 0;
            leFilter.DataSource = dtt;
            leFilter.ForceInitialize();
            leFilter.PopulateColumns();
            leFilter.DisplayMember = "VendorName";
            leFilter.ValueMember = "VendorID";
            leFilter.ShowHeader = false;
            leFilter.ShowFooter = false;
            leFilter.Columns[0].Visible = false;
            toolStripVendor.Edit = leFilter;
            toolStripVendor.EditValue = -1;
        }

        private void toolStripVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_bAns == false) { return; }
            PopulateGrid();
        }

        private void frmRegisterStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BsfGlobal.g_bWorkFlow == true)
            {
                if (BsfGlobal.g_bWorkFlowDialog == false) { try { this.Parent.Controls.Owner.Hide(); } catch { } }
            }
        }

        private void barExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        
       

     

     

       

       

    }
}
