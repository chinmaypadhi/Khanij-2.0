// ***********************************************************************
//  Class Name               : WeighBridgeModel
//  Description              : Add,View,Edit,Update,Delete WeighBridge Details
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.WeighBridge
{
    public class WeighBridgeModel:IWeighBridgeModel
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
        public WeighBridgeModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add WeighBridge Details in view
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        public MessageEF Add(WeighBridgemaster objWeighBridgemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridge/Add", JsonConvert.SerializeObject(objWeighBridgemaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update WeighBridge Details in view
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        public MessageEF Update(WeighBridgemaster objWeighBridgemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridge/Update", JsonConvert.SerializeObject(objWeighBridgemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind WeighBridge Details in view
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        public List<WeighBridgemaster> View(WeighBridgemaster objWeighBridgemaster)
        {
            try
            {
                List<WeighBridgemaster> objlistWeighBridgemaster = new List<WeighBridgemaster>();
                objlistWeighBridgemaster = JsonConvert.DeserializeObject<List<WeighBridgemaster>>(_objIHttpWebClients.PostRequest("WeighBridge/View", JsonConvert.SerializeObject(objWeighBridgemaster)));
                return objlistWeighBridgemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete WeighBridge Details in view
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        public MessageEF Delete(WeighBridgemaster objWeighBridgemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridge/Delete", JsonConvert.SerializeObject(objWeighBridgemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit WeighBridge Details in view
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        public WeighBridgemaster Edit(WeighBridgemaster objWeighBridgemaster)
        {
            try
            {
                objWeighBridgemaster = JsonConvert.DeserializeObject<WeighBridgemaster>(_objIHttpWebClients.PostRequest("WeighBridge/Edit", JsonConvert.SerializeObject(objWeighBridgemaster)));
                return objWeighBridgemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind District List Details in view
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        public List<WeighBridgemaster> GetDistrictList(WeighBridgemaster objWeighBridgemaster)
        {
            try
            {
                List<WeighBridgemaster> objlistDistrict = new List<WeighBridgemaster>();
                objlistDistrict = JsonConvert.DeserializeObject<List<WeighBridgemaster>>(_objIHttpWebClients.PostRequest("WeighBridge/GetDistrictList", JsonConvert.SerializeObject(objWeighBridgemaster)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
