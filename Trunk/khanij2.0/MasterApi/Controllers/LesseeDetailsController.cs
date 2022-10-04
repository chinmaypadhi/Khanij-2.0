// ***********************************************************************
//  Controller Name          : LesseeDetailsController
//  Desciption               : Lessee Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 July 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LesseeDetails;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeDetailsController : Controller
    {
        public ILesseeDetailsProvider _objILesseeDetailsProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objLesseeDetailsProvider"></param>
        public LesseeDetailsController(ILesseeDetailsProvider objLesseeDetailsProvider)
        {
            _objILesseeDetailsProvider = objLesseeDetailsProvider;
        }
        /// <summary>
        /// To bind Lessee Profile Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public LesseeInfoModel GetLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel)
        {
            return _objILesseeDetailsProvider.GetLesseeProfileDetails(objLesseeInfoModel);
        }
        /// <summary>
        /// To bind LesseeType dropdown in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<LesseeInfoModel> GetLesseeTypeList(LesseeInfoModel objLesseeInfoModel)
        {
            return _objILesseeDetailsProvider.GetLesseeTypeList(objLesseeInfoModel);
        }
        /// <summary>
        /// To bind Auction Type dropdown in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<LesseeInfoModel> GetAuctionTypeList(LesseeInfoModel objLesseeInfoModel)
        {
            return _objILesseeDetailsProvider.GetAuctionTypeList(objLesseeInfoModel);
        }
        /// <summary>
        /// To Update Lesse Profile details
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LesseeInfoModel objLesseeInfoModel)
        {
            return _objILesseeDetailsProvider.UpdateLesseeProfileDetails(objLesseeInfoModel);
        }
        /// <summary>
        /// To bind Lessee Profile Log Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<LesseeInfoModel> GetLesseeProfileLogList(LesseeInfoModel objLesseeInfoModel)
        {
            return _objILesseeDetailsProvider.GetLesseeProfileLogList(objLesseeInfoModel);
        }
        /// <summary>
        /// To bind Lessee Profile Request Data in view
        /// </summary>
        /// <param name="objLesseeProfileRequestInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<LesseeProfileRequestModel> GetLesseeProfileRequestData(LesseeProfileRequestModel objLesseeProfileRequestInfoModel)
        {
            return _objILesseeDetailsProvider.GetLesseeProfileRequestData(objLesseeProfileRequestInfoModel);
        }
        /// <summary>
        /// To bind Last approved Lessee Profile Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<LesseeInfoModel> GetLesseeProfileCompareDetails(LesseeInfoModel objLesseeInfoModel)
        {
            return _objILesseeDetailsProvider.GetLesseeProfileCompareDetails(objLesseeInfoModel);
        }
        /// <summary>
        /// To Approve Lesse Profile details by DD
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(LesseeInfoModel objLesseeInfoModel)
        {
            return _objILesseeDetailsProvider.ApproveLesseeProfileDetails(objLesseeInfoModel);
        }
        /// <summary>
        /// To Reject Lesse Profile details by DD
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(LesseeInfoModel objLesseeInfoModel)
        {
            return _objILesseeDetailsProvider.RejectLesseeProfileDetails(objLesseeInfoModel);
        }
        /// <summary>
        /// To Delete Lesse Profile details
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LesseeInfoModel objLesseeInfoModel)
        {
            return _objILesseeDetailsProvider.DeleteLesseeProfileDetails(objLesseeInfoModel);
        }
        /// <summary>
        /// To Bind the User Type Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LesseeInfoModel>> GetUserTypeList(LesseeInfoModel objLesseeInfoModel)
        {
            return await _objILesseeDetailsProvider.GetUserTypeList(objLesseeInfoModel);
        }
        /// <summary>
        /// To Bind the User Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LesseeInfoModel>> GetUserList(LesseeInfoModel objLesseeInfoModel)
        {
            return await _objILesseeDetailsProvider.GetUserList(objLesseeInfoModel);
        }
        /// <summary>
        /// To Bind the Captive Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LesseeInfoModel>> GetCaptiveList(LesseeInfoModel objLesseeInfoModel)
        {
            return await _objILesseeDetailsProvider.GetCaptiveList(objLesseeInfoModel);
        }

        /// <summary>
        /// To bind Captive purpose details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<CaptivePurposeModel>>> GetPurposeDetails(CaptivePurposeModel objLesseeInfoModel)
        {
            return await _objILesseeDetailsProvider.GetPurposeDetails(objLesseeInfoModel);
        }
        /// <summary>
        /// To bind Lessee Captive purpose log details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeInfoModel>>> GetCaptivePurposeLogDetails(LesseeInfoModel objLesseeInfoModel)
        {
            return await _objILesseeDetailsProvider.GetCaptivePurposeLogDetails(objLesseeInfoModel);
        }
        /// <summary>
        /// To bind Captive purpose log history details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeInfoModel>>> GetCaptivePurposeLogDetailsView(LesseeInfoModel objLesseeInfoModel)
        {
            return await _objILesseeDetailsProvider.GetCaptivePurposeLogDetailsView(objLesseeInfoModel);
        }
        /// <summary>
        /// To bind Captive purpose compare details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<CaptivePurposeModel>>> GetCaptivePurposeLogDetailsCompareDetails(CaptivePurposeModel objLesseeInfoModel)
        {
            return await _objILesseeDetailsProvider.GetCaptivePurposeLogDetailsCompareDetails(objLesseeInfoModel);
        }
    }
}
