// ***********************************************************************
//  Controller Name          : ChecklistController
//  Description              : Add,View,Edit,Update,Delete Checklist Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MasterEF;
using System.Collections.Generic;
using MasterApi.Model.Checklist;
using System.Threading.Tasks;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ChecklistController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public IChecklistProvider _objIChecklistProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        public ChecklistController(IChecklistProvider objIChecklistProvider)
        {
            _objIChecklistProvider = objIChecklistProvider;
        }
        /// <summary>
        /// Add Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(ChecklistMaster objChecklistMaster)
        {
            return await _objIChecklistProvider.AddChecklistmaster(objChecklistMaster);
        }
        /// <summary>
        /// View Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<ChecklistMaster>> View(ChecklistMaster objChecklistMaster)
        {
            return await _objIChecklistProvider.ViewChecklistMaster(objChecklistMaster);
        }
        /// <summary>
        /// Edit Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ChecklistMaster> Edit(ChecklistMaster objChecklistMaster)
        {
            return await _objIChecklistProvider.EditChecklistMaster(objChecklistMaster);
        }
        /// <summary>
        /// Delete Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Delete(ChecklistMaster objChecklistMaster)
        {
            return await _objIChecklistProvider.DeleteChecklistMaster(objChecklistMaster);
        }
        /// <summary>
        /// Update Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update(ChecklistMaster objChecklistMaster)
        {
            return await _objIChecklistProvider.UpdateChecklistMaster(objChecklistMaster);
        }
        /// <summary>
        /// Bind Module List Details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<ChecklistMaster>> GetModuleList(ChecklistMaster objChecklistMaster)
        {
            return await _objIChecklistProvider.GetModuleList(objChecklistMaster);
        }
    }
}
