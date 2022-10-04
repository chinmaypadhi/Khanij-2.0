// ***********************************************************************
//  Class Name               : LesseeForestClearanceProvider
//  Description              : Lessee Environment Clearance Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 July 2021
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


namespace MasterApi.Model.LesseeEnvironmentClearance
{
    public class LesseeEnvironmentClearanceProvider : RepositoryBase, ILesseeEnvironmentClearanceProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeEnvironmentClearanceProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To bind FY details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeEnvironmentClearanceViewModel>> GetFYDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            List<LesseeEnvironmentClearanceViewModel> ObjEnvClearancelistDetailslist = new List<LesseeEnvironmentClearanceViewModel>();
            try
            {
                var paramList = new
                {
                    Check = 4
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeEnvironmentClearanceViewModel>("[GetFinancialYearList]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjEnvClearancelistDetailslist = result.ToList();
                }
                return ObjEnvClearancelistDetailslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<LesseeEnvironmentClearanceViewModel> GetEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            LesseeEnvironmentClearanceViewModel ObjEnvClearancelistDetails = new LesseeEnvironmentClearanceViewModel();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeEnvironmentClearanceModel.CREATED_BY,
                    CHECK = 1
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeEnvironmentClearanceViewModel>("[USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjEnvClearancelistDetails = result.FirstOrDefault();
                }
                return ObjEnvClearancelistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Approved Quantity details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetApprovedQuantityDetails(MiningProductionModel objLesseeEnvironmentClearanceModel)
        {
            List<MiningProductionModel> ObjEnvClearancelistDetailslist = new List<MiningProductionModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeEnvironmentClearanceModel.CREATED_BY,
                    CHECK = 8
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MiningProductionModel>("[USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjEnvClearancelistDetailslist = result.ToList();
                }
                return ObjEnvClearancelistDetailslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Environment Clearance details
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        public MessageEF UpdateEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("LICENSEE_EC_ID", objLesseeEnvironmentClearanceModel.LICENSEE_EC_ID);
                p.Add("CREATED_BY", objLesseeEnvironmentClearanceModel.CREATED_BY);
                p.Add("USER_LOGIN_ID", objLesseeEnvironmentClearanceModel.UserLoginId);
                p.Add("EC_ORDRER_NUMBER", objLesseeEnvironmentClearanceModel.EC_ORDRER_NUMBER);
                p.Add("EC_APPROVED_CAPACITY", objLesseeEnvironmentClearanceModel.EC_APPROVED_CAPACITY);
                p.Add("ApplicationDateOfEC", objLesseeEnvironmentClearanceModel.EC_APPLICATON_DATE);
                p.Add("STATUS", objLesseeEnvironmentClearanceModel.STATUS);
                p.Add("EC_VALID_FROM", objLesseeEnvironmentClearanceModel.EC_VALID_FROM);
                p.Add("EC_VALID_TO", objLesseeEnvironmentClearanceModel.EC_VALID_TO);
                p.Add("EC_CLEARANCE_PATH", objLesseeEnvironmentClearanceModel.EC_CLEARANCE_PATH);
                p.Add("FILE_EC_CLEARANCE", objLesseeEnvironmentClearanceModel.FILE_EC_CLEARANCE);
                p.Add("Mineralid", objLesseeEnvironmentClearanceModel.MineralId);
                if (objLesseeEnvironmentClearanceModel.dtFYApprovedQuantity != null && objLesseeEnvironmentClearanceModel.dtFYApprovedQuantity.Rows.Count > 0)
                {
                    p.Add("BULK_PRODUCTION", objLesseeEnvironmentClearanceModel.dtFYApprovedQuantity, DbType.Object);
                }
                p.Add("CHECK", "2");                
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To get Environment Clearance Approved Quantity details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceLogDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            List<LesseeEnvironmentClearanceViewModel> ObjECLogDetails = new List<LesseeEnvironmentClearanceViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeEnvironmentClearanceModel.CREATED_BY,
                    CHECK = 5
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeEnvironmentClearanceViewModel>("[USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjECLogDetails = result.ToList();
                }
                return ObjECLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Approved Quantity Log History details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceApprovedQuantityLogDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            List<LesseeEnvironmentClearanceViewModel> ObjECLogDetails = new List<LesseeEnvironmentClearanceViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeEnvironmentClearanceModel.CREATED_BY,
                    CHECK = 9
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeEnvironmentClearanceViewModel>("[USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjECLogDetails = result.ToList();
                }
                return ObjECLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Approved Quantity Log History details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceApprovedQuantityLogDetailsView(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            List<LesseeEnvironmentClearanceViewModel> ObjECLogDetails = new List<LesseeEnvironmentClearanceViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeEnvironmentClearanceModel.CREATED_BY,
                    MODIFIED_ON = objLesseeEnvironmentClearanceModel.MODIFIED_ON,
                    LICENSEE_EC_ID = objLesseeEnvironmentClearanceModel.LICENSEE_EC_ID,
                    STATUS = objLesseeEnvironmentClearanceModel.STATUS,
                    CHECK = 10
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeEnvironmentClearanceViewModel>("[USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjECLogDetails = result.ToList();
                }
                return ObjECLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Compare details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceCompareDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            List<LesseeEnvironmentClearanceViewModel> ObjECLogDetails = new List<LesseeEnvironmentClearanceViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeEnvironmentClearanceModel.CREATED_BY,
                    CHECK = 6
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeEnvironmentClearanceViewModel>("[USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjECLogDetails = result.ToList();
                }
                return ObjECLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Compare details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetEnvironmentClearanceApprovedQuantityCompareDetails(MiningProductionModel objLesseeEnvironmentClearanceModel)
        {
            List<MiningProductionModel> ObjECLogDetails = new List<MiningProductionModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeEnvironmentClearanceModel.CREATED_BY,
                    CHECK = 12
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MiningProductionModel>("[USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjECLogDetails = result.ToList();
                }
                return ObjECLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 3);
                p.Add("APPROVED_BY", objLesseeEnvironmentClearanceModel.UserLoginId);
                p.Add("LICENSEE_EC_ID", objLesseeEnvironmentClearanceModel.LICENSEE_EC_ID);
                p.Add("Remarks", objLesseeEnvironmentClearanceModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To Reject Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 4);
                p.Add("REJECTED_BY", objLesseeEnvironmentClearanceModel.UserLoginId);
                p.Add("LICENSEE_EC_ID", objLesseeEnvironmentClearanceModel.LICENSEE_EC_ID);
                p.Add("Remarks", objLesseeEnvironmentClearanceModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To Delete Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 7);
                p.Add("USER_LOGIN_ID", objLesseeEnvironmentClearanceModel.CREATED_BY);
                p.Add("LICENSEE_EC_ID", objLesseeEnvironmentClearanceModel.LICENSEE_EC_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
    }
}
