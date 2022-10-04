// ***********************************************************************
//  Interface Name           : IExceptionProvider
//  Desciption               : Exception
//  Created By               : Lingaraj Dalai
//  Created On               : 23 Jan 2022
// ***********************************************************************
using System.Collections.Generic;
using QuarryPlanApprovalEF;

namespace QuarryPlanApprovalApp.Model.ExceptionList
{  
    public interface IExceptionProvider
    {
        string ErrorList(LogEntry objLogEntry);
        UserLoginSession LoginUser(LoginEF ObjloginEF);
        List<MenuEF> MenuList(menuonput objmenuonput);
    }
}
