// ***********************************************************************
//  Controller Name          : LeaveManagement
//  Desciption               : Leave Management Details 
//  Created By               : Suresh Kumar Behera
//  Created On               : 13-Jul-2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EstablishmentApp.Areas.LeaveManagement.Models.LeaveManagement;
using EstablishmentEf;
using Microsoft.AspNetCore.Mvc.Rendering;

using EstablishmentApp.Web;
using EstablishmentApp.ActionFilter;

using EstablishmentApp.Areas.LeaveManagement.Models.WorkFlowNotification;


namespace EstablishmentApp.Areas.LeaveManagement.Controllers
{
    [Area("LeaveManagement")]
    public class LeaveManagementController : Controller
    {
        private ILeaveManagementModel _LeaveManagementModel;
        //-----security----
        //private readonly KhanijSecurity.KhanijIDataProtection protector;
        /// <summary>
        /// Use for Url id encryption DI, KhanijSecurity.KhanijIDataProtection khanijIDataProtection
        /// </summary>
        /// <param name="leaveManagementModel"></param>
        /// <param name="khanijIDataProtection"></param>
        public LeaveManagementController(ILeaveManagementModel leaveManagementModel)
        {
            _LeaveManagementModel = leaveManagementModel;
            //protector = khanijIDataProtection;
        }

        #region LeaveRule

        /// <summary>
        /// Leave Rule Details
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Decryption]
        public async Task<IActionResult> AddLeaveRule(string id = "0")
        {
            LeaveRuleMasterEF objmodel = new LeaveRuleMasterEF();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy =profile.UserId;
                //objmodel.UserLoginID = profile.UserLoginId;
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    int iId = Convert.ToInt32(id);
                    //int iId = Convert.ToInt32(protector.Encode(id));
                    objmodel.Check = 1;
                    objmodel.RuleId = iId;
                    objmodel = await _LeaveManagementModel.ViewLeaveRuleMasterDetails(objmodel);
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
            finally
            {
                objmodel = null;
            }

        }


        /// <summary>
        /// Add/Update Leave Rule Details
        /// </summary>
        /// <param name="objLeaveRuleMasterEF"></param>
        /// <returns></returns>
        [HttpPost]
        //[IgnoreAntiforgeryToken]
        public IActionResult AddLeaveRule(LeaveRuleMasterEF objLeaveRuleMasterEF, string submit)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objLeaveRuleMasterEF.CreatedBy = profile.UserId;

