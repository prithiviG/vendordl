using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace Vendor.DataLayer
{
    class CapabilityDL
    {
        public DataTable GetWorkGroup()
        {

            DataTable dt;
            try
            {
                string sSql = "Select Work_Group_Id,Work_Group_Name from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Work_Group " +
                       "Order by Work_Group_Name";
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
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

        public DataTable GetMaterialGroup()
        {

            DataTable dt;
            try
            {
                string sSql = "Select Resource_Group_ID,Resource_Group_Name from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource_Group " +
                              "Where TypeId=2 Order by Resource_Group_Name";
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



        public DataTable GetActivity()
        {
            DataTable dt;
            try
            {
                string sSql = "Select Resource_Group_ID,Resource_Group_Name from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource_Group " +
                       "Where TypeId=4 Order by Resource_Group_Name";
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
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

        public DataTable GetActivityTrans(int argVendorId)
        {
            DataTable dt;
            try
            {
                string sSql = "SELECT VendorId,Resource_Group_ID from dbo.ActivityTrans " +
                              "Where VendorId= " + argVendorId;
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
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

        public DataTable GetMaterialGroupTrans(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorId,Resource_Group_Id,Priority,SupplyType,LeadTime,CreditDays " +
                              "from MaterialGroupTrans Where VendorID= " + argVendorId;
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

        public DataTable GetMaterialTrans(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorId,Resource_Id,Priority,SupplyType,LeadTime,CreditDays from MaterialTrans " +
                              "Where VendorId= " + argVendorId;
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

        public DataTable GetHireMachineryTrans(int argVendorId)
        {

            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorId,Resource_Id from dbo.HireMachineryTrans Where VendorId=" + argVendorId;
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


        public DataTable GetHireMachinery()
        {

            DataTable dt = null;
            try
            {
                string sSql = "Select Resource_ID,Resource_Name from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource " +
                              "Where TypeId=3 Order by Resource_Name";
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

        public DataTable GetVWorkGroup(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorID,Work_Group_ID from dbo.WorkGroup Where VendorId = " + argVendorId;
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

        public DataTable GetTurnOver(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "SELECT TurnOverId,VendorId,FYear,Value from VendorTurnOver " +
                              "Where VendorId = " + argVendorId;
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

        public DataTable GetTechPersons(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "Select TechPersonId,VendorId,PersonName,Qualification,Experience,Designation from " +
                              "TechPersons Where VendorId = " + argVendorId;
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


        public DataTable GetCertificateTrans(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorId,CertificateId from CertificateTrans Where VendorId= " + argVendorId;
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



        public DataTable GetLocation(int argVendorId)
        {

            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorId,CityId from dbo.VendorLocation Where VendorId= " + argVendorId;
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

        public DataTable GetTransport(int argVendorId)
        {

            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorId,TransportId from dbo.VendorTransport Where VendorId= " + argVendorId;
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

        public DataTable GetServiceTrans(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "SELECT VendorId,ServiceId from dbo.ServiceTrans Where VendorId= " + argVendorId;
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


        public DataTable GetResource(int argTypeId, string argSTypeId)
        {
            DataTable dt = null;
            try
            {
                //string sSql = "Select A.Resource_ID,Resource_Code Code,A.Resource_Name,ISNULL(B.Unit_Name,'') Unit_Name,C.Resource_Group_Id,Convert(bit,0,1) [Select] from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource A " +
                //              "Left join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.UOM B on A.Unit_Id=B.Unit_ID " +
                //              "Inner Join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource_Group C On A.Resource_Group_Id=C.Resource_Group_Id And A.TypeId=C.TypeId " +
                //              "Where A.TypeID= " + argTypeId + " Order by Resource_Name ";

                string sSql = "Select A.Resource_ID,Resource_Code Code,A.Resource_Name,ISNULL(B.Unit_Name,'') Unit_Name,C.Resource_Group_Id,Convert(bit,0,1) [Select] from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource A " +
                              "Left join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.UOM B on A.Unit_Id=B.Unit_ID " +
                              "Inner Join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource_Group C On A.Resource_Group_Id=C.Resource_Group_Id And A.TypeId=C.TypeId ";
                if (argSTypeId != "")
                {
                    sSql = sSql + "Where A.TypeID in ( " + argSTypeId + ") Order by Resource_Name ";
                }
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

        public DataTable GetResourceGroup(int argVendorId)
        {
            DataTable dt = null;
            try
            {               
                string sSql = "select G.Resource_Group_ID,G.Resource_Group_Name,G.[Select] from " +
                    "(select A.Resource_Group_ID,A.Resource_Group_Name,Case When B.Resource_Group_ID is Null then Convert(bit,0,0) else Convert(bit,1,1) End [Select] " +
                    "from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource_Group A INNER JOIN VendorResGroupTrans B On A.Resource_Group_ID=B.Resource_Group_ID Where B.VendorId=" + argVendorId + " " +
                    "UNION ALL " +
                    "select C.Resource_Group_ID,C.Resource_Group_Name , Convert(bit,0,0) [Select] from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource_Group C " +
                    "WHere C.Resource_Group_ID not in (select Resource_Group_ID from VendorResGroupTrans Where VendorId=" + argVendorId + ") ) G " +
                    "WHere G.Resource_Group_Name<>'' Order by G.Resource_Group_Name ";
               
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

        public DataTable GetManPower(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "SELECT A.ManPowerTransId,A.Resource_ID,A.VendorId,B.Resource_Name,C.Unit_Name,A.Qty from ManPower A " +
                              "Inner Join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource B on A.Resource_ID=B.Resource_ID " +
                              "Inner join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.UOM C on B.Unit_Id=C.Unit_ID Where A.VendorId = " + argVendorId;
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

        public DataTable GetMachinery(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "SELECT A.MachineryTransId,A.Resource_ID,A.VendorId,B.Resource_Name,C.Unit_Name,A.Qty,A.Capacity from Machinery A " +
                              "Inner Join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource B on A.Resource_ID=B.Resource_ID " +
                              "Inner join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.UOM C on B.Unit_Id=C.Unit_ID Where A.VendorId = " + argVendorId;
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

        public void UpdateTurnOver(DataTable argTurnOver, Vendor.BusinessLayer.CapabilityBL oCapability)
        {

            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                DataTable dt;
                dt = new DataTable();
                dt = argTurnOver.GetChanges(DataRowState.Added);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Insert_TurnOver", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@VendorId", oCapability.m_oVendorId);
                        Command.Parameters.AddWithValue("@FYear", dt.Rows[i]["FYear"]);
                        Command.Parameters.AddWithValue("@Value", dt.Rows[i]["Value"]);
                        Command.ExecuteNonQuery();
                    }
                }

                dt = new DataTable();
                dt = argTurnOver.GetChanges(DataRowState.Modified);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Update_TurnOver", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@TurnOverId", dt.Rows[i]["TurnOverId"]);
                        Command.Parameters.AddWithValue("@VendorId", oCapability.m_oVendorId);
                        Command.Parameters.AddWithValue("@FYear", dt.Rows[i]["FYear"]);
                        Command.Parameters.AddWithValue("@Value", dt.Rows[i]["Value"]);
                        Command.ExecuteNonQuery();
                    }
                }

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

        public void DeleteTurnOver(int argId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_TurnOver", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@TurnOverId", argId);
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


        public void UpdateTechPerson(DataTable argTechPerson, Vendor.BusinessLayer.CapabilityBL oCapability)
        {

            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                DataTable dt;
                dt = new DataTable();
                dt = argTechPerson.GetChanges(DataRowState.Added);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Insert_TechPerson", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@VendorId", oCapability.m_oVendorId);
                        Command.Parameters.AddWithValue("@PersonName", dt.Rows[i]["PersonName"]);
                        Command.Parameters.AddWithValue("@Qualification", dt.Rows[i]["Qualification"]);
                        Command.Parameters.AddWithValue("@Experience", dt.Rows[i]["Experience"]);
                        Command.Parameters.AddWithValue("@Designation", dt.Rows[i]["Designation"]);
                        Command.ExecuteNonQuery();
                    }
                }

                dt = new DataTable();
                dt = argTechPerson.GetChanges(DataRowState.Modified);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Update_TechPerson", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@TechPersonId", dt.Rows[i]["TechPersonId"]);
                        Command.Parameters.AddWithValue("@VendorId", oCapability.m_oVendorId);
                        Command.Parameters.AddWithValue("@PersonName", dt.Rows[i]["PersonName"]);
                        Command.Parameters.AddWithValue("@Qualification", dt.Rows[i]["Qualification"]);
                        Command.Parameters.AddWithValue("@Experience", dt.Rows[i]["Experience"]);
                        Command.Parameters.AddWithValue("@Designation", dt.Rows[i]["Designation"]);
                        Command.ExecuteNonQuery();
                    }
                }

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

        public void UpdateManPower(DataTable argManPower)
        {

            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                DataTable dt;
                dt = new DataTable();
                dt = argManPower.GetChanges(DataRowState.Added);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Insert_ManPower", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@VendorId", dt.Rows[i]["VendorId"]);
                        Command.Parameters.AddWithValue("@Resource_Id", dt.Rows[i]["Resource_Id"]);
                        Command.Parameters.AddWithValue("@Qty", dt.Rows[i]["Qty"]);
                        Command.ExecuteNonQuery();
                    }
                }

                dt = new DataTable();
                dt = argManPower.GetChanges(DataRowState.Modified);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Update_ManPower", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@ManPowerTransId", dt.Rows[i]["ManPowerTransId"]);
                        Command.Parameters.AddWithValue("@VendorId", dt.Rows[i]["VendorId"]);
                        Command.Parameters.AddWithValue("@Resource_Id", dt.Rows[i]["Resource_Id"]);
                        Command.Parameters.AddWithValue("@Qty", dt.Rows[i]["Qty"]);
                        Command.ExecuteNonQuery();
                    }
                }

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

        public static void UpdateVendorResGroup(int argVendorId, DataTable argResG)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSql = "Delete from VendorResGroupTrans Where VendorId = " + argVendorId;
                SqlCommand cmd = new SqlCommand(sSql, conn, tran);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                DataTable dt;
                dt = new DataTable();
                dt = argResG.GetChanges(DataRowState.Added);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sSql = "Insert into VendorResGroupTrans(VendorId,Resource_Group_ID) " +
                            "Values (" + argVendorId + "," + Convert.ToInt32(clsStatic.IsNullCheck(dt.Rows[i]["Resource_Group_ID"].ToString(), clsStatic.datatypes.vartypenumeric)) + ")";
                        cmd = new SqlCommand(sSql, conn, tran);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
             
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

        public void DeleteManPower(int argId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_ManPower", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@ManPowerTransId", argId);
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


        public void UpdateMachinery(DataTable argMachinery)
        {

            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                DataTable dt;
                dt = new DataTable();
                dt = argMachinery.GetChanges(DataRowState.Added);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Insert_Machinery", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@VendorId", dt.Rows[i]["VendorId"]);
                        Command.Parameters.AddWithValue("@Resource_Id", dt.Rows[i]["Resource_Id"]);
                        Command.Parameters.AddWithValue("@Qty", dt.Rows[i]["Qty"]);
                        Command.Parameters.AddWithValue("@Capacity", dt.Rows[i]["Capacity"]);
                        Command.ExecuteNonQuery();
                    }
                }

                dt = new DataTable();
                dt = argMachinery.GetChanges(DataRowState.Modified);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand Command = new SqlCommand("Update_Machinery", conn, tran);
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@MachineryTransId", dt.Rows[i]["MachineryTransId"]);
                        Command.Parameters.AddWithValue("@VendorId", dt.Rows[i]["VendorId"]);
                        Command.Parameters.AddWithValue("@Resource_Id", dt.Rows[i]["Resource_Id"]);
                        Command.Parameters.AddWithValue("@Qty", dt.Rows[i]["Qty"]);
                        Command.Parameters.AddWithValue("@Capacity", dt.Rows[i]["Capacity"]);
                        Command.ExecuteNonQuery();
                    }
                }

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

        public void DeleteMachinery(int argId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_Machinery", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@MachineryTransId", argId);
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


        public void DeleteTechPerson(int argId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_TechPerson", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@TechPersonId", argId);
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

        public DataTable GetService()
        {
            //SqlDataReader sda;
            //SqlCommand cmd;
            DataTable dt = null;
            try
            {
                //Select ServiceId,ServiceDescription from ' + @FADB + '.dbo.Service
                //cmd = new SqlCommand("Get_Service", BsfGlobal.OpenVendorAnalDB());
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@FADB", BsfGlobal.g_sFaDBName);
                //sda = cmd.ExecuteReader();
                //dt = new DataTable();
                //dt.Load(sda);
                //sda.Close();
                //BsfGlobal.g_VendorDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public void UpdateLocation(ArrayList argArray, int argVendorId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            int lLocationId;
            try
            {
                SqlCommand Command = new SqlCommand("Delete_Location", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendorId);
                Command.ExecuteNonQuery();


                for (int i = 0; i <= argArray.Count - 1; i++)
                {
                    lLocationId = Convert.ToInt32(argArray[i].ToString());
                    Command = new SqlCommand("Insert_Location", conn, tran);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Clear();
                    Command.Parameters.AddWithValue("@VendorId", argVendorId);
                    Command.Parameters.AddWithValue("@LocationID", lLocationId);
                    Command.ExecuteNonQuery();
                }

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

        public void UpdateTransport(ArrayList argArray, int argVendorId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            int iTransportId;
            try
            {
                SqlCommand Command = new SqlCommand("Delete_Transport", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendorId);
                Command.ExecuteNonQuery();


                for (int i = 0; i <= argArray.Count - 1; i++)
                {
                    iTransportId = Convert.ToInt32(argArray[i].ToString());
                    Command = new SqlCommand("Insert_Transport", conn, tran);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Clear();
                    Command.Parameters.AddWithValue("@VendorId", argVendorId);
                    Command.Parameters.AddWithValue("@TransportId", iTransportId);
                    Command.ExecuteNonQuery();
                }

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

        public void UpdateWorkGroup(ArrayList argArray, int argVendorId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            int lWId;
            try
            {
                SqlCommand Command = new SqlCommand("Delete_WorkGroup", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendorId);
                Command.ExecuteNonQuery();


                for (int i = 0; i <= argArray.Count - 1; i++)
                {
                    lWId = Convert.ToInt32(argArray[i].ToString());
                    Command = new SqlCommand("Insert_WorkGroup", conn, tran);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Clear();
                    Command.Parameters.AddWithValue("@VendorId", argVendorId);
                    Command.Parameters.AddWithValue("@Work_Group_Id", lWId);
                    Command.ExecuteNonQuery();
                }

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


        public void UpdateService(ArrayList argArray, int argVendorId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            int lSId;
            try
            {
                SqlCommand Command = new SqlCommand("Delete_Service", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendorId);
                Command.ExecuteNonQuery();


                for (int i = 0; i <= argArray.Count - 1; i++)
                {
                    lSId = Convert.ToInt32(argArray[i].ToString());
                    Command = new SqlCommand("Insert_Service", conn, tran);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Clear();
                    Command.Parameters.AddWithValue("@VendorId", argVendorId);
                    Command.Parameters.AddWithValue("@ServiceId", lSId);
                    Command.ExecuteNonQuery();
                }

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


        public void UpdateCertificate(ArrayList argArray, int argVendorId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            int lWId;
            try
            {
                SqlCommand Command = new SqlCommand("Delete_CertificateTrans", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendorId);
                Command.ExecuteNonQuery();


                for (int i = 0; i <= argArray.Count - 1; i++)
                {
                    lWId = Convert.ToInt32(argArray[i].ToString());
                    Command = new SqlCommand("Insert_CertificateTrans", conn, tran);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Clear();
                    Command.Parameters.AddWithValue("@VendorId", argVendorId);
                    Command.Parameters.AddWithValue("@CertificateId", lWId);
                    Command.ExecuteNonQuery();
                }

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


        public void UpdateHireMachinery(ArrayList argArray, int argVendorId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            int lSId;
            try
            {
                SqlCommand Command = new SqlCommand("Delete_HireMachinery", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendorId);
                Command.ExecuteNonQuery();


                for (int i = 0; i <= argArray.Count - 1; i++)
                {
                    lSId = Convert.ToInt32(argArray[i].ToString());
                    Command = new SqlCommand("Insert_HireMachinery", conn, tran);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Clear();
                    Command.Parameters.AddWithValue("@VendorId", argVendorId);
                    Command.Parameters.AddWithValue("@Resource_Id", lSId);
                    Command.ExecuteNonQuery();
                }

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

        public void UpdateActivity(ArrayList argArray, int argVendorId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            int lSId;
            try
            {
                SqlCommand Command = new SqlCommand("Delete_Activity", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendorId);
                Command.ExecuteNonQuery();


                for (int i = 0; i <= argArray.Count - 1; i++)
                {
                    lSId = Convert.ToInt32(argArray[i].ToString());
                    Command = new SqlCommand("Insert_Activity", conn, tran);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Clear();
                    Command.Parameters.AddWithValue("@VendorId", argVendorId);
                    Command.Parameters.AddWithValue("@REsource_Group_ID", lSId);
                    Command.ExecuteNonQuery();
                }

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

        public DataSet GetMaterials()
        {
            DataSet ds = null;
            try
            {
                BsfGlobal.OpenVendorAnalDB();

                string sSql = "Select Resource_Group_ID,Resource_Group_Name from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource_Group " +
                              "Where TypeId=2 Order by Resource_Group_Name";
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                ds = new DataSet();
                da.Fill(ds, "MaterialGroup");
                da.Dispose();

                sSql = "Select R.Resource_ID,R.Resource_Name,R.Resource_Group_ID,ISNULL(M.ContactPerson,'') ContactPerson,ISNULL(M.ContactNo,'') ContactNo from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource R " +
                       "Left Join MaterialTrans M On R.Resource_ID=M.Resource_Id " +
                       "Where TypeId=2 Order by R.Resource_Name";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Material");
                da.Dispose();
                BsfGlobal.g_VendorDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return ds;
        }

        public void UpdateMaterialGroupTrans(Vendor.BusinessLayer.SupplyBL argSupply)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Insert_MaterialGroupTrans", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argSupply.VendorId);
                Command.Parameters.AddWithValue("@Resource_Group_Id", argSupply.MaterialGroupId);
                Command.Parameters.AddWithValue("@Periority", argSupply.Priority);
                Command.Parameters.AddWithValue("@SupplyType", argSupply.SupplyType);
                Command.Parameters.AddWithValue("@LeadTime", argSupply.LeadTime);
                Command.Parameters.AddWithValue("@CreditDays", argSupply.CreditDays);

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



        public void UpdateMaterialTrans(Vendor.BusinessLayer.SupplyBL argSupply)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Insert_MaterialTrans", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argSupply.VendorId);
                Command.Parameters.AddWithValue("@Resource_Id", argSupply.MaterialId);
                Command.Parameters.AddWithValue("@Periority", argSupply.Priority);
                Command.Parameters.AddWithValue("@SupplyType", argSupply.SupplyType);
                Command.Parameters.AddWithValue("@LeadTime", argSupply.LeadTime);
                Command.Parameters.AddWithValue("@CreditDays", argSupply.CreditDays);
                Command.Parameters.AddWithValue("@ContactPerson", argSupply.ContactPerson);
                Command.Parameters.AddWithValue("@ContactNo", argSupply.ContactNo);
                Command.Parameters.AddWithValue("@Email", argSupply.Email);
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

        public void DeleteMaterialGroupTrans(int argVendorId, int argMGroupId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_MaterialGroupTrans", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendorId);
                Command.Parameters.AddWithValue("@Resource_Group_Id", argMGroupId);
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

        public void DeleteMaterialTrans(int argVendorId, int argMaterialId)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Delete_MaterialTrans", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendorId);
                Command.Parameters.AddWithValue("@Resource_ID", argMaterialId);
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
        public void DeleteCertifyTrans(int argVendorId, int argCerId)
        {

            SqlConnection conn;
            conn = new SqlConnection();
            string sSql = "";
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                sSql = "Delete CertificateTrans Where VendorId=" + argVendorId + " And CertificateId=" + argCerId + " ";
                SqlCommand Command = new SqlCommand(sSql, conn, tran);
                Command.ExecuteNonQuery();
                Command.Dispose();
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
        public DataTable PopulateMaterial(int argVendorId)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select R.Resource_ID,Resource_Code Code,R.Resource_Name ResourceName,M.Priority,M.SupplyType,M.LeadTime,M.CreditDays,ISNULL(M.ContactPerson,'') ContactPerson,ISNULL(M.ContactNo,'') ContactNo,ISNULL(M.Email,'') Email from ["+ BsfGlobal.g_sRateAnalDBName +"].dbo.Resource R " +
                     "Inner Join MaterialTrans M On R.Resource_ID=M.Resource_Id  " +
                     "Where TypeId in (2,3) And M.VendorId=" + argVendorId + " Order by R.Resource_Name";
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
        public DataTable PopulateEnclosure(int argVendorId)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select EnclosureId,Date,Name,Type,Location From Enclosure Where VendorId=" + argVendorId + " ";
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
        public void DeleteEnclosure(int argVendorId, int argEncId)
        {
            SqlCommand cmd;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Delete From Enclosure Where VendorId=" + argVendorId + " And EnclosureId=" + argEncId + " ";
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

        public DataTable PopulateMatCertificate(int argResId)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                //sSql = "Select CertificateId,CertificateName,ResourceId,Remarks from MaterialCertificate Where ResourceId="+ argResId +" ";
                sSql="SELECT A.CertificateId,A.CerDescription CertificateName,CAST((CASE WHEN ISNULL(B.ResourceId,0)=0 THEN 0 ELSE 1 END) AS Bit) Sel " +
                     "FROM CertificateMaster A LEFT JOIN MaterialCertificate B ON A.CertificateId=B.CertificateId AND B.ResourceId="+ argResId +" ";
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
        public void MatCertificateTransaction(int argCerId, int argResId,bool argMode)
        {
            string sSql = "";
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                sSql = "Delete from MaterialCertificate Where CertificateId=" + argCerId + " And ResourceId=" + argResId + " ";
                cmd = new SqlCommand(sSql, conn, trans);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (argMode == true)
                {
                    sSql = "Insert Into MaterialCertificate (ResourceId,CertificateId) Values ('" + argResId + "','" + argCerId + "') ";
                    cmd = new SqlCommand(sSql, conn, trans);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                trans.Commit();
            }
            catch (Exception ce)
            {
                trans.Rollback();
                throw ce;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static DataTable GetMGroup(int argTypeId)
        {
            string sSql = "";
            SqlDataAdapter sda;
            DataTable dt;
            try
            {
                BsfGlobal.OpenRateAnalDB();
                sSql = "Select Resource_Group_Id,Resource_Group_Name from Resource_Group Where TypeId = "+ argTypeId +" Order by Resource_Group_Name";
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_RateAnalDB);
                dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
            }
            catch (Exception ce)
            {
                throw ce;
            }
            finally
            {
                BsfGlobal.g_RateAnalDB.Close();
            }
            return dt;
        }
    }
}
