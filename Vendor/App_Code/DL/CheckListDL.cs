using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class CheckListDL
    {
        public DataTable GetCheckListMastert()
        {

            DataTable dt = null;
            try
            {
                string sSql = "Select CheckListId,Description,Supply,Contract,Service,MaxPoint from " +
	                          "CheckListMaster Order by MaxPoint Desc";
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

        public bool GetTypeSetup()
        {

            bool bAns = false;
            try
            {
                string sSql = "Select GenType from TypeSetup";
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                if (dt.Rows.Count >0) { bAns = Convert.ToBoolean(dt.Rows[0]["GenType"]);}
                dt.Dispose();
                BsfGlobal.g_VendorDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return bAns;
        }

        public void UpdateTypeSetup(bool argAns)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                int i=0;
                int iCount = 0;
                if (argAns == true) { i=1;}
                string sSql = "Update TypeSetup Set GenType = " + i;
                SqlCommand cmd = new SqlCommand(sSql, conn, tran);
                iCount = cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (iCount == 0)
                {
                    sSql = "Insert into TypeSetup(GenType) Values(" + i + ")";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
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

        public bool CheckListFound(int argId)
        {
            bool bAns = false;
            try
            {
                string sSql = "Select VendorId from VendorCheckListTrans Where CheckListId = " + argId;
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                if (dt.Rows.Count > 0) { bAns = true; }
                dt.Dispose();
                BsfGlobal.g_VendorDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return bAns;

        }

        public void DeleteCheckList(int argId)
        {

            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                string sSql = "Delete from CheckListMaster Where CheckListId = " + argId;
                SqlCommand cmd = new SqlCommand(sSql, conn, tran);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

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

        public void UpdateCheckList(DataTable argCheckList)
        {

            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                DataTable dt;
                dt= new DataTable();
                dt = argCheckList.GetChanges(DataRowState.Added);

                if (dt!= null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Insert_CheckList", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@Description", dt.Rows[i]["Description"]);
                        Command.Parameters.AddWithValue("@Supply", dt.Rows[i]["Supply"]);
                        Command.Parameters.AddWithValue("@Contract", dt.Rows[i]["Contract"]);
                        Command.Parameters.AddWithValue("@Service", dt.Rows[i]["Service"]);
                        Command.Parameters.AddWithValue("@MaxPoint", dt.Rows[i]["MaxPoint"]);
                        Command.ExecuteNonQuery();
                    }
                }

                dt = new DataTable();
                dt = argCheckList.GetChanges(DataRowState.Modified);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Update_CheckList", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@CheckListId", dt.Rows[i]["CheckListId"]);
                        Command.Parameters.AddWithValue("@Description", dt.Rows[i]["Description"]);
                        Command.Parameters.AddWithValue("@Supply", dt.Rows[i]["Supply"]);
                        Command.Parameters.AddWithValue("@Contract", dt.Rows[i]["Contract"]);
                        Command.Parameters.AddWithValue("@Service", dt.Rows[i]["Service"]);
                        Command.Parameters.AddWithValue("@MaxPoint", dt.Rows[i]["MaxPoint"]);
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

        //Vendor Code Setup
        public void UpdateVendorCodeSetup(bool argAns, string argPre, string argSuf, int argWidth)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                int i = 0;
                int iCount = 0;
                if (argAns == true) { i = 1; }
                string sSql = "Update VendorCodeType Set CodeType =  " + i + ",CodePrefix='" + argPre + "',Suffix='" + argSuf + "',Width=" + argWidth + " ";
                SqlCommand cmd = new SqlCommand(sSql, conn, tran);
                iCount = cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (iCount == 0)
                {                   
                    sSql = "Insert into VendorCodeType(CodeType,CodePrefix,Suffix,Width) Values(" + i + ",'" + argPre + "','" + argSuf + "'," + argWidth + ")";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
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

        public DataTable GetVendorCodeTypeSetup()
        {        
            DataTable dt = new DataTable();
            try
            {
                //select CodePrefix,CodeType,Suffix,Width,MaxNo from VM..VendorCodeType
                string sSql = "Select CodePrefix,CodeType,Suffix,Width,MaxNo from VendorCodeType";
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
               
                dt.Dispose();
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
