using MasterApp.ActionFilter;
using MasterApp.Areas.DMO.Models;
using MasterApp.Model.ExceptionList;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.DMO.Controllers
{
    [Area("DMO")]
    public class LicenseeProfileController : Controller
    {
        IUserInformationLicenseeAothorityModel _userInformation;
        DDProfileCount objProfileCount = new DDProfileCount();
        List<DDProfileCount> Userlist = new List<DDProfileCount>();
        private readonly IExceptionProvider _objIExceptionProvider;

        public LicenseeProfileController(IUserInformationLicenseeAothorityModel objibmdetailsmodel, IExceptionProvider objIExceptionProvider)
        {
            _userInformation = objibmdetailsmodel;
            _objIExceptionProvider = objIExceptionProvider;
        }

        public IActionResult ViewLicenseeIBMProfileRequests(ViewLicenseeDetailsAuthority objLicensee)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objLicensee.UserId =Convert.ToInt32(session.UserId);
            List<ViewLicenseeDetailsAuthority> listobj = _userInformation.ViewIBMDetailsLiecnsees(objLicensee);
            return View(listobj);
        }
        public IActionResult ViewLicenseeGrantProfileRequests(ViewLicenseeDetailsAuthority objLicensee)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objLicensee.UserId = Convert.ToInt32(session.UserId);
            List<ViewLicenseeDetailsAuthority> listobj = _userInformation.ViewGrantDetailsLiecnsees(objLicensee);
            return View(listobj);
        }
        /// <summary>
        /// View Environmental Clearance Requests Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public IActionResult ViewLicenseeECProfileRequests(ViewLicenseeDetailsAuthority objLicensee)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objLicensee.UserId = Convert.ToInt32(session.UserId);
            List<ViewLicenseeDetailsAuthority> listobj = _userInformation.ViewECDetailsLiecnsees(objLicensee);
            return View(listobj);
        }
        /// <summary>
        /// View CTE Requests Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public IActionResult ViewLicenseeCTEProfileRequests(ViewLicenseeDetailsAuthority objLicensee)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objLicensee.UserId = Convert.ToInt32(session.UserId);
            List<ViewLicenseeDetailsAuthority> listobj = _userInformation.ViewCTEDetailsLiecnsees(objLicensee);
            return View(listobj);
        }
        public IActionResult ViewLicenseeCTOProfileRequests(ViewLicenseeDetailsAuthority objLicensee)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objLicensee.UserId = Convert.ToInt32(session.UserId);
            List<ViewLicenseeDetailsAuthority> listobj = _userInformation.ViewCTODetailsLiecnsees(objLicensee);
            return View(listobj);
        }
        public IActionResult ViewLicenseeAreaProfileRequests(ViewLicenseeDetailsAuthority objLicensee)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objLicensee.UserId = Convert.ToInt32(session.UserId);
            List<ViewLicenseeDetailsAuthority> listobj = _userInformation.ViewAreaDetailsLiecnsees(objLicensee);
            return View(listobj);
        }
        public IActionResult ViewLicenseeOfficeProfileRequests(ViewLicenseeDetailsAuthority objLicensee)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objLicensee.UserId = Convert.ToInt32(session.UserId);
            List<ViewLicenseeDetailsAuthority> listobj = _userInformation.ViewOfficeDetailsLiecnsees(objLicensee);
            return View(listobj);
        }
        public IActionResult ViewLicenseeApplicationProfileRequests(ViewLicenseeDetailsAuthority objLicensee)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objLicensee.UserId = Convert.ToInt32(session.UserId);
            List<ViewLicenseeDetailsAuthority> listobj = _userInformation.ViewApplicationDetailsLiecnsees(objLicensee);
            return View(listobj);
        }
        public IActionResult ViewLicenseeMineralProfileRequests(ViewLicenseeDetailsAuthority objLicensee)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objLicensee.UserId = Convert.ToInt32(session.UserId);
            List<ViewLicenseeDetailsAuthority> listobj = _userInformation.ViewMineralDetailsLiecnsees(objLicensee);
            return View(listobj);
        }

        /// <summary>
        /// To show All Requests To DD
        /// </summary>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> AllRequest(string MMenuId = "0")
        {
            if(MMenuId=="0")
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objProfileCount.CREATED_BY = Convert.ToInt32(profile.UserId);
                ViewBag.LicenseeUser = await GetLienseeUsersList();
                DDProfileCount dDProfileCount = _userInformation.GetDDProfileCount(objProfileCount);
                return View(dDProfileCount);
            }
            else
            {
                HttpContext.Session.SetInt32("MMenuId", Convert.ToInt32(MMenuId));
                HttpContext.Session.Set<List<MenuEF>>("Index", GetIndexMenuList());
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objProfileCount.CREATED_BY = Convert.ToInt32(profile.UserId);
                ViewBag.LicenseeUser = await GetLienseeUsersList();
                DDProfileCount dDProfileCount = _userInformation.GetDDProfileCount(objProfileCount);
                return View(dDProfileCount);
            }
            
        }
        /// <summary>
        /// To Bind Licensee Dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<SelectList> GetLienseeUsersList()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objProfileCount.UserId = Convert.ToInt32(profile.UserId);
                Userlist = await _userInformation.GetLisenseeUserList(objProfileCount);
                if (Userlist.Any())
                {
                    return new SelectList(Userlist, "UserId", "ApplicantName");
                }
                else
                {
                    return new SelectList(null, "", "");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// To Filter According to User Selected in Dropdowonlist
        /// </summary>
        /// <param name="IndiviudalId"></param>
        /// <returns></returns>
        public JsonResult GetIndividualCount(int? IndiviudalId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objProfileCount.CREATED_BY = Convert.ToInt32(profile.UserId);
            objProfileCount.IndividualId = IndiviudalId;
            DDProfileCount dDProfileCount = _userInformation.GetDDProfileCount(objProfileCount);
            return Json(dDProfileCount);
        }


        /// <summary>
        /// Bind Menu list details in leftsider
        /// </summary>
        /// <returns></returns>
        public List<MenuEF> GetIndexMenuList()
        {
            List<MenuEF> Listmenu = new List<MenuEF>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            menuonput objmenu = new menuonput();
            try
            {
                objmenu.UserID = Convert.ToInt32(profile.UserId);
                objmenu.MineralId = Convert.ToInt32(profile.MineralId);
                objmenu.MineralName = profile.MineralName;
                objmenu.MMenuId = HttpContext.Session.GetInt32("MMenuId");
                Listmenu = _objIExceptionProvider.MenuList(objmenu);
                return Listmenu;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Listmenu = null;
                objmenu = null;
            }
        }
    }
}
