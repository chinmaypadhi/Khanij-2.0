using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Models.MIneral;
using MasterApp.Areas.Master.Models.StateMaster;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using MasterApp.Areas.Master.Models.Rule;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class RuleController : Controller
    {
        IRuleMasterModel _objRulemasterModel;
        MessageEF objobjmodel = new MessageEF();
        public RuleController(IRuleMasterModel objRulemasterModel)
        {
            _objRulemasterModel = objRulemasterModel;
        }
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            RuleMaster objmodel = new RuleMaster();
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                objmodel.RuleID = Convert.ToInt32(id);
                objmodel = _objRulemasterModel.Edit(objmodel);
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
        public IActionResult Add(RuleMaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy = profile.UserId ;
            if (string.IsNullOrEmpty(objmodel.RuleName))
            {
                ModelState.AddModelError("Rule Name", "Rule Name is required");
            }
            if (ModelState.IsValid)
            {

                if (submit == "Submit")
                {
                    objobjmodel = _objRulemasterModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objRulemasterModel.Update(objmodel);
                }
                if (objobjmodel.Satus == "1" && submit== "Submit")
                {
                    TempData["msg"] = "Data Save Sucessfully";
                    return RedirectToAction("ViewList");
                }
                else if(objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Data Updated Sucessfully";
                    return RedirectToAction("ViewList");
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["msg"] = "Rule Name Already Exists !!";
                    return RedirectToAction("Add");
                }
                else
                {
                    ViewBag.msg = "Data not Save Sucessfully";
                    return View(objmodel);
                }
            }
            return View();
        }

        public IActionResult ViewList(RuleMaster objmodel)
        {
            try
            {
                ViewBag.ViewList = _objRulemasterModel.View(objmodel);
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
            RuleMaster objmodel = new RuleMaster();
            objmodel.CreatedBy = (int)profile.UserId;
            objmodel.RuleID = Convert.ToInt32(id);
            objobjmodel = _objRulemasterModel.Delete(objmodel);
            if (objobjmodel.Satus == "1")
            {
                TempData["msgDel"] = "Data Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msgDel"] = "Data not Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
        }
    }
}