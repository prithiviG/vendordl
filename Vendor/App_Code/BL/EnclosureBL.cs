using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.BusinessLayer
{
    class EnclosureBL
    {
        DateTime E_EncDate;
        string E_Type;
        string E_Name;
        string E_Upload;
        int E_VendorId;
        string E_Location;
        int E_EnclosureId;
        Vendor.DataLayer.EnclosureDL m_oEnclosure;

        public EnclosureBL()
        {
            m_oEnclosure = new DataLayer.EnclosureDL();
        }
        public DateTime EncDate
        {
            get { return E_EncDate; }
            set { E_EncDate = value; }
        }
          public string Type
        {
            get { return E_Type; }
            set { E_Type = value; }
        }
           public string Name
        {
            get { return E_Name; }
            set { E_Name = value; }
        }
            public string Upload
        {
            get { return E_Upload; }
            set { E_Upload = value; }
        }
         
          public int VendorId
        {
            get { return E_VendorId; }
            set { E_VendorId = value; }
        }
          public string Location
          {
              get { return E_Location; }
              set { E_Location = value; }
          }
          public int EnclosureId
          {
              get { return E_EnclosureId; }
              set { E_EnclosureId = value; }
          }
        public void InsertEnclosure()
        {
            try
            {
                m_oEnclosure.InsertEnclosure(this);
            }
            catch (Exception ce)
            {
                throw ce;
            }

        }
           public void UpdateEnclosure()
        {
            try
            {
                m_oEnclosure.UpdateEnclosure(this);
            }
            catch (Exception ce)
            {
                throw ce;
            }

        }
           public DataTable GetEncDetails(int argVendorId, int argEncId)
           {
               DataTable dt = new DataTable();
               try
               {
                   dt = m_oEnclosure.GetEncDetails(argVendorId, argEncId);
               }
               catch (Exception ce)
               {
                   throw ce;
               }
               return dt; 
           }
    }
}
