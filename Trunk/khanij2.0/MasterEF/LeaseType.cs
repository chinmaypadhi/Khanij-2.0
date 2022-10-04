using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class LeaseType
    {
        public int? LeaseTypeId { get; set; }
        public string LeaseTypeName { get; set; }
        public string LeaseTypeCode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public String Status { get; set; }
        public int? UserLoginId { get; set; }
    }
}
