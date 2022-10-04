// ***********************************************************************
//  Class Name               : UserProfileProvider
//  Desciption               : Add,View,Edit,Update,Delete Website User Profile Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 05 Nov 2021
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

namespace HomeApi.Model.UserProfile
{
    public class UserProfileProvider : RepositoryBase, IUserProfileProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public UserProfileProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Website User Profile Details 
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        public MessageEF AddUserProfile(AddUserProfileModel objAddUserProfileModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_NAME", objAddUserProfileModel.VCH_NAME);
                p.Add("P_VCH_DESIGNATION", objAddUserProfileModel.VCH_DESIGNATION);
                p.Add("P_VCH_DEPARTMENT", objAddUserProfileModel.VCH_DEPARTMENT);
                p.Add("P_VCH_PHOTO_PATH", objAddUserProfileModel.VCH_PHOTO_PATH);
                p.Add("P_VCH_MOBILE_NO", objAddUserProfileModel.VCH_MOBILE_NO);
                p.Add("P_VCH_OFC_EXTN_NO", objAddUserProfileModel.VCH_OFC_EXTN_NO);
                p.Add("P_VCH_EMAIL_ID", objAddUserProfileModel.VCH_EMAIL_ID);
                p.Add("P_VCH_USER_ID", objAddUserProfileModel.VCH_USER_ID);
                p.Add("P_VCH_PASSWORD", objAddUserProfileModel.VCH_PASSWORD);
                p.Add("P_VCH_CONF_PASSWORD", objAddUserProfileModel.VCH_CONF_PASSWORD);
                p.Add("P_INT_USER_ID", objAddUserProfileModel.INT_CREATED_BY);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_USERPROFILE_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Select Website User Profile Details 
        /// </summary>
        /// <param name="objViewUserProfileModel"></param>
        /// <returns></returns>
        public async Task<List<ViewUserProfileModel>> ViewUserProfile(ViewUserProfileModel objViewUserProfileModel)
        {
            List<ViewUserProfileModel> ListNotification = new List<ViewUserProfileModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ViewUserProfileModel>("USP_WEB_USERPROFILE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Edit Website User Profile Details
        /// </summary>
        /// <param name="objViewUserProfileModel"></param>
        /// <returns></returns>
        public AddUserProfileModel EditUserProfile(AddUserProfileModel objAddUserProfileModel)
        {
            AddUserProfileModel objaddUserProfileModel = new AddUserProfileModel();
            try
            {
                var paramList = new
                {
                    P_INT_UPROFILE_ID = objAddUserProfileModel.INT_UPROFILE_ID,
                    P_VCH_ACTION = "IDSELECT",
                };
                var result = Connection.Query<AddUserProfileModel>("USP_WEB_USERPROFILE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddUserProfileModel = result.FirstOrDefault();
                }
                return objaddUserProfileModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Website User Profile Details 
        /// </summary>
        /// <param name="objViewUserProfileModel"></param>
        /// <returns></returns>
        public MessageEF DeleteUserProfile(ViewUserProfileModel objViewUserProfileModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_UPROFILE_ID", objViewUserProfileModel.INT_UPROFILE_ID);
                p.Add("P_INT_USER_ID", objViewUserProfileModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_USERPROFILE_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Update Website User Profile Details 
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        public MessageEF UpdateUserProfile(AddUserProfileModel objAddUserProfileModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_UPROFILE_ID", objAddUserProfileModel.INT_UPROFILE_ID);
                p.Add("P_VCH_NAME", objAddUserProfileModel.VCH_NAME);
                p.Add("P_VCH_DESIGNATION", objAddUserProfileModel.VCH_DESIGNATION);
                p.Add("P_VCH_DEPARTMENT", objAddUserProfileModel.VCH_DEPARTMENT);
                p.Add("P_VCH_PHOTO_PATH", objAddUserProfileModel.VCH_PHOTO_PATH);
                p.Add("P_VCH_MOBILE_NO", objAddUserProfileModel.VCH_MOBILE_NO);
                p.Add("P_VCH_OFC_EXTN_NO", objAddUserProfileModel.VCH_OFC_EXTN_NO);
                p.Add("P_VCH_EMAIL_ID", objAddUserProfileModel.VCH_EMAIL_ID);
                p.Add("P_VCH_USER_ID", objAddUserProfileModel.VCH_USER_ID);
                p.Add("P_VCH_PASSWORD", objAddUserProfileModel.VCH_PASSWORD);
                p.Add("P_VCH_CONF_PASSWORD", objAddUserProfileModel.VCH_CONF_PASSWORD);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_USERPROFILE_MASTER", p, commandType: CommandType.StoredProcedure);
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
    }
}
