using Dapper;
using MasterApi.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.Vhicle
{
    public class VehicleRegistrationProvider : RepositoryBase, IVehicleRegistrationProvider
    {
        public VehicleRegistrationProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        #region Add Vehicle Owner
        /// <summary>
        /// To Add Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public async Task<MessageEF> AddVehicleRegistration(TransporterModel transporterModel)
        {

            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                if (transporterModel.PaymentMode == "0")
                {
                    p.Add("@chk", 1);
                }
                else
                {
                    p.Add("@chk", 7);
                }
                p.Add("@TransporterName", transporterModel.TransporterName);
                p.Add("@CompanyName", transporterModel.CompanyName);
                p.Add("@Address", transporterModel.Address);
                p.Add("@StateId", transporterModel.StateId);
                p.Add("@DistrictId", transporterModel.DistrictId);
                p.Add("@PinCode", transporterModel.PinCode);
                p.Add("@MobileNumber", transporterModel.MobileNo);
                p.Add("@EmailId", transporterModel.EmailID);
                p.Add("@PAN", transporterModel.PAN);
                p.Add("@PANPath", transporterModel.PANPath);
                p.Add("@TINNo", transporterModel.TINNo);
                p.Add("@STaxRegNo", transporterModel.STaxRegNo);
                p.Add("@TransactionalId", transporterModel.TransactionalID);
                p.Add("@RegFees", transporterModel.RegFees);
                p.Add("@VehicleRegFees", transporterModel.VehicleRegFees);
                p.Add("@UserName", transporterModel.UserName);
                p.Add("@Password", transporterModel.Password);
                p.Add("@TransporterTypeStatus", transporterModel.TransporterTypeStatus);
                p.Add("@AadhaarNumber", transporterModel.AadhaarNumber);
                p.Add("@Firm", transporterModel.Firm);
                p.Add("@Company", transporterModel.Company);
                p.Add("@SQuestionId", transporterModel.SQuestionId);
                p.Add("@QAnswer", transporterModel.SQAnswer);
                p.Add("@RegistrationFeesId", transporterModel.RegistrationFeesId);
                p.Add("@RegistrationFees", transporterModel.RegistrationFees);
                p.Add("@UserCode", transporterModel.UserCode);
                p.Add("@ChallanNumber", transporterModel.ChallanNumber);
                p.Add("@ChallanDate", transporterModel.ChallanDate);
                p.Add("@ChallanCopy", transporterModel.Doc);
                p.Add("@IsSMS", 1);
                p.Add("@IsMailed", 1);
                p.Add("@GSTNo", transporterModel.GSTNo);
                p.Add("@UserId", 1);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                int rr = await Connection.QueryFirstOrDefaultAsync<int>("uspTransporterMasterOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                if (newID.ToString() == "1")
                {
                    objMessage.Satus = rr.ToString();
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion

        #region Verify Mobile No
        /// <summary>
        /// To Verify Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public async Task<MessageEF> CheckMobileNo(TransporterModel transporterModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                DynamicParameters param = new DynamicParameters();
                string result = await Connection.ExecuteScalarAsync<string>("select top 1 MobileNo from UserMaster where IsActive=1 and IsDelete=0 and MobileNo='" + transporterModel.MobileNo + "'", param, commandType: System.Data.CommandType.Text);

                messageEF.Satus = result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return messageEF;
        }
        #endregion

        #region Delete Vehicle Owner
        public Task<MessageEF> DeleteVehicleRegistration(TransporterModel transporterModel)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Edit Vehicle Owner
        /// <summary>
        /// To Edit Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        public async Task<TransporterModel> EditVehicleRegistration(TransporterModel transporterModel)
        {

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ProfileId", Convert.ToInt32(transporterModel.TransactionalID));

                var result = await Connection.QueryAsync<TransporterModel>("uspSelectTransporterMasterData", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    transporterModel = result.FirstOrDefault();
                }
                return transporterModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                transporterModel = null;
            }
        }
        #endregion

        #region Get OTP
        /// <summary>
        /// Get OTP to Validate Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public async Task<MessageEF> GetOTP(TransporterModel transporterModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {


                var p = new DynamicParameters();
                p.Add("@MobileNo", transporterModel.MobileNo);
                p.Add("@EmailId", transporterModel.EmailID);
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

        #region Get Record For Report
        /// <summary>
        /// To Get Record For Report
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        public async Task<TransporterModel> GetRecordForReport(TransporterModel transporterModel)
        {



            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@chk", 3);
                param.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await Connection.QueryAsync<TransporterModel>("uspTransporterMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    transporterModel = result.FirstOrDefault();
                }

                return transporterModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                transporterModel = null;
            }
        }
        #endregion

        #region Get Security Question
        /// <summary>
        /// To Get Security Question
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        public async Task<List<TransporterModel>> GetSQuestion(TransporterModel transporterModel)
        {
            List<TransporterModel> listTransporterModel = new List<TransporterModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<TransporterModel>("select SQuestionId,SQuestion from SQuestion where IsActive=1", param, commandType: System.Data.CommandType.Text);

                if (result.Count() > 0)
                {

                    listTransporterModel = result.ToList();
                }

                return listTransporterModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listTransporterModel = null;
            }
        }
        #endregion

        #region Get UserName and Password
        /// <summary>
        /// To Get UserName and Password
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        public async Task<TransporterModel> GetUserNamePassword(TransporterModel transporterModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@chk", 5);
                param.Add("@TransactionalID", transporterModel.TransactionalID);
                param.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await Connection.QueryAsync<TransporterModel>("uspTransporterMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    transporterModel = result.FirstOrDefault();
                }

                return transporterModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                transporterModel = null;
            }
        }
        #endregion

        #region Update Vehicle Owner
        /// <summary>
        /// To Update Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public async Task<MessageEF> UpdateVehicleRegistration(TransporterModel transporterModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();

                p.Add("@chk", 2);
                p.Add("@TransporterId", transporterModel.TransporterId);
                p.Add("@CompanyName", transporterModel.CompanyName);
                p.Add("@Address", transporterModel.Address);
                p.Add("@StateId", transporterModel.StateId);
                p.Add("@DistrictId", transporterModel.DistrictId);
                p.Add("@PinCode", transporterModel.PinCode);
                p.Add("@MobileNumber", transporterModel.MobileNo);
                p.Add("@EmailId", transporterModel.EmailID);
                p.Add("@TINNo", transporterModel.TINNo);
                p.Add("@GSTNo", transporterModel.GSTNo);
                p.Add("@TransporterTypeStatus", transporterModel.TransporterTypeStatus);
                p.Add("@Firm", transporterModel.Firm);
                p.Add("@Company", transporterModel.Company);
                p.Add("@UserLoginId", 1);
                p.Add("@UserId", transporterModel.UserId);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("uspTransporterMasterOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                if (newID.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else
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
        #endregion

        #region Vehicle Owner Registration Profile
        /// <summary>
        /// To Get Vehicle Registration Profile
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        public async Task<Result<TransporterModel>> VehicleRegistrationProfile(TransporterModel transporterModel)
        {
            Result<TransporterModel> vehicleRegistrationProfile = new Result<TransporterModel>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@ProfileUserId", Convert.ToInt32(transporterModel.TransactionalID));

                var result = await Connection.QueryAsync<TransporterModel>("uspGetTransporterMasterData", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    vehicleRegistrationProfile.Data = result.FirstOrDefault();
                    vehicleRegistrationProfile.Status = true;
                    vehicleRegistrationProfile.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    vehicleRegistrationProfile.Data = null;
                    vehicleRegistrationProfile.Status = false;
                    vehicleRegistrationProfile.Message = new List<string>() { "Failed!" };

                }

            }
            catch (Exception ex)
            {
                //throw ex;
                vehicleRegistrationProfile.Data = null;
                vehicleRegistrationProfile.Status = false;
                vehicleRegistrationProfile.Message = new List<string>() { "Failed!" };
            }
            finally
            {
                transporterModel = null;
            }
            return vehicleRegistrationProfile;
        }
        #endregion

        #region Verify OTP
        /// <summary>
        /// To Verify OTP
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public async Task<MessageEF> VerifyOTP(TransporterModel transporterModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@MobileNo", transporterModel.MobileNo);
                p.Add("@EmailId", transporterModel.EmailID);
                p.Add("@OTP", transporterModel.VerifyOTP);
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

        #region View District
        /// <summary>
        /// To Get District
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        public async Task<List<TransporterModel>> ViewVehicleDistrict(TransporterModel transporterModel)
        {
            List<TransporterModel> listTransporterModel = new List<TransporterModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@StateID", transporterModel.StateId);
                var result = await Connection.QueryAsync<TransporterModel>("uspDistrictMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listTransporterModel = result.ToList();
                }

                return listTransporterModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listTransporterModel = null;
            }
        }
        #endregion

        #region View Vehicle Owner
        public Task<List<TransporterModel>> ViewVehicleRegistration(TransporterModel transporterModel)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region View State
        /// <summary>
        /// To View State
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        public async Task<List<TransporterModel>> ViewVehicleState(TransporterModel transporterModel)
        {
            List<TransporterModel> listTransporterModel = new List<TransporterModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 5);
                var result = await Connection.QueryAsync<TransporterModel>("uspDivisionMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listTransporterModel = result.ToList();
                }

                return listTransporterModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listTransporterModel = null;
            }
        }
        #endregion

        #region VehicleAmountConfiguration Per Vehicle
        /// <summary>
        /// Add Vehicle Amount Configuration
        /// </summary>
        /// <param name="vehicleAmountConfiguration"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddVehicleAmountConfiguration(VehicleAmountConfiguration vehicleAmountConfiguration)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@VehicleAmount", vehicleAmountConfiguration.VehicleAmount);
                p.Add("@ExpiryPeriod", vehicleAmountConfiguration.ExpiryPeriod);
                p.Add("@UserId", vehicleAmountConfiguration.UserId);
                p.Add("@Action", "Insert");
                string rr = await Connection.QueryFirstOrDefaultAsync<string>("USPSetPerVehicleAmount", p, commandType: CommandType.StoredProcedure);
                messageEF.Satus = rr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return messageEF;
        }

        /// <summary>
        /// Update Vehicle Amount Configuration
        /// </summary>
        /// <param name="vehicleAmountConfiguration"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateVehicleAmountConfiguration(VehicleAmountConfiguration vehicleAmountConfiguration)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Id", vehicleAmountConfiguration.Id);
                p.Add("@VehicleAmount", vehicleAmountConfiguration.VehicleAmount);
                p.Add("@ExpiryPeriod", vehicleAmountConfiguration.ExpiryPeriod);
                p.Add("@UserId", vehicleAmountConfiguration.UserId);
                p.Add("@Action", "Update");
                string rr = await Connection.QueryFirstOrDefaultAsync<string>("USPSetPerVehicleAmount", p, commandType: CommandType.StoredProcedure);
                messageEF.Satus = rr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return messageEF;
        }

        /// <summary>
        /// Get Vehicle Amount Configuration
        /// </summary>
        /// <param name="vehicleAmountConfiguration"></param>
        /// <returns></returns>
        public async Task<VehicleAmountConfiguration> GetVehicleAmountConfiguration(VehicleAmountConfiguration vehicleAmountConfiguration)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@Action", "Get");
                var result = await Connection.QueryAsync<VehicleAmountConfiguration>("USPSetPerVehicleAmount", p, commandType: CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    vehicleAmountConfiguration = result.FirstOrDefault();
                }
                return vehicleAmountConfiguration;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                vehicleAmountConfiguration = null;
            }
        }
        #endregion
    }
}
