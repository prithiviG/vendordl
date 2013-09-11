using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class CountryDL
    {
        public DataTable GetCountryList()
        {
            DataTable dt = null;
            try
            {
                string sSql = "SELECT CountryId,CountryName from dbo.CountryMaster Order by CountryName";
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


        public int InsertCountry(string argCountry)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenWorkFlowDB();
            SqlTransaction tran = conn.BeginTransaction();
            int iCId = 0;
            try
            {
                string sSql = "Insert into CountryMaster(CountryName) Values('" + argCountry + "') SELECT SCOPE_IDENTITY();";
                SqlCommand Command = new SqlCommand(sSql, conn, tran);
                iCId = int.Parse(Command.ExecuteScalar().ToString());
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
            return iCId;
        }

        public void UpdateCountry(int argId, string argName)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenWorkFlowDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSql= "Update CountryMaster Set CountryName= '" + argName + "' Where CountryId = " + argId;
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

        public void DeleteCountry(int argId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenWorkFlowDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSql = "Delete from dbo.CountryMaster Where CountryId = " + argId;
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

        public bool CheckCountry(int argCId)
        {
            bool status = false;
            SqlDataAdapter sda;
            string sSql = "";
            DataTable dt;
            try
            {
                BsfGlobal.OpenWorkFlowDB();
                sSql = "Select CountryId from StateMaster Where CountryId="+ argCId +" ";
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_WorkFlowDB);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select CountryId from CityMaster Where CountryId=" + argCId + " ";
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_WorkFlowDB);
                dt = new DataTable();
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
    }
}
