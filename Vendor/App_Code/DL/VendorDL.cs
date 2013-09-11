using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Vendor.DataLayer
{
    class VendorDL
    {

        public DataSet GetVendorInfo(int argVendorId)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da;
                BsfGlobal.OpenVendorAnalDB();

                string sSql = "Select A.CityId,A.CityName,C.StateName,B.CountryName,A.CountryId,A.StateId from [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.CityMaster A " +
                              "Inner Join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.CountryMaster B on A.CountryId=B.CountryId " +
                              "Inner Join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.StateMaster C on A.StateId=C.StateID Order by A.CityName";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "CityList");
                da.Dispose();

                sSql = "Select VendorId,VendorName,Supply,Contract,Service,RegAddress,CityId,PinCode,ServiceTypeId,Company,SupplyType,ChequeNo,Code From VendorMaster " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Vendor_MasterInfo");
                da.Dispose();

                sSql = "Select VendorId,CAddress,Phone1,Phone2,Fax1,Fax2,Mobile1,Mobile2,CPerson1,CPerson2," + 
	                   "CDesignation1,CDesignation2,ContactNo1,ContactNo2,Email1,Email2,WebName from VendorContact " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "VendorContactInfo");
                da.Dispose();


                sSql = "Select VendorId,FirmType,EYear,PANNo,TANNo,CSTNo,TINNo,BankAccountNo,AccountType,BankName,BranchName,BranchCode,ServiceTaxNo,TNGSTNo,MICRCode,IFSCCode,SSIREGDNo,ServiceTaxCir,EPFNo,ESINo,ExciseVendor,ExciseRegNo,Excisedivision,ExciseRange,ECCno from VendorStatutory " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Statutory");
                da.Dispose();


                sSql = "SELECT TurnOverId,VendorId,FYear,Value from dbo.VendorTurnOver " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "TurnOver");
                da.Dispose();

                sSql = "Select A.BranchId,A.VendorId,A.BranchName,A.Address,B.CityName,A.TINNo,A.CityId,A.Phone,A.ChequeNo from Branch A " +
                       "Left Join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.CityMaster B on A.CityId=B.CityId " +
                       "Where A.VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "BranchList");
                da.Dispose();


                sSql = "Select ExperienceId,VendorId,WorkDescription,ClientName,Value,Period,Type " +
	                   "from VendorExperience Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Experience");
                da.Dispose();

                sSql = "Select TechPersonId,VendorId,PersonName,Qualification,Experience,Designation from " +
	                   "TechPersons Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "TechPersons");
                da.Dispose();


                sSql = "SELECT VendorId,CreditDays,MaxLeadTime,TermsAndCondition from VendorTerms " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "VendorTerms");
                da.Dispose();


                sSql = "Select Work_Group_Id,Work_Group_Name from [" + BsfGlobal.g_sRateAnalDBName  + "].dbo.Work_Group " +
                       "Order by Work_Group_Name";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Work_Group");
                da.Dispose();

                sSql = "SELECT A.ManPowerTransId,A.Resource_ID,A.VendorId,B.Resource_Name,C.Unit_Name,A.Qty from ManPower A " +
                       "Inner Join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource B on A.Resource_ID=B.Resource_ID " +
                       "Inner join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.UOM C on B.Unit_Id=C.Unit_ID Where A.VendorId = " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "ManPower");
                da.Dispose();

                sSql = "SELECT A.MachineryTransId,A.Resource_ID,A.VendorId,B.Resource_Name,C.Unit_Name,A.Qty,A.Capacity from Machinery A " +
			           "Inner Join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource B on A.Resource_ID=B.Resource_ID " +
	                   "Inner join [" + BsfGlobal.g_sRateAnalDBName + "].dbo.UOM C on B.Unit_Id=C.Unit_ID Where A.VendorId = " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Machinery");
                da.Dispose();

                sSql = "SELECT VendorId,CityId from VendorLocation " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Location");
                da.Dispose();


                sSql = "SELECT VendorID,Work_Group_ID from WorkGroup " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "VWorkGroup");
                da.Dispose();


                sSql = "SELECT VendorId,ServiceId from ServiceTrans " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "ServiceTrans");
                da.Dispose();


                sSql = "SELECT CertificateId,CerDescription,Date,Type,UpLoad from CertificateMaster";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "CertificateMaster");
                da.Dispose();

                sSql = "SELECT VendorId,CertificateId from CertificateTrans " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "CertificateTrans");
                da.Dispose();

                sSql = "Select Resource_Group_ID,Resource_Group_Name from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource_Group " +
	                   "Where TypeId=4 Order by Resource_Group_Name";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Activity");
                da.Dispose();

                sSql = "SELECT VendorId,Resource_Group_ID from ActivityTrans " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "ActivityTrans");
                da.Dispose();

                sSql = "Select Resource_ID,Resource_Name from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource " +
	                   "Where TypeId=3 Order by Resource_Name";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "HireMachinery");
                da.Dispose();

                sSql = "SELECT VendorId,Resource_Id from HireMachineryTrans " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "HireMachineryTrans");
                da.Dispose();

                sSql = "SELECT VendorId,Resource_Group_Id,Priority,SupplyType,LeadTime,CreditDays from MaterialGroupTrans " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "MaterialGroupTrans");
                da.Dispose();

                sSql = "SELECT VendorId,Resource_Id,Priority,SupplyType,LeadTime,CreditDays,ContactPerson,ContactNo from MaterialTrans " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "MaterialTrans");
                da.Dispose();

                sSql = "SELECT VendorId,TransportArrange,TransportMode,Delivery,Insurance,Unload from Logistics " +
                       "Where VendorId= " + argVendorId;
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Logistics");
                da.Dispose();


                sSql = "SELECT Distinct TransportMode from Logistics";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "TransportMode");
                da.Dispose();

                sSql = "Select ServiceId,ServiceName From ServiceMaster  ";                      
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Service");
                da.Dispose();

                sSql = "Select ServiceTypeId,ServiceType From ServiceType ";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "ServiceType");
                da.Dispose();

                sSql = "Select TransportId,TransportName From TransportMaster ";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Transport");
                da.Dispose();

                sSql = "Select B.VendorId,A.TransportId,A.TransportName From TransportMaster A " +
                       "Inner Join VendorTransport B On A.TransportId=B.TransportId Where B.VendorId=" + argVendorId + " ";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "VendorTransport");
                da.Dispose();
            }
            catch (Exception ce)
            {

                throw ce;
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return ds;

        }

        public DataSet GetFilterInfo()
        {



            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da;
                BsfGlobal.OpenVendorAnalDB();

                string sSql = "Select A.CityId,A.CityName,C.StateName,B.CountryName,A.CountryId,A.StateId from [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.CityMaster A " +
                              "Inner Join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.CountryMaster B on A.CountryId=B.CountryId " +
                              "Inner Join [" + BsfGlobal.g_sWorkFlowDBName + "].dbo.StateMaster C on A.StateId=C.StateID Order by A.CityName";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "CityList");
                da.Dispose();

                sSql = "SELECT CertificateId,CerDescription from CertificateMaster";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "CertificateMaster");
                da.Dispose();

                sSql = "Select Resource_ID,Resource_Name,Resource_Group_ID from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource " +
	                   "Where TypeId=2 Order by Resource_Name";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Material");
                da.Dispose();


                sSql = "Select Resource_Group_ID,Resource_Group_Name from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource_Group " +
                       "Where TypeId=2 Order by Resource_Group_Name";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "MaterialGroup");
                da.Dispose();


                sSql = "Select Work_Group_Id,Work_Group_Name from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Work_Group " +
                       "Order by Work_Group_Name";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Work_Group");
                da.Dispose();

                sSql = "Select Resource_Group_ID,Resource_Group_Name from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource_Group " +
                       "Where TypeId=4 Order by Resource_Group_Name";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Activity");
                da.Dispose();

                sSql = "Select Resource_ID,Resource_Name from [" + BsfGlobal.g_sRateAnalDBName + "].dbo.Resource " +
                       "Where TypeId=3 Order by Resource_Name";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "HireMachinery");
                da.Dispose();

                sSql = "SELECT GradeId,GradeName,FValue,TValue from dbo.GradeMaster	Order by FValue";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Grade");
                da.Dispose();

                sSql = "Select ServiceId,ServiceName From ServiceMaster  ";
                da = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
                da.Fill(ds, "Service");
                da.Dispose();
            }
            catch (Exception ce)
            {

                throw ce;
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return ds;
        }

        public DataTable GetVendorList()
        {

            DataTable dt = null;
            try
            {
                string sSql = "Select VendorId,VendorName,Supply,Contract,Service from VendorMaster Order by VendorName";
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
      
        public DataTable GetVendorMasterInfo(int argVendorId)
        {
            DataTable dt = null;
            try
            {
                string sSql = "Select VendorId,VendorName,Supply,Contract,Service,RegAddress,CityId,PinCode,ChequeNo,Code From VendorMaster " +
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

        public bool CheckVendorName(int argVendorId, string argVendorName)
        {
            bool bans = false;


            try
            {
                string sSql = "Select VendorId from VendorMaster Where VendorID<> " + argVendorId + " and VendorName = '" + argVendorName + "'";
                SqlDataAdapter da = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                if (dt.Rows.Count > 0) { bans = true; }
                dt.Dispose();
                BsfGlobal.g_VendorDB.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return bans;
        }

        public int InsertVendorMaster(Vendor.BusinessLayer.VendorBL argVendor)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            int iCId = 0;
            try
            {
                SqlCommand Command = new SqlCommand("Insert_VendorMaster", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendor.VendorId);
                Command.Parameters["@VendorId"].Direction = ParameterDirection.Output;
                Command.Parameters.AddWithValue("@VendorName", argVendor.VendorName);
                Command.Parameters.AddWithValue("@Supply", argVendor.Supply);
                Command.Parameters.AddWithValue("@Contract", argVendor.Contract);
                Command.Parameters.AddWithValue("@Service", argVendor.Service);
                Command.Parameters.AddWithValue("@Address", argVendor.RegAddress);
                Command.Parameters.AddWithValue("@CityId", argVendor.CityId);
                Command.Parameters.AddWithValue("@Pin", argVendor.PinNo);
                Command.Parameters.AddWithValue("@STypeId", argVendor.STypeId);
                Command.Parameters.AddWithValue("@Company", argVendor.iCompany);
                Command.Parameters.AddWithValue("@SuppTypeId", argVendor.SuppTypeId);
                Command.Parameters.AddWithValue("@ChequeNo", argVendor.ChequeNo);
                Command.Parameters.AddWithValue("@Code", argVendor.Code);
                Command.ExecuteNonQuery();
                iCId = (int)Command.Parameters["@VendorId"].Value;
                tran.Commit();
                if (BsfGlobal.g_bVendorDB == true) { BsfGlobal.RefreshSubLedger(1); }
                
                
            }
            catch
            {
                tran.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return iCId;
        }

        public void UpdateVendorMaster(Vendor.BusinessLayer.VendorBL argVendor)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                SqlCommand Command = new SqlCommand("Update_VendorMaster", conn, tran);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@VendorId", argVendor.VendorId);
                Command.Parameters.AddWithValue("@VendorName", argVendor.VendorName);
                Command.Parameters.AddWithValue("@Supply", argVendor.Supply);
                Command.Parameters.AddWithValue("@Contract", argVendor.Contract);
                Command.Parameters.AddWithValue("@Service", argVendor.Service);
                Command.Parameters.AddWithValue("@Address", argVendor.RegAddress);
                Command.Parameters.AddWithValue("@CityId", argVendor.CityId);
                Command.Parameters.AddWithValue("@Pin", argVendor.PinNo);
                Command.Parameters.AddWithValue("@STypeId", argVendor.STypeId);
                Command.Parameters.AddWithValue("@Company", argVendor.iCompany);
                Command.Parameters.AddWithValue("@SuppTypeId", argVendor.SuppTypeId);
                Command.Parameters.AddWithValue("@ChequeNo", argVendor.ChequeNo);
                Command.Parameters.AddWithValue("@Code", argVendor.Code);
                Command.ExecuteNonQuery();
                tran.Commit();
                if (BsfGlobal.g_bFADB == true) { BsfGlobal.RefreshSubLedger(1); }
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

        public void InsertVendorTemp(string sSql)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            SqlDataAdapter sda;
            DataTable dt;
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            string sTSql = "";
            try
            {
                sTSql = "Truncate Table TmpVendor";
                SqlCommand cmd = new SqlCommand(sTSql, conn, tran);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                dt = new DataTable();
                sda = new SqlDataAdapter(sSql, BsfGlobal.OpenVendorAnalDB());
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sTSql="Insert Into TmpVendor (VendorId) Values ("+ Convert.ToInt16(dt.Rows[i]["VendorId"]) +")";
                        cmd = new SqlCommand(sTSql, conn, tran);
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
                BsfGlobal.g_VendorDB.Close();
            }
        }

        public DataTable GetValidToDate(int argVenId)
        {
            DataTable dt;
            SqlDataAdapter sda;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select Convert(Varchar(10),STDate,103) STDate,Convert(Varchar(10),CTDate,103) CTDate,Convert(Varchar(10),HTDate,103) HTDate from Registration Where VendorId="+ argVenId +" ";
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
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
                BsfGlobal.g_VendorDB.Close();
            }
            return dt;

        }

        public DataTable GetVendorGeneralInfo(int argVenId)
        {
            DataTable dt;
            SqlDataAdapter sda;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select V.VendorId,V.VendorName,V.Supply,V.Contract,V.Service,V.RegAddress,C.CityName,S.StateName,CM.CountryName,V.PinCode,V.ServiceTypeId,VC.Phone1,VC.Phone2,Fax1,Fax2,Email1,Email2,WebName,Mobile1,Mobile2, " +
                        "CPerson1,CDesignation1,ContactNo1,CPerson2,CDesignation2,ContactNo2,V.Code From VendorMaster V " +
                        "Left Join ["+ BsfGlobal.g_sWorkFlowDBName +"]..CityMaster C On V.CityId=C.CityId  " +
                        "Left Join [" + BsfGlobal.g_sWorkFlowDBName + "]..StateMaster S On C.StateId=S.StateId " +
                        "Left Join [" + BsfGlobal.g_sWorkFlowDBName + "]..CountryMaster CM On C.CountryId=CM.CountryId " +
                        "Left Join VendorContact VC On V.VendorId=VC.VendorId " +
                        "Where V.VendorId="+ argVenId +" ";
                dt = new DataTable();
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

        public static DataTable PopulateSType()
        {
            DataTable dt;
            SqlDataAdapter sda;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                sSql = "Select ServiceTypeId,ServiceType From ServiceType ";
                dt = new DataTable();
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

        public static bool IsValidName(string argName)
        {
            SqlCommand cmd;
            SqlDataReader sdr;
            string sSql = "";
            DataTable dt = new DataTable();
            bool bReturn = true;
            string argCName = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                argCName = clsStatic.Insert_SingleQuot(argName);
                sSql = "Select VendorName From VendorMaster Where VendorName='" + argCName + "'";
                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                dt = new DataTable();
                sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                sdr.Dispose();
                if (dt.Rows.Count > 0) bReturn = false; else bReturn = true;
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return bReturn;
        }

        public static void ImportTransaction(string argVName, string argVAddress, string argContact, string argEmail, string argCST, string argTNGST, string argTIN, string argPAN,int argSupply,int argContract,int argService)
        {
            SqlConnection conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            string sSql = "";
            SqlCommand cmd;
            int iVendorId = 0;
            try
            {
                sSql = "Insert Into VendorMaster (VendorName,RegAddress,Supply,Contract,Service) Values ('" + clsStatic.Insert_SingleQuot(argVName) + "','" + clsStatic.Insert_SingleQuot(argVAddress) + "'," + argSupply + "," + argContract + "," + argService + ") SELECT SCOPE_IDENTITY();  ";
                cmd = new SqlCommand(sSql, conn, tran);
                iVendorId = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();

                if (iVendorId > 0)
                {
                    sSql = "Insert Into VendorContact (VendorId,ContactNo1,Email1) Values ("+ iVendorId +",'"+ argContact +"','"+ argEmail +"') ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql = "Insert Into VendorStatutory (VendorId,CSTNo,TNGSTNo,TINNo,PANNo) Values (" + iVendorId + ",'" + argCST + "','" + argTNGST + "','" + argTIN + "','" + argPAN + "') ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                conn.Close();
                tran.Dispose();
            }
        }

        public static void DeleteVendorDetailsWithoutMaster()
        {
            SqlConnection conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            string sSql = "";
            SqlCommand cmd;
            try
            {
                    sSql = "Delete from ActivityTrans Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from Branch Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from CertificateTrans Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from CompQual Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from GradeTrans Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from HireMachineryTrans Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from Logistics Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from Machinery Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from Machinery Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from MaterialGroupTrans Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from MaterialTrans Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from Registration Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from RegTrans Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from RegTransLatest Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from ServiceTrans Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from TechPersons Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from VendorAssesment Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from VendorCheckListTrans Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from VendorContact Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from VendorExperience Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from VendorLocation Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from VendorStatutory Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from VendorTerms Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from VendorTransport Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from VendorTurnOver Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql= "Delete from WorkGroup Where VendorId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();

                    sSql = "Delete from ["+ BsfGlobal.g_sFaDBName +"].dbo.SubledgerMaster Where SubLedgerTypeId=1 and RefId not in(Select VendorId from VendorMaster) ";
                    cmd = new SqlCommand(sSql, conn, tran);
                    cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                conn.Close();
                tran.Dispose();
            }
        }

        public static DataTable PopulateVendorDetList(int argVendorID, string argSuppType, string argListVendorId)
        {
            DataTable dt;
            SqlDataAdapter sda;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                if(argSuppType=="M")
                {
                    sSql = "Select VendorId,VendorName,Convert(bit,0,0) Sel from VendorMaster where VendorId <> " + argVendorID + " " +
                            " and VendorId Not in (select SupplierVendorId from VendorSupplierDet Where SupplierType in ('D' ,'S') and VendorId =" + argVendorID + " )";
                    if (argListVendorId != "")
                    {
                        sSql = sSql + " and VendorId Not in (" + argListVendorId + ")";
                    }
                }
                else if (argSuppType == "D")
                {
                    sSql = "Select VendorId,VendorName,Convert(bit,0,0) Sel from VendorMaster where VendorId <> " + argVendorID + " " +
                            " and VendorId Not in (select SupplierVendorId from VendorSupplierDet Where SupplierType in ('M' ,'S') and VendorId =" + argVendorID + " )";
                    if (argListVendorId != "")
                    {
                        sSql = sSql + " and VendorId Not in (" + argListVendorId + ")";
                    }
                }
                else if (argSuppType == "S")
                {
                    sSql = "Select VendorId,VendorName,Convert(bit,0,0) Sel from VendorMaster where VendorId <> " + argVendorID + " " +
                            " and VendorId Not in (select SupplierVendorId from VendorSupplierDet Where SupplierType in ('D' ,'M') and VendorId =" + argVendorID + ")";
                    if (argListVendorId != "")
                    {
                        sSql = sSql + " and VendorId Not in (" + argListVendorId + ")";
                    }
                }
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
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
                BsfGlobal.g_VendorDB.Close();
            }
            return dt;

        }

        public static DataTable FillSuppVendorDetList(int argVendorID, string argSuppType)
        {
            DataTable dt;
            SqlDataAdapter sda;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                if (argSuppType == "M")
                {
                    sSql = "select A.SupplierVendorId,A.VendorId,B.VendorName from VendorSupplierDet A " +
                        "inner join VendorMaster B On A.SupplierVendorId=B.VendorId Where A.VendorId=" + argVendorID + " and A.SupplierType='" + argSuppType + "'";
                    
                }
                else if (argSuppType == "D")
                {
                    sSql = "select A.SupplierVendorId,A.VendorId,B.VendorName from VendorSupplierDet A " +
                         "inner join VendorMaster B On A.SupplierVendorId=B.VendorId Where A.VendorId=" + argVendorID + " and A.SupplierType='" + argSuppType + "'";
                    
                }
                else if (argSuppType == "S")
                {
                    sSql = "select A.SupplierVendorId,A.VendorId,B.VendorName from VendorSupplierDet A " +
                        "inner join VendorMaster B On A.SupplierVendorId=B.VendorId Where A.VendorId=" + argVendorID + " and A.SupplierType='" + argSuppType + "'";
                   
                }
                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
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
                BsfGlobal.g_VendorDB.Close();
            }
            return dt;

        }

        public static void InsertVendorSupplierDet(int argVendorID, string argSuppType, DataTable dtList)
        {
            string sSql = "";
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd;
            conn = BsfGlobal.OpenVendorAnalDB();
            using (SqlTransaction tran = conn.BeginTransaction())
            {
                
                try
                {

                    if (dtList.Rows.Count > 0)
                    {
                        for (int k = 0; k < dtList.Rows.Count; k++)
                        {
                            sSql = String.Format("INSERT INTO VendorSupplierDet(VendorId,SupplierType,SupplierVendorId) values({0},'{1}',{2})", argVendorID, argSuppType, dtList.Rows[k]["VendorId"]);
                            cmd = new SqlCommand(sSql, conn, tran);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    BsfGlobal.CustomException(ex.Message, ex.StackTrace);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public static bool DelVendorSupplierDet(int argVendorID, int argSuppVenID, string argSuppType)
        {
            bool bSuccess = false;
            SqlConnection conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            string sSql = "";
            SqlCommand cmd;
            try
            {
                sSql = "Delete from VendorSupplierDet Where VendorId=" + argVendorID + " and SupplierVendorId=" + argSuppVenID + " and SupplierType='" + argSuppType + "' ";
                cmd = new SqlCommand(sSql, conn, tran);
                cmd.ExecuteNonQuery();

                tran.Commit();
                bSuccess = true;
               
            }
            catch (Exception ex)
            {
                tran.Rollback();
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                conn.Close();
                tran.Dispose();
            }
            return bSuccess;
        }

        public static bool IsChkSupplierValid(int argVendorID, string argType)
        {
            SqlCommand cmd;
            SqlDataReader sdr;
            string sSql = "";
            DataTable dt = new DataTable();
            bool bReturn = false;
            
            try
            {
                BsfGlobal.OpenVendorAnalDB();
                              
                if (argType == "M")
                {
                    sSql = "select VendorId from VendorSupplierDet Where VendorId=" + argVendorID + " and SupplierType in ('D' ,'S')";                   
                }
                else if (argType == "D")
                {
                    sSql = "select VendorId from VendorSupplierDet Where VendorId=" + argVendorID + " and  SupplierType in ('M' ,'S')";                 
                }
                else if (argType == "S")
                {
                    sSql = "select VendorId from VendorSupplierDet Where VendorId=" + argVendorID + " and  SupplierType in ('M' ,'D')";                   
                }

                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                dt = new DataTable();
                sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                sdr.Dispose();
                if (dt.Rows.Count > 0) bReturn = true; else bReturn = false;
            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return bReturn;
        }

        public void MaxVendorUpdate(int argMaxNo)
        {
            SqlCommand cmd;
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            string sSql = "";
            try
            {
                sSql = "Update VendorCodeType Set MaxNo=" + argMaxNo + " ";
                cmd = new SqlCommand(sSql, conn, tran);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
               
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }
            finally
            {
                conn.Close();
                BsfGlobal.g_VendorDB.Close();
            }
        }

        //Regenration Code
        public static DataTable GetVendorCodeRegen()
        {
            DataTable dt;
            SqlDataAdapter sda;
            string sSql = "";
            try
            {
                BsfGlobal.OpenVendorAnalDB();

                sSql = "Select * from VendorMaster ";

                sda = new SqlDataAdapter(sSql, BsfGlobal.g_VendorDB);
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
                BsfGlobal.g_VendorDB.Close();
            }
            return dt;

        }

         public static string GetCodeCheckVendor()
        {
             string s_Code="";
            SqlCommand cmd;
            SqlDataReader sdr;
            string sSql = "";
            DataTable dt = new DataTable();
            
            try
            {
                BsfGlobal.OpenVendorAnalDB();

                sSql = "Select * from VendorCodeType";                   

                cmd = new SqlCommand(sSql, BsfGlobal.g_VendorDB);
                dt = new DataTable();
                sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                sdr.Dispose();
                if (dt.Rows.Count > 0)
                {
                    string codeP = "";
                    string codeS = "";
                    int m_iMaxN = 0;
                    codeP = dt.Rows[0]["CodePrefix"].ToString().Trim();
                    codeS = dt.Rows[0]["Suffix"].ToString().Trim();
                    m_iMaxN = Convert.ToInt32(dt.Rows[0]["MaxNo"].ToString());
                    if (codeP != "")
                    {
                        m_iMaxN = m_iMaxN + 1;
                        if (codeS != "")
                        {
                            s_Code = codeP + codeS + "000" + m_iMaxN;
                        }
                        else
                        {
                            s_Code = codeP + "000" + m_iMaxN;
                        }
                        
                    }
                }

            }
            catch (Exception ex)
            {
                BsfGlobal.CustomException(ex.Message, ex.StackTrace);
            }
            finally
            {
                BsfGlobal.g_VendorDB.Close();
            }
            return s_Code;
        }

        public void MaxVendorMasterUpdate()
        {
            SqlCommand cmd;
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            string sSql = "";
            try
            {
                sSql = "Update VendorCodeType Set MaxNo=0 ";
                cmd = new SqlCommand(sSql, conn, tran);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }
            finally
            {
                conn.Close();
                BsfGlobal.g_VendorDB.Close();
            }
        }

        public static void MaxIncVendorMasterUpdate(int argVendorId, string argVendorCode)
        {
            SqlCommand cmd;
            SqlConnection conn;
            conn = new SqlConnection();
            conn = BsfGlobal.OpenVendorAnalDB();
            SqlTransaction tran = conn.BeginTransaction();
            string sSql = "";
            try
            {

                sSql = "Update VendorMaster Set Code='" + argVendorCode + "' Where VendorId=" + argVendorId + " ";
                cmd = new SqlCommand(sSql, conn, tran);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                sSql = "Update VendorCodeType Set MaxNo=MaxNo + 1 ";
                cmd = new SqlCommand(sSql, conn, tran);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }
            finally
            {
                conn.Close();
                BsfGlobal.g_VendorDB.Close();
            }
        }

    }
}
