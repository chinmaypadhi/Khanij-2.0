// ***********************************************************************
//  Controller Name          : UsertypeController
//  Description              : Add,View,Edit,Update,Delete Usertype Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MasterEF;
using System.Collections.Generic;
using MasterApi.Model.Usertype;
using System.Threading.Tasks;


namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class UsertypeController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public IUsertypeProvider _objIUsertypeProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        public UsertypeController(IUsertypeProvider objIUsertypeProvider)
        {
            _objIUsertypeProvider = objIUsertypeProvider;
        }
        /// <summary>
        /// Add Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(UsertypeMaster objUsertypeMaster)
        {
            return await _objIUsertypeProvider.AddUsertypemaster(objUsertypeMaster);
        }
        /// <summary>
        /// View Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<UsertypeMaster>> View(UsertypeMaster objUsertypeMaster)
        {
            return await _objIUsertypeProvider.ViewUsertypeMaster(objUsertypeMaster);
        }
        /// <summary>
        /// Edit Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<UsertypeMaster> Edit(UsertypeMaster objUsertypeMaster)
        {
            return await _objIUsertypeProvider.EditUsertypeMaster(objUsertypeMaster);
        }
        /// <summary>
        /// Delete Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Delete(UsertypeMaster objUsertypeMaster)
        {
            return await _objIUsertypeProvider.DeleteUsertypeMaster(objUsertypeMaster);
        }
        /// <summary>
        /// Update Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update(UsertypeMaster objUsertypeMaster)
        {
            return await _objIUsertypeProvider.UpdateUsertypeMaster(objUsertypeMaster);
        }
    }
}
