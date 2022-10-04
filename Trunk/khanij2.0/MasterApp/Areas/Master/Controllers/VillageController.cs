using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.District;
using MasterApp.Areas.Master.Models.Division;
using MasterApp.Areas.Master.Models.Tehsil;
using MasterApp.Areas.Master.Models.Village;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class VillageController : Controller
    {
        private readonly IVillageMaster villageMaster;
        private readonly ITehsilMasterModel tehsilMasterModel;
        private readonly IDivisionMasterModel divisionMasterModel;
        private readonly IDistrictMasterModel districtMasterModel;

        RegionalModel regionalModel = new RegionalModel();
        List<RegionalModel> lstregionalModels = new List<RegionalModel>();
        List<DistrictModel> lstdistrictModels = new List<DistrictModel>();
        List<TehsilModel> lsttehsilModels = new List<TehsilModel>();
        DistrictModel districtModel = new DistrictModel();
        TehsilModel tehsilModel = new TehsilModel();
        VillageModel villageModel = new VillageModel();
        MessageEF messageEF = new MessageEF();

        #region Constructor
        public VillageController(IVillageMaster villageMaster, ITehsilMasterModel tehsilMasterModel,
            IDivisionMasterModel divisionMasterModel, IDistrictMasterModel districtMasterModel)
        {
            this.villageMaster = villageMaster;
            this.tehsilMasterModel = tehsilMasterModel;
            this.divisionMasterModel = divisionMasterModel;
            this.districtMasterModel = districtMasterModel;
        }
        #endregion

        #region Add
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            
            ViewData["State"] = GetStateDetails();
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                villageModel.VillageID = Convert.ToInt32(id);
                villageModel = villageMaster.Edit(villageModel);
                villageModel.IsActive = villageModel.Status == "Active" ? true : false;
                ViewBag.Button = "Update";


                ViewData["Division"] = GetDivisionByStateID(villageModel.StateID); 
                ViewData["District"] = GetDistrictByDivisionID(villageModel.RegionalID); 
                ViewData["Tehsil"] = TehsilDetailsByDistrictID(villageModel.DistrictID);
                return View(villageModel);
            }
            else
            {
                villageModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(villageModel);
            }
        }

        private List<DistrictModel> GetDistrictByDivisionID(int? RegionalID)
        {
            if(RegionalID!=0 && RegionalID!=null)
            {
                districtModel.RegionalID = RegionalID;
                lstdistrictModels = districtMasterModel.View(districtModel);
            }
            else
            {
                lstdistrictModels = null;
            }
           
            return lstdistrictModels;
        }

        private List<RegionalModel> GetDivisionByStateID(int? StateID)
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
        public IActionResult Add(VillageModel villageModel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if(string.IsNullOrEmpty(villageModel.StateID.ToString()))
                {
                    ModelState.AddModelError("StateID", "Please Select State");
                }
                if (string.IsNullOrEmpty(villageModel.RegionalID.ToString()))
                {
                    ModelState.AddModelError("RegionalID", "Please Select Division");
                }
                if (string.IsNullOrEmpty(villageModel.DistrictID.ToString()))
                {
                    ModelState.AddModelError("DistrictID", "Please Select District");
                }
                if (string.IsNullOrEmpty(villageModel.TehsilID.ToString()))
                {
                    ModelState.AddModelError("TehsilID", "Please Select Tehsil");
                }
                if (string.IsNullOrEmpty(villageModel.VillageName))
                {
                    ModelState.AddModelError("VillageName", "Please Enter Village Name");
                }
                if (ModelState.IsValid)
                {
                    villageModel.CreatedBy =  profile.UserId;

                    if (submit == "Submit")
                    {
                        messageEF = villageMaster.Add(villageModel);
                    }
                    else
                    {
                        messageEF = villageMaster.Update(villageModel);
                    }
                    if (messageEF.Satus == "1" && submit== "Submit")
                    {
                        TempData["msg"] = "Data Saved Sucessfully";
                        return RedirectToAction("ViewList");
                    }
                    if (messageEF.Satus == "1")
                    {
                        TempData["msg"] = "Data Updated Sucessfully";
                        return RedirectToAction("ViewList");
                    }
                    if(messageEF.Satus=="2")
                    {
                        TempData["msg"] = "Village Name Already Exist !!";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        ViewBag.msg = "Data not Saved Sucessfully";
                        ViewData["State"] = GetStateDetails();
                        ViewData["Division"] = GetDivisionByStateID(villageModel.StateID);
                        ViewData["District"] = GetDistrictByDivisionID(villageModel.RegionalID);
                        ViewData["Tehsil"] = TehsilDetailsByDistrictID(villageModel.DistrictID);
                        return View(villageModel);
                    }
                }
                else
                {
                    ViewData["State"] = GetStateDetails();
                    ViewData["Division"] = GetDivisionByStateID(villageModel.StateID);
                    ViewData["District"] = GetDistrictByDivisionID(villageModel.RegionalID);
                    ViewData["Tehsil"] = TehsilDetailsByDistrictID(villageModel.DistrictID);
                    return View(villageModel);
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
            if (TempData["msg"] != null)
            {
                ViewBag.msg = TempData["msg"].ToString();
            }
            List<VillageModel> villageModels = new List<VillageModel>();
            villageModels = villageMaster.View(villageModel);
            return View(villageModels);
        }

        public JsonResult GetTehsilByDistrictID(int? DistrictID)
        {
            lsttehsilModels=TehsilDetailsByDistrictID(DistrictID);
            return Json(lsttehsilModels);
        }

        private List<TehsilModel> TehsilDetailsByDistrictID(int? DistrictID)
        {
            if (DistrictID != 0 && DistrictID != null)
            {
                tehsilModel.DistrictID = DistrictID;
                lsttehsilModels = tehsilMasterModel.View(tehsilModel);
            }
            else
            {
                lsttehsilModels = null;
            }
            return lsttehsilModels;
        }
        #endregion

        #region Delete
        [Decryption]
        public IActionResult Delete(string id ="0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            villageModel.CreatedBy = profile.UserId;
            villageModel.VillageID = Convert.ToInt32(id);
            messageEF = villageMaster.Delete(villageModel);

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