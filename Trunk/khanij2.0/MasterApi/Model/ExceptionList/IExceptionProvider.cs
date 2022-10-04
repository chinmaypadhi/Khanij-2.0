// ***********************************************************************
//  Interface Name           : IExceptionProvider
//  Description              : Exception Data details
//  Created By               : Lingaraj Dalai
//  Created On               : 05 Aug 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Repository;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Model.ExceptionList
{    
    public interface IExceptionProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Get error list details
        /// </summary>
        /// <param name="objLogEntry"></param>
        /// <returns></returns>
        string ErrorList(LogEntry objLogEntry);
        /// <summary>
        /// Get User details in view
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UserLoginSession getuserDetail(LoginEF model);
        /// <summary>
        /// Bind Menu list details
        /// </summary>
        /// <param name="objmenuonput"></param>
        /// <returns></returns>
        List<MenuEF> MenuList(menuonput objmenuonput);
    }
}
