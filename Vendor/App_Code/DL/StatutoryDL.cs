using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class StatutoryDL
    {
        public DataTable GetVendorStatutory(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorId,FirmType,EYear,PANNo,TANNo,CSTNo,TINNo,BankAccountNo,AccountType,BankName,BranchName,BranchCode,ServiceTaxNo,TNGSTNo,MICRCode,IFSCCode,SSIREGDNo,ServiceTaxCir,EPFNo,ESINo,ExciseVendor,ExciseRegNo,Excisedivision,ExciseRange,ECCno from VendorStatutory " +
	                          "Where VendorID = " + argVendorId;
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


        public void InsertVendorStatutory(Vendor.BusinessLayer.StatutoryBL argStatutory)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Insert_Statutory", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argStatutory.VendorId);
                Command.Parameters.AddWithValue("@FirmType", argStatutory.FirmType);
                Command.Parameters.AddWithValue("@EYear", argStatutory.EYear);
                Command.Parameters.AddWithValue("@PANNo", argStatutory.PANNo);
                Command.Parameters.AddWithValue("@TANNo", argStatutory.TANNo);
                Command.Parameters.AddWithValue("@CSTNo", argStatutory.CSTNo);
                Command.Parameters.AddWithValue("@TINNo", argStatutory.TINNo);
                Command.Parameters.AddWithValue("@BankAccountNo", argStatutory.BankAccountNo);
                Command.Parameters.AddWithValue("@AccountType", argStatutory.AccountType);
                Command.Parameters.AddWithValue("@BankName", argStatutory.BankName);
                Command.Parameters.AddWithValue("@BranchName", argStatutory.BranchName);
                Command.Parameters.AddWithValue("@BranchCode", argStatutory.BranchCode);
                Command.Parameters.AddWithValue("@ServiceTaxNo", argStatutory.ServiceTaxNo);
                Command.Parameters.AddWithValue("@TNGSTNo", argStatutory.TNGSTNo);
                Command.Parameters.AddWithValue("@MICRCode", argStatutory.MICRCode);
                Command.Parameters.AddWithValue("@IFSCCode", argStatutory.IFSCCode);

                //SSIREGDNo,ServiceTaxCir,EPFNo,ESINo,ExciseVendor,ExciseRegNo,Excisedivision,ExciseRange,ECCno
                Command.Parameters.AddWithValue("@SSIREGDNo", argStatutory.SSIREGDNo);
                Command.Parameters.AddWithValue("@ServiceTaxCir", argStatutory.ServiceTaxCir);
                Command.Parameters.AddWithValue("@EPFNo", argStatutory.EPFNo);
                Command.Parameters.AddWithValue("@ESINo", argStatutory.ESINo);
                Command.Parameters.AddWithValue("@ExciseVendor", argStatutory.ExciseVendor);
                Command.Parameters.AddWithValue("@ExciseRegNo", argStatutory.ExciseRegNo);
                Command.Parameters.AddWithValue("@Excisedivision", argStatutory.Excisedivision);
                Command.Parameters.AddWithValue("@ExciseRange", argStatutory.ExciseRange);
                Command.Parameters.AddWithValue("@ECCno", argStatutory.ECCno);
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
