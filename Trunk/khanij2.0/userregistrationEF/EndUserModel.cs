using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
namespace userregistrationEF
{
    public class EndUserModel
    {
        public IFormFile AAdharDocument { get; set; }
        public IFormFile PanDocument { get; set; }
        public IFormFile TinDocument { get; set; }
        public IFormFile GstDocument { get; set; }
        public IFormFile RcopyDocument { get; set; }
        public IFormFile AffitDocument { get; set; }
        public IFormFile EbillDocument { get; set; }
        public IFormFile CTODocument { get; set; }

        public int? EndUserId { get; set; }
        public int? ProfileUserID { get; set; }
        public int? EndUserTypeId { get; set; }
        public string EndUserTypeStatus { get; set; }
        public string Company { get; set; }
        public string Firm { get; set; }
        public string TransactionalID { get; set; }
        public string UserCode { get; set; }
        public int? UserId { get; set; }
        public int? UserTypeId { get; set; }
        public int? RoleId { get; set; }
        public int? IdentityProofId { get; set; }
        public int? RegistrationFeesId { get; set; }

        public decimal? RegistrationFees { get; set; }
        public decimal? RegFees { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        //[RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Enter alphabets only")]//Allowed only alphabets
        public string ApplicantName { get; set; }

        public string RoleName { get; set; }


        public string IdentityProofName { get; set; }
        public string Doc { get; set; }
        //public string Document { get; set; }
        public string DocPath { get; set; }

        public string MobileNo { get; set; }


        public string EMailId { get; set; }

        public int? SQuestionId { get; set; }

        public int? SecurityQueID { get; set; }
        public string SQuestion { get; set; }
        public string SecurityQue { get; set; }

        public string SQAnswer { get; set; }
        public string SQAns { get; set; }
        public string QAnswer { get; set; }

        public string captcha { get; set; }
        public string SrNo { get; set; }


        public string EndUserTypeName { get; set; }
        public string EndUserName { get; set; }

        public string CompanyName { get; set; }
        public string BussinessActivity { get; set; }
        //[Required(ErrorMessage = "Purpose required")]
        public string PurposeOfPurchaseMineral { get; set; }

        public string Pop_Mineral { get; set; }
        public string UserType { get; set; }
        public string Designation { get; set; }
        //[Required(ErrorMessage = "Plant Address required")]
        public string Address { get; set; }

        public string OfficeAddress { get; set; }
        public string IsFieldAddressIsNull { get; set; }


        public string PAN { get; set; }
        public string PANPath { get; set; }
        //[StringLength(15, MinimumLength = 11, ErrorMessage = "Enter at least 11 character")]
        //[RegularExpression(@"^[0-9a-zA-Z]*$", ErrorMessage = "Enter alphabets and number only")]
        public string TINNo { get; set; }
        public string ExciseRegNo { get; set; }

        //[StringLength(15, MinimumLength = 15, ErrorMessage = "Enter at least 15 character")]
        //[RegularExpression(@"^[0-9a-zA-Z]*$", ErrorMessage = "Enter alphabets and number only")]
        public string GSTNO { get; set; }
        public bool? IsSMS { get; set; }
        public bool? IsMailed { get; set; }
        public DateTime? IsMailedDateTime { get; set; }
        public DateTime? IsSMSDate { get; set; }
        //public int? Status { get; set; }

        public bool? ActiveStatus { get; set; }
        public bool? IsDelete { get; set; }
        //public int? AddedBy { get; set; }

        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string MineralId { get; set; }
        public string MineralFormId { get; set; }

        public string MineralName { get; set; }

        public int? MineralCnt { get; set; }
        public int? MineralFormCnt { get; set; }
        public int? MineralGradeCnt { get; set; }

        public string MineralIdList { get; set; }

        public string MineralTypeName { get; set; }

        // [Required(ErrorMessage = "Select Mineral")]
        //public List<MineralAssignment> MineralCount { get; set; }
        public class MineralAssignment
        {
            public int? Value { get; set; }
        }
        public int? MineralTypeId { get; set; }

        //public List<MineralTypeAssignment> MineralTypeCount { get; set; }
        public class MineralTypeAssignment
        {
            public int? Value { get; set; }
        }

        public string MineralFormName { get; set; }
        public string MineralFormIdList { get; set; }
        public string MineralNature { get; set; }
        public string MineralNatureId { get; set; }

        //public List<int?> MineralFormCount { get; set; }

        public string MineralGradeName { get; set; }
        public string MineralGradeIdList { get; set; }

        //public List<int?> MineralGradeCount { get; set; }


        public string MineralGradeId { get; set; }
        public string MineralGrade { get; set; }

        //[Required(ErrorMessage = "Aadhaar Card Number required.")]
        public string AadhaarNumber { get; set; }

        public string AadhaarNo { get; set; }
        public string ChallanDate { get; set; }
        public string ChallanNumber { get; set; }

        public int? PaymentMode { get; set; }
        public string PaymentBank { get; set; }
        public string RegistrationNumber { get; set; }
        public string OutsideState { get; set; }

        public string NatureOfBusiness { get; set; }
        public bool OutSide_State { get; set; }
        public string MineralUse { get; set; }
        public string OTP { get; set; }
        public string VerifyOTP { get; set; }

        public string DispatchDate { get; set; }

        public string DispatchNo { get; set; }
        public string DispatchFileName { get; set; }
        public string DispatchFilePath { get; set; }
        public string DispatchDateValidUpto { get; set; }
        public string DispatchStatus { get; set; }
        public string Remarks { get; set; }
        public string CaptiveStock { get; set; }
        public int? DispatchId { get; set; }
        public string HidDispatchUpload { get; set; }
        public string DispatchUpload { get; set; }

        //[Required]
        public int? EUPTypeId { get; set; }
        public string EUPType { get; set; }
        public string EUP_Type { get; set; }


        public string Aadhaar_UPLOAD { get; set; }
        public string Aadhaar_FILE_PATH { get; set; }
        public string Aadhaar_FILE_NAME { get; set; }


        public string PAN_UPLOAD { get; set; }
        public string PAN_FILE_PATH { get; set; }
        public string PAN_FILE_NAME { get; set; }


        public string TIN_UPLOAD { get; set; }
        public string TIN_FILE_PATH { get; set; }
        public string TIN_FILE_NAME { get; set; }


        public string GST_UPLOAD { get; set; }
        public string GST_FILE_PATH { get; set; }
        public string GST_FILE_NAME { get; set; }


        //[Required(ErrorMessage = "CTO (Consent To Operate) Letter is required")]
        public string CTO_UPLOAD { get; set; }
        public string CTO_FILE_PATH { get; set; }
        public string CTO_FILE_NAME { get; set; }



        public string ProductionCertificate_UPLOAD { get; set; }
        public string ProductionCertificate_FILE_PATH { get; set; }
        public string ProductionCertificate_FILE_NAME { get; set; }


        //[Required(ErrorMessage = "Electricity Bill of last 3 months is required")]
        public string ElectricityBill_UPLOAD { get; set; }
        public string ElectricityBill_FILE_PATH { get; set; }
        public string ElectricityBill_FILE_NAME { get; set; }



        public string RegistrationCopy_UPLOAD { get; set; }
        public string RegistrationCopy_FILE_PATH { get; set; }
        public string RegistrationCopy_FILE_NAME { get; set; }


        //[Required(ErrorMessage = "CTO Approval Number is required")]
        public string CTOApprovalNumber { get; set; }


        //[Required(ErrorMessage = "CTO Order Date is required")]
        public string CTOOrderDate { get; set; }


        //[Required(ErrorMessage = "CTO Validity From is required")]
        public string CTOValidityFrom { get; set; }


        //[Required(ErrorMessage = "CTO Validity To is required")]
        public string CTOValidityTo { get; set; }

        public string RegistrationNo { get; set; }
        public int? Is_Existing { get; set; }
        public int? Is_Approved { get; set; }

        public string ApprovalStatus { get; set; }

        public int? Is_Forwarded { get; set; }
        public int? NotificationStatus { get; set; }




        //[Required(ErrorMessage = "Select State")]
        public int? StateId { get; set; }

        public int? OutPutResult { get; set; }
        public string StateName { get; set; }

        //[Required(ErrorMessage = "District Name is required.")]
        public int? DistrictId { get; set; }
        //[Required(ErrorMessage = "District Name is required.")]
        public string DistrictName { get; set; }

        //[Required(ErrorMessage = "Pincode required")]

        //[StringLength(6, MinimumLength = 6, ErrorMessage = "Enter at least 6 character")]
        public string PinCode { get; set; }




        public int? StateId_O { get; set; }
        public string StateName_O { get; set; }


        public int? DistrictId_O { get; set; }

        public string DistrictName_O { get; set; }


        public string PinCode_O { get; set; }

        public string Other_IndustryType { get; set; }
        public string IBMRegistrationNo { get; set; }

        public int? EUP_Id { get; set; }
        public string Type { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
    public class GetIndustryType
    {
        public List<EndUserModel> IndustryType { get; set; }
    }
    public class GetListState
    {
        public List<EndUserModel> ListOfState { get; set; }
    }
}
