using MasterApp.Areas.Licensee.Models;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Licensee.Controllers
{
    [Area("Licensee")]
    public class LicenseeRenewalController : Controller
    { 
        private readonly ILicenseeRenewalModel licenseeRenewalModel;
        List<LicenseApplication> lstlicenseApplication = new List<LicenseApplication>();
        LicenseApplication licenseApplication = new LicenseApplication();
        public LicenseeRenewalController(ILicenseeRenewalModel licenseeRenewalModel)
        {
            this.licenseeRenewalModel = licenseeRenewalModel;
        }
        public IActionResult ApplyRenewal()
        {
            return View();
        }

       
        public IActionResult Apply()
        {
            lstlicenseApplication = licenseeRenewalModel.GetDistrictListForm4(licenseApplication);
            ViewData["ApplicationForDistrict"] = lstlicenseApplication;

            lstlicenseApplication = licenseeRenewalModel.GetLicenseeType(licenseApplication);
            ViewData["LicenseeType"] = lstlicenseApplication;

            lstlicenseApplication = licenseeRenewalModel.GetMineralTypeList(licenseApplication);
            ViewData["MineralType"] = lstlicenseApplication;

            lstlicenseApplication = licenseeRenewalModel.GetDistrictList(licenseApplication);
            ViewData["District"] = lstlicenseApplication;

            lstlicenseApplication = licenseeRenewalModel.GetApplicantTypeForForm4(licenseApplication);
            ViewData["ApplicantTypeForForm4"] = lstlicenseApplication;

            lstlicenseApplication = licenseeRenewalModel.GetCompanyList(licenseApplication);
            ViewData["Company"] = lstlicenseApplication;
            return View(licenseApplication);
        }

        [HttpPost]
        public IActionResult Apply(LicenseApplication licenseApplication)
        {
             
            return View( );
        }

        #region Get Mineral Name By Mineral Type
        /// <summary>
        /// To Get Mineral Name
        /// </summary>
        /// <param name="mineraltypes"></param>
        /// <returns></returns>

        public JsonResult GetCascadeMineral(int? mineraltypes)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (mineraltypes != null)
                {
                    licenseApplication.MineralTypeId = mineraltypes;
                    licenseApplication.UserId = profile == null ? null : profile.UserId;
                    lstlicenseApplication = licenseeRenewalModel.GetMineralNameFromMineralType(licenseApplication);
                    return Json(lstlicenseApplication);
                }
                else
                    return Json(null);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion

        #region Get Mineral Form By Mineral Id
        /// <summary>
        /// To Get Mineral Form Name
        /// </summary>
        /// <param name="mineralid"></param>
        /// <returns></returns>
        
        public JsonResult GetCascadeMineralForm(string mineralid)
        {
            try
            {
                if (mineralid != null)
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    licenseApplication.MineralId = Convert.ToInt32(mineralid);
                    licenseApplication.UserId = profile == null ? null : profile.UserId;
                    lstlicenseApplication = licenseeRenewalModel.GetMineralNatureListFromMineralIdList(licenseApplication);
                    return Json(lstlicenseApplication);
                }
                else
                    return Json(null);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion

        #region Get Mineral Grade By Mineral Id and Mineral Form Id
        /// <summary>
        /// To Get Mineral Grade
        /// </summary>
        /// <param name="mineralid,MineralNatureList"></param>
        /// <returns></returns>
        
        public JsonResult GetCascadeMineralGrade(string mineralid, string MineralNatureList)
        {
            try
            {
                if (!string.IsNullOrEmpty(mineralid))
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    licenseApplication.MineralIdList = mineralid;
                    licenseApplication.MineralNatureList = MineralNatureList;
                    licenseApplication.UserId = profile == null ? null : profile.UserId; //1;
                    lstlicenseApplication = licenseeRenewalModel.GetMineralGradeListFromMineralIdList(licenseApplication);
                    return Json(lstlicenseApplication);
                }
                else
                    return Json(null);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion

        #region Get Tehsil Data By District Id
        /// <summary>
        /// To Get TehsilData From DistrictID
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>
        
        public JsonResult GetTehsilDataFromDistrictID(int? DistrictId)
        {
            try
            {
                licenseApplication.DistrictId = DistrictId;
                lstlicenseApplication = licenseeRenewalModel.GetTehsilListByDistrictID(licenseApplication);
                return Json(lstlicenseApplication);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }
        #endregion

        #region Get Village Data By Tehsil Id
        /// <summary>
        /// To Get Village Data From TehsilID
        /// </summary>
        /// <param name="TehsilId"></param>
        /// <returns></returns>
        
        public JsonResult GetVillageDataFromTehsilID(int? TehsilId)
        {
            try
            {
                licenseApplication.TehsilID = TehsilId;
                lstlicenseApplication = licenseeRenewalModel.GetvillageFromTehsilID(licenseApplication);
                return Json(lstlicenseApplication);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }
        #endregion
        public IActionResult ViewStatus()
        {
            return View();
        }
    }
}
