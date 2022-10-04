// ***********************************************************************
//  Controller Name          : FPOCreatorController
//  Desciption               : Add,View Field Program Order
//  Created By               : Lingaraj Dalai
//  Created On               : 16 Feb 2021
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Model.FPO;
using GeologyEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class FPOCreatorController : ControllerBase
    {
        /// <summary>
        /// Global variable declaration
        /// </summary>
        public IFPOProvider _objIFPOProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objFPOProvider"></param>
        public FPOCreatorController(IFPOProvider objFPOProvider)
        {
            _objIFPOProvider = objFPOProvider;
        }
        /// <summary>
        /// Post method to View Field Program Order
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<FPOOrdermaster>> View(FPOOrdermaster objFPOMaster)
        {
            return await _objIFPOProvider.ViewFPOCreator(objFPOMaster);
        }
        /// <summary>
        ///  Post method to Add Field Program Order
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(FPOOrdermaster objFPOMaster)
        {
            return await  _objIFPOProvider.AddFPOCreator(objFPOMaster);
        }
    }
}