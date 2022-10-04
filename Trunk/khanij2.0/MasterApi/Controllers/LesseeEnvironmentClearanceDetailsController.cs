// ***********************************************************************
//  Controller Name          : LesseeEnvironmentClearanceDetailsController
//  Description              : Lessee Environment Clearance Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 July 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LesseeEnvironmentClearance;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeEnvironmentClearanceDetailsController : ControllerBase
    {
        public ILesseeEnvironmentClearanceProvider _objILesseeEnvironmentClearanceProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILesseeOfficeMasterProvider"></param>
        public LesseeEnvironmentClearanceDetailsController(ILesseeEnvironmentClearanceProvider objILesseeEnvironmentClearanceProvider)
        {
            _objILesseeEnvironmentClearanceProvider = objILesseeEnvironmentClearanceProvider;
        }
        /// <summary>
        /// To bind FY details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeEnvironmentClearanceViewModel>>> GetFYDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            return await _objILesseeEnvironmentClearanceProvider.GetFYDetails(objLesseeEnvironmentClearanceModel);
        }
        /// <summary>
        /// To bind Environment Clearance details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            return await _objILesseeEnvironmentClearanceProvider.GetEnvironmentClearanceDetails(objLesseeEnvironmentClearanceModel);
        }
        /// <summary>
        /// To bind Environment Clearance Approved Quantity details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MiningProductionModel>>> GetApprovedQuantityDetails(MiningProductionModel objLesseeEnvironmentClearanceModel)
        {
            return await _objILesseeEnvironmentClearanceProvider.GetApprovedQuantityDetails(objLesseeEnvironmentClearanceModel);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Environment Clearance details
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            return _objILesseeEnvironmentClearanceProvider.UpdateEnvironmentClearanceDetails(objLesseeEnvironmentClearanceModel);
        }
        /// <summary>
        /// To bind Environment Clearance Log History details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeEnvironmentClearanceViewModel>>> GetEnvironmentClearanceLogDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            return await _objILesseeEnvironmentClearanceProvider.GetEnvironmentClearanceLogDetails(objLesseeEnvironmentClearanceModel);
        }
        /// <summary>
        /// To get Environment Clearance Approved Quantity details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeEnvironmentClearanceViewModel>>> GetEnvironmentClearanceApprovedQuantityLogDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            return await _objILesseeEnvironmentClearanceProvider.GetEnvironmentClearanceApprovedQuantityLogDetails(objLesseeEnvironmentClearanceModel);
        }
        /// <summary>
        /// To bind Environment Clearance Approved Quantity Log History details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeEnvironmentClearanceViewModel>>> GetEnvironmentClearanceApprovedQuantityLogDetailsView(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            return await _objILesseeEnvironmentClearanceProvider.GetEnvironmentClearanceApprovedQuantityLogDetailsView(objLesseeEnvironmentClearanceModel);
        }
        /// <summary>
        /// To bind Environment Clearance Compare details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeEnvironmentClearanceViewModel>>> GetEnvironmentClearanceCompareDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            return await _objILesseeEnvironmentClearanceProvider.GetEnvironmentClearanceCompareDetails(objLesseeEnvironmentClearanceModel);
        }
        /// <summary>
        /// To bind Environment Clearance Approved Quantity Compare details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MiningProductionModel>>> GetEnvironmentClearanceApprovedQuantityCompareDetails(MiningProductionModel objLesseeEnvironmentClearanceModel)
        {
            return await _objILesseeEnvironmentClearanceProvider.GetEnvironmentClearanceApprovedQuantityCompareDetails(objLesseeEnvironmentClearanceModel);
        }
        /// <summary>
        /// To Approve Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            return _objILesseeEnvironmentClearanceProvider.ApproveLesseeEnvironmentClearanceDetails(objLesseeEnvironmentClearanceModel);
        }
        /// <summary>
        /// To Reject Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            return _objILesseeEnvironmentClearanceProvider.RejectLesseeEnvironmentClearanceDetails(objLesseeEnvironmentClearanceModel);
        }
        /// <summary>
        /// To Delete Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel)
        {
            return _objILesseeEnvironmentClearanceProvider.DeleteLesseeEnvironmentClearanceDetails(objLesseeEnvironmentClearanceModel);
        }
    }
}
