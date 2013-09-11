using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using System.Data.OleDb;
using DevExpress.Utils.Paint;
using System.Reflection;
using Vendor.BusinessLayer;

namespace Vendor
{
    public partial class frmVendorImport : Form
    {
        DialogResult retVal;
        DataTable dtExcelData;
        public frmVendorImport()
        {
            InitializeComponent();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExcelView();
        }

        private void ExcelView()
        {
            string strFilePath = null;
            //strFilePath = "D:\test"
            MyFileOpen.Multiselect = false;
            MyFileOpen.Filter = "Excel Files (*.xlsx;) (*.xls;)|*.xlsx;*.xls;";
            // "Excel Files|*.xls;*.xlsx|All Files|*.*"

            retVal = MyFileOpen.ShowDialog();
            if (retVal == System.Windows.Forms.DialogResult.OK)
            {
                strFilePath = MyFileOpen.FileName;
            }
            if (!string.IsNullOrEmpty(strFilePath))
                pLoadExcelData(strFilePath);
        }

        private void pLoadExcelData(string strXLSFile)
        {
            dtExcelData = new DataTable();
            DataSet ds = new DataSet();
            string strConn = "";
            OleDbDataAdapter da = default(OleDbDataAdapter);
            //int lCount = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // m_bAns = false;
                try
                {
                    if ((strXLSFile.Contains(".xlsx")))
                    {
                        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + strXLSFile + ";" + "Extended Properties=Excel 12.0;";
                    }
                    else if ((strXLSFile.Contains(".xls")))
                    {
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strXLSFile + ";" + "Extended Properties=Excel 8.0;";
                    }
                    //You must use the $ after the object
                    //you reference in the spreadsheet
                    da = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn);
                    da.Fill(dtExcelData);
                    da.Dispose();
                    if ((dtExcelData.Rows.Count > 0))
                    {
                        grdImport.DataSource = dtExcelData;
                        ImportView.PopulateColumns();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Cursor.Current = Cursors.Default;
                // Interaction.MsgBox("Excel Sheet Imported", Constants.vbInformation);
            }
            catch (Exception Except)
            {
                MessageBox.Show("Error: " + Except.Message);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtExcelData == null) return;
            if (CheckColumns() == false) return;
            string sVendorName = "";
            string sVAddress = "";
            string sContactNo = "";
            string sEmail = "";
            string sCSTNo = "";
            string sTNGSTNo = "";
            string sTIN = "";
            string sPAN = "";
            int iSupply = 0;
            int iContract = 0;
            int iService = 0;
            for (int i = 0; i < dtExcelData.Rows.Count; i++)
            {
                sVendorName = dtExcelData.Rows[i]["VendorName"].ToString();
                if (VendorBL.IsValidName(sVendorName) == true && sVendorName != "")
                {
                    sVAddress = dtExcelData.Rows[i]["Address"].ToString();
                    sContactNo = dtExcelData.Rows[i]["ContactNo"].ToString();
                    sEmail = dtExcelData.Rows[i]["EmailId"].ToString();
                    sCSTNo = dtExcelData.Rows[i]["CSTNo"].ToString();
                    sTNGSTNo = dtExcelData.Rows[i]["TNGST"].ToString();
                    sTIN=dtExcelData.Rows[i]["TIN"].ToString();
                    sPAN=dtExcelData.Rows[i]["PAN"].ToString();
                    iSupply = Convert.ToInt32(clsStatic.IsNullCheck(dtExcelData.Rows[i]["Supply"].ToString(), clsStatic.datatypes.vartypenumeric));
                    iContract = Convert.ToInt32(clsStatic.IsNullCheck(dtExcelData.Rows[i]["Contract"].ToString(), clsStatic.datatypes.vartypenumeric));
                    iService = Convert.ToInt32(clsStatic.IsNullCheck(dtExcelData.Rows[i]["Service"].ToString(), clsStatic.datatypes.vartypenumeric));
                    VendorBL.ImportTransaction(sVendorName, sVAddress, sContactNo, sEmail, sCSTNo, sTNGSTNo, sTIN, sPAN,iSupply,iContract,iService);
                }
            }
            
            if (BsfGlobal.g_bFADB == true) { BsfGlobal.RefreshSubLedger(1); }
            MessageBox.Show("Imported Successfully!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
        }

        public void Clear()
        {
            dtExcelData = null;
            grdImport.DataSource = null;
            Close();
        }
        private bool CheckColumns()
        {
            bool ChkStatus = false;
            bool NameStatus = false;
            bool AddStatus = false;
            bool ContactStatus = false;
            bool EmailStatus = false;
            bool CSTStatus = false;
            bool TNGSTStatus = false;
            bool TINStatus = false;
            bool PANStatus = false;
            bool SStatus = false;
            bool CStatus = false;
            bool SerStatus = false;

            foreach (DataColumn Col in dtExcelData.Columns)
            {
                if (Col.ToString() == "VendorName")
                {
                    NameStatus = true;
                    break;
                }

            }
            if (NameStatus == false)
            {
                MessageBox.Show("VendorName is Not Found!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ChkStatus;
            }
            foreach (DataColumn Col in dtExcelData.Columns)
            {
                if (Col.ToString() == "Address")
                {
                    AddStatus = true;
                    break;
                }

            }
            if (AddStatus == false)
            {
                MessageBox.Show("Address is Not Found!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ChkStatus;
            }
            foreach (DataColumn Col in dtExcelData.Columns)
            {
                if (Col.ToString() == "ContactNo")
                {
                    ContactStatus = true;
                    break;
                }

            }
            if (ContactStatus == false)
            {
                MessageBox.Show("ContactNo is Not Found!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ChkStatus;
            }

            foreach (DataColumn Col in dtExcelData.Columns)
            {
                if (Col.ToString() == "EmailId")
                {
                    EmailStatus = true;
                    break;
                }

            }
            if (EmailStatus == false)
            {
                MessageBox.Show("EmailId is Not Found!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ChkStatus;
            }

            foreach (DataColumn Col in dtExcelData.Columns)
            {
                if (Col.ToString() == "CSTNo")
                {
                    CSTStatus = true;
                    break;
                }

            }
            if (CSTStatus == false)
            {
                MessageBox.Show("CSTNo is Not Found!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ChkStatus;
            }

            foreach (DataColumn Col in dtExcelData.Columns)
            {
                if (Col.ToString() == "TNGST")
                {
                    TNGSTStatus = true;
                    break;
                }

            }
            if (TNGSTStatus == false)
            {
                MessageBox.Show("TNGST is Not Found!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ChkStatus;
            }

            foreach (DataColumn Col in dtExcelData.Columns)
            {
                if (Col.ToString() == "TIN")
                {
                    TINStatus = true;
                    break;
                }

            }
            if (TINStatus == false)
            {
                MessageBox.Show("TIN is Not Found!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ChkStatus;
            }

            foreach (DataColumn Col in dtExcelData.Columns)
            {
                if (Col.ToString() == "PAN")
                {
                    PANStatus = true;
                    break;
                }

            }
            if (PANStatus == false)
            {
                MessageBox.Show("PAN is Not Found!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ChkStatus;
            }

            foreach (DataColumn Col in dtExcelData.Columns)
            {
                if (Col.ToString() == "Supply")
                {
                    SStatus = true;
                    break;
                }

            }
            if (SStatus == false)
            {
                MessageBox.Show("Supply is Not Found!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ChkStatus;
            }

            foreach (DataColumn Col in dtExcelData.Columns)
            {
                if (Col.ToString() == "Contract")
                {
                    CStatus = true;
                    break;
                }

            }
            if (CStatus == false)
            {
                MessageBox.Show("Contract is Not Found!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ChkStatus;
            }

            foreach (DataColumn Col in dtExcelData.Columns)
            {
                if (Col.ToString() == "Service")
                {
                    SerStatus = true;
                    break;
                }

            }
            if (SerStatus == false)
            {
                MessageBox.Show("Service is Not Found!", "Vendor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ChkStatus;
            }

            ChkStatus = true;
            return ChkStatus;
        }


    }


}
