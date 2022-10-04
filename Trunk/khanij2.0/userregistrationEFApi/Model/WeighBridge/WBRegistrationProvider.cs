using Dapper;
using MasterApi.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;
namespace userregistrationEFApi.Model.WeighBridge
{
    public class WBRegistrationProvider : RepositoryBase, IWBRegisterProvider
    {
        public WBRegistrationProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public async Task<List<ViewWeighBridgeModel>> ViewWBByDistrict(ViewWeighBridgeModel obj)
        {
            List<ViewWeighBridgeModel> objviewlist = new List<ViewWeighBridgeModel>();
            try
            {
                var paramList = new
                {
                    District = obj.District,
                    ACTION = "VIEWBYDISTRICT"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeModel>("WeighBridgeView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ViewWeighBridgeModel>> ViewWBByUserID(ViewWeighBridgeModel obj)
        {
            List<ViewWeighBridgeModel> objviewlist = new List<ViewWeighBridgeModel>();
            try
            {
                var paramList = new
                {
                    UserID = obj.UserID,
                    ACTION = "VIEWBYUSERID"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeModel>("WeighBridgeView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ViewWeighBridgeModel>> RenewalWBByUserID(ViewWeighBridgeModel obj)
        {
            List<ViewWeighBridgeModel> objviewlist = new List<ViewWeighBridgeModel>();
            try
            {
                var paramList = new
                {
                    UserID = obj.UserID,
                    ACTION = "RENEWBYUSERID"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeModel>("WeighBridgeView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ViewWeighBridgeModel>> HistoryWBByID(ViewWeighBridgeModel obj)
        {
            List<ViewWeighBridgeModel> objviewlist = new List<ViewWeighBridgeModel>();
            try
            {
                var paramList = new
                {
                    WeighBridgeID = obj.WeighBridgeID,
                    ACTION = "HISTORYBYWBID"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeModel>("WeighBridgeView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ViewWeighBridgeModel> ViewWBByWeighBridgeID(ViewWeighBridgeModel objmodel)
        {
            ViewWeighBridgeModel objview = new ViewWeighBridgeModel();
            try
            {
                var paramList = new
                {
                    WeighBridgeID = objmodel.WeighBridgeID,
                    ACTION = "VIEWBYWBID"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeModel>("WeighBridgeView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objview = Output.FirstOrDefault();
                }
                return objview;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MessageEF> WBApprove(ViewWeighBridgeModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeID", objmodel.WeighBridgeID);
                p.Add("@UserID", objmodel.UserID);
                p.Add("@ActionId", objmodel.ApproveType);
                p.Add("@intActivity", objmodel.ActivityId);
                if (objmodel.ApproveType== "2")//approve
                { 
                    if(objmodel.IsRenewal)
                        p.Add("@Status", 8);
                    else
                        p.Add("@Status", 5);
                    p.Add("@ApprovalOrderFile", objmodel.ApprovalOrderFilePath);
                }
                    
                else if (objmodel.ApproveType == "4")//object
                {
                    if (objmodel.IsRenewal)
                        p.Add("@Status", 7);
                    else
                        p.Add("@Status", 3);

                }
                    
                else if (objmodel.ApproveType == "3")//reject
                p.Add("@Status", 4);
                p.Add("@ApprovedBy", objmodel.UserID);
                p.Add("@ApproveRemarks", objmodel.ApproveRemarks);
                p.Add("@ACTION", "APPROVE");
                p.Add("P_INT_RESULT", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeRegistration", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("P_INT_RESULT");
                if (!string.IsNullOrEmpty(result.ToString()))
                {
                    objMessage.Satus = result.ToString();
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
        public async Task<AddWeighBridgeModel> WBByID(ViewWeighBridgeModel objmodel)
        {
            AddWeighBridgeModel obj = new AddWeighBridgeModel();
            try
            {
                var paramList = new
                {
                    WeighBridgeID = objmodel.WeighBridgeID,
                    ACTION = "EDITBYWBID"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<AddWeighBridgeModel>("WeighBridgeView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    obj = Output.FirstOrDefault();
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MessageEF> WBForward(ViewWeighBridgeModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeID", objmodel.WeighBridgeID);
                p.Add("@UserID", objmodel.UserID);
                p.Add("@ACTION", "FORWARD");
                p.Add("@intActivity", objmodel.ActivityId);
                p.Add("P_INT_RESULT", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeRegistration", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("P_INT_RESULT");
                if (!string.IsNullOrEmpty(result.ToString()))
                {
                    objMessage.Satus = result.ToString();
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
        public async Task<MessageEF> WBCheck(ViewWeighBridgeModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeName", objmodel.WeighBridgeName);
                p.Add("@ACTION", "CHECK");
                p.Add("P_INT_RESULT", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeRegistration", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("P_INT_RESULT");
                if (!string.IsNullOrEmpty(result.ToString()))
                {
                    objMessage.Satus = result.ToString();
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
        public async Task<MessageEF> WBCheckContact(ViewWeighBridgeModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@SupervisorContact", objmodel.SupervisorContact);
                p.Add("@ACTION", "CONTACT");
                p.Add("P_INT_RESULT", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeRegistration", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("P_INT_RESULT");
                if (!string.IsNullOrEmpty(result.ToString()))
                {
                    objMessage.Satus = result.ToString();
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
        public async Task<MessageEF> WBRegister(AddWeighBridgeModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeName", objmodel.WeighBridgeName);
                p.Add("@UserID", objmodel.UserID);
                p.Add("@UserType", objmodel.UserType);
                p.Add("@SupervisorName", objmodel.SupervisorName);
                p.Add("@SupervisorContact", objmodel.SupervisorContact);
                p.Add("@MakeID", objmodel.MakeID);
                p.Add("@ModelID", objmodel.ModelID);
                p.Add("@ModemBaudRate", objmodel.ModelBaudRate);
                p.Add("@DataBit", objmodel.DataBit);
                p.Add("@StopBit", objmodel.StopBit);
                p.Add("@Parity", objmodel.Parity);
                p.Add("@HyperterminalReading", objmodel.HyperterminalReading);
                p.Add("@Capacity", objmodel.Capacity);
                p.Add("@LandAreaTypeID", objmodel.LandAreaTypeID);
                p.Add("@Area_of_Land", objmodel.AreaofLand);
                p.Add("@Location", objmodel.Location);
                p.Add("@District", objmodel.District);
                p.Add("@Lat1", objmodel.Lat1);
                p.Add("@Lon1", objmodel.Lon1);
                p.Add("@Lat2", objmodel.Lat2);
                p.Add("@Lon2", objmodel.Lon2);
                p.Add("@Lat3", objmodel.Lat3);
                p.Add("@Lon3", objmodel.Lon3);
                p.Add("@Lat4", objmodel.Lat4);
                p.Add("@Lon4", objmodel.Lon4);
                p.Add("@ElecticityAvailability", objmodel.ElectricityAvailablity);
                p.Add("@InternetAvailability", objmodel.InternetAvailability);
                p.Add("@WeighBridgeType", objmodel.WeighBridgeType);
                p.Add("@Updated_By", objmodel.UserID);
                p.Add("@StampingCopyFilePath", objmodel.StampCopyFilePath);
                p.Add("@StampingValidFrom", objmodel.StampValidFrom);
                p.Add("@StampingValidTo", objmodel.StampValidTo);
                p.Add("@Status", 1);
                p.Add("@ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeRegistration", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("P_INT_RESULT");
                if (!string.IsNullOrEmpty(result.ToString()))
                {
                    objMessage.Satus = result.ToString();
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
        public async Task<MessageEF> WBRenewal(AddWeighBridgeRenewal objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeID", objmodel.WeighBridgeID);
                p.Add("@StampingCopyFilePath", objmodel.StampCopyFilePath);
                p.Add("@StampingValidFrom", objmodel.StampValidFrom);
                p.Add("@StampingValidTo", objmodel.StampValidTo);
                p.Add("@Remarks", objmodel.Remarks);
                p.Add("@UserID", objmodel.UserID);
                p.Add("@ACTION", "RENEW");
                p.Add("P_INT_RESULT", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeRegistration", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("P_INT_RESULT");
                if (!string.IsNullOrEmpty(result.ToString()))
                {
                    objMessage.Satus = result.ToString();
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
        public async Task<MessageEF> WBRegisterEdit(AddWeighBridgeModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@ID", objmodel.ID);
                p.Add("@WeighBridgeID", objmodel.WeighBridgeID);
                p.Add("@WeighBridgeName", objmodel.WeighBridgeName);
                p.Add("@UserID", objmodel.UserID);
                p.Add("@UserType", objmodel.UserType);
                p.Add("@SupervisorName", objmodel.SupervisorName);
                p.Add("@SupervisorContact", objmodel.SupervisorContact);
                p.Add("@MakeID", objmodel.MakeID);
                p.Add("@ModelID", objmodel.ModelID);
                p.Add("@ModemBaudRate", objmodel.ModelBaudRate);
                p.Add("@DataBit", objmodel.DataBit);
                p.Add("@StopBit", objmodel.StopBit);
                p.Add("@Parity", objmodel.Parity);
                p.Add("@HyperterminalReading", objmodel.HyperterminalReading);
                p.Add("@Capacity", objmodel.Capacity);
                p.Add("@LandAreaTypeID", objmodel.LandAreaTypeID);
                p.Add("@Area_of_Land", objmodel.AreaofLand);
                p.Add("@Location", objmodel.Location);
                p.Add("@District", objmodel.District);
                p.Add("@Lat1", objmodel.Lat1);
                p.Add("@Lon1", objmodel.Lon1);
                p.Add("@Lat2", objmodel.Lat2);
                p.Add("@Lon2", objmodel.Lon2);
                p.Add("@Lat3", objmodel.Lat3);
                p.Add("@Lon3", objmodel.Lon3);
                p.Add("@Lat4", objmodel.Lat4);
                p.Add("@Lon4", objmodel.Lon4);
                p.Add("@ElecticityAvailability", objmodel.ElectricityAvailablity);
                p.Add("@InternetAvailability", objmodel.InternetAvailability);
                p.Add("@WeighBridgeType", objmodel.WeighBridgeType);
                p.Add("@Updated_By", objmodel.UserID);
                p.Add("@StampingCopyFilePath", objmodel.StampCopyFilePath);
                p.Add("@StampingValidFrom", objmodel.StampValidFrom);
                p.Add("@StampingValidTo", objmodel.StampValidTo);
                p.Add("@Status", 1);
                p.Add("@ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeRegistration", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("P_INT_RESULT");
                if (!string.IsNullOrEmpty(result.ToString()))
                {
                    objMessage.Satus = result.ToString();
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

        public async Task<MessageEF> WBIndependentRegister(AddIndependentWeighBridgeModel objmodel)
        {
            MessageEF objMessage = new MessageEF();

            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeName", objmodel.WeighBridgeName);
                p.Add("@UserID", objmodel.UserID);
                p.Add("@UserType", objmodel.UserType);
                p.Add("@SupervisorName", objmodel.SupervisorName);
                p.Add("@SupervisorContact", objmodel.SupervisorContact);
                p.Add("@MakeID", objmodel.MakeID);
                p.Add("@ModelID", objmodel.ModelID);
                p.Add("@ModemBaudRate", objmodel.ModelBaudRate);
                p.Add("@DataBit", objmodel.DataBit);
                p.Add("@StopBit", objmodel.StopBit);
                p.Add("@Parity", objmodel.Parity);
                p.Add("@HyperterminalReading", objmodel.HyperterminalReading);
                p.Add("@Capacity", objmodel.Capacity);
                p.Add("@LandAreaTypeID", objmodel.LandAreaTypeID);
                p.Add("@Area_of_Land", objmodel.AreaofLand);
                p.Add("@Location", objmodel.Location);
                p.Add("@DistrictID", objmodel.DistrictID);
                p.Add("@District", objmodel.District);
                p.Add("@Lat1", objmodel.Lat1);
                p.Add("@Lon1", objmodel.Lon1);
                p.Add("@Lat2", objmodel.Lat2);
                p.Add("@Lon2", objmodel.Lon2);
                p.Add("@Lat3", objmodel.Lat3);
                p.Add("@Lon3", objmodel.Lon3);
                p.Add("@Lat4", objmodel.Lat4);
                p.Add("@Lon4", objmodel.Lon4);
                p.Add("@ElecticityAvailability", objmodel.ElectricityAvailablity);
                p.Add("@InternetAvailability", objmodel.InternetAvailability);
                p.Add("@WeighBridgeType", objmodel.WeighBridgeType);
                p.Add("@Updated_By", objmodel.UserID);
                p.Add("@StampingCopyFilePath", objmodel.StampCopyFilePath);
                p.Add("@StampingValidFrom", objmodel.StampValidFrom);
                p.Add("@StampingValidTo", objmodel.StampValidTo);
                p.Add("@Status", 1);
                p.Add("@Email", objmodel.Email);
                p.Add("@Address", objmodel.Address);
                p.Add("@PinCode", objmodel.PinCode);
                p.Add("@ACTION", "TEST");
                p.Add("P_INT_RESULT", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeRegistration", p, commandType: CommandType.StoredProcedure);
                string result = rr.ToString();
                if (result != "0")
                {
                    objMessage.Satus = "1";
                    objMessage.Msg = result;
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

        public async Task<ViewIndependentUserDetailModel> ViewIndependentByUserID(ViewIndependentUserDetailModel objmodel)
        {
            ViewIndependentUserDetailModel objview = new ViewIndependentUserDetailModel();
            try
            {
                var paramList = new
                {
                    UserId = objmodel.UserId
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewIndependentUserDetailModel>("uspIndependentWBUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objview = Output.FirstOrDefault();
                }
                return objview;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ViewWeighBridgeModel>> ViewWeighBridgeTagActionList(ViewWeighBridgeModel obj)
        {
            List<ViewWeighBridgeModel> objviewlist = new List<ViewWeighBridgeModel>();
            try
            {
                

                var paramList = new
                {
                    ACTION = "ViewActionList",
                    ActivityId = obj.ActivityId,
                    status = obj.Status
                    
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeModel>("WeighBridgeView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
