// ***********************************************************************
//  Class Name               : LesseeIBMProvider
//  Description              : Lessee IBM Interface Details 
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

namespace MasterApi.Model.LesseeIBM
{
    public class LesseeIBMProvider: RepositoryBase,ILesseeIBMProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeIBMProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To bind IBM details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public async Task<LesseeIBMDetailsViewModel> GetIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            LesseeIBMDetailsViewModel ObjGrantOrderDetails = new LesseeIBMDetailsViewModel();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeIBMDetailsModel.CREATED_BY,
                    CHECK = 2
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeIBMDetailsViewModel>("[USP_LICENSEE_IBM_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Save/Update,ForwardToDD Lesse IBM details
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        public MessageEF UpdateIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CREATED_BY", objLesseeIBMDetailsModel.CREATED_BY);
                p.Add("USER_LOGIN_ID", objLesseeIBMDetailsModel.UserLoginId);
                p.Add("LICENSEE_IBM_ID", objLesseeIBMDetailsModel.LICENSEE_IBM_ID);
                p.Add("IBM_APPLICATION_NUMBER", objLesseeIBMDetailsModel.IBM_APPLICATION_NUMBER);
                p.Add("IBM_APPLICATON_DATE", objLesseeIBMDetailsModel.IBM_APPLICATON_DATE);
                p.Add("IBM_NUMBER", objLesseeIBMDetailsModel.IBM_NUMBER);
                p.Add("STATUS", objLesseeIBMDetailsModel.STATUS);
                p.Add("IBM_REGISTRATION_FORM_PATH", objLesseeIBMDetailsModel.IBM_REGISTRATION_FORM_PATH);
                p.Add("FILE_IBM_REGISTRATION_FORM", objLesseeIBMDetailsModel.FILE_IBM_REGISTRATION_FORM);
                p.Add("IBM_REGISTRATION_NUMBER", objLesseeIBMDetailsModel.IBM_REGISTRATION_NUMBER);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("CHECK", "3");
                Connection.Query<int>("[USP_LICENSEE_IBM_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To bind IBM Log History details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeIBMDetailsViewModel>> GetIBMLogDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            List<LesseeIBMDetailsViewModel> ObjGrantOrderLogDetails = new List<LesseeIBMDetailsViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeIBMDetailsModel.CREATED_BY,
                    CHECK = 6
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeIBMDetailsViewModel>("[USP_LICENSEE_IBM_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To bind IBM Compare details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeIBMDetailsViewModel>> GetIBMCompareDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            List<LesseeIBMDetailsViewModel> ObjGrantOrderLogDetails = new List<LesseeIBMDetailsViewModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeIBMDetailsModel.CREATED_BY,
                    CHECK = 7
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeIBMDetailsViewModel>("[USP_LICENSEE_IBM_DETAILS_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Approve Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("APPROVED_BY", objLesseeIBMDetailsModel.UserLoginId);
                p.Add("CHECK", "4");
                p.Add("LICENSEE_IBM_ID", objLesseeIBMDetailsModel.LICENSEE_IBM_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_IBM_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To Reject Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("REJECTED_BY", objLesseeIBMDetailsModel.UserLoginId);
                p.Add("CHECK", "5");
                p.Add("LICENSEE_IBM_ID", objLesseeIBMDetailsModel.LICENSEE_IBM_ID);
                p.Add("Remarks", objLesseeIBMDetailsModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_IBM_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
        /// To Delete Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("USER_LOGIN_ID", objLesseeIBMDetailsModel.UserLoginId);
                p.Add("CHECK", "8");
                p.Add("LICENSEE_IBM_ID", objLesseeIBMDetailsModel.LICENSEE_IBM_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LICENSEE_IBM_DETAILS_OFFICE]", p, commandType: CommandType.StoredProcedure);
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
