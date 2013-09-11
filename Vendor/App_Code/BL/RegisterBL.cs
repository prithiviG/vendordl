using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class RegisterBL
    {
        int m_lVendorId;
        DateTime m_dRegDate;
        string m_sRegNo;
        DateTime m_dSFDate;
        DateTime m_dSTDate;
        bool m_bSLife;
        DateTime m_dCFDate;
        DateTime m_dCTDate;
        bool m_bCLife;
        DateTime m_dHFDate;
        DateTime m_dHTDate;
        bool m_bHLife;
        int m_bRegesterId;
        int m_bRegTransId;
        bool m_bSupply;
        bool m_bContract;
        bool m_bService;
        string m_sType;
        string m_sRemarks;

        int m_lSGradeId;
        int m_lCGradeID;
        int m_lHGradeId;

        double  m_lSuppMaxPoint;
        double m_lSuppPoints;
        double m_lContMaxPoint;
        double m_lContPoints;
        double m_lServMaxPoint;
        double m_lServPoints;

        Vendor.DataLayer.RegisterDL m_oRegister;

        public RegisterBL()
        {
            m_oRegister = new Vendor.DataLayer.RegisterDL();
        }

        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
        }

        public DateTime RegDate
        {
            get { return m_dRegDate; }
            set { m_dRegDate = value; }
        }

        public string RegNo
        {
            get { return m_sRegNo; }
            set { m_sRegNo = value; }
        }

        public DateTime SFDate
        {
            get { return m_dSFDate; }
            set { m_dSFDate = value; }
        }

        public DateTime STDate
        {
            get { return m_dSTDate; }
            set { m_dSTDate = value; }
        }

        public DateTime CFDate
        {
            get { return m_dCFDate; }
            set { m_dCFDate = value; }
        }

        public DateTime CTDate
        {
            get { return m_dCTDate; }
            set { m_dCTDate = value; }
        }

        public DateTime HFDate
        {
            get { return m_dHFDate; }
            set { m_dHFDate = value; }
        }

        public DateTime HTDate
        {
            get { return m_dHTDate; }
            set { m_dHTDate = value; }
        }

        public int RegisterId
        {
            get { return m_bRegesterId; }
            set { m_bRegesterId = value; }
        }

        public int RegTransId
        {
            get { return m_bRegTransId; }
            set { m_bRegTransId = value; }
        }

        public bool SLife
        {
            get { return m_bSLife; }
            set { m_bSLife = value; }
        }

        public bool CLife
        {
            get { return m_bCLife; }
            set { m_bCLife = value; }
        }

        public bool HLife
        {
            get { return m_bHLife; }
            set { m_bHLife = value; }
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


        public int SGradeId
        {
            get { return m_lSGradeId; }
            set { m_lSGradeId = value; }
        }

        public int CGradeId
        {
            get { return m_lCGradeID; }
            set { m_lCGradeID = value; }
        }

        public int HGradeId
        {
            get { return m_lHGradeId; }
            set { m_lHGradeId = value; }
        }

        public string StatusType
        {
            get { return m_sType; }
            set { m_sType = value; }
        }

        public string Remarks
        {
            get { return m_sRemarks; }
            set { m_sRemarks = value; }
        }
        public double SupplyMaxPoint
        {
            get { return m_lSuppMaxPoint; }
            set { m_lSuppMaxPoint = value; }
        }
        public double SupplyPoints
        {
            get { return m_lSuppPoints; }
            set { m_lSuppPoints = value; }
        }
        public double ContractMaxPoint
        {
            get { return m_lContMaxPoint; }
            set { m_lContMaxPoint = value; }
        }
        public double ContractPoints
        {
            get { return m_lContPoints; }
            set { m_lContPoints = value; }
        }
        public double ServiceMaxPoint
        {
            get { return m_lServMaxPoint; }
            set { m_lServMaxPoint = value; }
        }
        public double ServicePoints
        {
            get { return m_lServPoints; }
            set { m_lServPoints = value; }
        }
        public DataTable GetCheckListTrans(int argVendorID)
        {
            return m_oRegister.GetCheckListTrans(argVendorID);
        }
        public void DeleteCheckListTrans(int argVendorId)
        {
            m_oRegister.DeleteCheckListTrans(argVendorId);
        }

        public void InsertCheckListTrans(Vendor.BusinessLayer.CheckListBL argCheckList)
        {
            m_oRegister.InsertCheckListTrans(argCheckList);
        }
        public void InsertAssessment(Vendor.BusinessLayer.RegisterBL argRegister)
        {
            m_oRegister.InsertAssessment(argRegister);
        }
        public DataTable GetRegistration(int argVendorID)
        {
            return m_oRegister.GetRegistration(argVendorID);
        }
        public void UpdateGradeTrans(Vendor.BusinessLayer.RegisterBL argRegister)
        {
            m_oRegister.UpdateGradeTrans(argRegister);
        }
        public DataTable GetGradeTrans(int argVendorID)
        {
            return m_oRegister.GetGradeTrans(argVendorID);
        }
        public bool CheckRegNo(int argRegId, string argRegNo)
        {
            return m_oRegister.CheckRegNo(argRegId, argRegNo);
        }
        public void InsertRegistration(Vendor.BusinessLayer.RegisterBL argRegister)
        {
            m_oRegister.InsertRegistration(argRegister);
        }
        public void UpdateRegistration(Vendor.BusinessLayer.RegisterBL argRegister)
        {
            m_oRegister.UpdateRegistration(argRegister);
        }
        public DataTable GetRegNo()
        {
            return m_oRegister.GetRegNo();
        }
        public DataTable GetRegTrans(int argVendorID)
        {
            return m_oRegister.GetRegTrans(argVendorID);
        }
        public void InsertRegTrans(Vendor.BusinessLayer.RegisterBL argRegister, int argTypeId)
        {
            m_oRegister.InsertRegTrans(argRegister, argTypeId);
        }
        public void UpdateRegTrans(Vendor.BusinessLayer.RegisterBL argRegister)
        {
            m_oRegister.UpdateRegTrans(argRegister);
        }
        public int GetMaxRegTransId(int argVendorID)
        {
            return m_oRegister.GetMaxRegTransId(argVendorID);
        }
        public void DeleteRegTrans(int argTransId)
        {
            m_oRegister.DeleteRegTrans(argTransId);
        }
        public bool CheckRegTrans(int argVendorId)
        {
            return m_oRegister.CheckRegTrans(argVendorId);
        }
        public void DeleteRegistration(int argRegId)
        {
            m_oRegister.DeleteRegistration(argRegId);
        }
        public DataTable GetRegVendorList()
        {
            return m_oRegister.GetRegVendorList();
        }
        public DataSet GetRegUpdateDetails(int argVendorID)
        {
            return m_oRegister.GetRegUpdateDetails(argVendorID);
        }
        public void InsertRegTransLatest(Vendor.BusinessLayer.RegUpdateBL argRegister)
        {
            m_oRegister.InsertRegTransLatest(argRegister);
        }
        public DataTable GetRegTransLatest(int argVendorID)
        {
            return m_oRegister.GetRegTransLatest(argVendorID);
        }
        public DataTable GetGradeName(int argVendorID, string argRegType)
        {
            return m_oRegister.GetGradeName(argVendorID, argRegType);
        }

       
    }
}
