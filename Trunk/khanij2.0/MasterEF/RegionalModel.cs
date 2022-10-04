using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class RegionalModel
    {
        public int? RegionalID { get; set; } 
        public string RegionalName { get; set; } 

        public int? StateID { get; set; }
        public string StateName { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ActiveStatus { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string IsActives { get; set; }
        public string Status { get; set; }
        public int? CHK { get; set; }
    }
}
