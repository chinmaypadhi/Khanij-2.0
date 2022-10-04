// ***********************************************************************
//  Class Name               : LesseeMiningPlanModel
//  Description              : Lessee Mining Plan Model Details
//  Created By               : Lingaraj Dalai
//  Created On               : 01 August 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.LesseeProfile.Models.LesseeMiningPlan
{
    public class LesseeMiningPlanModel:ILesseeMiningPlanModel
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
        public LesseeMiningPlanModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To bind Mining Plan Financial year details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMiningPlanViewModel>> GetFYDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            try
            {
                List<LesseeMiningPlanViewModel> ObjMiningPlanlistDetails = new List<LesseeMiningPlanViewModel>();
                ObjMiningPlanlistDetails = JsonConvert.DeserializeObject<List<LesseeMiningPlanViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMiningPlanDetails/GetFYDetails", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Plan details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<LesseeMiningPlanViewModel> GetMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            try
            {
                LesseeMiningPlanViewModel ObjMiningPlanDetails = new LesseeMiningPlanViewModel();
                ObjMiningPlanDetails = JsonConvert.DeserializeObject<LesseeMiningPlanViewModel>(await _objIHttpWebClients.AwaitPostRequest("LesseeMiningPlanDetails/GetMiningPlanDetails", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return ObjMiningPlanDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Plan Production details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetProductionDetails(MiningProductionModel objLesseeMiningPlanModel)
        {
            try
            {
                List<MiningProductionModel> ObjProductionlistDetails = new List<MiningProductionModel>();
                ObjProductionlistDetails = JsonConvert.DeserializeObject<List<MiningProductionModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMiningPlanDetails/GetProductionDetails", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return ObjProductionlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Mining Plan details
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public MessageEF UpdateMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeMiningPlanDetails/Update", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Plan Log details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMiningPlanViewModel>> GetMiningPlanMPLogDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            try
            {
                List<LesseeMiningPlanViewModel> ObjMiningPlanlistDetails = new List<LesseeMiningPlanViewModel>();
                ObjMiningPlanlistDetails = JsonConvert.DeserializeObject<List<LesseeMiningPlanViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMiningPlanDetails/GetMiningPlanMPLogDetails", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Scheme Log details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMiningPlanViewModel>> GetMiningPlanMSLogDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            try
            {
                List<LesseeMiningPlanViewModel> ObjMiningPlanlistDetails = new List<LesseeMiningPlanViewModel>();
                ObjMiningPlanlistDetails = JsonConvert.DeserializeObject<List<LesseeMiningPlanViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMiningPlanDetails/GetMiningPlanMSLogDetails", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Scheme Log details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMiningPlanViewModel>> GetMiningPlanMSLogDetailsView(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            try
            {
                List<LesseeMiningPlanViewModel> ObjMiningPlanlistDetails = new List<LesseeMiningPlanViewModel>();
                ObjMiningPlanlistDetails = JsonConvert.DeserializeObject<List<LesseeMiningPlanViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMiningPlanDetails/GetMiningPlanMSLogDetailsView", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Plan Compare details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMiningPlanViewModel>> GetMiningPlanCompareDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            try
            {
                List<LesseeMiningPlanViewModel> ObjMiningPlanlistDetails = new List<LesseeMiningPlanViewModel>();
                ObjMiningPlanlistDetails = JsonConvert.DeserializeObject<List<LesseeMiningPlanViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMiningPlanDetails/GetMiningPlanCompareDetails", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mining Scheme Compare details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetMiningSchemeCompareDetails(MiningProductionModel objLesseeMiningPlanModel)
        {
            try
            {
                List<MiningProductionModel> ObjMiningPlanlistDetails = new List<MiningProductionModel>();
                ObjMiningPlanlistDetails = JsonConvert.DeserializeObject<List<MiningProductionModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMiningPlanDetails/GetMiningSchemeCompareDetails", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return ObjMiningPlanlistDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeMiningPlanDetails/Approve", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeMiningPlanDetails/Reject", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Delete Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeMiningPlanDetails/Delete", JsonConvert.SerializeObject(objLesseeMiningPlanModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
