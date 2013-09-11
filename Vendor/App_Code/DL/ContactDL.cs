using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class ContactDL
    {
        public DataTable GetVendorContactInfo(int argVendorId)
        {

            DataTable dt = null;
            try
            {
                string sSql = "Select VendorId,CAddress,Phone1,Phone2,Fax1,Fax2,Mobile1,Mobile2,CPerson1,CPerson2," + 
	                          "CDesignation1,CDesignation2,ContactNo1,ContactNo2,Email1,Email2,WebName from VendorContact " +
                              "Where VendorId= " + argVendorId;;
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



        public void InsertVendorContact(Vendor.BusinessLayer.ContactBL argContact)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Insert_Vendor_Contact", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argContact.VendorId);
                Command.Parameters.AddWithValue("@CAddress", argContact.Address);
                Command.Parameters.AddWithValue("@Phone1", argContact.Phone1);
                Command.Parameters.AddWithValue("@Phone2", argContact.Phone2);
                Command.Parameters.AddWithValue("@Fax1", argContact.Fax1);
                Command.Parameters.AddWithValue("@Fax2", argContact.Fax2);
                Command.Parameters.AddWithValue("@Mobile1", argContact.Mobile1);
                Command.Parameters.AddWithValue("@Mobile2", argContact.Mobile2);
                Command.Parameters.AddWithValue("@CPerson1", argContact.CPerson1);
                Command.Parameters.AddWithValue("@CPerson2", argContact.CPerson2);
                Command.Parameters.AddWithValue("@CDesignation1", argContact.CDesignation1);
                Command.Parameters.AddWithValue("@CDesignation2", argContact.CDesignation2);
                Command.Parameters.AddWithValue("@ContactNo1", argContact.ContactNo1);
                Command.Parameters.AddWithValue("@ContactNo2", argContact.ContactNo2);
                Command.Parameters.AddWithValue("@Email1", argContact.Email1);
                Command.Parameters.AddWithValue("@Email2", argContact.Email2);
                Command.Parameters.AddWithValue("@WebName", argContact.Web);
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
