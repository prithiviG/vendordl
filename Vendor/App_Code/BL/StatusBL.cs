using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class StatusBL
    {
        int m_lStatusId;
        int m_lVendorId;
        string m_lStatusType;
        string m_lRegType;
        int m_lRegisterId;
        string m_lRefNo;
        DateTime m_lSDate;
        DateTime m_lValidFrom;
        DateTime m_lValidTo;
        int m_lLifTime;
        int m_lGradeId;
        
        Vendor.DataLayer.StatusDL m_oStastu;

        public StatusBL()
        {
            m_oStastu = new Vendor.DataLayer.StatusDL();
        }
        public DataTable GetStatusRegister()
        {
            return m_oStastu.GetStatusRegister();
        }
        public int StatusId
        {
            get { return m_lStatusId; }
            set { m_lStatusId = value; }
        }
        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
        }
        public String StatusType
        {
            get { return m_lStatusType; }
            set { m_lStatusType=value; }
        }
        public String RegType
        {
            get { return m_lRegType; }
            set { m_lRegType = value; }
        }
        public int RegisterId
        {
            get { return m_lRegisterId; }
            set { m_lRegisterId = value; }
        }
        public string RefNo
        {
            get { return m_lRefNo; }
            set { m_lRefNo = value; }
        }
        public DateTime SDate
        {
            get { return m_lSDate; }
            set { m_lSDate = value; }
        }
        public DateTime ValidFrom
        {
            get { return m_lValidFrom; }
            set { m_lValidFrom = value; }
        }
        public DateTime ValidTo
        {
            get { return m_lValidTo; }
            set { m_lValidTo = value; }
        }
        public int LifTime
        {
            get { return m_lLifTime; }
            set { m_lLifTime = value; }
        }
        public int GradeId
        {
            get { return m_lGradeId; }
            set { m_lGradeId = value; }
        }
        public void InsertStatusEntry(Vendor.BusinessLayer.StatusBL argSts)
        {
            m_oStastu.InsertStatusEntry(argSts);
        }
        public DataTable GetVendorName()
        {
            return m_oStastu.GetVendorName();
        }
        public DataSet GetStatusRegisterEdit(int StsId)
        {
            return m_oStastu.GetStatusRegisterEdit(StsId);
        }
        public void UpdateStatusEntry(Vendor.BusinessLayer.StatusBL argSts)
        {
            m_oStastu.UpdateStatusEntry(argSts);
        }
        public void DeleteStatusEntry(int StsId)
        {
            m_oStastu.DeleteStatusEntry(StsId);
        }
    }
}
