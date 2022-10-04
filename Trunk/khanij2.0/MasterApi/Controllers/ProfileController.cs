// ***********************************************************************
//  Controller Name          : MenuController
//  Desciption               : To Add,Edit,Update,Delete Menu master details
//  Created By               : Lingaraj Dalai
//  Created On               : 10 Feb 2022
// ***********************************************************************
using MasterApi.Model.Profile;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public IProfileProvider _objIProfileProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIProfileProvider"></param>
        public ProfileController(IProfileProvider objIProfileProvider)
        {
            _objIProfileProvider = objIProfileProvider;
        }
        /// <summary>
        /// Bind Profile Completion Count Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LesseeInfoModel> GetProfileCompletionCount(LesseeInfoModel objLesseeInfoModel)
        {
            return await _objIProfileProvider.GetProfileCompletionCount(objLesseeInfoModel);
        }
        /// <summary>
        /// Bind Profile Completion Request Count Details in view
        /// </summary>
        /// <param name="objLesseeProfileIndividualCountModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LesseeProfileIndividualCountModel> GetLesseeProfileIndividualCountModel(LesseeProfileIndividualCountModel objLesseeProfileIndividualCountModel)
        {
            return await _objIProfileProvider.GetLesseeProfileIndividualCountModel(objLesseeProfileIndividualCountModel);
        }
        /// <summary>
        /// Bind Lessee Licensee Users by District in view
        /// </summary>
        /// <param name="objLesseeProfileIndividualCountModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LesseeProfileIndividualCountModel>> GetLesseeLicneseeUserByDistrict(LesseeProfileIndividualCountModel objLesseeProfileIndividualCountModel)
        {
            return await _objIProfileProvider.GetLesseeLicneseeUserByDistrict(objLesseeProfileIndividualCountModel);
        }
        /// <summary>
        /// Bind Lessee Users by User,Role type in view
        /// </summary>
        /// <param name="objLesseeListForDGMModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LesseeListForDGMModel>> GetLesseeListDGM(LesseeListForDGMModel objLesseeListForDGMModel)
        {
            return await _objIProfileProvider.GetLesseeListDGM(objLesseeListForDGMModel);
        }
    }
}
