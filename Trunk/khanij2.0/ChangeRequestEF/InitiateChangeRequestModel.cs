using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeRequestEF
{
    class InitiateChangeRequestModel
    {
        public int ChangeRequestInitiateID { get; set; }
        public string ChangeRequestType { get; set; }
    }
}
