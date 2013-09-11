using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class AlertDL
    {
        public DataTable GetAlertDatas(DateTime argDate)
        {
            DataTable dt = null;
            try
            {
                string sSql = "Select B.RegNo,Convert(char(10),B.RegDate,103) as RegDate, " +
	                          "C.VendorName,G.Status,Convert(char(10),G.UDate,103) as ValidUpto from " +
	                          "(Select RegisterId,VendorId,STDate UDate,Case When SSuspend=0 then 'Supply Renewal' else 'Supply Suspend Renewal' End Status " +
	                          "From RegTransLatest Where STDate <= '" + String.Format("{0:dd/MMM/yyyy}",argDate) + "' and SBlackList=0 and SLife=0 " +
	                          "Union All " +
	                          "Select RegisterId,VendorId,CTDate UDate,Case When CSuspend=0 then 'Contract Renewal' else 'Contract Suspend Renewal' End Status " +
                              "From RegTransLatest Where CTDate <= '" + String.Format("{0:dd/MMM/yyyy}", argDate) + "' and CBlackList=0 and CLife=0 " +
	                          "Union All " +
	                          "Select RegisterId,VendorId,HTDate UDate,Case When HSuspend=0 then 'Service Renewal' else 'Service Suspend Renewal' End Status " +
                              "From RegTransLatest 	Where HTDate <= '" + String.Format("{0:dd/MMM/yyyy}", argDate) + "' and HBlackList=0 and HLife=0) G " +
	                          "Inner Join dbo.Registration B on G.RegisterId = B.RegisterId " +
	                          "Inner Join dbo.VendorMaster C on G.VendorId = C.VendorId " +
	                          "Order by G.UDate Desc";

                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_VendorDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;

        }
    }
}
