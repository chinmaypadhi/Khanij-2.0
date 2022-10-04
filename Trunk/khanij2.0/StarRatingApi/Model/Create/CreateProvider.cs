// ***********************************************************************
//  Class Name               : CreateProvider
//  Desciption               : Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 04 May 2021
// ***********************************************************************
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using StarRatingApi.Factory;
using StarRatingApi.Repository;
using StarratingEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Transactions;

namespace StarRatingApi.Model.Create
{
    public class CreateProvider : RepositoryBase, ICreateProvider
    {
        private readonly IConfiguration configuration;
        public CreateProvider(IConnectionFactory connectionFactory, IHostingEnvironment hostingEnvironment, IConfiguration configuration) : base(connectionFactory)
        {
            this.configuration = configuration;
        }
        #region CreateLesseeAssessment
        /// <summary>
        /// Bind Mineral List
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public List<SR_Assesment_Master> GetMineralList(SR_Assesment_Master objAllModelmaster)
        {
            List<SR_Assesment_Master> ObjMineralList = new List<SR_Assesment_Master>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Assesment_Master>("[USP_GetMineralList]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjMineralList = Output.ToList();
                }
                return ObjMineralList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Bind LeaseArea Type List
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public List<SR_Assesment_Master> GetLeaseAreaType(SR_Assesment_Master objAllModelmaster)
        {
            List<SR_Assesment_Master> ObjMineralList = new List<SR_Assesment_Master>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Assesment_Master>("[USP_GetLeaseAreaType]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjMineralList = Output.ToList();
                }
                return ObjMineralList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Assessment Count
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public AllModel GetAssessmentCount(AllModel objAllModelmaster)
        {
            AllModel ObjAssessmentCount = new AllModel();
            try
            {
                var paramList = new
                {
                    P_ACTION = "A",
                    P_USERID = objAllModelmaster.User_Id
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<AllModel>("[USP_SR_GENERALINFO_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjAssessmentCount = Output.FirstOrDefault();
                }
                return ObjAssessmentCount;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Bind User Details
        /// </summary>
        /// <param name="objUserLoginMaster"></param>
        /// <returns></returns>
        public UserLoginSession GetUserMaster(UserLoginSession objUserLoginMaster)
        {
            UserLoginSession ObjUserMaster = new UserLoginSession();
            try
            {
                var paramList = new
                {
                    P_ACTION = "B",
                    P_USERNAME = objUserLoginMaster.UserName
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<UserLoginSession>("[USP_SR_GENERALINFO_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjUserMaster = Output.SingleOrDefault();
                }
                return ObjUserMaster;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Bind Tehsil List
        /// </summary>
        /// <param name="objUserLoginMaster"></param>
        /// <returns></returns>
        public UserLoginSession GetTehsilVillage(UserLoginSession objUserLoginMaster)
        {
            UserLoginSession ObjTehsilVillage = new UserLoginSession();
            try
            {
                var paramList = new
                {
                    P_ACTION = "C",
                    P_USERNAME = objUserLoginMaster.UserName
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<UserLoginSession>("[USP_SR_GENERALINFO_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjTehsilVillage = Output.FirstOrDefault();
                }
                return ObjTehsilVillage;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Mineral Id
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public SR_Assesment_Master GetMineralId(SR_Assesment_Master objAllModelmaster)
        {
            SR_Assesment_Master ObjMineralId = new SR_Assesment_Master();
            try
            {
                var paramList = new
                {
                    P_ACTION = "D",
                    P_USERID = objAllModelmaster.User_Id
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Assesment_Master>("[USP_SR_GENERALINFO_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjMineralId = Output.FirstOrDefault();
                }
                return ObjMineralId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Lease Period
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public SR_Assesment_Master GetLeasePeriod(SR_Assesment_Master objAllModelmaster)
        {
            SR_Assesment_Master ObjLeasePeriod = new SR_Assesment_Master();
            try
            {
                var paramList = new
                {
                    P_ACTION = "E",
                    P_USERID = objAllModelmaster.User_Id
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Assesment_Master>("[USP_SR_GENERALINFO_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjLeasePeriod = Output.FirstOrDefault();
                }
                return ObjLeasePeriod;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Approved Plan
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public SR_Assesment_Master GetApprovedPlan(SR_Assesment_Master objAllModelmaster)
        {
            SR_Assesment_Master ObjApprovedPlan = new SR_Assesment_Master();
            try
            {
                var paramList = new
                {
                    P_ACTION = "F",
                    P_USERID = objAllModelmaster.User_Id
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Assesment_Master>("[USP_SR_GENERALINFO_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjApprovedPlan = Output.FirstOrDefault();
                }
                return ObjApprovedPlan;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Environment Clearance Validity Details
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public SR_Assesment_Master GetEnvironmentClearanceValidity(SR_Assesment_Master objAllModelmaster)
        {
            SR_Assesment_Master ObjEnvironmentClearanceValidity = new SR_Assesment_Master();
            try
            {
                var paramList = new
                {
                    P_ACTION = "G",
                    P_USERID = objAllModelmaster.User_Id
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Assesment_Master>("[USP_SR_GENERALINFO_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjEnvironmentClearanceValidity = Output.FirstOrDefault();
                }
                return ObjEnvironmentClearanceValidity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Forest Clearance Validity Details
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public SR_Assesment_Master GetForestClearanceValidityUpto(SR_Assesment_Master objAllModelmaster)
        {
            SR_Assesment_Master ObjForestClearanceValidityUpto = new SR_Assesment_Master();
            try
            {
                var paramList = new
                {
                    P_ACTION = "H",
                    P_USERID = objAllModelmaster.User_Id
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Assesment_Master>("[USP_SR_GENERALINFO_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjForestClearanceValidityUpto = Output.FirstOrDefault();
                }
                return ObjForestClearanceValidityUpto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Create Lessee Starrating Assessment
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public MessageEF LesseeStarratingAssessment(SR_Assesment_Master SR_AM)
        {
            MessageEF objMessage = new MessageEF();
            int Assessment_ID = 0;
            using (var connection = new SqlConnection(configuration.GetConnectionString("CIMSConnectionString")))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                using (var transaction = connection.BeginTransaction())
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    try
                    {
                        SR_AM.Contribution_To_State_Exploration_Trust = 0;
                        if (SR_AM.Forest_Clearance_Validity_Upto == null)
                        {
                            SR_AM.Forest_Clearance_Validity_Upto = "01/01/2018";
                        }
                        var p = new DynamicParameters();
                        p.Add("Assesment_Id", 1);
                        p.Add("User_Id", SR_AM.User_Id);
                        p.Add("Lessee_Code", SR_AM.Lessee_Code);
                        p.Add("Khasra_No", SR_AM.Khasra_No);
                        p.Add("State_Id", SR_AM.StateId);
                        p.Add("District_Id", SR_AM.DistrictId);
                        p.Add("Tehsil_Id", SR_AM.TehsilID);
                        p.Add("Village_Id", SR_AM.VillageID);
                        p.Add("Lease_Period_From", SR_AM.Lease_Period_From);
                        p.Add("Lease_Period_To", SR_AM.Lease_Period_To);
                        p.Add("Lessee_Type_Id", SR_AM.Lessee_Type_Id);
                        p.Add("Address", SR_AM.Address);
                        p.Add("Mobile_No", SR_AM.Mobile_No);
                        p.Add("Email_Id", SR_AM.Email_Id);
                        p.Add("Mineral_Id", SR_AM.Mineral_Id);
                        p.Add("Mining_Method_Id", SR_AM.Mining_Method_Id);
                        p.Add("Lease_Status_Id", SR_AM.Lease_Status_Id);
                        p.Add("Working_Days", SR_AM.Working_Days);
                        p.Add("Discontunuance_Days", SR_AM.Discontunuance_Days);
                        p.Add("Suspension_Days", SR_AM.Suspension_Days);
                        p.Add("Contact_Person", SR_AM.Contact_Person);
                        p.Add("Contact_No", SR_AM.Contact_No);
                        p.Add("Contact_Mail", SR_AM.Contact_Mail);
                        p.Add("Contact_Address", SR_AM.Contact_Address);
                        p.Add("Approved_Plan_Validity_From", SR_AM.Approved_Plan_Validity_From);
                        p.Add("Approved_Plan_Validity_To", SR_AM.Approved_Plan_Validity_To);
                        p.Add("Approved_Plan_Quantity", SR_AM.Approved_Plan_Quantity);
                        p.Add("Environment_Clearance_Validity_From", SR_AM.Environment_Clearance_Validity_From);
                        p.Add("Environment_Clearance_Validity_To", SR_AM.Environment_Clearance_Validity_To);
                        p.Add("Environment_Clearance_Quantity", SR_AM.Environment_Clearance_Quantity);
                        p.Add("SPCB_Validity_Upto", SR_AM.SPCB_Validity_Upto);
                        p.Add("SPCB_Quantity", SR_AM.SPCB_Quantity);
                        p.Add("Forest_Clearance_Validity_Upto", SR_AM.Forest_Clearance_Validity_Upto);
                        p.Add("Royalty_Paid", SR_AM.Royalty_Paid);
                        p.Add("Dead_Rent_Paid", SR_AM.Dead_Rent_Paid);
                        p.Add("Contribution_To_DMF", SR_AM.Contribution_To_DMF);
                        p.Add("Contribution_To_State_Exploration_Trust", SR_AM.Contribution_To_State_Exploration_Trust);
                        p.Add("Reporting_Year", SR_AM.Reporting_Year);
                        p.Add("Company_Name", SR_AM.Company_Name);
                        p.Add("Director_Name", SR_AM.Director_Name);
                        p.Add("Mode", 1);
                        p.Add("OutID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        Connection.Query<int>("SP_CRUD_SR_Assesment_Master", p, commandType: CommandType.StoredProcedure);
                        Assessment_ID = p.Get<int>("OutID");
                        if (Assessment_ID > 0)
                        {
                            objMessage.Satus = Convert.ToString(Assessment_ID);
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return objMessage;
        }
        /// <summary>
        /// FileUploadAssessment
        /// </summary>
        /// <param name="Assessment_ID"></param>
        /// <param name="objAllModelmaster"></param>
        public MessageEF FileUploadAssessment(SR_FileMaster objAllModelmaster)
        {
            MessageEF objMessage = new MessageEF();
            int Assessment_ID = objAllModelmaster.Assessment_ID;
            int fileLoop = 1;
            int mOtherID = 0; int mProtectionEnvironment1ID = 0; int mHealthSafety3ID = 0; int mStatutoryCompliance3ID = 0;
            #region FileUpload
            try
            {
                if (objAllModelmaster.HasObtainOther != null)
                {

                    if (fileLoop == 1)
                    {
                        var p11 = new DynamicParameters();
                        p11.Add("@OtherID", 1);
                        p11.Add("@OtherName", objAllModelmaster.HasObtainOther);
                        p11.Add("@AssesmentID", Assessment_ID);
                        p11.Add("@Mode", 1);
                        p11.Add("OutID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        Connection.Query<int>("SP_CRUD_SR_Other_Assesment", p11, commandType: CommandType.StoredProcedure);
                        mOtherID = p11.Get<int>("OutID");
                    }
                }
                if (objAllModelmaster.mFile == "_ProtectionEnvironment")
                {
                    objMessage = AddPE(objAllModelmaster);
                    mProtectionEnvironment1ID = Convert.ToInt32(objMessage.Satus);
                }
                if (objAllModelmaster.mFile == "_HealthSafety")
                {
                    objMessage = AddHS(objAllModelmaster);
                    mHealthSafety3ID = Convert.ToInt32(objMessage.Satus);
                }
                if (objAllModelmaster.mFile == "_StatutoryCompliance")
                {
                    objMessage = AddSC(objAllModelmaster);
                    mStatutoryCompliance3ID = Convert.ToInt32(objMessage.Satus);
                }
                if (objAllModelmaster.IsFileUpload == true)
                {
                    SR_FileMaster mSR_FileMaster = new SR_FileMaster();
                    var p1 = new DynamicParameters();
                    var InputFileName = Path.GetFileName(objAllModelmaster.FileName);
                    var FileType = Path.GetExtension(objAllModelmaster.FileExtension);
                    string mFileAdd = objAllModelmaster.mFile;
                    var FDate = DateTime.Now; var FileName = "";
                    if (mFileAdd == "_Other")
                    {
                        FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + Assessment_ID.ToString() + mOtherID.ToString() + mFileAdd;
                    }
                    else
                    {
                        FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + Assessment_ID.ToString() + mFileAdd;
                    }
                    mSR_FileMaster.FileName = FileName;
                    mSR_FileMaster.FileExtension = FileType;
                    p1.Add("FileMasterID", 1);
                    p1.Add("FileName", mSR_FileMaster.FileName);
                    p1.Add("FileExtension", mSR_FileMaster.FileExtension);
                    p1.Add("Mode", 1);
                    p1.Add("OutID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    Connection.Query<int>("SP_CRUD_SR_FileMaster", p1, commandType: CommandType.StoredProcedure);
                    int mFileMasterID = p1.Get<int>("OutID");
                    //-----------------------------------------------------------------------------------------------
                    var p2 = new DynamicParameters();
                    p2.Add("FileMappID", 1);
                    p2.Add("FileMasterID", mFileMasterID);
                    p2.Add("AssesmentID", Assessment_ID);
                    if (mFileAdd == "_Other")
                        p2.Add("OtherID", mOtherID);
                    if (mFileAdd == "_ProtectionEnvironment")
                        p2.Add("Protection_EnvironmentID", mProtectionEnvironment1ID);
                    if (mFileAdd == "_HealthSafety")
                        p2.Add("Health_SafetyID", mHealthSafety3ID);
                    if (mFileAdd == "_StatutoryCompliance")
                        p2.Add("Statutory_ComplianceID", mStatutoryCompliance3ID);
                    p2.Add("Mode", 1);
                    Connection.Query<int>(objAllModelmaster.SPName, p2, commandType: CommandType.StoredProcedure);
                    if (mFileMasterID > 0)
                    {
                        objMessage.Satus = "1";
                        objMessage.Msg = FileName + FileType;
                    }
                    else
                    {
                        objMessage.Satus = "2";
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            #endregion            
            return objMessage;
        }
        /// <summary>
        /// File Upload
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <param name="Assessment_ID"></param>
        public MessageEF AddMore(AllModel objAllModelmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                #region FILEUPLOAD
                if (objAllModelmaster.SR_CM != null)
                {
                    var p14 = new DynamicParameters();
                    p14.Add("@Coordinate_Id", 1);
                    p14.Add("@Latitude", objAllModelmaster.SR_CM.Latitude);
                    p14.Add("@Longitude", objAllModelmaster.SR_CM.Longitude);
                    p14.Add("@Assesment_Id", objAllModelmaster.Assessment_ID);
                    p14.Add("@Mode", 1);
                    Connection.Query<int>("SP_CRUD_SR_Coordinate_Master", p14, commandType: CommandType.StoredProcedure);
                }
                if (objAllModelmaster.SR_LAM != null)
                {
                    var p15 = new DynamicParameters();
                    p15.Add("@Lease_Area_Id", 1);
                    p15.Add("@Area_Type_Id", objAllModelmaster.SR_LAM.Area_Type_Id);
                    p15.Add("@Area_In_Hectare", objAllModelmaster.SR_LAM.Area_In_Hectare);
                    p15.Add("@Assesment_Id", objAllModelmaster.Assessment_ID);
                    p15.Add("@Mode", 1);
                    Connection.Query<int>("SP_CRUD_SR_Lease_Area_Master", p15, commandType: CommandType.StoredProcedure);
                }
                if (objAllModelmaster.SR_LAMM != null)
                {
                    var p16 = new DynamicParameters();
                    p16.Add("@LeaseAreaMineralID", 1);
                    p16.Add("@MineralID", objAllModelmaster.SR_LAMM.MineralID);
                    p16.Add("@LeaseArea", objAllModelmaster.SR_LAMM.LeaseArea);
                    p16.Add("@Assesment_Id", objAllModelmaster.Assessment_ID);
                    p16.Add("@Mode", 1);
                    Connection.Query<int>("SP_CRUD_SR_Lease_Area_Mineral", p16, commandType: CommandType.StoredProcedure);
                }
                #endregion
                objMessage.Satus = "1";
            }
            catch (Exception ex)
            {
                objMessage.Satus = "0";
                throw;
            }
            return objMessage;
        }
        /// <summary>
        /// Module 1. Add Systamatic Sustainable
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <param name="Assessment_ID"></param>
        public MessageEF AddSystSust(AllModel objAllModelmaster)
        {
            MessageEF objMessage = new MessageEF();
            using (var connection = new SqlConnection(configuration.GetConnectionString("CIMSConnectionString")))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                using (var transaction = connection.BeginTransaction())
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    try
                    {
                        SR_Systematic_Sustainable mSR_Systematic_Sustainable = new SR_Systematic_Sustainable();
                        mSR_Systematic_Sustainable = objAllModelmaster.SR_SS;
                        if (mSR_Systematic_Sustainable.Systematic_Sustainable_Type == null)
                        {
                            mSR_Systematic_Sustainable.Systematic_Sustainable_Type = ".";
                        }
                        if (mSR_Systematic_Sustainable.Systematic_Sustainable_Sub_Type == null)
                        {
                            mSR_Systematic_Sustainable.Systematic_Sustainable_Sub_Type = ".";
                        }
                        if (mSR_Systematic_Sustainable.Details == null)
                        {
                            mSR_Systematic_Sustainable.Details = ".";
                        }
                        if (mSR_Systematic_Sustainable.Rating_Value == null)
                        {
                            mSR_Systematic_Sustainable.Rating_Value = 0;
                        }
                        if (mSR_Systematic_Sustainable.Points_Obtained == null)
                        {
                            mSR_Systematic_Sustainable.Points_Obtained = 0;
                        }
                        if (mSR_Systematic_Sustainable.First_Point == null)
                        {
                            mSR_Systematic_Sustainable.First_Point = 0;
                        }
                        if (mSR_Systematic_Sustainable.First_Remark == null)
                        {
                            mSR_Systematic_Sustainable.First_Remark = ".";
                        }
                        if (mSR_Systematic_Sustainable.Second_Point == null)
                        {
                            mSR_Systematic_Sustainable.Second_Point = 0;
                        }
                        if (mSR_Systematic_Sustainable.Second_Remark == null)
                        {
                            mSR_Systematic_Sustainable.Second_Remark = ".";
                        }
                        if (mSR_Systematic_Sustainable.Third_Point == null)
                        {
                            mSR_Systematic_Sustainable.Third_Point = 0;
                        }
                        if (mSR_Systematic_Sustainable.Third_Remark == null)
                        {
                            mSR_Systematic_Sustainable.Third_Remark = ".";
                        }
                        mSR_Systematic_Sustainable.Assesment_Id = objAllModelmaster.Assessment_ID;
                        mSR_Systematic_Sustainable.Mode = objAllModelmaster.Mode;
                        if (mSR_Systematic_Sustainable.Mode == "1")
                            mSR_Systematic_Sustainable.Id = 1;
                        int OutId = 0;
                        var p = new DynamicParameters();
                        p.Add("Id", mSR_Systematic_Sustainable.Id);
                        p.Add("Assesment_Id", mSR_Systematic_Sustainable.Assesment_Id);
                        p.Add("Systematic_Sustainable_Type", mSR_Systematic_Sustainable.Systematic_Sustainable_Type);
                        p.Add("Systematic_Sustainable_Sub_Type", mSR_Systematic_Sustainable.Systematic_Sustainable_Sub_Type);
                        p.Add("Details", mSR_Systematic_Sustainable.Details);
                        p.Add("Rating_Value", mSR_Systematic_Sustainable.Rating_Value);
                        p.Add("Points_Obtained", mSR_Systematic_Sustainable.Points_Obtained);
                        p.Add("First_Point", mSR_Systematic_Sustainable.First_Point);
                        p.Add("First_Remark", mSR_Systematic_Sustainable.First_Remark);
                        p.Add("Second_Point", mSR_Systematic_Sustainable.Second_Point);
                        p.Add("Second_Remark", mSR_Systematic_Sustainable.Second_Remark);
                        p.Add("Third_Point", mSR_Systematic_Sustainable.Third_Point);
                        p.Add("Third_Remark", mSR_Systematic_Sustainable.Third_Remark);
                        p.Add("Mode", mSR_Systematic_Sustainable.Mode);
                        p.Add("OutID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        Connection.Query<int>("[SP_CRUD_SR_Systematic_Sustainable_new]", p, commandType: CommandType.StoredProcedure);
                        OutId = p.Get<int>("OutID");
                        if (OutId > 0)
                            objMessage.Satus = "1";
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return objMessage;
        }
        /// <summary>
        /// Module 2. Add Protection Environment
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public MessageEF AddPE(SR_FileMaster objAllModelmaster)
        {
            MessageEF objMessage = new MessageEF();
            using (var connection = new SqlConnection(configuration.GetConnectionString("CIMSConnectionString")))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                using (var transaction = connection.BeginTransaction())
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    try
                    {
                        int OutId = 0;
                        int Assessment_ID = objAllModelmaster.Assessment_ID;
                        SR_Protection_Environment mSR_Protection_Environment1 = new SR_Protection_Environment();
                        mSR_Protection_Environment1 = objAllModelmaster.SR_PE;
                        if (mSR_Protection_Environment1.Protection_Environment_Type == null)
                        {
                            mSR_Protection_Environment1.Protection_Environment_Type = ".";
                        }
                        if (mSR_Protection_Environment1.Approved_Quantity == null)
                        {
                            mSR_Protection_Environment1.Approved_Quantity = 0;
                        }
                        if (mSR_Protection_Environment1.Actual_Quantity == null)
                        {
                            mSR_Protection_Environment1.Actual_Quantity = 0;
                        }
                        if (mSR_Protection_Environment1.Details == null)
                        {
                            mSR_Protection_Environment1.Details = ".";
                        }
                        if (mSR_Protection_Environment1.Rating_Value == null)
                        {
                            mSR_Protection_Environment1.Rating_Value = 0;
                        }
                        if (mSR_Protection_Environment1.Points_Obtained == null)
                        {
                            mSR_Protection_Environment1.Points_Obtained = 0;
                        }
                        if (mSR_Protection_Environment1.First_Point == null)
                        {
                            mSR_Protection_Environment1.First_Point = 0;
                        }
                        if (mSR_Protection_Environment1.First_Remark == null)
                        {
                            mSR_Protection_Environment1.First_Remark = ".";
                        }
                        if (mSR_Protection_Environment1.Second_Point == null)
                        {
                            mSR_Protection_Environment1.Second_Point = 0;
                        }
                        if (mSR_Protection_Environment1.Second_Remark == null)
                        {
                            mSR_Protection_Environment1.Second_Remark = ".";
                        }
                        if (mSR_Protection_Environment1.Third_Point == null)
                        {
                            mSR_Protection_Environment1.Third_Point = 0;
                        }
                        if (mSR_Protection_Environment1.Third_Remark == null)
                        {
                            mSR_Protection_Environment1.Third_Remark = ".";
                        }
                        mSR_Protection_Environment1.Mode = objAllModelmaster.Action;
                        if (mSR_Protection_Environment1.Mode == "1")
                            mSR_Protection_Environment1.Id = 1;
                        var p12 = new DynamicParameters();
                        p12.Add("Id", mSR_Protection_Environment1.Id);
                        p12.Add("Assesment_Id", Assessment_ID);
                        p12.Add("Protection_Environment_Type", mSR_Protection_Environment1.Protection_Environment_Type);
                        p12.Add("Approved_Quantity", mSR_Protection_Environment1.Approved_Quantity);
                        p12.Add("Actual_Quantity", mSR_Protection_Environment1.Actual_Quantity);
                        p12.Add("Details", mSR_Protection_Environment1.Details);
                        p12.Add("Rating_Value", mSR_Protection_Environment1.Rating_Value);
                        p12.Add("Points_Obtained", mSR_Protection_Environment1.Points_Obtained);
                        p12.Add("First_Point", mSR_Protection_Environment1.First_Point);
                        p12.Add("First_Remark", mSR_Protection_Environment1.First_Remark);
                        p12.Add("Second_Point", mSR_Protection_Environment1.Second_Point);
                        p12.Add("Second_Remark", mSR_Protection_Environment1.Second_Remark);
                        p12.Add("Third_Point", mSR_Protection_Environment1.Third_Point);
                        p12.Add("Third_Remark", mSR_Protection_Environment1.Third_Remark);
                        p12.Add("Mode", mSR_Protection_Environment1.Mode);
                        p12.Add("OutID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        Connection.Query<int>("[SP_CRUD_SR_Protection_Environment_new]", p12, commandType: CommandType.StoredProcedure);
                        OutId = p12.Get<int>("OutID");
                        objMessage.Satus = OutId.ToString();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return objMessage;
        }
        /// <summary>
        /// Module 3. Add Health Safety
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public MessageEF AddHS(SR_FileMaster objAllModelmaster)
        {
            MessageEF objMessage = new MessageEF();
            using (var connection = new SqlConnection(configuration.GetConnectionString("CIMSConnectionString")))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                using (var transaction = connection.BeginTransaction())
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    try
                    {
                        int OutId = 0;
                        int Assessment_ID = objAllModelmaster.Assessment_ID;
                        SR_Health_Saftey mSR_Health_Saftey = new SR_Health_Saftey();
                        mSR_Health_Saftey = objAllModelmaster.SR_HS;
                        if (mSR_Health_Saftey.Health_Saftey_Type == null)
                        {
                            mSR_Health_Saftey.Health_Saftey_Type = ".";
                        }
                        if (mSR_Health_Saftey.Total_Employment == null)
                        {
                            mSR_Health_Saftey.Total_Employment = 0;
                        }
                        if (mSR_Health_Saftey.Percentage_Total_Employment == null)
                        {
                            mSR_Health_Saftey.Percentage_Total_Employment = 0;
                        }
                        if (mSR_Health_Saftey.Details == null)
                        {
                            mSR_Health_Saftey.Details = ".";
                        }
                        if (mSR_Health_Saftey.Rating_Value == null)
                        {
                            mSR_Health_Saftey.Rating_Value = 0;
                        }
                        if (mSR_Health_Saftey.Points_Obtained == null)
                        {
                            mSR_Health_Saftey.Points_Obtained = 0;
                        }
                        if (mSR_Health_Saftey.First_Point == null)
                        {
                            mSR_Health_Saftey.First_Point = 0;
                        }
                        if (mSR_Health_Saftey.First_Remark == null)
                        {
                            mSR_Health_Saftey.First_Remark = ".";
                        }
                        if (mSR_Health_Saftey.Second_Point == null)
                        {
                            mSR_Health_Saftey.Second_Point = 0;
                        }
                        if (mSR_Health_Saftey.Second_Remark == null)
                        {
                            mSR_Health_Saftey.Second_Remark = ".";
                        }
                        if (mSR_Health_Saftey.Third_Point == null)
                        {
                            mSR_Health_Saftey.Third_Point = 0;
                        }
                        if (mSR_Health_Saftey.Third_Remark == null)
                        {
                            mSR_Health_Saftey.Third_Remark = ".";
                        }
                        mSR_Health_Saftey.Mode = objAllModelmaster.Action;
                        if (mSR_Health_Saftey.Mode == "1")
                            mSR_Health_Saftey.Id = 1;
                        var p13 = new DynamicParameters();
                        p13.Add("Id", mSR_Health_Saftey.Id);
                        p13.Add("Assesment_Id", Assessment_ID);
                        p13.Add("Health_Saftey_Type", mSR_Health_Saftey.Health_Saftey_Type);
                        p13.Add("Total_Employment", mSR_Health_Saftey.Total_Employment);
                        p13.Add("Percentage_Total_Employment", mSR_Health_Saftey.Percentage_Total_Employment);
                        p13.Add("Details", mSR_Health_Saftey.Details);
                        p13.Add("Rating_Value", mSR_Health_Saftey.Rating_Value);
                        p13.Add("Points_Obtained", mSR_Health_Saftey.Points_Obtained);
                        p13.Add("First_Point", mSR_Health_Saftey.First_Point);
                        p13.Add("First_Remark", mSR_Health_Saftey.First_Remark);
                        p13.Add("Second_Point", mSR_Health_Saftey.Second_Point);
                        p13.Add("Second_Remark", mSR_Health_Saftey.Second_Remark);
                        p13.Add("Third_Point", mSR_Health_Saftey.Third_Point);
                        p13.Add("Third_Remark", mSR_Health_Saftey.Third_Remark);
                        p13.Add("Mode", mSR_Health_Saftey.Mode);
                        p13.Add("OutID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        Connection.Query<int>("[SP_CRUD_SR_Health_Saftey_new]", p13, commandType: CommandType.StoredProcedure);
                        OutId = p13.Get<int>("OutID");
                        objMessage.Satus = OutId.ToString();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return objMessage;
        }
        /// <summary>
        /// Module 1. Add Statuatory Compliance
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public MessageEF AddSC(SR_FileMaster objAllModelmaster)
        {
            MessageEF objMessage = new MessageEF();
            using (var connection = new SqlConnection(configuration.GetConnectionString("CIMSConnectionString")))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                using (var transaction = connection.BeginTransaction())
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    try
                    {
                        int OutId = 0;
                        int Assessment_ID = objAllModelmaster.Assessment_ID;
                        SR_Statutory_Compliance mSR_Statutory_Compliance = new SR_Statutory_Compliance();
                        mSR_Statutory_Compliance = objAllModelmaster.SR_SC;
                        if (mSR_Statutory_Compliance.Compliance_Type == null)
                        {
                            mSR_Statutory_Compliance.Compliance_Type = ".";
                        }
                        if (mSR_Statutory_Compliance.Compliance_Details == null)
                        {
                            mSR_Statutory_Compliance.Compliance_Details = ".";
                        }
                        if (mSR_Statutory_Compliance.Rating_Value == null)
                        {
                            mSR_Statutory_Compliance.Rating_Value = 0;
                        }
                        if (mSR_Statutory_Compliance.Points_Obtained == null)
                        {
                            mSR_Statutory_Compliance.Points_Obtained = 0;
                        }
                        if (mSR_Statutory_Compliance.First_Point == null)
                        {
                            mSR_Statutory_Compliance.First_Point = 0;
                        }
                        if (mSR_Statutory_Compliance.First_Remark == null)
                        {
                            mSR_Statutory_Compliance.First_Remark = ".";
                        }
                        if (mSR_Statutory_Compliance.Second_Point == null)
                        {
                            mSR_Statutory_Compliance.Second_Point = 0;
                        }
                        if (mSR_Statutory_Compliance.Second_Remark == null)
                        {
                            mSR_Statutory_Compliance.Second_Remark = ".";
                        }
                        if (mSR_Statutory_Compliance.Third_Point == null)
                        {
                            mSR_Statutory_Compliance.Third_Point = 0;
                        }
                        if (mSR_Statutory_Compliance.Third_Remark == null)
                        {
                            mSR_Statutory_Compliance.Third_Remark = ".";
                        }
                        mSR_Statutory_Compliance.Mode = objAllModelmaster.Action;
                        if (mSR_Statutory_Compliance.Mode == "1")
                            mSR_Statutory_Compliance.Id = 1;
                        var p13 = new DynamicParameters();
                        p13.Add("Id", mSR_Statutory_Compliance.Id);
                        p13.Add("Assesment_Id", Assessment_ID);
                        p13.Add("Compliance_Type", mSR_Statutory_Compliance.Compliance_Type);
                        p13.Add("Compliance_Details", mSR_Statutory_Compliance.Compliance_Details);
                        p13.Add("Rating_Value", mSR_Statutory_Compliance.Rating_Value);
                        p13.Add("Points_Obtained", mSR_Statutory_Compliance.Points_Obtained);
                        p13.Add("First_Point", mSR_Statutory_Compliance.First_Point);
                        p13.Add("First_Remark", mSR_Statutory_Compliance.First_Remark);
                        p13.Add("Second_Point", mSR_Statutory_Compliance.Second_Point);
                        p13.Add("Second_Remark", mSR_Statutory_Compliance.Second_Remark);
                        p13.Add("Third_Point", mSR_Statutory_Compliance.Third_Point);
                        p13.Add("Third_Remark", mSR_Statutory_Compliance.Third_Remark);
                        p13.Add("Mode", mSR_Statutory_Compliance.Mode);
                        p13.Add("OutID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        Connection.Query<int>("[SP_CRUD_SR_Statutory_Compliance_new]", p13, commandType: CommandType.StoredProcedure);
                        OutId = p13.Get<int>("OutID");
                        objMessage.Satus = OutId.ToString();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return objMessage;
        }
        #endregion
        #region EditLesseeAssessment
        /// <summary>
        /// Edit Lessee Starrating Assessment
        /// </summary>
        /// <param name="objSRAM"></param>
        /// <returns></returns>
        public SR_Assesment_Master EditLesseeStarratingAssessment(SR_Assesment_Master objSRAM)
        {
            SR_Assesment_Master LobjAllModelmaster = new SR_Assesment_Master();
            try
            {
                var paramList = new
                {
                    P_ASSESSMENTID = objSRAM.Assesment_Id,
                    P_ACTIONCODE = "A"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Assesment_Master>("[USP_EDIT_SR_ASSESSMENT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    LobjAllModelmaster = Output.FirstOrDefault();
                }
                return LobjAllModelmaster;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                LobjAllModelmaster = null;
            }
        }
        /// <summary>
        /// Module 1. Edit Systamatic Sustainable
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <param name="Assessment_ID"></param>
        public List<SR_Systematic_Sustainable> EditLesseeSS(SR_Systematic_Sustainable objMapFilemaster)
        {
            List<SR_Systematic_Sustainable> ObjFileList = new List<SR_Systematic_Sustainable>();
            try
            {
                var paramList = new
                {
                    P_ASSESSMENTID = objMapFilemaster.Assesment_Id,
                    P_ACTIONCODE = "B"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Systematic_Sustainable>("[USP_EDIT_SR_ASSESSMENT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjFileList = Output.ToList();
                }
                return ObjFileList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Module 2. Edit Protection Environment
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public List<SR_Protection_Environment> EditLesseePE(SR_Protection_Environment objMapFilemaster)
        {
            List<SR_Protection_Environment> ObjFileList = new List<SR_Protection_Environment>();
            try
            {
                var paramList = new
                {
                    P_ASSESSMENTID = objMapFilemaster.Assesment_Id,
                    P_ACTIONCODE = "C"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Protection_Environment>("[USP_EDIT_SR_ASSESSMENT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjFileList = Output.ToList();
                }
                return ObjFileList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Module 3. Edit Health Safety
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public List<SR_Health_Saftey> EditLesseeHS(SR_Health_Saftey objMapFilemaster)
        {
            List<SR_Health_Saftey> ObjFileList = new List<SR_Health_Saftey>();
            try
            {
                var paramList = new
                {
                    P_ASSESSMENTID = objMapFilemaster.Assesment_Id,
                    P_ACTIONCODE = "D"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Health_Saftey>("[USP_EDIT_SR_ASSESSMENT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjFileList = Output.ToList();
                }
                return ObjFileList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Module 1. Edit Statuatory Compliance
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        public List<SR_Statutory_Compliance> EditLesseeSC(SR_Statutory_Compliance objMapFilemaster)
        {
            List<SR_Statutory_Compliance> ObjFileList = new List<SR_Statutory_Compliance>();
            try
            {
                var paramList = new
                {
                    P_ASSESSMENTID = objMapFilemaster.Assesment_Id,
                    P_ACTIONCODE = "F"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Statutory_Compliance>("[USP_EDIT_SR_ASSESSMENT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjFileList = Output.ToList();
                }
                return ObjFileList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Bind Other files info
        /// </summary>
        /// <param name="objMapFilemaster"></param>
        /// <returns></returns>
        public List<SR_Additional_MappFile> GetOtherFiles(SR_Additional_MappFile objMapFilemaster)
        {
            List<SR_Additional_MappFile> ObjFileList = new List<SR_Additional_MappFile>();
            try
            {
                var paramList = new
                {
                    P_ACTIONCODE = objMapFilemaster.Action,
                    P_ASSESSMENTID = objMapFilemaster.AssesmentID
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Additional_MappFile>("[USP_EDIT_SR_ASSESSMENT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjFileList = Output.ToList();
                }
                return ObjFileList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Bind Info files details
        /// </summary>
        /// <param name="objMapFilemaster"></param>
        /// <returns></returns>
        public List<SR_FileMaster> GetInfoFiles(SR_FileMaster objMapFilemaster)
        {
            List<SR_FileMaster> ObjFileList = new List<SR_FileMaster>();
            try
            {
                var paramList = new
                {
                    P_ACTIONCODE = objMapFilemaster.Action,
                    P_ASSESSMENTID = objMapFilemaster.Assessment_ID,
                    P_ID = objMapFilemaster.FileMasterID
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_FileMaster>("[USP_EDIT_SR_ASSESSMENT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjFileList = Output.ToList();
                }
                return ObjFileList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Bind Coordinate list details
        /// </summary>
        /// <param name="objMapFilemaster"></param>
        /// <returns></returns>
        public List<SR_Coordinate_Master> GetCoordinateList(SR_Coordinate_Master objMapFilemaster)
        {
            List<SR_Coordinate_Master> ObjFileList = new List<SR_Coordinate_Master>();
            try
            {
                var paramList = new
                {
                    P_ACTIONCODE = "H",
                    P_ASSESSMENTID = objMapFilemaster.Assesment_Id
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Coordinate_Master>("[USP_EDIT_SR_ASSESSMENT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjFileList = Output.ToList();
                }
                return ObjFileList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Bind Lease Area list details
        /// </summary>
        /// <param name="objMapFilemaster"></param>
        /// <returns></returns>
        public List<SR_Lease_Area_Master> GetLeaseAreaList(SR_Lease_Area_Master objMapFilemaster)
        {
            List<SR_Lease_Area_Master> ObjFileList = new List<SR_Lease_Area_Master>();
            try
            {
                var paramList = new
                {
                    P_ACTIONCODE = "I",
                    P_ASSESSMENTID = objMapFilemaster.Assesment_Id
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Lease_Area_Master>("[USP_EDIT_SR_ASSESSMENT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjFileList = Output.ToList();
                }
                return ObjFileList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Bind Lease Type list details
        /// </summary>
        /// <param name="objMapFilemaster"></param>
        /// <returns></returns>
        public List<SR_Lease_Area_Mineral> GetLeaseTypeList(SR_Lease_Area_Mineral objMapFilemaster)
        {
            List<SR_Lease_Area_Mineral> ObjFileList = new List<SR_Lease_Area_Mineral>();
            try
            {
                var paramList = new
                {
                    P_ACTIONCODE = "J",
                    P_ASSESSMENTID = objMapFilemaster.Assesment_Id
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<SR_Lease_Area_Mineral>("[USP_EDIT_SR_ASSESSMENT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjFileList = Output.ToList();
                }
                return ObjFileList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}