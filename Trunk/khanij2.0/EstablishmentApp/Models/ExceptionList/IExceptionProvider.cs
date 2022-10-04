
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentEf;
using Microsoft.AspNetCore.Mvc;


namespace EstablishmentApp.Model.ExceptionList
{
    
    public interface IExceptionProvider
    {
        string ErrorList(LogEntry objLogEntry);
        UserLoginSession LoginUser(LoginEF ObjloginEF);
        List<MenuEF> MenuList(menuonput objmenuonput);
    }
}
