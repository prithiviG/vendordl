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
    public partial class frmGrade : Form
    {
        DataTable m_tGrade;

        Vendor.BusinessLayer.GradeBL m_oGrade;

        public frmGrade()
        {
            InitializeComponent();
            m_oGrade = new Vendor.BusinessLayer.GradeBL();
        }

        public void Execute()
        {
            this.ShowDialog();
        }
        private void toolStripExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_tGrade.GetChanges() != null)
            {
                m_oGrade.UpdateGrade(m_tGrade);
            }

            this.Close();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmGrade_Load(object sender, EventArgs e)
        {
            if (BsfGlobal.FindPermission("Vendor-Grade-Master-Add") == false)
            {
                TransView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            else
            {
                TransView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            }

            if (BsfGlobal.FindPermission("Vendor-Grade-Master-Edit") == false)
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
            m_tGrade = new DataTable();
            m_tGrade = m_oGrade.GetGradeMaster();
            grdTrans.DataSource = m_tGrade;
            TransView.Columns[0].Visible = false;
            TransView.Columns[1].Width = 150;
            TransView.Columns[2].Width = 50;
            TransView.Columns[3].Width = 50;
            TransView.Columns[1].Caption = "Grade Name";
            TransView.Columns[2].Caption = ">";
            TransView.Columns[3].Caption = "<=";
            TransView.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            TransView.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            TransView.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            TransView.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //TransView.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //TransView.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //TransView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //TransView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //TransView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            //TransView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            //TransView.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            //TransView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9, FontStyle.Bold);
        }

        private void grdTrans_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

            //if (grdTrans.CurrentRow != null)
            //{
            //    if (grdTrans.RowCount <= 1)
            //    {
            //        e.Row.Cells[2].Value = 0;
            //    }
            //    else
            //    {
            //        e.Row.Cells[2].Value = grdTrans.Rows[grdTrans.RowCount - 2].Cells[3].Value;
            //    }
            //}
            //else
            //{
            //    e.Row.Cells[2].Value = 0;
            //}

            //e.Row.Cells[3].Value = 0;
        }

        private void grdTrans_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }
        private void TransView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
            {
            if (TransView.FocusedColumn.FieldName == "TValue")
            {
                int rHandle = TransView.GetDataSourceRowIndex(TransView.FocusedRowHandle);
                Decimal tValue = Convert.ToDecimal(TransView.GetRowCellValue(rHandle - 1, "TValue"));
                Decimal tCurValue = Convert.ToDecimal(TransView.GetRowCellValue(TransView.FocusedRowHandle, "TValue"));
                if (tCurValue <= tValue)
                {
                    DataRow dr = TransView.GetDataRow(TransView.FocusedRowHandle);
                    dr["TValue"] = 0;
                }
            }
        }
        private void grdTrans_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (TransView.FocusedColumn.FieldName == "GradeName")
            {
                if (TransView.IsNewItemRow(TransView.FocusedRowHandle) == true)
                {
                    if (TransView.RowCount != 1)
                    {
                        if (Convert.ToInt32(TransView.GetRowCellValue(TransView.RowCount - 2, "TValue")) == 0.0)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }


            if (TransView.FocusedColumn.FieldName == "FValue")
            {
                e.Handled = true;
                return;
            }

            if (TransView.FocusedColumn.FieldName == "TValue")
            {
                if (TransView.IsNewItemRow(TransView.FocusedRowHandle) != true)
                {
                    if (TransView.FocusedRowHandle != TransView.RowCount - 2)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }



            if (TransView.FocusedColumn.FieldName == "TValue")
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

            if (TransView.FocusedColumn.FieldName == "TValue")
            {
                if (TransView.IsNewItemRow(TransView.FocusedRowHandle) != true)
                {
                    if (TransView.FocusedRowHandle != TransView.RowCount - 2)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }


        }
        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void grdTrans_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            if (e.Context == (DataGridViewDataErrorContexts.Formatting | DataGridViewDataErrorContexts.PreferredSize))
            {
                e.ThrowException = false;
            }

        }
        private void toolStripDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BsfGlobal.FindPermission("Vendor-Grade-Master-Delete") == false)
            {
                MessageBox.Show("No Rights to Vendor-Grade-Master-Delete");
                return;
            }
            
            if (TransView.FocusedRowHandle >= 0)
            {
                if (TransView.IsNewItemRow(TransView.FocusedRowHandle) == true) { return; }
                if (TransView.FocusedRowHandle != TransView.RowCount - 2) { return; }

                DialogResult reply = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (reply == DialogResult.Yes)
                {
                    int Id = 0;
                    Id = Convert.ToInt32(TransView.GetRowCellValue(TransView.FocusedRowHandle,"GradeId"));
                    m_oGrade.DeleteGrade(Id);
                    //grdTrans.Rows.RemoveAt(grdTrans.CurrentRow.Index);
                    TransView.DeleteRow(TransView.FocusedRowHandle);
                }
            }
        }

        private void TransView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {         
            //if (TransView.FocusedRowHandle >= 0)
            //{
                if (TransView.RowCount <= 1)
                {
                    //e.Row.Cells[2].Value = 0;
                    TransView.SetRowCellValue(TransView.FocusedRowHandle, "FValue", 0);
                }
                else
                {
                    //e.Row.Cells[2].Value = grdTrans.Rows[grdTrans.RowCount - 2].Cells[3].Value;
                    TransView.SetRowCellValue(TransView.FocusedRowHandle, "FValue", Convert.ToInt32(TransView.GetRowCellValue(TransView.RowCount - 2,"TValue")));
                }
            //}
            //else
            //{
            //    //e.Row.Cells[2].Value = 0;
            //    TransView.SetRowCellValue(TransView.FocusedRowHandle, "FValue", 0);
            //}

            ////e.Row.Cells[3].Value = 0;
            //TransView.SetRowCellValue(TransView.FocusedRowHandle, "TValue", 0);
            //DataRow dr = m_tGrade.NewRow();
            //dr[0] = 0;
            //dr[1] = "";
            //dr[2] = 0;
            //dr[3] = 0;
            //m_tGrade.Rows.Add(dr);
        }

        private void frmGrade_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BsfGlobal.g_bWorkFlow == true)
            {
                if (BsfGlobal.g_bWorkFlowDialog == false) { try { this.Parent.Controls.Owner.Hide(); } catch { } }
            }
        }

      

       

    }
}
