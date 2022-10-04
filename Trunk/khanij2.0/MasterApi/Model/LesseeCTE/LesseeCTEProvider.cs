// ***********************************************************************
//  Class Name               : LesseeCTEProvider
//  Description              : Lessee CTE Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 July 2021
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

namespace MasterApi.Model.LesseeCTE
{
    public class LesseeCTEProvider: RepositoryBase,ILesseeCTEProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeCTEProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To bind Consent To Establish details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public async Task<LesseeCTEViewModel> GetCTEDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            LesseeCTEViewModel ObjGrantOrderDetails = new LesseeCTEViewModel();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeCTEModel.CREATED_BY,
                    CHECK = 1
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeCTEViewModel>("[USP_LICENSEE_CTE_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Save/Update,ForwardToDD Lesse Consent To Establish details
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        public MessageEF UpdateCTEDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 2);
                p.Add("CREATED_BY", objLesseeCTEModel.CREATED_BY);
                p.Add("USER_LOGIN_ID", objLesseeCTEModel.UserLoginId);
                p.Add("CTE_ID", objLesseeCTEModel.CTE_ID);
                p.Add("CTE_ORDER_NO", objLesseeCTEModel.CTE_ORDER_NO);
                p.Add("CTE_ORDER_DATE", objLesseeCTEModel.CTE_Order_Date);
                p.Add("CTE_VALID_FROM", objLesseeCTEModel.CTE_VALID_FROM);
                p.Add("CTE_VALID_TO", objLesseeCTEModel.CTE_VALID_TO);
                p.Add("STATUS", objLesseeCTEModel.STATUS);
                p.Add("CTE_LETTER_PATH", objLesseeCTEModel.CTE_LETTER_PATH);
                p.Add("FILE_CTE_LETTER", objLesseeCTEModel.FILE_CTE_LETTER);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_CTE_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To bind Consent To Establish Log History details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTEViewModel>> GetCTELogDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            List<LesseeCTEViewModel> ObjGrantOrderLogDetails = new List<LesseeCTEViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeCTEModel.CREATED_BY,
                    CHECK = 5
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeCTEViewModel>("[USP_LICENSEE_CTE_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To bind Consent To Establish Compare details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTEViewModel>> GetCTECompareDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            List<LesseeCTEViewModel> ObjGrantOrderLogDetails = new List<LesseeCTEViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeCTEModel.CREATED_BY,
                    CHECK = 6
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeCTEViewModel>("[USP_LICENSEE_CTE_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Approve Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeCTEDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "3");
                p.Add("APPROVED_BY", objLesseeCTEModel.UserLoginId);
                p.Add("CREATED_BY", objLesseeCTEModel.CREATED_BY);
                p.Add("CTE_ID", objLesseeCTEModel.CTE_ID);
                p.Add("Remarks", objLesseeCTEModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_CTE_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To Reject Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeCTEDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "4");
                p.Add("REJECTED_BY", objLesseeCTEModel.UserLoginId);
                p.Add("CREATED_BY", objLesseeCTEModel.CREATED_BY);
                p.Add("CTE_ID", objLesseeCTEModel.CTE_ID);
                p.Add("Remarks", objLesseeCTEModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_CTE_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To Delete Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeCTEDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CREATED_BY", objLesseeCTEModel.CREATED_BY);
                p.Add("CHECK", "7");
                p.Add("CTE_ID", objLesseeCTEModel.CTE_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_CTE_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
