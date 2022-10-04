// ***********************************************************************
//  Controller Name          : LabReportsController
//  Desciption               : Add,Edit,Update,View,Delete,View Lab Forward,Approval,Check status, Analysed samples Lab Report Controller
//  Created By               : Lingaraj Dalai
//  Created On               : 24 Feb 2021
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Model.LabReports;
using GeologyEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LabReportsController : ControllerBase
    {
        /// <summary>
        /// Global variable declaration
        /// </summary>
        public ILabReportsProvider _objILabReportsProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objLabReportsProvider"></param>
        public LabReportsController(ILabReportsProvider objLabReportsProvider)
        {
            _objILabReportsProvider = objLabReportsProvider;
        }
        #region Submit New Samples
        /// <summary>
        /// Post method to Add Lab Report
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.AddLabReportsmaster(objLabReportmaster);
        }
        /// <summary>
        /// Post method to View Lab Report
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LabReportmaster>> View(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.ViewLabReportsmaster(objLabReportmaster);
        }
        /// <summary>
        /// Post method to Edit Lab Report
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LabReportmaster> Edit(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.EditLabReportsmaster(objLabReportmaster);
        }
        /// <summary>
        /// Post method to Update Lab Report
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.UpdateLabReportsmaster(objLabReportmaster);
        }
        /// <summary>
        /// Post method to Delete Lab Report
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Delete(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.DeleteLabReportsmaster(objLabReportmaster);
        }
        /// <summary>
        /// Post method to Forward Lab Report
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> SendForForward(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.SendForForward(objLabReportmaster);
        }
        /// <summary>
        /// Post method to Get MPR code list details
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LabReportmaster>> GetMPRCodeList(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.GetMPRCodeList(objLabReportmaster);
        }
        /// <summary>
        /// Post method to Get Mineral list details
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LabReportmaster>> GetMineralList(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.GetMineralList(objLabReportmaster);
        }
        /// <summary>
        /// Post method to Get Division list details
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LabReportmaster>> GetDivisionList(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.GetDivisionList(objLabReportmaster);
        }
        /// <summary>
        /// Post method to Get Regional office list details
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LabReportmaster>> GetRegionalOfficeList(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.GetRegionalOfficeList(objLabReportmaster);
        }
        /// <summary>
        /// Post method to Get Type of study anaysis list details
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LabReportmaster>> GetTypeOfStudyAnalysis(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.GetTypeOfStudyAnalysis(objLabReportmaster);
        }
        /// <summary>
        /// Post method to Get Officer details
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LabReportmaster> GetOfficerNameAndDesignation(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.GetOfficerNameAndDesignation(objLabReportmaster);
        }
        #endregion
        #region Lab Report Forward
        [HttpPost]
        public async Task<List<LabReportmaster>> ViewLabReportForward(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.ViewLabReportForward(objLabReportmaster);
        }
        [HttpPost]
        public async Task<MessageEF> SendForApproval(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.SendForApproval(objLabReportmaster);
        }
        #endregion
        #region StatusofLabReport
        /// <summary>
        /// Post method to View Lab Report status
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LabReportmaster>> ViewStatusOfLabReport(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.ViewStatusOfLabReport(objLabReportmaster);
        }
        /// <summary>
        /// Post method to Upload result
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UploadResult(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.UploadResult(objLabReportmaster);
        }
        #endregion
        #region GetAnalysedSamples
        /// <summary>
        /// Post method to View Analysed samples details
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LabReportmaster>> ViewAnalysedSamples(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.ViewAnalysedSamples(objLabReportmaster);
        }
        /// <summary>
        /// Post method to View Files list details
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LabReportmaster>> ViewFilesList(LabReportmaster objLabReportmaster)
        {
            return await _objILabReportsProvider.ViewFilesList(objLabReportmaster);
        }
        #endregion
    }
}