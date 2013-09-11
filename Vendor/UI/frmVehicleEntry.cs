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
    public partial class frmVehicleEntry : Form
    {
        int iVehicleId = 0;
        int iVendorId = 0;
        string sVehRegNo = "";
        string sVehName = "";
        readonly bool b_Return = false;

        public frmVehicleEntry()
        {
            InitializeComponent();
        }

        public bool Execute(int argVId,int argVenId)
        {
            iVehicleId = argVId;
            iVendorId = argVenId;
            ShowDialog();
            return b_Return;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && IsHandleCreated)
                BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
            else
                base.OnSizeChanged(e);
        }

        private void frmVehicleEntry_Load(object sender, EventArgs e)
        {
            if (iVehicleId != 0)
            {
                PopulateVehicle();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sVehName = txtVehicleName.Text;
            sVehRegNo = txtVehicleRegNo.Text;
            VehicleBL.InsertVehicle(iVehicleId, iVendorId, sVehRegNo, sVehName);
            Close();
        }

        private void PopulateVehicle()
        {
            DataTable dtVeh = new DataTable();
            dtVeh = VehicleBL.PopulateVehicle(iVehicleId);
            if (dtVeh.Rows.Count > 0)
            {
                txtVehicleRegNo.Text = Convert.ToString(clsStatic.IsNullCheck( dtVeh.Rows[0]["VehicleRegNo"].ToString(),clsStatic.datatypes.vartypestring));
                txtVehicleName.Text = Convert.ToString(clsStatic.IsNullCheck(dtVeh.Rows[0]["VehicleName"].ToString(), clsStatic.datatypes.vartypestring));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
