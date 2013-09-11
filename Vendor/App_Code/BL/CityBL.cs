using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class CityBL
    {

        int m_lCityId;
        String m_sCityName;
        int m_lCountryId;
        int m_lStateId;

        Vendor.DataLayer.CityDL m_oCity;

        public CityBL()
        {
            m_oCity = new Vendor.DataLayer.CityDL();
        }


        public int CityId
        {
            get { return m_lCityId; }
            set { m_lCityId = value; }
        }

        public int StateId
        {
            get { return m_lStateId; }
            set { m_lStateId = value; }
        }


        public int CountryId
        {
            get { return m_lCountryId; }
            set { m_lCountryId = value; }
        }

        public String CityName
        {
            get { return m_sCityName; }
            set { m_sCityName = value; }
        }


        public DataTable GetCityList()
        {
            return m_oCity.GetCityList();
        }

        public void UpdateCity(Vendor.BusinessLayer.CityBL argCity)
        {
            m_oCity.UpdateCity(argCity);
        }

        public void InsertCity(Vendor.BusinessLayer.CityBL argCity)
        {
            m_oCity.InsertCity(argCity);
        }

        public bool CheckCity(int argCityId)
        {
            bool status = false;
            try
            {
                status = m_oCity.CheckCity(argCityId);
            }
            catch (Exception ce)
            {
                throw ce;
            }
            return status;
        }
        public void DeleteCity(int argCityId)
        {
            try
            {
                m_oCity.DeleteCity(argCityId);
            }
            catch (Exception ce)
            {
                throw ce;
            }
        }
    }
}
