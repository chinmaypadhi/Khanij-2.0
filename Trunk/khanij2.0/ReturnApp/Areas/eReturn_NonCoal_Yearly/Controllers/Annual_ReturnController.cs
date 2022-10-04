// ***********************************************************************
//  Controller Name          : Annual_Return
//  Desciption               : eReturn Yearly G1 Details 
//  Created By               : Debaraj Swain
//  Created On               : 01 July 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReturnEF;
using ReturnApp.Areas.eReturn_NonCoal.Models;
using Appkey;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ReturnApp.Areas.eReturn_NonCoal_Yearly.Models;
using ReturnApp.Web;
using Microsoft.AspNetCore.DataProtection;

namespace ReturnApp.Areas.eReturn_NonCoal_Yearly.Controllers
{
    [Area("eReturn_NonCoal_Yearly")]
    public class Annual_ReturnController : Controller
    {
        IeReturnNonCoalYearlyG1Model _objIeReturnNonCoalYearlyG1Model;
        int SessionUID = int.Parse(ConfigurationManager.MySettings["MySettings:SessionUID"]);
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        private readonly IDataProtectionProvider dataProtectionProvider;
        private readonly IDataProtector protector;
        public Annual_ReturnController(IeReturnNonCoalYearlyG1Model objIeReturnNonCoalYearlyG1Model, IHostingEnvironment hostingEnvironment, IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider)
        {
            _objIeReturnNonCoalYearlyG1Model = objIeReturnNonCoalYearlyG1Model;
            this.hostingEnvironment = hostingEnvironment;
            this.dataProtectionProvider = dataProtectionProvider;
            this.configuration = configuration;
            protector = dataProtectionProvider.CreateProtector(configuration.GetSection("Encryption").GetValue<string>("EncryptionKey"));
        }

        /// <summary>
        /// Get portion of Dashboard of G1
        /// </summary>
        /// <returns>View</returns>
        public IActionResult YearlyReturn()
        {
            if (TempData["result"] != null)
            {
                //Response.Write("<script>alert('" + TempData["result"].ToString() + "')</script>");
            }

            return View();
        }

