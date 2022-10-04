using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using Microsoft.AspNetCore.Mvc;

namespace HomeApp.Model.ExceptionList
{

    public interface IExceptionProvider
    {
        /// <summary>
        /// Bind Error List details in view
        /// </summary>
        /// <param name="objLogEntry"></param>
        /// <returns></returns>
        string ErrorList(LogEntry objLogEntry);
        /// <summary>
        /// Bind Menu List details in view
        /// </summary>
        /// <param name="objmenuonput"></param>
        /// <returns></returns>
        List<MenuEF> MenuList(menuonput objmenuonput);
        /// <summary>
        /// Get Login User Deatils in view
        /// </summary>
        /// <param name="ObjloginEF"></param>
        /// <returns></returns>
        UserLoginSession LoginUser(LoginEF ObjloginEF);
    }
}
