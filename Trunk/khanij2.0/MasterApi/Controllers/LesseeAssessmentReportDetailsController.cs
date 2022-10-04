// ***********************************************************************
//  Controller Name          : LesseeAssessmentReportDetailsController
//  Description              : Lessee Assessment Report Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 29 July 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LesseeAssessmentReport;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeAssessmentReportDetailsController : ControllerBase
    {
        public ILesseeAssessmentReportProvider _objILesseeAssessmentReportProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILesseeOfficeMasterProvider"></param>
        public LesseeAssessmentReportDetailsController(ILesseeAssessmentReportProvider objILesseeAssessmentReportProvider)
        {
            _objILesseeAssessmentReportProvider = objILesseeAssessmentReportProvider;
        }
        /// <summary>
        /// To bind Assessment Report details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LesseeAssessmentReportViewModel>> GetAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            return await _objILesseeAssessmentReportProvider.GetAssessmentReportDetails(objLesseeAssessmentReportModel);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Assessment Report details
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            return _objILesseeAssessmentReportProvider.UpdateAssessmentReportDetails(objLesseeAssessmentReportModel);
        }
        /// <summary>
        /// To bind Assessment Report Log History details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeAssessmentReportViewModel>>> GetAssessmentReportLogDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            return await _objILesseeAssessmentReportProvider.GetAssessmentReportLogDetails(objLesseeAssessmentReportModel);
        }
        /// <summary>
        /// o bind Assessment Report Compare details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeAssessmentReportViewModel>>> GetAssessmentReportCompareDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            return await _objILesseeAssessmentReportProvider.GetAssessmentReportCompareDetails(objLesseeAssessmentReportModel);
        }
        /// <summary>
        /// To Approve Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            return _objILesseeAssessmentReportProvider.ApproveLesseeAssessmentReportDetails(objLesseeAssessmentReportModel);
        }
        /// <summary>
        /// To Reject Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            return _objILesseeAssessmentReportProvider.RejectLesseeAssessmentReportDetails(objLesseeAssessmentReportModel);
        }
        /// <summary>
        /// To Delete Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel)
        {
            return _objILesseeAssessmentReportProvider.DeleteLesseeAssessmentReportDetails(objLesseeAssessmentReportModel);
        }
    }
}
