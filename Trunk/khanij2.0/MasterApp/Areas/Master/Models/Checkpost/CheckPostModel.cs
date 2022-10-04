// ***********************************************************************
//  Class Name               : CheckPostModel
//  Description              : Add,View,Edit,Update,Delete Checkpost Details
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Checkpost
{
    public class CheckPostModel:ICheckPostModel
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
        public CheckPostModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Checkpost Details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public MessageEF Add(Checkpostmaster objCheckPostmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CheckPost/Add", JsonConvert.SerializeObject(objCheckPostmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Checkpost Details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public MessageEF Update(Checkpostmaster objCheckPostmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CheckPost/Update", JsonConvert.SerializeObject(objCheckPostmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// View Checkpost Details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public List<Checkpostmaster> View(Checkpostmaster objCheckPostmaster)
        {
            try
            {
                List<Checkpostmaster> objlistCheckPostmaster = new List<Checkpostmaster>();
                objlistCheckPostmaster = JsonConvert.DeserializeObject<List<Checkpostmaster>>(_objIHttpWebClients.PostRequest("CheckPost/View", JsonConvert.SerializeObject(objCheckPostmaster)));
                return objlistCheckPostmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Checkpost Details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public MessageEF Delete(Checkpostmaster objCheckPostmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CheckPost/Delete", JsonConvert.SerializeObject(objCheckPostmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Checkpost Details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public Checkpostmaster Edit(Checkpostmaster objCheckPostmaster)
        {
            try
            {
                objCheckPostmaster = JsonConvert.DeserializeObject<Checkpostmaster>(_objIHttpWebClients.PostRequest("CheckPost/Edit", JsonConvert.SerializeObject(objCheckPostmaster)));
                return objCheckPostmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public List<Checkpostmaster> GetDistrictList(Checkpostmaster objCheckPostmaster)
        {
            try
            {
                List<Checkpostmaster> objlistDistrict = new List<Checkpostmaster>();
                objlistDistrict = JsonConvert.DeserializeObject<List<Checkpostmaster>>(_objIHttpWebClients.PostRequest("CheckPost/GetDistrictList", JsonConvert.SerializeObject(objCheckPostmaster)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind User List details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public List<Checkpostmaster> GetUserList(Checkpostmaster objCheckPostmaster)
        {
            try
            {
                List<Checkpostmaster> objlistUser = new List<Checkpostmaster>();
                objlistUser = JsonConvert.DeserializeObject<List<Checkpostmaster>>(_objIHttpWebClients.PostRequest("CheckPost/GetUserList", JsonConvert.SerializeObject(objCheckPostmaster)));
                return objlistUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
