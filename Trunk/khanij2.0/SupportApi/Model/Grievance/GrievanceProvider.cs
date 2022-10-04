using Dapper;
using Microsoft.AspNetCore.Mvc;
using SupportApi.Repository;
using SupportEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SupportApi.Factory;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Nest;

namespace SupportApi.Model.Grievance
{
    public class GrievanceProvider: RepositoryBase, IGrievanceProvider
    {
        public IConfiguration Configuration { get; }
       // public readonly IHttpContextAccessor _httpContextAccessor;
        public GrievanceProvider(IConnectionFactory connectionFactory, IConfiguration configuration) : base(connectionFactory)
        {
            Configuration = configuration;
          //  _httpContextAccessor = httpContextAccessor;
        }
     

        /// <summary>
        /// Get List of District
        /// </summary>
        /// <param name="objGR"></param>
        /// <returns>FillDDl class</returns>
        public Result<FillDDl> ListOfDistrict(PublicGrievanceModel objGR)
        {
            FillDDl objres = new FillDDl(); 
            List<PublicGrievanceModel> ListDP = new List<PublicGrievanceModel>();
            Result<FillDDl> r = new Result<FillDDl>();

            try
            {
                var result = Connection.Query<PublicGrievanceModel>("GetDistrict", commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (PublicGrievanceModel dr in result)
                    {
                        ListDP.Add(new PublicGrievanceModel()
                        {
                            DistrictID = dr.DistrictID,
                            DistrictName = dr.DistrictName.ToString(),


                        });
                    }
                    objres.DDL = ListDP;
                }
                r.Data = objres;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };
              
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    objres = null;
            //    ListDP = null;

            //}
            return r;

        }
        /// <summary>
        /// Get List of State
        /// </summary>
        /// <param name="objGR"></param>
        /// <returns>FillDDl class</returns>
        public Result<FillDDl> ListOfState(PublicGrievanceModel objGR)
        {
            FillDDl objres = new FillDDl();
            List<PublicGrievanceModel> ListDP = new List<PublicGrievanceModel>();
            Result<FillDDl> r = new Result<FillDDl>();

            try
            {
                var paramList = new
                {
                    SP_MODE = "GET_STATE_MASTER_DROP_DOWN",

                };
                var result = Connection.Query<PublicGrievanceModel>("USP_GET_DROPDOWNLIST", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    foreach (PublicGrievanceModel dr in result)
                    {
                        ListDP.Add(new PublicGrievanceModel()
                        {
                            VALUE = dr.VALUE,
                            TEXT = dr.TEXT.ToString(),
                        });
                    }
                    objres.DDL = ListDP;
                }
                r.Data= objres;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };

            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    objres = null;
            //    ListDP = null;


            //}
            return r;
        }
        /// <summary>
        /// Get List of Coplaint Type
        /// </summary>
        /// <param name="objGR"></param>
        /// <returns>FillDDl class</returns>
        public Result<FillDDl> ListOfCType(PublicGrievanceModel objGR)
        {
            FillDDl objres = new FillDDl();
            List<PublicGrievanceModel> ListDP = new List<PublicGrievanceModel>();
            Result<FillDDl> r = new Result<FillDDl>();
            try
            {
                var paramList = new
                {
                    SP_MODE = "GET_GREVIANCE_COMPLEINT_TYPE_DROP_DOWN",

                };


                var result = Connection.Query<PublicGrievanceModel>("USP_GET_DROPDOWNLIST", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {


                    foreach (PublicGrievanceModel dr in result)
                    {
                        ListDP.Add(new PublicGrievanceModel()
                        {
                            TEXT = dr.TEXT,
                            VALUE = dr.VALUE.ToString(),


                        });
                    }
                    objres.DDL = ListDP;
                }

                r.Data = objres;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };

               
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    objres = null;
            //    ListDP = null;

            //}
            return r;
        }
        /// <summary>
        /// Get OTP
        /// </summary>
        /// <param name="objGR"></param>
        /// <returns>PublicGrievanceModel class</returns>
        public Result<PublicGrievanceModel> GetOTPProvider(PublicGrievanceModel objER)
        {
            Result<PublicGrievanceModel> r = new Result<PublicGrievanceModel>();
            PublicGrievanceModel LobjER = new PublicGrievanceModel();
            try
            {
                var paramList = new
                {
                    MobileNo = objER.MobileNo,
                    EmailId = objER.EmailId,
                    chk = "GET_OTP",


                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<PublicGrievanceModel>("USP_OTPVerification", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjER = result.FirstOrDefault();
                }
                r.Data= LobjER;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };

            }
            catch (Exception ex)
            {

                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{

            //    LobjER = null;

            //}
            return r;
        }
        /// <summary>
        /// Verify OTP
        /// </summary>
        /// <param name="objER"></param>
        /// <returns>MessageEF class</returns>
        public Result<MessageEF> VerifyOTP(PublicGrievanceModel objER)
        {
            MessageEF objMessage = new MessageEF();
            Result<MessageEF> r = new Result<MessageEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("MobileNo", objER.MobileNo);
                p.Add("EmailId", objER.EmailId);
                p.Add("OTP", objER.OTP);
                p.Add("chk", "VERIFY_OTP");
                p.Add("Result", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                Connection.Query<string>("USP_OTPVerification", p, commandType: CommandType.StoredProcedure);
                string Res = p.Get<string>("Result");
                objMessage.Msg = Res.ToString();
                r.Data= objMessage;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    objMessage = null;
            //    objER = null;
            //}
            return r;
        }
        /// <summary>
        /// Add Public Grievance
        /// </summary>
        /// <param name="objER"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF AddPublicGrievance(PublicGrievanceModel objER)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("SP_MODE", "REGISTER_COMPLAINT");
                p.Add("GRIEVANCE_COMPLAINT_TYPE_ID", objER.GRIEVANCE_COMPLAINT_TYPE_ID);
                p.Add("SUBJECT_OF_COMPLAINT", objER.SUBJECT_OF_COMPLAINT);
                p.Add("COMPLAINT_IN_BRIEF", objER.COMPLAINT_IN_BRIEF);
                p.Add("USER_CODE_OF_COMPLAINER", objER.USER_CODE_OF_COMPLAINER);
                p.Add("NAME_OF_COMPLAINER", objER.NAME_OF_COMPLAINER);
                p.Add("COMPLETE_ADDRESS", objER.COMPLETE_ADDRESS);
                p.Add("DISTRICT", objER.DISTRICT);
                p.Add("STATE", objER.STATE);
                p.Add("PINCODE", objER.PINCODE);
                p.Add("MOBILE_NUMBER_OF_COMPLAINER", objER.MOBILE_NUMBER_OF_COMPLAINER);
                p.Add("EMAIL_ADDRESS_OF_COMPLAINER", objER.EMAIL_ADDRESS_OF_COMPLAINER);
                p.Add("TO_WHOM_AGAINST_COMPLAINT", objER.TO_WHOM_AGAINST_COMPLAINT);
                p.Add("ROLE_OF_WHOME_AGAINST_COMPLAINT", objER.ROLE_OF_WHOME_AGAINST_COMPLAINT);
                p.Add("ADDRESS", objER.ADDRESS);
                p.Add("ATTACHMENT_FILE_NAME", objER.ATTACHMENT_FILE_NAME);
                p.Add("ATTACHMENT_FILE_PATH", objER.ATTACHMENT_FILE_PATH);
                p.Add("ActionRequired", objER.Action_Against);
                p.Add("C_DISTRICT", objER.C_DISTRICT);
                p.Add("C_TEHSIL", 0);
                p.Add("C_VILLAGE", 0);
                p.Add("USER_ID", 0);
                p.Add("ComplaintType", "Public");
                p.Add("OtherSubject", ((objER.OtherSubject == "" || objER.OtherSubject == null) ? objER.SUBJECT_OF_COMPLAINT : objER.OtherSubject));
                string response = Connection.QueryFirst<string>("USP_GRIEVANCE_COMPLAINT", p, commandType: CommandType.StoredProcedure);
                objMessage.Msg = response.ToString();
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objER = null;

            }
        
        }
        /// <summary>
        /// Add Grievance
        /// </summary>
        /// <param name="objER"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF AddGrievance(PublicGrievanceModel objER)
        {
            MessageEF objMessage = new MessageEF();
            string PathGrivanceRegistration = Convert.ToString(Configuration.GetSection("FilePath").GetSection("PathGriRegister").Value);
            try
            {

                if (objER.base64GrivanceRegistration != "")
                {
                    string mystr = objER.base64GrivanceRegistration.Replace("base64,", string.Empty);
                    var testb = Convert.FromBase64String(mystr);
                    using var writer = new BinaryWriter(File.OpenWrite(PathGrivanceRegistration + objER.ATTACHMENT_FILE_NAME));
                    writer.Write(testb);
                }
                //Panchaname

                var p = new DynamicParameters();
                p.Add("SP_MODE", "REGISTER_COMPLAINT");
                p.Add("GRIEVANCE_COMPLAINT_TYPE_ID", objER.GRIEVANCE_COMPLAINT_TYPE_ID);
                p.Add("SUBJECT_OF_COMPLAINT", objER.SUBJECT_OF_COMPLAINT);
                p.Add("COMPLAINT_IN_BRIEF", objER.COMPLAINT_IN_BRIEF);
                p.Add("USER_CODE_OF_COMPLAINER", objER.USER_CODE_OF_COMPLAINER);
                p.Add("NAME_OF_COMPLAINER", objER.NAME_OF_COMPLAINER);
                p.Add("COMPLETE_ADDRESS", objER.COMPLETE_ADDRESS);
                p.Add("DISTRICT", objER.DISTRICT);
                p.Add("STATE", objER.STATE);
                p.Add("PINCODE", objER.PINCODE);
                p.Add("MOBILE_NUMBER_OF_COMPLAINER", objER.MOBILE_NUMBER_OF_COMPLAINER);
                p.Add("EMAIL_ADDRESS_OF_COMPLAINER", objER.EMAIL_ADDRESS_OF_COMPLAINER);
                p.Add("TO_WHOM_AGAINST_COMPLAINT", objER.TO_WHOM_AGAINST_COMPLAINT);
                p.Add("ROLE_OF_WHOME_AGAINST_COMPLAINT", objER.ROLE_OF_WHOME_AGAINST_COMPLAINT);
                p.Add("ADDRESS", objER.ADDRESS);
                p.Add("ATTACHMENT_FILE_NAME", objER.ATTACHMENT_FILE_NAME);
                p.Add("ATTACHMENT_FILE_PATH",(objER.base64GrivanceRegistration != "")? PathGrivanceRegistration+ objER.ATTACHMENT_FILE_NAME: objER.ATTACHMENT_FILE_PATH);
                p.Add("ActionRequired", objER.Action_Against);
                p.Add("C_DISTRICT", objER.C_DISTRICT);
                p.Add("C_TEHSIL", objER.C_TEHSIL);
                p.Add("C_VILLAGE", objER.C_VILLAGE);
                p.Add("USER_ID", 0);
                p.Add("OtherSubject", ((objER.OtherSubject == "" || objER.OtherSubject == null) ? objER.SUBJECT_OF_COMPLAINT : objER.OtherSubject));
                string response = Connection.QueryFirst<string>("USP_GRIEVANCE_COMPLAINT", p, commandType: CommandType.StoredProcedure);
                objMessage.Msg = response.ToString();
                string [] arr = objMessage.Msg.Split(":");
                objMessage.Satus = (arr[0] == "Your Complaint has been registered successfully with Complaint Registration Number ") ? "true" : "false";
                return objMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMessage = null;
                objER = null;
            }
           
        }
        /// <summary>
        /// Get a particular users data
        /// </summary>
        /// <param name="objGR"></param>
        /// <returns>PublicGrievanceModel class</returns>
        public Result<PublicGrievanceModel> GetUserData(PublicGrievanceModel objER)
        {
            PublicGrievanceModel LobjER = new PublicGrievanceModel();
            Result<PublicGrievanceModel> r = new Result<PublicGrievanceModel>();
            try
            {
                var paramList = new
                {
                    UserId = objER.IntUserId,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<PublicGrievanceModel>("uspGetComplainerUserInfo", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjER = result.FirstOrDefault();
                }
                r.Data= LobjER;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }

            //finally
            //{
            //   LobjER = null;
            //   objER = null;

            //}
            return r;
        }
        /// <summary>
        /// Get Complaint List
        /// </summary>
        /// <param name="objER"></param>
        /// <returns>List of PublicGrievanceModel class</returns>
        public Result<List<PublicGrievanceModel>> GetCListDD(PublicGrievanceModel model)
        {
            List<PublicGrievanceModel> objGrievance = new List<PublicGrievanceModel>();
            Result<List<PublicGrievanceModel>> r = new Result<List<PublicGrievanceModel>>();
            try
            {
                var paramList = new
                {

                    USER_ID = model.IntUserId,
                    SP_MODE = "GET_GRIEVANCE_COMPLAINT_LIST_FOR_DD",
                    GRIEVANCE_COMPLAINT_ID=model.GRIEVANCE_COMPLAINT_ID,
                    FromDate = model.FromDate,
                    ToDate = model.ToDate,


                };


                var result = Connection.ExecuteReader("USP_GRIEVANCE_COMPLAINT", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new PublicGrievanceModel();

                    model.GRIEVANCE_COMPLAINT_ID = Convert.ToInt32(dt.Rows[i]["GRIEVANCE_COMPLAINT_ID"]);
                    model.SUBJECT_OF_COMPLAINT = Convert.ToString(dt.Rows[i]["SUBJECT_OF_COMPLAINT"]);
                    model.ACTIVE_STATUS = Convert.ToInt32(dt.Rows[i]["ACTIVE_STATUS"]);
                    model.NAME_OF_COMPLAINER = Convert.ToString(dt.Rows[i]["NAME_OF_COMPLAINER"]);
                    model.STATE_NAME = Convert.ToString(dt.Rows[i]["StateName"]);
                    model.DISTRICT_NAME = Convert.ToString(dt.Rows[i]["DistrictName"]);
                    model.TO_WHOM_AGAINST_COMPLAINT = Convert.ToString(dt.Rows[i]["TO_WHOM_AGAINST_COMPLAINT"]);
                    model.MOBILE_NUMBER = Convert.ToString(dt.Rows[i]["MOBILE_NUMBER"]);
                    model.DGM_REMARKS = Convert.ToString(dt.Rows[i]["DGM_REMARKS"]);
                    model.MOBILE_NUMBER_OF_COMPLAINER = Convert.ToString(dt.Rows[i]["MOBILE_NUMBER_OF_COMPLAINER"]);
                    if (dt.Rows[i]["ATTACHMENT_FILE_NAME"].ToString() != "" && dt.Rows[i]["ATTACHMENT_FILE_NAME"].ToString() != null)
                    {
                        model.ATTACHMENT_FILE_NAME =  Convert.ToString(dt.Rows[i]["ATTACHMENT_FILE_NAME"]);
                    }
                    model.ATTACHMENT_FILE_PATH = Convert.ToString(dt.Rows[i]["ATTACHMENT_FILE_PATH"]);
                    model.Date = Convert.ToString(dt.Rows[i]["Date"]);
                    model.ComplaintNumber = Convert.ToString(dt.Rows[i]["ComplaintNumber"]);
                    model.Complaint_Status = Convert.ToString(dt.Rows[i]["ComplaintStatus"]);
                    model.MINING_INSPECTER_REMARKS = Convert.ToString(dt.Rows[i]["REMARKS"]);
                    model.MIResultFile = Convert.ToString(dt.Rows[i]["MIResultFile"]);
                    if (dt.Rows[i]["MIResultFile"].ToString() != "" && dt.Rows[i]["MIResultFile"].ToString() != null)
                    {
                        model.MIResultFile =  Convert.ToString(dt.Rows[i]["MIResultFile"]);
                    }
                    else
                    {
                        model.MIResultFile = "";
                    }
                    model.ComplaintType = Convert.ToString(dt.Rows[i]["ComplaintType"]);
         
                    objGrievance.Add(model);
                }
                r.Data= objGrievance;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };
            }
            catch (Exception ex)
            {

                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    model = null;
            //    objGrievance = null;
            //}
            return r;
        }
        /// <summary>
        /// Get View Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>PublicGrievanceModel class</returns>
        public Result<PublicGrievanceModel> GetViewDetails(PublicGrievanceModel model)
        {
            Result<PublicGrievanceModel> r = new Result<PublicGrievanceModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = model.IntUserId,
                    SP_MODE = "GET_GRIEVANCE_COMPLAINT_LIST",
                    GRIEVANCE_COMPLAINT_ID = model.GRIEVANCE_COMPLAINT_ID,
                };


                var result = Connection.ExecuteReader("USP_GRIEVANCE_COMPLAINT", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!(dt.Rows[i]["GRIEVANCE_COMPLAINT_ID"] is DBNull))
                        model.GRIEVANCE_COMPLAINT_ID = Convert.ToInt32(dt.Rows[i]["GRIEVANCE_COMPLAINT_ID"]);
                        model.SUBJECT_OF_COMPLAINT = Convert.ToString(dt.Rows[i]["SUBJECT_OF_COMPLAINT"]);
                    if (!(dt.Rows[i]["ACTIVE_STATUS"] is DBNull))
                        model.ACTIVE_STATUS = Convert.ToInt32(dt.Rows[i]["ACTIVE_STATUS"]);
                    model.NAME_OF_COMPLAINER = Convert.ToString(dt.Rows[i]["NAME_OF_COMPLAINER"]);
                    model.STATE_NAME = Convert.ToString(dt.Rows[i]["StateName"]);
                    model.DISTRICT_NAME = Convert.ToString(dt.Rows[i]["DistrictName"]);
                    model.TO_WHOM_AGAINST_COMPLAINT = Convert.ToString(dt.Rows[i]["TO_WHOM_AGAINST_COMPLAINT"]);
                    model.MOBILE_NUMBER_OF_COMPLAINER = Convert.ToString(dt.Rows[i]["MOBILE_NUMBER_OF_COMPLAINER"]);
                    if (!(dt.Rows[i]["GRIEVANCE_COMPLAINT_TYPE_ID"] is DBNull))
                        model.GRIEVANCE_COMPLAINT_TYPE_ID = Convert.ToInt32(dt.Rows[i]["GRIEVANCE_COMPLAINT_TYPE_ID"]);
                    model.COMPLAINT_IN_BRIEF = Convert.ToString(dt.Rows[i]["COMPLAINT_IN_BRIEF"]);
                    model.USER_CODE_OF_COMPLAINER = Convert.ToString(dt.Rows[i]["USER_CODE_OF_COMPLAINER"]);
                    if (!(dt.Rows[i]["STATE"] is DBNull))
                        model.STATE = Convert.ToInt32(dt.Rows[i]["STATE"]);
                    if (!(dt.Rows[i]["DISTRICT"] is DBNull))
                        model.DISTRICT = Convert.ToInt32(dt.Rows[i]["DISTRICT"]);
                    model.COMPLETE_ADDRESS = Convert.ToString(dt.Rows[i]["COMPLETE_ADDRESS"]);
                    model.PINCODE = Convert.ToString(dt.Rows[i]["PINCODE"]);
                    model.EMAIL_ADDRESS_OF_COMPLAINER = Convert.ToString(dt.Rows[i]["EMAIL_ADDRESS_OF_COMPLAINER"]);
                    model.ROLE_OF_WHOME_AGAINST_COMPLAINT = Convert.ToString(dt.Rows[i]["ROLE_OF_WHOME_AGAINST_COMPLAINT"]);
                    model.ADDRESS = Convert.ToString(dt.Rows[i]["ADDRESS"]);
                    model.MOBILE_NUMBER = Convert.ToString(dt.Rows[i]["MOBILE_NUMBER"]);
                    model.Action_Against = Convert.ToString(dt.Rows[i]["ActionRequired"]);
                    model.OtherSubject = Convert.ToString(dt.Rows[i]["OtherSubject"]);
                    if (!(dt.Rows[i]["C_District"] is DBNull))
                        model.C_DISTRICT = Convert.ToInt32(dt.Rows[i]["C_District"]);
                    if (!(dt.Rows[i]["C_Tehsil"] is DBNull))
                        model.C_TEHSIL = Convert.ToInt32(dt.Rows[i]["C_Tehsil"]);
                    if (!(dt.Rows[i]["C_Village"] is DBNull))
                        model.C_VILLAGE = Convert.ToInt32(dt.Rows[i]["C_Village"]);

                    model.ATTACHMENT_FILE_NAME = Convert.ToString(dt.Rows[i]["ATTACHMENT_FILE_NAME"]);
                    model.ATTACHMENT_FILE_PATH = Convert.ToString(dt.Rows[i]["ATTACHMENT_FILE_PATH"]);

                    
                }
                r.Data= model;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };


            }
            catch (Exception ex)
            {

                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{

            //    model = null;
            //}
            return r;
        }
        /// <summary>
        /// Get List Of User Type
        /// </summary>
        /// <param name="objGR"></param>
        /// <returns>FillDDl class</returns>
        public Result<FillDDl> ListOfUserType(PublicGrievanceModel objGR)
        {
            FillDDl objres = new FillDDl();
            List<PublicGrievanceModel> ListDP = new List<PublicGrievanceModel>();
            Result<FillDDl> r = new Result<FillDDl>();

            try
            {
                var paramList = new
                {
                    Check = 1,
                    USER_ID = objGR.IntUserId,

                };


                var result = Connection.Query<PublicGrievanceModel>("uspGetMI_AMO_Grievance", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {


                    foreach (PublicGrievanceModel dr in result)
                    {
                        ListDP.Add(new PublicGrievanceModel()
                        {
                            RoleId = dr.RoleId,
                            RoleName = dr.RoleName.ToString(),


                        });
                    }
                    objres.DDL = ListDP;
                }


                r.Data = objres;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };          
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    objres = null;
            //    ListDP = null;

            //}
            return r;

        }
        /// <summary>
        /// Get List Of User by Type
        /// </summary>
        /// <param name="objGR"></param>
        /// <returns>FillDDl class</returns>
        public Result<FillDDl> ListOfUserByType(PublicGrievanceModel objGR)
        {

            FillDDl objres = new FillDDl();
            List<PublicGrievanceModel> ListDP = new List<PublicGrievanceModel>();
            Result<FillDDl> r = new Result<FillDDl>();

            try
            {
                var paramList = new
                {
                    Check = 0,
                    USER_ID = objGR.IntUserId,
                    ROLE_ID = objGR.RoleId,

                };
                var result = Connection.ExecuteReader("uspGetMI_AMO_Grievance", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListDP.Add(new PublicGrievanceModel()
                        {
                            IntUserId = int.Parse(dt.Rows[i]["USERID"].ToString()),
                            NAME_OF_COMPLAINER = dt.Rows[i]["APPLICANTNAME"].ToString(),


                        });
                    }
                    objres.DDL = ListDP;
                }
                r.Data= objres;

            }
            catch (Exception ex)
            {

                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    objres = null;
            //    ListDP = null;

            //}
            return r;
           
        }
        /// <summary>
        /// Get List Of Category of COmplaint
        /// </summary>
        /// <param name="objGR"></param>
        /// <returns>FillDDl class</returns>
        public Result<FillDDl> ListOfCatComp(PublicGrievanceModel objGR)
        {
            FillDDl objres = new FillDDl();
            List<PublicGrievanceModel> ListDP = new List<PublicGrievanceModel>();
            Result<FillDDl> r = new Result<FillDDl>();
            try
            {
                var result = Connection.ExecuteReader("uspGETComplaintCategory_GRIEVANCE", commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListDP.Add(new PublicGrievanceModel()
                        {
                            VALUE = dt.Rows[i]["Value"].ToString(),
                            TEXT = dt.Rows[i]["Text"].ToString(),
                        });
                    }
                    objres.DDL = ListDP;
                }

                r.Data= objres;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };

            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    objres = null;
            //    ListDP = null;
            //}

            return r;
        }
        /// <summary>
        /// COmplaint forward to DD
        /// </summary>
        /// <param name="objER"></param>
        /// <returns>FillDDl class</returns>
        public MessageEF Forwordtodd(PublicGrievanceModel objER)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("SP_MODE", "FORWARD_TO_MINING_INSPECTOR");
                p.Add("GRIEVANCE_COMPLAINT_ID", objER.GRIEVANCE_COMPLAINT_ID);
                p.Add("Remarks", objER.DD_DMO_REMARKS);
                p.Add("SEND_TO", objER.MINING_INSPECTER_ID);
                p.Add("UserType", objER.UserType);
                p.Add("CategoryOfComplaint", objER.COC);
                p.Add("USER_ID", objER.IntUserId);
                string response = Connection.QueryFirst<string>("USP_GRIEVANCE_COMPLAINT", p, commandType: CommandType.StoredProcedure);
                objMessage.Msg = response.ToString();

                objMessage.Satus = (objMessage.Msg == "1") ? "True" : "False";
                return objMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    objER = null;
            //    objMessage = null;
            //}
           
        }
        /// <summary>
        /// Get Complaint List
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of PublicGrievanceModel class</returns>
        public Result<List<PublicGrievanceModel>> GetGCList(PublicGrievanceModel model)
        {
            List<PublicGrievanceModel> objGrievance = new List<PublicGrievanceModel>();

            Result<List<PublicGrievanceModel>> r = new Result<List<PublicGrievanceModel>>();

            try
            {
                
                var paramList = new
                {
                    USER_ID = model.IntUserId,
                    SP_MODE = "GET_GRIEVANCE_COMPLAINT_LIST",
                    GRIEVANCE_COMPLAINT_ID = model.GRIEVANCE_COMPLAINT_ID,
                };

                var result = Connection.ExecuteReader("USP_GRIEVANCE_COMPLAINT", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                //string FileURL = "http://khanijsupportapp.khanij.com\\Grievance\\Register\\";
                string FileURL = Convert.ToString(Configuration.GetSection("FilePath").GetSection("PathMobFile").Value); ;
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new PublicGrievanceModel();
                    model.GRIEVANCE_COMPLAINT_ID = Convert.ToInt32(dt.Rows[i]["GRIEVANCE_COMPLAINT_ID"]);
                    model.SUBJECT_OF_COMPLAINT = Convert.ToString(dt.Rows[i]["SUBJECT_OF_COMPLAINT"]);
                    model.ACTIVE_STATUS = Convert.ToInt32(dt.Rows[i]["ACTIVE_STATUS"]);
                    model.NAME_OF_COMPLAINER = Convert.ToString(dt.Rows[i]["NAME_OF_COMPLAINER"]);
                    model.STATE_NAME = Convert.ToString(dt.Rows[i]["StateName"]);
                    model.DISTRICT_NAME = Convert.ToString(dt.Rows[i]["DistrictName"]);
                    model.TO_WHOM_AGAINST_COMPLAINT = Convert.ToString(dt.Rows[i]["ADDRESS"]);
                    model.MOBILE_NUMBER_OF_COMPLAINER = Convert.ToString(dt.Rows[i]["MOBILE_NUMBER_OF_COMPLAINER"]);
                    model.ATTACHMENT_FILE_NAME = Convert.ToString(dt.Rows[i]["ATTACHMENT_FILE_NAME"]);
                    model.ATTACHMENT_FILE_PATH = Convert.ToString(dt.Rows[i]["ATTACHMENT_FILE_PATH"]);
                    model.Date = Convert.ToString(dt.Rows[i]["Date"]);
                    model.FromDate = Convert.ToString(dt.Rows[i]["SolvedDate"]);
                    model.Complaint_Status = Convert.ToString(dt.Rows[i]["ComplaintStatus"]);
                    model.MINING_INSPECTER_REMARKS = Convert.ToString(dt.Rows[i]["Remarks"]);
                    model.ComplaintNumber = Convert.ToString(dt.Rows[i]["ComplaintNumber"]);
                    model.fileURLPath = FileURL + model.ATTACHMENT_FILE_NAME;

                    objGrievance.Add(model);

                }

                r.Data = objGrievance;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            return r;
            //finally
            //{
            //    model = null;
            //    objGrievance = null;
            //}
        }
        /// <summary>
        /// Add DGM Grievance
        /// </summary>
        /// <param name="objER"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF AddDGMGrievance(PublicGrievanceModel objER)
        {
            MessageEF objMessage = new MessageEF();
            string PathGrivanceRegistration = Convert.ToString(Configuration.GetSection("FilePath").GetSection("PathGriRegister").Value);
            try
            {

                if (objER.base64GrivanceRegistration != "")
                {
                    string mystr = objER.base64GrivanceRegistration.Replace("base64,", string.Empty);
                    var testb = Convert.FromBase64String(mystr);
                    using var writer = new BinaryWriter(File.OpenWrite(PathGrivanceRegistration + objER.ATTACHMENT_FILE_NAME));
                    writer.Write(testb);
                }

                var p = new DynamicParameters();
                p.Add("SP_MODE", "REGISTER_COMPLAINT");
                p.Add("DISTRICT", objER.C_DISTRICT);
                p.Add("C_DISTRICT", objER.C_DISTRICT);
                p.Add("SUBJECT_OF_COMPLAINT", objER.SUBJECT_OF_COMPLAINT);
                p.Add("NAME_OF_COMPLAINER", objER.NAME_OF_COMPLAINER);
                p.Add("COMPLETE_ADDRESS", objER.ADDRESS);
                p.Add("ComplaintDate", objER.Date);
                p.Add("ATTACHMENT_FILE_NAME", objER.ATTACHMENT_FILE_NAME);
                p.Add("ATTACHMENT_FILE_PATH", (objER.base64GrivanceRegistration != "") ? PathGrivanceRegistration + objER.ATTACHMENT_FILE_NAME : objER.ATTACHMENT_FILE_PATH);
                p.Add("USER_ID", objER.IntUserId);
                p.Add("ComplaintType", "DGM");
                string response = Connection.QueryFirst<string>("USP_GRIEVANCE_COMPLAINT", p, commandType: CommandType.StoredProcedure);
                objMessage.Msg = response.ToString();
                return objMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objER = null;
                objMessage = null;
            }
          
        }
        /// <summary>
        /// Get Complaint List in MI LogIn
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of PublicGrievanceModel class</returns>
        public Result<List<PublicGrievanceModel>> GetCListMI(PublicGrievanceModel model)
        {
            List<PublicGrievanceModel> objGrievance = new List<PublicGrievanceModel>();
            Result<List<PublicGrievanceModel>> r = new Result<List<PublicGrievanceModel>>();
            try
            {
                var paramList = new
                {
                    USER_ID = model.IntUserId,
                    SP_MODE = "GET_GRIEVANCE_COMPLAINT_LIST_FOR_MINING_INSPECTOR",
                    GRIEVANCE_COMPLAINT_ID = model.GRIEVANCE_COMPLAINT_ID,
                    FromDate = model.FromDate,
                    ToDate = model.ToDate,
                };

                var result = Connection.ExecuteReader("USP_GRIEVANCE_COMPLAINT", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new PublicGrievanceModel();

                    model.GRIEVANCE_COMPLAINT_ID = Convert.ToInt32(dt.Rows[i]["GRIEVANCE_COMPLAINT_ID"]);
                    model.SUBJECT_OF_COMPLAINT = Convert.ToString(dt.Rows[i]["SUBJECT_OF_COMPLAINT"]);
                    model.ACTIVE_STATUS = Convert.ToInt32(dt.Rows[i]["ACTIVE_STATUS"]);
                    model.NAME_OF_COMPLAINER = Convert.ToString(dt.Rows[i]["NAME_OF_COMPLAINER"]);
                    model.STATE_NAME = Convert.ToString(dt.Rows[i]["StateName"]);
                    model.DISTRICT_NAME = Convert.ToString(dt.Rows[i]["DistrictName"]);
                    model.TO_WHOM_AGAINST_COMPLAINT = Convert.ToString(dt.Rows[i]["TO_WHOM_AGAINST_COMPLAINT"]);
                    model.MOBILE_NUMBER = Convert.ToString(dt.Rows[i]["MOBILE_NUMBER"]);
                    model.DD_DMO_REMARKS = Convert.ToString(dt.Rows[i]["DD_DMO_REMARKS"]);
                    model.MOBILE_NUMBER_OF_COMPLAINER = Convert.ToString(dt.Rows[i]["MOBILE_NUMBER_OF_COMPLAINER"]);
                    if (dt.Rows[i]["ATTACHMENT_FILE_NAME"].ToString() != "" && dt.Rows[i]["ATTACHMENT_FILE_NAME"].ToString() != null)
                    {
                        model.ATTACHMENT_FILE_NAME = Convert.ToString(dt.Rows[i]["ATTACHMENT_FILE_NAME"]);
                    }
                    model.ATTACHMENT_FILE_PATH = Convert.ToString(dt.Rows[i]["ATTACHMENT_FILE_PATH"]);
                    model.Date = Convert.ToString(dt.Rows[i]["Date"]);
                    model.ComplaintNumber = Convert.ToString(dt.Rows[i]["ComplaintNumber"]);
                    model.ComplaintType = Convert.ToString(dt.Rows[i]["ComplaintType"]);

                    objGrievance.Add(model);
                }
                 r.Data=objGrievance;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    model = null;
            //    objGrievance = null;
            //}
            return r;
        }
        /// <summary>
        /// MI Forward complaint to DD
        /// </summary>
        /// <param name="objER"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF MIForwordtodd(ForwardMItoDD objER)
        {
            MessageEF objMessage = new MessageEF();
            string PathGrivanceRegistration = Convert.ToString(Configuration.GetSection("FilePath").GetSection("PathForw").Value);
            try
            {
                if (objER.base64GrivanceForward != null)
                {
                    string mystr = objER.base64GrivanceForward.Replace("base64,", string.Empty);
                    var testb = Convert.FromBase64String(mystr);
                    using var writer = new BinaryWriter(File.OpenWrite(PathGrivanceRegistration + objER.AFilename));
                    writer.Write(testb);
                }
                var p = new DynamicParameters();
                p.Add("SP_MODE", "FORWARD_TO_DD_BY_MINING_INSPECTOR");
                p.Add("GRIEVANCE_COMPLAINT_ID", objER.Gid);
                p.Add("Remarks", objER.Remark);
                p.Add("USER_ID", objER.Uid);
                p.Add("MIResultFile", objER.AFilename);
                string response = Connection.QueryFirst<string>("USP_GRIEVANCE_COMPLAINT", p, commandType: CommandType.StoredProcedure);
                objMessage.Msg = response.ToString();
                objMessage.Satus = (objMessage.Msg == "1") ? "True" : "False";
                return objMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objER = null;
                objMessage = null;

            }
         
        }
        /// <summary>
        /// MI Close complaint 
        /// </summary>
        /// <param name="objER"></param>
        /// <returns>PublicGrievanceModel class</returns>
        public Result<PublicGrievanceModel> CloseComplain(CloseComplain objER)
        {
            PublicGrievanceModel model = new PublicGrievanceModel();
            Result<PublicGrievanceModel> r = new Result<PublicGrievanceModel>();
            string PathGrivanceRegistration = Convert.ToString(Configuration.GetSection("FilePath").GetSection("PathFinal").Value);
            
               
                try
            {

                if (objER.base64GrivanceClose != null)
                {
                    string mystr = objER.base64GrivanceClose.Replace("base64,", string.Empty);
                    var testb = Convert.FromBase64String(mystr);
                    using var writer = new BinaryWriter(File.OpenWrite(PathGrivanceRegistration + objER.ATTACHMENT_FILE_NAME));
                    writer.Write(testb);
                }

                var paramList = new
                {
                    USER_ID = objER.IntUserId,
                    DDResultFile = objER.ATTACHMENT_FILE_NAME,
                    SP_MODE = "FINAL_RESULT_BY_DD",
                    GRIEVANCE_COMPLAINT_ID = objER.GRIEVANCE_COMPLAINT_ID,
                };

                var result = Connection.ExecuteReader("USP_GRIEVANCE_COMPLAINT", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model.EmailId = Convert.ToString(dt.Rows[i]["EmailID"]);
                    model.ComplaintNumber =  Convert.ToString(dt.Rows[i]["ComplaintNumber"]);
                    model.NAME_OF_COMPLAINER = Convert.ToString(dt.Rows[i]["UserName"]);
                    model.Complaint_Status= Convert.ToString(dt.Rows[i]["ComplaintStatus"]);
                    model.MOBILE_NUMBER = Convert.ToString(dt.Rows[i]["MobileNumber"]);
                }
                r.Data= model;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    objER = null;
            //    model = null;
            //}
            return r;
        }




        #region Verify OTP
        /// <summary>
        /// To Verify OTP
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public async Task<MessageEF> VerifyOTP1(PublicGrievanceModel GrievanceModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@MobileNo", GrievanceModel.MobileNo);
                p.Add("@EmailId", GrievanceModel.EmailId);
                p.Add("@OTP", GrievanceModel.OTP);
                p.Add("@chk", "VERIFY_OTP");
                p.Add("Result", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                await Connection.QueryAsync<string>("USP_OTPVerification", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("Result");
                if (result == "SUCCESS")
                {
                    messageEF.Satus = "SUCCESS";
                }
                else
                {
                    messageEF.Satus = "FAILED";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return messageEF;
        }
        #endregion

        #region Get OTP
        /// <summary>
        /// Get OTP to Validate Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public async Task<MessageEF> GetOTP1(PublicGrievanceModel GrievanceModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@MobileNo", GrievanceModel.MobileNo);
                p.Add("@EmailId", GrievanceModel.EmailId);
                p.Add("@chk", "GET_OTP");
                var OTP = await Connection.ExecuteScalarAsync<string>("USP_OTPVerification", p, commandType: CommandType.StoredProcedure);
                if (!string.IsNullOrEmpty(OTP.ToString()))
                {
                    messageEF.Satus = OTP.ToString();
                }
                else
                {
                    messageEF.Satus = string.Empty;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return messageEF;
        }
        #endregion


        #region Verify Mobile No
        /// <summary>
        /// To Verify Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public async Task<MessageEF> CheckMobileNo1(PublicGrievanceModel GrievanceModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                string result = await Connection.ExecuteScalarAsync<string>("select top 1 MobileNo from UserMaster where IsActive=1 and IsDelete=0 and MobileNo='" + GrievanceModel.MobileNo + "'", param, commandType: System.Data.CommandType.Text);

                messageEF.Satus = result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return messageEF;
        }
        #endregion
    }
}
