using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class RegisterDL
    {

        public DataTable GetRegistration(int argVendorID)
        {

            DataTable dt = null;
            try
            {
                string sSql = "Select A.RegisterId,A.RegDate,A.RegNo,V.VendorName,A.Supply,A.Contract,A.Service,A.SGradeId,B.GradeName SGrade," +
                              "A.CGradeId,C.GradeName CGrade,A.HGradeId,D.GradeName HGrade,A.SFDate,A.STDate,A.CFDate,A.CTDate,A.HFDate,A.HTDate," +
                              "A.SLifeTime,A.CLifeTime,A.HLifeTime,A.Remarks from Registration A " +
                              "Inner Join VendorMaster V on A.VendorId=V.VendorId " +
                              "Left Join GradeMaster B on A.SGradeId =B.GradeID " +
                              "Left Join GradeMaster C on A.CGradeId =C.GradeID " +
                              "Left Join GradeMaster D on A.HGradeId =D.GradeID " +
                              "Where A.VendorId = " + argVendorID;
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

        public DataTable GetRegTransLatest(int argVendorID)
        {

            DataTable dt = null;
            try
            {
                string sSql = "Select A.RegisterId,A.VendorId,A.Supply,R.RegNo,Convert(Varchar(10),R.RegDate,103) RegDate, A.Contract,A.Service,Convert(Varchar(10),A.STDate,103) STDate,Convert(Varchar(10),A.CTDate,103) CTDate,Convert(Varchar(10),A.HTDate,103) HTDate," + 
	                          "A.SLife,A.CLife,A.HLife,A.SSuspend,A.CSuspend,A.HSuspend,A.SBlackList,A.CBlackList,A.HBlackList," + 
	                          "A.SGradeId,A.CGradeId,A.HGradeID,B.GradeName SGrade,C.GradeName CGrade,D.GradeName HGrade From RegTransLatest A " + 
	                          "Inner Join dbo.Registration R on A.RegisterId = R.RegisterId " + 
	                          "Left Join dbo.GradeMaster B on A.SGradeId = B.GradeID " + 
	                          "Left Join dbo.GradeMaster C on A.CGradeId = B.GradeID " + 
	                          "Left Join dbo.GradeMaster D on A.HGradeId = B.GradeID " + 
	                          "Where A.VendorId= " + argVendorID;
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

        public int GetMaxRegTransId(int argVendorID)
        {
            int Id = 0;
            DataTable dt = null;
            try
            {
                string sSql = "Select ISNULL(MAX(RegTransID),0) MRegTransID from RegTrans Where VendorId= " + argVendorID;
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_VendorDB.Close();
                if (dt.Rows.Count > 0) { Id = Convert.ToInt32(dt.Rows[0]["MRegTransID"].ToString()); }
                dt.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return Id;
        }

        public DataSet GetRegUpdateDetails(int argVendorID)
        {

            DataSet ds = null;
            try
            {
                string sSql = "Select RegisterId,Supply,Contract,Service,STDate,SLifeTime,CTDate,CLifeTime,HTDate,HLifeTime, " +
                              "SGradeId,CGradeId,HGradeId From Registration Where VendorId= " + argVendorID;
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                ds = new DataSet();
                da.Fill(ds, "Registration");
                da.Dispose();

                sSql = "Select STDate,SLifeTime,StatusType,SGradeId From RegTrans Where VendorId= " + argVendorID + " and Supply=1 order by RegTransId Desc";
                da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                da.Fill(ds, "RegTransSup");
                da.Dispose();


                sSql = "Select CTDate,CLifeTime,StatusType,CGradeId From RegTrans Where VendorId=" + argVendorID + " and Contract=1 order by RegTransId Desc";
                da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                da.Fill(ds, "RegTransCon");
                da.Dispose();

                sSql = "Select CTDate,CLifeTime,StatusType,CGradeId From RegTrans Where VendorId=" + argVendorID + " and Service=1 order by RegTransId Desc";
                da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                da.Fill(ds, "RegTransSer");
                da.Dispose();


                BsfGlobal.g_VendorDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return ds;
        }


        public DataTable GetRegNo()
        {

            DataTable dt = null;
            try
            {
                string sSql = "SELECT A.RegisterId,A.RegNo,A.VendorId,B.VendorName from Registration A " +
	                          "Inner Join dbo.VendorMaster B on A.VendorId=B.VendorId " +
	                          "Order by A.RegDate,A.RegNo";
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

        public DataTable GetRegVendorList()
        {
            DataTable dt = null;
            try
            {
                string sSql = "Select A.VendorID,A.VendorName from dbo.VendorMaster A " +
                              "Inner Join Registration B on A.VendorId=B.VendorId " +
                              "Order by A.VendorName";
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


        public DataTable GetRegTrans(int argVendorID)
        {
            DataTable dt = null;
            try
            {
                string sSql = "Select A.RegTransId,A.VendorID,A.RegId,A.RDate,A.RefNo,V.VendorName,A.StatusType,A.Supply,A.Contract,A.Service,A.SGradeId,B.GradeName SGrade," +
                              "A.CGradeId,C.GradeName CGrade,A.HGradeId,D.GradeName HGrade,A.SFDate,A.STDate,A.CFDate,A.CTDate,A.HFDate,A.HTDate,A.SLifeTime," +
                              "A.CLifeTime,A.HLifeTime,A.Remarks from dbo.RegTrans A " +
                              "Inner Join VendorMaster V on A.VendorId=V.VendorId " +
                              "Left Join GradeMaster B on A.SGradeId =B.GradeID " +
                              "Left Join GradeMaster C on A.CGradeId =C.GradeID " +
                              "Left Join GradeMaster D on A.HGradeId =D.GradeID " +
                              "Where A.VendorId = " + argVendorID + " Order by RegTransId Desc";
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

        public bool CheckRegNo(int argRegId,string argRegNo)
        {

            DataTable dt = null;
            bool bFound = false;
            try
            {
                string sSql = "SELECT RegisterId from dbo.Registration " +
	                          "Where RegisterId <> " + argRegId + " and RegNo=' " + argRegNo + "'";
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_VendorDB.Close();
                if (dt.Rows.Count > 0) { bFound = true; }
                dt.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return bFound;
        }



        public bool CheckRegTrans(int argVendorId)
        {
            DataTable dt = null;
            bool bFound = false;
            try
            {
                string sSql = "Select RegTransId from dbo.RegTrans Where VendorId= " + argVendorId;
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                BsfGlobal.g_VendorDB.Close();
                if (dt.Rows.Count > 0) { bFound = true; }
                dt.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return bFound;
        }

        
        public DataTable GetGradeTrans(int argVendorID)
        {
            DataTable dt = null;
            try
            {
                string sSql = "Select A.SGradeId,B.GradeName SGrade,A.CGradeId,C.GradeName CGrade," +
	                          "A.HGradeId,D.GradeName HGrade from GradeTrans A " +
	                          "Left Join GradeMaster B on A.SGradeId =B.GradeID " +
	                          "Left Join GradeMaster C on A.CGradeId =C.GradeID " +
	                          "Left Join GradeMaster D on A.HGradeId =D.GradeID " +
	                          "Where A.VendorId = " + argVendorID;
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


        public DataTable GetCheckListTrans(int argVendorID)
        {

            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorId, CheckListId,RegType,Points from dbo.VendorCheckListTrans " +
	                          "Where VendorId = " + argVendorID;
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

        public void InsertCheckListTrans(Vendor.BusinessLayer.CheckListBL argCheckList)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Insert_VendorCheckListTrans", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argCheckList.VendorId);
                Command.Parameters.AddWithValue("@CheckListId", argCheckList.CheckListId);
                Command.Parameters.AddWithValue("@RegType", argCheckList.RegType);
                Command.Parameters.AddWithValue("@Points", argCheckList.Points);
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
        public void InsertAssessment(Vendor.BusinessLayer.RegisterBL argRegister)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Insert_VendorAssesment", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argRegister.VendorId);
                Command.Parameters.AddWithValue("@SupplyMaxPoint", argRegister.SupplyMaxPoint);
                Command.Parameters.AddWithValue("@SupplyPoints", argRegister.SupplyPoints);
                Command.Parameters.AddWithValue("@ContractMaxPoint", argRegister.ContractMaxPoint);
                Command.Parameters.AddWithValue("@ContractPoints", argRegister.ContractPoints);
                Command.Parameters.AddWithValue("@ServiceMaxPoint", argRegister.ServiceMaxPoint);
                Command.Parameters.AddWithValue("@ServicePoints", argRegister.ServicePoints);
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

        public void UpdateGradeTrans(Vendor.BusinessLayer.RegisterBL argRegister)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Update_GradeTrans", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argRegister.VendorId);
                Command.Parameters.AddWithValue("@SGradeId", argRegister.SGradeId);
                Command.Parameters.AddWithValue("@CGradeId", argRegister.CGradeId);
                Command.Parameters.AddWithValue("@HGradeId", argRegister.HGradeId);
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


        public void DeleteCheckListTrans(int argVendorId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_VendorCheckListTrans", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendorId);
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

        public void DeleteRegTrans(int argTransId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_RegTrans", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@RegTransId", argTransId);
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

        public void DeleteRegistration(int argRegId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_Registration", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@RegId", argRegId);
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



        public void InsertRegistration(Vendor.BusinessLayer.RegisterBL argRegister)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Insert_Registration", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@RegDate", argRegister.RegDate);
                Command.Parameters.AddWithValue("@RegNo", argRegister.RegNo);
                Command.Parameters.AddWithValue("@VendorId", argRegister.VendorId);
                Command.Parameters.AddWithValue("@Supply", argRegister.Supply);
                Command.Parameters.AddWithValue("@Contract", argRegister.Contract);
                Command.Parameters.AddWithValue("@Service", argRegister.Service);
                Command.Parameters.AddWithValue("@SGradeId", argRegister.SGradeId);
                Command.Parameters.AddWithValue("@CGradeId", argRegister.CGradeId);
                Command.Parameters.AddWithValue("@HGradeId", argRegister.HGradeId);
                Command.Parameters.AddWithValue("@SFDate", argRegister.SFDate);
                Command.Parameters.AddWithValue("@STDate", argRegister.STDate);
                Command.Parameters.AddWithValue("@CFDate", argRegister.CFDate);
                Command.Parameters.AddWithValue("@CTDate", argRegister.CTDate);
                Command.Parameters.AddWithValue("@HFDate", argRegister.HFDate);
                Command.Parameters.AddWithValue("@HTDate", argRegister.HTDate);
                Command.Parameters.AddWithValue("@SLifeTime", argRegister.SLife);
                Command.Parameters.AddWithValue("@CLifeTime", argRegister.CLife);
                Command.Parameters.AddWithValue("@HLifeTime", argRegister.HLife);
                Command.Parameters.AddWithValue("@Remarks", argRegister.Remarks);
                Command.ExecuteNonQuery();

                //Command = new SqlCommand("Update_MaxNo", conn, tran);
                //Command.CommandType = CommandType.StoredProcedure;
                //Command.Parameters.Clear();
                //Command.Parameters.AddWithValue("@TypeId", 1);
                //Command.ExecuteNonQuery();

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

        public void UpdateRegistration(Vendor.BusinessLayer.RegisterBL argRegister)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Update_Registration", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@RegisterId", argRegister.RegisterId);
                Command.Parameters.AddWithValue("@RegDate", argRegister.RegDate);
                Command.Parameters.AddWithValue("@RegNo", argRegister.RegNo);
                Command.Parameters.AddWithValue("@VendorId", argRegister.VendorId);
                Command.Parameters.AddWithValue("@Supply", argRegister.Supply);
                Command.Parameters.AddWithValue("@Contract", argRegister.Contract);
                Command.Parameters.AddWithValue("@Service", argRegister.Service);
                Command.Parameters.AddWithValue("@SGradeId", argRegister.SGradeId);
                Command.Parameters.AddWithValue("@CGradeId", argRegister.CGradeId);
                Command.Parameters.AddWithValue("@HGradeId", argRegister.HGradeId);
                Command.Parameters.AddWithValue("@SFDate", argRegister.SFDate);
                Command.Parameters.AddWithValue("@STDate", argRegister.STDate);
                Command.Parameters.AddWithValue("@CFDate", argRegister.CFDate);
                Command.Parameters.AddWithValue("@CTDate", argRegister.CTDate);
                Command.Parameters.AddWithValue("@HFDate", argRegister.HFDate);
                Command.Parameters.AddWithValue("@HTDate", argRegister.HTDate);
                Command.Parameters.AddWithValue("@SLifeTime", argRegister.SLife);
                Command.Parameters.AddWithValue("@CLifeTime", argRegister.CLife);
                Command.Parameters.AddWithValue("@HLifeTime", argRegister.HLife);
                Command.Parameters.AddWithValue("@Remarks", argRegister.Remarks);
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

        public void InsertRegTrans(Vendor.BusinessLayer.RegisterBL argRegister,int argTypeId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Insert_RegTrans", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argRegister.VendorId);
                Command.Parameters.AddWithValue("@RegId", argRegister.RegisterId);
                Command.Parameters.AddWithValue("@RDate", argRegister.RegDate);
                Command.Parameters.AddWithValue("@RefNo ", argRegister.RegNo);
                Command.Parameters.AddWithValue("@StatusType ", argRegister.StatusType);
                Command.Parameters.AddWithValue("@Supply", argRegister.Supply);
                Command.Parameters.AddWithValue("@Contract", argRegister.Contract);
                Command.Parameters.AddWithValue("@Service", argRegister.Service);
                Command.Parameters.AddWithValue("@SGradeId", argRegister.SGradeId);
                Command.Parameters.AddWithValue("@CGradeId", argRegister.CGradeId);
                Command.Parameters.AddWithValue("@HGradeId", argRegister.HGradeId);
                Command.Parameters.AddWithValue("@SFDate", argRegister.SFDate);
                Command.Parameters.AddWithValue("@STDate", argRegister.STDate);
                Command.Parameters.AddWithValue("@CFDate", argRegister.CFDate);
                Command.Parameters.AddWithValue("@CTDate", argRegister.CTDate);
                Command.Parameters.AddWithValue("@HFDate", argRegister.HFDate);
                Command.Parameters.AddWithValue("@HTDate", argRegister.HTDate);
                Command.Parameters.AddWithValue("@SLifeTime", argRegister.SLife);
                Command.Parameters.AddWithValue("@CLifeTime", argRegister.CLife);
                Command.Parameters.AddWithValue("@HLifeTime", argRegister.HLife);
                Command.Parameters.AddWithValue("@Remarks", argRegister.Remarks);
                Command.ExecuteNonQuery();

                //Command = new SqlCommand("Update_MaxNo", conn, tran);
                //Command.CommandType = CommandType.StoredProcedure;
                //Command.Parameters.Clear();
                //Command.Parameters.AddWithValue("@TypeId", argTypeId);
                //Command.ExecuteNonQuery();

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

        public void UpdateRegTrans(Vendor.BusinessLayer.RegisterBL argRegister)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Update_RegTrans", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@RegTransId", argRegister.RegTransId);
                Command.Parameters.AddWithValue("@VendorId", argRegister.VendorId);
                Command.Parameters.AddWithValue("@RegId", argRegister.VendorId);
                Command.Parameters.AddWithValue("@RDate", argRegister.RegDate);
                Command.Parameters.AddWithValue("@RefNo ", argRegister.RegNo);
                Command.Parameters.AddWithValue("@StatusType ", argRegister.StatusType);
                Command.Parameters.AddWithValue("@Supply", argRegister.Supply);
                Command.Parameters.AddWithValue("@Contract", argRegister.Contract);
                Command.Parameters.AddWithValue("@Service", argRegister.Service);
                Command.Parameters.AddWithValue("@SGradeId", argRegister.SGradeId);
                Command.Parameters.AddWithValue("@CGradeId", argRegister.CGradeId);
                Command.Parameters.AddWithValue("@HGradeId", argRegister.HGradeId);
                Command.Parameters.AddWithValue("@SFDate", argRegister.SFDate);
                Command.Parameters.AddWithValue("@STDate", argRegister.STDate);
                Command.Parameters.AddWithValue("@CFDate", argRegister.CFDate);
                Command.Parameters.AddWithValue("@CTDate", argRegister.CTDate);
                Command.Parameters.AddWithValue("@HFDate", argRegister.HFDate);
                Command.Parameters.AddWithValue("@HTDate", argRegister.HTDate);
                Command.Parameters.AddWithValue("@SLifeTime", argRegister.SLife);
                Command.Parameters.AddWithValue("@CLifeTime", argRegister.CLife);
                Command.Parameters.AddWithValue("@HLifeTime", argRegister.HLife);
                Command.Parameters.AddWithValue("@Remarks", argRegister.Remarks);
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


        public void InsertRegTransLatest(Vendor.BusinessLayer.RegUpdateBL argRegister)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Update_RegTransLatest", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@RegisterId", argRegister.RegisterId);
                Command.Parameters.AddWithValue("@VendorId", argRegister.VendorId);
                Command.Parameters.AddWithValue("@Supply", argRegister.Supply);
                Command.Parameters.AddWithValue("@Contract", argRegister.Contract);
                Command.Parameters.AddWithValue("@Service", argRegister.Service);
                Command.Parameters.AddWithValue("@STDate", argRegister.STDate);
                Command.Parameters.AddWithValue("@CTDate", argRegister.CTDate);
                Command.Parameters.AddWithValue("@HTDate", argRegister.HTDate);
                Command.Parameters.AddWithValue("@SLifeTime", argRegister.SLife);
                Command.Parameters.AddWithValue("@CLifeTime", argRegister.CLife);
                Command.Parameters.AddWithValue("@HLifeTime", argRegister.HLife);
                Command.Parameters.AddWithValue("@SSuspend", argRegister.SSuspend);
                Command.Parameters.AddWithValue("@CSuspend", argRegister.CSuspend);
                Command.Parameters.AddWithValue("@HSuspend", argRegister.HSuspend);
                Command.Parameters.AddWithValue("@SBlackList", argRegister.SBlackList);
                Command.Parameters.AddWithValue("@CBlackList", argRegister.CBlackList);
                Command.Parameters.AddWithValue("@HBlackList", argRegister.HBlackList);
                Command.Parameters.AddWithValue("@SGradeId", argRegister.SGradeId);
                Command.Parameters.AddWithValue("@CGradeId", argRegister.CGradeId);
                Command.Parameters.AddWithValue("@HGradeId", argRegister.HGradeId);
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

        public void UpdateRegistration(int argVendorId)
        {
            Vendor.BusinessLayer.RegUpdateBL oRegUpdate;
            Vendor.BusinessLayer.RegisterBL oRegister;
            oRegUpdate = new Vendor.BusinessLayer.RegUpdateBL();
            oRegister = new Vendor.BusinessLayer.RegisterBL();

            DataSet ds = new DataSet();
            ds = oRegister.GetRegUpdateDetails(argVendorId);

            DataTable dtM = new DataTable();
            DataTable dtS = new DataTable();
            DataTable dtC = new DataTable();
            DataTable dtH = new DataTable();

            dtM = ds.Tables[0];
            dtS = ds.Tables[1];
            dtC = ds.Tables[2];
            dtH = ds.Tables[3];

            if (dtM.Rows.Count > 0)
            {
                oRegUpdate.RegisterId = Convert.ToInt32(dtM.Rows[0]["RegisterId"].ToString());
                oRegUpdate.VendorId = argVendorId;

                oRegUpdate.Supply = Convert.ToBoolean(dtM.Rows[0]["Supply"].ToString());
                oRegUpdate.Contract = Convert.ToBoolean(dtM.Rows[0]["Contract"].ToString());
                oRegUpdate.Service = Convert.ToBoolean(dtM.Rows[0]["Contract"].ToString());

                oRegUpdate.STDate = Convert.ToDateTime(dtM.Rows[0]["STDate"].ToString());
                oRegUpdate.CTDate = Convert.ToDateTime(dtM.Rows[0]["HTDate"].ToString());
                oRegUpdate.HTDate = Convert.ToDateTime(dtM.Rows[0]["HTDate"].ToString());

                oRegUpdate.SLife = Convert.ToBoolean(dtM.Rows[0]["SLifeTime"].ToString());
                oRegUpdate.CLife = Convert.ToBoolean(dtM.Rows[0]["CLifeTime"].ToString());
                oRegUpdate.HLife = Convert.ToBoolean(dtM.Rows[0]["HLifeTime"].ToString());

                oRegUpdate.SGradeId = Convert.ToInt32(dtM.Rows[0]["SGradeId"].ToString());
                oRegUpdate.CGradeId = Convert.ToInt32(dtM.Rows[0]["SGradeId"].ToString());
                oRegUpdate.HGradeId = Convert.ToInt32(dtM.Rows[0]["SGradeId"].ToString());
            }

            if (dtS.Rows.Count > 0)
            {
                if (dtS.Rows[0]["StatusType"].ToString() == "R")
                {
                    oRegUpdate.Supply = true;
                    oRegUpdate.STDate = Convert.ToDateTime(dtS.Rows[0]["STDate"].ToString());
                    oRegUpdate.SLife = Convert.ToBoolean(dtS.Rows[0]["SLifeTime"].ToString());
                    oRegUpdate.SGradeId = Convert.ToInt32(dtS.Rows[0]["SGradeId"].ToString());
                }
                else if (dtS.Rows[0]["StatusType"].ToString() == "S")
                {
                    oRegUpdate.SSuspend = true;
                    oRegUpdate.STDate = Convert.ToDateTime(dtS.Rows[0]["STDate"].ToString());
                }

                else if (dtS.Rows[0]["StatusType"].ToString() == "B")
                {
                    oRegUpdate.SBlackList = true;
                }
            }

            if (dtC.Rows.Count > 0)
            {
                if (dtC.Rows[0]["StatusType"].ToString() == "R")
                {
                    oRegUpdate.Contract = true;
                    oRegUpdate.CTDate = Convert.ToDateTime(dtC.Rows[0]["CTDate"].ToString());
                    oRegUpdate.CLife = Convert.ToBoolean(dtC.Rows[0]["CLifeTime"].ToString());
                    oRegUpdate.CGradeId = Convert.ToInt32(dtC.Rows[0]["CGradeId"].ToString());
                }
                else if (dtC.Rows[0]["StatusType"].ToString() == "S")
                {
                    oRegUpdate.CSuspend = true;
                    oRegUpdate.CTDate = Convert.ToDateTime(dtC.Rows[0]["CTDate"].ToString());
                }

                else if (dtC.Rows[0]["StatusType"].ToString() == "B")
                {
                    oRegUpdate.CBlackList = true;
                }
            }

            if (dtH.Rows.Count > 0)
            {
                if (dtH.Rows[0]["StatusType"].ToString() == "R")
                {
                    oRegUpdate.Service = true;
                    //oRegUpdate.HTDate = Convert.ToDateTime(dtH.Rows[0]["HTDate"].ToString());
                    //oRegUpdate.HLife = Convert.ToBoolean(dtH.Rows[0]["HLifeTime"].ToString());
                    //oRegUpdate.HGradeId = Convert.ToInt32(dtH.Rows[0]["HGradeId"].ToString());
                }
                else if (dtH.Rows[0]["StatusType"].ToString() == "S")
                {
                    oRegUpdate.HSuspend = true;
                    //oRegUpdate.HTDate = Convert.ToDateTime(dtH.Rows[0]["HTDate"].ToString());
                }

                else if (dtH.Rows[0]["StatusType"].ToString() == "B")
                {
                    oRegUpdate.HBlackList = true;
                }
            }
            oRegister.InsertRegTransLatest(oRegUpdate);

            if (clsStatic.g_bTypeSelection == true)
            {
                bool bSupply = false;
                bool bContract = false;
                bool bService = false;

                if (oRegUpdate.Supply == true)
                {
                    if (oRegUpdate.SSuspend == true | oRegUpdate.SBlackList == true) { bSupply = false; }
                    else { bSupply = true; }
                }

                if (oRegUpdate.Contract == true)
                {
                    if (oRegUpdate.CSuspend == true | oRegUpdate.CBlackList == true) { bContract = false; }
                    else { bContract = true; }
                }

                if (oRegUpdate.Service == true)
                {
                    if (oRegUpdate.HSuspend == true | oRegUpdate.HBlackList == true) { bService = false; }
                    else { bService = true; }
                }

                UpdateVendorType(oRegUpdate.VendorId, bSupply, bContract, bService);
            }
        }


        public void UpdateVendorType(int argVendorId,bool argSupply,bool argContract,bool argService)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Update_VendorType", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendorId);
                Command.Parameters.AddWithValue("@Supply", argSupply);
                Command.Parameters.AddWithValue("@Contract", argContract);
                Command.Parameters.AddWithValue("@Service", argService);
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
        public DataTable  GetGradeName(int argVendorId, string argRegType)
        {
            DataTable dt = new DataTable();
            string sSql = "";
            SqlDataAdapter sda;
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            try
            {
                sSql = "Select Sum(Points) from VendorCheckListTrans Where VendorId=" + argVendorId + " and RegType='" + argRegType + "' ";
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() != "")
                {
                    sSql = "Select GradeId,GradeName from GradeMaster Where '" + dt.Rows[0][0].ToString() + "' Between FValue and TValue ";
                    sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                    dt = new DataTable();
                    sda.Fill(dt);
                }
                else
                {
                    dt = null;
                }

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
