// ***********************************************************************
//  Class Name               : LesseeGrantOrderModel
//  Description              : Lessee Grant Order View Model Details
//  Created By               : Lingaraj Dalai
//  Created On               : 16 July 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.LesseeProfile.Models.GrantOrderDetails
{
    public class LesseeGrantOrderModel:ILesseeGrantOrderModel
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
        public LesseeGrantOrderModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To bind Grant Order details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<GrantOrderViewModel> GetGrantOrderDetails(GrantOrderViewModel objGrantorderModel)
        {
            try
            {
                GrantOrderViewModel objgrantorderlist = new GrantOrderViewModel();
                objgrantorderlist = JsonConvert.DeserializeObject<GrantOrderViewModel>(await _objIHttpWebClients.AwaitPostRequest("LesseeGrantOrderDetails/GetGrantOrderDetails", JsonConvert.SerializeObject(objGrantorderModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Grant Order details
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public MessageEF UpdateGrantOrderDetails(GrantOrderViewModel objGrantorderModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeGrantOrderDetails/Update", JsonConvert.SerializeObject(objGrantorderModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To bind Grant Order Log details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<List<GrantOrderViewModel>> GetGrantOrderLogDetails(GrantOrderViewModel objGrantorderModel)
        {
            try
            {
                List<GrantOrderViewModel> objgrantorderlist = new List<GrantOrderViewModel>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<GrantOrderViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeGrantOrderDetails/GetGrantOrderLogDetails", JsonConvert.SerializeObject(objGrantorderModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Grant Order Compare details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<List<GrantOrderViewModel>> GetGrantOrderCompareDetails(GrantOrderViewModel objGrantorderModel)
        {
            try
            {
                List<GrantOrderViewModel> objgrantorderlist = new List<GrantOrderViewModel>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<GrantOrderViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeGrantOrderDetails/GetGrantOrderCompareDetails", JsonConvert.SerializeObject(objGrantorderModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Grant Order details by DD
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeGrantOrderDetails(GrantOrderViewModel objGrantorderModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeGrantOrderDetails/Approve", JsonConvert.SerializeObject(objGrantorderModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse Grant Order details by DD
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeGrantOrderDetails(GrantOrderViewModel objGrantorderModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeGrantOrderDetails/Reject", JsonConvert.SerializeObject(objGrantorderModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Delete Lesse Grant Order details by DD
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeGrantOrderDetails(GrantOrderViewModel objGrantorderModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeGrantOrderDetails/Delete", JsonConvert.SerializeObject(objGrantorderModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Bind the Auction Type Details Data in View
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<List<GrantOrderViewModel>> GetAuctionTypeList(GrantOrderViewModel objGrantorderModel)
        {
            try
            {
                List<GrantOrderViewModel> objlistAuction = new List<GrantOrderViewModel>();
                objlistAuction =JsonConvert.DeserializeObject<List<GrantOrderViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeGrantOrderDetails/GetAuctionTypeList", JsonConvert.SerializeObject(objGrantorderModel)));
                return objlistAuction;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To bind FY details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<List<GrantOrderViewModel>> GetFYDetails(GrantOrderViewModel objGrantorderModel)
        {
            try
            {
                List<GrantOrderViewModel> objfylist = new List<GrantOrderViewModel>();
                objfylist = JsonConvert.DeserializeObject<List<GrantOrderViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeEnvironmentClearanceDetails/GetFYDetails", JsonConvert.SerializeObject(objGrantorderModel)));
                return objfylist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To bind Grant Order Approved Quantity details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetApprovedQuantityDetails(MiningProductionModel objGrantorderModel)
        {
            try
            {
                List<MiningProductionModel> objeclist = new List<MiningProductionModel>();
                objeclist = JsonConvert.DeserializeObject<List<MiningProductionModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeGrantOrderDetails/GetApprovedQuantityDetails", JsonConvert.SerializeObject(objGrantorderModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To get Grant Order Approved Quantity details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<List<GrantOrderViewModel>> GetLesseeGrantOrderApprovedQuantityLogDetails(GrantOrderViewModel objGrantorderModel)
        {
            try
            {
                List<GrantOrderViewModel> objeclist = new List<GrantOrderViewModel>();
                objeclist = JsonConvert.DeserializeObject<List<GrantOrderViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeGrantOrderDetails/GetLesseeGrantOrderApprovedQuantityLogDetails", JsonConvert.SerializeObject(objGrantorderModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Grant Order Approved Quantity Log History details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<List<GrantOrderViewModel>> GetLesseeGrantOrderApprovedQuantityLogDetailsView(GrantOrderViewModel objGrantorderModel)
        {
            try
            {
                List<GrantOrderViewModel> objeclist = new List<GrantOrderViewModel>();
                objeclist = JsonConvert.DeserializeObject<List<GrantOrderViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeGrantOrderDetails/GetLesseeGrantOrderApprovedQuantityLogDetailsView", JsonConvert.SerializeObject(objGrantorderModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Grant Order Approved Quantity Compare details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetLesseeGrantOrderApprovedQuantityCompareDetails(MiningProductionModel objGrantorderModel)
        {
            try
            {
                List<MiningProductionModel> objeclist = new List<MiningProductionModel>();
                objeclist = JsonConvert.DeserializeObject<List<MiningProductionModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeGrantOrderDetails/GetLesseeGrantOrderApprovedQuantityCompareDetails", JsonConvert.SerializeObject(objGrantorderModel)));
                return objeclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
