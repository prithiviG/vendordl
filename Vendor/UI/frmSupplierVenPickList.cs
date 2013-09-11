using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vendor.BusinessLayer;
using DevExpress.XtraEditors;

namespace Vendor
{
    public partial class frmSupplierVenPickList : Form
    {
        #region Variables

        int m_iVenId = 0;
        public DataTable m_dtRtn;
        string m_sItemId = "";
        string m_sSuppType = "";
        #endregion

        #region Constructor

        public frmSupplierVenPickList()
        {
            InitializeComponent();
        }

        #endregion

        #region Functions

        private void PopulateGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = VendorBL.PopulateVendorDetList(m_iVenId, m_sSuppType, m_sItemId);
                grdAsset.DataSource = dt;
                //VendorId,VendorName
                grdViewAsset.Columns["VendorId"].Visible = false;                
                grdViewAsset.Columns["Sel"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grdViewAsset.Columns["VendorName"].OptionsColumn.AllowEdit = false;
                grdViewAsset.Columns["VendorName"].Width = 240;
                grdViewAsset.Columns["Sel"].Width = 50;
                grdViewAsset.OptionsView.ColumnAutoWidth = true;
                grdViewAsset.Appearance.HeaderPanel.Font = new Font(grdViewAsset.Appearance.HeaderPanel.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
        }
   
        public DataTable Execute(int argVendorId, string argSuppType, string argTransId)
        {
            m_iVenId = argVendorId;
            m_sSuppType = argSuppType;
            m_sItemId = argTransId;
            ShowDialog();
            return m_dtRtn;
        }
        #endregion

        #region Button Events

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdViewAsset.FocusedRowHandle = grdViewAsset.FocusedRowHandle + 1;
            m_dtRtn = new DataTable();
            DataTable dtM = new DataTable();
            dtM = grdAsset.DataSource as DataTable;
            DataView dv = new DataView(dtM);
            if (dtM != null)
            {
                dv.RowFilter = "Sel=" + true + "";
                m_dtRtn = dv.ToTable();
            }
            Close();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        #endregion

        #region Form Events
        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmSupplierVenPickList_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        #endregion
    }
}
