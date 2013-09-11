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
    public partial class frmServiceMaster : Form
    {
        Vendor.BusinessLayer.ServiceBL oService;
        DataTable dtSMaster;
        public frmServiceMaster()
        {
            InitializeComponent();
            oService = new BusinessLayer.ServiceBL();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmServiceMaster_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }
        private void PopulateGrid()
        {
            dtSMaster=new DataTable();
            dtSMaster=oService.GetServiceMaster();
            grdSMaster.DataSource = dtSMaster;
            SMView.Columns["ServiceId"].Visible = false;
        }

        private void btnSAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmService frm = new frmService();
            frm.Execute(0);
            PopulateGrid();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmService frm = new frmService();
            frm.Execute(Convert.ToInt32(SMView.GetFocusedRowCellValue("ServiceId")));
            PopulateGrid();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                bool status = false;
                status = oService.DeleteService(Convert.ToInt32(SMView.GetFocusedRowCellValue("ServiceId")));
                if (status == false)
                {
                    MessageBox.Show("Already Used, Do Not Delete", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                PopulateGrid();
            }
        }

        private void frmServiceMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BsfGlobal.g_bWorkFlow == true)
            {
                if (BsfGlobal.g_bWorkFlowDialog == false)
                {
                    try { this.Parent.Controls.Owner.Hide(); }
                    catch { }
                }
            }
        }
    }
}
