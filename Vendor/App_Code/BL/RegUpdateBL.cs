using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vendor.BusinessLayer
{
    class RegUpdateBL
    {
        int m_lVendorId;

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
        bool m_bSupply;
        bool m_bContract;
        bool m_bService;

        int m_lSGradeId;
        int m_lCGradeID;
        int m_lHGradeId;

        bool m_bSSespend;
        bool m_bCSespend;
        bool m_bHSespend;

        bool m_bSBlackList;
        bool m_bCBlackList;
        bool m_bHBlackList;


  


        Vendor.DataLayer.RegisterDL m_oRegister;

        public RegUpdateBL()
        {
            m_oRegister = new Vendor.DataLayer.RegisterDL();
        }

        public int RegisterId
        {
            get { return m_bRegesterId; }
            set { m_bRegesterId = value; }
        }


        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
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

        public bool SSuspend
        {
            get { return m_bSSespend; }
            set { m_bSSespend = value; }
        }

        public bool CSuspend
        {
            get { return m_bCLife; }
            set { m_bCSespend = value; }
        }

        public bool HSuspend
        {
            get { return m_bHSespend; }
            set { m_bHSespend = value; }
        }

        public bool SBlackList
        {
            get { return m_bSBlackList; }
            set { m_bSBlackList = value; }
        }

        public bool CBlackList
        {
            get { return m_bCBlackList; }
            set { m_bCBlackList = value; }
        }

        public bool HBlackList
        {
            get { return m_bHBlackList; }
            set { m_bHBlackList = value; }
        }
        public void UpdateRegistration(int argVendorId)
        {
            m_oRegister.UpdateRegistration(argVendorId);
        }
    }
}
