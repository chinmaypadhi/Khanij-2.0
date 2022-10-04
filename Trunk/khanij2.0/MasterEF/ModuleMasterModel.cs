// ***********************************************************************
//  Class Name               : ModuleMasterModel
//  Description              : Add,View,Edit,Update,Delete Module Master details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 26 Dec 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEF
{
    public class ModuleMasterModel
    {
        public int? ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int? StateId { get; set; }       
        public int? UserLoginID { get; set; }
        public int? UserID { get; set; }
        public bool? IsActive { get; set; }
        public string ActiveStatus { get; set; }
    }
}
