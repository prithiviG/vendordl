using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class CertificateDL
    {
        public DataTable GetCertificate()
        {

            DataTable dt = null;
            try
            {
                string sSql = "SELECT CertificateId,CerDescription from dbo.CertificateMaster Order by  CerDescription";
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

        public void UpdateCertificate(DataTable argCer)
        {

            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                DataTable dt;
                dt = new DataTable();
                dt = argCer.GetChanges(DataRowState.Added);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Insert_Certificate", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@CerDescription", dt.Rows[i]["CerDescription"]);
                        Command.ExecuteNonQuery();
                    }
                }

                dt = new DataTable();
                dt = argCer.GetChanges(DataRowState.Modified);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Update_Certificate", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@CertificateId", dt.Rows[i]["CertificateId"]);
                        Command.Parameters.AddWithValue("@CerDescription", dt.Rows[i]["CerDescription"]);
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

        public bool DeleteCertificate(int argCerId)
        {

            string sSql = "";                   
            DataTable dt;
            SqlCommand cmd;
            SqlDataAdapter sda;
            bool status=false;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select CertificateId From CertificateTrans Where CertificateId="+ argCerId +" ";
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
                if (dt.Rows.Count > 0) { status = false; }
                else
                {
                    status = true;
                    sSql = "Delete From CertificateMaster Where CertificateId="+ argCerId +" ";
                    cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch(Exception ce)
            {
                throw ce;

            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return status;
        }

    }
}
