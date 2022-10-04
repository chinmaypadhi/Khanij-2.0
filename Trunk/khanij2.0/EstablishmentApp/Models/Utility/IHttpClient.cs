using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Models.Utility
{
    public interface IHttpWebClients
    {
        string PostRequest(string URI, object parameterValues);
        string GetRequest(string URI, object parameterValues);
    }
}
