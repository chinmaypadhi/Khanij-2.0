// ***********************************************************************
//  Class Name               : StaffDirectoryModel
//  Desciption               : Add,Select,Update,Delete Website Staff Directory Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Oct 2021
// ***********************************************************************
using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.StaffDirectory
{
    public class StaffDirectoryModel:IStaffDirectoryModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public StaffDirectoryModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Website Staff Directory Details
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        public MessageEF Add(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("StaffDirectory/Add", JsonConvert.SerializeObject(objAddStaffDirectoryModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Website Staff Directory Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        public MessageEF Update(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("StaffDirectory/Update", JsonConvert.SerializeObject(objAddStaffDirectoryModel)));
                return objMessageEF;
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
        public AddStaffDirectoryModel Edit(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            try
            {
                objAddStaffDirectoryModel = JsonConvert.DeserializeObject<AddStaffDirectoryModel>(_objIHttpWebClients.PostRequest("StaffDirectory/Edit", JsonConvert.SerializeObject(objAddStaffDirectoryModel)));
                return objAddStaffDirectoryModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Staff Directory Details 
        /// </summary>
        /// <param name="objViewStaffDirectoryModel"></param>
        /// <returns></returns>
        public List<ViewStaffDirectoryModel> View(ViewStaffDirectoryModel objViewStaffDirectoryModel)
        {
            try
            {
                List<ViewStaffDirectoryModel> objlistStaffDirectory = new List<ViewStaffDirectoryModel>();
                objlistStaffDirectory = JsonConvert.DeserializeObject<List<ViewStaffDirectoryModel>>( _objIHttpWebClients.PostRequest("StaffDirectory/View", JsonConvert.SerializeObject(objViewStaffDirectoryModel)));
                return objlistStaffDirectory;
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
        public MessageEF Delete(ViewStaffDirectoryModel objViewStaffDirectoryModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("StaffDirectory/Delete", JsonConvert.SerializeObject(objViewStaffDirectoryModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Website Staff Directory Type List Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        public List<AddStaffDirectoryModel> GetOfficeTypeList(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            try
            {
                List<AddStaffDirectoryModel> objlistNotificationType = new List<AddStaffDirectoryModel>();
                objlistNotificationType = JsonConvert.DeserializeObject<List<AddStaffDirectoryModel>>(_objIHttpWebClients.PostRequest("StaffDirectory/GetOfficeTypeList", JsonConvert.SerializeObject(objAddStaffDirectoryModel)));
                return objlistNotificationType;
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
        public List<ViewStaffDirectoryModel> ViewPublishStaffDirectory(ViewStaffDirectoryModel objViewStaffDirectoryModel)
        {
            try
            {
                List<ViewStaffDirectoryModel> objlistStaffDirectory = new List<ViewStaffDirectoryModel>();
                objlistStaffDirectory = JsonConvert.DeserializeObject<List<ViewStaffDirectoryModel>>(_objIHttpWebClients.PostRequest("StaffDirectory/ViewPublishStaffDirectory", JsonConvert.SerializeObject(objViewStaffDirectoryModel)));
                return objlistStaffDirectory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
