using Dapper;
using DotNetIntegrationKit;
using MasterApi.Factory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;
using userregistrationEFApi.Utility.MailService;
using userregistrationEFApi.Utility.SMSService;

namespace userregistrationEFApi.Model.Vhicle
{
    public class VehicleProvider : RepositoryBase, IVehicleProvider
    {
        string CHALLAN_NO = string.Empty;
        string CHALLAN_INITIATE_DATE = string.Empty;
        string CHALLAN_SETTLEMENT_DATE = string.Empty;
        string UTR_NUMBER = string.Empty;
        string ICICI_TXN_NO = string.Empty;

        string strPG_TxnStatus = string.Empty;
        string[] strSplitDecryptedResponse;
        string CLNT_TXN_REF = string.Empty;
        string strPG_TxnAmount = string.Empty;
        string strPG_TRANSACTIONDATE = string.Empty;
        private readonly IConfiguration configuration;
        private readonly IMailServiceProvider mailServiceProvider;
        private readonly ISMSServiceProvider sMSServiceProvider;
        private readonly IVehicleRegistrationProvider vehicleRegistrationProvider;

        public VehicleProvider(IConnectionFactory connectionFactory, IConfiguration configuration,
            IMailServiceProvider mailServiceProvider, ISMSServiceProvider sMSServiceProvider, IVehicleRegistrationProvider vehicleRegistrationProvider) : base(connectionFactory)
        {
            this.configuration = configuration;
            this.mailServiceProvider = mailServiceProvider;
            this.sMSServiceProvider = sMSServiceProvider;
            this.vehicleRegistrationProvider = vehicleRegistrationProvider;
        }

        #region Add Vehicle
        /// <summary>
        /// To Add Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddVehicle(Vehicle vehicle)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@Check", 0);
                p.Add("@VehicleID", vehicle.VehicleID);
                p.Add("@VehicleNumber", vehicle.VehicleNumber);
                p.Add("@VehicleOwnerId", vehicle.UserLoginID);
                p.Add("@VehicleTypeId", vehicle.VehicleTypeId);
                p.Add("@TransporterId", vehicle.UserLoginID);
                p.Add("@MaxNetWeight", vehicle.MaxNetWeight);
                p.Add("@RCBookNumber", vehicle.RCBookNumber);
                p.Add("@RegFeesId", vehicle.RegistrationFeesId);
                p.Add("@RegFees", vehicle.RegistraionFees);
                p.Add("@IsSMS", false);
                p.Add("@IsMailed", false);
                p.Add("@AddedBy", vehicle.UserLoginID);
                p.Add("@ActiveStatus", vehicle.ActiveStatus);
                p.Add("@IsDelete", false);
                p.Add("@UserLoginID", vehicle.UserLoginID);
                p.Add("@IsPaymentDone", vehicle.VehicleID == 0 ? false : vehicle.IsPaymentDone);
                p.Add("@UnitId", vehicle.UnitId1);
                p.Add("@GPSID", vehicle.GPSDeviceID);
                p.Add("@IsGPSDevice", vehicle.IsGPSDevice);
                p.Add("@CarryingCapacity", vehicle.CarryingCapacity);
                p.Add("@UnitId2", vehicle.UnitId2);
                p.Add("@RcFile_Name", vehicle.RcFile_Name);
                p.Add("@RcFile_Path", vehicle.RcFile_Path);
                p.Add("@PermitFile_Name", vehicle.PermitFile_Name);
                p.Add("@PermitFile_Path", vehicle.PermitFile_Path);
                bool rr = await Connection.ExecuteAsync("InsertUpdateVehicleMaster", p, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                if (rr == true)
                {
                    objMessage.Satus = "1";
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

        #region Delete Vehicle
        /// <summary>
        /// To Delete Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteVehicle(Vehicle vehicle)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@VehicleId",vehicle.VehicleID,
                        "@UserID",vehicle.UserLoginID,
                        "@Check",1
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("RESULT");
                var result = await Connection.QueryAsync<string>("UspInsertUpdateDeleteVehicle", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("RESULT");
                if (response == "1")
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

        #region Edit Vehicle
        /// <summary>
        /// To Edit Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<Vehicle> EditVehicle(Vehicle vehicle)
        {

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", vehicle.Check);
                param.Add("@AddedBy", vehicle.UserLoginID);
                param.Add("@VehicleID", vehicle.VehicleID);
                param.Add("@Type", vehicle.Type);
                var result = await Connection.QueryAsync<Vehicle>("InsertUpdateVehicleMaster", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    vehicle = result.FirstOrDefault();
                }

                return vehicle;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                vehicle = null;
            }
        }
        #endregion

        #region Get Vehicle BreakDown Approval Letter
        /// <summary>
        /// To Get Vehicle BreakDown Approval Letter
        /// </summary>
        /// <param name="vehicleBreakdown"></param>
        /// <returns></returns>
        public async Task<List<VehicleBreakdown>> GetApprovalLetter(VehicleBreakdown vehicleBreakdown)
        {
            List<VehicleBreakdown> listVehicleBreakdown = new List<VehicleBreakdown>();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@SP_MODE", "GET_APPROVAL_LETTER");
                param.Add("@USER_ID", vehicleBreakdown.UserId);
                param.Add("@VEHICLE_BREAKDOWN_ID", vehicleBreakdown.BreakDownId);
                param.Add("@FromDate", vehicleBreakdown.FromDate);
                param.Add("@ToDate", vehicleBreakdown.ToDate);
                IDataReader dr = await Connection.ExecuteReaderAsync("USP_VEHICLE_BREAKDOWN", param, commandType: System.Data.CommandType.StoredProcedure);

                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        VehicleBreakdown data = new VehicleBreakdown();
                        data.SrNo = Convert.ToInt32(dt.Rows[i]["SrNo"]);
                        data.TransitPassNo = Convert.ToString(dt.Rows[i]["TransitPassNo"]);
                        data.LocationOfBreakDown = Convert.ToString(dt.Rows[i]["LOCATION_OF_BREAKDOWN"]);
                        data.ReasonOfBreakDown = Convert.ToString(dt.Rows[i]["REASON_OF_BREAKDOWN"]);
                        data.VehicleNumber = Convert.ToString(dt.Rows[i]["VehicleNumber"]);
                        data.BreakDownId = Convert.ToInt32(dt.Rows[i]["VEHICLE_BREAKDOWN_ID"]);
                        data.BreakDownDate = Convert.ToString(dt.Rows[i]["BreakDownDate"]);
                        data.Trip_Start_Status = Convert.ToString(dt.Rows[i]["Trip_Start_Status"]);
                        data.AssignedVehicleNo = Convert.ToInt32(dt.Rows[i]["NEW_VEHICLE_ID"]);
                        data.OldVehicleId = Convert.ToInt32(dt.Rows[i]["OLD_VEHICLE_ID"]);
                        data.TransitPassID = Convert.ToInt32(dt.Rows[i]["TransitPassID"]);
                        data.CREATED_ON = Convert.ToDateTime(dt.Rows[i]["CREATED_ON"]);
                        listVehicleBreakdown.Add(data);
                    }
                }
                return listVehicleBreakdown;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listVehicleBreakdown = null;
            }
        }
        #endregion

