using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Vendor.DataLayer;

namespace Vendor.BusinessLayer
{
    class VendorBL
    {
        int m_lVendorId;
        string m_sVendorName;
        bool m_bSupply;
        bool m_bContract;
        bool m_bService;
        string m_sAddress;
        int m_lCityId;
        string m_sPin;
        int m_STypeId;
        string m_SuppTypeId;
        int m_iCompany;
        string m_sChequeNo;
        string m_sCode;

        Vendor.DataLayer.VendorDL m_oVendor;
        public VendorBL()
        {
            m_oVendor = new Vendor.DataLayer.VendorDL();
        }
        public DataTable GetVendorList()
        {
            return m_oVendor.GetVendorList();
        }
    
        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
        }

        public String VendorName
        {
            get { return m_sVendorName; }
            set { m_sVendorName = value; }
        }

        public bool Supply
        {
            get { return m_bSupply; }
            set { m_bSupply = value; }
        }

        public bool Contract
        {
            get { return m_bContract; }
            set { m_bContract = value; }
        }

        public bool Service
        {
            get { return m_bService; }
            set { m_bService = value; }
        }

        public String RegAddress
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public int CityId
        {
            get { return m_lCityId; }
            set { m_lCityId = value; }
        }

        public String PinNo
        {
            get { return m_sPin; }
            set { m_sPin = value; }
        }

        public int STypeId
        {
            get { return m_STypeId; }
            set { m_STypeId = value; }

        }
        public String SuppTypeId
        {
            get { return m_SuppTypeId; }
            set { m_SuppTypeId = value; }

        }
        public int iCompany
        {
            get { return m_iCompany; }
            set { m_iCompany = value; }

        }
        public String ChequeNo
        {
            get { return m_sChequeNo; }
            set { m_sChequeNo = value; }
        }

        public String Code
        {
            get { return m_sCode; }
            set { m_sCode = value; }
        }
        public int InsertVendorMaster(Vendor.BusinessLayer.VendorBL argVendor)
        {
            return m_oVendor.InsertVendorMaster(argVendor);
        }

        public DataTable GetVendorMasterInfo(int argVendorId)
        {
            return m_oVendor.GetVendorMasterInfo(argVendorId);
        }
        public DataSet GetVendorInfo(int argVendorId)
        {
            return m_oVendor.GetVendorInfo(argVendorId);
        }
        public DataSet GetFilterInfo()
        {
            return m_oVendor.GetFilterInfo();
        }
        public void UpdateVendorMaster(Vendor.BusinessLayer.VendorBL argVendor)
        {
            m_oVendor.UpdateVendorMaster(argVendor);
        }
        public bool CheckVendorName(int argVendorId, string argVendorName)
        {
            return m_oVendor.CheckVendorName(argVendorId, argVendorName);
        }
        public void InsertVendorTemp(string sSql)
        {
            m_oVendor.InsertVendorTemp(sSql);
        }
        public DataTable GetValidToDate(int argVenId)
        {
            return m_oVendor.GetValidToDate(argVenId);
        }
        public DataTable GetVendorGeneralInfo(int argVenId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = m_oVendor.GetVendorGeneralInfo(argVenId);
            }
            catch (Exception ce)
            {
                throw ce;
            }
            return dt;
        }
        public static DataTable PopulateSType()
        {
            return VendorDL.PopulateSType();
        }

        public static bool IsValidName(string argName)
        {
            return VendorDL.IsValidName(argName);
        }

        public static void ImportTransaction(string argVName, string argVAddress, string argContact, string argEmail, string argCST, string argTNGST, string argTIN, string argPAN,int argSupply,int argContract,int argService)
        {
            VendorDL.ImportTransaction(argVName, argVAddress, argContact, argEmail, argCST, argTNGST, argTIN, argPAN, argSupply, argContract, argService);
        }

        public static void DeleteVendorDetailsWithoutMaster()
        {
            VendorDL.DeleteVendorDetailsWithoutMaster();
        }

        public static DataTable PopulateVendorDetList(int argVendorID, string argSuppType, string argListVendorId)
        {
            return VendorDL.PopulateVendorDetList(argVendorID, argSuppType, argListVendorId);
        }

        public static DataTable FillSuppVendorDetList(int argVendorID, string argSuppType)
        {
            return VendorDL.FillSuppVendorDetList(argVendorID, argSuppType);
        }

        public static void InsertVendorSupplierDet(int argVendorID, string argSuppType, DataTable dtList)
        {
            VendorDL.InsertVendorSupplierDet(argVendorID, argSuppType, dtList);
        }

        public static bool DelVendorSupplierDet(int argVendorID, int argSuppVenID, string argSuppType)
        {
            return VendorDL.DelVendorSupplierDet(argVendorID, argSuppVenID, argSuppType);
        }

        public static bool IsChkSupplierValid(int argVendorID, string argType)
        {
            return VendorDL.IsChkSupplierValid(argVendorID, argType);
        }

        public void MaxVendorUpdate(int argMaxNo)
        {
            m_oVendor.MaxVendorUpdate(argMaxNo);
        }

        //
        public static DataTable GetVendorCodeRegen()
        {
            return VendorDL.GetVendorCodeRegen();
        }

        public static string GetCodeCheckVendor()
        {
            return VendorDL.GetCodeCheckVendor();
        }

        public void MaxVendorMasterUpdate()
        {
            m_oVendor.MaxVendorMasterUpdate();
        }

        public static void MaxIncVendorMasterUpdate(int argVendorId, string argVendorCode)
        {
            VendorDL.MaxIncVendorMasterUpdate(argVendorId, argVendorCode);
        }
    }
}
