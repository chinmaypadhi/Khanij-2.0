// ***********************************************************************
//  Class Name               : User
//  Created By               : Kumar jeevan jyoti
//  Created On               : 28-dec-2020
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model
{
    public class User
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
