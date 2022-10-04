// ***********************************************************************
//  Controller Name          : LesseeOfficeDetailsController
//  Description              : Lessee Office Master View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 13 July 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LesseeOfficeMaster;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeOfficeDetailsController : ControllerBase
    {
        public ILesseeOfficeMasterProvider _objILesseeOfficeMasterProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILesseeOfficeMasterProvider"></param>
        public LesseeOfficeDetailsController(ILesseeOfficeMasterProvider objILesseeOfficeMasterProvider)
        {
            _objILesseeOfficeMasterProvider = objILesseeOfficeMasterProvider;
        }
        /// <summary>
        /// To bind Company/Association details in view
        /// </summary>
        /// <param name="objOfficeMasterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<OfficeMasterViewModel>>> GetAssociationListDetails(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return await _objILesseeOfficeMasterProvider.GetAssociationListDetails(objOfficeMasterViewModel);
        }
        /// <summary>
        /// To bind Office Master details in view
        /// </summary>
        /// <param name="objOfficeMasterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public OfficeMasterViewModel GetOfficeMasterDetails(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return _objILesseeOfficeMasterProvider.GetOfficeMasterDetails(objOfficeMasterViewModel);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Office details
        /// </summary>
        /// <param name="objOfficeMasterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return _objILesseeOfficeMasterProvider.UpdateOfficeMasterDetails(objOfficeMasterViewModel);
        }
        /// <summary>
        /// To bind Last approved Lessee Office Details in view
        /// </summary>
        /// <param name="objOfficeMasterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OfficeMasterViewModel> GetLesseeOfficeMasterCompareDetails(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return _objILesseeOfficeMasterProvider.GetLesseeOfficeMasterCompareDetails(objOfficeMasterViewModel);
        }
        /// <summary>
        /// To Approve Lesse Office details by DD
        /// </summary>
        /// <param name="objOfficeMasterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return _objILesseeOfficeMasterProvider.ApproveLesseeOfficeMasterDetails(objOfficeMasterViewModel);
        }
        /// <summary>
        /// To Reject Lesse Office details by DD
        /// </summary>
        /// <param name="objOfficeMasterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return _objILesseeOfficeMasterProvider.RejectLesseeOfficeMasterDetails(objOfficeMasterViewModel);
        }
        /// <summary>
        /// To bind Lessee Category Log Details in view
        /// </summary>
        /// <param name="objOfficeMasterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OfficeMasterViewModel> GetLesseeCategoryLogDetails(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return _objILesseeOfficeMasterProvider.GetLesseeCategoryLogDetails(objOfficeMasterViewModel);
        }
        /// <summary>
        /// To bind Lessee Corporate Office Log Details in view
        /// </summary>
        /// <param name="objOfficeMasterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OfficeMasterViewModel> GetLesseeCorporateOfficeLogDetails(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return _objILesseeOfficeMasterProvider.GetLesseeCorporateOfficeLogDetails(objOfficeMasterViewModel);
        }
        /// <summary>
        /// To bind Lessee Branch Office Log Details in view
        /// </summary>
        /// <param name="objOfficeMasterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OfficeMasterViewModel> GetLesseeBranchOfficeLogDetails(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return _objILesseeOfficeMasterProvider.GetLesseeBranchOfficeLogDetails(objOfficeMasterViewModel);
        }
        /// <summary>
        /// To bind Lessee Site Office Log Details in view
        /// </summary>
        /// <param name="objOfficeMasterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OfficeMasterViewModel> GetLesseeSiteOfficeLogDetails(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return _objILesseeOfficeMasterProvider.GetLesseeSiteOfficeLogDetails(objOfficeMasterViewModel);
        }
        /// <summary>
        /// To bind Lessee Agent Office Log Details in view
        /// </summary>
        /// <param name="objOfficeMasterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OfficeMasterViewModel> GetLesseeAgentOfficeLogDetails(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return _objILesseeOfficeMasterProvider.GetLesseeAgentOfficeLogDetails(objOfficeMasterViewModel);
        }
        /// <summary>
        /// To Delete Lesse Office Master details
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(OfficeMasterViewModel objOfficeMasterViewModel)
        {
            return _objILesseeOfficeMasterProvider.DeleteLesseeOfficeMasterDetails(objOfficeMasterViewModel);
        }
    }
}
