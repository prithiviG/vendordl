using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Vendor.BusinessLayer;

namespace Vendor
{
  public partial class frmVehicle : Form
  {
    #region Variables

    int iVehicleId=0;
    int iVendorId=0;
    DataTable dtVehRegNo = new DataTable();
    DataTable dtVehDetails = new DataTable();
    decimal aQty;
    decimal bQty;
    decimal cQty;
    decimal total1;
    decimal total2;
    decimal nettotal;
    decimal l1, l2, l3, b1, b2, b3, h1, h2, h3 = 0;
    readonly bool b_RetVal = false;
    #endregion
 
    #region Constructor

    public frmVehicle()
    {
      InitializeComponent();
    }
    public bool Execute(int argVehId,int argVenId)
    {
        iVehicleId = argVehId;
        iVendorId = argVenId;
        if (iVehicleId != -1)
            cboVehicleRegNo.EditValue = iVehicleId;
        ShowDialog();
        return b_RetVal;
    }
    #endregion

    #region Form Event
    protected override void OnSizeChanged(EventArgs e)
    {
        if (!DesignMode && IsHandleCreated)
            BeginInvoke((MethodInvoker)delegate { base.OnSizeChanged(e); });
        else
            base.OnSizeChanged(e);
    }

    private void frmVehicle_Load(object sender, EventArgs e)
    {
            PopulateVehicleNo();
            txtBLMQ.Enabled = false;
            txtTSMQ.Enabled = false;
            txtTSMinQ.Enabled = false;
            txtTotal.Enabled = false;
            txtPercentage.Enabled = false;        
    }
    #endregion

    #region Button Event

