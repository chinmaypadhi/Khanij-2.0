// ***********************************************************************
//  Class Name               : LesseeForestClearanceModel
//  Description              : Lessee Forest Clearance Model Details
//  Created By               : Lingaraj Dalai
//  Created On               : 27 July 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.LesseeProfile.Models.ForestClearanceDetails
{
    public class LesseeForestClearanceModel:ILesseeForestClearanceModel
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
        public LesseeForestClearanceModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To bind Forest Clearance details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public async Task<LesseeForestClearanceViewModel> GetForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            try
            {
                LesseeForestClearanceViewModel objgrantorderlist = new LesseeForestClearanceViewModel();
                objgrantorderlist = JsonConvert.DeserializeObject<LesseeForestClearanceViewModel>(await _objIHttpWebClients.AwaitPostRequest("LesseeForestClearanceDetails/GetForestClearanceDetails", JsonConvert.SerializeObject(objLesseeForestClearanceModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Forest Clearance details
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public MessageEF UpdateForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeForestClearanceDetails/Update", JsonConvert.SerializeObject(objLesseeForestClearanceModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Forest Clearance Log details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeForestClearanceViewModel>> GetForestClearanceLogDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            try
            {
                List<LesseeForestClearanceViewModel> objgrantorderlist = new List<LesseeForestClearanceViewModel>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<LesseeForestClearanceViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeForestClearanceDetails/GetForestClearanceLogDetails", JsonConvert.SerializeObject(objLesseeForestClearanceModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Forest Clearance Compare details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeForestClearanceViewModel>> GetForestClearanceCompareDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            try
            {
                List<LesseeForestClearanceViewModel> objgrantorderlist = new List<LesseeForestClearanceViewModel>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<LesseeForestClearanceViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeForestClearanceDetails/GetForestClearanceCompareDetails", JsonConvert.SerializeObject(objLesseeForestClearanceModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeForestClearanceDetails/Approve", JsonConvert.SerializeObject(objLesseeForestClearanceModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeForestClearanceDetails/Reject", JsonConvert.SerializeObject(objLesseeForestClearanceModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Delete Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeForestClearanceDetails/Delete", JsonConvert.SerializeObject(objLesseeForestClearanceModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
