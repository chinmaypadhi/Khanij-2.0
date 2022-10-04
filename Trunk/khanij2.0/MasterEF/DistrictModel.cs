using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
   public class DistrictModel
    {
        public int? DistrictID { get; set; } 
        public string DistrictName { get; set; }
         
        public string DistrictCode { get; set; }
         
        public int? RegionalID { get; set; }
        public string RegionalName { get; set; }

       
        public int? StateID { get; set; }
        public string StateName { get; set; }
 
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string IsActives { get; set; }
        public string Status { get; set; }
        public int? CreatedBy { get; set; }
    }
}
