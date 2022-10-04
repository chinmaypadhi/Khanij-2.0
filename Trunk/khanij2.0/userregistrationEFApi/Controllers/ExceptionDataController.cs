using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Model.ExceptionList;

namespace userregistrationEFApi.Controllers
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
