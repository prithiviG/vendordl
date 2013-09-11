using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class ServiceDL
    {
        public DataTable GetServiceMaster()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select A.ServiceId,A.ServiceCode Code,A.ServiceName Name,B.ServiceGroupName GroupName,C.Unit_Name Unit from ServiceMaster A  " +
                       "Inner Join ServiceGroup B On A.ServiceGroupId=B.ServiceGroupId  " +
                       "Inner Join [" + BsfGlobal.g_sRateAnalDBName + "]..UOM C On A.UnitId=C.Unit_ID ";
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

        public DataTable GetServiceGroup()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select ServiceGroupId,ServiceGroupName from ServiceGroup ";
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

        public void InsertServiceGroup(string argSGName)
        {
            SqlCommand cmd;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Insert Into ServiceGroup (ServiceGroupName) Values ('" + argSGName + "') ";
                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ce)
            {
                throw ce;
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
        }



        public void UpdateServiceGroup(int argSGId,string argSGName)
        {
            SqlCommand cmd;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Update ServiceGroup Set ServiceGroupName='"+ argSGName +"' Where ServiceGroupId="+ argSGId +" ";
                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ce)
            {
                throw ce;
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
        }
        public DataTable GetUnit()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select * from ["+ BsfGlobal.g_sRateAnalDBName +"]..UOM";
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

        public void InsertService(string argSCode, string argSName, int argSGId, int argUnitId)
        {
            SqlCommand cmd;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Insert Into ServiceMaster (ServiceCode,ServiceName,ServiceGroupId,UnitId) Values ('" + argSCode + "','" + argSName + "'," + argSGId + "," + argUnitId + ") ";
                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ce)
            {
                throw ce;
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
        }



        public void UpdateService(int argSId, string argSCode, string argSName, int argSGId, int argUnitId)
        {
            SqlCommand cmd;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Update ServiceMaster Set ServiceCode='" + argSCode + "',ServiceName='" + argSName + "',ServiceGroupId=" + argSGId + ",UnitId=" + argUnitId + " Where ServiceId=" + argSId + " ";
                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ce)
            {
                throw ce;
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
        }

        public DataTable GetServiceDetails(int argSId)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select ServiceCode,ServiceName,ServiceGroupId,UnitId From ServiceMaster Where ServiceId =" + argSId + " ";
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
        public bool DeleteService(int argSerId)
        {

            string sSql = "";
            DataTable dt;
            SqlCommand cmd;
            SqlDataAdapter sda;
            bool status = false;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select ServiceId From ServiceTrans Where ServiceId=" + argSerId + " ";
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
                if (dt.Rows.Count > 0) { status = false; }
                else
                {
                    status = true;
                    sSql = "Delete From ServiceMaster Where ServiceId=" + argSerId + " ";
                    cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (Exception ce)
            {
                throw ce;

            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return status;
        }
        public bool DeleteServiceGroup(int argSerGId)
        {

            string sSql = "";
            DataTable dt;
            SqlCommand cmd;
            SqlDataAdapter sda;
            bool status = false;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select ServiceGroupId From ServiceMaster Where ServiceGroupId=" + argSerGId + " ";
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
                if (dt.Rows.Count > 0) { status = false; }
                else
                {
                    status = true;
                    sSql = "Delete From ServiceGroup Where ServiceGroupId=" + argSerGId + " ";
                    cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (Exception ce)
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
