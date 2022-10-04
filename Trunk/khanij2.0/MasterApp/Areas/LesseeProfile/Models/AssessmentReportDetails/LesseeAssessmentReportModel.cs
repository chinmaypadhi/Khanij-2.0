// ***********************************************************************
//  Class Name               : LesseeAssessmentReportModel
//  Description              : Lessee Assessment Report Model Details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 July 2021
// ***********************************************************************
using MasterApp.Models.Utility;
using MasterEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterApp.Areas.LesseeProfile.Models.AssessmentReportDetails
{
    public class LesseeAssessmentReportModel:ILesseeAssessmentReportModel
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
        public LesseeAssessmentReportModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To bind Assessment Report details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public async Task<LesseeAssessmentReportViewModel> GetAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            try
            {
                LesseeAssessmentReportViewModel objctelist = new LesseeAssessmentReportViewModel();
                objctelist = JsonConvert.DeserializeObject<LesseeAssessmentReportViewModel>(await _objIHttpWebClients.AwaitPostRequest("LesseeAssessmentReportDetails/GetAssessmentReportDetails", JsonConvert.SerializeObject(objLesseeAssessmentReportModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Assessment Report details
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public MessageEF UpdateAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeAssessmentReportDetails/Update", JsonConvert.SerializeObject(objLesseeAssessmentReportModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Assessment Report Log details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeAssessmentReportViewModel>> GetAssessmentReportLogDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            try
            {
                List<LesseeAssessmentReportViewModel> objctelist = new List<LesseeAssessmentReportViewModel>();
                objctelist = JsonConvert.DeserializeObject<List<LesseeAssessmentReportViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeAssessmentReportDetails/GetAssessmentReportLogDetails", JsonConvert.SerializeObject(objLesseeAssessmentReportModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Assessment Report Compare details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeAssessmentReportViewModel>> GetAssessmentReportCompareDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            try
            {
                List<LesseeAssessmentReportViewModel> objctelist = new List<LesseeAssessmentReportViewModel>();
                objctelist = JsonConvert.DeserializeObject<List<LesseeAssessmentReportViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeAssessmentReportDetails/GetAssessmentReportCompareDetails", JsonConvert.SerializeObject(objLesseeAssessmentReportModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeAssessmentReportDetails/Approve", JsonConvert.SerializeObject(objLesseeAssessmentReportModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeAssessmentReportDetails/Reject", JsonConvert.SerializeObject(objLesseeAssessmentReportModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Delete Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeAssessmentReportDetails/Delete", JsonConvert.SerializeObject(objLesseeAssessmentReportModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
