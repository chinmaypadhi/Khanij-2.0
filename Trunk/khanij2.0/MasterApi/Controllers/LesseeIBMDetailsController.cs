// ***********************************************************************
//  Controller Name          : LesseeIBMDetailsController
//  Description              : Lessee IBM Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 26 July 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LesseeIBM;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeIBMDetailsController : ControllerBase
    {
        public ILesseeIBMProvider _objILesseeIBMProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILesseeOfficeMasterProvider"></param>
        public LesseeIBMDetailsController(ILesseeIBMProvider objILesseeIBMProvider)
        {
            _objILesseeIBMProvider = objILesseeIBMProvider;
        }
        /// To bind IBM details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LesseeIBMDetailsViewModel>> GetIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            return await _objILesseeIBMProvider.GetIBMDetails(objLesseeIBMDetailsModel);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse IBM details
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            return _objILesseeIBMProvider.UpdateIBMDetails(objLesseeIBMDetailsModel);
        }
        /// <summary>
        /// To bind IBM Log History details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeIBMDetailsViewModel>>> GetIBMLogDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            return await _objILesseeIBMProvider.GetIBMLogDetails(objLesseeIBMDetailsModel);
        }
        /// <summary>
        /// o bind IBM Compare details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeIBMDetailsViewModel>>> GetIBMCompareDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            return await _objILesseeIBMProvider.GetIBMCompareDetails(objLesseeIBMDetailsModel);
        }
        /// <summary>
        /// To Approve Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            return _objILesseeIBMProvider.ApproveLesseeIBMDetails(objLesseeIBMDetailsModel);
        }
        /// <summary>
        /// To Reject Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            return _objILesseeIBMProvider.RejectLesseeIBMDetails(objLesseeIBMDetailsModel);
        }
        /// <summary>
        /// To Delete Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel)
        {
            return _objILesseeIBMProvider.DeleteLesseeIBMDetails(objLesseeIBMDetailsModel);
        }
    }
}
