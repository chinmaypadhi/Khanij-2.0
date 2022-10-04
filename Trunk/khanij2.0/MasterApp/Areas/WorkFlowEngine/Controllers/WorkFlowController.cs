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

using MasterEF;

using MasterApp.Areas.WorkFlowEngine.Models.WorkFlow;
using Microsoft.AspNetCore.Mvc.Rendering;
using MasterApp.Web;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Designation;

using MasterApp.Areas.Master.Models.MainMenu;
using Microsoft.Extensions.Localization;

namespace MasterApp.Areas.WorkFlowEngine.Controllers
{
    [Area("WorkFlowEngine")]
    public class WorkFlowController : Controller
    {
        private readonly IStringLocalizer<CommonResources> _sharedLocalizer;
        private readonly IMainMenuMasterModel mainMenuMasterModel;
        private readonly IDesignationModel designationModel;
        private IWorkFlowModel _workFlowModel;
        public WorkFlowController(IWorkFlowModel objWorkFlowModel, IDesignationModel designationModel, IMainMenuMasterModel mainMenuMasterModel, IStringLocalizer<CommonResources> stringLocalizer)
        {
            _workFlowModel = objWorkFlowModel;
            this.designationModel = designationModel;
            this.mainMenuMasterModel = mainMenuMasterModel; 
            _sharedLocalizer = stringLocalizer;
        }

        /// <summary>
        /// WorkFlow details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Decryption]
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

                ViewBag.SetAuthority = Enumerable.Empty<SelectListItem>();

                ViewBag.PrimaryDistrict = Enumerable.Empty<SelectListItem>();
                ViewBag.SecondaryDistrict = Enumerable.Empty<SelectListItem>();


                //--Bind Module New
                ModuleMasterModel moduleMasterModel = new ModuleMasterModel();
                //ViewData["ModuleDetails"] = mainMenuMasterModel.ViewModuleDetails(moduleMasterModel);

                var varModule = mainMenuMasterModel.ViewModuleDetails(moduleMasterModel);
                ViewBag.Module = varModule.ToList().Select(c => new SelectListItem
                {
                    Text = c.ModuleName,
                    Value = c.ModuleId.ToString(),

                }).ToList();

                ////---Bind  module

                //objWorkFlowDDL.Check = 1;
                //var varModule = _workFlowModel.BindActivityDDL(objWorkFlowDDL);
                //ViewBag.Module = varModule.ToList().Select(c => new SelectListItem
                //{
                //    Text = c.Text,
                //    Value = c.Value.ToString(),

                //}).ToList();

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

