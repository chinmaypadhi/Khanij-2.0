using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.Licensee.Models.LicenseeApplication
{
    public class LicenseeApplicationModel : ILicenseeApplicationModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public LicenseeApplicationModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        #region Add Licensee
        /// <summary>
        /// To Add Licensee Application
        /// </summary>
        /// <param name="createLicenseApplication"></param>
        /// <returns>MessageEF</returns>
        public MessageEF Add(CreateLicenseApplication createLicenseApplication)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/Add", JsonConvert.SerializeObject(createLicenseApplication)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Add Licensee Uploaded Document
        /// <summary>
        /// To Add Licensee Uploaded Document
        /// </summary>
        /// <param name="licenseeDocUploadModel"></param>
        /// <returns>MessageEF</returns>
        public MessageEF AddLicenseeDocUpload(LicenseeDocUploadModel licenseeDocUploadModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/AddLicenseeDocUpload", JsonConvert.SerializeObject(licenseeDocUploadModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Add Security Deposit
        /// <summary>
        /// To Add Licensee Security Deposit
        /// </summary>
        /// <param name="licenseeDocUploadModel"></param>
        /// <returns>MessageEF</returns>
        public MessageEF AddSecurityDeposit(LicenseApplication licenseApplication)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/AddSecurity", JsonConvert.SerializeObject(licenseApplication)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete Licensee
        public MessageEF Delete(LicenseApplication licenseApplication)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Edit Licensee Application
        /// <summary>
        /// To Update Licensee Application
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public LicenseApplication Edit(LicenseApplication licenseApplication)
        {
            try
            {
                licenseApplication = JsonConvert.DeserializeObject<LicenseApplication>(_objIHttpWebClients.PostRequest("LicenseApplication/Edit", JsonConvert.SerializeObject(licenseApplication)));
                return licenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Form4 Review
        /// <summary>
        /// To Review Form4
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public LicenseApplication Form4Review(LicenseApplication licenseApplication)
        {
            try
            {
                licenseApplication = JsonConvert.DeserializeObject<LicenseApplication>(_objIHttpWebClients.PostRequest("LicenseApplication/Form4ReviewDetail", JsonConvert.SerializeObject(licenseApplication)));
                return licenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Application Type For Form4
        /// <summary>
        /// Application Type For Form4
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public List<LicenseApplication> GetApplicantTypeForForm4(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
                lstLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/ApplicantTypeForForm4", JsonConvert.SerializeObject(licenseApplication)));
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Company List
        /// <summary>
        /// Get Company List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public List<LicenseApplication> GetCompanyList(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
                lstLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/CompanyList", JsonConvert.SerializeObject(licenseApplication)));
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get District List
        /// <summary>
        /// Get District List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public List<LicenseApplication> GetDistrictList(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
                lstLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/DistrictList", JsonConvert.SerializeObject(licenseApplication)));
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get District List Form4
        /// <summary>
        /// Get District List Form4
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public List<LicenseApplication> GetDistrictListForm4(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
                lstLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/DistrictListForm4", JsonConvert.SerializeObject(licenseApplication)));
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Licensee Type
        /// <summary>
        /// Get Licensee Type
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public List<LicenseApplication> GetLicenseeType(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
                lstLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/LicenseeType", JsonConvert.SerializeObject(licenseApplication)));
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Mineral Grade List From MineralId List
        /// <summary>
        /// To Get Mineral Grade List From MineralId List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public List<LicenseApplication> GetMineralGradeListFromMineralIdList(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
                lstLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/MineralGradeListFromMineralIdList", JsonConvert.SerializeObject(licenseApplication)));
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get MineralName From MineralType
        /// <summary>
        /// To Get MineralName From MineralType
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public List<LicenseApplication> GetMineralNameFromMineralType(LicenseApplication licenseApplication)
        {
            try
            {

                List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
                lstLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/MineralNameFromMineralType", JsonConvert.SerializeObject(licenseApplication)));
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get MineralNature List FromMineralId List
        /// <summary>
        /// To Get MineralNature List FromMineralId List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public List<LicenseApplication> GetMineralNatureListFromMineralIdList(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
                lstLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/MineralNatureListFromMineralIdList", JsonConvert.SerializeObject(licenseApplication)));
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get MineralType List
        /// <summary>
        /// To Get MineralNature List FromMineralId List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public List<LicenseApplication> GetMineralTypeList(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
                lstLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/MineralTypeList", JsonConvert.SerializeObject(licenseApplication)));
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Security Deposit Detail
        /// <summary>
        /// To Get Security Deposit Detail
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public LicenseApplication GetSecurityDepositDetail(LicenseApplication licenseApplication)
        {
            try
            {
                licenseApplication = JsonConvert.DeserializeObject<LicenseApplication>(_objIHttpWebClients.PostRequest("LicenseApplication/SecurityDepositDetails", JsonConvert.SerializeObject(licenseApplication)));
                return licenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Tehsil List By DistrictID
        /// <summary>
        /// To Get Tehsil List By DistrictID
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public List<LicenseApplication> GetTehsilListByDistrictID(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
                lstLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/TehsilListByDistrictID", JsonConvert.SerializeObject(licenseApplication)));
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get village From TehsilID
        /// <summary>
        /// To Get village From TehsilID
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public List<LicenseApplication> GetvillageFromTehsilID(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
                lstLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/VillageFromTehsilID", JsonConvert.SerializeObject(licenseApplication)));
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Licensee Uploaded Document 
        /// <summary>
        /// To Get Licensee Uploaded Document
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public LicenseeDocUploadModel LicenseeDocUpload(LicenseApplication licenseApplication)
        {
            try
            {
                LicenseeDocUploadModel licenseeDocUploadModel = new LicenseeDocUploadModel();
                licenseeDocUploadModel = JsonConvert.DeserializeObject<LicenseeDocUploadModel>(_objIHttpWebClients.PostRequest("LicenseApplication/LicenseeDocUploadDetails", JsonConvert.SerializeObject(licenseApplication)));
                return licenseeDocUploadModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get License Final Approval Details
        /// <summary>
        /// To Get License Final Approval Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public LicenseFinalApproval LicenseFinalApprovalDetails(LicenseApplication licenseApplication)
        {
            try
            {
                LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
                licenseFinalApproval = JsonConvert.DeserializeObject<LicenseFinalApproval>(_objIHttpWebClients.PostRequest("LicenseApplication/DDLicenseFinalApproval", JsonConvert.SerializeObject(licenseApplication)));
                return licenseFinalApproval;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Get License Registered List
        /// <summary>
        /// To Get License Registered List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public List<LicenseApplication> LicenseRegisteredList(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> listLicenseApplication = new List<LicenseApplication>();
                listLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/GetLicenseRegisteredList", JsonConvert.SerializeObject(licenseApplication)));
                return listLicenseApplication;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Get Payment Process Detail
        /// <summary>
        /// To Get Payment Process Detail
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public LicenseApplication PaymentProcessDetail(LicenseApplication licenseApplication)
        {
            try
            {
                licenseApplication = JsonConvert.DeserializeObject<LicenseApplication>(_objIHttpWebClients.PostRequest("LicenseApplication/GetPaymentProcessDetail", JsonConvert.SerializeObject(licenseApplication)));
                return licenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Licensee
        /// <summary>
        /// Update Licensee
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        public MessageEF Update(LicenseApplication licenseApplication)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region View Licensee Application
        /// <summary>
        /// View Licensee Application
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public List<LicenseApplication> View(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> listLicenseApplication = new List<LicenseApplication>();
                listLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/ViewDetails", JsonConvert.SerializeObject(licenseApplication)));
                return listLicenseApplication;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View Form7
        /// <summary>
        /// View Form7
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public LicenseApplication ViewForm7(LicenseApplication licenseApplication)
        {
            try
            {
                licenseApplication = JsonConvert.DeserializeObject<LicenseApplication>(_objIHttpWebClients.PostRequest("LicenseApplication/ViewForm7Details", JsonConvert.SerializeObject(licenseApplication)));
                return licenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get License Details By AppCode
        public LicenseMail GetLicenseDetailsByAppCode(LicenseMail licenseMail)
        {
            try
            {
                licenseMail = JsonConvert.DeserializeObject<LicenseMail>(_objIHttpWebClients.PostRequest("LicenseApplication/GetLicenseDetailsByAppCode", JsonConvert.SerializeObject(licenseMail)));
                return licenseMail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update DSC Path
        /// <summary>
        /// Update DSC Path
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public MessageEF UpdatedDSCPath(UpdateDSCPath updateDSCPath)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/UpdatedDSCPath", JsonConvert.SerializeObject(updateDSCPath)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region LICENSE_APP_ACK Detail for MSG
        /// <summary>
        /// LICENSE APP ACK Detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public LicenseFinalApproval LICENSE_APP_ACK(UpdateDSCPath updateDSCPath)
        {
            try
            {
                LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
                licenseFinalApproval = JsonConvert.DeserializeObject<LicenseFinalApproval>(_objIHttpWebClients.PostRequest("LicenseApplication/LICENSE_APP_ACK", JsonConvert.SerializeObject(updateDSCPath)));
                return licenseFinalApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region License App Granr Order Details for MSG
        /// <summary>
        /// License App Granr Order Details for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public LicenseFinalApproval LICENSE_APP_GRANT_ORDER(UpdateDSCPath updateDSCPath)
        {
            try
            {
                LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
                licenseFinalApproval = JsonConvert.DeserializeObject<LicenseFinalApproval>(_objIHttpWebClients.PostRequest("LicenseApplication/LICENSE_APP_GRANT_ORDER", JsonConvert.SerializeObject(updateDSCPath)));
                return licenseFinalApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Encrypted Password
        /// <summary>
        /// Update Encrypted Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        public MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel)
        {
            try
            {

                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/UpdateEncryptPassword", JsonConvert.SerializeObject(updateEncryptPasswordModel)));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Lease Deed
        public MessageEF LeaseDeedUpload(LeaseDeedModel leaseDeedModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/LeaseDeedUpload", JsonConvert.SerializeObject(leaseDeedModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF ApproveLeaseDeed(LeaseDeedModel leaseDeedModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/ApproveLeaseDeed", JsonConvert.SerializeObject(leaseDeedModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
       
        #region Add Lease Deed Fine 
        /// <summary>
        /// To Add Licensee Security Deposit
        /// </summary>
        /// <param name="licenseeDocUploadModel"></param>
        /// <returns>MessageEF</returns>
        public MessageEF AddLeaseDeedFine(LicenseApplication licenseApplication)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/AddLeaseDeedFine", JsonConvert.SerializeObject(licenseApplication)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ExtendLease Deed Details
        /// <summary>
        /// ExtendLease Deed Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        public List<LicenseApplication> ExtendLeaseDeedDetails(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication> listLicenseApplication = new List<LicenseApplication>();
                listLicenseApplication = JsonConvert.DeserializeObject<List<LicenseApplication>>(_objIHttpWebClients.PostRequest("LicenseApplication/ExtendLeaseDeedDetails", JsonConvert.SerializeObject(licenseApplication)));
                return listLicenseApplication;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Approve Extend Lease Deed Request
        /// <summary>
        /// Approve Extend Lease Deed Request
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        public MessageEF ApproveExtendLeaseDeedDetails(LicenseApplication licenseApplication)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/ApproveExtendLeaseDeedDetails", JsonConvert.SerializeObject(licenseApplication))); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Issue Grand Order
        /// <summary>
        /// Issue Grand Order
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        public MessageEF IssueGrantOrder(LicenseApplication licenseApplication)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/IssueGrantOrder", JsonConvert.SerializeObject(licenseApplication)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
