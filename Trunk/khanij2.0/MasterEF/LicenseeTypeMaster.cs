using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
   public class LicenseeTypeMaster
    {
        public int? LicenseeTypeId { get; set; }
        public string LicenseeTypeName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string Status { get; set; }
        public int? UserLoginId { get; set; }
    }
}
