// ***********************************************************************
//  interface Name           : IExceptionProvider
//  Desciption               : Exception details class 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Sept 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarratingEF;
using Microsoft.AspNetCore.Mvc;

namespace StarratingApp.Model.ExceptionList
{   
    public interface IExceptionProvider
    {
        string ErrorList(LogEntry objLogEntry);
        UserLoginSession LoginUser(LoginEF ObjloginEF);
        List<MenuEF> MenuList(menuonput objmenuonput);
    }
}
