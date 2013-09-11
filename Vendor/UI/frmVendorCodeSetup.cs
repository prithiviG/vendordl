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
    public partial class frmVendorCodeSetup : Form
    {
        Vendor.BusinessLayer.CheckListBL m_oCheckList;
        string sCodePre = "";
        string sCodeSuf = "";
        int iwidth = 0;
        bool bAns = false;
        public frmVendorCodeSetup()
        {
            InitializeComponent();
            m_oCheckList = new Vendor.BusinessLayer.CheckListBL();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulateData()
        {           
            DataTable dtComp = new DataTable();
            dtComp = m_oCheckList.GetVendorCodeTypeSetup();

            if (dtComp.Rows.Count > 0)
            {
                bAns = Convert.ToBoolean(dtComp.Rows[0]["CodeType"].ToString());
                if (bAns == true)
                {
                    radioGroup1.SelectedIndex = 0;
                }
                else
                {
                    radioGroup1.SelectedIndex = 1;
                }
                TxtCoPre.Text=clsStatic.IsNullCheck(dtComp.Rows[0]["CodePrefix"], clsStatic.datatypes.vartypestring).ToString();
                txtCodeSuf.Text = clsStatic.IsNullCheck(dtComp.Rows[0]["Suffix"], clsStatic.datatypes.vartypestring).ToString();
                txtWidth.Text = Convert.ToInt32(clsStatic.IsNullCheck(dtComp.Rows[0]["Width"], clsStatic.datatypes.vartypenumeric)).ToString();
            }
            else
            {
                radioGroup1.SelectedIndex = 1;
            }
            
        }

        private void frmVendorCodeSetup_Load(object sender, EventArgs e)
        {
            radioGroup1.SelectedIndex = 0;
            PopulateData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            if (radioGroup1.SelectedIndex == 0) { bAns = true; }
            else { bAns = false; }
            sCodePre=TxtCoPre.Text;
            sCodeSuf = txtCodeSuf.Text;
            iwidth = Convert.ToInt32(clsStatic.IsNullCheck(txtWidth.Text, clsStatic.datatypes.vartypenumeric));
            m_oCheckList.UpdateVendorCodeSetup(bAns, sCodePre, sCodeSuf, iwidth);
            this.Close();
        }

     
    }
}
