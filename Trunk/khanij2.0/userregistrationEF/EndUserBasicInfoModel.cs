using System;
using System.Collections.Generic;
using System.Text;

namespace userregistrationEF
{
    public class EndUserBasicInfoModel
    {
        public int? EndUserId { get; set; }
        public int? EndUserTypeId { get; set; }
        public string EndUserTypeStatus { get; set; }
        public string Company { get; set; }
        public string Firm { get; set; }
        public string TransactionalID { get; set; }
        public string UserCode { get; set; }
        public int? UserId { get; set; }

        public int? ProfileUserID { get; set; }
        public int? UserTypeId { get; set; }
        public int? RoleId { get; set; }
        public int? IdentityProofId { get; set; }
        public int? RegistrationFeesId { get; set; }

        public decimal? RegistrationFees { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
      
        //[RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Enter alphabets only")]//Allowed only alphabets
        public string ApplicantName { get; set; }

        public string RoleName { get; set; }

        public string StateName { get; set; }
    
        public string PinCode { get; set; }

        public string IdentityProofName { get; set; }
        public string Doc { get; set; }
       // public HttpPostedFileBase Document { get; set; }
        public string DocPath { get; set; }
     
        public string MobileNo { get; set; }
       
        //[EmailAddress(ErrorMessage = "Invalid Email Id")]
       
        public string EMailId { get; set; }
      
        public int? SQuestionId { get; set; }
        public string SQuestion { get; set; }
     
        public string SQAnswer { get; set; }

        public string captcha { get; set; }


        public string EndUserTypeName { get; set; }
        public string EndUserName { get; set; }

        public string CompanyName { get; set; }
        public string BussinessActivity { get; set; }
       
        public string PurposeOfPurchaseMineral { get; set; }
        public string UserType { get; set; }
        public string Designation { get; set; }
        
        public string Address { get; set; }
  
        public string OfficeAddress { get; set; }
        public string IsFieldAddressIsNull { get; set; }
    
        public int? DistrictId { get; set; }
  
        public int? StateId { get; set; }
   
        public string PAN { get; set; }
        public string PANPath { get; set; }
        //[StringLength(15, MinimumLength = 11, ErrorMessage = "Enter at least 11 character")]
        //[RegularExpression(@"^[0-9a-zA-Z]*$", ErrorMessage = "Enter alphabets and number only")]
        public string TINNo { get; set; }
        public string ExciseRegNo { get; set; }

        //[StringLength(15, MinimumLength = 15, ErrorMessage = "Enter at least 15 character")]
        //[RegularExpression(@"^[0-9a-zA-Z]*$", ErrorMessage = "Enter alphabets and number only")]
        public string GSTNO { get; set; }
        public bool IsSMS { get; set; }
        public bool IsMailed { get; set; }
        public DateTime IsMailedDateTime { get; set; }
        public DateTime IsSMSDate { get; set; }
        public int? Status { get; set; }

        public bool? ActiveStatus { get; set; }
        public bool? IsDelete { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }

        public int? MineralId { get; set; }
        public string MineralName { get; set; }
        public string MineralIdList { get; set; }

        public string MineralTypeName { get; set; }

        // [Required(ErrorMessage = "Select Mineral")]
       // public List<MineralAssignment> MineralCount { get; set; }

        public string MineralCount { get; set; }
        public class MineralAssignment
        {
            public int? Value { get; set; }
        }
        public int? MineralTypeId { get; set; }

        public List<MineralTypeAssignment> MineralTypeCount { get; set; }
        public class MineralTypeAssignment
        {
            public int? Value { get; set; }
        }

        public string MineralFormName { get; set; }
        public string MineralFormIdList { get; set; }
    
        public List<int?> MineralFormCount { get; set; }

        public string MineralGradeName { get; set; }
        public string MineralGradeIdList { get; set; }
       
        public List<int?> MineralGradeCount { get; set; }

        //[Required(ErrorMessage = "Aadhaar Card Number required")]
        public string AadhaarNumber { get; set; } 
        public string ChallanDate { get; set; }
        public string ChallanNumber { get; set; }

        public int? PaymentMode { get; set; }
        public string PaymentBank { get; set; }
        public string RegistrationNumber { get; set; }
        public string OutsideState { get; set; }
        public string NatureOfBusiness { get; set; }
        public bool OutSide_State { get; set; }
        public string MineralUse { get; set; }
        public string VerifyOTP { get; set; }
      
        public string DispatchDate { get; set; }
   
        public string DispatchNo { get; set; }
        public string DispatchFileName { get; set; }
        public string DispatchFilePath { get; set; }
        public string DispatchDateValidUpto { get; set; }
        public string DispatchStatus { get; set; }

        public string CaptiveStock { get; set; }
        public int DispatchId { get; set; }
        public string HidDispatchUpload { get; set; }
       // public HttpPostedFileBase DispatchUpload { get; set; }
     
        public int? EUPTypeId { get; set; }
        public string EUPType { get; set; }
        public string EUP_Type { get; set; }

        // public HttpPostedFileBase Aadhaar_UPLOAD { get; set; }
        public string Aadhaar_FILE_PATH { get; set; }
        public string Aadhaar_FILE_NAME { get; set; }

        //[Display(Name = "PAN Card")]
       // [Required(ErrorMessage = "PAN Card is required")]
        //public HttpPostedFileBase PAN_UPLOAD { get; set; }
        public string PAN_FILE_PATH { get; set; }
        public string PAN_FILE_NAME { get; set; }

       // [Display(Name = "Document for Tin")]
       // public HttpPostedFileBase TIN_UPLOAD { get; set; }
        public string TIN_FILE_PATH { get; set; }
        public string TIN_FILE_NAME { get; set; }

       // [Display(Name = "Document for GST")]
       // public HttpPostedFileBase GST_UPLOAD { get; set; }
        public string GST_FILE_PATH { get; set; }
        public string GST_FILE_NAME { get; set; }

    
       // public HttpPostedFileBase CTO_UPLOAD { get; set; }
        public string CTO_FILE_PATH { get; set; }
        public string CTO_FILE_NAME { get; set; }

      
      //  public HttpPostedFileBase ProductionCertificate_UPLOAD { get; set; }
        public string ProductionCertificate_FILE_PATH { get; set; }
        public string ProductionCertificate_FILE_NAME { get; set; }

       
       // public HttpPostedFileBase ElectricityBill_UPLOAD { get; set; }
        public string ElectricityBill_FILE_PATH { get; set; }
        public string ElectricityBill_FILE_NAME { get; set; }

       
       // public HttpPostedFileBase RegistrationCopy_UPLOAD { get; set; }
        public string RegistrationCopy_FILE_PATH { get; set; }
        public string RegistrationCopy_FILE_NAME { get; set; }

       
        public string CTOApprovalNumber { get; set; }

       
        public DateTime CTOOrderDate { get; set; }

       
        public DateTime CTOValidityFrom { get; set; }

     
        public DateTime CTOValidityTo { get; set; }

        public string RegistrationNo { get; set; }
        public int Is_Existing { get; set; }
        public int Is_Approved { get; set; }

        public string ApprovalStatus { get; set; }
        public string DistrictName { get; set; }

        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string Remarks { get; set; }
        public string Remarks1 { get; set; }
        public DateTime? VerificationDate { get; set; }

        public string DSCResponse { get; set; }



        public int? StateId_O { get; set; }
        public string StateName_O { get; set; }

     
        public int? DistrictId_O { get; set; }
        
        public string DistrictName_O { get; set; }

   
        public string PinCode_O { get; set; }

        public string Other_IndustryType { get; set; }
        public string IBMRegistrationNo { get; set; }
        public string CTOOrderDate_str { get; set; }
        public string CTOValidityFrom_str { get; set; }
        public string CTOValidityTo_str { get; set; }
        public string AadhaarNo { get; set; }
        public string Pop_Mineral { get; set; }

        public decimal Latitude { get; set; }
        public decimal longitude { get; set; }
    }
}
