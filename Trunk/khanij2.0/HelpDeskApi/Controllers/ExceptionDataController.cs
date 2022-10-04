using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HelpDeskEF;
using HelpDeskApi.Model.ExceptionList;
using Microsoft.AspNetCore.Authorization;

namespace HelpDeskApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class ExceptionDataController : ControllerBase
    {
        IExceptionProvider _objIExceptionProvider;
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