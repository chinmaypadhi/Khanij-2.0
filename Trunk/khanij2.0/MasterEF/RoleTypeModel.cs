using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MasterEF
{
    public class RoleTypeModel
    {
        public int? RoleTypeId { get; set; } 
        public int? UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string UserType { get; set; } 
        public string RoleTypeName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string Status { get; set; }


    }
}
