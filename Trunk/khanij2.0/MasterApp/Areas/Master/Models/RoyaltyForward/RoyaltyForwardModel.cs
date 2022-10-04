// ***********************************************************************
//  Class Name               : RoyaltyForwardModel
//  Description              : Add,View,Edit,Update,Delete Royalty Forward Details
//  Created By               : Lingaraj Dalai
//  Created On               : 31 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.RoyaltyForward
{
    public class RoyaltyForwardModel:IRoyaltyForwardModel
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
        public RoyaltyForwardModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Bind Royalty Forward Details in view
        /// </summary>
        /// <param name="objRoyaltyForwardmaster"></param>
        /// <returns></returns>
        public List<RoyaltyForwardmaster> View(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            try
            {
                List<RoyaltyForwardmaster> objlistRoyaltyForwardmaster = new List<RoyaltyForwardmaster>();
                objlistRoyaltyForwardmaster = JsonConvert.DeserializeObject<List<RoyaltyForwardmaster>>(_objIHttpWebClients.PostRequest("RoyaltyForward/View", JsonConvert.SerializeObject(objRoyaltyForwardmaster)));
                return objlistRoyaltyForwardmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Add Royalty Forward Details in view
        /// </summary>
        /// <param name="objRoyaltyForwardmaster"></param>
        /// <returns></returns>
        public MessageEF Submit(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RoyaltyForward/Submit", JsonConvert.SerializeObject(objRoyaltyForwardmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Download Royalty Forward Details in view
        /// </summary>
        /// <param name="objRoyaltyForwardmaster"></param>
        /// <returns></returns>
        public List<RoyaltyForwardmaster> Download(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            try
            {
                List<RoyaltyForwardmaster> objlistRoyaltyForwardmaster = new List<RoyaltyForwardmaster>();
                objlistRoyaltyForwardmaster = JsonConvert.DeserializeObject<List<RoyaltyForwardmaster>>(_objIHttpWebClients.PostRequest("RoyaltyForward/Download", JsonConvert.SerializeObject(objRoyaltyForwardmaster)));
                return objlistRoyaltyForwardmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public List<RoyaltyForwardmaster> RoyaltyInbox(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            try
            {
                List<RoyaltyForwardmaster> objlistRoyaltyForwardmaster = new List<RoyaltyForwardmaster>();
                objlistRoyaltyForwardmaster = JsonConvert.DeserializeObject<List<RoyaltyForwardmaster>>(_objIHttpWebClients.PostRequest("RoyaltyForward/RoyaltyInbox", JsonConvert.SerializeObject(objRoyaltyForwardmaster)));
                return objlistRoyaltyForwardmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF TakeAction(RoyaltyForwardmaster objRoyalty)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RoyaltyForward/TakeAction", JsonConvert.SerializeObject(objRoyalty)));
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<WorkFlowDropDown> BindActionType(WorkFlowDropDown objActionType)
        {
            List<WorkFlowDropDown> _listActionType = new List<WorkFlowDropDown>();
            try
            {
                _listActionType = JsonConvert.DeserializeObject<List<WorkFlowDropDown>>(_objIHttpWebClients.PostRequest("WorkFlow/BindActionType", JsonConvert.SerializeObject(objActionType)));
                return _listActionType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RoyaltyApprovedLogEF> ViewRoyaltyActionHistory(RoyaltyApprovedLogEF objRoyalty)
        {
            List<RoyaltyApprovedLogEF> _listActionType = new List<RoyaltyApprovedLogEF>();
            try
            {
                _listActionType = JsonConvert.DeserializeObject<List<RoyaltyApprovedLogEF>>(_objIHttpWebClients.PostRequest("RoyaltyForward/ViewRoyaltyActionHistory", JsonConvert.SerializeObject(objRoyalty)));
                return _listActionType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RoyaltyApprovedEF> RoyaltyInboxView(RoyaltyApprovedEF objRoyalty)
        {
            try
            {
                List<RoyaltyApprovedEF> objlistRoyaltyForwardmaster = new List<RoyaltyApprovedEF>();
                objlistRoyaltyForwardmaster = JsonConvert.DeserializeObject<List<RoyaltyApprovedEF>>(_objIHttpWebClients.PostRequest("RoyaltyForward/RoyaltyInboxView", JsonConvert.SerializeObject(objRoyalty)));
                return objlistRoyaltyForwardmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
