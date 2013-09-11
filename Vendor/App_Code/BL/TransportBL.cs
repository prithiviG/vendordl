using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Vendor.DataLayer;

namespace Vendor.BusinessLayer
{
    class TransportBL
    {
        public static DataTable PopulateTransport()
        {
            return TransportDL.PopulateTransport();
        }
        public static void TransportTransaction(int argTId,string argTName)
        {
            TransportDL.TransportTransaction(argTId, argTName);
        }
        public static bool ValidDelete(int argTId)
        {
            return TransportDL.ValidDelete(argTId);
        }
        public static void DeleteTransport(int argTId)
        {
            TransportDL.DeleteTransport(argTId);
        }

        public static DataTable GetTransport()
        {
            return TransportDL.GetTransport();
        }
        public static DataTable GetVendorTransport(int argVId)
        {
            return TransportDL.GetVendorTransport(argVId);
        }
    }
}
