
// ***********************************************************************
//  Controller Name          : ReportController
//  Desciption               : Used to view helpdesk reports
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 18-mar-2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskEF;
using HelpdeskApp.Areas.Helpdesk.Models.Ticket;
using Microsoft.AspNetCore.Hosting;
using HelpdeskApp.Web;
using HelpdeskApp.ActionFilter;
//using System.Web.Mvc;

namespace HelpdeskApp.Areas.Helpdesk.Controllers
{
    [Area("Helpdesk")]
    public class ReportController : Controller
    {
        ITicketModel _objIticketmodel;
        MessageEF objobjmodel = new MessageEF();

        /// <summary>
        /// Added by suroj on 15-mar-2021 for dependency injection
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        public ReportController(ITicketModel objtickettypemastermodel, IHostingEnvironment hostingEnvironment)
        {
            _objIticketmodel = objtickettypemastermodel;
            this.hostingEnvironment = hostingEnvironment;
        }
        //Ended by suroj

        /// <summary>
        /// ADDED BY SUROJ ON 15-mar-2021 TO view helpdesk Modulewise Ticket Report 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ModuleWiseTicketReport(int? id)
        {
            RaiseTicket objRaise = new RaiseTicket();
            List<RaiseTicket> objTicket = new List<RaiseTicket>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objRaise.Userid = profile.UserId;
                objTicket = _objIticketmodel.getModuleWisedata(objRaise);
                ViewBag.ViewList = objTicket;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRaise = null;
                objTicket = null;
            }
            return View();

        }
        /// <summary>
        /// Added by suroj on 18-mar-2021 to view issue log summary report
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult IssueLogsummary()
        {
            IssueLogsummaryModel objRaise = new IssueLogsummaryModel();
            List<IssueLogsummaryModel> objTicket = new List<IssueLogsummaryModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                objRaise.Userid = profile.UserId;
                objTicket = _objIticketmodel.getIssueLogsummary(objRaise);
                ViewBag.viewlogdata = objTicket;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRaise = null;
                objTicket = null;
            }
            return View();
        }
        /// <summary>
        /// Added by Lingaraj on 25-mar-2022 to Search to issue log summary report
        /// </summary>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult IssueLogsummary(IssueLogsummaryModel objRaise,string fromdate, string todate)
        {
            List<IssueLogsummaryModel> objTicket = new List<IssueLogsummaryModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                objRaise.Userid = profile.UserId;
                objRaise.FromDate = fromdate;
                objRaise.ToDate = todate;
                objTicket = _objIticketmodel.getIssueLogsummary(objRaise);
                ViewBag.viewlogdata = objTicket;
                return View(objRaise);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRaise = null;
                objTicket = null;
            }          
        }
        /// <summary>
        /// Added by suroj 11-mar-2021 to view Locationwise Data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objRaise"></param>
        /// <returns></returns>
        public IActionResult DistrictWiseTicketReport(int? id, RaiseTicket objRaise)
        {
            List<RaiseTicket> objTicket = new List<RaiseTicket>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objRaise.Userid = profile.UserId;
                objTicket = _objIticketmodel.getDistrictWisedata(objRaise);
                ViewBag.viewdistrictdata = objTicket;
                if (objTicket.Count > 0)
                {
                    ViewBag.fromdate = objTicket[0].fromdate;
                    ViewBag.todate = objTicket[0].todate;
                }
            }
            catch(Exception ex)
            {

                throw ex;
            }
            finally
            {

                objTicket = null;
            }
            return View(objRaise);

        }
        /// <summary>
        /// Added by suroj on 21-mar-2021 to get Issue logsummary report
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <param name="IssueStatus"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Summary(int? id, string fromdate, string todate,string IssueStatus)
        {
            IssueLogsummaryModel objRaise = new IssueLogsummaryModel();
            List<IssueLogsummaryModel> objTicket = new List<IssueLogsummaryModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            //profile.UserId = 1;
            objRaise.Userid = Convert.ToInt16(profile.UserId);
            objRaise.FromDate = fromdate;
            objRaise.ToDate = todate;
            objRaise.IssueStatus = IssueStatus=null??"";
            objTicket = _objIticketmodel.getIssueLogsummary(objRaise);
            ViewBag.viewlogdata = objTicket;
           
            return RedirectToAction("Summary",new { FromDate= fromdate, ToDate=todate });
        }
        /// <summary>
        /// Added by suroj on 21-mar-2021 to get Issue ModulewiseTicket report
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Showdata(int? id, string fromdate, string todate)
        {
            RaiseTicket objRaise = new RaiseTicket();
            List<RaiseTicket> objTicket = new List<RaiseTicket>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objRaise.Userid = profile.UserId;
            objRaise.fromdate = fromdate;
            objRaise.todate = todate;
            objTicket = _objIticketmodel.getModuleWisedata(objRaise);
            ViewBag.ViewList = objTicket;
            return RedirectToAction("ModuleWiseTicketReport");
            
        }
        /// <summary>
        /// ADDED BY SUROJ ON 18-mar-2021 TO VIEW LOCATIONWISEDETAILS REPORT
        /// </summary>
        /// <param name="Did"></param>
        /// <param name="type"></param>
        /// <param name="Dname"></param>
        /// <param name="Fromdate"></param>
        /// <param name="Todate"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult LocationWiseDetailsReport(string Did, string type, string Dname, string Fromdate, string Todate)
        {
            RaiseTicket objRaise = new RaiseTicket();
            List<RaiseTicket> objTicket = new List<RaiseTicket>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objRaise.Userid = profile.UserId;
                objRaise.UserType = type;
                objRaise.fromdate = Fromdate;
                objRaise.todate = Todate;
                objRaise.DistrictID = Convert.ToInt32(Did);
                objTicket = _objIticketmodel.getDistrictWiseDetailsdata(objRaise);
                ViewBag.Locationdata = objTicket;
                if (objTicket.Count > 0)
                {
                    ViewBag.fromdate = objTicket[0].fromdate;
                    ViewBag.todate = objTicket[0].todate;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTicket = null;
            }
            return View(objRaise);

        }
        /// <summary>
        /// ADDED BY SUROJ ON 19-mar-2021 TO VIEW ISSUE REPORT
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objRaise"></param>
        /// <returns></returns>
        public IActionResult IssueReport(int? id, RaiseTicket objRaise)
        {
            List<RaiseTicket> objTicket = new List<RaiseTicket>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objRaise.Userid = profile.UserId;

                objTicket = _objIticketmodel.getdata(objRaise);
                ViewBag.viewissuereport = objTicket;
                if (objTicket.Count > 0)
                {
                    ViewBag.fromdate = objTicket[0].fromdate;
                    ViewBag.todate = objTicket[0].todate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTicket = null;
            }
            return View(objRaise);

        }
        /// <summary>
        /// ADDED BY SUROJ ON 18-mar-2021 TO VIEW LOCATIONWISEDETAILS REPORT
        /// </summary>
        /// <param name="Did"></param>
        /// <param name="type"></param>
        /// <param name="Dname"></param>
        /// <param name="Fromdate"></param>
        /// <param name="Todate"></param>
        /// <returns></returns>
        public IActionResult Summary(int? id, RaiseTicket objRaise)
        {
            return View(objRaise);
        }
        /// <summary>
        /// Added by suroj on 14-mar-2021 to show issue summary record 
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public JsonResult GetIssuesSummaryTables(string FromDate,string ToDate,string IssueStatus)
        {
            RaiseTicket objRaise = new RaiseTicket();           
            TotalIssueLogModel objmodel = new TotalIssueLogModel();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objRaise.Userid = profile.UserId;
                objRaise.fromdate = FromDate;
                objRaise.todate = ToDate;
                objRaise.IssueStatus = IssueStatus;
                objmodel = _objIticketmodel.GetIssuesSummaryTables(objRaise);
                #region For URL Encryption
                string SoftwareIssueLoggedEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "SoftwareIssuesLogged", Fromdate = FromDate, Todate = ToDate });
                string SoftwareIssuesTotalCallResolvedEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "SoftwareIssuesTotalCallResolved", Fromdate = FromDate, Todate = ToDate });
                string SoftwareCurrentOpenIssueEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "SoftwareCurrentOpenIssue", Fromdate = FromDate, Todate = ToDate });
                string HardwareIssuesEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "HardwareIssues", Fromdate = FromDate, Todate = ToDate });
                string HardwareTotalIssuesResolvedEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "HardwareTotalIssuesResolved", Fromdate = FromDate, Todate = ToDate });
                string HardwareCurrentOpenIssueEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "HardwareCurrentOpenIssue", Fromdate = FromDate, Todate = ToDate });
                string NetworkInternetConnectivityAtUserSideEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "NetworkInternetConnectivityAtUserSide", Fromdate = FromDate, Todate = ToDate });
                string NetworkServerDownEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "NetworkServerDown", Fromdate = FromDate, Todate = ToDate });
                string OtherIssuesEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "OtherIssues", Fromdate = FromDate, Todate = ToDate });
                string StatusSummaryInitiatedEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "StatusSummaryInitiated", Fromdate = FromDate, Todate = ToDate });
                string StatusSummaryFMSEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "StatusSummaryFMS", Fromdate = FromDate, Todate = ToDate });
                string StatusSummaryOSUEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "StatusSummaryOSU", Fromdate = FromDate, Todate = ToDate });
                string StatusSummaryClosedEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "StatusSummaryClosed", Fromdate = FromDate, Todate = ToDate });
                string StatusSummaryReopenEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "StatusSummaryReopen", Fromdate = FromDate, Todate = ToDate });
                string StatusSummaryTotalEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "StatusSummaryTotal", Fromdate = FromDate, Todate = ToDate });
                string TotalIssueReSolvedEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "TotalIssueReSolved", Fromdate = FromDate, Todate = ToDate });
                string TotalIssuePendingEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "TotalIssuePending", Fromdate = FromDate, Todate = ToDate });
                string LoggedEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "Logged", Fromdate = FromDate, Todate = ToDate });
                string Resolved_Issues_On_Same_DayEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "Resolved_Issues_On_Same_Day", Fromdate = FromDate, Todate = ToDate });
                string PreviousPendingIssueSolvedEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "PreviousPendingIssueSolved", Fromdate = FromDate, Todate = ToDate });
                string TodaysPendingIssueEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "TodaysPendingIssue", Fromdate = FromDate, Todate = ToDate });
                string PreviousPendingIssueEncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "LocationWiseDetailsReport", "Report", new { type = "PreviousPendingIssue", Fromdate = FromDate, Todate = ToDate });
                objmodel.SoftwareIssueLoggedEncryptUrl = SoftwareIssueLoggedEncryptUrl;
                objmodel.SoftwareIssuesTotalCallResolvedEncryptUrl = SoftwareIssuesTotalCallResolvedEncryptUrl;
                objmodel.SoftwareCurrentOpenIssueEncryptUrl = SoftwareCurrentOpenIssueEncryptUrl;
                objmodel.HardwareIssuesEncryptUrl = HardwareIssuesEncryptUrl;
                objmodel.HardwareTotalIssuesResolvedEncryptUrl = HardwareTotalIssuesResolvedEncryptUrl;
                objmodel.HardwareCurrentOpenIssueEncryptUrl = HardwareCurrentOpenIssueEncryptUrl;
                objmodel.NetworkInternetConnectivityAtUserSideEncryptUrl = NetworkInternetConnectivityAtUserSideEncryptUrl;
                objmodel.NetworkServerDownEncryptUrl = NetworkServerDownEncryptUrl;
                objmodel.OtherIssuesEncryptUrl = OtherIssuesEncryptUrl;
                objmodel.StatusSummaryInitiatedEncryptUrl = StatusSummaryInitiatedEncryptUrl;
                objmodel.StatusSummaryFMSEncryptUrl = StatusSummaryFMSEncryptUrl;
                objmodel.StatusSummaryOSUEncryptUrl = StatusSummaryOSUEncryptUrl;
                objmodel.StatusSummaryClosedEncryptUrl = StatusSummaryClosedEncryptUrl;
                objmodel.StatusSummaryReopenEncryptUrl = StatusSummaryReopenEncryptUrl;
                objmodel.StatusSummaryTotalEncryptUrl = StatusSummaryTotalEncryptUrl;
                objmodel.TotalIssueReSolvedEncryptUrl = TotalIssueReSolvedEncryptUrl;
                objmodel.TotalIssuePendingEncryptUrl = TotalIssuePendingEncryptUrl;
                objmodel.LoggedEncryptUrl = LoggedEncryptUrl;
                objmodel.Resolved_Issues_On_Same_DayEncryptUrl = Resolved_Issues_On_Same_DayEncryptUrl;
                objmodel.PreviousPendingIssueSolvedEncryptUrl = PreviousPendingIssueSolvedEncryptUrl;
                objmodel.TodaysPendingIssueEncryptUrl = TodaysPendingIssueEncryptUrl;
                objmodel.PreviousPendingIssueEncryptUrl = PreviousPendingIssueEncryptUrl;
                #endregion
                return Json(objmodel, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRaise = null;
                objmodel = null;
            }           
        }
        /// <summary>
        /// Added by Lingaraj on 25-mar-2022 To View Detail Report
        /// </summary>
        /// <param name="ItemId"></param>
        /// <param name="Days"></param>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult DetailReport(string ItemId, string Days, string FromDate, string ToDate)
        {
            RaiseTicket objRaise = new RaiseTicket();
            List<RaiseTicket> objTicket = new List<RaiseTicket>();
            try
            {
                ViewBag.ItemId = ItemId;
                ViewBag.Days = Days;
                if (!(string.IsNullOrEmpty(Convert.ToString(FromDate))))
                {
                    ViewBag.FromDate = FromDate;                   
                }
                if (!(string.IsNullOrEmpty(Convert.ToString(ToDate))))
                {
                    ViewBag.ToDate = ToDate;                   
                }
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objRaise.Userid = profile.UserId;
                objRaise.ItemID = Convert.ToInt32(ItemId);
                objRaise.DaysTimeTaken = Days;
                objRaise.fromdate = FromDate;
                objRaise.todate = ToDate;
                objTicket = _objIticketmodel.getDetaildata(objRaise);
                ViewBag.viewdetailreport = objTicket;
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                objRaise = null;
            }
            return View();
        }
    }
}
