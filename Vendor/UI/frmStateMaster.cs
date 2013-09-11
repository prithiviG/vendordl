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
    public partial class frmStateMaster : Form
    {
        Vendor.BusinessLayer.StateBL m_oState;
        public frmStateMaster()
        {
            InitializeComponent();
            m_oState = new Vendor.BusinessLayer.StateBL();
        }
        public void Execute()
        {
            this.ShowDialog();
        }
        private void toolStripAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmStateEntry StateEntry = new frmStateEntry();
            if (StateEntry.Execute(0) == true) { PopulateGrid(); }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        public void frmStateMaster_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }          
 
         private void PopulateGrid()
        {
            DataTable dt;
            dt = new DataTable();
            dt = m_oState.GetStateList();
            grdTrans.DataSource = dt;
            TransView.Columns[0].Visible = false;
            TransView.Columns[1].Width = 150;
            TransView.Columns[2].Width = 150;
            TransView.Columns[1].Caption = "State";
            TransView.Columns[2].Caption = "Country";
            TransView.Columns[3].Visible = false;
        }

         
         private void toolStripExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             this.Close();
         }
         private void toolStripEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {

             int lStateId = Convert.ToInt32(TransView.GetRowCellValue(TransView.FocusedRowHandle,"StateId"));
             frmStateEntry StateEntry = new frmStateEntry();
             if (StateEntry.Execute(lStateId) == true) { PopulateGrid(); }
         }
         
         private void toolStripDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             int StateId=Convert.ToInt32(TransView.GetFocusedRowCellValue("StateId") );
             bool status = m_oState.CheckState(StateId);
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
                     m_oState.DeleteState(StateId);
                     TransView.DeleteRow(TransView.FocusedRowHandle);
                 }
             }
         }
    }
}
