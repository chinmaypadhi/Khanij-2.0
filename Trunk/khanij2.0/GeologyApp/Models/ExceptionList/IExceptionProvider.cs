// ***********************************************************************
//  Interface Name           : IExceptionProvider
//  Desciption               : Exception
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Dec 2021
// ***********************************************************************
using System.Collections.Generic;
using GeologyEF;

namespace GeologyApp.Model.ExceptionList
{  
    public interface IExceptionProvider
    {
        string ErrorList(LogEntry objLogEntry);
        UserLoginSession LoginUser(LoginEF ObjloginEF);
        List<MenuEF> MenuList(menuonput objmenuonput);
    }
}
