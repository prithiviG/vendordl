using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class ExperienceBL
    {

        int m_lExperienceId;
        int m_lVendorId;
        string m_sWorkDescription;
        string m_sClientName;
        decimal m_dValue;
        string m_sPeriod;
        string m_sType;

        Vendor.DataLayer.ExperienceDL m_oExperience;

        public ExperienceBL()
        {
            m_oExperience = new Vendor.DataLayer.ExperienceDL();
        }

        public int ExperienceId
        {
            get { return m_lExperienceId; }
            set { m_lExperienceId = value; }
        }

        public int VendorId
        {
            get { return m_lVendorId; }
            set { m_lVendorId = value; }
        }

        public string WorkDescription
        {
            get { return m_sWorkDescription; }
            set { m_sWorkDescription = value; }
        }

        public string ClientName
        {
            get { return m_sClientName; }
            set { m_sClientName = value; }
        }

        public decimal Value
        {
            get { return m_dValue; }
            set { m_dValue = value; }
        }


        public string Period
        {
            get { return m_sPeriod; }
            set { m_sPeriod = value; }
        }

        public string Type
        {
            get { return m_sType; }
            set { m_sType = value; }
        }

        public DataTable GetExperience(int argVendorId)
        {
            return m_oExperience.GetExperience(argVendorId);
        }

        public void InsertExperience(Vendor.BusinessLayer.ExperienceBL argExp)
        {
            m_oExperience.InsertExperience(argExp);
        }

        public void UpdateExperience(Vendor.BusinessLayer.ExperienceBL argExp)
        {
            m_oExperience.UpdateExperience(argExp);
        }
        public void DeleteExperience(int argId)
        {
            m_oExperience.DeleteExperience(argId);
        }

    }
}
