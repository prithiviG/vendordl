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
    public partial class frmCertificate : Form
    {
        Vendor.BusinessLayer.CertificateBL m_oCer;
        DataTable m_tCer;

        public frmCertificate()
        {
            InitializeComponent();
            m_oCer= new Vendor.BusinessLayer.CertificateBL();
        }

        public void Execute()
        {
            this.ShowDialog();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmCertificate_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }
        private void PopulateGrid()
        {
            m_tCer = new DataTable();
            m_tCer = m_oCer.GetCertificate();
            grdCertificate.DataSource = m_tCer;


            CerView.Columns["CertificateId"].Visible = false;

            CerView.Columns["CerDescription"].Width = 250;
            CerView.Columns["CerDescription"].Caption = "Description";

            //grdTrans.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);

            m_tCer.AcceptChanges();

        }

     

        private void grdTrans_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == (DataGridViewDataErrorContexts.Formatting | DataGridViewDataErrorContexts.PreferredSize))
            {
                e.ThrowException = false;
            }
        }
  
      

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_tCer.GetChanges() != null)
            {
                m_oCer.UpdateCertificate(m_tCer);
            }
            this.Close();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                bool status = false;
                status = m_oCer.DeleteCertificate(Convert.ToInt32(CerView.GetFocusedRowCellValue("CertificateId")));

                if (status == false)
                {
                    MessageBox.Show("Already Used, Do Not Delete", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    CerView.DeleteRow(CerView.FocusedRowHandle);
                }
                PopulateGrid();
            }
        }
    }
}
