// ***********************************************************************
//  Controller Name          : ExceptionDataController
//  Desciption               : Exception controller
//  Created By               : Lingaraj Dalai
//  Created On               : 18 March 2021
// ***********************************************************************
using System.Collections.Generic;
using GeologyApi.Model.ExceptionList;
using GeologyEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GeologyApi.Controllers
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