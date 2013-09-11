using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class ExperienceDL
    {
        public DataTable GetExperience(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "Select ExperienceId,VendorId,WorkDescription,ClientName,Value,Period,Type " +
                              "from dbo.VendorExperience Where VendorId = " + argVendorId;
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


        public void InsertExperience(Vendor.BusinessLayer.ExperienceBL argExp)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Insert_Experience", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argExp.VendorId);
                Command.Parameters.AddWithValue("@WorkDescription", argExp.WorkDescription);
                Command.Parameters.AddWithValue("@ClientName", argExp.ClientName);
                Command.Parameters.AddWithValue("@Value", argExp.Value);
                Command.Parameters.AddWithValue("@Period", argExp.Period);
                Command.Parameters.AddWithValue("@Type", argExp.Type);
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


        public void UpdateExperience(Vendor.BusinessLayer.ExperienceBL argExp)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Update_Experience", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@ExperienceId", argExp.ExperienceId);
                Command.Parameters.AddWithValue("@VendorId", argExp.VendorId);
                Command.Parameters.AddWithValue("@WorkDescription", argExp.WorkDescription);
                Command.Parameters.AddWithValue("@ClientName", argExp.ClientName);
                Command.Parameters.AddWithValue("@Value", argExp.Value);
                Command.Parameters.AddWithValue("@Period", argExp.Period);
                Command.Parameters.AddWithValue("@Type", argExp.Type);
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

        public void DeleteExperience(int argId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_Experience", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@ExperienceId", argId);
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
