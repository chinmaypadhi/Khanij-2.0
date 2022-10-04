using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
namespace MineralConcessionEF
{
    public class ChekcboxListModel
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public string id { get; set; }
        public bool IsSelected { get; set; }
    }
    
    public class LeaseApplicationModel
    {
        public List<string> doclist { get; set; }
       
        public DataTable DocumentName { get; set; }
        public string PerformanceSecurity_Installment_UploadName { get; set; }
        public string PerformanceSecurity_Installment_UploadPath { get; set; }
        public string Third_Installment_UploadPath { get; set; }
        public string Third_Installment_UploadName { get; set; }
        public string Second_Installment_UploadPath { get; set; }
        public string Second_Installment_UploadName { get; set; }
        public decimal totalPayable { get; set; }
        public string Lands { get; set; }
        public int DocId { get; set; }
        public string DocName { get; set; }

        public IFormFile ExcelKharsa { get; set; }


        public int LesseeLOI { get; set; }
        public List<ChekcboxListModel> TypeOfLand { get; set; }
        //public string SubmissionId { get; set; }       
        public string CategoryOfLicensee { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAs { get; set; }
        public string FirmAs { get; set; }
        public string modeOfGrant { get; set; }
       
        public int? CompanyId { get; set; }

        public string DateOfLOI { get; set; }
       
        public string NameOfApplicant { get; set; }
        
        public string AddressOfApplicant { get; set; }
       
        public string ApplicantMobileNo { get; set; }
        
        public string ApplicantEmailId { get; set; }
      
        public string Designation { get; set; }
        
        //public HttpPostedFileBase PAN_Card { get; set; }
        public string Path_PAN_Card { get; set; }
        public string File_PAN_Card { get; set; }
        public IFormFile PAN_Card_File { get; set; }
        //public HttpPostedFileBase TIN_Card { get; set; }
        public string Path_TIN_Card { get; set; }
        public string File_TIN_Card { get; set; }
        public IFormFile TIN_Card_File { get; set; }
        public string KhasraNo { get; set; }
        public string KhasraNo_FilePath { get; set; }
        public IFormFile KhasraNo_File { get; set; }

        public string ExcelKhasraNo { get; set; }
        public string ExcelKhasraNo_FilePath { get; set; }
       
        public int? VillageID { get; set; }

        public string VillageName { get; set; }
        
        public string BlockForestRange { get; set; }
       
        public int? TehsilID { get; set; }
        public string TehsilName { get; set; }
       
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
       
        public int? StateID { get; set; }
        public string StateName { get; set; }
       
        public string Pincode { get; set; }

        public string GovernmentAs { get; set; }
        public string PrivateAs { get; set; }
       
        public string AreaInHect { get; set; }
        
        //[Required(ErrorMessage = "This field is required")]
        public string TopoSheetNo { get; set; }
        public IFormFile TopoSheetNo_File { get; set; }

        //[Required(ErrorMessage = "Please Upload Coordinates.")]
        public string Coordinates { get; set; }
        public string Coordinates_FilePath { get; set; }
        public IFormFile Coordinates_File { get; set; }
        public string ExcelCoordinates { get; set; }
        public string ExcelCoordinates_FilePath { get; set; }
        
       // public HttpPostedFileBase DemarcationReport { get; set; }
        public string Path_DemarcationReport { get; set; }
        public string File_DemarcationReport { get; set; }
        public IFormFile DemarcationReport_File { get; set; }


        public int? MineralTypeID { get; set; }
        public string MineralTypeName { get; set; }
      
        public int? MineralID { get; set; }

        
        public int? MineralIDCount { get; set; }
        public string MineralName { get; set; }
        public decimal? Reserve { get; set; }

        // New properties
        public string IBM_ReceivingCopy { get; set; }
        public IFormFile IBM_ReceivingFile { get; set; }
        public string PS_BankName { get; set; }
        public string PS_BankGaurrantyNo { get; set; }
        public string PS_BankGuarantyDate { get; set; }
        public string PS_ValidityUpto { get; set; }

        public string MP_ApprovalOrderNo { get; set; }
        public string MP_ValidFrom { get; set; }
        public string MP_ValidUpto { get; set; }

        public string EC_OrderDate { get; set; }
        public string EC_OrderNo { get; set; }
        public float EC_AnnualCapacity { get; set; }
        public string EC_ValidUpto { get; set; }

        public string CTE_OrderDate { get; set; }
        public string CTE_OrderNo { get; set; }
        public string CTE_ValidUpto { get; set; }

        public string CTO_OrderDate { get; set; }
        public string CTO_OrderNo { get; set; }

        public string FC_OrderDate { get; set; }
        public string FC_OrderNo { get; set; }


        public int? SubmissionID { get; set; }
        public string MPSOMLetter { get; set; }
        public IFormFile MPSOMLetterFile { get; set; }
        public string ProposedProductionLetter { get; set; }
        public IFormFile ProposedProductionLetterFile { get; set; }
        public string ECLetter { get; set; }
        public IFormFile ECLetterFile { get; set; }
        public string CTELetter { get; set; }
        public IFormFile CTELetterFile { get; set; }
        public string FCLetter { get; set; }
        public IFormFile FCLetterFile { get; set; }
        public string DGPSLetter { get; set; }
        public IFormFile DGPSLetterFile { get; set; }
        public string LandLetter { get; set; }
        public IFormFile LandLetterFile { get; set; }
        public string RevenueLetter { get; set; }
        public IFormFile RevenueLetterFile { get; set; }
        public string GramPanchayatLetter { get; set; }

        public IFormFile GramPanchayatLetterFile { get; set; }
        public string BankGaurrantyLetter { get; set; }
        public IFormFile BankGaurrantyFile { get; set; }
        public int? UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string DateOfPayment { get; set; }
        public string StatusOfPayment { get; set; }
        public string PaymentPaid { get; set; }

        public string GrantOrderCopy { get; set; }
        public string MajorMineralCLGrantOrderCopy { get; set; }
        public string MDPA { get; set; }
        public IFormFile MDPAFile { get; set; }
        public int Status { get; set; }

        public string Third_DateOfPayment { get; set; }
        public string Third_StatusOfPayment { get; set; }
        public string Third_PaymentPaid { get; set; }

        public string LeaseDeedAgreement { get; set; }
        public IFormFile LeaseDeedAgreementFile { get; set; }
        public string WorkingPermission { get; set; }
        public IFormFile WorkingPermissionFile { get; set; }
        public string UserType { get; set; }
        public int? IsView { get; set; }
        public int? ActiveStatus { get; set; }
        public int? TotalSubmitedCountOfStep5 { get; set; }

      
        public int? LeaseTypeId { get; set; }
        public string ClientTransactionID { get; set; }


        public decimal? EVR { get; set; }
        public decimal? FinalPriceOffer { get; set; }
        public decimal? TotalUpfrontPayment { get; set; }
        public decimal? PerformanceSecurity { get; set; }
        public decimal? AuctionMoney { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        public string First_Installment_Amount { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public string First_Installment_ScheduleDate { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public string First_Installment_DateOfDiposite { get; set; }
        //public HttpPostedFileBase First_Installment_Upload { get; set; }
        public string First_Installment_FilePath { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        public string Second_Installment_Amount { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public string Second_Installment_ScheduleDate { get; set; }
        public string Second_Installment_DateOfDiposite { get; set; }
       // public HttpPostedFileBase Second_Installment_Upload { get; set; }
        public string Second_Installment_FilePath { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        public string Third_Installment_Amount { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public string Third_Installment_ScheduleDate { get; set; }
        public string Third_Installment_DateOfDiposite { get; set; }
       // public HttpPostedFileBase Third_Installment_Upload { get; set; }
        public string Third_Installment_FilePath { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        public string PerformanceSecurity_Installment_Amount { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public string PerformanceSecurity_Installment_ScheduleDate { get; set; }
        public string PerformanceSecurity_Installment_SubmissionDate { get; set; }
       // public HttpPostedFileBase PerformanceSecurity_Installment_Upload { get; set; }
        public string PerformanceSecurity_Installment_FilePath { get; set; }

        public decimal? MajorMineral_CL_Reserve { get; set; }
        public decimal? MajorMineral_CL_EVR { get; set; }
        public decimal? MajorMineral_CL_FinalPriceOffer { get; set; }
        public decimal? MajorMineral_CL_PerformanceSecurity_Installment_Amount { get; set; }
        public string MajorMineral_CL_PerformanceSecurity_Installment_ScheduleDate { get; set; }
        public string MajorMineral_CL_PerformanceSecurity_Installment_SubmissionDate { get; set; }
        public string MajorMineral_CL_PerformanceSecurity_Installment_FileName { get; set; }
       // public HttpPostedFileBase MajorMineral_CL_PerformanceSecurity_Installment_Upload { get; set; }
        public string MajorMineral_CL_PerformanceSecurity_Installment__FilePath { get; set; }



        public string AreaGovernmentAs { get; set; }
        public string AreaForestAs { get; set; }
        public string AreaPrivateAs { get; set; }



        public string SubmissionDateMiningPlan { get; set; }
        public string SubmissionDatePerformanceSecurity { get; set; }
        public string ApprovaDateMiningPlan { get; set; }
        public string CTOLetter { get; set; }
        public IFormFile CTOLetterFile { get; set; }
        public string SchemeofProspecting { get; set; }
        public string MajorMineral_CL_FCApprovalLetter { get; set; }
        public string MajorMineral_CL_DGPSReport { get; set; }
        public string MajorMineral_CL_PrivateLand { get; set; }

        #region MajorMineralNonCoalCL
        public string DateofExecution { get; set; }
        public string DocumentofLicenseDeed { get; set; }
        public string DateofPermissionCLArea { get; set; }
        public string DocumentofPermissionofCLArea { get; set; }
        public string DatetofProspectingOperation { get; set; }
        public string DocumentofProspectingOperation { get; set; }
        public string DatetofDrillingOperation { get; set; }
        public string DocumentofDrillingOperation { get; set; }

        public string DateofProgressReport { get; set; }
        public string DateofProgressReport_Field { get; set; }
        public string DateofProgressReport_Upload { get; set; }
        public string DateofAbundanceExpiry { get; set; }
        public string FinalReport { get; set; }
        public string DateofApplication { get; set; }
        public string MLApplication { get; set; }
        public IFormFile MLA { get; set; }
        public string FOR { get; set; }
        public string IsMLCompleted { get; set; }
        public string SpMode { get; set; }
        public string LeaseType { get; set; }
        public string MineralType { get; set; }
        public string WorkingPermissionUploadedOn { get; set; }
        public string MDPAUploadedDate { get; set; }
        public string LeaseDeedUploadedOn { get; set; }
       public IEnumerable<SelectListItem> LOI_StatutoryDocuments { get; set; }
        public List<string> otherdocs { get; set; }
        //#region Payment Code Properties
        //public string PaymentBank { get; set; }
        //public string Pmode { get; set; }
        //public string NetBanking_mode { get; set; }

        //#endregion
        #endregion

        #region Minor Mineral Step1 and Step2 fields
        public string SubmissionDateOfDraft_MiningPlan { get; set; }
        public string SubmissionOfDraftOf_MiningPlanFilePath { get; set; }
        #endregion

        #region Preferred Bidder
        public int SrNo { get; set; }
        public string AuctionNo { get; set; }
        public string AuctionType { get; set; }
        public string PeriodFrom { get; set; }
        public string PeriodTo { get; set; }
        public string BidStart { get; set; }
        public string BidFinal { get; set; }
        public string BlockName { get; set; }
        public string BidUnitId { get; set; }
        public IFormFile BidSheetFile { get; set; }
        public string BidSheetFileName { get; set; }
        public string BidSheetFilePath { get; set; }
        public string Remarks { get; set; }

        #endregion

        public string MiningPlanDueDate { get; set; }
        public string OtherDocumentName { get; set; }
        public DataTable dt { get; set; }
        public string StrStatus { get; set; }

        public bool Revenue { get; set; }
        public bool RevenueForest { get; set; }
        public bool Nistar { get; set; }
        public bool Forest { get; set; }
        public bool Tribal { get; set; }
        public bool NonTribal { get; set; }

      
        public decimal First_Year_PQty { get; set; }

     
        public decimal Second_Year_PQty { get; set; }

      
        public decimal Third_Year_PQty { get; set; }

        
        public decimal Fourth_Year_PQty { get; set; }

       
        public decimal Fifth_Year_PQty { get; set; }


        public string txtRevenue { get; set; }
        public string txtRevenueForest { get; set; }
        public string txtNistar { get; set; }
        public string txtForest { get; set; }
        public string txtTribal { get; set; }
        public string txtNonTribal { get; set; }
        public string DSCResponse { get; set; }
        public string ThirdPaymentDate { get; set; }
        public string IssueDate { get; set; }
        public DataTable RemarksHistory { get; set; }
        public DataTable OtherDocHistory { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[Display(Name = "Location")]
        public string Location { get; set; }

        public string BidderIssuance_Date { get; set; }
        public DataTable Particpantlist { get; set; }
        //Added By Prakash Kumar Sahoo
        public string Participant_List { get; set; }
        public string Enc_Password { get; set; }
    }
    public class PreferredBidder
    {
        #region Preferred Bidder
        public int LesseeLOI { get; set; }
        public string AuctionNo { get; set; }
        public string AuctionType { get; set; }
        public string PeriodFrom { get; set; }
        public string PeriodTo { get; set; }
        public string BidStart { get; set; }
        public string BidFinal { get; set; }
        public string BlockName { get; set; }
        public string BidUnitId { get; set; }
        public IFormFile BidSheetFile { get; set; }
        public string BidSheetFileName { get; set; }
        public string BidSheetFilePath { get; set; }
        public string AreaInHect { get; set; }
        public string LeaseType { get; set; }
        public int? DistrictId { get; set; }
        public int? MineralId { get; set; }
        public DataTable ParticipatesTable { get; set; }
        public string Remarks { get; set; }
        public string DSCResponse { get; set; }
        public string For { get; set; }
        public int Status { get; set; }
        public string Location { get; set; }
        public int? TehsilId { get; set; }
        public int? VillageId { get; set; }
        public int? userid { get; set; }

        public int? Auctiontypeid { get; set; }
        public string  Type { get; set; }

        public int? LeaseTypeID { get; set; }
        public string LeaseTypeName { get; set; }
        public string MineralName { get; set; }
        public string Action { get; set; }
        public int? Stateid { get; set; }
        public string DistrictName { get; set; }
        public string TehsilName { get; set; }
        public string VillageName { get; set; }

        public DataTable Particpantlist { get; set; }
        public string Participant_List { get; set; }
        #endregion
    }
    public class Filedetail
    {

        public string BidSheetFileName { get; set; }
        public string BidSheetFilePath { get; set; }

        public int SrNo { get; set; }
    }
}
