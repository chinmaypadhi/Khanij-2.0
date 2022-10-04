using HomeApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApi.ExceptionHandlear;
using Microsoft.AspNetCore.Mvc;

namespace HomeApi.Model.ExceptionList
{
    
    public interface IExceptionProvider: IDisposable, IRepository
    {
        string ErrorList(LogEntry objLogEntry);
    }
}
