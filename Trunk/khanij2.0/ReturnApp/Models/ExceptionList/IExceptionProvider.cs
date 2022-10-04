
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using ReturnEF;


namespace ReturnApp.Model.ExceptionList
{
    
    public interface IExceptionProvider
    {
        string ErrorList(LogEntry objLogEntry);
        UserLoginSession LoginUser(LoginEF ObjloginEF);
        List<MenuEF> MenuList(menuonput objmenuonput);
    }
}
