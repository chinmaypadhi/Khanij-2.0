using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PermitEF
{
    public class EPermitEF
    {


        public int SRNumber { get; set; }
        public int BulkPermitId { get; set; }

        public string TransactionalID { get; set; }
        public string PaymentReceiptID { get; set; }
        public string BulkPermitNo { get; set; }
        public string ApprovedDateText { get; set; }
        public string MineralName { get; set; }
        public string MineralNature { get; set; }
        public string MineralGradeName { get; set; }
        public decimal? ApprovedQty { get; set; }
        public string UnitName { get; set; }
        public int? ActiveStatus { get; set; }
        public decimal? TCS { get; set; }
        public decimal? Cess { get; set; }
        public decimal? eCess { get; set; }
        public decimal? MonthlyPeriodicAmount { get; set; }
        public int? Payment_Status { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentType { get; set; }
        public string PaymentValue { get; set; }

        public string LesseeName { get; set; }

        public string LesseeAddress { get; set; }
        public string LesseeDistrict { get; set; }

        public string TransitPassNo { get; set; }
        public string TransitPassQty { get; set; }

        public string DemandNoteQty { get; set; }
        public string DemandDate { get; set; }

        public string ChallanNumber { get; set; }
        public string ChallanDate { get; set; }
        public string ChallanCopy { get; set; }
        public string Remarks { get; set; }
    }

    public class ListofLTP
    {
        public string FromDATE { get; set; }
        public string ToDATE { get; set; }
        public int UserID { get; set; }
        public string CreateOn { get; set; }
        public int? LTPPermitId { get; set; }
        public int? SrNo { get; set; }
        public string LTPApplicationNo { get; set; }
        public string LTPPermitNo { get; set; }
        public string ApplicationDate { get; set; }
        public string ApplicantName { get; set; }
        public string MineralName { get; set; }
        public string MineralForm { get; set; }
        public string MineralGrade { get; set; }
        public decimal? ProposedqtybyRailway { get; set; }
        public decimal? qtybyRailway { get; set; }
        
        public decimal? ApprovedqtybyRailway { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string LicenseeCode { get; set; }
        public string ApprovedOn { get; set; }
        public string RejectOn { get; set; }
        public string FromStationSideName { get; set; }
        public string ToStationSideName { get; set; }
        public string Address { get; set; }

        public string Designation { get; set; }
        public string CompanyName { get; set; }
        public string MobileNo { get; set; }
        public string Purpose { get; set; }
        public string DestinationAddress { get; set; }
        public string TransportationRoute { get; set; }
        public string OtherDetails { get; set; }
        public string DetailOfRailwayReceipt { get; set; }
        public string NameofMineralReceipt { get; set; }
        public string DistrictName { get; set; }
        public string LTPFilePath { get; set; }

        public string DSCgeneratedby { get; set; }
        public string GeneratedBy { get; set; }
        public string DSCgeneratedDesgination { get; set; }
        public string GeneratedDesignation { get; set; }
        public int? ExpectedNoOfLtp { get; set; }

        public string TotalPassCount { get; set; }
        public string DispatchQty { get; set; }
        public string ReceivedQty { get; set; }


    }
    public class LTPInfo
    {
        public string UserType { get; set; }
        public int RTPPassID { get; set; }
        public string RTPPassNo { get; set; }
        public string UserLoginId { get; set; }
        public int UserID { get; set; }
        public int UserId { get; set; }
        public int SubUserID { get; set; }
        public string ReceivedFrom { get; set; }
        public int? RTPPassId { get; set; }
        public string RTPPassNumber { get; set; }

        public int? LTPPermitId { get; set; }
        public string LTPApplicationNo { get; set; }
        public string LTPPermitNo { get; set; }
        public int? LicenseId { get; set; }
        public string LicenseName { get; set; }
        public string DesignationName { get; set; }
        public string Designation { get; set; }
        public string MobileNo { get; set; }
        public int? MineralId { get; set; }
        public int? MineralID { get; set; }
        public string MineralName { get; set; }
        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
        public string EmailID { get; set; }
        public decimal? qtybyRailway { get; set; }
        public int? FromRailwaySidingId { get; set; }
        public string FromRailwaySidingName { get; set; }
        //[Required(ErrorMessage = "Please select mineral receiver.")]
        public int? NameoftheRecieptMineralId { get; set; }
        public int? RecipientId { get; set; }
        public string NameoftheRecieptMineral { get; set; }
        public string RecipientName { get; set; }
        public string NameoftheRecieptAddress { get; set; }
        public int? WhereRailwaySidingId { get; set; }
        public string WhereRailwaySidingName { get; set; }
        public string Purpose { get; set; }
        public string DestinationAddress { get; set; }
        public string TransportationRoute { get; set; }
        public string OtherDetails { get; set; }
        public string DetailsofRailwayReciept { get; set; }
        public string Attachment { get; set; }
        public string Address { get; set; }
        public decimal? ApprovedQty { get; set; }
        public int? ActiveStatus { get; set; }
        public int? IsApproved { get; set; }
        public int? IsReject { get; set; }
        public string Remark { get; set; }
        public string BulkPermitNo { get; set; }
        public int? UserTypeId { get; set; }
        public string ForwardingReceiptName { get; set; }
        //[Required(ErrorMessage = "Please Attached Forwarding Note/Indent/Railway Receipt.")]
        public string ForwardingReceiptFilePath { get; set; }
        public string command { get; set; }
        public string DSCResponse { get; set; }
        //[Range(0, 3999)]
        //[Display(Name = "Expected Number Of E-Local Transit Pass")]
        public int? ExpectedNoOfLtp { get; set; }
        public decimal ClosingStock { get; set; }
        public decimal TotalStock { get; set; }
        public decimal ECQuantity { get; set; }
        public int RailwayID { get; set; }
        public string RailwaySlidingName { get; set; }
        public int? DestinationRailwayId { get; set; }
        public int? DestinationRailwayID { get; set; }
        public string DestinationRailwayName { get; set; }

        public string DestinationRailwaySiding { get; set; }
        public string ApplicantName { get; set; }
        public string CORPORATE_DESIGNATION { get; set; }
        public int ToRailwaySidingId { get; set; }
        public string DetailOfRailwayReceipt { get; set; }
        public string NameofMineralReceipt { get; set; }
        public string RTPQuantity { get; set; }
        public int SourceRailwayID { get; set; }
        public string SourceRailwayName { get; set; }
    }
  
    public class LesseePaymentModel
    {
        public string BulkPermitId { get; set; }
        public string PaymentTypeId { get; set; }
        public string PaymentType { get; set; }
        public string MappingValue { get; set; }
        public string TotalPaid { get; set; }
        public string TotalAmount { get; set; }

        public string PayableAmount { get; set; }
        public string ChallanNumber { get; set; }
        public string ChallanDate { get; set; }
        public string Doc { get; set; }
        // public HttpPostedFileBase Document { get; set; }
        public int? PaymentMode { get; set; }
        public string PaymentBank { get; set; }
    }

    public class ePermitPaymentHead
    {
        public int? IsPaymentApplicable { get; set; }
        public string Applicable { get; set; }
        public decimal PaymentPercent { get; set; }
        public int? IsMakePayment { get; set; }
        public string MakePayment { get; set; }
        public int? PaymentToId { get; set; }
        public string PaymentType { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? IsSchedule { get; set; }
        public string ScheduleName { get; set; }
        public int? CalTypeId { get; set; }
        public string CalType { get; set; }
        public int? PayDeptId { get; set; }
        public string PaymentDept { get; set; }
        public int? IsAdjustable { get; set; }
        public string Adjustable { get; set; }
    }
    public class ePermitModel
    {
        //[ModelBinder(BinderType = typeof(ePermitPaymentHead))]
        public int AuctionTypeId { get; set; }
        public int CheckoutStatus { get; set; }
        public decimal UpfrontPaymentDeposited { get; set; }
        public string LastDate { get; set; }
        public decimal PermittedQty { get; set; }
        public int? ScheduleRateId { get; set; }
        public int? PayDeptId { get; set; }
        public string PaymentDept { get; set; }
        public int? PaymentConfigID { get; set; }
        public string FifthDesc { get; set; }
        public string SixthDesc { get; set; }
        public List<ePermitPaymentHead> datatable { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? PaymentToId { get; set; }
        public int? CalTypeId { get; set; }
        public string CalTypeText { get; set; }
        public int? IsPaymentApplicable { get; set; }
        public int? IsMakePayment { get; set; }
        public int? PaymentPercent { get; set; }
        public string PaymentType { get; set; }
        public string Location { get; set; }
        public String CalType { get; set; }
        public int CalculationValue { get; set; }
        public int? IsChecked { get; set; }
        public int? CheckListId { get; set; }
        public string CheckListDescription { get; set; }
       // public List<ChecklistModel> RiderCheckMaster { get; set; }
        public string SelectedRiderList { get; set; }
        public int RiderConfigId { get; set; }
        public int? ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int? SubModuleId { get; set; }
        public string SubModuleName { get; set; }
        public decimal? AddtionalRate { get; set; }
        public string Description { get; set; }
        public int SixthSchId { get; set; }
        public int FifthSchId { get; set; }
        public int IsLeaseExtend { get; set; }
        public string LeaseExtendText { get; set; }
        public int IsPremium { get; set; }
        public int IsCaptive { get; set; }
        public int MLGrantedDate { get; set; }
        public string MLGrantedDateText { get; set; }
        public string CaptiveText { get; set; }
        public int IsAdditionalAmt { get; set; }
        public int IsSchedule { get; set; }
        public string ScheduleText { get; set; }
        public int ScheduleId { get; set; }
        public int IsActive { get; set; }
        public string IsActiveStatus { get; set; }
        public string RiderDescription { get; set; }
        public int RiderValid { get; set; }
        public string MinesTypeName { get; set; }
        public int MinesType { get; set; }
        public int MinesTypeId { get; set; }
        public int Captive { get; set; }
        public int CompanyType { get; set; }
        public int LeaseExtend { get; set; }
        public int AuctionPremium { get; set; }
        public ePermitModel()
        {
            this.RoadDispatch = "0.0";
            this.RoadRailDispatch = "0.0";
            this.InsideRailwaySidingDispatch = "0.0";
            this.ConveyorBeltDispatch = "0.0";
            this.MGROWNWagonDispatch = "0.0";
            this.EndUsePlantinsIdetheLeaseAreaDispatch = "0.0";
            this.RopewayDispatch = "0.0";
            this.UserTotalDispatch = "0.0";
        }
        public string MineralNatureID { get; set; }
        public string MineralNatureName { get; set; }
        public string LeaseTypeID { get; set; }
        public decimal ExtraContent { get; set; }
        public string UserLoginId { get; set; }
        public decimal? Quantity { get; set; }
        public int UserID { get; set; }
        public int SubUserID { get; set; }
        public int SRNumber { get; set; }
        public string StatusText { get; set; }
        public int BulkPermitId { get; set; }
        public string ForwardedDate { get; set; }
        public string BulkPermitNo { get; set; }
        public long? LeaseInfoId { get; set; }
        // [Required(ErrorMessage = "Mineral Category required")]
        public int? MineralTypeId { get; set; }
        //Added by priyabrat Das
        public string MineralTypeName { get; set; }
        public int? MineralId { get; set; }
        public int? MINERAL_ID { get; set; }
        public string MineralName { get; set; }
        //[Required(ErrorMessage = "Mineral Grade required")]
        public string MineralGrade { get; set; }
        public int MineralGradeId { get; set; }
        public int? MINERAL_GRADE_ID { get; set; }
        public int MineralGradeID { get; set; }
        public string MineralGradeName { get; set; }
        public string ActualGrade { get; set; }
        public decimal? ActualGradeName { get; set; }
        public decimal? ProposedQty { get; set; }
        public decimal? ApprovedQty { get; set; }
        public decimal? PayableRoyalty { get; set; }
        public decimal? TCS { get; set; }
        public decimal? Cess { get; set; }
        public decimal? eCess { get; set; }
        public decimal? DMF { get; set; }
        public decimal NMET { get; set; }
        public decimal TotalPayableAmount { get; set; }
        public decimal TotalMiningPayableAmount { get; set; }
        public decimal TotalEVSPayableAmount { get; set; }
        public decimal TotalIncomTaxPayableAmount { get; set; }
        public string MiningOrder { get; set; }
        public string EVSOrder { get; set; }
        public string IncomeTaxOrder { get; set; }

        public int? PaymentStatus { get; set; }
        public string ApprovedDate { get; set; }
        // public DateTime? ApprovedDate { get; set; }
        public string ApprovedDateText { get; set; }
        public int? ActiveStatus { get; set; }
        public string Remark { get; set; }
        public int? IsApproved { get; set; }
        public int? IsReject { get; set; }
        public int? IsMailed { get; set; }
        public DateTime? IsMailedDateTime { get; set; }
        public int? IsSMS { get; set; }
        public DateTime? IsSMSDate { get; set; }
        public DateTime? CreateOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? LesseeId { get; set; }
        public string LesseeName { get; set; }
        public string ApplicantName { get; set; }
        public string LesseeAddress { get; set; }
        public string Address { get; set; }
        public string GrantOrderNo { get; set; }
        public string GrantOrderNumber { get; set; }
        public string DateOfGrant { get; set; }

        //[Required(ErrorMessage = "Unit required")]
        public int? UnitId { get; set; }
        public string UnitName { get; set; }
        public string PeriodOfLeaseFrom { get; set; }
        public string PROSPECTING_VALIDITY_FROM { get; set; }
        public string PeriodOfLeaseTo { get; set; }
        public string PROSPECTING_VALIDITY_TO { get; set; }
        public decimal? RoyaltyRate { get; set; }
        public int? LeaseTypeId { get; set; }
        public string LeaseTypeName { get; set; }
        public string TransactionalID { get; set; }
        public string PaymentReceiptID { get; set; }
        public string EmailId { get; set; }
        public string EMailId { get; set; }
        public string MobileNo { get; set; }
        public string Production { get; set; }
        public string RemainingProduction { get; set; }
        public string ProductionYear { get; set; }
        public string ProductionCap { get; set; }
        public string Dispatch { get; set; }
        public string RunningQty { get; set; }
        public int? VillageId { get; set; }
        public int? VILLAGE_ID { get; set; }
        public string Village { get; set; }
        public string VillageName { get; set; }
        public int? TehsilId { get; set; }
        public int? TehsilID { get; set; }
        public string Tehsil { get; set; }
        public string TehsilName { get; set; }
        public int? DistrictId { get; set; }
        public string District { get; set; }
        public string DistrictName { get; set; }
        public string DistrictCode { get; set; }
        public int? StateID { get; set; }
        public string StateName { get; set; }
        public string Panchayat { get; set; }
        public string GRAM_PANCHAYAT { get; set; }
        public string PoliceStation { get; set; }
        public string POLICE_STATION { get; set; }
        public string PeriodOfLease { get; set; }
        public string command { get; set; }

        public int? IsCoal { get; set; }
        public string DONumber { get; set; }
        public string DODate { get; set; }
        public string TypeOfCoalDispatched { get; set; }
        public string eAuctionTypeId { get; set; }
        public string SchemeOfCoal { get; set; }
        public string ProductionFrom { get; set; }
        public int Production_Id { get; set; }
        public string EAuctionType { get; set; }
        public int? MineralSizeId { get; set; }
        public string MineralSizeName { get; set; }
        public string MineralSize { get; set; }
        public decimal? BasicRate { get; set; }

        public int? isForwarded { get; set; }

        public string TCSPer { get; set; }
        public string CessPer { get; set; }
        public string eCessPer { get; set; }
        public string DMFPer { get; set; }
        public string NMETPer { get; set; }
        public string PayableRoyaltyBase { get; set; }

        public string ChallanNumber { get; set; }
        public string ChallanDate { get; set; }
        //  public HttpPostedFileBase ChallanCopyPath { get; set; }
        public string Doc { get; set; }
        public string ChallanCopyFilePath { get; set; }
        public string ChallanCopyPath { get; set; }
        public string ChallanFileName { get; set; }

        public string MineralNature { get; set; }
        public int? MineralNatureId { get; set; }
        public int? RoyaltyRateID { get; set; }
        public int? PaymentMode { get; set; }
        public string PaymentBank { get; set; }
        public string P_Mode { get; set; }
        public string NetBanking_mode { get; set; }
        public string GeneratedBy { get; set; }
        public string GeneratedDesignation { get; set; }
        public string GeneratedDateTime { get; set; }
        public string GeneratedDSC { get; set; }


        public string TotalECApprovedQty { get; set; }
        public string ECQty { get; set; }
        public string TotalMiningProductionQty { get; set; }
        public string MiningQty { get; set; }
        public string ECValidity { get; set; }
        public string MPValidity { get; set; }
        public string LeaseValidity { get; set; }
        public string TillDateDispatched { get; set; }
        public string TotalDispatched { get; set; }
        public decimal? TillDateDispatchedQty { get; set; }
        public decimal? TillDateBalanceUpfrontPayment { get; set; }
        public decimal? TotalAdjustAmount { get; set; }

        public decimal? PendingQty { get; set; }
        public decimal? AdjustedQty { get; set; }
        public int? IsCompleted { get; set; }
        public string BulkPermitIdList { get; set; }
        public string MergeEPermitCount { get; set; }
        public string MergePermitCount { get; set; }
        public List<ePaymentData> PaymentDetails { get; set; }

        public string DSCLesseeFilePath { get; set; }
        public string DSCDDFilePath { get; set; }
        public string BPLesseeDSCPath { get; set; }
        public string LesseeDSCPath { get; set; }
        public string GrantOrderDate { get; set; }

        public String RoadDispatch { get; set; }
        public String RoadRailDispatch { get; set; }
        public String InsideRailwaySidingDispatch { get; set; }
        public String ConveyorBeltDispatch { get; set; }
        public String MGROWNWagonDispatch { get; set; }
        public String EndUsePlantinsIdetheLeaseAreaDispatch { get; set; }
        public String RopewayDispatch { get; set; }
        public String UserTotalDispatch { get; set; }
        public String MergePermitAmount { get; set; }

        public String AreaName { get; set; }
        public String UserCode { get; set; }

        public decimal? AluminaContent { get; set; }
        public decimal? TinContent { get; set; }
        public int? Total_e_Permit { get; set; }
        public int? Generated_e_Permit { get; set; }

        public int? ISCessAdjusted { get; set; }
        public int? PaymentDone_e_Permit { get; set; }
        public string CalValue { get; set; }
        public int? ISAdjustmentCess { get; set; }

        public string OrderDate { get; set; }
        public string OrderNo { get; set; }
        public string OrderOf { get; set; }
        public int? NoOfRunningPass { get; set; }
        public string IsWalletAdjusted { get; set; }
        public string RoyaltyAndOtherPayable { get; set; }
        public DateTime? FromDATE { get; set; }
        public DateTime? ToDATE { get; set; }
        public string permittype { get; set; }
        public string UserType { get; set; }
        public int? UserTypeId { get; set; }
        public bool IsWallet { get; set; }
        public string AdjustedAmount { get; set; }//To pass adjusted amount manually
        public int RiderType { get; set; }
        public string RiderTypeName { get; set; }
        public string ChangeBiggerEC { get; set; }
        public string ChangeBiggerMining { get; set; }
        public string COMPANY { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CoalPercentage { get; set; }
    }


    public class ePaymentData
    {
        public int OrderNStatus { get; set; }
        public int CheckoutStatus { get; set; }
        public int BulkPaymentId { get; set; }
        public int MappingCount { get; set; }
        public string PaymentTypeID { get; set; }
        public string PaymentType { get; set; }
        public string CalType { get; set; }
        public string CalValue { get; set; }
        public string MappingValue { get; set; }

        public string RoyaltyRate { get; set; }
        public string PayableRoyalty { get; set; }
        public string BasisRate { get; set; }
        public string BasicPrice { get; set; }
        public string TotalPayableAmount { get; set; }
        public string HeadAccount { get; set; }
        public string IsAdjustmentCess { get; set; }

        public string OrderDate { get; set; }
        public string OrderNo { get; set; }
        public string OrderOf { get; set; }

        public bool IsApplicable { get; set; }

        public string TotalAmount { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public decimal WalletAdjustedAmount { get; set; }
        public string IsWalletAdjusted { get; set; }
        public decimal WalletAmount { get; set; }
        public string PaymentHead { get; set; }
        public int Amount { get; set; }
        public string MakepaymentUrl { get; set; }
        public int PayDeptId { get; set; }
        public string PayDeptString { get; set; }
        public int MakePayementId { get; set; }
        public int ApplicableId { get; set; }
        public string TXN_STATUS { get; set; }
        public string CLNT_TXN_REF { get; set; }
        public string TPSL_BANK_CD { get; set; }
        public string TPSL_TXN_ID { get; set; }
        public string AdditionalRoyalty { get; set; }

    }

    public class ListCoalPermit
    {
        public int BulkPermitId { get; set; }
        public string BulkPermitNo { get; set; }
        public string TransactionId { get; set; }
        public string TransactionalID { get; set; }

        public string MineralName { get; set; }
        public string MineralNature { get; set; }
        public string MineralGrade { get; set; }
        public string ProposedQty { get; set; }
        public string Status { get; set; }
        public string ApprovedQty { get; set; }
        public int SrNo { get; set; }
        public string DateOfApplication { get; set; }
        public string DateOfAcceptApplication { get; set; }
        public string Remarks { get; set; }
        public string PaymentId { get; set; }
        public string UserCode { get; set; }
        public string ActiveStatus { get; set; }
        public string SubmitedPayment { get; set; }
        public string MergeEPermitCount { get; set; }
        public string MergePermitCount { get; set; }

        public string DSCLesseeFilePath { get; set; }

    }
    #region RTP
    public class ForwardingNoteModel
    {
        public string Month_Year { get; set; }
        public string UpdateIn { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }
        public string MobileNo { get; set; }
        public string EMailId { get; set; }
        public string FORWARDINGTRANSACATIONID { get; set; }
        public string TransactionalId { get; set; }
        public int SubUserID { get; set; }
        public int RailwayID { get; set; }
        public string GrantOrderDateExpired { get; set; }
        public string RailwaySlidingName { get; set; }
        public string FileName { get; set; }
        public int UserLoginId { get; set; }
        public int? SRNO { get; set; }
        public int? ForwardingNoteId { get; set; }
        public int? FNID { get; set; }
        public int? PassClick { get; set; }
        public int? RTP_Id { get; set; }
        public string ForwardingNoteNumber { get; set; }
        public string ForwardingNote { get; set; }
        public string ForwardingTransacationId { get; set; }
        // [Required(ErrorMessage = "Select e-Permit No.")]
        public int? BulkPermitId { get; set; }
        public string BulkPermitNumber { get; set; }
        public string BulkPermitNo { get; set; }
        // [Required(ErrorMessage = "Select Railway Sliding")]
        public int? RailwayId { get; set; }
        public string RailwaySliding { get; set; }
        public string RailwayAddress { get; set; }
        public string DateOfGrant { get; set; }
        public string PeriodOfLeaseTo { get; set; }
        public int? DestinationRailwayId { get; set; }

        public string DestinationRailwaySiding { get; set; }

        public string EndUserRailwayAddress { get; set; }



        public string AddressofRailwaySliding { get; set; }
        // [DataType(DataType.Date)]
        public DateTime? DateofSubmitedRTPRequest { get; set; }
        public DateTime? CreatedOn { get; set; }
        // [Required(ErrorMessage = "Select Mineral")]
        public int? MineralId { get; set; }
        public int? MineralID { get; set; }
        public string MineralName { get; set; }
        // [Required(ErrorMessage = "Select  Mineral Grade")]
        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
        // [Required(ErrorMessage = "Qty field required")]
        public decimal? ReqQty { get; set; }
        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public decimal? ApprovedQty { get; set; }


        public decimal? PrintAndCloseFNQty { get; set; }

        public int? Status { get; set; }
        public string Request_Status { get; set; }
        public string ViewUserType { get; set; }
        public int? TotalPass { get; set; }
        public int? LicenseeId { get; set; }
        public string Consigner { get; set; }
        public string ApplicantName { get; set; }
        public string Name { get; set; }
        public string Consignee { get; set; }
        public string Address { get; set; }
        public string PurchaserAddress { get; set; }
        public string TripStatusText { get; set; }

        public string TelephoneNo { get; set; }
        public string ContactNumber { get; set; }
        public string GrantOrderNo { get; set; }
        public string GrantOrderNumber { get; set; }

        public string GrantOrderDate { get; set; }
        public string LeaseFrom { get; set; }
        public string PeriodOfLeaseFrom { get; set; }
        public string LeaseTo { get; set; }
        public int? UnitId { get; set; }
        public string UnitName { get; set; }
        //[Required(ErrorMessage = "Select Consignee")]
        public int? EndUserId { get; set; }
        public int? PurchaserId { get; set; }
        public string EndUser { get; set; }
        public string Purchaser { get; set; }
        public string EndUserName { get; set; }
        public string AddressofConsignee { get; set; }
        public string EndAddress { get; set; }
        public int? NoofRTP { get; set; }
        public DateTime? From { get; set; }
        public DateTime? Date_OfExecution { get; set; }
        public DateTime? To { get; set; }
        public string RTP_RequestedOn { get; set; }
        public string Remarks { get; set; }
        public string Remark { get; set; }
        // public decimal? AreaInHect { get; set; }
        public int? isForwarded { get; set; }
        public string UserType { get; set; }
        public string emailid { get; set; }
        public int? RTPQty { get; set; }
        public decimal StockQty { get; set; }
        public decimal IssuedQty { get; set; }
        public decimal PendingQty { get; set; }
        public decimal DispatchedQty { get; set; }
        public decimal? DispatchStatus { get; set; }
        public decimal TotalDispatchedQty { get; set; }
        public decimal IndividualtakenRTP { get; set; }
        public string RTPPassNo { get; set; }
        public int? RoyaltyPaidTransitPassId { get; set; }
        public string PassNo { get; set; }
        public string DateOfDispatch { get; set; }
        public string DateOfDispatche { get; set; }
        public string RPTPIds { get; set; }
        public string ReceivedWeights { get; set; }
        public string LeaseValidity { get; set; }

        public string GeneratedDSC { get; set; }
        public string GeneratedBy { get; set; }
        public string GeneratedDesignation { get; set; }
        public string District { get; set; }
        public string DistrictName { get; set; }
        public string DSCResponse { get; set; }

        public string TransportationMode { get; set; }
        public decimal BalanceQty { get; set; }
        public decimal RTPAppliedQty { get; set; }
        public string TrainNo { get; set; }
        public string RackNo { get; set; }

        public string DSCLesseeFilePath { get; set; }
        public string DSCDDFilePath { get; set; }

        // [Required(ErrorMessage = "Please Enter EDRM Number")]
        public string EDRMNumber { get; set; }
        public string EDRMDate { get; set; }
        //public HttpPostedFileBase EDRM_SCAN_COPY { get; set; }
        public string EDRMCopyPath { get; set; }
        // [Required(ErrorMessage = "Please Enter EDRM Qty")]
        public decimal EDRMQty { get; set; }

        public decimal? RTP_ApprovedQty { get; set; }

        public decimal? OpenRoadTPQty { get; set; }

        public int? CloseTripStatus { get; set; }
        public int? GenerateRTPStatus { get; set; }
        public int? CloseRTPStatus { get; set; }
        public int? TripStatus { get; set; }
        public int? isLable { get; set; }
        public decimal? DiffDisplay { get; set; }
    }
    public class BulkPermitModel
    {
        public int BulkPermitId { get; set; }
        public string BulkPermitNumber { get; set; }
        public string BulkPermitNo { get; set; }
        public decimal StockQty { get; set; }
        public decimal PendingQty { get; set; }
    }
    public class eTransitResult
    {
        public List<BulkPermitModel> PermitLst { get; set; }
        public List<PurchaseConsignee> PurchaseConsigneeLst { get; set; }
        public List<ForwardingNoteModel> RailwaySidingLst { get; set; }
        public List<ForwardingNoteModel> RailwaySidingDestinationLst { get; set; }
        public List<ForwardingNoteModel> PermitPreviewLst { get; set; }
        public List<ForwardingNoteModel> MineralPreviewLst { get; set; }
        public List<ForwardingNoteModel> MineralGradePreviewLst { get; set; }
        public List<ForwardingNoteModel> EndUserPreviewLst { get; set; }

    }
    public class PurchaseConsignee
    {
        public int PurchaserConsigneeId { get; set; }
        public int PCId { get; set; }
        public string PurchaserConsigneeName { get; set; }
        public string ApplicantName { get; set; }
        public string Address { get; set; }
    }
    #endregion
    
    public class ePermitResult
    {
        public List<ePermitModel> MineralNatureLst { get; set; }
        public List<ePermitModel> MineralLst { get; set; }
        public List<ePermitModel> TypeOfCoalLst { get; set; }
        public List<ePermitModel> MineralGradeLst { get; set; }
        public List<ePermitModel> TotalPermitLstByUserID { get; set; }
        public List<ePermitModel> DetailsPermitLstByUserID { get; set; }
        public List<ePermitModel> PermitOperationLst { get; set; }
        public List<ePermitModel> PermitOperationBulkIDLst { get; set; }
        public List<ePaymentData> PermitPaymentLst { get; set; }
        public List<ePermitModel> MergeEPermitLst { get; set; }
        public List<ePermitModel> FifthSchedule { get; set; }
        public List<ePermitModel> SixthSchedule { get; set; }
        public List<ePermitModel> RiderLst { get; set; }
        public List<ePaymentData> WalletLst { get; set; }
        public List<ePermitModel> StateLst { get; set; }
        public List<ePermitModel> DistrictLst { get; set; }
        public List<ePermitModel> UserTypeLst { get; set; }
        public List<ePermitModel> ModuleTypeLst { get; set; }
        public List<ePermitModel> SubModuleTypeLst { get; set; }
        public List<ePermitModel> CheckList { get; set; }
        public List<ePermitModel> UserList { get; set; }
        public List<ePermitModel> LeaseTypeLst { get; set; }
        public List<ePermitModel> PaymnetHeadLst { get; set; }
        public List<ePermitModel> DynamicPaymnetLst { get; set; }
        public List<ePermitModel> PayDeptLst { get; set; }
        public List<ePermitModel> ScheduleLst { get; set; }
        public List<ePermitPaymentHead> PermitPaymentHead { get; set; }
        public List<ePermitModel> GetTaggedDetails { get; set; }
        public List<ePermitModel> GetSECLDODetails { get; set; }
    }
    #region RPTP
    public class LicenseInfoRPTP
    {
        public int UserID { get; set; }
        public int UserId { get; set; }
        public int SubUserID { get; set; }
        public string permittype { get; set; }
        public int? RPTPBulkPermitId { get; set; }
        public int? EndUser_RPTPBulkPermitId { get; set; }
        public string BulkApplicationNo { get; set; }
        public string ApplicantName { get; set; }
        public string LicenseeCode { get; set; }
        public string ApprovedOn { get; set; }
        public int? BultPermitId { get; set; }
        public int? LicenseId { get; set; }
        public string LicenseName { get; set; }
        public string Address { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseDate { get; set; }
        public string Village { get; set; }
        public string VillageName { get; set; }
        public string Tehsil { get; set; }
        public string TehsilName { get; set; }
        public string Panchayat { get; set; }
        public string PoliceStation { get; set; }
        public string State { get; set; }
        public string StateName { get; set; }
        public string District { get; set; }
        public string DistrictName { get; set; }
        public int? MineralId { get; set; }
        public int? MineralID { get; set; }
        public string MineralName { get; set; }
        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
        public decimal? AvailableQuantityinStock { get; set; }
        public decimal? TotalQty { get; set; }
        public decimal? ClosingStock { get; set; }
        public decimal? QuantitytobeDispatched { get; set; }
        public string Unit { get; set; }
        public string UnitName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public decimal? ApprovedQty { get; set; }
        public int? ActiveStatus { get; set; }
        public int? IsApproved { get; set; }
        public int? IsReject { get; set; }
        public string Remark { get; set; }
        public string BulkPermitNo { get; set; }
        public int? UserTypeId { get; set; }
        public string TypeOfCoal { get; set; }
        public string TypeOfCoalTobeDispatch { get; set; }

        public int? isForwarded { get; set; }
        public string UserType { get; set; }
        public string Mineral { get; set; }
        public string listOfSelectedPass { get; set; }
        public string PeriodOfLisense { get; set; }

        public string GrantOrderNo { get; set; }
        public string GrantOrderNumber { get; set; }
        public string GrantOrderDate { get; set; }

        public string DSCResponse { get; set; }
        public string DSCLesseeFilePath { get; set; }
        public int? MineralFormId { get; set; }
        public string CreateOn { get; set; }
        public decimal? AvailableStock { get; set; }
        public decimal? DispatchedQty { get; set; }

        public string ApprovedRejectOn { get; set; }
        public string DSCFilePath { get; set; }


    }
    public class ListofRPTP
    {
        public int? RPTPBulkPermitId { get; set; }
        public int? SrNo { get; set; }
        public string ApplicationNo { get; set; }
        public string BulkPermitNo { get; set; }
        public string ApplicationDate { get; set; }
        public decimal? AvailableQty { get; set; }
        public string MineralName { get; set; }
        public string MineralGrade { get; set; }
        public decimal? ProposedQty { get; set; }
        public decimal? ApprovedQty { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string LicenseeCode { get; set; }
        public string ApprovedOn { get; set; }
        public string RejectOn { get; set; }
        public string DSCLesseeFilePath { get; set; }

    }
    public class DMOVerifiedReport
    {
        public string OpeningStock { get; set; }
        public string ClosingBalance { get; set; }
        public string RecievedByName { get; set; }
        public string RecievedByAddress { get; set; }
        public string EtransistPassNo { get; set; }
        public string DateIssuanceOfTransitPass { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string Qty { get; set; }
    }
    public class LicenseeRPTPResult
    {
        public List<LicenseInfoRPTP> RPTPPermitLst { get; set; }
        public List<LicenseInfoRPTP> RPTPClosingPermitLst { get; set; }
    }
    #endregion
    public class ValidityExpiredEF
    {
        public int BulkPermitId { get; set; }
        public int UserID { get; set; }
        public string TotalECApprovedQty { get; set; }
        public string ECApprovedQuantity { get; set; }
        public string TotalMiningProductionQty { get; set; }
        public string Production { get; set; }
        public string ECValidity { get; set; }
        public string MPValidity { get; set; }
        public string MiningValidity { get; set; }
        public string LeaseValidity { get; set; }
        public string TotalDispatched { get; set; }
        public string TPStoppedReason { get; set; }
    }
    public class LicenseFinalApproval
    {
        public string MOBILENO { get; set; }
        public string EMAILADDRESS { get; set; }
        public string APPLICANTNAME { get; set; }
        public string LICENSE_APP_CODE { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string application_tyep { get; set; }
        public string Status { get; set; }
        public string License_SI_NO { get; set; }
        public string ApprovedGrantOn { get; set; }
    }
    public class LesseeFinalApproval
    {
        public string MOBILENO { get; set; }
        public string EMAILADDRESS { get; set; }
        public string APPLICANTNAME { get; set; }
        public string LICENSE_APP_CODE { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string application_tyep { get; set; }
        public string Status { get; set; }
        public string License_SI_NO { get; set; }
        public string ApprovedGrantOn { get; set; }
        public string TransactionalId { get; set; }
        public string PaymentReceiptID { get; set; }
    }
    //Created By Priyabrat Das
    public class PermitWeighBridgeMapp
    {
        public int PermitWeighBridgeId { get; set; }
        public int UserId { get; set; }
        public string PermitId { get; set; }
        public int WeighBridgeId { get; set; }
        public string WeighBridgeName { get; set; }
        public int Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public int Modifiedby { get; set; }
        public DateTime Modifiedon { get; set; }
        public int IsDelete { get; set; }
        public int IsActive { get; set; }
        public string PermitType { get; set; }
    }
}
