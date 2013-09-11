using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Vendor.BusinessLayer;

namespace Vendor.DataLayer
{
    class VehicleDL
    {
        #region Methods
        
        public DataTable GetVehicleRegNo()
        {
            SqlDataAdapter sda = null;
            DataTable dt;
            try
            {
                sda = new SqlDataAdapter("GetVehicleRegNo", BsfGlobal.OpenMMSDB());
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt = new DataTable();
                sda.Fill(dt);

            }
            catch (Exception ce)
            {

                throw ce;
            }
            finally
            {
                BsfGlobal.g_MMSDB.Close();
            }
            return dt;

        }

        public DataSet PopulateTripSheet(int vId)
        {
            String sSql;
            SqlDataAdapter sda = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                sSql = "Select * From TripSheet Where VehicleId =" + vId;
                sda = new SqlDataAdapter(sSql, BsfGlobal.OpenMMSDB());
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.Fill(ds, "Vehicle");
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                BsfGlobal.g_MMSDB.Close();
            }

        }
       
        public static void InsertVehicle(int argVehId, int argVenId, string argVehNo, string argVehName)
        {
            string sSql = "";
            SqlCommand cmd;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                if (argVehId == 0)
                    sSql = "INSERT INTO VehicleMaster (VendorId,VehicleRegNo,VehicleName) VALUES (" + argVenId + ",'" + argVehNo + "','" + argVehName + "') ";
                else
                    sSql = "UPDATE VehicleMaster Set VehicleRegNo='"+ argVehNo +"',VehicleName='"+ argVehName +"' Where VehicleId="+ argVehId +" ";

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

        public static DataTable PopulateVehicle(int argVehId)
        {
            string sSql = "";
            DataTable dt;
            SqlDataAdapter sda;

            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select VehicleRegNo,VehicleName From VehicleMaster Where VehicleId=" + argVehId + "";
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

        public static DataTable GetVehicleRegNo(int argVenId)
        {
            string sSql = "";
            SqlDataAdapter sda;
            DataTable dt;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select VehicleId,VehicleRegNo,VehicleName From VehicleMaster Where VendorId="+ argVenId +" ";
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

        public static DataTable PopulateVehicleDetails(int argVehId)
        {
            string sSql = "";
            SqlDataAdapter sda;
            DataTable dt;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select * From VehicleMaster Where VehicleId=" + argVehId + " ";
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

        public static void UpdateVehicleDetails()
        {
            string sSql = "";
            SqlCommand cmd;
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Update VehicleMaster Set BLLen='" + VehicleBL.BlLen + "',BLBreadth='" + VehicleBL.BlBreadth + "',  " +
                        "BLHeight='" + VehicleBL.BlHeight + "',BLQty='" + VehicleBL.BlQty + "',TSMaxLen='" + VehicleBL.TsMaxLen + "',TSMaxBreadth='" + VehicleBL.TsMaxBredth + "',  " +
                        "TSMaxHeight='" + VehicleBL.TsMaxHeight + "',TSMaxQty='" + VehicleBL.TsMaxQty + "',TSMinLen='" + VehicleBL.TsMinLen + "',TSMinBreadth='" + VehicleBL.TsMinBredth + "',   " +
                        "TSMinHeight='" + VehicleBL.TsMinHeight + "',TSMinQty='" + VehicleBL.TsMinQty + "',Total1='" + VehicleBL.Total1 + "',Total2='" + VehicleBL.Total2 + "',NetTotal='" + VehicleBL.NetTotal + "',Remarks='" + VehicleBL.Remarks + "'  " +
                        "WHERE VehicleId="+ VehicleBL.VehicleId +"   ";
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
        #endregion
    }
}
