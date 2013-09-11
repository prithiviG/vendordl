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
    public partial class frmCityMaster : Form
    {
        Vendor.BusinessLayer.CityBL m_oCity;
        DataTable m_tCity;
        frmBranch frm;
        frmMain frmM;
        public frmCityMaster()
        {
            InitializeComponent();
            m_oCity = new Vendor.BusinessLayer.CityBL();
        }
        public void Execute(frmBranch _frm,frmMain _frmM)
        {
            frm = _frm;
            frmM = _frmM;
            this.ShowDialog();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmCityMaster_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }
        private void PopulateGrid()
        {
            m_tCity = new DataTable();
            m_tCity = m_oCity.GetCityList();
            grdTrans.DataSource = m_tCity;
            TransView.Columns[0].Visible = false;
            TransView.Columns[1].Width = 150;
            TransView.Columns[2].Width = 150;
            TransView.Columns[3].Width = 150;
            TransView.Columns[1].Caption = "City";
            TransView.Columns[2].Caption = "State";
            TransView.Columns[3].Caption = "Country";
            TransView.Columns[4].Visible = false;
            TransView.Columns[5].Visible = false;
        }      
        private void toolStripAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BsfGlobal.FindPermission("Location-Add") == false)
            {
                MessageBox.Show("No Rights to Location-Add");
                return;
            }

            
            
            frmCityEntry CityEntry = new frmCityEntry();
            if (CityEntry.Execute(0, m_tCity) == true)
            {
                PopulateGrid();
            }
        }       
        private void toolStripEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            if (BsfGlobal.FindPermission("Location-Edit") == false)
            {
                MessageBox.Show("No Rights to Location-Edit");
                return;
            }

            
            
            int lCityID = Convert.ToInt32(TransView.GetRowCellValue(TransView.FocusedRowHandle, "CityId"));
            frmCityEntry CityEntry = new frmCityEntry();
            if (CityEntry.Execute(lCityID, m_tCity) == true)
            {
                PopulateGrid();
            }
        }

        private void toolStripExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmCityMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BsfGlobal.g_bWorkFlow == true)
            {
                if (BsfGlobal.g_bWorkFlowDialog == false) { try { this.Parent.Controls.Owner.Hide(); } catch { }}
            }
        }

        private void toolStripDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BsfGlobal.FindPermission("Location-Delete") == false)
            {
                MessageBox.Show("No Rights to Location-Edit");
                return;
            }
            
            
            bool status = false;
            int CityId=Convert.ToInt32(TransView.GetFocusedRowCellValue("CityId"));
            status = m_oCity.CheckCity(CityId);

            if (status == false)
            {
                MessageBox.Show("Already Used, Do Not Delete", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reply == DialogResult.Yes)
                {
                    m_oCity.DeleteCity(CityId);
                    TransView.DeleteRow(TransView.FocusedRowHandle);
                }
            }
        }

      }
}
