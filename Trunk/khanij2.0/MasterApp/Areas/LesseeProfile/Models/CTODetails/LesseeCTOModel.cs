// ***********************************************************************
//  Class Name               : LesseeCTOModel
//  Description              : Lessee Consent To Operate Model Details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 July 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.LesseeProfile.Models.CTODetails
{
    public class LesseeCTOModel:ILesseeCTOModel
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
        public LesseeCTOModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To bind Consent To Operate Financial year details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTOViewModel>> GetFYDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            try
            {
                List<LesseeCTOViewModel> objctelist = new List<LesseeCTOViewModel>();
                objctelist = JsonConvert.DeserializeObject<List<LesseeCTOViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeCTODetails/GetFYDetails", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Consent To Operate details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<LesseeCTOViewModel> GetCTODetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            try
            {
                LesseeCTOViewModel objctelist = new LesseeCTOViewModel();
                objctelist = JsonConvert.DeserializeObject<LesseeCTOViewModel>(await _objIHttpWebClients.AwaitPostRequest("LesseeCTODetails/GetCTODetails", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Consent To Operate Approved Quantity Details details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetApprovedQuantityDetails(MiningProductionModel objLesseeCTOModel)
        {
            try
            {
                List<MiningProductionModel> objctelist = new List<MiningProductionModel>();
                objctelist = JsonConvert.DeserializeObject<List<MiningProductionModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeCTODetails/GetApprovedQuantityDetails", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Consent To Operate details
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public MessageEF UpdateCTODetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeCTODetails/Update", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Consent To Operate Log details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTOViewModel>> GetCTOLogDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            try
            {
                List<LesseeCTOViewModel> objctelist = new List<LesseeCTOViewModel>();
                objctelist = JsonConvert.DeserializeObject<List<LesseeCTOViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeCTODetails/GetCTOLogDetails", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To get Consent To Operate Log History details
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTOViewModel>> GetCTOApprovedQuantityLogDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            try
            {
                List<LesseeCTOViewModel> objctelist = new List<LesseeCTOViewModel>();
                objctelist = JsonConvert.DeserializeObject<List<LesseeCTOViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeCTODetails/GetCTOApprovedQuantityLogDetails", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Consent To Operate Log History details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTOViewModel>> GetCTOApprovedQuantityLogDetailsView(LesseeCTOViewModel objLesseeCTOModel)
        {
            try
            {
                List<LesseeCTOViewModel> objctelist = new List<LesseeCTOViewModel>();
                objctelist = JsonConvert.DeserializeObject<List<LesseeCTOViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeCTODetails/GetCTOApprovedQuantityLogDetailsView", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Consent To Operate Compare details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTOViewModel>> GetCTOCompareDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            try
            {
                List<LesseeCTOViewModel> objctelist = new List<LesseeCTOViewModel>();
                objctelist = JsonConvert.DeserializeObject<List<LesseeCTOViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeCTODetails/GetCTOCompareDetails", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Consent To Operate Approved Quantity Compare details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetCTOApprovedQuantityCompareDetails(MiningProductionModel objLesseeCTOModel)
        {
            try
            {
                List<MiningProductionModel> objctelist = new List<MiningProductionModel>();
                objctelist = JsonConvert.DeserializeObject<List<MiningProductionModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeCTODetails/GetCTOApprovedQuantityCompareDetails", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeCTODetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeCTODetails/Approve", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeCTODetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeCTODetails/Reject", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Delete Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeCTODetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeCTODetails/Delete", JsonConvert.SerializeObject(objLesseeCTOModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
