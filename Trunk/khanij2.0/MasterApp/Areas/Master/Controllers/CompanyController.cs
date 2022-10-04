// ***********************************************************************
// Assembly         : Khanij
// Author           : Sanjay kumar
// Created          : 05-jan-2021
// Modified By      : Prakash Biswal
// Modified On      : 16 Feb 2022
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Models.Company;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class CompanyController : Controller
    {
        #region Global Declartion
        ICompanyModel _objCompanyModel;
        MessageEF objobjmodel = new MessageEF();
        List<CompanyMaster> companyMasters = new List<CompanyMaster>();
        #endregion
        #region Constructor Dependency Injection
        public CompanyController(ICompanyModel objCompany)
        {
            _objCompanyModel = objCompany;
        }
        #endregion

        [Decryption]
        public IActionResult Add(string id = "0")
        {
            CompanyMaster objmodel = new CompanyMaster();
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                objmodel.CompanyId = Convert.ToInt32(id);
                objmodel = _objCompanyModel.Edit(objmodel);
                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(objmodel);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(CompanyMaster objmodel, string submit)
        {
            if (string.IsNullOrEmpty(objmodel.CompanyName))
            {
                ModelState.AddModelError("CompanyName", "Company Name is required");
            }
            if (!string.IsNullOrEmpty(objmodel.CompanyName) && (objmodel.CompanyName.Length > 50))
            {
                ModelState.AddModelError("CompanyName", "Company Name must be less than 50 characters");
            }
            if (ModelState.IsValid)
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy = profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                if (submit == "Submit")
                {
                    objobjmodel = _objCompanyModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objCompanyModel.Update(objmodel);
                }
                if (objobjmodel.Satus == "1" && submit== "Submit")
                {
                    TempData["msg"] = "Data Saved Sucessfully";
                    return RedirectToAction("ViewList");
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Data Updated Sucessfully";
                    return RedirectToAction("ViewList");
                }
                else if(objobjmodel.Satus == "2")
                {
                    ViewBag.msg = "Company Name Already Exists !!";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.msg = "Data not Save Sucessfully";
                    return View(objmodel);
                }
            }
            return View();
        }
        public IActionResult ViewList(CompanyMaster objmodel)
        {
            try
            {
                companyMasters = _objCompanyModel.View(objmodel);
                return View(companyMasters);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            CompanyMaster objmodel = new CompanyMaster();
            objmodel.CreatedBy =  profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            objmodel.CompanyId = Convert.ToInt32(id);
            objobjmodel = _objCompanyModel.Delete(objmodel);
            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Data Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
        }
        
    }
}