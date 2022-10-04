// ***********************************************************************
//  Controller Name          : eReturnProcess
//  Desciption               : eReturn Form1 Details 
//  Created By               : Debaraj Swain
//  Created On               : 30 July 2021
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
using ReturnApp.Web;
using Microsoft.AspNetCore.DataProtection;

namespace ReturnApp.Areas.eReturn_NonCoal.Controllers
{
    [Area("eReturn_NonCoal")]
    public class eReturnProcessController : Controller
    {
        IeReturnNonCoalModel _objIeReturnNonCoalModel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        private readonly IDataProtectionProvider dataProtectionProvider;
        private readonly IDataProtector protector;
        MessageEF objobjmodel = new MessageEF();
        int SessionUID = int.Parse(ConfigurationManager.MySettings["MySettings:SessionUID"]);
        public eReturnProcessController(IeReturnNonCoalModel objeReturnNonCoalModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration, IDataProtectionProvider dataProtectionProvider)
        {
            _objIeReturnNonCoalModel = objeReturnNonCoalModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            this.dataProtectionProvider = dataProtectionProvider;
            protector = dataProtectionProvider.CreateProtector(configuration.GetSection("Encryption").GetValue<string>("EncryptionKey"));
        }

        /// <summary>
        /// eReturn DashBoard
        /// </summary>
        /// <returns>View</returns>
        public IActionResult eReturnDashboard()
        {
            if (TempData["result"] != null)
            {
                //Response.Write("<script>alert('" + TempData["result"].ToString() + "')</script>");
            }
            MonthlyReturnModelNonCoal objmodel = new MonthlyReturnModelNonCoal();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.Uid = profile.UserId;
            //objmodel.Uid = 194;//(F1)
            //objmodel.Uid = 132;//(F2)
            //objmodel.Uid =150;//(Coal Monthly)
            var x = _objIeReturnNonCoalModel.GetFyDDL(objmodel);
            if (x.GetDDL != null)
            {
                ViewBag.ViewFYList = x.GetDDL.Select(c => new SelectListItem
                {
                    Text = c.Year,
                    Value = c.Year.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewFYList = Enumerable.Empty<SelectListItem>();
            }

            return View();
        }

        /// <summary>
        /// Get Monthly Return Details
        /// </summary>
        /// <param name="FinancialYear"></param>
        /// <returns>Json String</returns>
        public JsonResult GetMonthlyReturn(string FinancialYear)
        {
            try
            {
                MonthlyReturnModelNonCoal objmodel = new MonthlyReturnModelNonCoal();
                // List<MonthlyReturnModelNonCoal> List = new List<MonthlyReturnModelNonCoal>();
                objmodel.Year = FinancialYear;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.Uid = profile.UserId;
                //objmodel.Uid = 194;//(F1)
                //objmodel.Uid = 132;//(F2)
                //objmodel.Uid = 150;//(Coal Monthly)
                var List = _objIeReturnNonCoalModel.ViewLst(objmodel)
                    .Select
                     (e =>
                     {
                         e.EncryptedId = protector.Protect(e.MonthYear);
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
        /// Get Portion of Part1
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <returns>View</returns> 
        public ActionResult PartOne(string MonthYear)
        {
            MonthlyReturnModelNonCoal objmodel = new MonthlyReturnModelNonCoal();
            GetFormF1DetailsModel data = new GetFormF1DetailsModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.Uid = profile.UserId;
            //objmodel.Uid = 194;
            data = _objIeReturnNonCoalModel.GetLesseMineDeatils(objmodel);
            TempData["M_Y"] = MonthYear;
            TempData.Keep("MonthYear");
            ViewBag.Month_Year = protector.Unprotect(MonthYear);
            return View(data);
        }

        /// <summary>
        /// Get Return Details
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <returns>Json String</returns>
        public JsonResult GetReturn(string Month_Year)
        {
            MonthlyReturnModelNonCoal objmodel = new MonthlyReturnModelNonCoal();
            GetFormF1DetailsModel data = new GetFormF1DetailsModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.Uid = profile.UserId;
            //objmodel.Uid = 194;
            objmodel.MonthYear = Month_Year;
            data = _objIeReturnNonCoalModel.GeteReturnSubmittedDetails(objmodel);
            return Json(data);
        }

        /// <summary>
        /// Get Lessee Monthly Rent Rotalty Details
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <returns>Json String</returns>
        public JsonResult GetLesseeMonthRentRoyaltyDetails(string Month_Year)
        {
            MonthlyReturnModelNonCoal objmodel = new MonthlyReturnModelNonCoal();
            GetRentRoyaltyDetailsModel data = new GetRentRoyaltyDetailsModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.Uid = profile.UserId;
            //objmodel.Uid = 194;
            objmodel.MonthYear = Month_Year;
            data = _objIeReturnNonCoalModel.GetRentRoyalty(objmodel);
            return Json(data);
        }

        /// <summary>
        /// Post portion of PArt1 of Form1
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Work_Id"></param>
        /// <param name="NoOfDaysWorkStop"></param>
        /// <param name="Reason"></param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult AddPartOneF1(GetFormF1DetailsModel data, List<int> Work_Id, List<int> NoOfDaysWorkStop, List<string> Reason)
        {
            if (data.Flag == 1)
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                data.UserID = profile.UserId;
                //data.UserID = 194;
                data.intwork = Work_Id;
                data.intwork = NoOfDaysWorkStop;
                data.intNoOfDaysWorkStop = NoOfDaysWorkStop;
                data.strReason = Reason;
                objobjmodel = _objIeReturnNonCoalModel.UpdateRoyaltyDetails(data);
                TempData["result"] = objobjmodel.Msg;
                return RedirectToAction("eReturnDashboard");
            }
            else
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                data.UserID = profile.UserId;
                //data.UserID = 194;
                data.intwork = NoOfDaysWorkStop;
                data.intNoOfDaysWorkStop = NoOfDaysWorkStop;
                data.strReason = Reason;
                objobjmodel = _objIeReturnNonCoalModel.AddRoyaltyDetails(data);
                TempData["result"] = objobjmodel.Msg;
                return RedirectToAction("eReturnDashboard");

            }
        }

        /// <summary>
        /// Get Portion of Part2
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns>View</returns>
        public ActionResult PartTwo(string MonthYear, int? UserId)
        {
            if (TempData["result"] != null)
            {
                // Response.Write("<script>alert('" + TempData["result"].ToString() + "')</script>");
            }
            TempData["M_Y"] = MonthYear;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            TempData["UID"] = profile.UserId;
            //TempData["UID"] = 194;

            TempData.Keep("M_Y");
            TempData.Keep("UID");
            GetFormF1DetailsModel data = new GetFormF1DetailsModel();
            MonthlyReturnModelNonCoal objmodel = new MonthlyReturnModelNonCoal();
            objmodel.Uid = profile.UserId;
            //objmodel.Uid = 194;
            data = _objIeReturnNonCoalModel.GetMineralInfo(objmodel);
            string str = data.MineralName;
            int MineralId = data.MineralID;
            ViewBag.Mineral = str;
            ViewBag.MineralId = MineralId;
            ViewBag.Month_Year = protector.Unprotect(MonthYear);

            objmodel = new MonthlyReturnModelNonCoal();
            objmodel.Uid = profile.UserId;
            //objmodel.Uid = 194;
            objmodel.MineralId = ViewBag.MineralId;
            var xx = _objIeReturnNonCoalModel.GetMineralForm(objmodel);
            if (xx.GetDDL != null)
            {
                ViewBag.MineralNature = xx.GetDDL.Select(c => new SelectListItem
                {
                    Text = c.MineralNature,
                    Value = c.MineralNatureId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.MineralNature = Enumerable.Empty<SelectListItem>();
            }

            objmodel = new MonthlyReturnModelNonCoal();
            objmodel.Uid = profile.UserId;
            //objmodel.Uid = 194;
            objmodel.MineralId = ViewBag.MineralId;
            TempData["MineralID"] = ViewBag.MineralId;
            TempData.Keep("MineralID");
            var Productionddl = _objIeReturnNonCoalModel.GetMineralFormProduction(objmodel);
            if (Productionddl.GetDDL != null)
            {
                ViewBag.MineralNatureProd = Productionddl.GetDDL.Select(c => new SelectListItem
                {
                    Text = c.MineralNature,
                    Value = c.MineralNatureId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.MineralNatureProd = Enumerable.Empty<SelectListItem>();
            }


            SalesDispatchModel objsd = new SalesDispatchModel();
            List<SalesDispatchModel> ListDP = new List<SalesDispatchModel>();
            ListDP = _objIeReturnNonCoalModel.GetNatureOfDispatch(objsd);
            if (ListDP.Count > 0)
            {
                ViewBag.NatureofDisp = ListDP.Select(c => new SelectListItem
                {
                    Text = c.NatureofDispatch,
                    Value = c.NatureofDispatch.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.NatureofDisp = Enumerable.Empty<SelectListItem>();
            }

            objmodel = new MonthlyReturnModelNonCoal();
            objmodel.Uid = profile.UserId;
            //objmodel.Uid = 194;
            ListDP = new List<SalesDispatchModel>();
            ListDP = _objIeReturnNonCoalModel.GetPurchaserConsignee(objmodel);
            if (ListDP.Count > 0)
            {
                ViewBag.PurcConsig = ListDP.Select(c => new SelectListItem
                {
                    Text = c.PurchaserConsinee,
                    Value = c.PurchaserConsineeId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.PurcConsig = Enumerable.Empty<SelectListItem>();
            }


            return View();
        }

        /// <summary>
        /// Get Production Details
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <returns>Json String</returns>
        public JsonResult GetProduction(string MonthYear)
        {
            MonthlyPartTwoViewModel objViewModel = new MonthlyPartTwoViewModel();
            MonthlyReturnModelNonCoal objmodel = new MonthlyReturnModelNonCoal();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.Uid = profile.UserId;
            //objmodel.Uid = 194;
            objmodel.MonthYear = MonthYear;
            objViewModel.objProduction = _objIeReturnNonCoalModel.GetProduction(objmodel);
            return Json(objViewModel);
        }

        /// <summary>
        /// Get Details Of Deduction
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="MineralId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetDetails_of_deductions(string MonthYear, int MineralId)
        {
            MonthlyPartTwoViewModel objViewModel = new MonthlyPartTwoViewModel();
            GetFormF1DetailsModel objmodel = new GetFormF1DetailsModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = profile.UserId;
            //objmodel.UserID = 194;
            objmodel.Month_Year = MonthYear;
            objmodel.MineralID = MineralId;
            objViewModel.objDeduction = _objIeReturnNonCoalModel.GetDetails_of_deductions(objmodel);
            return Json(objViewModel);
        }

        /// <summary>
        /// Get Reason
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="MineralId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetReason_Inc_Dec(string MonthYear, int MineralId)
        {
            MonthlyPartTwoViewModel objViewModel = new MonthlyPartTwoViewModel();
            GetFormF1DetailsModel objmodel = new GetFormF1DetailsModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = profile.UserId;
            //objmodel.UserID = 194;
            objmodel.Month_Year = MonthYear;
            objmodel.MineralID = MineralId;
            objViewModel.objReason_Inc_Dec = _objIeReturnNonCoalModel.GetReason_Inc_Dec(objmodel);
            return Json(objViewModel);
        }

        /// <summary>
        /// Get Pulverization Details
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <returns>Json String</returns>
        public JsonResult Getpulverization(string MonthYear)
        {
            MonthlyPartTwoViewModel objViewModel = new MonthlyPartTwoViewModel();
            GetFormF1DetailsModel objmodel = new GetFormF1DetailsModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = profile.UserId;
            //objmodel.UserID = 194;
            objmodel.Month_Year = MonthYear;
            objViewModel.objDeduction = _objIeReturnNonCoalModel.Getpulverization(objmodel);
            return Json(objViewModel);
        }

        /// <summary>
        /// Get Opening Stock Details
        /// </summary>
        /// <param name="MineralId"></param>
        /// <param name="MonthYear"></param>
        /// <returns>Json String</returns>
        public JsonResult GetOpeningStock(int MineralId, string MonthYear)
        {
            MonthlyPartTwoViewModel data = new MonthlyPartTwoViewModel();
            GetFormF1DetailsModel objmodel = new GetFormF1DetailsModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = profile.UserId;
            //objmodel.UserID = 194;
            objmodel.Month_Year = MonthYear;
            objmodel.MineralID = MineralId;
            data.objProduction = _objIeReturnNonCoalModel.OpeningStock(objmodel);
            return Json(data);
        }

        /// <summary>
        /// Get Grade List
        /// </summary>
        /// <param name="intMineralFormID"></param>
        /// <returns>Json String</returns>
        public JsonResult GetGradeList(int intMineralFormID)
        {
            MonthlyReturnModelNonCoal objGrade = null;
            try
            {
                objGrade = new MonthlyReturnModelNonCoal();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objGrade.Uid = profile.UserId;
                //objGrade.Uid = 194;
                objGrade.MineralNatureId = intMineralFormID;
                var x = _objIeReturnNonCoalModel.GetMineralGrade(objGrade);
                var SList = x.GetDDL.ToList();
                return Json(SList);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objGrade = null;
            }

        }

        /// <summary>
        /// Add Grade Wise ROM
        /// </summary>
        /// <param name="mineralform"></param>
        /// <param name="mineralGrade"></param>
        /// <param name="desp"></param>
        /// <param name="ExMinesprice"></param>
        /// <param name="monthYear"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult ADDGradewise_ROM(int mineralform, int mineralGrade, decimal desp, decimal ExMinesprice, string monthYear, int UID)
        {
            try
            {
                string result;
                Gradewise_ROMModel objModel = new Gradewise_ROMModel();
                objModel.MineralNatureId8 = mineralform;
                objModel.MineralGradeId8 = mineralGrade;
                objModel.Despatches_minehead = desp;
                objModel.Ex_mine_Price = ExMinesprice;
                objModel.Month_YearGradewise_ROM = monthYear;
                objModel.UID = UID;
                objobjmodel = _objIeReturnNonCoalModel.ADDGradewise_ROM(objModel);
                result = objobjmodel.Satus;
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Get Grade Wise ROM
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetGradewise_ROM(string MonthYear, int? UserId)
        {
            List<Gradewise_ROMModel> list = new List<Gradewise_ROMModel>();
            try
            {
                MonthlyReturnModelNonCoal model = new MonthlyReturnModelNonCoal();
                model.MonthYear = MonthYear;
                model.Uid = UserId;
                list = _objIeReturnNonCoalModel.GetGradewise_ROM(model);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// Update Grade Wise ROM
        /// </summary>
        /// <param name="ROMID"></param>
        /// <param name="mineralform"></param>
        /// <param name="mineralGrade"></param>
        /// <param name="desp"></param>
        /// <param name="ExMinesprice"></param>
        /// <param name="monthYear"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult UpdateGradewise_ROM(int ROMID, int mineralform, int mineralGrade, decimal desp, decimal ExMinesprice, string monthYear, int UID)
        {
            try
            {
                string result;
                Gradewise_ROMModel objModel = new Gradewise_ROMModel();
                objModel.GradeWiseRom_Id = ROMID;
                objModel.MineralNatureId8 = mineralform;
                objModel.MineralGradeId8 = mineralGrade;
                objModel.Despatches_minehead = desp;
                objModel.Ex_mine_Price = ExMinesprice;
                objModel.Month_YearGradewise_ROM = monthYear;
                objModel.UID = UID;
                objobjmodel = _objIeReturnNonCoalModel.UpdateGradewise_ROM(objModel);
                result = objobjmodel.Satus;
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete Grade wise ROM
        /// </summary>
        /// <param name="ROMID"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult DeleteGradewise_ROM(int ROMID, int UID)
        {
            try
            {
                string result;
                Gradewise_ROMModel objModel = new Gradewise_ROMModel();
                objModel.GradeWiseRom_Id = ROMID;
                objModel.UID = UID;
                objobjmodel = _objIeReturnNonCoalModel.UpdateGradewise_ROM(objModel);
                result = objobjmodel.Satus;
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Add Grade Wise Production
        /// </summary>
        /// <param name="mineralform"></param>
        /// <param name="mineralGrade"></param>
        /// <param name="OpeningStock_MineHead"></param>
        /// <param name="Production"></param>
        /// <param name="Dispatch_MineHead"></param>
        /// <param name="ClosingStock_MineHead"></param>
        /// <param name="Ex_MinePrice"></param>
        /// <param name="monthYear"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult ADDGradewise_Production(int mineralform, int mineralGrade, decimal OpeningStock_MineHead, decimal Production, decimal Dispatch_MineHead, decimal ClosingStock_MineHead, decimal Ex_MinePrice, string monthYear, int UID)
        {
            try
            {
                string result;
                Grade_WiseProduction objModel = new Grade_WiseProduction();
                objModel.MineralNatureId5 = mineralform;
                objModel.MineralGradeId5 = mineralGrade;
                objModel.OpeningStock_MineHead = OpeningStock_MineHead;
                objModel.Production = Production;
                objModel.Dispatch_MineHead = Dispatch_MineHead;
                objModel.ClosingStock_MineHead = ClosingStock_MineHead;
                objModel.Ex_MinePrice = Ex_MinePrice;
                objModel.Month_YearGradeWise = monthYear;
                objModel.UID = UID;
                objobjmodel = _objIeReturnNonCoalModel.ADDGradewise_Production(objModel);
                result = objobjmodel.Satus;
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Get Grade Wise Production
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetGrade_WiseProduction(string MonthYear, int? UserId)
        {
            List<Grade_WiseProduction> list = new List<Grade_WiseProduction>();
            try
            {
                MonthlyReturnModelNonCoal model = new MonthlyReturnModelNonCoal();
                model.MonthYear = MonthYear;
                model.Uid = UserId;
                list = _objIeReturnNonCoalModel.GetGrade_WiseProduction(model);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// Update Grade wise Production
        /// </summary>
        /// <param name="ProdID"></param>
        /// <param name="mineralform"></param>
        /// <param name="mineralGrade"></param>
        /// <param name="OpeningStock_MineHead"></param>
        /// <param name="Production"></param>
        /// <param name="Dispatch_MineHead"></param>
        /// <param name="ClosingStock_MineHead"></param>
        /// <param name="Ex_MinePrice"></param>
        /// <param name="monthYear"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult UpdateGradewise_Prod(int ProdID, int mineralform, int mineralGrade, decimal OpeningStock_MineHead, decimal Production, decimal Dispatch_MineHead, decimal ClosingStock_MineHead, decimal Ex_MinePrice, string monthYear, int UID)
        {
            try
            {
                string result;
                Grade_WiseProduction objModel = new Grade_WiseProduction();
                objModel.GradeWiseProduction_Id = ProdID;
                objModel.MineralNatureId5 = mineralform;
                objModel.MineralGradeId5 = mineralGrade;
                objModel.OpeningStock_MineHead = OpeningStock_MineHead;
                objModel.Production = Production;
                objModel.Dispatch_MineHead = Dispatch_MineHead;
                objModel.ClosingStock_MineHead = ClosingStock_MineHead;
                objModel.Ex_MinePrice = Ex_MinePrice;
                objModel.Month_YearGradeWise = monthYear;
                objModel.UID = UID;
                objobjmodel = _objIeReturnNonCoalModel.UpdateGradewise_Prod(objModel);
                result = objobjmodel.Satus;

                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete Grade Wise Production
        /// </summary>
        /// <param name="ProdID"></param>
        /// <param name="UID"></param>
        /// <returns>Json Result</returns>
        public JsonResult DeleteGradewise_Prod(int ProdID, int UID)
        {
            try
            {
                string result;
                Grade_WiseProduction objModel = new Grade_WiseProduction();
                objModel.GradeWiseProduction_Id = ProdID;
                objModel.UID = UID;
                objobjmodel = _objIeReturnNonCoalModel.DeleteGradewise_Prod(objModel);
                result = objobjmodel.Satus;
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Add Sale Dispatch
        /// </summary>
        /// <param name="MineralNatureId6"></param>
        /// <param name="MineralGradeId6"></param>
        /// <param name="NatureofDispatch"></param>
        /// <param name="RegistrationNo"></param>
        /// <param name="PurchaserConsinee"></param>
        /// <param name="DomesticPurposes_Quantity"></param>
        /// <param name="SaleValue"></param>
        /// <param name="Country"></param>
        /// <param name="Export_Quantity"></param>
        /// <param name="FOBValue"></param>
        /// <param name="MonthYear"></param>
        /// <param name="MineralId"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult AddSaleDispatch(int MineralNatureId6, int MineralGradeId6, string NatureofDispatch, string RegistrationNo, string PurchaserConsinee, decimal DomesticPurposes_Quantity, decimal SaleValue, string Country, decimal Export_Quantity, string FOBValue, string MonthYear, int MineralId, int UID)
        {
            try
            {
                string result;
                SalesDispatchModel objModel = new SalesDispatchModel();
                objModel.MineralNatureId6 = MineralNatureId6;
                objModel.MineralGradeId6 = MineralGradeId6;
                objModel.NatureofDispatch = NatureofDispatch;
                objModel.RegistrationNo = RegistrationNo;
                objModel.PurchaserConsinee = PurchaserConsinee;
                objModel.DomesticPurposes_Quantity = DomesticPurposes_Quantity;
                objModel.SaleValue = SaleValue;
                objModel.Country = Country;
                objModel.Export_Quantity = Export_Quantity;
                objModel.FOBValue = FOBValue;
                objModel.MonthYear = MonthYear;
                objModel.MineralId = MineralId;
                objModel.UId = UID;
                objobjmodel = _objIeReturnNonCoalModel.AddSaleDispatch(objModel);
                result = objobjmodel.Satus;
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Get Sale Dispatch
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetSalesDespatch(string MonthYear, int? UserId)
        {
            List<SalesDispatchModel> list = new List<SalesDispatchModel>();
            try
            {
                MonthlyReturnModelNonCoal model = new MonthlyReturnModelNonCoal();
                model.MonthYear = MonthYear;
                model.Uid = UserId;
                list = _objIeReturnNonCoalModel.GetSalesDespatch(model);
                return Json(list);

            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// Update Sale Dispatch
        /// </summary>
        /// <param name="id"></param>
        /// <param name="MineralNatureId6"></param>
        /// <param name="MineralGradeId6"></param>
        /// <param name="NatureofDispatch"></param>
        /// <param name="RegistrationNo"></param>
        /// <param name="PurchaserConsinee"></param>
        /// <param name="DomesticPurposes_Quantity"></param>
        /// <param name="SaleValue"></param>
        /// <param name="Country"></param>
        /// <param name="Export_Quantity"></param>
        /// <param name="FOBValue"></param>
        /// <param name="MonthYear"></param>
        /// <param name="MineralId"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult UpdateSaleDispatch(int id, int MineralNatureId6, int MineralGradeId6, string NatureofDispatch, string RegistrationNo, string PurchaserConsinee, decimal DomesticPurposes_Quantity, decimal SaleValue, string Country, decimal Export_Quantity, string FOBValue, string MonthYear, int MineralId, int UID)
        {
            try
            {
                string result;
                SalesDispatchModel objModel = new SalesDispatchModel();
                objModel.Sale_Dispatch_Id = id;
                objModel.MineralNatureId6 = MineralNatureId6;
                objModel.MineralGradeId6 = MineralGradeId6;
                objModel.NatureofDispatch = NatureofDispatch;
                objModel.RegistrationNo = RegistrationNo;
                objModel.PurchaserConsinee = PurchaserConsinee;
                objModel.DomesticPurposes_Quantity = DomesticPurposes_Quantity;
                objModel.SaleValue = SaleValue;
                objModel.Country = Country;
                objModel.Export_Quantity = Export_Quantity;
                objModel.FOBValue = FOBValue;
                objModel.MonthYear = MonthYear;
                objModel.UId = UID;
                objobjmodel = _objIeReturnNonCoalModel.UpdateSaleDispatch(objModel);
                result = objobjmodel.Satus;
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete Sale Dispatch
        /// </summary>
        /// <param name="DID"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult DeleteSaleDispatch(int DID, int UID)
        {
            try
            {
                string result;
                SalesDispatchModel objModel = new SalesDispatchModel();
                objModel.Sale_Dispatch_Id = DID;
                objModel.UId = UID;
                objobjmodel = _objIeReturnNonCoalModel.DeleteSaleDispatch(objModel);
                result = objobjmodel.Satus;
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Add Pulverization
        /// </summary>
        /// <param name="MineralNatureId7"></param>
        /// <param name="MineralGradeId7"></param>
        /// <param name="Total_Qty_Mineral_Pulverization"></param>
        /// <param name="Pulverized_MeshSize"></param>
        /// <param name="Pulverized_Qty"></param>
        /// <param name="Produced_MeshSize"></param>
        /// <param name="Produced_Qty"></param>
        /// <param name="Produced_Ex_factory_Sale_value"></param>
        /// <param name="MonthYear"></param>
        /// <param name="MineralId"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult AddPulverization(int MineralNatureId7, int MineralGradeId7, decimal Total_Qty_Mineral_Pulverization, string Pulverized_MeshSize, decimal Pulverized_Qty, string Produced_MeshSize, decimal Produced_Qty, decimal Produced_Ex_factory_Sale_value, string MonthYear, int MineralId, int UID)
        {
            try
            {
                string result;
                Mineral_PulverizedModel objModel = new Mineral_PulverizedModel();
                objModel.MineralNatureId7 = MineralNatureId7;
                objModel.MineralGradeId7 = MineralGradeId7;
                objModel.Total_Qty_Mineral_Pulverization = Total_Qty_Mineral_Pulverization;
                objModel.Pulverized_MeshSize = Pulverized_MeshSize;
                objModel.Pulverized_Qty = Pulverized_Qty;
                objModel.Produced_MeshSize = Produced_MeshSize;
                objModel.Produced_Qty = Produced_Qty;
                objModel.Produced_Ex_factory_Sale_value = Produced_Ex_factory_Sale_value;
                objModel.Month_YearPulverization = MonthYear;
                objModel.UId = UID;
                objobjmodel = _objIeReturnNonCoalModel.AddPulverization(objModel);
                result = objobjmodel.Satus;

                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Get Pulverization Details
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetMineral_Pulverized(string MonthYear, int? UserId)
        {
            List<Mineral_PulverizedModel> list = new List<Mineral_PulverizedModel>();
            try
            {
                MonthlyReturnModelNonCoal model = new MonthlyReturnModelNonCoal();
                model.MonthYear = MonthYear;
                model.Uid = UserId;
                list = _objIeReturnNonCoalModel.GetMineral_Pulverized(model);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// Update Pulverization Details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="MineralNatureId7"></param>
        /// <param name="MineralGradeId7"></param>
        /// <param name="Total_Qty_Mineral_Pulverization"></param>
        /// <param name="Pulverized_MeshSize"></param>
        /// <param name="Pulverized_Qty"></param>
        /// <param name="Produced_MeshSize"></param>
        /// <param name="Produced_Qty"></param>
        /// <param name="Produced_Ex_factory_Sale_value"></param>
        /// <param name="MonthYear"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult UpdateMineral_Pulverized(int id, int MineralNatureId7, int MineralGradeId7, decimal Total_Qty_Mineral_Pulverization, string Pulverized_MeshSize, decimal Pulverized_Qty, string Produced_MeshSize, decimal Produced_Qty, decimal Produced_Ex_factory_Sale_value, string MonthYear, int UID)
        {
            try
            {
                string result;
                Mineral_PulverizedModel objModel = new Mineral_PulverizedModel();
                objModel.Pulverization_id = id;
                objModel.MineralNatureId7 = MineralNatureId7;
                objModel.MineralGradeId7 = MineralGradeId7;
                objModel.Total_Qty_Mineral_Pulverization = Total_Qty_Mineral_Pulverization;
                objModel.Pulverized_MeshSize = Pulverized_MeshSize;
                objModel.Pulverized_Qty = Pulverized_Qty;
                objModel.Produced_MeshSize = Produced_MeshSize;
                objModel.Produced_Qty = Produced_Qty;
                objModel.Produced_Ex_factory_Sale_value = Produced_Ex_factory_Sale_value;
                objModel.Month_YearPulverization = MonthYear;
                objModel.UId = UID;
                objobjmodel = _objIeReturnNonCoalModel.UpdateMineral_Pulverized(objModel);
                result = objobjmodel.Satus;
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete Pulverized Mineral
        /// </summary>
        /// <param name="DID"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult DeleteeMineral_Pulverized(int DID, int UID)
        {
            try
            {
                string result;
                Mineral_PulverizedModel objModel = new Mineral_PulverizedModel();
                objModel.Pulverization_id = DID;
                objModel.UId = UID;
                objobjmodel = _objIeReturnNonCoalModel.DeleteeMineral_Pulverized(objModel);
                result = objobjmodel.Satus;
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Post of Part2 form1
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult PartTwo(MonthlyPartTwoViewModel objModel)
        {
            if (objModel.objProduction.Flag1 == 1)
            {
                ProductionModel_Monthly objModelR = new ProductionModel_Monthly();
                objModelR.TypeOfProduction_Id = objModel.objProduction.TypeOfProduction_Id;
                objModelR.TypeofOreProduced = objModel.objProduction.TypeofOreProduced;
                objModelR.OpeningStockOCW = objModel.objProduction.OpeningStockOCW;
                objModelR.productionOCW = objModel.objProduction.productionOCW;
                objModelR.closingOCW = objModel.objProduction.closingOCW;
                objModelR.OpeningStockUW = objModel.objProduction.OpeningStockUW;
                objModelR.productionUW = objModel.objProduction.productionUW;
                objModelR.closingUW = objModel.objProduction.closingUW;
                objModelR.OpeningStockDW = objModel.objProduction.OpeningStockDW;
                objModelR.productionDW = objModel.objProduction.productionDW;
                objModelR.closingDW = objModel.objProduction.closingDW;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID = 194;
                objModelR.MineralId1 = (int)TempData["MineralID"];
                objModelR.Month_Year = objModel.objProduction.Month_Year;
                objModelR.Hematite = objModel.objProduction.Hematite;
                objModelR.Magnetite = objModel.objProduction.Magnetite;
                objobjmodel = _objIeReturnNonCoalModel.UpdateTypeProductionPartTwo(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }
            else if (objModel.objProduction.Flag1 == 2)
            {
                ProductionModel_Monthly objModelR = new ProductionModel_Monthly();
                objModelR.TypeofOreProduced = objModel.objProduction.TypeofOreProduced;
                objModelR.OpeningStockOCW = objModel.objProduction.OpeningStockOCW;
                objModelR.productionOCW = objModel.objProduction.productionOCW;
                objModelR.closingOCW = objModel.objProduction.closingOCW;
                objModelR.OpeningStockUW = objModel.objProduction.OpeningStockUW;
                objModelR.productionUW = objModel.objProduction.productionUW;
                objModelR.closingUW = objModel.objProduction.closingUW;
                objModelR.OpeningStockDW = objModel.objProduction.OpeningStockDW;
                objModelR.productionDW = objModel.objProduction.productionDW;
                objModelR.closingDW = objModel.objProduction.closingDW;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID = 194;
                objModelR.MineralId1 = (int)TempData["MineralID"];
                objModelR.Month_Year = objModel.objProduction.Month_Year;
                objModelR.Hematite = objModel.objProduction.Hematite;
                objModelR.Magnetite = objModel.objProduction.Magnetite;
                objobjmodel = _objIeReturnNonCoalModel.AddTypeProductionPartTwo(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }

            if (objModel.objDeduction.Flag2 == 1)
            {
                Details_of_deductions_Monthly objModelR = new Details_of_deductions_Monthly();

                objModelR.DeductionMade_Id = objModel.objDeduction.DeductionMade_Id;
                objModelR.Averagecostofpulverization = objModel.objDeduction.Averagecostofpulverization;
                objModelR.Deduction_claimedType1 = objModel.objDeduction.Deduction_claimedType1;
                objModelR.Amount1 = objModel.objDeduction.Amount1;
                objModelR.Remarks1 = objModel.objDeduction.Remarks1;
                objModelR.Deduction_claimedType2 = objModel.objDeduction.Deduction_claimedType2;
                objModelR.Amount2 = objModel.objDeduction.Amount2;
                objModelR.Remarks2 = objModel.objDeduction.Remarks2;
                objModelR.Deduction_claimedType3 = objModel.objDeduction.Deduction_claimedType3;
                objModelR.Amount3 = objModel.objDeduction.Amount3;
                objModelR.Remarks3 = objModel.objDeduction.Remarks3;
                objModelR.Deduction_claimedType4 = objModel.objDeduction.Deduction_claimedType4;
                objModelR.Amount4 = objModel.objDeduction.Amount4;
                objModelR.Remarks4 = objModel.objDeduction.Remarks4;
                objModelR.Deduction_claimedType5 = objModel.objDeduction.Deduction_claimedType5;
                objModelR.Amount5 = objModel.objDeduction.Amount5;
                objModelR.Remarks5 = objModel.objDeduction.Remarks5;
                objModelR.Deduction_claimedType6 = objModel.objDeduction.Deduction_claimedType6;
                objModelR.Amount6 = objModel.objDeduction.Amount6;
                objModelR.Remarks6 = objModel.objDeduction.Remarks6;
                objModelR.Deduction_claimedType7 = objModel.objDeduction.Deduction_claimedType7;
                objModelR.Amount7 = objModel.objDeduction.Amount7;
                objModelR.Remarks7 = objModel.objDeduction.Remarks7;
                objModelR.TotalAmount = objModel.objDeduction.TotalAmount;
                objModelR.MineralId = (int)TempData["MineralID"];
                objModelR.Month_Year = objModel.objDeduction.Month_Year;
                objModelR.CExMineSale = objModel.objDeduction.CExMineSale;
                objModelR.ex_mineSale = objModel.objDeduction.ex_mineSale;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID = 194;
                objobjmodel = _objIeReturnNonCoalModel.UpdateDetails_of_deductions(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }
            else if (objModel.objDeduction.Flag2 == 2)
            {
                Details_of_deductions_Monthly objModelR = new Details_of_deductions_Monthly();
                objModelR.Deduction_claimedType7 = objModel.objDeduction.Deduction_claimedType7;
                objModelR.Amount1 = objModel.objDeduction.Amount1;
                objModelR.Amount2 = objModel.objDeduction.Amount2;
                objModelR.Amount3 = objModel.objDeduction.Amount3;
                objModelR.Amount4 = objModel.objDeduction.Amount4;
                objModelR.Amount5 = objModel.objDeduction.Amount5;
                objModelR.Amount6 = objModel.objDeduction.Amount6;
                objModelR.Amount7 = objModel.objDeduction.Amount7;
                objModelR.Remarks1 = objModel.objDeduction.Remarks1;
                objModelR.Remarks2 = objModel.objDeduction.Remarks2;
                objModelR.Remarks3 = objModel.objDeduction.Remarks3;
                objModelR.Remarks4 = objModel.objDeduction.Remarks4;
                objModelR.Remarks5 = objModel.objDeduction.Remarks5;
                objModelR.Remarks6 = objModel.objDeduction.Remarks6;
                objModelR.Remarks7 = objModel.objDeduction.Remarks7;
                objModelR.TotalAmount = objModel.objDeduction.TotalAmount;
                objModelR.MineralId = (int)TempData["MineralID"];
                objModelR.CExMineSale = objModel.objDeduction.CExMineSale;
                objModelR.ex_mineSale = objModel.objDeduction.ex_mineSale;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID = 194;
                objModelR.Month_Year = objModel.objDeduction.Month_Year;
                objobjmodel = _objIeReturnNonCoalModel.AddDeductionMade(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }

            if (objModel.objDeduction.PFlag == 1)
            {
                Details_of_deductions_Monthly objModelR = new Details_of_deductions_Monthly();
                objModelR.Average_Id = objModel.objDeduction.Average_Id;
                objModelR.Averagecostofpulverization = objModel.objDeduction.Averagecostofpulverization;
                objModelR.Month_Year = objModel.objDeduction.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID = 194;
                objobjmodel = _objIeReturnNonCoalModel.Updatepulverization(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }
            else if (objModel.objDeduction.PFlag == 2)
            {

                Details_of_deductions_Monthly objModelR = new Details_of_deductions_Monthly();
                objModelR.Averagecostofpulverization = objModel.objDeduction.Averagecostofpulverization;
                objModelR.Month_Year = objModel.objDeduction.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID = 194;
                objobjmodel = _objIeReturnNonCoalModel.Addpulverization1(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }

            if (objModel.objReason_Inc_Dec.Flag3 == 1)
            {
                Reason_Inc_Dec_Monthly objModelR = new Reason_Inc_Dec_Monthly();
                objModelR.Reason_Inc_Dec_Id = objModel.objReason_Inc_Dec.Reason_Inc_Dec_Id;
                objModelR.productionIncrDecResion = objModel.objReason_Inc_Dec.productionIncrDecResion;
                objModelR.ex_minepriceIncrDecResion = objModel.objReason_Inc_Dec.ex_minepriceIncrDecResion;
                objModelR.MineralId = (int)TempData["MineralID"];
                objModelR.Month_Year = objModel.objReason_Inc_Dec.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID = 194;
                objobjmodel = _objIeReturnNonCoalModel.UpdateReasonForInDc(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }
            else if (objModel.objReason_Inc_Dec.Flag3 == 2)
            {
                Reason_Inc_Dec_Monthly objModelR = new Reason_Inc_Dec_Monthly();
                objModelR.productionIncrDecResion = objModel.objReason_Inc_Dec.productionIncrDecResion;
                objModelR.ex_minepriceIncrDecResion = objModel.objReason_Inc_Dec.ex_minepriceIncrDecResion;
                objModelR.certify = objModel.objReason_Inc_Dec.certify;
                objModelR.MineralId = (int)TempData["MineralID"];
                objModelR.Month_Year = objModel.objReason_Inc_Dec.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID = 194;
                objobjmodel = _objIeReturnNonCoalModel.AddReasonForInDc(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }
            else if (objModel.objReason_Inc_Dec.FinalSubmitFlag == 1)
            {
                Reason_Inc_Dec_Monthly objModelR = new Reason_Inc_Dec_Monthly();
                objModelR.Month_Year = objModel.objReason_Inc_Dec.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID = 194;
                objobjmodel = _objIeReturnNonCoalModel.Update_FinalSubmit(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
                return RedirectToAction("eReturnDashboard");
            }
            return RedirectToAction("PartTwo", new { MonthYear = TempData["M_Y"] });
        }

        /// <summary>
        /// Form1 Print 
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns>View</returns>
        public ActionResult GeteReturnFormOneDetails(string Month_Year, int? UserId)
        {

            MonthlyReturnModelNonCoal objModelR = new MonthlyReturnModelNonCoal();
            GetFormF1DetailsModel data = new GetFormF1DetailsModel();
            objModelR.MonthYear = protector.Unprotect(Month_Year);
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objModelR.Uid = profile.UserId;
            //objModelR.Uid = 194;
            ViewBag.UserId = profile.UserId;
            //ViewBag.UserId = 194;
            ViewBag.usertype = ConfigurationManager.MySettings["MySettings:UserType"];
            data = _objIeReturnNonCoalModel.GetFormF1Part1ForPrint(objModelR);
            ViewBag.ServerPath = ConfigurationManager.MySettings["MySettings:ServerPath"];
            ViewBag.DSCReadFilePath = ConfigurationManager.MySettings["MySettings:DSCReadFilePath"];
            return View(data);
        }

        /// <summary>
        /// Get Mineral Work Details For Print
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns>Json Result</returns>
        public JsonResult GetMineWorkDetails(string MonthYear, int? UserId)
        {
            List<Working_of_Mine> list = new List<Working_of_Mine>();
            try
            {
                MonthlyReturnModelNonCoal model = new MonthlyReturnModelNonCoal();
                model.MonthYear = MonthYear;
                model.Uid = UserId;
                list = _objIeReturnNonCoalModel.GetMineWorkDetails(model);
                return Json(list);

            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        #region DSC Response Verify
        string Signature = string.Empty;
        string OutputResult = string.Empty;
        /// <summary>
        /// Verify User For Print
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="signDataBase64Encoded"></param>
        /// <param name="responseType"></param>
        /// <returns>String</returns>
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
        /// Get Digital Signature Data
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>String</returns>
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
        /// Save PDF Format
        /// </summary>
        /// <param name="base64BinaryStr"></param>
        /// <param name="fileName"></param>
        /// <param name="ID"></param>
        /// <param name="UpdateIn"></param>
        /// <param name="Month_Year"></param>
        /// <returns>Json Result</returns>
        public JsonResult SavePdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn, string Month_Year)
        {
            string OutputResult = "SUCCESS";
            try
            {
                var ServerPath = "DSC/WithDSC/" + fileName;
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, ConfigurationManager.MySettings["MySettings:FNDSCCreateFilePATH"]);
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
                    OutputResult = "PDF File Save failed. Please try after some time";
                    return Json(OutputResult.ToUpper());
                }
                try
                {

                    string result;
                    MonthlyReturnModelNonCoal objModel = new MonthlyReturnModelNonCoal();
                    objModel.ServerPath = ServerPath;
                    objModel.ID = ID;
                    objModel.UpdateIn = UpdateIn.ToUpper();
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    objModel.Uid = profile.UserId;
                    objModel.MonthYear = Month_Year;

                    objobjmodel = _objIeReturnNonCoalModel.Update_Filepath(objModel);
                    result = objobjmodel.Satus;
                    if (result == null)
                    {
                        OutputResult = "FAILED";
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                OutputResult = "FAILED";
            }
            return Json(OutputResult.ToUpper());
        }
        /// <summary>
        /// Save without Digital Signature PDF File
        /// </summary>
        /// <param name="base64BinaryStr"></param>
        /// <param name="fileName"></param>
        /// <param name="ID"></param>
        /// <param name="UpdateIn"></param>
        /// <returns>Json String</returns>
        public JsonResult SaveNormalPdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn)
        {
            string OutputResult = "SUCCESS";
            try
            {
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, ConfigurationManager.MySettings["MySettings:FNDSCReadFilePATH"]);
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
