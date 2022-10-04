using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Areas.Licensee.Models.LicenseeApplication
{
    public interface ILicenseeApplicationModel
    {
        #region Add Licensee Application
        /// <summary>
        /// To Add Licensee Application
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        MessageEF Add(CreateLicenseApplication licenseApplication);
        #endregion

        #region Update Licensee Application
        /// <summary>
        /// To Update Licensee Application
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        MessageEF Update(LicenseApplication licenseApplication);
        #endregion

        #region View Licensee
        /// <summary>
        /// To View Licensee Application
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> View(LicenseApplication licenseApplication);
        #endregion

        #region Delete License
        /// <summary>
        /// To Delete Licensee Application
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        MessageEF Delete(LicenseApplication licenseApplication);
        #endregion

        #region Edit License
        /// <summary>
        /// To Edit Licensee Application
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        LicenseApplication Edit(LicenseApplication licenseApplication);
        #endregion

        #region Get District
        /// <summary>
        /// To Get District Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> GetDistrictListForm4(LicenseApplication licenseApplication);
        #endregion

        #region Get License Type
        /// <summary>
        /// To Get License Type Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> GetLicenseeType(LicenseApplication licenseApplication);
        #endregion

        #region Get Mineral Type
        /// <summary>
        /// To Get Mineral Type Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> GetMineralTypeList(LicenseApplication licenseApplication);
        #endregion

        #region Get MineralName From Mineral Type
        /// <summary>
        /// To Get MineralName From Mineral Type
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> GetMineralNameFromMineralType(LicenseApplication licenseApplication);
        #endregion

        #region Mineral NatureList From MineralId List
        /// <summary>
        /// To Get Mineral NatureList From MineralId List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> GetMineralNatureListFromMineralIdList(LicenseApplication licenseApplication);
        #endregion

        #region Get Mineral GradeList From MineralId List
        /// <summary>
        /// To Get Mineral GradeList From MineralId List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> GetMineralGradeListFromMineralIdList(LicenseApplication licenseApplication);
        #endregion

        #region Get District List
        /// <summary>
        /// To Get District List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> GetDistrictList(LicenseApplication licenseApplication);
        #endregion

        #region Get Tehsil By District Id
        /// <summary>
        /// To Get Tehsil By District Id
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> GetTehsilListByDistrictID(LicenseApplication licenseApplication);
        #endregion

        #region Get Village By TehsilId
        /// <summary>
        /// To Get Village From TehsilId
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> GetvillageFromTehsilID(LicenseApplication licenseApplication);
        #endregion

        #region Get Application Type
        /// <summary>
        /// To Get Application Type
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> GetApplicantTypeForForm4(LicenseApplication licenseApplication);
        #endregion

        #region Get Company List
        /// <summary>
        /// To Get Company List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> GetCompanyList(LicenseApplication licenseApplication);
        #endregion

        #region Payment Process Details
        /// <summary>
        /// To Get Payment Process Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        LicenseApplication PaymentProcessDetail(LicenseApplication licenseApplication);
        #endregion

        #region License Registered List
        /// <summary>
        /// To Get License Registered List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        List<LicenseApplication> LicenseRegisteredList(LicenseApplication licenseApplication);
        #endregion

        #region Form4 Review
        /// <summary>
        /// To Get Form4 Review
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        LicenseApplication Form4Review(LicenseApplication licenseApplication);
        #endregion

        #region Get License Uploaded Document
        /// <summary>
        /// To Get License Uploaded Document
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        LicenseeDocUploadModel LicenseeDocUpload(LicenseApplication licenseApplication);
        #endregion

        #region Add License Uploaded Document
        /// <summary>
        /// To Add License Uploaded Document
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        MessageEF AddLicenseeDocUpload(LicenseeDocUploadModel licenseeDocUploadModel);
        #endregion

        #region View Form7
        /// <summary>
        /// To View Form7
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        LicenseApplication ViewForm7(LicenseApplication licenseApplication);
        #endregion

        #region Get Security Deposit Details
        /// <summary>
        /// To Get Security Deposit Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        LicenseApplication GetSecurityDepositDetail(LicenseApplication licenseApplication);
        #endregion

        #region Add Security Deposit
        /// <summary>
        /// To Add Security Deposit
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        MessageEF AddSecurityDeposit(LicenseApplication licenseApplication);
        #endregion

        #region License Final Approval Details By DD
        /// <summary>
        /// To Get License Final Approval Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        LicenseFinalApproval LicenseFinalApprovalDetails(LicenseApplication licenseApplication);
        #endregion

        LicenseMail GetLicenseDetailsByAppCode(LicenseMail licenseMail);
        MessageEF UpdatedDSCPath(UpdateDSCPath updateDSCPath);
        LicenseFinalApproval LICENSE_APP_ACK(UpdateDSCPath updateDSCPath);
        LicenseFinalApproval LICENSE_APP_GRANT_ORDER(UpdateDSCPath updateDSCPath);
        MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel);
        List<LicenseApplication> ExtendLeaseDeedDetails(LicenseApplication licenseApplication);
        MessageEF ApproveExtendLeaseDeedDetails(LicenseApplication licenseApplication);

        #region Lease Deed
        MessageEF LeaseDeedUpload(LeaseDeedModel leaseDeedModel);
        MessageEF ApproveLeaseDeed(LeaseDeedModel leaseDeedModel);
        #endregion
       
        #region Add Lease Deed Fine Deposit
        /// <summary>
        /// To Add Lease Deed Fine Deposit
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        MessageEF AddLeaseDeedFine(LicenseApplication licenseApplication);
        #endregion

        MessageEF IssueGrantOrder(LicenseApplication licenseApplication);
    }
}
