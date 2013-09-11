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
    public partial class frmTransportMaster : Form
    {
        public frmTransportMaster()
        {
            InitializeComponent();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmServiceProviderMaster_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }
        private void PopulateGrid()
        {
            DataTable dt = new DataTable();
            dt = TransportBL.PopulateTransport();
            grdTransport.DataSource = dt;
            grdTransportView.Columns["TransportId"].Visible = false;
        }

        private void grdSProviderView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iTId = 0;
            string sTName = "";
            iTId = Convert.ToInt32(clsStatic.IsNullCheck(grdTransportView.GetFocusedRowCellValue("TransportId"), clsStatic.datatypes.vartypenumeric));
            sTName = Convert.ToString(clsStatic.IsNullCheck(grdTransportView.GetFocusedRowCellValue("TransportName"), clsStatic.datatypes.vartypestring));
            TransportBL.TransportTransaction(iTId, sTName);
            PopulateGrid();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int iTId = Convert.ToInt32(clsStatic.IsNullCheck(grdTransportView.GetFocusedRowCellValue("TransportId"), clsStatic.datatypes.vartypenumeric));
            if (iTId == 0) { grdTransportView.DeleteRow(grdTransportView.FocusedRowHandle); return; }
            if (TransportBL.ValidDelete(iTId) == true)
            {
                TransportBL.DeleteTransport(iTId);
                grdTransportView.DeleteRow(grdTransportView.FocusedRowHandle);
            }
            else
            {
                MessageBox.Show("Already Used! Do Not Delete!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
