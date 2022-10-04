using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

using EpassApp.Web;
using EpassApp.Model.ExceptionList;
using EpassEF;

namespace MasterApp.ActionFilter
{
    public class newActionFilter: IActionFilter
    {
        IExceptionProvider _objIExceptionProvider;
        public newActionFilter(IExceptionProvider objIExceptionProvider)
        {
            _objIExceptionProvider = objIExceptionProvider;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {

            var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (claimsIdentity.IsAuthenticated)
            {

                
                UserLoginSession objUserLoginSession = context.HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if(objUserLoginSession==null)
                {
                    LoginEF ObjloginEF = new LoginEF();
                    ObjloginEF.UserID = Convert.ToInt32(claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                    ObjloginEF.UserName  =claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData)?.Value;
                    UserLoginSession objUserLoginSession1 = _objIExceptionProvider.LoginUser(ObjloginEF);
                    if(objUserLoginSession1.UserName !=null)
                    {
                        List<MenuEF> Listmenu = new List<MenuEF>();
                        objUserLoginSession1.UserLoginId = Convert.ToInt32(claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value);
                        Listmenu = _objIExceptionProvider.MenuList(new menuonput());
                        objUserLoginSession1.Listmenu = Listmenu;
                    }
                    context.HttpContext.Session.Set<UserLoginSession>(KeyHelper.UserKey, objUserLoginSession1);

                }
                
            }
            else
            {
                context.Result = new RedirectResult("http://ko2home.in/");
            }

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //this method will be executed after an action method has executed 
        }
    }
}
