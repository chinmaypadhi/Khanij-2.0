using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationEF
{
    public class TransporterModel
    {
        #region UserMaster field
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public string ApplicantName { get; set; }
       
        public string Address { get; set; }
        public int? UserTypeId { get; set; }
        public string UserType { get; set; }
        public int? RoleId { get; set; }
      
        public int? DistrictId { get; set; }
        //[Required(ErrorMessage = "Select district")]
        public string DistrictName { get; set; }

       
        public int? StateId { get; set; }
        public string StateName { get; set; }

        public int? RegionalID { get; set; }
        public string RegionalName { get; set; }

        public string PinCode { get; set; }
        public int? IdentityProofId { get; set; }
        public string IdentityProofName { get; set; }
        public string Doc { get; set; }

        //[Required(ErrorMessage = "Upload Challan Copy")]
       // public HttpPostedFileBase Document { get; set; }
        public string DocPath { get; set; } 
        public string MobileNo { get; set; }

      
        public int? SQuestionId { get; set; }
        public string SQuestion { get; set; }
        
        public string QAnswer { get; set; }
        public string captcha { get; set; }
        #endregion

        #region Payment fields
        public string TransactionalID { get; set; }
        public decimal? RegistrationFees { get; set; }

       
        public string ChallanDate { get; set; }

        //[Required(ErrorMessage = "Challan Number is required")]
        public string ChallanNumber { get; set; }

        #endregion

        public int? TransporterId { get; set; }
        public int? TransporterTypeId { get; set; }
        public string TransporterTypeStatus { get; set; }
    
        public string TransporterName { get; set; }

        public string CompanyName { get; set; }

        public int? MobileNumber { get; set; }
      

        
        public string EmailID { get; set; }
      
        public string PAN { get; set; }
        public string PANPath { get; set; }

     
        public string TINNo { get; set; }

       
        public string GSTNo { get; set; }

       
        public string STaxRegNo { get; set; }
        public string STARegNo { get; set; }
        public DateTime? STAValidDate { get; set; }
        public string STAPath { get; set; }
        public bool? IsVehicleOwner { get; set; }
        public string RegNo { get; set; }

        public int? RegistrationFeesId { get; set; }
        public decimal? RegFees { get; set; }
        public decimal? VehicleRegFees { get; set; }

        public bool? IsSMS { get; set; }
        public bool? IsMailed { get; set; }
        public bool? ActiveStatus { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public string Status { get; set; }

        public string Company { get; set; }
        public string Firm { get; set; } 
        public string SQAnswer { get; set; }
        public string UserCode { get; set; }

        public string TotalVehiclesPayment { get; set; }
        public int VehicleCount { get; set; }
        public string AadhaarNumber { get; set; }
        public string AadhaarNo{ get; set; }

        public string PaymentMode { get; set; }
        public string PaymentBank { get; set; }
        public string RegistrationNumber { get; set; }
        public string VerifyOTP { get; set; }
    }
}
