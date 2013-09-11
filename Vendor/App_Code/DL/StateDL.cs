using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class StateDL
    {
        public DataTable GetStateList()
        {

            DataTable dt = null;
            try
            {
                string sSql = "Select A.StateId,A.StateName,B.CountryName,A.CountryId from StateMaster A " +
                              "Inner Join dbo.CountryMaster B on A.CountryId=B.CountryId Order by A.StateName";
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenWorkFlowDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_WorkFlowDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable GetStateData(int argID)
        {

            DataTable dt = null;
            try
            {
                string sSql = "SELECT StateName,CountryId from dbo.StateMaster Where StateID = " + argID;
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenWorkFlowDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_WorkFlowDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }


        public void InsertState(Vendor.BusinessLayer.StateBL argState)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenWorkFlowDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSql = "Insert into dbo.StateMaster(StateName,CountryID) " +
                              "Values('" + argState.StateName +"'," + argState.CountryId +")";
                SqlCommand Command = new SqlCommand(sSql, conn, tran);
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

        public void UpdateState(Vendor.BusinessLayer.StateBL argState)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenWorkFlowDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSql = "Update StateMaster Set StateName='" + argState.StateName + "',CountryId= " + argState.CountryId + " " +
                             "Where StateID = " + argState.StateId;
                SqlCommand Command = new SqlCommand(sSql, conn, tran);
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
        public bool CheckState(int argStateId)
        {
            bool status = false;
            DataTable dt;
            string sSql = "";
            SqlDataAdapter sda;
            try
            {
                BsfGlobal.OpenWorkFlowDB();
                sSql="Select StateId from CityMaster Where StateId="+ argStateId +" ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_WorkFlowDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                status = true;
            }
            catch (Exception ce)
            {
                throw ce;
            }
            finally
            {
                BsfGlobal.g_WorkFlowDB.Close();
            }
            return status;
        }

        public void DeleteState(int argStateId)
        {
            string sSql = "";
            SqlCommand cmd;
            try
            {
                BsfGlobal.OpenWorkFlowDB();
                sSql = "Delete StateMaster Where StateId="+ argStateId +" ";
                cmd = new SqlCommand(sSql, BsfGlobal.g_WorkFlowDB);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ce)
            {
                throw ce;
            }
            finally
            {
                BsfGlobal.g_WorkFlowDB.Close();
            }
        }
    }
}
