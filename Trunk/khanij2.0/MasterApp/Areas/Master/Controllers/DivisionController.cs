using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Division;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class DivisionController : Controller
    {
        #region Global Declaration
        private readonly IDivisionMasterModel divisionMasterModel;
        RegionalModel regionalModel = new RegionalModel();
        List<RegionalModel> lstregionalModels = new List<RegionalModel>();
        MessageEF messageEF = new MessageEF();
        #endregion
        #region Constructor
        public DivisionController(IDivisionMasterModel divisionMasterModel)
        {
            this.divisionMasterModel = divisionMasterModel;
        }
        #endregion

        #region Add
        [Decryption]
        public IActionResult Add(string id="0")
        {
            ViewData["State"] = GetStateDetails();
            regionalModel.CHK = 0;
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                regionalModel.RegionalID = Convert.ToInt32(id);
                regionalModel = divisionMasterModel.Edit(regionalModel);
                regionalModel.IsActive = regionalModel.Status == "Active" ? true : false;
                ViewBag.Button = "Update";
                return View(regionalModel);
            }
            else
            {
                regionalModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(regionalModel);
            }
        }
        private List<RegionalModel> GetStateDetails()
        {
            regionalModel.CHK = 5;
            lstregionalModels = divisionMasterModel.View(regionalModel);
            return lstregionalModels;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(RegionalModel objmodel, string submit)
        {
            
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if(string.IsNullOrEmpty(objmodel.StateID.ToString()))
                {
                    ModelState.AddModelError("StateID", "Please Select State");
                }

                if (string.IsNullOrEmpty(objmodel.RegionalName))
                {
                    ModelState.AddModelError("RegionalName", "Please Enter Division");
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy =  profile.UserId;

                    if (submit == "Submit")
                    {
                        messageEF = divisionMasterModel.Add(objmodel);
                        if (messageEF.Satus == "1")
                        {
                            TempData["msg"] = "Data Saved Sucessfully";
                            return RedirectToAction("ViewList");
                        }
                        else if(messageEF.Satus=="2")
                        {
                            TempData["msg"] = "Division Name Already Exists !!";
                            return RedirectToAction("Add");
                        }
                        else
                        {
                            ViewData["State"] = GetStateDetails();
                            ViewBag.msg = "Data not Saved Sucessfully";
                            return View(objmodel);
                        }
                    }
                    else
                    {
                        messageEF = divisionMasterModel.Update(objmodel);
                        if (messageEF.Satus == "1")
                        {
                            TempData["msg"] = "Data Updated Sucessfully";
                            return RedirectToAction("ViewList");
                        }
                        else if (messageEF.Satus == "2")
                        {
                            TempData["msg"] = "Division Name Already Exists";
                            return RedirectToAction("Add");
                        }
                        else
                        {
                            ViewData["State"] = GetStateDetails();
                            ViewBag.msg = "Data not Updated Sucessfully";
                            return View(objmodel);
                        }
                    }
                    
                }
                else
                {
                    ViewData["State"] = GetStateDetails(); 
                    return View(objmodel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region View
        public IActionResult ViewList()
        {
            try
            {
                if(TempData["msg"]!=null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                regionalModel.CHK = 4;
                List<RegionalModel> lstRegionalModel = divisionMasterModel.View(regionalModel);
                return View(lstRegionalModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete 
        [Decryption]
        public IActionResult Delete(string id ="0" )
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey); 
            regionalModel.CreatedBy = profile.UserId;
            regionalModel.RegionalID = Convert.ToInt32(id);
            messageEF = divisionMasterModel.Delete(regionalModel);

            if (messageEF.Satus == "1")
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
        #endregion
    }
}