using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class RoyaltyForwardmaster
    {
        public int? RoyaltyId { get; set; }
        public int? checkboxid { get; set; }
        public string Production_DispatchType { get; set; }
        public decimal RoyaltyRate { get; set; }
        public decimal AverageSalePrice { get; set; }
        public DateTime RateEffectiveUPTO { get; set; }
        public DateTime RateEffectiveFrom { get; set; }
        public int? MineralId { get; set; }
        public string MineralName { get; set; }
        public int? UnitId { get; set; }
        public int? MineralGradeId { get; set; }
        public int? MineralTypeId { get; set; }
        public string MineralType { get; set; }
        public string MineralGrade { get; set; }
        public int? MineralSchedulePartID { get; set; }
        public string MineralSchedulePart { get; set; }
        public int? MineralScheduleID { get; set; }
        public string MineralScheduleName { get; set; }
        public int? UnitID { get; set; }
        public string UnitName { get; set; }
        public int? RoyaltyRateTypeId { get; set; }
        public string RoyaltyRateType { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }
        public int? UserLoginId { get; set; }
        public int? IsSend { get; set; }
        public string MineralNature { get; set; }
        #region Download Royalty
        public string CalculationType { get; set; }
        public int? UserId { get; set; }
        public string CalculationTypeName { get; set; }
        public string Active_InActive { get; set; }
        public string Type { get; set; }
        public string RoyaltyCreaterFilePath { get; set; }
        public string MineralNatureName { get; set; }
        public string MineralGradeName { get; set; }
        public string MineralTypeName { get; set; }
        #endregion
    }
}
