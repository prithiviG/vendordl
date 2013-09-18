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
    public partial class frmCheckList : Form
    {

        DataTable m_tCheckList;

        Vendor.BusinessLayer.CheckListBL m_oCheckList;

        public frmCheckList()
        {
            InitializeComponent();
            m_oCheckList = new Vendor.BusinessLayer.CheckListBL();
        }
        public void Execute()
        {
            this.ShowDialog();
        }
        private void grdTrans_Click(object sender, EventArgs e)
        {

        }
        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmCheckList_Load(object sender, EventArgs e)
        {
            if (BsfGlobal.FindPermission("Vendor-Assessment-Master-Add") == false)
            {
                TransView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            else
            {
                TransView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            }

            if (BsfGlobal.FindPermission("Vendor-Assessment-Master-Edit") == false)
            {
                TransView.OptionsBehavior.Editable = false;
            }
            else
            {
                TransView.OptionsBehavior.Editable = true;
            }


            PopulateGrid();
        }

        private void PopulateGrid()
        {
            m_tCheckList = new DataTable();
            m_tCheckList = m_oCheckList.GetCheckListMastert();

            grdTrans.DataSource = m_tCheckList;
            TransView.Columns[0].Visible = false;
            TransView.Columns[1].Width = 250;
            TransView.Columns[2].Width = 60;
            TransView.Columns[3].Width = 60;
            TransView.Columns[4].Width = 60;
            TransView.Columns[5].Width = 100;
            TransView.Columns[1].Caption = "Description";
            TransView.Columns[2].Caption = "Supply";
            TransView.Columns[3].Caption = "Contract";
            TransView.Columns[4].Caption = "Service";
            TransView.Columns[5].Caption = "Max Points";
            //TransView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            TransView.Columns[5].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            //TransView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
        }
        private void toolStripExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TransView.FocusedRowHandle = TransView.FocusedRowHandle + 1;
            if (m_tCheckList.GetChanges() != null)
            {
                m_oCheckList.UpdateCheckList(m_tCheckList);
            }
            this.Close();
        }

        private void grdTrans_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            if (e.Context == (DataGridViewDataErrorContexts.Formatting | DataGridViewDataErrorContexts.PreferredSize))
            {
                e.ThrowException = false;
            }
        }
        private void grdTrans_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);


            if (TransView.FocusedColumn.FieldName == "MaxPoint")
            {
                if (!char.IsNumber(e.KeyChar))
                    e.Handled = true;
                else e.Handled = false;
                if (e.KeyChar == 8)
                    e.Handled = false;
            }



            if (e.KeyChar == '.')
            {
                char[] c = (((System.Windows.Forms.TextBoxBase)(sender))).Text.ToString().ToCharArray();
                int cnt = 1;
                foreach (char b in c)
                {
                    if (b == '.')
                    {
                        cnt += 1;
                    }
                }
                if (cnt > 1)
                {
                    e.Handled = true;
                }
                else { e.Handled = false; }
            }
        }
      

        private void grdTrans_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //TextBox txtbox = e.Control as TextBox;
            //if (txtbox != null)
            //{
            //    txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            //}
        }

        private void grdTrans_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[2].Value = 0;
            e.Row.Cells[3].Value = false;
            e.Row.Cells[4].Value = false;
            e.Row.Cells[5].Value = 0;
        }


        private void grdTrans_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 1)
            //{
            //    if (string.IsNullOrEmpty(grdTrans.CurrentRow.Cells[1].Value.ToString()) == true)
            //    {
            //        grdTrans.CancelEdit();
            //    }
            //}
        }

        private void TransView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            TransView.SetRowCellValue(e.RowHandle, "Supply", false);
            TransView.SetRowCellValue(e.RowHandle, "Contract", false);
            TransView.SetRowCellValue(e.RowHandle, "Service", false);
            TransView.SetRowCellValue(e.RowHandle, "MaxPoint", 0);
        }

        private void frmCheckList_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BsfGlobal.g_bWorkFlow == true)
            {
                if (BsfGlobal.g_bWorkFlowDialog == false) { try { this.Parent.Controls.Owner.Hide(); } catch { } }
            }
        }

        private void toolStripDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BsfGlobal.FindPermission("Vendor-Assessment-Master-Delete") == false)
            {
                MessageBox.Show("No Rights to Vendor-Assessment-Master-Delete");
                return;
            }

            
            
            if (TransView.FocusedRowHandle < 0) { return; }

            int Id = 0;
            if (TransView.GetRowCellValue(TransView.FocusedRowHandle, "CheckListId").ToString() == "" )
            {
                TransView.DeleteRow(TransView.FocusedRowHandle);
                return;
            }
            Id = Convert.ToInt32(TransView.GetRowCellValue(TransView.FocusedRowHandle, "CheckListId"));
            if (m_oCheckList.CheckListFound(Id) == true)
            {
                MessageBox.Show("Already Used, Do Not Delete");
                return;
            }

            DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reply == DialogResult.Yes)
            {
                m_oCheckList.DeleteCheckList(Id);
                TransView.DeleteRow(TransView.FocusedRowHandle);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BsfGlobal.FindPermission("Vendor-Master-Type-Setup") == false)
            {
                MessageBox.Show("No Rights to Vendor-Master-Type-Setup");
                return;
            }
            
            frmTypeSetup frm = new frmTypeSetup();
            frm.ShowDialog();
        }

       
    }
}
