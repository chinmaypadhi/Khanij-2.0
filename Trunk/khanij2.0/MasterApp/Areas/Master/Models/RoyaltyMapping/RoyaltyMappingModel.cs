// ***********************************************************************
//  Class Name               : RoyaltyMappingModel
//  Description              : Add,View,Edit,Update,Delete RoyaltyMapping Details
//  Created By               : Lingaraj Dalai
//  Created On               : 02 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.RoyaltyMapping
{
    public class RoyaltyMappingModel:IRoyaltyMappingModel
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
        public RoyaltyMappingModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add RoyaltyMapping Details in view
        /// </summary>
        /// <param name="objRoyaltyMappingmaster"></param>
        /// <returns></returns>
        public MessageEF Add(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RoyaltyMapping/Add", JsonConvert.SerializeObject(objRoyaltyMappingmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind RoyaltyMapping Details in view
        /// </summary>
        /// <param name="objRoyaltyMappingmaster"></param>
        /// <returns></returns>
        public List<RoyaltyMappingmaster> View(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            try
            {
                List<RoyaltyMappingmaster> objlistRoyaltyMappingmaster = new List<RoyaltyMappingmaster>();
                objlistRoyaltyMappingmaster = JsonConvert.DeserializeObject<List<RoyaltyMappingmaster>>(_objIHttpWebClients.PostRequest("RoyaltyMapping/View", JsonConvert.SerializeObject(objRoyaltyMappingmaster)));
                return objlistRoyaltyMappingmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete RoyaltyMapping Details in view
        /// </summary>
        /// <param name="objRoyaltyMappingmaster"></param>
        /// <returns></returns>
        public MessageEF Delete(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RoyaltyMapping/Delete", JsonConvert.SerializeObject(objRoyaltyMappingmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit RoyaltyMapping Details in view
        /// </summary>
        /// <param name="objRoyaltyMappingmaster"></param>
        /// <returns></returns>
        public RoyaltyMappingmaster Edit(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            try
            {
                objRoyaltyMappingmaster = JsonConvert.DeserializeObject<RoyaltyMappingmaster>(_objIHttpWebClients.PostRequest("RoyaltyMapping/Edit", JsonConvert.SerializeObject(objRoyaltyMappingmaster)));
                return objRoyaltyMappingmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// View Payment Type Detais in view
        /// </summary>
        /// <param name="objRoyaltyMappingmaster"></param>
        /// <returns></returns>
        public List<RoyaltyMappingmaster> ViewPaymentType(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            try
            {
                List<RoyaltyMappingmaster> objlistRoyaltyMappingmaster = new List<RoyaltyMappingmaster>();
                objlistRoyaltyMappingmaster = JsonConvert.DeserializeObject<List<RoyaltyMappingmaster>>(_objIHttpWebClients.PostRequest("RoyaltyMapping/ViewPaymentType", JsonConvert.SerializeObject(objRoyaltyMappingmaster)));
                return objlistRoyaltyMappingmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// View Royalty Type Mapping Details in view
        /// </summary>
        /// <param name="objRoyaltyMappingmaster"></param>
        /// <returns></returns>
        public List<RoyaltyMappingmaster> ViewRoyaltyType(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            try
            {
                List<RoyaltyMappingmaster> objlistRoyaltyMappingmaster = new List<RoyaltyMappingmaster>();
                objlistRoyaltyMappingmaster = JsonConvert.DeserializeObject<List<RoyaltyMappingmaster>>(_objIHttpWebClients.PostRequest("RoyaltyMapping/ViewRoyaltyType", JsonConvert.SerializeObject(objRoyaltyMappingmaster)));
                return objlistRoyaltyMappingmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
