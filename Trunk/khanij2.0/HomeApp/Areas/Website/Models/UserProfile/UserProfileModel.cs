// ***********************************************************************
//  Class Name               : UserProfileModel
//  Desciption               : Add,View,Edit,Update,Delete Website User Profile Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 05 Nov 2021
// ***********************************************************************
using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HomeApp.Areas.Website.Models.UserProfile
{
    public class UserProfileModel:IUserProfileModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public UserProfileModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Website User Profile Details
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        public MessageEF Add(AddUserProfileModel objAddUserProfileModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserProfile/Add", JsonConvert.SerializeObject(objAddUserProfileModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Website User Profile Details 
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        public MessageEF Update(AddUserProfileModel objAddUserProfileModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserProfile/Update", JsonConvert.SerializeObject(objAddUserProfileModel)));
                return objMessageEF;
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
        public AddUserProfileModel Edit(AddUserProfileModel objAddUserProfileModel)
        {
            try
            {
                objAddUserProfileModel = JsonConvert.DeserializeObject<AddUserProfileModel>(_objIHttpWebClients.PostRequest("UserProfile/Edit", JsonConvert.SerializeObject(objAddUserProfileModel)));
                return objAddUserProfileModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website User Profile Details 
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        public List<ViewUserProfileModel> View(ViewUserProfileModel objViewUserProfileModel)
        {
            try
            {
                List<ViewUserProfileModel> objlistUserProfile = new List<ViewUserProfileModel>();
                objlistUserProfile = JsonConvert.DeserializeObject<List<ViewUserProfileModel>>(_objIHttpWebClients.PostRequest("UserProfile/View", JsonConvert.SerializeObject(objViewUserProfileModel)));
                return objlistUserProfile;
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
        public MessageEF Delete(ViewUserProfileModel objViewUserProfileModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserProfile/Delete", JsonConvert.SerializeObject(objViewUserProfileModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