        #region Indivisual Vehicle Fees
        /// <summary>
        /// Indivisual Vehicle Fees
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<List<Vehicle>> GetIndividualVehicleFees(Vehicle vehicle)
        {
            List<Vehicle> lstVehicle = new List<Vehicle>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<Vehicle>("GetIndividualVehicleFees", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstVehicle = result.ToList();
                }
                return lstVehicle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstVehicle = null;
            }
        }
        #endregion

        #region Payment Remaining Vehicle
        /// <summary>
        /// To Payment Remaining Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<List<Vehicle>> GetPaymentRemainingVehicle(Vehicle vehicle)
        {
            List<Vehicle> listVehicle = new List<Vehicle>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserId", vehicle.UserLoginID);
                var result = await Connection.QueryAsync<Vehicle>("uspGetVehiclePaymentList", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    listVehicle = result.ToList();
                }
                return listVehicle;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listVehicle = null;
            }
        }
        #endregion

        #region Vehicle Trips
        /// <summary>
        /// To Get Vehicle Trips
        /// </summary>
        /// <param name="eTransitPassModel"></param>
        /// <returns></returns>
        public async Task<List<ETransitPassModel>> GetRunningClosedTripGridData(ETransitPassModel eTransitPassModel)
        {
            List<ETransitPassModel> listETransitPassModel = new List<ETransitPassModel>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserId", eTransitPassModel.UserId);
                param.Add("@TripsStatus", eTransitPassModel.TripStatus);
                param.Add("@FromDate", eTransitPassModel.FromDate);
                param.Add("@ToDate", eTransitPassModel.ToDate);
                param.Add("@VNumber", eTransitPassModel.VehicleNumber);
                var result = await Connection.QueryAsync<ETransitPassModel>("uspGetTransporterOperationReport", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    listETransitPassModel = result.ToList();
                }
                return listETransitPassModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listETransitPassModel = null;
            }
        }
        #endregion

        #region Get BreakDown Details By TP No
        /// <summary>
        /// To Get BreakDown Details By TP No
        /// </summary>
        /// <param name="vehicleBreakdownTpDetails"></param>
        /// <returns></returns>
        public async Task<VehicleBreakdownTpDetails> GetTransitPassNoWiseData(VehicleBreakdownTpDetails vehicleBreakdownTpDetails)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@TRANSIT_PASS_NO", vehicleBreakdownTpDetails.TransitPassNo);
                param.Add("@SP_MODE", "GET_TP_DATA_BY_PASS_NO");
                param.Add("@USER_ID", vehicleBreakdownTpDetails.UserId);
                var result = await Connection.QueryAsync<VehicleBreakdownTpDetails>("USP_VEHICLE_BREAKDOWN", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    vehicleBreakdownTpDetails = result.FirstOrDefault();
                }
                else
                {
                    vehicleBreakdownTpDetails.Message = "No Data Found With " + vehicleBreakdownTpDetails.TransitPassNo;
                }

                return vehicleBreakdownTpDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                vehicleBreakdownTpDetails = null;
            }
        }
        #endregion

        #region Check Vehicle No
        /// <summary>
        /// To Check Vehicle No
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<MessageEF> IsVehicleExist(Vehicle vehicle)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@VehicleNumber", vehicle.VehicleNumber);
                param.Add("@UserId", vehicle.UserLoginID);
                string result = await Connection.ExecuteScalarAsync<string>("uspCheckIsVehicleExist", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return messageEF;
        }
        #endregion

        #region Update
        /// <summary>
        /// To Update Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public Task<MessageEF> UpdateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region View Vehicle Unit
        /// <summary>
        /// To View Vehicle Unit
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<List<Vehicle>> ViewUnit(Vehicle vehicle)
        {
            List<Vehicle> listVehicle = new List<Vehicle>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<Vehicle>("select UnitID UnitId1,UnitName from UnitMaster where IsActive=1 and IsDelete=0 order by UnitName", param, commandType: System.Data.CommandType.Text);

                if (result.Count() > 0)
                {
                    listVehicle = result.ToList();
                }
                return listVehicle;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listVehicle = null;
            }
        }
        #endregion

        #region View Vehicle Details
        /// <summary>
        /// To View Vehicle Details
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<List<Vehicle>> ViewVehicle(Vehicle vehicle)
        {
            List<Vehicle> listVehicle = new List<Vehicle>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@AddedBy", vehicle.UserLoginID);
                var result = await Connection.QueryAsync<Vehicle>("InsertUpdateVehicleMaster", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    listVehicle = result.ToList();
                }
                return listVehicle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                listVehicle = null;
            }
        }
        #endregion

        #region View Vehicle Renewal Details
        /// <summary>
        /// To View Vehicle Renewal Details
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<List<Vehicle>> ViewVehicleRenewal(Vehicle vehicle)
        {
            List<Vehicle> listVehicle = new List<Vehicle>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserId", vehicle.UserLoginID);
                param.Add("@VehicleId", vehicle.VehicleID);
                var result = await Connection.QueryAsync<Vehicle>("getVehicleRenewalReport", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    listVehicle = result.ToList();
                }
                return listVehicle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                listVehicle = null;
            }
        }
        #endregion

        #region View Vehicle Type
        /// <summary>
        /// To View Vehicle Type
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<List<Vehicle>> ViewVehicleType(Vehicle vehicle)
        {
            List<Vehicle> listVehicle = new List<Vehicle>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<Vehicle>("select VehicleTypeId,VehicleTypeName  from VehicleTypeMaster where ActiveStatus=1", param, commandType: System.Data.CommandType.Text);

                if (result.Count() > 0)
                {
                    listVehicle = result.ToList();
                }
                return listVehicle;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listVehicle = null;
            }
        }
        #endregion

        #region Get Record For Report
        /// <summary>
        /// Get Record For Report
        /// </summary>
        /// <returns></returns>
        public async Task<MessageEF> getRecordForReport(MessageEF messageEF)
        {

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@chk", 3);
                param.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                IDataReader dr = await Connection.ExecuteReaderAsync("uspTransporterMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    messageEF.Satus = dt.Rows[0]["TransactionalId"].ToString();
                }
                return messageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        /// <summary>
        /// Get Vehicles By Transit Pass No
        /// </summary>
        /// <param name="vehicleBreakdownTpDetails"></param>
        /// <returns></returns>
        public async Task<List<TextValue>> GetVehiclesByTransitPassNo(VehicleBreakdownTpDetails vehicleBreakdownTpDetails)
        {
            List<TextValue> lstTextValue = new List<TextValue>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@TransitPassNo", vehicleBreakdownTpDetails.TransitPassNo);
                param.Add("@SP_MODE", "GET_VEHICLE_DROP_DOWN_BY_TRANSIT_PASS_NO");
                param.Add("@USER_ID", vehicleBreakdownTpDetails.UserId);
                param.Add("@TransitPassType", vehicleBreakdownTpDetails.TransitPassType);
                var result = await Connection.QueryAsync<TextValue>("USP_GET_DROPDOWNLIST", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstTextValue = result.ToList();
                }
                return lstTextValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstTextValue = null;
            }
        }

        /// <summary>
        /// Save Vehicle Breakdown
        /// </summary>
        /// <param name="vehicleBreakdown"></param>
        /// <returns></returns>
        public async Task<MessageEF> SaveVehicleBreakdownDetails(VehicleBreakdown vehicleBreakdown)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@TRANSIT_PASS_NO", vehicleBreakdown.TransitPassNo);
                param.Add("@LOCATION_OF_BREAKDOWN", vehicleBreakdown.LocationOfBreakDown);
                param.Add("@REASON_OF_BREAKDOWN", vehicleBreakdown.ReasonOfBreakDown);
                param.Add("@NEW_VEHICLE_ID", vehicleBreakdown.AssignedVehicleNo);
                param.Add("@Transit_Pass_Type", vehicleBreakdown.TransitPassType);
                param.Add("@OLD_VEHICLE_ID", vehicleBreakdown.OldVehicleId);
                param.Add("@SP_MODE", "SAVE_BREAKDOWN_DATA");
                param.Add("@USER_ID", vehicleBreakdown.UserId);
                var result = await Connection.ExecuteScalarAsync("USP_VEHICLE_BREAKDOWN", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString();

            }
            catch (Exception ex)
            {
                messageEF.Satus = "Error occuerd while saving data";
            }
            return messageEF;
        }

        /// <summary>
        /// Get VehicleBreak downData
        /// </summary>
        /// <param name="vehicleBreakdown"></param>
        /// <returns></returns>
        public async Task<List<VehicleBreakdown>> GetVehicleBreakdownData(VehicleBreakdown vehicleBreakdown)
        {
            List<VehicleBreakdown> lstVehicleBreakdown = new List<VehicleBreakdown>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SP_MODE", "GET_BREAKDOWN_DATA");
                param.Add("@USER_ID", vehicleBreakdown.UserId);
                IDataReader dr = await Connection.ExecuteReaderAsync("USP_VEHICLE_BREAKDOWN", param, commandType: System.Data.CommandType.StoredProcedure);

                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        VehicleBreakdown data = new VehicleBreakdown();
                        data.BreakDownId = Convert.ToInt32(dt.Rows[i]["VEHICLE_BREAKDOWN_ID"]);
                        data.TransitPassNo = Convert.ToString(dt.Rows[i]["TRANSIT_PASS_NO"]);
                        data.LocationOfBreakDown = Convert.ToString(dt.Rows[i]["LOCATION_OF_BREAKDOWN"]);
                        data.ReasonOfBreakDown = Convert.ToString(dt.Rows[i]["REASON_OF_BREAKDOWN"]);
                        data.VehicleNumber = Convert.ToString(dt.Rows[i]["VEHICLENUMBER"]);
                        data.TransporterName = Convert.ToString(dt.Rows[i]["TRANSPORTERNAME"]);
                        lstVehicleBreakdown.Add(data);
                    }
                }
                return lstVehicleBreakdown;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstVehicleBreakdown = null;
            }
        }

        /// <summary>
        /// Get Vehicle BreakdownData By BreakDownId
        /// </summary>
        /// <param name="vehicleBreakdown"></param>
        /// <returns></returns>
        public async Task<VehicleBreakdown> GetVehicleBreakdownDataByBreakDownId(VehicleBreakdown vehicleBreakdown)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SP_MODE", "GET_BREAKDOWN_DATA");
                param.Add("@Breakdown_Id", vehicleBreakdown.BreakDownId);
                param.Add("@USER_ID", vehicleBreakdown.UserId);
                IDataReader dr = await Connection.ExecuteReaderAsync("USP_VEHICLE_BREAKDOWN", param, commandType: System.Data.CommandType.StoredProcedure);

                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    vehicleBreakdown.BreakDownId = Convert.ToInt32(dt.Rows[0]["VEHICLE_BREAKDOWN_ID"]);
                    vehicleBreakdown.TransitPassNo = Convert.ToString(dt.Rows[0]["TRANSIT_PASS_NO"]);
                    vehicleBreakdown.LocationOfBreakDown = Convert.ToString(dt.Rows[0]["LOCATION_OF_BREAKDOWN"]);
                    vehicleBreakdown.ReasonOfBreakDown = Convert.ToString(dt.Rows[0]["REASON_OF_BREAKDOWN"]);
                    vehicleBreakdown.VehicleNumber = Convert.ToString(dt.Rows[0]["VEHICLENUMBER"]);
                    vehicleBreakdown.TransporterName = Convert.ToString(dt.Rows[0]["TRANSPORTERNAME"]);

                    vehicleBreakdown.SourceAddress = Convert.ToString(dt.Rows[0]["SourceAddress"]);
                    vehicleBreakdown.DestinationAddress = Convert.ToString(dt.Rows[0]["DestinationAddress"]);
                    vehicleBreakdown.GrossWeight = Convert.ToString(dt.Rows[0]["GrossWeight"]);
                }
                return vehicleBreakdown;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                vehicleBreakdown = null;
            }
        }

        /// <summary>
        /// Approve/Reject Vehicle Breakdown Request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> ApproveRejectRequest(VehicleBreakdown vehicleBreakdown)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Breakdown_Id", vehicleBreakdown.BreakDownId);
                param.Add("@CommandType", vehicleBreakdown.CommandType);
                param.Add("@Remarks", vehicleBreakdown.Remarks);
                param.Add("@SP_MODE", "APPROVE_REJECT_REQUEST");
                param.Add("@TRANSIT_PASS_NO", vehicleBreakdown.TransitPassNo);
                param.Add("@USER_ID", vehicleBreakdown.UserId);
                var result = await Connection.ExecuteScalarAsync("USP_VEHICLE_BREAKDOWN", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "Error occuerd while saving data";
            }
            return messageEF;
        }

        /// <summary>
        /// Start Vehicle Breakdown Trip
        /// </summary>
        /// <param name="vehicleBreakdown"></param>
        /// <returns></returns>
        public async Task<MessageEF> StartVehicleBreakdownTrip(VehicleBreakdown vehicleBreakdown)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Breakdown_Id", vehicleBreakdown.BreakDownId);
                param.Add("@TRANSIT_PASS_NO", vehicleBreakdown.TransitPassNo);
                param.Add("@SP_MODE", "START_TRIP");
                var result = await Connection.ExecuteScalarAsync("USP_VEHICLE_BREAKDOWN", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString();
                return messageEF;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GET USER DETAILS BY MOBILENO
        /// </summary>
        /// <param name="MobileNo"></param>
        /// <returns></returns>
        public async Task<Result<List<VehicleBreakdownDetailsByMobileNo>>> GETUSERDETAILSBYMOBILENO(string MobileNo)
        {
            Result<List<VehicleBreakdownDetailsByMobileNo>> lstVehicleBreakdownDetailsByMobileNo = new Result<List<VehicleBreakdownDetailsByMobileNo>>();
            try
            {
                DynamicParameters param = new DynamicParameters(); 
                param.Add("@SP_MODE", "GET_USERDETAILSBY_MOBILENO");
                param.Add("@DriverContactNumber", MobileNo); 
                var result = await Connection.QueryAsync<VehicleBreakdownDetailsByMobileNo>("USP_VEHICLE_BREAKDOWN", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    lstVehicleBreakdownDetailsByMobileNo.Data = result.ToList();
                    lstVehicleBreakdownDetailsByMobileNo.Status = true;
                    lstVehicleBreakdownDetailsByMobileNo.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    lstVehicleBreakdownDetailsByMobileNo.Data = null;
                    lstVehicleBreakdownDetailsByMobileNo.Status = false;
                    lstVehicleBreakdownDetailsByMobileNo.Message = new List<string>() { "Failed!" };

                }
                return lstVehicleBreakdownDetailsByMobileNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstVehicleBreakdownDetailsByMobileNo = null;
            }
        }

        /// <summary>
        /// Breakdown Request From MobileApp
        /// </summary>
        /// <param name="breakdownRequestFromMobileApp"></param>
        /// <returns></returns>
        public async Task<Result<MessageEF>> BreakdownRequestFromMobileApp(BreakdownRequestFromMobileApp breakdownRequestFromMobileApp)
        {
            Result<MessageEF> messageEF = new Result<MessageEF>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@TransitPassIDByMobileApp", breakdownRequestFromMobileApp.TransitPassID);
                param.Add("@TRANSIT_PASS_NO", breakdownRequestFromMobileApp.TransitPassNo);
                param.Add("@NEW_VEHICLE_ID", breakdownRequestFromMobileApp.New_VehicleId);
                param.Add("@New_VehicleNo", breakdownRequestFromMobileApp.New_VehicleNo);
                param.Add("@New_DriverName", breakdownRequestFromMobileApp.New_DriverName);
                param.Add("@DriverMobileNo", breakdownRequestFromMobileApp.DriverMobileNo);
                param.Add("@REASON_OF_BREAKDOWN", breakdownRequestFromMobileApp.BreakdownReason);
                param.Add("@LOCATION_OF_BREAKDOWN", breakdownRequestFromMobileApp.BreakdownLocation);
                param.Add("@Latitude", breakdownRequestFromMobileApp.Latitude);
                param.Add("@Longitude", breakdownRequestFromMobileApp.Longitude);
                param.Add("@SP_MODE", "Insert_BreakdownRequest_By_MobileApp");
                param.Add("@USER_ID", breakdownRequestFromMobileApp.UserId);
                var result = await Connection.ExecuteScalarAsync("USP_VEHICLE_BREAKDOWN", param, commandType: System.Data.CommandType.StoredProcedure);
                string Status = result.ToString();
                 
                if (Status == "Record Inserted Successfully")
                {
                    messageEF.Data = null;
                    messageEF.Status = true;
                    messageEF.Message = new List<string>() { "Successfull!" };
                    #region Mail and SMS
                    try
                    {
                        BreakdownRequestDetailsByMobileApp breakdownRequestDetailsByMobileApp = new BreakdownRequestDetailsByMobileApp();
                        DynamicParameters param1 = new DynamicParameters();
                        param.Add("@SP_MODE", "GET_USERINFO_BYTPNO");
                        param.Add("@TRANSIT_PASS_NO", breakdownRequestFromMobileApp.TransitPassNo);
                        var result1 = await Connection.QueryAsync<BreakdownRequestDetailsByMobileApp>("USP_VEHICLE_BREAKDOWN", param, commandType: System.Data.CommandType.StoredProcedure);
                        if (result1.Count() > 0)
                        {
                            breakdownRequestDetailsByMobileApp = result1.FirstOrDefault();
                        }
                        breakdownRequestDetailsByMobileApp.TransitPassNo = breakdownRequestFromMobileApp.TransitPassNo;
                        #region Send Mail and SMS To Vehicle Owner
                        if (!string.IsNullOrEmpty(breakdownRequestDetailsByMobileApp.TransporterEMailId))
                        {
                            breakdownRequestDetailsByMobileApp.Type = "VehicleOwner";
                            mailServiceProvider.SendMail_VehicleBreakdownTransporter(breakdownRequestDetailsByMobileApp);
                        }
                        if (!string.IsNullOrEmpty(breakdownRequestDetailsByMobileApp.TransporterMobileNo))
                        {


                            string msg = "Your Vehicle has been break down with TPNO " + breakdownRequestFromMobileApp.TransitPassNo + Environment.NewLine +
                               " on" + DateTime.Now.Date.ToString("dd-MM-yyyy") + Environment.NewLine +
                              "Please check your e-mail for details of Breakdown. CHiMMS, GoCG";
                            string templateid = "1307161883460589272";
                            sMSServiceProvider.Main(new SMS() { mobileNo = breakdownRequestDetailsByMobileApp.TransporterMobileNo, message = msg, templateid = templateid });
                        }
                        #endregion

                        #region Send Mail and SMS To Enduser or Licensee
                        if (!string.IsNullOrEmpty(breakdownRequestDetailsByMobileApp.EndUserEmailId))
                        {
                            breakdownRequestDetailsByMobileApp.Type = "EndUser";
                            mailServiceProvider.SendMail_VehicleBreakdownTransporter(breakdownRequestDetailsByMobileApp);
                        }
                        if (!string.IsNullOrEmpty(breakdownRequestDetailsByMobileApp.EndUserMobileNo))
                        {


                            string msg = "Your Vehicle has been break down with TPNO " + breakdownRequestFromMobileApp.TransitPassNo + Environment.NewLine +
                               " on" + DateTime.Now.Date.ToString("dd-MM-yyyy") + Environment.NewLine +
                              "Please check your e-mail for details of Breakdown. CHiMMS, GoCG";
                            string templateid = "1307161883460589272";
                            sMSServiceProvider.Main(new SMS() { mobileNo = breakdownRequestDetailsByMobileApp.EndUserMobileNo, message = msg, templateid = templateid });
                        }

                        if (!string.IsNullOrEmpty(breakdownRequestDetailsByMobileApp.LicenseeEmailId))
                        {
                            breakdownRequestDetailsByMobileApp.Type = "Licensee";
                            mailServiceProvider.SendMail_VehicleBreakdownTransporter(breakdownRequestDetailsByMobileApp);
                        }

                        if (!string.IsNullOrEmpty(breakdownRequestDetailsByMobileApp.LicenseeMobileNo))
                        {


                            string msg = "Your Vehicle has been break down with TPNO " + breakdownRequestFromMobileApp.TransitPassNo + Environment.NewLine +
                               " on" + DateTime.Now.Date.ToString("dd-MM-yyyy") + Environment.NewLine +
                              "Please check your e-mail for details of Breakdown. CHiMMS, GoCG";
                            string templateid = "1307161883460589272";
                            sMSServiceProvider.Main(new SMS() { mobileNo = breakdownRequestDetailsByMobileApp.LicenseeMobileNo, message = msg, templateid = templateid });
                        }
                        #endregion

                        #region Send Mail and SMS To Lessee
                        if (!string.IsNullOrEmpty(breakdownRequestDetailsByMobileApp.LesseeEmailId))
                        {
                            breakdownRequestDetailsByMobileApp.Type = "Lessee";
                            mailServiceProvider.SendMail_VehicleBreakdownTransporter(breakdownRequestDetailsByMobileApp);
                        }
                        if (!string.IsNullOrEmpty(breakdownRequestDetailsByMobileApp.LesseeMobileNo))
                        { 
                            string msg = "Your Vehicle has been break down with TPNO " + breakdownRequestFromMobileApp.TransitPassNo + Environment.NewLine +
                               " on" + DateTime.Now.Date.ToString("dd-MM-yyyy") + Environment.NewLine +
                              "Please check your e-mail for details of Breakdown. CHiMMS, GoCG";
                            string templateid = "1307161883460589272";
                            sMSServiceProvider.Main(new SMS() { mobileNo = breakdownRequestDetailsByMobileApp.LesseeMobileNo, message = msg, templateid = templateid });
                        }
                         
                        #endregion
                    }
                    catch (Exception)
                    {

                    }

                    #endregion
                }
                else
                {
                    messageEF.Data = null;
                    messageEF.Status = false;
                    messageEF.Message = new List<string>() { "Failed!" };
                }

            }
            catch (Exception ex)
            {
                messageEF.Message = new List<string>() { "Error occuerd while saving data" };
            }
            return messageEF;
        }

        /// <summary>
        /// Get OTP
        /// </summary>
        /// <param name="MobileNo"></param>
        /// <returns></returns>
        public async Task<Result<MessageEF>> GetOTPByMobileNo(string MobileNo)
        {
            try
            {
                Result<MessageEF> resultMessageEF = new Result<MessageEF>();
                MessageEF messageEF = new MessageEF();
                DynamicParameters param = new DynamicParameters();
                param.Add("@DriverContactNumber", MobileNo);
                var result = await Connection.ExecuteScalarAsync("select COUNT(1) from ETransitPassDetails where TripStatus=0 and DriverContactNumber=@DriverContactNumber", param, commandType: System.Data.CommandType.Text);
                if (Convert.ToInt32(result.ToString()) > 0)
                {
                    messageEF = await vehicleRegistrationProvider.GetOTP(new TransporterModel() { MobileNo = MobileNo, EmailID = "" });
                    if (!string.IsNullOrEmpty(messageEF.Satus))
                    {

                        string message = "Your One time code for Khanij Online application is : " + messageEF.Satus + " CHiMMS, GoCG";
                        string templateid = "1307161883520738720";
                        sMSServiceProvider.Main(new SMS() { mobileNo = MobileNo, message = message, templateid = templateid });
                        resultMessageEF.Data = messageEF;
                        resultMessageEF.Status = true;
                        resultMessageEF.Message = new List<string>() { "Successfull!" };
                    }
                    else
                    {
                        resultMessageEF.Data = null;
                        resultMessageEF.Status = false;
                        resultMessageEF.Message = new List<string>() { "Failed!" };
                    }
                }
                else
                {
                    resultMessageEF.Data = null;
                    resultMessageEF.Status = false;
                    resultMessageEF.Message = new List<string>() { "Failed!","Invalid Mobile Number" };
                }
                return resultMessageEF;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #region Cancel Vehicle Payment Transaction
        /// <summary>
        /// Cancel Vehicle Payment Transaction
        /// </summary>
        /// <param name="cancelVehiclePayment"></param>
        /// <returns></returns>
        public async Task<MessageEF> CancelVehiclePaymentTransaction(CancelVehiclePayment cancelVehiclePayment)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MerchantTxnRefNumber", cancelVehiclePayment.paymentReqId);
                param.Add("@UserId", cancelVehiclePayment.UserId);
                param.Add("@PaymentTYpe", cancelVehiclePayment.PaymentType);
                var result = await Connection.ExecuteScalarAsync("getPaymentStatusReport", param, commandType: System.Data.CommandType.StoredProcedure);

                if (!string.IsNullOrEmpty(result.ToString()))
                {
                    messageEF.Satus = result.ToString();
                }
                return messageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Check Payment Status
        public async Task<MessageEF> PaymentStatusFromGateway(CancelVehiclePayment cancelVehiclePayment)
        {

            MessageEF messageEF = new MessageEF();
            try
            {
                if (!string.IsNullOrEmpty(cancelVehiclePayment.paymentReqId))
                {

                    string response = string.Empty;
                    string strResponse = response.ToUpper();
                    RequestURL objRequestURL = new RequestURL();
                    string permitType = string.Empty;

                    if (cancelVehiclePayment.PaymentType == "VP")
                    {
                        permitType = cancelVehiclePayment.paymentReqId;
                    }
                    else if (cancelVehiclePayment.PaymentType == "CVP")
                    {
                        permitType = cancelVehiclePayment.paymentReqId;
                    }

                    else
                    {
                        permitType = cancelVehiclePayment.PaymentType + cancelVehiclePayment.paymentReqId;
                    }

                    string BankTPSLId = string.Empty;

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MerchantTxnRefNumber", permitType);
                    param.Add("@UserId", cancelVehiclePayment.UserId);
                    param.Add("@PaymentTYpe", cancelVehiclePayment.PaymentType);
                    IDataReader dr = await Connection.ExecuteReaderAsync("getPaymentStatusReport", param, commandType: System.Data.CommandType.StoredProcedure);

                    DataSet ds = new DataSet();
                    ds = ConvertDataReaderToDataSet(dr);
                    DataTable dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        #region SBI Verification
                        if (dt.Rows[0]["BANKCODE"].ToString() == "SBI")
                        {

                            try
                            {
                                //DoubleVerifyMerchantServicePortTypeClient objSBI = new DoubleVerifyMerchantServicePortTypeClient();
                                //var CLINET_TXN_NO = dt.Rows[0]["CLINETTXNNO"].ToString();
                                //var AMOUNT = dt.Rows[0]["AMOUNT"].ToString();
                                //var PostRequest = "CLNT_TXN_NO=" + CLINET_TXN_NO + "|TXN_AMOUNT=" + AMOUNT;
                                //string Result = GetMD5Hash(PostRequest);
                                //string str1 = PostRequest + "|checkSum=" + Result;
                                //string SBIPostRequest = Encrypt(str1) + "^MINERAL_DEPT";
                                //string str = objSBI.DoubleVerification(SBIPostRequest);
                                //response = Decrypt(str);
                                //strSplitDecryptedResponse = response.Split('|');
                                //GetPGRespnseData(strSplitDecryptedResponse);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        #endregion 

                        #region payment updation

                        if (string.IsNullOrEmpty(response) == true || response.ToUpper().StartsWith("ERROR"))
                        {
                            #region if no payment response
                            DynamicParameters param1 = new DynamicParameters();
                            param1.Add("@MerchantTxnRefNumber", permitType);
                            param1.Add("@UserId", cancelVehiclePayment.UserId);
                            if (cancelVehiclePayment.PaymentType == "VP")
                            {
                                param1.Add("@PaymentTYpe", "VPCAN");
                            }
                            else
                            {
                                param1.Add("@PaymentTYpe", "BPCAN");
                            }
                            var result = await Connection.ExecuteScalarAsync("getPaymentStatusReport", param, commandType: System.Data.CommandType.StoredProcedure);
                            if (Convert.ToInt32(result.ToString()) > 0)
                            {
                                messageEF.Satus = "REVERTED";
                            }
                            else
                            {

                                messageEF.Satus = "FAILED";
                            }
                            #endregion
                            messageEF.Satus = "FAILED";
                        }
                        else if (!string.IsNullOrEmpty(strPG_TxnStatus) && strPG_TxnStatus.ToUpper() == "FAILURE")
                        {
                            DynamicParameters param2 = new DynamicParameters();
                            param2.Add("@TXN_STATUS", "FAILED");
                            param2.Add("@UserId", cancelVehiclePayment.UserId);
                            param2.Add("@CLNT_TXN_REF", permitType);
                            param2.Add("@TPSL_BANK_CD", dt.Rows[0]["BANKCODE"].ToString());
                            param2.Add("@TPSL_TXN_ID", "");
                            param2.Add("@TXN_AMT", dt.Rows[0]["AMOUNT"].ToString());
                            param2.Add("@TPSL_TXN_TIME", System.DateTime.Now);
                            param2.Add("@strPGRESPONSE", response);
                            param2.Add("@PAYMENTFOR", 1);// this value should be change as per payment recived.
                            param2.Add("@PaymentResponseID", 0);
                            await Connection.ExecuteReaderAsync("InsertUpdatePaymentRecords", param, commandType: System.Data.CommandType.StoredProcedure);

                        }
                        else
                        {
                            strResponse = response.ToUpper();
                            if (!string.IsNullOrEmpty(strResponse))
                            {

                                if (!string.IsNullOrEmpty(strPG_TxnStatus) && strPG_TxnStatus.ToUpper() == "SUCCESS")
                                {

                                    permitType = cancelVehiclePayment.PaymentType + cancelVehiclePayment.paymentReqId;

                                    if (permitType.StartsWith("VP"))
                                    {
                                        #region Vehicle Payments 
                                        string strBulkPermitID = permitType.Replace("VP", "").Trim();
                                        DynamicParameters param3 = new DynamicParameters();
                                        param3.Add("@PaymentVehicleID", strBulkPermitID);
                                        param3.Add("@UserId", cancelVehiclePayment.UserId);
                                        param3.Add("@PaymentStatus", "SUCCESS");
                                        param3.Add("@UserLoginId", cancelVehiclePayment.UserId);
                                        param3.Add("@CHECK", 2);
                                        param3.Add("@strPG_TRANSACTION_DATE", strPG_TRANSACTIONDATE);
                                        param3.Add("@CheckStatusCall", "1");
                                        IDataReader dr1 = await Connection.ExecuteReaderAsync("upsInsertVehicleMasterPaymentDetails", param, commandType: System.Data.CommandType.StoredProcedure);

                                        DataSet ds1 = new DataSet();
                                        ds1 = ConvertDataReaderToDataSet(dr1);
                                        DataTable dt1 = ds1.Tables[0];

                                        if (dt1 != null && dt1.Rows.Count > 0)
                                        {
                                            #region Send Mail
                                            try
                                            {

                                                TransporterMail transporterMail = new TransporterMail();
                                                transporterMail.EmailId = Convert.ToString(dt1.Rows[0]["EmailID"]);
                                                transporterMail.TotalVehiclesPayment = Convert.ToString(dt1.Rows[0]["RegFees"]);
                                                transporterMail.VehicleCount = Convert.ToInt32(dt1.Rows[0]["TotalVehicleCount"]);
                                                mailServiceProvider.SendMail_AddVehiclesAck(transporterMail);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                            #endregion

                                            #region Send SMS

                                            try
                                            {
                                                string message = "Vehicles are successfully registered in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details of vehicles registration. CHiMMS, GoCG";
                                                string templateid = "1307161883599887989";
                                                SMS sMS = new SMS();
                                                sMS.mobileNo = Convert.ToString(dt1.Rows[0]["MobileNo"]);
                                                sMS.message = message;
                                                sMS.templateid = templateid;
                                                sMSServiceProvider.Main(sMS);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                            #endregion
                                        }

                                        #endregion
                                    }
                                    else if (permitType.StartsWith("CVP"))
                                    {
                                        #region Vehicle Payments 
                                        DynamicParameters param4 = new DynamicParameters();
                                        param4.Add("@PaymentVehicleID", cancelVehiclePayment.paymentReqId);
                                        param4.Add("@UserId", cancelVehiclePayment.UserId);
                                        param4.Add("@PaymentStatus", "SUCCESS");
                                        param4.Add("@UserLoginId", cancelVehiclePayment.UserId);
                                        param4.Add("@CHECK", 4);
                                        param4.Add("@strPG_TRANSACTION_DATE", strPG_TRANSACTIONDATE);
                                        param4.Add("@CheckStatusCall", "1");
                                        IDataReader dr2 = await Connection.ExecuteReaderAsync("upsInsertVehicleMasterPaymentDetails", param, commandType: System.Data.CommandType.StoredProcedure);

                                        DataSet ds2 = new DataSet();
                                        ds2 = ConvertDataReaderToDataSet(dr2);
                                        DataTable dt2 = ds2.Tables[0];
                                        if (dt2 != null && dt2.Rows.Count > 0)
                                        {
                                            #region Send Mail
                                            try
                                            {
                                                TransporterMail transporterMail = new TransporterMail();
                                                transporterMail.EmailId = Convert.ToString(dt2.Rows[0]["EmailID"]);
                                                transporterMail.TotalVehiclesPayment = Convert.ToString(dt2.Rows[0]["RegFees"]);
                                                transporterMail.VehicleCount = Convert.ToInt32(dt2.Rows[0]["TotalVehicleCount"]);
                                                mailServiceProvider.SendMail_AddVehiclesAck(transporterMail);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                            #endregion

                                            #region Send SMS

                                            try
                                            {
                                                string message = "Vehicles are successfully registered in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details of vehicles registration, CHiMMS, GoCG";

                                                string templateid = "1307161883599887989";
                                                SMS sMS = new SMS();
                                                sMS.mobileNo = Convert.ToString(dt2.Rows[0]["MobileNo"]);
                                                sMS.message = message;
                                                sMS.templateid = templateid;
                                                sMSServiceProvider.Main(sMS);

                                            }
                                            catch (Exception)
                                            {

                                            }
                                            #endregion
                                        }

                                        #endregion
                                    }

                                    messageEF.Satus = "SUCCESS";
                                }
                                else if (strPG_TxnStatus.ToUpper() == "AWAITED" || strPG_TxnStatus.ToUpper() == "PENDING")
                                {
                                    messageEF.Satus = "AWAITED";
                                }
                            }
                            else
                            {
                                messageEF.Satus = "FAILED";
                            }
                        }
                        #endregion
                    }

                    return messageEF;

                }
                else
                {
                    messageEF.Satus = "FAILED";
                    return messageEF;

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        /// <summary>
        /// Add VTS Log
        /// </summary>
        /// <param name="vTSLog"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddVTSLog(VTSLog vTSLog)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@VTSApiName", vTSLog.VTSApiName);
                param.Add("@Result", vTSLog.Result);
                param.Add("@CreatedBy", vTSLog.CreatedBy);
                param.Add("@RequestedData", vTSLog.RequestedData);
                param.Add("@ResponseData", vTSLog.ResponseData);
                var result = await Connection.ExecuteScalarAsync("Sp_InsertVTSApiLog", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString(); 
            }
            catch(Exception ex)
            {
                messageEF.Satus = "some error has occurred.please try after sometime";
            }
            return messageEF;
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

        protected string GetMD5Hash(string name)
        {

            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encode = new UTF8Encoding();
            byte[] ba = md5.ComputeHash(encode.GetBytes(name));
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        #region SBI Decryption and Bifurcation

        string Encrypt(string textToEncrypt)
        {

            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] pwdBytes = GetFileBytes(Convert.ToString(configuration.GetSection("Path").GetSection("SBIENCKey").Value));
            byte[] keyBytes = new byte[0x10];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
            return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
        }


        string Decrypt(string textToDecrypt)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] encryptedData = Convert.FromBase64String(textToDecrypt);
            byte[] pwdBytes = GetFileBytes(Convert.ToString(configuration.GetSection("Path").GetSection("SBIENCKey").Value));
            byte[] keyBytes = new byte[0x10];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            byte[] plainText = rijndaelCipher.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }

        Byte[] GetFileBytes(String filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;
                buffer = new byte[length];
                int count;
                int sum = 0;
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        public void SBINETGetPGRespnseData(string[] parameters)
        {
            try
            {
                string[] strGetMerchantParamForCompare;

                for (int i = 0; i < parameters.Length; i++)
                {
                    strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                    if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXSTATUSDESC")
                    {
                        strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
                    }
                }
            }
            catch (Exception Exception)
            {
            }

        }

        public void GetPGRespnseData(string[] parameters)
        {
            string[] strGetMerchantParamForCompare;
            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_STATUS")
                {
                    strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_AMOUNT")
                {
                    strPG_TxnAmount = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TRANSACTION_DATE")
                {
                    strPG_TRANSACTIONDATE = Convert.ToString(strGetMerchantParamForCompare[1]);
                }

            }
        }

        #endregion
    }
}
