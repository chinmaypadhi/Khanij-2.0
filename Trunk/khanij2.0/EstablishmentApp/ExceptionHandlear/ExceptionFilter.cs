



using EstablishmentApp.Model.ExceptionList;
using EstablishmentEf;
using Microsoft.AspNetCore.Mvc.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.ExceptionHandlear
{
    public class ExceptionFilterHandlear : ExceptionFilterAttribute
    {
        IExceptionProvider _objIExceptionProvider;
        public ExceptionFilterHandlear(IExceptionProvider objIExceptionProvider)
        {
            _objIExceptionProvider = objIExceptionProvider;
        }
        public override void OnException(ExceptionContext context)
        {
            try
            {
                LogEntry objLogEntry = new LogEntry();
                objLogEntry.Action = context.ActionDescriptor.DisplayName;
                objLogEntry.Controller = context.HttpContext.Request.Path;
                objLogEntry.ReturnType = "Master";
                objLogEntry.StackTrace = context.Exception.StackTrace;
                objLogEntry.ErrorMessage = context.Exception.Message;

                _objIExceptionProvider.ErrorList(objLogEntry);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