    private void btnExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(cboVehicleRegNo.EditValue) != -1)
        {
            InputValues();
            VehicleBL.UpdateVehicleDetails();
            SetEmpty();
        }
        else
        {
            MessageBox.Show("Choose Vehicle Registration Number!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    
    private void Calculation()
    {    
        if (txtBLMLen.Text != string.Empty) { l1 = Convert.ToDecimal(txtBLMLen.Text); }
        if (txtBLMB.Text != string.Empty) { b1 = Convert.ToDecimal(txtBLMB.Text); }
        if (txtBLMH.Text != string.Empty) { h1 = Convert.ToDecimal(txtBLMH.Text); }
        if (txtTSML.Text != string.Empty) { l2 = Convert.ToDecimal(txtTSML.Text); }
        if (txtTSMB.Text != string.Empty) { b2 = Convert.ToDecimal(txtTSMB.Text); }
        if (txtTSMH.Text != string.Empty) { h2 = Convert.ToDecimal(txtTSMH.Text); }
        if (txtTSMinL.Text != string.Empty) { l3 = Convert.ToDecimal(txtTSMinL.Text); }
        if (txtTSMinB.Text != string.Empty) { b3 = Convert.ToDecimal(txtTSMinB.Text); }
        if (txtTSMinH.Text != string.Empty) { h3 = Convert.ToDecimal(txtTSMinH.Text); }
        aQty = l1 * b1 * h1;
        txtBLMQ.Text = aQty.ToString();
        bQty = l2 * b2 * h2;
        txtTSMQ.Text = bQty.ToString();
        cQty = l3 * b3 * h3;
        txtTSMinQ.Text = cQty.ToString();    
        total1 = bQty + cQty;
        txtTotal.Text = total1.ToString();
        total2 = (bQty + cQty) / 2;
        txtPercentage.Text = total2.ToString();
        nettotal = (aQty + ((bQty + cQty) / 2));
        lblNetTotal.Text = nettotal.ToString();   
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        SetEmpty();
    }
    private void barExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        Close();
    }

    private void cboVehicleRegNo_EditValueChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(cboVehicleRegNo.EditValue) > 0)
        {
            iVehicleId = Convert.ToInt32(clsStatic.IsNullCheck(cboVehicleRegNo.EditValue, clsStatic.datatypes.vartypenumeric));
            PopulateVehicleDetails();
        }
    }

    private void btnVehicleAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        frmVehicleEntry frmVEntry = new frmVehicleEntry();
        frmVEntry.Execute(0,iVendorId);
        PopulateVehicleNo();
    }

    private void btnVehicleEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        VehicleBL.VehicleId = Convert.ToInt32(clsStatic.IsNullCheck( cboVehicleRegNo.EditValue,clsStatic.datatypes.vartypenumeric));
        if (VehicleBL.VehicleId != -1)
        {
            frmVehicleEntry frmVEntry = new frmVehicleEntry();
            frmVEntry.Execute(VehicleBL.VehicleId,iVendorId);
            iVehicleId = VehicleBL.VehicleId;
            PopulateVehicleNo();
            cboVehicleRegNo.EditValue = iVehicleId;
        }
        else
        {
            MessageBox.Show("Choose Vehicle Registration No!", "MMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void txtBLMLen_EditValueChanged(object sender, EventArgs e)
    {
        Calculation();
    }

    private void txtBLMB_EditValueChanged(object sender, EventArgs e)
    {
        Calculation();
    }

    private void txtBLMH_EditValueChanged(object sender, EventArgs e)
    {
        Calculation();
    }

    private void txtTSML_EditValueChanged(object sender, EventArgs e)
    {
        Calculation();

    }

    private void txtTSMB_EditValueChanged(object sender, EventArgs e)
    {
        Calculation();

    }

    private void txtTSMH_EditValueChanged(object sender, EventArgs e)
    {
        Calculation();
    }

    private void txtTSMinL_EditValueChanged(object sender, EventArgs e)
    {
        Calculation();
    }

    private void txtTSMinB_EditValueChanged(object sender, EventArgs e)
    {
        Calculation();
    }

    private void txtTSMinH_EditValueChanged(object sender, EventArgs e)
    {
        Calculation();
    }
    #endregion

    #region Functions

    public void InputValues()
    {
      VehicleBL.VehicleId = Convert.ToInt32(clsStatic.IsNullCheck( cboVehicleRegNo.EditValue,clsStatic.datatypes.vartypenumeric));
    VehicleBL.VendorId = iVendorId;
      VehicleBL.BlLen = Convert.ToDecimal(clsStatic.IsNullCheck(txtBLMLen.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.BlHeight = Convert.ToDecimal(clsStatic.IsNullCheck(txtBLMH.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.BlBreadth = Convert.ToDecimal(clsStatic.IsNullCheck(txtBLMB.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.BlHeight = Convert.ToDecimal(clsStatic.IsNullCheck(txtBLMH.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.BlQty = Convert.ToDecimal(clsStatic.IsNullCheck(txtBLMQ.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.TsMaxLen = Convert.ToDecimal(clsStatic.IsNullCheck(txtTSML.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.TsMaxBredth = Convert.ToDecimal(clsStatic.IsNullCheck(txtTSMB.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.TsMaxHeight = Convert.ToDecimal(clsStatic.IsNullCheck(txtTSMH.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.TsMaxQty = Convert.ToDecimal(clsStatic.IsNullCheck(txtTSMQ.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.TsMinLen = Convert.ToDecimal(clsStatic.IsNullCheck(txtTSMinL.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.TsMinBredth = Convert.ToDecimal(clsStatic.IsNullCheck(txtTSMinB.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.TsMinHeight = Convert.ToDecimal(clsStatic.IsNullCheck(txtTSMinH.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.TsMinQty = Convert.ToDecimal(clsStatic.IsNullCheck(txtTSMinQ.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.Total1 = Convert.ToDecimal(clsStatic.IsNullCheck(txtTotal.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.Total2 = Convert.ToDecimal(clsStatic.IsNullCheck(txtPercentage.Text,clsStatic.datatypes.vartypenumeric));
      VehicleBL.NetTotal = Convert.ToDecimal(clsStatic.IsNullCheck(lblNetTotal.Text, clsStatic.datatypes.vartypenumeric));
      VehicleBL.Remarks = Convert.ToString(clsStatic.IsNullCheck( txtRemarks.Text,clsStatic.datatypes.vartypestring));
    }

    public void SetEmpty()
    {
      cboVehicleRegNo.EditValue = -1;
      txtBLMLen.Text = string.Empty;
      txtBLMB.Text = string.Empty;
      txtBLMH.Text = string.Empty;
      txtBLMQ.Text = string.Empty;
      txtTSML.Text = string.Empty;
      txtTSMB.Text = string.Empty;
      txtTSMH.Text = string.Empty;
      txtTSMQ.Text = string.Empty;
      txtTSMinL.Text = string.Empty;
      txtTSMinB.Text = string.Empty;
      txtTSMinH.Text = string.Empty;
      txtTSMinQ.Text = string.Empty;
      txtTotal.Text = string.Empty;
      txtPercentage.Text = string.Empty;
      lblNetTotal.Text = string.Empty;
      txtRemarks.Text = "";
    }

    public void PopulateVehicleDetails()
    {
        dtVehDetails = new DataTable();
        dtVehDetails = VehicleBL.PopulateVehicleDetails(iVehicleId);
        if (dtVehDetails.Rows.Count > 0)
          {
              txtBLMLen.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["BLLen"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtBLMB.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["BLBreadth"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtBLMH.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["BLHeight"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtBLMQ.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["BLQty"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtTSML.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["TSMaxLen"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtTSMB.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["TSMaxBreadth"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtTSMH.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["TSMaxHeight"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtTSMQ.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["TSMaxQty"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtTSMinL.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["TSMinLen"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtTSMinB.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["TSMinBreadth"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtTSMinH.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["TSMinHeight"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtTSMinQ.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["TSMinQty"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtTotal.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["Total1"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtPercentage.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["Total2"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              lblNetTotal.Text = Convert.ToDecimal(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["NetTotal"].ToString(),clsStatic.datatypes.vartypenumeric)).ToString();
              txtRemarks.Text = Convert.ToString(clsStatic.IsNullCheck( dtVehDetails.Rows[0]["Remarks"].ToString(),clsStatic.datatypes.vartypestring));

          }

    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keydata)
    {
      if (keydata == Keys.Enter)
      {
        SendKeys.Send("{Tab}");
        return true;
      }
      return base.ProcessCmdKey(ref msg, keydata);
    }

    private void PopulateVehicleNo()
    {
        dtVehRegNo = VehicleBL.GetVehicleRegNo(iVendorId);
        DataRow dr = dtVehRegNo.NewRow();
        dr["VehicleId"] = "-1";
        dr["VehicleRegNo"] = "--- Select ---";
        dr["VehicleName"] = "";
        dtVehRegNo.Rows.InsertAt(dr, 0);
        cboVehicleRegNo.Properties.DataSource = dtVehRegNo;
        cboVehicleRegNo.Properties.ForceInitialize();
        cboVehicleRegNo.Properties.PopulateColumns();
        cboVehicleRegNo.Properties.ValueMember = "VehicleId";
        cboVehicleRegNo.Properties.DisplayMember = "VehicleRegNo";
        cboVehicleRegNo.Properties.ShowHeader = false;
        cboVehicleRegNo.Properties.ShowFooter = false;
        cboVehicleRegNo.Properties.Columns["VehicleId"].Visible = false;
        cboVehicleRegNo.Properties.Columns["VehicleName"].Visible = false;
        cboVehicleRegNo.EditValue = -1;
    }

   
    #endregion   

  }
}
        