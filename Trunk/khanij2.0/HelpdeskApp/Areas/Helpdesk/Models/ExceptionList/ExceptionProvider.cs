

using HelpDeskEF;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpdeskApp.Model.ExceptionList
{
    public class ExceptionProvider:IExceptionProvider
    {
        
        public string ErrorList(LogEntry objLogEntry)
        {
            try
            {
              string   s = JsonConvert.DeserializeObject<string>(HelpdeskApp.Areas.Helpdesk.Models.Utility.HttpWebClients.PostRequest("ExceptionData/AddException", objLogEntry));
                return s;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
