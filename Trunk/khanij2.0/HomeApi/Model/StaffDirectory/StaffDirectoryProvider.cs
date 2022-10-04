// ***********************************************************************
//  Class Name               : StaffDirectoryProvider
//  Desciption               : Add,Select,Update,Delete Website Staff Directory Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Oct 2021
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

namespace HomeApi.Model.StaffDirectory
{
    public class StaffDirectoryProvider: RepositoryBase, IStaffDirectoryProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public StaffDirectoryProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Website Staff Directory Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        public MessageEF AddStaffDirectory(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_OFFICE_TYPE", objAddStaffDirectoryModel.INT_OFFICE_TYPE_ID);
                p.Add("P_VCH_OFFICER_NAME", objAddStaffDirectoryModel.VCH_OFFICER_NAME);
                p.Add("P_VCH_OFFICER_DESIG", objAddStaffDirectoryModel.VCH_OFFICER_DESIG);
                p.Add("P_VCH_PHONE_NO", objAddStaffDirectoryModel.VCH_PHONE_NO);
                p.Add("P_VCH_EMAIL", objAddStaffDirectoryModel.VCH_EMAIL);
                p.Add("P_VCH_LOCATION", objAddStaffDirectoryModel.VCH_LOCATION);
                p.Add("P_BIT_STATUS", objAddStaffDirectoryModel.BIT_STATUS);
                p.Add("P_INT_USER_ID", objAddStaffDirectoryModel.INT_CREATED_BY);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_STAFF_DIRECTORY_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Select Website Staff Directory Details 
        /// </summary>
        /// <param name="objViewStaffDirectoryModel"></param>
        /// <returns></returns>
        public async Task<List<ViewStaffDirectoryModel>> ViewStaffDirectory(ViewStaffDirectoryModel objViewStaffDirectoryModel)
        {
            List<ViewStaffDirectoryModel> ListNotificationType = new List<ViewStaffDirectoryModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ViewStaffDirectoryModel>("USP_WEB_STAFF_DIRECTORY_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Edit Website Staff Directory Details
        /// </summary>
        /// <param name="objViewStaffDirectoryModel"></param>
        /// <returns></returns>
        public AddStaffDirectoryModel EditStaffDirectory(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            AddStaffDirectoryModel objaddStaffDirectoryModel = new AddStaffDirectoryModel();
            try
            {
                var paramList = new
                {
                    P_INT_STAFFDIR_ID = objAddStaffDirectoryModel.INT_STAFFDIR_ID,
                    P_VCH_ACTION = "IDSELECT",
                };
                var result = Connection.Query<AddStaffDirectoryModel>("USP_WEB_STAFF_DIRECTORY_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddStaffDirectoryModel = result.FirstOrDefault();
                }
                return objaddStaffDirectoryModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Website Staff Directory Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        public MessageEF DeleteStaffDirectory(ViewStaffDirectoryModel objViewStaffDirectoryModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_STAFFDIR_ID", objViewStaffDirectoryModel.INT_STAFFDIR_ID);
                p.Add("P_INT_USER_ID", objViewStaffDirectoryModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_STAFF_DIRECTORY_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Update Website Staff Directory Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        public MessageEF UpdateStaffDirectory(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_STAFFDIR_ID", objAddStaffDirectoryModel.INT_STAFFDIR_ID);
                p.Add("P_INT_OFFICE_TYPE", objAddStaffDirectoryModel.INT_OFFICE_TYPE_ID);
                p.Add("P_VCH_OFFICER_NAME", objAddStaffDirectoryModel.VCH_OFFICER_NAME);
                p.Add("P_VCH_OFFICER_DESIG", objAddStaffDirectoryModel.VCH_OFFICER_DESIG);
                p.Add("P_VCH_PHONE_NO", objAddStaffDirectoryModel.VCH_PHONE_NO);
                p.Add("P_VCH_EMAIL", objAddStaffDirectoryModel.VCH_EMAIL);
                p.Add("P_VCH_LOCATION", objAddStaffDirectoryModel.VCH_LOCATION);
                p.Add("P_BIT_STATUS", objAddStaffDirectoryModel.BIT_STATUS);
                p.Add("P_INT_USER_ID", objAddStaffDirectoryModel.INT_CREATED_BY);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_STAFF_DIRECTORY_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Bind Website Staff Directory List Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        public async Task<List<AddStaffDirectoryModel>> GetOfficeTypeList(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            List<AddStaffDirectoryModel> ObjNotificationTypeList = new List<AddStaffDirectoryModel>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<AddStaffDirectoryModel>("USP_GET_OFFICE_TYPE", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Bind Publish Website Staff Directory Details 
        /// </summary>
        /// <param name="objViewStaffDirectoryModel"></param>
        /// <returns></returns>
        public async Task<List<ViewStaffDirectoryModel>> ViewPublishStaffDirectory(ViewStaffDirectoryModel objViewStaffDirectoryModel)
        {
            List<ViewStaffDirectoryModel> ListNotificationType = new List<ViewStaffDirectoryModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "WEBSITEACTIVE",
                    P_VCH_OFFICE_TYPE = objViewStaffDirectoryModel.VCH_OFFICE_TYPE,
                    P_VCH_OFFICER_NAME = objViewStaffDirectoryModel.VCH_OFFICER_NAME
                };
                var result = await Connection.QueryAsync<ViewStaffDirectoryModel>("USP_WEB_STAFF_DIRECTORY_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
    }
}
