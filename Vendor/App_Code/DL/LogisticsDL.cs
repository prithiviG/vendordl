using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class LogisticsDL
    {
        public DataTable GetLogistics(int argVendorId)
        {

            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorId,TransportArrange,TransportMode,Delivery,Insurance,Unload " +
	                          "from Logistics Where VendorId= " + argVendorId;
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

        public DataTable GetTransportMode()
        {

            DataTable dt = null;
            try
            {
                string sSql = "SELECT Distinct TransportMode from dbo.Logistics Order by TransportMode";
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

        public void InsertLogistics(Vendor.BusinessLayer.LogisticsBL argLogistics)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Insert_Logistics", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argLogistics.VendorId);
                Command.Parameters.AddWithValue("@TransportArrange", argLogistics.TransportArrange);
                Command.Parameters.AddWithValue("@TransportMode", argLogistics.TransportMode);
                Command.Parameters.AddWithValue("@Delivery", argLogistics.Delivery);
                Command.Parameters.AddWithValue("@Insurance", argLogistics.Insurance);
                Command.Parameters.AddWithValue("@Unload", argLogistics.Unload);

                Command.ExecuteNonQuery();
                tran.Commit();
            }
            catch 
            {
                tran.Rollback();
            }

            finally
            {
                conn.Close();
            }
        }

    }
}
