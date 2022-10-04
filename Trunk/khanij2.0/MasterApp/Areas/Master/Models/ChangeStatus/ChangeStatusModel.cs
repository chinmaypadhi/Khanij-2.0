// ***********************************************************************
//  Class Name               : ChangeStatusModel
//  Description              : Add,View,Edit,Update,Delete Change Status Model Details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.ChangeStatus
{
    public class ChangeStatusModel:IChangeStatusModel
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
        public ChangeStatusModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Change Status Model details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public MessageEF Add(ChangeStatusmaster objChangeStatusmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ChangeStatus/Add", JsonConvert.SerializeObject(objChangeStatusmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind District list details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public List<ChangeStatusmaster> GetDistrictList(ChangeStatusmaster objChangeStatusmaster)
        {
            try
            {
                List<ChangeStatusmaster> objlistDistrict = new List<ChangeStatusmaster>();
                objlistDistrict = JsonConvert.DeserializeObject<List<ChangeStatusmaster>>(_objIHttpWebClients.PostRequest("ChangeStatus/GetDistrictList", JsonConvert.SerializeObject(objChangeStatusmaster)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Division list details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public List<ChangeStatusmaster> GetDivisionList(ChangeStatusmaster objChangeStatusmaster)
        {
            try
            {
                List<ChangeStatusmaster> objlistUser = new List<ChangeStatusmaster>();
                objlistUser = JsonConvert.DeserializeObject<List<ChangeStatusmaster>>(_objIHttpWebClients.PostRequest("ChangeStatus/GetDivisionList", JsonConvert.SerializeObject(objChangeStatusmaster)));
                return objlistUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Get User Type List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public List<ChangeStatusmaster> GetUserTypeList(ChangeStatusmaster objChangeStatusmaster)
        {
            try
            {
                List<ChangeStatusmaster> objlistDistrict = new List<ChangeStatusmaster>();
                objlistDistrict = JsonConvert.DeserializeObject<List<ChangeStatusmaster>>(_objIHttpWebClients.PostRequest("ChangeStatus/GetUserTypeList", JsonConvert.SerializeObject(objChangeStatusmaster)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Get User Name List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public List<ChangeStatusmaster> GetUserNameList(ChangeStatusmaster objChangeStatusmaster)
        {
            try
            {
                List<ChangeStatusmaster> objlistUser = new List<ChangeStatusmaster>();
                objlistUser = JsonConvert.DeserializeObject<List<ChangeStatusmaster>>(_objIHttpWebClients.PostRequest("ChangeStatus/GetUserNameList", JsonConvert.SerializeObject(objChangeStatusmaster)));
                return objlistUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Get Change Status List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public List<ChangeStatusmaster> GetChangeStatusList(ChangeStatusmaster objChangeStatusmaster)
        {
            try
            {
                List<ChangeStatusmaster> objlistUser = new List<ChangeStatusmaster>();
                objlistUser = JsonConvert.DeserializeObject<List<ChangeStatusmaster>>(_objIHttpWebClients.PostRequest("ChangeStatus/GetChangeStatusList", JsonConvert.SerializeObject(objChangeStatusmaster)));
                return objlistUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Get Current Status List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public ChangeStatusmaster GetCurrentStatusList(ChangeStatusmaster objChangeStatusmaster)
        {
            try
            {
                ChangeStatusmaster objlistUser = new ChangeStatusmaster();
                objlistUser = JsonConvert.DeserializeObject<ChangeStatusmaster>(_objIHttpWebClients.PostRequest("ChangeStatus/GetCurrentStatusList", JsonConvert.SerializeObject(objChangeStatusmaster)));
                return objlistUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
