using HomeApi.Factory;
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
namespace HomeApi.Model.ExceptionList
{
    public class ExceptionProvider: RepositoryBase,IExceptionProvider
    {
        public ExceptionProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
          
        }
        public string ErrorList(LogEntry objLogEntry)
        {
            try
            {
                var paramList = new
                {
                    Controller      =objLogEntry.Controller
                    ,Action          =objLogEntry.Action      
                    ,ReturnType      =objLogEntry.ReturnType  
                    ,ErrorMessage    =objLogEntry.ErrorMessage
                    ,StackTrace      =objLogEntry.StackTrace  
                    ,UserId          =objLogEntry.UserID      
                    ,UserLoginID     = objLogEntry.UserLoginID
                };
                var result = Connection.Execute("ReportErrorLog", paramList, commandType: System.Data.CommandType.StoredProcedure);
                return "1";
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
