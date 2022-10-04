// ***********************************************************************
//  Controller Name          : AssessmentController
//  Desciption               : Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2021
// ***********************************************************************
using System.Collections.Generic;
using StarRatingApi.Model.Assessment;
using StarratingEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace StarRatingApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class AssessmentController : ControllerBase
    {
        public IAssessmentProvider _objIAssessmentProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objAssessmentProvider"></param>
        public AssessmentController(IAssessmentProvider objAssessmentProvider)
        {
            _objIAssessmentProvider = objAssessmentProvider;
        }
        /// <summary>
        /// POST method of View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<AssessmentListmaster> View(AssessmentListmaster objAssessmentListmaster)
        {
            return _objIAssessmentProvider.ViewAssessmentListmaster(objAssessmentListmaster);
        }
        /// <summary>
        /// POST method to bind State List
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<AssessmentListmaster> GetStateList(AssessmentListmaster objAssessmentListmaster)
        {
            return _objIAssessmentProvider.GetStateList(objAssessmentListmaster);
        }
        /// <summary>
        /// POST method to bind District List
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<AssessmentListmaster> GetDistrictList(AssessmentListmaster objAssessmentListmaster)
        {
            return _objIAssessmentProvider.GetDistrictList(objAssessmentListmaster);
        }
        /// <summary>
        /// POST method to bind Tehsil List
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<AssessmentListmaster> GetTehsilList(AssessmentListmaster objAssessmentListmaster)
        {
            return _objIAssessmentProvider.GetTehsilList(objAssessmentListmaster);
        }
        /// <summary>
        /// POST method to bind Village List
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<AssessmentListmaster> GetVillageList(AssessmentListmaster objAssessmentListmaster)
        {
            return _objIAssessmentProvider.GetVillageList(objAssessmentListmaster);
        }
    }
}
