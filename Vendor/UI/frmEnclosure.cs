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
    public partial class frmEnclosure : Form
    {
        int E_VendorId = 0;
        int E_EncId = 0;
        string E_Mode = "";
        Vendor.BusinessLayer.EnclosureBL m_oEncolosure;
        public frmEnclosure()
        {
            InitializeComponent();
            m_oEncolosure = new BusinessLayer.EnclosureBL();
        }
        public void Execute(int argVendorId,string argMode,int argEncId)
        {
            E_VendorId = argVendorId;
            E_Mode = argMode;
            E_EncId = argEncId;
            ShowDialog();
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_oEncolosure.VendorId=E_VendorId;
            m_oEncolosure.EncDate = Convert.ToDateTime(deDate.EditValue);
            m_oEncolosure.Location = txtUpload.Text;
            m_oEncolosure.Name = txtName.Text;
            m_oEncolosure.Type = txtType.Text;
            m_oEncolosure.EnclosureId = E_EncId;
            if (E_Mode == "A")
            {
                m_oEncolosure.InsertEnclosure();
            }
            else if (E_Mode == "E")
            {
                m_oEncolosure.UpdateEnclosure();
            }
            Close();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deDate.EditValue = DateTime.Now;
            txtUpload.Text = "";
            txtName.Text = "";
            txtType.Text = "";
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmEnclosure_Load(object sender, EventArgs e)
        {
            if (E_Mode == "E")
            {
                GetEnclosureDetails(E_EncId, E_VendorId);
            }
        }

        private void GetEnclosureDetails(int argEncId, int argVendorId)
        {
            DataTable dt = new DataTable();
            dt = m_oEncolosure.GetEncDetails(argVendorId, argEncId);
            if (dt.Rows.Count > 0)
            {
                deDate.EditValue = Convert.ToDateTime(dt.Rows[0]["Date"].ToString());
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtType.Text = dt.Rows[0]["Type"].ToString();
                txtUpload.Text = dt.Rows[0]["Location"].ToString();
            }
        }

    }
}
