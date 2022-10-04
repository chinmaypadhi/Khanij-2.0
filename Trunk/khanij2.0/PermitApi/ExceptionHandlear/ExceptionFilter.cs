// ***********************************************************************
//  Class Name               : ExceptionFilterHandlear
//  Desciption               : Exception handler class
//  Created By               : sanjay kumar
//  Created On               : 28 Dec 2020
// ***********************************************************************

using PermitApi.Model.ExceptionList;
using PermitEF;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace PermitApi.ExceptionHandlear
{
    public class ExceptionFilterHandlear : ExceptionFilterAttribute
    {
        /// <summary>
        /// Global variable declaration
        /// </summary>
        IExceptionProvider _objIExceptionProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIExceptionProvider"></param>
        public ExceptionFilterHandlear(IExceptionProvider objIExceptionProvider)
        {
            _objIExceptionProvider = objIExceptionProvider;
        }
        /// <summary>
        /// Exception method
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            try
            {
                LogEntry objLogEntry = new LogEntry();
                objLogEntry.Action = context.ActionDescriptor.DisplayName;
                objLogEntry.Controller = context.HttpContext.Request.Path;
                objLogEntry.ReturnType = "Permit API";
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
