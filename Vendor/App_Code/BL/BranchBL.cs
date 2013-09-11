using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Vendor.DataLayer;

namespace Vendor.BusinessLayer
{
    class BranchBL
    {
        int m_lBranchId;
        int m_lVendorId;
        string m_sBranchName;
        string m_sBranchAddress;
        int m_lCityId;
        string m_sTINNo;
        string m_sPhone;
        string m_sChequeNo;
        
        Vendor.DataLayer.BranchDL m_oBranch;

        public BranchBL()
        {
            m_oBranch = new Vendor.DataLayer.BranchDL();
        }

        public int BranchId
        {
            get { return m_lBranchId; }
            set { m_lBranchId = value; }
        }

        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
        }

        public string BranchName
        {
            get { return m_sBranchName; }
            set { m_sBranchName = value; }
        }
        public string BranchAddress
        {
            get { return m_sBranchAddress; }
            set { m_sBranchAddress = value; }
        }

        public int CityId
        {
            get { return m_lCityId; }
            set { m_lCityId = value; }
        }

        public string TINNo
        {
            get { return m_sTINNo; }
            set { m_sTINNo = value; }
        }

        public string Phone
        {
            get { return m_sPhone; }
            set { m_sPhone = value; }
        }

        public string ChequeNo
        {
            get { return m_sChequeNo; }
            set { m_sChequeNo = value; }
        }

        public DataTable GetBrachList(int argVendorId)
        {
            return m_oBranch.GetBrachList(argVendorId);
        }

        public void InsertBranch(Vendor.BusinessLayer.BranchBL argBranch,DataTable dtContact)
        {
            m_oBranch.InsertBranch(argBranch,dtContact);
        }

        public void UpdateBranch(Vendor.BusinessLayer.BranchBL argBranch,DataTable dtContact)
        {
            m_oBranch.UpdateBranch(argBranch,dtContact);
        }
        public void DeleteBranch(int argId)
        {
            m_oBranch.DeleteBranch(argId);
        }
        public static DataTable GetContact(int argBId)
        {
            return BranchDL.GetContact(argBId);
        }
    }
}
