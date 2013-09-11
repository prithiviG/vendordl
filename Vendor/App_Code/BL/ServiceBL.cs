using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.BusinessLayer
{
    class ServiceBL
    {
        Vendor.DataLayer.ServiceDL oService;
        public string m_oGroupName { set; get; }
        public int m_oGroupId { set; get; }
        public ServiceBL()
        {
            oService = new DataLayer.ServiceDL();
        }

        public DataTable GetServiceMaster()
        {
            DataTable dt=new DataTable();
            
            try
            {
                dt = oService.GetServiceMaster();
         
            }
            catch (Exception ce)
            {
                throw ce;
            }
            return dt;
        }
        public DataTable GetServiceGroup()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = oService.GetServiceGroup();

            }
            catch (Exception ce)
            {
                throw ce;
            }
            return dt;
        }
        public void InsertServiceGroup(string argSGName)
        {
            try
            {
                oService.InsertServiceGroup(argSGName);
            }
            catch (Exception ce)
            {
                throw ce;
            }

        }

        public void UpdateServiceGroup(int argSGId,string argSGName)
        {
            try
            {
                oService.UpdateServiceGroup(argSGId, argSGName);
            }
            catch (Exception ce)
            {
                throw ce;
            }

        }
        public DataTable  GetUnit()
        {
            DataTable dt = new DataTable();
            try
            {
                dt=oService.GetUnit();
            }
            catch (Exception ce)
            {
                throw ce;
            }
            return dt;
        }
        public void InsertService(string argSCode,string argSName,int argSGId,int argUnitId)
        {
            try
            {
                oService.InsertService(argSCode, argSName, argSGId, argUnitId);
            }
            catch (Exception ce)
            {
                throw ce;
            }

        }

        public void UpdateService(int argSId,string argSCode, string argSName, int argSGId, int argUnitId)
        {
            try
            {
                oService.UpdateService(argSId,argSCode, argSName, argSGId, argUnitId);
            }
            catch (Exception ce)
            {
                throw ce;
            }

        }
        public DataTable GetServiceDetails(int argSId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = oService.GetServiceDetails(argSId);
            }
            catch (Exception ce)
            {
                throw ce;
            }
            return dt;
        }
  
        public bool DeleteService(int argSerId)
        {
            bool status;
            status = oService.DeleteService(argSerId);
            return status;
        }
        public bool DeleteServiceGroup(int argSerGId)
        {
            bool status;
            status = oService.DeleteServiceGroup(argSerGId);
            return status;
        }
    }
}
