using System;
using System.Collections.Generic;
using System.Text;

namespace EpassEF
{
    public class ReturnOuputResultRPTP
    {
        public string OutputResult { get; set; }
        public Int64 RPTPID { get; set; }
    }
    public class RPTPModel
    {
        public int Tpoffline { get; set; }
        public int? RoyaltyPaidTransitPassId { get; set; }
        public string RoyaltyPaidTransitPassNo { get; set; }
        
        public int? ForwardingNoteID { get; set; }
        public string ForwardingNote { get; set; }
        public string NoteQty { get; set; }

        
        public string BulkPermitId { get; set; }
       
        public int? PurchaserConsigneeId { get; set; }
        public int? UserId { get; set; }
        public int? MineralTypeId { get; set; }
        public int? MineralGradeId { get; set; }
       
        public DateTime? DateOfDispatche { get; set; }

        public string IssueDateTimeTp { get; set; }

        public int? ModeOfTransportationId { get; set; }
        public int? CarrierOwnerId { get; set; }
        public int? CarrierNo { get; set; }
        //[Required(ErrorMessage = "Enter Carrier Driver")]
        public string NameOfCarrierDriver { get; set; }
        //[Required(ErrorMessage = "Enter Tare Weight")]
        public decimal? TareWeight { get; set; }
        //[Required(ErrorMessage = "Enter Gross Weight")]
        public decimal? GrossWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public string Remark { get; set; }
        public string Address { get; set; }
        public int? ApprovalStatus { get; set; }
        public int? ApprovedBy { get; set; }
        public decimal? ApprovedQty { get; set; }
        public int? UserLoginId { get; set; }

        public string DriverContactNumber { get; set; }

        public string MineralName { get; set; }
        public string MineralGrade { get; set; }
        public int? Route { get; set; }
        public string TransportationMode { get; set; }
        public int? ActiveStatus { get; set; }
        public string PurchaserConsigneeName { get; set; }
        public string MineralTypeName { get; set; }
        public string TransportationModeName { get; set; }
        public string Destination { get; set; }
        public string NameOfCarrierOwner { get; set; }
        public DateTime AddedOn { get; set; }

        public decimal? TotalQty { get; set; }
        public decimal? RailQty { get; set; }

        public int? RailwayId { get; set; }
        public string AddressofRailwaySliding { get; set; }
        public string NameofRailwaySlidingName { get; set; }
        public string RailwayZoneName { get; set; }

        //[Required(ErrorMessage = "Select Carrier Owner")]
        public int? TransporterId { get; set; }
        //[Required(ErrorMessage = "Select Carrier No.")]
        public int? VehicleId { get; set; }
        public string VehicleCHiMMSNo { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public decimal? MineralSaleValue { get; set; }
        //[Required(ErrorMessage = "Enter Particular Of Licensee")]
        public string ParticularOfLicensee { get; set; }
        public string EndUserName { get; set; }

        public string RouteName { get; set; }
        public string VillageName { get; set; }
        public string TehsilName { get; set; }
        public string DistrictName { get; set; }
        public string BulkPermitNo { get; set; }
        public string AddressOfLicenseHolder { get; set; }
        public string UnitName { get; set; }
        public decimal? Remaining_Qty { get; set; }
        public string ApplicantName { get; set; }
        public string DateOfDispatcheString { get; set; }

        public string Minor_VehicleOwner { get; set; }
        public string Minor_VehicleNumber { get; set; }
       
        public int? Minor_VehicleTypeId { get; set; }
        public string Minor_VehicleType { get; set; }
        public string RePrintCount { get; set; }

        public DateTime SystemDateTime { get; set; }

        public int? VehicleTypeId { get; set; }
        public string Mineral_PurchaserName { get; set; }
        public int? DistrictId { get; set; }
        public string PurchaserType { get; set; }
        public string PurchaserSubType { get; set; }
        public string PurchaserName { get; set; }
        public string PurchaserContactNumber { get; set; }
        //public string VehicleType { get; set; }
        public string UnRegistredVehicleTypeId { get; set; }
        public string UnRegistredWithoutTractorVehicleId { get; set; }
        public string UnRegistredWithoutTractorVehicleOwner { get; set; }
        public string UnRegistredWithTractorVehicleId { get; set; }
        public string UnRegistredWithTractorVehicleOwner { get; set; }
        public string DestinationBlock { get; set; }
    }

    
}
