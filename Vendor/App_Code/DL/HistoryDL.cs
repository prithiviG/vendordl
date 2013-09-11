using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Vendor.DataLayer
{
    class HistoryDL
    {

        public DataTable GetSupplyDetails(int VenId)
        {
            SqlDataReader sda;
            SqlCommand cmd;
            DataTable dt = null;
            try
            {
                cmd = new SqlCommand("dbo.Get_SupplyDetails", BsfGlobal.OpenMMSDB());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VenId", VenId);
                sda = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(sda);
                sda.Close();
                BsfGlobal.g_MMSDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }
        public DataTable GetOrderDetails(int VenId)
        {
            SqlDataReader sda;
            SqlCommand cmd;
            DataTable dt = null;
            try
            {
                cmd = new SqlCommand("dbo.Get_OrderDetails", BsfGlobal.OpenMMSDB());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VenId", VenId);
                sda = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(sda);
                sda.Close();
                BsfGlobal.g_MMSDB.Close();
               
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }
        public DataTable GetPendingDetails(int VenId)
        {
            //SqlDataReader sda;
            //SqlCommand cmd;
            DataTable dt = null;
            try
            {
                //cmd = new SqlCommand("dbo.Get_PendingOrders", BsfGlobal.OpenMMSDB());
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@VenId", VenId);
                //cmd.Parameters.AddWithValue("@RateAnalDB", BsfGlobal.g_sRateAnalDBName);
                //sda = cmd.ExecuteReader();
                //dt = new DataTable();
                //dt.Load(sda);
                //sda.Close();
                //BsfGlobal.g_MMSDB.Close();

                string sSql = "select P.PONo,P.PoDate,C.CostCentreName,R.Resource_Name as ResourceName,U.Unit_Name as UnitName,T.PoQty as Qty,T.Rate,T.Amount,P.PORegisterId,P.CostcentreId,R.Resource_Id from PoRegister P " +
                               "Inner Join PoTrans T on P.PORegisterId=T.PORegisterId " +
                               "Left Join Costcentre C on P.CostcentreId=C.CostcentreId " +
                               "Inner Join [" + BsfGlobal.g_sRateAnalDBName + "]..Resource R on R.Resource_Id=T.ResourceId " +
                               "Inner Join [" + BsfGlobal.g_sRateAnalDBName + "]..UOM U on T.UnitId=U.Unit_ID where P.VendorId=" + VenId;

                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenMMSDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_MMSDB.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }
        public DataTable GetPendingBills(int VenId)
        {
            SqlDataReader sda;
            SqlCommand cmd;
            DataTable dt = null;
            try
            {
                cmd = new SqlCommand("dbo.Get_PendingBills", BsfGlobal.OpenMMSDB());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VenId", VenId);
                sda = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(sda);
                sda.Close();
                BsfGlobal.g_MMSDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }
        public DataTable GetRejected(int VenId)
        {
            SqlDataReader sda;
            SqlCommand cmd;
            DataTable dt = null;
            try
            {
                cmd = new SqlCommand("dbo.Get_Rejected", BsfGlobal.OpenMMSDB());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VenId", VenId);
                cmd.Parameters.AddWithValue("@RateAnalDB", BsfGlobal.g_sRateAnalDBName);
                sda = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(sda);
                sda.Close();
                BsfGlobal.g_MMSDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }
        public DataTable GetReturns(int VenId)
        {
            SqlDataReader sda;
            SqlCommand cmd;
            DataTable dt = null;
            try
            {
                cmd = new SqlCommand("dbo.Get_Return", BsfGlobal.OpenMMSDB());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VenId", VenId);
                sda = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(sda);
                sda.Close();
                BsfGlobal.g_MMSDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable GetContractWorkOrderDetails(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "select P.WONo,P.WODate,C.CostcentreName,P.NetAmount from [" + BsfGlobal.g_sWPMDBName + "].dbo.WORegister P " +
                             "Inner join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.OperationalCostCentre C on P.CostcentreId=C.CostcentreId " +
                             "Inner join [" + BsfGlobal.g_sVendorDBName + "].dbo.vendorMaster D on P.ContractorId=D.VendorId where D.Contract=1 and VendorId= " + argVendorId;
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenMMSDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_MMSDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable GetContractWorkBillDetails(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "select P.BillNo,P.Edate BillDate,C.CostcentreName,P.BillAmount from [" + BsfGlobal.g_sWPMDBName + "].dbo.BillRegister P " +
                           "Inner join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.OperationalCostCentre C on P.CostcentreId=C.CostcentreId " +
                           "Inner join [" + BsfGlobal.g_sVendorDBName + "].dbo.vendorMaster D on P.ContractorId=D.VendorId where D.Contract=1 and P.ContractorID= " + argVendorId;
               
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenMMSDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_MMSDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable GetContractWorkPendingBillDetails(int argVendorId)
        {
            DataTable dt = null;
            try
            {

                string sSql = "Select * from (Select Convert(Varchar(10),A.WODate,103) WODate,A.WONo,C.VendorName Vendor, " +
                        "D.CostCentreName CostCentre,B.Code,B.Specification Resource,  " +
                        "B.UnitId Unit,isnull(B.Qtty,0) as WOQty, SUM(ISNULL(F.Qty,0)) DPEQty,  " +
                        "SUM(isnull(H.Qty,0))BillQty,(isnull(B.Qtty,0)-(SUM(ISNULL(F.Qty,0))+SUM(isnull(H.Qty,0)))) BalanceQty,B.Rate,((isnull(B.Qtty,0)-(SUM(ISNULL(F.Qty,0))+SUM(isnull(H.Qty,0))))*B.Rate) Amount,A.CostCentreId from  [" + BsfGlobal.g_sWPMDBName + "].dbo.WORegister A " +
                        "Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.WOTrans B on A.WORegisterId=B.WORegisterId   and B.WOType In('A','L') " +
                        "Left Join [" + BsfGlobal.g_sVendorDBName + "].dbo.VendorMaster C on A.ContractorID=C.VendorId   " +
                        "Inner Join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.OperationalCostCentre D on A.CostCentreId=D.CostCentreId  " +
                        "Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.DPERegister E on A.WORegisterId=E.WORegisterId and E.ConvertBill=0 " +
                        "Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.DPETrans F on E.DPERegisterId=F.DPERegisterId  and F.BillType In('A','L') and B.Comp_ID=F.Comp_ID " +
                        "Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.BillDPETrans I on E.DPERegisterId=I.DPERegisterId   " +
                        "Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.BillRegister G on A.WORegisterId=G.WORegisterId  or (I.BillRegisterId=G.BillRegisterId) and A.CostCentreId=G.CostCentreId  " +
                        "Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.BillTrans H on G.BillRegisterID=H.BillRegisterID and H.BillType In('A','L') and B.Comp_ID=H.Comp_ID " +
                        "Where A.ContractorID=" + argVendorId + " " +
                        "group by A.WODate,A.WONo,C.VendorName, " +
                        "D.CostCentreName,B.Code,B.Specification,B.UnitId,A.CostCentreId,B.Qtty,B.Rate " +
                        "Union ALL " +
                        "Select Convert(Varchar(10),A.WODate,103) WODate,A.WONo,C.VendorName Vendor, " +
                        "D.CostCentreName CostCentre,B.Code,B.Specification Resource,  " +
                        "B.UnitId Unit,isnull(B.Qtty,0) as WOQty, SUM(ISNULL(F.Qty,0)) DPEQty ,  " +
                        "SUM(ISNULL(H.Qty,0))BillQty,(isnull(B.Qtty,0)-(SUM(ISNULL(F.Qty,0))+SUM(isnull(H.Qty,0)))) BalanceQty,B.Rate,((isnull(B.Qtty,0)-(SUM(ISNULL(F.Qty,0))+SUM(isnull(H.Qty,0))))*B.Rate) Amount,A.CostCentreId from  [" + BsfGlobal.g_sWPMDBName + "].dbo.WORegister A  " +
                        "Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.WOTrans B on A.WORegisterId=B.WORegisterId   and B.WOType In('I','S') " +
                        "Left Join [" + BsfGlobal.g_sVendorDBName + "].dbo.VendorMaster C on A.ContractorID=C.VendorId   " +
                        "Inner Join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.OperationalCostCentre D on A.CostCentreId=D.CostCentreId  " +
                        "Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.DPERegister E on A.WORegisterId=E.WORegisterId  and E.ConvertBill=0  " +
                        "Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.DPETrans F on E.DPERegisterId=F.DPERegisterId  and F.BillType In('I','S') and B.IOW_ID=F.IOW_ID " +
                        "Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.BillDPETrans I on E.DPERegisterId=I.DPERegisterId   " +
                        "Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.BillRegister G on A.WORegisterId=G.WORegisterId  or (I.BillRegisterId=G.BillRegisterId)  " +
                        " Left Join [" + BsfGlobal.g_sWPMDBName + "].dbo.BillTrans H on G.BillRegisterID=H.BillRegisterID and H.BillType In('I','S') and B.IOW_ID=H.IOW_ID " +
                        "Where A.ContractorID=" + argVendorId + " " +
                        "group by A.WODate,A.WONo,C.VendorName, " +
                        "D.CostCentreName,B.Code,B.Specification,B.UnitId,A.CostCentreId,B.Qtty,B.Rate) G where  G.Code is not null  and G.Resource is not null and G.Unit is not null and G.BalanceQty>0 ";


                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenMMSDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_MMSDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable GetServiceBillDetails(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "select P.SBNo,P.SBDate,P.BillNo,P.BillDate,C.CostcentreName,P.BillAmount,P.NettAmount from [" + BsfGlobal.g_sWPMDBName + "].dbo.SBRegister P " +
                                   "Inner join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.OperationalCostCentre C on P.CostCentreId=C.CostcentreId  " +
                                   "Inner join [" + BsfGlobal.g_sVendorDBName + "].dbo.vendorMaster D on P.ContractorId=D.VendorId where D.Service=1 and VendorId=" + argVendorId;
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenMMSDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_MMSDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable GetServiceOrderDetails(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "select P.SONo,P.SODate,P.BillNo,P.BillDate,C.CostcentreName,P.BillAmount,P.NettAmount from [" + BsfGlobal.g_sWPMDBName + "].dbo.SORegister P " +
                               "Inner join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.OperationalCostCentre C on P.CostCentreId=C.CostcentreId " +
                               "Inner join [" + BsfGlobal.g_sVendorDBName + "].dbo.vendorMaster D on P.ContractorId=D.VendorId where D.Service=1 and VendorId=" + argVendorId;
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenMMSDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_MMSDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable GetPendingMINDet(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "SELECT DCNo [MIN No],Convert(Varchar(10), DCDate,103) [MIN Date], C.SiteDCNo [Site MIN No], CC.CostCentreName CostCentre, " +
                                 "Case When A.ItemId <> 0 Then BR.ItemCode Else Resource_Code End Code, " +
                                 "Case When A.ItemId <> 0 Then BR.BrandName Else Resource_Name End Resource,B.Unit_Name Unit, A.AcceptQty MINQty,  " +
                                 "A.BillQty,A.BalQty,A.QRate Rate,A.QAmount Amount,A.RejectQty,(A.RejectQty*A.QRate) RejectAmount,C.RegisterId,C.CostCentreId ,Case When A.ItemId <> 0 Then BR.ResourceId Else Resource_ID End ResourceID  " +
                                 "FROM DCTrans A  INNER JOIN Resource_View B ON A.ResourceId=B.Resource_ID " +
                                 "INNER JOIN DCRegister C ON A.DCRegisterId=C.RegisterId And C.DCOrCSM=1 " +
                                 "INNER JOIN [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.OperationalCostCentre CC ON C.CostCentreId = CC.CostCentreId " + 
                                 "INNER JOIN Vendor_View V ON V.VendorId=C.VendorId  " +
                                 "LEFT JOIN Brand BR On A.ItemId=BR.BrandId " +
                                 "INNER JOIN [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.CostCentre CA On CC.FACostCentreId=CA.CostCentreId " +
                                 "INNER JOIN [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.CompanyMaster CM On CA.CompanyId=CM.CompanyId " +
                                 "INNER JOIN [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource_Group RG On B.Resource_Group_Id=RG.Resource_Group_Id " + 
                                 "WHERE A.BalQty>0 And V.VendorId=" + argVendorId + " And C.Approve='Y' Order By C.RegisterId "; 
          
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenMMSDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_MMSDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

    }
}
