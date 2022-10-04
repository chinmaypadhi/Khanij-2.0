
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReturnApi.Repository;
using Microsoft.AspNetCore.Mvc;
using ReturnEF;
using System.Data;

namespace ReturnApi.Model.ExceptionList
{    
    public interface IExceptionProvider: IDisposable, IRepository
    {
        string ErrorList(LogEntry objLogEntry);
        UserLoginSession getuserDetail(LoginEF model);
        List<MenuEF> MenuList(menuonput objmenuonput);
        DataSet ConvertDataReaderToDataSet(IDataReader data);
    }
}
