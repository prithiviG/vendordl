using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vendor.BusinessLayer
{
    class SupplyBL
    {
        int m_lVendorId;
        int m_lMaterialId;
        int m_lMaterialGroupId;
        string m_sPriority;
        string m_sSupplyType;
        int m_lLeadTime;
        int m_lCrediDays;
        string m_sContactPerson;
        string m_sContactNo;
        string m_sEmail;

        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
        }

        public int MaterialId
        {
            get { return m_lMaterialId; }
            set { m_lMaterialId = value; }
        }

        public int MaterialGroupId
        {
            get { return m_lMaterialGroupId; }
            set { m_lMaterialGroupId = value; }
        }

        public string Priority
        {
            get { return m_sPriority; }
            set { m_sPriority = value; }
        }

        public string SupplyType
        {
            get { return m_sSupplyType; }
            set { m_sSupplyType = value; }
        }

        public int LeadTime
        {
            get { return m_lLeadTime; }
            set { m_lLeadTime = value; }
        }

        public int CreditDays
        {
            get { return m_lCrediDays; }
            set { m_lCrediDays = value; }
        }

        public string ContactPerson
        {
            get { return m_sContactPerson; }
            set { m_sContactPerson = value; }
        }
        public string ContactNo
        {
            get { return m_sContactNo; }
            set { m_sContactNo = value; }
        }
        public string Email
        {
            get { return m_sEmail; }
            set { m_sEmail = value; }
        }
    }
}
