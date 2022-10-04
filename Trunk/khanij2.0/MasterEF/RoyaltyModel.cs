using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class RoyaltyModel
    {
        public int? RoyaltyID { get; set; } 
        public int? MineralTypeId { get; set; }
        public string MineralTypeName { get; set; }

        public string Production_DispatchType { get; set; }
        public bool? DispatchType { get; set; } 
        public decimal? RoyaltyRate { get; set; }

        public decimal? AverageSalePrice { get; set; }
        public string RateEffectiveFrom { get; set; }
         
        public String RateEffectiveFrom2 { get; set; } 
        public DateTime? RateEffectiveFrom1 { get; set; } 
        public int? MineralId { get; set; }
        public string MineralName { get; set; }

 
        public int? MineralScheduleId { get; set; }
        public string MineralScheduleName { get; set; }

     
        public int? MineralSchedulePartId { get; set; }
        public string MineralSchedulePartName { get; set; }

   
        public int? UnitId { get; set; }
        public string UnitName { get; set; }
         
        public int? RoyaltyRateTypeId { get; set; }
        public string RoyaltyRateType { get; set; }
 
        public int? MineralNatureId { get; set; }
        public string MineralNatureName { get; set; }

  
        public int? MineralGradeId { get; set; }
        public string MineralGradeName { get; set; }

    
        public string CalculationTypeId { get; set; }
        public string CalculationTypeName { get; set; }

        public bool? IsActive { get; set; }
        public string status { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? isApproved { get; set; }

   
        public string Remarks { get; set; }

        public string RequestTime { get; set; }
        public string ApprovedTime { get; set; }

        public string RoyaltyCreaterFilePath { get; set; }
        public string RoyaltyApproverFilePath { get; set; }
        public string Active_InActive { get; set; }
        public string Type { get; set; }

        public string BasiRoyaltyPrice { get; set; }
        public int? chk { get; set; }
    }
}
