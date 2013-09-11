using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class AlertBL
    {
        Vendor.DataLayer.AlertDL m_oAlert;

        public AlertBL()
        {
            m_oAlert = new Vendor.DataLayer.AlertDL();
        }
        public DataTable GetAlertDatas(DateTime DDate)
        {
            return m_oAlert.GetAlertDatas(DDate);
        }
    }
}
