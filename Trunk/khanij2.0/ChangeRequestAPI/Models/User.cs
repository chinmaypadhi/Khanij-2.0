using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeRequestAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
