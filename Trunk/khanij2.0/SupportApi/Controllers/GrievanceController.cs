// ***********************************************************************
//  Controller Name          : Grievance
//  Desciption               : Adding grievance,Showing List of Grievence and DD Approval of grievance
//  Created By               : Debaraj Swain
//  Created On               : 25 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportApi.Model.Grievance;
using SupportEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SupportApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class GrievanceController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public IGrievanceProvider _objIGrievanceModel;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objInspectionProvider"></param>
        public GrievanceController(IGrievanceProvider objGrievanceProvider)
        {
            _objIGrievanceModel = objGrievanceProvider;
        }
        /// <summary>
        /// To fill District Name
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns> List of District </returns>
        [HttpPost]
        public Result<FillDDl> fillDist(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.ListOfDistrict(objEU);
        }
        /// <summary>
        /// To fill Complaint Type
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns> List of Complaint Type </returns>
        [HttpPost]
        public Result<FillDDl> fillCtype(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.ListOfCType(objEU);
        }
        /// <summary>
        /// To Get OTP
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>PublicGrievanceModel class and OTP will fill in the respective properties </returns>
        [HttpPost]
        public Result<PublicGrievanceModel> GetOTP(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.GetOTPProvider(objEU);
        }
        /// <summary>
        /// To Verify OTP
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class and OTP will fill in the respective properties </returns>
        [HttpPost]
        public Result<MessageEF> OTPVerify (PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.VerifyOTP(objEU);
        }
        /// <summary>
        /// To Add Pblic Grievance
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class and Output message will fill in the respective properties </returns>
        [HttpPost]
        public MessageEF AddPGrievance(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.AddPublicGrievance(objEU);
        }
        /// <summary>
        /// To fill all states
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of state </returns>
        [HttpPost]
        public Result<FillDDl> fillState(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.ListOfState(objEU);
        }
        /// <summary>
        /// To get user information
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>PublicGrievanceModel class and Output message will fill in the respective properties </returns>
        [HttpPost]
        public Result<PublicGrievanceModel> GetUserData(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.GetUserData(objEU);
        }
        /// <summary>
        /// To Add Grievance
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class and Output message will fill in the respective properties </returns>
        [HttpPost]
        public MessageEF AddGrievance(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.AddGrievance(objEU);
        }
        /// <summary>
        /// To List of Grievance for DD Approval
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of PublicGrievanceModel class and Output message will fill in the respective properties </returns>
        [HttpPost]
        public Result<List<PublicGrievanceModel>> GetList(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.GetCListDD(objEU);
        }
        /// <summary>
        /// To View perticular Grievance Data
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>PublicGrievanceModel class and Output message will fill in the respective properties </returns>
        [HttpPost]
        public Result<PublicGrievanceModel> GetData(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.GetViewDetails(objEU);
        }
        /// <summary>
        /// To VGet List Of User Type
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of user Type</returns>
        [HttpPost]
        public Result<FillDDl> UTDDLLoad(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.ListOfUserType(objEU);
        }
        /// <summary>
        /// To VGet List Of User Type
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of user Type</returns>
        [HttpPost]
        public Result<FillDDl> GetName(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.ListOfUserByType(objEU);
        }
        /// <summary>
        /// To VGet List Of Category Complaint
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of Category Complaint</returns>
        [HttpPost]
        public Result<FillDDl> CComplaint(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.ListOfCatComp(objEU);
        }
        /// <summary>
        /// To Forward the Grievance to DD
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF Class and Output message will fill in the respective properties</returns>
        [HttpPost]
        public MessageEF FDD(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.Forwordtodd(objEU);
        }
        /// <summary>
        /// To View List of Grievance Complaint List
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of PublicGrievanceModel Class and Output message will fill in the respective properties</returns>
        [HttpPost]
        public Result<List<PublicGrievanceModel>> GetGCList(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.GetGCList(objEU);
        }
        /// <summary>
        /// To Add DGM Grievance
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns> MessageEF Class and Output message will fill in the respective properties</returns>
        [HttpPost]
        public MessageEF AddDGMGrievance(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.AddDGMGrievance(objEU);
        }
        /// <summary>
        /// To Get Mining Inspector List
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of PublicGrievanceModel Class and Output message will fill in the respective properties</returns>
        [HttpPost]
        public Result<List<PublicGrievanceModel>> GetMIList(PublicGrievanceModel objEU)
        {
            return _objIGrievanceModel.GetCListMI(objEU);
        }
        /// <summary>
        /// To forward Mining inspector to DD
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns> MessageEF Class and Output message will fill in the respective properties</returns>
        [HttpPost]
        public MessageEF MIFDD(ForwardMItoDD objEU)
        {
            return _objIGrievanceModel.MIForwordtodd(objEU);
        }
        /// <summary>
        /// To Close the complaint
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns> PublicGrievanceModel Class and Output message will fill in the respective properties</returns>
        [HttpPost]
        public Result<PublicGrievanceModel> CloseGrievance(CloseComplain objEU)
        {
            return _objIGrievanceModel.CloseComplain(objEU);
        }




        #region Verify Mobile No
        /// <summary>
        /// To Verify Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        [HttpPost]
        public async Task<MessageEF> VerifyMobile1(PublicGrievanceModel GrievanceModel)
        {
            return await _objIGrievanceModel.CheckMobileNo1(GrievanceModel);
        }
        #endregion







        #region Get OTP
        /// <summary>
        /// Get OTP to Validate Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        [HttpPost]
        public async Task<MessageEF> OTPDetails1(PublicGrievanceModel GrievanceModel)
        {
            return await _objIGrievanceModel.GetOTP1(GrievanceModel);
        }
        #endregion




        #region Verify OTP
        /// <summary>
        /// To Verify OTP
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        [HttpPost]
        public async Task<MessageEF> OTPVerification1(PublicGrievanceModel GrievanceModel)
        {
            return await _objIGrievanceModel.VerifyOTP1(GrievanceModel);
        }
        #endregion


    }
}
