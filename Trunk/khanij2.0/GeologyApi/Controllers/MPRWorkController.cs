// ***********************************************************************
//  Controller Name          : MPRWorkController
//  Desciption               : Add,View,Edit,Update,Delete Monthly Progress Report Work
//  Created By               : Lingaraj Dalai
//  Created On               : 02 March 2021
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Model.MPR;
using GeologyEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MPRWorkController : ControllerBase
    {
        /// <summary>
        /// Global variable declaration
        /// </summary>
        public IMPRProvider _objIMPRWorkProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objMPRWorkProvider"></param>
        public MPRWorkController(IMPRProvider objMPRWorkProvider)
        {
            _objIMPRWorkProvider = objMPRWorkProvider;
        }
        /// <summary>
        /// Post method to View Monthly Progress Report Work
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MPRWorkmaster>> ViewMPRWorkMaster(MPRWorkmaster objMPRWorkMaster)
        {
            return await _objIMPRWorkProvider.ViewMPRWorkMaster(objMPRWorkMaster);
        }
        /// <summary>
        /// Post method to Add Monthly Progress Report Work
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddMPRWorkMaster(MPRWorkmaster objMPRWorkMaster)
        {
            return await _objIMPRWorkProvider.AddMPRWorkMaster(objMPRWorkMaster);
        }
        /// <summary>
        /// Post method to Edit Monthly Progress Report Work
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MPRWorkmaster> EditMPRWorkMaster(MPRWorkmaster objMPRWorkMaster)
        {
            return await _objIMPRWorkProvider.EditMPRWorkMaster(objMPRWorkMaster);
        }
        /// <summary>
        /// Post method to Update Monthly Progress Report Work
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMPRWorkMaster(MPRWorkmaster objMPRWorkMaster)
        {
            return await _objIMPRWorkProvider.UpdateMPRWorkMaster(objMPRWorkMaster);
        }
        /// <summary>
        /// Post method to Delete Monthly Progress Report Work
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> DeleteMPRWorkMaster(MPRWorkmaster objMPRWorkMaster)
        {
            return await _objIMPRWorkProvider.DeleteMPRWorkMaster(objMPRWorkMaster);
        }
    }
}