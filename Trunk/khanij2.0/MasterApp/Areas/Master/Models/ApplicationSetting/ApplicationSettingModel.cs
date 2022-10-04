// ***********************************************************************
//  Class Name               : ApplicationSettingModel
//  Description              : Add,View,Edit,Update Application Setting Model Details
//  Created By               : Lingaraj Dalai
//  Created On               : 28-Jan-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.ApplicationSetting
{
    public class ApplicationSettingModel:IApplicationSettingModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public ApplicationSettingModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Update Application Setting Model Details in view
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        public MessageEF Update(ApplicationSettingmaster objApplicationSettingmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ApplicationSetting/Update", JsonConvert.SerializeObject(objApplicationSettingmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// View Application Setting Model Details in view
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        public List<ApplicationSettingmaster> View(ApplicationSettingmaster objApplicationSettingmaster)
        {
            try
            {
                List<ApplicationSettingmaster> objlistApplicationSettingmaster = new List<ApplicationSettingmaster>();
                objlistApplicationSettingmaster = JsonConvert.DeserializeObject<List<ApplicationSettingmaster>>(_objIHttpWebClients.PostRequest("ApplicationSetting/View", JsonConvert.SerializeObject(objApplicationSettingmaster)));
                return objlistApplicationSettingmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Application Setting Model Details in view
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        public ApplicationSettingmaster Edit(ApplicationSettingmaster objApplicationSettingmaster)
        {
            try
            {
                objApplicationSettingmaster = JsonConvert.DeserializeObject<ApplicationSettingmaster>(_objIHttpWebClients.PostRequest("ApplicationSetting/Edit", JsonConvert.SerializeObject(objApplicationSettingmaster)));
                return objApplicationSettingmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
