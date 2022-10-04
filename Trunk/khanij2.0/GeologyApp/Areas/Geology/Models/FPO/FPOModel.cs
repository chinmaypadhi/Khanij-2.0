// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 12-Feb-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using GeologyEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using GeologyApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace GeologyApp.Models.FPO
{
    public class FPOModel:IFPOModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public FPOModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region FPO Order
        /// <summary>
        /// To Add Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        public MessageEF Add(FPOOrdermaster objFPOmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("FPOOrder/Add",JsonConvert.SerializeObject(objFPOmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Update Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        public MessageEF Update(FPOOrdermaster objFPOmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("FPOOrder/Update",JsonConvert.SerializeObject(objFPOmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To View Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        public List<FPOOrdermaster> View(FPOOrdermaster objFPOmaster)
        {
            try
            {
                List<FPOOrdermaster> objlistFPOmaster = new List<FPOOrdermaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<FPOOrdermaster>>(_objIHttpWebClients.PostRequest("FPOOrder/View",JsonConvert.SerializeObject(objFPOmaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public MessageEF Delete(FPOOrdermaster objFPOmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("FPOOrder/Delete",JsonConvert.SerializeObject(objFPOmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Edit Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        public FPOOrdermaster Edit(FPOOrdermaster objFPOmaster)
        {
            try
            {
                objFPOmaster = JsonConvert.DeserializeObject<FPOOrdermaster>(_objIHttpWebClients.PostRequest("FPOOrder/Edit",JsonConvert.SerializeObject(objFPOmaster)));
                return objFPOmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Bind the Field Season list Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        public List<FPOOrdermaster> GetFieldSeasonList(FPOOrdermaster objFPOmaster)
        {
            try
            {
                List<FPOOrdermaster> objlistFPOtype = new List<FPOOrdermaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<FPOOrdermaster>>(_objIHttpWebClients.PostRequest("FPOOrder/GetFieldSeasonList",JsonConvert.SerializeObject(objFPOmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region FPO Creator
        /// <summary>
        /// To Bind the Field Program Order Creator Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        public MessageEF AddFPOCreator(FPOOrdermaster objFPOmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("FPOCreator/Add",JsonConvert.SerializeObject(objFPOmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Add the Field Program Order Creator Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        public List<FPOOrdermaster> ViewFPOCreator(FPOOrdermaster objFPOmaster)
        {
            try
            {
                List<FPOOrdermaster> objlistFPOmaster = new List<FPOOrdermaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<FPOOrdermaster>>(_objIHttpWebClients.PostRequest("FPOCreator/View",JsonConvert.SerializeObject(objFPOmaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region FPO Approver
        /// <summary>
        /// To Bind Field Program Order Approver details data in view
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        public MessageEF AddFPOApprover(FPOOrdermaster objFPOmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("FPOApprover/Add",JsonConvert.SerializeObject(objFPOmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Add Field Program Order Approver details data in view
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        public List<FPOOrdermaster> ViewFPOApprover(FPOOrdermaster objFPOmaster)
        {
            try
            {
                List<FPOOrdermaster> objlistFPOmaster = new List<FPOOrdermaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<FPOOrdermaster>>(_objIHttpWebClients.PostRequest("FPOApprover/View",JsonConvert.SerializeObject(objFPOmaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Generated FPO
        /// <summary>
        /// To View Generated Field Program Order details data in view
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        public List<FPOOrdermaster> ViewGeneratedFPO(FPOOrdermaster objFPOmaster)
        {
            try
            {
                List<FPOOrdermaster> objlistFPOmaster = new List<FPOOrdermaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<FPOOrdermaster>>(_objIHttpWebClients.PostRequest("GeneratedFPO/View",JsonConvert.SerializeObject(objFPOmaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
