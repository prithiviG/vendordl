using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class CountryBL
    {
        int m_lCountryId;
        string m_sCountryName;

        Vendor.DataLayer.CountryDL m_oCountry;

        public CountryBL()
        {
            m_oCountry = new Vendor.DataLayer.CountryDL();
        }

        public int CountryId
        {
            get { return m_lCountryId; }
            set { m_lCountryId = value; }
        }

        public String CountryName
        {
            get { return m_sCountryName; }
            set { m_sCountryName = value; }
        }
        public DataTable GetCountryList()
        {
            return m_oCountry.GetCountryList();
        }

        public int InsertCountry(string argCountry)
        {
            return m_oCountry.InsertCountry(argCountry);
        }

        public void UpdateCountry(int argId, string argName)
        {
            m_oCountry.UpdateCountry(argId, argName);
        }
        public void DeleteCountry(int argId)
        {
            m_oCountry.DeleteCountry(argId);
        }
        public bool CheckCountry(int argCId)
        {
            bool status = false;
            try
            {
                status = m_oCountry.CheckCountry(argCId);
            }
            catch (Exception ce)
            {
                throw ce;
            }
            return status;
        }
    }
}
