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
using MasterApp.Areas.Master.Models.MainMenu;
using Microsoft.Extensions.Localization;

namespace MasterApp.Areas.WorkFlowEngine.Controllers
{
    [Area("WorkFlowEngine")]

    public class WorkFlowActivityController : Controller
    {
        private readonly IMainMenuMasterModel mainMenuMasterModel;
        private readonly IStringLocalizer<CommonResources> _sharedLocalizer;
        private IActivityModel _WorkFlowModel;
        public WorkFlowActivityController(IActivityModel WorkFlowModel, IMainMenuMasterModel mainMenuMasterModel, IStringLocalizer<CommonResources> stringLocalizer)
        {
            _WorkFlowModel = WorkFlowModel;
            this.mainMenuMasterModel = mainMenuMasterModel; 
            _sharedLocalizer = stringLocalizer;

        }


        /// <summary>
        /// Activity details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Decryption]
        public IActionResult AddActivity(string id = "0")
        {
            try
            {
                ActivityEF objmodel = new ActivityEF(); //ActivityEF.GetInstance();
                WorkFlowDropDown objWorkFlowDDL = new WorkFlowDropDown(); //WorkFlowDropDown.GetInstance();

                ViewBag.Module = Enumerable.Empty<SelectListItem>();
                ViewBag.SubModule = Enumerable.Empty<SelectListItem>();
                ViewBag.Action = Enumerable.Empty<SelectListItem>();
                ViewBag.ActionTobeTakenAt = Enumerable.Empty<SelectListItem>();
                ViewBag.ActionTobeTakenBy = Enumerable.Empty<SelectListItem>();
                ViewBag.VRequiredNotification = Enumerable.Empty<SelectListItem>();
                ViewBag.VNotificationType = Enumerable.Empty<SelectListItem>();


                //--Bind Module New
                ModuleMasterModel moduleMasterModel = new ModuleMasterModel();
                //ViewData["ModuleDetails"] = mainMenuMasterModel.ViewModuleDetails(moduleMasterModel);

                var varModule = mainMenuMasterModel.ViewModuleDetails(moduleMasterModel);
                ViewBag.Module = varModule.ToList().Select(c => new SelectListItem
                {
                    Text = c.ModuleName,
                    Value = c.ModuleId.ToString(),

                }).ToList();

                //---Bind module

                //objWorkFlowDDL.Check = 1;
                //var varModule = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                //ViewBag.Module = varModule.ToList().Select(c => new SelectListItem
                //{
                //    Text = c.Text,
                //    Value = c.Value.ToString(),

                //}).ToList();


                //---Bind sub module

                objWorkFlowDDL.Check = 2;
                var varSubModule = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.SubModule = varSubModule.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---Bind Action

                //objWorkFlowDDL.Check = 3;
                //var varAction = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                //ViewBag.Action = varAction.ToList().Select(c => new SelectListItem
                //{
                //    Text = c.Text,
                //    Value = c.Value.ToString(),

                //}).ToList();

                //---Bind action to be taken at

                objWorkFlowDDL.Check = 4;
                var varActionTobeTakenAt = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.ActionTobeTakenAt = varActionTobeTakenAt.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();



                objWorkFlowDDL.Check = 7;
                var varActionTobeTakenBy = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.ActionTobeTakenBy = varActionTobeTakenBy.ToList().Select(
                    c => new SelectListItem
                    {
                        Text = c.Text,
                        Value = c.Value.ToString(),
                    }
                    ).ToList();


                //---Bind required notification
                var varRequiredNotification = new List<SelectListItem>();
                varRequiredNotification.Add(new SelectListItem { Text = "Yes", Value = "1" });
                varRequiredNotification.Add(new SelectListItem { Text = "No", Value = "0" });
                ViewBag.VRequiredNotification = varRequiredNotification;

                //---Bind Notification Type

                objWorkFlowDDL.Check = 5;
                var varNotificationType = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.VNotificationType = varNotificationType.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    int iId = Convert.ToInt32(id);
                    objmodel.Check = 6;
                    objmodel.ActivityId = iId;
                    objmodel = _WorkFlowModel.ViewWorkFlowActivityDetails(objmodel);
                    ViewBag.Button = _sharedLocalizer["Update"];
                    ViewBag.Reset = _sharedLocalizer["Cancel"];
                    return View(objmodel);
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


        /// <summary>
        /// bind submodule as per module selected
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BindAction()
        {
            try
            {
                WorkFlowDropDown objWorkFlowDDL = new WorkFlowDropDown();//.GetInstance();
                objWorkFlowDDL.Check = 3;
                var varAction = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                return Json(varAction);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Add Activity details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult AddActivity(ActivityEF objmodel, string submit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();//.GetInstance();
                try
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    objmodel.CreatedBy = profile.UserId;

                    if (Convert.ToInt32(objmodel.ModuleId) <= 0)
                    {
                        ModelState.AddModelError("ModuleId", "Module is required");
                    }
                    if (Convert.ToInt32(objmodel.SubModuleId) <= 0)
                    {
                        ModelState.AddModelError("SubModuleId", "SubModule is required");
                    }
                    if (string.IsNullOrEmpty(objmodel.ActivityName))
                    {
                        ModelState.AddModelError("ActivityName", "Activity Name is required");
                    }
                    if (objmodel.ActionCount == null)
                    {
                        ModelState.AddModelError("ActionCount", "Action Name is required");
                    }
                    if (Convert.ToInt32(objmodel.ActionTobeTakenAt) <= 0)
                    {
                        ModelState.AddModelError("ActionTobeTakenAt", "ActionTobeTakenAt is required");
                    }
                    if (Convert.ToInt32(objmodel.ActionTobeTakenBy) <= 0)
                    {
                        ModelState.AddModelError("ActionTobeTakenBy", "ActionTobeTakenBy is required");
                    }
                    if (Convert.ToBoolean(objmodel.RequiredNotification) == true)
                    {
                        if (Convert.ToInt32(objmodel.NotificationType) <= 0)
                        {
                            ModelState.AddModelError("NotificationType", "NotificationType is required");
                        }
                    }
                    if (Convert.ToInt32(objmodel.Step) <= 0)
                    {
                        ModelState.AddModelError("Step", "Step is required");
                    }

                    if (ModelState.IsValid)
                    {

                        string _actionId = "";

                        if (objmodel.ActionCount != null && objmodel.ActionCount.Count > 0)
                        {
                            for (int i = 0; i < objmodel.ActionCount.Count; i++)
                            {
                                _actionId += objmodel.ActionCount[i].ToString();
                                _actionId += ",";
                            }
                        }
                        objmodel.ActionIdList = _actionId;

                        if (submit == "Submit")
                        {
                            objmodel.Check = 1;
                            objMessageEF = _WorkFlowModel.AddWorkFlowActivity(objmodel);
                        }
                        else
                        {
                            objmodel.Check = 2;
                            objMessageEF = _WorkFlowModel.AddWorkFlowActivity(objmodel);
                        }
                        if (objMessageEF.Satus == "1" && submit == "Submit")
                        {
                            TempData["msg"] = "1";//data Details Saved Successfully
                            return RedirectToAction("AddActivity");
                            //return RedirectToAction("AddActivity", "WorkFlowActivity", new { Area = "WorkFlow" });
                        }
                        if (objMessageEF.Satus == "3" && submit == "Update")
                        {
                            TempData["msg"] = "3";//data Updated Sucessfully
                            return RedirectToAction("ViewActivity");
                            //return RedirectToAction("ViewActivity", "WorkFlowActivity", new { Area = "WorkFlow" });
                        }
                        else if (objMessageEF.Satus == "2")
                        {
                            TempData["msg"] = "2";//data Details allready exists
                        }
                        else
                        {
                            TempData["msg"] = "Error ! while Saving activity Details";
                        }

                    }


                    return RedirectToAction("AddActivity");
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
        /// bind submodule as per module selected
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BindSubMudule(int ModuleId = 0)
        {
            try
            {
                WorkFlowDropDown objWorkFlowDDL = new WorkFlowDropDown();//.GetInstance();
                objWorkFlowDDL.Check = 2;
                objWorkFlowDDL.Id = ModuleId;
                var varSubModuleId = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                return Json(varSubModuleId);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// View Activity 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult ViewActivity()
        {
            try
            {
                ActivityEFQuery objModel = new ActivityEFQuery();// ActivityEFQuery.GetInstance();
                List<ActivityEFQuery> objModelList = new List<ActivityEFQuery>();

                objModel.Check = 6;
                objModelList = _WorkFlowModel.ViewWorkFlowActivity(objModel);
                return View(objModelList);


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// delete Activity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        /// <returns></returns>
        [IgnoreAntiforgeryToken]
        [Decryption]
        public IActionResult DeleteActivity(string id = "0")
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            ActivityEF objmodel = new ActivityEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy = profile.UserId;
                int iId = Convert.ToInt32(id);
                objmodel.Check = 3;
                objmodel.ActivityId = iId;
                objMessageEF = _WorkFlowModel.DeleteWorkFlowActivity(objmodel);
                if (objMessageEF.Satus == "4")
                {
                    TempData["msg"] = "4";//activity deleted Successfully
                }
                else
                {
                    TempData["msg"] = "Error ! while deleting activity Details";
                }
                return RedirectToAction("ViewActivity");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
