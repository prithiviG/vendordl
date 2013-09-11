using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Vendor.DataLayer;

namespace Vendor.BusinessLayer
{
    class VehicleBL
    {
        #region Variables

        public static int VehicleId { get; set; }
        public static int VendorId { get; set; }
        public static decimal BlLen { get; set; }
        public static decimal BlBreadth { get; set; }
        public static decimal BlHeight { get; set; }
        public static decimal BlQty { get; set; }
        public static decimal TsMaxLen { get; set; }
        public static decimal TsMaxBredth { get; set; }
        public static decimal TsMaxHeight { get; set; }
        public static decimal TsMaxQty { get; set; }
        public static decimal TsMinLen { get; set; }
        public static decimal TsMinBredth { get; set; }
        public static decimal TsMinHeight { get; set; }
        public static decimal TsMinQty { get; set; }
        public static decimal Total1 { get; set; }
        public static decimal Total2 { get; set; }
        public static decimal NetTotal { get; set; }
        public static string Remarks { get; set; }

        #endregion

        #region Methods

        public static void InsertVehicle(int argVehId,int argVenId, string argVehNo, string argVehName)
        {
            VehicleDL.InsertVehicle(argVehId, argVenId, argVehNo, argVehName);
        }

        public static DataTable PopulateVehicle(int argVehId)
        {
            return VehicleDL.PopulateVehicle(argVehId);
        }

        public static DataTable GetVehicleRegNo(int argVenId)
        {
            return VehicleDL.GetVehicleRegNo(argVenId);
        }

        public static DataTable PopulateVehicleDetails(int argVehId)
        {
            return VehicleDL.PopulateVehicleDetails(argVehId);
        }
        public static void UpdateVehicleDetails()
        {
            VehicleDL.UpdateVehicleDetails();
        }

        #endregion
    }

}
