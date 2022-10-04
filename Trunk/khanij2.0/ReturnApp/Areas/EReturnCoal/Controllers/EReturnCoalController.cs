// ***********************************************************************
//  Controller Name          : EReturnCoal
//  Desciption               : Liecensee Monthly & Yearly Coal Return
//  Created By               : Akshaya Dalei
//  Created On               : 25 June 2021
// ***********************************************************************
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReturnApp.Areas.EReturnCoal.Models.ReturnCoalMonthly;
using ReturnApp.Areas.EReturnCoal.Models.ReturnCoalYearly;
using ReturnApp.Models;
using ReturnApp.Web;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturnApp.Areas.EReturnCoal.Controllers
{
    [Area("EReturnCoal")]
    public class EReturnCoalController : Controller
    {
        private readonly IReturnCoalMonthlyModel returnCoalMonthlyModel;
        private readonly IReturnCoalYearlyModel returnCoalYearlyModel;
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IDataProtector protector;
        #region Monthly Return Models
        List<MonthlyReturnModel> lstMonthlyReturnModel = new List<MonthlyReturnModel>();
        MonthlyReturnModel monthlyReturnModel = new MonthlyReturnModel();
        CoalMonthlyViewModel coalMonthlyViewModel = new CoalMonthlyViewModel();
        List<TABLE_A_Model> listTABLE_A_Model = new List<TABLE_A_Model>();
        List<TABLE_B_Model> listTABLE_B_Model = new List<TABLE_B_Model>();
        TABLE_A_Model tABLE_A_Model = new TABLE_A_Model();
        TABLE_B_Model tABLE_B_Model = new TABLE_B_Model();
        CoalMonthlyMineDetailsModel coalMonthlyMineDetailsModel = new CoalMonthlyMineDetailsModel();
        #endregion

        #region Yearly Return Model Details
        YearlyReturnModel yearlyReturnModel = new YearlyReturnModel();
        List<YearlyReturnModel> lstYearlyReturnModel = new List<YearlyReturnModel>();
        CoalYearlyViewModel coalYearlyViewModel = new CoalYearlyViewModel();
        CoalYearlyMineDetailsModel coalYearlyMineDetailsModel = new CoalYearlyMineDetailsModel();
        #endregion
        MessageEF messageEF = new MessageEF();
        string OutputResult = "";
        public EReturnCoalController(IReturnCoalMonthlyModel returnCoalMonthlyModel, IReturnCoalYearlyModel returnCoalYearlyModel,
            IConfiguration configuration, IHostingEnvironment hostingEnvironment,
            IDataProtectionProvider dataProtectionProvider)
        {
            this.returnCoalMonthlyModel = returnCoalMonthlyModel;
            this.returnCoalYearlyModel = returnCoalYearlyModel;
            this.configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
            protector = dataProtectionProvider.CreateProtector(configuration.GetSection("Encryption").GetValue<string>("EncryptionKey"));

        }

        #region Monthly Coal Return
        /// <summary>
        /// Monthly Return Details
        /// </summary>
        /// <returns></returns>
        public IActionResult eReturnDashboard()
        {

            ViewBag.msg = TempData["resultSubmit"] != null ? TempData["resultSubmit"].ToString() : null;
            string FY = DateTime.Now.Year.ToString() + "-" + DateTime.Now.AddYears(1).Year.ToString();
            var lstMonthlyReturnModel = GetMonthlyReturn(FY)
                  .Select
                     (e =>
                     {
                         e.EncryptedId = protector.Protect(e.MonthYear);
                         return e;
                     });
            return View(lstMonthlyReturnModel);
        }

        /// <summary>
        /// To Get Monthly Return
        /// </summary>
        /// <param name="FinancialYear"></param>
        /// <returns></returns>
        private List<MonthlyReturnModel> GetMonthlyReturn(string FinancialYear)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            monthlyReturnModel.FinancialYear = FinancialYear;
            monthlyReturnModel.UserId = profile.UserId; //150;
            lstMonthlyReturnModel = returnCoalMonthlyModel.eReturnMonthlyDetails(monthlyReturnModel);
            return lstMonthlyReturnModel;
        }

        #region FORMII
        /// <summary>
        /// To View FORM II
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <returns></returns>
        public ActionResult FORMII(string MonthYear)
        {
            TempData["M_Y"] = MonthYear;
            MonthYear = protector.Unprotect(MonthYear);
            if (TempData["resultWork"] != null)
            {
                ViewBag.msg = TempData["resultWork"].ToString();
            }
            if (TempData["resultEarn"] != null)
            {
                ViewBag.msg = TempData["resultEarn"].ToString();
            }
            if (TempData["resultMine"] != null)
            {
                ViewBag.msg = TempData["resultMine"].ToString();
            }
            if (TempData["resultSubmit"] != null)
            {
                ViewBag.msg = TempData["resultSubmit"].ToString();
            }
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            //Mine Lessee Details
            coalMonthlyMineDetailsModel.UserId = profile.UserId; //150;
            coalMonthlyViewModel.objMine = returnCoalMonthlyModel.GetLesseMineDeatils(coalMonthlyMineDetailsModel);
            coalMonthlyMineDetailsModel = GetMineDetails(MonthYear, profile.UserId);
            coalMonthlyMineDetailsModel.MineName = coalMonthlyViewModel.objMine.MineName;
            coalMonthlyMineDetailsModel.MineAddress = coalMonthlyViewModel.objMine.MineAddress;
            coalMonthlyMineDetailsModel.MineDistrict = coalMonthlyViewModel.objMine.MineDistrict;
            coalMonthlyMineDetailsModel.MineState = coalMonthlyViewModel.objMine.MineState;
            coalMonthlyMineDetailsModel.MineTehsil = coalMonthlyViewModel.objMine.MineTehsil;
            coalMonthlyMineDetailsModel.LesseeName = coalMonthlyViewModel.objMine.LesseeName;
            coalMonthlyMineDetailsModel.LesseeAddress = coalMonthlyViewModel.objMine.LesseeAddress;
            coalMonthlyViewModel.objMine = coalMonthlyMineDetailsModel;
            coalMonthlyViewModel.objWork = GetData(MonthYear, profile.UserId);
            coalMonthlyViewModel.objEarn = GetEarnDetails(MonthYear, profile.UserId);
            //--------------

            //---------------
            ViewBag.Month_Year = MonthYear;
            return View(coalMonthlyViewModel);
        }

        /// <summary>
        /// To Save ,Update and Final Submit Of FORM II
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FORMII(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            coalMonthlyViewModel.UserId = profile.UserId; //150;

            #region Mine Flag
            if (coalMonthlyViewModel.objMine.Flag == 1)
            {
                messageEF = returnCoalMonthlyModel.Update_MineDetails(coalMonthlyViewModel);
                if (messageEF.Satus == "1")
                {
                    TempData["resultMine"] = "Record Updated..";
                }
                else
                {
                    TempData["resultMine"] = "Record not Updated..";
                }
                TempData["resultEarn"] = null;
                TempData["resultWork"] = null;
            }
            else if (coalMonthlyViewModel.objMine.Flag == 2)
            {
                messageEF = returnCoalMonthlyModel.ADD_MineDetails(coalMonthlyViewModel);
                if (messageEF.Satus == "1")
                {
                    TempData["resultMine"] = "Mine Details has Been Saved..";
                }
                else if (messageEF.Satus == "2")
                {
                    TempData["resultMine"] = "This Month Details are already Exist..";
                }
                else if (messageEF.Satus == "4")
                {
                    TempData["resultMine"] = "Please Certify Details...";
                }
                TempData["resultEarn"] = null;
                TempData["resultWork"] = null;
            }
            #endregion

            #region Table C Work flag

            if (coalMonthlyViewModel.objWork.Flag == 1)
            {
                messageEF = returnCoalMonthlyModel.Update_NumberOF_Work_TableCMonthly(coalMonthlyViewModel);
                if (messageEF.Satus == "1")
                {
                    TempData["resultWork"] = "Mine Details Updated..";
                }
                else
                {
                    TempData["resultWork"] = "Mine Details not Updated..";
                }
                TempData["resultEarn"] = null;
                TempData["resultMine"] = null;
            }
            else if (coalMonthlyViewModel.objWork.Flag == 2)
            {
                messageEF = returnCoalMonthlyModel.ADD_NumberOF_Work_TableCMonthly(coalMonthlyViewModel);
                if (messageEF.Satus == "1")
                {
                    TempData["resultWork"] = "Details has Been Save..";
                }
                else if (messageEF.Satus == "2")
                {
                    TempData["resultWork"] = "This Month Details are already Exist..";
                }
                TempData["resultEarn"] = null;
                TempData["resultMine"] = null;
            }
            #endregion

            #region Table D Earn Flag
            if (coalMonthlyViewModel.objEarn.Flag == 1)
            {
                messageEF = returnCoalMonthlyModel.Update_Table_D(coalMonthlyViewModel);
                if (messageEF.Satus == "1")
                {
                    TempData["resultEarn"] = "Record has been Updated.";
                }
                else
                {
                    TempData["resultEarn"] = "Record has not been Updated.";
                }
                TempData["resultWork"] = null;
                TempData["resultMine"] = null;
            }
            else if (coalMonthlyViewModel.objEarn.Flag == 2)
            {
                messageEF = returnCoalMonthlyModel.ADD_Table_D(coalMonthlyViewModel);
                if (messageEF.Satus == "1")
                {
                    TempData["resultEarn"] = "Details has been Save.";
                }
                else if (messageEF.Satus == "2")
                {
                    TempData["resultEarn"] = "This Month Details are already Exist.";
                }
                TempData["resultWork"] = null;
                TempData["resultMine"] = null;
            }
            #endregion

            #region Final Submit
            if (coalMonthlyViewModel.objMine.SubmitFlag == 1)
            {
                messageEF = returnCoalMonthlyModel.Update_FinalSubmit(coalMonthlyViewModel);
                if (messageEF.Satus == "1")
                {
                    TempData["resultSubmit"] = "Your Return has been Submitted";
                }
                else
                {
                    TempData["resultSubmit"] = "Your Return has not Submitted.";
                }
                TempData["resultEarn"] = null;
                TempData["resultMine"] = null;
                TempData["resultWork"] = null;
                return RedirectToAction("eReturnDashboard", "eReturnProcess", new { area = "eReturn_NonCoal" });
            }
            #endregion

            return RedirectToAction("FORMII", new { MonthYear = TempData["M_Y"].ToString() });

        }
        #endregion

        #region Table A
        /// <summary>
        /// Table A Monthly Details
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public JsonResult GetCoalMonthly_eReturn(string MonthYear, int? UserID)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                monthlyReturnModel.MonthYear = MonthYear;
                monthlyReturnModel.UserId = profile.UserId; //UserID;
                listTABLE_A_Model = returnCoalMonthlyModel.Coal_TableAMonthlyDetails(monthlyReturnModel);
                return Json(listTABLE_A_Model);

            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// Get Dispatch By Mineral Grade and Month Year
        /// </summary>
        /// <param name="monthYear"></param>
        /// <param name="MineralGradeId"></param>
        /// <returns></returns>
        public JsonResult getDisaptchByMonthYear(string monthYear, int? MineralGradeId)
        {

            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                monthlyReturnModel.MonthYear = monthYear;
                monthlyReturnModel.UserId = profile.UserId; //150;
                monthlyReturnModel.MineralGradeId = MineralGradeId;
                listTABLE_A_Model = returnCoalMonthlyModel.GetCoal_TableADispatchDetails(monthlyReturnModel);

                return Json(listTABLE_A_Model);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// Get Opening Stock
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="MineralNatureId"></param>
        /// <param name="MineralGradeId"></param>
        /// <param name="Size_Of_Coal"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public JsonResult GetOpeningStock(string MonthYear, int? MineralNatureId, int? MineralGradeId, string Size_Of_Coal, int? UserID)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            monthlyReturnModel.MonthYear = MonthYear;
            monthlyReturnModel.MineralNatureId = MineralNatureId;
            monthlyReturnModel.MineralGradeId = MineralGradeId;
            monthlyReturnModel.Size_Of_Coal = Size_Of_Coal;
            monthlyReturnModel.UserId = profile.UserId; //UserID;
            tABLE_A_Model = returnCoalMonthlyModel.Coal_TableAOpeningStock(monthlyReturnModel);
            return Json(tABLE_A_Model);
        }

        /// <summary>
        /// Delete Table A
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public JsonResult DeleteCoalMonthly_eReturn(int? Id, int? UserId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            tABLE_A_Model.Coal_TableA_Id = Id;
            tABLE_A_Model.UserId = profile.UserId; //UserId;
            messageEF = returnCoalMonthlyModel.DeleteCoal_TableAMonthly(tABLE_A_Model);
            return Json(messageEF.Satus);
        }

        /// <summary>
        /// Update Table A
        /// </summary>
        /// <param name="tABLE_A_Model"></param>
        /// <returns></returns>
        public IActionResult UpdateCoalMonthlyEReturn(TABLE_A_Model tABLE_A_Model)
        {
            messageEF = returnCoalMonthlyModel.UpdateCoal_TableAMonthly(tABLE_A_Model);
            return View();
        }

        /// <summary>
        /// Add Table A
        /// </summary>
        /// <param name="Coal_TableA_Id"></param>
        /// <param name="MineralNatureId"></param>
        /// <param name="MineralGradeId"></param>
        /// <param name="Name_OF_Colliery_Siding"></param>
        /// <param name="Size_Of_Coal"></param>
        /// <param name="CoalRaised"></param>
        /// <param name="Opening_Stock"></param>
        /// <param name="OpenCW"></param>
        /// <param name="Below_GW_DevelopmentDistricts"></param>
        /// <param name="Below_GW_DepillaringDistricts"></param>
        /// <param name="CollieryConsumption"></param>
        /// <param name="Coalused_Makingcoke_Colliery"></param>
        /// <param name="CokeProduced"></param>
        /// <param name="CoalDespatched_ByRail"></param>
        /// <param name="CoalDespatched_ByRoad"></param>
        /// <param name="CoalDespatched_ByOther"></param>
        /// <param name="Closing_Stock"></param>
        /// <param name="Month_Year"></param>
        /// <returns></returns>
        public JsonResult ADDCoalMonthly_eReturn(int Coal_TableA_Id, int? MineralNatureId, int? MineralGradeId, string Name_OF_Colliery_Siding,
            string Size_Of_Coal, string CoalRaised, decimal? Opening_Stock, decimal? OpenCW, decimal? Below_GW_DevelopmentDistricts,
            decimal? Below_GW_DepillaringDistricts, decimal? CollieryConsumption, decimal? Coalused_Makingcoke_Colliery, decimal? CokeProduced,
            decimal? CoalDespatched_ByRail, decimal? CoalDespatched_ByRoad, decimal? CoalDespatched_ByOther, decimal? Closing_Stock, string Month_Year)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            tABLE_A_Model.Coal_TableA_Id = Coal_TableA_Id;
            tABLE_A_Model.MineralNatureId = MineralNatureId;
            tABLE_A_Model.MineralGradeId = MineralGradeId;
            tABLE_A_Model.Name_OF_Colliery_Siding = Name_OF_Colliery_Siding;
            tABLE_A_Model.Size_Of_Coal = Size_Of_Coal;
            tABLE_A_Model.CoalRaised = CoalRaised;
            tABLE_A_Model.Opening_Stock = Opening_Stock;
            tABLE_A_Model.OpenCW = OpenCW;
            tABLE_A_Model.Below_GW_DevelopmentDistricts = Below_GW_DevelopmentDistricts;
            tABLE_A_Model.Below_GW_DepillaringDistricts = Below_GW_DepillaringDistricts;
            tABLE_A_Model.CollieryConsumption = CollieryConsumption;
            tABLE_A_Model.Coalused_Makingcoke_Colliery = Coalused_Makingcoke_Colliery;
            tABLE_A_Model.CokeProduced = CokeProduced;
            tABLE_A_Model.CoalDespatched_ByRail = CoalDespatched_ByRail;
            tABLE_A_Model.CoalDespatched_ByRoad = CoalDespatched_ByRoad;
            tABLE_A_Model.CoalDespatched_ByOther = CoalDespatched_ByOther;
            tABLE_A_Model.Closing_Stock = Closing_Stock;
            tABLE_A_Model.Month_Year = Month_Year;
            tABLE_A_Model.UserId = profile.UserId; //150;
            messageEF = returnCoalMonthlyModel.AddCoal_TableAMonthly(tABLE_A_Model);
            return Json(messageEF.Satus);
        }
        /// <summary>
        /// Get Mineral Nature
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMineralNature()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            monthlyReturnModel.UserId = profile.UserId; //150;
            List<MonthlyReturnModel> lstmonthlyReturnModels = returnCoalMonthlyModel.GetMineralNature(monthlyReturnModel);
            return Json(lstmonthlyReturnModels);


        }

        /// <summary>
        /// Get Mineral Grade
        /// </summary>
        /// <param name="MineralNatureId"></param>
        /// <returns></returns>
        public JsonResult GetMineralGrade(int? MineralNatureId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            monthlyReturnModel.UserId = profile.UserId; //150;
            monthlyReturnModel.MineralNatureId = MineralNatureId;
            List<MonthlyReturnModel> lstmonthlyReturnModels = returnCoalMonthlyModel.GetMineralGrade(monthlyReturnModel);
            return Json(lstmonthlyReturnModels);
        }


        #endregion

        #region Table B
        /// <summary>
        /// Add Machinery
        /// </summary>
        /// <param name="MACHINERY_TableB_Id"></param>
        /// <param name="WorkingsBG_Type"></param>
        /// <param name="Coal_Cutting_No_In_Use"></param>
        /// <param name="Coal_Cutting_Type"></param>
        /// <param name="Square_Metres_Cut"></param>
        /// <param name="Coal_cut"></param>
        /// <param name="MechanicalLoaders_NoInUse"></param>
        /// <param name="MechanicalLoaders_Type"></param>
        /// <param name="MechanicalLoaders_Coalloaded"></param>
        /// <param name="Conveyors_Type"></param>
        /// <param name="Conveyors_Length"></param>
        /// <param name="Coal_conveyed"></param>
        /// <param name="Month_Year"></param>
        /// <returns></returns>
        public JsonResult ADDMACHINERYMonthly_eReturn(int? MACHINERY_TableB_Id, string WorkingsBG_Type,
            decimal? Coal_Cutting_No_In_Use, string Coal_Cutting_Type, decimal? Square_Metres_Cut, decimal? Coal_cut, decimal? MechanicalLoaders_NoInUse,
            string MechanicalLoaders_Type, decimal? MechanicalLoaders_Coalloaded, string Conveyors_Type, decimal? Conveyors_Length, decimal? Coal_conveyed, string Month_Year)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            tABLE_B_Model.UserId = profile.UserId; //150;
            tABLE_B_Model.MACHINERY_TableB_Id = MACHINERY_TableB_Id;
            tABLE_B_Model.WorkingsBG_Type = WorkingsBG_Type;
            tABLE_B_Model.Coal_Cutting_No_In_Use = Coal_Cutting_No_In_Use;
            tABLE_B_Model.Coal_Cutting_Type = Coal_Cutting_Type;
            tABLE_B_Model.Square_Metres_Cut = Square_Metres_Cut;
            tABLE_B_Model.Coal_cut = Coal_cut;
            tABLE_B_Model.MechanicalLoaders_NoInUse = MechanicalLoaders_NoInUse;
            tABLE_B_Model.MechanicalLoaders_Type = MechanicalLoaders_Type;
            tABLE_B_Model.MechanicalLoaders_Coalloaded = MechanicalLoaders_Coalloaded;
            tABLE_B_Model.Conveyors_Type = Conveyors_Type;
            tABLE_B_Model.Conveyors_Length = Conveyors_Length;
            tABLE_B_Model.Coal_conveyed = Coal_conveyed;
            tABLE_B_Model.Month_Year = Month_Year;
            messageEF = returnCoalMonthlyModel.AddMACHINERY_TableBMonthly(tABLE_B_Model);
            return Json(messageEF.Satus);
        }

        /// <summary>
        /// Update Machinery
        /// </summary>
        /// <param name="tABLE_B_Model"></param>
        /// <returns></returns>
        public IActionResult UpdateMACHINERYMonthly_eReturn(TABLE_B_Model tABLE_B_Model)
        {
            messageEF = returnCoalMonthlyModel.UpdateMACHINERY_TableBMonthly(tABLE_B_Model);
            return View();
        }

        /// <summary>
        /// Delete Machinery
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public JsonResult DeleteMACHINERYMonthly_eReturn(int? Id, int? UserId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            tABLE_B_Model.MACHINERY_TableB_Id = Id;
            tABLE_B_Model.UserId = profile.UserId; //UserId;
            messageEF = returnCoalMonthlyModel.DeleteMACHINERY_TableBMonthly(tABLE_B_Model);
            return Json(messageEF.Satus);
        }

        /// <summary>
        /// Get Machinery Details
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public JsonResult GetMACHINERYMonthly_eReturn(string MonthYear, int? UserID)
        {

            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                monthlyReturnModel.MonthYear = MonthYear;
                monthlyReturnModel.UserId = profile.UserId; //UserID;
                listTABLE_B_Model = returnCoalMonthlyModel.GetMACHINERY_TableBMonthly(monthlyReturnModel);
                return Json(listTABLE_B_Model);

            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// Get Working Background Type
        /// </summary>
        /// <returns></returns>
        public JsonResult GetWorkingBackGroungType()
        {
            listTABLE_B_Model = returnCoalMonthlyModel.GetWorkingBackGroungType(monthlyReturnModel);
            return Json(listTABLE_B_Model);
        }
        #endregion

        #region Table C
        /// <summary>
        /// Get Number OF Work TableC Monthly
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public CoalMonthlyModel GetData(string Month_Year, int? UserId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            monthlyReturnModel.MonthYear = Month_Year;
            monthlyReturnModel.UserId = profile.UserId; //UserId;
            CoalMonthlyModel coalMonthlyModel = returnCoalMonthlyModel.Get_NumberOF_Work_TableCMonthly(monthlyReturnModel);
            return coalMonthlyModel;
        }
        #endregion

        #region Table D
        /// <summary>
        /// Get Earn Details TableD Monthly
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Table_D_Model GetEarnDetails(string Month_Year, int? UserId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            monthlyReturnModel.MonthYear = Month_Year;
            monthlyReturnModel.UserId = profile.UserId; //UserId;
            Table_D_Model table_D_Model = returnCoalMonthlyModel.Get_EarnDetails_TableDMonthly(monthlyReturnModel);
            return table_D_Model;
        }
        #endregion

        #region Mine Details
        /// <summary>
        /// Get Mine Details
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public CoalMonthlyMineDetailsModel GetMineDetails(string Month_Year, int? UserId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            monthlyReturnModel.MonthYear = Month_Year;
            monthlyReturnModel.UserId = profile.UserId; //UserId;
            coalMonthlyMineDetailsModel = returnCoalMonthlyModel.Get_CoalMonthlyMineDetails(monthlyReturnModel);
            return coalMonthlyMineDetailsModel;
        }
        #endregion

        #region Previous Month Closing Stock
        /// <summary>
        /// Get Previous Month Closing Stock
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public JsonResult getPreviousMonthClosingStock(string MonthYear, int? UserId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            monthlyReturnModel.MonthYear = MonthYear;
            monthlyReturnModel.UserId = profile.UserId; //UserId;
            string result = returnCoalMonthlyModel.PreviousMonthClosingStock(monthlyReturnModel);
            return Json(result);
        }
        #endregion

        #region for Print Preview
        /// <summary>
        /// Print Form II
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public ActionResult PrintCoalFIRSTSCHEDULE_FORMII(string Month_Year, int? UserId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.EncryptData = Month_Year;
            Month_Year = protector.Unprotect(Month_Year);
            UserId = profile.UserId; //150;
            monthlyReturnModel.MonthYear = Month_Year;
            monthlyReturnModel.UserId = UserId;
            coalMonthlyViewModel.objMine = returnCoalMonthlyModel.Get_CoalMonthlyMineDetails(monthlyReturnModel);
            coalMonthlyViewModel.objEarn = returnCoalMonthlyModel.Get_EarnDetails_TableDMonthly(monthlyReturnModel);
            coalMonthlyViewModel.objWork = returnCoalMonthlyModel.Get_NumberOF_Work_TableCMonthly(monthlyReturnModel);
            coalMonthlyViewModel.listTABLE_A_Model = returnCoalMonthlyModel.Coal_TableAMonthlyDetails(monthlyReturnModel);
            coalMonthlyViewModel.listTABLE_B_Model = returnCoalMonthlyModel.GetMACHINERY_TableBMonthly(monthlyReturnModel);
            ViewBag.Month_Year = Month_Year;
            TempData["M_Y"] = Month_Year;
            ViewBag.UserId = UserId;
            ViewBag.ServerPath = configuration.GetSection("MySettings").GetValue<string>("ServerPath");
            ViewBag.DSCReadFilePath = configuration.GetSection("MySettings").GetValue<string>("DSCReadFilePath");
            return View(coalMonthlyViewModel);
        }

        /// <summary>
        /// Get Table A Details For Print
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public JsonResult GetCoalMonthlyForPrint(string MonthYear, int? UserId)
        {

            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                monthlyReturnModel.MonthYear = MonthYear;
                monthlyReturnModel.UserId = profile.UserId; //UserId;
                listTABLE_A_Model = returnCoalMonthlyModel.Coal_TableAMonthlyDetails(monthlyReturnModel);
                return Json(listTABLE_A_Model);

            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// Get Table B Details For Print
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public JsonResult GetMACHINERYMonthlyForPrint(string MonthYear, int? UserId)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                monthlyReturnModel.MonthYear = MonthYear;
                monthlyReturnModel.UserId = profile.UserId; //UserId;
                listTABLE_B_Model = returnCoalMonthlyModel.GetMACHINERY_TableBMonthly(monthlyReturnModel);
                return Json(listTABLE_B_Model);

            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion
        #endregion

        #region Yearly Coal Return

        #region Yearly Coal Return Details
        /// <summary>
        /// Yearly Coal Return Details
        /// </summary>
        /// <returns></returns>
        public ActionResult YearlyReturn()
        {
            try
            {
                if (TempData["resultSubmit"] != null)
                {
                    ViewBag.msg = TempData["resultSubmit"].ToString();
                }
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.UserId = profile.UserId; //150;
                var lstYearlyReturnModel = returnCoalYearlyModel.GetYearlyReturnDetails(yearlyReturnModel)
                     .Select
                     (e =>
                     {
                         e.EncryptedId = protector.Protect(e.Financial_Year);
                         return e;
                     });
                return View(lstYearlyReturnModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FORMIII
        /// <summary>
        /// To Get FORM III Data in View
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns></returns>
        public IActionResult FORMIII(string Financial_Year)
        {
            TempData["F_Y"] = Financial_Year;
            Financial_Year = protector.Unprotect(Financial_Year);
            try
            {
                if (TempData["resultMine"] != null)
                {
                    ViewBag.msg = TempData["resultMine"].ToString();
                }
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.UserId = profile.UserId; //150;
                coalYearlyViewModel.objMine = returnCoalYearlyModel.GetLesseMineDeatils(yearlyReturnModel);
                coalYearlyMineDetailsModel = Get_CoalYearlyMineDetails(Financial_Year);
                coalYearlyMineDetailsModel.MineName = string.IsNullOrEmpty(coalYearlyViewModel.objMine.MineName) ? "N/A" : coalYearlyViewModel.objMine.MineName;
                coalYearlyMineDetailsModel.MineAddress = string.IsNullOrEmpty(coalYearlyViewModel.objMine.MineAddress) ? "N/A" : coalYearlyViewModel.objMine.MineAddress;
                coalYearlyMineDetailsModel.MineDistrict = coalYearlyViewModel.objMine.MineDistrict;
                coalYearlyMineDetailsModel.MineState = coalYearlyViewModel.objMine.MineState;
                coalYearlyMineDetailsModel.MineTehsil = coalYearlyViewModel.objMine.MineTehsil;
                coalYearlyMineDetailsModel.LesseeName = coalYearlyViewModel.objMine.LesseeName;
                coalYearlyMineDetailsModel.LesseeAddress = coalYearlyViewModel.objMine.LesseeAddress;
                coalYearlyViewModel.objMine = coalYearlyMineDetailsModel;
                coalYearlyViewModel.objEmployment = Get_EMPLOYMENT(Financial_Year);
                coalYearlyViewModel.objElectrical = Get_ELECTRICAL(Financial_Year);
                coalYearlyViewModel.objMachinery = Get_EQUIPMENT(Financial_Year);
                coalYearlyViewModel.objVentilators = Get_MECHANICAL_VENTILATORS(Financial_Year);
                coalYearlyViewModel.objE_Explosives_b = Get_E_EXPLOSIVES_b(Financial_Year);
                ViewBag.Year = Financial_Year;
                return View(coalYearlyViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// To Save FORM III
        /// </summary>
        /// <param name="objModel"></param>
        /// <param name="list_Designations"></param>
        /// <param name="list_Numbers_employed"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FORMIII(CoalYearlyViewModel objModel, List<string> list_Designations, List<int> list_Numbers_employed)
        {
            try
            {
                StringBuilder sb_list_Designations = new StringBuilder();
                StringBuilder sb_Numbers_employed = new StringBuilder();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.UserId = profile.UserId; //150;

                #region Save & Update Mine Details
                if (list_Designations != null)
                {
                    for (int i = 0; i < list_Designations.Count; i++)
                    {
                        sb_list_Designations.Append(Convert.ToString(list_Designations[i]));
                        sb_list_Designations.Append(",");
                    }
                    sb_list_Designations.Length--;
                }

                if (list_Designations != null)
                {
                    for (int i = 0; i < list_Numbers_employed.Count; i++)
                    {
                        sb_Numbers_employed.Append(Convert.ToString(list_Numbers_employed[i]));
                        sb_Numbers_employed.Append(",");
                    }
                    sb_Numbers_employed.Length--;
                }

                if (!string.IsNullOrEmpty(sb_list_Designations.ToString()))
                    objModel.objMine.Designations = sb_list_Designations.ToString();
                if (!string.IsNullOrEmpty(sb_Numbers_employed.ToString()))
                    objModel.objMine.Numbers_employed = sb_Numbers_employed.ToString();
                if (objModel.objMine.Flag == 1)
                {
                    messageEF = returnCoalYearlyModel.Update_MineDetails(objModel);
                    TempData["resultMine"] = messageEF.Satus;

                }
                else if (objModel.objMine.Flag == 2)
                {
                    messageEF = returnCoalYearlyModel.ADD_MineDetails(objModel);
                    TempData["resultMine"] = messageEF.Satus;
                }
                #endregion

                #region Save & Update Table A
                if (objModel.objEmployment.Flag == 1)
                {
                    messageEF = returnCoalYearlyModel.Update_EMPLOYMENT(objModel);
                    TempData["resultMine"] = messageEF.Satus;
                }
                else if (objModel.objEmployment.Flag == 2)
                {
                    messageEF = returnCoalYearlyModel.ADD_EMPLOYMENT(objModel);
                    TempData["resultMine"] = messageEF.Satus;
                }
                #endregion

                #region Save & Update Table B
                if (objModel.objElectrical.Flag == 1)
                {
                    messageEF = returnCoalYearlyModel.Update_ELECTRICAL_APPARTATUS(objModel);
                    TempData["resultMine"] = messageEF.Satus;

                }
                else if (objModel.objElectrical.Flag == 2)
                {
                    messageEF = returnCoalYearlyModel.ADD_ELECTRICAL_APPARTATUS(objModel);
                    TempData["resultMine"] = messageEF.Satus;
                }
                #endregion

                #region Save & Update Table C
                if (objModel.objMachinery.Flag == 1)
                {
                    messageEF = returnCoalYearlyModel.Update_MACHINERY_EQUIPMENT(objModel);
                    TempData["resultMine"] = messageEF.Satus;

                }
                else if (objModel.objMachinery.Flag == 2)
                {
                    messageEF = returnCoalYearlyModel.ADD_MACHINERY_EQUIPMENT(objModel);
                    TempData["resultMine"] = messageEF.Satus;
                }
                #endregion

                #region Save & Update Table D
                if (objModel.objVentilators.Flag == 1)
                {
                    messageEF = returnCoalYearlyModel.Update_MECHANICAL_VENTILATORS(objModel);
                    TempData["resultMine"] = messageEF.Satus;
                }
                else if (objModel.objVentilators.Flag == 2)
                {
                    messageEF = returnCoalYearlyModel.ADD_MECHANICAL_VENTILATORS(objModel);
                    TempData["resultMine"] = messageEF.Satus;
                }
                #endregion

                #region Save & Update Table E(b)
                if (objModel.objE_Explosives_b.Flag == 1)
                {
                    messageEF = returnCoalYearlyModel.Update_E_EXPLOSIVES_b(objModel);
                    TempData["resultMine"] = messageEF.Satus;

                }
                else if (objModel.objE_Explosives_b.Flag == 2)
                {
                    messageEF = returnCoalYearlyModel.ADD_E_EXPLOSIVES_b(objModel);
                    TempData["resultMine"] = messageEF.Satus;
                }
                #endregion

                #region Final Submit
                if (objModel.objE_Explosives_b.FinalSubmitFlag == 1)
                {
                    objModel.objE_Explosives_b.UserId = 150;
                    messageEF = returnCoalYearlyModel.Update_FinalSubmit(objModel.objE_Explosives_b);
                    TempData["resultSubmit"] = messageEF.Satus;
                    return RedirectToAction("YearlyReturn", "Annual_Return", new { area = "eReturn_NonCoal_Yearly" });
                }
                #endregion

                return RedirectToAction("FORMIII", new { Financial_Year = TempData["F_Y"].ToString() });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Mine Details
        /// <summary>
        /// Get Mine Details
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public CoalYearlyMineDetailsModel Get_CoalYearlyMineDetails(string Year)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //150;
                coalYearlyMineDetailsModel = returnCoalYearlyModel.Get_CoalYearlyMineDetails(yearlyReturnModel);
                if (!string.IsNullOrEmpty(coalYearlyMineDetailsModel.Designations))
                {
                    string[] list_Designations = coalYearlyMineDetailsModel.Designations.Split(',');
                    List<string> lstDesignation = new List<string>();
                    foreach (string item in list_Designations)
                    {
                        lstDesignation.Add(item);
                    }
                    coalYearlyMineDetailsModel.DesignationsList = lstDesignation;
                }
                if (!string.IsNullOrEmpty(coalYearlyMineDetailsModel.Numbers_employed))
                {
                    string[] list_Number_emp = coalYearlyMineDetailsModel.Numbers_employed.Split(',');
                    List<string> lstNumber = new List<string>();
                    foreach (string i in list_Number_emp)
                    {
                        lstNumber.Add(i);
                    }
                    coalYearlyMineDetailsModel.Numbers_employedList = lstNumber;
                }
                return coalYearlyMineDetailsModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Table A
        /// <summary>
        /// Get Employment Details
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public EMPLOYMENT Get_EMPLOYMENT(string Year)
        {
            EMPLOYMENT eMPLOYMENT = new EMPLOYMENT();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //150;
                eMPLOYMENT = returnCoalYearlyModel.Get_EMPLOYMENT(yearlyReturnModel);
                return eMPLOYMENT;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Table B
        /// <summary>
        /// To Get ELECTRICAL APPARTATUS Details Data in View
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public ELECTRICAL_APPARTATUS Get_ELECTRICAL(string Year)
        {
            ELECTRICAL_APPARTATUS eLECTRICAL_APPARTATUS = new ELECTRICAL_APPARTATUS();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //150;
                eLECTRICAL_APPARTATUS = returnCoalYearlyModel.Get_ELECTRICAL_APPARTATUS(yearlyReturnModel);
                return eLECTRICAL_APPARTATUS;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Table C
        /// <summary>
        /// To Get MACHINERY EQUIPMENT Details Data in View
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public MACHINERY_EQUIPMENT Get_EQUIPMENT(string Year)
        {
            MACHINERY_EQUIPMENT mACHINERY_EQUIPMENT = new MACHINERY_EQUIPMENT();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //150;
                mACHINERY_EQUIPMENT = returnCoalYearlyModel.Get_MACHINERY_EQUIPMENT(yearlyReturnModel);
                return mACHINERY_EQUIPMENT;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Table D
        /// <summary>
        /// To Get MECHANICAL VENTILATORS Details Data in View
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public MECHANICAL_VENTILATORS Get_MECHANICAL_VENTILATORS(string Year)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //150;
                MECHANICAL_VENTILATORS mECHANICAL_VENTILATORS = returnCoalYearlyModel.Get_MECHANICAL_VENTILATORS(yearlyReturnModel);
                return mECHANICAL_VENTILATORS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region E – EXPLOSIVES
        /// <summary>
        /// To Get E EXPLOSIVES Details Data in View
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public JsonResult GetE_EXPLOSIVES(string Year)
        {
            List<E_EXPLOSIVES> list = new List<E_EXPLOSIVES>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //150;
                list = returnCoalYearlyModel.GetE_EXPLOSIVES(yearlyReturnModel);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// To Add E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="MineralGradeId"></param>
        /// <param name="Opening_stocks"></param>
        /// <param name="Coal_raised"></param>
        /// <param name="Totalvalueofrasing"></param>
        /// <param name="TotalI"></param>
        /// <param name="Coaldespatched"></param>
        /// <param name="Collieryconsumption"></param>
        /// <param name="Coalusedforcoking"></param>
        /// <param name="Shortagedueto_Causes"></param>
        /// <param name="Closingstocks"></param>
        /// <param name="TotalII"></param>
        /// <param name="Year1"></param>
        /// <returns></returns>
        public JsonResult AddE_EXPLOSIVES(int? MineralGradeId, string Opening_stocks, string Coal_raised,
            string Totalvalueofrasing, string TotalI, string Coaldespatched, string Collieryconsumption,
            string Coalusedforcoking, string Shortagedueto_Causes, string Closingstocks, string TotalII, string Year1)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                E_EXPLOSIVES objModel = new E_EXPLOSIVES();
                objModel.MineralGradeId = MineralGradeId;
                objModel.Opening_stocks = Opening_stocks;
                objModel.Coal_raised = Coal_raised;
                objModel.Totalvalueofrasing = Totalvalueofrasing;
                objModel.TotalI = TotalI;
                objModel.Coaldespatched = Coaldespatched;
                objModel.Collieryconsumption = Collieryconsumption;
                objModel.Coalusedforcoking = Coalusedforcoking;
                objModel.Shortagedueto_Causes = Shortagedueto_Causes;
                objModel.Closingstocks = Closingstocks;
                objModel.TotalII = TotalII;
                objModel.Year1 = Year1;
                objModel.UserId = profile.UserId; //150;
                messageEF = returnCoalYearlyModel.AddE_EXPLOSIVES(objModel);
                return Json(messageEF.Satus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Update E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult UpdateE_EXPLOSIVES(E_EXPLOSIVES objModel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.UserId = profile.UserId; //150;
                messageEF = returnCoalYearlyModel.UpdateE_EXPLOSIVES(objModel);
                return Json(messageEF.Satus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Delete E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult DeleteE_EXPLOSIVES(int? Id)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (Id != null && Id != 0)
                {
                    E_EXPLOSIVES objModel = new E_EXPLOSIVES();
                    objModel.E_Explosive_Id = Id;
                    objModel.UserId = profile.UserId; //150;
                    messageEF = returnCoalYearlyModel.DeleteE_EXPLOSIVES(objModel);
                }
                return Json(messageEF.Satus);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Print E EXPLOSIVES Details Data in View
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public List<E_EXPLOSIVES> GetE_EXPLOSIVES_ForPrint(string Year)
        {
            List<E_EXPLOSIVES> list = new List<E_EXPLOSIVES>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //150;
                list = returnCoalYearlyModel.GetE_EXPLOSIVES(yearlyReturnModel);
                return list;
            }
            catch (Exception ex)
            {
                return list; throw ex;
            }
        }

        /// <summary>
        /// To Get Mineral Grade Details Data 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMineralGarde()
        {
            List<E_EXPLOSIVES> lste_EXPLOSIVEs = new List<E_EXPLOSIVES>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.UserId = profile.UserId; //150;
                lste_EXPLOSIVEs = returnCoalYearlyModel.GetMineralGarde(yearlyReturnModel);
                return Json(lste_EXPLOSIVEs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Get Details By Mineral Id Data 
        /// </summary>
        /// <param name="MineralGradeId"></param>
        /// <returns></returns>
        public JsonResult Change_MineralGrade(int MineralGradeId)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.MineralGradeId = MineralGradeId;
                yearlyReturnModel.UserId = profile.UserId; //150;
                E_EXPLOSIVES eEXPLOSIVES = returnCoalYearlyModel.Change_MineralGrade(yearlyReturnModel);
                return Json(eEXPLOSIVES);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Table E(b)
        /// <summary>
        /// To Get E EXPLOSIVES b Details Data in View
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public E_EXPLOSIVES_b Get_E_EXPLOSIVES_b(string Year)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //150;
                E_EXPLOSIVES_b e_EXPLOSIVES_B = returnCoalYearlyModel.Get_E_EXPLOSIVES_b(yearlyReturnModel);
                return e_EXPLOSIVES_B;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Print Preview
        /// <summary>
        /// Print FORM III
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns></returns>
        public ActionResult Print_FORMIII(string Financial_Year)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.EncryptData = Financial_Year;
            Financial_Year = protector.Unprotect(Financial_Year);
            coalYearlyViewModel.objMine = Get_CoalYearlyMineDetails(Financial_Year);
            coalYearlyViewModel.objEmployment = Get_EMPLOYMENT(Financial_Year);
            coalYearlyViewModel.objElectrical = Get_ELECTRICAL(Financial_Year);
            coalYearlyViewModel.objMachinery = Get_EQUIPMENT(Financial_Year);
            coalYearlyViewModel.objVentilators = Get_MECHANICAL_VENTILATORS(Financial_Year);
            coalYearlyViewModel.objE_Explosives_b = Get_E_EXPLOSIVES_b(Financial_Year);
            coalYearlyViewModel.obje_EXPLOSIVEs = GetE_EXPLOSIVES_ForPrint(Financial_Year);
            ViewBag.UserId = profile.UserId; //150;
            ViewBag.Year = Financial_Year;
            TempData["F_Y"] = Financial_Year;
            ViewBag.ServerPath = configuration.GetSection("MySettings").GetValue<string>("ServerPath");
            ViewBag.DSCReadFilePath = configuration.GetSection("MySettings").GetValue<string>("DSCReadFilePath");
            return View(coalYearlyViewModel);
        }
        #endregion

        #endregion

        #region DSC Response Verify 
        string Signature = string.Empty;
        /// <summary>
        /// Check Verify Response
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="signDataBase64Encoded"></param>
        /// <param name="responseType"></param>
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
        /// Save PDF File With Digital Signature
        /// </summary>
        /// <param name="base64BinaryStr"></param>
        /// <param name="fileName"></param>
        /// <param name="ID"></param>
        /// <param name="UpdateIn"></param>
        /// <param name="Month_Year"></param>
        /// <returns></returns>
        public JsonResult SavePdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn, string Month_Year)
        {
            string OutputResult = "SUCCESS";
            try
            {
                var ServerPath = "DSC/WithDSC/" + fileName;
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("MySettings").GetValue<string>("FNDSCCreateFilePATH"));
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


                //using (SqlCommand cmd = new SqlCommand())
                //{
                //    if (ID == 0)
                //    {
                //        ID = Convert.ToInt32(TempData["FNID"]);

                //    }
                //    cmd.CommandText = "UpdateDSCPath";
                //    cmd.Parameters.AddWithValue("@fileName", ServerPath);
                //    cmd.Parameters.AddWithValue("@ID", ID);
                //    cmd.Parameters.AddWithValue("@UpdateIn", UpdateIn.ToUpper());
                //    cmd.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //    cmd.Parameters.AddWithValue("@MonthYear", Month_Year);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    object retID = db.GetSingleValue(cmd);
                //    if (retID == null)
                //    {
                //        OutputResult = "FAILED";
                //    }
                //}






            }
            catch (Exception ex)
            {
                OutputResult = "FAILED";
            }
            return Json(OutputResult.ToUpper());
        }

        /// <summary>
        /// Save PDF File Without Digital Signature
        /// </summary>
        /// <param name="base64BinaryStr"></param>
        /// <param name="fileName"></param>
        /// <param name="ID"></param>
        /// <param name="UpdateIn"></param>
        /// <returns></returns>
        public JsonResult SaveNormalPdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn)
        {
            string OutputResult = "SUCCESS";
            try
            {

                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("MySettings").GetValue<string>("FNDSCReadFilePATH"));
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
