using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Vendor.BusinessLayer
{
    class HistoryBL
    {
        //int m_lVendorId;

        Vendor.DataLayer.HistoryDL m_oHistory;

        public HistoryBL()
        {
            m_oHistory = new Vendor.DataLayer.HistoryDL();
        }
        public DataTable GetSupplyDetails(int m_lVendorId)
        {
            return m_oHistory.GetSupplyDetails(m_lVendorId);
        }
        public DataTable GetOrderDetails(int m_lVendorId)
        {
            return m_oHistory.GetOrderDetails(m_lVendorId);
        }
        public DataTable GetPendingDetails(int m_lVendorId)
        {
            return m_oHistory.GetPendingDetails(m_lVendorId);
        }
        public DataTable GetPendingBills(int m_lVendorId)
        {
            return m_oHistory.GetPendingBills(m_lVendorId);
        }
        public DataTable GetRejected(int m_lVendorId)
        {
            return m_oHistory.GetRejected(m_lVendorId);
        }
        public DataTable GetReturns(int m_lVendorId)
        {
            return m_oHistory.GetReturns(m_lVendorId);
        }

        //GetContractDetails
        public DataTable GetContractWorkOrderDetails(int m_lVendorId)
        {
            return m_oHistory.GetContractWorkOrderDetails(m_lVendorId);
        }
        public DataTable GetContractWorkBillDetails(int m_lVendorId)
        {
            return m_oHistory.GetContractWorkBillDetails(m_lVendorId);
        }
        public DataTable GetContractWorkPendingBillDetails(int m_lVendorId)
        {
            return m_oHistory.GetContractWorkPendingBillDetails(m_lVendorId);
        }
        public DataTable GetServiceBillDetails(int m_lVendorId)
        {
            return m_oHistory.GetServiceBillDetails(m_lVendorId);
        }
        public DataTable GetServiceOrderDetails(int m_lVendorId)
        {
            return m_oHistory.GetServiceOrderDetails(m_lVendorId);
        }

        public DataTable GetPendingMINDet(int m_lVendorId)
        {
            return m_oHistory.GetPendingMINDet(m_lVendorId);
        }
    }
}



