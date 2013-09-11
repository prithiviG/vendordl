using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class ContactBL
    {
        int m_lVendorId;
        string m_sAddress;
        string m_sPhone1;
        string m_sPhone2;
        string m_sFax1;
        string m_sFax2;
        string m_sMobile1;
        string m_sMobile2;
        string m_sCPerson1;
        string m_sCPerson2;
        string m_sCDesignation1;
        string m_sCDesignation2;
        string m_sContactNo1;
        string m_sContactNo2;
        string m_sEmail1;
        string m_sEmail2;
        string m_sWeb;

        Vendor.DataLayer.ContactDL m_oContact;        

        public ContactBL()
        {
            m_oContact = new Vendor.DataLayer.ContactDL();
        }

        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
        }

        public String Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public String Phone1
        {
            get { return m_sPhone1; }
            set { m_sPhone1 = value; }
        }

        public String Phone2
        {
            get { return m_sPhone2; }
            set { m_sPhone2 = value; }
        }

        public String Fax1
        {
            get { return m_sFax1; }
            set { m_sFax1 = value; }
        }

        public String Fax2
        {
            get { return m_sFax2; }
            set { m_sFax2 = value; }
        }

        public String Mobile1
        {
            get { return m_sMobile1; }
            set { m_sMobile1 = value; }
        }

        public String Mobile2
        {
            get { return m_sMobile2; }
            set { m_sMobile2 = value; }
        }

        public String CPerson1
        {
            get { return m_sCPerson1; }
            set { m_sCPerson1 = value; }
        }

        public String CPerson2
        {
            get { return m_sCPerson2; }
            set { m_sCPerson2 = value; }
        }

        public String CDesignation1
        {
            get { return m_sCDesignation1; }
            set { m_sCDesignation1 = value; }
        }

        public String CDesignation2
        {
            get { return m_sCDesignation2; }
            set { m_sCDesignation2 = value; }
        }

        public String ContactNo1
        {
            get { return m_sContactNo1; }
            set { m_sContactNo1 = value; }
        }

        public String ContactNo2
        {
            get { return m_sContactNo2; }
            set { m_sContactNo2 = value; }
        }

        public String Email1
        {
            get { return m_sEmail1; }
            set { m_sEmail1 = value; }
        }

        public String Email2
        {
            get { return m_sEmail2; }
            set { m_sEmail2 = value; }
        }

        public String Web
        {
            get { return m_sWeb; }
            set { m_sWeb = value; }
        }

        public DataTable GetVendorContactInfo(int argVendorId)
        {
            return m_oContact.GetVendorContactInfo(argVendorId);            
        }

        public void InsertVendorContact(Vendor.BusinessLayer.ContactBL argContact)
        {
            m_oContact.InsertVendorContact(argContact);
        }
    }
}
