using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace MasterEF
{
   public class UserInformationEF
    {
        public int UserID { get; set; }
        public int? APPLICATION_ID { get; set; }
        public int? APPLICATION_TYPE_ID { get; set; }
        public string APPLICATION_TYPE_Name { get; set; }
        public String APPLICATION_NUMBER { get; set; }
        //public HttpPostedFileBase APPLICATION_FORM_COPY { get; set; }
        //public IFormFile APPLICATION_FORM_COPY { get; set; }
        public string APPLICATION_FORM_FILE_NAME { get; set; }
        public string APPLICATION_FORM_COPY_FILE_NAME { get; set; }
        public string APPLICATION_FORM_FILE_PATH { get; set; }
        public string APPLICATION_FORM_COPY_FILE_PATH { get; set; }
        public String RECONNAISSANCE_LICENSE_NAME { get; set; }
        public String RECONNAISSANCE_LICENSE_ADDRESS { get; set; }
        public DateTime? PROSPECTING_VALIDITY_FROM { get; set; }
        public DateTime? PROSPECTING_VALIDITY_TO { get; set; }
        public String PAN_CARD_NO { get; set; }
       // public HttpPostedFileBase PAN_CARD_COPY { get; set; }
        public string PAN_CARD_COPY_FILE_NAME { get; set; }
        public string PAN_CARD_COPY_FILE_PATH { get; set; }
        public String Remarks { get; set; }
        public String ADHAR_CARD { get; set; }
        //public HttpPostedFileBase ADHAR_CARD_SCAN_COPY { get; set; }
        public string ADHAR_CARD_SCAN_COPY_FILE_NAME { get; set; }
        public string ADHAR_CARD_SCAN_COPY_FILE_PATH { get; set; }
        public String MINE_CODE { get; set; }
        public String TIN_CARD { get; set; }
       // public HttpPostedFileBase TIN_CARD_SCAN_COPY { get; set; }
        public string TIN_CARD_SCAN_COPY_FILE_PATH { get; set; }
        public string TIN_CARD_SCAN_COPY_FILE_NAME { get; set; }

        public String FIRMREGISTRATION_DEED_NUMBER { get; set; }
       // public HttpPostedFileBase FIRM_REGISTRATION_DEED { get; set; }
        public string FIRM_REGISTRATION_DEED_FILE_NAME { get; set; }
        public string FIRM_REGISTRATION_DEED_FILE_PATH { get; set; }

        public String CERTIFICATE_OF_INCORPORATION_NUMBER { get; set; }
       // public HttpPostedFileBase CERTIFICATE_OF_INCORPORATION_DOC { get; set; }
        public string CERTIFICATE_OF_INCORPORATION_DOC_FILE_PATH { get; set; }
        public string CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME { get; set; }

       // public HttpPostedFileBase AFFIDAVITS_MINING_DUE_CERTIFICATE { get; set; }
        public string AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_NAME { get; set; }
        public string AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_PATH { get; set; }

        public string PerformanceSecurity_FILE { get; set; }
        public string File_PerformanceSecurity { get; set; }
        public string PerformanceSecurity_PATH { get; set; }
        public string Path_PerformanceSecurity { get; set; }
        public string FinancialAssuranceAttachment_FILE { get; set; }
        public string File_FinancialAssurance { get; set; }
        public string FinancialAssuranceAttachment_PATH { get; set; }
        public string Path_FinancialAssurance { get; set; }
        public string StorageCrusher { get; set; }
        public string CrusherInstalled { get; set; }
        public string PaymentModeType { get; set; }
        public decimal SecurityDeposit { get; set; }
        public decimal FinancialAmountAssurance { get; set; }

        public string AdjustCess { get; set; }
        public string AdjustCESSFromRoyalty { get; set; }
        public string BG_ValidityUpto { get; set; }
        public decimal AmountOfDD { get; set; }
        public string WBStampDate { get; set; }
        public string WBValidUpto { get; set; }
        public string WBInstalled { get; set; }

        public string OrderOf { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string OrderAttachment_File { get; set; }
        public string OrderAttachment_Path { get; set; }

        public string StorageCrusherAttachment_FILE { get; set; }
        public string StorageCrusherAttachment_PATH { get; set; }
        public string File_LicenseStorageCrusher { get; set; }
        public string Path_LicenseStorageCrusher { get; set; }

        //public HttpPostedFileBase POWER_OF_ATORNY { get; set; }
        public string POWER_OF_ATORNY_FILE_PATH { get; set; }
        public string POWER_OF_ATORNY_FILE_NAME { get; set; }

        //public HttpPostedFileBase MAP_PLAN_OF_APPLIED_AREA { get; set; }
        public string MAP_PLAN_OF_APPLIED_AREA_FILE_NAME { get; set; }
        public string MAP_PLAN_OF_APPLIED_AREA_FILE_PATH { get; set; }

       // public HttpPostedFileBase KHASARA_PANCHSALA { get; set; }
        public string KHASARA_PANCHSALA_FILE_PATH { get; set; }
        public string KHASARA_PANCHSALA_FILE_NAME { get; set; }

        //public HttpPostedFileBase REVENUE_OFFICER_REPORT { get; set; }
        public string REVENUE_OFFICER_REPORT_FILE_NAME { get; set; }
        public string REVENUE_OFFICER_REPORT_FILE_PATH { get; set; }

       // public HttpPostedFileBase FOREST_REPORT { get; set; }
        public string FOREST_REPORT_FILE_NAME { get; set; }
        public string FOREST_REPORT_FILE_PATH { get; set; }

       // public HttpPostedFileBase MINING_INSPECTOR_REPORT { get; set; }
        public string MINING_INSPECTOR_REPORT_FILE_NAME { get; set; }
        public string MINING_INSPECTOR_REPORT_FILE_PATH { get; set; }

        //public HttpPostedFileBase SPOT_INSPECTION_AND_ANALYSIS_REPORT { get; set; }
        public string SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_PATH { get; set; }
        public string SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME { get; set; }

       // public HttpPostedFileBase GRAM_PANCHAYAT_PROPOSAL { get; set; }
        public string GRAM_PANCHAYAT_PROPOSAL_FILE_NAME { get; set; }
        public string GRAM_PANCHAYAT_PROPOSAL_FILE_PATH { get; set; }

       // public HttpPostedFileBase MinorMineralFormAttachment { get; set; }
        public string MinorMineralFormAttachment_FILE { get; set; }
        public string MinorMineralFormAttachment_PATH { get; set; }

        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }

        //======================
        //  FEES DETAI MODEL
        //======================
        public String APPLICATION_FEES { get; set; }
        public DateTime? APPLICATION_FEES_DATE { get; set; }
        //public HttpPostedFileBase APPLICATION_FEES_COPY { get; set; }
        public string APPLICATION_FEES_COPY_FILE_NAME { get; set; }
        public string APPLICATION_FEES_COPY_FILE_PATH { get; set; }

        public String CHALLAN_DD_AMOUNT { get; set; }
        public DateTime? CHALLAN_DD_AMOUNT_DATE { get; set; }
       // public HttpPostedFileBase CHALLAN_DD_AMOUNT_COPY { get; set; }
        public string CHALLAN_DD_AMOUNT_COPY_FILE_NAME { get; set; }
        public string CHALLAN_DD_AMOUNT_COPY_FILE_PATH { get; set; }


        public String BANK_GUARRANTEE_AMOUNT { get; set; }
        public DateTime? BANK_GUARRANTEE_DATE { get; set; }
       // public HttpPostedFileBase BANK_GUARRANTEE_COPY { get; set; }
        public string BANK_GUARRANTEE_COPY_FILE_PATH { get; set; }
        public string BANK_GUARRANTEE_COPY_FILE_NAME { get; set; }

        public String SURITY_BOND_AMOUNT { get; set; }
        public DateTime? SURITY_BOND_DATE { get; set; }
       // public HttpPostedFileBase SURITY_BOND_COPY { get; set; }
        public string SURITY_BOND_COPY_FILE_PATH { get; set; }
        public string SURITY_BOND_COPY_FILE_NAME { get; set; }

        public decimal? UpfrontPaymentDeposited { get; set; }

        public decimal? TillDateBalanceUpfrontPayment { get; set; }
        public int? IsInterNetConnectionAtDistpatch { get; set; }
        public decimal? TillDateDispatchQty { get; set; }

        public int? STATUS { get; set; }
        public string Actionstatus { get; set; }
        public int? CREATED_BY { get; set; }
        public string LabEstablished { get; set; }
        public int? AuctionTypeId { get; set; }
        public string AuctionName { get; set; }
        public int AuctionApplicationTypeID { get; set; }
        public string AuctionApplicationTypeName { get; set; }
        public string MonthlyPeriodicAmt { get; set; }
        public string MonthlyPeriodicAmtRate { get; set; }
        public int MonthlyPeriodicAmount { get; set; }
        public string File_Minor_Mineral { get; set; }
        public string Path_Minor_Mineral { get; set; }
        public string MINERAL_NAME { get; set; }
        public string MINERALNAME { get; set; }
        public string MineralIdList { get; set; }
        public string WBExemption_FILE { get; set; }
        public string WBExemption_PATH { get; set; }
        public string LabExemption_FILE { get; set; }
        public string LabExemption_PATH { get; set; }

        public string MonthlyPeriodAmountRate { get; set; }
        #region  Transfer
        public DateTime? DATE_OF_TRANSFER { get; set; }

        public string NAME_OF_TRANSFEREE { get; set; }

        public string ADDRESS_OF_TRANSFEREE { get; set; }

       // public HttpPostedFileBase TRANSFER_GRANT_ORDER__COPY { get; set; }
        public string TRANSFER_GRANT_ORDER_COPY_FILE_PATH { get; set; }
        public string TRANSFER_GRANT_ORDER_COPY_FILE_NAME { get; set; }

        //public HttpPostedFileBase TRANSFER_LEASE_DEED__COPY { get; set; }
        public string TRANSFER_LEASE_DEED_COPY_FILE_PATH { get; set; }
        public string TRANSFER_LEASE_DEED_COPY_FILE_NAME { get; set; }
        #endregion
        #region DSC
        public string DSCResponse { get; set; }
        #endregion
        #region Renewal

        // public HttpPostedFileBase FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_COPY { get; set; }
        public string FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH { get; set; }
        public string FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME { get; set; }
        #endregion
        #region GrandOrder
        public int? GrantOrderId { get; set; }
        //[Required(ErrorMessage = "Enter Grant Order Number")]
        public string GrantOrderNumber { get; set; }

        public DateTime? GrantOrderDate { get; set; }
        public DateTime? FromValidity { get; set; }
        public DateTime? ToValidity { get; set; }
        public string ExecutionOfDeedNumber { get; set; }
        public DateTime? ExecutionOfDeedDate { get; set; }
        public string GrantOrderFilePath { get; set; }
        public string GrantOrderFileName { get; set; }
        //public HttpPostedFileBase GRANT_ORDER_COPY { get; set; }

        public string ExecutionOfDeedFilePath { get; set; }
        public string ExecutionOfDeedFileName { get; set; }
        //public HttpPostedFileBase EXECUTION_OF_DEED_COPY { get; set; }
        //public int? STATUS { get; set; }

//        public int? CREATED_BY { get; set; }
        public int? REJECTED_BY { get; set; }
        public int? APPROVED_BY { get; set; }

        public string Lease_Period { get; set; }

        public String TodateIntimation { get; set; }
        public decimal PERCENTAGES { get; set; }
        public string UserLoginId { get; set; }

        //public ProfileStatusModel objProfileStatus { get; set; }

        #region DSC
        #endregion
        #endregion
        #region LeaseInformationDetails
        public int? LICENSE_AREA_ID { get; set; }
        public int? VILLAGE_ID { get; set; }
        public string VillageName { get; set; }

        public String BLOCK_FOREST_RANGE { get; set; }
        public int? TEHSIL_FOREST_DIVISION { get; set; }
        public string TehsilName { get; set; }
        public int? DISTRICT_ID { get; set; }
        public string DistrictName { get; set; }
        public int? STATE_ID { get; set; }
        public string STATE_NAME { get; set; }
        
        

        public String PIN_CODE { get; set; }
        public String TYPE_OF_LAND { get; set; }
        public decimal? AREA_IN_HECT { get; set; }
        public string TOPOSHEET_NO { get; set; }
        public String COORDINATES { get; set; }
      //  public HttpPostedFileBase DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES { get; set; }
        public String DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME { get; set; }
        public String DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH { get; set; }
        public DateTime? WORKING_PERMISSION_DATE { get; set; }
        //public HttpPostedFileBase WORKING_PERMISSION_COPY { get; set; }
        public String WORKING_PERMISSION_COPY_NAME { get; set; }
        public String WORKING_PERMISSION_COPY_PATH { get; set; }
        public DateTime? COMENCEMENT_OF_MINING_DATE { get; set; }
        //public HttpPostedFileBase COMMENCEMENT_OF_MINING_COPY { get; set; }
        public String COMENCEMENT_OF_MINING_FILE_NAME { get; set; }
        public String COMENCEMENT_OF_MINING_FILE_PATH { get; set; }
        public DateTime? DATE_OF_EXECUTION { get; set; }
        public string POLICE_STATION { get; set; }
        public string GRAM_PANCHAYAT { get; set; }
        public decimal? Forest { get; set; }
        public decimal? Revenue_Forest { get; set; }
        public decimal Revenue_Government_Land { get; set; }
        public decimal? Private_Tribal { get; set; }
        public decimal Private_Non_Tribal { get; set; }
        public decimal Nistar { get; set; }
        public string Land_Under_Vidhansabha_kshetra { get; set; }
        #endregion
        #region MineralInformationModel
        public int LESSEE_MINERAL_INFORMATION_ID { get; set; }
        public int MINERAL_CATEGORY_ID { get; set; }
        public string MINERAL_CATEGORY_NAME { get; set; }
        public int? MINERAL_ID { get; set; }
        public int? MINERALID { get; set; }

        public int? MINERAL_GRADE_ID { get; set; }
        public string MINERAL_GRADE_NAME { get; set; }
        public string MineralFormName { get; set; }
        public List<int> MineralFormCount { get; set; }
        public class MineralFormAssignment
        {
            public int? Value { get; set; }
        }

        public string MineralGradeName { get; set; }
        public List<int> MineralGradeCount { get; set; }
        public class MineralGradeAssignment
        {
            public int? Value { get; set; }
        }

        //[Required(ErrorMessage = "Enter Reserve Estimated")]
        public string ESTIMATED_RESERVE { get; set; }

        public string MINABLE_RESERVE { get; set; }
        public string COPY_OF_MP_SOM_ESTIMATION_FILE_NAME { get; set; }
        public string COPY_OF_MP_SOM_ESTIMATION_FILE_PATH { get; set; }
        //        public HttpPostedFileBase FILE { get; set; }
        //      public ProfileStatusModel objProfileStatus { get; set; }
        #endregion
        #region IBM
        //[Required(ErrorMessage = "Enter Application Number")]
        public string IBM_APPLICATION_NUMBER { get; set; }
        public int LICENSEE_IBM_ID { get; set; }
        public DateTime IBM_APPLICATON_DATE { get; set; }
        public DateTime? APPROVED_ON { get; set; }
        public string IBM_REGISTRATION_FORM_PATH { get; set; }
        public string FILE_IBM_REGISTRATION_FORM { get; set; }
        //public HttpPostedFileBase IBM_REGISTRATION_FORM { get; set; }
        public string IBM_NUMBER { get; set; }
        #endregion
        #region MiningPlan
        public int? MiningPlanId { get; set; }

        public DateTime? MP_APPROVE_DATE { get; set; }
        public DateTime? MP_EXPIRY_DATE { get; set; }
        public DateTime? MP_VALID_FORM { get; set; }
        public DateTime? MP_VALID_TO { get; set; }
        public String MP_VALID_TO_INTIMATION { get; set; }
      //  public List<ProductionModel> Product { get; set; }
        //public ProfileStatusModel objProfileStatus { get; set; }
        public string MP_APPROVAL_NO { get; set; }
        public int? UnitId { get; set; }
        public string YEAR { get; set; }
        public int Srno { get; set; }
        public string PRODUCTION1 { get; set; }
        public decimal? EC_APPROVED_CAPACITY { get; set; }

        public string MP_SOM_FilePath { get; set; }
        public string MP_SOM_FileName { get; set; }
        public List<ProductionModel> Product { get; set; }

        #endregion
        #region ForestClearence
        public int? FC_APPROVAL_ID { get; set; }

        public String FC_APPROVAL_NUMBER { get; set; }

        public DateTime? FC_APPROVAL_DATE { get; set; }

        public DateTime? VALID_FROM { get; set; }

        public DateTime? VALID_TO { get; set; }
        public String VALID_TO_INTIMATION { get; set; }
     //   public HttpPostedFileBase FC_LETTER { get; set; }
        public String FC_LETTER_FILE_NAME { get; set; }
        public String FC_LETTER_FILE_PATH { get; set; }
        #endregion
        #region EC
        public int? LICENSEE_EC_ID { get; set; }
        public string EC_APPLICATION_NUMBER { get; set; }
        public DateTime? EC_APPLICATON_DATE { get; set; }
        public string EC_NUMBER { get; set; }
        public string EC_CLEARANCE_PATH { get; set; }
        public string FILE_EC_CLEARANCE { get; set; }
//        public HttpPostedFileBase Env_Clearance_Letter { get; set; }
        public string EC_ORDRER_NUMBER { get; set; }
        public DateTime? EC_VALID_FROM { get; set; }
        public DateTime? EC_VALID_TO { get; set; }
//        public ProfileStatusModel objProfileStatus { get; set; }

        public int? MineralId { get; set; }
        public string MineralName { get; set; }
        public string Action_Transfer { get; set; }
        public string Action_Approve { get; set; }
        public string Action_Reject { get; set; }
        #endregion
        #region CTE
        public int? CTE_ID { get; set; }
        public string CTE_ORDER_NO { get; set; }
        public DateTime? CTE_VALID_FROM { get; set; }
        public DateTime? CTE_VALID_TO { get; set; }
        public DateTime? CTE_ORDER_DATE { get; set; }
        public String CTE_VALID_TO_INTIMATION { get; set; }
        public string CTE_LETTER_PATH { get; set; }
        public int LICENSEE_ID { get; set; }
        public string FILE_CTE_LETTER { get; set; }
        #endregion
                #region CTO
        public int? CTO_ID { get; set; }
        public string CTO_ORDER_NO { get; set; }
        public DateTime? CTO_VALID_FROM { get; set; }
        public DateTime? CTO_VALID_TO { get; set; }
        public DateTime? CTO_ORDER_DATE
 { get; set; }
        public String CTO_VALID_TO_INTIMATION { get; set; }
        public string CTO_LETTER_PATH { get; set; }
        public string FILE_CTO_LETTER { get; set; }
        #endregion
        #region AssessmentModel
        public int? AssessmentID { get; set; }
        public DateTime? Assessmentdate { get; set; }
        public string StrAssessmentdate { get; set; }
        public string RecoveryReportFilePath { get; set; }
        public string RecoveryReportFileName { get; set; }
        public string HalfyearassesmentFilePath { get; set; }
        public string HalfyearassesmentFileName { get; set; }
        public DateTime? HalfYearAssesmentDate { get; set; }
        public int? CORPORATE_STATUS { get; set; }
        public List<int> ProductList { get; set; }
        public List<string> YearList { get; set; }
        public List<string> UnitList { get; set; }
        #endregion
        public int btnId { get; set; }
    }
    public class LesseeResult
    {
        public List<UserInformationEF> LesseeLst { get; set; }
        public List<UserInformationEF> StateLst { get; set; }
        public List<UserInformationEF> DistrictLst { get; set; }
        public List<UserInformationEF> TehsilLst { get; set; }
        public List<UserInformationEF> VillageLst { get; set; }
        public List<UserInformationEF> YearLst { get; set; }
    }
    public class ApplicationResult
    {
        public List<UserInformationEF> ApplicationLst { get; set; }
        public List<UserInformationEF> GrantOrderLst { get; set; }
        public List<UserInformationEF> LeaseAreaDetailsLst { get; set; }
        public List<UserInformationEF> MineralLst { get; set; }
        public List<UserInformationEF> IBMDetailsLst { get; set; }
        public List<UserInformationEF> MiningPlanDetailsLst { get; set; }
        public List<ProductionModel> MiningPlanProductLst { get; set; }
        public List<UserInformationEF> ForestClearenceLst { get; set; }
        public List<UserInformationEF> EnvClearenceLst { get; set; }
        public List<UserInformationEF> CTEDetailsLst { get; set; }
        public List<UserInformationEF> CTODetailsLst { get; set; }
        public List<UserInformationEF> AssessmentRptLst { get; set; }


    }
    public class ProductionModel
    {
        public ProductionModel()
        {
            PRODUCTION = 0;
            FromToYear = "";
            CREATED_BY = 0;
            UNIT_ID = "";
        }
        public int? PRODUCTION { get; set; }
        public string FromToYear { get; set; }
        public string YEAR { get; set; }
        public string Units { get; set; }
        public int? CREATED_BY { get; set; }
        public string UNIT_ID { get; set; }
    }
}
