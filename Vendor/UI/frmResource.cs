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
    public partial class frmResource : Form
    {
        Vendor.BusinessLayer.CapabilityBL m_oCapability;
        Projects.CodeTypeBLR m_oCodeType;
        
        int m_lTypeId=0;
        string m_sTypeId = "";
        DataTable m_tResource;
        DataTable m_tReturn = null;
        GridSelectAll selection;

        public frmResource()
        {
            InitializeComponent();
            m_oCapability = new Vendor.BusinessLayer.CapabilityBL();
            m_oCodeType = new Projects.CodeTypeBLR();
        }

        public DataTable Execute(string argType)
        {
            if (argType == "L") { m_lTypeId = 1; m_sTypeId = "1"; }
            else if (argType == "A") { m_lTypeId = 3; m_sTypeId = "3"; }
            else if (argType == "M") { m_lTypeId = 2; m_sTypeId = "2,3"; }
            ShowDialog();
            return m_tReturn;
        }

        private void PopulateGrid(int argGId)
        {
            m_tResource = new DataTable();

            m_tResource = m_oCapability.GetResource(m_lTypeId, m_sTypeId);
            if (argGId > 0)
            {
                DataView dv = new DataView(m_tResource);
                dv.RowFilter = "Resource_Group_Id=" + argGId + " ";
                m_tResource = dv.ToTable();
            }
            
            //DataColumn dtcCheck = new DataColumn("Select");//create the data          
            ////column object with the name 
            //dtcCheck.DataType = System.Type.GetType("System.Boolean");//Set its 
            ////data Type    
            //dtcCheck.DefaultValue = false;//Set the default value
            //m_tResource.Columns.Add(dtcCheck);//Add the above column to the 
            //if(TransView.Columns.Count == 7)
            //    TransView.Columns.RemoveAt(6);
            grdTrans.DataSource = m_tResource;
            //selection = new GridSelectAll(TransView);
            //selection.CheckMarkColumn.VisibleIndex = 3;

            //TransView.Columns["Select"].Visible = false;
            TransView.Columns["Resource_ID"].Visible = false;
            TransView.Columns["Code"].Width = 80;
            TransView.Columns["Resource_Name"].Width = 150;
            TransView.Columns["Resource_Name"].Caption = "Resource Name";

            TransView.Columns["Unit_Name"].Visible = false;
            TransView.Columns["Resource_Group_Id"].Visible = false;
            TransView.Columns["Code"].OptionsColumn.AllowEdit = false;
            TransView.Columns["Resource_Name"].OptionsColumn.AllowEdit = false;
            //TransView.Columns["CheckMarkSelection"].Width = 40;
            TransView.Columns["Select"].Width = 40;
            TransView.Columns["Select"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            TransView.Columns["Select"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //grdTrans.Columns["Sel"].ReadOnly = false;
            //TransView.BestFitColumns();
            //TransView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
            //for (int i = 0; i < m_tResource.Rows.Count; i++)
            //{
            //    bool j =Convert.ToBoolean(m_tResource.Rows[i]["Select"]);
            //    TransView.SetRowCellValue(i, selection.CheckMarkColumn, j);
            //}

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmResource_Load(object sender, EventArgs e)
        {
            PopulateGrid(Convert.ToInt32(cboMGroup.EditValue));
            PopulateMGroup();
        }      

        private void barExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_tReturn = null;
            Close();
        }

        private void grdTrans_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (Convert.ToBoolean(grdTrans.CurrentRow.Cells["Sel"].Value.ToString()) == true)
            //{
            //    grdTrans.CurrentRow.Cells["Sel"].Value = false;
            //}
            //else
            //{
            //    grdTrans.CurrentRow.Cells["Sel"].Value = true;
            //}
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Projects.frmResourceAddR frm = new Projects.frmResourceAddR();
            if (m_lTypeId == 1)
            {
                frm.Execute(0, m_lTypeId, 0, 0, 0,false);
            }
            else if (m_lTypeId == 3)
            {
                frm.Execute(0, m_lTypeId, 0, 0, 0,false);
            }
            PopulateGrid(Convert.ToInt32(cboMGroup.EditValue));
        }

        private void PopulateMGroup()
        {
            DataTable dtMGroup = CapabilityBL.GetMGroup(m_lTypeId);
            DataRow dr = dtMGroup.NewRow();
            dr["Resource_Group_Id"] = 0;
            dr["Resource_Group_Name"] = "All";
            dtMGroup.Rows.InsertAt(dr, 0);               
            repositoryItemLookUpEdit1.DataSource = dtMGroup;
            repositoryItemLookUpEdit1.ValueMember = "Resource_Group_Id";
            repositoryItemLookUpEdit1.DisplayMember = "Resource_Group_Name";
            repositoryItemLookUpEdit1.PopulateColumns();
            repositoryItemLookUpEdit1.ForceInitialize();
            repositoryItemLookUpEdit1.ShowHeader = false;
            repositoryItemLookUpEdit1.ShowFooter = false;
            repositoryItemLookUpEdit1.Columns["Resource_Group_Id"].Visible = false;
            cboMGroup.EditValue = 0;
        }

        private void cboMGroup_EditValueChanged(object sender, EventArgs e)
        {
                PopulateGrid(Convert.ToInt32(cboMGroup.EditValue));
        }

        private void cmdOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TransView.FocusedRowHandle = TransView.FocusedRowHandle + 1;
            grdTrans.RefreshDataSource();
            DataTable dtU = new DataTable();
            dtU = grdTrans.DataSource as DataTable;

            //if (dtU != null)
            //{
            //    if (selection.SelectedCount == 0)
            //    {
            //        m_tResource = dtU;
            //        for (int i = 0; i < m_tResource.Rows.Count; i++) { m_tResource.Rows[i]["Select"] = false; }
            //    }
            //    else if (selection.SelectedCount == dtU.Rows.Count)
            //    {
            //        m_tResource = dtU;
            //        for (int i = 0; i < m_tResource.Rows.Count; i++) { m_tResource.Rows[i]["Select"] = true; }
            //    }
            //    else
            //    {
            //        for (int i = 0; i < dtU.Rows.Count; i++)
            //        {
            //            bool j = Convert.ToBoolean(selection.IsRowSelected(i).ToString());
            //            if (j == true)
            //            {
            //                dtU.Rows[i]["Select"] = true;
            //            }
            //            else
            //            {
            //                dtU.Rows[i]["Select"] = false;
            //            }
            //        }
            //        m_tResource = dtU;
            //    }
            //}
            DataView dv = new System.Data.DataView(dtU);
            dv.RowFilter = "Select=True";
            //m_tResource = dv.ToTable();
            m_tReturn = dv.ToTable();  
            //m_tReturn = new DataTable();

            //DataView dvData = new DataView(m_tResource);
            //dvData.RowFilter = "Select = '" + true + "'";
            //m_tReturn = dvData.ToTable();
            Close();
        }

        private void cmdCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_tReturn = null;
            Close();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
