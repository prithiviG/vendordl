using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Vendor.DataLayer;

namespace Vendor.BusinessLayer
{
    class CapabilityBL
    {
        Vendor.DataLayer.CapabilityDL m_oCapability;
        public int m_oVendorId = 0;

        public CapabilityBL()
        {
            m_oCapability = new Vendor.DataLayer.CapabilityDL();
        }

        public DataTable GetWorkGroup()
        {
            return m_oCapability.GetWorkGroup();
        }


        public DataTable GetTechPersons(int argVendorId)
        {
            return m_oCapability.GetTechPersons(argVendorId);
        }


        public DataTable GetTurnOver(int argVendorId)
        {
            return m_oCapability.GetTurnOver(argVendorId);
        }

        public void UpdateTurnOver(DataTable argTurnOver)
        {
            m_oCapability.UpdateTurnOver(argTurnOver,this);
        }

        public void DeleteTurnOver(int argId)
        {
            m_oCapability.DeleteTurnOver(argId);
        }
        public void UpdateTechPerson(DataTable argTechPerson)
        {
            m_oCapability.UpdateTechPerson(argTechPerson,this);
        }

        public void DeleteTechPerson(int argId)
        {
            m_oCapability.DeleteTechPerson(argId);
        }

        public DataTable GetService()
        {
            return m_oCapability.GetService();
        }
        public DataTable GetResource(int argTypeId, string argSTypeId)
        {
            return m_oCapability.GetResource(argTypeId, argSTypeId);
        }
        public DataTable GetResourceGroup(int argVendorId)
        {
            return m_oCapability.GetResourceGroup(argVendorId);
        }
        public DataTable GetManPower(int argVendorId)
        {
            return m_oCapability.GetManPower(argVendorId);
        }
        public void UpdateManPower(DataTable argManPower)
        {
            m_oCapability.UpdateManPower(argManPower);
        }
        public static void UpdateVendorResGroup(int argVendorId, DataTable argResG)
        {
            CapabilityDL.UpdateVendorResGroup(argVendorId, argResG);
        }
        public void DeleteManPower(int argId)
        {
            m_oCapability.DeleteManPower(argId);
        }
        public DataTable GetMachinery(int argVendorId)
        {
            return m_oCapability.GetMachinery(argVendorId);
        }
        public void UpdateMachinery(DataTable argMachinery)
        {
            m_oCapability.UpdateMachinery(argMachinery);
        }
        public void DeleteMachinery(int argId)
        {
            m_oCapability.DeleteMachinery(argId);
        }

        public void UpdateLocation(ArrayList argArray, int argVendorId)
        {
            m_oCapability.UpdateLocation(argArray, argVendorId);
        }

        public void UpdateTransport(ArrayList argArray, int argVendorId)
        {
            m_oCapability.UpdateTransport(argArray, argVendorId);
        }
        public DataTable GetLocation(int argVendorId)
        {
            return m_oCapability.GetLocation(argVendorId);
        }
        public DataTable GetTransport(int argVendorId)
        {
            return m_oCapability.GetTransport(argVendorId);
        }
        public DataTable GetVWorkGroup(int argVendorId)
        {
            return m_oCapability.GetVWorkGroup(argVendorId);
        }
        public void UpdateWorkGroup(ArrayList argArray, int argVendorId)
        {
            m_oCapability.UpdateWorkGroup(argArray, argVendorId);
        }

        public DataTable GetServiceTrans(int argVendorId)
        {
            return m_oCapability.GetServiceTrans(argVendorId);
        }
        public void UpdateService(ArrayList argArray, int argVendorId)
        {
            m_oCapability.UpdateService(argArray, argVendorId);
        }
        public DataTable GetCertificateTrans(int argVendorId)
        {
            return m_oCapability.GetCertificateTrans(argVendorId);
        }

        public void UpdateCertificate(ArrayList argArray, int argVendorId)
        {
            m_oCapability.UpdateCertificate(argArray, argVendorId);
        }
        public DataTable GetHireMachinery()
        {
            return m_oCapability.GetHireMachinery();
        }
        public DataTable GetHireMachineryTrans(int argVendorId)
        {
            return m_oCapability.GetHireMachineryTrans(argVendorId);
        }
        public DataTable GetActivity()
        {
            return m_oCapability.GetActivity();
        }
        public DataTable GetActivityTrans(int argVendorId)
        {
            return m_oCapability.GetActivityTrans(argVendorId);
        }
        public void UpdateHireMachinery(ArrayList argArray, int argVendorId)
        {
            m_oCapability.UpdateHireMachinery(argArray, argVendorId);
        }
        public void UpdateActivity(ArrayList argArray, int argVendorId)
        {
            m_oCapability.UpdateActivity(argArray, argVendorId);
        }
        public DataTable GetMaterialGroup()
        {
            return m_oCapability.GetMaterialGroup();
        }
        public DataTable GetMaterialGroupTrans(int argVendorId)
        {
            return m_oCapability.GetMaterialGroupTrans(argVendorId);
        }
        public DataSet GetMaterials()
        {
            return m_oCapability.GetMaterials();
        }

        public void UpdateMaterialGroupTrans(Vendor.BusinessLayer.SupplyBL argSupply)
        {
            m_oCapability.UpdateMaterialGroupTrans(argSupply);
        }
      
        public void UpdateMaterialTrans(Vendor.BusinessLayer.SupplyBL argSupply)
        {
            m_oCapability.UpdateMaterialTrans(argSupply);
        }

        public void DeleteMaterialGroupTrans(int argVendorId, int argMGroupId)
        {
            m_oCapability.DeleteMaterialGroupTrans(argVendorId, argMGroupId);
        }
        public void DeleteMaterialTrans(int argVendorId, int argMaterialId)
        {
            m_oCapability.DeleteMaterialTrans(argVendorId, argMaterialId);
        }
        public DataTable GetMaterialTrans(int argVendorId)
        {
            return m_oCapability.GetMaterialTrans(argVendorId);
        }
        public void DeleteCertifyTrans(int argVendorId, int argCerId)
        {
            m_oCapability.DeleteCertifyTrans(argVendorId, argCerId);
        }
        public DataTable PopulateMaterial(int argVendorId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt=m_oCapability.PopulateMaterial(argVendorId);
            }
            catch (Exception ce)
            {
                throw ce;
            }
            return dt;
        }
        public DataTable PopulateEnclosure(int argVendorId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = m_oCapability.PopulateEnclosure(argVendorId);
            }
            catch (Exception ce)
            {
                throw ce;
            }
            return dt;
        }
        public void DeleteEnclosure(int argVendorId, int argEncId)
        {
            try
            {
                m_oCapability.DeleteEnclosure(argVendorId, argEncId);
            }
            catch (Exception ce)
            {
                throw ce;
            }

        }
        public DataTable  PopulateMatCertificate(int argResId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = m_oCapability.PopulateMatCertificate(argResId);
            }
            catch (Exception ce)
            {
                throw ce;
            }
            return dt;
        }
        public void MatCerTransaction(int argCerId,int argResId,bool argMode)
        {
              m_oCapability.MatCertificateTransaction(argCerId,argResId,argMode);
        }

        public static DataTable GetMGroup(int argTypeId)
        {
            return CapabilityDL.GetMGroup(argTypeId);
        }
    }
}
