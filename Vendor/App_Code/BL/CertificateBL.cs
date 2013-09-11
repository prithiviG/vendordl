using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Vendor.BusinessLayer
{
    class CertificateBL
    {
        Vendor.DataLayer.CertificateDL m_oCer;

        public CertificateBL()
        {
            m_oCer = new Vendor.DataLayer.CertificateDL();
        }

        public DataTable GetCertificate()
        {
            return m_oCer.GetCertificate();
        }
        public void UpdateCertificate(DataTable argCer)
        {
            m_oCer.UpdateCertificate(argCer);
        }
        public bool DeleteCertificate(int argCerId)
        {
            bool status;
            status=m_oCer.DeleteCertificate(argCerId);
            return status;
        }
    }
}
