// ***********************************************************************
//  Class Name               : TenderModel
//  Desciption               : Add,Select,Update,Delete Website Tender Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Oct 2021
// ***********************************************************************
using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HomeApp.Areas.Website.Models.Tender
{
    public class TenderModel: ITenderModel
    {
        /// <summary>
        /// Object and Variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public TenderModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Website Tender Details
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        public MessageEF Add(AddTenderModel objAddTenderModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Tender/Add", JsonConvert.SerializeObject(objAddTenderModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        public MessageEF Update(AddTenderModel objAddTenderModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Tender/Update", JsonConvert.SerializeObject(objAddTenderModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Website Tender Details
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public AddTenderModel Edit(AddTenderModel objAddTenderModel)
        {
            try
            {
                objAddTenderModel = JsonConvert.DeserializeObject<AddTenderModel>(_objIHttpWebClients.PostRequest("Tender/Edit", JsonConvert.SerializeObject(objAddTenderModel)));
                return objAddTenderModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        public List<ViewTenderModel> View(ViewTenderModel objViewTenderModel)
        {
            try
            {
                List<ViewTenderModel> objlistTender = new List<ViewTenderModel>();
                objlistTender = JsonConvert.DeserializeObject<List<ViewTenderModel>>(_objIHttpWebClients.PostRequest("Tender/View", JsonConvert.SerializeObject(objViewTenderModel)));
                return objlistTender;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        public MessageEF Delete(ViewTenderModel objViewNotificationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Tender/Delete", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Active Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        public List<ViewTenderModel> ViewWebsiteTenderActive(ViewTenderModel objViewTenderModel)
        {
            try
            {
                List<ViewTenderModel> objlistTender = new List<ViewTenderModel>();
                objlistTender = JsonConvert.DeserializeObject<List<ViewTenderModel>>(_objIHttpWebClients.PostRequest("Tender/ViewWebsiteTenderActive", JsonConvert.SerializeObject(objViewTenderModel)));
                return objlistTender;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Acrhive Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        public List<ViewTenderModel> ViewWebsiteTenderArchive(ViewTenderModel objViewTenderModel)
        {
            try
            {
                List<ViewTenderModel> objlistTender = new List<ViewTenderModel>();
                objlistTender = JsonConvert.DeserializeObject<List<ViewTenderModel>>(_objIHttpWebClients.PostRequest("Tender/ViewWebsiteTenderArchive", JsonConvert.SerializeObject(objViewTenderModel)));
                return objlistTender;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Top Active Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        public List<ViewTenderModel> ViewTopWebsiteTender(ViewTenderModel objViewTenderModel)
        {
            try
            {
                List<ViewTenderModel> objlistTender = new List<ViewTenderModel>();
                objlistTender = JsonConvert.DeserializeObject<List<ViewTenderModel>>(_objIHttpWebClients.PostRequest("Tender/ViewTopWebsiteTender", JsonConvert.SerializeObject(objViewTenderModel)));
                return objlistTender;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
