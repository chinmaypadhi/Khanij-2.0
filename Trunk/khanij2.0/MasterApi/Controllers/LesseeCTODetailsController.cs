// ***********************************************************************
//  Controller Name          : LesseeCTODetailsController
//  Description              : Lessee Consent To Operate Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 29 July 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LesseeCTO;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeCTODetailsController : ControllerBase
    {
        public ILesseeCTOProvider _objILesseeCTOProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILesseeOfficeMasterProvider"></param>
        public LesseeCTODetailsController(ILesseeCTOProvider objILesseeCTOProvider)
        {
            _objILesseeCTOProvider = objILesseeCTOProvider;
        }
        /// <summary>
        /// To bind Consent To Opserate Financial year details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeCTOViewModel>>> GetFYDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            return await _objILesseeCTOProvider.GetFYDetails(objLesseeCTOModel);
        }
        /// To bind Consent To Operate details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LesseeCTOViewModel>> GetCTODetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            return await _objILesseeCTOProvider.GetCTODetails(objLesseeCTOModel);
        }
        /// <summary>
        /// To bind Consent To Operate Approved Quantity details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MiningProductionModel>>> GetApprovedQuantityDetails(MiningProductionModel objLesseeCTOModel)
        {
            return await _objILesseeCTOProvider.GetApprovedQuantityDetails(objLesseeCTOModel);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Consent To Operate details
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LesseeCTOViewModel objLesseeCTOModel)
        {
            return _objILesseeCTOProvider.UpdateCTODetails(objLesseeCTOModel);
        }
        /// <summary>
        /// To bind Consent To Operate Log History details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeCTOViewModel>>> GetCTOLogDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            return await _objILesseeCTOProvider.GetCTOLogDetails(objLesseeCTOModel);
        }
        /// <summary>
        /// To get Consent To Operate Log History details
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeCTOViewModel>>> GetCTOApprovedQuantityLogDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            return await _objILesseeCTOProvider.GetCTOApprovedQuantityLogDetails(objLesseeCTOModel);
        }
        /// <summary>
        /// To bind Consent To Operate Log History details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeCTOViewModel>>> GetCTOApprovedQuantityLogDetailsView(LesseeCTOViewModel objLesseeCTOModel)
        {
            return await _objILesseeCTOProvider.GetCTOApprovedQuantityLogDetailsView(objLesseeCTOModel);
        }
        /// <summary>
        /// o bind Consent To Operate Compare details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeCTOViewModel>>> GetCTOCompareDetails(LesseeCTOViewModel objLesseeCTOModel)
        {
            return await _objILesseeCTOProvider.GetCTOCompareDetails(objLesseeCTOModel);
        }
        /// <summary>
        /// To bind Consent To Operate Approved Quantity Compare details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MiningProductionModel>>> GetCTOApprovedQuantityCompareDetails(MiningProductionModel objLesseeCTOModel)
        {
            return await _objILesseeCTOProvider.GetCTOApprovedQuantityCompareDetails(objLesseeCTOModel);
        }
        /// <summary>
        /// To Approve Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(LesseeCTOViewModel objLesseeCTOModel)
        {
            return _objILesseeCTOProvider.ApproveLesseeCTODetails(objLesseeCTOModel);
        }
        /// <summary>
        /// To Reject Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(LesseeCTOViewModel objLesseeCTOModel)
        {
            return _objILesseeCTOProvider.RejectLesseeCTODetails(objLesseeCTOModel);
        }
        /// <summary>
        /// To Delete Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LesseeCTOViewModel objLesseeCTOModel)
        {
            return _objILesseeCTOProvider.DeleteLesseeCTODetails(objLesseeCTOModel);
        }
    }
}
