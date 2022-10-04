// ***********************************************************************
//  Class Name               : NotificationTypeProvider
//  Desciption               : Add,Select,Update,Delete Website Notification Type Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Oct 2021
// ***********************************************************************
using Dapper;
using HomeApi.Factory;
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Model.NotificationType
{
    public class NotificationTypeProvider: RepositoryBase, INotificationTypeProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public NotificationTypeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        public MessageEF AddNotificationType(AddNotificationTypeModel objAddNotificationTypeModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_NOTIFICATION_NAME", objAddNotificationTypeModel.VCH_NOTIFICATION_NAME);
                p.Add("P_VCH_NOTIFICATION_DESC", objAddNotificationTypeModel.VCH_NOTIFICATION_DESC);
                p.Add("P_BIT_STATUS", objAddNotificationTypeModel.BIT_STATUS);
                p.Add("P_INT_USER_ID", objAddNotificationTypeModel.INT_CREATED_BY);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_NOTIFICATION_TYPE_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response == "2")
                {
                    objMessage.Satus = "2";
                }
                else
                {
                    objMessage.Satus = "3";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Select Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        public async Task<List<ViewNotificationTypeModel>> ViewNotificationType(ViewNotificationTypeModel objViewNotificationTypeModel)
        {
            List<ViewNotificationTypeModel> ListNotificationType = new List<ViewNotificationTypeModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ViewNotificationTypeModel>("USP_WEB_NOTIFICATION_TYPE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListNotificationType = result.ToList();
                }
                return ListNotificationType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Website Notification Type Details
        /// </summary>
        /// <param name="objViewNotificationTypeModel"></param>
        /// <returns></returns>
        public AddNotificationTypeModel EditNotificationType(AddNotificationTypeModel objAddNotificationTypeModel)
        {
            AddNotificationTypeModel objaddNotificationTypeModel = new AddNotificationTypeModel();
            try
            {
                var paramList = new
                {
                    P_INT_NOTIFICATION_TYPE_ID = objAddNotificationTypeModel.INT_NOTIFICATION_TYPE_ID,
                    P_VCH_ACTION = "IDSELECT",
                };
                var result = Connection.Query<AddNotificationTypeModel>("USP_WEB_NOTIFICATION_TYPE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddNotificationTypeModel = result.FirstOrDefault();
                }
                return objaddNotificationTypeModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        public MessageEF DeleteNotificationType(ViewNotificationTypeModel objAddNotificationTypeModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_NOTIFICATION_TYPE_ID", objAddNotificationTypeModel.INT_NOTIFICATION_TYPE_ID);
                p.Add("P_INT_USER_ID", objAddNotificationTypeModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_NOTIFICATION_TYPE_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                if (response == "4")
                {
                    objMessage.Satus = "4";
                }
                else
                {
                    objMessage.Satus = "3";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Update Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        public MessageEF UpdateNotificationType(AddNotificationTypeModel objAddNotificationTypeModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_NOTIFICATION_TYPE_ID", objAddNotificationTypeModel.INT_NOTIFICATION_TYPE_ID);
                p.Add("P_VCH_NOTIFICATION_NAME", objAddNotificationTypeModel.VCH_NOTIFICATION_NAME);
                p.Add("P_VCH_NOTIFICATION_DESC", objAddNotificationTypeModel.VCH_NOTIFICATION_DESC);
                p.Add("P_INT_USER_ID", objAddNotificationTypeModel.INT_CREATED_BY);
                p.Add("P_BIT_STATUS", objAddNotificationTypeModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_NOTIFICATION_TYPE_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response == "2")
                {
                    objMessage.Satus = "2";
                }
                else
                {
                    objMessage.Satus = "3";
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
