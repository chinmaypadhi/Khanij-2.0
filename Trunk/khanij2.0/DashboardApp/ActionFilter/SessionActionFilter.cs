// ***********************************************************************
//  Class Name               : SessionActionFilter
//  Desciption               : Session Action Class
//  Created By               : Lingaraj Dalai
//  Created On               : 31 August 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DashboardApp.Web;
using DashboardApp.Model.ExceptionList;
using DashboardEF;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Globalization;
using Microsoft.AspNetCore.Routing;

namespace DashboardApp.ActionFilter
{
    public class SessionActionFilter : IActionFilter
    {
        IExceptionProvider _objIExceptionProvider;
        IOptions<KeyList> _objKeyList;
        public SessionActionFilter(IExceptionProvider objIExceptionProvider, IOptions<KeyList> objKeyList)
        {
            _objIExceptionProvider = objIExceptionProvider;
            _objKeyList = objKeyList;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            // Check if the attribute exists on the action method
            if (controllerActionDescriptor.MethodInfo?.GetCustomAttributes(inherit: true)?.Any(a => a.GetType().Equals(typeof(SkipImportantTaskAttribute))) ?? false)
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
            if (claimsIdentity.IsAuthenticated)
            {
                UserLoginSession objUserLoginSession = context.HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);              
                if (objUserLoginSession == null)
                {
                    LoginEF ObjloginEF = new LoginEF();
                    ObjloginEF.UserID = Convert.ToInt32(claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                    ObjloginEF.UserName = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData)?.Value;
                    UserLoginSession objUserLoginSession1 = _objIExceptionProvider.LoginUser(ObjloginEF);
                    if (objUserLoginSession1.UserName != null)
                    {
                        List<MenuEF> Listmenu = new List<MenuEF>();
                        objUserLoginSession1.UserLoginId = Convert.ToInt32(claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value);
                        menuonput objmenu = new menuonput();
                        objmenu.UserID = Convert.ToInt32(objUserLoginSession1.UserId);
                        objmenu.MineralId = Convert.ToInt32(objUserLoginSession1.MineralId);
                        objmenu.MineralName = objUserLoginSession1.MineralName;
                        Listmenu = _objIExceptionProvider.MenuList(objmenu);
                        objUserLoginSession1.Listmenu = Listmenu;
                    }
                    context.HttpContext.Session.Set<UserLoginSession>(KeyHelper.UserKey, objUserLoginSession1);

                }
                else if (Convert.ToInt32(claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value) != objUserLoginSession.UserId)
                {
                    LoginEF ObjloginEF = new LoginEF();
                    ObjloginEF.UserID = Convert.ToInt32(claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                    ObjloginEF.UserName = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData)?.Value;
                    UserLoginSession objUserLoginSession1 = _objIExceptionProvider.LoginUser(ObjloginEF);
                    if (objUserLoginSession1.UserName != null)
                    {
                        List<MenuEF> Listmenu = new List<MenuEF>();
                        objUserLoginSession1.UserLoginId = Convert.ToInt32(claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value);
                        menuonput objmenu = new menuonput();
                        objmenu.UserID = Convert.ToInt32(objUserLoginSession1.UserId);
                        objmenu.MineralId = Convert.ToInt32(objUserLoginSession1.MineralId);
                        objmenu.MineralName = objUserLoginSession1.MineralName;
                        Listmenu = _objIExceptionProvider.MenuList(objmenu);
                        objUserLoginSession1.Listmenu = Listmenu;
                    }
                    context.HttpContext.Session.Set<UserLoginSession>(KeyHelper.UserKey, objUserLoginSession1);

                }

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
    public class SkipImportantTaskAttribute : Attribute { }
}
