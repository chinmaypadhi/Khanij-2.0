using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Country;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class CountryController : Controller
    {
        private readonly ICountryMasterModel countryMasterModel;
        CountryMaster countryMaster = new CountryMaster();
        List<CountryMaster> listcountryMaster = new List<CountryMaster>();
        MessageEF messageEF = new MessageEF();

        public CountryController(ICountryMasterModel countryMasterModel)
        {
            this.countryMasterModel = countryMasterModel;
        }


        /// <summary>
        /// Get Country By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            if (TempData["msg"] != null)
            {
                ViewBag.msg = TempData["msg"].ToString();
            }
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                countryMaster.CountryId = Convert.ToInt32(id);
                countryMaster = countryMasterModel.EditCountry(countryMaster);
                countryMaster.IsActive = countryMaster.Status == "Active" ? true : false;
                ViewBag.Button = "Update";
                return View(countryMaster);
            }
            else
            {
                countryMaster.IsActive = true;
                ViewBag.Button = "Submit";
                return View(countryMaster);
            }
           

        }

        /// <summary>
        /// Save Country Details
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(CountryMaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
               
                if (string.IsNullOrEmpty(objmodel.CountryName))
                {
                    ModelState.AddModelError("CountryName", "Please Enter Country");
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy = profile.UserId;

                    if (submit == "Submit")
                    {
                        messageEF = countryMasterModel.AddCountry(objmodel);
                    }
                    else
                    {
                        messageEF = countryMasterModel.UpdateCountry(objmodel);
                    }
                    if (messageEF.Satus == "1" && submit == "Submit")
                    {
                        TempData["msg"] = "Data Saved Sucessfully";
                        return RedirectToAction("ViewList");
                    }
                    if (messageEF.Satus == "1" )
                    {
                        TempData["msg"] = "Data Updated Sucessfully";
                        return RedirectToAction("ViewList");
                    }
                    if (messageEF.Satus == "2")
                    {
                        TempData["msg"] = "Data Already Exist!!";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        TempData["msg"] = "Data not Saved Sucessfully";
                        return RedirectToAction("Add");
                    }
                   
                }
                else
                { 
                    return View(objmodel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
        /// <summary>
        /// View Country Details
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>
        
        public IActionResult ViewList(CountryMaster countryMaster)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }

                listcountryMaster = countryMasterModel.ViewCountry(countryMaster);
                return View(listcountryMaster);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            countryMaster.CreatedBy = profile.UserId;
            countryMaster.CountryId = Convert.ToInt32(id);
            messageEF = countryMasterModel.DeleteCountry(countryMaster);

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
      
    }
}
