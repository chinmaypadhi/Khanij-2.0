// ***********************************************************************
//  Controller Name          : WebsiteController
//  Desciption               : Website Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Nov 2021
// ***********************************************************************
using HomeApp.Areas.Website.Models.Testimonial;
using HomeApp.Areas.Website.Models.StaffDirectory;
using HomeApp.Areas.Website.Models.Tender;
using HomeApp.Areas.Website.Models.GlobalLink;
using HomeApp.Models.Notification;
using HomeEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApp.Areas.Website.Models.Feedback;
using HomeApp.Areas.Website.Models.Banner;
using HomeApp.Areas.Website.Models.Gallery;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using HomeApp.Areas.Configuration.Controllers;
using System.Text;
using HomeApp.ActionFilter;
using HomeApp.Areas.Website.Models.Graph;
using HomeApp.Areas.Website.Models.Notice;
using HomeApp.Areas.Website.Models.MineralMap;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]    
    public class WebsiteController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        ITestimonialModel _objITestimonialModel;
        IStaffDirectoryModel _objIStaffDirectoryModel;
        INotificationModel _objINotificationModel;
        ITenderModel _objITenderModel;
        IGlobalLinkModel _objIGlobalLinkModel;
        IFeedbackModel _objFeedbackModel;
        IBannerModel _objIBannerModel;
        IGalleryModel _objgalleryModel;
        IRevenue _objIrevenuemodel;
        IProduction _objIproductionmodel;
        IResources _objIresourcemodel;
        INoticeModel _objnoticeModel;
        IMineralMapModel _objIMineralMapModel;
        List<WebNotice> objnoticeModelsList = new List<WebNotice>();
        WebNotice objnotice = new WebNotice();
        ViewTestimonialModel objTestimonialViewmodel = new ViewTestimonialModel();
        List<ViewTestimonialModel> objTestimoniallistviewmodel = new List<ViewTestimonialModel>();
        AddStaffDirectoryModel objStaffdirectoryAddmodel = new AddStaffDirectoryModel();
        ViewStaffDirectoryModel objStaffdirectoryViewmodel = new ViewStaffDirectoryModel();
        List<ViewStaffDirectoryModel> objStaffdirectorylistviewmodel = new List<ViewStaffDirectoryModel>();
        List<AddStaffDirectoryModel> objStaffdirectorylistAddmodel = new List<AddStaffDirectoryModel>();
        ViewNotificationModel objNotificationviewmodel = new ViewNotificationModel();
        List<ViewNotificationModel> objNotificationlistviewmodel = new List<ViewNotificationModel>();
        ViewTenderModel objTenderviewmodel = new ViewTenderModel();
        List<ViewTenderModel> objTenderlistviewmodel = new List<ViewTenderModel>();
        AddGlobalLinkModel objAddGloballinkModel = new AddGlobalLinkModel();
        AddFeedbackModel objAddmodel = new AddFeedbackModel();
        ViewFeedbackModel objViewmodel = new ViewFeedbackModel();
        List<AddFeedbackModel> objlistmodel = new List<AddFeedbackModel>();
        List<ViewFeedbackModel> objlistviewmodel = new List<ViewFeedbackModel>();
        List<ViewBannerModel> objbannerlist = new List<ViewBannerModel>();
        List<ViewGalleryModel> objGalleryLsit = new List<ViewGalleryModel>();
        ViewBannerModel objViewBannerModel = new ViewBannerModel();
        ViewGalleryModel objViewGallerymodel = new ViewGalleryModel();
        AddPageModel objAddPageModel = new AddPageModel();
        List<AddPageModel> objAddPageModellist = new List<AddPageModel>();
        ViewMineralMapModel objViewMineralMapModel = new ViewMineralMapModel();
        List<ViewMineralMapModel> objViewMineralMapModellist = new List<ViewMineralMapModel>();
        MessageEF objMessage = new MessageEF();
        private readonly IHtmlLocalizer<HomeController> _localizer;
        private readonly IStringLocalizer<CommonResources> _sharedLocalizer;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objITestimonialModel"></param>
        /// <param name="objIStaffDirectoryModel"></param>
        /// <param name="objINotificationModel"></param>
        /// <param name="objITenderModel"></param>
        /// <param name="objIGlobalLinkModel"></param>
        /// <param name="feedbackModel"></param>
        /// <param name="bannerModel"></param>
        /// <param name="galleryModel"></param>
        /// <param name="hostingEnvironment"></param>
        public WebsiteController(ITestimonialModel objITestimonialModel, IStaffDirectoryModel objIStaffDirectoryModel, INotificationModel objINotificationModel, ITenderModel objITenderModel, IGlobalLinkModel objIGlobalLinkModel, IFeedbackModel feedbackModel, IBannerModel bannerModel, IGalleryModel galleryModel, IHostingEnvironment hostingEnvironment, IStringLocalizer<CommonResources> stringLocalizer, IRevenue objIrevenuemodel, IProduction objIproduction, IResources objIresourcesmodel, INoticeModel noticeModel, IMineralMapModel objIMineralMapModel)
        {
            _objITestimonialModel = objITestimonialModel;
            _objIStaffDirectoryModel = objIStaffDirectoryModel;
            _objINotificationModel = objINotificationModel;
            _objITenderModel = objITenderModel;
            _objIGlobalLinkModel = objIGlobalLinkModel;
            _objFeedbackModel = feedbackModel;
            _objIBannerModel = bannerModel;
            _objgalleryModel = galleryModel;
            _objIrevenuemodel = objIrevenuemodel;
            _objIproductionmodel = objIproduction;
            _objIresourcemodel = objIresourcesmodel;
            this.hostingEnvironment = hostingEnvironment;           
            _sharedLocalizer = stringLocalizer;
            _objnoticeModel = noticeModel;
            _objIMineralMapModel = objIMineralMapModel;
        }
        [SkipSessionTask]
        public IActionResult Home()
        {
            //ViewData["TopmenuTable"] = GetTopmenulist();
            ViewData["MainmenuTable"] = GetMainmenulist();
            ViewData["FootermenuTable"] = GetFootermenulist();
            ViewBag.Banner = Banner(objViewBannerModel);
            ViewBag.Gallery = Gallery(objViewGallerymodel);
            ViewData["Tender"] = Tender(objTenderviewmodel);
            ViewData["Notification"] = CircularNotification(objNotificationviewmodel);
            ViewData["ProductionChartDropdown"] = GetRevenueDropdownlist();
            ViewData["RevenueChartDropdown"] = GetRevenueDropdownlist();
            ViewBag.Notice = Notices(objnotice);
            return View();
        }
        [SkipSessionTask]
        public IEnumerable<string> GetProductionDropdownlist()
        {
            ViewProductionModel productionmodel = new ViewProductionModel();
            IEnumerable<string> productionyearlist = _objIproductionmodel.View(productionmodel).Select(x => x.FinancialYear).Distinct();
            return productionyearlist;
        }
        [SkipSessionTask]
        public IEnumerable<string> GetRevenueDropdownlist()
        {
            ViewRevenueModel revenuemodel = new ViewRevenueModel();
            IEnumerable<string> revenueyearlist = _objIrevenuemodel.View(revenuemodel).Select(x => x.FinancialYear).Distinct();
            return revenueyearlist;
        }
        /// <summary>
        /// For Production graph data fill by financialyear
        /// </summary>
        /// <param name="financialyear"></param>
        /// <returns>list of GraphProduction_DespatchModel</returns>
        [SkipSessionTask]
        public JsonResult Production(string financialyear)
        {
            ViewProductionModel obj = new ViewProductionModel();
            obj.FinancialYear = financialyear;
            List<ViewProductionModel> productionlist = new List<ViewProductionModel>();
            productionlist = _objIproductionmodel.ViewByFinancialYear(obj);
            return Json(productionlist);
        }
        /// <summary>
        /// For Revenue graph data fill by financialyear
        /// </summary>
        /// <param name="financialyear"></param>
        /// <returns>list of ViewProductionModel</returns>
        [SkipSessionTask]
        public JsonResult Revenue(string financialyear)
        {
            ViewRevenueModel obj = new ViewRevenueModel();
            obj.FinancialYear = financialyear;
            List<ViewRevenueModel> revenuelist = _objIrevenuemodel.ViewByFinancialYear(obj);
            return Json(revenuelist);
        }
        /// <summary>
        /// For Resource graph data fill
        /// </summary>
        /// <returns>list of ViewResourcesModel</returns>
        [SkipSessionTask]
        public JsonResult Resource(string financialyear)
        {
            ViewResourcesModel obj = new ViewResourcesModel();
            obj = _objIresourcemodel.View(obj);
            return Json(obj);
        }
        [SkipSessionTask]
        public IActionResult Introduction()
        {
            ViewData["MainmenuTable"] = GetMainmenulist();
            ViewData["FootermenuTable"] = GetFootermenulist();
            return View();
        }
        [SkipSessionTask]
        public IActionResult Tender()
        {
            ViewData["ActiveTenderTable"] = GetActiveTenderList();
            ViewData["ArchiveTenderTable"] = GetArchiveTenderList();
            //ViewData["TopmenuTable"] = GetTopmenulist();
            ViewData["MainmenuTable"] = GetMainmenulist();
            ViewData["FootermenuTable"] = GetFootermenulist();
            return View();
        }
        [SkipSessionTask]
        public IActionResult StaffDirectory()
        {
            objStaffdirectorylistAddmodel = (List<AddStaffDirectoryModel>)(ViewData["DepartmentTypeTable"] = GetDepartmenttypeList());
            var Department = objStaffdirectorylistAddmodel.First().VCH_OFFICE_TYPE;
            ViewData["StaffDirectoryTable"] = GetStaffDirectoryList(Department);
            //ViewData["TopmenuTable"] = GetTopmenulist();
            ViewData["MainmenuTable"] = GetMainmenulist();
            ViewData["FootermenuTable"] = GetFootermenulist();
            return View();
        }
        [SkipSessionTask]
        public IActionResult Gallery()
        {
            return View();
        }
        [SkipSessionTask]
        public IActionResult Notification()
        {
            ViewData["ActiveNotificationTable"] = GetActiveNotificationList();
            ViewData["ArchiveNotificationTable"] = GetArchiveNotificationList();
            //ViewData["TopmenuTable"] = GetTopmenulist();
            ViewData["MainmenuTable"] = GetMainmenulist();
            ViewData["FootermenuTable"] = GetFootermenulist();
            return View();
        }
        [SkipSessionTask]
        public IActionResult Testimonials()
        {
            try
            {
                ViewData["Testimonialtable"] = GetTestimonialList();
                //ViewData["TopmenuTable"] = GetTopmenulist();
                ViewData["MainmenuTable"] = GetMainmenulist();
                ViewData["FootermenuTable"] = GetFootermenulist();
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objTestimonialViewmodel = null;
            }
        }
        public IActionResult Logout()
        {
            return View();
        }
        [SkipSessionTask]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [SkipSessionTask]
        public IActionResult ChangePassword()
        {
            return View();
        }
        #region Testimonial website screen
        /// <summary>
        /// Bind Testimonial list details in view
        /// </summary>
        /// <returns></returns>
        public string GetTestimonialList()
        {
            try
            {
                string s = "";
                objTestimoniallistviewmodel = _objITestimonialModel.ViewPublishTestimonial(objTestimonialViewmodel);
                foreach (ViewTestimonialModel item in objTestimoniallistviewmodel)
                {
                    s += "<div class='col-lg-4 col-md-6 col-sm-12'>";
                    s += "<div class='card'>";
                    s += "<div class='card-body'>";
                    if (!string.IsNullOrEmpty(item.VCH_IMG_PATH))
                    {
                        s += "<img src='/" + item.VCH_IMG_PATH + "' class='rounded-circle' alt='user image' width='94'height='94' >";
                    }
                    s += "<h5 class='card-title'><i class='fas fa-quote-left'></i></h5>";
                    s += "<p class='card-text'>" + item.VCH_TESTIMONIAL_MSG + "</p>";
                    s += "<span class='blockquote-footer font-weight-bolder'>";
                    s += "<span class='name'>" + item.VCH_TESTIMONIAL_NAME + "</span>,";
                    s += "<span class='designation'>" + item.VCH_TESTIMONIAL_DESG + "</span>";
                    s += "<cite class='address'>(" + item.VCH_TESTIMONIAL_LOCATION + ")</cite>";
                    s += "</span>";
                    s += "</div>";
                    s += "</div>";
                    s += "</div>";
                }
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTestimoniallistviewmodel = null;
            }
        }
        #endregion
        #region Staffdirectory website screen
        /// <summary>
        /// Bind Department Type list details in view
        /// </summary>
        /// <returns></returns>     
        private List<AddStaffDirectoryModel> GetDepartmenttypeList()
        {
            try
            {
                objStaffdirectorylistAddmodel = _objIStaffDirectoryModel.GetOfficeTypeList(objStaffdirectoryAddmodel);
                return objStaffdirectorylistAddmodel.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objStaffdirectorylistAddmodel = null;
                objStaffdirectoryAddmodel = null;
            }
        }
        /// <summary>
        /// Bind Staff directory list details in view
        /// </summary>
        /// <returns></returns>        
        private List<ViewStaffDirectoryModel> GetStaffDirectoryList(string Department)
        {
            try
            {
                objStaffdirectoryViewmodel.VCH_OFFICE_TYPE = Department;
                objStaffdirectorylistviewmodel = _objIStaffDirectoryModel.ViewPublishStaffDirectory(objStaffdirectoryViewmodel);
                return objStaffdirectorylistviewmodel.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objStaffdirectoryViewmodel = null;
                objStaffdirectorylistviewmodel = null;
            }
        }
        /// <summary>
        /// Search Staff directory details in view
        /// </summary>
        /// <param name="Officername"></param>
        /// <param name="Departmenttype"></param>
        /// <returns></returns>
        [SkipSessionTask]
        public JsonResult SearchStaffDirectoryList(string Officername, string Departmenttype)
        {
            try
            {
                string s = "";
                objStaffdirectoryViewmodel.VCH_OFFICER_NAME = Officername;
                objStaffdirectoryViewmodel.VCH_OFFICE_TYPE = Departmenttype;
                objStaffdirectorylistviewmodel = _objIStaffDirectoryModel.ViewPublishStaffDirectory(objStaffdirectoryViewmodel);
                s += "<div class='tab-pane fade show active' id='" + Departmenttype + " line-content'>";
                s += "<div class='custom-scroll staff-port-height'>";
                s += "<div class='mr-2'>";
                s += "<div class='row'>";
                foreach (ViewStaffDirectoryModel item in objStaffdirectorylistviewmodel)
                {
                    s += "<div class='col-lg-6 col-md-6 col-sm-12'>";
                    s += "<div class='emp-card'>";
                    s += "<div class='emp-content'>";
                    s += "<h6 class='card-title text-primary font-weight-bold'>" + item.VCH_OFFICER_NAME + "</h6>";
                    s += "<ul class='pl-0 list-unstyled mb-0 staff-list'>";
                    s += "<li class='designation'>" + item.VCH_OFFICER_DESIG + "</li>";
                    if (Departmenttype.Contains("District Office") || Departmenttype.Contains("Facility Management Service"))
                        s += "<li class='distict'>" + item.VCH_LOCATION + "</li>";
                    s += "<li class='phoneno'><span><a class='text-dark'>" + item.VCH_PHONE_NO + " (M)</a></span></li>";
                    s += "<li class='gmail'><a href='mailto: ' class='text-dark'>" + item.VCH_EMAIL + "</a></li>";
                    s += "</ul>";
                    s += "</div>";
                    s += "</div>";
                    s += "</div>";
                }
                s += "</div>";
                s += "</div>";
                s += "</div>";
                s += "</div>";
                return Json(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objStaffdirectoryViewmodel = null;
                objStaffdirectorylistviewmodel = null;
            }
        }
        #endregion
        #region Notification website screen
        /// <summary>
        /// Bind Active Notification list details in view
        /// </summary>
        /// <returns></returns>
        public List<ViewNotificationModel> GetActiveNotificationList()
        {
            try
            {
                objNotificationlistviewmodel = _objINotificationModel.ViewWebsiteNotification(objNotificationviewmodel);
                return objNotificationlistviewmodel.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objNotificationlistviewmodel = null;
            }
        }
        /// <summary>
        /// Bind Archive Notification list details in view
        /// </summary>
        /// <returns></returns>
        public List<ViewNotificationModel> GetArchiveNotificationList()
        {
            try
            {
                string s = "";
                objNotificationlistviewmodel = _objINotificationModel.ViewWebsiteNotificationArchive(objNotificationviewmodel);
                return objNotificationlistviewmodel.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objNotificationlistviewmodel = null;
            }
        }
        /// <summary>
        /// Search Notification List details in view
        /// </summary>
        /// <param name="NotificationType"></param>
        /// <param name="Fromdate"></param>
        /// <param name="Todate"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [SkipSessionTask]
        public JsonResult SearchNotificationList(int? NotificationType, string Fromdate, string Todate, string Status)
        {
            try
            {
                string s = "";
                objNotificationviewmodel.INT_NOTIFICATION_TYPE_ID = NotificationType;
                objNotificationviewmodel.DTM_FROM_DATE = Fromdate;
                objNotificationviewmodel.DTM_TO_DATE = Todate;
                if (Status == "Archive")
                {
                    objNotificationlistviewmodel = _objINotificationModel.ViewWebsiteNotificationArchive(objNotificationviewmodel);
                }
                else
                {
                    objNotificationlistviewmodel = _objINotificationModel.ViewWebsiteNotification(objNotificationviewmodel);
                }
                foreach (ViewNotificationModel item in objNotificationlistviewmodel)
                {
                    s += "<div class='tender-card " + item.VCH_NOTIFICATION_NAME + " line-content'>";
                    s += "<p class='mb-4'>" + item.VCH_NOTIFICATION_SUB + "</p>";
                    s += "<p class='mb-0'><small><i class='far fa-calendar-alt mr-2'></i> Publish On : " + item.DTM_PUBLISHED_ON + "</small></p>";
                    s += "<div class='downloads'><a href='/" + item.VCH_UPLOAD_FILE + "' target='_blank'><i class='fas fa-file-pdf ml-2'></i></a></div>";
                    s += "</div>";
                }
                return Json(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objNotificationlistviewmodel = null;
            }
        }
        /// <summary>
        /// For Circular Notification
        /// </summary>
        /// <param name="notificationModel"></param>
        /// <returns></returns>
        private List<ViewNotificationModel> CircularNotification(ViewNotificationModel notificationModel)
        {
            try
            {
                objNotificationlistviewmodel = _objINotificationModel.ViewTopWebsiteNotification(notificationModel);
                return objNotificationlistviewmodel.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objNotificationlistviewmodel = null;
                notificationModel = null;
            }
        }
        #endregion
        #region Tender website screen
        /// <summary>
        /// Bind Active Tender list details in view
        /// </summary>
        /// <returns></returns>
        public string GetActiveTenderList()
        {
            try
            {
                string s = "";
                objTenderlistviewmodel = _objITenderModel.ViewWebsiteTenderActive(objTenderviewmodel);
                foreach (ViewTenderModel item in objTenderlistviewmodel)
                {
                    s += "<div class='line-content tender-card " + item.BIT_STATUS + "'>";
                    s += "<h5>Tender Number : " + item.VCH_TENDER_NO + "</h5>";
                    s += "<p>" + item.VCH_SUBJECT + "</p>";
                    s += "<p class='mb-1'>";
                    s += "<small class='text-danger d-lg-inline-block d-block'>";
                    s += "<span class='d-md-inline-block d-block'><i class='far fa-calendar-alt mr-2'></i> Closing  Date : " + item.DTM_TENDER_CLOSE_DATE + "</span>";
                    s += "<i class='far fa-clock ml-md-2 mr-2 ml-0'></i> Closing Time : " + item.DTM_TENDER_CLOSE_TIME + "</small>";
                    s += "<span class='d-lg-inline-block d-none mx-2'>|</span>";
                    s += "<small>";
                    s += "<span class='d-md-inline-block d-block'>";
                    s += "<i class='far fa-calendar-alt ml-lg-2 mr-2 ml-0'></i> Opening Date : " + item.DTM_TENDER_OPEN_DATE + "</span>";
                    s += "<i class='far fa-clock ml-md-2 mr-2 ml-0'></i> Opening Time : " + item.DTM_TENDER_OPEN_TIME + "</small>";
                    s += "</p>";
                    s += "<div class='downloads'><a href='/" + item.VCH_DOCUMENT + "' target='_blank'><i class='fas fa-file-pdf ml-2'></i></a></div>";
                    s += "</div>";
                }
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTenderlistviewmodel = null;
            }
        }
        /// <summary>
        /// Bind Archive Notification list details in view
        /// </summary>
        /// <returns></returns>
        public string GetArchiveTenderList()
        {
            try
            {
                string s = "";
                objTenderlistviewmodel = _objITenderModel.ViewWebsiteTenderArchive(objTenderviewmodel);
                foreach (ViewTenderModel item in objTenderlistviewmodel)
                {
                    s += "<div class='line-content tender-card'>";
                    s += "<h5>Tender Number : " + item.VCH_TENDER_NO + "</h5>";
                    s += "<p>" + item.VCH_SUBJECT + "</p>";
                    s += "<p class='mb-1'>";
                    s += "<small class='text-danger d-lg-inline-block d-block'>";
                    s += "<span class='d-md-inline-block d-block'><i class='far fa-calendar-alt mr-2'></i> Closing  Date : " + item.DTM_TENDER_CLOSE_DATE + "</span>";
                    s += "<i class='far fa-clock ml-md-2 mr-2 ml-0'></i> Closing Time : " + item.DTM_TENDER_CLOSE_TIME + "</small>";
                    s += "<span class='d-lg-inline-block d-none mx-2'>|</span>";
                    s += "<small>";
                    s += "<span class='d-md-inline-block d-block'>";
                    s += "<i class='far fa-calendar-alt ml-lg-2 mr-2 ml-0'></i> Opening Date : " + item.DTM_TENDER_OPEN_DATE + "</span>";
                    s += "<i class='far fa-clock ml-md-2 mr-2 ml-0'></i> Opening Time : " + item.DTM_TENDER_CLOSE_TIME + "</small>";
                    s += "</p>";
                    s += "<div class='downloads'><a href='/" + item.VCH_DOCUMENT + "' target='_blank'><i class='fas fa-file-pdf ml-2'></i></a></div>";
                    s += "</div>";
                }
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTenderlistviewmodel = null;
            }
        }
        /// <summary>
        /// Search Tender List details in view
        /// </summary>
        /// <param name="Tenderno"></param>
        /// <param name="Fromdate"></param>
        /// <param name="Todate"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [SkipSessionTask]
        public JsonResult SearchTenderList(string Tenderno, string Fromdate, string Todate, string Status)
        {
            try
            {
                string s = "";
                objTenderviewmodel.VCH_TENDER_NO = Tenderno;
                objTenderviewmodel.DTM_FROM_DATE = Fromdate;
                objTenderviewmodel.DTM_TO_DATE = Todate;
                if (Status == "Archive")
                {
                    objTenderlistviewmodel = _objITenderModel.ViewWebsiteTenderArchive(objTenderviewmodel);
                }
                else
                {
                    objTenderlistviewmodel = _objITenderModel.ViewWebsiteTenderActive(objTenderviewmodel);
                }
                foreach (ViewTenderModel item in objTenderlistviewmodel)
                {
                    s += "<div class='tender-card " + item.BIT_STATUS + " line-content'>";
                    s += "<h5>Tender Number : " + item.VCH_TENDER_NO + "</h5>";
                    s += "<p>" + item.VCH_SUBJECT + "</p>";
                    s += "<p class='mb-1'>";
                    s += "<small class='text-danger d-lg-inline-block d-block'>";
                    s += "<span class='d-md-inline-block d-block'><i class='far fa-calendar-alt mr-2'></i> Closing  Date : " + item.DTM_TENDER_CLOSE_DATE + "</span>";
                    s += "<i class='far fa-clock ml-md-2 mr-2 ml-0'></i> Closing Time : " + item.DTM_TENDER_CLOSE_TIME + "</small>";
                    s += "<span class='d-lg-inline-block d-none mx-2'>|</span>";
                    s += "<small>";
                    s += "<span class='d-md-inline-block d-block'>";
                    s += "<i class='far fa-calendar-alt ml-lg-2 mr-2 ml-0'></i> Opening Date : " + item.DTM_TENDER_OPEN_DATE + "</span>";
                    s += "<i class='far fa-clock ml-md-2 mr-2 ml-0'></i> Opening Time : " + item.DTM_TENDER_CLOSE_TIME + "</small>";
                    s += "</p>";
                    s += "<div class='downloads'><a href='/" + item.VCH_DOCUMENT + "' target='_blank'><i class='fas fa-file-pdf ml-2'></i></a></div>";
                    s += "</div>";
                }
                return Json(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTenderlistviewmodel = null;
            }
        }
        /// <summary>
        /// For Tender
        /// </summary>
        /// <param name="tenderModel"></param>
        /// <returns></returns>
        private List<ViewTenderModel> Tender(ViewTenderModel tenderModel)
        {
            try
            {
                objTenderlistviewmodel = _objITenderModel.ViewTopWebsiteTender(tenderModel);
                return objTenderlistviewmodel.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTenderlistviewmodel = null;
                tenderModel = null;
            }
        }
        #endregion
        #region GlobalLink
        /// <summary>
        /// Get Top menu list
        /// </summary>
        /// <returns></returns>
        public string GetTopmenulist()
        {
            string Topmenu = "";
            objAddGloballinkModel = _objIGlobalLinkModel.WebsiteMenu(objAddGloballinkModel);
            Topmenu = Getmenulist(objAddGloballinkModel.VCH_TOPMENU_ID, objAddGloballinkModel.VCH_TOPMENU_URL, null);
            return Topmenu;
        }
        /// <summary>
        /// Get Main menu list
        /// </summary>
        /// <returns></returns>
        public string GetMainmenulist()
        {
            string Mainmenu = "";
            objAddGloballinkModel = _objIGlobalLinkModel.WebsiteMenu(objAddGloballinkModel);
            Mainmenu = Getmenulist(objAddGloballinkModel.VCH_MAINMENU_ID, objAddGloballinkModel.VCH_MAINMENU_URL, "Main");
            return Mainmenu;
        }
        /// <summary>
        /// Get Footer menu list
        /// </summary>
        /// <returns></returns>
        public string GetFootermenulist()
        {
            string Footermenu = "";
            objAddGloballinkModel = _objIGlobalLinkModel.WebsiteMenu(objAddGloballinkModel);
            Footermenu = Getmenulist(objAddGloballinkModel.VCH_FOOTERMENU_ID, objAddGloballinkModel.VCH_FOOTERMENU_URL, null);
            return Footermenu;
        }
        /// <summary>
        /// Bind Menu list details in Website view
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="url"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string Getmenulist(string menu, string url, string type)
        {
            string s = "";
            if (menu != null)
            {
                string[] ValuemultiArray = menu.Split(new Char[] { ',' });
                string[] UrlmultiArray = url.Split(new Char[] { ',', '-', '\n', '\t', '[', ']', '"' });
                int colLA = 0;
                for (int i = 0; i < ValuemultiArray.Count(); i++)
                {
                    if (ValuemultiArray[i].Trim() != "")
                    {
                        for (int j = 0; j < UrlmultiArray.Count(); j++)
                        {
                            int k = 1;
                            j = colLA;
                            if (UrlmultiArray[j].Trim() != "")
                            {
                                if (type == "Main")
                                {
                                    if (ValuemultiArray[i].Contains("About Us"))
                                    {
                                        objAddPageModel.VCH_ACTION = "ABOUTUS";
                                        objAddPageModellist = _objIGlobalLinkModel.WebsiteChildMenu(objAddPageModel);
                                        if (objAddPageModellist.Count > 0)
                                        {
                                            s += "<li class='nav-item dropdown about'>";
                                            s += "<a class='nav-link dropdown-toggle' href='#' id='A1' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>" + _sharedLocalizer[ValuemultiArray[i]] + "</a>";
                                            s += "<div class='dropdown-menu' aria-labelledby='navbarDropdown'>";
                                            for (var childmenu = 0; childmenu < objAddPageModellist.Count; childmenu++)
                                            {
                                                if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 1 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 1)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 0 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 0)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "' target='_blank'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 1 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 0)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "' target='_blank'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 0 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 1)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else
                                                {
                                                    s += "<a class='dropdown-item introduction' href='/" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                            }
                                            s += "</div>";
                                            s += "</li>";
                                        }
                                    }
                                    else if (ValuemultiArray[i].Contains("Registration"))
                                    {
                                        objAddPageModel.VCH_ACTION = "REGISTRATION";
                                        objAddPageModellist = _objIGlobalLinkModel.WebsiteChildMenu(objAddPageModel);
                                        if (objAddPageModellist.Count > 0)
                                        {
                                            s += "<li class='nav-item dropdown reg-app'>";
                                            s += "<a class='nav-link dropdown-toggle' href='#' id='A2' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>" + _sharedLocalizer[ValuemultiArray[i]] + "</a>";
                                            s += "<div class='dropdown-menu' aria-labelledby='navbarDropdown'>";
                                            for (var childmenu = 0; childmenu < objAddPageModellist.Count; childmenu++)
                                            {
                                                if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 1 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 1)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 0 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 0)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "' target='_blank'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 1 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 0)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "' target='_blank'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 0 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 1)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else
                                                {
                                                    s += "<a class='dropdown-item introduction' href='/" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                            }
                                            s += "</div>";
                                            s += "</li>";
                                        }
                                    }
                                    else
                                    {
                                        s += "<li class='nav-item'>";
                                        s += "<a class='nav-link' href='" + UrlmultiArray[j] + "'>" + _sharedLocalizer[ValuemultiArray[i]] + "</a>";
                                        s += "</li>";
                                    }
                                }
                                else
                                {
                                    s += "<li>";
                                    s += "<a href='" + UrlmultiArray[j] + "'>" + _sharedLocalizer[ValuemultiArray[i]] + "</a>";
                                    s += "</li>";
                                }
                            }
                            if (k == 1)
                                break;
                        }
                    }
                    colLA++;
                }
            }
            return s;
        }
        #endregion
        #region Banner
        /// <summary>
        /// For Banner
        /// </summary>
        /// <param name="bannerModel"></param>
        /// <returns></returns>
        private List<ViewBannerModel> Banner(ViewBannerModel bannerModel)
        {
            objbannerlist = _objIBannerModel.ViewWebsiteBanner(bannerModel);
            return objbannerlist.ToList();
        }
        #endregion
        #region Gallery
        /// <summary>
        /// For Gallery
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        private List<ViewGalleryModel> Gallery(ViewGalleryModel objViewGalleryModel)
        {
            objGalleryLsit = _objgalleryModel.ViewWebsiteGallery(objViewGalleryModel);
            return objGalleryLsit.ToList();
        }
        #endregion
        #region for Notice
        private List<WebNotice> Notices(WebNotice webNotice)
        {
            try
            {
                objnoticeModelsList = _objnoticeModel.ViewWebsiteNotice(webNotice);
                return objnoticeModelsList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objnoticeModelsList = null;

            }
        }
        #endregion
        #region For Mineral Map
        [SkipSessionTask]
        public IActionResult MapDetails()
        {
            ViewData["MainmenuTable"] = GetMainmenulist();
            ViewData["FootermenuTable"] = GetFootermenulist();
            return View();
        }
        #endregion
        /// <summary>
        /// For Feedback from home page
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [SkipSessionTask]
        public IActionResult Home(AddFeedbackModel objmodel, string submit)
        {
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.FULL_NAME))
                {
                    ModelState.AddModelError("FULL_NAME", "Full Name is Required");
                }
                if (string.IsNullOrEmpty(objmodel.MAIL_ID))
                {
                    ModelState.AddModelError("MAIL_ID", "Mail Id is Required");
                }
                if (string.IsNullOrEmpty(objmodel.FEEDBACK))
                {
                    ModelState.AddModelError("FEEDBACK", "Feedback is Required");
                }
                
                #endregion
                if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        objMessage = _objFeedbackModel.Add(objmodel);
                        if (objMessage.Satus == "1")
                            TempData["Message"] = "Thank You For Your Valueable Feedback.";
                    }
                    return RedirectToAction("Home");
                }
                else
                {
                    ViewData["TopmenuTable"] = GetTopmenulist();
                    ViewData["MainmenuTable"] = GetMainmenulist();
                    ViewData["FootermenuTable"] = GetFootermenulist();
                    ViewBag.Banner = Banner(objViewBannerModel);
                    ViewBag.Gallery = Gallery(objViewGallerymodel);
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [SkipSessionTask]
        public IActionResult CommercialLabAnalysis()
        {
            //ViewData["TopmenuTable"] = GetTopmenulist();
            ViewData["MainmenuTable"] = GetMainmenulist();
            ViewData["FootermenuTable"] = GetFootermenulist();
            return View();
        }
        [SkipSessionTask]
        public JsonResult ViewMineralMap(int DistrictId)
        {
            try
            {
                objViewMineralMapModel.DistrictID = DistrictId;
                objViewMineralMapModel = _objIMineralMapModel.ViewMineralMapCount(objViewMineralMapModel);
                return Json(objViewMineralMapModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objViewMineralMapModel = null;
            }
        }
        [SkipSessionTask]
        public JsonResult BindDistrict()
        {
            try
            {
                objViewMineralMapModel.RegionalID = 7;
                objViewMineralMapModellist = _objIMineralMapModel.View(objViewMineralMapModel);
                return Json(objViewMineralMapModellist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objViewMineralMapModel = null;
                objViewMineralMapModellist = null;
            }
        }
    }
}
