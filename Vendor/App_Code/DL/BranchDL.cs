using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class BranchDL
    {
        public DataTable GetBrachList(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "Select A.BranchId,A.VendorId,A.BranchName,A.Address,B.CityName,A.TINNo,A.CityId,A.Phone,A.ChequeNo from Branch A " +
                              "Left Join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.CityMaster B on A.CityId=B.CityId " +
                              "Where A.VendorId= " + argVendorId;
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



        public void InsertBranch(Vendor.BusinessLayer.BranchBL argBranch,DataTable dtContact)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            string sSql = "";
            int BranchId = 0;
            try
            {
                SqlCommand Command = new SqlCommand("Insert_Branch", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argBranch.VendorId);
                Command.Parameters.AddWithValue("@BranchName", argBranch.BranchName);
                Command.Parameters.AddWithValue("@Address", argBranch.BranchAddress);
                Command.Parameters.AddWithValue("@CityId", argBranch.CityId);
                Command.Parameters.AddWithValue("@TINNo", argBranch.TINNo);
                Command.Parameters.AddWithValue("@Phone", argBranch.Phone);
                Command.Parameters.AddWithValue("@ChequeNo", argBranch.ChequeNo);
                Command.Parameters.AddWithValue("@BranchId", 0);
                Command.Parameters["@BranchId"].Direction = ParameterDirection.Output;
                Command.ExecuteNonQuery();
                BranchId = Convert.ToInt32(Command.Parameters["@BranchId"].Value);

                if (dtContact.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtContact.Rows)
                    {
                        sSql = "Insert Into BranchTrans (BranchId,ContactPerson,Designation,ContactNo,Email,Fax) Values " +
                                "(" + BranchId + ",'" + dr["ContactPerson"].ToString() + "','" + dr["Designation"].ToString() + "', " +
                                "'" + dr["ContactNo"].ToString() + "','" + dr["Email"].ToString() + "','"+ dr["Fax"].ToString() +"') ";
                        Command = new SqlCommand(sSql, conn, tran);
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


        public void UpdateBranch(Vendor.BusinessLayer.BranchBL argBranch,DataTable dtContact)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            string sSql = "";
            try
            {
                SqlCommand Command = new SqlCommand("Update_Branch", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@BranchId", argBranch.BranchId);
                Command.Parameters.AddWithValue("@VendorId", argBranch.VendorId);
                Command.Parameters.AddWithValue("@BranchName", argBranch.BranchName);
                Command.Parameters.AddWithValue("@Address", argBranch.BranchAddress);
                Command.Parameters.AddWithValue("@CityId", argBranch.CityId);
                Command.Parameters.AddWithValue("@TINNo", argBranch.TINNo);
                Command.Parameters.AddWithValue("@Phone", argBranch.Phone);
                Command.Parameters.AddWithValue("@ChequeNo", argBranch.ChequeNo);
                Command.ExecuteNonQuery();

                if (dtContact.Rows.Count > 0)
                {
                    sSql="Delete BranchTrans Where BranchId="+ argBranch.BranchId +" ";
                    Command = new SqlCommand(sSql, conn, tran);
                    Command.ExecuteNonQuery();

                    foreach (DataRow dr in dtContact.Rows)
                    {
                        sSql = "Insert Into BranchTrans (BranchId,ContactPerson,Designation,ContactNo,Email,Fax) Values " +
                                "(" + argBranch.BranchId + ",'" + dr["ContactPerson"].ToString() + "','" + dr["Designation"].ToString() + "', " +
                                "'" + dr["ContactNo"].ToString() + "','" + dr["Email"].ToString() + "','"+ dr["Fax"].ToString() +"') ";
                        Command = new SqlCommand(sSql, conn, tran);
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

        public void DeleteBranch(int argId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_Branch", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@BranchId", argId);
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

        public static DataTable GetContact(int argBId)
        {
            string sSql = "";
            SqlDataAdapter sda;
            DataTable dt;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql="Select BranchTransId,BranchId,ContactPerson,Designation,ContactNo,Email,Fax From BranchTrans Where BranchId="+ argBId +" ";
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
            }
            catch (Exception ce)
            {
                throw ce;
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return dt;
        }

    }
}
