// ***********************************************************************
//  Controller Name          : StaffDirectoryController
//  Desciption               : Add,Select,Update,Delete Website Staff Directory Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Oct 2021
// ***********************************************************************
using HomeApi.Model.StaffDirectory;
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
    public class StaffDirectoryController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public IStaffDirectoryProvider _objIStaffDirectoryProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public StaffDirectoryController(IStaffDirectoryProvider objIStaffDirectoryProvider)
        {
            _objIStaffDirectoryProvider = objIStaffDirectoryProvider;
        }
        /// <summary>
        /// Add Website Staff Directory Details in view
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>     
        [HttpPost]
        public MessageEF Add(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            return _objIStaffDirectoryProvider.AddStaffDirectory(objAddStaffDirectoryModel);
        }
        /// <summary>
        /// Edit Website Staff Directory Details in view
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public AddStaffDirectoryModel Edit(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            return _objIStaffDirectoryProvider.EditStaffDirectory(objAddStaffDirectoryModel);
        }
        /// <summary>
        /// Select Website Staff Directory Details in view
        /// </summary>
        /// <param name="objViewStaffDirectoryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewStaffDirectoryModel>>> View(ViewStaffDirectoryModel objViewStaffDirectoryModel)
        {
            return await _objIStaffDirectoryProvider.ViewStaffDirectory(objViewStaffDirectoryModel);
        }
        /// <summary>
        /// Delete Website Staff Directory Details in view
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(ViewStaffDirectoryModel objViewStaffDirectoryModel)
        {
            return _objIStaffDirectoryProvider.DeleteStaffDirectory(objViewStaffDirectoryModel);
        }
        /// <summary>
        /// Update Website Staff Directory Details in view
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            return _objIStaffDirectoryProvider.UpdateStaffDirectory(objAddStaffDirectoryModel);
        }
        /// <summary>
        /// Bind Website Staff Directory Type List Details in view
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AddStaffDirectoryModel>>> GetOfficeTypeList(AddStaffDirectoryModel objAddStaffDirectoryModel)
        {
            return await _objIStaffDirectoryProvider.GetOfficeTypeList(objAddStaffDirectoryModel);
        }
        /// <summary>
        /// Bind Publish Website Staff Directory Details 
        /// </summary>
        /// <param name="objViewStaffDirectoryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewStaffDirectoryModel>>> ViewPublishStaffDirectory(ViewStaffDirectoryModel objViewStaffDirectoryModel)
        {
            return await _objIStaffDirectoryProvider.ViewPublishStaffDirectory(objViewStaffDirectoryModel);
        }
    }
}
