// ***********************************************************************
//  Class Name               : LesseeMiningPlanProvider
//  Description              : Lessee Mining Plan Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 August 2021
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

namespace MasterApi.Model.LesseeMiningPlan
{
    public class LesseeMiningPlanProvider: RepositoryBase,ILesseeMiningPlanProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeMiningPlanProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To bind Mining Plan Financial year details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMiningPlanViewModel>> GetFYDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            List<LesseeMiningPlanViewModel> ObjMiningPlanlistDetails = new List<LesseeMiningPlanViewModel>();
            try
            {
                var paramList = new
                {
                    Check = 4
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMiningPlanViewModel>("[GetFinancialYearList]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMiningPlanlistDetails = result.ToList();
                }
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Plan details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<LesseeMiningPlanViewModel> GetMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            LesseeMiningPlanViewModel ObjMiningPlanDetails = new LesseeMiningPlanViewModel();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeMiningPlanModel.CREATED_BY,
                    SP_MODE = "GET_DATA"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMiningPlanViewModel>("[USP_LESSEE_MININGPLAN]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMiningPlanDetails = result.FirstOrDefault();
                }
                return ObjMiningPlanDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Plan Production details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetProductionDetails(MiningProductionModel objLesseeMiningPlanModel)
        {
            List<MiningProductionModel> ObjProdlistDetails = new List<MiningProductionModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeMiningPlanModel.CREATED_BY,
                    SP_MODE = "GET_PRODDATA"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MiningProductionModel>("[USP_LESSEE_MININGPLAN]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjProdlistDetails = result.ToList();
                }
                return ObjProdlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Mining Plan details
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        public MessageEF UpdateMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("USER_ID", objLesseeMiningPlanModel.CREATED_BY);
                p.Add("MINING_PLAN_ID", objLesseeMiningPlanModel.MINING_PLAN_ID);
                if (objLesseeMiningPlanModel.MP_APPROVE_DATE != null)
                {
                    p.Add("MP_APPROVE_DATE", objLesseeMiningPlanModel.MP_APPROVE_DATE);
                }
                if (objLesseeMiningPlanModel.MP_EXPIRY_DATE != null)
                {
                    p.Add("MP_EXPIRY_DATE", objLesseeMiningPlanModel.MP_EXPIRY_DATE);
                }
                if (objLesseeMiningPlanModel.MP_VALID_FORM != null)
                {
                    p.Add("MP_VALID_FORM", objLesseeMiningPlanModel.MP_VALID_FORM);
                }
                if (objLesseeMiningPlanModel.MP_VALID_TO != null)
                {
                    p.Add("MP_VALID_TO", objLesseeMiningPlanModel.MP_VALID_TO);
                }
                p.Add("STATUS", objLesseeMiningPlanModel.STATUS);
                p.Add("MP_APPROVAL_NO", objLesseeMiningPlanModel.MP_APPROVAL_NO);
                if (objLesseeMiningPlanModel.dtMines != null && objLesseeMiningPlanModel.dtMines.Rows.Count > 0)
                {
                    p.Add("BULK_PRODUCTION", objLesseeMiningPlanModel.dtMines,DbType.Object);
                }
                p.Add("MP_SOM_FilePath", objLesseeMiningPlanModel.MP_SOM_FilePath);
                p.Add("MP_SOM_FileName", objLesseeMiningPlanModel.MP_SOM_FileName);
                p.Add("SP_MODE", "SAVE_DATA");
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_MININGPLAN]", p, commandType: CommandType.StoredProcedure);
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
        /// To bind Mining Plan Log History details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMiningPlanViewModel>> GetMiningPlanMPLogDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            List<LesseeMiningPlanViewModel> ObjMiningPlanlistDetails = new List<LesseeMiningPlanViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeMiningPlanModel.CREATED_BY,
                    SP_MODE = "LOGHISTORYMP"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMiningPlanViewModel>("[USP_LESSEE_MININGPLAN]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMiningPlanlistDetails = result.ToList();
                }
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Scheme Log History details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMiningPlanViewModel>> GetMiningPlanMSLogDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            List<LesseeMiningPlanViewModel> ObjMiningPlanlistDetails = new List<LesseeMiningPlanViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeMiningPlanModel.CREATED_BY,
                    SP_MODE = "LOGHISTORYSM"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMiningPlanViewModel>("[USP_LESSEE_MININGPLAN]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMiningPlanlistDetails = result.ToList();
                }
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Scheme Log History details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMiningPlanViewModel>> GetMiningPlanMSLogDetailsView(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            List<LesseeMiningPlanViewModel> ObjMiningPlanlistDetails = new List<LesseeMiningPlanViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeMiningPlanModel.CREATED_BY,
                    MODIFIED_ON = objLesseeMiningPlanModel.MODIFIED_ON,
                    MINING_PLAN_ID = objLesseeMiningPlanModel.MiningPlanId,
                    STATUS = objLesseeMiningPlanModel.STATUS,
                    SP_MODE = "LOGHISTORYSMVIEW"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMiningPlanViewModel>("[USP_LESSEE_MININGPLAN]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMiningPlanlistDetails = result.ToList();
                }
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Plan Compare details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMiningPlanViewModel>> GetMiningPlanCompareDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            List<LesseeMiningPlanViewModel> ObjMiningPlanlistDetails = new List<LesseeMiningPlanViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeMiningPlanModel.CREATED_BY,
                    SP_MODE = "COMPAREMP"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMiningPlanViewModel>("[USP_LESSEE_MININGPLAN]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMiningPlanlistDetails = result.ToList();
                }
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Scheme Compare details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetMiningSchemeCompareDetails(MiningProductionModel objLesseeMiningPlanModel)
        {
            List<MiningProductionModel> ObjMiningPlanlistDetails = new List<MiningProductionModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeMiningPlanModel.CREATED_BY,
                    SP_MODE = "COMPAREMS"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MiningProductionModel>("[USP_LESSEE_MININGPLAN]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMiningPlanlistDetails = result.ToList();
                }
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("SP_MODE", "APPROVE");
                p.Add("APPROVED_BY", objLesseeMiningPlanModel.UserLoginId);
                p.Add("MINING_PLAN_ID", objLesseeMiningPlanModel.MINING_PLAN_ID);
                p.Add("USER_ID", objLesseeMiningPlanModel.CREATED_BY);
                p.Add("Remarks", objLesseeMiningPlanModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_MININGPLAN]", p, commandType: CommandType.StoredProcedure);
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
        /// To Reject Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("SP_MODE", "REJECT");
                p.Add("REJECTED_BY", objLesseeMiningPlanModel.UserLoginId);
                p.Add("MINING_PLAN_ID", objLesseeMiningPlanModel.MINING_PLAN_ID);
                p.Add("USER_ID", objLesseeMiningPlanModel.CREATED_BY);
                p.Add("Remarks", objLesseeMiningPlanModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_MININGPLAN]", p, commandType: CommandType.StoredProcedure);
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
        /// To Delete Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("SP_MODE", "DELETE");
                p.Add("USER_LOGIN_ID", objLesseeMiningPlanModel.CREATED_BY);
                p.Add("MINING_PLAN_ID", objLesseeMiningPlanModel.MINING_PLAN_ID);
                p.Add("USER_ID", objLesseeMiningPlanModel.CREATED_BY);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_MININGPLAN]", p, commandType: CommandType.StoredProcedure);
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
