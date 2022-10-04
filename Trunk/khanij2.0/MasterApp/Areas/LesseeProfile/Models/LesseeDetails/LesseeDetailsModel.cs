// ***********************************************************************
//  Class Name               : LesseeDetailsModel
//  Desciption               : Lessee Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 July 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace MasterApp.Areas.LesseeProfile.Models.LesseeDetails
{
    public class LesseeDetailsModel : ILesseeDetailsModel
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
        public LesseeDetailsModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To bind Lessee Profile Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public LesseeInfoModel GetLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                LesseeInfoModel objlistUser = new LesseeInfoModel();
                objlistUser = JsonConvert.DeserializeObject<LesseeInfoModel>(_objIHttpWebClients.PostRequest("LesseeDetails/GetLesseeProfileDetails", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objlistUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Lessee Type Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetLesseeTypeList(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                List<LesseeInfoModel> objlistUser = new List<LesseeInfoModel>();
                objlistUser = JsonConvert.DeserializeObject<List<LesseeInfoModel>>(_objIHttpWebClients.PostRequest("LesseeDetails/GetLesseeTypeList", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objlistUser;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Auction Type Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetAuctionTypeList(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                List<LesseeInfoModel> objlistAuction = new List<LesseeInfoModel>();
                objlistAuction = JsonConvert.DeserializeObject<List<LesseeInfoModel>>(_objIHttpWebClients.PostRequest("LesseeDetails/GetAuctionTypeList", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objlistAuction;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Update Lesse Profile details
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public MessageEF UpdateLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeDetails/Update", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Bind the Lessee Profile Log Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetLesseeProfileLogList(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                List<LesseeInfoModel> objlistUser = new List<LesseeInfoModel>();
                objlistUser = JsonConvert.DeserializeObject<List<LesseeInfoModel>>(_objIHttpWebClients.PostRequest("LesseeDetails/GetLesseeProfileLogList", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objlistUser;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To bind Lessee Profile Request Data in view
        /// </summary>
        /// <param name="objLesseeProfileRequestInfoModel"></param>
        /// <returns></returns>
        public List<LesseeProfileRequestModel> GetLesseeProfileRequestData(LesseeProfileRequestModel objLesseeProfileRequestInfoModel)
        {
            try
            {
                List<LesseeProfileRequestModel> objlistlesseeProfileRequest = new List<LesseeProfileRequestModel>();
                objlistlesseeProfileRequest = JsonConvert.DeserializeObject<List<LesseeProfileRequestModel>>(_objIHttpWebClients.PostRequest("LesseeDetails/GetLesseeProfileRequestData", JsonConvert.SerializeObject(objLesseeProfileRequestInfoModel)));
                return objlistlesseeProfileRequest;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        ///  To bind Last approved Lessee Profile Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetLesseeProfileCompareDetails(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                List<LesseeInfoModel> objlistUser = new List<LesseeInfoModel>();
                objlistUser = JsonConvert.DeserializeObject<List<LesseeInfoModel>>(_objIHttpWebClients.PostRequest("LesseeDetails/GetLesseeProfileCompareDetails", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objlistUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Profile details by DD
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeDetails/Approve", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse Profile details by DD
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeDetails/Reject", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Delete Lesse Profile details
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeDetails/Delete", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Bind the State Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetStateList(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                List<LesseeInfoModel> objlistAuction = new List<LesseeInfoModel>();
                objlistAuction = JsonConvert.DeserializeObject<List<LesseeInfoModel>>(_objIHttpWebClients.PostRequest("LesseeLeaseAreaDetails/GetStateList", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objlistAuction;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Bind the User Type Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetUserTypeList(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                List<LesseeInfoModel> objlistAuction = new List<LesseeInfoModel>();
                objlistAuction = JsonConvert.DeserializeObject<List<LesseeInfoModel>>(_objIHttpWebClients.PostRequest("LesseeDetails/GetUserTypeList", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objlistAuction;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Bind the User Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetUserList(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                List<LesseeInfoModel> objlistAuction = new List<LesseeInfoModel>();
                objlistAuction = JsonConvert.DeserializeObject<List<LesseeInfoModel>>(_objIHttpWebClients.PostRequest("LesseeDetails/GetUserList", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objlistAuction;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Captive Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetCaptiveList(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                List<LesseeInfoModel> objlistAuction = new List<LesseeInfoModel>();
                objlistAuction = JsonConvert.DeserializeObject<List<LesseeInfoModel>>(_objIHttpWebClients.PostRequest("LesseeDetails/GetCaptiveList", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objlistAuction;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// To bind Captive purpose details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<CaptivePurposeModel>> GetPurposeDetails(CaptivePurposeModel objLesseeInfoModel)
        {
            try
            {
                List<CaptivePurposeModel> objeclist = new List<CaptivePurposeModel>();
                objeclist = JsonConvert.DeserializeObject<List<CaptivePurposeModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeDetails/GetPurposeDetails", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Lessee Captive purpose log details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeInfoModel>> GetCaptivePurposeLogDetails(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                List<LesseeInfoModel> objeclist = new List<LesseeInfoModel>();
                objeclist = JsonConvert.DeserializeObject<List<LesseeInfoModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeDetails/GetCaptivePurposeLogDetails", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Captive purpose log history details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeInfoModel>> GetCaptivePurposeLogDetailsView(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                List<LesseeInfoModel> objeclist = new List<LesseeInfoModel>();
                objeclist = JsonConvert.DeserializeObject<List<LesseeInfoModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeDetails/GetCaptivePurposeLogDetailsView", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Captive purpose compare details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<CaptivePurposeModel>> GetCaptivePurposeLogDetailsCompareDetails(CaptivePurposeModel objLesseeInfoModel)
        {
            try
            {
                List<CaptivePurposeModel> objeclist = new List<CaptivePurposeModel>();
                objeclist = JsonConvert.DeserializeObject<List<CaptivePurposeModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeDetails/GetCaptivePurposeLogDetailsCompareDetails", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
