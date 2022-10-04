// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 21-Jan-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using MasterApp.Areas.Master.Models.Policy;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class PolicyController : Controller
    {
        IPolicyModel _objPolicymasterModel;
        private readonly IHostingEnvironment hostingEnvironment;
        MessageEF objobjmodel = new MessageEF();
        Policymaster objmodel = new Policymaster();
        public PolicyController(IPolicyModel objPolicymasterModel, IHostingEnvironment hostingEnvironment)
        {
            _objPolicymasterModel = objPolicymasterModel;
            this.hostingEnvironment = hostingEnvironment;
        }
        [Decryption]
        public IActionResult Add(string id = "0")
        {                              
            if (!string.IsNullOrEmpty(id) && id != "0")
            {               
                objmodel.PolicyID = Convert.ToInt32(id);
                objmodel = _objPolicymasterModel.Edit(objmodel);
                ViewBag.Policy = GetPolicytype(objmodel.RuleID);
                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = true;
                ViewBag.Policy = GetPolicytype(null);
                ViewBag.Button = "Submit";
                return View(objmodel);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Policymaster objmodel, string submit)
        {
            if (string.IsNullOrEmpty(objmodel.RuleID.ToString()) || objmodel.RuleID.ToString() == "0")
            {
                ModelState.AddModelError("Policy Type", "Please Select Policy Type");
            }
            if (string.IsNullOrEmpty(objmodel.PolicyName))
            {
                ModelState.AddModelError("Policy Name", "Policy Name is required");
            }
            if (string.IsNullOrEmpty(objmodel.RuleID.ToString()) || objmodel.RuleID.ToString() == "0")
            {
                ModelState.AddModelError("RuleID", "Please Select Policy Type");
                ViewBag.Policy = GetPolicytype(null);
            }
            if (string.IsNullOrEmpty(objmodel.PolicyName))
            {
                ModelState.AddModelError("PolicyName", "Policy Name is required");
            }
            if (!string.IsNullOrEmpty(objmodel.PolicyName) && (objmodel.PolicyName.Length > 50))
            {
                ModelState.AddModelError("PolicyName", "Policy Name must be less than 50 characters");
            }
            //if (objmodel.Photo == null)
            //{
            //    ModelState.AddModelError("Photo", "Upload file");
            //}
            if (ModelState.IsValid)
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy = profile.UserId;
                //objmodel.UserLoginId = 1;// profile.UserLoginId;
                
                #region File Upload
                string uniqueFileName = null; 
                string filePath = null;
                if (objmodel.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "UploadPolicy");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + objmodel.Photo.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        objmodel.Photo.CopyTo(fileStream);
                    objmodel.AttachmentName = uniqueFileName;
                    objmodel.AttachmentPath = filePath;
                }
                objmodel.Photo = null;
                
                #endregion
                if (submit == "Submit")
                {
                    objobjmodel = _objPolicymasterModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objPolicymasterModel.Update(objmodel);
                }
                if (ModelState.IsValid)
                {
                    if (objobjmodel.Satus == "1" && submit == "Submit")
                    {
                        objmodel.IsActive = true;
                        TempData["msg"] = "Policy Saved Sucessfully";
                        objmodel.PolicyName = "";
                        ModelState.Clear();
                        return RedirectToAction("Viewlist", "Policy", new { Area = "master" });
                    }
                    if (objobjmodel.Satus == "1" && submit != "Submit")
                    {
                        TempData["msg"] = "Policy Updated Sucessfully";
                        return RedirectToAction("Viewlist", "Policy", new { Area = "master" });
                    }
                    if (objobjmodel.Satus == "3")
                    {
                        ViewBag.msg = "Policy Already Exist!";
                        ViewBag.Policy = GetPolicytype(null);
                        ViewBag.Button = objmodel.PolicyID > 0 ? "Update" : "Submit";
                        return View(objmodel);
                    }
                    else
                    {
                        ViewBag.msg = "Data not Saved Sucessfully";
                        ViewBag.Policy = GetPolicytype(null);
                        ViewBag.Button = objmodel.PolicyID > 0 ? "Update" : "Submit";
                        return View(objmodel);
                    }
                }
                else
                {
                    ViewBag.Policy = GetPolicytype(null);
                    ViewBag.Button = objmodel.PolicyID > 0 ? "Update" : "Submit";
                    return View();
                }
            }
            return View();
        }
        public IActionResult ViewList(Policymaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objPolicymasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ViewList(Policymaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objPolicymasterModel.View(objmodel);
                return View();
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
            Policymaster objmodel = new Policymaster();
            objmodel.CreatedBy = (int)profile.UserId;
           
            objmodel.PolicyID = Convert.ToInt32(id);

            objobjmodel = _objPolicymasterModel.Delete(objmodel);

            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Policy Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
        }
        private SelectList GetPolicytype(int? RuleID)
        {
            List<Policymaster> listPolicyTypeResult = new List<Policymaster>();
            listPolicyTypeResult = _objPolicymasterModel.GetPolicyTypeList(objmodel);
            return new SelectList(listPolicyTypeResult, "RuleID", "RuleName", RuleID);
        }
    }
}