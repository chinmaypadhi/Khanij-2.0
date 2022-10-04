using System;
using System.Collections.Generic;
using System.Text;

namespace userregistrationEF
{
    public class TransporterModel
    {
        public TransporterModel()
        {
            this.UserId = 0;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.ApplicantName = string.Empty;
            this.Address = string.Empty;
            this.UserTypeId = 0;
            this.UserType = string.Empty;
            this.RoleId = 0;
            this.DistrictId = 0;
            this.DistrictName = string.Empty;
            this.StateId = 0;
            this.StateName = string.Empty;
            this.RegionalID = 0;
            this.RegionalName = string.Empty;
            this.PinCode = string.Empty;
            this.IdentityProofId = 0;
            this.IdentityProofName = string.Empty;
            this.Doc = string.Empty;
            this.DocPath = string.Empty;
            this.MobileNo = string.Empty;
            this.SQuestionId = 0;
            this.SQuestion = string.Empty;
            this.QAnswer = string.Empty;
            this.captcha = string.Empty;
            this.TransactionalID = string.Empty;
            this.RegistrationFees = 0;
            this.ChallanDate = string.Empty;
            this.ChallanNumber = string.Empty;
            this.TransporterId = 0;
            this.TransporterTypeId = 0;
            this.TransporterTypeStatus = string.Empty;
            this.TransporterName = string.Empty;
            this.CompanyName = string.Empty;
            this.MobileNumber = 0;
            this.EmailID = string.Empty;
            this.PAN = string.Empty;
            this.PANPath = string.Empty;
            this.TINNo = string.Empty;
            this.GSTNo = string.Empty;
            this.STaxRegNo = string.Empty;
            this.STARegNo = string.Empty;
            this.STAValidDate = DateTime.Now;
            this.STAPath = string.Empty;
            this.IsVehicleOwner = false;
            this.RegNo = string.Empty;
            this.RegistrationFeesId = 0;
            this.RegFees = 0;
            this.VehicleRegFees = 0;
            this.IsSMS = false;
            this.IsMailed = false;
            this.ActiveStatus = false;
            this.AddedBy = 0;
            this.AddedOn = DateTime.Now;
            this.UpdatedBy = 0;
            this.UpdatedOn = DateTime.Now;
            this.IsDelete = false;
            this.IsActive = false;
            this.Status = string.Empty;
            this.Company = string.Empty;
            this.Firm = string.Empty;
            this.SQAnswer = string.Empty;
            this.UserCode = string.Empty;
            this.TotalVehiclesPayment = string.Empty;
            this.VehicleCount = 0;
            this.AadhaarNumber = string.Empty;
            this.AadhaarNo = string.Empty;
            this.PaymentMode = string.Empty;
            this.PaymentBank = string.Empty;
            this.RegistrationNumber = string.Empty;
            this.VerifyOTP = string.Empty;
        }
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
        public string AadhaarNo { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentBank { get; set; }
        public string RegistrationNumber { get; set; }
        public string VerifyOTP { get; set; }
    }
}
