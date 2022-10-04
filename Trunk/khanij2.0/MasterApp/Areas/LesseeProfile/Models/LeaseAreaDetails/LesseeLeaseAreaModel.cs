// ***********************************************************************
//  Class Name               : LeaseAreaViewModel
//  Description              : Lessee Lease Area Model Details
//  Created By               : Lingaraj Dalai
//  Created On               : 21 July 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.LesseeProfile.Models.LeaseAreaDetails
{
    public class LesseeLeaseAreaModel:ILesseeLeaseAreaModel
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
        public LesseeLeaseAreaModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To Bind the State Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetStateList(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objleasearealist = new List<LeaseAreaViewModel>();
                objleasearealist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeLeaseAreaDetails/GetStateList", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objleasearealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the District Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetDistrictList(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objleasearealist = new List<LeaseAreaViewModel>();
                objleasearealist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeLeaseAreaDetails/GetDistrictList", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objleasearealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Tehsil Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetTehsilList(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objleasearealist = new List<LeaseAreaViewModel>();
                objleasearealist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeLeaseAreaDetails/GetTehsilList", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objleasearealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Village Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetVillageList(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objleasearealist = new List<LeaseAreaViewModel>();
                objleasearealist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeLeaseAreaDetails/GetVillageList", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objleasearealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Lessee Lease Area details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<LeaseAreaViewModel> GetLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                LeaseAreaViewModel objleasearealist = new LeaseAreaViewModel();
                objleasearealist = JsonConvert.DeserializeObject<LeaseAreaViewModel>(await _objIHttpWebClients.AwaitPostRequest("LesseeLeaseAreaDetails/GetLeaseAreaDetails", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objleasearealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Lease Land District Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLeaseLandDistrictList(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objleasearealist = new List<LeaseAreaViewModel>();
                objleasearealist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeLeaseAreaDetails/GetLeaseLandDistrictList", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objleasearealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Lease Land Village Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLeaseLandVillageList(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objleasearealist = new List<LeaseAreaViewModel>();
                objleasearealist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeLeaseAreaDetails/GetLeaseLandVillageList", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objleasearealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Lease Area details
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public MessageEF UpdateLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeLeaseAreaDetails/Update", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To bind Lease Area Log details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLeaseAreaLogDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objgrantorderlist = new List<LeaseAreaViewModel>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeLeaseAreaDetails/GetLeaseAreaLogDetails", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Lease Area Compare details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLeaseAreaCompareDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objgrantorderlist = new List<LeaseAreaViewModel>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeLeaseAreaDetails/GetLeaseAreaCompareDetails", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeLeaseAreaDetails/Approve", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public MessageEF RejectLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeLeaseAreaDetails/Reject", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Delete Lesse Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeLeaseAreaDetails/Delete", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Bind the Land Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLandList(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objleasearealist = new List<LeaseAreaViewModel>();
                objleasearealist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeLeaseAreaDetails/GetLandList", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objleasearealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Lease Land Block Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<LeaseAreaViewModel>> GetLeaseLandBlockList(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objleasearealist = new List<LeaseAreaViewModel>();
                objleasearealist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeLeaseAreaDetails/GetLeaseLandBlockList", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objleasearealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Vidhan Sabha list Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public List<LeaseAreaViewModel> GetVidhanSabhaList(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objleasearealist = new List<LeaseAreaViewModel>();
                objleasearealist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(_objIHttpWebClients.PostRequest("LesseeLeaseAreaDetails/GetVidhanSabhaList", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objleasearealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Lok Sabha list Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public List<LeaseAreaViewModel> GetLokSabhaList(LeaseAreaViewModel objLeaseAreaModel)
        {
            try
            {
                List<LeaseAreaViewModel> objleasearealist = new List<LeaseAreaViewModel>();
                objleasearealist = JsonConvert.DeserializeObject<List<LeaseAreaViewModel>>(_objIHttpWebClients.PostRequest("LesseeLeaseAreaDetails/GetLokSabhaList", JsonConvert.SerializeObject(objLeaseAreaModel)));
                return objleasearealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
