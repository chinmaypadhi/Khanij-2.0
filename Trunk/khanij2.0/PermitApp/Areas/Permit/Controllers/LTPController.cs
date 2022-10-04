using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermitApp.Areas.Permit.Models.LTP;
using PermitEF;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using PermitApp.Helper;
using PermitApp.Web;
using Microsoft.Extensions.Configuration;
using PermitApp.ActionFilter;

namespace PermitApp.Areas.Permit.Controllers
{
    [Area("Permit")]
    public class LTPController : Controller
    {
        ILTPModel _userLTP;

        private IConfiguration configuration;

        string SBIAPIPath = "";
        MessageEF objMSmodel = new MessageEF();
        public object JsonRequestBehavior { get; private set; }
        IHostingEnvironment _hostingEnvironment;
        string OutputResult = "";


        public LTPController(ILTPModel objPermit, IHostingEnvironment hostingEnvironment, IConfiguration _configuration)
        {
            _userLTP = objPermit;
            _hostingEnvironment = hostingEnvironment;
            this.configuration = _configuration;
        }
        [HttpGet]
        public IActionResult Permit(int? LTPPermitId)
        {
            LTPInfo objmodel = new LTPInfo();
            LTPInfo model = new LTPInfo();
            List<LTPInfo> LtpList = new List<LTPInfo>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
            //objmodel.UserID = 483;

            objmodel.LTPPermitId = LTPPermitId;

            LtpList = _userLTP.GetRTPPassList(objmodel);
            if (LtpList != null)
            {
                ViewBag.RTPPassNo = LtpList.Select(c => new SelectListItem
                {
                    Text = c.RTPPassNo,
                    Value = c.RTPPassID.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.RTPPassNo = Enumerable.Empty<SelectListItem>();
            }
            LtpList = new List<LTPInfo>();
            LtpList = _userLTP.GetCascadeMineral(objmodel);
            if (LtpList != null)
            {
                ViewBag.Mineral = LtpList.Select(c => new SelectListItem
                {
                    Text = c.MineralName,
                    Value = c.MineralId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.Mineral = Enumerable.Empty<SelectListItem>();
            }


            LtpList = new List<LTPInfo>();
            LtpList = _userLTP.GetRailwaySiding(objmodel);
            if (LtpList != null)
            {
                ViewBag.RailwaySidingFrom = LtpList.Select(c => new SelectListItem
                {
                    Text = c.RailwaySlidingName,
                    Value = c.RailwayID.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.RailwaySidingFrom = Enumerable.Empty<SelectListItem>();
            }
            LtpList = new List<LTPInfo>();
            LtpList = _userLTP.GetRailwaySidingDestination(objmodel);
            if (LtpList != null)
            {
                ViewBag.RailwaySidingDestination = LtpList.Select(c => new SelectListItem
                {
                    Text = c.DestinationRailwaySiding,
                    Value = c.DestinationRailwayId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.RailwaySidingDestination = Enumerable.Empty<SelectListItem>();
            }
            if (LTPPermitId != null && LTPPermitId > 0)
            {
                model.ReceivedFrom = "INSIDESTATE";
                LtpList = new List<LTPInfo>();
                LtpList = _userLTP.getAddLTPDetails(objmodel);
                if (LtpList != null)
                {
                    foreach (var app in LtpList)
                    {
                        model.LTPPermitId = Convert.ToInt32(app.LTPPermitId);
                        model.LicenseId = Convert.ToInt32(app.UserId);
                        model.LicenseName = Convert.ToString(app.ApplicantName);
                        model.Address = Convert.ToString(app.Address);
                        model.DesignationName = Convert.ToString(app.CORPORATE_DESIGNATION);
                        model.MobileNo = Convert.ToString(app.MobileNo);

                        model.qtybyRailway = Convert.ToDecimal(app.qtybyRailway);
                        model.FromRailwaySidingId = Convert.ToInt16(app.FromRailwaySidingId);

                        model.NameoftheRecieptMineral = Convert.ToString(app.NameoftheRecieptMineral);
                        model.NameoftheRecieptMineralId = Convert.ToInt32(app.NameoftheRecieptMineralId);

                        model.FromRailwaySidingName = Convert.ToString(app.FromRailwaySidingName);
                        model.WhereRailwaySidingName = Convert.ToString(app.WhereRailwaySidingName);
                        model.WhereRailwaySidingId = Convert.ToInt16(app.ToRailwaySidingId);
                        model.Purpose = Convert.ToString(app.Purpose);
                        model.DestinationAddress = Convert.ToString(app.DestinationAddress);
                        model.ForwardingReceiptName = Convert.ToString(app.ForwardingReceiptName);
                        model.OtherDetails = Convert.ToString(app.OtherDetails);
                        model.DetailsofRailwayReciept = Convert.ToString(app.DetailOfRailwayReceipt);
                        model.TransportationRoute = Convert.ToString(app.TransportationRoute);
                        model.MineralName = Convert.ToString(app.MineralName);
                        model.MineralId = Convert.ToInt16(app.MineralID);

                        //model.UserTypeId = SessionWrapper.UserTypeId;
                    }
                }
                return View(model);
            }
            else
            {
                model.ReceivedFrom = "INSIDESTATE";
                LtpList = new List<LTPInfo>();
                LtpList = _userLTP.getLTPDetails(objmodel);
                model.LTPPermitId = 0;
                if (LtpList != null)
                {
                    foreach (var app in LtpList)
                    {
                        model.LicenseId = Convert.ToInt32(app.UserId);
                        model.LicenseName = Convert.ToString(app.ApplicantName);
                        model.Address = Convert.ToString(app.Address);
                        model.DesignationName = Convert.ToString(app.CORPORATE_DESIGNATION);
                        model.MobileNo = Convert.ToString(app.MobileNo);
                        model.MineralName = Convert.ToString(app.MineralName);


                        model.NameoftheRecieptMineral = Convert.ToString(app.NameofMineralReceipt);
                        model.NameoftheRecieptMineralId = Convert.ToInt32(app.UserId);
                    }
                }
                return View(model);

            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Permit(LTPInfo model, List<IFormFile> flLTPCopy)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.UserType = profile.UserType;
            model.SubUserID = Convert.ToInt32(profile.SubUserID);
            //model.UserID = 483;
            //model.UserType = "Licensee";
            List<LTPInfo> LTPList = new List<LTPInfo>();
            try
            {
                //if (ModelState.IsValid)
                //{
                    long size = flLTPCopy.Sum(f => f.Length);
                    var filePaths = new List<string>();
                    string RootPath = configuration.GetSection("Path").GetSection("UploadPath").Value;
                    foreach (var formFile in flLTPCopy)
                    {
                        if (formFile != null && formFile.Length > 0)
                        {
                            if (!string.IsNullOrEmpty(formFile.FileName))
                            {
                                //string strName = string.Format(@"LTP_{0}", DateTime.Now.Ticks) + "_" + Path.GetFileName(formFile.FileName);
                                string strName = string.Format( Path.GetFileName(formFile.FileName));
                                //string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var destinationPath = Path.Combine(Directory.GetCurrentDirectory(), RootPath + "/LTPPermit/", formFile.FileName);
                                var savePath = Path.Combine((RootPath + "/LTPPermit/"), formFile.FileName);
                                var fileName = strName;

                                // DataRow dr = dt.NewRow();
                                using (var stream = new FileStream(destinationPath, FileMode.Create))
                                {
                                   
                                    formFile.CopyTo(stream);
                                }
                                model.ForwardingReceiptFilePath = savePath;
                                model.ForwardingReceiptName = strName;
                            }
                            else
                            {
                                ModelState.Clear();
                                return View();
                            }

                            // }
                        }
                    }

                    objMSmodel = _userLTP.AddLTPApplication(model);
                    ViewBag.UserTypeId = model.UserTypeId;

                    OutputResult = objMSmodel.Satus;
                    if (Convert.ToInt64(OutputResult) > 1)
                    {

                        //DataTable dt = UtilityModel.GetLtpPermitNoByLtpPermitId(Convert.ToInt64(OutputResult));

                        //string LTPApplicationNo = Convert.ToString(dt.Rows[0]["LTPApplicationNo"]);
                        //string LTPPermitNo = Convert.ToString(dt.Rows[0]["LTPPermitNo"]);
                        //string Qty = Convert.ToString(dt.Rows[0]["qtybyRailway"]);
                        //string MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
                        //model.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
                        //model.EmailID = Convert.ToString(dt.Rows[0]["EMailId"]);

                        //if (model.MobileNo != null && model.EmailID != null)
                        //{

                        //    #region Send SMS
                        //    try
                        //    {
                        //        string message = "Your E-Permit ID is " + LTPApplicationNo + Environment.NewLine + Environment.NewLine + "Mineral Name : " + MineralName + Environment.NewLine + Environment.NewLine +
                        //                            "Quantity of the mineral to be brought by way of railway transportation : " + Qty + " Tonne" + Environment.NewLine + Environment.NewLine +
                        //                             "You can start dispatch using generated E-permit ID";

                        //        SMSHttpPostClient.Main(model.MobileNo, message);

                        //    }
                        //    catch (Exception)
                        //    {

                        //    }
                        //    #endregion

                        //    #region Send Mail
                        //    try
                        //    {

                        //        MailService mail = new MailService();
                        //        mail.SendLtpPermitMail(model.MobileNo, model.EmailID, MineralName, LTPApplicationNo, Qty);

                        //    }
                        //    catch (Exception)
                        //    {
                        //        TempData["AckMessage"] = "Something went wrong.Please try again letter!!!";

                        //    }
                        //    #endregion
                        //}

                    }
                    else
                    {
                        TempData["AckMessage"] = "Something went wrong.Please try again later!!!";

                    }

                    //objDSCResponse.getDSCResponse(model.DSCResponse, "Ltp-Permit", Convert.ToInt32(getIdentity));
                    // TempData["AckMessage"] = "Your LTP Request Saved Successfully";

                    ModelState.Clear();
                    var dataString = CustomQueryStringHelper.
                     EncryptString("Permit", "DownloadLtp_Permit", "LTP", new { id = OutputResult });
                // return RedirectToAction("DownloadLtp_Permit", new { id = OutputResult });
                return new RedirectResult(dataString);



                //}
            }
            catch (Exception ex)
            {
                return View(model);
            }
            return View();

        }
        /// <summary>
        /// Get all RTP data
        /// </summary>
        /// <param name="RTPPassID"></param>
        /// <returns></returns>
        public JsonResult GetuserDetailsUsingRTP(int? RTPPassID)
        {
            LTPInfo model = new LTPInfo();
            List<LTPInfo> LTPList = new List<LTPInfo>();
             UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 483;
            model.RTPPassID = Convert.ToInt32(RTPPassID);
            try
            {

                LTPList = _userLTP.GetuserDetailsUsingRTP(model);

                var SList = LTPList.ToList();
                return Json(SList);

            }
            catch (Exception ex)
            {
                return Json("");
            }
        }
        /// <summary>
        /// Get  mineral nature on mineral id
        /// </summary>
        /// <param name="MineralId"></param>
        /// <returns></returns>
        public JsonResult GetMineralNature(int? MineralId)
        {
            LTPInfo model = new LTPInfo();
            List<LTPInfo> LTPList = new List<LTPInfo>();
             UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 483;
            model.MineralId = Convert.ToInt32(MineralId);
            try
            {
                LTPList = _userLTP.GetMineralNatureList(model);
                var NatureList = LTPList.ToList();
                return Json(NatureList);
            }
            catch (Exception ex)
            {
                return Json("");
            }
        }
        /// <summary>
        /// Get mineral grade on mineral nature
        /// </summary>
        /// <param name="MineralNatureId"></param>
        /// <returns></returns>
        public JsonResult GetMineralGrade(int? MineralNatureId)
        {
            LTPInfo model = new LTPInfo();
            List<LTPInfo> LTPList = new List<LTPInfo>();
             UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 483;
            model.MineralNatureId = Convert.ToInt32(MineralNatureId);
            try
            {
                LTPList = _userLTP.GetMineralGradList(model);
                var GradeList = LTPList.ToList();
                return Json(GradeList);
            }
            catch (Exception ex)
            {
                return Json("");
            }
        }
        /// <summary>
        /// Get the saved LTP Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult DownloadLtp_Permit(string id)
        {
            ListofLTP model = new ListofLTP();

            List<ListofLTP> LTPList = new List<ListofLTP>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 483;
            model.LTPPermitId = Convert.ToInt32(id);
            try
            {
                LTPList = _userLTP.DownloadLTP(model);
                if (LTPList != null)
                {
                    foreach (var app in LTPList)
                    {
                        model.ApplicantName = Convert.ToString(app.ApplicantName);
                        model.Address = Convert.ToString(app.Address);
                        model.Designation = Convert.ToString(app.Designation);

                        model.MobileNo = Convert.ToString(app.MobileNo);
                        model.Purpose = Convert.ToString(app.Purpose);
                        model.DestinationAddress = Convert.ToString(app.DestinationAddress);

                        model.TransportationRoute = Convert.ToString(app.TransportationRoute);
                        model.OtherDetails = Convert.ToString(app.OtherDetails);
                        model.DetailOfRailwayReceipt = Convert.ToString(app.DetailOfRailwayReceipt);


                        model.LicenseeCode = Convert.ToString(app.LicenseeCode);
                        model.LTPPermitId = string.IsNullOrEmpty(Convert.ToString(app.LTPPermitId)) ? 0 : Convert.ToInt32(app.LTPPermitId);
                        model.LTPApplicationNo = Convert.ToString(app.LTPApplicationNo);
                        model.ApplicationDate = string.IsNullOrEmpty(Convert.ToString(app.CreateOn)) ? "" : Convert.ToDateTime(app.CreateOn).ToString("dd/MM/yyyy");
                        model.MineralName = Convert.ToString(app.MineralName);
                        model.MineralForm = Convert.ToString(app.MineralForm);
                        model.MineralGrade = Convert.ToString(app.MineralGrade);
                        model.ProposedqtybyRailway = string.IsNullOrEmpty(Convert.ToString(app.qtybyRailway)) ? 0 : Convert.ToDecimal(app.qtybyRailway);
                        model.FromStationSideName = Convert.ToString(app.FromStationSideName);
                        model.ToStationSideName = Convert.ToString(app.ToStationSideName);
                        model.NameofMineralReceipt = Convert.ToString(app.NameofMineralReceipt);
                        model.DistrictName = Convert.ToString(app.DistrictName);
                        if (app.LTPFilePath == null || app.LTPFilePath.ToString() == "")
                        {

                            //@System.Configuration.ConfigurationManager.AppSettings["ServerPath
                            model.LTPFilePath = "";
                        }
                        else
                        {
                            model.LTPFilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(app.LTPFilePath);
                            //model.LTPFilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath + Convert.ToString(app.LTPFilePath);
                        }
                        model.DSCgeneratedby = Convert.ToString(app.GeneratedBy);

                        model.DSCgeneratedDesgination = Convert.ToString(app.GeneratedDesignation);
                        if ((app.ExpectedNoOfLtp.HasValue))
                            model.ExpectedNoOfLtp = Convert.ToInt32(app.ExpectedNoOfLtp);
                        else
                            model.ExpectedNoOfLtp = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return Json("");
            }
           
            return View(model);
        }
        /// <summary>
        /// Get the saved LTP Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Permit_List()
        {
            ListofLTP model = new ListofLTP();
            List<ListofLTP> PendingLTP = new List<ListofLTP>();
            List<ListofLTP> LTPList = new List<ListofLTP>();
             UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 483;
            try
            {
                LTPList = _userLTP.DownloadLTP(model);
                if (LTPList != null)
                {
                    foreach (var app in LTPList)
                    {
                        ListofLTP lst = new ListofLTP();
                       
                        lst.LicenseeCode = Convert.ToString(app.LicenseeCode);
                        lst.LTPPermitId = string.IsNullOrEmpty(Convert.ToString(app.LTPPermitId)) ? 0 : Convert.ToInt32(app.LTPPermitId);
                        lst.LTPApplicationNo = Convert.ToString(app.LTPApplicationNo);
                        lst.LTPPermitNo = Convert.ToString(app.LTPPermitNo);
                        lst.ApplicationDate = string.IsNullOrEmpty(Convert.ToString(app.CreateOn)) ? "" : Convert.ToDateTime(app.CreateOn).ToString("dd/MM/yyyy");
                        lst.MineralName = Convert.ToString(app.MineralName);
                        lst.ProposedqtybyRailway = string.IsNullOrEmpty(Convert.ToString(app.qtybyRailway)) ? 0 : Convert.ToDecimal(app.qtybyRailway);
                        lst.FromStationSideName = Convert.ToString(app.FromStationSideName);
                        lst.ToStationSideName = Convert.ToString(app.ToStationSideName);
                        lst.ApplicantName = Convert.ToString(app.NameofMineralReceipt);
                        lst.LTPFilePath = Convert.ToString(app.LTPFilePath);
                        lst.TotalPassCount = Convert.ToString(app.TotalPassCount);
                        if (Convert.ToString(app.DispatchQty) == "")
                            lst.DispatchQty = "0";
                        else
                            lst.DispatchQty = Convert.ToString(app.DispatchQty);
                        if (Convert.ToString(app.DispatchQty) == "")
                            lst.ReceivedQty = "0";
                        else
                            lst.ReceivedQty = Convert.ToString(app.ReceivedQty);
                        lst.Status = "Saved Application";
                        PendingLTP.Add(lst);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json("");
            }
            ViewBag.ViewList = PendingLTP;
            return View();
        }
    }
}
