// ***********************************************************************
//  Controller Name          : LesseeMiningPlanDetailsController
//  Description              : Lessee Mining Plan Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 August 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LesseeMiningPlan;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeMiningPlanDetailsController : ControllerBase
    {
        public ILesseeMiningPlanProvider _objILesseeMiningPlanProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILesseeOfficeMasterProvider"></param>
        public LesseeMiningPlanDetailsController(ILesseeMiningPlanProvider objILesseeMiningPlanProvider)
        {
            _objILesseeMiningPlanProvider = objILesseeMiningPlanProvider;
        }
        /// <summary>
        /// To bind Mining Plan Financial year details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeMiningPlanViewModel>>> GetFYDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            return await _objILesseeMiningPlanProvider.GetFYDetails(objLesseeMiningPlanModel);
        }
        /// <summary>
        /// To bind Mining Plan details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LesseeMiningPlanViewModel>> GetMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            return await _objILesseeMiningPlanProvider.GetMiningPlanDetails(objLesseeMiningPlanModel);
        }
        /// <summary>
        /// To bind Mining Plan Production details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MiningProductionModel>>> GetProductionDetails(MiningProductionModel objLesseeMiningPlanModel)
        {
            return await _objILesseeMiningPlanProvider.GetProductionDetails(objLesseeMiningPlanModel);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Mining Plan details
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            return _objILesseeMiningPlanProvider.UpdateMiningPlanDetails(objLesseeMiningPlanModel);
        }
        /// <summary>
        /// To bind Mining Plan Log History details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeMiningPlanViewModel>>> GetMiningPlanMPLogDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            return await _objILesseeMiningPlanProvider.GetMiningPlanMPLogDetails(objLesseeMiningPlanModel);
        }
        /// <summary>
        /// To bind Mining Scheme Log History details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeMiningPlanViewModel>>> GetMiningPlanMSLogDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            return await _objILesseeMiningPlanProvider.GetMiningPlanMSLogDetails(objLesseeMiningPlanModel);
        }
        /// <summary>
        /// To bind Mining Scheme Log History details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeMiningPlanViewModel>>> GetMiningPlanMSLogDetailsView(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            return await _objILesseeMiningPlanProvider.GetMiningPlanMSLogDetailsView(objLesseeMiningPlanModel);
        }
        /// <summary>
        /// To bind Mining Plan Compare details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeMiningPlanViewModel>>> GetMiningPlanCompareDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            return await _objILesseeMiningPlanProvider.GetMiningPlanCompareDetails(objLesseeMiningPlanModel);
        }
        /// <summary>
        /// To bind Mining Scheme Compare details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MiningProductionModel>>> GetMiningSchemeCompareDetails(MiningProductionModel objLesseeMiningPlanModel)
        {
            return await _objILesseeMiningPlanProvider.GetMiningSchemeCompareDetails(objLesseeMiningPlanModel);
        }
        /// <summary>
        /// To Approve Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            return _objILesseeMiningPlanProvider.ApproveLesseeMiningPlanDetails(objLesseeMiningPlanModel);
        }
        /// <summary>
        /// To Reject Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            return _objILesseeMiningPlanProvider.RejectLesseeMiningPlanDetails(objLesseeMiningPlanModel);
        }
        /// <summary>
        /// To Delete Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LesseeMiningPlanViewModel objLesseeMiningPlanModel)
        {
            return _objILesseeMiningPlanProvider.DeleteLesseeMiningPlanDetails(objLesseeMiningPlanModel);
        }
    }
}
