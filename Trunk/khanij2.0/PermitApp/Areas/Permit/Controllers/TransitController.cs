// ***********************************************************************
//  Controller Name          : Transit
//  Desciption               : Liecensee Apply New Permit,Generate permit,Close permit,Show Permit List 
//  Created By               : Sanjay Kumar
//  Created On               : 23 June 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermitApp.Areas.Permit.Models.Transit;
using PermitEF;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using PermitApp.Helper;
using PermitApp.Web;
using PermitApp.Models.MailService;
using PermitApp.Models.SMSService;
using PermitApp.ActionFilter;

namespace PermitApp.Areas.Permit.Controllers
{
    [Area("Permit")]
    public class TransitController : Controller
    {
        ITransitPermitModel _userPemit;
        MessageEF objMSmodel = new MessageEF();
        public object JsonRequestBehavior { get; private set; }
        IHostingEnvironment _hostingEnvironment;
        string OutputResult = "";
        // string UserType = "Licensee";//it will comes from session variable
        private readonly IConfiguration Configuration;
        LicenseFinalApproval LicenseFinalApproval = new LicenseFinalApproval();
        LesseeFinalApproval LesseeFinalApproval = new LesseeFinalApproval();
        private readonly IMailModel mailModel;
        private readonly ISMSModel sMSModel;
        public TransitController(ITransitPermitModel objPermit, IHostingEnvironment hostingEnvironment, IConfiguration _configuration)
        {
            _userPemit = objPermit;
            _hostingEnvironment = hostingEnvironment;
            Configuration = _configuration;
        }
        /// <summary>
        /// To Bind the Licensee RTP Permit Details Data in View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ApplyForwardingNote(int? ForwardingNoteId = 0)
        {
            ForwardingNoteModel objmodel = new ForwardingNoteModel();
            ForwardingNoteModel model = new ForwardingNoteModel();
            List<ForwardingNoteModel> GrantOrderList = new List<ForwardingNoteModel>();
            List<ForwardingNoteModel> ForwardingNoteList = new List<ForwardingNoteModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
             objmodel.UserID = Convert.ToInt32(profile.UserId);
            string UserType = profile.UserType;
            //objmodel.UserID = 95;
            //string UserType = "Lessee";

            objmodel.ForwardingNoteId = ForwardingNoteId;
            var x = _userPemit.GetBulkPermitForwarding(objmodel);
            if (x.PermitLst != null)
            {
                ViewBag.PermitNumberLst = x.PermitLst.Select(c => new SelectListItem
                {
                    Text = c.BulkPermitNumber,
                    Value = c.BulkPermitId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.PermitNumberLst = Enumerable.Empty<SelectListItem>();
            }
            var y = _userPemit.GetRailwaySiding(objmodel);
            if (y.RailwaySidingLst != null)
            {
                ViewBag.RailSidingLst = y.RailwaySidingLst.Select(c => new SelectListItem
                {
                    Text = c.RailwaySlidingName,
                    Value = c.RailwayId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.RailSidingLst = Enumerable.Empty<SelectListItem>();
            }
            var z = _userPemit.GetRailwaySidingDestination(objmodel);
            if (z.RailwaySidingDestinationLst != null)
            {
                ViewBag.RailDestSidingLst = z.RailwaySidingDestinationLst.Select(c => new SelectListItem
                {
                    Text = c.DestinationRailwaySiding,
                    Value = c.DestinationRailwayId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.RailDestSidingLst = Enumerable.Empty<SelectListItem>();
            }
            //if (string.IsNullOrEmpty(objmodel.BulkPermitId))
            //{
            //    ModelState.AddModelError("GrantOrderNumber", "Grant Order Number is required");
            //}
            if (ModelState.IsValid)
            {
                if (UserType == "Licensee") 
                {
                    GrantOrderList = _userPemit.GetGrantOrderExpiry(objmodel);
                    if (GrantOrderList != null && GrantOrderList.Count > 0 && (Convert.ToString(GrantOrderList[0].GrantOrderDateExpired) == "0"))
                    {
                        ForwardingNoteList = _userPemit.GetForwardingNoteView(objmodel);
                        for (var i = 0; i < ForwardingNoteList.Count; i++)
                        {
                            model.ForwardingNoteId = Convert.ToInt32(ForwardingNoteList[i].ForwardingNoteId);
                            model.ForwardingNoteNumber = Convert.ToString(ForwardingNoteList[i].ForwardingNote);
                            model.BulkPermitId = Convert.ToInt32(ForwardingNoteList[i].BulkPermitId);
                            model.BulkPermitNumber = Convert.ToString(ForwardingNoteList[i].BulkPermitNo);
                            model.RailwayId = Convert.ToInt32(ForwardingNoteList[i].RailwayId);
                            model.RailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                            model.DateofSubmitedRTPRequest = Convert.ToDateTime(ForwardingNoteList[i].CreatedOn);
                            model.MineralName = Convert.ToString(ForwardingNoteList[i].MineralName);
                            model.MineralId = Convert.ToInt32(ForwardingNoteList[i].MineralID);
                            model.MineralGrade = Convert.ToString(ForwardingNoteList[i].MineralGrade);
                            model.MineralGradeId = Convert.ToInt32(ForwardingNoteList[i].MineralGradeId);
                            model.MineralNatureId = Convert.ToInt32(ForwardingNoteList[i].MineralNatureId);
                            model.MineralNature = Convert.ToString(ForwardingNoteList[i].MineralNature);
                            model.EndUserId = Convert.ToInt32(ForwardingNoteList[i].EndUserId);
                            model.EndUser = Convert.ToString(ForwardingNoteList[i].EndUserName);
                            model.ReqQty = Convert.ToDecimal(ForwardingNoteList[i].ReqQty);
                            model.Status = Convert.ToInt32(ForwardingNoteList[i].Status);
                            model.GrantOrderDate = Convert.ToString(ForwardingNoteList[i].DateOfGrant);
                            model.GrantOrderNo = Convert.ToString(ForwardingNoteList[i].GrantOrderNo);
                            model.LeaseFrom = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseFrom);
                            model.LeaseTo = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseTo);
                            model.LicenseeId = Convert.ToInt32(ForwardingNoteList[i].LicenseeId);

                            model.Consigner = Convert.ToString(ForwardingNoteList[i].Name);
                            model.Address = Convert.ToString(ForwardingNoteList[i].Address);
                            model.TelephoneNo = Convert.ToString(ForwardingNoteList[i].ContactNumber);
                            model.UnitName = Convert.ToString(ForwardingNoteList[i].UnitName);
                            // model.UnitId = Convert.ToInt32(ForwardingNoteList[i].UnitId);

                            model.AddressofConsignee = Convert.ToString(ForwardingNoteList[i].AddressofConsignee);
                            model.NoofRTP = Convert.ToInt32(ForwardingNoteList[i].NoofRTP);
                            model.ForwardingTransacationId = Convert.ToString(ForwardingNoteList[i].ForwardingTransacationId);
                            model.isForwarded = Convert.ToInt32(ForwardingNoteList[i].isForwarded);
                            model.StockQty = Convert.ToDecimal(ForwardingNoteList[i].PendingQty);

                            model.LeaseValidity = Convert.ToString(ForwardingNoteList[i].LeaseValidity);

                            model.District = Convert.ToString(ForwardingNoteList[i].DistrictName);
                            model.GeneratedDesignation = Convert.ToString(ForwardingNoteList[i].GeneratedDesignation);
                            model.GeneratedBy = Convert.ToString(ForwardingNoteList[i].GeneratedBy);

                            model.EDRMNumber = Convert.ToString(ForwardingNoteList[i].EDRMNumber);
                            model.EDRMDate = Convert.ToString(ForwardingNoteList[i].EDRMDate);
                            model.EDRMQty = Convert.ToDecimal(ForwardingNoteList[i].EDRMQty);

                            if (string.IsNullOrEmpty(ForwardingNoteList[i].AddressofRailwaySliding.ToString()))
                                model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                            else
                                model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName) + " ( " + Convert.ToString(ForwardingNoteList[i].AddressofRailwaySliding) + " ) ";
                            model.DestinationRailwaySiding = Convert.ToString(ForwardingNoteList[i].DestinationRailwaySiding);

                            if (ForwardingNoteList[i].EDRMCopyPath.ToString() == "")
                            {

                                //@System.Configuration.ConfigurationManager.AppSettings["ServerPath
                                model.EDRMCopyPath = "";
                            }
                            else
                            {
                                model.EDRMCopyPath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(ForwardingNoteList[i].EDRMCopyPath);
                            }

                            if (ForwardingNoteList[i].DSCLesseeFilePath.ToString() == "")
                            {

                                //@System.Configuration.ConfigurationManager.AppSettings["ServerPath
                                model.DSCLesseeFilePath = "";
                            }
                            else
                            {
                                model.DSCLesseeFilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(ForwardingNoteList[i].DSCLesseeFilePath);
                            }

                            if (model.Status == 0)
                            {
                                model.Request_Status = "Pending";
                            }
                            else if (model.Status == 1)
                            {
                                model.Request_Status = "Approved";
                            }
                            else if (model.Status == 2)
                            {
                                model.Request_Status = "Rejected";
                            }
                            else if (model.Status == 3)
                            {
                                model.Request_Status = "RTP Reqested";
                            }
                        }
                        if (ForwardingNoteId > 0)
                        {
                            ViewBag.StockQty = model.StockQty;
                            return View(model);
                        }
                        else
                        {
                            //var model = objRepository.GetForwardingNoteView(ForwardingNoteId);

                            return View(model);
                        }
                    }
                    else
                    {
                        return RedirectToAction("ValidityExpired", "LicenseeValidityExpired", new { Area = "Licensee" });
                    }
                }
                else
                {
                    ForwardingNoteList = _userPemit.GetForwardingNoteView(objmodel);
                    for (var i = 0; i < ForwardingNoteList.Count; i++)
                    {
                        model.ForwardingNoteId = Convert.ToInt32(ForwardingNoteList[i].ForwardingNoteId);
                        model.ForwardingNoteNumber = Convert.ToString(ForwardingNoteList[i].ForwardingNote);
                        model.BulkPermitId = Convert.ToInt32(ForwardingNoteList[i].BulkPermitId);
                        model.BulkPermitNumber = Convert.ToString(ForwardingNoteList[i].BulkPermitNo);
                        model.RailwayId = Convert.ToInt32(ForwardingNoteList[i].RailwayId);
                        model.RailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                        model.DateofSubmitedRTPRequest = Convert.ToDateTime(ForwardingNoteList[i].CreatedOn);
                        model.MineralName = Convert.ToString(ForwardingNoteList[i].MineralName);
                        model.MineralId = Convert.ToInt32(ForwardingNoteList[i].MineralID);
                        model.MineralGrade = Convert.ToString(ForwardingNoteList[i].MineralGrade);
                        model.MineralGradeId = Convert.ToInt32(ForwardingNoteList[i].MineralGradeId);
                        model.MineralNatureId = Convert.ToInt32(ForwardingNoteList[i].MineralNatureId);
                        model.MineralNature = Convert.ToString(ForwardingNoteList[i].MineralNature);
                        model.EndUserId = Convert.ToInt32(ForwardingNoteList[i].EndUserId);
                        model.EndUser = Convert.ToString(ForwardingNoteList[i].EndUserName);
                        model.ReqQty = Convert.ToDecimal(ForwardingNoteList[i].ReqQty);
                        model.Status = Convert.ToInt32(ForwardingNoteList[i].Status);
                        model.GrantOrderDate = Convert.ToString(ForwardingNoteList[i].DateOfGrant);
                        model.GrantOrderNo = Convert.ToString(ForwardingNoteList[i].GrantOrderNo);
                        model.LeaseFrom = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseFrom);
                        model.LeaseTo = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseTo);
                        model.LicenseeId = Convert.ToInt32(ForwardingNoteList[i].LicenseeId);

                        model.Consigner = Convert.ToString(ForwardingNoteList[i].Name);
                        model.Address = Convert.ToString(ForwardingNoteList[i].Address);
                        model.TelephoneNo = Convert.ToString(ForwardingNoteList[i].ContactNumber);
                        model.UnitName = Convert.ToString(ForwardingNoteList[i].UnitName);
                        // model.UnitId = Convert.ToInt32(ForwardingNoteList[i].UnitId);

                        model.AddressofConsignee = Convert.ToString(ForwardingNoteList[i].AddressofConsignee);
                        model.NoofRTP = Convert.ToInt32(ForwardingNoteList[i].NoofRTP);
                        model.ForwardingTransacationId = Convert.ToString(ForwardingNoteList[i].ForwardingTransacationId);
                        model.isForwarded = Convert.ToInt32(ForwardingNoteList[i].isForwarded);
                        model.StockQty = Convert.ToDecimal(ForwardingNoteList[i].PendingQty);

                        model.LeaseValidity = Convert.ToString(ForwardingNoteList[i].LeaseValidity);

                        model.District = Convert.ToString(ForwardingNoteList[i].DistrictName);
                        model.GeneratedDesignation = Convert.ToString(ForwardingNoteList[i].GeneratedDesignation);
                        model.GeneratedBy = Convert.ToString(ForwardingNoteList[i].GeneratedBy);

                        model.EDRMNumber = Convert.ToString(ForwardingNoteList[i].EDRMNumber);
                        model.EDRMDate = Convert.ToString(ForwardingNoteList[i].EDRMDate);
                        model.EDRMQty = Convert.ToDecimal(ForwardingNoteList[i].EDRMQty);

                        if (string.IsNullOrEmpty(ForwardingNoteList[i].AddressofRailwaySliding.ToString()))
                            model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                        else
                            model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName) + " ( " + Convert.ToString(ForwardingNoteList[i].AddressofRailwaySliding) + " ) ";
                        model.DestinationRailwaySiding = Convert.ToString(ForwardingNoteList[i].DestinationRailwaySiding);

                        if (ForwardingNoteList[i].EDRMCopyPath.ToString() == "")
                        {

                            //@System.Configuration.ConfigurationManager.AppSettings["ServerPath
                            model.EDRMCopyPath = "";
                        }
                        else
                        {
                            model.EDRMCopyPath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(ForwardingNoteList[i].EDRMCopyPath);
                        }

                        if (ForwardingNoteList[i].DSCLesseeFilePath.ToString() == "")
                        {

                            //@System.Configuration.ConfigurationManager.AppSettings["ServerPath
                            model.DSCLesseeFilePath = "";
                        }
                        else
                        {
                            model.DSCLesseeFilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(ForwardingNoteList[i].DSCLesseeFilePath);
                        }

                        if (model.Status == 0)
                        {
                            model.Request_Status = "Pending";
                        }
                        else if (model.Status == 1)
                        {
                            model.Request_Status = "Approved";
                        }
                        else if (model.Status == 2)
                        {
                            model.Request_Status = "Rejected";
                        }
                        else if (model.Status == 3)
                        {
                            model.Request_Status = "RTP Reqested";
                        }
                    }
                    if (ForwardingNoteId > 0)
                    {
                        //var model = objRepository.GetForwardingNoteView(ForwardingNoteId);
                        ViewBag.StockQty = model.StockQty;
                        return View(model);
                    }
                    else
                    {
                        // var model = objRepository.GetForwardingNoteView(ForwardingNoteId);
                        return View(model);
                    }
                }
            }
            return View(model);
        }
        /// <summary>
        /// Save and edit of Licensee RTP Permit Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ApplyForwardingNote(ForwardingNoteModel model, string cmdPreview, List<IFormFile> flEDRMCopy)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.UserType = profile.UserType;
            
