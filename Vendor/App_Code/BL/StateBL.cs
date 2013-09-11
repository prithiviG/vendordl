using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Vendor.BusinessLayer
{
    class StateBL
    {

        int m_lStateId;
        String m_sStateName;
        int m_lCountryId;

        Vendor.DataLayer.StateDL m_oState;

        public StateBL()
        {
            m_oState = new Vendor.DataLayer.StateDL();
        }

        public int StateId
        {
            get { return m_lStateId; }
            set { m_lStateId = value; }
        }

        public int CountryId
        {
            get { return m_lCountryId; }
            set { m_lCountryId = value; }
        }

        public String StateName
        {
            get { return m_sStateName; }
            set { m_sStateName = value; }
        }

        public DataTable GetStateList()
        {
            return m_oState.GetStateList();
        }

        public DataTable GetStateData(int argID)
        {
            return m_oState.GetStateData(argID);
        }

        public void InsertState(Vendor.BusinessLayer.StateBL argState)
        {
            m_oState.InsertState(argState);
        }

        public void UpdateState(Vendor.BusinessLayer.StateBL argState)
        {
            m_oState.UpdateState(argState);
        }
        public bool CheckState(int argStateId)
        {
            bool status = false;
            try
            {
                status = m_oState.CheckState(argStateId);
            }
            catch (Exception ce)
            {
                throw ce;
            }
            return status;
        }
        public void DeleteState(int argStateId)
        {
            try
            {
                m_oState.DeleteState(argStateId);
            }
            catch (Exception ce)
            {
                throw ce;
            }
        }

    }
}
