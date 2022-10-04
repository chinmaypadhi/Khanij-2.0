

using MasterApp.Areas.Licensee.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using MasterApp.Web;

namespace MasterApp.Areas.Licensee.Controllers
{
    [Area("Licensee")]
    public class ProfileController : Controller
    {
        #region for Global Declaration
        IUserInformationLicenseeModel _userInformation;
        ViewIBMProfile objviewIBMProfile = new ViewIBMProfile();
        ProfileCount objProfileCount = new ProfileCount();
        CTEProfile objcTEProfile = new CTEProfile();
        CTOProfile objcTOProfile = new CTOProfile();
        GrantProfile objgrantProfile = new GrantProfile();
        ECProfile objeCProfile = new ECProfile();
        AreaProfile objareaProfile = new AreaProfile();
        ApplicationProfile objapplicationProfile = new ApplicationProfile();
        LicenseeDetails objofficeProfile = new LicenseeDetails();
        MineralProfile objMineralProfile = new MineralProfile();
        #endregion
        #region Constrocutor Dependency injection
        public ProfileController(IUserInformationLicenseeModel userInformationLicenseeModel)
        {
            _userInformation = userInformationLicenseeModel;
        }
        #endregion
        public IActionResult Index()
        {
            //if (SessionWrapper.UserType.ToUpper() != "LICENSEE") //checks the user type must be dd user for the data isolation
            //{
            //    if (Id == null || Id.Value == 0) return RedirectToAction("Index", "Home", new { Area = "" });
            //    ViewBag.LicenseeId = Id.Value;
            //}
            //else
            //{
            //    Id = 0;
            //}
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

            objviewIBMProfile.CREATED_BY = profile.UserId;
            objProfileCount.CREATED_BY = profile.UserId;
            objcTEProfile.CREATED_BY = profile.UserId;
            objcTOProfile.CREATED_BY = profile.UserId;
            objgrantProfile.CREATED_BY = profile.UserId;
            objeCProfile.CREATED_BY = profile.UserId;
            objareaProfile.CREATED_BY = profile.UserId;
            objapplicationProfile.CREATED_BY = profile.UserId;
            objofficeProfile.CREATED_BY = profile.UserId;
            objofficeProfile.UserID = profile.UserId;
            objMineralProfile.CREATED_BY = profile.UserId;
            objMineralProfile.CREATED_BY = profile.UserId;
            ViewBag.ProfileIBMDetailsModel = _userInformation.GetIBMProfile(objviewIBMProfile);
            ViewBag.GetProfileCount = _userInformation.GetProfileCount(objProfileCount);
            ViewBag.CTEProfile = _userInformation.GetCTEProfile(objcTEProfile);
            ViewBag.CTOProfile = _userInformation.GetCTOProfile(objcTOProfile);
            ViewBag.GrantProfile = _userInformation.GetGrantProfile(objgrantProfile);
            ViewBag.ECProfile = _userInformation.GetECProfile(objeCProfile);
            ViewBag.AreaProfile = _userInformation.GetAreaProfile(objareaProfile);
            ViewBag.ApplicationProfile = _userInformation.GetApplicationProfile(objapplicationProfile);
            ViewBag.OfficeProfile = _userInformation.GetOfficeProfile(objofficeProfile);

            ViewBag.MineralProfile = _userInformation.GetMineralProfile(objMineralProfile);


            return View();
        }
        public IActionResult LicenseeProfile()
        {
            return View();
        }
    }
}
