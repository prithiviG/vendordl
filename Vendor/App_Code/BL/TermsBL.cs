using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class TermsBL
    {
        int m_lVendorId;
        int m_lCreditDays;
        string m_sTerms;
        int m_lMaxLeadTime;

        Vendor.DataLayer.TermsDL m_oTerms;

        public TermsBL()
        {
            m_oTerms = new Vendor.DataLayer.TermsDL();
        }

        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
        }


        public int CreditDays
        {
            get { return m_lCreditDays; }
            set { m_lCreditDays = value; }
        }

        public string Terms
        {
            get { return m_sTerms; }
            set { m_sTerms = value; }
        }
        public int MaxLeadTime
        {
            get { return m_lMaxLeadTime; }
            set { m_lMaxLeadTime = value; }
        }
        public DataTable GetTerms(int argVendorId)
        {
            return m_oTerms.GetTerms(argVendorId);
        }
        public void InsertTerms(Vendor.BusinessLayer.TermsBL argTerms)
        {
            m_oTerms.InsertTerms(argTerms);
        }
    }
}
