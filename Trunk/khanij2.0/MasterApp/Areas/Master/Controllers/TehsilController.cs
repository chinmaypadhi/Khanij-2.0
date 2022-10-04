using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.District;
using MasterApp.Areas.Master.Models.Division;
using MasterApp.Areas.Master.Models.Tehsil;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class TehsilController : Controller
    {
        #region Global Declaration
        private readonly ITehsilMasterModel tehsilMasterModel;
        private readonly IDivisionMasterModel divisionMasterModel;
        private readonly IDistrictMasterModel districtMasterModel;
        RegionalModel regionalModel = new RegionalModel();
        List<RegionalModel> lstregionalModels = new List<RegionalModel>();
        List<DistrictModel> lstdistrictModels = new List<DistrictModel>();
        DistrictModel districtModel = new DistrictModel();
        TehsilModel tehsilModel = new TehsilModel();
        MessageEF messageEF = new MessageEF();
        #endregion

        #region Constructor
        public TehsilController(ITehsilMasterModel tehsilMasterModel, IDivisionMasterModel divisionMasterModel, IDistrictMasterModel districtMasterModel)
        {
            this.tehsilMasterModel = tehsilMasterModel;
            this.divisionMasterModel = divisionMasterModel;
            this.districtMasterModel = districtMasterModel;
        }
        #endregion

        #region Add
        [Decryption]
        public IActionResult Add(string id= "0")
        {
            ViewData["State"] = GetStateDetails();
            if ( !string.IsNullOrEmpty(id) && id != "0")
            {
                tehsilModel.TehsilID = Convert.ToInt32(id);
                tehsilModel = tehsilMasterModel.Edit(tehsilModel);
                tehsilModel.IsActive = tehsilModel.Status == "Active" ? true : false;
                ViewBag.Button = "Update"; 
                ViewData["Division"] = GetDivisionByState(tehsilModel.StateID);   
                ViewData["District"] = DistrictByDivisionID(tehsilModel.RegionalID);
                return View(tehsilModel);
            }
            else
            { 
                tehsilModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(tehsilModel);
            }
        }

        private List<RegionalModel> GetDivisionByState(int? StateID)
        {
            if (StateID != 0 && StateID != null)
            {
                regionalModel.CHK = 4;
                regionalModel.StateID = StateID;
                lstregionalModels = divisionMasterModel.View(regionalModel);
            }
            else
            {
                lstregionalModels = null;
            }
            return lstregionalModels;
        }

        private List<RegionalModel> GetStateDetails()
        {
            regionalModel.CHK = 5;
            lstregionalModels = divisionMasterModel.View(regionalModel);
            return lstregionalModels;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(TehsilModel tehsilModel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if(string.IsNullOrEmpty(tehsilModel.StateID.ToString()))
                {
                    ModelState.AddModelError("StateID","Please Select State");
                }

                if (string.IsNullOrEmpty(tehsilModel.RegionalID.ToString()))
                {
                    ModelState.AddModelError("RegionalID", "Please Select Division");
                }

                if (string.IsNullOrEmpty(tehsilModel.DistrictID.ToString()))
                {
                    ModelState.AddModelError("DistrictID", "Please Select District");
                }

                if (string.IsNullOrEmpty(tehsilModel.TehsilName))
                {
                    ModelState.AddModelError("TehsilName", "Please Enter Tehsil Name");
                }
                if (ModelState.IsValid)
                {
                    tehsilModel.CreatedBy = profile.UserId;

                    if (submit == "Submit")
                    {
                        messageEF = tehsilMasterModel.Add(tehsilModel);
                        if (messageEF.Satus == "1")
                        {
                            TempData["msg"] = "Data Saved Sucessfully";
                            return RedirectToAction("ViewList");
                        }
                        else if(messageEF.Satus=="2")
                        {
                            TempData["msg"] = "Tehsil Name Already Exist !!";
                            return RedirectToAction("Add");
                        }
                        else
                        {
                            ViewBag.msg = "Data not Saved Sucessfully";
                            ViewData["State"] = GetStateDetails();
                            ViewData["Division"] = GetDivisionByState(tehsilModel.StateID);
                            ViewData["District"] = DistrictByDivisionID(tehsilModel.RegionalID);
                            return View(tehsilModel);
                        }
                    }
                    else
                    {
                        messageEF = tehsilMasterModel.Update(tehsilModel);
                        if (messageEF.Satus == "1")
                        {
                            TempData["msg"] = "Data Update Sucessfully";
                            return RedirectToAction("ViewList");
                        }
                        else if (messageEF.Satus == "2")
                        {
                            TempData["msg"] = "Tehsil Name Already Exist !!";
                            return RedirectToAction("Add");
                        }
                        else
                        {
                            ViewBag.msg = "Data not Updated Sucessfully";
                            ViewData["State"] = GetStateDetails();
                            ViewData["Division"] = GetDivisionByState(tehsilModel.StateID);
                            ViewData["District"] = DistrictByDivisionID(tehsilModel.RegionalID);
                            return View(tehsilModel);
                        }
                    }
                    
                }
                else
                {
                    ViewData["State"] = GetStateDetails();
                    ViewData["Division"] = GetDivisionByState(tehsilModel.StateID);
                    ViewData["District"] = DistrictByDivisionID(tehsilModel.RegionalID);
                    return View(tehsilModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region View
        public IActionResult ViewList(TehsilModel tehsilModel)
        {
           if(TempData["msg"]!=null)
            {
                ViewBag.msg = TempData["msg"].ToString();
            }
            List<TehsilModel> tehsilModels = new List<TehsilModel>();
            tehsilModels = tehsilMasterModel.View(tehsilModel);
            return View(tehsilModels);
        }

        public JsonResult GetDistrictByDivisionID(int? DivisionID)
        {
            DistrictByDivisionID(DivisionID);
            return Json(lstdistrictModels);
        }

        private List<DistrictModel> DistrictByDivisionID(int? DivisionID)
        {
            if (DivisionID != 0 && DivisionID != null)
            {
                districtModel.RegionalID = DivisionID;
                lstdistrictModels = districtMasterModel.View(districtModel);
            }
            else
            {
                lstdistrictModels = null;
            }
            return lstdistrictModels;
        }
        #endregion

        #region Delete
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            tehsilModel.CreatedBy = profile.UserId;
            tehsilModel.TehsilID = Convert.ToInt32(id);
            messageEF = tehsilMasterModel.Delete(tehsilModel);

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