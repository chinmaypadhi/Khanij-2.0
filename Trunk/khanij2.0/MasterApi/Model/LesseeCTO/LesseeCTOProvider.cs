// ***********************************************************************
//  Class Name               : LesseeCTOProvider
//  Description              : Lessee Consent To Operate Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 29 July 2021
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

namespace MasterApi.Model.LesseeCTO
{
    public class LesseeCTOProvider: RepositoryBase,ILesseeCTOProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeCTOProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To bind FY Consent To Operate details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTOViewModel>> GetFYDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            List<LesseeCTOViewModel> ObjCTODetailslist = new List<LesseeCTOViewModel>();
            try
            {
                var paramList = new
                {
                    Check = 4
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeCTOViewModel>("[GetFinancialYearList]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjCTODetailslist = result.ToList();
                }
                return ObjCTODetailslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Consent To Operate details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<LesseeCTOViewModel> GetCTODetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            LesseeCTOViewModel ObjCTODetails = new LesseeCTOViewModel();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeCTOModel.CREATED_BY,
                    CHECK = 1
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeCTOViewModel>("[USP_LICENSEE_CTO_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjCTODetails = result.FirstOrDefault();
                }
                return ObjCTODetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Consent To Operate Approved Quantity details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetApprovedQuantityDetails(MiningProductionModel objLesseeCTOModel)
        {
            List<MiningProductionModel> ObjCTODetailslist = new List<MiningProductionModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeCTOModel.CREATED_BY,
                    CHECK = 8
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MiningProductionModel>("[USP_LICENSEE_CTO_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjCTODetailslist = result.ToList();
                }
                return ObjCTODetailslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Consent To Operate details
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        public MessageEF UpdateCTODetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 2);
                p.Add("CREATED_BY", objLesseeCTOModel.CREATED_BY);
                p.Add("USER_LOGIN_ID", objLesseeCTOModel.UserLoginId);
                p.Add("CTO_ID", objLesseeCTOModel.CTO_ID);
                p.Add("CTO_ORDER_NO", objLesseeCTOModel.CTO_ORDER_NO);
                p.Add("CTO_ORDER_DATE", objLesseeCTOModel.CTO_Order_Date);
                p.Add("CTO_VALID_FROM", objLesseeCTOModel.CTO_VALID_FROM);
                p.Add("CTO_VALID_TO", objLesseeCTOModel.CTO_VALID_TO);
                p.Add("STATUS", objLesseeCTOModel.STATUS);
                p.Add("CTO_LETTER_PATH", objLesseeCTOModel.CTO_LETTER_PATH);
                p.Add("FILE_CTO_LETTER", objLesseeCTOModel.FILE_CTO_LETTER);
                if (objLesseeCTOModel.dtFYApprovedQuantity != null && objLesseeCTOModel.dtFYApprovedQuantity.Rows.Count > 0)
                {
                    p.Add("BULK_PRODUCTION", objLesseeCTOModel.dtFYApprovedQuantity, DbType.Object);
                }
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_CTO_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To bind Consent To Operate Log History details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTOViewModel>> GetCTOLogDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            List<LesseeCTOViewModel> ObjGrantOrderLogDetails = new List<LesseeCTOViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeCTOModel.CREATED_BY,
                    CHECK = 5
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeCTOViewModel>("[USP_LICENSEE_CTO_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To get Consent To Operate Log History details
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTOViewModel>> GetCTOApprovedQuantityLogDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            List<LesseeCTOViewModel> ObjGrantOrderLogDetails = new List<LesseeCTOViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeCTOModel.CREATED_BY,
                    CHECK = 9
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeCTOViewModel>("[USP_LICENSEE_CTO_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To bind Consent To Operate Log History details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTOViewModel>> GetCTOApprovedQuantityLogDetailsView(LesseeCTOViewModel objLesseeCTOModel)
        {
            List<LesseeCTOViewModel> ObjGrantOrderLogDetails = new List<LesseeCTOViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeCTOModel.CREATED_BY,
                    MODIFIED_ON=objLesseeCTOModel.MODIFIED_ON,
                    CTO_ID = objLesseeCTOModel.CTO_ID,
                    STATUS = objLesseeCTOModel.STATUS,
                    CHECK = 10
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeCTOViewModel>("[USP_LICENSEE_CTO_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To bind Consent To Operate Compare details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTOViewModel>> GetCTOCompareDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            List<LesseeCTOViewModel> ObjGrantOrderLogDetails = new List<LesseeCTOViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeCTOModel.CREATED_BY,
                    CHECK = 6
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeCTOViewModel>("[USP_LICENSEE_CTO_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To bind Consent To Operate Approved Quantity Compare details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetCTOApprovedQuantityCompareDetails(MiningProductionModel objLesseeCTOModel)
        {
            List<MiningProductionModel> ObjGrantOrderLogDetails = new List<MiningProductionModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeCTOModel.CREATED_BY,
                    CHECK = 12
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MiningProductionModel>("[USP_LICENSEE_CTO_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Approve Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeCTODetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "3");
                p.Add("APPROVED_BY", objLesseeCTOModel.UserLoginId);
                p.Add("CTO_ID", objLesseeCTOModel.CTO_ID);
                p.Add("CREATED_BY", objLesseeCTOModel.CREATED_BY);
                p.Add("Remarks", objLesseeCTOModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_CTO_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To Reject Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeCTODetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "4");
                p.Add("REJECTED_BY", objLesseeCTOModel.UserLoginId);
                p.Add("CTO_ID", objLesseeCTOModel.CTO_ID);
                p.Add("CREATED_BY", objLesseeCTOModel.CREATED_BY);
                p.Add("Remarks", objLesseeCTOModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_CTO_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To Delete Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeCTODetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CREATED_BY", objLesseeCTOModel.CREATED_BY);
                p.Add("CHECK", "7");
                p.Add("CTO_ID", objLesseeCTOModel.CTO_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_CTO_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
