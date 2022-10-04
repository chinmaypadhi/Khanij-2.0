// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 22-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MasterApi.Model.UserFeedback
{
    public class UserFeedbackProvider: RepositoryBase, IUserFeedbackProvider
    {
        public UserFeedbackProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF PublishUserFeedback(UserFeedbackmaster objUserFeedbackmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FeedbackId", objUserFeedbackmaster.FeedbackId);
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspUpdateFeedback", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response == "0")
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
        public MessageEF UndoPublishUserFeedback(UserFeedbackmaster objUserFeedbackmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FeedbackId", objUserFeedbackmaster.FeedbackId);
                p.Add("Chk", "1");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspUpdateFeedback", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response == "0")
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
        public List<UserFeedbackmaster> ViewUserFeedbackmaster(UserFeedbackmaster objUserFeedbackmaster)
        {
            List<UserFeedbackmaster> ListUserFeedbackmaster = new List<UserFeedbackmaster>();
            try
            {
                var paramList = new
                {
                    FromDate = objUserFeedbackmaster.FromDate,
                    ToDate = objUserFeedbackmaster.ToDate,
                    chk = "2",
                };
                var Output = Connection.Query<UserFeedbackmaster>("uspGetFeedBack", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    ListUserFeedbackmaster = Output.ToList();
                }

                return ListUserFeedbackmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListUserFeedbackmaster = null;
            }



        }
    }
}
