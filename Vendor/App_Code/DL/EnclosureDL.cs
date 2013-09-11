using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class EnclosureDL
    {
        public void InsertEnclosure(Vendor.BusinessLayer.EnclosureBL m_oEnclosure)
        {
            string sSql = "";
            SqlCommand cmd;
            string argDate = String.Format("{0:dd-MMM-yyyy}", m_oEnclosure.EncDate);
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Insert Into Enclosure (VendorId,Location,Date,Name,Type) Values " +
                       "("+ m_oEnclosure.VendorId +",'"+ m_oEnclosure.Location +"', '"+ argDate +"',  " +
                       "  '"+ m_oEnclosure.Name +"','"+ m_oEnclosure.Type +"') ";
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
        public void UpdateEnclosure(Vendor.BusinessLayer.EnclosureBL m_oEnclosure)
        {
            string sSql = "";
            SqlCommand cmd;
            string argDate = String.Format("{0:dd-MMM-yyyy}", m_oEnclosure.EncDate);
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Update Enclosure Set VendorId="+ m_oEnclosure.VendorId +",Location='"+ m_oEnclosure.Location +"', " +
                       " Date='" + argDate + "',Name='" + m_oEnclosure.Name + "',Type='" + m_oEnclosure.Type + "' Where EnclosureId=" + m_oEnclosure.EnclosureId + " ";
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
        public DataTable GetEncDetails(int argVendorId, int argEncId)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select Location,Convert(Varchar(10),Date,103) Date,Name,Type From Enclosure Where VendorId="+ argVendorId +" and EnclosureId="+ argEncId +" ";
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
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
