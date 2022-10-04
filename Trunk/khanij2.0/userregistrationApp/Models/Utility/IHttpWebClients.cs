using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userregistrationApp.Models.Utility
{
    public interface IHttpWebClients
    {
        string PostRequest(string URI, string parameterValues);
        string GetRequest(string URI, object parameterValues);
    }
}