        #region Part 1 H1
        /// <summary>
        /// Get Yearly Return Details
        /// </summary>
        /// <param name="Year"></param>
        /// <returns>Json String</returns>
        public JsonResult GetYearlyReturnDetails(string Year)
        {
            try
            {
               // List<YearlyReturnModel> List = new List<YearlyReturnModel>();
                MonthlyReturnModelNonCoal obj = new MonthlyReturnModelNonCoal();
                obj.Year = Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                obj.Uid =profile.UserId;
                //obj.Uid = 150;//150-Coal Yearly; //132-G2;//194-G1;
               var List = _objIeReturnNonCoalYearlyG1Model.GetYearlyReturnDetails(obj)
                    .Select(e =>
                     {
                         e.EncryptedId = protector.Protect(e.FinancialYear);
                         return e;
                     });
                return Json(List);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get portion of part1 of G1 
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns>View</returns>
        public ActionResult PartOneFormH1(string Financial_Year)
        {
            AnnualReturnH1ViewModel objViewModel = new AnnualReturnH1ViewModel();
            MonthlyReturnModelNonCoal obj = new MonthlyReturnModelNonCoal();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.Uid = profile.UserId;
            //obj.Uid = 194;
            objViewModel.objMineDetails = _objIeReturnNonCoalYearlyG1Model.GetLesseMineDeatils(obj); 
            TempData["F_Y"] = Financial_Year;
            Financial_Year = protector.Unprotect(Financial_Year);
            ViewBag.Year = Financial_Year; 
            TempData.Keep("F_Y");

            obj = new MonthlyReturnModelNonCoal();
            List<GetDDL> objddl = new List<GetDDL>();
            objddl = _objIeReturnNonCoalYearlyG1Model.GetAgencyOfMine(obj);
            if (objddl != null)
            {
                ViewBag.AgencyType = objddl.Select(c => new SelectListItem
                {
                    Text = c.Agency_Mine,
                    Value = c.Agency_Mine.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.AgencyType = Enumerable.Empty<SelectListItem>();
            }

            return View(objViewModel);
        }

        /// <summary>
        /// Get Mines Other Details
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="UserId"></param>
        /// <returns>Json Result</returns>
        public JsonResult GetMineOtherDetails(string Year, int? UserId)
        {
            AnnualReturnH1ViewModel objViewModel = new AnnualReturnH1ViewModel();
            MonthlyReturnModelNonCoal obj = new MonthlyReturnModelNonCoal();
            obj.Year = Year;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.Uid = profile.UserId;
            //obj.Uid = 194;  
            objViewModel = _objIeReturnNonCoalYearlyG1Model.GetMineOtherDetails(obj);
            return Json(objViewModel);

        }

        /// <summary>
        /// Get Portion of Particulars of Area
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="UserId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetParticularsofArea(string Year, int? UserId)
        {
            AnnualReturnH1ViewModel objViewModel = new AnnualReturnH1ViewModel();
            MonthlyReturnModelNonCoal obj = new MonthlyReturnModelNonCoal();
            obj.Year = Year;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.Uid = profile.UserId;
            //obj.Uid = 194; 
            objViewModel.objParticular = _objIeReturnNonCoalYearlyG1Model.GetParticularsofArea(obj);
            return Json(objViewModel);

        }

        /// <summary>
        /// Get Lease Area Details
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="UserId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetLeasearea(string Year, int? UserId)
        {
            AnnualReturnH1ViewModel objViewModel = new AnnualReturnH1ViewModel();
            MonthlyReturnModelNonCoal obj = new MonthlyReturnModelNonCoal();
            obj.Year = Year;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.Uid = profile.UserId;
            //obj.Uid = 194; 
            objViewModel.objLeaseArea = _objIeReturnNonCoalYearlyG1Model.GetLeasearea(obj);
            return Json(objViewModel);

        }

        /// <summary>
        /// Post portion of Part1 of G1
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult PartOneFormH1(AnnualReturnH1ViewModel objModel)
        {
            if (objModel.objOtherDetails.Flag1 == 1)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objMineDetails.UID = profile.UserId;
                //objModel.objMineDetails.UID = 194; 
                objMessage = _objIeReturnNonCoalYearlyG1Model.UpdateMineOtherDetails(objModel);
                TempData["result"] = objMessage.Msg;

            }
            else if (objModel.objOtherDetails.Flag1 == 2)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objMineDetails.UID = profile.UserId;
                //objModel.objMineDetails.UID = 194;
                objMessage = _objIeReturnNonCoalYearlyG1Model.AddMineOtherDetails(objModel);
                TempData["result"] = objMessage.Msg;
            }

            if (objModel.objParticular.Flag2 == 1)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objParticular.UID = profile.UserId;
                //objModel.objParticular.UID = 194;
                objModel.objParticular.Year = (string)TempData["F_Y"];
                objMessage = _objIeReturnNonCoalYearlyG1Model.UpdateParticularsofArea(objModel);
                if (objMessage.Msg == "")
                {
                    TempData["result"] = "Something went wrong";
                }
                else
                {
                    TempData["result"] = objMessage.Msg;
                }
            }
            else if (objModel.objParticular.Flag2 == 2)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objParticular.UID = profile.UserId;
                //objModel.objParticular.UID = 194;
                objModel.objParticular.Year = (string)TempData["F_Y"];
                objMessage = _objIeReturnNonCoalYearlyG1Model.AddParticularsofArea(objModel);
                TempData["result"] = objMessage.Msg;

            }

            if (objModel.objLeaseArea.Flag3 == 1)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objLeaseArea.UID = profile.UserId;
                //objModel.objLeaseArea.UID = 194;
                objMessage = _objIeReturnNonCoalYearlyG1Model.UpdateLeasearea(objModel);
                TempData["result"] = objMessage.Msg;
            }
            else if (objModel.objLeaseArea.Flag3 == 2)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objLeaseArea.UID = profile.UserId;
                //objModel.objLeaseArea.UID = 194;
                objMessage = _objIeReturnNonCoalYearlyG1Model.AddLeasearea(objModel);
                TempData["result"] = objMessage.Msg;

            }

