using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.Module;
using MasterEF;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ModuleController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public IModuleProvider _objIModuleProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="moduleProvider"></param>
        public ModuleController(IModuleProvider moduleProvider)
        {
            _objIModuleProvider = moduleProvider;
        }
        /// <summary>
        ///     To Add a Mdule Name
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(ModuleMasterModel moduleMasterModel)
        {
            return await _objIModuleProvider.AddModule(moduleMasterModel);
        }
        /// <summary>
        /// To View Module Names
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<ModuleMasterModel>> View(ModuleMasterModel moduleMasterModel)
        {
            return await _objIModuleProvider.ViewModule(moduleMasterModel);
        }
        /// <summary>
        /// To Edit a Module Name
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ModuleMasterModel> Edit(ModuleMasterModel moduleMasterModel)
        {
            return await _objIModuleProvider.EditModule(moduleMasterModel);
        }
        /// <summary>
        /// To Delete Module
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Delete(ModuleMasterModel moduleMasterModel)
        {
            return await _objIModuleProvider.DeleteModule(moduleMasterModel);
        }
        [HttpPost]
        public async Task<MessageEF> Update(ModuleMasterModel moduleMasterModel)
        {
            return await _objIModuleProvider.UpdateModule(moduleMasterModel);
        }
    }
}
