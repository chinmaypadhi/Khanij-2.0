// ***********************************************************************
//  Class Name               : NotificationProvider
//  Desciption               : Add,Select,Update,Delete Website Notification Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 07 Oct 2021
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

namespace HomeApi.Model.Notification
{
    public class NotificationProvider : RepositoryBase, INotificationProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public NotificationProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        public MessageEF AddNotification(AddNotificationModel objAddNotificationModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_NOTIFICATION_TYPE_ID", objAddNotificationModel.INT_NOTIFICATION_TYPE_ID);
                p.Add("P_VCH_NOTIFICATION_SUB", objAddNotificationModel.VCH_NOTIFICATION_SUB);
                p.Add("P_DTM_PUBLISHED_ON", objAddNotificationModel.DTM_PUBLISHED_ON);
                p.Add("P_VCH_UPLOAD_FILE", objAddNotificationModel.VCH_UPLOAD_FILE);
                p.Add("P_INT_USER_ID", objAddNotificationModel.INT_CREATED_BY);
                p.Add("P_BIT_STATUS", objAddNotificationModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_NOTIFICATION_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Select Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public async Task<List<ViewNotificationModel>> ViewNotification(ViewNotificationModel objViewNotificationModel)
        {
            List<ViewNotificationModel> ListNotification = new List<ViewNotificationModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ViewNotificationModel>("USP_WEB_NOTIFICATION_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListNotification = result.ToList();
                }
                return ListNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Notification Archive Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public async Task<List<ViewNotificationModel>> ViewNotificationArchive(ViewNotificationModel objViewNotificationModel)
        {
            List<ViewNotificationModel> ListNotification = new List<ViewNotificationModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECTARCHIVE",
                };
                var result = await Connection.QueryAsync<ViewNotificationModel>("USP_WEB_NOTIFICATION_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListNotification = result.ToList();
                }
                return ListNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Website Notification Details
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public AddNotificationModel EditNotification(AddNotificationModel objAddNotificationModel)
        {
            AddNotificationModel objaddNotificationModel = new AddNotificationModel();
            try
            {
                var paramList = new
                {
                    P_INT_NOTIFICATION_ID = objAddNotificationModel.INT_NOTIFICATION_ID,
                    P_VCH_ACTION = "IDSELECT",
                };
                var result = Connection.Query<AddNotificationModel>("USP_WEB_NOTIFICATION_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddNotificationModel = result.FirstOrDefault();
                }
                return objaddNotificationModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Archive Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ArchiveNotification(ViewNotificationModel objViewNotificationModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "ARCHIVE");
                p.Add("P_INT_NOTIFICATION_ID", objViewNotificationModel.INT_NOTIFICATION_ID);
                p.Add("P_INT_USER_ID", objViewNotificationModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_NOTIFICATION_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Delete Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public MessageEF DeleteNotification(ViewNotificationModel objViewNotificationModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_NOTIFICATION_ID", objViewNotificationModel.INT_NOTIFICATION_ID);
                p.Add("P_INT_USER_ID", objViewNotificationModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_NOTIFICATION_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Update Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        public MessageEF UpdateNotification(AddNotificationModel objAddNotificationModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_NOTIFICATION_ID", objAddNotificationModel.INT_NOTIFICATION_ID);
                p.Add("P_VCH_NOTIFICATION_SUB", objAddNotificationModel.VCH_NOTIFICATION_SUB);
                p.Add("P_DTM_PUBLISHED_ON", objAddNotificationModel.DTM_PUBLISHED_ON);
                p.Add("P_INT_NOTIFICATION_TYPE_ID", objAddNotificationModel.INT_NOTIFICATION_TYPE_ID);
                p.Add("P_VCH_UPLOAD_FILE", objAddNotificationModel.VCH_UPLOAD_FILE);
                p.Add("P_INT_USER_ID", objAddNotificationModel.INT_CREATED_BY);
                p.Add("P_BIT_STATUS", objAddNotificationModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_NOTIFICATION_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// Publish Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> PublishNotification(ViewNotificationModel objViewNotificationModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "PUBLISH");
                p.Add("P_INT_NOTIFICATION_ID", objViewNotificationModel.INT_NOTIFICATION_ID);
                p.Add("P_INT_USER_ID", objViewNotificationModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_NOTIFICATION_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Unpublish Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UnpublishNotification(ViewNotificationModel objViewNotificationModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "UNPUBLISH");
                p.Add("P_INT_NOTIFICATION_ID", objViewNotificationModel.INT_NOTIFICATION_ID);
                p.Add("P_INT_USER_ID", objViewNotificationModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_NOTIFICATION_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Active Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> Active(ViewNotificationModel objViewNotificationModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "ACTIVE");
                p.Add("P_INT_NOTIFICATION_ID", objViewNotificationModel.INT_NOTIFICATION_ID);
                p.Add("P_INT_USER_ID", objViewNotificationModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_NOTIFICATION_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Bind Website Notification Type List Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        public async Task<List<AddNotificationModel>> GetNotificationTypeList(AddNotificationModel objAddNotificationModel)
        {
            List<AddNotificationModel> ObjNotificationTypeList = new List<AddNotificationModel>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<AddNotificationModel>("USP_GET_NOTIFICATION_TYPE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjNotificationTypeList = result.ToList();
                }
                return ObjNotificationTypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Publish Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public async Task<List<ViewNotificationModel>> ViewWebsiteNotification(ViewNotificationModel objViewNotificationModel)
        {
            List<ViewNotificationModel> ListNotification = new List<ViewNotificationModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "WEBSITEACTIVE",
                    P_INT_NOTIFICATION_TYPE_ID = objViewNotificationModel.INT_NOTIFICATION_TYPE_ID,
                    P_DTM_FROM_DATE = objViewNotificationModel.DTM_FROM_DATE,
                    P_DTM_TO_DATE = objViewNotificationModel.DTM_TO_DATE
                };
                var result = await Connection.QueryAsync<ViewNotificationModel>("USP_WEB_NOTIFICATION_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListNotification = result.ToList();
                }
                return ListNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Publish Website Notification Archive Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public async Task<List<ViewNotificationModel>> ViewWebsiteNotificationArchive(ViewNotificationModel objViewNotificationModel)
        {
            List<ViewNotificationModel> ListNotification = new List<ViewNotificationModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "WEBSITEARCHIVE",
                    P_INT_NOTIFICATION_TYPE_ID = objViewNotificationModel.INT_NOTIFICATION_TYPE_ID,
                    P_DTM_FROM_DATE = objViewNotificationModel.DTM_FROM_DATE,
                    P_DTM_TO_DATE = objViewNotificationModel.DTM_TO_DATE
                };
                var result = await Connection.QueryAsync<ViewNotificationModel>("USP_WEB_NOTIFICATION_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListNotification = result.ToList();
                }
                return ListNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Top Publish Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public async Task<List<ViewNotificationModel>> ViewTopWebsiteNotification(ViewNotificationModel objViewNotificationModel)
        {
            List<ViewNotificationModel> ListNotification = new List<ViewNotificationModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "TOPWEBSITEACTIVE",
                };
                var result = await Connection.QueryAsync<ViewNotificationModel>("USP_WEB_NOTIFICATION_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListNotification = result.ToList();
                }
                return ListNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
