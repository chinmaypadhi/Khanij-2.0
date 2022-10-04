// ***********************************************************************
//  Class Name               : LesseeAssessmentReportProvider
//  Description              : Lessee CTE Details 
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

namespace MasterApi.Model.LesseeAssessmentReport
{
    public class LesseeAssessmentReportProvider : RepositoryBase, ILesseeAssessmentReportProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeAssessmentReportProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To bind Assessment Report details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public async Task<LesseeAssessmentReportViewModel> GetAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            LesseeAssessmentReportViewModel ObjAssessmentReportDetails = new LesseeAssessmentReportViewModel();
            try
            {
                var paramList = new
                {
                    CreatedBy = objLesseeAssessmentReportModel.CREATED_BY,
                    CHECK = 1
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeAssessmentReportViewModel>("[USP_AssessmentData]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjAssessmentReportDetails = result.FirstOrDefault();
                }
                return ObjAssessmentReportDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Assessment Report details
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        public MessageEF UpdateAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", 2);
                p.Add("CreatedOn", DateTime.Now);
                p.Add("AssessmentID", objLesseeAssessmentReportModel.AssessmentID);
                p.Add("UserLoginID", objLesseeAssessmentReportModel.UserLoginId);
                p.Add("CreatedBy", objLesseeAssessmentReportModel.CREATED_BY);
                p.Add("Assessmentdate", objLesseeAssessmentReportModel.Assessmentdate);
                p.Add("HalfYearAssesmentDate", objLesseeAssessmentReportModel.HalfYearAssesmentDate);
                p.Add("Status", objLesseeAssessmentReportModel.Status);
                p.Add("RecoveryReportFilePath", objLesseeAssessmentReportModel.RecoveryReportFilePath);
                p.Add("RecoveryReportFileName", objLesseeAssessmentReportModel.RecoveryReportFileName);
                p.Add("HalfyearassesmentFilePath", objLesseeAssessmentReportModel.HalfyearassesmentFilePath);
                p.Add("HalfyearassesmentFileName", objLesseeAssessmentReportModel.HalfyearassesmentFileName);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_AssessmentData]", p, commandType: CommandType.StoredProcedure);
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
        /// To bind Assessment Report Log History details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeAssessmentReportViewModel>> GetAssessmentReportLogDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            List<LesseeAssessmentReportViewModel> ObjAssessmentReportLogDetails = new List<LesseeAssessmentReportViewModel>();
            try
            {
                var paramList = new
                {
                    CreatedBy = objLesseeAssessmentReportModel.CREATED_BY,
                    CHECK = 5
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeAssessmentReportViewModel>("[USP_AssessmentData]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjAssessmentReportLogDetails = result.ToList();
                }
                return ObjAssessmentReportLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Assessment Report Compare details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeAssessmentReportViewModel>> GetAssessmentReportCompareDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            List<LesseeAssessmentReportViewModel> ObjAssessmentReportComparelistDetails = new List<LesseeAssessmentReportViewModel>();
            try
            {
                var paramList = new
                {
                    CreatedBy = objLesseeAssessmentReportModel.CREATED_BY,
                    CHECK = 6
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeAssessmentReportViewModel>("[USP_AssessmentData]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjAssessmentReportComparelistDetails = result.ToList();
                }
                return ObjAssessmentReportComparelistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "3");
                p.Add("ApprovedBy", objLesseeAssessmentReportModel.UserId);
                p.Add("UserLoginID", objLesseeAssessmentReportModel.UserLoginId);
                p.Add("AssessmentID", objLesseeAssessmentReportModel.AssessmentID);
                p.Add("CreatedBy", objLesseeAssessmentReportModel.CREATED_BY);
                p.Add("Remarks", objLesseeAssessmentReportModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_AssessmentData]", p, commandType: CommandType.StoredProcedure);
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
        /// To Reject Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "4");
                p.Add("RejectedBy", objLesseeAssessmentReportModel.UserId);
                p.Add("UserLoginID", objLesseeAssessmentReportModel.UserLoginId);
                p.Add("AssessmentID", objLesseeAssessmentReportModel.AssessmentID);
                p.Add("CreatedBy", objLesseeAssessmentReportModel.CREATED_BY);
                p.Add("Remarks", objLesseeAssessmentReportModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_AssessmentData]", p, commandType: CommandType.StoredProcedure);
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
        /// To Delete Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "7");
                p.Add("CreatedBy", objLesseeAssessmentReportModel.CREATED_BY);
                p.Add("AssessmentID", objLesseeAssessmentReportModel.AssessmentID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_AssessmentData]", p, commandType: CommandType.StoredProcedure);
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
