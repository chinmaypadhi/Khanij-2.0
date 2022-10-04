using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.Licensee
{
    public interface ILicenseeApplicationProvider : IDisposable, IRepository
    {

        Task<MessageEF> AddLicenseApplication(CreateLicenseApplication createLicenseApplication);
        Task<List<LicenseApplication>> ViewLicenseApplication(LicenseApplication licenseApplication);
        Task<LicenseApplication> EditLicenseApplication(LicenseApplication licenseApplication);
        Task<MessageEF> DeleteLicenseApplication(LicenseApplication licenseApplication);
        Task<MessageEF> UpdateLicenseApplication(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> GetDistrictListForm4(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> GetLicenseeType(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> GetMineralTypeList(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> GetMineralNameFromMineralType(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> GetMineralNatureListFromMineralIdList(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> GetMineralGradeListFromMineralIdList(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> GetDistrictList(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> GetTehsilListByDistrictID(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> GetvillageFromTehsilID(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> GetApplicantTypeForForm4(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> GetCompanyList(LicenseApplication licenseApplication);
        Task<LicenseApplication> PaymentProcessDetails(LicenseApplication licenseApplication);
        Task<List<LicenseApplication>> LicenseRegisteredList(LicenseApplication licenseApplication);
        Task<LicenseApplication> Form4Review(LicenseApplication licenseApplication);
        Task<LicenseeDocUploadModel> LicenseeDocUpload(LicenseApplication licenseApplication);
        Task<MessageEF> AddLicenseeDocUpload(LicenseeDocUploadModel licenseeDocUploadModel);
        Task<LicenseApplication> ViewForm7(LicenseApplication licenseApplication);
        Task<LicenseApplication> GetSecurityDepositDetail(LicenseApplication licenseApplication);
        Task<MessageEF> AddSecurityDeposit(LicenseApplication licenseApplication);
        Task<LicenseFinalApproval> LicenseFinalApprovalDetails(LicenseApplication licenseApplication);
        Task<LicenseMail> GetLicenseDetailsByAppCode(LicenseMail licenseMail);
        Task<MessageEF> UpdatedDSCPath(UpdateDSCPath updateDSCPath);
        Task<LicenseFinalApproval> LICENSE_APP_ACK(UpdateDSCPath updateDSCPath);
        Task<LicenseFinalApproval> LICENSE_APP_GRANT_ORDER(UpdateDSCPath updateDSCPath);
        Task<MessageEF> UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel);
        Task<List<LicenseApplication>> ExtendLeaseDeedDetails(LicenseApplication licenseApplication);
        Task<MessageEF> ApproveExtendLeaseDeedDetails(LicenseApplication licenseApplication);
        Task<MessageEF> LeaseDeedUpload(LeaseDeedModel leaseDeedModel);
        Task<MessageEF> ApproveLeaseDeed(LeaseDeedModel leaseDeedModel);
        Task<MessageEF> AddLeaseDeedFine(LicenseApplication licenseApplication);
        Task<MessageEF> IssueGrantOrder(LicenseApplication licenseApplication);
        Task<MessageEF> ObjectExtendLeaseDeedDetails(LicenseApplication licenseApplication);
    }
}
