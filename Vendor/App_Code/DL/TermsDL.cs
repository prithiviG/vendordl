using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class TermsDL
    {
        public DataTable GetTerms(int argVendorId)
        {

            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorId,CreditDays,MaxLeadTime,TermsAndCondition from VendorTerms " +
                              "Where VendorId = " + argVendorId;
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

        public void InsertTerms(Vendor.BusinessLayer.TermsBL argTerms)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Insert_Terms", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argTerms.VendorId);
                Command.Parameters.AddWithValue("@CreditDays", argTerms.CreditDays);
                Command.Parameters.AddWithValue("@MaxLeadTime", argTerms.MaxLeadTime);
                Command.Parameters.AddWithValue("@Terms", argTerms.Terms);
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
