using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using SupportApp.Model.ExceptionList;
using SupportEF;

namespace SupportApp.Controllers
{
    public class ErrorController : Controller
    {
        IExceptionProvider _objIExceptionProvider;
        LogEntry objLogEntry = new LogEntry();
        public ErrorController(IExceptionProvider objIExceptionProvider)
        {
            _objIExceptionProvider = objIExceptionProvider;
        }

        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            // Retrieve the exception Details
            var exceptionHandlerPathFeature =
                    HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            objLogEntry.Action = exceptionHandlerPathFeature.GetType().FullName;
            objLogEntry.Controller = exceptionHandlerPathFeature.Path;
            objLogEntry.ReturnType = "Return";
            objLogEntry.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;
            objLogEntry.ErrorMessage = exceptionHandlerPathFeature.Error.Message;

            _objIExceptionProvider.ErrorList(objLogEntry);


            return View("Error");
        }
    }
}
