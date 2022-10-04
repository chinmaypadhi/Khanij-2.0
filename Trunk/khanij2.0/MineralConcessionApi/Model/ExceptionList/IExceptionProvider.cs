
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MineralConcessionEF;
using MineralConcessionApi.Repository;

namespace MineralConcessionApi.Model.ExceptionList
{
    public interface IExceptionProvider : IDisposable, IRepository
    {
        [HttpPost]
        string ErrorList(LogEntry objLogEntry);
        [HttpPost]
        public UserLoginSession getuserDetail(LoginEF model);
        [HttpPost]
        public List<MenuEF> MenuList(menuonput objmenuonput);
    }
}
