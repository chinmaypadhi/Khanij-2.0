using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ReturnApp.Web;
using ReturnApp.Model.ExceptionList;
using ReturnEF;
using Microsoft.Extensions.Options;

namespace ReturnApp.ActionFilter
{
    public class SessionActionFilter: IActionFilter
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
                        menuonput objmenu = new menuonput();
                        objmenu.UserID = Convert.ToInt32(objUserLoginSession1.UserId);
                        objmenu.MineralId = Convert.ToInt32(objUserLoginSession1.MineralId);
                        objmenu.MineralName = objUserLoginSession1.MineralName;
                        Listmenu = _objIExceptionProvider.MenuList(objmenu);                        
                        objUserLoginSession1.Listmenu = Listmenu;
                    }
                    context.HttpContext.Session.Set<UserLoginSession>(KeyHelper.UserKey, objUserLoginSession1);

                }
                else if(Convert.ToInt32(claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value)!= objUserLoginSession.UserId)
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
}
