// ***********************************************************************
//  Class Name               : OtherMineralModel
//  Description              : Add,View,Edit,Update,Delete Other Mineral Details
//  Created By               : Lingaraj Dalai
//  Created On               : 27 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Mineral
{
    public class OtherMineralModel:IOtherMineralModel
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
        public OtherMineralModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineralsmaster"></param>
        /// <returns></returns>
        public MessageEF AddOtherMineral(OtherMineralsmaster objOtherMineralsmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Mineral/AddOtherMineral", JsonConvert.SerializeObject(objOtherMineralsmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineralsmaster"></param>
        /// <returns></returns>
        public MessageEF UpdateOtherMineral(OtherMineralsmaster objOtherMineralsmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Mineral/UpdateOtherMineral", JsonConvert.SerializeObject(objOtherMineralsmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineralsmaster"></param>
        /// <returns></returns>
        public List<OtherMineralsmaster> ViewOtherMineral(OtherMineralsmaster objOtherMineralsmaster)
        {
            try
            {
                List<OtherMineralsmaster> objlistOtherMineralsmaster = new List<OtherMineralsmaster>();
                objlistOtherMineralsmaster = JsonConvert.DeserializeObject<List<OtherMineralsmaster>>(_objIHttpWebClients.PostRequest("Mineral/ViewOtherMineral", JsonConvert.SerializeObject(objOtherMineralsmaster)));
                return objlistOtherMineralsmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineralsmaster"></param>
        /// <returns></returns>
        public MessageEF DeleteOtherMineral(OtherMineralsmaster objOtherMineralsmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Mineral/DeleteOtherMineral", JsonConvert.SerializeObject(objOtherMineralsmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineralsmaster"></param>
        /// <returns></returns>
        public OtherMineralsmaster EditOtherMineral(OtherMineralsmaster objOtherMineralsmaster)
        {
            try
            {
                objOtherMineralsmaster = JsonConvert.DeserializeObject<OtherMineralsmaster>(_objIHttpWebClients.PostRequest("Mineral/EditOtherMineral", JsonConvert.SerializeObject(objOtherMineralsmaster)));
                return objOtherMineralsmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineralsmaster"></param>
        /// <returns></returns>
        public List<OtherMineralsmaster> GetOtherMineralList(OtherMineralsmaster objOtherMineralsmaster)
        {
            try
            {
                List<OtherMineralsmaster> objlistOtherMineral = new List<OtherMineralsmaster>();
                objlistOtherMineral = JsonConvert.DeserializeObject<List<OtherMineralsmaster>>(_objIHttpWebClients.PostRequest("Mineral/GetOtherMineralList", JsonConvert.SerializeObject(objOtherMineralsmaster)));
                return objlistOtherMineral;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Publish Status Details in view
        /// </summary>
        /// <param name="objOtherMineralsmaster"></param>
        /// <returns></returns>
        public MessageEF UpdatePublishStatus(OtherMineralsmaster objOtherMineralsmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Mineral/UpdatePublishStatus", JsonConvert.SerializeObject(objOtherMineralsmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Download Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineralsmaster"></param>
        /// <returns></returns>
        public OtherMineralsmaster Download_OtherMinerals(OtherMineralsmaster objOtherMineralsmaster)
        {
            try
            {
                OtherMineralsmaster objlistOtherMineral = new OtherMineralsmaster();
                objlistOtherMineral = JsonConvert.DeserializeObject<OtherMineralsmaster>(_objIHttpWebClients.PostRequest("Mineral/Download_OtherMinerals", JsonConvert.SerializeObject(objOtherMineralsmaster)));
                return objlistOtherMineral;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
