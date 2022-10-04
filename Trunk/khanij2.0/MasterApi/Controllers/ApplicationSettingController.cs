// ***********************************************************************
//  Controller Name          : ApplicationSettingController
//  Description              : Add,View,Edit,Update,Delete Application Setting details
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Jan 2021
// ***********************************************************************
using System.Collections.Generic;
using MasterApi.Model.ApplicationSetting;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ApplicationSettingController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public IApplicationSettingProvider _objIApplicationSettingProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        public ApplicationSettingController(IApplicationSettingProvider objApplicationSettingProvider)
        {
            _objIApplicationSettingProvider = objApplicationSettingProvider;
        }
        /// <summary>
        /// View Setting details
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ApplicationSettingmaster> View(ApplicationSettingmaster objApplicationSettingmaster)
        {
            return _objIApplicationSettingProvider.ViewApplicationSettingmaster(objApplicationSettingmaster);
        }
        /// <summary>
        /// Edit Application Setting details
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public ApplicationSettingmaster Edit(ApplicationSettingmaster objApplicationSettingmaster)
        {
            return _objIApplicationSettingProvider.EditApplicationSettingmaster(objApplicationSettingmaster);
        }
        /// <summary>
        /// Update Application Setting details
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(ApplicationSettingmaster objApplicationSettingmaster)
        {
            return _objIApplicationSettingProvider.UpdateApplicationSettingmaster(objApplicationSettingmaster);
        }
    }
   
}