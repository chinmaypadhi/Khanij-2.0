using System; 
using Microsoft.AspNetCore.Http;
namespace userregistrationEF
{
   public class Vehicle
    {
        public int? VehicleID { get; set; }
        public bool? IsPaymentDone { get; set; } 
        public string VehicleNumber { get; set; } 
        public int? RegistrationFeesId { get; set; }
        public decimal? RegistraionFees { get; set; } 
        public decimal? RegistrationFees { get; set; }

        public int? VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; } 

        public decimal? CarryingCapacity { get; set; } 
        public decimal? MaxNetWeight { get; set; } 
        public string RCBookNumber { get; set; } 
        public int? IsGPSDevice { get; set; } 
        public string GPSDeviceID { get; set; }

        
        public int? UnitId1 { get; set; }
        public int? UnitId2 { get; set; }
        public string UnitName { get; set; }

        public int? AddedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? UpdatedOn { get; set; } 
        public bool? ActiveStatus { get; set; }
        public bool? IsDelete { get; set; }
        public int? UserLoginID { get; set; } 
        public int? SrNo { get; set; }
        public string ValidityMsg { get; set; }
        public string IsVehiclePaymentRenew { get; set; }
        
        public string CarryingCapacity_UnitName { get; set; }
        public string FlagType { get; set; }
        public string ExpiryType { get; set; } 
        public int? VehiclePaymentStatus { get; set; }
        public string PaymentReqID { get; set; } 
        public string IsGPSDeviceOrNot { get; set; }
        public string IsOutsideOrNot { get; set; }
        public string VehicleRegistrationNumber { get; set; } 
        public string VehicleValidFromDate { get; set; }
        public string VehicleValidToDate { get; set; }
        public string NoOfPaymentCount { get; set; }
        public string CurrentOwner { get; set; }
        public string PreviousOwner { get; set; } 
        public string RcFile_Name { get; set; }
        public string RcFile_Path { get; set; } 
        public string PermitFile_Name { get; set; }
        public string PermitFile_Path { get; set; }
        public int? PaymentStatus { get; set; }
        public int? CarryingCapacity_UnitId { get; set; }
        public int? UnitID { get; set; }
        public int? Check { get; set; }
        public string RegistrationNumber { get; set; }
        public string GPSID { get; set; }
        public string Type { get; set; }
        public string BankName { get; set; }
    }

    public class VehicleCreateModel: Vehicle
    {
        public IFormFile RCBook { get; set; }
        public IFormFile PermitCopy { get; set; }
    }
}
