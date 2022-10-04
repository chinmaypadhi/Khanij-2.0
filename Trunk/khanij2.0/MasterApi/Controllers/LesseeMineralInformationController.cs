// ***********************************************************************
//  Controller Name          : LesseeMineralInformationController
//  Description              : Lessee Mineral Information Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 04 August 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LesseeMineralInformation;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeMineralInformationController : ControllerBase
    {
        public ILesseeMineralInformationProvider _objILesseeMineralInformationProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILesseeMineralInformationProvider"></param>
        public LesseeMineralInformationController(ILesseeMineralInformationProvider objILesseeMineralInformationProvider)
        {
            _objILesseeMineralInformationProvider = objILesseeMineralInformationProvider;
        }
        #region Binddropdowns
        /// To bind Mineral Category details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeMineralInformationModel>>> GetMineralCategoryDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            return await _objILesseeMineralInformationProvider.GetMineralCategoryDetails(objLesseeMineralInformationModel);
        }
        /// To bind Mineral Name details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeMineralInformationModel>>> GetMineralNameDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            return await _objILesseeMineralInformationProvider.GetMineralNameDetails(objLesseeMineralInformationModel);
        }
        /// To bind Mineral Form details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeMineralInformationModel>>> GetMineralFormDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            return await _objILesseeMineralInformationProvider.GetMineralFormDetails(objLesseeMineralInformationModel);
        }
        /// To bind Mineral Grade details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeMineralInformationModel>>> GetMineralGradeDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            return await _objILesseeMineralInformationProvider.GetMineralGradeDetails(objLesseeMineralInformationModel);
        }
        #endregion
        /// To bind Lessee Mineral Information details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LesseeMineralInformationModel>> GetMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            return await _objILesseeMineralInformationProvider.GetMineralInformationDetails(objLesseeMineralInformationModel);
        }
        /// <summary>
        /// To bind Mineral Information Log History details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeMineralInformationModel>>> GetMineralInformationLogDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            return await _objILesseeMineralInformationProvider.GetMineralInformationLogDetails(objLesseeMineralInformationModel);
        }
        /// <summary>
        /// To bind Mineral Information Compare details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeMineralInformationModel>>> GetMineralInformationCompareDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            return await _objILesseeMineralInformationProvider.GetMineralInformationCompareDetails(objLesseeMineralInformationModel);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Mineral Information details
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            return _objILesseeMineralInformationProvider.UpdateMineralInformationDetails(objLesseeMineralInformationModel);
        }
        /// <summary>
        /// To Approve Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            return _objILesseeMineralInformationProvider.ApproveLesseeMineralInformationDetails(objLesseeMineralInformationModel);
        }
        /// <summary>
        /// To Reject Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            return _objILesseeMineralInformationProvider.RejectLesseeMineralInformationDetails(objLesseeMineralInformationModel);
        }
        /// <summary>
        /// To Delete Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            return _objILesseeMineralInformationProvider.DeleteLesseeMineralInformationDetails(objLesseeMineralInformationModel);
        }
    }
}
