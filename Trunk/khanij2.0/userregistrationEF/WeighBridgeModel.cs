using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class AddWeighBridgeModel
    {
        public int? ID { get; set; }
        public int? WeighBridgeID { get; set; }
        [Required(ErrorMessage = "Please Enter WeighBridge Name")]
        public string WeighBridgeName { get; set; }
        public int? UserID { get; set; }
        public string UserType { get; set; }
        [Required(ErrorMessage = "Please Enter Supervisor Name")]
        public string SupervisorName { get; set; }
        [Required(ErrorMessage = "Please Enter Supervisor Contact")]
        public string SupervisorContact { get; set; }
        [Required(ErrorMessage = "Please Select WeighBridge Make")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select WeighBridge Make")]
        public int? MakeID { get; set; }
        [Required(ErrorMessage = "Please Select WeightBridge Model")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select WeighBridge Model")]
        public int? ModelID { get; set; }
        [Required(ErrorMessage = "Please Enter Model Baut Rate")]
        public string ModelBaudRate { get; set; }
        [Required(ErrorMessage = "Please Enter Data Bit")]
        public string DataBit { get; set; }
        [Required(ErrorMessage = "Please Enter Stop Bit")]
        public string StopBit { get; set; }
        [Required(ErrorMessage = "Please Enter Parity")]
        public string Parity { get; set; }
        [Required(ErrorMessage = "Please Enter Hyper terminal Reading")]
        public string HyperterminalReading { get; set; }
        [Required(ErrorMessage = "Please Enter WeightBridge Capacity")]
        public string Capacity { get; set; }
        [Required(ErrorMessage = "Please Select Land Area Type")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Land Area Type")]
        public int? LandAreaTypeID { get; set; }
        [Required(ErrorMessage = "Please Enter Area of Land")]
        public string AreaofLand { get; set; }
        public string District { get; set; }
        [Required(ErrorMessage = "Please Select Location")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Please Enter Lattitude1")]
        public string Lat1 { get; set; }
        [Required(ErrorMessage = "Please Enter Longitude1")]
        public string Lon1 { get; set; }
        [Required(ErrorMessage = "Please Enter Lattitude2")]
        public string Lat2 { get; set; }
        [Required(ErrorMessage = "Please Enter Longitude2")]
        public string Lon2 { get; set; }
        [Required(ErrorMessage = "Please Enter Lattitude3")]
        public string Lat3 { get; set; }
        [Required(ErrorMessage = "Please Enter Longitude3")]
        public string Lon3 { get; set; }
        [Required(ErrorMessage = "Please Enter Lattitude4")]
        public string Lat4 { get; set; }
        [Required(ErrorMessage = "Please Enter Longitude4")]
        public string Lon4 { get; set; }
        public string SitePlanFile { get; set; }
        public IFormFile SitePlanCopy { get; set; }
        public bool ElectricityAvailablity { get; set; }
        public bool InternetAvailability { get; set; }
        [Required(ErrorMessage = "Please Select WeighBridge Type")]
        public string WeighBridgeType { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public IFormFile StampCopy { get; set; }
        
        public string StampCopyFilePath { get; set; }
        [Required(ErrorMessage = "Please Enter StampValid from")]
        public DateTime StampValidFrom { get; set; }
        [Required(ErrorMessage = "Please Enter StampValid To")]
        public DateTime StampValidTo { get; set; }
        public string Remarks { get; set; }

    }
    public class ViewWeighBridgeModel
    {
        public int? WeighBridgeID { get; set; }
        public string RenewApplicationNo { get; set; }
        public string WeighBridgeName { get; set; }
        public int? UserID { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorContact { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ModelBaudRate { get; set; }
        public string DataBit { get; set; }
        public string StopBit { get; set; }
        public string Parity { get; set; }
        public string HyperterminalReading { get; set; }
        public string Capacity { get; set; }
        public string LandAreaType { get; set; }
        public string AreaofLand { get; set; }
        public string Location { get; set; }
        public string District { get; set; }
        public string SitePlanFile { get; set; }
        public bool ElectricityAvailablity { get; set; }
        public bool InternetAvailability { get; set; }
        public string StampCopyFilePath { get; set; }
        public DateTime StampValidFrom { get; set; }
        public DateTime StampValidTo { get; set; }
        public string Lat1 { get; set; }
        public string Lon1 { get; set; }
        public string Lat2 { get; set; }
        public string Lon2 { get; set; }
        public string Lat3 { get; set; }
        public string Lon3 { get; set; }
        public string Lat4 { get; set; }
        public string Lon4 { get; set; }
        public string ApplicationNo { get; set; }
        public string ApplicantName { get; set; }
        public string UserCode { get; set; }
        public string UserType { get; set; }
        public string WeighBridgeType { get; set; }
        public string Status { get; set; }
        public string StatusDescription { get; set; }
        public string Address { get; set; }
        public DateTime AppliedDate { get; set; }
        public DateTime ApprovedOn { get; set; }
        public string ApproveType { get; set; }
        public IFormFile ApprovalOrderFile { get; set; }
        public string ApprovalOrderFilePath { get; set; }
        public string ApproveRemarks { get; set; }
        public string Remarks { get; set; }
        public bool IsRenewal { get; set; }
        //Work flow changes
        public int ActivityId { get; set; }  
        public string Text { get; set; }  
        public int Value { get; set; }  
        
    }
    public class AddWeighBridgeRenewal
    {
        public int? WeighBridgeID { get; set; }
        public int? UserID { get; set; }
        public IFormFile StampCopy { get; set; }
        public string StampCopyFilePath { get; set; }
        public DateTime StampValidFrom { get; set; }
        public DateTime StampValidTo { get; set; }
        public string Remarks { get; set; }
    }
    public class AddIndependentWeighBridgeModel
    {
        public string WeighBridgeName { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorContact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public int? MakeID { get; set; }
        public int? ModelID { get; set; }
        public string ModelBaudRate { get; set; }
        public string DataBit { get; set; }
        public string StopBit { get; set; }
        public string Parity { get; set; }
        public string HyperterminalReading { get; set; }
        public string Capacity { get; set; }
        public int? LandAreaTypeID { get; set; }
        public string AreaofLand { get; set; }
        public string District { get; set; }
        public int? DistrictID { get; set; }
        public string Location { get; set; }
        public string Lat1 { get; set; }
        public string Lon1 { get; set; }
        public string Lat2 { get; set; }
        public string Lon2 { get; set; }
        public string Lat3 { get; set; }
        public string Lon3 { get; set; }
        public string Lat4 { get; set; }
        public string Lon4 { get; set; }
        public bool ElectricityAvailablity { get; set; }
        public bool InternetAvailability { get; set; }
        public string WeighBridgeType { get; set; }
        public IFormFile StampCopy { get; set; }
        public string StampCopyFilePath { get; set; }
        public DateTime StampValidFrom { get; set; }
        public DateTime StampValidTo { get; set; }
        public int? UserID { get; set; }
        public string UserType { get; set; }

    }
    public class ViewIndependentUserDetailModel
    {
        public string ApplicationNo { get; set; }
        public string SupervisorName { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string SupervisorContact { get; set; }
    }
}
