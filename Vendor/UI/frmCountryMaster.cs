using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Vendor
{
    public partial class frmCountryMaster : Form
    {
        Vendor.BusinessLayer.CountryBL m_oCountry;
        bool m_bEdit = false;
        string cCName = "";
        bool m_bAns = false;
        //string m_sOldString="";
        //bool m_bNew=false;
        public bool m_CRefresh = false;
        public frmCountryMaster()
        {      
            InitializeComponent();
            m_oCountry = new Vendor.BusinessLayer.CountryBL();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmCountryMaster_Load(object sender, EventArgs e)
        {           
            PopulateGrid();           
        }
        public void Execute()
        {
            this.ShowDialog();
        }
        private void PopulateGrid()
        {
            m_bAns = false;
            DataTable dt;
            dt= new DataTable();
            dt = m_oCountry.GetCountryList();
            grdTrans.DataSource = dt;
            TransView.Columns[0].Visible = false;
            TransView.Columns[1].Width = 220;
            m_bAns = true;
            
        }     
        private void toolStripExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void grdTrans_DoubleClick_1(object sender, EventArgs e)
        {
            m_bEdit = true;
            TransView.Columns["CountryName"].OptionsColumn.AllowEdit = true;
        }    
        private void TransView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (m_bAns == false) { return; }

            int rowhandleva = TransView.GetDataSourceRowIndex(TransView.FocusedRowHandle);
            m_oCountry.CountryName = cCName;
            if (TransView.IsNewItemRow(TransView.FocusedRowHandle) == true)
            {
                int cId;
                cId = m_oCountry.InsertCountry(m_oCountry.CountryName);
                m_bAns = false;
                TransView.SetRowCellValue(TransView.FocusedRowHandle, "CountryId", cId);
                m_bAns = true;
            }
            else
            {
                m_oCountry.CountryId = Convert.ToInt32(TransView.GetRowCellValue(TransView.FocusedRowHandle, "CountryId"));
                m_oCountry.UpdateCountry(m_oCountry.CountryId, m_oCountry.CountryName);
            }
            m_bEdit = false;          
        }

        private void toolStripDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int CountryId = Convert.ToInt32(TransView.GetFocusedRowCellValue("CountryId"));
            bool status = m_oCountry.CheckCountry(CountryId);
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
                    m_oCountry.DeleteCountry(CountryId);
                    TransView.DeleteRow(TransView.FocusedRowHandle);
                }
            }
        }

        private void TransView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 113)
            {
                m_bEdit = true;
                TransView.Columns["CountryName"].OptionsColumn.AllowEdit = true;
            }                              
        }

        private void TransView_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (m_bEdit == false)
                e.Cancel = true;
        }

        private void TransView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            m_bEdit = false;
        }

        private void TransView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (m_bAns == false) { return; }
            cCName = e.Value.ToString();
        }

        

        private void TransView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            this.TransView.AddNewRow();
        }

        private void grdTrans_Validated(object sender, EventArgs e)
        {

        }  
    }
}
