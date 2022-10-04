// ***********************************************************************
//  Controller Name          : Workflow activity
//  Desciption               : Work Flow activity Details 
//  Created By               : Suresh Kumar Behera
//  Created On               : 13-Jul-2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EstablishmentEf;

using EstablishmentApp.Areas.WorkFlow.Models.WorkFlow;
using Microsoft.AspNetCore.Mvc.Rendering;
using EstablishmentApp.Web;

namespace EstablishmentApp.Areas.WorkFlow.Controllers
{
    [Area("WorkFlow")]
    public class WorkFlowController : Controller
    {
        private readonly KhanijSecurity.KhanijIDataProtection _protector;
        private IWorkFlowModel _workFlowModel;

        public WorkFlowController(IWorkFlowModel objWorkFlowModel, KhanijSecurity.KhanijIDataProtection protector)
        {
            _protector = protector;
            _workFlowModel = objWorkFlowModel;
        }

        /// <summary>
        /// WorkFlow details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult AddWorkFlow(string id = "0")
        {
            try
            {
                WorkFlowEF objmodel = new WorkFlowEF();// WorkFlowEF.GetInstance();
                WorkFlowDropDown objWorkFlowDDL = new WorkFlowDropDown();// WorkFlowDropDown.GetInstance();

                ViewBag.Module = Enumerable.Empty<SelectListItem>();
                ViewBag.SubModule = Enumerable.Empty<SelectListItem>();
                ViewBag.Activity = Enumerable.Empty<SelectListItem>();
                ViewBag.Step = Enumerable.Empty<SelectListItem>();

                ViewBag.AuthorityType = Enumerable.Empty<SelectListItem>();

                ViewBag.PrimaryOfficeLevel = Enumerable.Empty<SelectListItem>();
                ViewBag.PrimaryDesignation = Enumerable.Empty<SelectListItem>();
                ViewBag.PrimaryAuthority = Enumerable.Empty<SelectListItem>();

                ViewBag.SecondaryOfficeLevel = Enumerable.Empty<SelectListItem>();
                ViewBag.SecondaryDesignation = Enumerable.Empty<SelectListItem>();
                ViewBag.SecondaryAuthority = Enumerable.Empty<SelectListItem>();

                ViewBag.NotificationType = Enumerable.Empty<SelectListItem>();


                //---Bind  module

                objWorkFlowDDL.Check = 1;
                var varModule = _workFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.Module = varModule.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---bind submodule
                objWorkFlowDDL.Check = 2;
                var varSubModule = _workFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.SubModule = varSubModule.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //-----bind activity---
                objWorkFlowDDL.Check = 1;
                var varActivity = _workFlowModel.BindWorkFlowDDL(objWorkFlowDDL);
                ViewBag.Activity = varActivity.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---Step---
                objWorkFlowDDL.Check = 3;
                var varStep = _workFlowModel.BindWorkFlowDDL(objWorkFlowDDL);
                ViewBag.Step = varStep.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                #region primary
                //---office level
                objWorkFlowDDL.Check = 7;
                var varPrimaryOfficeLevel = _workFlowModel.BindDropDownSetAuthority(objWorkFlowDDL);
                ViewBag.PrimaryOfficeLevel = varPrimaryOfficeLevel.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---primary designation
                objWorkFlowDDL.Check = 8;
                var varPrimaryDesignation = _workFlowModel.BindDropDownSetAuthority(objWorkFlowDDL);
                ViewBag.PrimaryDesignation = varPrimaryDesignation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //---primary authority User
                objWorkFlowDDL.Check = 9;
                var varPrimaryAuthority = _workFlowModel.BindDropDownSetAuthority(objWorkFlowDDL);
                ViewBag.PrimaryAuthority = varPrimaryAuthority.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();
                #endregion

                #region secondary
                //---office level
                objWorkFlowDDL.Check = 7;
                var varSecondaryOfficeLevel = _workFlowModel.BindDropDownSetAuthority(objWorkFlowDDL);
                ViewBag.SecondaryOfficeLevel = varSecondaryOfficeLevel.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---primary designation
                objWorkFlowDDL.Check = 8;
                var varSecondaryDesignation = _workFlowModel.BindDropDownSetAuthority(objWorkFlowDDL);
                ViewBag.SecondaryDesignation = varSecondaryDesignation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //---primary authority User
                objWorkFlowDDL.Check = 9;
                var varSecondaryAuthority = _workFlowModel.BindDropDownSetAuthority(objWorkFlowDDL);
                ViewBag.SecondaryAuthority = varSecondaryAuthority.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();
                #endregion

                //---bind notification type
                objWorkFlowDDL.Check = 5;
                var varNotificationType = _workFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.NotificationType = varNotificationType.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---use for during edit
                if (id != "0")
                {
                    int iId = Convert.ToInt32(_protector.Encode(id));
                    objmodel.Check = 4;
                    objmodel.intWorkFlowId = iId;
                    objmodel = _workFlowModel.ViewWorkFlowDetails(objmodel);

                    objmodel.Check = 5;
                    objmodel.intWorkFlowId = iId;
                    objmodel.WorkFlowtransaction = _workFlowModel.ViewWorkFlowDetailsTransaction(objmodel);

                    //objmodel.intStep = objmodel.WorkFlowtransaction.Count + 1;
                    objmodel.intPrimaryOfficeLevelId = 0;
                    objmodel.intPrimaryDesignationId = 0;
                    objmodel.intPrimaryAuthorityUserId = 0;

                    objmodel.intSecondaryOfficeLevelid = 0;
                    objmodel.intSecondaryDesignationId = 0;
                    objmodel.intSecondaryAuthorityUserId = 0;

                    //objmodel.intEscalationinDays = 0;
                    //objmodel.intNotificationType = 0;
                    //objmodel.bitAuthorityMultiple = objmodel.WorkFlowtransaction[0].bitAuthorityMultiple;
                    //objmodel.intNoofMultipleAuthority = objmodel.WorkFlowtransaction[0].intNoofMultipleAuthority;

                    //ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    //ViewBag.Button = "Submit";
                    return View(objmodel);
                }
                //return View(objmodel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// bind Activity as per sub module selected
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BindActivity(int SubModuleId = 0)
        {
            try
            {
                //-----bind activity---               
                WorkFlowDropDown objWorkFlowDDL = WorkFlowDropDown.GetInstance();
                objWorkFlowDDL.Check = 1;
                objWorkFlowDDL.Id = SubModuleId;
                var varActivity = _workFlowModel.BindWorkFlowDDL(objWorkFlowDDL);
                return Json(varActivity);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// bind submodule as per module selected
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BindStep(int ActivityId = 0)
        {
            try
            {
                //-----bind activity---               
                WorkFlowDropDown objWorkFlowDDL = WorkFlowDropDown.GetInstance();
                objWorkFlowDDL.Check = 3;
                objWorkFlowDDL.Id = ActivityId;
                var varActivity = _workFlowModel.BindWorkFlowDDL(objWorkFlowDDL);
                return Json(varActivity);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Activity details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult AddWorkFlow(WorkFlowEF objmodel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                try
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    objmodel.CreatedBy = profile.UserId;

                    if (Convert.ToInt32(objmodel.intModuleId) <= 0)
                    {
                        ModelState.AddModelError("intModuleId", "Module is required");
                    }
                    if (Convert.ToInt32(objmodel.intSubModuleId) <= 0)
                    {
                        ModelState.AddModelError("intSubModuleId", "SubModule is required");
                    }
                    if (Convert.ToInt32(objmodel.intActivityId) <= 0)
                    {
                        ModelState.AddModelError("intActivityId", "Activity Name is required");
                    }
                    if (Convert.ToInt32(objmodel.intStep) <= 0)
                    {
                        ModelState.AddModelError("intStep", "Step Id is required");
                    }
                    //if (Convert.ToInt32(objmodel.intAuthorityType) <= 0)
                    //{
                    //    ModelState.AddModelError("intAuthorityType", "AuthorityType is required");
                    //}

                    if (Convert.ToInt32(objmodel.intPrimaryOfficeLevelId) <= 0)
                    {
                        ModelState.AddModelError("intPrimaryOfficeLevelId", "Primary Office level is required");
                    }
                    if (Convert.ToInt32(objmodel.intPrimaryDesignationId) <= 0)
                    {
                        ModelState.AddModelError("intPrimaryDesignationId", "Primary Designation is required");
                    }
                    if (Convert.ToInt32(objmodel.intPrimaryAuthorityUserId) <= 0)
                    {
                        ModelState.AddModelError("intPrimaryAuthorityUserId", "Primary Authority user is required");
                    }
                    //----for single authority secondary authority
                    if (Convert.ToBoolean(objmodel.bitAuthorityMultiple) == false)
                    {


                        if (Convert.ToInt32(objmodel.intSecondaryOfficeLevelid) <= 0)
                        {
                            ModelState.AddModelError("intSecondaryOfficeLevelid", "Secondary Office level is required");
                        }
                        if (Convert.ToInt32(objmodel.intSecondaryDesignationId) <= 0)
                        {
                            ModelState.AddModelError("intSecondaryDesignationId", "Secondary Designation is required");
                        }
                        if (Convert.ToInt32(objmodel.intSecondaryAuthorityUserId) <= 0)
                        {
                            ModelState.AddModelError("intSecondaryAuthorityUserId", "Secondary Authority user is required");
                        }
                    }
                    //---for multiple authority
                    if (Convert.ToBoolean(objmodel.bitAuthorityMultiple) == true)
                    {
                        if (Convert.ToInt32(objmodel.intNoofMultipleAuthority) <= 0)
                        {
                            ModelState.AddModelError("intNoofMultipleAuthority", "No. of Action Taking Authority");
                        }
                    }
                    if (Convert.ToBoolean(objmodel.bitEscalation) == true)
                    {
                        if (Convert.ToInt32(objmodel.intEscalationinDays) <= 0)
                        {
                            ModelState.AddModelError("intEscalationinDays", "EscalationinDays is required");
                        }
                    }
                    if (Convert.ToBoolean(objmodel.bitNotification) == true)
                    {
                        if (Convert.ToInt32(objmodel.intNotificationType) <= 0)
                        {
                            ModelState.AddModelError("intNotificationType", "NotificationType is required");
                        }
                    }

                    if (ModelState.IsValid)
                    {
                        objmodel.Check = 1;
                        objMessageEF = _workFlowModel.AddWorkFlow(objmodel);

                        if (objMessageEF.Satus == "1" && Convert.ToBoolean(objmodel.bitAuthorityMultiple) == true)
                        {
                            TempData["msg"] = "1";//---data saved sucessfully
                            return RedirectToAction("AddWorkFlow", "WorkFlow", new { Area = "WorkFlow", id = _protector.Decode(Convert.ToString(objMessageEF.Id)) });

                        }
                        if (objMessageEF.Satus == "1" && Convert.ToBoolean(objmodel.bitAuthorityMultiple) == false)
                        {
                            TempData["msg"] = "1";//---data saved sucessfully
                            return RedirectToAction("ViewWorkFlow", "WorkFlow", new { Area = "WorkFlow" });

                        }
                        if (objMessageEF.Satus == "3" )
                        {
                            TempData["msg"] = "3";//data Updated Sucessfully
                            return RedirectToAction("ViewWorkFlow", "WorkFlow", new { Area = "WorkFlow" });
                        }
                        else if (objMessageEF.Satus == "2")
                        {
                            TempData["msg"] = "2";//---allready exists
                            return RedirectToAction("AddWorkFlow", "WorkFlow", new { Area = "WorkFlow", id = _protector.Decode(Convert.ToString(objMessageEF.Id)) });
                        }


                    }
                    //return RedirectToAction("AddUserWiseSetAuthority", "LeaveManagement", new { Area = "LeaveManagement", id = protector.Decode(Convert.ToString(0)) });

                    return RedirectToAction("AddWorkFlow");
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    objMessageEF = null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult ViewWorkFlow()
        {
            WorkFlowEFQuery objmodel = WorkFlowEFQuery.GetInstance();
            List<WorkFlowEFQuery> listWorkFlow = new List<WorkFlowEFQuery>();
            try
            {
                objmodel.Check = 4;
                listWorkFlow = _workFlowModel.ViewWorkFlow(objmodel);
            }
            catch (Exception)
            {

                throw;
            }
            return View(listWorkFlow);
        }

        [HttpGet]
        public IActionResult DeleteWorkFlow(string id = "0")
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();

                WorkFlowEF objmodel = new WorkFlowEF();// WorkFlowEF.GetInstance();

                //---use for during edit
                if (id != "0")
                {
                    int iId = Convert.ToInt32(_protector.Encode(id));
                    objmodel.Check = 3;
                    objmodel.intWorkFlowId = iId;
                    objMessageEF = _workFlowModel.DeleteWorkFlow(objmodel);
                    if (objMessageEF.Satus == "4")
                    {
                        TempData["msg"] = "4";//Leave Assign deleted Successfully
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while deleting workflow Details";
                    }
                    return RedirectToAction("ViewWorkFlow");

                }
                else
                {
                    ViewBag.Button = "Submit";
                    return View(objmodel);
                }
                //return View(objmodel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult RemoveWorkFlowTransaction(string id = "0")
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();

                WorkFlowTransactionEF objmodel = new WorkFlowTransactionEF();// WorkFlowEF.GetInstance();

                //---use for during edit
                if (id != "0")
                {
                    int iId = Convert.ToInt32(_protector.Encode(id));
                    objmodel.Check = 4;
                    objmodel.intId = iId;
                    objMessageEF = _workFlowModel.RemoveWorkFlowTransaction(objmodel);
                    if (objMessageEF.Satus == "4")
                    {
                        TempData["msg"] = "4";//Leave Assign deleted Successfully
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while deleting workflow Details";
                    }
                    return RedirectToAction("AddWorkFlow", "WorkFlow", new { Area = "WorkFlow", id = _protector.Decode(Convert.ToString(objMessageEF.Id)) });

                }
                else
                {
                    ViewBag.Button = "Submit";
                    return View(objmodel);
                }
                //return View(objmodel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
