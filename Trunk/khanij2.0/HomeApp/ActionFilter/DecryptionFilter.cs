using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using HomeApp.Web;
using HomeApp.Model.ExceptionList;
using HomeEF;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Routing;
using System.Globalization;
using System.IO;

namespace HomeApp.ActionFilter
{
    public class DecryptionFilter:IActionFilter
    {
        IExceptionProvider _objIExceptionProvider;
        IOptions<KeyList> _objKeyList;
        public DecryptionFilter(IExceptionProvider objIExceptionProvider, IOptions<KeyList> objKeyList)
        {
            _objIExceptionProvider = objIExceptionProvider;
            _objKeyList = objKeyList;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            // Check if the attribute exists on the action method
            if (controllerActionDescriptor.MethodInfo?.GetCustomAttributes(inherit: true)?.Any(a => a.GetType().Equals(typeof(DecryptionAttribute))) ?? false)
            {
                #region decrypt encrypted url
                var dataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo(_objKeyList.Value.EncryptionPath));
                var protector = dataProtectionProvider.CreateProtector("KhanijEncryptDecryptQuery.QueryStrings");

                Dictionary<string, object> decryptedParameters = new Dictionary<string, object>();
                if (!string.IsNullOrEmpty(context.HttpContext.Request.Query["q"].ToString()))
                {
                    string decrptedString = protector.Unprotect(context.HttpContext.Request.Query["q"].ToString());
                    string[] getRandom = decrptedString.Split('|');

                    var format = new CultureInfo("en-GB");
                    var dateCheck = Convert.ToDateTime(getRandom[2], format);

                    TimeSpan diff = Convert.ToDateTime(DateTime.Now, format) - dateCheck;

                    /* For Development it is been commented */
                    if (diff.Minutes > 30)
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Error", controller = "Error" }));
                    }

                    string[] paramsArrs = getRandom[1].Split('?');

                    for (int i = 0; i < paramsArrs.Length; i++)
                    {
                        string[] paramArr = paramsArrs[i].Split('=');
                        decryptedParameters.Add(paramArr[0], Convert.ToString(paramArr[1]));
                    }
                }

                if (decryptedParameters.Count > 0)
                {
                    for (int i = 0; i < decryptedParameters.Count; i++)
                    {
                        context.ActionArguments[decryptedParameters.Keys.ElementAt(i)] = decryptedParameters.Values.ElementAt(i);
                    }
                }
                #endregion
            }
            else
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectResult(_objKeyList.Value.LoginUrl);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //this method will be executed after an action method has executed 
        }
    }
    public class DecryptionAttribute : Attribute { }
}
