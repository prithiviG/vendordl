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
    public partial class frmServiceGroup : Form
    {
        Vendor.BusinessLayer.ServiceBL oService;
        DataTable dtSGroup;
        string SerName = "";
        public frmServiceGroup()
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

        private void frmServiceGroup_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void SGView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //int rowhandleva = TransView.GetDataSourceRowIndex(TransView.FocusedRowHandle);
            //m_oCountry.CountryName = cCName;//TransView.GetRowCellValue(rowhandleva, "CountryName").ToString();
            //if (TransView.IsNewItemRow(TransView.FocusedRowHandle) == true)
            //{
            //    int cId;
            //    cId = m_oCountry.InsertCountry(m_oCountry.CountryName);

            //    //TransView.SetRowCellValue(rowhandleva, "CountryId", cId);
            //    grdTrans.RefreshDataSource();
            //    //grdTrans.CurrentRow.Cells[0].Value = cId;
            //}
            //else
            //{
            //    m_oCountry.CountryId = Convert.ToInt32(TransView.GetRowCellValue(TransView.FocusedRowHandle, "CountryId"));
            //    m_oCountry.UpdateCountry(m_oCountry.CountryId, m_oCountry.CountryName);
            //}
            oService.m_oGroupName=SerName;
            if (SGView.IsNewItemRow(SGView.FocusedRowHandle) == true)
            {
                oService.InsertServiceGroup(oService.m_oGroupName);
            }
            else
            {
                oService.m_oGroupId=Convert.ToInt32(SGView.GetRowCellValue(SGView.FocusedRowHandle, "ServiceGroupId"));
                oService.UpdateServiceGroup(oService.m_oGroupId, oService.m_oGroupName);
            }

            
        }
        private void PopulateGrid()
        {
            dtSGroup = new DataTable();
            dtSGroup = oService.GetServiceGroup();
            grdServiceGroup.DataSource = dtSGroup;
            SGView.Columns["ServiceGroupId"].Visible = false;
        }

        private void SGView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SerName = e.Value.ToString();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                bool status = false;
                status = oService.DeleteServiceGroup(Convert.ToInt32(SGView.GetFocusedRowCellValue("ServiceGroupId")));
                if (status == false)
                {
                    MessageBox.Show("Already Used, Do Not Delete", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                PopulateGrid();
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}
