
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInformationEF;
using Microsoft.AspNetCore.Mvc;


namespace UserInformationApp.Model.ExceptionList
{
    
    public interface IExceptionProvider
    {
        string ErrorList(LogEntry objLogEntry);
        //public UserLoginSession getuserDetail(LoginEF model);
        public List<MenuEF> MenuList(menuonput objmenuonput);
        UserLoginSession LoginUser(LoginEF ObjloginEF);
    }
}
