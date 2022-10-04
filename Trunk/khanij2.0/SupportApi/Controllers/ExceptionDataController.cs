using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportEF;
using SupportApi.Model.ExceptionList;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ExceptionDataController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        IExceptionProvider _objIExceptionProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objInspectionProvider"></param>
        public ExceptionDataController(IExceptionProvider objIExceptionProvider)
        {
            _objIExceptionProvider = objIExceptionProvider;
        }
        [HttpPost]
        public string AddException(LogEntry objLogEntry)
        {
            return _objIExceptionProvider.ErrorList(objLogEntry);
        }
        [HttpPost]
        public UserLoginSession getuserDetail(LoginEF model)
        {
            return _objIExceptionProvider.getuserDetail(model);
        }
        [HttpPost]
        public List<MenuEF> MenuList(menuonput objmenuonput)
        {
            return _objIExceptionProvider.MenuList(objmenuonput);
        }
        [HttpPost]
        public string AddApiException()
        {
            LogEntry objLogEntry = new LogEntry();
            return _objIExceptionProvider.ErrorList(objLogEntry);
        }
    }
}