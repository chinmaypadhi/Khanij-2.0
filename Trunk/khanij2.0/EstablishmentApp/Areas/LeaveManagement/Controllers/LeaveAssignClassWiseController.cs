//  Controller Name          : LeaveManagement
//  Desciption               : Leave assign class wise 
//  Created By               : Suresh Kumar Behera
//  Created On               : 13-Jul-2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentApp.Areas.LeaveManagement.Models.LeaveManagement;
using Microsoft.AspNetCore.Mvc.Rendering;
using EstablishmentApp.Web;
using EstablishmentEf;

using EstablishmentApp.ActionFilter;

namespace EstablishmentApp.Areas.LeaveManagement.Controllers
{
    [Area("LeaveManagement")]
    public class LeaveAssignClassWiseController : Controller
    {
        //-----security----
        private ILeaveAssignClassWiseModel _LeaveManagementModel;
        public LeaveAssignClassWiseController(ILeaveAssignClassWiseModel LeaveManagementModel)
        {
            _LeaveManagementModel = LeaveManagementModel;
        }

        #region Add leave assign class wise
        /// <summary>
        /// add leave assign class wise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Decryption]
        public async Task<IActionResult> AddLeaveAssignClassWise(string id = "0")
        {
            
            LeaveAssignClassWise objmodel = new LeaveAssignClassWise();
            try
            {
                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                ViewBag.EmployeeClass = Enumerable.Empty<SelectListItem>();
                ViewBag.LeaveType = Enumerable.Empty<SelectListItem>();

                //---Bind Employee class

                objLeaveDropDown.Check = 1;
                var varEmployeeClass = await _LeaveManagementModel.BindEmployeeClass(objLeaveDropDown);
                ViewBag.EmployeeClass = varEmployeeClass.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---Bind Leave Type
                objLeaveDropDown.Check = 2;
                var varLeaveType = await _LeaveManagementModel.BindLeaveTypeClass(objLeaveDropDown);

                ViewBag.LeaveType = varLeaveType.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    int iId = Convert.ToInt32(id);
                    objmodel.Check = 3;
                    objmodel.intId = iId;
                    objmodel = await _LeaveManagementModel.ViewLeaveAssignClassWiseDetails(objmodel);
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.Button = "Submit";
                    return View(objmodel);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// add leave assign class wise
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddLeaveAssignClassWise(LeaveAssignClassWise objmodel, string submit)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;

                if (string.IsNullOrEmpty(objmodel.intClassId.ToString().Trim()))
                {
                    ModelState.AddModelError("intClassId", "Employee Class is required");
                }
                if (string.IsNullOrEmpty(objmodel.intLeaveTypeId.ToString().Trim()))
                {
                    ModelState.AddModelError("intLeaveTypeId", "Leave type is required");
                }
                else if (string.IsNullOrEmpty(objmodel.decNoOfDays.ToString().Trim()))
                {
                    ModelState.AddModelError("intNoOfDays", "No Of days is required");
                }
                
                else if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        objmodel.Check = 1;
                        objMessageEF = _LeaveManagementModel.AddLeaveAssignClassWise(objmodel);
                    }
                    else
                    {
                        objmodel.Check = 2;

                        //objmodel.intId = objmodel.intId;
                        objMessageEF = _LeaveManagementModel.AddLeaveAssignClassWise(objmodel);
                    }
                    if (objMessageEF.Satus == "1" && submit == "Submit")
                    {
                        TempData["msg"] = "1";//Leave assign class wise Saved Successfully
                        return RedirectToAction("AddLeaveAssignClassWise");

                    }
                    if (objMessageEF.Satus == "3" && submit == "Update")
                    {
                        TempData["msg"] = "3";//Leave  assign class wise Updated Sucessfully
                        return RedirectToAction("ViewLeaveAssignClassWise");
                    }
                    else if (objMessageEF.Satus == "2")
                    {
                        TempData["msg"] = "2";// assign class wise  Details allready exists
                        return RedirectToAction("AddLeaveAssignClassWise");
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving  assign class wise Details";
                        return RedirectToAction("AddLeaveAssignClassWise");
                    }

                }

                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// View leave assign class wise
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewLeaveAssignClassWise()
        {

            LeaveAssignClassWiseQuery objApplyLeave = new LeaveAssignClassWiseQuery();
            List<LeaveAssignClassWiseQuery> listAuthoritySetting = new List<LeaveAssignClassWiseQuery>();
            try
            {
                objApplyLeave.Check = 3;
                listAuthoritySetting = await _LeaveManagementModel.ViewLeaveAssignClassWise(objApplyLeave);
                return View(listAuthoritySetting);

            }
            catch (Exception)
            {

                throw;
            }

        }

        
        /// <summary>
        /// delete authority setting
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [IgnoreAntiforgeryToken]
        [Decryption]
        public IActionResult DeleteLeaveAssignClassWise(string id = "0")
        {
            MessageEF objMessageEF = new MessageEF();
            LeaveAssignClassWise objmodel = new LeaveAssignClassWise();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;

                int iId = Convert.ToInt32(id);
                objmodel.Check = 3;
                objmodel.intId = iId;
                //objmodel.intCreatedBy = 1;
                objMessageEF = _LeaveManagementModel.DeleteLeaveAssignClassWise(objmodel);
                if (objMessageEF.Satus == "4")
                {
                    TempData["msg"] = "4";//Leave Assign deleted Successfully
                }
                else
                {
                    TempData["msg"] = "Error ! while deleting leave assign Details";
                }
                return RedirectToAction("ViewLeaveAssignClassWise");
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

    }
}
