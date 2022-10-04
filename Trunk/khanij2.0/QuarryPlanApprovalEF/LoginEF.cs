// ***********************************************************************
//  Class Name               : LoginEF
//  Desciption               : User Login Details
//  Created By               : Lingaraj Dalai
//  Created On               : 23 Jan 2022
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarryPlanApprovalEF
{
    public class LoginEF
    {
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int UserID { get; set; }
        public string MobileNo { get; set; }
        public string Remoteid { get; set; }
        public string Localip { get; set; }
        public string Browserinfo { get; set; }
    }
}
