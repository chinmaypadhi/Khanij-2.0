using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using userregistrationEFApi.Repository;
using userregistrationEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Factory;
using System.Globalization;
using System.Runtime.Serialization;
using userregistrationEFApi.Utility;

namespace userregistrationEFApi.Model.EndUser
{
    public class EndUserRegProvider : RepositoryBase, IEndUserRegProvider
    {
        
        public EndUserRegProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        /// <summary>
        /// Get OTP
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<EndUserModel> GetOTPProvider(EndUserModel objER)
        {
            EndUserModel LobjER = new EndUserModel();


            try
            {
                var paramList = new
                {
                    MobileNo = objER.MobileNo,
                    EmailId = objER.EMailId,
                    chk = "GET_OTP",


                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<EndUserModel>("USP_OTPVerification", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjER = result.FirstOrDefault();
                }
                return LobjER;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                // LobjDP = null;

            }
        }

        /// <summary>
        /// Get List Of Type
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<GetIndustryType> ListOfIType(EndUserModel objER)
        {
            GetIndustryType objres = new GetIndustryType();
            DataTable ObjDt = new DataTable();
            List<EndUserModel> ListDP = new List<EndUserModel>();
            EndUserModel DPEF = new EndUserModel();

            try
            {
                var paramList = new
                {
                    // MineralId = objDailyProduction.MineralId,
                    // UserId = objDailyProduction.UserId,
                    UserId = objER.UserId,

                };


                var result = await Connection.QueryAsync<EndUserModel>("uspGetEndUserEUPMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {


                    foreach (EndUserModel dr in result)
                    {
                        ListDP.Add(new EndUserModel()
                        {
                            EUP_Id = dr.EUP_Id,
                            Type = dr.Type.ToString(),


                        });
                    }
                    objres.IndustryType = ListDP;
                }





            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objres;




        }

        /// <summary>
        /// Get State
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<GetListState> LstState(EndUserModel objER)
        {
            GetListState objres = new GetListState();
            DataTable ObjDt = new DataTable();
            List<EndUserModel> ListDP = new List<EndUserModel>();
            EndUserModel DPEF = new EndUserModel();
            try
            {
                var paramList = new
                {
                    // MineralId = objDailyProduction.MineralId,
                    // UserId = objDailyProduction.UserId,
                    Userid = objER.UserId,
                    Chk = "State",

                };
                var result = await Connection.QueryAsync<EndUserModel>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {


                    foreach (EndUserModel dr in result)
                    {
                        ListDP.Add(new EndUserModel()
                        {
                            StateId = dr.StateId,
                            StateName = dr.StateName.ToString(),


                        });
                    }
                    objres.ListOfState = ListDP;
                }





            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objres;




        }

        /// <summary>
        /// Get List Of District By StateID
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<GetListState> ListOfDistrictByStateID(EndUserModel objER)
        {


            GetListState objres = new GetListState();
            DataTable ObjDt = new DataTable();
            List<EndUserModel> ListDP = new List<EndUserModel>();
            EndUserModel DPEF = new EndUserModel();

            try
            {
                var paramList = new
                {
                    StateID = objER.StateId,
                    // UserId = objDailyProduction.UserId,
                    Userid = objER.UserId,
                    Chk = "District",
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<EndUserModel>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (EndUserModel dr in result)
                    {
                        ListDP.Add(new EndUserModel()
                        {
                            DistrictId = dr.DistrictId,
                            DistrictName = dr.DistrictName.ToString(),


                        });
                    }
                    objres.ListOfState = ListDP;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objres;
        }

        /// <summary>
        /// Get List State O
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<GetListState> LstState_O(EndUserModel objER)
        {
            GetListState objres = new GetListState();
            DataTable ObjDt = new DataTable();
            List<EndUserModel> ListDP = new List<EndUserModel>();
            EndUserModel DPEF = new EndUserModel();

            try
            {
                var paramList = new
                {
                    // MineralId = objDailyProduction.MineralId,
                    // UserId = objDailyProduction.UserId,
                    Userid = objER.UserId,
                    Chk = "State_O",

                };


                var result = await Connection.QueryAsync<EndUserModel>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {


                    foreach (EndUserModel dr in result)
                    {
                        ListDP.Add(new EndUserModel()
                        {
                            StateId_O = dr.StateId_O,
                            StateName_O = dr.StateName_O.ToString(),


                        });
                    }
                    objres.ListOfState = ListDP;
                }





            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objres;




        }

        /// <summary>
        /// Get List Of District By StateID_O
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<GetListState> ListOfDistrictByStateID_O(EndUserModel objER)
        {


            GetListState objres = new GetListState();
            DataTable ObjDt = new DataTable();
            List<EndUserModel> ListDP = new List<EndUserModel>();
            EndUserModel DPEF = new EndUserModel();

            try
            {
                var paramList = new
                {
                    StateID = objER.StateId,
                    // UserId = objDailyProduction.UserId,
                    Userid = objER.UserId,
                    Chk = "District_O",
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<EndUserModel>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (EndUserModel dr in result)
                    {
                        ListDP.Add(new EndUserModel()
                        {
                            DistrictId_O = dr.DistrictId_O,
                            DistrictName_O = dr.DistrictName_O.ToString(),


                        });
                    }
                    objres.ListOfState = ListDP;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objres;
        }

        /// <summary>
        /// Get SQ
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<GetListState> LstSQ(EndUserModel objER)
        {
            GetListState objres = new GetListState();
            DataTable ObjDt = new DataTable();
            List<EndUserModel> ListDP = new List<EndUserModel>();
            EndUserModel DPEF = new EndUserModel();

            try
            {
                var paramList = new
                {
                    // MineralId = objDailyProduction.MineralId,
                    // UserId = objDailyProduction.UserId,
                    Userid = objER.UserId,
                    Chk = "SQ",

                };


                var result = await Connection.QueryAsync<EndUserModel>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {


                    foreach (EndUserModel dr in result)
                    {
                        ListDP.Add(new EndUserModel()
                        {
                            SQuestionId = dr.SQuestionId,
                            SQuestion = dr.SQuestion.ToString(),


                        });
                    }
                    objres.ListOfState = ListDP;
                }





            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objres;




        }

        /// <summary>
        /// Get Mineral
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<GetListState> ListOfMineral(EndUserModel objER)
        {


            GetListState objres = new GetListState();
            DataTable ObjDt = new DataTable();
            List<EndUserModel> ListDP = new List<EndUserModel>();
            EndUserModel DPEF = new EndUserModel();

            try
            {
                var paramList = new
                {

                    chk = "GetMineral",
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<EndUserModel>("Usp_MineralMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (EndUserModel dr in result)
                    {
                        ListDP.Add(new EndUserModel()
                        {
                            MineralId = dr.MineralId,
                            MineralName = dr.MineralName.ToString(),


                        });
                    }
                    objres.ListOfState = ListDP;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objres;
        }

        /// <summary>
        /// Get Mineral Form
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<GetListState> ListOfMineralForm(EndUserModel objER)
        {


            GetListState objres = new GetListState();
            DataTable ObjDt = new DataTable();
            List<EndUserModel> ListDP = new List<EndUserModel>();
            EndUserModel DPEF = new EndUserModel();

            try
            {
                var paramList = new
                {
                    UserId = objER.UserId,
                    MineralIdList = objER.MineralFormIdList,
                    Check = 2,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<EndUserModel>("uspGetMineralNature_GradeFromMineral", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (EndUserModel dr in result)
                    {
                        ListDP.Add(new EndUserModel()
                        {
                            MineralNatureId = dr.MineralNatureId,
                            MineralNature = dr.MineralNature.ToString(),


                        });
                    }
                    objres.ListOfState = ListDP;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objres;
        }

        /// <summary>
        /// Get Mineral Grade
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<GetListState> ListOfMineralGrade(EndUserModel objER)
        {


            GetListState objres = new GetListState();
            DataTable ObjDt = new DataTable();
            List<EndUserModel> ListDP = new List<EndUserModel>();
            EndUserModel DPEF = new EndUserModel();

            try
            {
                var paramList = new
                {
                    UserId = objER.UserId,
                    MineralIdList = objER.MineralFormIdList,
                    MineralNatureId = objER.MineralNatureId,
                    Check = 3,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<EndUserModel>("uspGetMineralNature_GradeFromMineral", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (EndUserModel dr in result)
                    {
                        ListDP.Add(new EndUserModel()
                        {
                            MineralGradeId = dr.MineralGradeId,
                            MineralGrade = dr.MineralGrade.ToString(),
                        });
                    }
                    objres.ListOfState = ListDP;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objres;
        }

        /// <summary>
        /// Verify OTP
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<MessageEF> VerifyOTP(EndUserModel objER)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MobileNo", objER.MobileNo);
                p.Add("EmailId", objER.EMailId);
                p.Add("OTP", objER.OTP);
                p.Add("chk", "VERIFY_OTP");
                p.Add("Result", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                // ObjParm.Add("@ComplaintId", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                await Connection.QueryAsync<string>("USP_OTPVerification", p, commandType: CommandType.StoredProcedure);
                string Res = p.Get<string>("Result");





                objMessage.Msg = Res.ToString();



            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// Add End User
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddEndUserData(EndUserModel objER)
        {
            MessageEF objMessage = new MessageEF();
            try
            {


                var p = new DynamicParameters();
                if (objER.PaymentMode == 0 || objER.PaymentMode == null)
                {

                    p.Add("chk", 1);
                }
                else
                {
                    p.Add("chk", 2);
                }

                p.Add("EndUserId", objER.EndUserId);
                p.Add("EndUserName", objER.ApplicantName);
                p.Add("CompanyName", objER.CompanyName);
                p.Add("BusinessActivity", objER.BussinessActivity);
                p.Add("Designation", objER.Designation);
                p.Add("Address", objER.Address);
                p.Add("OfficeAddress", objER.OfficeAddress);

                p.Add("DistrictId", objER.DistrictId);
                p.Add("StateId", objER.StateId);
                p.Add("PinCode", objER.PinCode);

                p.Add("DistrictId_O", objER.DistrictId_O);
                p.Add("StateId_O", objER.StateId_O);
                p.Add("PinCode_O", objER.PinCode_O);

                p.Add("ExciseRegNo", objER.ExciseRegNo);
                p.Add("PurposeOfPurchaseMineral", objER.PurposeOfPurchaseMineral);
                p.Add("SQAns", objER.SQAnswer);
                p.Add("AddedBy", objER.UserId);
                p.Add("UpdatedBy", objER.UpdatedBy);
                p.Add("EndUserTypeStatus", objER.EndUserTypeStatus);
                p.Add("AadhaarNumber", objER.AadhaarNumber);

                p.Add("Firm", objER.Firm);
                p.Add("Company", objER.Company);
                p.Add("UserCode", objER.UserCode);
                p.Add("MobileNo", objER.MobileNo);
                p.Add("EMailId", objER.EMailId);
                p.Add("SQuestionId", objER.SQuestionId);
                p.Add("TransactionalId", objER.TransactionalID);
                p.Add("GSTNO", objER.GSTNO);
                p.Add("PAN", objER.PAN);

                if (objER.TINNo != "")
                {
                    p.Add("TINNo", objER.TINNo);
                    p.Add("TINNo", objER.TINNo);
                }

                if (objER.MineralId != "")
                {
                    p.Add("MineralCount", objER.MineralCnt);
                    p.Add("MineralID", objER.MineralId);
                }

                if (objER.MineralFormId != "")
                {
                    p.Add("MineralFormCount", objER.MineralFormCnt);
                    p.Add("MineralFormID", objER.MineralFormId);
                }
                if (objER.MineralGradeId != "")
                {
                    p.Add("MineralGradeCount", objER.MineralGradeCnt);
                    p.Add("MineralGradeID", objER.MineralGradeId);
                }
                p.Add("ChallanNumber", objER.ChallanNumber);
                p.Add("ChallanDate", objER.ChallanDate);
                p.Add("Doc", objER.Doc);
                p.Add("UserLoginId", objER.UserId);
                p.Add("RegFees", objER.RegistrationFees);
                p.Add("RegistrationFeesId", objER.RegistrationFeesId);
                p.Add("NatureOfBusiness", objER.NatureOfBusiness);
                p.Add("EUPTypeId", objER.EUPTypeId);
                p.Add("MineralUse", objER.MineralUse);


                p.Add("Aadhaar_FILE_PATH", objER.Aadhaar_FILE_PATH);
                p.Add("Aadhaar_FILE_NAME", objER.Aadhaar_FILE_NAME);

                p.Add("PAN_FILE_PATH", objER.PAN_FILE_PATH);
                p.Add("PAN_FILE_NAME", objER.PAN_FILE_NAME);

                p.Add("TIN_FILE_PATH", objER.TIN_FILE_PATH);
                p.Add("TIN_FILE_NAME", objER.TIN_FILE_NAME);

                p.Add("GST_FILE_PATH", objER.GST_FILE_PATH);
                p.Add("GST_FILE_NAME", objER.GST_FILE_NAME);

                p.Add("CTO_FILE_PATH", objER.CTO_FILE_PATH);
                p.Add("CTO_FILE_NAME", objER.CTO_FILE_NAME);

                p.Add("ProductionCertificate_FILE_PATH", objER.ProductionCertificate_FILE_PATH);
                p.Add("ProductionCertificate_FILE_NAME", objER.ProductionCertificate_FILE_NAME);

                p.Add("ElectricityBill_FILE_PATH", objER.ElectricityBill_FILE_PATH);
                p.Add("ElectricityBill_FILE_NAME", objER.ElectricityBill_FILE_NAME);

                p.Add("RegistrationCopy_FILE_PATH", objER.RegistrationCopy_FILE_PATH);
                p.Add("RegistrationCopy_FILE_NAME", objER.RegistrationCopy_FILE_NAME);

                p.Add("CTOApprovalNumber", objER.CTOApprovalNumber);

                if (!string.IsNullOrEmpty(objER.CTOOrderDate))
                {
                    p.Add("CTOOrderDate", DateTimeStandard.SetDateFormat(objER.CTOOrderDate));
                }
                else { p.Add("CTOOrderDate", DateTime.Now); }
                if (!string.IsNullOrEmpty(objER.CTOValidityFrom))
                {
                    p.Add("CTOValidityFrom", DateTimeStandard.SetDateFormat(objER.CTOValidityFrom));
                }
                else { p.Add("CTOValidityFrom", DateTime.Now); }
                if (!string.IsNullOrEmpty(objER.CTOValidityTo))
                {
                    p.Add("CTOValidityTo", DateTimeStandard.SetDateFormat(objER.CTOValidityTo));
                }
                else { p.Add("CTOValidityTo", DateTime.Now); }
                p.Add("RegistrationNo", objER.RegistrationNo);
                p.Add("IsExisting", 0);
                p.Add("IsApprove", 0);
                p.Add("IsForwarded", 1);
                p.Add("Other_IndustryType", objER.Other_IndustryType);
                p.Add("IBMRegistrationNo", objER.IBMRegistrationNo);
                p.Add("Latitude", objER.Latitude);
                p.Add("longitude", objER.Longitude);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("uspInsertEndUserData", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");

                string response = newID.ToString();
                objMessage.Satus = response;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<EndUserModel> GetUserDetailsProvider(EndUserModel objER)
        {
            EndUserModel LobjER = new EndUserModel();


            try
            {
                var paramList = new
                {
                    ProfileUserId = objER.OutPutResult,
                    Check = 3,


                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<EndUserModel>("uspEndUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjER = result.FirstOrDefault();
                }
                return LobjER;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                // LobjDP = null;

            }
        }

        /// <summary>
        /// View All Request
        /// </summary>
        /// <param name="OBJEU"></param>
        /// <returns></returns>
        public async Task<List<EndUserModel>> ViewAllRequest(EndUserModel OBJEU)
        {

            List<EndUserModel> ListDP = new List<EndUserModel>();


            try
            {
                var paramList = new
                {
                    Check = 6,
                    UserID = OBJEU.UserId,
                };


                var result = await Connection.QueryAsync<EndUserModel>("Usp_DMOBulkPermit", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListDP = result.ToList();
                }

                return ListDP;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListDP = null;
            }



        }

        /// <summary>
        /// Get New Request Details
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<EndUserBasicInfoModel> GetNewRequestDetailsProvider(EndUserModel objER)
        {
            EndUserBasicInfoModel LobjER = new EndUserBasicInfoModel();


            try
            {
                var paramList = new
                {
                    USER_ID = objER.EndUserId,
                    SP_MODE = "GET_FORCE_DATA_ENDUSER",


                };
                //DynamicParameters param = new DynamicParameters();

                //var result = await Connection.QueryAsync<EndUserBasicInfoModel>("LESSEE_REGISTRATION_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);

                //if (result.Count() > 0)
                //{
                //    LobjER = result.FirstOrDefault();
                //}
                IDataReader dr = await Connection.ExecuteReaderAsync("LESSEE_REGISTRATION_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure); 
                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!(dt.Rows[0]["EUP_Type"] is DBNull))
                    {
                        LobjER.EUPType = dt.Rows[0]["EUP_Type"].ToString();
                    }

                    if (!(dt.Rows[0]["MineralName"] is DBNull))
                    {
                        LobjER.MineralName = dt.Rows[0]["MineralName"].ToString();
                    }

                    if (!(dt.Rows[0]["StateName"] is DBNull))
                    {
                        LobjER.StateName = dt.Rows[0]["StateName"].ToString();
                    }

                    if (!(dt.Rows[0]["DistrictName"] is DBNull))
                    {
                        LobjER.DistrictName = dt.Rows[0]["DistrictName"].ToString();
                    }

                    if (!(dt.Rows[0]["MineralIdList"] is DBNull))
                    {
                        LobjER.MineralIdList = dt.Rows[0]["MineralIdList"].ToString();
                    }

                    if (!(dt.Rows[0]["EndUserId"] is DBNull))
                    {
                        LobjER.EndUserId = Int32.Parse(dt.Rows[0]["EndUserId"].ToString());
                    }

                    if (!(dt.Rows[0]["EndUserName"] is DBNull))
                    {
                        LobjER.EndUserName = dt.Rows[0]["EndUserName"].ToString();
                    }

                    if (!(dt.Rows[0]["CompanyName"] is DBNull))
                    {
                        LobjER.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    }

                    if (!(dt.Rows[0]["BussinessActivity"] is DBNull))
                    {
                        LobjER.BussinessActivity = dt.Rows[0]["BussinessActivity"].ToString();
                    }

                    if (!(dt.Rows[0]["UserTypeId"] is DBNull))
                    {
                        LobjER.UserTypeId = Int32.Parse(dt.Rows[0]["UserTypeId"].ToString());
                    }

                    if (!(dt.Rows[0]["UserType"] is DBNull))
                    {
                        LobjER.UserType = dt.Rows[0]["UserType"].ToString();
                    }

                    if (!(dt.Rows[0]["Designation"] is DBNull))
                    {
                        LobjER.Designation = dt.Rows[0]["Designation"].ToString();
                    }

                    if (!(dt.Rows[0]["Address"] is DBNull))
                    {
                        LobjER.Address = dt.Rows[0]["Address"].ToString();
                    }

                    if (!(dt.Rows[0]["DistrictId"] is DBNull))
                    {
                        LobjER.DistrictId = Int32.Parse(dt.Rows[0]["DistrictId"].ToString());
                    }

                    if (!(dt.Rows[0]["StateId"] is DBNull))
                    {
                        LobjER.StateId = Int32.Parse(dt.Rows[0]["StateId"].ToString());
                    }

                    if (!(dt.Rows[0]["PinCode"] is DBNull))
                    {
                        LobjER.PinCode = dt.Rows[0]["PinCode"].ToString();
                    }


                    if (!(dt.Rows[0]["DistrictName_O"] is DBNull))
                    {
                        LobjER.DistrictName_O = dt.Rows[0]["DistrictName_O"].ToString();
                    }

                    if (!(dt.Rows[0]["StateName_O"] is DBNull))
                    {
                        LobjER.StateName_O = dt.Rows[0]["StateName_O"].ToString();
                    }

                    if (!(dt.Rows[0]["PinCode_O"] is DBNull))
                    {
                        LobjER.PinCode_O = dt.Rows[0]["PinCode_O"].ToString();
                    }


                    if (!(dt.Rows[0]["PAN"] is DBNull))
                    {
                        LobjER.PAN = dt.Rows[0]["PAN"].ToString();
                    }

                    if (!(dt.Rows[0]["PANPath"] is DBNull))
                    {
                        LobjER.PANPath = dt.Rows[0]["PANPath"].ToString();
                    }

                    if (!(dt.Rows[0]["TINNo"] is DBNull))
                    {
                        LobjER.TINNo = dt.Rows[0]["TINNo"].ToString();
                    }

                    if (!(dt.Rows[0]["ExciseRegNo"] is DBNull))
                    {
                        LobjER.ExciseRegNo = dt.Rows[0]["ExciseRegNo"].ToString();
                    }

                    if (!(dt.Rows[0]["Pop_Mineral"] is DBNull))
                    {
                        LobjER.PurposeOfPurchaseMineral = dt.Rows[0]["Pop_Mineral"].ToString();
                    }

                    if (!(dt.Rows[0]["SecurityQue"] is DBNull))
                    {
                        LobjER.SQuestion = dt.Rows[0]["SecurityQue"].ToString();
                    }

                    if (!(dt.Rows[0]["SQAns"] is DBNull))
                    {
                        LobjER.SQAnswer = dt.Rows[0]["SQAns"].ToString();
                    }

                    if (!(dt.Rows[0]["UserName"] is DBNull))
                    {
                        LobjER.UserName = dt.Rows[0]["UserName"].ToString();
                    }

                    if (!(dt.Rows[0]["Password"] is DBNull))
                    {
                        LobjER.Password = dt.Rows[0]["Password"].ToString();
                    }

                    if (!(dt.Rows[0]["TransactionalId"] is DBNull))
                    {
                        LobjER.TransactionalID = dt.Rows[0]["TransactionalId"].ToString();
                    }

                    if (!(dt.Rows[0]["RegFees"] is DBNull))
                    {
                        LobjER.RegistrationFees = Decimal.Parse(dt.Rows[0]["RegFees"].ToString());
                    }

                    if (!(dt.Rows[0]["IsSMS"] is DBNull))
                    {
                        LobjER.IsSMS = Boolean.Parse(dt.Rows[0]["IsSMS"].ToString());
                    }

                    if (!(dt.Rows[0]["IsMailed"] is DBNull))
                    {
                        LobjER.IsMailed = Boolean.Parse(dt.Rows[0]["IsMailed"].ToString());
                    }

                    if (!(dt.Rows[0]["ActiveStatus"] is DBNull))
                    {
                        LobjER.ActiveStatus = Boolean.Parse(dt.Rows[0]["ActiveStatus"].ToString());
                    }

                    if (!(dt.Rows[0]["IsDelete"] is DBNull))
                    {
                        LobjER.IsDelete = Boolean.Parse(dt.Rows[0]["IsDelete"].ToString());
                    }

                    if (!(dt.Rows[0]["AddedBy"] is DBNull))
                    {
                        LobjER.AddedBy = Int32.Parse(dt.Rows[0]["AddedBy"].ToString());
                    }

                    if (!(dt.Rows[0]["AddedOn"] is DBNull))
                    {
                        LobjER.AddedOn = DateTime.Parse(dt.Rows[0]["AddedOn"].ToString());
                    }

                    if (!(dt.Rows[0]["UpdatedBy"] is DBNull))
                    {
                        LobjER.UpdatedBy = Int32.Parse(dt.Rows[0]["UpdatedBy"].ToString());
                    }

                    if (!(dt.Rows[0]["UpdatedOn"] is DBNull))
                    {
                        LobjER.UpdatedOn = DateTime.Parse(dt.Rows[0]["UpdatedOn"].ToString());
                    }

                    if (!(dt.Rows[0]["EndUserTypeStatus"] is DBNull))
                    {
                        LobjER.EndUserTypeStatus = dt.Rows[0]["EndUserTypeStatus"].ToString();
                    }

                    if (!(dt.Rows[0]["Firm"] is DBNull))
                    {
                        LobjER.Firm = dt.Rows[0]["Firm"].ToString();
                    }

                    if (!(dt.Rows[0]["Company"] is DBNull))
                    {
                        LobjER.Company = dt.Rows[0]["Company"].ToString();
                    }

                    if (!(dt.Rows[0]["UserCode"] is DBNull))
                    {
                        LobjER.UserCode = dt.Rows[0]["UserCode"].ToString();
                    }

                    if (!(dt.Rows[0]["AadhaarNo"] is DBNull))
                    {
                        LobjER.AadhaarNumber = dt.Rows[0]["AadhaarNo"].ToString();
                    }

                    if (!(dt.Rows[0]["SecurityQueID"] is DBNull))
                    {
                        LobjER.SQuestionId = Int32.Parse(dt.Rows[0]["SecurityQueID"].ToString());
                    }

                     

                    if (!(dt.Rows[0]["MobileNo"] is DBNull))
                    {
                        LobjER.MobileNo = dt.Rows[0]["MobileNo"].ToString();
                    }

                    if (!(dt.Rows[0]["EmailId"] is DBNull))
                    {
                        LobjER.EMailId = dt.Rows[0]["EmailId"].ToString();
                    }

                    if (!(dt.Rows[0]["NatureOfBusiness"] is DBNull))
                    {
                        LobjER.NatureOfBusiness = dt.Rows[0]["NatureOfBusiness"].ToString();
                    }

                    if (!(dt.Rows[0]["MineralUse"] is DBNull))
                    {
                        LobjER.MineralUse = dt.Rows[0]["MineralUse"].ToString();
                    }

                    if (!(dt.Rows[0]["GSTNo"] is DBNull))
                    {
                        LobjER.GSTNO = dt.Rows[0]["GSTNo"].ToString();
                    }

                    if (!(dt.Rows[0]["OfficeAddress"] is DBNull))
                    {
                        LobjER.OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                    }

                    if (!(dt.Rows[0]["EUPTypeId"] is DBNull))
                    {
                        LobjER.EUPTypeId = Int32.Parse(dt.Rows[0]["EUPTypeId"].ToString());
                    }

                    if (!(dt.Rows[0]["Aadhaar_FILE_PATH"] is DBNull))
                    {
                        LobjER.Aadhaar_FILE_PATH =Convert.ToString(ds.Tables[0].Rows[0]["Aadhaar_FILE_PATH"]);
                    }

                    if (!(dt.Rows[0]["Aadhaar_FILE_NAME"] is DBNull))
                    {
                        LobjER.Aadhaar_FILE_NAME = dt.Rows[0]["Aadhaar_FILE_NAME"].ToString();
                    }

                    if (!(dt.Rows[0]["PAN_FILE_PATH"] is DBNull))
                    {
                        LobjER.PAN_FILE_PATH =Convert.ToString(ds.Tables[0].Rows[0]["PAN_FILE_PATH"]);
                    }

                    if (!(dt.Rows[0]["PAN_FILE_NAME"] is DBNull))
                    {
                        LobjER.PAN_FILE_NAME = dt.Rows[0]["PAN_FILE_NAME"].ToString();
                    }

                    if (!(dt.Rows[0]["TIN_FILE_PATH"] is DBNull))
                    {
                        LobjER.TIN_FILE_PATH =Convert.ToString(ds.Tables[0].Rows[0]["TIN_FILE_PATH"]);
                    }

                    if (!(dt.Rows[0]["TIN_FILE_NAME"] is DBNull))
                    {
                        LobjER.TIN_FILE_NAME = dt.Rows[0]["TIN_FILE_NAME"].ToString();
                    }

                    if (!(dt.Rows[0]["GST_FILE_PATH"] is DBNull))
                    {
                        LobjER.GST_FILE_PATH =Convert.ToString(ds.Tables[0].Rows[0]["GST_FILE_PATH"]);
                    }

                    if (!(dt.Rows[0]["GST_FILE_NAME"] is DBNull))
                    {
                        LobjER.GST_FILE_NAME = dt.Rows[0]["GST_FILE_NAME"].ToString();
                    }

                    if (!(dt.Rows[0]["CTO_FILE_PATH"] is DBNull))
                    {
                        LobjER.CTO_FILE_PATH =Convert.ToString(ds.Tables[0].Rows[0]["CTO_FILE_PATH"]);
                    }

                    if (!(dt.Rows[0]["CTO_FILE_NAME"] is DBNull))
                    {
                        LobjER.CTO_FILE_NAME = dt.Rows[0]["CTO_FILE_NAME"].ToString();
                    }

                    if (!(dt.Rows[0]["ProductionCertificate_FILE_PATH"] is DBNull))
                    {
                        LobjER.ProductionCertificate_FILE_PATH =Convert.ToString(ds.Tables[0].Rows[0]["ProductionCertificate_FILE_PATH"]);
                    }

                    if (!(dt.Rows[0]["ProductionCertificate_FILE_NAME"] is DBNull))
                    {
                        LobjER.ProductionCertificate_FILE_NAME = dt.Rows[0]["ProductionCertificate_FILE_NAME"].ToString();
                    }

                    if (!(dt.Rows[0]["ElectricityBill_FILE_PATH"] is DBNull))
                    {
                        LobjER.ElectricityBill_FILE_PATH =Convert.ToString(ds.Tables[0].Rows[0]["ElectricityBill_FILE_PATH"]);
                    }

                    if (!(dt.Rows[0]["ElectricityBill_FILE_NAME"] is DBNull))
                    {
                        LobjER.ElectricityBill_FILE_NAME = dt.Rows[0]["ElectricityBill_FILE_NAME"].ToString();
                    }

                    if (!(dt.Rows[0]["RegistrationCopy_FILE_PATH"] is DBNull))
                    {
                        LobjER.RegistrationCopy_FILE_PATH =Convert.ToString(ds.Tables[0].Rows[0]["RegistrationCopy_FILE_PATH"]);
                    }

                    if (!(dt.Rows[0]["RegistrationCopy_FILE_NAME"] is DBNull))
                    {
                        LobjER.RegistrationCopy_FILE_NAME = dt.Rows[0]["RegistrationCopy_FILE_NAME"].ToString();
                    }

                    if (!(dt.Rows[0]["CTOApprovalNumber"] is DBNull))
                    {
                        LobjER.CTOApprovalNumber = dt.Rows[0]["CTOApprovalNumber"].ToString();
                    }

                    if (!(dt.Rows[0]["CTOOrderDate"] is DBNull))
                    {
                        LobjER.CTOOrderDate = Convert.ToDateTime((dt.Rows[0]["CTOOrderDate"])); 
                    }
                    if (!(dt.Rows[0]["CTOOrderDate_str"] is DBNull))
                    {
                        LobjER.CTOOrderDate_str = Convert.ToString(dt.Rows[0]["CTOOrderDate_str"]);
                    }

                    if (!(dt.Rows[0]["CTOValidityFrom"] is DBNull))
                    {
                        LobjER.CTOValidityFrom = Convert.ToDateTime(dt.Rows[0]["CTOValidityFrom"]);
                    }
                    if (!(dt.Rows[0]["CTOValidityFrom_str"] is DBNull))
                    {
                        LobjER.CTOValidityFrom_str = Convert.ToString(dt.Rows[0]["CTOValidityFrom_str"]);
                    }
                    if (!(dt.Rows[0]["CTOValidityTo"] is DBNull))
                    {
                        LobjER.CTOValidityTo = Convert.ToDateTime(dt.Rows[0]["CTOValidityTo"]);
                    }
                    if (!(dt.Rows[0]["CTOValidityTo_str"] is DBNull))
                    {
                        LobjER.CTOValidityTo_str = Convert.ToString((dt.Rows[0]["CTOValidityTo_str"]));
                    }
                    if (!(dt.Rows[0]["RegistrationNo"] is DBNull))
                    {
                        LobjER.RegistrationNo = dt.Rows[0]["RegistrationNo"].ToString();
                    }

                    if (!(dt.Rows[0]["Is_Existing"] is DBNull))
                    {
                        LobjER.Is_Existing = Int32.Parse(dt.Rows[0]["Is_Existing"].ToString());
                    }

                    if (!(dt.Rows[0]["Is_Approved"] is DBNull))
                    {
                        LobjER.Is_Approved = Int32.Parse(dt.Rows[0]["Is_Approved"].ToString());

                        if (LobjER.Is_Approved > 0)
                        {
                            LobjER.ApprovalStatus = (LobjER.Is_Approved == 1) ? "APPROVED" : "REJECTED";
                        }
                        else { LobjER.ApprovalStatus = "PENDING"; }
                    }

                    if (!(dt.Rows[0]["MineralName"] is DBNull))
                    {
                        LobjER.MineralName = dt.Rows[0]["MineralName"].ToString();
                    }

                    if (!(dt.Rows[0]["MineralFormName"] is DBNull))
                    {
                        LobjER.MineralFormName = dt.Rows[0]["MineralFormName"].ToString();
                    }

                    if (!(dt.Rows[0]["MineralGradeName"] is DBNull))
                    {
                        LobjER.MineralGradeName = dt.Rows[0]["MineralGradeName"].ToString();
                    }

                    if (!(dt.Rows[0]["Other_IndustryType"] is DBNull))
                    {
                        LobjER.Other_IndustryType = dt.Rows[0]["Other_IndustryType"].ToString();
                    }

                    if (!(dt.Rows[0]["IBMRegistrationNo"] is DBNull))
                    {
                        LobjER.IBMRegistrationNo = dt.Rows[0]["IBMRegistrationNo"].ToString();
                    }
                    if (!(dt.Rows[0]["Latitude"] is DBNull))
                    {
                        LobjER.Latitude =Convert.ToDecimal(dt.Rows[0]["Latitude"].ToString());
                    }

                    if (!(dt.Rows[0]["longitude"] is DBNull))
                    {
                        LobjER.longitude =Convert.ToDecimal(dt.Rows[0]["longitude"].ToString());
                    }
                }
                return LobjER;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                // LobjDP = null;

            }
        }

        /// <summary>
        /// Approve End User
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<MessageEF> ApproveEndUser(EndUserBasicInfoModel objER)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Mode", "NEW PROFILE");
                p.Add("Action", "APPROVED");
                p.Add("EndUserId", objER.EndUserId);
                p.Add("Remarks", objER.Remarks);
                p.Add("ProfileUserId", objER.UserId);
                p.Add("Result", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                // ObjParm.Add("@ComplaintId", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                await Connection.QueryAsync<string>("uspEndUserProfileApprovalProcess", p, commandType: CommandType.StoredProcedure);
                string Res = p.Get<string>("Result");
                objMessage.Msg = Res.ToString();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// Reject End User
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<MessageEF> RejectEndUser(EndUserBasicInfoModel objER)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Mode", "NEW PROFILE");
                p.Add("Action", "REJECT");
                p.Add("EndUserId", objER.EndUserId);
                p.Add("Remarks", objER.Remarks);
                p.Add("ProfileUserId", objER.UserId);
                p.Add("Result", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                // ObjParm.Add("@ComplaintId", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                await Connection.QueryAsync<string>("uspEndUserProfileApprovalProcess", p, commandType: CommandType.StoredProcedure);
                string Res = p.Get<string>("Result");
                objMessage.Msg = Res.ToString();



            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<EndUserBasicInfoModel> GetUserDetails(EndUserBasicInfoModel objER)
        {
            EndUserBasicInfoModel LobjER = new EndUserBasicInfoModel();


            try
            {
                var paramList = new
                {

                    Check = 3,
                    ProfileUserId = objER.ProfileUserID,


                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<EndUserBasicInfoModel>("uspEndUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjER = result.FirstOrDefault();
                }
                return LobjER;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                // LobjDP = null;

            }
        }

        /// <summary>
        /// View Updation Request
        /// </summary>
        /// <param name="OBJEU"></param>
        /// <returns></returns>
        public async Task<List<EndUserModel>> ViewUpdationRequest(EndUserModel OBJEU)
        {

            List<EndUserModel> ListDP = new List<EndUserModel>();


            try
            {
                var paramList = new
                {
                    Check = 7,
                    UserID = OBJEU.UserId,
                };


                var result = await Connection.QueryAsync<EndUserModel>("Usp_DMOBulkPermit", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListDP = result.ToList();
                }

                return ListDP;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListDP = null;
            }



        }

        /// <summary>
        /// Action Taken Request
        /// </summary>
        /// <param name="OBJEU"></param>
        /// <returns></returns>
        public async Task<List<ForceFullDataEndUser>> ActionTakenRequest(EndUserModel OBJEU)
        {

            List<ForceFullDataEndUser> ListDP = new List<ForceFullDataEndUser>();


            try
            {
                var paramList = new
                {
                    Check = 8,
                    UserID = OBJEU.UserId,
                };


                var result = await Connection.QueryAsync<ForceFullDataEndUser>("Usp_DMOBulkPermit", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListDP = result.ToList();
                }

                return ListDP;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListDP = null;
            }



        }

        /// <summary>
        /// Get Action Taken Details
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<EndUserBasicInfoModel> GetActionTakenDetailsProvider(EndUserModel objER)
        {
            EndUserBasicInfoModel LobjER = new EndUserBasicInfoModel(); 
            try
            {
                var paramList = new
                {
                    USER_ID = objER.EndUserId,
                    SP_MODE = "GE_DATA_ENDUSER",


                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<EndUserBasicInfoModel>("LESSEE_REGISTRATION_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjER = result.FirstOrDefault();
                }
                return LobjER;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                // LobjDP = null;

            }
        }

        /// <summary>
        /// View End User Status
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<MessageEF> ViewEuserStatus(EndUserBasicInfoModel objER)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("RegistrationNo", objER.UserCode);
                p.Add("Mode", "CHECK");
                // p.Add("Result", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                //Connection.Query<int>("uspCheckEndUserStatus", p, commandType: CommandType.StoredProcedure);
                //int Res = p.Get<int>("Result");
                //objMessage.Msg = Res.ToString();
                string response = await Connection.QueryFirstAsync<string>("uspCheckEndUserStatus", p, commandType: CommandType.StoredProcedure);
                objMessage.Msg = response.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// Get End User Details
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<EndUserModel> GetEndUserDetails(EndUserModel objER)
        {
            EndUserModel LobjER = new EndUserModel();


            try
            {
                var paramList = new
                {
                    RegistrationNo = objER.UserCode,
                    Mode = "FETCH",


                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<EndUserModel>("uspCheckEndUserStatus", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjER = result.FirstOrDefault();
                }
                return LobjER;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                // LobjDP = null;

            }
        }

        /// <summary>
        /// Get End User Profile Status
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<MessageEF> ViewEuserProfStatus(EndUserModel1 objER)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MobileNo", objER.MobileNo);
                p.Add("EmailId", objER.EMailId);
                p.Add("Check", 7);
                // p.Add("Result", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                //Connection.Query<int>("uspCheckEndUserStatus", p, commandType: CommandType.StoredProcedure);
                //int Res = p.Get<int>("Result");
                //objMessage.Msg = Res.ToString();
                string response = await Connection.QueryFirstAsync<string>("uspEndUser", p, commandType: CommandType.StoredProcedure);
                objMessage.Msg = response.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        public DataSet ConvertDataReaderToDataSet(IDataReader data)
        {
            DataSet ds = new DataSet();
            int i = 0;
            while (!data.IsClosed)
            {
                ds.Tables.Add("Table" + (i + 1));
                ds.EnforceConstraints = false;
                ds.Tables[i].Load(data);
                i++;
            }
            return ds;
        }

    }
}
