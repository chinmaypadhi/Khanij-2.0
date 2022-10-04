// ***********************************************************************
//  Class Name               : LesseeForestClearanceProvider
//  Description              : Lessee Forest Clearance Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 26 July 2021
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

namespace MasterApi.Model.LesseeForestClearance
{
    public class LesseeForestClearanceProvider : RepositoryBase, ILesseeForestClearanceProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeForestClearanceProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To bind Forest Clearance details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public async Task<LesseeForestClearanceViewModel> GetForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            LesseeForestClearanceViewModel ObjGrantOrderDetails = new LesseeForestClearanceViewModel();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeForestClearanceModel.CREATED_BY,
                    SP_MODE = "GET_DATA"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeForestClearanceViewModel>("[USP_LESSEE_FOREST_CLEARANCE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Save/Update,ForwardToDD Lesse Forest Clearance details
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        public MessageEF UpdateForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("USER_ID", objLesseeForestClearanceModel.CREATED_BY);
                p.Add("FC_APPROVAL_ID", objLesseeForestClearanceModel.FC_APPROVAL_ID);                
                p.Add("FC_APPROVAL_NUMBER", objLesseeForestClearanceModel.FC_APPROVAL_NUMBER);
                if (objLesseeForestClearanceModel.FC_APPROVAL_DATE != null)
                {
                    p.Add("FC_APPROVAL_DATE", objLesseeForestClearanceModel.FC_APPROVAL_DATE);
                }
                if (objLesseeForestClearanceModel.VALID_FROM != null)
                {
                    p.Add("VALID_FROM", objLesseeForestClearanceModel.VALID_FROM);
                }
                if (objLesseeForestClearanceModel.VALID_TO != null)
                {
                    p.Add("VALID_TO", objLesseeForestClearanceModel.VALID_TO);
                }
                p.Add("STATUS", objLesseeForestClearanceModel.STATUS);
                p.Add("FC_LETTER_FILE_path", objLesseeForestClearanceModel.FC_LETTER_FILE_PATH);
                p.Add("FC_LETTER_FILE_NAME", objLesseeForestClearanceModel.FC_LETTER_FILE_NAME);
                p.Add("SP_MODE", "SAVE_DATA");
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_FOREST_CLEARANCE]", p, commandType: CommandType.StoredProcedure);
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
        /// To bind Forest Clearance Log History details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeForestClearanceViewModel>> GetForestClearanceLogDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            List<LesseeForestClearanceViewModel> ObjGrantOrderLogDetails = new List<LesseeForestClearanceViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeForestClearanceModel.CREATED_BY,
                    SP_MODE = "LOGHISTORY"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeForestClearanceViewModel>("[USP_LESSEE_FOREST_CLEARANCE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To bind Forest Clearance Compare details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeForestClearanceViewModel>> GetForestClearanceCompareDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            List<LesseeForestClearanceViewModel> ObjGrantOrderLogDetails = new List<LesseeForestClearanceViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeForestClearanceModel.CREATED_BY,
                    SP_MODE = "COMPARE"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeForestClearanceViewModel>("[USP_LESSEE_FOREST_CLEARANCE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Approve Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("SP_MODE", "APPROVE");
                p.Add("APPROVED_BY", objLesseeForestClearanceModel.UserLoginId);
                p.Add("USER_ID", objLesseeForestClearanceModel.CREATED_BY);
                p.Add("FC_APPROVAL_ID", objLesseeForestClearanceModel.FC_APPROVAL_ID);
                p.Add("Remarks", objLesseeForestClearanceModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_FOREST_CLEARANCE]", p, commandType: CommandType.StoredProcedure);
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
        /// To Reject Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("SP_MODE", "REJECT");
                p.Add("REJECTED_BY", objLesseeForestClearanceModel.UserLoginId);
                p.Add("USER_ID", objLesseeForestClearanceModel.CREATED_BY);
                p.Add("FC_APPROVAL_ID", objLesseeForestClearanceModel.FC_APPROVAL_ID);
                p.Add("Remarks", objLesseeForestClearanceModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_FOREST_CLEARANCE]", p, commandType: CommandType.StoredProcedure);
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
        /// To Delete Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("USER_ID", objLesseeForestClearanceModel.CREATED_BY);
                p.Add("SP_MODE", "DELETE");
                p.Add("FC_APPROVAL_ID", objLesseeForestClearanceModel.FC_APPROVAL_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_FOREST_CLEARANCE]", p, commandType: CommandType.StoredProcedure);
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
