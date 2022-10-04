// ***********************************************************************
//  Controller Name          : InspectionReport
//  Desciption               : Add view of inspection report submitted by Mining Inspector for API
//  Created By               : Debaraj Swain
//  Created On               : 25 May 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportApi.Model.Inspection;
using SupportEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace SupportApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class InspectionReportController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
  
        public IInspectionProvider _objIInspectionModel;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objInspectionProvider"></param>
        public InspectionReportController(IInspectionProvider objInspectionProvider, IHostingEnvironment hostingEnvironment)
        {
            _objIInspectionModel = objInspectionProvider;
            this.hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// To Get User Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>InspectionModel class , values will fill in to the respective Properties </returns>
        [HttpPost]
        public Result< InspectionModel> GetUserData(InspectionModel objEU)
        {
            return   _objIInspectionModel.GetViewDetails(objEU);
        }
        /// <summary>
        /// To Get User list
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>FillDDlInspection class </returns>
        [HttpPost]
        public Result<FillDDlInspection> fillUtype(InspectionModel objEU)
        {
            return _objIInspectionModel.ListOfUType(objEU);
        }
        /// <summary>
        /// To Get Notice list
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns> List of NoticeModel class </returns>
        [HttpPost]
        public Result<List<NoticeModel>> GetLst(NoticeModel model)
        {
            return _objIInspectionModel.Getissuranceofnotice(model);
        }
        /// <summary>
        /// To Get users
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns> FillDDlInspection class </returns>
        [HttpPost]
        public Result<FillDDlInspection> fillLuser(InspectionModel objEU)
        {
            return _objIInspectionModel.ListOfUser(objEU);
        }
        /// <summary>
        /// To Get user details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns> InspectionModel class </returns>
        [HttpPost]
        public Result<InspectionModel> UserData(InspectionModel objEU)
        {
            return _objIInspectionModel.ViewUserDetails(objEU);
        }
        /// <summary>
        /// To Add inspection
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns> MessageEF class </returns>
        [HttpPost]
        public MessageEF AddData(InspectionModel objEU)
        {
            return _objIInspectionModel.AddInspectionData(objEU);
        }
        /// <summary>
        /// To View Grievance data  
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns> List of InspectionModel Class </returns>
        [HttpPost]
        public Result<List<InspectionModel>> ViewData(InspectionModel objEU)
        {
            return _objIInspectionModel.ViewInspectionData(objEU);
        }

        /// <summary>
        /// To View inspection details  
        /// </summary>

        /// <returns> List of InspectionModel Class </returns>
        [HttpPost]
        public Result<List<InspectionModel>> ViewInspectionDetails(InspectionModel objEU)
        {
            return _objIInspectionModel.ViewInspectionDetails(objEU);
        }
    }
}
