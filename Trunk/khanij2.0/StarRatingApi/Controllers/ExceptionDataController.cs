// ***********************************************************************
//  Controller Name          : ExceptionDataController
//  Desciption               : Exception controller
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Sept 2021
// ***********************************************************************
using StarRatingApi.Model.ExceptionList;
using StarratingEF;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace StarRatingApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ExceptionDataController : ControllerBase
    {
        /// <summary>
        /// Global variable declaration
        /// </summary>
        IExceptionProvider _objIExceptionProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIExceptionProvider"></param>
        public ExceptionDataController(IExceptionProvider objIExceptionProvider)
        {
            _objIExceptionProvider = objIExceptionProvider;
        }
        /// <summary>
        /// To Add Exception
        /// </summary>
        /// <param name="objLogEntry"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddException(LogEntry objLogEntry)
        {
            return _objIExceptionProvider.ErrorList(objLogEntry);
        }
        /// <summary>
        /// To get user detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public UserLoginSession getuserDetail(LoginEF model)
        {
            return _objIExceptionProvider.getuserDetail(model);
        }
        /// <summary>
        /// To bind Menulist
        /// </summary>
        /// <param name="objmenuonput"></param>
        /// <returns></returns>
        [HttpPost]
        public List<MenuEF> MenuList(menuonput objmenuonput)
        {
            return _objIExceptionProvider.MenuList(objmenuonput);
        }
        /// <summary>
        /// To add api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string AddApiException()
        {
            LogEntry objLogEntry = new LogEntry();
            return _objIExceptionProvider.ErrorList(objLogEntry);
        }
    }
}