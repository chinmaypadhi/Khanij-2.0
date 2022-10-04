using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MasterEF
{
    public class LicenseeProfile
    {
        public int? UserID { get; set; }
        public int? STATUS { get; set; }
        public int? CREATED_BY { get; set; }
        public string Remarks { get; set; }
        public string UserLoginId { get; set; }
        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }
        public string Action_Transfer { get; set; }
        public string Action_Approve { get; set; }
        public string Action_Reject { get; set; }
        public string TodateIntimation { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
        public int? VillageID { get; set; }
        public int? StateId { get; set; }
        public int? DistrictId { get; set; }
        public string BLOCK_FOREST_RANG { get; set; }
        public string PIN_CODE { get; set; }
        public int? REJECTED_BY { get; set; }
        public DateTime? REJECTED_ON { get; set; }
        public int? MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_ON { get; set; }

    }
    #region IBM Details
    public class IBMDetails : LicenseeProfile
    {
        public string IBM_APPLICATION_NUMBER { get; set; }
        public int? LICENSEE_IBM_ID { get; set; }
        public string IBM_APPLICATON_DATE { get; set; }
        public DateTime? APPROVED_ON { get; set; }
        public string IBM_REGISTRATION_FORM_PATH { get; set; }
        public string FILE_IBM_REGISTRATION_FORM { get; set; }
        //public HttpPostedFileBase IBM_REGISTRATION_FORM { get; set; }
        public string IBM_NUMBER { get; set; }

    }
    #endregion
    #region CTE Details
    public class CTEDetails : LicenseeProfile
    {
        public int? CTE_ID { get; set; }
        public string CTE_ORDER_NO { get; set; }
        public string CTE_VALID_FROM { get; set; }
        public string CTE_VALID_TO { get; set; }
        public string CTE_ORDER_DATE { get; set; }
        public String CTE_VALID_TO_INTIMATION { get; set; }
        public string CTE_LETTER_PATH { get; set; }
        public int LICENSEE_ID { get; set; }
        public string FILE_CTE_LETTER { get; set; }
        public string CTEVALIDITY { get; set; }
        public string CTEValidityStatus { get; set; }
    }
    #endregion
    #region CTO Details
    public class CTODetails : LicenseeProfile
    {
        public int? CTO_ID { get; set; }
        public string CTO_ORDER_NO { get; set; }
        public string CTO_VALID_FROM { get; set; }
        public string CTO_VALID_TO { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public string CTO_ORDER_DATE { get; set; }
        public String CTO_VALID_TO_INTIMATION { get; set; }
        public string CTO_LETTER_PATH { get; set; }
        public string FILE_CTO_LETTER { get; set; }
        public string CTOVALIDITY { get; set; }
        public string CTOValidityStatus { get; set; }

    }
    #endregion
    #region Grant Order
    public class GrantDetails : LicenseeProfile
    {
        public int? GrantOrderId { get; set; }
        public string GrantOrderNumber { get; set; }
        public string GrantOrderDate { get; set; }
        public string FromValidity { get; set; }
        public string ToValidity { get; set; }
        public string GrantOrderFilePath { get; set; }
        public string GrantOrderFileName { get; set; }
        public string LicensePeriod { get; set; }
        public String GRANTVALIDITY { get; set; }
        public string GRANTValidityStatus { get; set; }
    }
    #endregion
    #region EC Details
    public class ECDetails : LicenseeProfile
    {
        public int? LICENSEE_EC_ID { get; set; }
        public string EC_APPLICATION_NUMBER { get; set; }
        public string EC_APPLICATON_DATE { get; set; }
        public string EC_ORDRER_NUMBER { get; set; }
        public string EC_CLEARANCE_PATH { get; set; }
        public string FILE_EC_CLEARANCE { get; set; }
        public string EC_NUMBER { get; set; }
        public string EC_VALID_FROM { get; set; }
        public string EC_VALID_TO { get; set; }
        public double EC_APPROVED_CAPACITY { get; set; }
        public int MineralId { get; set; }
        public string MineralName { get; set; }
        public string ECValidityStatus { get; set; }
    }
    #endregion
    #region Licensee Area Details
    public class AreaDetails : LicenseeProfile
    {
        public int? LICENSEE_AREA_DETAIL_ID { get; set; }
        public int? TehsilID { get; set; }
        public string TehsilName { get; set; }
        public string DistrictName { get; set; }
        public string StateName { get; set; }
        public string VillageName { get; set; }
        public string LandName { get; set; }
        public int? LAND_ID { get; set; }
        public string AREA_IN_HECT { get; set; }
        public string TOPOSHEET_NO { get; set; }
        public string COORDINATES_NO { get; set; }
        public string POLICE_STATION { get; set; }
        public string GRAM_PANCHAYAT { get; set; }
        public string ATTACHMENT_PATH { get; set; }
        public string FILE_ATTACHMENT { get; set; }
        public string DEMARCATION_REPORT_PATH { get; set; }
        public string FILE_DEMARCATION_REPORT { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

    }

    #endregion
    #region Application Details
    public class ApplicationDetails : LicenseeProfile
    {
        #region Mineral
        public int? MINERAL_CATEGORY_ID { get; set; }
        public string MINERAL_CATEGORY_NAME { get; set; }
        public string MineralID { get; set; }
        public string MineralName { get; set; }
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
        public List<int?> MineralCount { get; set; }
        public class MineralAssignment
        {
            public int? Value { get; set; }
        }
        public string MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public string MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
        public string MineralIdList { get; set; }
        public string MineralFormIdList { get; set; }
        public string MineralGradeIdList { get; set; }
        #endregion
        public int? LICENSEE_APPLICATION_ID { get; set; }
        public string LICENSEE_CODE { get; set; }
        public int? APPLICATION_TYPE_ID { get; set; }
        public String APPLICATION_TYPE_NAME { get; set; }
        public int MINERAL_ID { get; set; }
        public int MINERAL_ID_COUNT { get; set; }
        public string APPLICATION_NUMBER { get; set; }
        public IFormFile APPLICATION_FORM_COPY { get; set; }
        public string FILE_APPLICATION_FORM_COPY { get; set; }
        public string APPLICATION_FORM_COPY_PATH { get; set; }
        public int DMO_ID { get; set; }
        public int COMPANY_ID { get; set; }
        public string PAN_CARD_NO { get; set; }
        public IFormFile PAN_CARD_COPY { get; set; }
        public string PAN_CARD_PATH { get; set; }
        public string FILE_PAN_CARD { get; set; }
        public string ADHAR_CARD_NO { get; set; }
        public IFormFile ADHAR_CARD_SCAN_COPY { get; set; }
        public string ADHAR_CARD_PATH { get; set; }
        public string FILE_ADHAR_CARD { get; set; }
        public string TIN_CARD_NO { get; set; }
        public IFormFile TIN_CARD_SCAN_COPY { get; set; }
        public string TIN_CARD_PATH { get; set; }
        public string FILE_TIN_CARD { get; set; }
        public string FIRM_REGISTRATION_DEED_NO { get; set; }
        public IFormFile FIRM_REGISTRATION_DEED { get; set; }
        public string FIRM_REGISTRATION_DEED_PATH { get; set; }
        public string FILE_FIRM_REGISTRATION_DEED { get; set; }
        public string CERTIFICATE_OF_INCORPORATION_NO { get; set; }
        public IFormFile CERTIFICATE_OF_INCORPORATION_DOC { get; set; }
        public string CERTIFICATE_OF_INCORPORATION_PATH { get; set; }
        public string FILE_CERTIFICATE_OF_INCORPORATION { get; set; }
        public string STORAGE_CAPACITY { get; set; }
        public string NHA_NOC_NUMBER { get; set; }
        public IFormFile NHA_NOC_NUMBER_COPY { get; set; }
        public string NHA_NOC_DATE { get; set; }
        public string NHA_NOC_COPY_PATH { get; set; }
        public string FILE_NHA_NOC_COPY { get; set; }
        public string PCB_NOC_NUMBER { get; set; }
        public IFormFile PCB_NOC_NUMBER_COPY { get; set; }
        public string PCB_NOC_DATE { get; set; }
        public string PCB_NOC_COPY_PATH { get; set; }
        public string FILE_PCB_NOC_COPY { get; set; }
        public string APPLICATION_FEES { get; set; }
        public IFormFile APPLICATION_FEES_COPY { get; set; }
        public string APPLICATION_FEES_DATE { get; set; }
        public string APPLICATION_FEES_CHALLAN_PATH { get; set; }
        public string FILE_APPLICATION_FEES_CHALLAN { get; set; }
        public IFormFile AFFIDAVITS_MINING_DUE_COPY { get; set; }
        public string AFFIDAVITS_MINING_DUE_PATH { get; set; }
        public string FILE_AFFIDAVITS_MINING_DUE { get; set; }
        public IFormFile POWER_OF_ATORNY_PATH_COPY { get; set; }
        public string POWER_OF_ATORNY_PATH { get; set; }
        public string FILE_POWER_OF_ATORNY { get; set; }
        public IFormFile MAP_PLAN_OF_APPLIED_AREA_COPY { get; set; }
        public string MAP_PLAN_OF_APPLIED_AREA_PATH { get; set; }
        public string FILE_MAP_PLAN_OF_APPLIED_AREA { get; set; }
        public IFormFile KHASARA_PANCHSALA_COPY { get; set; }
        public string KHASARA_PANCHSALA_PATH { get; set; }
        public string FILE_KHASARA_PANCHSALA { get; set; }
        public IFormFile REVENUE_OFFICER_REPORT_COPY { get; set; }
        public string REVENUE_OFFICER_REPORT_PATH { get; set; }
        public string FILE_REVENUE_OFFICER_REPORT { get; set; }
        public IFormFile FOREST_REPORT_COPY { get; set; }
        public string FOREST_REPORT_PATH { get; set; }
        public string FILE_FOREST_REPORT { get; set; }
        public IFormFile MINING_INSPECTOR_REPORT_COPY { get; set; }
        public string MINING_INSPECTOR_REPORT_PATH { get; set; }
        public string FILE_MININIG_INSPECTOR_REPORT { get; set; }
        public IFormFile SPOT_INSPECTION_AND_ANALYSIS_REPORT_COPY { get; set; }
        public string SPOT_INSPECTION_AND_ANALYSIS_REPORT_PATH { get; set; }
        public string FILE_SPOT_INSPECTION_AND_ANALYSIS_REPORT { get; set; }
        public IFormFile GRAM_PANCHAYAT_PROPOSAL_COPY { get; set; }
        public string GRAM_PANCHAYAT_PROPOSAL_PATH { get; set; }
        public string FILE_GRAM_PANCHAYAT_PROPOSAL { get; set; }
        public string CHALLAN_DD_AMOUNT { get; set; }
        public string CHALLAN_DD_DATE { get; set; }
        public IFormFile CHALLAN_DD_COPY { get; set; }
        public string CHALLAN_DD_PATH { get; set; }
        public string FILE_CHALLAN_DD { get; set; }
        public string SURETY_BOND_AMOUNT { get; set; }
        public string SURETY_BOND_DATE { get; set; }
        public IFormFile SURETY_BOND_COPY { get; set; }
        public string SURETY_BOND_PATH { get; set; }
        public string FILE_SURETY_BOND { get; set; }
        public string BANK_GUARRANTEE_AMOUNT { get; set; }
        public string BANK_GUARRANTEE_DATE { get; set; }
        public IFormFile BANK_GUARRANTEE_COPY { get; set; }
        public string BANK_GUARRANTEE_PATH { get; set; }
        public string FILE_BANK_GUARRANTEE { get; set; }
        public IFormFile FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_COPY { get; set; }
        public string FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_PATH { get; set; }
        public string FILE_FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE { get; set; }
        public int CompanyID { get; set; }
        public int LeaseStatusId { get; set; }
        public string LeaseCode { get; set; }
        public string DateOfRenewal { get; set; }
        public string PeriodOfRenewalFrom { get; set; }
        public string PeriodOfRenewalTo { get; set; }
        public IFormFile Renewal_GrantOrder_COPY { get; set; }
        public string Renewal_GrantOrderCopy_Path { get; set; }
        public string Renewal_GrantOrderCopy_File { get; set; }
        public string NameOfTransferee { get; set; }
        public string AddressOfTransferee { get; set; }
        public string DateOfTransfer { get; set; }
        public IFormFile Transfer_GrantOrder_COPY { get; set; }
        public string Transfer_GrantOrderCopy_Path { get; set; }
        public string Transfer_GrantOrderCopy_File { get; set; }
        public IFormFile Transfer_LeaseDeed_COPY { get; set; }
        public string Transfer_LeaseDeedCopy_Path { get; set; }
        public string Transfer_LeaseDeedCopy_File { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int MineralTypeId { get; set; }
        public int APPLICANT_TYPE_ID { get; set; }
        public string License_Location { get; set; }
    }
    #endregion
    #region Licensee Details
    public class LicenseeDetails : LicenseeProfile
    {
        public int LICENSEE_DETAIL_ID { get; set; }
        public string CategoryOfLicensee { get; set; }
        public string FirmAs { get; set; }
        public string CompanyAs { get; set; }
        public string CORPORATE_NAME { get; set; }
        public string CORPORATE_ADDRESS { get; set; }
        public string CORPORATE_NAME_PREFIX { get; set; }
        public string CORPORATE_CONTACT_DETAILS1 { get; set; }
        public string CORPORATE_LANDLINE_NO { get; set; }
        public string CORPORATE_DESIGNATION { get; set; }
        public string CORPORATE_MAIL_ID { get; set; }
        public string BRANCH_NAME { get; set; }
        public string BRANCH_ADDRESS { get; set; }
        public string BRANCH_NAME_PREFIX { get; set; }
        public string BRANCH_CONTACT_DETAILS1 { get; set; }
        public string BRANCH_LANDLINE_NO { get; set; }
        public string BRANCH_DESIGNATION { get; set; }
        public string BRANCH_MAIL_ID { get; set; }
        public string SITE_NAME { get; set; }
        public string SITE_ADDRESS { get; set; }
        public string SITE_NAME_PREFIX { get; set; }
        public string SITE_CONTACT_DETAILS1 { get; set; }
        public string SITE_LANDLINE_NO { get; set; }
        public string SITE_DESIGNATION { get; set; }
        public string SITE_MAIL_ID { get; set; }
        public string SECONDARY_SITE_NAME_PREFIX { get; set; }
        public string SECONDARY_SITE_NAME { get; set; }
        public string SECONDARY_SITE_ADDRESS { get; set; }
        public string SECONDARY_SITE_CONTACT_DETAILS { get; set; }
        public string SECONDARY_SITE_LANDLINE_NO { get; set; }
        public string SECONDARY_SITE_DESIGNATION { get; set; }
        public string SECONDARY_SITE_MAIL_ID { get; set; }
        public string AGENT_NAME { get; set; }
        public string AGENT_ADDRESS { get; set; }
        public string AGENT_NAME_PREFIX { get; set; }
        public string AGENT_CONTACT_DETAILS1 { get; set; }
        public string AGENT_LANDLINE_NO { get; set; }
        public string AGENT_DESIGNATION { get; set; }
        public string AGENT_MAIL_ID { get; set; }
        public string LETTER_OF_APPOINTMENT_OF_AGENT_PATH { get; set; }
        public string FILE_LETTER_OF_APPOINTMENT_OF_AGENT { get; set; }
        public IFormFile LETTER_OF_APPOINTMENT_OF_AGENT { get; set; }
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public string CompanyName { get; set; }
    }
    #endregion
    #region Mineral Information
    public class MineralDetails : LicenseeProfile
    {
        public int? MINERAL_CATEGORY_ID { get; set; }
        public string MINERAL_CATEGORY_NAME { get; set; }
        public string MineralID { get; set; }
        public string MineralName { get; set; }
        public int? MINERAL_GRADE_ID { get; set; }
        public string MINERAL_GRADE_NAME { get; set; }
        public string MineralFormName { get; set; }
        public List<int> MineralFormCount { get; set; }
        public string MineralGradeName { get; set; }
        public List<int> MineralGradeCount { get; set; }
        public List<int?> MineralCount { get; set; }        
        public string MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public string MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
        public string MineralIdList { get; set; }
        public string MineralFormIdList { get; set; }
        public string MineralGradeIdList { get; set; }
        public int LICENSEE_APPLICATION_ID { get; set; }
    }
    #endregion
    #region Licensee Profile 
    public class ViewIBMProfile
    {
        public string IBM_APPLICATON_DATE { get; set; }
        public string IBM_NUMBER { get; set; }
        public string IBM_APPLICATION_NUMBER { get; set; }
        public int? CREATED_BY { get; set; }
        public int? STATUS { get; set; }

    }
    public class ProfileCount
    {
        public int? CREATED_BY { get; set; }
        public string PERCENTAGES { get; set; }
    }
    public class CTEProfile
    {
        public string CTE_ORDER_NO { get; set; }
        public string CTE_VALID_TO { get; set; }
        public string CTE_ORDER_DATE { get; set; }
        public int? CREATED_BY { get; set; }
        public int? STATUS { get; set; }
        public string CTEVALIDITY { get; set; }
        public string CTEValidityStatus { get; set; }
    }
    public class CTOProfile
    {
        public string CTO_ORDER_NO { get; set; }
        public string CTO_ORDER_DATE { get; set; }
        public string CTO_VALID_TO { get; set; }
        public int? CREATED_BY { get; set; }
        public int? STATUS { get; set; }
        public string CTOVALIDITY { get; set; }
        public string CTOValidityStatus { get; set; }
    }
    public class GrantProfile
    {
        public string GrantOrderNumber { get; set; }
        public string GrantOrderDate { get; set; }
        public string ToValidity { get; set; }
        public string LicensePeriod { get; set; }
        public int? CREATED_BY { get; set; }
        public int? STATUS { get; set; }
        public String GRANTVALIDITY { get; set; }
        public string GRANTValidityStatus { get; set; }
    }
    public class ECProfile
    {
        public string EC_ORDRER_NUMBER { get; set; }
        public string EC_APPLICATON_DATE { get; set; }
        public string EC_VALID_TO { get; set; }
        public int? CREATED_BY { get; set; }
        public int? STATUS { get; set; }
        public string ECValidityStatus { get; set; }
        public string EC_VALIDITY { get; set; }
    }
    public class AreaProfile
    {
        public string DistrictName { get; set; }
        public string StateName { get; set; }
        public string VillageName { get; set; }
        public string AREA_IN_HECT { get; set; }
        public string LandName { get; set; }
        public string PIN_CODE { get; set; }
        public int? CREATED_BY { get; set; }
        public int? STATUS { get; set; }
    }
    public class ApplicationProfile
    {
        public String APPLICATION_TYPE_NAME { get; set; }
        public string STORAGE_CAPACITY { get; set; }
        public string LeaseStatus { get; set; }
        public int? CREATED_BY { get; set; }
        public int? STATUS { get; set; }
    }
    public class MineralProfile
    {
        public int MineralId { get; set; }
        public string MineralName { get; set; }
        public string MineralType { get; set; }
        public int? CREATED_BY { get; set; }
        public int? STATUS { get; set; }
    }

    #endregion
    #region Individual Profile Count For DD
    public class DDProfileCount
    {
        public string LICENSEE_OFFICE_COUNT { get; set; }
        public string LICENSEE_APPLICATION_COUNT { get; set; }
        public string LICENSEE_CTE_COUNT { get; set; }
        public string LICENSEE_CTO_COUNT { get; set; }
        public string LICENSEE_EC_COUNT { get; set; }
        public string LICENSEE_GRANT_ORDER_COUNT { get; set; }
        public string LICENSEE_IBM_COUNT { get; set; }
        public string LICENSEE_LICENSE_COUNT { get; set; }
        public string LICENSEE_MINERAL_INFORMATION_COUNT { get; set; }
        public string LICENSEE_NEW_APPLICATION_COUNT { get; set; }
        public int CREATED_BY { get; set; }
        public int? IndividualId { get; set; }
        public string ApplicantName { get; set; }
        public int UserId { get; set; }
        public string UserTypeName { get; set; }
    }
    
    #endregion
    public class ViewLicenseeDetailsAuthority
    {
        public int id { get; set; }
        public string APPLICANT_NAME { get; set; }
        public string USER_NAME { get; set; }
        public string DISTRICT_NAME { get; set; }
        public string STATE_NAME { get; set; }
        public string REQUESTED_ON { get; set; }
        public string status { get; set; }
        public int UserId { get; set; }
    }
    public class LicenseeResult
    {
        public List<IBMDetails> IBMDetailsLst { get; set; }
        public List<CTEDetails> CTEDetailsLst { get; set; }
        public List<CTODetails> CTODetailsLst { get; set; }
        public List<GrantDetails> GratnDetilsList { get; set; }
        public List<ECDetails> ECDetailsList { get; set; }
        public List<AreaDetails> AreaDetalsList { get; set; }
        public List<LicenseeDetails> LicesenseeOfficeDetailsList { get; set; }
        public List<ApplicationDetails> ApplicationDetailsList { get; set; }
        public List<MineralDetails> MineralDetailsList { get; set; }

    }
}