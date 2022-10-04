// ***********************************************************************
//  Model Name               : LesseeInfoModel
//  Desciption               : Lessee Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MasterEF
{
    public class LesseeInfoModel
    {
        public int? APPLICATION_ID { get; set; }
        public int? APPLICATION_TYPE_ID { get; set; }
        public string APPLICATION_NUMBER { get; set; }
        public IFormFile APPLICATION_FORM_COPY { get; set; }
        public string APPLICATION_FORM_FILE_NAME { get; set; }
        public string APPLICATION_FORM_FILE_PATH { get; set; }
        public string RECONNAISSANCE_LICENSE_NAME { get; set; }
        public string RECONNAISSANCE_LICENSE_ADDRESS { get; set; }
        public DateTime? PROSPECTING_VALIDITY_FROM { get; set; }
        public DateTime? PROSPECTING_VALIDITY_TO { get; set; }
        public string PAN_CARD_NO { get; set; }
        public IFormFile PAN_CARD_COPY { get; set; }
        public string PAN_CARD_COPY_FILE_NAME { get; set; }
        public string PAN_CARD_COPY_FILE_PATH { get; set; }
        public string Remarks { get; set; }
        public string ADHAR_CARD { get; set; }
        public IFormFile ADHAR_CARD_SCAN_COPY { get; set; }
        public string ADHAR_CARD_SCAN_COPY_FILE_NAME { get; set; }
        public string ADHAR_CARD_SCAN_COPY_FILE_PATH { get; set; }
        public string MINE_CODE { get; set; }
        public string TIN_CARD { get; set; }
        public IFormFile TIN_CARD_SCAN_COPY { get; set; }
        public string TIN_CARD_SCAN_COPY_FILE_PATH { get; set; }
        public string TIN_CARD_SCAN_COPY_FILE_NAME { get; set; }
        public string FIRMREGISTRATION_DEED_NUMBER { get; set; }
        public IFormFile FIRM_REGISTRATION_DEED { get; set; }
        public string FIRM_REGISTRATION_DEED_FILE_NAME { get; set; }
        public string FIRM_REGISTRATION_DEED_FILE_PATH { get; set; }
        public string CERTIFICATE_OF_INCORPORATION_NUMBER { get; set; }
        public IFormFile CERTIFICATE_OF_INCORPORATION_DOC { get; set; }
        public string CERTIFICATE_OF_INCORPORATION_DOC_FILE_PATH { get; set; }
        public string CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME { get; set; }
        public IFormFile AFFIDAVITS_MINING_DUE_CERTIFICATE { get; set; }
        public string AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_NAME { get; set; }
        public string AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_PATH { get; set; }
        public IFormFile CopyOfPerformanceSecurity { get; set; }
        public string PerformanceSecurity_FILE { get; set; }
        public string PerformanceSecurity_PATH { get; set; }
        public IFormFile FinancialAssuranceCopy_Upload { get; set; }
        public string FinancialAssuranceAttachment_FILE { get; set; }
        public string FinancialAssuranceAttachment_PATH { get; set; }
        public string StorageCrusher { get; set; }
        public string CrusherInstalled { get; set; }
        public string PaymentModeType { get; set; }
        public decimal? SecurityDeposit { get; set; }
        public decimal? FinancialAmountAssurance { get; set; }
        public string AdjustCess { get; set; }
        public string OrderOf { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public IFormFile OrderCessRoyalty_Upload { get; set; }
        public string OrderAttachment_File { get; set; }
        public string OrderAttachment_Path { get; set; }
        public IFormFile StorageCrusherAttachment_Upload { get; set; }
        public string StorageCrusherAttachment_FILE { get; set; }
        public string StorageCrusherAttachment_PATH { get; set; }
        public IFormFile POWER_OF_ATORNY { get; set; }
        public string POWER_OF_ATORNY_FILE_PATH { get; set; }
        public string POWER_OF_ATORNY_FILE_NAME { get; set; }
        public IFormFile MAP_PLAN_OF_APPLIED_AREA { get; set; }
        public string MAP_PLAN_OF_APPLIED_AREA_FILE_NAME { get; set; }
        public string MAP_PLAN_OF_APPLIED_AREA_FILE_PATH { get; set; }
        public IFormFile KHASARA_PANCHSALA { get; set; }
        public string KHASARA_PANCHSALA_FILE_PATH { get; set; }
        public string KHASARA_PANCHSALA_FILE_NAME { get; set; }
        public IFormFile REVENUE_OFFICER_REPORT { get; set; }
        public string REVENUE_OFFICER_REPORT_FILE_NAME { get; set; }
        public string REVENUE_OFFICER_REPORT_FILE_PATH { get; set; }
        public IFormFile FOREST_REPORT { get; set; }
        public string FOREST_REPORT_FILE_NAME { get; set; }
        public string FOREST_REPORT_FILE_PATH { get; set; }
        public IFormFile MINING_INSPECTOR_REPORT { get; set; }
        public string MINING_INSPECTOR_REPORT_FILE_NAME { get; set; }
        public string MINING_INSPECTOR_REPORT_FILE_PATH { get; set; }
        public IFormFile SPOT_INSPECTION_AND_ANALYSIS_REPORT { get; set; }
        public string SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_PATH { get; set; }
        public string SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME { get; set; }
        public IFormFile GRAM_PANCHAYAT_PROPOSAL { get; set; }
        public string GRAM_PANCHAYAT_PROPOSAL_FILE_NAME { get; set; }
        public string GRAM_PANCHAYAT_PROPOSAL_FILE_PATH { get; set; }
        public IFormFile MinorMineralFormAttachment { get; set; }
        public string MinorMineralFormAttachment_FILE { get; set; }
        public string MinorMineralFormAttachment_PATH { get; set; }

        //======================
        //  FEES DETAIL MODEL
        //======================
        public string APPLICATION_FEES { get; set; }
        public string APPLICATION_FEES_DATE { get; set; }
        public IFormFile APPLICATION_FEES_COPY { get; set; }
        public string APPLICATION_FEES_COPY_FILE_NAME { get; set; }
        public string APPLICATION_FEES_COPY_FILE_PATH { get; set; }
        public string CHALLAN_DD_AMOUNT { get; set; }
        public string CHALLAN_DD_AMOUNT_DATE { get; set; }
        public IFormFile CHALLAN_DD_AMOUNT_COPY { get; set; }
        public string CHALLAN_DD_AMOUNT_COPY_FILE_NAME { get; set; }
        public string CHALLAN_DD_AMOUNT_COPY_FILE_PATH { get; set; }
        public string BANK_GUARRANTEE_AMOUNT { get; set; }
        public string BANK_GUARRANTEE_DATE { get; set; }
        public IFormFile BANK_GUARRANTEE_COPY { get; set; }
        public string BANK_GUARRANTEE_COPY_FILE_PATH { get; set; }
        public string BANK_GUARRANTEE_COPY_FILE_NAME { get; set; }
        public string SURITY_BOND_AMOUNT { get; set; }
        public string SURITY_BOND_DATE { get; set; }
        public IFormFile SURITY_BOND_COPY { get; set; }
        public string SURITY_BOND_COPY_FILE_PATH { get; set; }
        public string SURITY_BOND_COPY_FILE_NAME { get; set; }
        public decimal? UpfrontPaymentDeposited { get; set; }
        public decimal? TillDateBalanceUpfrontPayment { get; set; }
        public int? IsInterNetConnectionAtDistpatch { get; set; }
        public decimal? TillDateDispatchQty { get; set; }
        public int? STATUS { get; set; }
        public int? CREATED_BY { get; set; }
        //public ProfileStatusModel objProfileStatus { get; set; }
        #region  Transfer
        public string DATE_OF_TRANSFER { get; set; }
        public string NAME_OF_TRANSFEREE { get; set; }
        public string ADDRESS_OF_TRANSFEREE { get; set; }
        public IFormFile TRANSFER_GRANT_ORDER__COPY { get; set; }
        public string TRANSFER_GRANT_ORDER_COPY_FILE_PATH { get; set; }
        public string TRANSFER_GRANT_ORDER_COPY_FILE_NAME { get; set; }
        public IFormFile TRANSFER_LEASE_DEED__COPY { get; set; }
        public string TRANSFER_LEASE_DEED_COPY_FILE_PATH { get; set; }
        public string TRANSFER_LEASE_DEED_COPY_FILE_NAME { get; set; }
        #endregion
        #region Renewal
        public IFormFile FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_COPY { get; set; }
        public string FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH { get; set; }
        public string FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME { get; set; }
        #endregion
        public List<int?> MineralCount { get; set; }
        public string MINERAL_NAME { get; set; }
        public class mineralassignment
        {
            public int? value { get; set; }
        }

        //public ApplicationViewModel()
        //{
        //    objProfileStatus = new ProfileStatusModel();
        //}

        public int? AuctionTypeId { get; set; }
        public string AuctionName { get; set; }
        public string MonthlyPeriodicAmt { get; set; }
        public string MonthlyPeriodicAmtRate { get; set; }
        public string PaymentMode { get; set; }
        public string BG_ValidityUpto { get; set; }
        public decimal? AmountOfDD { get; set; }
        #region DSC
        public string DSCResponse { get; set; }
        #endregion
        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }
        public string WBStampDate { get; set; }
        public string WBValidUpto { get; set; }
        public string WBInstalled { get; set; }
        public string LabEstablished { get; set; }
        public IFormFile WBExemption_Upload { get; set; }
        public string WBExemption_FILE { get; set; }
        public string WBExemption_PATH { get; set; }
        public IFormFile LabExemption_Upload { get; set; }
        public string LabExemption_FILE { get; set; }
        public string LabExemption_PATH { get; set; }
        #region new
        public int? ID { get; set; }
        public string Name { get; set; }
        public float? BidPremium { get; set; }
        public int? LeasePurpose { get; set; }
        public int? DistrictId { get; set; }
        public string StateName { get; set; }
        public string DisrictName { get; set; }
        public string EndUserPlant { get; set; }
        public string PlantCapacity { get; set; }
        public string IsWBInstalled { get; set; }
        public string LeaseTypeName { get; set; }
        public string IsLabEstablished { get; set; }
        public string IsAuctionType { get; set; }
        public string IsLeasePurpose { get; set; }
        public string InterNetConnectionAtDistpatch { get; set; }
        public string LogStatus { get; set; }
        public string MODIFIED_ON { get; set; }
        public int? UserId { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
        public string CurrentStatus { get; set; }
        public string MineralType { get; set; }
        public string PERCENTAGES { get; set; }
        public string BANK_GUARRANTEE_VALIDITY { get; set; }
        public int StateId { get; set; }
        public int UserTypeId { get; set; }
        public int CaptiveUserId { get; set; }
        public string CaptiveUserName { get; set; }
        public string UserType { get; set; }
        public DataTable dtCaptive { get; set; }
        public int State_Id { get; set; }
        public int District_Id { get; set; }
        public int UserType_Id { get; set; }
        public int CaptiveUser_Id { get; set; }
        public List<CaptivePurposeModel> Product { get; set; }
        #endregion
    }
}