                if (string.IsNullOrEmpty(objLeaveRuleMasterEF.RuleName))
                {
                    ModelState.AddModelError("RuleName", "RuleName is required");
                }
                else if (string.IsNullOrEmpty(objLeaveRuleMasterEF.RuleNo))
                {
                    ModelState.AddModelError("RuleNo", "RuleNo is required");
                }
                else if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        //objLeaveRuleMasterEF.CreatedBy = 1;
                        objLeaveRuleMasterEF.Check = 2;
                        objMessageEF = _LeaveManagementModel.AddLeaveRuleMaster(objLeaveRuleMasterEF);
                    }
                    else
                    {
                        //objLeaveRuleMasterEF.CreatedBy = 1;
                        objLeaveRuleMasterEF.Check = 3;
                        objMessageEF = _LeaveManagementModel.AddLeaveRuleMaster(objLeaveRuleMasterEF);
                    }
                    if (objMessageEF.Satus == "1" && submit == "Submit")
                    {
                        TempData["msg"] = "1";//Rule Details Saved Successfully
                        return RedirectToAction("AddLeaveRule", "LeaveManagement", new { Area = "LeaveManagement" });
                    }
                    if (objMessageEF.Satus == "3" && submit == "Update")
                    {
                        TempData["msg"] = "3";//Rule Updated Sucessfully
                        return RedirectToAction("ViewLeaveRule", "LeaveManagement", new { Area = "LeaveManagement" });
                    }
                    else if (objMessageEF.Satus == "2")
                    {
                        TempData["msg"] = "2";//Rule Details allready exists
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving Rule Details";
                        //TempData.Keep("msg");
                    }

                }


                return View();
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

        /// <summary>
        /// View Leave Rule Details
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<IActionResult> ViewLeaveRule()
        {
            LeaveRuleMasterEF objLeaveRuleMasterEF = new LeaveRuleMasterEF();
            List<LeaveRuleMasterEF> listLeaveRule = new List<LeaveRuleMasterEF>();
            try
            {

                objLeaveRuleMasterEF.Check = 1;
                listLeaveRule = await _LeaveManagementModel.ViewLeaveRuleMaster(objLeaveRuleMasterEF);
                return View(listLeaveRule);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objLeaveRuleMasterEF = null;
                listLeaveRule = null;
            }
        }

        /// <summary>
        /// delete Leave Rule Details
        /// </summary>
        /// <param name="objLeaveRuleMasterEF"></param>
        /// <returns></returns>

        [IgnoreAntiforgeryToken]
        [Decryption]
        public IActionResult DeleteLeaveRuleDetails(string id = "0")
        {
            LeaveRuleMasterEF objLeaveRuleMasterEF = new LeaveRuleMasterEF();
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objLeaveRuleMasterEF.CreatedBy = profile.UserId;

                if (ModelState.IsValid)
                {
                    int iId = Convert.ToInt32(id);
                    objLeaveRuleMasterEF.RuleId = iId;
                    //objLeaveRuleMasterEF.CreatedBy = 1;
                    objLeaveRuleMasterEF.Check = 4;
                    objMessageEF = _LeaveManagementModel.DeleteLeaveRuleDetails(objLeaveRuleMasterEF);


                    if (objMessageEF.Satus == "4")
                    {
                        TempData["msg"] = "4";//Rule deleted Sucessfully
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving Rule Details";
                    }
                }

                return RedirectToAction("ViewLeaveRule", "LeaveManagement", new { Area = "LeaveManagement" });
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objMessageEF = null;
                objLeaveRuleMasterEF = null;
            }
        }
        #endregion

        #region LeaveType
        /// <summary>
        /// Leave Type Details
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        [Decryption]
        public async Task<IActionResult> AddLeaveType(string id = "0")
        {
            LeaveTypeMasterEF objmodel = new LeaveTypeMasterEF();
            try
            {
                ViewBag.Rule = Enumerable.Empty<SelectListItem>();

                LeaveDropDown objLeaveDDL = new LeaveDropDown();
                objLeaveDDL.Check = 5;
                var varRule = await _LeaveManagementModel.BindLeaveRule(objLeaveDDL);

                ViewBag.Rule = varRule.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),
                }).ToList();

                if (!string.IsNullOrEmpty(id) && id != "0")
                {


                    int iId = Convert.ToInt32(id);
                    objmodel.Check = 1;
                    objmodel.LeaveTypeId = iId;
                    objmodel = await _LeaveManagementModel.ViewLeaveTypeMasterDetails(objmodel);
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.Button = "Submit";
                    return View(objmodel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }

        }

        /// <summary>
        /// Add/Update Leave Type Details
        /// </summary>
        /// <param name="objLeavetypeMasterEF"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddLeaveType(LeaveTypeMasterEF objLeavetypeMasterEF, string submit)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objLeavetypeMasterEF.CreatedBy = profile.UserId;

                if (string.IsNullOrEmpty(objLeavetypeMasterEF.LeaveType.Trim()))
                {
                    ModelState.AddModelError("Leave Type", "LeaveType is required");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(objLeavetypeMasterEF.NoOfLeave).Trim()))
                {
                    ModelState.AddModelError("No Of Leave ", "No Of Leave is required");
                }
                else if (Convert.ToInt32( objLeavetypeMasterEF.NoOfLeave)<=0)
                {
                    ModelState.AddModelError("No Of Leave ", "No Of Leave is required");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(objLeavetypeMasterEF.Description).Trim()))
                {
                    ModelState.AddModelError("Description", "Description is required");
                }
                else if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        //objLeavetypeMasterEF.CreatedBy = 1;
                        objLeavetypeMasterEF.Check = 2;
                        objMessageEF = _LeaveManagementModel.AddLeaveTypeMaster(objLeavetypeMasterEF);
                    }
                    else
                    {
                        //objLeavetypeMasterEF.CreatedBy = 1;
                        objLeavetypeMasterEF.Check = 3;
                        objMessageEF = _LeaveManagementModel.AddLeaveTypeMaster(objLeavetypeMasterEF);
                    }
                    if (objMessageEF.Satus == "1" && submit == "Submit")
                    {
                        TempData["msg"] = "1";//Leave Type Details Saved Successfully
                        return RedirectToAction("AddLeaveType");
                    }
                    if (objMessageEF.Satus == "3" && submit == "Update")
                    {
                        TempData["msg"] = "3";//Leave Type Updated Sucessfully
                        return RedirectToAction("ViewLeaveType", "LeaveManagement", new { Area = "LeaveManagement" });
                    }
                    else if (objMessageEF.Satus == "2")
                    {
                        TempData["msg"] = "2";//Leave Type Details allready exists
                        return RedirectToAction("AddLeaveType");
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving Leave Type Details";
                    }

                }


                return View();
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

        /// <summary>
        /// View Leave Type Details
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<IActionResult> ViewLeaveType()
        {
            LeaveTypeMasterEF objLeaveTypeMasterEF = new LeaveTypeMasterEF();
            List<LeaveTypeMasterEF> listLeaveType = new List<LeaveTypeMasterEF>();
            try
            {

                objLeaveTypeMasterEF.Check = 1;
                listLeaveType = await _LeaveManagementModel.ViewLeaveTypeMaster(objLeaveTypeMasterEF);
                return View(listLeaveType);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objLeaveTypeMasterEF = null;
                listLeaveType = null;
            }
        }

        /// <summary>
        /// delete Leave Type Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [IgnoreAntiforgeryToken]
        [Decryption]
        public IActionResult DeleteLeaveTypeDetails(string id = "0")
        {
            LeaveTypeMasterEF objLeaveTypeMasterEF = new LeaveTypeMasterEF();
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objLeaveTypeMasterEF.CreatedBy = profile.UserId;

                if (ModelState.IsValid)
                {
                    int iId = Convert.ToInt32(id);
                    objLeaveTypeMasterEF.LeaveTypeId = iId;
                    //objLeaveTypeMasterEF.CreatedBy = 1;
                    objLeaveTypeMasterEF.Check = 4;
                    objMessageEF = _LeaveManagementModel.DeleteLeaveTypeDetails(objLeaveTypeMasterEF);


                    if (objMessageEF.Satus == "4")
                    {
                        TempData["msg"] = "4";//Leave Type deleted Sucessfully
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving Rule Details";
                    }
                }

                return RedirectToAction("ViewLeaveType", "LeaveManagement", new { Area = "LeaveManagement" });
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objMessageEF = null;
                objLeaveTypeMasterEF = null;
            }
        }
        #endregion

        #region HolidayType
        /// <summary>
        /// Holiday type details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> AddHolidayType(string id = "0")
        {
            HolidayTypeMasterEF objmodel = new HolidayTypeMasterEF();
            try
            {
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    int iId = Convert.ToInt32(id);
                    objmodel.Check = 1;
                    objmodel.HolidayTypeId = iId;
                    objmodel = await _LeaveManagementModel.ViewHolidayTypeDetails(objmodel);
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.Button = "Submit";
                    ModelState.Clear();
                    return View(objmodel);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Add/Update Holiday type
        /// </summary>
        /// <param name="objHolidayType"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddHolidayType(HolidayTypeMasterEF objHolidayType, string submit)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objHolidayType.CreatedBy = profile.UserId;

                if (string.IsNullOrEmpty(objHolidayType.HolidayTypeName.Trim()))
                {
                    ModelState.AddModelError("Leave Type", "HolidayType Name is required");
                }
                else if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        //objHolidayType.CreatedBy = 1;
                        objHolidayType.Check = 2;
                        objMessageEF = _LeaveManagementModel.AddHolidayType(objHolidayType);
                    }
                    else
                    {
                        //objHolidayType.CreatedBy = 1;
                        objHolidayType.Check = 3;
                        objMessageEF = _LeaveManagementModel.AddHolidayType(objHolidayType);
                    }
                    if (objMessageEF.Satus == "1" && submit == "Submit")
                    {
                        TempData["msg"] = "1";//Holiday Type Saved Successfully
                        return RedirectToAction("AddHolidayType", "LeaveManagement", new { Area = "LeaveManagement" });

                    }
                    if (objMessageEF.Satus == "3" && submit == "Update")
                    {
                        TempData["msg"] = "3";//Holiday Type Updated Sucessfully
                        return RedirectToAction("ViewHolidayType", "LeaveManagement", new { Area = "LeaveManagement" });
                    }
                    else if (objMessageEF.Satus == "2")
                    {
                        TempData["msg"] = "Holiday Type Details allready exists";

                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving Holiday Type Details";

                    }

                }

                return View();
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

        /// <summary>
        /// View Leave Type Details
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<IActionResult> ViewHolidayType()
        {
            HolidayTypeMasterEF objHolidayType = new HolidayTypeMasterEF();
            List<HolidayTypeMasterEF> listHoliday = new List<HolidayTypeMasterEF>();
            try
            {

                objHolidayType.Check = 1;
                listHoliday = await _LeaveManagementModel.ViewHolidayTypeMaster(objHolidayType);
                return View(listHoliday);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objHolidayType = null;
                listHoliday = null;
            }
        }

        /// <summary>
        /// delete Holiday Type Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [IgnoreAntiforgeryToken]
        [Decryption]
        public IActionResult DeleteHolidayType(string id = "0")
        {
            HolidayTypeMasterEF objHoliday = new HolidayTypeMasterEF();
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objHoliday.CreatedBy = profile.UserId;

                if (ModelState.IsValid)
                {
                    int iId = Convert.ToInt32(id);
                    objHoliday.HolidayTypeId = iId;
                    //objHoliday.CreatedBy = 1;
                    objHoliday.Check = 4;
                    objMessageEF = _LeaveManagementModel.DeleteHolidayType(objHoliday);

                    if (objMessageEF.Satus == "4")
                    {
                        TempData["msg"] = "4";//Leave Type deleted Sucessfully
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving Rule Details";
                    }
                }

                return RedirectToAction("ViewHolidayType", "LeaveManagement", new { Area = "LeaveManagement" });
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objMessageEF = null;
                objHoliday = null;
            }
        }
        #endregion

        #region Holiday
        /// <summary>
        /// Add Holiday
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Decryption]
        public async Task<IActionResult> AddHoliday(string id = "0")
        {
            HolidayMasterEF objmodel = new HolidayMasterEF();
            try
            {
                ViewBag.HolidayType = Enumerable.Empty<SelectListItem>();
                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                objLeaveDropDown.Check = 5;
                var varHolidayType = await _LeaveManagementModel.BindDropdown(objLeaveDropDown);

                ViewBag.HolidayType = varHolidayType.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    int iId = Convert.ToInt32(id);
                    objmodel.Check = 1;
                    objmodel.HolidayId = iId;
                    objmodel = await _LeaveManagementModel.ViewHolidayDetails(objmodel);
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {

                    ViewBag.Button = "Submit";
                    ModelState.Clear();
                    return View(objmodel);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Add/Update holiday
        /// </summary>
        /// <param name="objHoliday"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddHoliday(HolidayMasterEF objHoliday, string submit)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objHoliday.CreatedBy = profile.UserId;


                if (string.IsNullOrEmpty(objHoliday.HolidayName.Trim()))
                {
                    ModelState.AddModelError("HolidayName", "Holiday Name is required");
                }
                else if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        //objHoliday.CreatedBy = 1;
                        objHoliday.Check = 2;
                        objMessageEF = _LeaveManagementModel.AddHoliday(objHoliday);
                    }
                    else
                    {
                        //objHoliday.CreatedBy = 1;
                        objHoliday.Check = 3;
                        objMessageEF = _LeaveManagementModel.AddHoliday(objHoliday);
                    }
                    if (objMessageEF.Satus == "1" && submit == "Submit")
                    {
                        TempData["msg"] = "1";//Holiday Details Saved Successfully
                        return RedirectToAction("AddHoliday", "LeaveManagement", new { Area = "LeaveManagement" });

                    }
                    if (objMessageEF.Satus == "3" && submit == "Update")
                    {
                        TempData["msg"] = "3";//Holiday Updated Sucessfully
                        return RedirectToAction("ViewHoliday", "LeaveManagement", new { Area = "LeaveManagement" });
                    }
                    else if (objMessageEF.Satus == "2")
                    {
                        TempData["msg"] = "2";//Holiday Details allready exists

                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving Holiday Details";

                    }

                }

                return View();
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


        /// <summary>
        /// View holiday
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<IActionResult> ViewHoliday()
        {
            HolidayMasterEF objHolidayType = new HolidayMasterEF();
            List<HolidayMasterEF> listHoliday = new List<HolidayMasterEF>();
            try
            {

                objHolidayType.Check = 1;
                listHoliday = await _LeaveManagementModel.ViewHoliday(objHolidayType);
                return View(listHoliday);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objHolidayType = null;
                listHoliday = null;
            }
        }

        /// <summary>
        /// delete holiday
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [IgnoreAntiforgeryToken]
        [Decryption]
        public IActionResult DeleteHoliday(string id = "0")
        {
            HolidayMasterEF objHoliday = new HolidayMasterEF();
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objHoliday.CreatedBy = profile.UserId;

                if (ModelState.IsValid)
                {
                    int iId = Convert.ToInt32(id);
                    objHoliday.HolidayId = iId;
                    //objHoliday.CreatedBy = 1;
                    objHoliday.Check = 4;
                    objMessageEF = _LeaveManagementModel.DeleteHoliday(objHoliday);

                    if (objMessageEF.Satus == "4")
                    {
                        TempData["msg"] = "4";//Holiday deleted Sucessfully
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while delete holiday Details";
                    }
                }

                return RedirectToAction("ViewHoliday", "LeaveManagement", new { Area = "LeaveManagement" });
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objMessageEF = null;
                objHoliday = null;
            }
        }
        #endregion

        #region RiderLeave
        /// <summary>
        /// Add rider leave
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Decryption]
        public async Task<IActionResult> AddRiderLeave(string id = "0")
        {
            RiderLeave objmodel = new RiderLeave();
            try
            {
                ViewBag.District = Enumerable.Empty<SelectListItem>();
                ViewBag.Designation = Enumerable.Empty<SelectListItem>();
                ViewBag.LeaveType = Enumerable.Empty<SelectListItem>();


                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                objLeaveDropDown.Check = 5;
                var varDistrict = await _LeaveManagementModel.BindDistrict(objLeaveDropDown);

                ViewBag.District = varDistrict.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                objLeaveDropDown = new LeaveDropDown();
                objLeaveDropDown.Check = 6;
                var varDesignation = await _LeaveManagementModel.BindDesignation(objLeaveDropDown);

                ViewBag.Designation = varDesignation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                objLeaveDropDown = new LeaveDropDown();
                objLeaveDropDown.Check = 7;
                var varLeaveType = await _LeaveManagementModel.BindLeaveType(objLeaveDropDown);

                ViewBag.LeaveType = varLeaveType.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    int iId = Convert.ToInt32(id);
                    objmodel.Check = 1;
                    objmodel.RiderLeaveId = iId;
                    objmodel = await _LeaveManagementModel.ViewRiderleaveDetails(objmodel);
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.Button = "Submit";
                    ModelState.Clear();
                    return View(objmodel);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Add/Update rider leave
        /// </summary>
        /// <param name="objRiderLeave"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddRiderLeave(RiderLeave objRiderLeave, string submit)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objRiderLeave.CreatedBy = profile.UserId;

                if (string.IsNullOrEmpty(objRiderLeave.Remarks.Trim()))
                {
                    ModelState.AddModelError("Remarks", "Remarks is required");
                }
                else if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        //objRiderLeave.CreatedBy = 1;
                        objRiderLeave.Check = 2;
                        objMessageEF = _LeaveManagementModel.AddRiderLeave(objRiderLeave);
                    }
                    else
                    {

                        //objRiderLeave.CreatedBy = 1;
                        objRiderLeave.Check = 3;
                        objMessageEF = _LeaveManagementModel.AddRiderLeave(objRiderLeave);
                    }
                    if (objMessageEF.Satus == "1" && submit == "Submit")
                    {
                        TempData["msg"] = "1";//Rider Leave Details Saved Successfully
                        return RedirectToAction("AddRiderLeave", "LeaveManagement", new { Area = "LeaveManagement" });

                    }
                    if (objMessageEF.Satus == "3" && submit == "Update")
                    {
                        TempData["msg"] = "3";//Rider Leave Updated Sucessfully
                        return RedirectToAction("ViewRiderLeave", "LeaveManagement", new { Area = "LeaveManagement" });
                    }
                    else if (objMessageEF.Satus == "2")
                    {
                        TempData["msg"] = "Rider Leave Details allready exists";

                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving Rider Leave Details";

                    }

                }

                return View();
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

        /// <summary>
        /// view rider leave
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewRiderLeave()
        {

            RiderLeave objHolidayType = new RiderLeave();
            List<RiderLeave> listHoliday = new List<RiderLeave>();
            try
            {

                objHolidayType.Check = 1;
                listHoliday = await _LeaveManagementModel.ViewRiderleave(objHolidayType);
                return View(listHoliday);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objHolidayType = null;
                listHoliday = null;
            }
        }


        /// <summary>
        /// delete rider leave
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [IgnoreAntiforgeryToken]
        [Decryption]
        public IActionResult DeleteRiderLeave(string  id = "0")
        {
            RiderLeave objHoliday = new RiderLeave();
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objHoliday.CreatedBy = profile.UserId;


                if (ModelState.IsValid)
                {
                    int iId = Convert.ToInt32(id);
                    objHoliday.RiderLeaveId = iId;
                    //objHoliday.CreatedBy = 1;
                    objHoliday.Check = 4;
                    objMessageEF = _LeaveManagementModel.DeleteRiderLeave(objHoliday);

                    if (objMessageEF.Satus == "4")
                    {
                        TempData["msg"] = "4";//Rider leave deleted Sucessfully
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while delete rider leave Details";
                    }
                }

                return RedirectToAction("ViewRiderLeave", "LeaveManagement", new { Area = "LeaveManagement" });
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objMessageEF = null;
                objHoliday = null;
            }
        }
        #endregion

        #region AuthoritySetting
        /// <summary>
        /// Add authority setting
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddAuthoritySetting(int id = 0)
        {
            AuthoritySetting objmodel = new AuthoritySetting();
            try
            {

                ViewBag.State = Enumerable.Empty<SelectListItem>();
                ViewBag.Department = Enumerable.Empty<SelectListItem>();
                ViewBag.District = Enumerable.Empty<SelectListItem>();

                ViewBag.VerifyDesignation = Enumerable.Empty<SelectListItem>();
                ViewBag.ForwardDepartment = Enumerable.Empty<SelectListItem>();
                ViewBag.ForwardDesignation = Enumerable.Empty<SelectListItem>();

                ViewBag.OICOfficer = Enumerable.Empty<SelectListItem>();
                ViewBag.OICApproveDesignation = Enumerable.Empty<SelectListItem>();
                ViewBag.OICApproveUserId = Enumerable.Empty<SelectListItem>();

                ViewBag.DaysExceed1 = Enumerable.Empty<SelectListItem>();
                ViewBag.NextApproveDesignation1 = Enumerable.Empty<SelectListItem>();
                ViewBag.NextApprovedUserId1 = Enumerable.Empty<SelectListItem>();

                ViewBag.DaysExceed2 = Enumerable.Empty<SelectListItem>();
                ViewBag.NextApprovedDesignation2 = Enumerable.Empty<SelectListItem>();
                ViewBag.NextApprovedUserId2 = Enumerable.Empty<SelectListItem>();

                LeaveDropDown objLeaveDropDown = new LeaveDropDown();

                //---Bind State

                objLeaveDropDown.Check = 5;
                var varState = await _LeaveManagementModel.BindState_Authority(objLeaveDropDown);

                ViewBag.State = varState.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //--Bind Department
                objLeaveDropDown.Check = 6;
                var varDepartment = await _LeaveManagementModel.BindDepartment_Authority(objLeaveDropDown);

                ViewBag.Department = varDepartment.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //--Bind verify Designation
                objLeaveDropDown.Check = 8;
                var varVerifyDesignation = await _LeaveManagementModel.BindVerifyDesignation(objLeaveDropDown);

                ViewBag.VerifyDesignation = varVerifyDesignation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //Bind forward department
                objLeaveDropDown.Check = 9;
                var varForwardDepartment = await _LeaveManagementModel.BindForwardDepartment_Authority(objLeaveDropDown);

                ViewBag.ForwardDepartment = varForwardDepartment.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //-Bind forward designation
                objLeaveDropDown.Check = 10;
                var varForwardDesignation = await _LeaveManagementModel.BindForwardDesignation(objLeaveDropDown);

                ViewBag.ForwardDesignation = varForwardDesignation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //Bind OIC officer 
                objLeaveDropDown.Check = 11;
                objLeaveDropDown.Id = 21;
                var varOICOfficer = await _LeaveManagementModel.BindOICOfficer(objLeaveDropDown);

                ViewBag.OICOfficer = varOICOfficer.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //Bind OIC Approve/reject designation  
                objLeaveDropDown.Check = 12;
                var varOICApproveDesignation = await _LeaveManagementModel.BindOICApproveDesignation(objLeaveDropDown);

                ViewBag.OICApproveDesignation = varOICApproveDesignation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();



                //----bind no of days exceed first level
                objLeaveDropDown.Check = 14;
                var varDaysExceed1 = await _LeaveManagementModel.BindNoOfDaysExceed_FirstLevel(objLeaveDropDown);

                ViewBag.DaysExceed1 = varDaysExceed1.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //----bind next approve/reject designation first level
                objLeaveDropDown.Check = 15;
                var varNextApproveDesignation1 = await _LeaveManagementModel.BindNextApproveDesignation1(objLeaveDropDown);

                ViewBag.NextApproveDesignation1 = varNextApproveDesignation1.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();




                //----bind no of days exceed second level
                objLeaveDropDown.Check = 17;
                var varDaysExceed2 = await _LeaveManagementModel.BindNoOfDaysExceed_secondLevel(objLeaveDropDown);

                ViewBag.DaysExceed2 = varDaysExceed2.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //----bind next approve/reset designation second level
                objLeaveDropDown.Check = 18;
                var varNextApproveDesignation2 = await _LeaveManagementModel.BindNextApproveDesignation2(objLeaveDropDown);

                ViewBag.NextApprovedDesignation2 = varNextApproveDesignation2.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                if (id > 0)
                {
                    objmodel.Check = 2;
                    objmodel.intAuthorityId = id;
                    objmodel = await _LeaveManagementModel.ViewAuthoritySettingDetails(objmodel);

                    //--Bind District when state selected

                    objLeaveDropDown.Check = 7;
                    objLeaveDropDown.Id = objmodel.intStateId;
                    var varDistrict = await _LeaveManagementModel.BindDistrict_Authority(objLeaveDropDown);
                    ViewBag.District = varDistrict.ToList().Select(c => new SelectListItem
                    {
                        Text = c.Text,
                        Value = c.Value.ToString(),
                    }
                    ).ToList();



                    //-Bind forward designation
                    objLeaveDropDown.Check = 10;
                    varForwardDesignation = await _LeaveManagementModel.BindForwardDesignation(objLeaveDropDown);

                    ViewBag.ForwardDesignation = varForwardDesignation.ToList().Select(c => new SelectListItem
                    {
                        Text = c.Text,
                        Value = c.Value.ToString(),

                    }).ToList();


                    //---OIC Approved User-----

                    objLeaveDropDown.Check = 13;
                    objLeaveDropDown.Id = objmodel.intOicApproveDesignationId;
                    var varOICApproveUserId = await _LeaveManagementModel.BindOICApproveUser(objLeaveDropDown);

                    ViewBag.OICApproveUserId = varOICApproveUserId.ToList().Select(c => new SelectListItem
                    {
                        Text = c.Text,
                        Value = c.Value.ToString(),

                    }).ToList();




                    objLeaveDropDown.Check = 16;
                    objLeaveDropDown.Id = objmodel.intNextApprovedDesignationId1;
                    var varNextApprovedUserId1 = await _LeaveManagementModel.BindNextApproveUser1(objLeaveDropDown);
                    ViewBag.NextApprovedUserId1 = varNextApprovedUserId1.ToList().Select(c => new SelectListItem
                    {
                        Text = c.Text,
                        Value = c.Value.ToString(),
                    }
                    ).ToList();




                    objLeaveDropDown.Check = 19;
                    objLeaveDropDown.Id = objmodel.intNextApprovedDesignationId2;
                    var varNextApprovedUserId2 = await _LeaveManagementModel.BindNextApproveUser2(objLeaveDropDown);
                    ViewBag.NextApprovedUserId2 = varNextApprovedUserId2.ToList().Select(c => new SelectListItem
                    {
                        Text = c.Text,
                        Value = c.Value.ToString(),
                    }
                    ).ToList();




                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.Button = "Submit";
                    ModelState.Clear();
                    return View(objmodel);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// add/update authority setting
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddAuthoritySetting(AuthoritySetting objmodel, string submit)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {


                if (string.IsNullOrEmpty(objmodel.intStateId.ToString().Trim()))
                {
                    ModelState.AddModelError("intStateId", "State is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intDepartmentId.ToString().Trim()))
                {
                    ModelState.AddModelError("intDepartmentId", "DEpartment is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intDistrictId.ToString().Trim()))
                {
                    ModelState.AddModelError("intDistrictId", "District is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intVerifyDesignationId.ToString().Trim()))
                {
                    ModelState.AddModelError("intVerifyDesignationId", "Verify Designation is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intForwardDepartmentId.ToString().Trim()))
                {
                    ModelState.AddModelError("intForwardDepartmentId", "Forward Department is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intForwardDesignationId.ToString().Trim()))
                {
                    ModelState.AddModelError("intForwardDesignationId", "Forward Designation is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intOicOfficerId.ToString().Trim()))
                {
                    ModelState.AddModelError("intOicOfficerId", "OIC Officer is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intOicApproveDesignationId.ToString().Trim()))
                {
                    ModelState.AddModelError("intOicApproveDesignationId", "OIC Approved designation is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intOicApproveUserId.ToString().Trim()))
                {
                    ModelState.AddModelError("intOicApproveUserId", "Approved User is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intDaysExceed1.ToString().Trim()))
                {
                    ModelState.AddModelError("intDaysExceed1", "Day exceed is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intNextApprovedDesignationId1.ToString().Trim()))
                {
                    ModelState.AddModelError("intNextApprovedDesignationId1", "Next Approve designation is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intNextApprovedUserId1.ToString().Trim()))
                {
                    ModelState.AddModelError("intNextApprovedUserId1", "Next Approved User is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intDaysExceed2.ToString().Trim()))
                {
                    ModelState.AddModelError("intDaysExceed2", "Day Exceed is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intNextApprovedDesignationId2.ToString().Trim()))
                {
                    ModelState.AddModelError("intNextApprovedDesignationId2", "Next Approved Designation is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intNextApprovedUserId2.ToString().Trim()))
                {
                    ModelState.AddModelError("intNextApprovedUserId2", "Next Approved User is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intStateId.ToString().Trim()))
                {
                    ModelState.AddModelError("intStateId", "State is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intStateId.ToString().Trim()))
                {
                    ModelState.AddModelError("intStateId", "State is required");
                }
                else if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        objmodel.intCreatedBy = 1;
                        objmodel.Check = 1;
                        objMessageEF = _LeaveManagementModel.AddAuthoritySetting(objmodel);
                    }
                    else
                    {

                        objmodel.intCreatedBy = 1;
                        objmodel.Check = 2;
                        objMessageEF = _LeaveManagementModel.AddAuthoritySetting(objmodel);
                    }
                    if (objMessageEF.Satus == "1" && submit == "Submit")
                    {
                        TempData["msg"] = "Authority Setting Saved Successfully";
                        return RedirectToAction("ViewAuthoritySetting", "LeaveManagement", new { Area = "LeaveManagement" });

                    }
                    if (objMessageEF.Satus == "1" && submit == "Update")
                    {
                        TempData["msg"] = "Authority Setting Updated Sucessfully";
                        return RedirectToAction("ViewAuthoritySetting", "LeaveManagement", new { Area = "LeaveManagement" });
                    }
                    else if (objMessageEF.Satus == "2")
                    {
                        TempData["msg"] = "Authority Setting Details allready exists";

                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving Authority Setting Details";

                    }

                }

                return View();
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

        /// <summary>
        /// bind district for authority setting
        /// </summary>
        /// <param name="Stateid"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> BindDistrict(int Stateid)
        {
            try
            {
                LeaveDropDown objEmpDropDown = new LeaveDropDown();
                objEmpDropDown.Check = 7;
                objEmpDropDown.Id = Stateid;
                var HomeDistrict = await _LeaveManagementModel.BindDistrict_Authority(objEmpDropDown);
                return Json(HomeDistrict);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// bind OIC approved user
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> BindOICApproveUser(int UserTypeId)
        {
            try
            {
                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                objLeaveDropDown.Check = 13;
                objLeaveDropDown.Id = UserTypeId;
                var varOICApproveUserId = await _LeaveManagementModel.BindOICApproveUser(objLeaveDropDown);
                return Json(varOICApproveUserId);
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
        public async Task<JsonResult> BindNextApproveUser1(int UserTypeId)
        {
            try
            {
                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                objLeaveDropDown.Check = 16;
                objLeaveDropDown.Id = UserTypeId;
                var varNextApprovedUserId1 = await _LeaveManagementModel.BindNextApproveUser1(objLeaveDropDown);
                return Json(varNextApprovedUserId1);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// bind next user2
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> BindNextApproveUser2(int UserTypeId)
        {
            try
            {
                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                objLeaveDropDown.Check = 19;
                objLeaveDropDown.Id = UserTypeId;
                var varNextApprovedUserId1 = await _LeaveManagementModel.BindNextApproveUser2(objLeaveDropDown);
                return Json(varNextApprovedUserId1);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// View authority setting details
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewAuthoritySetting()
        {
            AuthoritySettingQuery objAuthoritySetting = new AuthoritySettingQuery();
            List<AuthoritySettingQuery> listAuthoritySetting = new List<AuthoritySettingQuery>();
            try
            {
                objAuthoritySetting.Check = 1;
                listAuthoritySetting = await _LeaveManagementModel.ViewAuthoritySetting(objAuthoritySetting);
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
        public IActionResult DeleteAuthoritySetting(int id = 0)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            AuthoritySetting objmodel = new AuthoritySetting();
            try
            {
                objmodel.intCreatedBy = 1;
                objmodel.Check = 3;
                objmodel.intAuthorityId = id;
                objMessageEF = _LeaveManagementModel.DeleteAuthoritySetting(objmodel);

                if (objMessageEF.Satus == "1")
                {
                    TempData["msg"] = "Authority deleted Successfully";
                }
                else
                {
                    TempData["msg"] = "Error ! while deleting Authority Setting Details";
                }
                return RedirectToAction("ViewAuthoritySetting", "LeaveManagement", new { Area = "LeaveManagement" });
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region tribal Leave

        /// <summary>
        /// tribal dist leave configuration
        /// </summary>
        /// <returns></returns>
        /// 
        [Decryption]
        public async Task<IActionResult> TribalLeaveConfiguration(string id = "0")
        {

            TribalDistLeave objmodel = new TribalDistLeave();
            try
            {
                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                ViewBag.District = Enumerable.Empty<SelectListItem>();
                ViewBag.LeaveType = Enumerable.Empty<SelectListItem>();

                //---Bind Leave Type
                objLeaveDropDown.Check = 7;
                var varLeaveType = await _LeaveManagementModel.BindLeaveType(objLeaveDropDown);

                ViewBag.LeaveType = varLeaveType.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---Bind District

                objLeaveDropDown.Check = 5;
                var varDistrict = await _LeaveManagementModel.BindDistrict(objLeaveDropDown);
                ViewBag.District = varDistrict.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //---use for during edit
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    int iId = Convert.ToInt32(id);
                    objmodel.Check = 1;
                    objmodel.intTribalLeaveid = iId;
                    objmodel = await _LeaveManagementModel.ViewTribalDistrictLeaveDetails(objmodel);
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
        /// add/update tribal dist leave configuration
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult TribalLeaveConfiguration(TribalDistLeave objmodel, string submit)
        {

            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;

                if (string.IsNullOrEmpty(objmodel.intLeaveTypeId.ToString().Trim()))
                {
                    ModelState.AddModelError("intLeaveTypeId", "Leave type is required");
                }
                else if (string.IsNullOrEmpty(objmodel.IntDistrictId.ToString().Trim()))
                {
                    ModelState.AddModelError("IntDistrictId", "Tribal District is required");
                }

                else if (string.IsNullOrEmpty(objmodel.intNoOfLeave.ToString().Trim()))
                {
                    ModelState.AddModelError("intNoOfDays", "No Of days is required");
                }

                else if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        //objmodel.intCreatedBy = 1;
                        objmodel.Check = 1;
                        objMessageEF = _LeaveManagementModel.AddTribalDistrictLeave(objmodel);
                    }
                    else
                    {
                        objmodel.Check = 2;
                        //objmodel.intCreatedBy = 1;
                        objMessageEF = _LeaveManagementModel.AddTribalDistrictLeave(objmodel);
                    }
                    if (objMessageEF.Satus == "1" && submit == "Submit")
                    {
                        TempData["msg"] = "1";//---save sucess
                        return RedirectToAction("TribalLeaveConfiguration");

                    }
                    if (objMessageEF.Satus == "3" && submit == "Update")
                    {
                        TempData["msg"] = "3";//---update sucess
                        return RedirectToAction("ViewTribalDistrictLeave");
                    }
                    else if (objMessageEF.Satus == "2")
                    {
                        TempData["msg"] = "2";//---allready exists
                        return RedirectToAction("TribalLeaveConfiguration");
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving  assign class wise Details";
                        return RedirectToAction("TribalLeaveConfiguration");
                    }

                }
                else
                {
                    TempData["msg"] = "Error ! while Saving  assign class wise Details";

                }

                return RedirectToAction("TribalLeaveConfiguration");
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// View tribal dist leave configuration details
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewTribalDistrictLeave()
        {

            TribalDistLeaveQuery objApplyLeave = new TribalDistLeaveQuery();
            List<TribalDistLeaveQuery> listAuthoritySetting = new List<TribalDistLeaveQuery>();
            try
            {
                objApplyLeave.Check = 1;
                listAuthoritySetting = await _LeaveManagementModel.ViewTribalDistrictLeave(objApplyLeave);
                return View(listAuthoritySetting);

            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// delete user wise set authority
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [IgnoreAntiforgeryToken]
        [Decryption]
        public IActionResult DeleteTribalDistrictLeave(string id = "0")
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            TribalDistLeave objmodel = new TribalDistLeave();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;

                int iId = Convert.ToInt32(id);
                objmodel.Check = 3;
                objmodel.intTribalLeaveid = iId;
                ///objmodel.intCreatedBy = 1;
                objMessageEF = _LeaveManagementModel.DeleteTribalDistrictLeave(objmodel);
                if (objMessageEF.Satus == "4")
                {
                    TempData["msg"] = "4";
                }
                else
                {
                    TempData["msg"] = "Error ! while deleting leave assign Details";
                }
                return RedirectToAction("ViewTribalDistrictLeave");
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region User wise set Authority
        /// <summary>
        /// user wise authority setting
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Decryption]
        public async Task<IActionResult> AddUserWiseSetAuthority(string id = "0")
        {
            UserWiseSetAuthority objmodel = new UserWiseSetAuthority();
            try
            {
                //objmodel.intAuthorityId = id;
                ViewBag.State = Enumerable.Empty<SelectListItem>();
                ViewBag.Department = Enumerable.Empty<SelectListItem>();
                ViewBag.EmployeeOfficeLevel = Enumerable.Empty<SelectListItem>();
                ViewBag.EmploeeDesignation = Enumerable.Empty<SelectListItem>();
                ViewBag.Employee = Enumerable.Empty<SelectListItem>();

                //ViewBag.Step = Enumerable.Empty<SelectListItem>();

                ViewBag.PrimaryOfficeLevel = Enumerable.Empty<SelectListItem>();
                ViewBag.PrimaryDesignation = Enumerable.Empty<SelectListItem>();
                ViewBag.PrimaryAuthority = Enumerable.Empty<SelectListItem>();

                ViewBag.SecondaryOfficeLevel = Enumerable.Empty<SelectListItem>();
                ViewBag.SecondaryDesignation = Enumerable.Empty<SelectListItem>();
                ViewBag.SecondaryAuthority = Enumerable.Empty<SelectListItem>();


                LeaveDropDown objLeaveDropDown = new LeaveDropDown();

                #region Employee
                //---Bind State

                objLeaveDropDown.Check = 5;
                var varState = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);

                ViewBag.State = varState.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //--Bind Department
                objLeaveDropDown.Check = 6;
                var varDepartment = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);

                ViewBag.Department = varDepartment.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //Bind Employeeoffice level
                objLeaveDropDown.Check = 7;
                var varEmployeeOfficeLevel = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);

                ViewBag.EmployeeOfficeLevel = varEmployeeOfficeLevel.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //Bind employee designation
                objLeaveDropDown.Check = 8;
                var varEmploeeDesignation = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);

                ViewBag.EmploeeDesignation = varEmploeeDesignation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //Bind employee 
                objLeaveDropDown.Check = 9;
                var varEmployee = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);

                ViewBag.Employee = varEmployee.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();



                #endregion

                #region primary action taking authority

                //Bind Employeeoffice level
                objLeaveDropDown.Check = 7;
                var varPrimaryOfficeLevel = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);

                ViewBag.PrimaryOfficeLevel = varPrimaryOfficeLevel.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //Bind employee designation
                objLeaveDropDown.Check = 8;
                var varPrimaryDesignation = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);

                ViewBag.PrimaryDesignation = varPrimaryDesignation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //Bind employee 
                objLeaveDropDown.Check = 9;
                var varPrimaryAuthority = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);

                ViewBag.PrimaryAuthority = varPrimaryAuthority.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                #endregion

                #region Secondary action taking authority

                //Bind Employeeoffice level
                objLeaveDropDown.Check = 7;
                var varSecondaryOfficeLevel = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);

                ViewBag.SecondaryOfficeLevel = varSecondaryOfficeLevel.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //Bind employee designation
                objLeaveDropDown.Check = 8;
                var varSecondaryDesignation = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);

                ViewBag.SecondaryDesignation = varSecondaryDesignation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //Bind employee 
                objLeaveDropDown.Check = 9;
                var varSecondaryAuthority = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);

                ViewBag.SecondaryAuthority = varSecondaryAuthority.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                #endregion

                //---use for during edit
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    int iId = Convert.ToInt32(id);
                    objmodel.Check = 2;
                    objmodel.intAuthorityId = iId;
                    objmodel = await _LeaveManagementModel.ViewUserWiseSetAuthoritySettingDetails(objmodel);


                    objmodel.Check = 1;
                    objmodel.intAuthorityId = iId;
                    objmodel.childAuthority = await _LeaveManagementModel.ViewUserWiseSetAuthorityChild(objmodel);

                    objmodel.intStep = objmodel.childAuthority.Count + 1;
                    objmodel.intPrimaryOfficeLevelId = 0;
                    objmodel.intPrimaryDesignationId = 0;
                    objmodel.intPrimaryAuthorityUserId = 0;

                    objmodel.intSecondaryOfficeLevelid = 0;
                    objmodel.intSecondaryDesignationId = 0;
                    objmodel.intSecondaryAuthorityUserId = 0;

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
        /// Bind next approve user1
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> BindEmployeeOfficeLevelWise(int OfficeLevelId = 0, int UserTypeId = 0,int EmployeeId=0)
        {
            try
            {
                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                objLeaveDropDown.Check = 9;
                objLeaveDropDown.Id = OfficeLevelId;
                objLeaveDropDown.Id2 = UserTypeId;
                objLeaveDropDown.Id3 = EmployeeId;
                var varNextApprovedUserId1 = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);
                return Json(varNextApprovedUserId1);
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
        public async Task<JsonResult> BindOfficeLevelById(int id = 0)
        {
            try
            {
                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                objLeaveDropDown.Check = 7;
                objLeaveDropDown.Id = id;
                var varNextApprovedUserId1 = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);
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
        public async Task<JsonResult> BindDesignationById(int id = 0)
        {
            try
            {
                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                objLeaveDropDown.Check = 8;
                objLeaveDropDown.Id = id;
                var varNextApprovedUserId1 = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);
                return Json(varNextApprovedUserId1);
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
        public async Task<JsonResult> BindEmployeeIdWise(int OfficeLevelId = 0, int UserTypeId = 0, int EmployeeId = 0)
        {
            try
            {
                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                objLeaveDropDown.Check = 11;
                objLeaveDropDown.Id = OfficeLevelId;
                objLeaveDropDown.Id2 = UserTypeId;
                objLeaveDropDown.Id3 = EmployeeId;
                var varNextApprovedUserId1 = await _LeaveManagementModel.BindDropDownSetAuthority(objLeaveDropDown);
                return Json(varNextApprovedUserId1);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// add/update user wise set authority
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddUserWiseSetAuthority(UserWiseSetAuthority objmodel)
        {
            MessageEF objMessageEF =new MessageEF();
            //MessageEF objMessageEF = new MessageEF();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;


                if (string.IsNullOrEmpty(objmodel.intEmpStateId.ToString().Trim()))
                {
                    ModelState.AddModelError("intEmpStateId", "State is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intEmpDepartmentId.ToString().Trim()))
                {
                    ModelState.AddModelError("intEmpDepartmentId", "Department is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intEmpOfficeLevelId.ToString().Trim()))
                {
                    ModelState.AddModelError("intEmpOfficeLevelId", "Office level is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intEmpDesignationId.ToString().Trim()))
                {
                    ModelState.AddModelError("intEmpDesignationId", "Employee designation is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intEmployeeId.ToString().Trim()))
                {
                    ModelState.AddModelError("intEmployeeId", "Employee is required");
                }

                if (string.IsNullOrEmpty(objmodel.intStep.ToString().Trim()))
                {
                    ModelState.AddModelError("intStep", "Step is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intPrimaryOfficeLevelId.ToString().Trim()))
                {
                    ModelState.AddModelError("intPrimaryOfficeLevelId", "Primary Office level is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intPrimaryDesignationId.ToString().Trim()))
                {
                    ModelState.AddModelError("intPrimaryDesignationId", "Primary designation is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intPrimaryAuthorityUserId.ToString().Trim()))
                {
                    ModelState.AddModelError("intPrimaryAuthorityUserId", "Primary authority is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intSecondaryOfficeLevelid.ToString().Trim()))
                {
                    ModelState.AddModelError("intSecondaryOfficeLevelid", "Secondary office level is required");
                }


                else if (string.IsNullOrEmpty(objmodel.intSecondaryDesignationId.ToString().Trim()))
                {
                    ModelState.AddModelError("intSecondaryDesignationId", "Secondary designation is required");
                }
                else if (string.IsNullOrEmpty(objmodel.intSecondaryAuthorityUserId.ToString().Trim()))
                {
                    ModelState.AddModelError("intSecondaryAuthorityUserId", "Secondary user id is required");
                }

                else if (ModelState.IsValid)
                {
                    //objmodel.intCreatedBy = 1;
                    objmodel.Check = 1;
                    objMessageEF = _LeaveManagementModel.AddUserWiseSetAuthority(objmodel);
                    if (objMessageEF.Satus == "2")
                    {
                        TempData["msg"] = "2";//---allready exists

                        return RedirectToAction("AddUserWiseSetAuthority", "LeaveManagement", new { Area = "LeaveManagement", id = Convert.ToString(objMessageEF.Id) });

                        //return RedirectToAction("AddUserWiseSetAuthority", "LeaveManagement", new { Area = "LeaveManagement", id = protector.Decode(Convert.ToString(objMessageEF.Id)) });
                    }

                    return RedirectToAction("AddUserWiseSetAuthority", "LeaveManagement", new { Area = "LeaveManagement", id = Convert.ToString(objMessageEF.Id) });

                }
                return RedirectToAction("AddUserWiseSetAuthority", "LeaveManagement", new { Area = "LeaveManagement", id = Convert.ToString(objMessageEF.Id) });

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

        /// <summary>
        /// remove authority setting from add more
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>

        [IgnoreAntiforgeryToken]
        [Decryption]
        public IActionResult RemoveUserWiseSetAuthoritychild(string id = "0")
        {
            MessageEF objMessageEF = new MessageEF();
            UserWiseSetAuthorityChild objmodel = new UserWiseSetAuthorityChild();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;

                int iId = Convert.ToInt32(id);
                objmodel.Check = 3;
                objmodel.intChildId = iId;
                //objmodel.intCreatedBy = 1;
                objMessageEF = _LeaveManagementModel.RemoveUserWiseSetAuthoritychild(objmodel);
                if (objMessageEF.Satus == "4")
                {
                    TempData["msg"] = "4";

                }
                else
                {
                    TempData["msg"] = "Error ! while deleting leave assign Details";
                }
                return RedirectToAction("AddUserWiseSetAuthority");

                //return RedirectToAction("AddUserWiseSetAuthority", "LeaveManagement", new { Area = "LeaveManagement", id = protector.Decode(Convert.ToString(objMessageEF.Id)) });

            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// view user wise set authority
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewUserWiseSetAuthority()
        {
            UserWiseSetAuthorityQuery objApplyLeave = new UserWiseSetAuthorityQuery();
            List<UserWiseSetAuthorityQuery> listAuthoritySetting = new List<UserWiseSetAuthorityQuery>();
            try
            {
                objApplyLeave.Check = 2;
                listAuthoritySetting = await _LeaveManagementModel.ViewUserWiseSetAuthority(objApplyLeave);
                return View(listAuthoritySetting);

            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Delete user wise set authority
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [IgnoreAntiforgeryToken]
        [Decryption]
        public IActionResult DeleteUserWiseSetAuthority(string id = "0")
        {
            MessageEF objMessageEF = new MessageEF();
            UserWiseSetAuthority objmodel = new UserWiseSetAuthority();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;

                int iId = Convert.ToInt32(id);
                objmodel.Check = 4;
                objmodel.intAuthorityId = iId;
                //objmodel.intCreatedBy = 1;
                objMessageEF = _LeaveManagementModel.DeleteUserWiseSetAuthoritySetting(objmodel);
                if (objMessageEF.Satus == "5")//--deleted sucessfully
                {
                    TempData["msg"] = "4";

                }
                else
                {
                    TempData["msg"] = "Error ! while deleting leave assign Details";
                }
                return RedirectToAction("ViewUserWiseSetAuthority");

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region ApplyLeave
        /// <summary>
        /// Apply leave
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Decryption]
        public async Task<IActionResult> AddApplyLeave(string id = "0")
        {
            ApplyLeave objmodel = new ApplyLeave();
          
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;

                LeaveDropDown objLeaveDropDown = new LeaveDropDown();
                ViewBag.Employee = Enumerable.Empty<SelectListItem>();
                ViewBag.LeaveType = Enumerable.Empty<SelectListItem>();

                ViewBag.FromHalfDay = Enumerable.Empty<SelectListItem>();
                ViewBag.ToHalfDay = Enumerable.Empty<SelectListItem>();
                //---for bind half day for from date
                List<SelectListItem> listFromHalfDay = new List<SelectListItem>();
                listFromHalfDay.Add(new SelectListItem { Value = "1", Text = "First Half" });
                listFromHalfDay.Add(new SelectListItem { Value = "2", Text = "Second Half" });
                ViewBag.FromHalfDay = listFromHalfDay;

                //----for bind half day for to date
                List<SelectListItem> listToHalfDay = new List<SelectListItem>();
                listToHalfDay.Add(new SelectListItem { Value = "1", Text = "First Half" });
                listToHalfDay.Add(new SelectListItem { Value = "2", Text = "Second Half" });
                ViewBag.ToHalfDay = listToHalfDay;


                //---Bind Employee

                objLeaveDropDown.Check = 2;
                objLeaveDropDown.Id = objmodel.intCreatedBy;
                var varEmployee = await _LeaveManagementModel.BindEmployee(objLeaveDropDown);

                ViewBag.Employee = varEmployee.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---Bind Leave Type
                objLeaveDropDown.Check = 1;
                var varLeaveType = await _LeaveManagementModel.BindLeaveType_ApplyLeave(objLeaveDropDown);

                ViewBag.LeaveType = varLeaveType.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //---for edit bind the details
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    int iId = Convert.ToInt32(id);
                    objmodel.Check = 4;
                    objmodel.intLeaveId = iId;
                    objmodel = await _LeaveManagementModel.ViewApplyLeaveDetails(objmodel);
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.Button = "Submit";
                    ModelState.Clear();
                    return View(objmodel);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// add/update apply leave
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddApplyLeave(ApplyLeave objmodel, string submit)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;

                //objmodel.intNoOfDaysApply = 10;
                if (string.IsNullOrEmpty(objmodel.intLeaveTypeId.ToString().Trim()))
                {
                    ModelState.AddModelError("intLeaveTypeId", "Leave type is required");
                }
                else if (string.IsNullOrEmpty(objmodel.dtFromDate.ToString().Trim()))
                {
                    ModelState.AddModelError("dtFromDate", "From date is required");
                }
                else if (string.IsNullOrEmpty(objmodel.dtToDate.ToString().Trim()))
                {
                    ModelState.AddModelError("dtToDate", "To date is required");
                }
                else if (string.IsNullOrEmpty(objmodel.varReason.ToString().Trim()))
                {
                    ModelState.AddModelError("varReason", "Reason is required");
                }
                else if (string.IsNullOrEmpty(objmodel.NoOfDays.ToString().Trim()))
                {
                    ModelState.AddModelError("NoOfDays", "No of days is required");
                }
                if (objmodel.intLeaveTypeId == 4)//1:Casual Leave,2:optional Leave,3:Medical Leave,4:Earned Leave
                {

                    if (string.IsNullOrEmpty(objmodel.varOffice.ToString().Trim()))
                    {
                        ModelState.AddModelError("varOffice", "Office is required");
                    }
                    else if (string.IsNullOrEmpty(objmodel.varSection.ToString().Trim()))
                    {
                        ModelState.AddModelError("varSection", "Section is required");
                    }
                    else if (string.IsNullOrEmpty(objmodel.varPay.ToString().Trim()))
                    {
                        ModelState.AddModelError("varPay", "Pay is required");
                    }
                    else if (string.IsNullOrEmpty(objmodel.varHouseAndRentAllowance.ToString().Trim()))
                    {
                        ModelState.AddModelError("varHouseAndRentAllowance", "House rent allowance is required");
                    }
                    else if (string.IsNullOrEmpty(objmodel.varSundayHoliday.ToString().Trim()))
                    {
                        ModelState.AddModelError("varSundayHoliday", "Sunday holiday is required");
                    }
                    else if (string.IsNullOrEmpty(objmodel.varProposedToAvail.ToString().Trim()))
                    {
                        ModelState.AddModelError("varProposedToAvail", "Proposed to avail is required");
                    }
                    else if (string.IsNullOrEmpty(objmodel.varChildName.ToString().Trim()))
                    {
                        ModelState.AddModelError("varChildName", "Child name is required");
                    }
                    else if (string.IsNullOrEmpty(objmodel.dtChildDOB.ToString().Trim()))
                    {
                        ModelState.AddModelError("dtChildDOB", "Child date of birth is required");
                    }
                    else if (string.IsNullOrEmpty(objmodel.bitPermissionRequired.ToString().Trim()))
                    {
                        ModelState.AddModelError("bitPermissionRequired", "Permission required is required");
                    }
                    else if (string.IsNullOrEmpty(objmodel.dtDateOfReturn.ToString().Trim()))
                    {
                        ModelState.AddModelError("dtDateOfReturn", "Date of return is required");
                    }
                }
                else if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        objmodel.Check = 1;
                        objMessageEF = _LeaveManagementModel.AddApplyLeave(objmodel);
                    }
                    else
                    {
                        objmodel.Check = 2;
                        objmodel.intLeaveId = objmodel.intLeaveId;
                        objMessageEF = _LeaveManagementModel.AddApplyLeave(objmodel);
                    }
                    if (objMessageEF.Satus == "1" && submit == "Submit")
                    {
                        TempData["msg"] = "1";//Apply Leave Saved Successfully
                        return RedirectToAction("ViewApplyLeave");

                    }
                    if (objMessageEF.Satus == "3" && submit == "Update")
                    {
                        TempData["msg"] = "3";//Apply Leave  Updated Sucessfully
                        return RedirectToAction("ViewApplyLeave");
                    }
                    else if (objMessageEF.Satus == "2")
                    {
                        TempData["msg"] = "2";//Apply Leave  Details allready exists

                    }
                    if (objMessageEF.Satus == "5")
                    {
                        TempData["msg"] = "5";//Leave allready approved
                        return RedirectToAction("ViewApplyLeave");
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving Apply Leave Details";

                    }

                }
                return RedirectToAction("AddApplyLeave");
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Bind LeaveCount Details
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> BindLeaveCount(int EmployeeId, int LeaveTypeId)
        {
            try
            {
                LeaveDetails objLeaveDropDown = new LeaveDetails();
                objLeaveDropDown.Check = 3;
                objLeaveDropDown.intEmployeeId = EmployeeId;
                objLeaveDropDown.intLeaveTypeId = LeaveTypeId;
                var varNextApprovedUserId1 = await _LeaveManagementModel.BindLeaveCount(objLeaveDropDown);
                return Json(varNextApprovedUserId1);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// View apply leave details
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewApplyLeave()
        {
            ApplyLeaveQuery objApplyLeave = new ApplyLeaveQuery();
            List<ApplyLeaveQuery> listAuthoritySetting = new List<ApplyLeaveQuery>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objApplyLeave.intCreatedBy = profile.UserId;
                objApplyLeave.Check = 4;
 objApplyLeave.intModuleId = 30;//--establishment
                objApplyLeave.intSubModuleId = 2;//----apply leave

                listAuthoritySetting = await _LeaveManagementModel.ViewApplyLeave(objApplyLeave);
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
        public IActionResult DeleteApplyLeave(string id = "0")
        {
            MessageEF objMessageEF = new MessageEF();
            ApplyLeave objmodel = new ApplyLeave();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;


                int iId = Convert.ToInt32(id);
                //objmodel.intCreatedBy = 1;
                objmodel.Check = 3;
                objmodel.intLeaveId = iId;
                objMessageEF = _LeaveManagementModel.DeleteApplyLeave(objmodel);
                if (objMessageEF.Satus == "4")
                {
                    TempData["msg"] = "4";//Leave deleted Successfully
                }
                if (objMessageEF.Satus == "5")
                {
                    TempData["msg"] = "5";//Leave allready approved
                }
                else
                {
                    TempData["msg"] = "Error ! while deleting leave Details";
                }
                return RedirectToAction("ViewApplyLeave");
            }
            catch (Exception)
            {

                throw;
            }

        }


        #endregion
        
        #region LeaveInbox

        /// <summary>
        /// leave inbox details
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LeaveInbox()
        {

            LeaveInboxQuery objApplyLeave = new LeaveInboxQuery();
            List<LeaveInboxQuery> listAuthoritySetting = new List<LeaveInboxQuery>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objApplyLeave.intCreatedBy = profile.UserId;

                objApplyLeave.Check = 1;
                //objApplyLeave.intCreatedBy = 3;
                listAuthoritySetting = await _LeaveManagementModel.ViewLeaveInbox(objApplyLeave);
                return View(listAuthoritySetting);

            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// leave take action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> LeaveTakeAction(string id = "0")
        {
            LeaveInboxDetails objInboxDetails = new LeaveInboxDetails();
            //LeaveDropDown objAction = new LeaveDropDown();
            WorkFlowDropDown objAction = new WorkFlowDropDown();
            try
            {
                ViewBag.ActionType = Enumerable.Empty<SelectListItem>();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objInboxDetails.intCreatedBy = profile.UserId;

                int iId = Convert.ToInt32(id);
                objInboxDetails.Check = 1;
                objInboxDetails.intLeaveId = iId;
                objInboxDetails = await _LeaveManagementModel.ViewLeaveInboxDetails(objInboxDetails);

                objAction.Check = 1;
                objAction.Id =  iId;
                objAction.Id2 = 30;//----Leave Module id
                objAction.Id3 = 2;//---apply leave submodule id
                var varACtionType = _LeaveManagementModel.BindActionType(objAction);
                //var varACtionType = _LeaveManagementModel.BindActionType(new WorkFlowDropDown() { Check = 3, Id = iId, Id2 = 30, Id3 = 2 });

                ViewBag.ActionType = varACtionType.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),
                }

                    ).ToList();

                return View(objInboxDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// take leave action approve/reject
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult LeaveTakeAction(LeaveInboxDetails objmodel)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;
                objmodel.Check = 1;
                objMessageEF = _LeaveManagementModel.TakeAction(objmodel);
                if (objMessageEF.Satus == "1")
                {
                    if (objmodel.intActionId == 1)
                    {
                        TempData["msg"] = "1";//forwaded Successfully

                    }
                    if (objmodel.intActionId == 2)
                    {
                        TempData["msg"] = "2";//Approved Successfully
                        //Notification objNotification = new Notification(new MailNotification());
                        //objNotification.SendNotification("9937218715", "Approved Successfully");


                    }
                    if (objmodel.intActionId == 3)
                    {
                        TempData["msg"] = "3";//rejected Successfully

                    }
                    return RedirectToAction("LeaveInbox");

                }
                else
                {
                    TempData["msg"] = "Error ! while Saving Leave Details";

                }


                return RedirectToAction("LeaveInbox");
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        /// View leave inbox details
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewLeaveInbox()
        {

            LeaveInboxQuery objApplyLeave = new LeaveInboxQuery();
            List<LeaveInboxQuery> listAuthoritySetting = new List<LeaveInboxQuery>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objApplyLeave.intCreatedBy = profile.UserId;

                objApplyLeave.Check = 2;
                listAuthoritySetting = await _LeaveManagementModel.ViewLeaveInbox(objApplyLeave);
                return View(listAuthoritySetting);

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }



}
