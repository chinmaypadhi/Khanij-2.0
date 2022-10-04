
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace EpassEF
{
   
    public class TransitPassModel
    {
        public string Barcode { get; set; }

        public string BarcodeText { get; set; }
       
        public int Destinationdistrictid { get; set; }
        public string Tpoffline { get; set; }
        public string VechicleNumber { get; set; }
        public string RPTPBulkPermitId { get; set; }
        public string Errormsg { get; set; }
        public string Usertype { get; set; }
        public int? userid { get; set; }
        public int? SrNo { get; set; }
        public int? TransitPassId { get; set; }
        public string TransitPassNumber { get; set; }

        public int? BulkPermitId { get; set; }
        public string BulkPermitNo { get; set; }
        public string SchemeofCoal { get; set; }

        public int? PurchaserConsigneeId { get; set; }
        public string PurchaserConsigneeName { get; set; }
        public int? Lessee_Licensee_Id { get; set; }
        public string Lessee_Licensee_Name { get; set; }
        public int? VillageId { get; set; }
        public string VillageName { get; set; }
        public int? TehsilID { get; set; }
        public string TehsilName { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public decimal? Area { get; set; }
        public DateTime? LeaseValidity_From { get; set; }
        public DateTime? LeaseValidity_To { get; set; }
        public int? MineralId { get; set; }
        public string MineralName { get; set; }
        public int? MineralCategoryId { get; set; }
        public string MineralCategoryName { get; set; }

        public int? MineralGradeId { get; set; }            // on behalf of mineral category
        public string MineralGradeName { get; set; }        // on behalf of mineral category

        public string UnitName { get; set; }
        public string Hindi_UnitName { get; set; }
        public string MineralNature { get; set; }

        public decimal? Mineral_SaleValue { get; set; }
        public string SaleValueOfMineral { get; set; }
        public DateTime? Mineral_DateOfDispatch { get; set; }
        public DateTime SystemDateTime { get; set; }

        public string IssueDateTime { get; set; }
        public string IssueTime { get; set; }

        public int? TransporterId { get; set; }
        public string TransporterName { get; set; }
        public string TransporterMobile { get; set; }
        public string TransporterCHiMMSNo { get; set; }

        public int? TransportationModeId { get; set; }
        public string TransportationMode { get; set; }
        public int? VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleCHiMMSNo { get; set; }
        public int? VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public string DriverName { get; set; }
        public string DriverContactNumber { get; set; }
        public string Mineral_PurchaserName { get; set; }
        public string DONumber { get; set; }
        public string DODate { get; set; }
        public string Mineral_Destination { get; set; }
        public string Remarks { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string RouteName { get; set; }

        public decimal? TareWeight_Qty { get; set; }
        public decimal? GrossWeight_Qty { get; set; }
        public decimal? NetWeight_Qty { get; set; }

        public decimal? TotalQty { get; set; }
        public decimal? RailQty { get; set; }

        public String LeaseFromDate { get; set; }
        public String LeaseToDate { get; set; }
        public String LeaseValidity { get; set; }
        public decimal? Remaining_Qty { get; set; }

        public int? ForwardingNoteID { get; set; }
        public string ForwardingNoteNo { get; set; }
        public string NoteQty { get; set; }

        public decimal? OfflineQty { get; set; }

        public int? RailwayId { get; set; }
        public string AddressofRailwaySliding { get; set; }
        public string DateOfDispach_TP { get; set; }
        public string RailwayZoneName { get; set; }
        public string TPMode { get; set; }
        public string IntTripStatus { get; set; }
        public string TripStatus { get; set; }
        public string TransitPass_Type { get; set; }
        public string TypeOfCoalDispatched { get; set; }

        public string TimeFormat { get; set; }

        public string Hours { get; set; }

        public string Minutes { get; set; }

        public string Seconds { get; set; }

        public string Format { get; set; }

        public string MineralType { get; set; }
        public string IsLowGrade { get; set; }
        public string AreaInHect { get; set; }
        public string Minor_VehicleOwner { get; set; }
        public string Minor_VehicleNumber { get; set; }
        public string Minor_VehicleType { get; set; }
        public string RePrintCount { get; set; }

        [Display(Name = "Attachment")]
        //public HttpPostedFileBase ATTACHMENT { get; set; }
        public String ATTACHMENT_FILE_NAME { get; set; }
        public String ATTACHMENT_FILE_PATH { get; set; }

        [Display(Name = "Number of TP")]
        public string NumberOfTP { get; set; }

        public string NameOfCosignee { get; set; }
        public string AddressOfConsiger { get; set; }
        public string NameofEndUser { get; set; }
        public string AddressofEndUser { get; set; }
        public string EDRMNumber { get; set; }
        public string EDRMDate { get; set; }
        public string EDRMQty { get; set; }
        public string NameofRailway { get; set; }
        public string AddressofRailway { get; set; }
        public string DestinationRailwayName { get; set; }
        public string DestinationRailwayAddress { get; set; }
        public string IsTailingDamLicensee { get; set; }

        public string PurchaserType { get; set; }
        public string PurchaserSubType { get; set; }
        public string PurchaserName { get; set; }
        public string PurchaserContactNumber { get; set; }
        public string VehicleType { get; set; }
        public string UnRegistredVehicleTypeId { get; set; }
        public string UnRegistredWithoutTractorVehicleId { get; set; }
        public string UnRegistredWithoutTractorVehicleOwner { get; set; }
        public string UnRegistredWithTractorVehicleId { get; set; }
        public string UnRegistredWithTractorVehicleOwner { get; set; }

        public string DestinationBlock { get; set; }

    }

    public class ReturnOuputResult
    {
        public string OutputResult { get; set; }
        public Int64 TPID { get; set; }
    }


   
    public class RailwayModel
    {
        public int RailwayID { get; set; }
        public string RailwayName { get; set; }
        public string RailwaySlidingName { get; set; }
        public string Address { get; set; }
    }


    public class UserWiseTPConfigurationViewModel
    {
        public int ID { get; set; } 
        [Required]
        public int DistrictID { get; set; }
       // public string UserName { get; set; } = "";
        public string UserID { get; set; }
        public int TransportationModeID { get; set; } //Road/Road-Rail
        public string TransportationMode { get; set; }//Road/Road-Rail
        public bool CheckStampingValidity { get; set; }//Yes/NO
        public bool IntigrationWithWB { get; set; }//Yes/NO
        public string eTPGenrationMode { get; set; }//Paper/QR/Both
        public int UserTypeID { get; set; }//Lessee/Licensee
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string IpAddress { get; set; }
        public int Chk { get; set; } = 1;
    }

    public class UserWiseTPConfigurationModel
    {
        public int ID { get; set; }
        public string DistrictName { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string TransportationMode { get; set; }//Road/Road-Rail
        public string GenerationMode { get; set; }//Paper/QR/Both
        public bool CheckStampingValidity { get; set; }//Yes/NO
        public bool WBIntegration  { get; set; }//Yes/NO
       
        public string UserType { get; set; }//Lessee/Licensee
     


        public int DistrictID { get; set; } 
        public int UserTypeID { get; set; }//Lessee/Licensee

        public int TransportationModeID { get; set; } //Road/Road-Rail
    }

}