            model.SubUserID = Convert.ToInt32(profile.SubUserID);
            model.UserLoginId = Convert.ToInt32(profile.UserLoginId);
            List<ForwardingNoteModel> ForwardingNoteList = new List<ForwardingNoteModel>();
            eTransitResult GrantOrderList = new eTransitResult();
            try
            {
                var previewRequest = Convert.ToString(cmdPreview);
                if (previewRequest != null)
                {
                    // return View("ForwardingNotePreview", model);
                    return RedirectToAction("ForwardingNotePreview", "ForwardingNote", new { ForwardingNoteId = model.ForwardingNoteId });
                }
                else
                {

                    //using (SqlCommand cmd = new SqlCommand())
                    //{
                    GrantOrderList = _userPemit.getFNPreviewData(model);
                    if (GrantOrderList != null)
                    {

                        if (GrantOrderList.PermitPreviewLst != null)
                        {
                            foreach (var app1 in GrantOrderList.PermitPreviewLst)
                            {
                                model.BulkPermitNumber = Convert.ToString(app1.BulkPermitNo);
                                model.MineralId = Convert.ToInt32(app1.MineralId);
                                model.MineralName = Convert.ToString(app1.MineralName);
                                model.MineralGradeId = Convert.ToInt32(app1.MineralGradeId);
                                model.MineralGrade = Convert.ToString(app1.MineralGrade);
                            }
                        }

                        if (GrantOrderList.RailwaySidingLst != null)
                        {
                            foreach (var app2 in GrantOrderList.RailwaySidingLst)
                            {
                                model.RailwaySliding = Convert.ToString(app2.RailwaySlidingName);
                            }
                        }
                        if (GrantOrderList.EndUserPreviewLst != null)
                        {
                            foreach (var app3 in GrantOrderList.EndUserPreviewLst)
                            {
                                model.EndUser = Convert.ToString(app3.EndUserName);
                            }
                        }
                        //}
                        // }
                    }
                    //  }
                }

                if (ModelState.IsValid)
                {
                    long size = flEDRMCopy.Sum(f => f.Length);
                    var filePaths = new List<string>();
                    foreach (var formFile in flEDRMCopy)
                    {
                        if (formFile != null && formFile.Length > 0)
                        {
                            //foreach (var file in UploadFile)
                            //{
                            if (!string.IsNullOrEmpty(formFile.FileName))
                            {
                                string strName = string.Format(@"EDRM_{0}", DateTime.Now.Ticks) + "_" + Path.GetFileName(formFile.FileName);
                                //string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/UploadEDRMCopy/",  formFile.FileName);
                                var fileName = strName;

                                // DataRow dr = dt.NewRow();
                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    formFile.CopyTo(stream);
                                }
                                model.EDRMCopyPath = fileName;

                                //FilePathList.Add(path);
                                //dr["FileName"] = fileName;
                                //dr["FilePath"] = path;
                                //dt.Rows.Add(dr);
                                //dt.AcceptChanges();

                                ////dt.Rows.Add(fileName, objmodel.AttatchmentPath);

                                //FileCount += 1;
                            }
                            else
                            {
                                ModelState.Clear();
                                return View();
                            }

                            // }
                        }
                    }
                    //if (TempData["EDRM_PATH"] != null)
                    //{
                    //    model.EDRMCopyPath = TempData["EDRM_PATH"].ToString();
                    //}
                    Int32 RTPID = 0;
                    objMSmodel = _userPemit.AddRTPApplication(model);
                    OutputResult = objMSmodel.Satus;
                    RTPID = Convert.ToInt32(objMSmodel.Msg);
                    if (OutputResult == "1")
                    {
                        TempData["SuccMessage"] = "Your Request Regarding Forwarding-Note been Proceed Successfully.";
                        TempData.Keep();
                        return RedirectToAction("ApplyForwardingNote", "Transit");

                    }
                    else if (OutputResult.Contains("FN"))
                    {
                        var fnId = OutputResult.Replace("FN", "").ToString();
                        model.ForwardingNoteId = Convert.ToInt32(fnId);
                        TempData["FNID"] = Convert.ToInt32(fnId);
                        TempData["LeaseValidity"] = model.LeaseFrom + "-" + model.LeaseTo;
                        ForwardingNoteList = _userPemit.GetForwadingTransactionNo(model);
                        for (var i = 0; i < ForwardingNoteList.Count; i++)
                        {
                            model.ForwardingTransacationId = ForwardingNoteList[i].FORWARDINGTRANSACATIONID;
                        }
                        // return RedirectToAction("ForwardingNotePreview", "ForwardingNote", new { ForwardingNoteId = Convert.ToInt32(fnId) });

                        return RedirectToAction("RTPPermitApplication", "Transit", new { ForwardingNoteId = Convert.ToInt32(fnId) });

                    }
                    else
                    {
                        if (RTPID > 0)
                        {
                            TempData["FNID"] = RTPID;
                            TempData["LeaseValidity"] = model.LeaseFrom + "-" + model.LeaseTo;
                            model.ForwardingNoteId = Convert.ToInt32(RTPID);
                            ForwardingNoteList = _userPemit.GetForwadingTransactionNo(model);
                            for (var i = 0; i < ForwardingNoteList.Count; i++)
                            {
                                model.ForwardingTransacationId = ForwardingNoteList[i].FORWARDINGTRANSACATIONID;
                            }
                            // return RedirectToAction("ForwardingNotePreview", "ForwardingNote", new { ForwardingNoteId = Convert.ToInt32(fnId) });

                            return RedirectToAction("RTPPermitApplication", "Transit", new { ForwardingNoteId = Convert.ToInt32(RTPID) });
                        }
                        else
                        {
                            TempData["SuccMessage"] = "Your Request Regarding Forwarding-Note been not Proceed.";
                            TempData.Keep();
                            return View(model);
                        }
                    }
                }
                else
                {
                    OutputResult = "3";
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                return View(model);
            }

        }
        /// <summary>
        /// Bind the Purchaser consignee dropdown on bulk permit number change
        /// </summary>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        public JsonResult GetPurchaseConsignee(int BulkPermitId)
        {
            ForwardingNoteModel objPermit = null;
            try
            {
                objPermit = new ForwardingNoteModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objPermit.UserID = Convert.ToInt32(profile.UserId);
               // objPermit.UserID = 95;
                objPermit.BulkPermitId = BulkPermitId;
                var x = _userPemit.GetConsigerListForwardingNote(objPermit);
                var SList = x.PurchaseConsigneeLst.ToList();
                return Json(SList);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objPermit = null;
            }

        }
        /// <summary>
        /// Bind the adress of Purchaser confignee
        /// </summary>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        public JsonResult GetConsigneeAddress(int EndUserId, int BulkPermitId)
        {
            ForwardingNoteModel objPermit = null;
            try
            {
                objPermit = new ForwardingNoteModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objPermit.UserID = Convert.ToInt32(profile.UserId);
                objPermit.BulkPermitId = BulkPermitId;
                var x = _userPemit.GetConsigerListForwardingNote(objPermit);
                var Address = x.PurchaseConsigneeLst.Where(d => d.PurchaserConsigneeId == EndUserId);
                var SList = Address.ToList();
                return Json(SList);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objPermit = null;
            }

        }
        /// <summary>
        /// Get all Available data
        /// </summary>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        public JsonResult GetAvailableData(int BulkPermitId)
        {
            List<ForwardingNoteModel> ForwardingNoteList = new List<ForwardingNoteModel>();
            ForwardingNoteModel objmodel = new ForwardingNoteModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.BulkPermitId = BulkPermitId;
            try
            {
                ForwardingNoteList = _userPemit.GetAvailableData(objmodel);

                var SList = ForwardingNoteList.ToList();
                return Json(SList);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                ForwardingNoteList = null;
            }

        }
        /// <summary>
        /// Bind the Stock of selected permit
        /// </summary>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        public JsonResult GetStockDetails(int BulkPermitId)
        {
            ForwardingNoteModel objPermit = null;
            try
            {
                objPermit = new ForwardingNoteModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objPermit.UserID = Convert.ToInt32(profile.UserId);
                objPermit.BulkPermitId = BulkPermitId;
                var x = _userPemit.GetBulkPermitForwarding(objPermit);
                var stock = x.PermitLst.Where(d => d.BulkPermitId == BulkPermitId);

                var SList = stock.ToList();
                return Json(SList);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objPermit = null;
            }

        }
        /// <summary>
        /// To bind details of permit application 
        /// </summary>
        /// <param name="ForwardingNoteId"></param>
        /// <returns></returns>
        /// 
        [SkipImportantTask]
        public IActionResult RTPPermitApplication(string ForwardingNoteId)
        {
            ForwardingNoteModel objmodel = new ForwardingNoteModel();
            ForwardingNoteModel model = new ForwardingNoteModel();
            List<ForwardingNoteModel> GrantOrderList = new List<ForwardingNoteModel>();
            List<ForwardingNoteModel> ForwardingNoteList = new List<ForwardingNoteModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            string UserType = profile.UserType;
            //objmodel.UserID = 83;
            objmodel.ForwardingNoteId =Convert.ToInt16(ForwardingNoteId);
            //string UserType = "Lessee";
            if (ModelState.IsValid)
            {
                ForwardingNoteList = _userPemit.GetForwardingNoteView(objmodel);
                for (var i = 0; i < ForwardingNoteList.Count; i++)
                {
                    model.ForwardingNoteId = Convert.ToInt32(ForwardingNoteList[i].ForwardingNoteId);
                    model.ForwardingNoteNumber = Convert.ToString(ForwardingNoteList[i].ForwardingNote);
                    model.BulkPermitId = Convert.ToInt32(ForwardingNoteList[i].BulkPermitId);
                    model.BulkPermitNumber = Convert.ToString(ForwardingNoteList[i].BulkPermitNo);
                    model.RailwayId = Convert.ToInt32(ForwardingNoteList[i].RailwayId);
                    model.RailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                    model.DateofSubmitedRTPRequest = Convert.ToDateTime(ForwardingNoteList[i].CreatedOn);
                    model.MineralName = Convert.ToString(ForwardingNoteList[i].MineralName);
                    model.MineralId = Convert.ToInt32(ForwardingNoteList[i].MineralID);
                    model.MineralGrade = Convert.ToString(ForwardingNoteList[i].MineralGrade);
                    model.MineralGradeId = Convert.ToInt32(ForwardingNoteList[i].MineralGradeId);
                    model.MineralNatureId = Convert.ToInt32(ForwardingNoteList[i].MineralNatureId);
                    model.MineralNature = Convert.ToString(ForwardingNoteList[i].MineralNature);
                    model.EndUserId = Convert.ToInt32(ForwardingNoteList[i].EndUserId);
                    model.EndUser = Convert.ToString(ForwardingNoteList[i].EndUserName);
                    model.ReqQty = Convert.ToDecimal(ForwardingNoteList[i].ReqQty);
                    model.Status = Convert.ToInt32(ForwardingNoteList[i].Status);
                    model.GrantOrderDate = Convert.ToString(ForwardingNoteList[i].DateOfGrant);
                    model.GrantOrderNo = Convert.ToString(ForwardingNoteList[i].GrantOrderNo);
                    model.LeaseFrom = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseFrom);
                    model.LeaseTo = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseTo);
                    model.LicenseeId = Convert.ToInt32(ForwardingNoteList[i].LicenseeId);

                    model.Consigner = Convert.ToString(ForwardingNoteList[i].Name);
                    model.Address = Convert.ToString(ForwardingNoteList[i].Address);
                    model.TelephoneNo = Convert.ToString(ForwardingNoteList[i].ContactNumber);
                    model.UnitName = Convert.ToString(ForwardingNoteList[i].UnitName);
                    // model.UnitId = Convert.ToInt32(ForwardingNoteList[i].UnitId);

                    model.AddressofConsignee = Convert.ToString(ForwardingNoteList[i].AddressofConsignee);
                    model.NoofRTP = Convert.ToInt32(ForwardingNoteList[i].NoofRTP);
                    model.ForwardingTransacationId = Convert.ToString(ForwardingNoteList[i].ForwardingTransacationId);
                    model.isForwarded = Convert.ToInt32(ForwardingNoteList[i].isForwarded);
                    model.StockQty = Convert.ToDecimal(ForwardingNoteList[i].PendingQty);

                    model.LeaseValidity = Convert.ToString(ForwardingNoteList[i].LeaseValidity);

                    model.District = Convert.ToString(ForwardingNoteList[i].DistrictName);
                    model.GeneratedDesignation = Convert.ToString(ForwardingNoteList[i].GeneratedDesignation);
                    model.GeneratedBy = Convert.ToString(ForwardingNoteList[i].GeneratedBy);

                    model.EDRMNumber = Convert.ToString(ForwardingNoteList[i].EDRMNumber);
                    model.EDRMDate = Convert.ToString(ForwardingNoteList[i].EDRMDate);
                    model.EDRMQty = Convert.ToDecimal(ForwardingNoteList[i].EDRMQty);

                    if (string.IsNullOrEmpty(ForwardingNoteList[i].AddressofRailwaySliding))
                        model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                    else
                        model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName) + " ( " + Convert.ToString(ForwardingNoteList[i].AddressofRailwaySliding) + " ) ";
                    model.DestinationRailwaySiding = Convert.ToString(ForwardingNoteList[i].DestinationRailwaySiding);

