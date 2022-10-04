using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.District;
using MasterApp.Areas.Master.Models.Division;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class DistrictController : Controller
    {
        #region Global Declaration
        private readonly IDistrictMasterModel districtMasterModel;
        private readonly IDivisionMasterModel divisionMasterModel;
        List<RegionalModel> lstDivision = new List<RegionalModel>();
        RegionalModel regionalModel = new RegionalModel();
        DistrictModel districtModel = new DistrictModel();
        //List<RegionalModel> lstregionalModels = new List<RegionalModel>();
        MessageEF messageEF = new MessageEF();
        #endregion
        #region Constructor
        public DistrictController(IDistrictMasterModel districtMasterModel,IDivisionMasterModel divisionMasterModel)
        {
            this.districtMasterModel = districtMasterModel;
            this.divisionMasterModel = divisionMasterModel;
        }
        #endregion

        #region Add
        [Decryption]
        public IActionResult Add(string id="0")
        {
            
            ViewData["State"] = GetStateDetail();
            if ( ! string.IsNullOrEmpty(id) && id !="0" )
            {
                districtModel.DistrictID =Convert.ToInt32(id);
                districtModel = districtMasterModel.Edit(districtModel);
                districtModel.IsActive = districtModel.Status == "Active" ? true : false;
                ViewBag.Button = "Update"; 
                ViewData["Division"] = GetDivisionDetails(districtModel);
                return View(districtModel);
            }
            else
            { 
                districtModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(districtModel);
            }
        }

        private List<RegionalModel> GetDivisionDetails(DistrictModel districtModel)
        {
            if (districtModel.StateID != 0 && districtModel.StateID != null)
            {
                regionalModel.CHK = 4;
                regionalModel.StateID = districtModel.StateID;
                lstDivision = divisionMasterModel.View(regionalModel);
            }
            else
            {
                lstDivision = null;
            }
            return lstDivision;
        }

        private List<RegionalModel> GetStateDetail()
        {
            regionalModel.CHK = 5;
            lstDivision = divisionMasterModel.View(regionalModel);
            return lstDivision;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(DistrictModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if(string.IsNullOrEmpty(objmodel.StateID.ToString()))
                {
                    ModelState.AddModelError("StateID", "Please Select State");
                }
                if (string.IsNullOrEmpty(objmodel.RegionalID.ToString()))
                {
                    ModelState.AddModelError("RegionalID", "Please Select Division");
                }
                if (string.IsNullOrEmpty(objmodel.DistrictName))
                {
                    ModelState.AddModelError("DistrictName", "Please Enter District Name");
                }
                if (string.IsNullOrEmpty(objmodel.DistrictCode))
                {
                    ModelState.AddModelError("DistrictCode", "Please Enter District Code");
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy =  profile.UserId;

                    if (submit == "Submit")
                    {
                        messageEF = districtMasterModel.Add(objmodel);
                        if (messageEF.Satus == "1")
                        {
                            TempData["msg"] = "Data Saved Sucessfully";
                            return RedirectToAction("ViewList");
                        }
                        else if(messageEF.Satus=="2")
                        {
                            TempData["msg"] = "District Name Already Exists !!";
                            return RedirectToAction("Add");
                        }
                        else
                        {
                            ViewBag.msg = "Data not Saved Sucessfully";
                            ViewData["State"] = GetStateDetail();
                            ViewData["Division"] = GetDivisionDetails(objmodel);
                            return View(objmodel);
                        }
                    }
                    else
                    {
                        messageEF = districtMasterModel.Update(objmodel);
                        if (messageEF.Satus == "1")
                        {
                            TempData["msg"] = "Data Updated Sucessfully";
                            return RedirectToAction("ViewList");
                        }
                        else if (messageEF.Satus == "2")
                        {
                            TempData["msg"] = "District Name Already Exists !!";
                            return RedirectToAction("Add");
                        }
                        else
                        {
                            ViewBag.msg = "Data not Updated Sucessfully";
                            ViewData["State"] = GetStateDetail();
                            ViewData["Division"] = GetDivisionDetails(objmodel);
                            return View(objmodel);
                        }
                    }
                }
                else
                {
                    ViewData["State"] = GetStateDetail();
                    ViewData["Division"] = GetDivisionDetails(objmodel);
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
        public IActionResult ViewList(DistrictModel districtModel)
        {
            if(TempData["msg"]!=null)
            {
                ViewBag.msg = TempData["msg"].ToString();
            }
            List<DistrictModel> districtModels = new List<DistrictModel>();
            districtModels=districtMasterModel.View(districtModel);
            return View(districtModels);
        }

        public JsonResult GetDivisionByStateID(int? StateID)
        {
            districtModel.StateID = StateID; 
            lstDivision = GetDivisionDetails(districtModel);
            return Json(lstDivision);
        }
        #endregion

        #region Delete
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey); 
            districtModel.CreatedBy = profile.UserId;
            districtModel.DistrictID = Convert.ToInt32(id);
            messageEF = districtMasterModel.Delete(districtModel);

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