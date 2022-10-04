// ***********************************************************************
//  Controller Name          : LicenseApplication
//  Desciption               : Liecensee Application Details 
//  Created By               : Akshaya Dalei
//  Created On               : 23 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userregistrationEF;
using userregistrationEFApi.Model.Licensee;

namespace userregistrationEFApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LicenseApplicationController : ControllerBase
    {
        private readonly ILicenseeApplicationProvider licenseeApplicationProvider;

        public LicenseApplicationController(ILicenseeApplicationProvider licenseeApplicationProvider)
        {
            this.licenseeApplicationProvider = licenseeApplicationProvider;
        }

        #region Add License Application
        /// <summary>
        /// To Add License Application
        /// </summary>
        /// <param name="MessageEF"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(CreateLicenseApplication createLicenseApplication)
        {
            return await licenseeApplicationProvider.AddLicenseApplication(createLicenseApplication);
        }
        #endregion

        #region View License Application
        /// <summary>
        /// To View License Application
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> ViewDetails(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.ViewLicenseApplication(licenseApplication);
        }
        #endregion

        #region Edit License Application
        /// <summary>
        /// To Edit License Application
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        [HttpPost]
        public async Task<LicenseApplication> Edit(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.EditLicenseApplication(licenseApplication);
        }
        #endregion

        #region Get District Form4
        /// <summary>
        /// To Get District Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> DistrictListForm4(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetDistrictListForm4(licenseApplication);
        }
        #endregion

        #region License Type
        /// <summary>
        /// To Get License Type
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> LicenseeType(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetLicenseeType(licenseApplication);
        }
        #endregion

        #region Mineral Type
        /// <summary>
        /// To Get Mineral Type Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> MineralTypeList(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetMineralTypeList(licenseApplication);
        }
        #endregion

        #region Mineral Name By Mineral Type
        /// <summary>
        /// To Get MineralName From Mineral Type
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> MineralNameFromMineralType(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetMineralNameFromMineralType(licenseApplication);
        }
        #endregion

        #region Mineral Nature By MineralId
        /// <summary>
        /// To Get Mineral Nature By MineralId
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> MineralNatureListFromMineralIdList(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetMineralNatureListFromMineralIdList(licenseApplication);
        }
        #endregion

        #region Mineral Grade By MineralId List
        /// <summary>
        /// To Get Mineral Grade By MineralId List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> MineralGradeListFromMineralIdList(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetMineralGradeListFromMineralIdList(licenseApplication);
        }
        #endregion

        #region District List
        /// <summary>
        /// To Get District Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> DistrictList(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetDistrictList(licenseApplication);
        }
        #endregion

        #region Tehsil By District Id
        /// <summary>
        /// To Get Tehsil By District Id
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> TehsilListByDistrictID(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetTehsilListByDistrictID(licenseApplication);
        }
        #endregion

        #region Village By Tehsil Id
        /// <summary>
        /// To Get Village From Tehsil Id
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> VillageFromTehsilID(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetvillageFromTehsilID(licenseApplication);
        }
        #endregion

        #region Application Type
        /// <summary>
        /// To Get Application Type
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> ApplicantTypeForForm4(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetApplicantTypeForForm4(licenseApplication);
        }
        #endregion

        #region Company List
        /// <summary>
        /// To Get Company List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> CompanyList(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetCompanyList(licenseApplication);
        }
        #endregion

        #region Payment Process Details
        /// <summary>
        /// To Get Payment Process Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<LicenseApplication> GetPaymentProcessDetail(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.PaymentProcessDetails(licenseApplication);
        }
        #endregion

        #region License Registered List
        /// <summary>
        /// To Get License Registered Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> GetLicenseRegisteredList(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.LicenseRegisteredList(licenseApplication);
        }
        #endregion

        #region Form4 Review Details
        /// <summary>
        /// To Get Form4 Review Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        [HttpPost]
        public async Task<LicenseApplication> Form4ReviewDetail(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.Form4Review(licenseApplication);
        }
        #endregion

        #region License Uploaded Document Details
        /// <summary>
        /// To Get License Uploaded Document Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        [HttpPost]
        public async Task<LicenseeDocUploadModel> LicenseeDocUploadDetails(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.LicenseeDocUpload(licenseApplication);
        }
        #endregion

        #region Add License Uploaded Document
        /// <summary>
        /// To Add License Uploaded Document
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        [HttpPost]
        public async Task<MessageEF> AddLicenseeDocUpload(LicenseeDocUploadModel licenseeDocUploadModel)
        {
            return await licenseeApplicationProvider.AddLicenseeDocUpload(licenseeDocUploadModel);
        }
        #endregion

        #region View Form7 Details
        /// <summary>
        /// To View Form7 Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        [HttpPost]
        public async Task<LicenseApplication> ViewForm7Details(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.ViewForm7(licenseApplication);
        }
        #endregion

        #region Security Deposit Details
        /// <summary>
        /// To Get Security Deposit Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        [HttpPost]
        public async Task<LicenseApplication> SecurityDepositDetails(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.GetSecurityDepositDetail(licenseApplication);
        }
        #endregion

        #region Add Security Deposit
        /// <summary>
        /// To Add Security Deposit
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        [HttpPost]
        public async Task<MessageEF> AddSecurity(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.AddSecurityDeposit(licenseApplication);
        }
        #endregion

        #region License Final Approval By DD
        /// <summary>
        /// License Final Approval By DD
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseFinalApproval</returns>
        [HttpPost]
        public async Task<LicenseFinalApproval> DDLicenseFinalApproval(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.LicenseFinalApprovalDetails(licenseApplication);
        }
        #endregion

        #region License Details By App Code
        /// <summary>
        /// License Details By App Code
        /// </summary>
        /// <param name="licenseMail"></param>
        /// <returns></returns>

        public async Task<LicenseMail> GetLicenseDetailsByAppCode(LicenseMail licenseMail)
        {
            return await licenseeApplicationProvider.GetLicenseDetailsByAppCode(licenseMail);
        }
        #endregion

        #region Update DSC File Path
        /// <summary>
        /// Update DSC File Path
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdatedDSCPath(UpdateDSCPath updateDSCPath)
        {
            return await licenseeApplicationProvider.UpdatedDSCPath(updateDSCPath);
        }
        #endregion

        #region License Approval ACK Detail for MSG
        /// <summary>
        /// License Approval ACK Detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<LicenseFinalApproval> LICENSE_APP_ACK(UpdateDSCPath updateDSCPath)
        {
            return await licenseeApplicationProvider.LICENSE_APP_ACK(updateDSCPath);
        }
        #endregion

        #region License App Grant Order Details for MSG
        /// <summary>
        /// License App Grant Order detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<LicenseFinalApproval> LICENSE_APP_GRANT_ORDER(UpdateDSCPath updateDSCPath)
        {
            return await licenseeApplicationProvider.LICENSE_APP_GRANT_ORDER(updateDSCPath);
        }
        #endregion

        #region Update Encrypt Password
        /// <summary>
        /// Update Encrypt Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel)
        {
            return await licenseeApplicationProvider.UpdateEncryptPassword(updateEncryptPasswordModel);
        }
        #endregion

        #region Upload Lease Deed
        /// <summary>
        /// To Upload Lease Deed 
        /// </summary>
        /// <param name="leaseDeedModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> LeaseDeedUpload(LeaseDeedModel leaseDeedModel)
        {
            return await licenseeApplicationProvider.LeaseDeedUpload(leaseDeedModel);
        }
        [HttpPost]
        public async Task<MessageEF> ApproveLeaseDeed(LeaseDeedModel leaseDeedModel)
        {
            return await licenseeApplicationProvider.ApproveLeaseDeed(leaseDeedModel);
        }
        #endregion

        #region Lease Deed Fine
        /// <summary>
        /// To Add Lease Deed Fine 
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        [HttpPost]
        public async Task<MessageEF> AddLeaseDeedFine(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.AddLeaseDeedFine(licenseApplication);
        }
        #endregion

        #region Extend Lease Deed Details
        /// <summary>
        /// Extend Lease Deed Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<LicenseApplication>> ExtendLeaseDeedDetails(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.ExtendLeaseDeedDetails(licenseApplication);
        }
        #endregion

        #region Approve Extend Lease Deed Request
        /// <summary>
        /// Approve Extend Lease Deed Request
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ApproveExtendLeaseDeedDetails(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.ApproveExtendLeaseDeedDetails(licenseApplication);
        }
        #endregion

        #region Issue Grant Order
        /// <summary>
        /// Issue Grant Order
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> IssueGrantOrder(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.IssueGrantOrder(licenseApplication);
        }
        #endregion

        #region Object Extend Lease Deed Request
        /// <summary>
        /// Object Extend Lease Deed Request
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ObjectExtendLeaseDeedDetails(LicenseApplication licenseApplication)
        {
            return await licenseeApplicationProvider.ObjectExtendLeaseDeedDetails(licenseApplication);
        }
        #endregion
    }
}