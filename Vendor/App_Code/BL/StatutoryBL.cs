using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class StatutoryBL
    {
        int m_lVendorId;
        string m_sFirmType;
        int m_lEYear;
        string m_sPANNo;
        string m_sTANNo;
        string m_sCSTNo;
        string m_sTINNo;
        string m_sBankAccountNo;
        string m_sAccountType;
        string m_sBankName;
        string m_sBranchName;
        string m_sBranchCode;
        string m_sServiceTaxNo;
        string m_sTNGSTNo;
        string m_sMICRCode;
        string m_sIFSCCode;
        string m_sSSIREGDNo;
        string m_sServiceTaxCir;
        string m_sEPFNo;
        string m_sESINo;
        int m_sExciseVendor;
        string m_sExciseRegNo;
        string m_sExcisedivision;
        string m_sExciseRange;
        string m_sECCno;


        Vendor.DataLayer.StatutoryDL m_oStatutory;

        public StatutoryBL()
        {
            m_oStatutory = new Vendor.DataLayer.StatutoryDL();
        }



        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
        }

        public String FirmType
        {
            get { return m_sFirmType; }
            set { m_sFirmType = value; }
        }

        public int EYear
        {
            get { return m_lEYear; }
            set { m_lEYear = value; }
        }

        public String PANNo
        {
            get { return m_sPANNo; }
            set { m_sPANNo = value; }
        }

        public String TANNo
        {
            get { return m_sTANNo; }
            set { m_sTANNo = value; }
        }

        public String CSTNo
        {
            get { return m_sCSTNo; }
            set { m_sCSTNo = value; }
        }

        public String TINNo
        {
            get { return m_sTINNo; }
            set { m_sTINNo = value; }
        }

        public String BankAccountNo
        {
            get { return m_sBankAccountNo; }
            set { m_sBankAccountNo = value; }
        }

        public String AccountType
        {
            get { return m_sAccountType; }
            set { m_sAccountType = value; }
        }

        public String BankName
        {
            get { return m_sBankName; }
            set { m_sBankName = value; }
        }

        public String BranchName
        {
            get { return m_sBranchName; }
            set { m_sBranchName = value; }
        }

        public String BranchCode
        {
            get { return m_sBranchCode; }
            set { m_sBranchCode = value; }
        }

        public String ServiceTaxNo
        {
            get { return m_sServiceTaxNo; }
            set { m_sServiceTaxNo = value; }
        }

        public String TNGSTNo
        {
            get { return m_sTNGSTNo; }
            set { m_sTNGSTNo = value; }
        }

        public String MICRCode
        {
            get { return m_sMICRCode; }
            set { m_sMICRCode = value; }
        }

        public String IFSCCode
        {
            get { return m_sIFSCCode; }
            set { m_sIFSCCode = value; }
        }
        //SSIREGDNo,ServiceTaxCir,EPFNo,ESINo,ExciseVendor,ExciseRegNo,Excisedivision,ExciseRange,ECCno
        public String SSIREGDNo
        {
            get { return m_sSSIREGDNo; }
            set { m_sSSIREGDNo = value; }
        }

        public String ServiceTaxCir
        {
            get { return m_sServiceTaxCir; }
            set { m_sServiceTaxCir = value; }
        }
        public String EPFNo
        {
            get { return m_sEPFNo; }
            set { m_sEPFNo = value; }
        }
        public String ESINo
        {
            get { return m_sESINo; }
            set { m_sESINo = value; }
        }
        public int ExciseVendor
        {
            get { return m_sExciseVendor; }
            set { m_sExciseVendor = value; }
        }
        public String ExciseRegNo
        {
            get { return m_sExciseRegNo; }
            set { m_sExciseRegNo = value; }
        }
        public String Excisedivision
        {
            get { return m_sExcisedivision; }
            set { m_sExcisedivision = value; }
        }
        public String ECCno
        {
            get { return m_sECCno; }
            set { m_sECCno = value; }
        }
        public String ExciseRange
        {
            get { return m_sExciseRange; }
            set { m_sExciseRange = value; }
        }

        public DataTable GetVendorStatutory(int argVendorId)
        {
            return m_oStatutory.GetVendorStatutory(argVendorId);
        }

        public void InsertVendorStatutory(Vendor.BusinessLayer.StatutoryBL argStatutory)
        {
            m_oStatutory.InsertVendorStatutory(argStatutory);

        }

    
    }
}
