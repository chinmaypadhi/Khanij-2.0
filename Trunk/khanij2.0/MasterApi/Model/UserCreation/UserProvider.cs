// ***********************************************************************
//  Class Name               : UserProvider
//  Description              : Add,View,Edit,Update,Delete User Master details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 27 Dec 2021
// ***********************************************************************
using MasterApi.Factory;
using MasterApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Dapper;
using System.Data;

namespace MasterApi.Model.UserCreation
{
    public class UserProvider : RepositoryBase, IUserProvider
    {
        /// <summary>
        /// Connction to DB
        /// </summary>
        /// <param name="connectionFactory"></param>
        public UserProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        //public async Task<List<UserCreationModel>> GetDistricts(UserCreationModel userCreationModel)
        //{
        //    List<UserCreationModel> userCreationModels = new List<UserCreationModel>();
        //    try
        //    {
        //        var paramlist = new
        //        {
        //            Chk = "District",
        //            StateID = userCreationModel.StateId
        //        };
        //        var result = await Connection.QueryAsync<UserCreationModel>("Usp_GetStateDistrictMaster", paramlist, commandType: System.Data.CommandType.StoredProcedure);
        //        if (result.Count() > 0)
        //        {
        //            userCreationModels = result.ToList();
        //        }
        //        return userCreationModels;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// To Bind Department Dropdownlist by selecting usertype
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        public async Task<List<UserCreationModel>> GetRoleTypeListByUserType(UserCreationModel userCreationModel)
        {
            try
            {
                List<UserCreationModel> userCreationModels = new List<UserCreationModel>();
                var paramslist = new
                {
                    SP_MODE = "GET_ROLE_TYPE_DROPDOWN",
                    USERTYPEID = userCreationModel.UsertypeId,
                    USER_ID = userCreationModel.UserId
                };
                var result = await Connection.QueryAsync<UserCreationModel>("USP_GET_DROPDOWNLIST", paramslist, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    userCreationModels = result.ToList();
                }
                return userCreationModels;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// To Bind Designation Dropdwon by selecting Department
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        public async Task<List<UserCreationModel>> GetRoleListByRoleType(UserCreationModel userCreationModel)
        {
            try
            {
                List<UserCreationModel> userCreationModels = new List<UserCreationModel>();
                var paramslist = new
                {
                    SP_MODE = "GET_ROLE_DROPDOWN",
                    ROLETYPEID = userCreationModel.RoleTypeId
                };
                var result = await Connection.QueryAsync<UserCreationModel>("USP_GET_DROPDOWNLIST", paramslist, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    userCreationModels = result.ToList();
                }
                return userCreationModels;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// To Create a New User
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        public MessageEF AddNewUser(UserCreationModel userCreationModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("UserName", userCreationModel.UserName);
                p.Add("ApplicantName", userCreationModel.ApplicantName);
                p.Add("MobileNo", userCreationModel.MobileNo);
                p.Add("EMailId", userCreationModel.EMailId);
                p.Add("DistrictId", userCreationModel.DistrictID);
                p.Add("StateId", userCreationModel.StateId);
                p.Add("Address", userCreationModel.Address);
                p.Add("Password", userCreationModel.Password);
                p.Add("EncryptPassword", userCreationModel.EncryptPassword);
                p.Add("PinCode", userCreationModel.PinCode);
                if (userCreationModel.LicenseeApplicationTypeId != null)
                {
                    p.Add("ApplicationTypeId", userCreationModel.LicenseeApplicationTypeId);
                }
                if (userCreationModel.LesseeApplicationTypeId != null)
                {
                    p.Add("APPLICATION_TYPE_ID", userCreationModel.LesseeApplicationTypeId);
                }
                p.Add("RoleId", userCreationModel.RoleId);
                p.Add("RoleTypeId", userCreationModel.RoleTypeId);
                p.Add("UserId", userCreationModel.UserId);
                p.Add("USER_LOGIN_ID", userCreationModel.UserLoginId);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("CHK", 1);
                Connection.Query<int>("USP_USER_CREATION", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                if (newID > 0)
                {
                    messageEF.Satus = newID.ToString();
                }
                return messageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// To View Users
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        public async Task<List<ViewUserCreationModel>> ViewUser(ViewUserCreationModel userCreationModel)
        {
            try
            {
                List<ViewUserCreationModel> userCreationModels = new List<ViewUserCreationModel>();
                var paramslist = new
                {
                    SP_MODE = "GET_USER_MASTER_DATA",
                    USER_ID = userCreationModel.UserId
                };
                var result = await Connection.QueryAsync<ViewUserCreationModel>("USP_USER_MASTER", paramslist, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    userCreationModels = result.ToList();
                }
                return userCreationModels;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public UserCreationModel EditUser(UserCreationModel userCreationModel)
        {
            try
            {
                UserCreationModel objuserCreation = new UserCreationModel();
                var paramslist = new
                {
                    CHK = 2,
                    UserId = userCreationModel.UserId
                };
                var result =  Connection.Query<UserCreationModel>("USP_USER_CREATION", paramslist, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objuserCreation = result.FirstOrDefault();
                }
                return objuserCreation;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MessageEF UpdateUser(UserCreationModel userCreationModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("UserName", userCreationModel.UserName);
                p.Add("ApplicantName", userCreationModel.ApplicantName);
                p.Add("MobileNo", userCreationModel.MobileNo);
                p.Add("EMailId", userCreationModel.EMailId);
                p.Add("DistrictId", userCreationModel.DistrictID);
                p.Add("StateId", userCreationModel.StateId);
                p.Add("Address", userCreationModel.Address);
                p.Add("Password", userCreationModel.Password);
                p.Add("EncryptPassword", userCreationModel.EncryptPassword);
                p.Add("PinCode", userCreationModel.PinCode);
                if (userCreationModel.LicenseeApplicationTypeId != null)
                {
                    p.Add("ApplicationTypeId", userCreationModel.LicenseeApplicationTypeId);
                }
                if (userCreationModel.LesseeApplicationTypeId != null)
                {
                    p.Add("APPLICATION_TYPE_ID", userCreationModel.LesseeApplicationTypeId);
                }
                p.Add("RoleId", userCreationModel.RoleId);
                p.Add("RoleTypeId", userCreationModel.RoleTypeId);
                p.Add("UserTypeId", userCreationModel.UsertypeId);
                p.Add("UserId", userCreationModel.UserId);
                p.Add("USER_LOGIN_ID", userCreationModel.UserLoginId);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("CHK", 3);
                p.Add("isActive", userCreationModel.IsActive);
                p.Add("isDelete", userCreationModel.IsDelete);
                Connection.Query<int>("USP_USER_CREATION", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                if (newID > 0)
                {
                    messageEF.Satus = newID.ToString();
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF DeleteUser(UserCreationModel userCreationModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("UserId", userCreationModel.UserId);
                p.Add("UserId2", userCreationModel.Userid1); 
                p.Add("USER_LOGIN_ID", userCreationModel.UserLoginId);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspInsertUserMaster2", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                if (newID > 0)
                {
                    messageEF.Satus = newID.ToString();
                }
                return messageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
