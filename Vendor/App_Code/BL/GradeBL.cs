using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class GradeBL
    {

        int m_lGradeId;
        string m_sGradeName;
        double m_dFValue;
        double m_dTValue;

        Vendor.DataLayer.GradeDL m_oGrade;

        public GradeBL()
        {
            m_oGrade = new Vendor.DataLayer.GradeDL();
        }


        public int GradeId
        {
            get { return m_lGradeId; }
            set { m_lGradeId = value; }
        }

        public String GradeName
        {
            get { return m_sGradeName; }
            set { m_sGradeName = value; }
        }

        public double FValue
        {
            get { return m_dFValue; }
            set { m_dFValue = value; }
        }

        public double TValue
        {
            get { return m_dTValue; }
            set { m_dTValue = value; }
        }

        public DataTable GetGradeMaster()
        {
            return m_oGrade.GetGradeMaster();
        }

        public void DeleteGrade(int argId)
        {
            m_oGrade.DeleteGrade(argId);
        }

        public void UpdateGrade(DataTable argGrade)
        {
            m_oGrade.UpdateGrade(argGrade);
        }
    }
}
