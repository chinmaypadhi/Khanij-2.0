// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 14-Apr-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using StarratingEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using StarratingApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace StarratingApp.Areas.Starrating.Models.Assessment
{
    public class AssessmentModel:IAssessmentModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public AssessmentModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region View Assessment List
        /// <summary>
        /// Bind Assessment List details
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> View(AssessmentListmaster objAssessmentListmaster)
        {
            try
            {
                List<AssessmentListmaster> objlistAssessmentListmaster = new List<AssessmentListmaster>();
                objlistAssessmentListmaster = JsonConvert.DeserializeObject<List<AssessmentListmaster>>(_objIHttpWebClients.PostRequest("Assessment/View", JsonConvert.SerializeObject(objAssessmentListmaster)));
                return objlistAssessmentListmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Bind dropdowns
        /// <summary>
        /// To Bind the State Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> GetStateList(AssessmentListmaster objAssessmentListmaster)
        {
            try
            {
                List<AssessmentListmaster> objlistFPOtype = new List<AssessmentListmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<AssessmentListmaster>>(_objIHttpWebClients.PostRequest("Assessment/GetStateList",JsonConvert.SerializeObject(objAssessmentListmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Bind the District Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> GetDistrictList(AssessmentListmaster objAssessmentListmaster)
        {
            try
            {
                List<AssessmentListmaster> objlistFPOtype = new List<AssessmentListmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<AssessmentListmaster>>(_objIHttpWebClients.PostRequest("Assessment/GetDistrictList",JsonConvert.SerializeObject(objAssessmentListmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Tehsil Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> GetTehsilList(AssessmentListmaster objAssessmentListmaster)
        {
            try
            {
                List<AssessmentListmaster> objlistFPOtype = new List<AssessmentListmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<AssessmentListmaster>>(_objIHttpWebClients.PostRequest("Assessment/GetTehsilList",JsonConvert.SerializeObject(objAssessmentListmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Village Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> GetVillageList(AssessmentListmaster objAssessmentListmaster)
        {
            try
            {
                List<AssessmentListmaster> objlistFPOtype = new List<AssessmentListmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<AssessmentListmaster>>(_objIHttpWebClients.PostRequest("Assessment/GetVillageList",JsonConvert.SerializeObject(objAssessmentListmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion
        #region View Assessment Template List
        /// <summary>
        /// Bind Financial Year List details in view
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> GetFYList(AssessmentListmaster objAssessmentListmaster)
        {
            try
            {
                List<AssessmentListmaster> objFYlist = new List<AssessmentListmaster>();
                objFYlist = JsonConvert.DeserializeObject<List<AssessmentListmaster>>(_objIHttpWebClients.PostRequest("Starrating/GetFYList",JsonConvert.SerializeObject(objAssessmentListmaster)));
                return objFYlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Assessment Template List Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public AssessmentListmaster ViewAssessmentTemplate(AssessmentListmaster objAssessmentListmaster)
        {
            try
            {
                AssessmentListmaster objassessmentlistmaster = new AssessmentListmaster();
                objassessmentlistmaster = JsonConvert.DeserializeObject<AssessmentListmaster>(_objIHttpWebClients.PostRequest("Starrating/ViewAssessmentTemplate", JsonConvert.SerializeObject(objAssessmentListmaster)));
                return objassessmentlistmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
    }
}
