using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.ReportSource;
using System.Collections;

namespace Vendor
{
    public partial class frmAlert : Form
    {
        DateTime DDate;
        //DateTime DDate1;
        DataTable m_tAlert;
        Vendor.BusinessLayer.AlertBL m_oAlert;

        public frmAlert()
        {
            InitializeComponent();
            m_oAlert = new Vendor.BusinessLayer.AlertBL();
        }
       


        public void Execute()
        {
            this.ShowDialog();
        }
        private void toolStripExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
       
        private void toolStripRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (toolStripADays.EditValue.ToString() != "")
            {
                int days = Convert.ToInt32(toolStripADays.EditValue);
                DDate = DateTime.Today.Date.AddDays(days);
                m_tAlert = new DataTable();
                m_tAlert = m_oAlert.GetAlertDatas(DDate);
                DataView dv;
                dv = new DataView(m_tAlert);
                grdAlert.DataSource = dv.ToTable();
                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
                columnHeaderStyle.BackColor = Color.Beige;
                columnHeaderStyle.Font = new Font("TimesNewRoman", 8, FontStyle.Bold);
                //grdAlert.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                AlertView.Columns[0].Width = 100;
                AlertView.Columns[1].Width = 80;
                AlertView.Columns[2].Width = 200;
                AlertView.Columns[3].Width = 200;
                AlertView.Columns[4].Width = 80;
                this.Text = "Alert Upto " + Convert.ToString(DDate.ToShortDateString());
            }
            else
            {
                MessageBox.Show("Please Enter No.of days!");
                grdAlert.DataSource = "";
                this.Text = "Alert";
            }
        }
        private void toolStripPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReport objReport = new frmReport();
            string strReportPath = Application.StartupPath + "\\AlertRpt.Rpt";
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(strReportPath);
            cryRpt.SetParameterValue("@UDate", DDate);
            string[] DataFiles = new string[] { BsfGlobal.g_sVendorDBName };
            objReport.ReportConvert(cryRpt, DataFiles);
            objReport.rptViewer.ReportSource = null;
            objReport.rptViewer.ReportSource = cryRpt;
            objReport.rptViewer.Refresh();
            objReport.Show();
        }    
        private void toolStripADays_TextChanged(object sender, EventArgs e)
        {
            toolStripADays.ItemPress += new DevExpress.XtraBars.ItemClickEventHandler(toolStripADays_ItemPress);
        }
        private void toolStripADays_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if ((e.KeyChar < '0') || (e.KeyChar > '9')) e.Handled = true;    
            
        }
     


        private void frmAlert_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BsfGlobal.g_bWorkFlow == true)
            {
                if (BsfGlobal.g_bWorkFlowDialog == false) { try { this.Parent.Controls.Owner.Hide(); } catch { } }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void toolStripADays_ShowingEditor(object sender, DevExpress.XtraBars.ItemCancelEventArgs e)
        {
           
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmAlert_Load(object sender, EventArgs e)
        {
            toolStripADays.EditValue = 0;
        }

       
       

    }
}