                //---Bind Authority Type---
                objWorkFlowDDL.Check = 6;
                var varSetAuthority = _workFlowModel.BindWorkFlowDDL(objWorkFlowDDL);
                ViewBag.SetAuthority = varSetAuthority.ToList().Select(c => new SelectListItem
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

                ////---primary designation new
                RoleListModel roleListModel = new RoleListModel();
                //List<RoleListModel> lstRoleListModel = designationModel.View(roleListModel);
                var varPrimaryDesignation = designationModel.View(roleListModel);
                ViewBag.PrimaryDesignation = varPrimaryDesignation.ToList().Select(c => new SelectListItem
                {
                    Text = c.RoleName,
                    Value = c.RoleId.ToString(),

                }).ToList();

                ////---primary designation
                //objWorkFlowDDL.Check = 8;
                //var varPrimaryDesignation = _workFlowModel.BindDropDownSetAuthority(objWorkFlowDDL);
                //ViewBag.PrimaryDesignation = varPrimaryDesignation.ToList().Select(c => new SelectListItem
                //{
                //    Text = c.Text,
                //    Value = c.Value.ToString(),

                //}).ToList();


                //---primary authority User
                objWorkFlowDDL.Check = 9;
                var varPrimaryAuthority = _workFlowModel.BindDropDownSetAuthority(objWorkFlowDDL);
                ViewBag.PrimaryAuthority = varPrimaryAuthority.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                ////---bind primary District
                objWorkFlowDDL.Check = 8;
                var varPrimaryDistrict = _workFlowModel.BindWorkFlowDDL(objWorkFlowDDL);
                ViewBag.PrimaryDistrict = varPrimaryDistrict.ToList().Select(c => new SelectListItem
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

                ////---primary designation new
                //RoleListModel roleListModel = new RoleListModel();
                //List<RoleListModel> lstRoleListModel = designationModel.View(roleListModel);
                var varSecondaryDesignation = designationModel.View(roleListModel);
                ViewBag.SecondaryDesignation = varSecondaryDesignation.ToList().Select(c => new SelectListItem
                {
                    Text = c.RoleName,
                    Value = c.RoleId.ToString(),

                }).ToList();

                //---primary designation
                //objWorkFlowDDL.Check = 8;
                //var varSecondaryDesignation = _workFlowModel.BindDropDownSetAuthority(objWorkFlowDDL);
                //ViewBag.SecondaryDesignation = varSecondaryDesignation.ToList().Select(c => new SelectListItem
                //{
                //    Text = c.Text,
                //    Value = c.Value.ToString(),

                //}).ToList();


                //---primary authority User
                objWorkFlowDDL.Check = 9;
                var varSecondaryAuthority = _workFlowModel.BindDropDownSetAuthority(objWorkFlowDDL);
                ViewBag.SecondaryAuthority = varSecondaryAuthority.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                ////---bind primary District
                objWorkFlowDDL.Check = 8;
                var varSecondaryDistrict = _workFlowModel.BindWorkFlowDDL(objWorkFlowDDL);
                ViewBag.SecondaryDistrict = varSecondaryDistrict.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                #endregion


                //---use for during edit
                if (!string.IsNullOrEmpty(id) && id != "0")
                {

                    int iId = Convert.ToInt32(id);
                    objmodel.Check = 4;
                    objmodel.intWorkFlowId = iId;
                    objmodel = _workFlowModel.ViewWorkFlowDetails(objmodel);

                    objmodel.Check = 5;
                    objmodel.intWorkFlowId = iId;
                    objmodel.WorkFlowtransaction = _workFlowModel.ViewWorkFlowDetailsTransaction(objmodel);

                    objmodel.intPrimaryOfficeLevelId = 0;
                    objmodel.intPrimaryDesignationId = 0;
                    objmodel.intPrimaryAuthorityUserId = 0;

                    objmodel.intSecondaryOfficeLevelid = 0;
                    objmodel.intSecondaryDesignationId = 0;
                    objmodel.intSecondaryAuthorityUserId = 0;

                    return View(objmodel);
                }
                else
                {
                    return View(objmodel);
                }
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
                WorkFlowDropDown objWorkFlowDDL = new WorkFlowDropDown();//.GetInstance();
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
        /// bind step as per module selected
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BindStep(int ActivityId = 0)
        {
            try
            {
                //-----bind activity---               
                WorkFlowDropDown objWorkFlowDDL = new WorkFlowDropDown();//.GetInstance();
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
        /// bind activity details as per step selected
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BindActivityDetails(int ModuleId = 0, int SubModuleId = 0, int StepId = 0)
        {
            try
            {
                //-----bind activity---               
                WorkFlowEF objWorkFlowDDL = new WorkFlowEF();//.GetInstance();
                objWorkFlowDDL.Check = 7;
                objWorkFlowDDL.intModuleId = ModuleId;
                objWorkFlowDDL.intSubModuleId = SubModuleId;
               objWorkFlowDDL.intWorkFlowId = StepId;
               
                var varActivity = _workFlowModel.ViewWorkFlowDetails(objWorkFlowDDL);
                TempData["intActionToBeTakenAt"] = varActivity.intActionToBeTakenAt.ToString();
                TempData["intActionToBeTakenBy"] = varActivity.intActionToBeTakenBy.ToString();
                return Json(varActivity);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// bind activity details as per step selected
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDistrictList(int StepId = 0)
        {
            try
            {
                //-----bind activity---               
                WorkFlowEF objWorkFlowDDL = new WorkFlowEF();//.GetInstance();
                objWorkFlowDDL.Check = 7;
                objWorkFlowDDL.intWorkFlowId = StepId;
                var varActivity = _workFlowModel.ViewWorkFlowDetails(objWorkFlowDDL);
                return Json(varActivity);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// add workflow
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult AddWorkFlow(WorkFlowEF objmodel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();//.GetInstance();
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
                    if (Convert.ToInt32(objmodel.intPrimaryOfficeLevelId) <= 0)
                    {
                        ModelState.AddModelError("intPrimaryOfficeLevelId", "Primary Office level is required");
                    }
                    if (Convert.ToInt32(objmodel.intPrimaryDesignationId) <= 0)
                    {
                        ModelState.AddModelError("intPrimaryDesignationId", "Primary Designation is required");
                    }
                    if (Convert.ToInt32(objmodel.intPrimaryOfficeLevelId) != 3)
                    {
                        if (Convert.ToInt32(objmodel.intPrimaryAuthorityUserId) <= 0)
                        {
                            ModelState.AddModelError("intPrimaryAuthorityUserId", "Primary Authority user is required");
                        }
                    }
                    else
                    {
                        objmodel.intPrimaryAuthorityUserId = 0;
                    }
                    if (Convert.ToInt32(objmodel.intSecondaryOfficeLevelid) <= 0)
                    {
                        ModelState.AddModelError("intSecondaryOfficeLevelid", "Secondary Office level is required");
                    }
                    if (Convert.ToInt32(objmodel.intSecondaryDesignationId) <= 0)
                    {
                        ModelState.AddModelError("intSecondaryDesignationId", "Secondary Designation is required");
                    }
                    if (Convert.ToInt32(objmodel.intPrimaryOfficeLevelId) != 3)
                    {
                        if (Convert.ToInt32(objmodel.intSecondaryAuthorityUserId) <= 0)
                        {
                            ModelState.AddModelError("intSecondaryAuthorityUserId", "Secondary Authority user is required");
                        }
                    }
                    else
                    {
                        objmodel.intSecondaryAuthorityUserId = 0;
                    }
                    //----for single authority secondary authority
                    //if (Convert.ToBoolean(objmodel.bitAuthorityMultiple) == false)
                    //{

                    //    if (Convert.ToInt32(objmodel.intSecondaryOfficeLevelid) <= 0)
                    //    {
                    //        ModelState.AddModelError("intSecondaryOfficeLevelid", "Secondary Office level is required");
                    //    }
                    //    if (Convert.ToInt32(objmodel.intSecondaryDesignationId) <= 0)
                    //    {
                    //        ModelState.AddModelError("intSecondaryDesignationId", "Secondary Designation is required");
                    //    }
                    //    if (Convert.ToInt32(objmodel.intSecondaryAuthorityUserId) <= 0)
                    //    {
                    //        ModelState.AddModelError("intSecondaryAuthorityUserId", "Secondary Authority user is required");
                    //    }
                    //}
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

                    if (Convert.ToInt32(objmodel.intSetAuthority) <= 0)
                    {
                        ModelState.AddModelError("intSetAuthority", "Set Authority is required");
                    }


                    //if (Convert.ToBoolean(objmodel.bitNotification) == true)
                    //{
                    //    if (Convert.ToInt32(objmodel.intNotificationType) <= 0)
                    //    {
                    //        ModelState.AddModelError("intNotificationType", "NotificationType is required");
                    //    }
                    //}

                    if (ModelState.IsValid)
                    {

                        objmodel.intActionToBeTakenAt = Convert.ToInt32(TempData["intActionToBeTakenAt"].ToString());
                        objmodel.intActionToBeTakenBy = Convert.ToInt32(TempData["intActionToBeTakenBy"].ToString());
                        objmodel.Check = 1;
                        objMessageEF = _workFlowModel.AddWorkFlow(objmodel);

                        if (objMessageEF.Satus == "1" && Convert.ToBoolean(objmodel.bitAuthorityMultiple) == true)
                        {
                            TempData["msg"] = "1";//---data saved sucessfully
                            return RedirectToAction("AddWorkFlow", "WorkFlow", new { Area = "WorkFlowEngine", id = objMessageEF.Id });

                            //return RedirectToAction(@CustomQueryStringHelper.EncryptString("WorkFlowEngine", "AddWorkFlow", "WorkFlow", new { id = objMessageEF.Id }));

                            //return RedirectToAction("AddWorkFlow", "WorkFlow", new { Area = "WorkFlow", id = _protector.Decode(Convert.ToString(objMessageEF.Id)) });

                        }
                        if (objMessageEF.Satus == "1" && Convert.ToBoolean(objmodel.bitAuthorityMultiple) == false)
                        {
                            TempData["msg"] = "1";//---data saved sucessfully
                            return RedirectToAction("ViewWorkFlow");

                        }
                        if (objMessageEF.Satus == "3")
                        {
                            TempData["msg"] = "3";//data Updated Sucessfully
                            return RedirectToAction("ViewWorkFlow");
                        }
                        else if (objMessageEF.Satus == "2")
                        {
                            TempData["msg"] = "2";//---allready exists
                            return RedirectToAction("ViewWorkFlow");
                            //return RedirectToAction(@CustomQueryStringHelper.EncryptString("WorkFlowEngine", "AddWorkFlow", "WorkFlow", new { id = objMessageEF.Id }));

                        }


                    }
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

        /// <summary>
        /// add workflow in case of take user wise set authority like leave management
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public JsonResult AddWorkFlowDefault(WorkFlowEF objmodel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();//.GetInstance();
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

                    if (Convert.ToInt32(objmodel.intSetAuthority) <= 0)
                    {
                        ModelState.AddModelError("intSetAuthority", "Set Authority is required");
                    }

                    if (ModelState.IsValid)
                    {
                        objmodel.Check = 1;
                        objMessageEF = _workFlowModel.AddWorkFlow(objmodel);

                        if (objMessageEF.Satus == "1" && Convert.ToBoolean(objmodel.bitAuthorityMultiple) == true)
                        {
                            TempData["msg"] = "1";//---data saved sucessfully
                            //return RedirectToAction("AddWorkFlow", "WorkFlow", new { Area = "WorkFlowEngine", id = objMessageEF.Id });

                        }
                        if (objMessageEF.Satus == "1" && Convert.ToBoolean(objmodel.bitAuthorityMultiple) == false)
                        {
                            TempData["msg"] = "1";//---data saved sucessfully
                            //return RedirectToAction("ViewWorkFlow");

                        }
                        if (objMessageEF.Satus == "3")
                        {
                            TempData["msg"] = "3";//data Updated Sucessfully
                           //return RedirectToAction("ViewWorkFlow");
                        }
                        else if (objMessageEF.Satus == "2")
                        {
                            TempData["msg"] = "2";//---allready exists
                            //return RedirectToAction("ViewWorkFlow");
                            //return RedirectToAction(@CustomQueryStringHelper.EncryptString("WorkFlowEngine", "AddWorkFlow", "WorkFlow", new { id = objMessageEF.Id }));

                        }


                    }
                    return Json(objMessageEF);
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
        /// <summary>
        /// view work flow
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ViewWorkFlow()
        {
            WorkFlowEFQuery objmodel = new WorkFlowEFQuery();//.GetInstance();
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

        public JsonResult ViewActionTakingAuthority(int? intWorkFlowId)
        {
            try
            {
                WorkFlowAuthorityLogEF objEmpDropDown = new WorkFlowAuthorityLogEF();
                objEmpDropDown.Check = 9;
                objEmpDropDown.intWorkFlowId = intWorkFlowId;
                var ActionHistory = _workFlowModel.ViewActionTakingAuthority(objEmpDropDown);
                return Json(ActionHistory);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// delete workflow
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Decryption]
        public IActionResult DeleteWorkFlow(string id = "0")
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();//.GetInstance();

                WorkFlowEF objmodel = new WorkFlowEF();// WorkFlowEF.GetInstance();

                //---use for during edit
                if (id != "0")
                {
                    int iId = Convert.ToInt32(id);
                    objmodel.Check = 3;
                    objmodel.intWorkFlowId = iId;
                    objMessageEF = _workFlowModel.DeleteWorkFlow(objmodel);
                    if (objMessageEF.Satus == "4")
                    {
                        TempData["msg"] = "4";//workflow deleted Successfully
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while deleting workflow Details";
                    }
                    return RedirectToAction("ViewWorkFlow");

                }
                else
                {
                    ViewBag.Button = _sharedLocalizer["Submit"];
                    ViewBag.Reset = _sharedLocalizer["Reset"];

                    return View(objmodel);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Decryption]
        public IActionResult RemoveWorkFlowTransaction(string id = "0")
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();//.GetInstance();

                WorkFlowTransactionEF objmodel = new WorkFlowTransactionEF();// WorkFlowEF.GetInstance();

                //---use for during edit
                if (id != "0")
                {
                    int iId = Convert.ToInt32(id);
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

                    return RedirectToAction("AddWorkFlow", "WorkFlow", new { Area = "WorkFlowEngine", id = objMessageEF.Id });

                    //return RedirectToAction(@CustomQueryStringHelper.EncryptString("WorkFlowEngine", "AddWorkFlow", "WorkFlow", new { id = objMessageEF.Id }));
                }
                else
                {
                    ViewBag.Button = _sharedLocalizer["Submit"];
                    ViewBag.Reset = _sharedLocalizer["Reset"];
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
        /// select office level id wise
        /// </summary>
        /// <param name="Bind Satate"></param>
        /// <returns></returns>
        [HttpPost]
        public  JsonResult BindOfficeLevelById(int id = 0)
        {
            try
            {
                WorkFlowDropDown objLeaveDropDown = new WorkFlowDropDown();
                objLeaveDropDown.Check = 7;
                objLeaveDropDown.Id = id;
                var varNextApprovedUserId1 =  _workFlowModel.BindDropDownSetAuthority(objLeaveDropDown);
                return Json(varNextApprovedUserId1);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// select designation id wise
        /// </summary>
        /// <param name="Bind Designation"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BindDesignationById(int id = 0)
        {
            try
            {
                WorkFlowDropDown objLeaveDropDown = new WorkFlowDropDown();
                objLeaveDropDown.Check = 8;
                objLeaveDropDown.Id = id;
                var varNextApprovedUserId1 =  _workFlowModel.BindDropDownSetAuthority(objLeaveDropDown);
                return Json(varNextApprovedUserId1);
            }
            catch (Exception)
            {

                throw;
            }

        }

/// <summary>
        /// select district id wise
        /// </summary>
        /// <param name="Bind Designation"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BindDistrictById(int id = 0)
        {
            try
            {
                ////---bind primary District
                WorkFlowDropDown objWorkFlowDDL = new WorkFlowDropDown();
                objWorkFlowDDL.Check = 8;
                objWorkFlowDDL.Id = id;
                var varPrimaryDistrict = _workFlowModel.BindWorkFlowDDL(objWorkFlowDDL);
                ViewBag.PrimaryDistrict = varPrimaryDistrict.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();
                return Json(varPrimaryDistrict);

                //WorkFlowDropDown objLeaveDropDown = new WorkFlowDropDown();
                //objLeaveDropDown.Check = 8;
                //objLeaveDropDown.Id = id;
                //var varNextApprovedUserId1 =  _workFlowModel.BindDropDownSetAuthority(objLeaveDropDown);
                //return Json(varNextApprovedUserId1);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Bind employee id wise
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public  JsonResult BindEmployeeIdWise(int OfficeLevelId = 0, int UserTypeId = 0, int EmployeeId = 0)
        {
            try
            {
                WorkFlowDropDown objLeaveDropDown = new WorkFlowDropDown();
                objLeaveDropDown.Check = 11;
                objLeaveDropDown.Id = OfficeLevelId;
                objLeaveDropDown.Id2 = UserTypeId;
                objLeaveDropDown.Id3 = EmployeeId;
                var varNextApprovedUserId1 =  _workFlowModel.BindDropDownSetAuthority(objLeaveDropDown);
                return Json(varNextApprovedUserId1);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Bind next approve user1
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public  JsonResult BindEmployeeOfficeLevelWise(int OfficeLevelId = 0, int UserTypeId = 0, int PostingDistrict = 0)
        {
            try
            {
                WorkFlowDropDown objLeaveDropDown = new WorkFlowDropDown();
                objLeaveDropDown.Check = 9;
                objLeaveDropDown.Id = OfficeLevelId;
                objLeaveDropDown.Id2 = UserTypeId;
                objLeaveDropDown.Id3 = PostingDistrict;
                var varNextApprovedUserId1 =  _workFlowModel.BindDropDownSetAuthority(objLeaveDropDown);
                return Json(varNextApprovedUserId1);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
