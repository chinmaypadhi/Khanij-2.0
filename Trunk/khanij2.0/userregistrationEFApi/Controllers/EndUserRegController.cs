using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEFApi.Model.EndUser;
using userregistrationEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace userregistrationEFApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]  
    [Authorize]
    public class EndUserRegController : ControllerBase
    {
        public IEndUserRegProvider _objIEndUserRegModel;
        public EndUserRegController(IEndUserRegProvider objEndUserProvider)
        {
            _objIEndUserRegModel = objEndUserProvider;
        }

        /// <summary>
        /// Get OTP
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<EndUserModel> GetOTP(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.GetOTPProvider(objEU);
        }

        /// <summary>
        /// Get IType
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<GetIndustryType> ViewIType(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.ListOfIType(objEU);
        }

        /// <summary>
        /// Get LState
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public  async Task<GetListState> ViewLState(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.LstState(objEU);
        }

        /// <summary>
        /// Get District
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public  async Task<GetListState> ViewLDistrict(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.ListOfDistrictByStateID(objEU);
        }

        /// <summary>
        /// Get LState_O
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        public async Task<GetListState> ViewLState_O(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.LstState_O(objEU);
        }

        /// <summary>
        /// Get District_O
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        public async Task<GetListState> ViewLDistrict_O(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.ListOfDistrictByStateID_O(objEU);
        }

        /// <summary>
        /// Get LSQ
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<GetListState> ViewLSQ(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.LstSQ(objEU);
        }

        /// <summary>
        /// Get Mineral
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<GetListState> GetMineral(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.ListOfMineral(objEU);
        }

        /// <summary>
        /// Get Mineral Form
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public  async Task<GetListState> GetMineralForm(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.ListOfMineralForm(objEU);
        }

        /// <summary>
        /// Get Mineral Grade
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<GetListState> GetMineralGrade(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.ListOfMineralGrade(objEU);
        }

        /// <summary>
        /// OTP Verify
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> OTPVerify(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.VerifyOTP(objEU);
        }

        /// <summary>
        /// Add End User
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddEndUser(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.AddEndUserData(objEU);
        }

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<EndUserModel> GetUserDet(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.GetUserDetailsProvider(objEU);
        }

        /// <summary>
        /// Get All Report
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<EndUserModel>> ViewAllReport(EndUserModel ObjEU)
        {
            return await _objIEndUserRegModel.ViewAllRequest(ObjEU);
        }

        /// <summary>
        /// Get New Request User Wise
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<EndUserBasicInfoModel> GetNewRequsetUserWise(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.GetNewRequestDetailsProvider(objEU);
        }

        /// <summary>
        /// Approve End User
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ApproveEndUser(EndUserBasicInfoModel objEU)
        {
            return await _objIEndUserRegModel.ApproveEndUser(objEU);
        }

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<EndUserBasicInfoModel> GetUDetails(EndUserBasicInfoModel objEU)
        {
            return await _objIEndUserRegModel.GetUserDetails(objEU);
        }

        /// <summary>
        /// Reject End User
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> RejectEndUser(EndUserBasicInfoModel objEU)
        {
            return await _objIEndUserRegModel.RejectEndUser(objEU);
        }

        /// <summary>
        /// Get Updation Report
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<EndUserModel>> ViewUpdationReport(EndUserModel ObjEU)
        {
            return await _objIEndUserRegModel.ViewUpdationRequest(ObjEU);
        }

        /// <summary>
        /// Action Taken Report
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns></returns>
        [HttpPost]
        public  async Task<List<ForceFullDataEndUser>> ActionTakenReport(EndUserModel ObjEU)
        {
            return await _objIEndUserRegModel.ActionTakenRequest(ObjEU);
        }

        /// <summary>
        /// Get Action Taken User Wise
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public  async Task<EndUserBasicInfoModel> GetActionTakenUserWise(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.GetActionTakenDetailsProvider(objEU);
        }

        /// <summary>
        /// Get User Status
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> GetEuserStatus(EndUserBasicInfoModel objEU)
        {
            return await _objIEndUserRegModel.ViewEuserStatus(objEU);
        }

        /// <summary>
        /// Get End User Status Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<EndUserModel> GetEuserStatusDEt(EndUserModel objEU)
        {
            return await _objIEndUserRegModel.GetEndUserDetails(objEU);
        }

        /// <summary>
        /// Get End User Profile Status
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> GetEuserProfileStatus(EndUserModel1 objEU)
        {
            return await _objIEndUserRegModel.ViewEuserProfStatus(objEU);
        }
    }
}
