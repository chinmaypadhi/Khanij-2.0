// ***********************************************************************
//  Class Name               : LesseeLeaseAreaProvider
//  Description              : Lessee Lease Area Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 21 July 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.LesseeLeaseArea
{
    public class LesseeLeaseAreaProvider:RepositoryBase,ILesseeLeaseAreaProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeLeaseAreaProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To Bind the State Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetStateList(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjStateList = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    Chk = "State",
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<LeaseAreaViewModel>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Bind the District Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetDistrictList(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjDistrictList = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    Chk = "District",
                    StateID = objLeaseAreaModel.StateId
                };
                DynamicParameters param = new DynamicParameters();

                var Output = await Connection.QueryAsync<LeaseAreaViewModel>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
        /// To Bind the Tehsil Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetTehsilList(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjTehsilList = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    DistrictId = objLeaseAreaModel.DistrictId,
                    ACTION = "Q"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<LeaseAreaViewModel>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Bind the Village Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetVillageList(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjVillageList = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    TehsilID = objLeaseAreaModel.TehsilID,
                    chk = "9"
                };
                DynamicParameters param = new DynamicParameters();

                var Output = await Connection.QueryAsync<LeaseAreaViewModel>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
        /// To bind Lessee Lease Area details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<LeaseAreaViewModel> GetLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            LeaseAreaViewModel ObjGrantOrderDetails = new LeaseAreaViewModel();
            try
            {
                var paramList = new
                {
                    USER_ID = objLeaseAreaModel.CREATED_BY,
                    SP_MODE = "GETDATA"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LeaseAreaViewModel>("[USP_LESSEE_LICENSE_AREA]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjGrantOrderDetails = result.FirstOrDefault();
                }
                return ObjGrantOrderDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Lease land District Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLeaseLandDistrictList(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjDistrictList = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    SP_MODE = "DISTRICT",
                    STATE_ID = objLeaseAreaModel.StateId
                };
                DynamicParameters param = new DynamicParameters();

                var Output = await Connection.QueryAsync<LeaseAreaViewModel>("[USP_LESSEE_LICENSE_AREA]", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
        /// To Bind the Lease Land Village Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLeaseLandVillageList(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjVillageList = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    TEHSIL_FOREST_DIVISION = objLeaseAreaModel.TehsilID,
                    SP_MODE = "VILLAGE"
                };
                DynamicParameters param = new DynamicParameters();

                var Output = await Connection.QueryAsync<LeaseAreaViewModel>("[USP_LESSEE_LICENSE_AREA]", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
        /// To Save/Update,ForwardToDD Lesse Lease Area details
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        public MessageEF UpdateLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("USER_ID", objLeaseAreaModel.CREATED_BY);
                p.Add("SP_MODE", "SAVEDATA");
                p.Add("LICENSE_AREA_ID", objLeaseAreaModel.LICENSE_AREA_ID);
                p.Add("VILLAGE_ID", objLeaseAreaModel.VillageID);
                p.Add("BLOCK_FOREST_RANGE", objLeaseAreaModel.BLOCK_FOREST_RANGE);
                p.Add("TEHSIL_FOREST_DIVISION", objLeaseAreaModel.TehsilID);
                p.Add("DISTRICT_ID", objLeaseAreaModel.DistrictId);
                p.Add("STATE_ID", objLeaseAreaModel.StateId);
                p.Add("PIN_CODE", objLeaseAreaModel.PIN_CODE);
                p.Add("TYPE_OF_LAND", objLeaseAreaModel.TYPE_OF_LAND);
                p.Add("AREA_IN_HECT", objLeaseAreaModel.AREA_IN_HECT);
                p.Add("TOPOSHEET_NO", objLeaseAreaModel.TOPOSHEET_NO);
                p.Add("COORDINATES", objLeaseAreaModel.COORDINATES);
                p.Add("POLICE_STATION", objLeaseAreaModel.POLICE_STATION);
                p.Add("GRAM_PANCHAYAT", objLeaseAreaModel.GRAM_PANCHAYAT);
                p.Add("STATUS", objLeaseAreaModel.STATUS);
                p.Add("USER_LOGIN_ID", objLeaseAreaModel.UserId);
                p.Add("Forest", objLeaseAreaModel.Forest);
                p.Add("RevenueForest", objLeaseAreaModel.RevenueForest);
                p.Add("RevenueGovernmentLand", objLeaseAreaModel.RevenueGovernmentLand);
                p.Add("PrivateTribal", objLeaseAreaModel.PrivateTribal);
                p.Add("PrivateNonTribal", objLeaseAreaModel.PrivateNonTribal);
                p.Add("Nistar", objLeaseAreaModel.Nistar);
                p.Add("LandUnderVidhansabhakshetra", objLeaseAreaModel.LandUnderVidhansabhakshetra);
                p.Add("DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH", objLeaseAreaModel.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH);
                p.Add("DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME", objLeaseAreaModel.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME);
                p.Add("FILE_COORDINATES_PILLARS", objLeaseAreaModel.FILE_COORDINATES_PILLARS);
                p.Add("PATH_COORDINATES_PILLARS", objLeaseAreaModel.PATH_COORDINATES_PILLARS);
                p.Add("FILE_LEASE_AREA_MAP", objLeaseAreaModel.FILE_LEASE_AREA_MAP);
                p.Add("PATH_LEASE_AREA_MAP", objLeaseAreaModel.PATH_LEASE_AREA_MAP);
                if (objLeaseAreaModel.WORKING_PERMISSION_DATE != null)
                {
                    p.Add("WORKING_PERMISSION_DATE", objLeaseAreaModel.WORKING_PERMISSION_DATE);
                }
                p.Add("WORKING_PERMISSION_COPY_PATH", objLeaseAreaModel.WORKING_PERMISSION_COPY_PATH);
                p.Add("WORKING_PERMISSION_COPY_NAME", objLeaseAreaModel.WORKING_PERMISSION_COPY_NAME);
                if (objLeaseAreaModel.COMMENCEMENT_OF_MINING_DATE != null)
                {
                    p.Add("COMENCEMENT_OF_MINING_DATE", objLeaseAreaModel.COMMENCEMENT_OF_MINING_DATE);
                }
                p.Add("COMENCEMENT_OF_MINING_FILE_PATH", objLeaseAreaModel.COMMENCEMENT_OF_MINING_PATH);
                p.Add("COMENCEMENT_OF_MINING_FILE_NAME", objLeaseAreaModel.COMMENCEMENT_OF_MINING_COPY_NAME);
                if (objLeaseAreaModel.DATE_OF_EXECUTION != null)
                {
                    p.Add("DATE_OF_EXECUTION", objLeaseAreaModel.DATE_OF_EXECUTION);
                }
                p.Add("FILE_COORDINATES_PILLARS", objLeaseAreaModel.FILE_COORDINATES_PILLARS);
                p.Add("PATH_COORDINATES_PILLARS", objLeaseAreaModel.PATH_COORDINATES_PILLARS);
                p.Add("FILE_LEASE_AREA_MAP", objLeaseAreaModel.FILE_LEASE_AREA_MAP);
                p.Add("PATH_LEASE_AREA_MAP", objLeaseAreaModel.PATH_LEASE_AREA_MAP);
                p.Add("LEASELAND_DISRICT_ID", objLeaseAreaModel.LEASELAND_DISRICT_ID);
                p.Add("LEASELAND_GP", objLeaseAreaModel.LEASELAND_GP);
                p.Add("LEASELAND_VILLAGE_ID", objLeaseAreaModel.LEASELAND_VILLAGE_ID);
                p.Add("LEASELAND_KHASRA_NO", objLeaseAreaModel.LEASELAND_KHASRA_NO);
                p.Add("LEASELAND_BASRA_NO", objLeaseAreaModel.LEASELAND_BASRA_NO);
                p.Add("LEASELAND_DHARANADIKAR", objLeaseAreaModel.LEASELAND_DHARANADIKAR);
                p.Add("LEASELAND_AREA_TYPE", objLeaseAreaModel.LEASELAND_AREA_TYPE);
                if (objLeaseAreaModel.LEASELAND_AREA_TYPE != "Forest")
                {
                    objLeaseAreaModel.LEASELAND_AREA_SUB_TYPE = objLeaseAreaModel.LEASELAND_AREA_NF_SUB_TYPE;
                }
                p.Add("LEASELAND_AREA_SUB_TYPE", objLeaseAreaModel.LEASELAND_AREA_SUB_TYPE);
                p.Add("LEASELAND_AREA", objLeaseAreaModel.LEASELAND_AREA);
                p.Add("LEASELAND_SURFACE_RIGHT_AREA", objLeaseAreaModel.LEASELAND_SURFACE_RIGHT_AREA);
                p.Add("LEASELAND_MAP", objLeaseAreaModel.LEASELAND_MAP);
                p.Add("LokSabha", objLeaseAreaModel.LokSabha);
                p.Add("VidhanSabha", objLeaseAreaModel.VidhanSabha);
                p.Add("BlockId", objLeaseAreaModel.BlockId);
                p.Add("LEASELAND_BLOCK_ID", objLeaseAreaModel.LEASELAND_BLOCK_ID);
                p.Add("BlockId", objLeaseAreaModel.BlockId);
                p.Add("FOREST_RANGE", objLeaseAreaModel.FOREST_RANGE);
                if (objLeaseAreaModel.FOREST_RANGE == "Protected,Revenue")
                {
                    p.Add("ForestRangeProtected", objLeaseAreaModel.ForestRangeProtected);
                    p.Add("ForestRangeRevenue", objLeaseAreaModel.ForestRangeRevenue);
                    p.Add("COMPARTMENT_NUMBER", objLeaseAreaModel.COMPARTMENT_NUMBER);
                }
                else
                {
                    objLeaseAreaModel.ForestRangeProtected = objLeaseAreaModel.FOREST_RANGE != "Protected" ? 0 : objLeaseAreaModel.ForestRangeProtected;
                    p.Add("ForestRangeProtected", objLeaseAreaModel.ForestRangeProtected);
                    objLeaseAreaModel.ForestRangeRevenue = objLeaseAreaModel.FOREST_RANGE != "Revenue" ? 0 : objLeaseAreaModel.ForestRangeRevenue;
                    p.Add("ForestRangeRevenue", objLeaseAreaModel.ForestRangeRevenue);
                    objLeaseAreaModel.COMPARTMENT_NUMBER = objLeaseAreaModel.FOREST_RANGE != "Revenue" ? null : objLeaseAreaModel.COMPARTMENT_NUMBER;
                    p.Add("COMPARTMENT_NUMBER", objLeaseAreaModel.COMPARTMENT_NUMBER);
                }
                if (objLeaseAreaModel.dtCoordinatePillars != null && objLeaseAreaModel.dtCoordinatePillars.Rows.Count > 0)
                {
                    p.Add("BULK_PRODUCTION", objLeaseAreaModel.dtCoordinatePillars, DbType.Object);
                }
                p.Add("DATA_LEASE_AREA_MAP", objLeaseAreaModel.DATA_LEASE_AREA_MAP);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_LICENSE_AREA]", p, commandType: CommandType.StoredProcedure);
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
        /// To bind Lease Area Log History details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLeaseAreaLogDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjLeaseAreaLogDetails = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLeaseAreaModel.UserId,
                    SP_MODE = "LOGHISTORY"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LeaseAreaViewModel>("[USP_LESSEE_LICENSE_AREA]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLeaseAreaLogDetails = result.ToList();
                }
                return ObjLeaseAreaLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Lessee Lease Area Compare details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLeaseAreaCompareDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjLeaseAreaCompareDetails = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLeaseAreaModel.UserId,
                    SP_MODE = "COMPARE"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LeaseAreaViewModel>("[USP_LESSEE_LICENSE_AREA]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLeaseAreaCompareDetails = result.ToList();
                }
                return ObjLeaseAreaCompareDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("APPROVED_BY", objLeaseAreaModel.UserId);
                p.Add("SP_MODE", "APPROVE");
                p.Add("USER_ID", objLeaseAreaModel.CREATED_BY);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_LICENSE_AREA]", p, commandType: CommandType.StoredProcedure);
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
        /// To Reject Lesse Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public MessageEF RejectLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("REJECTED_BY", objLeaseAreaModel.UserId);
                p.Add("SP_MODE", "REJECT");
                p.Add("UserId", objLeaseAreaModel.CREATED_BY);
                p.Add("Remarks", objLeaseAreaModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_LESSEE_LICENSE_AREA", p, commandType: CommandType.StoredProcedure);
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
        /// To Delete Lesse Lease Area details
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", "DELETE");
                p.Add("UserId", objLeaseAreaModel.CREATED_BY);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_LICENSE_AREA]", p, commandType: CommandType.StoredProcedure);
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
        /// To Bind the Land Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLandList(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjLandList = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    ACTION = "P",
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<LeaseAreaViewModel>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjLandList = Output.ToList();
                }
                return ObjLandList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Lease land Block Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLeaseLandBlockList(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjBlockList = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    SP_MODE = "BLOCK",
                    LEASELAND_DISRICT_ID = objLeaseAreaModel.LEASELAND_DISRICT_ID
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<LeaseAreaViewModel>("[USP_LESSEE_LICENSE_AREA]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjBlockList = Output.ToList();
                }
                return ObjBlockList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Vidhan Sabha Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetVidhanSabhaList(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjStateList = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    ACTION = "U",
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<LeaseAreaViewModel>("[USP_FILL_COMMON_DATA]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Bind the Lok Sabha Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLokSabhaList(LeaseAreaViewModel objLeaseAreaModel)
        {
            List<LeaseAreaViewModel> ObjStateList = new List<LeaseAreaViewModel>();
            try
            {
                var paramList = new
                {
                    ACTION = "V",
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<LeaseAreaViewModel>("[USP_FILL_COMMON_DATA]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
    }
}
