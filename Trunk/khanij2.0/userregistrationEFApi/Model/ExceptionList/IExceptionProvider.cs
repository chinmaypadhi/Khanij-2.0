
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.ExceptionList
{    
    public interface IExceptionProvider: IDisposable, IRepository
    {
        string ErrorList(LogEntry objLogEntry);
        UserLoginSession getuserDetail(LoginEF model);
        List<MenuEF> MenuList(menuonput objmenuonput);
        DataSet ConvertDataReaderToDataSet(IDataReader data);
    }
}
