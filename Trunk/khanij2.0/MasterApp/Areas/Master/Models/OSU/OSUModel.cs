// ***********************************************************************
//  Class Name               : OSUModel
//  Description              : Add,View,Edit,Update,Delete OSU Details
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.OSU
{
    public class OSUModel:IOSUModel
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
        public OSUModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add OSU Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public MessageEF Add(OSUmaster objOSUmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("OSU/Add", JsonConvert.SerializeObject(objOSUmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetDistrictList(OSUmaster objOSUmaster)
        {
            try
            {
                List<OSUmaster> objlistDistrict = new List<OSUmaster>();
                objlistDistrict = JsonConvert.DeserializeObject<List<OSUmaster>>(_objIHttpWebClients.PostRequest("OSU/GetDistrictList", JsonConvert.SerializeObject(objOSUmaster)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind User Type List details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetUserTypeList(OSUmaster objOSUmaster)
        {
            try
            {
                List<OSUmaster> objlistUser = new List<OSUmaster>();
                objlistUser = JsonConvert.DeserializeObject<List<OSUmaster>>(_objIHttpWebClients.PostRequest("OSU/GetUserTypeList", JsonConvert.SerializeObject(objOSUmaster)));
                return objlistUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Company List details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetCompanyList(OSUmaster objOSUmaster)
        {
            try
            {
                List<OSUmaster> objlistUser = new List<OSUmaster>();
                objlistUser = JsonConvert.DeserializeObject<List<OSUmaster>>(_objIHttpWebClients.PostRequest("OSU/GetCompanyList", JsonConvert.SerializeObject(objOSUmaster)));
                return objlistUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Lesse Type List details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetLesseeTypeList(OSUmaster objOSUmaster)
        {
            try
            {
                List<OSUmaster> objlistUser = new List<OSUmaster>();
                objlistUser = JsonConvert.DeserializeObject<List<OSUmaster>>(_objIHttpWebClients.PostRequest("OSU/GetLesseeTypeList", JsonConvert.SerializeObject(objOSUmaster)));
                return objlistUser;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Licensee List details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetLicenseeTypeList(OSUmaster objOSUmaster)
        {
            try
            {
                List<OSUmaster> objlistUser = new List<OSUmaster>();
                objlistUser = JsonConvert.DeserializeObject<List<OSUmaster>>(_objIHttpWebClients.PostRequest("OSU/GetLicenseeTypeList", JsonConvert.SerializeObject(objOSUmaster)));
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
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetChangeStatusList(OSUmaster objOSUmaster)
        {
            try
            {
                List<OSUmaster> objlistStatus = new List<OSUmaster>();
                objlistStatus = JsonConvert.DeserializeObject<List<OSUmaster>>(_objIHttpWebClients.PostRequest("OSU/GetChangeStatusList", JsonConvert.SerializeObject(objOSUmaster)));
                return objlistStatus;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// To Update Encrypt Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        public MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("OSU/UpdateEncryptPassword", JsonConvert.SerializeObject(updateEncryptPasswordModel)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
