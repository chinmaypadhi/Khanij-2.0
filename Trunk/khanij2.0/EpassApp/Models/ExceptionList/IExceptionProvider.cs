
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpassEF;
using Microsoft.AspNetCore.Mvc;


namespace EpassApp.Model.ExceptionList
{
    
    public interface IExceptionProvider
    {
        string ErrorList(LogEntry objLogEntry);
        public List<MenuEF> MenuList(menuonput objmenuonput);
        UserLoginSession LoginUser(LoginEF ObjloginEF);
    }
}
