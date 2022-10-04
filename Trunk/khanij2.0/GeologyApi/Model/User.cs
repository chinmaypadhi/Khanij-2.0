// ***********************************************************************
//  Class Name               : User
//  Desciption               : User details
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Dec 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GeologyApi.Model
{
    public class User
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
