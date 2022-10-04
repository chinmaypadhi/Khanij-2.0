// ***********************************************************************
//  Controller Name          : ProfileController
//  Desciption               : Lessee Profile Dashboard Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 10 Feb 2022
// ***********************************************************************
using MasterApp.ActionFilter;
using MasterApp.Areas.LesseeProfile.Models.AssessmentReportDetails;
using MasterApp.Areas.LesseeProfile.Models.CTEDetails;
using MasterApp.Areas.LesseeProfile.Models.CTODetails;
using MasterApp.Areas.LesseeProfile.Models.EnvironmentClearanceDetails;
using MasterApp.Areas.LesseeProfile.Models.ForestClearanceDetails;
using MasterApp.Areas.LesseeProfile.Models.GrantOrderDetails;
using MasterApp.Areas.LesseeProfile.Models.IBMDetails;
using MasterApp.Areas.LesseeProfile.Models.LeaseAreaDetails;
using MasterApp.Areas.LesseeProfile.Models.LesseeDetails;
using MasterApp.Areas.LesseeProfile.Models.LesseeMiningPlan;
using MasterApp.Areas.LesseeProfile.Models.MineralInformation;
using MasterApp.Areas.LesseeProfile.Models.OfficeDetails;
using MasterApp.Areas.LesseeProfile.Models.Profile;
using MasterApp.Model.ExceptionList;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterApp.Areas.LesseeProfile.Controllers
{
    [Area("LesseeProfile")]
    public class ProfileController : Controller
    {
        /// <summary>
        /// Global Variable,object declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        private readonly IExceptionProvider _objIExceptionProvider;
        ILesseeOfficeMasterModel _objILesseeOfficeMasterModel;
        ILesseeDetailsModel _objILesseeDetailsModel;
        ILesseeGrantOrderModel _objLesseeGrantOrderModel;
        ILesseeLeaseAreaModel _objILesseeLeaseAreaModel;
        IMineralInformationModel _objIMineralInformationModel;
        ILesseeForestClearanceModel _objILesseeForestClearanceModel;
        ILesseeIBMModelDetails _objILesseeIBMModelDetails;
        ILesseeMiningPlanModel _objILesseeMiningPlanModel;
        ILesseEnvironmentClearanceModel _objILesseEnvironmentClearanceModel;
        ILesseeCTEModel _objILesseeCTEModel;
        ILesseeCTOModel _objILesseeCTOModel;
        ILesseeAssessmentReportModel _objILesseeAssessmentReportModel;
        IProfileModel _objIProfileModel;
        OfficeMasterViewModel objOfficeMasterViewModel = new OfficeMasterViewModel();
        LesseeInfoModel objLesseeInfoModel = new LesseeInfoModel();
        GrantOrderViewModel objGrantOrderViewModel = new GrantOrderViewModel();
        LeaseAreaViewModel objLeaseAreaViewModel = new LeaseAreaViewModel();
        LesseeMineralInformationModel objLesseeMineralInformationModel = new LesseeMineralInformationModel();
        LesseeIBMDetailsViewModel objLesseeIBMDetailsViewModel = new LesseeIBMDetailsViewModel();
        LesseeMiningPlanViewModel objLesseeMiningPlanViewModel = new LesseeMiningPlanViewModel();
        LesseeForestClearanceViewModel objLesseeForestClearanceViewModel = new LesseeForestClearanceViewModel();
        LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceViewModel = new LesseeEnvironmentClearanceViewModel();
        LesseeCTEViewModel objLesseeCTEViewModel = new LesseeCTEViewModel();
        LesseeCTOViewModel objLesseeCTOViewModel = new LesseeCTOViewModel();
        LesseeAssessmentReportViewModel objLesseeAssessmentReportViewModel = new LesseeAssessmentReportViewModel();
        LesseeProfileIndividualCountModel objmodel = new LesseeProfileIndividualCountModel();
        List<LesseeProfileIndividualCountModel> objlistmodel = new List<LesseeProfileIndividualCountModel>();
        LesseeListForDGMModel objLesseeDGMmodel = new LesseeListForDGMModel();
        List<LesseeListForDGMModel> objLesseelistDGMmodel = new List<LesseeListForDGMModel>();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIProfileModel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        /// <param name="objLesseeGrantOrderModel"></param>
        public ProfileController(IHostingEnvironment hostingEnvironment, IConfiguration configuration, ILesseeGrantOrderModel objLesseeGrantOrderModel, ILesseeDetailsModel objILesseeDetailsModel, ILesseeOfficeMasterModel objILesseeOfficeMasterModel, ILesseeForestClearanceModel objILesseeForestClearanceModel
            , ILesseeLeaseAreaModel objILesseeLeaseAreaModel, IMineralInformationModel objIMineralInformationModel, ILesseeIBMModelDetails objILesseeIBMModelDetails, ILesseeMiningPlanModel objILesseeMiningPlanModel, ILesseEnvironmentClearanceModel objILesseEnvironmentClearanceModel
            , ILesseeCTEModel objILesseeCTEModel, ILesseeCTOModel objILesseeCTOModel, ILesseeAssessmentReportModel objILesseeAssessmentReportModel, IProfileModel objIProfileModel, IExceptionProvider objIExceptionProvider)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            _objLesseeGrantOrderModel = objLesseeGrantOrderModel;
            _objILesseeDetailsModel = objILesseeDetailsModel;
            _objILesseeOfficeMasterModel = objILesseeOfficeMasterModel;
            _objILesseeLeaseAreaModel = objILesseeLeaseAreaModel;
            _objIMineralInformationModel = objIMineralInformationModel;
            _objILesseeIBMModelDetails = objILesseeIBMModelDetails;
            _objILesseeMiningPlanModel = objILesseeMiningPlanModel;
            _objILesseeForestClearanceModel = objILesseeForestClearanceModel;
            _objILesseEnvironmentClearanceModel = objILesseEnvironmentClearanceModel;
            _objILesseeCTEModel = objILesseeCTEModel;
            _objILesseeCTOModel = objILesseeCTOModel;
            _objILesseeAssessmentReportModel = objILesseeAssessmentReportModel;
            _objIProfileModel = objIProfileModel;
            _objIExceptionProvider = objIExceptionProvider;
        }
        /// <summary>
        /// Lessee Profile Dashboard details
        /// </summary>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Dashboard(string Userid, string MineralType, string LeaseCode, string ApplicantName, string Devicetype)
        {
            UserLoginSession profile = new UserLoginSession();
            if (!string.IsNullOrEmpty(Convert.ToString(Userid)) && !string.IsNullOrEmpty(Devicetype))
            {
                profile.UserId = Convert.ToInt32(Userid);
            }
            else if (!string.IsNullOrEmpty(Convert.ToString(Userid)) && !string.IsNullOrEmpty(MineralType)) //For Other than Lessee User Login
            {
                profile.UserId = Convert.ToInt32(Userid);
                profile.MineralTypeName = MineralType;
                ViewBag.UserId = profile.UserId;
                ViewBag.LeaseCode = LeaseCode;
                ViewBag.ApplicantName = ApplicantName;
            }
            else
            {
                profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            }

            ViewBag.dashBoardUserModel = GetUserDetails(profile.UserId,profile.MineralTypeName);
            ViewBag.lease = GetApplicationDetails(profile.UserId);
            ViewBag.dashBoardGrantOrderModel = await GetGrantOrderDetails(profile.UserId);
            ViewBag.dashBoardLeaseAreaModel = await GetLeaseDetails(profile.UserId);
            ViewBag.dashBoardMineralInfoModel = await GetMineralDetails(profile.UserId);
            ViewBag.dashboardIBM = await GetIBMDetails(profile.UserId);
            ViewBag.dashBoardMiningPlanModel = await GetMiningPlanDetails(profile.UserId);
            ViewBag.forestClearanceViewModel = await GetForestClearanceDetails(profile.UserId);
            ViewBag.dashBoardEnvironmentClearanceModel = await GetEnvironmentClearanceDetails(profile.UserId);
            ViewBag.consentToEstablish = await GetCTEDetails(profile.UserId);
            ViewBag.consentToOperate = await GetCTODetails(profile.UserId);
            ViewBag.AssessmentReport = await GetAssessmentReportDetails(profile.UserId);
            ViewBag.ProfilePercentage = GetProfileCompletionCount(profile.UserId, profile.MineralTypeName);
            return View();
        }
        /// <summary>
        /// Get Lessee User details
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="MineralTypeName"></param>
        /// <returns></returns>
        public OfficeMasterViewModel GetUserDetails(int? UserId,string MineralTypeName)
        {
            try
            {
                objOfficeMasterViewModel.User_Id = UserId;
                objOfficeMasterViewModel.MineralTypeName = MineralTypeName;
                objOfficeMasterViewModel = _objILesseeOfficeMasterModel.GetOfficeMasterDetails(objOfficeMasterViewModel);
                return objOfficeMasterViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objOfficeMasterViewModel = null;
            }
        }
        /// <summary>
        /// Get Lessee Application details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public LesseeInfoModel GetApplicationDetails(int? UserId)
        {
            try
            {
                objLesseeInfoModel.CREATED_BY = UserId;
                objLesseeInfoModel = _objILesseeDetailsModel.GetLesseeProfileDetails(objLesseeInfoModel);
                return objLesseeInfoModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objLesseeInfoModel = null;
            }
        }
        /// <summary>
        /// Get Lessee Application details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<GrantOrderViewModel> GetGrantOrderDetails(int? UserId)
        {
            try
            {
                objGrantOrderViewModel.UserId = UserId;
                objGrantOrderViewModel = await _objLesseeGrantOrderModel.GetGrantOrderDetails(objGrantOrderViewModel);
                return objGrantOrderViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objGrantOrderViewModel = null;
            }
        }
        /// <summary>
        /// Get Lessee Lease Area details
        /// </summary>
        /// <returns></returns>
        public async Task<LeaseAreaViewModel> GetLeaseDetails(int? UserId)
        {
            try
            {
                objLeaseAreaViewModel.CREATED_BY = UserId;
                objLeaseAreaViewModel = await _objILesseeLeaseAreaModel.GetLeaseAreaDetails(objLeaseAreaViewModel);
                return objLeaseAreaViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objLeaseAreaViewModel = null;
            }
        }
        /// <summary>
        /// Get Lessee Mineral Information details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<LesseeMineralInformationModel> GetMineralDetails(int? UserId)
        {
            try
            {
                objLesseeMineralInformationModel.CREATED_BY = UserId;
                objLesseeMineralInformationModel = await _objIMineralInformationModel.GetMineralInformationDetails(objLesseeMineralInformationModel);
                return objLesseeMineralInformationModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objLesseeMineralInformationModel = null;
            }
        }
        /// <summary>
        /// Get Lessee IBM details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<LesseeIBMDetailsViewModel> GetIBMDetails(int? UserId)
        {
            try
            {
                objLesseeIBMDetailsViewModel.CREATED_BY = UserId;
                objLesseeIBMDetailsViewModel = await _objILesseeIBMModelDetails.GetIBMDetails(objLesseeIBMDetailsViewModel);
                return objLesseeIBMDetailsViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objLesseeIBMDetailsViewModel = null;
            }
        }
        /// <summary>
        /// Get Lessee Mining Plan details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<LesseeMiningPlanViewModel> GetMiningPlanDetails(int? UserId)
        {
            try
            {
                objLesseeMiningPlanViewModel.CREATED_BY = UserId;
                objLesseeMiningPlanViewModel = await _objILesseeMiningPlanModel.GetMiningPlanDetails(objLesseeMiningPlanViewModel);
                return objLesseeMiningPlanViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objLesseeMiningPlanViewModel = null;
            }
        }
        /// <summary>
        /// Get Lessee Forest Clearance details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<LesseeForestClearanceViewModel> GetForestClearanceDetails(int? UserId)
        {
            try
            {
                objLesseeForestClearanceViewModel.CREATED_BY = UserId;
                objLesseeForestClearanceViewModel = await _objILesseeForestClearanceModel.GetForestClearanceDetails(objLesseeForestClearanceViewModel);
                return objLesseeForestClearanceViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objLesseeForestClearanceViewModel = null;
            }
        }
        /// <summary>
        /// Get Lessee Environment Clearance details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<LesseeEnvironmentClearanceViewModel> GetEnvironmentClearanceDetails(int? UserId)
        {
            try
            {
                objLesseeEnvironmentClearanceViewModel.CREATED_BY = UserId;
                objLesseeEnvironmentClearanceViewModel = await _objILesseEnvironmentClearanceModel.GetEnvironmentClearanceDetails(objLesseeEnvironmentClearanceViewModel);
                return objLesseeEnvironmentClearanceViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objLesseeEnvironmentClearanceViewModel = null;
            }
        }
        /// <summary>
        /// Get Lessee CTE details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<LesseeCTEViewModel> GetCTEDetails(int? UserId)
        {
            try
            {
                objLesseeCTEViewModel.CREATED_BY = UserId;
                objLesseeCTEViewModel = await _objILesseeCTEModel.GetCTEDetails(objLesseeCTEViewModel);
                return objLesseeCTEViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objLesseeCTEViewModel = null;
            }
        }
        /// <summary>
        /// Get Lessee CTO details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<LesseeCTOViewModel> GetCTODetails(int? UserId)
        {
            try
            {
                objLesseeCTOViewModel.CREATED_BY = UserId;
                objLesseeCTOViewModel = await _objILesseeCTOModel.GetCTODetails(objLesseeCTOViewModel);
                return objLesseeCTOViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objLesseeCTOViewModel = null;
            }
        }
        /// <summary>
        /// Get Lessee Assessment Report details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<LesseeAssessmentReportViewModel> GetAssessmentReportDetails(int? UserId)
        {
            try
            {
                objLesseeAssessmentReportViewModel.CREATED_BY = UserId;
                objLesseeAssessmentReportViewModel = await _objILesseeAssessmentReportModel.GetAssessmentReportDetails(objLesseeAssessmentReportViewModel);
                return objLesseeAssessmentReportViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objLesseeAssessmentReportViewModel = null;
            }
        }
        /// <summary>
        /// Bind Profile Completion Count Details in view
        /// </summary>
        /// <returns></returns>
        public LesseeInfoModel GetProfileCompletionCount(int? UserId,string MineralTypeName)
        {
            LesseeInfoModel objmodel = new LesseeInfoModel();
            try
            {
                objmodel.CREATED_BY = UserId;
                objmodel.MineralType = MineralTypeName;
                objmodel = _objIProfileModel.GetProfileCompletionCount(objmodel);
                return objmodel;
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
        /// Bind All Lessee Profile Request Count details in view
        /// </summary>
        /// <returns></returns>
        [Decryption]
        public IActionResult AllRequest(string MMenuId = "0")
        {
            try
            {
                HttpContext.Session.SetInt32("MMenuId", Convert.ToInt32(MMenuId));
                HttpContext.Session.Set<List<MenuEF>>("Index", GetIndexMenuList());
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                //objmodel.IndividualId = Convert.ToInt32(id);
                objmodel = _objIProfileModel.GetLesseeProfileIndividualCountModel(objmodel);
                ViewBag.LesseeUser = GetLesseeLicenseeUserByDistrict();
                return View(objmodel);
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
        /// Bind Lessee Licensee User List details by District in view
        /// </summary>
        /// <returns></returns>
        private SelectList GetLesseeLicenseeUserByDistrict()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                objmodel.UserTypeName = "Lessee";
                objlistmodel = _objIProfileModel.GetLesseeLicneseeUserByDistrict(objmodel);
                return new SelectList(objlistmodel, "UserId", "ApplicantName");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objlistmodel = null;
            }
        }
        /// <summary>
        /// Bind Indvidual Lessee Count details in view 
        /// </summary>
        /// <param name="IndiviudalId"></param>
        /// <returns></returns>
        public JsonResult GetIndividualCount(int? IndiviudalId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = profile.UserId;
            objmodel.IndividualId = IndiviudalId;
            objmodel=_objIProfileModel.GetLesseeProfileIndividualCountModel(objmodel);
            HttpContext.Session.SetInt32("LeeseeUserId", Convert.ToInt32(IndiviudalId));
            return Json(objmodel);
        }
        /// <summary>
        /// Bind Encrypted Url of Request
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="IndiviudalId"></param>
        /// <returns></returns>
        public JsonResult ProfileRequestUrl(string Request,int? IndiviudalId)
        {
            string EncryptUrl = CustomQueryStringHelper.EncryptString("LesseeProfile", "ViewApplicationDetails", "LesseeDetails", new { Request = Request, LesseeUserId = Convert.ToString(IndiviudalId) });
            return Json(EncryptUrl);
        }
        /// <summary>
        /// Bind Menu list details in leftsider
        /// </summary>
        /// <returns></returns>
        public List<MenuEF> GetIndexMenuList()
        {
            List<MenuEF> Listmenu = new List<MenuEF>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            menuonput objmenu = new menuonput();
            try
            {
                objmenu.UserID = Convert.ToInt32(profile.UserId);
                objmenu.MineralId = Convert.ToInt32(profile.MineralId);
                objmenu.MineralName = profile.MineralName;
                objmenu.MMenuId = HttpContext.Session.GetInt32("MMenuId");
                Listmenu = _objIExceptionProvider.MenuList(objmenu);
                return Listmenu;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Listmenu = null;
                objmenu = null;
            }
        }
        #region For Login other than Lessee
        /// <summary>
        /// To Bind Lessee Users by User,Role type in view
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewLesseeList()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objLesseeDGMmodel.UserId = profile.UserId;
                objLesseeDGMmodel.RoleTypeName = "Lessee";
                objLesseelistDGMmodel = _objIProfileModel.GetLesseeListDGM(objLesseeDGMmodel);
                return View(objLesseelistDGMmodel);
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                objLesseeDGMmodel = null;
                objLesseelistDGMmodel = null;
            }
        }
        #endregion
    }
}
