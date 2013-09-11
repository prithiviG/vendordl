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
    public partial class frmTypeSetup : Form
    {
        Vendor.BusinessLayer.CheckListBL m_oCheckList;

        public frmTypeSetup()
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
            clsStatic.g_bTypeSelection = m_oCheckList.GetTypeSetup();
            if (clsStatic.g_bTypeSelection == true)
            {
                radioGroup1.SelectedIndex = 0;
            }
            else
            {
                radioGroup1.SelectedIndex = 1;
            }

        }

        private void frmTypeSetup_Load(object sender, EventArgs e)
        {
            radioGroup1.SelectedIndex = 0;
            PopulateData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bool bAns = false;
            if (radioGroup1.SelectedIndex == 0) { bAns = true; }
            else { bAns = false; }
            m_oCheckList.UpdateTypeSetup(bAns);
            this.Close();
        }
    }
}
