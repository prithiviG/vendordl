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
    public partial class frmResourceGroup : Form
    {
        Vendor.BusinessLayer.CapabilityBL m_oCapability;       
        int iVendorId = 0;
        DataTable m_tResource;
        DataTable m_tReturn = null;
       
        public frmResourceGroup()
        {
            InitializeComponent();
            m_oCapability = new Vendor.BusinessLayer.CapabilityBL();           
        }

        public DataTable Execute(string argType, int argVendorId)
        {            
            iVendorId = argVendorId;
            ShowDialog();
            return m_tReturn;
        }

        private void PopulateGrid()
        {
            m_tResource = new DataTable();
            m_tResource = m_oCapability.GetResourceGroup(iVendorId);                              
            grdTrans.DataSource = m_tResource;
            TransView.Columns["Resource_Group_ID"].Visible = false;
            TransView.Columns["Resource_Group_Name"].Width = 250;
            TransView.Columns["Resource_Group_Name"].Caption = "Resource Group Name";
            TransView.Columns["Resource_Group_Name"].OptionsColumn.AllowEdit = false;         
            TransView.Columns["Select"].Width = 40;
            TransView.Columns["Select"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            TransView.Columns["Select"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;         
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmResourceGroup_Load(object sender, EventArgs e)
        {
            PopulateGrid();         
        }      

        private void barExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_tReturn = null;
            Close();
        }

        private void cmdOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TransView.FocusedRowHandle = TransView.FocusedRowHandle + 1;
            grdTrans.RefreshDataSource();
            DataTable dtU = new DataTable();
            dtU = grdTrans.DataSource as DataTable;            
            DataView dv = new System.Data.DataView(dtU);
            dv.RowFilter = "Select=True";          
            m_tReturn = dv.ToTable();  
           
            Close();
        }

        private void cmdCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_tReturn = null;
            Close();
        }

    }
}
