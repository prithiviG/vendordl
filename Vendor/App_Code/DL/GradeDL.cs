using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class GradeDL
    {

        public DataTable GetGradeMaster()
        {

            DataTable dt = null;
            try
            {
                string sSql = "SELECT GradeId,GradeName,FValue,TValue from dbo.GradeMaster " +
                              "Order by FValue";
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


        public void UpdateGrade(DataTable argGrade)
        {

            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                DataTable dt;
                dt = new DataTable();
                dt = argGrade.GetChanges(DataRowState.Added);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Insert_Grade", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@GradeName", dt.Rows[i]["GradeName"]);
                        Command.Parameters.AddWithValue("@FValue", dt.Rows[i]["FValue"]);
                        Command.Parameters.AddWithValue("@TValue", dt.Rows[i]["TValue"]);
                        Command.ExecuteNonQuery();
                    }
                }

                dt = new DataTable();
                dt = argGrade.GetChanges(DataRowState.Modified);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Update_Grade", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@GradeId", dt.Rows[i]["GradeId"]);
                        Command.Parameters.AddWithValue("@GradeName", dt.Rows[i]["GradeName"]);
                        Command.Parameters.AddWithValue("@FValue", dt.Rows[i]["FValue"]);
                        Command.Parameters.AddWithValue("@TValue", dt.Rows[i]["TValue"]);
                        Command.ExecuteNonQuery();
                    }
                }

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

        public void DeleteGrade(int argId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_Grade", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@GradeId", argId);
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
