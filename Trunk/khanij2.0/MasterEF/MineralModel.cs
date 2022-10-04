using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class MineralModel
    {
        public int? MineralID { get; set; }

     
        public int? MineralTypeId { get; set; }
        public string MineralTypeName { get; set; }

     
        public int? MineralScheduleId { get; set; }
        public string MineralScheduleName { get; set; }

      
        public int? MineralSchedulePartId { get; set; }
        public string MineralSchedulePartName { get; set; }

       
        public string MineralName { get; set; }

       
        public int? UnitId { get; set; }
        public string UnitName { get; set; }

  
        public int? RoyaltyRateTypeId { get; set; }
        public string RoyaltyRateType { get; set; } 

      
        public bool? Cess_7_5_Infrastructure { get; set; }

    
        public bool? Cess_7_5_Env { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public string Status { get; set; }
    }
}
