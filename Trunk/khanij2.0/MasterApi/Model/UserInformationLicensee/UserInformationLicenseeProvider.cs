using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MasterApi.Repository;
using MasterEF;
using MasterApi.Factory;
using System.Data;

namespace MasterApi.Model.UserInformationLicensee
{
    public class UserInformationLicenseeProvider : RepositoryBase, IUserInformationLicenseeProvider
    {
        public UserInformationLicenseeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        #region IBM Details
        /// <summary>
        /// To Get IBM Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public async Task<LicenseeResult> GetLicenseeIBMDetail(IBMDetails objLicensee)
        {
            LicenseeResult UserInfo = new LicenseeResult();
            try
            {
                var paramList = new
                {
                    CHECK = "2",
                    CREATED_BY = objLicensee.CREATED_BY,
                };
                //DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<IBMDetails>("USP_LICENSEE_IBM_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.IBMDetailsLst = result.ToList(); 
                    //ListuserType = result.ToList();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        /// <summary>
        /// To Add New IBM Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF NewLicenseeIBMDetail(IBMDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 1);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("IBM_APPLICATION_NUMBER", model.IBM_APPLICATION_NUMBER);
                p.Add("IBM_APPLICATON_DATE", model.IBM_APPLICATON_DATE);
                p.Add("IBM_NUMBER", model.IBM_NUMBER);
                p.Add("STATUS", model.STATUS);
                p.Add("IBM_REGISTRATION_FORM_PATH", model.IBM_REGISTRATION_FORM_PATH);
                p.Add("FILE_IBM_REGISTRATION_FORM", model.FILE_IBM_REGISTRATION_FORM);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_IBM_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Update IBM Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF UpdateLicenseeIBMDetail(IBMDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 3);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("LICENSEE_IBM_ID", model.LICENSEE_IBM_ID);
                p.Add("IBM_APPLICATION_NUMBER", model.IBM_APPLICATION_NUMBER);
                p.Add("IBM_APPLICATON_DATE", model.IBM_APPLICATON_DATE);
                p.Add("IBM_NUMBER", model.IBM_NUMBER);
                p.Add("STATUS", model.STATUS);
                p.Add("Remarks", model.Remarks);
                p.Add("IBM_REGISTRATION_FORM_PATH", model.IBM_REGISTRATION_FORM_PATH);
                p.Add("FILE_IBM_REGISTRATION_FORM", model.FILE_IBM_REGISTRATION_FORM);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_IBM_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Delete IBM Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF DeleteLicenseeIBMDetail(IBMDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 7);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("LICENSEE_IBM_ID", model.LICENSEE_IBM_ID);
                p.Add("IBM_APPLICATION_NUMBER", model.IBM_APPLICATION_NUMBER);
                p.Add("IBM_APPLICATON_DATE", model.IBM_APPLICATON_DATE);
                p.Add("IBM_NUMBER", model.IBM_NUMBER);
                p.Add("STATUS", model.STATUS);
                p.Add("IBM_REGISTRATION_FORM_PATH", model.IBM_REGISTRATION_FORM_PATH);
                p.Add("FILE_IBM_REGISTRATION_FORM", model.FILE_IBM_REGISTRATION_FORM);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_IBM_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Approve IBM Details of Licensee By Authority
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF ApproveLicenseeIBMDetails(IBMDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 4);
                p.Add("APPROVED_BY", model.UserID);
                p.Add("LICENSEE_IBM_ID", model.LICENSEE_IBM_ID);
                // p.Add("Remarks", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_IBM_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Reject IBM Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF RejectLicenseeIBMDetails(IBMDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 5);
                p.Add("REJECTED_BY", model.UserID);
                p.Add("LICENSEE_IBM_ID", model.LICENSEE_IBM_ID);
                p.Add("Remarks", model.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_IBM_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To View IBM Details for Authority
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewIBMDetailsAuthority(ViewLicenseeDetailsAuthority model)
        {
            List<ViewLicenseeDetailsAuthority> ListIBMDetails = new List<ViewLicenseeDetailsAuthority>();
            try
            {
                var paramList = new
                {
                    REQUEST = "IBM DETAILS",
                    UserID = model.UserId,
                };
                var result = Connection.Query<ViewLicenseeDetailsAuthority>("LICENSEE_PROFILE_APPROVAL_REQUEST_GRID", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    ListIBMDetails = result.ToList();
                }
                return ListIBMDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListIBMDetails = null;
            }
        }
        /// <summary>
        /// To Compare IBM Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<IBMDetails> CompareIBMDetails(IBMDetails model)
        {
            List<IBMDetails> ListIBMDetails = new List<IBMDetails>();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 6);
                p.Add("CREATED_BY", model.CREATED_BY);
                var result = Connection.Query<IBMDetails>("USP_LICENSEE_IBM_DETAILS", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListIBMDetails = result.ToList();
                }
                return ListIBMDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListIBMDetails = null;
            }

        }
        public IBMDetails ViewIBMDetails(IBMDetails objLicensee)
        {
            IBMDetails UserInfo = new IBMDetails();
            try
            {
                var paramList = new
                {
                    CHECK = "8",
                    CREATED_BY = objLicensee.UserID
                    
                    ,
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.QueryFirst<IBMDetails>("USP_LICENSEE_IBM_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {    

                throw ex;
            }
            finally
            {

                UserInfo = null;
            }
        }
        public async Task<List<IBMDetails>> GetIBMLogDetails(IBMDetails iBMDetails)
        {
            List<IBMDetails> ObjiBMDetailslog = new List<IBMDetails>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = iBMDetails.CREATED_BY,
                    CHECK = 9
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<IBMDetails>("[USP_LICENSEE_IBM_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjiBMDetailslog = result.ToList();
                }
                return ObjiBMDetailslog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region CTE Details
        /// <summary>
        /// To Get CTE Details of Licesnee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public async Task <LicenseeResult> GetLicenseeCTEDetail(CTEDetails objLicensee)
        {
            LicenseeResult UserInfo = new LicenseeResult();
            try
            {
                var paramList = new
                {
                    CHECK = 1,
                    CREATED_BY = objLicensee.CREATED_BY,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<CTEDetails>("USP_CTE_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.CTEDetailsLst = result.ToList();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// To Add New CTE Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF NewLicenseeCTEDetail(CTEDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 8);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("CTE_ORDER_NO", model.CTE_ORDER_NO);
                p.Add("CTE_ORDER_DATE", model.CTE_ORDER_DATE);
                p.Add("CTE_VALID_FROM", model.CTE_VALID_FROM);
                p.Add("CTE_VALID_TO", model.CTE_VALID_TO);
                p.Add("STATUS", model.STATUS);
                p.Add("CTE_LETTER_PATH", model.CTE_LETTER_PATH);
                p.Add("FILE_CTE_LETTER", model.FILE_CTE_LETTER);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<CTEDetails>("USP_CTE_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Update CTE Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF UpdateLicenseeCTEDetail(CTEDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 2);
                p.Add("MODIFIED_BY", model.UserID);
                p.Add("CREATED_BY", model.CREATED_BY);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("CTE_ID", model.CTE_ID);
                p.Add("CTE_ORDER_NO", model.CTE_ORDER_NO);
                p.Add("CTE_ORDER_DATE", model.CTE_ORDER_DATE);
                p.Add("CTE_VALID_FROM", model.CTE_VALID_FROM);
                p.Add("CTE_VALID_TO", model.CTE_VALID_TO);
                p.Add("STATUS", model.STATUS);
                p.Add("CTE_LETTER_PATH", model.CTE_LETTER_PATH);
                p.Add("FILE_CTE_LETTER", model.FILE_CTE_LETTER);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_CTE_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Approve CTE Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF ApproveLicenseeCTEDetails(CTEDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 3);
                p.Add("APPROVED_BY", model.UserID);
                p.Add("CREATED_BY", model.CREATED_BY);
                p.Add("CTE_ID", model.CTE_ID);
                p.Add("Remarks", model.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_CTE_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Reject CTE Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF RejectLicenseeCTEDetails(CTEDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 4);
                p.Add("REJECTED_BY", model.UserID);
                p.Add("CREATED_BY", model.CREATED_BY);
                p.Add("CTE_ID", model.CTE_ID);
                p.Add("Remarks", model.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_CTE_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Compare CTE Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<CTEDetails> CompareCTEDetails(CTEDetails model)
        {
            List<CTEDetails> ListCTEDetails = new List<CTEDetails>();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 6);
                p.Add("CREATED_BY", model.CREATED_BY);
                var result = Connection.Query<CTEDetails>("USP_CTE_DETAILS", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListCTEDetails = result.ToList();
                }
                return ListCTEDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListCTEDetails = null;
            }
        }
        /// <summary>
        /// TO Bind CTE Log Details in View
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        public async Task<List<CTEDetails>> GetCTELogDetails(CTEDetails cTEDetails)
        {
            List<CTEDetails> ObjCTEDetailslog = new List<CTEDetails>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = cTEDetails.CREATED_BY,
                    CHECK = 5
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CTEDetails>("USP_CTE_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjCTEDetailslog = result.ToList();
                }
                return ObjCTEDetailslog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete CTE Details
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        public MessageEF DeleteCTEDetail(CTEDetails cTEDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CREATED_BY", cTEDetails.CREATED_BY);
                p.Add("CHECK", "7");
                p.Add("CTE_ID", cTEDetails.CTE_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_CTE_DETAILS]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            return objMessage;
        }
        /// <summary>
        /// To View CTE Details for Authority
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewCTEDetailsAuthority(ViewLicenseeDetailsAuthority model)
        {
            List<ViewLicenseeDetailsAuthority> ListIBMDetails = new List<ViewLicenseeDetailsAuthority>();
            try
            {
                var paramList = new
                {
                    REQUEST = "CONSENT TO ESTABLISH",
                    UserID = model.UserId,
                };
                var result = Connection.Query<ViewLicenseeDetailsAuthority>("LICENSEE_PROFILE_APPROVAL_REQUEST_GRID", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    ListIBMDetails = result.ToList();
                }
                return ListIBMDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListIBMDetails = null;
            }
        }

        #endregion
        #region CTO Details
        /// <summary>
        /// To Get CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public async Task<LicenseeResult> GetLicenseeCTODetail(CTODetails cTODetails)
        {
            LicenseeResult UserInfo = new LicenseeResult();
            try
            {
                var paramList = new
                {
                    CHECK = 2,
                    CREATED_BY = cTODetails.UserID,
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CTODetails>("USP_CTO_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.CTODetailsLst = result.ToList();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { UserInfo = null; }

        }
        /// <summary>
        /// To Add New CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public MessageEF NewLicenseeCTODetail(CTODetails cTODetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 1);
                p.Add("CREATED_BY", cTODetails.UserID);
                p.Add("USER_LOGIN_ID", cTODetails.UserLoginId);
                p.Add("CTO_ORDER_NO", cTODetails.CTO_ORDER_NO);
                p.Add("CTO_ORDER_DATE", cTODetails.CTO_ORDER_DATE);
                p.Add("CTO_VALID_FROM", cTODetails.CTO_VALID_FROM);
                p.Add("CTO_VALID_TO", cTODetails.CTO_VALID_TO);
                p.Add("STATUS", cTODetails.STATUS);
                p.Add("CTO_LETTER_PATH", cTODetails.CTO_LETTER_PATH);
                p.Add("FILE_CTO_LETTER", cTODetails.FILE_CTO_LETTER);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<CTEDetails>("USP_CTO_DETAILS", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Update CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public MessageEF UpdateLicenseeCTODetail(CTODetails cTODetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 3);
                p.Add("CREATED_BY", cTODetails.CREATED_BY);
                p.Add("MODIFIED_BY", cTODetails.CREATED_BY);
                p.Add("CTO_ID", cTODetails.CTO_ID);
                p.Add("USER_LOGIN_ID", cTODetails.UserLoginId);
                p.Add("CTO_ORDER_NO", cTODetails.CTO_ORDER_NO);
                p.Add("CTO_ORDER_DATE", cTODetails.CTO_ORDER_DATE);
                p.Add("CTO_VALID_FROM", cTODetails.CTO_VALID_FROM);
                p.Add("CTO_VALID_TO", cTODetails.CTO_VALID_TO);
                p.Add("STATUS", cTODetails.STATUS);
                p.Add("CTO_LETTER_PATH", cTODetails.CTO_LETTER_PATH);
                p.Add("FILE_CTO_LETTER", cTODetails.FILE_CTO_LETTER);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_CTO_DETAILS", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Approve CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public MessageEF ApproveLicenseeCTODetails(CTODetails cTODetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 4);
                p.Add("APPROVED_BY", cTODetails.UserID);
                p.Add("CREATED_BY", cTODetails.CREATED_BY);
                p.Add("CTO_ID", cTODetails.CTO_ID);
                p.Add("Remarks", cTODetails.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_CTO_DETAILS", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Reject CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public MessageEF RejectLicenseeCTODetails(CTODetails cTODetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 5);
                p.Add("REJECTED_BY", cTODetails.UserID); 
                p.Add("CREATED_BY", cTODetails.CREATED_BY);
                p.Add("CTO_ID", cTODetails.CTO_ID);
                p.Add("Remarks", cTODetails.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_CTO_DETAILS", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Compare CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public List<CTODetails> CompareCTODetails(CTODetails cTODetails)
        {
            List<CTODetails> ListCTODetails = new List<CTODetails>();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 7);
                p.Add("CREATED_BY", cTODetails.CREATED_BY);
                var result = Connection.Query<CTODetails>("USP_CTO_DETAILS", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListCTODetails = result.ToList();
                }
                return ListCTODetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListCTODetails = null;
            }

        }
        /// <summary>
        /// To Bind CTO Details Log History of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public async Task<List<CTODetails>> GetCTOLogDetails(CTODetails cTODetails)
        {
            List<CTODetails> ObjCTODetailslog = new List<CTODetails>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = cTODetails.CREATED_BY,
                    CHECK = 6
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CTODetails>("USP_CTO_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjCTODetailslog = result.ToList();
                }
                return ObjCTODetailslog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete CTO Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF DeleteCTODetail(CTODetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 8);
                p.Add("CREATED_BY", model.CREATED_BY);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("CTO_ID", model.CTO_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_CTO_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objMessage;
        }
        public List<ViewLicenseeDetailsAuthority> ViewCTODetailsAuthority(ViewLicenseeDetailsAuthority model)
        {
            List<ViewLicenseeDetailsAuthority> ListIBMDetails = new List<ViewLicenseeDetailsAuthority>();
            try
            {
                var paramList = new
                {
                    REQUEST = "CONSENT TO OPERATE",
                    UserID = model.UserId,
                };
                var result = Connection.Query<ViewLicenseeDetailsAuthority>("LICENSEE_PROFILE_APPROVAL_REQUEST_GRID", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    ListIBMDetails = result.ToList();
                }
                return ListIBMDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListIBMDetails = null;
            }
        }
        #endregion
        #region Grant Order Details
        /// <summary>
        /// To Get Grant Order Details Data in View
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public async Task<LicenseeResult> GetGrantOrderDetails(GrantDetails objLicensee)
        {
            LicenseeResult UserInfo = new LicenseeResult();
            try
            {
                var paramList = new
                {
                    CHECK = 2,
                    CREATED_BY = objLicensee.UserID,
                };

                var result = await Connection.QueryAsync<GrantDetails>("USP_LICENSEE_GRANT", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.GratnDetilsList = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserInfo;
        }
        /// <summary>
        /// To Add New Grant Order Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF NewGrantOrderDetail(GrantDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 1);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("GRANT_ORDER_NUMBER", model.GrantOrderNumber);
                p.Add("GRANT_ORDER_DATE", model.GrantOrderDate);
                p.Add("FROM_VALIDITY", model.FromValidity);
                p.Add("TO_VALIDITY", model.ToValidity);
                p.Add("STATUS", model.STATUS);
                p.Add("GRANT_ORDER_COPY_PATH", model.GrantOrderFilePath);
                p.Add("FILE_GRANT_ORDER_COPY", model.GrantOrderFileName);
                p.Add("LicensePeriod_InYears", model.LicensePeriod);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<CTEDetails>("USP_LICENSEE_GRANT", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Update Grant Order Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF UpdateGrantOrderDetail(GrantDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 3);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("LICENSEE_GRANT_ORDER_ID", model.GrantOrderId);
                p.Add("GRANT_ORDER_NUMBER", model.GrantOrderNumber);
                p.Add("GRANT_ORDER_DATE", model.GrantOrderDate);
                p.Add("FROM_VALIDITY", model.FromValidity);
                p.Add("TO_VALIDITY", model.ToValidity);
                p.Add("STATUS", model.STATUS);
                p.Add("GRANT_ORDER_COPY_PATH", model.GrantOrderFilePath);
                p.Add("FILE_GRANT_ORDER_COPY", model.GrantOrderFileName);
                p.Add("LicensePeriod", model.LicensePeriod);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_GRANT", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Approve Grant Order Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF ApproveGrantOrderDetails(GrantDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 4);
                p.Add("APPROVED_BY", model.UserID);
                p.Add("CREATED_BY", model.CREATED_BY);
                p.Add("LICENSEE_GRANT_ORDER_ID", model.GrantOrderId);
                p.Add("REMARKS", model.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_GRANT", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Reject Grant Order Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF RejectGrantOrderDetails(GrantDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 5);
                p.Add("REJECTED_BY", model.UserID);
                p.Add("CREATED_BY", model.CREATED_BY);
                p.Add("LICENSEE_GRANT_ORDER_ID", model.GrantOrderId);
                p.Add("REMARKS", model.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_GRANT", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Compare Grant Order Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<GrantDetails> CompareGrantOrderDetails(GrantDetails model)
        {
            List<GrantDetails> ListGrantDetails = new List<GrantDetails>();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 6);
                p.Add("CREATED_BY", model.UserID);
                var result = Connection.Query<GrantDetails>("USP_LICENSEE_GRANT", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListGrantDetails = result.ToList();
                }
                return ListGrantDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListGrantDetails = null;
            }
        }
        /// <summary>
        /// To View Grant Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewGrantDetailsAuthority(ViewLicenseeDetailsAuthority objLicensee)
        {
            List<ViewLicenseeDetailsAuthority> ListIBMDetails = new List<ViewLicenseeDetailsAuthority>();
            try
            {
                var paramList = new
                {
                    REQUEST = "GRANT ORDER DETAILS",
                    UserID = objLicensee.UserId,
                };
                var result = Connection.Query<ViewLicenseeDetailsAuthority>("LICENSEE_PROFILE_APPROVAL_REQUEST_GRID", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    ListIBMDetails = result.ToList();
                }
                return ListIBMDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListIBMDetails = null;
            }
        }
        /// <summary>
        /// To Bind Grant Order Details in View
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<List<GrantDetails>> GetGrantLogDetails(GrantDetails model)
        {
            List<GrantDetails> ObjiBMDetailslog = new List<GrantDetails>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = model.CREATED_BY,
                    CHECK = 7
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<GrantDetails>("[USP_LICENSEE_GRANT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjiBMDetailslog = result.ToList();
                }
                return ObjiBMDetailslog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delte Grant Order Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF DeleteGrantOrderDetail(GrantDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 8);
                p.Add("CREATED_BY", model.CREATED_BY);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("LICENSEE_GRANT_ORDER_ID", model.GrantOrderId);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_GRANT", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objMessage;
        }
        #endregion
        #region EC Details
        /// <summary>
        /// To Get Mineral Names
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        public async Task<List<ECDetails>> GetMineralNames(ECDetails eCDetails)
        {
            List<ECDetails> ObjMineralNameDetails = new List<ECDetails>();
            try
            {
                var paramList = new
                {
                    UserId = eCDetails.CREATED_BY,
                    //MineralTypeId = applicationDetails.MINERAL_CATEGORY_ID
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<ECDetails>("uspGetLicenseeECQuantityMineralwise", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralNameDetails = result.ToList();
                }
                return ObjMineralNameDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Envirnmental Clearance Details Data in View
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public async Task<LicenseeResult> GetECDetails(ECDetails objLicensee)
        {

            LicenseeResult UserInfo = new LicenseeResult();
            try
            {
                var paramList = new
                {
                    CHECK = 1,
                    CREATED_BY = objLicensee.UserID,
                };
                var result = await Connection.QueryAsync<ECDetails>("USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.ECDetailsList = result.ToList();
                    //ListuserType = result.ToList();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return UserInfo;
        }
        /// <summary>
        /// To Add New Environmental Clearance 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF NewECDetail(ECDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 2);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("ApplicationDateOfEC", model.EC_APPLICATON_DATE);
                p.Add("EC_ORDRER_NUMBER", model.EC_ORDRER_NUMBER); ;
                p.Add("EC_VALID_FROM", model.EC_VALID_FROM);
                p.Add("EC_VALID_TO", model.EC_VALID_TO);
                p.Add("STATUS", model.STATUS);
                p.Add("EC_CLEARANCE_PATH", model.EC_CLEARANCE_PATH);
                p.Add("FILE_EC_CLEARANCE", model.FILE_EC_CLEARANCE);
                p.Add("EC_APPROVED_CAPACITY", model.EC_APPROVED_CAPACITY);
                var result = Connection.Query<ECDetails>("USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Update Environmental Clearance Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF UpdateECDetail(ECDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 2);
                p.Add("CREATED_BY", model.UserID);
                p.Add("LICENSEE_EC_ID", model.LICENSEE_EC_ID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("ApplicationDateOfEC", model.EC_APPLICATON_DATE);
                p.Add("EC_ORDRER_NUMBER", model.EC_ORDRER_NUMBER);
                p.Add("EC_VALID_FROM", model.EC_VALID_FROM);
                p.Add("EC_VALID_TO", model.EC_VALID_TO);
                p.Add("STATUS", model.STATUS);
                p.Add("EC_CLEARANCE_PATH", model.EC_CLEARANCE_PATH);
                p.Add("FILE_EC_CLEARANCE", model.FILE_EC_CLEARANCE);
                p.Add("EC_APPROVED_CAPACITY", model.EC_APPROVED_CAPACITY);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Approve Environmental Clearance Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF ApproveECDetails(ECDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 3);
                p.Add("APPROVED_BY", model.UserLoginId);
                p.Add("LICENSEE_EC_ID", model.LICENSEE_EC_ID);
                p.Add("Remarks", model.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Reject Environmental Clearance Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF RejectECDetails(ECDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 4);
                p.Add("REJECTED_BY", model.UserLoginId);
                p.Add("LICENSEE_EC_ID", model.LICENSEE_EC_ID);
                p.Add("Remarks", model.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Compare Environmental Clearance Old and Modified Data Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ECDetails> CompareECDetails(ECDetails model)
        {
            List<ECDetails> ListGrantDetails = new List<ECDetails>();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 6);
                p.Add("CREATED_BY", model.CREATED_BY);
                var result = Connection.Query<ECDetails>("USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListGrantDetails = result.ToList();
                }
                return ListGrantDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListGrantDetails = null;
            }
        }
        /// <summary>
        /// To View EC Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewECDetailsAuthority(ECDetails model)
        {
            List<ViewLicenseeDetailsAuthority> ListIBMDetails = new List<ViewLicenseeDetailsAuthority>();
            try
            {
                var paramList = new
                {
                    REQUEST = "ENVIRONMENTAL CLEARANCE DETAILS",
                    UserID = model.UserID,
                };
                var result = Connection.Query<ViewLicenseeDetailsAuthority>("LICENSEE_PROFILE_APPROVAL_REQUEST_GRID", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListIBMDetails = result.ToList();
                }
                return ListIBMDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListIBMDetails = null;
            }

        }
        /// <summary>
        /// To Bind EC Log Details in View
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<List<ECDetails>> GetECLogDetails(ECDetails model)
        {
            List<ECDetails> ObjiBMDetailslog = new List<ECDetails>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = model.CREATED_BY,
                    CHECK = 5
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<ECDetails>("USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjiBMDetailslog = result.ToList();
                }
                return ObjiBMDetailslog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete EC Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF DeleteECDetail(ECDetails model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 7);
                p.Add("CREATED_BY", model.CREATED_BY);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("LICENSEE_EC_ID", model.LICENSEE_EC_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objMessage;
        }
        #endregion
        #region Area Details
        /// <summary>
        /// Bind State List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<AreaDetails>> GetStateList(AreaDetails objLeaseAreaModel)
        {
            List<AreaDetails> ObjStateList = new List<AreaDetails>();
            try
            {
                var paramList = new
                {
                    Chk = "State",
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<AreaDetails>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjStateList = Output.ToList();
                }
                return ObjStateList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<AreaDetails>> GetDistrictList(AreaDetails objLeaseAreaModel)
        {
            List<AreaDetails> ObjDistrictList = new List<AreaDetails>();
            try
            {
                var paramList = new
                {
                    Chk = "District",
                    StateID = objLeaseAreaModel.StateId
                };
                DynamicParameters param = new DynamicParameters();

                var Output = await Connection.QueryAsync<AreaDetails>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {
                    ObjDistrictList = Output.ToList();
                }
                return ObjDistrictList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Tehsil List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<AreaDetails>> GetTehsilList(AreaDetails objLeaseAreaModel)
        {
            List<AreaDetails> ObjTehsilList = new List<AreaDetails>();
            try
            {
                var paramList = new
                {
                    DistrictID = objLeaseAreaModel.DistrictId,
                    chk = "8"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<AreaDetails>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjTehsilList = Output.ToList();
                }
                return ObjTehsilList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Village List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<AreaDetails>> GetVillageList(AreaDetails objLeaseAreaModel)
        {
            List<AreaDetails> ObjVillageList = new List<AreaDetails>();
            try
            {
                var paramList = new
                {
                    TehsilID = objLeaseAreaModel.TehsilID,
                    chk = "9"
                };
                DynamicParameters param = new DynamicParameters();

                var Output = await Connection.QueryAsync<AreaDetails>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    ObjVillageList = Output.ToList();
                }

                return ObjVillageList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Bind Land Type List
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<AreaDetails>> GetLandTypeList(AreaDetails objLeaseAreaModel)
        {
            List<AreaDetails> ObjStateList = new List<AreaDetails>();
            try
            {
                var paramList = new
                {
                    Chk = "LandType",
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<AreaDetails>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjStateList = Output.ToList();
                }
                return ObjStateList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Get Area Details
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public async Task<LicenseeResult> GetAreaDetails(AreaDetails areaDetails)
        {
            LicenseeResult UserInfo = new LicenseeResult();
            try
            {
                var paramList = new
                {
                    CHECK = "2",
                    CREATED_BY = areaDetails.UserID,
                };
                var result = await Connection.QueryAsync<AreaDetails>("USP_LICENSEE_AREA_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.AreaDetalsList = result.ToList();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        /// <summary>
        /// To Add New Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public MessageEF NewAreaetail(AreaDetails areaDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 1);
                p.Add("CREATED_BY", areaDetails.UserID);
                p.Add("USER_LOGIN_ID", areaDetails.UserLoginId);
                p.Add("STATE_ID", areaDetails.StateId);
                p.Add("DISTRICT_ID", areaDetails.DistrictId); ;
                p.Add("VILLAGE_ID", areaDetails.VillageID);
                p.Add("TehsilID", areaDetails.TehsilID);
                p.Add("BLOCK_FOREST_RANG", areaDetails.BLOCK_FOREST_RANG);
                p.Add("PIN_CODE", areaDetails.PIN_CODE);
                p.Add("LAND_ID", areaDetails.LAND_ID);
                p.Add("AREA_IN_HECT", areaDetails.AREA_IN_HECT);
                p.Add("COORDINATES_NO", areaDetails.COORDINATES_NO);
                p.Add("POLICE_STATION", areaDetails.POLICE_STATION);
                p.Add("GRAM_PANCHAYAT", areaDetails.GRAM_PANCHAYAT);
                p.Add("GRAM_PANCHAYAT", areaDetails.GRAM_PANCHAYAT);
                p.Add("STATUS", areaDetails.STATUS);
                p.Add("ATTACHMENT_PATH", areaDetails.ATTACHMENT_PATH);
                p.Add("FILE_ATTACHMENT", areaDetails.FILE_ATTACHMENT);
                p.Add("DEMARCATION_REPORT_PATH", areaDetails.DEMARCATION_REPORT_PATH);
                p.Add("FILE_DEMARCATION_REPORT", areaDetails.FILE_DEMARCATION_REPORT);
                p.Add("FILE_DEMARCATION_REPORT", areaDetails.FILE_DEMARCATION_REPORT);
                p.Add("REMARKS", areaDetails.Remarks);
                p.Add("Longitude", areaDetails.Longitude);
                p.Add("Latitude", areaDetails.Latitude);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<CTEDetails>("USP_LICENSEE_AREA_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT"); ;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Update Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public MessageEF UpdateAreaDetail(AreaDetails areaDetails)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 3);
                p.Add("CREATED_BY", areaDetails.UserID);
                p.Add("CREATED_BY", areaDetails.CREATED_BY);
                p.Add("LICENSEE_AREA_DETAIL_ID", areaDetails.LICENSEE_AREA_DETAIL_ID);
                p.Add("USER_LOGIN_ID", areaDetails.UserLoginId);
                p.Add("STATE_ID", areaDetails.StateId);
                p.Add("DISTRICT_ID", areaDetails.DistrictId); ;
                p.Add("VILLAGE_ID", areaDetails.VillageID);
                p.Add("TehsilID", areaDetails.TehsilID);
                p.Add("BLOCK_FOREST_RANG", areaDetails.BLOCK_FOREST_RANG);
                p.Add("PIN_CODE", areaDetails.PIN_CODE);
                p.Add("LAND_ID", areaDetails.LAND_ID);
                p.Add("AREA_IN_HECT", areaDetails.AREA_IN_HECT);
                p.Add("COORDINATES_NO", areaDetails.COORDINATES_NO);
                p.Add("POLICE_STATION", areaDetails.POLICE_STATION);
                p.Add("GRAM_PANCHAYAT", areaDetails.GRAM_PANCHAYAT);
                p.Add("TOPOSHEET_NO", areaDetails.TOPOSHEET_NO);
                p.Add("STATUS", areaDetails.STATUS);
                p.Add("ATTACHMENT_PATH", areaDetails.ATTACHMENT_PATH);
                p.Add("FILE_ATTACHMENT", areaDetails.FILE_ATTACHMENT);
                p.Add("DEMARCATION_REPORT_PATH", areaDetails.DEMARCATION_REPORT_PATH);
                p.Add("FILE_DEMARCATION_REPORT", areaDetails.FILE_DEMARCATION_REPORT);
                p.Add("FILE_DEMARCATION_REPORT", areaDetails.FILE_DEMARCATION_REPORT);
                p.Add("REMARKS", areaDetails.Remarks);
                p.Add("Longitude", areaDetails.Longitude);
                p.Add("Latitude", areaDetails.Latitude);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<CTEDetails>("USP_LICENSEE_AREA_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    messageEF.Satus = "1";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return messageEF;
        }
        /// <summary>
        /// To Approve Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public MessageEF ApproveAreaDetails(AreaDetails areaDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 4);
                p.Add("APPROVED_BY", areaDetails.UserID);
                p.Add("CREATED_BY", areaDetails.CREATED_BY);
                p.Add("LICENSEE_AREA_DETAIL_ID", areaDetails.LICENSEE_AREA_DETAIL_ID);
                p.Add("REMARKS", areaDetails.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_AREA_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Reject Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public MessageEF RejectAreaDetails(AreaDetails areaDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 5);
                p.Add("REJECTED_BY", areaDetails.UserID);
                p.Add("CREATED_BY", areaDetails.CREATED_BY);
                p.Add("LICENSEE_AREA_DETAIL_ID", areaDetails.LICENSEE_AREA_DETAIL_ID);
                p.Add("REMARKS", areaDetails.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_AREA_DETAILS", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To View Area Details to Authority
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewAreaDetailsAuthority(AreaDetails areaDetails)
        {
            List<ViewLicenseeDetailsAuthority> ListIBMDetails = new List<ViewLicenseeDetailsAuthority>();
            try
            {
                var paramList = new
                {
                    REQUEST = "AREA DETAILS",
                    UserID = areaDetails.UserID,
                };
                var result = Connection.Query<ViewLicenseeDetailsAuthority>("LICENSEE_PROFILE_APPROVAL_REQUEST_GRID", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListIBMDetails = result.ToList();
                }
                return ListIBMDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListIBMDetails = null;
            }
        }
        /// <summary>
        /// To Compare Area Details of Licensee 
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public List<AreaDetails> CompareAreaDetails(AreaDetails areaDetails)
        {
            List<AreaDetails> ListAreaDetails = new List<AreaDetails>();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 6);
                p.Add("CREATED_BY", areaDetails.UserID);
                var result = Connection.Query<AreaDetails>("USP_LICENSEE_AREA_DETAILS", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListAreaDetails = result.ToList();
                }
                return ListAreaDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListAreaDetails = null;
            }
        }
        public async Task<List<AreaDetails>> GetAreaDetailsLogDetails(AreaDetails model)
        {
            List<AreaDetails> ObjiBMDetailslog = new List<AreaDetails>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = model.CREATED_BY,
                    CHECK = 8
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<AreaDetails>("USP_LICENSEE_AREA_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjiBMDetailslog = result.ToList();
                }
                return ObjiBMDetailslog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF DeleteAreaDetails(AreaDetails areaDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 7);
                p.Add("CREATED_BY", areaDetails.CREATED_BY);
                p.Add("USER_LOGIN_ID", areaDetails.UserLoginId);
                p.Add("LICENSEE_AREA_DETAIL_ID", areaDetails.LICENSEE_AREA_DETAIL_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_AREA_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objMessage;
        }
        #endregion
        #region   LICENSEE OFFICE DETAILS
        public async Task<List<LicenseeDetails>> GetAssociationListDetails(LicenseeDetails licenseeDetails)
        {
            List<LicenseeDetails> objOfficemasterModelList = new List<LicenseeDetails>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LicenseeDetails>("[USP_GET_COMPANY_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objOfficemasterModelList = result.ToList();
                }
                return objOfficemasterModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<LicenseeResult> GetLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            LicenseeResult UserInfo = new LicenseeResult();
            try
            {
                var paramList = new
                {
                    CHECK = "2",
                    CREATED_BY = licenseeDetails.UserID,
                };
                var result = await Connection.QueryAsync<LicenseeDetails>("USP_LICENSEE_DETAILS_OFFICE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.LicesenseeOfficeDetailsList = result.ToList();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        public MessageEF NewLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 1);
                p.Add("CREATED_BY", licenseeDetails.UserID);
                p.Add("USER_LOGIN_ID", licenseeDetails.UserLoginId);
                p.Add("CategoryOLicensee", licenseeDetails.CategoryOfLicensee);
                p.Add("FirmAs", licenseeDetails.FirmAs);
                p.Add("CompanyAs", licenseeDetails.CompanyAs);
                p.Add("CompanyId", licenseeDetails.CompanyId);

                p.Add("CORPORATE_NAME_PREFIX", licenseeDetails.CORPORATE_NAME_PREFIX);
                p.Add("CORPORATE_NAME", licenseeDetails.CORPORATE_NAME);
                p.Add("CORPORATE_ADDRESS", licenseeDetails.CORPORATE_ADDRESS);
                p.Add("CORPORATE_CONTACT_DETAILS", licenseeDetails.CORPORATE_CONTACT_DETAILS1);
                p.Add("CORPORATE_LANDLINE_NO", licenseeDetails.CORPORATE_LANDLINE_NO);
                p.Add("CORPORATE_DESIGNATION", licenseeDetails.CORPORATE_DESIGNATION);
                p.Add("CORPORATE_MAIL_ID", licenseeDetails.CORPORATE_MAIL_ID);

                p.Add("SITE_NAME_PREFIX", licenseeDetails.SITE_NAME_PREFIX);
                p.Add("SITE_NAME", licenseeDetails.SITE_NAME);
                p.Add("SITE_ADDRESS", licenseeDetails.SITE_ADDRESS);
                p.Add("SITE_CONTACT_DETAILS", licenseeDetails.SITE_CONTACT_DETAILS1);
                p.Add("SITE_LANDLINE_NO", licenseeDetails.SITE_LANDLINE_NO);
                p.Add("SITE_DESIGNATION", licenseeDetails.SITE_DESIGNATION);
                p.Add("SITE_MAIL_ID", licenseeDetails.SITE_MAIL_ID);

                p.Add("SECONDARY_SITE_NAME_PREFIX", licenseeDetails.SECONDARY_SITE_NAME_PREFIX);
                p.Add("SECONDARY_SITE_NAME", licenseeDetails.SECONDARY_SITE_NAME);
                p.Add("SECONDARY_SITE_ADDRESS", licenseeDetails.SECONDARY_SITE_ADDRESS);
                p.Add("SECONDARY_SITE_CONTACT_DETAILS", licenseeDetails.SECONDARY_SITE_CONTACT_DETAILS);
                p.Add("SECONDARY_SITE_LANDLINE_NO", licenseeDetails.SECONDARY_SITE_LANDLINE_NO);
                p.Add("SECONDARY_SITE_DESIGNATION", licenseeDetails.SECONDARY_SITE_DESIGNATION);
                p.Add("SECONDARY_SITE_MAIL_ID", licenseeDetails.SECONDARY_SITE_MAIL_ID);

                p.Add("BRANCH_NAME_PREFIX", licenseeDetails.BRANCH_NAME_PREFIX);
                p.Add("BRANCH_NAME", licenseeDetails.BRANCH_NAME);
                p.Add("BRANCH_ADDRESS", licenseeDetails.BRANCH_ADDRESS);
                p.Add("BRANCH_CONTACT_DETAILS", licenseeDetails.BRANCH_CONTACT_DETAILS1);
                p.Add("BRANCH_LANDLINE_NO", licenseeDetails.BRANCH_LANDLINE_NO);
                p.Add("BRANCH_DESIGNATION", licenseeDetails.BRANCH_DESIGNATION);
                p.Add("BRANCH_MAIL_ID", licenseeDetails.BRANCH_MAIL_ID);

                p.Add("AGENT_NAME_PREFIX", licenseeDetails.AGENT_NAME_PREFIX);
                p.Add("AGENT_NAME", licenseeDetails.AGENT_NAME);
                p.Add("AGENT_ADDRESS", licenseeDetails.AGENT_ADDRESS);
                p.Add("AGENT_CONTACT_DETAILS", licenseeDetails.AGENT_CONTACT_DETAILS1);
                p.Add("AGENT_LANDLINE_NO", licenseeDetails.AGENT_LANDLINE_NO);
                p.Add("AGENT_DESIGNATION", licenseeDetails.AGENT_DESIGNATION);
                p.Add("AGENT_MAIL_ID", licenseeDetails.AGENT_MAIL_ID);
                p.Add("LETTER_OF_APPOINTMENT_OF_AGENT_PATH", licenseeDetails.LETTER_OF_APPOINTMENT_OF_AGENT_PATH);
                p.Add("FILE_LETTER_OF_APPOINTMENT_OF_AGENT", licenseeDetails.FILE_LETTER_OF_APPOINTMENT_OF_AGENT);
                p.Add("STATUS", licenseeDetails.STATUS);
                p.Add("REMARKS", licenseeDetails.Remarks);

                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<CTEDetails>("USP_LICENSEE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT"); ;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public MessageEF UpdateLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 3);
                p.Add("LICENSEE_DETAIL_ID", licenseeDetails.LICENSEE_DETAIL_ID);
                p.Add("CREATED_BY", licenseeDetails.UserID);
                p.Add("USER_LOGIN_ID", licenseeDetails.UserLoginId);
                p.Add("CategoryOLicensee", licenseeDetails.CategoryOfLicensee);
                p.Add("FirmAs", licenseeDetails.FirmAs);
                p.Add("CompanyAs", licenseeDetails.CompanyAs);
                p.Add("CompanyId", licenseeDetails.CompanyId);

                p.Add("CORPORATE_NAME_PREFIX", licenseeDetails.CORPORATE_NAME_PREFIX);
                p.Add("CORPORATE_NAME", licenseeDetails.CORPORATE_NAME);
                p.Add("CORPORATE_ADDRESS", licenseeDetails.CORPORATE_ADDRESS);
                p.Add("CORPORATE_CONTACT_DETAILS", licenseeDetails.CORPORATE_CONTACT_DETAILS1);
                p.Add("CORPORATE_LANDLINE_NO", licenseeDetails.CORPORATE_LANDLINE_NO);
                p.Add("CORPORATE_DESIGNATION", licenseeDetails.CORPORATE_DESIGNATION);
                p.Add("CORPORATE_MAIL_ID", licenseeDetails.CORPORATE_MAIL_ID);

                p.Add("SITE_NAME_PREFIX", licenseeDetails.SITE_NAME_PREFIX);
                p.Add("SITE_NAME", licenseeDetails.SITE_NAME);
                p.Add("SITE_ADDRESS", licenseeDetails.SITE_ADDRESS);
                p.Add("SITE_CONTACT_DETAILS", licenseeDetails.SITE_CONTACT_DETAILS1);
                p.Add("SITE_LANDLINE_NO", licenseeDetails.SITE_LANDLINE_NO);
                p.Add("SITE_DESIGNATION", licenseeDetails.SITE_DESIGNATION);
                p.Add("SITE_MAIL_ID", licenseeDetails.SITE_MAIL_ID);

                p.Add("SECONDARY_SITE_NAME_PREFIX", licenseeDetails.SECONDARY_SITE_NAME_PREFIX);
                p.Add("SECONDARY_SITE_NAME", licenseeDetails.SECONDARY_SITE_NAME);
                p.Add("SECONDARY_SITE_ADDRESS", licenseeDetails.SECONDARY_SITE_ADDRESS);
                p.Add("SECONDARY_SITE_CONTACT_DETAILS", licenseeDetails.SECONDARY_SITE_CONTACT_DETAILS);
                p.Add("SECONDARY_SITE_LANDLINE_NO", licenseeDetails.SECONDARY_SITE_LANDLINE_NO);
                p.Add("SECONDARY_SITE_DESIGNATION", licenseeDetails.SECONDARY_SITE_DESIGNATION);
                p.Add("SECONDARY_SITE_MAIL_ID", licenseeDetails.SECONDARY_SITE_MAIL_ID);

                p.Add("BRANCH_NAME_PREFIX", licenseeDetails.BRANCH_NAME_PREFIX);
                p.Add("BRANCH_NAME", licenseeDetails.BRANCH_NAME);
                p.Add("BRANCH_ADDRESS", licenseeDetails.BRANCH_ADDRESS);
                p.Add("BRANCH_CONTACT_DETAILS", licenseeDetails.BRANCH_CONTACT_DETAILS1);
                p.Add("BRANCH_LANDLINE_NO", licenseeDetails.BRANCH_LANDLINE_NO);
                p.Add("BRANCH_DESIGNATION", licenseeDetails.BRANCH_DESIGNATION);
                p.Add("BRANCH_MAIL_ID", licenseeDetails.BRANCH_MAIL_ID);

                p.Add("AGENT_NAME_PREFIX", licenseeDetails.AGENT_NAME_PREFIX);
                p.Add("AGENT_NAME", licenseeDetails.AGENT_NAME);
                p.Add("AGENT_ADDRESS", licenseeDetails.AGENT_ADDRESS);
                p.Add("AGENT_CONTACT_DETAILS", licenseeDetails.AGENT_CONTACT_DETAILS1);
                p.Add("AGENT_LANDLINE_NO", licenseeDetails.AGENT_LANDLINE_NO);
                p.Add("AGENT_DESIGNATION", licenseeDetails.AGENT_DESIGNATION);
                p.Add("AGENT_MAIL_ID", licenseeDetails.AGENT_MAIL_ID);
                p.Add("LETTER_OF_APPOINTMENT_OF_AGENT_PATH", licenseeDetails.LETTER_OF_APPOINTMENT_OF_AGENT_PATH);
                p.Add("FILE_LETTER_OF_APPOINTMENT_OF_AGENT", licenseeDetails.FILE_LETTER_OF_APPOINTMENT_OF_AGENT);
                p.Add("STATUS", licenseeDetails.STATUS);
                p.Add("REMARKS", licenseeDetails.Remarks);

                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<CTEDetails>("USP_LICENSEE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT"); ;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public MessageEF ApproveLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 4);
                p.Add("APPROVED_BY", licenseeDetails.UserID);
                p.Add("CREATED_BY", licenseeDetails.CREATED_BY);
                p.Add("LICENSEE_DETAIL_ID", licenseeDetails.LICENSEE_DETAIL_ID);
                p.Add("REMARKS", licenseeDetails.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public MessageEF RejectLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 5);
                p.Add("REJECTED_BY", licenseeDetails.UserID);
                p.Add("CREATED_BY", licenseeDetails.CREATED_BY);
                p.Add("LICENSEE_DETAIL_ID", licenseeDetails.LICENSEE_DETAIL_ID);
                p.Add("REMARKS", licenseeDetails.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else if(response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public MessageEF DeleteLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 7);
                p.Add("CREATED_BY", licenseeDetails.CREATED_BY);
                p.Add("USER_LOGIN_ID", licenseeDetails.UserLoginId);
                p.Add("LICENSEE_DETAIL_ID", licenseeDetails.LICENSEE_DETAIL_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objMessage;
        }
        public List<ViewLicenseeDetailsAuthority> ViewLicenseeOfficeDetailsAuthority(LicenseeDetails licenseeDetails)
        {
            List<ViewLicenseeDetailsAuthority> ListIBMDetails = new List<ViewLicenseeDetailsAuthority>();
            try
            {
                var paramList = new
                {
                    REQUEST = "Office Details",
                    UserID = licenseeDetails.UserID,
                };
                var result = Connection.Query<ViewLicenseeDetailsAuthority>("LICENSEE_PROFILE_APPROVAL_REQUEST_GRID", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListIBMDetails = result.ToList();
                }
                return ListIBMDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListIBMDetails = null;
            }
        }
        /// <summary>
        /// To Compare Area Details of Licensee 
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public List<LicenseeDetails> CompareLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            List<LicenseeDetails> ListLicenseeDetails = new List<LicenseeDetails>();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 6);
                p.Add("CREATED_BY", licenseeDetails.UserID);
                var result = Connection.Query<LicenseeDetails>("USP_LICENSEE_DETAILS_OFFICE", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListLicenseeDetails = result.ToList();
                }
                return ListLicenseeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListLicenseeDetails = null;
            }
        }
        public async Task<List<LicenseeDetails>> GetLicenseeOfficeLogDetails(LicenseeDetails licenseeDetails)
        {
            List<LicenseeDetails> ObjLicenseeOfficeDetailslog = new List<LicenseeDetails>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = licenseeDetails.CREATED_BY,
                    CHECK = 8
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LicenseeDetails>("USP_LICENSEE_DETAILS_OFFICE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLicenseeOfficeDetailslog = result.ToList();
                }
                return ObjLicenseeOfficeDetailslog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Application Details
        //#region Binddropdowns
        ///// <summary>
        ///// To bind Mineral Category details in view
        ///// </summary>
        ///// <param name="objLesseeMineralInformationModel"></param>
        ///// <returns></returns>
        //public async Task<List<ApplicationDetails>> GetMineralCategoryDetails(ApplicationDetails applicationDetails)
        //{
        //    List<ApplicationDetails> ObjMineralTypeDetails = new List<ApplicationDetails>();
        //    try
        //    {
        //        var paramList = new
        //        {
        //        };
        //        DynamicParameters param = new DynamicParameters();
        //        var result = await Connection.QueryAsync<ApplicationDetails>("[USP_GET_MINERALTYPE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
        //        if (result.Count() > 0)
        //        {
        //            ObjMineralTypeDetails = result.ToList();
        //        }
        //        return ObjMineralTypeDetails;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// To bind Mineral Name details in view
        ///// </summary>
        ///// <param name="objLesseeMineralInformationModel"></param>
        ///// <returns></returns>
        //public async Task<List<ApplicationDetails>> GetMineralNameDetails(ApplicationDetails applicationDetails)
        //{
        //    List<ApplicationDetails> ObjMineralNameDetails = new List<ApplicationDetails>();
        //    try
        //    {
        //        var paramList = new
        //        {
        //            UserId = applicationDetails.CREATED_BY,
        //            //MineralTypeId = applicationDetails.MINERAL_CATEGORY_ID  MineralTypeIDList
        //            MineralTypeIDList = applicationDetails.MINERAL_CATEGORY_ID
        //        };
        //        DynamicParameters param = new DynamicParameters(); //[uspGetMineralNameFromMineralType]
        //        var result = await Connection.QueryAsync<ApplicationDetails>("uspGetMineralFromMineralTypeList", paramList, commandType: System.Data.CommandType.StoredProcedure);
        //        if (result.Count() > 0)
        //        {
        //            ObjMineralNameDetails = result.ToList();
        //        }
        //        return ObjMineralNameDetails;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// To bind Mineral Form details in view
        ///// </summary>
        ///// <param name="objLesseeMineralInformationModel"></param>
        ///// <returns></returns>
        //public async Task<List<ApplicationDetails>> GetMineralFormDetails(ApplicationDetails objLesseeMineralInformationModel)
        //{
        //    List<ApplicationDetails> ObjMineralNameDetails = new List<ApplicationDetails>();
        //    try
        //    {
        //        var paramList = new
        //        {
        //            UserId = objLesseeMineralInformationModel.CREATED_BY,
        //            MineralIdList = objLesseeMineralInformationModel.MineralIdList,
        //            Check = 2
        //        };
        //        DynamicParameters param = new DynamicParameters();
        //        var result = await Connection.QueryAsync<ApplicationDetails>("[uspGetMineralNature_GradeFromMineral]", paramList, commandType: System.Data.CommandType.StoredProcedure);
        //        if (result.Count() > 0)
        //        {
        //            ObjMineralNameDetails = result.ToList();
        //        }
        //        return ObjMineralNameDetails;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// To bind Mineral Grade details in view
        ///// </summary>
        ///// <param name="objLesseeMineralInformationModel"></param>
        ///// <returns></returns>
        //public async Task<List<ApplicationDetails>> GetMineralGradeDetails(ApplicationDetails objLesseeMineralInformationModel)
        //{
        //    List<ApplicationDetails> ObjMineralNameDetails = new List<ApplicationDetails>();
        //    try
        //    {
        //        var paramList = new
        //        {
        //            UserId = objLesseeMineralInformationModel.CREATED_BY,
        //            MineralIdList = objLesseeMineralInformationModel.MineralIdList,
        //            MineralNatureId = objLesseeMineralInformationModel.MineralNatureId,
        //            CHECK = 3
        //        };
        //        DynamicParameters param = new DynamicParameters();
        //        var result = await Connection.QueryAsync<ApplicationDetails>("[uspGetMineralNature_GradeFromMineral]", paramList, commandType: System.Data.CommandType.StoredProcedure);
        //        if (result.Count() > 0)
        //        {
        //            ObjMineralNameDetails = result.ToList();
        //        }
        //        return ObjMineralNameDetails;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion
        public async Task<LicenseeResult> GetMineralUnit(ApplicationDetails applicationDetails)
        {
            LicenseeResult UserInfo = new LicenseeResult();
            try
            {
                var paramList = new
                {
                    CHECK = "10",
                };
                var result = await Connection.QueryAsync<ApplicationDetails>("USP_LICENSEE_APPLICATION_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.ApplicationDetailsList = result.ToList();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        public async Task<LicenseeResult> GetLicenseeType(ApplicationDetails applicationDetails)
        {
            LicenseeResult UserInfo = new LicenseeResult();
            try
            {
                var paramList = new
                {
                    CHECK = "11",
                };
                var result = await Connection.QueryAsync<ApplicationDetails>("USP_LICENSEE_APPLICATION_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.ApplicationDetailsList = result.ToList();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        public async Task<LicenseeResult> GetLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            LicenseeResult UserInfo = new LicenseeResult();
            try
            {
                var paramList = new
                {
                    CHECK = "2",
                    CREATED_BY = applicationDetails.UserID,
                };
                var result = await Connection.QueryAsync<ApplicationDetails>("USP_LICENSEE_APPLICATION_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.ApplicationDetailsList = result.ToList();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        public MessageEF NewLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 1);
                p.Add("CREATED_BY", applicationDetails.CREATED_BY);
                p.Add("USER_LOGIN_ID", applicationDetails.UserLoginId);
                p.Add("STORAGE_CAPACITY", applicationDetails.STORAGE_CAPACITY);
                p.Add("UnitId", applicationDetails.UnitId);
                p.Add("APPLICATION_NUMBER", applicationDetails.APPLICATION_NUMBER);
                p.Add("FILE_APPLICATION_COPY", applicationDetails.FILE_APPLICATION_FORM_COPY);
                p.Add("APPLICATION_COPY_PATH", applicationDetails.APPLICATION_FORM_COPY_PATH);
                p.Add("PAN_CARD_NO", applicationDetails.PAN_CARD_NO);
                p.Add("PAN_CARD_PATH", applicationDetails.PAN_CARD_PATH);
                p.Add("FILE_PAN_CARD", applicationDetails.FILE_PAN_CARD);
                p.Add("ADHAR_CARD_NO", applicationDetails.ADHAR_CARD_NO);
                p.Add("ADHAR_CARD_PATH", applicationDetails.ADHAR_CARD_PATH);
                p.Add("FILE_ADHAR_CARD", applicationDetails.FILE_ADHAR_CARD);
                p.Add("TIN_CARD_NO", applicationDetails.TIN_CARD_NO);
                p.Add("TIN_CARD_PATH", applicationDetails.TIN_CARD_PATH);
                p.Add("FILE_TIN_CARD", applicationDetails.FILE_TIN_CARD);

                p.Add("FIRM_REGISTRATION_DEED_NO", applicationDetails.FIRM_REGISTRATION_DEED_NO);
                p.Add("FILE_FIRM_REGISTRATION_DEED", applicationDetails.FILE_FIRM_REGISTRATION_DEED);
                p.Add("FIRM_REGISTRATION_DEED_PATH", applicationDetails.FIRM_REGISTRATION_DEED_PATH);

                p.Add("CERTIFICATE_OF_INCORPORATION_NO", applicationDetails.CERTIFICATE_OF_INCORPORATION_NO);
                p.Add("FILE_CERTIFICATE_OF_INCORPORATION", applicationDetails.FILE_CERTIFICATE_OF_INCORPORATION);
                p.Add("CERTIFICATE_OF_INCORPORATION_PATH", applicationDetails.CERTIFICATE_OF_INCORPORATION_PATH);
                p.Add("APPLICATION_TYPE_ID", applicationDetails.APPLICATION_TYPE_ID);
                p.Add("FILE_POWER_OF_ATORNY", applicationDetails.FILE_POWER_OF_ATORNY);
                p.Add("POWER_OF_ATORNY_PATH", applicationDetails.POWER_OF_ATORNY_PATH);
                p.Add("FILE_AFFIDAVITS_MINING_DUE", applicationDetails.FILE_AFFIDAVITS_MINING_DUE);
                p.Add("AFFIDAVITS_MINING_DUE_PATH", applicationDetails.AFFIDAVITS_MINING_DUE_PATH);
                p.Add("FILE_KHASARA_PANCHSALA", applicationDetails.FILE_KHASARA_PANCHSALA);
                p.Add("KHASARA_PANCHSALA_PATH", applicationDetails.KHASARA_PANCHSALA_PATH);
                p.Add("FILE_MAP_PLAN_OF_APPLIED_AREA", applicationDetails.FILE_MAP_PLAN_OF_APPLIED_AREA);
                p.Add("MAP_PLAN_OF_APPLIED_AREA_PATH", applicationDetails.MAP_PLAN_OF_APPLIED_AREA_PATH);
                p.Add("FILE_FOREST_REPORT", applicationDetails.FILE_FOREST_REPORT);
                p.Add("FOREST_REPORT_PATH", applicationDetails.FOREST_REPORT_PATH);
                p.Add("FILE_REVENUE_OFFICER_REPORT", applicationDetails.FILE_REVENUE_OFFICER_REPORT);
                p.Add("REVENUE_OFFICER_REPORT_PATH", applicationDetails.REVENUE_OFFICER_REPORT_PATH);
                p.Add("FILE_SPOT_INSPECTION_AND_ANALYSIS_REPORT", applicationDetails.FILE_SPOT_INSPECTION_AND_ANALYSIS_REPORT);
                p.Add("SPOT_INSPECTION_AND_ANALYSIS_REPORT_PATH", applicationDetails.SPOT_INSPECTION_AND_ANALYSIS_REPORT_PATH);
                p.Add("FILE_MININIG_INSPECTOR_REPORT", applicationDetails.FILE_MININIG_INSPECTOR_REPORT);
                p.Add("MINING_INSPECTOR_REPORT_PATH", applicationDetails.MINING_INSPECTOR_REPORT_PATH);
                p.Add("FILE_GRAM_PANCHAYAT_PROPOSAL", applicationDetails.FILE_GRAM_PANCHAYAT_PROPOSAL);
                p.Add("GRAM_PANCHAYAT_PROPOSAL_PATH", applicationDetails.GRAM_PANCHAYAT_PROPOSAL_PATH);

                p.Add("APPLICATION_FEES", applicationDetails.APPLICATION_FEES);
                p.Add("APPLICATION_FEES_DATE", applicationDetails.APPLICATION_FEES_DATE);
                p.Add("FILE_APPLICATION_FEES_CHALLAN", applicationDetails.FILE_APPLICATION_FEES_CHALLAN);
                p.Add("APPLICATION_FEES_CHALLAN_PATH", applicationDetails.APPLICATION_FEES_CHALLAN_PATH);
                p.Add("CHALLAN_DD_AMOUNT", applicationDetails.CHALLAN_DD_AMOUNT);
                p.Add("CHALLAN_DD_DATE", applicationDetails.CHALLAN_DD_DATE);
                p.Add("FILE_CHALLAN_DD", applicationDetails.FILE_CHALLAN_DD);
                p.Add("CHALLAN_DD_PATH", applicationDetails.CHALLAN_DD_PATH);
                p.Add("BANK_GUARRANTEE_AMOUNT", applicationDetails.BANK_GUARRANTEE_AMOUNT);
                p.Add("BANK_GUARRANTEE_DATE", applicationDetails.BANK_GUARRANTEE_DATE);
                p.Add("FILE_BANK_GUARRANTEE", applicationDetails.FILE_BANK_GUARRANTEE);
                p.Add("BANK_GUARRANTEE_PATH", applicationDetails.BANK_GUARRANTEE_PATH);
                p.Add("SURETY_BOND_AMOUNT", applicationDetails.SURETY_BOND_AMOUNT);
                p.Add("SURETY_BOND_DATE", applicationDetails.SURETY_BOND_DATE);
                p.Add("FILE_SURETY_BOND", applicationDetails.FILE_SURETY_BOND);
                p.Add("SURETY_BOND_PATH", applicationDetails.SURETY_BOND_PATH);
                p.Add("FILE_FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE", applicationDetails.FILE_FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE);
                p.Add("FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_PATH", applicationDetails.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_PATH);

                p.Add("DateOfRenewal", applicationDetails.DateOfRenewal);
                p.Add("RenewalGrantOrderCopy_FILE", applicationDetails.Renewal_GrantOrderCopy_File);
                p.Add("RenewalGrantOrderCopy_PATH", applicationDetails.Renewal_GrantOrderCopy_Path);
                p.Add("PeriodOfRenewalFrom", applicationDetails.PeriodOfRenewalFrom);
                p.Add("PeriodOfRenewalTo", applicationDetails.PeriodOfRenewalTo);

                p.Add("NameOfTransferee", applicationDetails.NameOfTransferee);
                p.Add("AddressOfTransferee", applicationDetails.AddressOfTransferee);
                p.Add("TransferGrantOrderCopy_FILE", applicationDetails.Transfer_GrantOrderCopy_File);
                p.Add("TransferGrantOrderCopy_PATH", applicationDetails.Transfer_GrantOrderCopy_Path);
                p.Add("TransferLeaseDeedCopy_FILE", applicationDetails.Transfer_LeaseDeedCopy_File);
                p.Add("TransferLeaseDeedCopy_PATH", applicationDetails.Transfer_LeaseDeedCopy_Path);

                p.Add("STATUS", applicationDetails.STATUS);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<CTEDetails>("USP_LICENSEE_APPLICATION_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT"); ;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public MessageEF UpdateLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 3);
                p.Add("LICENSEE_APPLICATION_ID", applicationDetails.LICENSEE_APPLICATION_ID);
                p.Add("CREATED_BY", applicationDetails.CREATED_BY);
                p.Add("USER_LOGIN_ID", applicationDetails.UserLoginId);
                p.Add("STORAGE_CAPACITY", applicationDetails.STORAGE_CAPACITY);
                p.Add("UnitId", applicationDetails.UnitId);
                p.Add("APPLICATION_NUMBER", applicationDetails.APPLICATION_NUMBER);
                p.Add("FILE_APPLICATION_COPY", applicationDetails.FILE_APPLICATION_FORM_COPY);
                p.Add("APPLICATION_COPY_PATH", applicationDetails.APPLICATION_FORM_COPY_PATH);
                p.Add("PAN_CARD_NO", applicationDetails.PAN_CARD_NO);
                p.Add("PAN_CARD_PATH", applicationDetails.PAN_CARD_PATH);
                p.Add("FILE_PAN_CARD", applicationDetails.FILE_PAN_CARD);
                p.Add("ADHAR_CARD_NO", applicationDetails.ADHAR_CARD_NO);
                p.Add("ADHAR_CARD_PATH", applicationDetails.ADHAR_CARD_PATH);
                p.Add("FILE_ADHAR_CARD", applicationDetails.FILE_ADHAR_CARD);
                p.Add("TIN_CARD_NO", applicationDetails.TIN_CARD_NO);
                p.Add("TIN_CARD_PATH", applicationDetails.TIN_CARD_PATH);
                p.Add("FILE_TIN_CARD", applicationDetails.FILE_TIN_CARD);

                p.Add("FIRM_REGISTRATION_DEED_NO", applicationDetails.FIRM_REGISTRATION_DEED_NO);
                p.Add("FILE_FIRM_REGISTRATION_DEED", applicationDetails.FILE_FIRM_REGISTRATION_DEED);
                p.Add("FIRM_REGISTRATION_DEED_PATH", applicationDetails.FIRM_REGISTRATION_DEED_PATH);

                p.Add("CERTIFICATE_OF_INCORPORATION_NO", applicationDetails.CERTIFICATE_OF_INCORPORATION_NO);
                p.Add("FILE_CERTIFICATE_OF_INCORPORATION", applicationDetails.FILE_CERTIFICATE_OF_INCORPORATION);
                p.Add("CERTIFICATE_OF_INCORPORATION_PATH", applicationDetails.CERTIFICATE_OF_INCORPORATION_PATH);
                p.Add("APPLICATION_TYPE_ID", applicationDetails.APPLICATION_TYPE_ID);
                p.Add("FILE_POWER_OF_ATORNY", applicationDetails.FILE_POWER_OF_ATORNY);
                p.Add("POWER_OF_ATORNY_PATH", applicationDetails.POWER_OF_ATORNY_PATH);
                p.Add("FILE_AFFIDAVITS_MINING_DUE", applicationDetails.FILE_AFFIDAVITS_MINING_DUE);
                p.Add("AFFIDAVITS_MINING_DUE_PATH", applicationDetails.AFFIDAVITS_MINING_DUE_PATH);
                p.Add("FILE_KHASARA_PANCHSALA", applicationDetails.FILE_KHASARA_PANCHSALA);
                p.Add("KHASARA_PANCHSALA_PATH", applicationDetails.KHASARA_PANCHSALA_PATH);
                p.Add("FILE_MAP_PLAN_OF_APPLIED_AREA", applicationDetails.FILE_MAP_PLAN_OF_APPLIED_AREA);
                p.Add("MAP_PLAN_OF_APPLIED_AREA_PATH", applicationDetails.MAP_PLAN_OF_APPLIED_AREA_PATH);
                p.Add("FILE_FOREST_REPORT", applicationDetails.FILE_FOREST_REPORT);
                p.Add("FOREST_REPORT_PATH", applicationDetails.FOREST_REPORT_PATH);
                p.Add("FILE_REVENUE_OFFICER_REPORT", applicationDetails.FILE_REVENUE_OFFICER_REPORT);
                p.Add("REVENUE_OFFICER_REPORT_PATH", applicationDetails.REVENUE_OFFICER_REPORT_PATH);
                p.Add("FILE_SPOT_INSPECTION_AND_ANALYSIS_REPORT", applicationDetails.FILE_SPOT_INSPECTION_AND_ANALYSIS_REPORT);
                p.Add("SPOT_INSPECTION_AND_ANALYSIS_REPORT_PATH", applicationDetails.SPOT_INSPECTION_AND_ANALYSIS_REPORT_PATH);
                p.Add("FILE_MININIG_INSPECTOR_REPORT", applicationDetails.FILE_MININIG_INSPECTOR_REPORT);
                p.Add("MINING_INSPECTOR_REPORT_PATH", applicationDetails.MINING_INSPECTOR_REPORT_PATH);
                p.Add("FILE_GRAM_PANCHAYAT_PROPOSAL", applicationDetails.FILE_GRAM_PANCHAYAT_PROPOSAL);
                p.Add("GRAM_PANCHAYAT_PROPOSAL_PATH", applicationDetails.GRAM_PANCHAYAT_PROPOSAL_PATH);

                p.Add("APPLICATION_FEES", applicationDetails.APPLICATION_FEES);
                p.Add("APPLICATION_FEES_DATE", applicationDetails.APPLICATION_FEES_DATE);
                p.Add("FILE_APPLICATION_FEES_CHALLAN", applicationDetails.FILE_APPLICATION_FEES_CHALLAN);
                p.Add("APPLICATION_FEES_CHALLAN_PATH", applicationDetails.APPLICATION_FEES_CHALLAN_PATH);
                p.Add("CHALLAN_DD_AMOUNT", applicationDetails.CHALLAN_DD_AMOUNT);
                p.Add("CHALLAN_DD_DATE", applicationDetails.CHALLAN_DD_DATE);
                p.Add("FILE_CHALLAN_DD", applicationDetails.FILE_CHALLAN_DD);
                p.Add("CHALLAN_DD_PATH", applicationDetails.CHALLAN_DD_PATH);
                p.Add("BANK_GUARRANTEE_AMOUNT", applicationDetails.BANK_GUARRANTEE_AMOUNT);
                p.Add("BANK_GUARRANTEE_DATE", applicationDetails.BANK_GUARRANTEE_DATE);
                p.Add("FILE_BANK_GUARRANTEE", applicationDetails.FILE_BANK_GUARRANTEE);
                p.Add("BANK_GUARRANTEE_PATH", applicationDetails.BANK_GUARRANTEE_PATH);
                p.Add("SURETY_BOND_AMOUNT", applicationDetails.SURETY_BOND_AMOUNT);
                p.Add("SURETY_BOND_DATE", applicationDetails.SURETY_BOND_DATE);
                p.Add("FILE_SURETY_BOND", applicationDetails.FILE_SURETY_BOND);
                p.Add("SURETY_BOND_PATH", applicationDetails.SURETY_BOND_PATH);
                p.Add("FILE_FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE", applicationDetails.FILE_FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE);
                p.Add("FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_PATH", applicationDetails.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_PATH);

                p.Add("DateOfRenewal", applicationDetails.DateOfRenewal);
                p.Add("RenewalGrantOrderCopy_FILE", applicationDetails.Renewal_GrantOrderCopy_File);
                p.Add("RenewalGrantOrderCopy_PATH", applicationDetails.Renewal_GrantOrderCopy_Path);
                p.Add("PeriodOfRenewalFrom", applicationDetails.PeriodOfRenewalFrom);
                p.Add("PeriodOfRenewalTo", applicationDetails.PeriodOfRenewalTo);

                p.Add("NameOfTransferee", applicationDetails.NameOfTransferee);
                p.Add("AddressOfTransferee", applicationDetails.AddressOfTransferee);
                p.Add("TransferGrantOrderCopy_FILE", applicationDetails.Transfer_GrantOrderCopy_File);
                p.Add("TransferGrantOrderCopy_PATH", applicationDetails.Transfer_GrantOrderCopy_Path);
                p.Add("TransferLeaseDeedCopy_FILE", applicationDetails.Transfer_LeaseDeedCopy_File);
                p.Add("DateOfTransfer", applicationDetails.DateOfTransfer);

                p.Add("STATUS", applicationDetails.STATUS);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<CTEDetails>("USP_LICENSEE_APPLICATION_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT"); ;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public MessageEF ApproveLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 4);
                p.Add("APPROVED_BY", applicationDetails.UserID);
                p.Add("CREATED_BY", applicationDetails.CREATED_BY); 
                p.Add("LICENSEE_APPLICATION_ID", applicationDetails.LICENSEE_APPLICATION_ID);
                p.Add("REMARKS", applicationDetails.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_APPLICATION_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public MessageEF RejectLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 4);
                p.Add("APPROVED_BY", applicationDetails.UserID);
                p.Add("LICENSEE_APPLICATION_ID", applicationDetails.LICENSEE_APPLICATION_ID);
                p.Add("REMARKS", applicationDetails.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_APPLICATION_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public MessageEF DeleteLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 7);
                p.Add("CREATED_BY", applicationDetails.CREATED_BY);
                p.Add("USER_LOGIN_ID", applicationDetails.UserLoginId);
                p.Add("LICENSEE_DETAIL_ID", applicationDetails.LICENSEE_APPLICATION_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEE_APPLICATION_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response.ToString() == "2")
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objMessage;
        }
        public List<ViewLicenseeDetailsAuthority> ViewLicenseeApplicationDetailsAuthority(ApplicationDetails applicationDetails)
        {
            List<ViewLicenseeDetailsAuthority> ListIBMDetails = new List<ViewLicenseeDetailsAuthority>();
            try
            {
                var paramList = new
                {
                    REQUEST = "APPLICATION DETAILS",
                    UserID = applicationDetails.UserID,
                };
                var result = Connection.Query<ViewLicenseeDetailsAuthority>("LICENSEE_PROFILE_APPROVAL_REQUEST_GRID", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListIBMDetails = result.ToList();
                }
                return ListIBMDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListIBMDetails = null;
            }
        }
        public List<ApplicationDetails> CompareLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            List<ApplicationDetails> ListLicenseeDetails = new List<ApplicationDetails>();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 6);
                p.Add("CREATED_BY", applicationDetails.CREATED_BY);
                var result = Connection.Query<ApplicationDetails>("USP_LICENSEE_APPLICATION_DETAILS", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListLicenseeDetails = result.ToList();
                }
                return ListLicenseeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListLicenseeDetails = null;
            }
        }
        public async Task<List<ApplicationDetails>> GetLicenseeApplicationLogDetails(ApplicationDetails applicationDetails)
        {
            List<ApplicationDetails> ObjLicenseeOfficeDetailslog = new List<ApplicationDetails>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = applicationDetails.CREATED_BY,
                    CHECK = 8
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<ApplicationDetails>("USP_LICENSEE_APPLICATION_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLicenseeOfficeDetailslog = result.ToList();
                }
                return ObjLicenseeOfficeDetailslog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Mineral Details
        #region Binddropdowns
        /// <summary>
        /// To bind Mineral Category details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralCategoryDetails(MineralDetails mineralDetails)
        {
            List<MineralDetails> ObjMineralTypeDetails = new List<MineralDetails>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MineralDetails>("[USP_GET_MINERALTYPE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralTypeDetails = result.ToList();
                }
                return ObjMineralTypeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Name details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralNameDetails(MineralDetails mineralDetails)
        {
            List<MineralDetails> ObjMineralNameDetails = new List<MineralDetails>();
            try
            {
                var paramList = new
                {
                    UserId = mineralDetails.CREATED_BY,
                    MineralTypeIDList = mineralDetails.MINERAL_CATEGORY_ID
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MineralDetails>("uspGetMineralFromMineralTypeList", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralNameDetails = result.ToList();
                }
                return ObjMineralNameDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Form details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralFormDetails(MineralDetails mineralDetails)
        {
            List<MineralDetails> ObjMineralNameDetails = new List<MineralDetails>();
            try
            {
                var paramList = new
                {
                    UserId = mineralDetails.CREATED_BY,
                    MineralIdList = mineralDetails.MineralIdList,
                    Check = 2
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MineralDetails>("uspGetMineralNature_GradeFromMineral", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralNameDetails = result.ToList();
                }
                return ObjMineralNameDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Grade details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralGradeDetails(MineralDetails mineralDetails)
        {
            List<MineralDetails> ObjMineralNameDetails = new List<MineralDetails>();
            try
            {
                var paramList = new
                {
                    UserId = mineralDetails.CREATED_BY,
                    MineralIdList = mineralDetails.MineralIdList,
                    MineralNatureId = mineralDetails.MineralNatureId,
                    CHECK = 3
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MineralDetails>("uspGetMineralNature_GradeFromMineral", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralNameDetails = result.ToList();
                }
                return ObjMineralNameDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        /// <summary>
        /// To bind Lessee Mineral Information details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<MineralDetails> GetMineralInformationDetails(MineralDetails mineralDetails)
        {
            MineralDetails ObjMineralInformationDetails = new MineralDetails();
            try
            {
                var paramList = new
                {
                    CREATED_BY = mineralDetails.CREATED_BY,
                    CHECK = "2"
                };
                DynamicParameters param = new DynamicParameters();//  USP_LESSEE_MINERAL_INFORMATION_OFFICE USP_LICENSEE_MINERAL_DETAILS
                var result = await Connection.QueryAsync<MineralDetails>("USP_LICENSEE_MINERAL_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralInformationDetails = result.FirstOrDefault();
                }
                return ObjMineralInformationDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Information Log History details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralInformationLogDetails(MineralDetails mineralDetails)
        {
            List<MineralDetails> ObjGrantOrderLogDetails = new List<MineralDetails>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = mineralDetails.CREATED_BY,
                    CHECK = "8"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MineralDetails>("USP_LICENSEE_MINERAL_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjGrantOrderLogDetails = result.ToList();
                }
                return ObjGrantOrderLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Information Compare details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralInformationCompareDetails(MineralDetails mineralDetails)
        {
            List<MineralDetails> mineralDetailsList = new List<MineralDetails>();
            try
            {
                var paramlist = new { CREATED_BY = mineralDetails.CREATED_BY, CHECK = "6" };
                DynamicParameters parameters = new DynamicParameters();
                var result = await Connection.QueryAsync<MineralDetails>("USP_LICENSEE_MINERAL_DETAILS", paramlist, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    mineralDetailsList = result.ToList();
                }
                return mineralDetailsList;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Licensee Mineral Information details
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public MessageEF UpdateMineralInformationDetails(MineralDetails mineralDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "3");
                p.Add("CREATED_BY", mineralDetails.CREATED_BY);
                p.Add("USER_LOGIN_ID", mineralDetails.UserLoginId);
                p.Add("LICENSEE_APPLICATION_ID", mineralDetails.LICENSEE_APPLICATION_ID);
                p.Add("MINERAL_CATEGORY_ID", mineralDetails.MINERAL_CATEGORY_ID);
                p.Add("MINERAL_ID", mineralDetails.MineralID);
                //p.Add("MINERAL_GRADE_ID", mineralDetails.MINERAL_GRADE_ID);
                string mineralid = "";
                string mineralFormId = "";
                string mineralGradeId = "";

                if (mineralDetails.MineralCount != null)
                {
                    if (mineralDetails.MineralCount.Count > 0)
                    {
                        for (int i = 0; i < mineralDetails.MineralCount.Count; i++)
                        {
                            mineralid += mineralDetails.MineralCount[i].ToString();
                            mineralid += ",";

                        }
                    }
                }
                if (mineralDetails.MineralFormCount != null)
                {
                    if (mineralDetails.MineralFormCount.Count > 0)
                    {
                        for (int i = 0; i < mineralDetails.MineralFormCount.Count; i++)
                        {
                            mineralFormId += mineralDetails.MineralFormCount[i].ToString();
                            mineralFormId += ",";
                        }
                    }
                }
                if (mineralDetails.MineralGradeCount != null)
                {
                    if (mineralDetails.MineralGradeCount.Count > 0)
                    {
                        for (int i = 0; i < mineralDetails.MineralGradeCount.Count; i++)
                        {
                            mineralGradeId += mineralDetails.MineralGradeCount[i].ToString();
                            mineralGradeId += ",";

                        }
                    }
                }
                p.Add("MINERAL_ID_LIST", mineralid);
                p.Add("MINERAL_FORMID_LIST", mineralFormId);
                p.Add("MINERAL_GRADEID_LIST", mineralGradeId);
                p.Add("STATUS", mineralDetails.STATUS);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_LICENSEE_MINERAL_DETAILS", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Approve Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public MessageEF ApproveMineralInformationDetails(MineralDetails mineralDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "4");
                p.Add("APPROVED_BY", mineralDetails.UserID);
                //p.Add("LICENSEE_APPLICATION_ID", mineralDetails.LICENSEE_APPLICATION_ID);
                p.Add("CREATED_BY", mineralDetails.CREATED_BY);
                p.Add("Remarks", mineralDetails.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_LICENSEE_MINERAL_DETAILS", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// To Reject Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public MessageEF RejectMineralInformationDetails(MineralDetails mineralDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "5");
                p.Add("REJECTED_BY", mineralDetails.UserID);
                //p.Add("LICENSEE_APPLICATION_ID", mineralDetails.LICENSEE_APPLICATION_ID);
                p.Add("CREATED_BY", mineralDetails.CREATED_BY);
                p.Add("Remarks", mineralDetails.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_LICENSEE_MINERAL_DETAILS", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// To Delete Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public MessageEF DeleteMineralInformationDetails(MineralDetails mineralDetails)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "7");
                p.Add("USER_LOGIN_ID", mineralDetails.CREATED_BY);
                p.Add("LICENSEE_APPLICATION_ID", mineralDetails.LICENSEE_APPLICATION_ID);
                p.Add("CREATED_BY", mineralDetails.CREATED_BY);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_LICENSEE_MINERAL_DETAILS", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
        public List<ViewLicenseeDetailsAuthority> ViewLicenseeMineralDetailsAuthority(MineralDetails mineralDetails)
        {
            List<ViewLicenseeDetailsAuthority> ListIBMDetails = new List<ViewLicenseeDetailsAuthority>();
            try
            {
                var paramList = new
                {
                    REQUEST = "Mineral Details",
                    UserID = mineralDetails.UserID, //30
                };
                var result = Connection.Query<ViewLicenseeDetailsAuthority>("LICENSEE_PROFILE_APPROVAL_REQUEST_GRID", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListIBMDetails = result.ToList();
                }
                return ListIBMDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListIBMDetails = null;
            }
        }
        #endregion
        #region Licensee Profile Details
        /// <summary>
        /// IBM Profile of Licensee
        /// </summary>
        /// <param name="viewIBMProfile"></param>
        /// <returns></returns>
        public async Task<ViewIBMProfile> GetIBMProfile(ViewIBMProfile viewIBMProfile)
        {
            ViewIBMProfile UserInfo = new ViewIBMProfile();
            try
            {
                var paramList = new
                {
                    CHECK = "10",
                    CREATED_BY = viewIBMProfile.CREATED_BY,
                };
                //DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<ViewIBMProfile>("USP_LICENSEE_PROFILE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.FirstOrDefault();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        public async Task<ProfileCount> GetProfileCount(ProfileCount profileCount)
        {
            ProfileCount UserInfo = new ProfileCount();
            try
            {
                var paramList = new
                {
                    //CHECK = "2",
                    USER_ID = profileCount.CREATED_BY,
                };
                //DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<ProfileCount>("LICENSEE_PROFILE_COMPLETION_COUNT", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.FirstOrDefault();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        public async Task<CTEProfile> GetCTEProfile(CTEProfile cTEProfile)
        {
            CTEProfile UserInfo = new CTEProfile();
            try
            {
                var paramList = new
                {
                    CHECK = 9,
                    CREATED_BY = cTEProfile.CREATED_BY,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<CTEProfile>("USP_LICENSEE_PROFILE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.FirstOrDefault();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return UserInfo;

        }
        public async Task<CTOProfile> GetCTOProfile(CTOProfile cTOProfile)
        {
            CTOProfile UserInfo = new CTOProfile();
            try
            {
                var paramList = new
                {
                    CHECK = 7,
                    CREATED_BY = cTOProfile.CREATED_BY,
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CTOProfile>("USP_LICENSEE_PROFILE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.FirstOrDefault();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { UserInfo = null; }
        }
        public async Task<GrantProfile> GetGrantProfile(GrantProfile grantProfile)
        {
            GrantProfile UserInfo = new GrantProfile();
            try
            {
                var paramList = new
                {
                    CHECK = 4,
                    CREATED_BY = grantProfile.CREATED_BY,
                };

                var result = await Connection.QueryAsync<GrantProfile>("USP_LICENSEE_PROFILE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserInfo;
        }
        public async Task<ECProfile> GetECProfile(ECProfile eCProfile)
        {
            ECProfile UserInfo = new ECProfile();
            try
            {
                var paramList = new
                {
                    CHECK = 11,
                    CREATED_BY = eCProfile.CREATED_BY,
                };
                var result = await Connection.QueryAsync<ECProfile>("USP_LICENSEE_PROFILE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.FirstOrDefault();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return UserInfo;
        }
        public async Task<AreaProfile> GetAreaProfile(AreaProfile areaProfile)
        {
            AreaProfile UserInfo = new AreaProfile();
            try
            {
                var paramList = new
                {
                    CHECK = "6",
                    CREATED_BY = areaProfile.CREATED_BY,
                };
                var result = await Connection.QueryAsync<AreaProfile>("USP_LICENSEE_PROFILE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.FirstOrDefault();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        public async Task<ApplicationProfile> GetApplicationProfile(ApplicationProfile applicationProfile)
        {
            ApplicationProfile UserInfo = new ApplicationProfile();
            try
            {
                var paramList = new
                {
                    CHECK = "5", //2
                    CREATED_BY = applicationProfile.CREATED_BY, //LICENSEE_PROFILE USP_LICENSEE_APPLICATION_DETAILS
                };
                var result = await Connection.QueryAsync<ApplicationProfile>("USP_LICENSEE_PROFILE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.FirstOrDefault();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        public async Task<LicenseeDetails> GetOfficeProfile(LicenseeDetails licenseeDetails)
        {
            LicenseeDetails UserInfo = new LicenseeDetails();
            try
            {
                var paramList = new
                {
                    CHECK = "3",
                    CREATED_BY = licenseeDetails.UserID,
                };
                var result = await Connection.QueryAsync<LicenseeDetails>("USP_LICENSEE_PROFILE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.FirstOrDefault();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        public async Task<MineralProfile> GetMineralProfile(MineralProfile mineralDetails)
        {
            MineralProfile UserInfo = new MineralProfile();
            try
            {
                var paramList = new
                {
                    CHECK = "14",
                    CREATED_BY = mineralDetails.CREATED_BY,
                };
                var result = await Connection.QueryAsync<MineralProfile>("USP_LICENSEE_PROFILE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.FirstOrDefault();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }

        }
        #endregion
        #region Individual Profile Count For DD
        public async Task<DDProfileCount> GetDDProfileCount(DDProfileCount dDProfileCount)
        {
            DDProfileCount UserInfo = new DDProfileCount();
            try
            {
                var paramList = new
                {
                    UserID = dDProfileCount.CREATED_BY,
                    IndividualId = dDProfileCount.IndividualId
                };
                //DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<DDProfileCount>("LICENSEE_DGM_PROFILE_REQUEST_INDIVIDUAL_COUNT", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.FirstOrDefault();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        public async Task<List<DDProfileCount>> GetLicenseeUserList(DDProfileCount dDProfileCount)
        {
            List<DDProfileCount> UserInfo = new List<DDProfileCount>();
            try
            {
                var paramList = new
                {
                    UserId = dDProfileCount.UserId,
                    UserTypeName = "Licensee"
                };
                //DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<DDProfileCount>("GetDistrictwiseLessee_Licensee", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.ToList();
                }
                return UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UserInfo = null;
            }
        }
        #endregion
    }
}