                    if (ForwardingNoteList[i].EDRMCopyPath == "")
                    {

                        //@System.Configuration.ConfigurationManager.AppSettings["ServerPath
                        model.EDRMCopyPath = "";
                    }
                    else
                    {
                        model.EDRMCopyPath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(ForwardingNoteList[i].EDRMCopyPath);
                    }

                    if (ForwardingNoteList[i].DSCLesseeFilePath == "")
                    {

                        //@System.Configuration.ConfigurationManager.AppSettings["ServerPath
                        model.DSCLesseeFilePath = "";
                    }
                    else
                    {
                        model.DSCLesseeFilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(ForwardingNoteList[i].DSCLesseeFilePath);
                    }

                    if (model.Status == 0)
                    {
                        model.Request_Status = "Pending";
                    }
                    else if (model.Status == 1)
                    {
                        model.Request_Status = "Approved";
                    }
                    else if (model.Status == 2)
                    {
                        model.Request_Status = "Rejected";
                    }
                    else if (model.Status == 3)
                    {
                        model.Request_Status = "RTP Reqested";
                    }
                }
                if (Convert.ToInt32(ForwardingNoteId) > 0)
                {
                    ViewBag.StockQty = model.StockQty;
                    return View(model);
                }
                else
                {
                    //var model = objRepository.GetForwardingNoteView(ForwardingNoteId);

                    return View(model);
                }
                //if (UserType == "Licensee")
                //{
                //    GrantOrderList = _userPemit.GetGrantOrderExpiry(objmodel);
                //    if (GrantOrderList != null && GrantOrderList.Count > 0 && (Convert.ToString(GrantOrderList[0].GrantOrderDateExpired) == "0"))
                //    {
                //        ForwardingNoteList = _userPemit.GetForwardingNoteView(objmodel);
                //        for (var i = 0; i < ForwardingNoteList.Count; i++)
                //        {
                //            model.ForwardingNoteId = Convert.ToInt32(ForwardingNoteList[i].ForwardingNoteId);
                //            model.ForwardingNoteNumber = Convert.ToString(ForwardingNoteList[i].ForwardingNote);
                //            model.BulkPermitId = Convert.ToInt32(ForwardingNoteList[i].BulkPermitId);
                //            model.BulkPermitNumber = Convert.ToString(ForwardingNoteList[i].BulkPermitNo);
                //            model.RailwayId = Convert.ToInt32(ForwardingNoteList[i].RailwayId);
                //            model.RailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                //            model.DateofSubmitedRTPRequest = Convert.ToDateTime(ForwardingNoteList[i].CreatedOn);
                //            model.MineralName = Convert.ToString(ForwardingNoteList[i].MineralName);
                //            model.MineralId = Convert.ToInt32(ForwardingNoteList[i].MineralID);
                //            model.MineralGrade = Convert.ToString(ForwardingNoteList[i].MineralGrade);
                //            model.MineralGradeId = Convert.ToInt32(ForwardingNoteList[i].MineralGradeId);
                //            model.MineralNatureId = Convert.ToInt32(ForwardingNoteList[i].MineralNatureId);
                //            model.MineralNature = Convert.ToString(ForwardingNoteList[i].MineralNature);
                //            model.EndUserId = Convert.ToInt32(ForwardingNoteList[i].EndUserId);
                //            model.EndUser = Convert.ToString(ForwardingNoteList[i].EndUserName);
                //            model.ReqQty = Convert.ToDecimal(ForwardingNoteList[i].ReqQty);
                //            model.Status = Convert.ToInt32(ForwardingNoteList[i].Status);
                //            model.GrantOrderDate = Convert.ToString(ForwardingNoteList[i].DateOfGrant);
                //            model.GrantOrderNo = Convert.ToString(ForwardingNoteList[i].GrantOrderNo);
                //            model.LeaseFrom = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseFrom);
                //            model.LeaseTo = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseTo);
                //            model.LicenseeId = Convert.ToInt32(ForwardingNoteList[i].LicenseeId);

                //            model.Consigner = Convert.ToString(ForwardingNoteList[i].Name);
                //            model.Address = Convert.ToString(ForwardingNoteList[i].Address);
                //            model.TelephoneNo = Convert.ToString(ForwardingNoteList[i].ContactNumber);
                //            model.UnitName = Convert.ToString(ForwardingNoteList[i].UnitName);
                //            // model.UnitId = Convert.ToInt32(ForwardingNoteList[i].UnitId);

                //            model.AddressofConsignee = Convert.ToString(ForwardingNoteList[i].AddressofConsignee);
                //            model.NoofRTP = Convert.ToInt32(ForwardingNoteList[i].NoofRTP);
                //            model.ForwardingTransacationId = Convert.ToString(ForwardingNoteList[i].ForwardingTransacationId);
                //            model.isForwarded = Convert.ToInt32(ForwardingNoteList[i].isForwarded);
                //            model.StockQty = Convert.ToDecimal(ForwardingNoteList[i].PendingQty);

                //            model.LeaseValidity = Convert.ToString(ForwardingNoteList[i].LeaseValidity);

                //            model.District = Convert.ToString(ForwardingNoteList[i].DistrictName);
                //            model.GeneratedDesignation = Convert.ToString(ForwardingNoteList[i].GeneratedDesignation);
                //            model.GeneratedBy = Convert.ToString(ForwardingNoteList[i].GeneratedBy);

                //            model.EDRMNumber = Convert.ToString(ForwardingNoteList[i].EDRMNumber);
                //            model.EDRMDate = Convert.ToString(ForwardingNoteList[i].EDRMDate);
                //            model.EDRMQty = Convert.ToDecimal(ForwardingNoteList[i].EDRMQty);

                //            if (string.IsNullOrEmpty(ForwardingNoteList[i].AddressofRailwaySliding.ToString()))
                //                model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                //            else
                //                model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName) + " ( " + Convert.ToString(ForwardingNoteList[i].AddressofRailwaySliding) + " ) ";
                //            model.DestinationRailwaySiding = Convert.ToString(ForwardingNoteList[i].DestinationRailwaySiding);

                //            if (ForwardingNoteList[i].EDRMCopyPath.ToString() == "")
                //            {

                //                //@System.Configuration.ConfigurationManager.AppSettings["ServerPath
                //                model.EDRMCopyPath = "";
                //            }
                //            else
                //            {
                //                model.EDRMCopyPath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(ForwardingNoteList[i].EDRMCopyPath);
                //            }

                //            if (ForwardingNoteList[i].DSCLesseeFilePath.ToString() == "")
                //            {

                //                //@System.Configuration.ConfigurationManager.AppSettings["ServerPath
                //                model.DSCLesseeFilePath = "";
                //            }
                //            else
                //            {
                //                model.DSCLesseeFilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(ForwardingNoteList[i].DSCLesseeFilePath);
                //            }

                //            if (model.Status == 0)
                //            {
                //                model.Request_Status = "Pending";
                //            }
                //            else if (model.Status == 1)
                //            {
                //                model.Request_Status = "Approved";
                //            }
                //            else if (model.Status == 2)
                //            {
                //                model.Request_Status = "Rejected";
                //            }
                //            else if (model.Status == 3)
                //            {
                //                model.Request_Status = "RTP Reqested";
                //            }
                //        }
                //        if (ForwardingNoteId > 0)
                //        {
                //            ViewBag.StockQty = model.StockQty;
                //            return View(model);
                //        }
                //        else
                //        {
                //            //var model = objRepository.GetForwardingNoteView(ForwardingNoteId);

                //            return View(model);
                //        }
                //    }
                //    else
                //    {
                //        return RedirectToAction("ValidityExpired", "LicenseeValidityExpired", new { Area = "Licensee" });
                //    }
                //}
                //else
                //{
                //    for (var i = 0; i < ForwardingNoteList.Count; i++)
                //    {
                //        model.ForwardingNoteId = Convert.ToInt32(ForwardingNoteList[i].ForwardingNoteId);
                //        model.ForwardingNoteNumber = Convert.ToString(ForwardingNoteList[i].ForwardingNote);
                //        model.BulkPermitId = Convert.ToInt32(ForwardingNoteList[i].BulkPermitId);
                //        model.BulkPermitNumber = Convert.ToString(ForwardingNoteList[i].BulkPermitNo);
                //        model.RailwayId = Convert.ToInt32(ForwardingNoteList[i].RailwayId);
                //        model.RailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                //        model.DateofSubmitedRTPRequest = Convert.ToDateTime(ForwardingNoteList[i].CreatedOn);
                //        model.MineralName = Convert.ToString(ForwardingNoteList[i].MineralName);
                //        model.MineralId = Convert.ToInt32(ForwardingNoteList[i].MineralID);
                //        model.MineralGrade = Convert.ToString(ForwardingNoteList[i].MineralGrade);
                //        model.MineralGradeId = Convert.ToInt32(ForwardingNoteList[i].MineralGradeId);
                //        model.MineralNatureId = Convert.ToInt32(ForwardingNoteList[i].MineralNatureId);
                //        model.MineralNature = Convert.ToString(ForwardingNoteList[i].MineralNature);
                //        model.EndUserId = Convert.ToInt32(ForwardingNoteList[i].EndUserId);
                //        model.EndUser = Convert.ToString(ForwardingNoteList[i].EndUserName);
                //        model.ReqQty = Convert.ToDecimal(ForwardingNoteList[i].ReqQty);
                //        model.Status = Convert.ToInt32(ForwardingNoteList[i].Status);
                //        model.GrantOrderDate = Convert.ToString(ForwardingNoteList[i].DateOfGrant);
                //        model.GrantOrderNo = Convert.ToString(ForwardingNoteList[i].GrantOrderNo);
                //        model.LeaseFrom = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseFrom);
                //        model.LeaseTo = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseTo);
                //        model.LicenseeId = Convert.ToInt32(ForwardingNoteList[i].LicenseeId);

                //        model.Consigner = Convert.ToString(ForwardingNoteList[i].Name);
                //        model.Address = Convert.ToString(ForwardingNoteList[i].Address);
                //        model.TelephoneNo = Convert.ToString(ForwardingNoteList[i].ContactNumber);
                //        model.UnitName = Convert.ToString(ForwardingNoteList[i].UnitName);
                //        // model.UnitId = Convert.ToInt32(ForwardingNoteList[i].UnitId);

                //        model.AddressofConsignee = Convert.ToString(ForwardingNoteList[i].AddressofConsignee);
                //        model.NoofRTP = Convert.ToInt32(ForwardingNoteList[i].NoofRTP);
                //        model.ForwardingTransacationId = Convert.ToString(ForwardingNoteList[i].ForwardingTransacationId);
                //        model.isForwarded = Convert.ToInt32(ForwardingNoteList[i].isForwarded);
                //        model.StockQty = Convert.ToDecimal(ForwardingNoteList[i].PendingQty);

                //        model.LeaseValidity = Convert.ToString(ForwardingNoteList[i].LeaseValidity);

                //        model.District = Convert.ToString(ForwardingNoteList[i].DistrictName);
                //        model.GeneratedDesignation = Convert.ToString(ForwardingNoteList[i].GeneratedDesignation);
                //        model.GeneratedBy = Convert.ToString(ForwardingNoteList[i].GeneratedBy);

                //        model.EDRMNumber = Convert.ToString(ForwardingNoteList[i].EDRMNumber);
                //        model.EDRMDate = Convert.ToString(ForwardingNoteList[i].EDRMDate);
                //        model.EDRMQty = Convert.ToDecimal(ForwardingNoteList[i].EDRMQty);

                //        if (string.IsNullOrEmpty(ForwardingNoteList[i].AddressofRailwaySliding.ToString()))
                //            model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                //        else
                //            model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName) + " ( " + Convert.ToString(ForwardingNoteList[i].AddressofRailwaySliding) + " ) ";
                //        model.DestinationRailwaySiding = Convert.ToString(ForwardingNoteList[i].DestinationRailwaySiding);

                //        if (ForwardingNoteList[i].EDRMCopyPath.ToString() == "")
                //        {

                //            //@System.Configuration.ConfigurationManager.AppSettings["ServerPath
                //            model.EDRMCopyPath = "";
                //        }
                //        else
                //        {
                //            model.EDRMCopyPath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(ForwardingNoteList[i].EDRMCopyPath);
                //        }

                //        if (ForwardingNoteList[i].DSCLesseeFilePath.ToString() == "")
                //        {

                //            //@System.Configuration.ConfigurationManager.AppSettings["ServerPath
                //            model.DSCLesseeFilePath = "";
                //        }
                //        else
                //        {
                //            model.DSCLesseeFilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(ForwardingNoteList[i].DSCLesseeFilePath);
                //        }

                //        if (model.Status == 0)
                //        {
                //            model.Request_Status = "Pending";
                //        }
                //        else if (model.Status == 1)
                //        {
                //            model.Request_Status = "Approved";
                //        }
                //        else if (model.Status == 2)
                //        {
                //            model.Request_Status = "Rejected";
                //        }
                //        else if (model.Status == 3)
                //        {
                //            model.Request_Status = "RTP Reqested";
                //        }
                //    }
                //    if (ForwardingNoteId > 0)
                //    {
                //        //var model = objRepository.GetForwardingNoteView(ForwardingNoteId);
                //        ViewBag.StockQty = model.StockQty;
                //        return View(model);
                //    }
                //    else
                //    {
                //        // var model = objRepository.GetForwardingNoteView(ForwardingNoteId);
                //        return View(model);
                //    }
                //}
            }
            return View(model);
        }
        /// <summary>
        /// To display the list after apply RTP permit
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult FinalForwadingNote(ForwardingNoteModel objmodel)
        {
            List<ForwardingNoteModel> modelList = new List<ForwardingNoteModel>();
            List<ForwardingNoteModel> List = new List<ForwardingNoteModel>();
            ForwardingNoteModel model = new ForwardingNoteModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            string UserType = profile.UserType;
            //objmodel.UserID = 83;
            //string UserType = "Lessee";
            objmodel.Status = 3;

            modelList = _userPemit.GetDGDMOFN(objmodel);
            if (modelList != null && modelList.Count > 0)
            {
                int sn = 1;
                for (var i = 0; i < modelList.Count; i++)
                {
                    model = new ForwardingNoteModel();
                    model.SRNO = sn;
                    model.ForwardingNoteId = Convert.ToInt32(modelList[i].ForwardingNoteId);
                    model.ForwardingTransacationId = Convert.ToString(modelList[i].ForwardingTransacationId);
                    model.ForwardingNoteNumber = Convert.ToString(modelList[i].ForwardingNote);
                    model.BulkPermitId = Convert.ToInt32(modelList[i].BulkPermitId);
                    model.BulkPermitNumber = Convert.ToString(modelList[i].BulkPermitNo);
                    model.RailwayId = Convert.ToInt32(modelList[i].RailwayId);
                    model.RailwaySliding = Convert.ToString(modelList[i].RailwaySlidingName);
                    model.DateofSubmitedRTPRequest = Convert.ToDateTime(modelList[i].CreatedOn);
                    model.MineralName = Convert.ToString(modelList[i].MineralName);
                    model.MineralId = Convert.ToInt32(modelList[i].MineralID);
                    model.MineralGrade = Convert.ToString(modelList[i].MineralGrade);
                    model.MineralGradeId = Convert.ToInt32(modelList[i].MineralGradeId);
                    model.MineralNature = Convert.ToString(modelList[i].MineralNature);
                    model.MineralNatureId = Convert.ToInt32(modelList[i].MineralNatureId);
                    model.EndUserId = Convert.ToInt32(modelList[i].EndUserId);
                    model.EndUser = Convert.ToString(modelList[i].EndUserName);
                    model.ReqQty = Convert.ToDecimal(modelList[i].ReqQty);
                    model.ApprovedQty = !string.IsNullOrEmpty(modelList[i].ApprovedQty.ToString()) ? Convert.ToDecimal(modelList[i].ApprovedQty) : 0;
                    model.Status = Convert.ToInt32(modelList[i].Status);
                    model.GrantOrderDate = Convert.ToString(modelList[i].DateOfGrant);
                    model.GrantOrderNo = Convert.ToString(modelList[i].GrantOrderNo);
                    model.LeaseFrom = Convert.ToString(modelList[i].PeriodOfLeaseFrom);
                    model.LeaseTo = Convert.ToString(modelList[i].PeriodOfLeaseTo);
                    model.LicenseeId = Convert.ToInt32(modelList[i].LicenseeId);
                    model.Consigner = Convert.ToString(modelList[i].Name);
                    model.Address = Convert.ToString(modelList[i].Address);
                    model.TelephoneNo = Convert.ToString(modelList[i].ContactNumber);
                    model.UnitName = Convert.ToString(modelList[i].UnitName);
                    model.UnitId = Convert.ToInt32(modelList[i].UnitId);
                    model.Remarks = Convert.ToString(modelList[i].Remark);

                    model.NoofRTP = Convert.ToInt32(modelList[i].NoofRTP);


                    if (!string.IsNullOrEmpty(modelList[i].ApprovedQty.ToString()) && !string.IsNullOrEmpty(modelList[i].ReqQty.ToString()))
                    {
                        if (Convert.ToDecimal(modelList[i].ReqQty.ToString()) - Convert.ToDecimal(modelList[i].ApprovedQty.ToString()) == 0)
                        {
                            model.isLable = 0;
                        }
                        else
                        {
                            model.isLable = 1;
                            model.DiffDisplay = Convert.ToDecimal(modelList[i].ReqQty.ToString()) - (Convert.ToDecimal(modelList[i].ReqQty.ToString()) - Convert.ToDecimal(modelList[i].ApprovedQty.ToString()));
                        }


                    }
                    model.ViewUserType = UserType;

                    model.PendingQty = Convert.ToDecimal(modelList[i].PendingQty);
                    model.TransportationMode = Convert.ToString(modelList[i].TransportationMode);

                    if (!string.IsNullOrEmpty(modelList[i].IndividualtakenRTP.ToString()) && Convert.ToDecimal(modelList[i].IndividualtakenRTP) > 0)
                    {
                        model.TotalDispatchedQty = Convert.ToDecimal(modelList[i].IndividualtakenRTP);
                        model.BalanceQty = Convert.ToDecimal(modelList[i].RTPAppliedQty);
                    }
                    else
                    {
                        if (model.TransportationMode.ToUpper() == "INSIDE RAILWAY SIDING")
                        {
                            model.TotalDispatchedQty = Convert.ToDecimal(modelList[i].DispatchedQty);
                            model.BalanceQty = Convert.ToDecimal(modelList[i].RTPAppliedQty);
                        }
                        else
                        {
                            model.TotalDispatchedQty = Convert.ToDecimal(modelList[i].DispatchedQty);
                            model.BalanceQty = Convert.ToDecimal(modelList[i].RTPAppliedQty);
                        }
                    }

                    //if (modelList.Contains("RTPPassNo"))
                    //{
                    model.RTPPassNo = Convert.ToString(modelList[i].RTPPassNo);
                    //  }

                    //if (data.Columns.Contains("DispatchStatus"))
                    //{
                    model.DispatchedQty = Convert.ToDecimal(modelList[i].DispatchStatus);
                    //  }

                    if (model.Status == 1)
                    {
                        model.Request_Status = "Pending For Forwarding";
                    }
                    else if (model.Status == 2)
                    {
                        if (UserType.ToUpper() != "LESSEE" && UserType.ToUpper() != "Licensee")
                        {
                            model.Request_Status = "New Forwarding Note";
                        }
                        else
                        {
                            model.Request_Status = "Forward To DD/DMO";
                        }
                    }
                    else if (model.Status == 3)
                    {
                        //model.Request_Status = "Accepted";
                        model.Request_Status = "Approved";
                    }
                    else if (model.Status == 4)
                    {
                        model.Request_Status = "Rejected";
                    }
                    else if (model.Status == 5)
                    {
                        model.Request_Status = "RTP Reqested";
                    }
                    else if (model.Status == 6)
                    {
                        model.Request_Status = "Accepted";
                    }


                    model.CloseTripStatus = Convert.ToInt32(modelList[i].CloseTripStatus);
                    model.GenerateRTPStatus = Convert.ToInt32(modelList[i].GenerateRTPStatus);
                    model.CloseRTPStatus = Convert.ToInt32(modelList[i].CloseRTPStatus);
                    model.TripStatus = Convert.ToInt32(modelList[i].TripStatus);

                    model.EDRMNumber = Convert.ToString(modelList[i].EDRMNumber);
                    model.EDRMDate = Convert.ToString(modelList[i].EDRMDate);

                    if (modelList[i].EDRMCopyPath.ToString() != "" && modelList[i].EDRMCopyPath.ToString() != null)
                    {
                        model.EDRMCopyPath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(modelList[i].EDRMCopyPath);
                    }
                    List.Add(model);
                    sn++;
                }
            }
            ViewBag.ViewList = List;
            return View();
        }
        /// <summary>
        /// Get and bind the details of closing permit
        /// </summary>
        /// <param name="ForwardingNoteId"></param>
        /// <returns></returns>
        public ActionResult CloseRTPPassList(int ForwardingNoteId = 0)
        {
            List<ForwardingNoteModel> modelList = new List<ForwardingNoteModel>();
            List<ForwardingNoteModel> List = new List<ForwardingNoteModel>();
            ForwardingNoteModel objmodel = new ForwardingNoteModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            //objmodel.UserID = 83;
            objmodel.ForwardingNoteId = ForwardingNoteId;
            TempData["ForwardingNoteId"] = ForwardingNoteId;
            ViewBag.ForwardingNoteId = ForwardingNoteId;
            modelList = _userPemit.GetCloseRTPPassDetailsList(objmodel);
            if (modelList != null && modelList.Count > 0)
            {
                int sn = 1;
                for (var i = 0; i < modelList.Count; i++)
                {
                    ForwardingNoteModel model = new ForwardingNoteModel();
                    model.SRNO = sn;
                    model.ForwardingNoteId = ForwardingNoteId;
                    model.RoyaltyPaidTransitPassId = Convert.ToInt32(modelList[i].RoyaltyPaidTransitPassId);
                    model.ForwardingNoteNumber = modelList[i].ForwardingNote.ToString();
                    model.BulkPermitNumber = modelList[i].BulkPermitNo.ToString();
                    model.PassNo = modelList[i].PassNo.ToString();
                    model.DateOfDispatch = modelList[i].DateOfDispatche.ToString();
                    model.MineralName = modelList[i].MineralName.ToString();
                    model.StockQty = Convert.ToDecimal(modelList[i].IssuedQty);
                    model.UnitName = modelList[i].UnitName.ToString();
                    model.EndUserId = Convert.ToInt32(modelList[i].PurchaserId);
                    model.EndUser = modelList[i].Purchaser.ToString();
                    model.Address = modelList[i].PurchaserAddress.ToString();
                    List.Add(model);
                    sn++;
                }
            }
            ViewBag.ViewList = List;
            return View();
        }
        /// <summary>
        /// Closing permit
        /// </summary>
        /// <param name="ForwardingNoteID"></param>
        /// <param name="RTPId"></param>
        /// <param name="RTPQty"></param>
        /// <param name="RTPDate"></param>
        /// <returns></returns>
        public string CloseRTPTripForForwardingNote(int? ForwardingNoteID, int? RTPId, string RTPQty, string RTPDate, List<IFormFile> UploadFile)
        {
            ForwardingNoteModel model = new ForwardingNoteModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.UserType = profile.UserType;
           
            model.ForwardingNoteId = ForwardingNoteID;
            model.RTP_Id = RTPId;
            model.ReqQty = Convert.ToDecimal(RTPQty);
            model.Date_OfExecution = DateTime.Parse(RTPDate);

            List<ForwardingNoteModel> ForwardingNoteList = new List<ForwardingNoteModel>();
            try
            {
                long size = UploadFile.Sum(f => f.Length);
                var filePaths = new List<string>();
                foreach (var formFile in UploadFile)
                {
                    if (formFile != null && formFile.Length > 0)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(formFile.FileName))
                        {
                            string strName = string.Format(@"EDRM_{0}", DateTime.Now.Ticks) + "_" + Path.GetFileName(formFile.FileName);
                            //string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/UploadEDRMCopy/", formFile.FileName);
                            var fileName = strName;

                            // DataRow dr = dt.NewRow();
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                formFile.CopyTo(stream);
                            }
                            model.EDRMCopyPath = path;
                            model.FileName = strName;

                            //FilePathList.Add(path);
                            //dr["FileName"] = fileName;
                            //dr["FilePath"] = path;
                            //dt.Rows.Add(dr);
                            //dt.AcceptChanges();

                            ////dt.Rows.Add(fileName, objmodel.AttatchmentPath);

                            //FileCount += 1;
                        }
                        else
                        {
                            ModelState.Clear();
                        }

                        // }
                    }
                }

                objMSmodel = _userPemit.CloseRTPTripFor(model);
                if (objMSmodel != null && !string.IsNullOrEmpty(Convert.ToString(objMSmodel.Satus)))
                {
                    return Convert.ToString(objMSmodel.Satus);
                }
                else
                {
                    return "FAILED";
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                model = null;
            }

        }
        /// <summary>
        /// Get the data and bind for generate RTP pass
        /// </summary>
        /// <param name="ForwardingNoteId"></param>
        /// <returns></returns>
        public ActionResult GenerateRTPPass(int? ForwardingNoteId)
        {
            ForwardingNoteModel model = new ForwardingNoteModel();
            List<ForwardingNoteModel> ForwardingNoteList = new List<ForwardingNoteModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 83;
            model.ForwardingNoteId = ForwardingNoteId;
            try
            {
                if (ModelState.IsValid)
                {
                    ForwardingNoteList = _userPemit.GenerateRTPPass(model);
                    for (var i = 0; i < ForwardingNoteList.Count; i++)
                    {
                        model.SRNO = 1;

                        model.Consigner = Convert.ToString(ForwardingNoteList[i].ApplicantName);
                        model.Address = Convert.ToString(ForwardingNoteList[i].Address);

                        model.TelephoneNo = Convert.ToString(ForwardingNoteList[i].MobileNo);
                        model.GrantOrderNo = Convert.ToString(ForwardingNoteList[i].GrantOrderNumber);
                        model.GrantOrderDate = Convert.ToString(ForwardingNoteList[i].GrantOrderDate);

                        model.ForwardingNoteId = Convert.ToInt32(ForwardingNoteList[i].ForwardingNoteId);
                        model.ForwardingTransacationId = Convert.ToString(ForwardingNoteList[i].ForwardingTransacationId);
                        model.ForwardingNoteNumber = Convert.ToString(ForwardingNoteList[i].ForwardingNote);
                        model.BulkPermitId = Convert.ToInt32(ForwardingNoteList[i].BulkPermitId);
                        model.BulkPermitNumber = Convert.ToString(ForwardingNoteList[i].BulkPermitNo);

                        model.RailwayId = Convert.ToInt32(ForwardingNoteList[i].RailwayId);
                        model.RailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                        model.RailwayAddress = Convert.ToString(ForwardingNoteList[i].RailwayAddress);

                        model.DateofSubmitedRTPRequest = Convert.ToDateTime(ForwardingNoteList[i].CreatedOn);
                        model.MineralName = Convert.ToString(ForwardingNoteList[i].MineralName);
                        model.MineralId = Convert.ToInt32(ForwardingNoteList[i].MineralID);
                        model.MineralGrade = Convert.ToString(ForwardingNoteList[i].MineralGrade);
                        model.MineralGradeId = Convert.ToInt32(ForwardingNoteList[i].MineralGradeId);
                        model.MineralNature = Convert.ToString(ForwardingNoteList[i].MineralNature);
                        model.MineralNatureId = Convert.ToInt32(ForwardingNoteList[i].MineralNatureId);

                        model.EndUserId = Convert.ToInt32(ForwardingNoteList[i].EndUserId);
                        model.EndUser = Convert.ToString(ForwardingNoteList[i].EndUserName);
                        model.AddressofConsignee = Convert.ToString(ForwardingNoteList[i].EndAddress);

                        model.UnitName = Convert.ToString(ForwardingNoteList[i].UnitName);
                        model.UnitId = Convert.ToInt32(ForwardingNoteList[i].UnitId);

                        model.ReqQty = Convert.ToDecimal(ForwardingNoteList[i].ReqQty);
                        model.ApprovedQty = !string.IsNullOrEmpty(ForwardingNoteList[i].ApprovedQty.ToString()) ? Convert.ToDecimal(ForwardingNoteList[i].ApprovedQty) : 0;
                        model.Status = Convert.ToInt32(ForwardingNoteList[i].Status);
                        model.LeaseFrom = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseFrom);
                        model.LeaseTo = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseTo);

                        if (!string.IsNullOrEmpty(ForwardingNoteList[i].RTPAppliedQty.ToString()))
                        {
                            model.RTP_ApprovedQty = Convert.ToDecimal(ForwardingNoteList[i].RTPAppliedQty);
                        }
                        else
                        {
                            model.RTP_ApprovedQty = 0;
                        }

                        if (string.IsNullOrEmpty(Convert.ToString(ForwardingNoteList[i].RailwayAddress)))
                            model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                        else
                            model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName) + " ( " + Convert.ToString(ForwardingNoteList[i].RailwayAddress) + " ) ";
                        model.DestinationRailwaySiding = Convert.ToString(ForwardingNoteList[i].DestinationRailwaySiding);
                    }
                }
                return View(model);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                model = null;
            }
           
        }
        /// <summary>
        /// Generate RTP pass and continue
        /// </summary>
        /// <param name="ForwardingNoteID"></param>
        /// <param name="TrainNo"></param>
        /// <param name="RackNo"></param>
        /// <param name="ApprovedQty"></param>
        /// <param name="PassClick"></param>
        /// <returns></returns>
        public int UpdateRTPPass(int? ForwardingNoteID, string TrainNo, string RackNo, decimal? ApprovedQty, int? PassClick)
        {
            ForwardingNoteModel model = new ForwardingNoteModel();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserID = Convert.ToInt32(profile.UserId);
                model.SubUserID = Convert.ToInt32(profile.SubUserID);
                //model.UserID = 83;
               
                model.ForwardingNoteId = ForwardingNoteID;
               
                model.TrainNo = TrainNo;
                model.RackNo = RackNo;
                model.ApprovedQty = ApprovedQty;
                model.PassClick = PassClick;
                objMSmodel = _userPemit.UpdateRTPPass(model);
                if (objMSmodel.Satus != null && Convert.ToInt32(objMSmodel.Satus) > 0)
                {
                    return Convert.ToInt32(objMSmodel.Satus);
                }
                else
                {
                    return 0;
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                model = null;
            }
        }
        /// <summary>
        /// Generate RTP pass and close
        /// </summary>
        /// <param name="ForwardingNoteId"></param>
        /// <param name="entqty"></param>
        /// <returns></returns>
        public ActionResult PrintAndCloseTP(string ForwardingNoteId, string entqty)
        {
            ForwardingNoteModel model = new ForwardingNoteModel();
            List<ForwardingNoteModel> ForwardingNoteList = new List<ForwardingNoteModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.ForwardingNoteId =Convert.ToInt32(ForwardingNoteId);
            try
            {
                if (ModelState.IsValid)
                {
                    ForwardingNoteList = _userPemit.PrintAndCloseTP(model);
                    for (var i = 0; i < ForwardingNoteList.Count; i++)
                    {
                        model.SRNO = 1;

                        model.Consigner = Convert.ToString(ForwardingNoteList[i].ApplicantName);
                        model.Address = Convert.ToString(ForwardingNoteList[i].Address);

                        model.TelephoneNo = Convert.ToString(ForwardingNoteList[i].MobileNo);
                        model.GrantOrderNo = Convert.ToString(ForwardingNoteList[i].GrantOrderNumber);
                        model.GrantOrderDate = Convert.ToString(ForwardingNoteList[i].GrantOrderDate);

                        model.ForwardingNoteId = Convert.ToInt32(ForwardingNoteList[i].ForwardingNoteId);
                        model.ForwardingTransacationId = Convert.ToString(ForwardingNoteList[i].ForwardingTransacationId);
                        model.ForwardingNoteNumber = Convert.ToString(ForwardingNoteList[i].ForwardingNote);
                        model.BulkPermitId = Convert.ToInt32(ForwardingNoteList[i].BulkPermitId);
                        model.BulkPermitNumber = Convert.ToString(ForwardingNoteList[i].BulkPermitNo);

                        model.RailwayId = Convert.ToInt32(ForwardingNoteList[i].RailwayId);
                        model.RailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                        model.RailwayAddress = Convert.ToString(ForwardingNoteList[i].RailwayAddress);

                        model.DateofSubmitedRTPRequest = Convert.ToDateTime(ForwardingNoteList[i].CreatedOn);
                        model.MineralName = Convert.ToString(ForwardingNoteList[i].MineralName);
                        model.MineralId = Convert.ToInt32(ForwardingNoteList[i].MineralID);
                        model.MineralGrade = Convert.ToString(ForwardingNoteList[i].MineralGrade);
                        model.MineralGradeId = Convert.ToInt32(ForwardingNoteList[i].MineralGradeId);
                        model.MineralNature = Convert.ToString(ForwardingNoteList[i].MineralNature);
                        model.MineralNatureId = Convert.ToInt32(ForwardingNoteList[i].MineralNatureId);

                        model.EndUserId = Convert.ToInt32(ForwardingNoteList[i].EndUserId);
                        model.EndUser = Convert.ToString(ForwardingNoteList[i].EndUserName);
                        model.AddressofConsignee = Convert.ToString(ForwardingNoteList[i].EndAddress);

                        model.UnitName = Convert.ToString(ForwardingNoteList[i].UnitName);
                        model.UnitId = Convert.ToInt32(ForwardingNoteList[i].UnitId);
                        model.StockQty = !string.IsNullOrEmpty(entqty) ? Convert.ToDecimal(entqty) : 0;
                        model.ReqQty = Convert.ToDecimal(ForwardingNoteList[i].ReqQty);
                        model.ApprovedQty = !string.IsNullOrEmpty(ForwardingNoteList[i].ApprovedQty.ToString()) ? Convert.ToDecimal(ForwardingNoteList[i].ApprovedQty.ToString()) : 0;
                        model.PrintAndCloseFNQty = !string.IsNullOrEmpty(ForwardingNoteList[i].PrintAndCloseFNQty.ToString()) ? Convert.ToDecimal(ForwardingNoteList[i].PrintAndCloseFNQty.ToString()) : 0;

                        model.Status = Convert.ToInt32(ForwardingNoteList[i].Status);
                        model.LeaseFrom = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseFrom);
                        model.LeaseTo = Convert.ToString(ForwardingNoteList[i].PeriodOfLeaseTo);

                        if (!string.IsNullOrEmpty(ForwardingNoteList[i].OpenRoadTPQty.ToString()))
                        {
                            model.OpenRoadTPQty = Convert.ToDecimal(ForwardingNoteList[i].OpenRoadTPQty);
                        }

                        if (!string.IsNullOrEmpty(ForwardingNoteList[i].RTPAppliedQty.ToString()))
                        {
                            model.RTP_ApprovedQty = Convert.ToDecimal(ForwardingNoteList[i].RTPAppliedQty);
                        }
                        else
                        {
                            model.RTP_ApprovedQty = 0;
                        }
                        if (string.IsNullOrEmpty(Convert.ToString(ForwardingNoteList[i].RailwayAddress).ToString()))
                            model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName);
                        else
                            model.AddressofRailwaySliding = Convert.ToString(ForwardingNoteList[i].RailwaySlidingName) + " ( " + Convert.ToString(ForwardingNoteList[i].RailwayAddress) + " ) ";
                        model.DestinationRailwaySiding = Convert.ToString(ForwardingNoteList[i].DestinationRailwaySiding);
                    }
                }
                return View(model);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                model = null;
            }

           

        }
        #region DSC Response Verify
        string Signature = string.Empty;

        /// <summary>
        /// Check Verify DSC Response
        /// </summary>
        /// <param name="contentType,signDataBase64Encoded,responseType"></param>
        /// <returns></returns>
        public string CheckVerifyResponse(string contentType, string signDataBase64Encoded, string responseType)
        {
            try
            {
                if (signDataBase64Encoded.Contains("signing canceled"))
                {
                    OutputResult = "";
                }
                else
                {
                    signDataBase64Encoded = signDataBase64Encoded.Replace("IssuerCommonName", " Issuer");
                    signDataBase64Encoded = signDataBase64Encoded.Replace("CommonName", " CommonName").Replace("SerialNo", " SerialNo").Replace("IssuedDate", " IssuedDate").Replace("ExpiryDate", " ExpiryDate").Replace("Email", " Email").Replace("Country", " Country").Replace("CertificateClass", " CertificateClass").Replace("\r\n", "");
                    string[] tokens = signDataBase64Encoded.Split(new[] { " " }, StringSplitOptions.None);

                    string strSign = GetDSCRespnseData(tokens);

                    TempData["DSCResponse"] = signDataBase64Encoded;
                    TempData["Base64Data"] = strSign;
                    OutputResult = "SUCCESS";
                }
            }
            catch
            {
            }
            return OutputResult.ToUpper();
        }

        /// <summary>
        /// Get DSC Response Data
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string GetDSCRespnseData(string[] parameters)
        {
            string strSign = string.Empty;
            string[] strGetMerchantParamForCompare;
            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "SIGNATURE")
                {
                    Signature = Convert.ToString(strGetMerchantParamForCompare[1]);
                    break;
                }
            }
            strSign = Signature;
            return strSign;
        }

        /// <summary>
        /// Save DSC PDF File
        /// </summary>
        /// <param name="base64BinaryStr,fileName,ID,UpdateIn"></param>
        /// <returns></returns>

        public JsonResult SavePdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn, string Month_Year)
        {
            string OutputResult = "SUCCESS";
            try
            {
                var ServerPath = "/DSC/WithDSC/" + fileName;
                
                var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, Configuration["FNDSCCreateFilePATH"]);
                var savepath = Path.Combine(RootPath, fileName);
                try
                {
                    string strFinalString = string.Empty;
                    if (base64BinaryStr.Contains("Signature="))
                    {
                        string strWithoutSign = base64BinaryStr.Replace("Signature=", string.Empty);
                        strFinalString = strWithoutSign.Substring(0, strWithoutSign.IndexOf("CommonName"));
                        strFinalString = strFinalString.Replace("==", string.Empty).Replace("\r", string.Empty);
                    }
                    else
                    {
                        strFinalString = base64BinaryStr.Substring(0, base64BinaryStr.IndexOf("CommonName"));
                        strFinalString = strFinalString.Replace("==", string.Empty).Replace("\r", string.Empty);
                    }

                    if ((System.IO.File.Exists(savepath)))
                    {
                        string file = "File Already Exists";
                    }
                    else
                    {
                        byte[] bytes = Convert.FromBase64String(strFinalString);
                        System.IO.FileStream stream = new FileStream(savepath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    OutputResult = "PDF File Save failed. Please try after some time";
                    return Json(OutputResult.ToUpper());
                }

                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objMSmodel = _userPemit.DSCPathUpdate(new UpdateDSCPath()
                {
                    fileName = ServerPath,
                    ID = ID,
                    UpdateIn = UpdateIn,
                    UserId = profile.UserId,
                    MonthYear = Month_Year
                });

                if (string.IsNullOrEmpty(objMSmodel.Satus))
                {
                    OutputResult = "FAILED";
                }
                if (UpdateIn.ToUpper() == "LESSEE_BP")
                {
                    #region Sent Mail & MSG
                   // LesseeFinalApproval = _userPemit.LESSEE_BP(new UpdateDSCPath()
                   // {
                   //     UserId = profile.UserId,
                   //     ID = ID
                   // });
                   // string message = "Your e-Permit Application has been generated against Transaction Id: " + LesseeFinalApproval.TransactionalId + " Dated " + System.DateTime.Now.Date.ToString("dd / MM / yyyy") + "Payment Reference ID: " + LesseeFinalApproval.PaymentReceiptID + ".";
                   // //string message = "Your application for Storage License has been received by the sanctioning authority. CHiMMS, GoCG";
                   // string templateid = "1307161883499215951";
                   //sMSModel.Main(new SMS() { mobileNo = LesseeFinalApproval.MOBILENO, message = message, templateid = templateid });
                    #endregion

                    //#region Sent Mail & MSG
                    //using (var cmd1 = new SqlCommand())
                    //{
                    //    var mobile = "";
                    //    var email = "";
                    //    var TransactionId = "";
                    //    var PaymentReceiptID = "";
                    //    var forwadedDate = "";
                    //    var ApplicantName = "";

                    //    cmd1.CommandText = "uspCoalEPermit";
                    //    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    //    cmd1.Parameters.AddWithValue("@Check", 18);
                    //    cmd1.Parameters.AddWithValue("@BulkPermitId", ID);
                    //    using (var dt = db.ExecuteStoreProcedure(cmd1))
                    //    {
                    //        if (dt != null && dt.Rows.Count > 0)
                    //        {
                    //            mobile = dt.Rows[0]["MobileNo"].ToString();
                    //            email = dt.Rows[0]["EMailId"].ToString();
                    //            ApplicantName = dt.Rows[0]["ApplicantName"].ToString();
                    //            TransactionId = dt.Rows[0]["TransactionalId"].ToString();
                    //            PaymentReceiptID = dt.Rows[0]["PaymentReceiptID"].ToString();
                    //            forwadedDate = dt.Rows[0]["forwadedDate"].ToString();
                    //            string BulkPermitNo = dt.Rows[0]["BulkPermitNo"].ToString();
                    //            string ApprovedQty = Convert.ToString(dt.Rows[0]["ApprovedQty"]);
                    //            string TotalPayableAmount = Convert.ToString(dt.Rows[0]["TotalPayableAmount"]);
                    //            string MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
                    //            string MineralGrade = Convert.ToString(dt.Rows[0]["MineralGrade"]);
                    //            string MineralNature = Convert.ToString(dt.Rows[0]["MineralNature"]);
                    //            string UnitName = Convert.ToString(dt.Rows[0]["UnitName"]);

                    //            string message = "Your e-Permit Application has been generated against Transaction Id: " + TransactionId + " Dated " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "Payment Reference ID : " + PaymentReceiptID + ".";

                    //            SMSHttpPostClient.Main(mobile, message);
                    //            MailService mail = new MailService();
                    //            mail.SendMail_PaymentAck(PaymentReceiptID, email, forwadedDate, TransactionId, ApplicantName);

                    //            #region Send SMS
                    //            try
                    //            {
                    //                if (!string.IsNullOrEmpty(email))
                    //                {
                    //                    MailService dmoMail = new MailService();
                    //                    dmoMail.SendPermitDSCAck(email, BulkPermitNo, ApprovedQty, TotalPayableAmount, MineralName, MineralGrade, MineralNature, "Offline", TransactionId);
                    //                }

                    //                if (!string.IsNullOrEmpty(mobile))
                    //                {
                    //                    string msg = "Your e-Permit Application has been generated successfully and Your e-Permit No. is: " + BulkPermitNo + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                    //                        "Mineral Name : " + MineralName + "" + Environment.NewLine +
                    //                        "Mineral Form : " + MineralNature + "" + Environment.NewLine +
                    //                        "Mineral Grade : " + MineralGrade + "" + Environment.NewLine +
                    //                        "Quantity to be dispatched: " + ApprovedQty + " " + UnitName + "" + Environment.NewLine + "";

                    //                    SMSHttpPostClient.Main(mobile, msg);

                    //                    // SMSHttpPostClient.Main(mobile, msg);
                    //                }
                    //            }
                    //            catch (Exception)
                    //            {

                    //            }

                    //            #endregion
                    //        }
                    //    }
                    //}
                    //#endregion
                }
                if (UpdateIn.ToUpper() == "LICENSE_APP_ACK")
                {
                    #region Sent Mail & MSG
                    LicenseFinalApproval = _userPemit.LICENSE_APP_ACK(new UpdateDSCPath()
                    {
                        UserId = profile.UserId,
                        ID = ID
                    });
                    string message = "Your application for Storage License has been received by the sanctioning authority";
                    string templateid = "1307161883499215951";
                    sMSModel.Main(new SMS() { mobileNo = LicenseFinalApproval.MOBILENO, message = message, templateid = templateid });
                    #endregion
                }

                if (UpdateIn.ToUpper() == "LICENSE_APP_GRANT_ORDER")
                {
                    #region Sent Mail & MSG
                    LicenseFinalApproval = _userPemit.LICENSE_APP_GRANT_ORDER(new UpdateDSCPath()
                    {
                        UserId = profile.UserId,
                        ID = ID
                    });
                    string message = "Dear " + LicenseFinalApproval.APPLICANTNAME + " , Your Storage Permit application Ref ID " + LicenseFinalApproval.LICENSE_APP_CODE + " dated " + LicenseFinalApproval.ApprovedGrantOn + " has been approved and your permit order " + LicenseFinalApproval.License_SI_NO + " has been approved on dated " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + " . Please login in your portal and pay security fees within 7 days of approved grant order. CHiMMS, GoCG";


                    string templateid = "1307161883503430214";
                    sMSModel.Main(new SMS() { mobileNo = LicenseFinalApproval.MOBILENO, message = message, templateid = templateid });
                    #endregion
                }
            }
            catch (Exception ex)
            {
                OutputResult = "FAILED";
            }
            return Json(OutputResult.ToUpper());
        }

        /// <summary>
        /// Save Normal PDF File
        /// </summary>
        /// <param name="base64BinaryStr,fileName,ID,UpdateIn"></param>
        /// <returns></returns>

        public JsonResult SaveNormalPdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn)
        {
            string OutputResult = "SUCCESS";
           
            try
            {
               
                var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, Configuration["FNDSCReadFilePATH"]);
                var savepath = Path.Combine(RootPath, fileName);
                using (FileStream fs = new FileStream(savepath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(base64BinaryStr);
                        bw.Write(data);
                        bw.Close();
                    }
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                OutputResult = "FAILED";
            }
            return Json(OutputResult.ToUpper());
        }
        #endregion
    }
}