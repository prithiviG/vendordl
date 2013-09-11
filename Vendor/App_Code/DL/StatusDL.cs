using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class StatusDL
    {
        public DataTable GetStatusRegister()
        {

            DataTable dt = null;
            try
            {
                string sSql = "Select G.RegTransID,G.VendorId,G.RDate,G.RefNo, " +
	                          "G.RegNo,G.VendorName,G.Status,G.Supply,G.Contract,G.Service from " +
	                          "(Select A.RegisterId RegTransID,A.VendorId,Convert(char(10),A.RegDate,103) as RDate,A.RegNo RefNo," + 
	                          "A.RegNo,B.VendorName,'Register' Status,A.Supply,A.Contract,A.Service " +
	                          "from dbo.Registration A Inner Join VendorMaster B on A.VendorId=B.VendorId " +
	                          "Union All " +
	                          "Select A.RegTransID,A.VendorId,Convert(char(10),A.RDate,103) as RDate,A.RefNo,C.RegNo,B.VendorName," + 
	                          "Case When A.StatusType='R' then 'Renewal' else 	Case When A.StatusType='S' then 'Suspend' else " + 
	                          "Case When A.StatusType='B' then 'BlackList' end end end Status,A.Supply,A.Contract,A.Service " +
	                          "from RegTrans A Inner Join dbo.VendorMaster B on A.VendorId=B.VendorId " +
	                          "Inner Join dbo.Registration C on A.RegId=C.RegisterId) G Order by G.RDate,G.RefNo";

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
        public void InsertStatusEntry(Vendor.BusinessLayer.StatusBL argSts)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Insert_StatusEntry", BsfGlobal.OpenVendorAnalDB());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@StatusId", argSts.StatusId);
                cmd.Parameters.AddWithValue("@VendorId", argSts.VendorId);
                cmd.Parameters.AddWithValue("@StatusType", argSts.StatusType);
                cmd.Parameters.AddWithValue("@RegType", argSts.RegType);
                cmd.Parameters.AddWithValue("@RegisterId", argSts.RegisterId);
                cmd.Parameters.AddWithValue("@RefNo", argSts.RefNo);
                cmd.Parameters.AddWithValue("@SDate", argSts.SDate);
                cmd.Parameters.AddWithValue("@ValidFrom", argSts.ValidFrom);
                cmd.Parameters.AddWithValue("@ValidTo", argSts.ValidTo);
                cmd.Parameters.AddWithValue("@LifTime", argSts.LifTime);
                cmd.Parameters.AddWithValue("@GradeId", argSts.GradeId);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void UpdateStatusEntry(Vendor.BusinessLayer.StatusBL argSts)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Update_StatusEntry", BsfGlobal.OpenVendorAnalDB());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@StatusId", argSts.StatusId);
                cmd.Parameters.AddWithValue("@VendorId", argSts.VendorId);
                cmd.Parameters.AddWithValue("@StatusType", argSts.StatusType);
                cmd.Parameters.AddWithValue("@RegType", argSts.RegType);
                cmd.Parameters.AddWithValue("@RegisterId", argSts.RegisterId);
                cmd.Parameters.AddWithValue("@RefNo", argSts.RefNo);
                cmd.Parameters.AddWithValue("@SDate", argSts.SDate);
                cmd.Parameters.AddWithValue("@ValidFrom", argSts.ValidFrom);
                cmd.Parameters.AddWithValue("@ValidTo", argSts.ValidTo);
                cmd.Parameters.AddWithValue("@LifTime", argSts.LifTime);
                cmd.Parameters.AddWithValue("@GradeId", argSts.GradeId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void DeleteStatusEntry(int StsId)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Delete_StatusEntry", BsfGlobal.OpenVendorAnalDB());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@StatusId", StsId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetVendorName()
        {

            DataTable dt = null;
            try
            {
                string sSql = "Select VendorId,VendorName from VendorMaster Order by VendorName";
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
        public DataSet GetStatusRegisterEdit(int StsId)
        {
            SqlDataAdapter sda = null;
            DataSet ds = null;
            try
            {
                sda = new SqlDataAdapter("Get_StatusRegisterEdit", BsfGlobal.OpenVendorAnalDB());
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.Clear();
                sda.SelectCommand.Parameters.AddWithValue("@StsId", StsId);
                ds = new DataSet();
                sda.Fill(ds);
                BsfGlobal.g_VendorDB.Close();
            }
            catch (Exception ce)
            {
                throw ce;
            }
            return ds;
        }
    }
}