            return RedirectToAction("PartOneFormH1", new { Financial_Year = TempData["F_Y"] });
        }
        #endregion

        #region Part 2 H1
        /// <summary>
        /// Get portion of part2 of G1
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns>View</returns>
        public ActionResult PartTwoFormH1(string Financial_Year)
        {
            //ViewBag.Year = Financial_Year;
            //TempData["F_Y"] = Financial_Year;
            TempData["F_Y"] = Financial_Year;
            Financial_Year = protector.Unprotect(Financial_Year);
            ViewBag.Year = Financial_Year;
            TempData.Keep("F_Y");
            return View();
        }

        /// <summary>
        /// Get staff and work details
        /// </summary>
        /// <param name="Year"></param>
        /// <returns>Json String</returns>
        public JsonResult GetStaffandWork(string Year)
        {
            try
            {
                StaffandWorkModel List = new StaffandWorkModel();
                MonthlyReturnModelNonCoal obj = new MonthlyReturnModelNonCoal();
                obj.Year = Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                obj.Uid = profile.UserId;
                //obj.Uid = 194;
                List = _objIeReturnNonCoalYearlyG1Model.GetStaffandWork(obj);
                return Json(List);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Salary Wages PAid
        /// </summary>
        /// <param name="Year"></param>
        /// <returns>Json String</returns>
        public JsonResult GetSalaryWagesPaid(string Year)
        {
            try
            {
                SalaryWagesPaidModel List = new SalaryWagesPaidModel();
                MonthlyReturnModelNonCoal obj = new MonthlyReturnModelNonCoal();
                obj.Year = Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                obj.Uid = profile.UserId;
                //obj.Uid =194;
                List = _objIeReturnNonCoalYearlyG1Model.GetSalaryWagesPaid(obj);
                return Json(List);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Capital Structure
        /// </summary>
        /// <param name="Year"></param>
        /// <returns>Json String</returns>
        public JsonResult GetCapitalStructure(string Year)
        {
            try
            {
                CapitalStructure List = new CapitalStructure();
                MonthlyReturnModelNonCoal obj = new MonthlyReturnModelNonCoal();
                obj.Year = Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                obj.Uid = profile.UserId;
                //obj.Uid =194;
                List = _objIeReturnNonCoalYearlyG1Model.GetCapitalStructure(obj);
                return Json(List);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get source of finance
        /// </summary>
        /// <param name="Year"></param>
        /// <returns>Json String</returns>
        public JsonResult GetSourceOfFinance(string Year)
        {
            try
            {
                SourceOfFinance List = new SourceOfFinance();
                MonthlyReturnModelNonCoal obj = new MonthlyReturnModelNonCoal();
                obj.Year = Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                obj.Uid = profile.UserId;
                //obj.Uid =194;
                List = _objIeReturnNonCoalYearlyG1Model.GetSourceOfFinance(obj);
                return Json(List);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get work details
        /// </summary>
        /// <param name="Year"></param>
        /// <returns>Json String</returns>
        public JsonResult GetWorkDetails(string Year)
        {
            try
            {
                WorkModel List = new WorkModel();
                MonthlyReturnModelNonCoal obj = new MonthlyReturnModelNonCoal();
                obj.Year = Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                obj.Uid = profile.UserId;
                //obj.Uid =194;
                List = _objIeReturnNonCoalYearlyG1Model.GetWorkDetails(obj);
                return Json(List);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Post portion od part2 of G1
        /// </summary>
        /// <param name="objModel"></param>
        /// <param name="Work_Id"></param>
        /// <param name="Reason"></param>
        /// <param name="NoOfDaysMineStop"></param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult PartTwoFormH1(AnnualReturnH1PartTwoModel objModel, List<int?> Work_Id, List<string> Reason, List<int?> NoOfDaysMineStop)
        {
            if (objModel.objStaffWork.Flag1 == 1)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objStaffWork.UID = profile.UserId;
                //objModel.objStaffWork.UID = 194;
                objMessage = _objIeReturnNonCoalYearlyG1Model.UpdateStaffandWork(objModel);
                TempData["result"] = objMessage.Msg;

            }
            else if (objModel.objStaffWork.Flag1 == 2)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objStaffWork.UID = profile.UserId;
                //objModel.objStaffWork.UID = 194;
                objMessage = _objIeReturnNonCoalYearlyG1Model.AddStaffandWork(objModel);
                TempData["result"] = objMessage.Msg;

            }
            if (objModel.objWork.Flag == 1)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objWork.UID = profile.UserId;
                //objModel.objWork.UID = 194;
                objModel.objWork.Work_Id = Work_Id;
                objModel.objWork.Reason = Reason;
                objModel.objWork.NoOfDaysMineStop = NoOfDaysMineStop;
                objMessage = _objIeReturnNonCoalYearlyG1Model.UpdateWorkDetails(objModel);
                TempData["result"] = objMessage.Msg;

            }
            else if (objModel.objWork.Flag == 2)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objWork.UID = profile.UserId;
                //objModel.objWork.UID = 194;
                objModel.objWork.Work_Id = Work_Id;
                objModel.objWork.Reason = Reason;
                objModel.objWork.NoOfDaysMineStop = NoOfDaysMineStop;
                objMessage = _objIeReturnNonCoalYearlyG1Model.AddWorkDetails(objModel);
                TempData["result"] = objMessage.Msg;

            }


            if (objModel.objSalaryWages.Flag2 == 1)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objSalaryWages.UID = profile.UserId;
                //objModel.objSalaryWages.UID = 194;
                objMessage = _objIeReturnNonCoalYearlyG1Model.UpdateSalaryWagesPaid(objModel);

            }
            else if (objModel.objSalaryWages.Flag2 == 2)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objSalaryWages.UID = profile.UserId;
                //objModel.objSalaryWages.UID = 194;
                objMessage = _objIeReturnNonCoalYearlyG1Model.AddSalaryWagesPaid(objModel);
                TempData["result"] = objMessage.Msg;

            }

            if (objModel.objCapitalStructure.Flag3 == 1)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objCapitalStructure.UID = profile.UserId;
                //objModel.objCapitalStructure.UID = 194;
                objMessage = _objIeReturnNonCoalYearlyG1Model.UpdateCapitalStructure(objModel);
                TempData["result"] = objMessage.Msg;

            }
            else if (objModel.objCapitalStructure.Flag3 == 2)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objCapitalStructure.UID = profile.UserId;
                //objModel.objCapitalStructure.UID = 194;
                objMessage = _objIeReturnNonCoalYearlyG1Model.AddCapitalStructure(objModel);
                TempData["result"] = objMessage.Msg;

            }
            if (objModel.objSource.Flag4 == 1)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objSource.UID = profile.UserId;
                //objModel.objSource.UID = 194;
                objMessage = _objIeReturnNonCoalYearlyG1Model.UpdateSourceOfFinance(objModel);
                TempData["result"] = objMessage.Msg;

            }
            else if (objModel.objSource.Flag4 == 2)
            {
                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.objSource.UID = profile.UserId;
                //objModel.objSource.UID = 194;
                objMessage = _objIeReturnNonCoalYearlyG1Model.AddSourceOfFinance(objModel);
                TempData["result"] = objMessage.Msg;

            }

            return RedirectToAction("PartTwoFormH1", new { Financial_Year = TempData["F_Y"] });
        }
        #endregion
    }
}
