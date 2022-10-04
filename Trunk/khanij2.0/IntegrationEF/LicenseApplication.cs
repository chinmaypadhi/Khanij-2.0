using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationEF
{
    public class LicenseApplication
    {
        public int? SRNO { get; set; }
        public int? LicenseAppId { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int? MINERAL_ID { get; set; }
        public int? MineralTypeId { get; set; }
        public string MINERALTYPE_NAME { get; set; }
        public string MINERAL_NAME { get; set; }

        //public decimal? StorageCapicity { get; set; }
        public string StorageCapicity { get; set; }
        //public decimal? Period { get; set; }
        public string Period { get; set; }

        public string Panchayat { get; set; }
        public string PoliceStation { get; set; }

        public string Place { get; set; }
        public string ApplicantName { get; set; }
        public string CompleteAddress { get; set; }

        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int? AppVillageId { get; set; }
        public string AppVillageName { get; set; }
        public int? AppTehsilId { get; set; }
        public string AppTehsilName { get; set; }
        public int? AppDistrictId { get; set; }
        public string AppDistrictName { get; set; }
        public int? ApplicantTypeId { get; set; }
        public string ApplicantTypeName { get; set; }
        public string SecurityDepositLastDate { get; set; }

        public string NatureofBusiness { get; set; }
        public string Form4Path { get; set; }
        public string Form6Path { get; set; }

        public int? IntendMineralProductId { get; set; }
        public string IntendMineralProductName { get; set; }

        // public HttpPostedFileBase NO_MINING_DUE_CERTIFICATE { get; set; }
        public string NO_MINING_DUE_CERTIFICATE_FILE_PATH { get; set; }
        public string NO_MINING_DUE_CERTIFICATE_FILE_NAME { get; set; }

        // public HttpPostedFileBase AFFIDAVITE { get; set; }
        public string AFFIDAVITE_FILE_PATH { get; set; }
        public string AFFIDAVITE_FILE_NAME { get; set; }

        // public HttpPostedFileBase AFFIDAVITE_JOINTLY { get; set; }
        public string AFFIDAVITE_JOINTLY_FILE_PATH { get; set; }
        public string AFFIDAVITE_JOINTLY_FILE_NAME { get; set; }

        //  public HttpPostedFileBase MAP_LAND_CERTIFICATE { get; set; }
        public string MAP_LAND_CERTIFICATE_FILE_PATH { get; set; }
        public string MAP_LAND_CERTIFICATE_FILE_NAME { get; set; }


        // public HttpPostedFileBase LATEST_REVENEW_CERTIFICATE { get; set; }
        public string LATEST_REVENEW_CERTIFICATE_FILE_PATH { get; set; }
        public string LATEST_REVENEW_CERTIFICATE_FILE_NAME { get; set; }

        // public HttpPostedFileBase OWNER_LAND_CERTIFICATE { get; set; }
        public string OWNER_LAND_CERTIFICATE_FILE_PATH { get; set; }
        public string OWNER_LAND_CERTIFICATE_FILE_NAME { get; set; }


        // public HttpPostedFileBase NOC_OTHER_CERTIFICATE { get; set; }
        public string NOC_OTHER_CERTIFICATE_FILE_PATH { get; set; }
        public string NOC_OTHER_CERTIFICATE_FILE_NAME { get; set; }

        public string MineralFormName { get; set; }
        public string MineralGradeName { get; set; }
        public int? FF_MineralTypeId { get; set; }
        public string MINERAL_Count_String { get; set; }
        public string MINERAL_FORM_String { get; set; }
        public string MINERAL_GRADE_String { get; set; }

        public string MobileNo { get; set; }

        public string EmailAddress { get; set; }
        public string LICENSE_APP_CODE { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string ApplicationReceivedDate { get; set; }
        public string PaymentRecieptId { get; set; }
        public string PAYMENTID { get; set; }
        public decimal? TotalPayment { get; set; }
        public string Status { get; set; }
        public string ActiveStatus { get; set; }
        public string Action { get; set; }

        public string GrantOrderNo { get; set; }
        public string GrantOrderDate { get; set; }
        public string Remarks { get; set; }

        public string TransactionalID { get; set; }
        public string DSCLesseeFilePath { get; set; }
        public string GeneratedBy { get; set; }
        public string GeneratedDesignation { get; set; }
        public string GeneratedDateTime { get; set; }
        public string GeneratedDSC { get; set; }
        public string ChallanNumber { get; set; }
        public string ChallanDate { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentBank { get; set; }

        public string ApplicationFor { get; set; }
        public int? LicenseeTypeId { get; set; }
        public string LicenseeTypeName { get; set; }
        public string LicenseTypeName { get; set; }
        public int? MineralId { get; set; }
        public string MineralName { get; set; }

        public string North { get; set; }
        public string East { get; set; }
        public string West { get; set; }
        public string South { get; set; }

        public string SecurityAmount { get; set; }
        public string SecurityDate { get; set; }
        public string SecurityReceipteNo { get; set; }
        public string SecurityBank { get; set; }
        public string SecurityMode { get; set; }

        public string SecurityAmountChallanNumber { get; set; }

        public string SecurityAmountTreasuryDate { get; set; }
        public string SecurityAmountTreasuryNumber { get; set; }

        public string P_Mode { get; set; }
        public string NetBanking_mode { get; set; }

        
        public List<string> Conditions { get; set; }
        public List<int?> Mineral_Count { get; set; }
        
        public List<int?> MineralGradeCount { get; set; }
        public List<int?> MineralFormCount { get; set; }

        public int? UserId { get; set; }
        public int? UserLoginId { get; set; }
        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }

        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; }

        public int? TehsilID { get; set; }
        public string TehsilName { get; set; }

        public int? VillageID { get; set; }
        public string VillageName { get; set; }
        public string MineralIdList { get; set; }
        public DateTime? PaymentDoneDate { get; set; }


        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public int? LicenseType { get; set; }
        public string Form4FilePath { get; set; }
        public string Form6FilePath { get; set; }
        public string StatusId { get; set; }


        public string MineralNatureList { get; set; }

        //public string DeedFineAmount { get; set; }
        //public string DeedAmountDate { get; set; }
        //public string DeedReceiptNo { get; set; }
        //public string DeedBankName { get; set; }
        //public string DeedAmountMode { get; set; }

    }
}
