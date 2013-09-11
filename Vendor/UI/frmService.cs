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
    public partial class frmService : Form
    {
        Vendor.BusinessLayer.ServiceBL oService;
        DataTable dtSGroup;
        DataTable dtUnit;
        DataTable dtSDetails;
        int ServiceId = 0;
        string ServiceCode = "";
        string ServiceName = "";
        int SGroupId = 0;
        int SUnitId = 0;
        public frmService()
        {
            InitializeComponent();
            oService = new BusinessLayer.ServiceBL();
        }
        public void Execute(int argSId)
        {
            ServiceId = argSId;
            ShowDialog();
        }
        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            PopulateSGroup();
            PopulateUnit();
            if (ServiceId > 0)
            {
                GetServiceDetails();
            }
        }
  
        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            frmServiceGroup frm = new frmServiceGroup();
            frm.ShowDialog();
            PopulateSGroup();
        }
        private void PopulateSGroup()
        {
            dtSGroup = new DataTable();
            dtSGroup = oService.GetServiceGroup();
            cboServiceGroup.Properties.DataSource = dtSGroup;
            cboServiceGroup.Properties.ForceInitialize();
            cboServiceGroup.Properties.PopulateColumns();
            cboServiceGroup.Properties.ShowHeader = false;
            cboServiceGroup.Properties.ShowFooter = false;
            cboServiceGroup.Properties.ValueMember = "ServiceGroupId";
            cboServiceGroup.Properties.DisplayMember = "ServiceGroupName";
            cboServiceGroup.Properties.Columns["ServiceGroupId"].Visible = false;
        }
        private void PopulateUnit()
        {
            dtUnit = new DataTable();
            dtUnit = oService.GetUnit();
            cboUnit.Properties.DataSource = dtUnit;
            cboUnit.Properties.ForceInitialize();
            cboUnit.Properties.PopulateColumns();
            cboUnit.Properties.ShowHeader = false;
            cboUnit.Properties.ShowFooter = false;
            cboUnit.Properties.ValueMember = "Unit_ID";
            cboUnit.Properties.DisplayMember = "Unit_Name";
            cboUnit.Properties.Columns["Unit_ID"].Visible = false;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ServiceCode = txtSCode.Text;
            ServiceName = txtSName.Text;
            SGroupId = Convert.ToInt32(cboServiceGroup.EditValue);
            SUnitId = Convert.ToInt32(cboUnit.EditValue);
            if (ServiceId == 0)
            {
                oService.InsertService(ServiceCode, ServiceName, SGroupId, SUnitId);
            }
            else
            {
                oService.UpdateService(ServiceId,ServiceCode, ServiceName, SGroupId, SUnitId);
            }
            Close();
        }
        private void GetServiceDetails()
        {
            dtSDetails = new DataTable();
            if (ServiceId > 0)
            {
                dtSDetails = oService.GetServiceDetails(ServiceId);
                if (dtSDetails.Rows.Count > 0)
                {
                    txtSCode.Text = dtSDetails.Rows[0]["ServiceCode"].ToString();
                    txtSName.Text = dtSDetails.Rows[0]["ServiceName"].ToString();
                    cboServiceGroup.EditValue = Convert.ToInt32(dtSDetails.Rows[0]["ServiceGroupId"].ToString());
                    cboUnit.EditValue = Convert.ToInt32(dtSDetails.Rows[0]["UnitId"].ToString());
                }
            }

        }
    }
}
