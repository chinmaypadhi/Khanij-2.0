using MasterApp.Models.Utility;
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Licensee.Models
{
    public class LicenseeRenewalModel : ILicenseeRenewalModel
    {
        private readonly IHttpWebClients _objIHttpWebClients;
        public LicenseeRenewalModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

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
    }
}
