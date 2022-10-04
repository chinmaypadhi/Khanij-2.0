
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;

using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Model.ExceptionList
{
    
    public interface IExceptionProvider
    {
        string ErrorList(LogEntry objLogEntry);
        List<MenuEF> MenuList(menuonput objmenuonput);
        UserLoginSession LoginUser(LoginEF ObjloginEF);
    }

}
