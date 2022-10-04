// ***********************************************************************
// Class Name       : UserModel
// Author           : Prakash Chandra Biswal
// Created          : 24-Mar-2022
//
// ***********************************************************************
using MasterApp.Models.Utility;
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.User
{
    public class UserModel : IUserModel
    {
        #region for Global Declaration
        IHttpWebClients _objIHttpWebClients;
        #endregion

        public UserModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
        /// <summary>
        /// To Bind UserType Dropdown List
        /// </summary>
        /// <returns></returns>
        public List<UserCreationModel> GetUserTypeList()
        {
            try
            {
                List<UserCreationModel> objlistCheckPostmaster = new List<UserCreationModel>();
                objlistCheckPostmaster = JsonConvert.DeserializeObject<List<UserCreationModel>>(_objIHttpWebClients.PostRequest("Usertype/View", JsonConvert.SerializeObject(new UsertypeMaster())));
                return objlistCheckPostmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Bind State details in view
        /// </summary>
        /// <param name="objStatemaster"></param>
        /// <returns></returns>
        public List<UserCreationModel> StateList()
        {
            try
            {
                List<UserCreationModel> objlistStatemaster = new List<UserCreationModel>();
                objlistStatemaster = JsonConvert.DeserializeObject<List<UserCreationModel>>(_objIHttpWebClients.PostRequest("StateMaster/View", JsonConvert.SerializeObject(new Statemaster())));
                return objlistStatemaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        public List<UserCreationModel> GetDistrictList(UserCreationModel userCreationModel)
        {
            try
            {
                List<UserCreationModel> objlistDistrict = new List<UserCreationModel>();
                objlistDistrict = JsonConvert.DeserializeObject<List<UserCreationModel>>(_objIHttpWebClients.PostRequest("Block/GetDistrictList", JsonConvert.SerializeObject(userCreationModel)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// To Bind Department Dropdownlist by selecting usertype
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        public List<UserCreationModel> GetRoleTypeListByUserType(UserCreationModel userCreationModel)
        {
            try
            {
                List<UserCreationModel> objlistDistrict = new List<UserCreationModel>();
                objlistDistrict = JsonConvert.DeserializeObject<List<UserCreationModel>>(_objIHttpWebClients.PostRequest("User/GetRoleTypeListByUserType", JsonConvert.SerializeObject(userCreationModel)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Bind Designation Dropdwon by selecting Department
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        public List<UserCreationModel> GetRoleListByRoleType(UserCreationModel userCreationModel)
        {
            try
            {
                List<UserCreationModel> objlistDistrict = new List<UserCreationModel>();
                objlistDistrict = JsonConvert.DeserializeObject<List<UserCreationModel>>(_objIHttpWebClients.PostRequest("User/GetRoleListByRoleType", JsonConvert.SerializeObject(userCreationModel)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Create a New User
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        public MessageEF AddNewUser(UserCreationModel userCreationModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("User/AddNewUser", JsonConvert.SerializeObject(userCreationModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To View all Users
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        public List<ViewUserCreationModel> View(ViewUserCreationModel userCreationModel)
        {
            try
            {
                List<ViewUserCreationModel> objlistDistrict = new List<ViewUserCreationModel>();
                objlistDistrict = JsonConvert.DeserializeObject<List<ViewUserCreationModel>>(_objIHttpWebClients.PostRequest("User/ViewUser", JsonConvert.SerializeObject(userCreationModel)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public UserCreationModel Edit(UserCreationModel userCreationModel)
        {
            try
            {
                UserCreationModel objuserCreation = new UserCreationModel();
                objuserCreation = JsonConvert.DeserializeObject<UserCreationModel>(_objIHttpWebClients.PostRequest("User/EditUser", JsonConvert.SerializeObject(userCreationModel)));
                return objuserCreation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF Update(UserCreationModel userCreationModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("User/UpdateUser", JsonConvert.SerializeObject(userCreationModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF Delete(UserCreationModel userCreationModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("User/DeleteUser", JsonConvert.SerializeObject(userCreationModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Send SMS
        /// </summary>
        /// <param name="sMS"></param>
        /// <returns></returns>
        public MessageEF Main(SMS sMS)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SMSService/Main", JsonConvert.SerializeObject(sMS)));
                return messageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
