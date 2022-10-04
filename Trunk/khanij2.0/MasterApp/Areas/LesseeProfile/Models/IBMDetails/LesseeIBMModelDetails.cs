// ***********************************************************************
//  Class Name               : LesseeIBMModelDetails
//  Description              : Lessee IBM Model Details
//  Created By               : Lingaraj Dalai
//  Created On               : 26 July 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.LesseeProfile.Models.IBMDetails
{
    public class LesseeIBMModelDetails:ILesseeIBMModelDetails
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
        public LesseeIBMModelDetails(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To bind IBM details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public async Task<LesseeIBMDetailsViewModel> GetIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            try
            {
                LesseeIBMDetailsViewModel objgrantorderlist = new LesseeIBMDetailsViewModel();
                objgrantorderlist = JsonConvert.DeserializeObject<LesseeIBMDetailsViewModel>(await _objIHttpWebClients.AwaitPostRequest("LesseeIBMDetails/GetIBMDetails", JsonConvert.SerializeObject(objLesseeIBMDetailsModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse IBM details
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public MessageEF UpdateIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeIBMDetails/Update", JsonConvert.SerializeObject(objLesseeIBMDetailsModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind IBM Log details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeIBMDetailsViewModel>> GetIBMLogDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            try
            {
                List<LesseeIBMDetailsViewModel> objgrantorderlist = new List<LesseeIBMDetailsViewModel>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<LesseeIBMDetailsViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeIBMDetails/GetIBMLogDetails", JsonConvert.SerializeObject(objLesseeIBMDetailsModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind IBM Compare details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeIBMDetailsViewModel>> GetIBMCompareDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            try
            {
                List<LesseeIBMDetailsViewModel> objgrantorderlist = new List<LesseeIBMDetailsViewModel>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<LesseeIBMDetailsViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeIBMDetails/GetIBMCompareDetails", JsonConvert.SerializeObject(objLesseeIBMDetailsModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeIBMDetails/Approve", JsonConvert.SerializeObject(objLesseeIBMDetailsModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeIBMDetails/Reject", JsonConvert.SerializeObject(objLesseeIBMDetailsModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Delete Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeIBMDetails/Delete", JsonConvert.SerializeObject(objLesseeIBMDetailsModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
