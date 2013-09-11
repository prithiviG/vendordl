using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Vendor.DataLayer
{
    class CityDL
    {
        public DataTable GetCityList()
        {
            DataTable dt = null;
            try
            {
                string sSql = "Select A.CityId,A.CityName,C.StateName,B.CountryName,A.CountryId,A.StateId from CityMaster A " +
                              "Inner Join dbo.CountryMaster B on A.CountryId=B.CountryId " +
                              "Inner Join dbo.StateMaster C on A.StateId=C.StateID Order by A.CityName"; 
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

        public void InsertCity(Vendor.BusinessLayer.CityBL argCity)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenWorkFlowDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSql = "Insert into CityMaster(CityName,StateId,CountryID) " +
                              "Values('" + argCity.CityName + "'," + argCity.StateId + "," + argCity.CountryId + ")";  
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


        public void UpdateCity(Vendor.BusinessLayer.CityBL argCity)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenWorkFlowDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSql = "Update CityMaster set CityName= '" + argCity.CityName + "',StateId= " + argCity.StateId + "," +
                             "CountryId=" + argCity.CountryId + " Where CityID = " + argCity.CityId;
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

        public bool CheckCity(int argCityId)
        {
            bool status = false;
            string sSql = "";
            SqlDataAdapter sda;         
            DataTable dt;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                BsfGlobal.OpenWorkFlowDB();
                BsfGlobal.OpenRateAnalDB();
                sSql = "Select CityId from Branch Where CityId="+ argCityId +" ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select CityId from VendorLocation Where CityId="+ argCityId +" ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select CityId from VendorMaster Where CityId=" + argCityId + " ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select CityId from CompanyMaster Where CityId=" + argCityId + " ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_WorkFlowDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select CityId from CostCentre Where CityId=" + argCityId + " ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_WorkFlowDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select CityId from Users Where CityId=" + argCityId + " ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_WorkFlowDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select Location_Id from ConceptionRegister Where Location_Id=" + argCityId + " ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_RateAnalDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select Location_Id from IOW_Rate Where Location_Id=" + argCityId + " ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_RateAnalDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select Location_Id from IOW_Rate_Q Where Location_Id=" + argCityId + " ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_RateAnalDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select Location_Id from Project_List Where Location_Id=" + argCityId + " ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_RateAnalDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select Location_Id from Project_List Where Location_Id=" + argCityId + " ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_RateAnalDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select Location_Id from Resource_Rate Where Location_Id=" + argCityId + " ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_RateAnalDB);
                sda.Fill(dt);
                if (dt.Rows.Count > 0) { status = false; return status; }

                sSql = "Select Location_Id from Resource_Rate_Q Where Location_Id=" + argCityId + " ";
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_RateAnalDB);
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
                BsfGlobal.g_VendorDB.Close();
                BsfGlobal.g_WorkFlowDB.Close();
                BsfGlobal.g_RateAnalDB.Close();
            }
            return status;
        }

        public void DeleteCity(int argCityId)
        {
            SqlCommand cmd;
            string sSql = "";
            try
            {
                BsfGlobal.OpenWorkFlowDB();
                sSql = "Delete CityMaster Where CityId=" + argCityId + " ";
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
