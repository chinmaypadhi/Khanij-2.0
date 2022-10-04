// ***********************************************************************
//  Class Name               : OTPModel
//  Desciption               : Add Website Tender Model Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 23 DEC 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class OTPModel
    {
        public string UserName { get; set; }
        public string OTP { get; set; }
        public string status { get; set; }
        public string MobileNumber { get; set; }
        public string Mailtype { get; set; }
        public string OptionData { get; set; }

    }
}
