// ***********************************************************************
//  Controller Name          : ChangePasswordController
//  Desciption               : To Change User Password Details in view 
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2022
// ***********************************************************************
using HomeApi.Model.ChangePassword;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using Microsoft.AspNetCore.Authorization;

namespace HomeApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ChangePasswordController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration 
        /// </summary>
        private IChangePasswordProvider _objIChangePasswordProvider;
        /// <summary>
        /// Constructor Dependency Injection
        /// </summary>
        /// <param name="objIChangePasswordProvider"></param>
        public ChangePasswordController(IChangePasswordProvider objIChangePasswordProvider)
        {
            _objIChangePasswordProvider = objIChangePasswordProvider;
        }
        /// <summary>
        /// To change user password details
        /// </summary>
        /// <param name="objChangePasswordEF"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ChangeUserPassword(ChangePasswordEF objChangePasswordEF)
        {
            return await _objIChangePasswordProvider.ChangeUserPassword(objChangePasswordEF);
        }
    }
}
