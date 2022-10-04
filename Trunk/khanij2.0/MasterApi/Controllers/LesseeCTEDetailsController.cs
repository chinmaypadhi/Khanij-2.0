// ***********************************************************************
//  Controller Name          : LesseeCTEDetailsController
//  Description              : Lessee Consent To Establish Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 July 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LesseeCTE;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeCTEDetailsController : ControllerBase
    {
        public ILesseeCTEProvider _objILesseeCTEProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILesseeOfficeMasterProvider"></param>
        public LesseeCTEDetailsController(ILesseeCTEProvider objILesseeCTEProvider)
        {
            _objILesseeCTEProvider = objILesseeCTEProvider;
        }
        /// To bind Consent To Establish details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LesseeCTEViewModel>> GetCTEDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            return await _objILesseeCTEProvider.GetCTEDetails(objLesseeCTEModel);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Consent To Establish details
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LesseeCTEViewModel objLesseeCTEModel)
        {
            return _objILesseeCTEProvider.UpdateCTEDetails(objLesseeCTEModel);
        }
        /// <summary>
        /// To bind Consent To Establish Log History details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeCTEViewModel>>> GetCTELogDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            return await _objILesseeCTEProvider.GetCTELogDetails(objLesseeCTEModel);
        }
        /// <summary>
        /// o bind Consent To Establish Compare details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LesseeCTEViewModel>>> GetCTECompareDetails(LesseeCTEViewModel objLesseeCTEModel)
        {
            return await _objILesseeCTEProvider.GetCTECompareDetails(objLesseeCTEModel);
        }
        /// <summary>
        /// To Approve Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(LesseeCTEViewModel objLesseeCTEModel)
        {
            return _objILesseeCTEProvider.ApproveLesseeCTEDetails(objLesseeCTEModel);
        }
        /// <summary>
        /// To Reject Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(LesseeCTEViewModel objLesseeCTEModel)
        {
            return _objILesseeCTEProvider.RejectLesseeCTEDetails(objLesseeCTEModel);
        }
        /// <summary>
        /// To Delete Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LesseeCTEViewModel objLesseeCTEModel)
        {
            return _objILesseeCTEProvider.DeleteLesseeCTEDetails(objLesseeCTEModel);
        }
    }
}
