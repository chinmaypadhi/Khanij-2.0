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

    public class WorkFlowActivityController : Controller
    {
        //-----security----
        private readonly KhanijSecurity.KhanijIDataProtection protector;
        private IActivityModel _WorkFlowModel;
        public WorkFlowActivityController(IActivityModel WorkFlowModel, KhanijSecurity.KhanijIDataProtection khanijIDataProtection)
        {
            protector = khanijIDataProtection;
            _WorkFlowModel = WorkFlowModel;
        }

      
        /// <summary>
        /// Activity details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult AddActivity(string id = "0")
        {
            try
            {
                ActivityEF objmodel = new ActivityEF(); //ActivityEF.GetInstance();
                WorkFlowDropDown objWorkFlowDDL = new WorkFlowDropDown(); //WorkFlowDropDown.GetInstance();

                ViewBag.Module = Enumerable.Empty<SelectListItem>();
                ViewBag.SubModule = Enumerable.Empty<SelectListItem>();
                ViewBag.Action = Enumerable.Empty<SelectListItem>();
                ViewBag.WorkSpecefic = Enumerable.Empty<SelectListItem>();
                ViewBag.VRequiredNotification = Enumerable.Empty<SelectListItem>();
                ViewBag.VNotificationType = Enumerable.Empty<SelectListItem>();

                //---Bind sub module

                objWorkFlowDDL.Check = 1;
                var varModule = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.Module = varModule.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //---Bind sub module

                objWorkFlowDDL.Check = 2;
                var varSubModule = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.SubModule = varSubModule.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---Bind Action

                objWorkFlowDDL.Check = 3;
                var varAction = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.Action = varAction.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---Bind Work specific

                objWorkFlowDDL.Check = 4;
                var varWorkSpecefic = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.WorkSpecefic = varWorkSpecefic.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //---Bind required notification
                var varRequiredNotification = new List<SelectListItem>();
                varRequiredNotification.Add(new SelectListItem { Text = "Yes", Value = "1" });
                varRequiredNotification.Add(new SelectListItem { Text = "No", Value = "0" });
                ViewBag.VRequiredNotification = varRequiredNotification;

                //---Bind Work specific

                objWorkFlowDDL.Check = 5;
                var varNotificationType = _WorkFlowModel.BindActivityDDL(objWorkFlowDDL);
                ViewBag.VNotificationType = varNotificationType.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                if (id != "0")
                {
                    int iId = Convert.ToInt32(protector.Encode(id));
                    objmodel.Check = 6;
                    objmodel.ActivityId = iId;
                    objmodel = _WorkFlowModel.ViewWorkFlowActivityDetails(objmodel);
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
        /// Activity details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult AddActivity(ActivityEF objmodel, string submit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
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
                    if (Convert.ToInt32(objmodel.ActionId) <= 0)
                    {
                        ModelState.AddModelError("ActionId", "Action Id is required");
                    }
                    if (Convert.ToInt32(objmodel.WorkSpecific) <= 0)
                    {
                        ModelState.AddModelError("WorkSpecific", "WorkSpecific is required");
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
                            return RedirectToAction("AddActivity", "WorkFlowActivity", new { Area = "WorkFlow" });
                        }
                        if (objMessageEF.Satus == "3" && submit == "Update")
                        {
                            TempData["msg"] = "3";//data Updated Sucessfully
                            return RedirectToAction("ViewActivity", "WorkFlowActivity", new { Area = "WorkFlow" });
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
                WorkFlowDropDown objWorkFlowDDL = WorkFlowDropDown.GetInstance();
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
                ActivityEFQuery objModel = ActivityEFQuery.GetInstance();
                List<ActivityEFQuery> objModelList = new List<ActivityEFQuery>();

                objModel.Check = 6;
                objModelList = _WorkFlowModel.ViewWorkFlowActivity(objModel);
                //ViewBag.Button = "Update";
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
        public IActionResult DeleteActivity(string id = "0")
        {
            MessageEF objMessageEF = new MessageEF();
            ActivityEF objmodel = ActivityEF.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy = profile.UserId;

                int iId = Convert.ToInt32(protector.Encode(id));
                objmodel.Check = 3;
                objmodel.ActivityId = iId;
                objMessageEF = _WorkFlowModel.DeleteWorkFlowActivity(objmodel);
                if (objMessageEF.Satus == "4")
                {
                    TempData["msg"] = "4";//Leave Assign deleted Successfully
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
