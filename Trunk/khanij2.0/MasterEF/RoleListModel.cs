using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MasterEF
{
    public class RoleListModel
    {

        public int? RoleId { get; set; }

        public int? RoleTypeId { get; set; }
        public string RoleTypeName { get; set; }

        public string RoleName { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int? TotalRole { get; set; }
        public bool? IsActive { get; set; }
        public int? UserTypeId { get; set; }
        public string UserType { get; set; }

        public string Status { get; set; }
        public int? CreatedBy { get; set; }

    }
}
