// ***********************************************************************
//  Controller Name          : GeneratedFPOController
//  Desciption               : View Generated Field Program Order
//  Created By               : Lingaraj Dalai
//  Created On               : 17 Feb 2021
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
    public class GeneratedFPOController : ControllerBase
    {
        /// <summary>
        /// Global variable declaration
        /// </summary>
        public IFPOProvider _objIFPOProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objFPOProvider"></param>
        public GeneratedFPOController(IFPOProvider objFPOProvider)
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
            return await _objIFPOProvider.ViewGeneratedFPO(objFPOMaster);
        }
    }
}