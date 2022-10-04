// ***********************************************************************
//  Controller Name          : LesseeForestClearanceDetailsController
//  Description              : Lessee Forest Clearance Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 July 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LesseeForestClearance;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeForestClearanceDetailsController : ControllerBase
    {
        public ILesseeForestClearanceProvider _objILesseeForestClearanceProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILesseeOfficeMasterProvider"></param>
        public LesseeForestClearanceDetailsController(ILesseeForestClearanceProvider objILesseeForestClearanceProvider)
        {
            _objILesseeForestClearanceProvider = objILesseeForestClearanceProvider;
        }
        /// <summary>
        /// To bind Forest Clearance details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LesseeForestClearanceViewModel>> GetForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            return await _objILesseeForestClearanceProvider.GetForestClearanceDetails(objLesseeForestClearanceModel);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Forest Clearance details
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            return _objILesseeForestClearanceProvider.UpdateForestClearanceDetails(objLesseeForestClearanceModel);
        }
        /// <summary>
        /// To bind Forest Clearance Log History details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeForestClearanceViewModel>>> GetForestClearanceLogDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            return await _objILesseeForestClearanceProvider.GetForestClearanceLogDetails(objLesseeForestClearanceModel);
        }
        /// <summary>
        /// To bind Forest Clearance Compare details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeForestClearanceViewModel>>> GetForestClearanceCompareDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            return await _objILesseeForestClearanceProvider.GetForestClearanceCompareDetails(objLesseeForestClearanceModel);
        }
        /// <summary>
        /// To Approve Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            return _objILesseeForestClearanceProvider.ApproveLesseeForestClearanceDetails(objLesseeForestClearanceModel);
        }
        /// <summary>
        /// To Reject Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            return _objILesseeForestClearanceProvider.RejectLesseeForestClearanceDetails(objLesseeForestClearanceModel);
        }
        /// <summary>
        /// To Delete Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LesseeForestClearanceViewModel objLesseeForestClearanceModel)
        {
            return _objILesseeForestClearanceProvider.DeleteLesseeForestClearanceDetails(objLesseeForestClearanceModel);
        }
    }
}
