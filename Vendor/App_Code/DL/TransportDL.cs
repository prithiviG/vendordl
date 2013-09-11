using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class TransportDL
    {
        public static DataTable PopulateTransport()
        {
            string sSql = "";
            DataTable dt = new DataTable();
            SqlDataAdapter sda;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select TransportId,TransportName From TransportMaster Order By TransportId Asc";
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return dt;
        }

        public static void TransportTransaction(int argTId, string argTName)
        {
            string sSql = "";
            SqlCommand cmd = new SqlCommand();
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                if (argTId == 0)
                {
                    sSql = "Insert Into TransportMaster (TransportName) Values ('" + argTName + "') ";

                }
                else
                {
                    sSql = "Update TransportMaster Set TransportName='" + argTName + "' Where TransportId=" + argTId + " ";
                }
                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
        }

        public static bool ValidDelete(int argTId)
        {
            string sSql = "";
            SqlDataReader sdr;
            SqlCommand cmd;
            DataTable dt = new DataTable();
            bool bValid = false;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select VehicleId From ["+ BsfGlobal.g_sMMSDBName +"].dbo.POLogistic Where VehicleId=" + argTId + " ";
                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                sdr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(sdr);
                sdr.Dispose();
                if (dt.Rows.Count > 0) { bValid = false; } else { bValid = true; }
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return bValid;
        }

        public static void DeleteTransport(int argTId)
        {
            string sSql = "";
            SqlCommand cmd;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Delete From TransportMaster Where TransportId=" + argTId + " ";
                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
        }

        public static DataTable GetTransport()
        {
            string sSql = "";
            SqlCommand cmd;
            SqlDataReader sdr;
            DataTable dt = new DataTable();
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select TransportId,TransportName From TransportMaster Order By TransportName Asc ";
                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                sdr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(sdr);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return dt;
        }

        public static DataTable GetVendorTransport(int argVId)
        {
            string sSql = "";
            SqlCommand cmd;
            SqlDataReader sdr;
            DataTable dt = new DataTable();
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select B.VendorId,A.TransportId,A.TransportName From TransportMaster A " +
                        "Inner Join VendorTransport B On A.TransportId=B.TransportId Where B.VendorId=" + argVId + " ";
                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                sdr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(sdr);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return dt;
        }
    }
}
