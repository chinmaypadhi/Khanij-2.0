// ***********************************************************************
//  Class Name               : LesseEnvironmentClearanceModel
//  Description              : Lessee Environment Clearance Model Details
//  Created By               : Lingaraj Dalai
//  Created On               : 30 July 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.LesseeProfile.Models.EnvironmentClearanceDetails
{
    public class LesseEnvironmentClearanceModel:ILesseEnvironmentClearanceModel
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
        public LesseEnvironmentClearanceModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To bind FY details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeEnvironmentClearanceViewModel>> GetFYDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                List<LesseeEnvironmentClearanceViewModel> objeclist = new List<LesseeEnvironmentClearanceViewModel>();
                objeclist = JsonConvert.DeserializeObject<List<LesseeEnvironmentClearanceViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeEnvironmentClearanceDetails/GetFYDetails", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<LesseeEnvironmentClearanceViewModel> GetEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                LesseeEnvironmentClearanceViewModel objeclist = new LesseeEnvironmentClearanceViewModel();
                objeclist = JsonConvert.DeserializeObject<LesseeEnvironmentClearanceViewModel>(await _objIHttpWebClients.AwaitPostRequest("LesseeEnvironmentClearanceDetails/GetEnvironmentClearanceDetails", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Approved Quantity details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetApprovedQuantityDetails(MiningProductionModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                List<MiningProductionModel> objeclist = new List<MiningProductionModel>();
                objeclist = JsonConvert.DeserializeObject<List<MiningProductionModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeEnvironmentClearanceDetails/GetApprovedQuantityDetails", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Environment Clearance details
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public MessageEF UpdateEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeEnvironmentClearanceDetails/Update", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Log details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceLogDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                List<LesseeEnvironmentClearanceViewModel> objeclist = new List<LesseeEnvironmentClearanceViewModel>();
                objeclist = JsonConvert.DeserializeObject<List<LesseeEnvironmentClearanceViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeEnvironmentClearanceDetails/GetEnvironmentClearanceLogDetails", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To get Environment Clearance Approved Quantity details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceApprovedQuantityLogDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                List<LesseeEnvironmentClearanceViewModel> objeclist = new List<LesseeEnvironmentClearanceViewModel>();
                objeclist = JsonConvert.DeserializeObject<List<LesseeEnvironmentClearanceViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeEnvironmentClearanceDetails/GetEnvironmentClearanceApprovedQuantityLogDetails", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Approved Quantity Log History details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceApprovedQuantityLogDetailsView(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                List<LesseeEnvironmentClearanceViewModel> objeclist = new List<LesseeEnvironmentClearanceViewModel>();
                objeclist = JsonConvert.DeserializeObject<List<LesseeEnvironmentClearanceViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeEnvironmentClearanceDetails/GetEnvironmentClearanceApprovedQuantityLogDetailsView", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Compare details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceCompareDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                List<LesseeEnvironmentClearanceViewModel> objeclist = new List<LesseeEnvironmentClearanceViewModel>();
                objeclist = JsonConvert.DeserializeObject<List<LesseeEnvironmentClearanceViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeEnvironmentClearanceDetails/GetEnvironmentClearanceCompareDetails", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Approved Quantity Compare details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetEnvironmentClearanceApprovedQuantityCompareDetails(MiningProductionModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                List<MiningProductionModel> objeclist = new List<MiningProductionModel>();
                objeclist = JsonConvert.DeserializeObject<List<MiningProductionModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeEnvironmentClearanceDetails/GetEnvironmentClearanceApprovedQuantityCompareDetails", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeEnvironmentClearanceDetails/Approve", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeEnvironmentClearanceDetails/Reject", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Delete Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeEnvironmentClearanceDetails/Delete", JsonConvert.SerializeObject(objLesseeEnvironmentClearanceModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
