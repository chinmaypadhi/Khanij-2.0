// ***********************************************************************
//  Controller Name          : MineralMapController
//  Desciption               : View Mineral Map Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2022
// ***********************************************************************
using HomeApi.Model.MineralMap;
using HomeEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MineralMapController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public IMineralMapProvider _objIMineralMapProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public MineralMapController(IMineralMapProvider objIMineralMapProvider)
        {
            _objIMineralMapProvider = objIMineralMapProvider;
        }
        /// <summary>
        /// View Mineral Map Count details in view
        /// </summary>
        /// <param name="objMineralMapModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ViewMineralMapModel>> ViewMineralMapCount(ViewMineralMapModel objMineralMapModel)
        {
            return await _objIMineralMapProvider.ViewMineralMapCount(objMineralMapModel);
        }
    }
}
