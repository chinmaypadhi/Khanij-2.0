// ***********************************************************************
//  Class Name               : LesseeCTEModel
//  Description              : Lessee Consent To Establish Model Details
//  Created By               : Lingaraj Dalai
//  Created On               : 28 July 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.LesseeProfile.Models.CTEDetails
{
    public class LesseeCTEModel:ILesseeCTEModel
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
        /// <summary>
        /// To bind Consent To Establish details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public LesseeCTEModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To Bind Lessee CTE details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public async Task<LesseeCTEViewModel> GetCTEDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            try
            {
                LesseeCTEViewModel objctelist = new LesseeCTEViewModel();
                objctelist = JsonConvert.DeserializeObject<LesseeCTEViewModel>(await _objIHttpWebClients.AwaitPostRequest("LesseeCTEDetails/GetCTEDetails", JsonConvert.SerializeObject(objLesseeCTEModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Consent To Establish details
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public MessageEF UpdateCTEDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeCTEDetails/Update", JsonConvert.SerializeObject(objLesseeCTEModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Consent To Establish Log details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTEViewModel>> GetCTELogDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            try
            {
                List<LesseeCTEViewModel> objctelist = new List<LesseeCTEViewModel>();
                objctelist = JsonConvert.DeserializeObject<List<LesseeCTEViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeCTEDetails/GetCTELogDetails", JsonConvert.SerializeObject(objLesseeCTEModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Consent To Establish Compare details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeCTEViewModel>> GetCTECompareDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            try
            {
                List<LesseeCTEViewModel> objctelist = new List<LesseeCTEViewModel>();
                objctelist = JsonConvert.DeserializeObject<List<LesseeCTEViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeCTEDetails/GetCTECompareDetails", JsonConvert.SerializeObject(objLesseeCTEModel)));
                return objctelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeCTEDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeCTEDetails/Approve", JsonConvert.SerializeObject(objLesseeCTEModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeCTEDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeCTEDetails/Reject", JsonConvert.SerializeObject(objLesseeCTEModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Delete Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeCTEDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeCTEDetails/Delete", JsonConvert.SerializeObject(objLesseeCTEModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
