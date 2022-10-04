// ***********************************************************************
//  Controller Name          : ExceptionDataController
//  Desciption               : Exception controller
//  Created By               : Lingaraj Dalai
//  Created On               : 18 March 2021
// ***********************************************************************
using System.Collections.Generic;
using IntegrationApi.Model.ExceptionList;
using IntegrationEF;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
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
        public string AddException(LogEntry objLogEntry)
        {
            return _objIExceptionProvider.ErrorList(objLogEntry);
        }
        /// <summary>
        /// To get user detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserLoginSession getuserDetail(LoginEF model)
        {
            return _objIExceptionProvider.getuserDetail(model);
        }
        /// <summary>
        /// To bind Menulist
        /// </summary>
        /// <param name="objmenuonput"></param>
        /// <returns></returns>
        public List<MenuEF> MenuList(menuonput objmenuonput)
        {
            return _objIExceptionProvider.MenuList(objmenuonput);
        }
        /// <summary>
        /// To add api
        /// </summary>
        /// <returns></returns>
        public string AddApiException()
        {
            LogEntry objLogEntry = new LogEntry();
            return _objIExceptionProvider.ErrorList(objLogEntry);
        }
    }
}