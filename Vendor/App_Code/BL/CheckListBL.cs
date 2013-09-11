using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class CheckListBL
    {
        int m_lCheckListId;
        int m_lVendorId;
        string m_sDescription;
        bool m_bSupply;
        bool m_bContract;
        bool m_bService;
        double m_dPoints;
        string m_sRegType;


        Vendor.DataLayer.CheckListDL m_oCheckList;

        public CheckListBL()
        {
            m_oCheckList = new Vendor.DataLayer.CheckListDL();
        }


        public int CheckListId
        {
            get { return m_lCheckListId; }
            set { m_lCheckListId = value; }
        }

        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
        }


        public String Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }

        public String RegType
        {
            get { return m_sRegType; }
            set { m_sRegType = value; }
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

        public double Points
        {
            get { return m_dPoints; }
            set { m_dPoints = value; }
        }

        public DataTable GetCheckListMastert()
        {
            return m_oCheckList.GetCheckListMastert();
        }

        public void UpdateCheckList(DataTable argCheckList)
        {
            m_oCheckList.UpdateCheckList(argCheckList);
        }
        public bool CheckListFound(int argId)
        {
            return m_oCheckList.CheckListFound(argId);
        }
        public void DeleteCheckList(int argId)
        {
            m_oCheckList.DeleteCheckList(argId);
        }

        public bool GetTypeSetup()
        {
            return m_oCheckList.GetTypeSetup();
        }
        public void UpdateTypeSetup(bool argAns)
        {
            m_oCheckList.UpdateTypeSetup(argAns);
        }

        //Vendor Code Setup

        public void UpdateVendorCodeSetup(bool argAns, string argPre, string argSuf,int argWidth)
        {
            m_oCheckList.UpdateVendorCodeSetup(argAns,argPre, argSuf, argWidth);
        }

        public DataTable GetVendorCodeTypeSetup()
        {
            return m_oCheckList.GetVendorCodeTypeSetup();
        }

    }
}
