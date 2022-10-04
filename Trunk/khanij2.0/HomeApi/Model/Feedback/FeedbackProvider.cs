// ***********************************************************************
//  Class Name               : FeedbackProvider
//  Desciption               : Add,Select,Update,Delete Website Feedback Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 21 Oct 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.Repository;
using HomeApi.Factory;
using HomeEF;
using Dapper;
using System.Data;

namespace HomeApi.Model.Feedback
{
    public class FeedbackProvider : RepositoryBase, IFeedbackProvider
    {
        /// <summary>
        /// Constructor Initialisation
        /// </summary>
        /// <param name="connectionFactory"></param>
        public FeedbackProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {

        }
        /// <summary>
        /// To Insert Feedback Deatails
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        public MessageEF AddFeedback(AddFeedbackModel addFeedbackModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_FEEDBACK_ID", addFeedbackModel.FEEDBACK_ID);
                p.Add("P_VCH_FULL_NAME", addFeedbackModel.FULL_NAME);
                p.Add("P_VCH_MAIL_ID", addFeedbackModel.MAIL_ID);
                p.Add("P_VCH_FEEDBACK", addFeedbackModel.FEEDBACK);
                p.Add("P_BIT_STATUS", addFeedbackModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_WEB_FEEDBACK]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";
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
        /// <summary>
        /// To View Feedback Details
        /// </summary>
        /// <param name="viewFeedbackModel"></param>
        /// <returns></returns>
        public async Task<List<ViewFeedbackModel>> ViewFeedback(ViewFeedbackModel  viewFeedbackModel)
        {
            List<ViewFeedbackModel> FeedbackList = new List<ViewFeedbackModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ViewFeedbackModel>("[USP_WEB_FEEDBACK]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    FeedbackList = result.ToList();
                }
                return FeedbackList;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
        /// <summary>
        /// To Edit Fedeback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        public AddFeedbackModel EditFeedback(AddFeedbackModel addFeedbackModel)
        {
            AddFeedbackModel objaddFeedback = new AddFeedbackModel();
            try
            {
                var paramList = new
                {
                    P_INT_NOTIFICATION_ID = addFeedbackModel.FEEDBACK_ID,
                    P_VCH_ACTION = "IDSELECT",
                };
                var result = Connection.Query<AddFeedbackModel>("[USP_WEB_FEEDBACK]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddFeedback = result.FirstOrDefault();
                }
                return objaddFeedback;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// To Delete Feedback Details
        /// </summary>
        /// <param name="viewFeedbackModel"></param>
        /// <returns></returns>
        public MessageEF DelteFeedback(ViewFeedbackModel viewFeedbackModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_FEEDBACK_ID", viewFeedbackModel.FEEDBACK_ID);
                p.Add("P_INT_USER_ID", viewFeedbackModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_WEB_FEEDBACK]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objMessage;
        }
        /// <summary>
        /// To Update Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        public MessageEF UpdateFeedback(AddFeedbackModel addFeedbackModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_FEEDBACK_ID", addFeedbackModel.FEEDBACK_ID);
                p.Add("P_VCH_FULL_NAME", addFeedbackModel.FULL_NAME);
                p.Add("P_VCH_MAIL_ID", addFeedbackModel.MAIL_ID);
                p.Add("P_VCH_FEEDBACK", addFeedbackModel.FEEDBACK);
                p.Add("P_BIT_STATUS", addFeedbackModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_FEEDBACK", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";
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
    }

}
