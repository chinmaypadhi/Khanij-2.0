// ***********************************************************************
//  Class Name               : ChangePasswordEF
//  Desciption               : To Manage Change Password Model  
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2022
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class ChangePasswordEF
    {
        public int? UserId { get; set; }
        public string OldPassword { get; set; }
        public string EncryptPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
