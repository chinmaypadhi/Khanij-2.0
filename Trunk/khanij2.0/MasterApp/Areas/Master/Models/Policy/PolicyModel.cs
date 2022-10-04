// ***********************************************************************
//  Class Name               : PolicyModel
//  Description              : Add,View,Edit,Update,Delete Policy Details
//  Created By               : Lingaraj Dalai
//  Created On               : 21 Jan 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Policy
{
    public class PolicyModel:IPolicyModel
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
        public PolicyModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Policy Details in view
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        public MessageEF Add(Policymaster objPolicymaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Policy/Add", JsonConvert.SerializeObject(objPolicymaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Policy Details in view
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        public MessageEF Update(Policymaster objPolicymaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Policy/Update", JsonConvert.SerializeObject(objPolicymaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Policy Details in view
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        public List<Policymaster> View(Policymaster objPolicymaster)
        {
            try
            {
                List<Policymaster> objlistPolicymaster = new List<Policymaster>();
                objlistPolicymaster = JsonConvert.DeserializeObject<List<Policymaster>>(_objIHttpWebClients.PostRequest("Policy/View", JsonConvert.SerializeObject(objPolicymaster)));
                return objlistPolicymaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Policy Details in view
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        public MessageEF Delete(Policymaster objPolicymaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Policy/Delete", JsonConvert.SerializeObject(objPolicymaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Policy Details in view
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        public Policymaster Edit(Policymaster objPolicymaster)
        {
            try
            {
                objPolicymaster = JsonConvert.DeserializeObject<Policymaster>(_objIHttpWebClients.PostRequest("Policy/Edit", JsonConvert.SerializeObject(objPolicymaster)));
                return objPolicymaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get Policy Type List details in view
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        public List<Policymaster> GetPolicyTypeList(Policymaster objPolicymaster)
        {
            try
            {
                List<Policymaster> objlistPolicytype = new List<Policymaster>();
                objlistPolicytype = JsonConvert.DeserializeObject<List<Policymaster>>(_objIHttpWebClients.PostRequest("Policy/GetPolicyTypeList", JsonConvert.SerializeObject(objPolicymaster)));
                return objlistPolicytype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
