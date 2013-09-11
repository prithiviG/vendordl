using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class LogisticsBL
    {
        int m_lVendorId;
        string m_sTransportArrange;
        string m_sTransportMode;
        string m_sDelivery;
        string m_sInsurance;
        string m_sUnload;

        Vendor.DataLayer.LogisticsDL m_oLogistics;

        public LogisticsBL()
        {
            m_oLogistics = new Vendor.DataLayer.LogisticsDL();
        }

        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
        }

        public string TransportArrange
        {
            get { return m_sTransportArrange; }
            set { m_sTransportArrange = value; }
        }

        public string TransportMode
        {
            get { return m_sTransportMode; }
            set { m_sTransportMode = value; }
        }

        public string Delivery
        {
            get { return m_sDelivery; }
            set { m_sDelivery = value; }
        }

        public string Insurance
        {
            get { return m_sInsurance; }
            set { m_sInsurance = value; }
        }

        public string Unload
        {
            get { return m_sUnload; }
            set { m_sUnload = value; }
        }

        public DataTable GetLogistics(int argVendorId)
        {
            return m_oLogistics.GetLogistics(argVendorId);
        }

        public DataTable GetTransportMode()
        {
            return m_oLogistics.GetTransportMode();
        }

        public void InsertLogistics(Vendor.BusinessLayer.LogisticsBL argLogistics)
        {
            m_oLogistics.InsertLogistics(argLogistics);
        }
    }
}
