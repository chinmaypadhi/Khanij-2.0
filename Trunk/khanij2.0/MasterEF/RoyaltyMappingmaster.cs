using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class RoyaltyMappingmaster
    {
        public int MappingID { get; set; }

        public int? MineralTypeId { get; set; }
        public string MineralType { get; set; }

        public string GrantType { get; set; }
        public string GrantOrderDate { get; set; }

        public string AuctionName { get; set; }
        public int? LeaseTypeId { get; set; }
        public string LeaseTypeName { get; set; }
        //public DateTime? RateEffectiveFrom { get; set; }

        public int? MineralId { get; set; }
        public string MineralName { get; set; }

        public int? MineralScheduleId { get; set; }
        public string MineralScheduleName { get; set; }
        public int? MineralSchedulePartId { get; set; }
        public string MineralSchedulePart { get; set; }
        public int? UnitId { get; set; }
        public string UnitName { get; set; }

        public int? RoyaltyRateTypeId { get; set; }
        public string RoyaltyRateType { get; set; }
        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; }

        public int? CalculationTypeId { get; set; }
        public string CalculationValue { get; set; }
        public int? CalculationPaymentTypeId { get; set; }

        public string[] CalcType { get; set; }
        public string[] CalcVal { get; set; }
        public string[] CalcChecked { get; set; }
        public string[] PaymentTypeId1 { get; set; }

        public string RoyaltyRateMappingFilePath { get; set; }
        public int? chk { get; set; }
        public int? LesseeTypeID { get; set; }
        public bool? IsGrantType { get; set; }
        public string CalType { get; set; }
        public string CalValue { get; set; }
        public int? IsApplicable { get; set; }
        public int? PaymentTypeId { get; set; }
        public string PaymentType { get; set; }
        public int? RoyaltyId { get; set; }
        public int? RoyaltyRateID { get; set; }
        public string RoyaltyRate { get; set; }
        public int? ID { get; set; }

        public int? AuctionTypeId { get; set; }
    }
}
