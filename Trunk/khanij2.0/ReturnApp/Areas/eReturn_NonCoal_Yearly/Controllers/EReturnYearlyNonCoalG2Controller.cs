// ***********************************************************************
//  Controller Name          : ReturnYearlyNonCoal G2
//  Desciption               : To be used for minerals Copper, Gold, Lead, Pyrites, Tin, Tungsten and Zinc
//  Created By               : Akshaya Dalei
//  Created On               : 28 July 2021
// ***********************************************************************

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReturnApp.Areas.eReturn_NonCoal_Yearly.Models;
using ReturnApp.Web;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApp.Areas.eReturn_NonCoal_Yearly.Controllers
{
    [Area("eReturn_NonCoal_Yearly")]
    public class EReturnYearlyNonCoalG2Controller : Controller
    {
        private readonly IeReturnNonCoalYearlyG2Model yearlyNonCoalModel;
        private readonly IDataProtectionProvider dataProtectionProvider;
        private readonly IConfiguration configuration;
        private readonly IDataProtector protector;
        YearlyReturnModel yearlyReturnModel = new YearlyReturnModel();
        List<YearlyReturnModel> lstYearlyReturnModel = new List<YearlyReturnModel>();
        AnnualReturnH1ViewModel annualReturnH1ViewModel = new AnnualReturnH1ViewModel();
        AnnualReturnH1PartTwoModel annualReturnH1PartTwoModel = new AnnualReturnH1PartTwoModel();
        MineDetailsModel mineDetailsModel = new MineDetailsModel();
        AnnualReturnH1PartThreeModel annualReturnH1PartThreeModel = new AnnualReturnH1PartThreeModel();
        AnnualReturnH1PartFourModel annualReturnH1PartFourModel = new AnnualReturnH1PartFourModel();
        AnnualReturnH1PartFiveModel annualReturnH1PartFiveModel = new AnnualReturnH1PartFiveModel();
        FormF2PartTwoViewModel annualReturnG2PartSixViewModel = new FormF2PartTwoViewModel();
        MessageEF messageEF = new MessageEF();
       
        public EReturnYearlyNonCoalG2Controller(IeReturnNonCoalYearlyG2Model yearlyNonCoalModel, IDataProtectionProvider dataProtectionProvider, IConfiguration configuration)
        {
            this.yearlyNonCoalModel = yearlyNonCoalModel;
            this.dataProtectionProvider = dataProtectionProvider;
            this.configuration = configuration;
            protector = dataProtectionProvider.CreateProtector(configuration.GetSection("Encryption").GetValue<string>("EncryptionKey"));
           
        }

        public IActionResult YearlyReturn()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.UserId = profile.UserId; //132;
                var lstYearlyReturnModel = yearlyNonCoalModel.GetYearlyReturnDetails(yearlyReturnModel)
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

        #region Form H2
        #region Part One
        #region Part One View Page
        /// <summary>
        /// To Bind Mine Details,Other Mine Details,Particulars Of Area,Lease Area
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns></returns>
        public IActionResult PartOneH2(string Financial_Year)
        {
            ViewBag.FinancialYear = Financial_Year;
            TempData["F_Y"] = Financial_Year;
            Financial_Year = protector.Unprotect(Financial_Year);
            if (TempData["result_G2"] != null)
            {
                ViewBag.msg = TempData["result_G2"].ToString();
            }
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            yearlyReturnModel.UserId = profile.UserId; //132;
            yearlyReturnModel.Year = Financial_Year;
            mineDetailsModel = yearlyNonCoalModel.GetLesseMineDeatils(yearlyReturnModel);
            annualReturnH1ViewModel = yearlyNonCoalModel.GetMineOtherDetails(yearlyReturnModel);
            //-------------Mine Details--------
            if (annualReturnH1ViewModel.objOtherDetails.OtherDetails_Id > 0)
            {
                if (string.IsNullOrEmpty(annualReturnH1ViewModel.objMineDetails.OtherMineral))
                    annualReturnH1ViewModel.objMineDetails.OtherMineral = mineDetailsModel.OtherMineral;
                if (string.IsNullOrEmpty(annualReturnH1ViewModel.objMineDetails.MineName))
                    annualReturnH1ViewModel.objMineDetails.MineName = mineDetailsModel.MineName;
                annualReturnH1ViewModel.objMineDetails.MinePostOffice = mineDetailsModel.MinePostOffice;
                annualReturnH1ViewModel.objMineDetails.MineFaxNo = mineDetailsModel.MineFaxNo;
                annualReturnH1ViewModel.objMineDetails.LesseePostOffice = mineDetailsModel.LesseePostOffice;
                annualReturnH1ViewModel.objMineDetails.LesseeFaxNo = mineDetailsModel.LesseeFaxNo;
            }
            else
            {
                annualReturnH1ViewModel.objMineDetails = mineDetailsModel;
            }
            //----------------End Here------------- 


            annualReturnH1ViewModel.objParticular = yearlyNonCoalModel.GetParticularsofArea(yearlyReturnModel);
            annualReturnH1ViewModel.objLeaseArea = yearlyNonCoalModel.GetLeasearea(yearlyReturnModel);
            ViewData["AgencyOfMine"] = yearlyNonCoalModel.GetAgencyOfMine(profile.UserId);
            ViewBag.Year = Financial_Year;

            return View(annualReturnH1ViewModel);
        }
        #endregion

        #region Save Part One
        /// <summary>
        /// To Save Mine Details,Other Mine Details,Particulars Of Area,Lease Area
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PartOneH2(AnnualReturnH1ViewModel objModel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objModel.UserId = profile.UserId; //132;
            objModel.objParticular.UserId = profile.UserId; //132;
            objModel.objLeaseArea.UserId = profile.UserId; //132;
            if (objModel.objOtherDetails.Flag1 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateMineOtherDetails(objModel);
                TempData["result_G2"] = messageEF.Satus;

            }
            else if (objModel.objOtherDetails.Flag1 == 2)
            {
                messageEF = yearlyNonCoalModel.AddMineOtherDetails(objModel);
                TempData["result_G2"] = messageEF.Satus;
            }

            if (objModel.objParticular.Flag2 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateParticularsofArea(objModel.objParticular);
                TempData["result_G2"] = messageEF.Satus;
            }
            else if (objModel.objParticular.Flag2 == 2)
            {
                messageEF = yearlyNonCoalModel.AddParticularsofArea(objModel.objParticular);
                TempData["result_G2"] = messageEF.Satus;

            }

            if (objModel.objLeaseArea.Flag3 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateLeasearea(objModel.objLeaseArea);
                TempData["result_G2"] = messageEF.Satus;
            }
            else if (objModel.objLeaseArea.Flag3 == 2)
            {
                messageEF = yearlyNonCoalModel.AddLeasearea(objModel.objLeaseArea);
                TempData["result_G2"] = messageEF.Satus;

            }

            return RedirectToAction("PartOneH2", "EReturnYearlyNonCoalG2", new { area = "eReturn_NonCoal_Yearly", Financial_Year = TempData["F_Y"].ToString() });
        }

        #endregion

        #endregion

        #region Part Two
        #region Part Two View Page
        /// <summary>
        /// To Bind Staff Details,Work Details,Salary/Wages Paid,Part-II A(Capital Structure),Part-II A(Source Of Finance/Interest and Rent)
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns></returns>
        public IActionResult PartTwoH2(string Financial_Year)
        {
            ViewBag.FinancialYear = Financial_Year;
            TempData["F_Y"] = Financial_Year;
            Financial_Year = protector.Unprotect(Financial_Year);
            if (TempData["resultPart2_G2"] != null)
            {
                ViewBag.msg = TempData["resultPart2_G2"].ToString();
            }
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            yearlyReturnModel.UserId = profile.UserId; //132;
            yearlyReturnModel.Year = Financial_Year;
            //-----------------Get Staff and Work Details------
            annualReturnH1PartTwoModel.objStaffWork = yearlyNonCoalModel.GetStaffandWork(yearlyReturnModel);
            //------------------End Here---------------------
            //------------------Get Work Details---------------------
            annualReturnH1PartTwoModel.objWork = yearlyNonCoalModel.GetWorkDetails(yearlyReturnModel);
            //------------------End Here------------------------
            //----------------Get Salary/Wages Paid------------
            annualReturnH1PartTwoModel.objSalaryWages = yearlyNonCoalModel.GetSalaryWagesPaid(yearlyReturnModel);
            //----------------End Here--------------------------
            //---------------Get Capital Structure-----------
            annualReturnH1PartTwoModel.objCapitalStructure = yearlyNonCoalModel.GetCapitalStructure(yearlyReturnModel);
            //---------------End Here----------------------
            //---------------Get Source Of Finance------------
            annualReturnH1PartTwoModel.objSource = yearlyNonCoalModel.GetSourceOfFinance(yearlyReturnModel);
            //---------------End Here---------------
            ViewBag.Year = Financial_Year;
            return View(annualReturnH1PartTwoModel);
        }
        #endregion

        #region Save Part Two H2
        /// <summary>
        /// To Save Staff Details,Work Details,Salary/Wages Paid,Part-II A(Capital Structure),Part-II A(Source Of Finance/Interest and Rent)
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PartTwoH2(AnnualReturnH1PartTwoModel objModel, List<int?> Work_Id, List<string> Reason, List<int?> NoOfDaysMineStop)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objModel.objStaffWork.UserId = profile.UserId; //132;
            objModel.objWork.UserId = profile.UserId; //132;
            objModel.objSalaryWages.UserId = profile.UserId; //132;
            objModel.objCapitalStructure.UserId = profile.UserId; //132;
            objModel.objSource.UserId = profile.UserId; //132;

            #region Staff Details
            if (objModel.objStaffWork.Flag1 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateStaffandWork(objModel.objStaffWork);
                TempData["resultPart2_G2"] = messageEF.Satus;

            }
            else if (objModel.objStaffWork.Flag1 == 2)
            {
                messageEF = yearlyNonCoalModel.AddStaffandWork(objModel.objStaffWork);
                TempData["resultPart2_G2"] = messageEF.Satus;
            }
            #endregion

            #region Work Details
            objModel.objWork.Work_Id = Work_Id;
            objModel.objWork.Reason = Reason;
            objModel.objWork.NoOfDaysMineStop = NoOfDaysMineStop;
            if (objModel.objWork.Flag == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateWorkDetails(objModel.objWork);
                TempData["resultPart2_G2"] = messageEF.Satus;

            }
            else if (objModel.objWork.Flag == 2)
            {
                messageEF = yearlyNonCoalModel.AddWorkDetails(objModel.objWork);
                TempData["resultPart2_G2"] = messageEF.Satus;
            }
            #endregion

            #region Salary/Wages Paid
            if (objModel.objSalaryWages.Flag2 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateSalaryWagesPaid(objModel.objSalaryWages);
                TempData["resultPart2_G2"] = messageEF.Satus;

            }
            else if (objModel.objSalaryWages.Flag2 == 2)
            {
                messageEF = yearlyNonCoalModel.AddSalaryWagesPaid(objModel.objSalaryWages);
                TempData["resultPart2_G2"] = messageEF.Satus;
            }
            #endregion

            #region Part-II A(Capital Structure)
            if (objModel.objCapitalStructure.Flag3 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateCapitalStructure(objModel.objCapitalStructure);
                TempData["resultPart2_G2"] = messageEF.Satus;

            }
            else if (objModel.objCapitalStructure.Flag3 == 2)
            {
                messageEF = yearlyNonCoalModel.AddCapitalStructure(objModel.objCapitalStructure);
                TempData["resultPart2_G2"] = messageEF.Satus;
            }
            #endregion

            #region Part-II A(Source Of Finance/Interest and Rent)
            if (objModel.objSource.Flag4 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateSourceOfFinance(objModel.objSource);
                TempData["resultPart2_G2"] = messageEF.Satus;
            }
            else if (objModel.objSource.Flag4 == 2)
            {
                messageEF = yearlyNonCoalModel.AddSourceOfFinance(objModel.objSource);
                TempData["resultPart2_G2"] = messageEF.Satus;
            }
            #endregion

            return RedirectToAction("PartTwoH2", "EReturnYearlyNonCoalG2", new { Area = "eReturn_NonCoal_Yearly", Financial_Year = TempData["F_Y"].ToString() });
        }
        #endregion

        #endregion

        #region Part Three
        #region Part Three View Page
        /// <summary>
        /// To Bind Quantity and Cost of Material Consumed,Royalty,Rents and Payments
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns></returns>
        public IActionResult PartThreeH2(string Financial_Year)
        {
            ViewBag.FinancialYear = Financial_Year;
            TempData["F_Y"] = Financial_Year;
            Financial_Year = protector.Unprotect(Financial_Year);
            if (TempData["resultPart3_G2"] != null)
            {
                ViewBag.msg = TempData["resultPart3_G2"].ToString();
            }
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            yearlyReturnModel.UserId = profile.UserId; //132;
            yearlyReturnModel.Year = Financial_Year;
            //-----------Get Material Consumed-----------
            annualReturnH1PartThreeModel.objMaterialConsumed = yearlyNonCoalModel.GetMaterialConsumed(yearlyReturnModel);
            //-----------End Here--------------------------
            //-----------Get Royalty and Rent----------------
            annualReturnH1PartThreeModel.objRoyaltyandRents = yearlyNonCoalModel.GetRoyaltyandRent(yearlyReturnModel);
            //-----------End Here-----------------------------
            ViewBag.Year = Financial_Year;
            return View(annualReturnH1PartThreeModel);
        }
        #endregion

        #region Save Part Three H2
        /// <summary>
        /// To Save Quantity and Cost of Material Consumed,Royalty,Rents and Payments
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PartThreeH2(AnnualReturnH1PartThreeModel objModel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objModel.objMaterialConsumed.UserId = profile.UserId; //132;
            objModel.objRoyaltyandRents.UserId = profile.UserId; //132;
            #region Quantity and Cost Of Material Consumed
            if (objModel.objMaterialConsumed.Flag1 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateMaterialConsumed(objModel.objMaterialConsumed);
                TempData["resultPart3_G2"] = messageEF.Satus;

            }
            else if (objModel.objMaterialConsumed.Flag1 == 2)
            {
                messageEF = yearlyNonCoalModel.AddMaterialConsumed(objModel.objMaterialConsumed);
                TempData["resultPart3_G2"] = messageEF.Satus;
            }
            #endregion

            #region Royalty,Rents and Payments
            if (objModel.objRoyaltyandRents.Flag2 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateRoyaltyandRent(objModel.objRoyaltyandRents);
                TempData["resultPart3_G2"] = messageEF.Satus;

            }
            else if (objModel.objRoyaltyandRents.Flag2 == 2)
            {
                messageEF = yearlyNonCoalModel.AddRoyaltyandRent(objModel.objRoyaltyandRents);
                TempData["resultPart3_G2"] = messageEF.Satus;
            }
            #endregion

            return RedirectToAction("PartThreeH2", "EReturnYearlyNonCoalG2", new { Area = "eReturn_NonCoal_Yearly", Financial_Year = TempData["F_Y"].ToString() });
        }
        #endregion
        #endregion

        #region Part Four
        #region Part Four View Page
        /// <summary>
        /// To Bind Consumption Of Explosives
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns></returns>
        public IActionResult PartFourH2(string Financial_Year)
        {
            ViewBag.FinancialYear = Financial_Year;
            TempData["F_Y"] = Financial_Year;
            Financial_Year = protector.Unprotect(Financial_Year);
            if (TempData["resultPart4_G2"] != null)
            {
                ViewBag.msg = TempData["resultPart4_G2"].ToString();
            }

            //-------------Get Consumption Of Explosives------------
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            yearlyReturnModel.UserId = profile.UserId; //132;
            yearlyReturnModel.Year = Financial_Year;
            annualReturnH1PartFourModel = yearlyNonCoalModel.GetExplosives(yearlyReturnModel);
            //-------------End Here------------------------
            //--------------Get Unit-----------------
            List<UnitType> lstUnit = new List<UnitType>();
            lstUnit = yearlyNonCoalModel.GetUnitTypeList(yearlyReturnModel);
            ViewData["Unit"] = lstUnit;
            //--------------End Here-----------------
            ViewBag.Year = Financial_Year;
            return View(annualReturnH1PartFourModel);
        }
        #endregion

        #region Part Four Save
        /// <summary>
        /// To Save Consumption Of Explosives
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PartFourH2(AnnualReturnH1PartFourModel objModel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objModel.UserId = profile.UserId; //132;
            if (objModel.Flag4 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateExplosives(objModel);
                TempData["resultPart4_G2"] = messageEF.Satus;

            }
            else if (objModel.Flag4 == 2)
            {
                messageEF = yearlyNonCoalModel.AddExplosives(objModel);
                TempData["resultPart4_G2"] = messageEF.Satus;
            }

            return RedirectToAction("PartFourH2", "EReturnYearlyNonCoalG2", new { Area = "eReturn_NonCoal_Yearly", Financial_Year = TempData["F_Y"].ToString() });
        }
        #endregion
        #endregion

        #region Part Five
        #region Part Five View Pge
        /// <summary>
        /// To Bind Exploration,Reserves and Resources estimated,Reject,Waste,Trees Planted/Survival,Type of Machinery,Details of mineral Treatment plant
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns></returns>
        public IActionResult PartFiveH2(string Financial_Year)
        {
            if (TempData["resultPart5_G2"] != null)
            {
                ViewBag.msg = TempData["resultPart5_G2"].ToString();
            }
            ViewBag.FinancialYear = Financial_Year;
            TempData["F_Y"] = Financial_Year;
            Financial_Year = protector.Unprotect(Financial_Year);
            yearlyReturnModel.Year = Financial_Year;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            yearlyReturnModel.UserId = profile.UserId; //132;
            //----------Get Exploration-------------
            annualReturnH1PartFiveModel.objExploration = yearlyNonCoalModel.GetExploration(yearlyReturnModel);
            //----------End Here-----------------
            //-----------Get Reserves and Resources--------------
            annualReturnH1PartFiveModel.objResources = yearlyNonCoalModel.GetResources(yearlyReturnModel);
            //-----------End Here-----------------------
            //-----------Get Reject,Waste,Trees Planted/Survival-------------------
            annualReturnH1PartFiveModel.objRejectWaste = yearlyNonCoalModel.GetRejectWasteTreesPlanted(yearlyReturnModel);
            //-----------End Here----------------------
            //-----------Get Details Of Mineral Treatment Plant---------------
            annualReturnH1PartFiveModel.objFurnishDetails = yearlyNonCoalModel.GetFurnishDetails(yearlyReturnModel);
            //-----------End Here---------------------

            ViewBag.Year = Financial_Year;
            string[] year = Financial_Year.Split('-');
            ViewBag.begning = year[0].ToString();
            ViewBag.closing = year[1].ToString();
            return View(annualReturnH1PartFiveModel);
        }
        #endregion

        #region Save Part Five
        /// <summary>
        /// To Save Exploration,Reserves and Resources estimated,Reject,Waste,Trees Planted/Survival,Type of Machinery,Details of mineral Treatment plant
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PartFiveH2(AnnualReturnH1PartFiveModel objModel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objModel.objExploration.UserId = profile.UserId; //132;
            objModel.objResources.UserId = profile.UserId; //132;
            objModel.objRejectWaste.UserId = profile.UserId; //132;
            objModel.objFurnishDetails.UserId = profile.UserId; //132;

            #region Exploration
            if (objModel.objExploration.Flag1 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateExploration(objModel.objExploration);
                TempData["resultPart5_G2"] = messageEF.Satus;

            }
            else if (objModel.objExploration.Flag1 == 2)
            {
                messageEF = yearlyNonCoalModel.AddExploration(objModel.objExploration);
                TempData["resultPart5_G2"] = messageEF.Satus;
            }
            #endregion

            #region Reserves and Resources estimated
            if (objModel.objResources.Flag2 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateResources(objModel.objResources);
                TempData["resultPart5_G2"] = messageEF.Satus;

            }
            else if (objModel.objResources.Flag2 == 2)
            {
                messageEF = yearlyNonCoalModel.AddResources(objModel.objResources);
                TempData["resultPart5_G2"] = messageEF.Satus;
            }
            #endregion

            #region Reject,Waste,Trees Planted/Survival
            if (objModel.objRejectWaste.Flag3 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateRejectWaste(objModel.objRejectWaste);
                TempData["resultPart5_G2"] = messageEF.Satus;

            }
            else if (objModel.objRejectWaste.Flag3 == 2)
            {
                messageEF = yearlyNonCoalModel.AddRejectWaste(objModel.objRejectWaste);
                TempData["resultPart5_G2"] = messageEF.Satus;
            }
            #endregion

            #region Details Of Mineral Treatment Plant
            if (objModel.objFurnishDetails.Flag4 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateFurnishDetails(objModel.objFurnishDetails);
                TempData["resultPart5_G2"] = messageEF.Satus;

            }
            else if (objModel.objFurnishDetails.Flag4 == 2)
            {
                messageEF = yearlyNonCoalModel.AddFurnishDetails(objModel.objFurnishDetails);
                TempData["resultPart5_G2"] = messageEF.Satus;
            }
            #endregion
            return RedirectToAction("PartFiveH2", "EReturnYearlyNonCoalG2", new { Area = "eReturn_NonCoal_Yearly", Financial_Year = TempData["F_Y"].ToString() });
        }
        #endregion

        #region Machinery Details
        #region Add Machinery
        /// <summary>
        /// To Add Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult AddMachineryDetails(string TypeofMachinery, string Capacity, string Capacity_Unit,
            string NoofMachinery, string Type_Electrical, string Used_Area, string Year)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                MachineryDetails objModel = new MachineryDetails();
                objModel.TypeofMachinery = TypeofMachinery;
                objModel.Capacity = Capacity;
                objModel.Capacity_Unit = Capacity_Unit;
                objModel.NoofMachinery = NoofMachinery;
                objModel.Type_Electrical = Type_Electrical;
                objModel.Used_Area = Used_Area;
                objModel.Year = Year;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.AddMachineryDetails(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Update Machinery
        /// <summary>
        /// To Update Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult UpdateMachineryDetails(int? MachineryType_Id, string TypeofMachinery, string Capacity, string Capacity_Unit,
            string NoofMachinery, string Type_Electrical, string Used_Area, string Year)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                MachineryDetails objModel = new MachineryDetails();
                objModel.MachineryType_Id = MachineryType_Id;
                objModel.TypeofMachinery = TypeofMachinery;
                objModel.Capacity = Capacity;
                objModel.Capacity_Unit = Capacity_Unit;
                objModel.NoofMachinery = NoofMachinery;
                objModel.Type_Electrical = Type_Electrical;
                objModel.Used_Area = Used_Area;
                objModel.Year = Year;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.UpdateMachineryDetails(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Delete Machinery
        /// <summary>
        /// To Delete Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult DeleteMachineryDetails(int? MachineryType_Id)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                MachineryDetails objModel = new MachineryDetails();
                objModel.MachineryType_Id = MachineryType_Id;
                objModel.UserId = profile.UserId; //132;

                messageEF = yearlyNonCoalModel.DeleteMachineryDetails(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Machinery Details
        /// <summary>
        /// To Bind Machinery Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult GetMachineryDetails(string Year)
        {
            List<MachineryDetails> list = new List<MachineryDetails>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //132;
                list = yearlyNonCoalModel.GetMachineryDetails(yearlyReturnModel);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion

        #region Type Of Machinery
        public JsonResult TypeOfMachinery()
        {
            //----------Type Of Machinery Details-------
            List<TypeOfMachinery> lstTypeOfMachinery = yearlyNonCoalModel.GetTypeOfMachineryDetails(yearlyReturnModel);
            //----------End Here-------------------
            return Json(lstTypeOfMachinery);
        }
        #endregion

        #endregion
        #endregion

        #region Part Six
        #region Part Six View Pge
        /// <summary>
        /// To Bind Production and Stocks,Recoveries at Concentrator,Recovery at the Smelter,Sales during the year,Details of deductions,Sales/Dispatches,Reasons for increase/decrease
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns></returns>
        public IActionResult PartSixH2(string Financial_Year)
        {
            if (TempData["resultPart6_G2"] != null)
            {
                ViewBag.msg = TempData["resultPart6_G2"].ToString();
            }

            ViewBag.FinancialYear = Financial_Year;
            TempData["F_Y"] = Financial_Year;
            Financial_Year = protector.Unprotect(Financial_Year);

            yearlyReturnModel.Year = Financial_Year;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            yearlyReturnModel.UserId = profile.UserId; //132;
            //--------Get Production and Stocks------------------- 
            annualReturnG2PartSixViewModel.objProduction = yearlyNonCoalModel.GetProductionandStocks(yearlyReturnModel);
            //-----------End Here---------------------------------
            //-----------Get Details Of Deduction-----------
            annualReturnG2PartSixViewModel.objDeduction = yearlyNonCoalModel.GetDetails_of_deductions(yearlyReturnModel);
            //------------End Here------------------------
            //-----------Get Reason for Increase/Decrease---------
            annualReturnG2PartSixViewModel.objReason_Reason_Inc_Dec = yearlyNonCoalModel.GetReason_Inc_Dec(yearlyReturnModel);
            //-----------End Here-------------------
            //-----------Mineral Info---------------

            MineralInfo mineralInfo = yearlyNonCoalModel.GetMineralInfo(yearlyReturnModel);
            string str = mineralInfo.MineralName;
            int MineralId = mineralInfo.MineralID;
            ViewBag.Mineral = str;
            ViewBag.MineralId = MineralId;
            //-----------End Here-------------------
            ViewBag.Year = Financial_Year;
            return View(annualReturnG2PartSixViewModel);
        }
        #endregion

        #region Save Part Six
        [HttpPost]
        public ActionResult PartSixH2(FormF2PartTwoViewModel objModel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objModel.objProduction.UserId = profile.UserId; //132;
            objModel.objDeduction.UserId = profile.UserId; //132;
            objModel.objReason_Reason_Inc_Dec.UserId = profile.UserId; //132;

            #region Product and Stocks
            if (objModel.objProduction.Flag == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateProductionandStocks(objModel.objProduction);
                TempData["resultPart6_G2"] = messageEF.Satus;
            }
            else if (objModel.objProduction.Flag == 2)
            {
                messageEF = yearlyNonCoalModel.AddProductionandStocks(objModel.objProduction);
                TempData["resultPart6_G2"] = messageEF.Satus;
            }
            #endregion

            #region Details Of Deduction
            if (objModel.objDeduction.Flag2 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateDetails_of_deductions(objModel.objDeduction);
                TempData["resultPart6_G2"] = messageEF.Satus;
            }
            else if (objModel.objDeduction.Flag2 == 2)
            {
                messageEF = yearlyNonCoalModel.AddDetails_of_deductions(objModel.objDeduction);
                TempData["resultPart6_G2"] = messageEF.Satus;
            }
            #endregion

            #region Reason For Increase/Decrease
            if (objModel.objReason_Reason_Inc_Dec.Flag3 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateReasonForInDc(objModel.objReason_Reason_Inc_Dec);
                TempData["resultPart6_G2"] = messageEF.Satus;
            }
            else if (objModel.objReason_Reason_Inc_Dec.Flag3 == 2)
            {
                messageEF = yearlyNonCoalModel.AddReasonForInDc(objModel.objReason_Reason_Inc_Dec);
                TempData["resultPart6_G2"] = messageEF.Satus;
            }
            #endregion

            return RedirectToAction("PartSixH2", "EReturnYearlyNonCoalG2", new { Area = "eReturn_NonCoal_Yearly", Financial_Year = TempData["F_Y"].ToString() });
        }
        #endregion

        #region Recoveries at Concentrator/Mill/Plant
        #region Add Recoveries
        /// <summary>
        /// To Add Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult AddRecoveries(string CS_grade, decimal? CS_qty, decimal? Concentrates_Value,
            string Concentrates_grade, decimal? Concentrates_qty, string OS_grade, decimal? OS_qty,
            string OreReceived_grade, decimal? OreReceived_qty, string OreTreated_grade, decimal? OreTreated_qty,
            string Tailing_grade, decimal? Tailings_Qty, string Year, int? MineralId)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                RecoveriesModel objModel = new RecoveriesModel();
                objModel.CS_grade = CS_grade;
                objModel.CS_qty = CS_qty;
                objModel.Concentrates_Value = Concentrates_Value;
                objModel.Concentrates_grade = Concentrates_grade;
                objModel.Concentrates_qty = Concentrates_qty;
                objModel.OS_grade = OS_grade;
                objModel.OS_qty = OS_qty;
                objModel.OreReceived_grade = OreReceived_grade;
                objModel.OreReceived_qty = OreReceived_qty;
                objModel.OreTreated_grade = OreTreated_grade;
                objModel.OreTreated_qty = OreTreated_qty;
                objModel.Tailing_grade = Tailing_grade;
                objModel.Tailings_Qty = Tailings_Qty;
                objModel.Year = Year;
                objModel.MineralId = MineralId;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.AddRecoveries(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Update Recoveries
        /// <summary>
        /// To Update Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult UpdateRecoveries(int Recoverie_Id, string CS_grade, decimal? CS_qty, decimal? Concentrates_Value,
            string Concentrates_grade, decimal? Concentrates_qty, string OS_grade, decimal? OS_qty,
            string OreReceived_grade, decimal? OreReceived_qty, string OreTreated_grade, decimal? OreTreated_qty,
            string Tailing_grade, decimal? Tailings_Qty, string Year, int? MineralId)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                RecoveriesModel objModel = new RecoveriesModel();
                objModel.Recoverie_Id = Recoverie_Id;
                objModel.CS_grade = CS_grade;
                objModel.CS_qty = CS_qty;
                objModel.Concentrates_Value = Concentrates_Value;
                objModel.Concentrates_grade = Concentrates_grade;
                objModel.Concentrates_qty = Concentrates_qty;
                objModel.OS_grade = OS_grade;
                objModel.OS_qty = OS_qty;
                objModel.OreReceived_grade = OreReceived_grade;
                objModel.OreReceived_qty = OreReceived_qty;
                objModel.OreTreated_grade = OreTreated_grade;
                objModel.OreTreated_qty = OreTreated_qty;
                objModel.Tailing_grade = Tailing_grade;
                objModel.Tailings_Qty = Tailings_Qty;
                objModel.Year = Year;
                objModel.MineralId = MineralId;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.UpdateRecoveries(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Delete Recoveries
        /// <summary>
        /// To Delete Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult DeleteRecoveries(int Recoverie_Id)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                RecoveriesModel objModel = new RecoveriesModel();
                objModel.Recoverie_Id = Recoverie_Id;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.DeleteRecoveries(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Get Recoveries
        /// <summary>
        /// To Delete Recoveries
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public JsonResult GetRecoveries(string Year)
        {
            List<RecoveriesModel> list = new List<RecoveriesModel>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //132;
                list = yearlyNonCoalModel.GetRecoveries(yearlyReturnModel);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion

        #endregion

        #region Recovery at the Smelter/Mill/Plant
        #region Add Recovery at the Smelter
        /// <summary>
        /// To Add Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult AddRecoveriesSmelter(string CS_grade, decimal? CS_qty, string Concentrates_othersources_grade,
            decimal? Concentrates_othersources_qty, string Concentrates_sold_grade, decimal? Concentrates_sold_qty,
            string Concentrates_treated_grade, decimal? Concentrates_treated_qty, string Concentratesreceived_grade,
            decimal? Concentratesreceived_qty, decimal? Metalsrecovered_Value, string Metalsrecovered_grade,
            decimal? Metalsrecovered_qty, string OS_grade, decimal? OS_qty, decimal? Other_byproducts_Value,
            string Other_byproducts_grade, decimal? Other_byproducts_qty, string Year, int? MineralId)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                Recovery_atSmelterModel objModel = new Recovery_atSmelterModel();
                objModel.CS_grade = CS_grade;
                objModel.CS_qty = CS_qty;
                objModel.Concentrates_othersources_grade = Concentrates_othersources_grade;
                objModel.Concentrates_othersources_qty = Concentrates_othersources_qty;
                objModel.Concentrates_sold_grade = Concentrates_sold_grade;
                objModel.Concentrates_sold_qty = Concentrates_sold_qty;
                objModel.Concentrates_treated_grade = Concentrates_treated_grade;
                objModel.Concentrates_treated_qty = Concentrates_treated_qty;
                objModel.Concentratesreceived_grade = Concentratesreceived_grade;
                objModel.Concentratesreceived_qty = Concentratesreceived_qty;
                objModel.Metalsrecovered_Value = Metalsrecovered_Value;
                objModel.Metalsrecovered_grade = Metalsrecovered_grade;
                objModel.Metalsrecovered_qty = Metalsrecovered_qty;
                objModel.OS_grade = OS_grade;
                objModel.OS_qty = OS_qty;
                objModel.Other_byproducts_Value = Other_byproducts_Value;
                objModel.Other_byproducts_grade = Other_byproducts_grade;
                objModel.Other_byproducts_qty = Other_byproducts_qty;
                objModel.Year = Year;
                objModel.MineralId = MineralId;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.AddRecoveriesSmelter(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Update Recovery at the Smelter
        /// <summary>
        /// To Update Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult UpdateRecoveriesSmelter(int? Recovery_atSmelter_Id, string CS_grade, decimal? CS_qty, string Concentrates_othersources_grade,
            decimal? Concentrates_othersources_qty, string Concentrates_sold_grade, decimal? Concentrates_sold_qty,
            string Concentrates_treated_grade, decimal? Concentrates_treated_qty, string Concentratesreceived_grade,
            decimal? Concentratesreceived_qty, decimal? Metalsrecovered_Value, string Metalsrecovered_grade,
            decimal? Metalsrecovered_qty, string OS_grade, decimal? OS_qty, decimal? Other_byproducts_Value,
            string Other_byproducts_grade, decimal? Other_byproducts_qty, string Year, int? MineralId)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                Recovery_atSmelterModel objModel = new Recovery_atSmelterModel();
                objModel.Recovery_atSmelter_Id = Recovery_atSmelter_Id;
                objModel.CS_grade = CS_grade;
                objModel.CS_qty = CS_qty;
                objModel.Concentrates_othersources_grade = Concentrates_othersources_grade;
                objModel.Concentrates_othersources_qty = Concentrates_othersources_qty;
                objModel.Concentrates_sold_grade = Concentrates_sold_grade;
                objModel.Concentrates_sold_qty = Concentrates_sold_qty;
                objModel.Concentrates_treated_grade = Concentrates_treated_grade;
                objModel.Concentrates_treated_qty = Concentrates_treated_qty;
                objModel.Concentratesreceived_grade = Concentratesreceived_grade;
                objModel.Concentratesreceived_qty = Concentratesreceived_qty;
                objModel.Metalsrecovered_Value = Metalsrecovered_Value;
                objModel.Metalsrecovered_grade = Metalsrecovered_grade;
                objModel.Metalsrecovered_qty = Metalsrecovered_qty;
                objModel.OS_grade = OS_grade;
                objModel.OS_qty = OS_qty;
                objModel.Other_byproducts_Value = Other_byproducts_Value;
                objModel.Other_byproducts_grade = Other_byproducts_grade;
                objModel.Other_byproducts_qty = Other_byproducts_qty;
                objModel.Year = Year;
                objModel.MineralId = MineralId;
                objModel.UserId = profile.UserId; //132;

                messageEF = yearlyNonCoalModel.UpdateRecoveriesSmelter(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Delete Recovery at the Smelter
        /// <summary>
        /// To Delete Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult DeleteRecoveriesSmelter(int? Recovery_atSmelter_Id)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                Recovery_atSmelterModel objModel = new Recovery_atSmelterModel();
                objModel.Recovery_atSmelter_Id = Recovery_atSmelter_Id;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.DeleteRecoveriesSmelter(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Get Recovery at the Smelter
        /// <summary>
        /// To Get Recovery at the Smelter
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public JsonResult GetRecoveriesSmelter(string Year)
        {
            List<Recovery_atSmelterModel> list = new List<Recovery_atSmelterModel>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //132;
                list = yearlyNonCoalModel.GetRecoveriesSmelter(yearlyReturnModel);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion

        #endregion

        #region Sales During the month
        #region Add Sales During the month
        /// <summary>
        /// To Add Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult AddSaleProduct(string CS_Qty, string OS_Qty, string PlaceOfSale, string Product,
            string Sold_Qty, string Sold_Value, int? MineralGradeId6, string Year, int? MineralId, string MineralGrade)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                SaleProductModel objModel = new SaleProductModel();
                objModel.CS_Qty = CS_Qty;
                objModel.CS_Grade = MineralGrade;
                objModel.OS_Qty = OS_Qty;
                objModel.OS_Grade = MineralGrade;
                objModel.PlaceOfSale = PlaceOfSale;
                objModel.Product = Product;
                objModel.Sold_Qty = Sold_Qty;
                objModel.Sold_Value = Sold_Value;
                objModel.Sold_Grade = MineralGrade;
                objModel.MineralGradeId6 = MineralGradeId6;
                objModel.Year = Year;
                objModel.MineralId = MineralId;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.AddSaleProduct(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Update Sales During the month
        /// <summary>
        /// To Update Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult UpdateSaleProduct(int SaleProductId, string CS_Qty, string OS_Qty, string PlaceOfSale, string Product,
            string Sold_Qty, string Sold_Value, int? MineralGradeId6, string Year, int? MineralId)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                SaleProductModel objModel = new SaleProductModel();
                objModel.SaleProductId = SaleProductId;
                objModel.CS_Qty = CS_Qty;
                objModel.OS_Qty = OS_Qty;
                objModel.PlaceOfSale = PlaceOfSale;
                objModel.Product = Product;
                objModel.Sold_Qty = Sold_Qty;
                objModel.Sold_Value = Sold_Value;
                objModel.MineralGradeId6 = MineralGradeId6;
                objModel.Year = Year;
                objModel.MineralId = MineralId;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.UpdateSaleProduct(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Delete Sales During the month
        /// <summary>
        /// To Delete Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult DeleteSaleProduct(int SaleProductId)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                SaleProductModel objModel = new SaleProductModel();
                objModel.SaleProductId = SaleProductId;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.DeleteSaleProduct(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Get Sales During the month
        /// <summary>
        /// To Get Sales During the month
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public JsonResult GetSaleProduct(string Year)
        {
            List<SaleProductModel> list = new List<SaleProductModel>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //132;
                list = yearlyNonCoalModel.GetSaleProduct(yearlyReturnModel);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion

        #region Get Mineral Grade
        /// <summary>
        /// To Get Mineral Grade
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public JsonResult GetMineralGradeForTinMineral(YearlyReturnModel yearlyReturnModel)
        {
            List<MineralGrade> lstMineralGrade = new List<MineralGrade>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.UserId = profile.UserId; //132;
                lstMineralGrade = yearlyNonCoalModel.GetMineralGradeForTinMineral(yearlyReturnModel);
                return Json(lstMineralGrade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Closing Stock
        /// <summary>
        /// To Get Closing Stock
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns> 
        public JsonResult Get_G2_ClosingStock(string Year)
        {
            OpeningStockandDispatch openingStockandDispatch = new OpeningStockandDispatch();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.UserId = profile.UserId; //132;
                yearlyReturnModel.Year = Year;
                openingStockandDispatch = yearlyNonCoalModel.Get_G2_ClosingStock(yearlyReturnModel);
                return Json(openingStockandDispatch);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Dispatch
        /// <summary>
        /// To Get Dispatch
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns> 
        public JsonResult GetDespatches_MineHead_Annual_G2(int? MineralGradeId, string MonthYear, decimal? TinContent)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            OpeningStockandDispatch data = new OpeningStockandDispatch();
            yearlyReturnModel.MineralGradeId = MineralGradeId;
            yearlyReturnModel.Year = MonthYear;
            yearlyReturnModel.TinContent = TinContent;
            yearlyReturnModel.UserId = profile.UserId; //132;
            data = yearlyNonCoalModel.GetDispatch_Form2_Annual(yearlyReturnModel);
            return Json(data);
        }
        #endregion

        #endregion

        #region Sales Dispatch
        #region Add Sales Dispatch
        /// <summary>
        /// To Add Sales Dispatch
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult ADDSaleDispatch_G2(int? MineralNatureId, int? MineralGradeId, string NatureofDispatch,
            string RegistrationNo, string PurchaserConsinee, decimal? DomesticPurposes_Quantity, decimal? SaleValue,
            string Country, decimal? Export_Quantity, string FOBValue, string Year, int? MineralId)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                SalesDispatchOf_OreModel objModel = new SalesDispatchOf_OreModel();
                objModel.MineralNatureId = MineralNatureId;
                objModel.MineralGradeId = MineralGradeId;
                objModel.NatureofDispatch = NatureofDispatch;
                objModel.RegistrationNo = RegistrationNo;
                objModel.PurchaserConsinee = PurchaserConsinee;
                objModel.DomesticPurposes_Quantity = DomesticPurposes_Quantity ?? 0;
                objModel.SaleValue = SaleValue ?? 0;
                objModel.Country = Country;
                objModel.Export_Quantity = Export_Quantity ?? 0;
                objModel.FOBValue = FOBValue;
                objModel.Year = Year;
                objModel.MineralId = MineralId;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.AddSaleDispatch(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Update Sales Dispatch
        /// <summary>
        /// To Add Sales Dispatch
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult UpdateSaleDispatch_G2(int Sale_Dispatch_Id, int? MineralNatureId, int? MineralGradeId, string NatureofDispatch,
            string RegistrationNo, string PurchaserConsinee, decimal? DomesticPurposes_Quantity, decimal? SaleValue,
            string Country, decimal? Export_Quantity, string FOBValue, string Year, int? MineralId)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                SalesDispatchOf_OreModel objModel = new SalesDispatchOf_OreModel();
                objModel.Sale_Dispatch_Id = Sale_Dispatch_Id;
                objModel.MineralNatureId = MineralNatureId;
                objModel.MineralGradeId = MineralGradeId;
                objModel.NatureofDispatch = NatureofDispatch;
                objModel.RegistrationNo = RegistrationNo;
                objModel.PurchaserConsinee = PurchaserConsinee;
                objModel.DomesticPurposes_Quantity = DomesticPurposes_Quantity;
                objModel.SaleValue = SaleValue;
                objModel.Country = Country;
                objModel.Export_Quantity = Export_Quantity;
                objModel.FOBValue = FOBValue;
                objModel.Year = Year;
                objModel.MineralId = MineralId;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.UpdateSaleDispatch(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Delete Sales Dispatch
        /// <summary>
        /// To Delete Sales Dispatch
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public JsonResult DeleteSaleDispatch_G2(int Sale_Dispatch_Id)
        {
            string OutputResult = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                SalesDispatchOf_OreModel objModel = new SalesDispatchOf_OreModel();
                objModel.Sale_Dispatch_Id = Sale_Dispatch_Id;
                objModel.UserId = profile.UserId; //132;
                messageEF = yearlyNonCoalModel.DeleteSaleDispatch(objModel);
                if (messageEF.Satus == "2")
                {
                    OutputResult = "2";
                }
                else if (messageEF.Satus == "1")
                {
                    OutputResult = "1";
                }
                return Json(OutputResult);
            }
            catch (Exception ex)
            {
                OutputResult = "3";
                return Json(OutputResult);
            }
        }
        #endregion

        #region Get Sales Dispatch
        /// <summary>
        /// To Get Sales Dispatch
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public JsonResult GetSaleDispatch_G2(string Year)
        {
            List<SalesDispatchOf_OreModel> list = new List<SalesDispatchOf_OreModel>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.Year = Year;
                yearlyReturnModel.UserId = profile.UserId; //132;
                list = yearlyNonCoalModel.GetSaleDispatch(yearlyReturnModel);
                return Json(list);

            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion

        #region Mineral Form
        /// <summary>
        /// To Get Mineral Form
        /// </summary>
        /// <param name="MineralId"></param>
        /// <returns></returns>
        public JsonResult GetMineralForm(int? MineralId)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                List<MineralInfo> lstMineralInfo = new List<MineralInfo>();
                yearlyReturnModel.MineralId = MineralId;
                yearlyReturnModel.UserId = profile.UserId; //132;
                lstMineralInfo = yearlyNonCoalModel.GetMineralForm(yearlyReturnModel);
                return Json(lstMineralInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Mineral Nature/Grade
        /// <summary>
        /// To Get Mineral Grade
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public JsonResult GetMineralGrade()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                List<MineralGrade> lstMineralGrade = new List<MineralGrade>();
                yearlyReturnModel.UserId = profile.UserId; //132;
                lstMineralGrade = yearlyNonCoalModel.GetMineralGrade(yearlyReturnModel);
                return Json(lstMineralGrade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json("");
        }
        #endregion

        #region Nature Of Dispatch
        /// <summary>
        /// To Get Nature Of Dispatch
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public JsonResult GetNatureOfDispatch()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                List<MineralInfo> lstMineralInfo = new List<MineralInfo>();
                yearlyReturnModel.UserId = profile.UserId; //132;
                lstMineralInfo = yearlyNonCoalModel.GetNatureOfDispatch(yearlyReturnModel);
                return Json(lstMineralInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Purchaser Consignee
        /// <summary>
        /// To Get Purchaser Consignee
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public JsonResult GetPurchaserConsignee()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                List<MineralInfo> lstMineralInfo = new List<MineralInfo>();
                yearlyReturnModel.UserId = profile.UserId; //132;
                lstMineralInfo = yearlyNonCoalModel.GetPurchaserConsignee(yearlyReturnModel);
                return Json(lstMineralInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #endregion

        #region Part Seven
        #region Part Seven View Page 
        /// <summary>
        /// To Bind Cost of production per tonne of ore/mineral produced
        /// </summary>
        /// <param name="Financial_Year"></param>
        /// <returns></returns>
        public IActionResult PartSevenH2(string Financial_Year)
        {
            if (TempData["resultPart7_G2"] != null)
            {
                ViewBag.msg = TempData["resultPart7_G2"].ToString();
            }

            ViewBag.FinancialYear = Financial_Year;
            TempData["F_Y"] = Financial_Year;
            Financial_Year = protector.Unprotect(Financial_Year);
            //---------Get Cost Of Production----------
            CostOfProduction_Annual objModel = new CostOfProduction_Annual();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            yearlyReturnModel.UserId = profile.UserId; //132;
            yearlyReturnModel.Year = Financial_Year;
            objModel = yearlyNonCoalModel.GetCostOfProduction(yearlyReturnModel);
            //------------End Here--------------------
            ViewBag.Year = Financial_Year;
            return View(objModel);
        }
        #endregion

        #region Save Part Seven
        [HttpPost]
        public ActionResult PartSevenH2(CostOfProduction_Annual objModel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objModel.UserId = profile.UserId; //132;
            if (objModel.Flag1 == 1)
            {
                messageEF = yearlyNonCoalModel.UpdateCostOfProduction(objModel);
                TempData["resultPart7_G2"] = messageEF.Satus;

            }
            else if (objModel.Flag1 == 2)
            {
                messageEF = yearlyNonCoalModel.AddCostOfProduction(objModel);
                TempData["resultPart7_G2"] = messageEF.Satus;
            }
            else if (objModel.FinalSubmitFlag == 1)
            {
                messageEF = yearlyNonCoalModel.Update_FinalSubmit(objModel);
                if (messageEF.Satus == "Yearly Return has not Submited")
                {
                    TempData["resultPart7_G2"] = messageEF.Satus;
                }
                else
                {
                    return RedirectToAction("YearlyReturn", "Annual_Return", new { Area = "eReturn_NonCoal_Yearly" });
                }
            }

            return RedirectToAction("PartSevenH2", "EReturnYearlyNonCoalG2", new { Area = "eReturn_NonCoal_Yearly", Financial_Year = TempData["F_Y"].ToString() });
        }
        #endregion

        #endregion

        #region Print Preview G2
        public ActionResult PrintFormG2(string Financial_Year)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            Financial_Year = protector.Unprotect(Financial_Year);
            yearlyReturnModel.UserId = profile.UserId; //132;
            yearlyReturnModel.Year = Financial_Year;
            string[] year = Financial_Year.Split('-');
            ViewBag.begning = year[0].ToString();
            ViewBag.closing = year[1].ToString();
            ViewBag.Year = Financial_Year;
            ViewBag.UserId = profile.UserId; //132;
            dynamic Preview = new ExpandoObject();
            #region Calling (Part 1)
            AnnualReturnH1ViewModel objViewModel = new AnnualReturnH1ViewModel();
            objViewModel = yearlyNonCoalModel.GetMineOtherDetails(yearlyReturnModel);
            objViewModel.objParticular = yearlyNonCoalModel.GetParticularsofArea(yearlyReturnModel);
            Preview.MineDetails = objViewModel.objMineDetails;
            Preview.OtherDetails = objViewModel.objOtherDetails;
            Preview.ParticularsofArea = objViewModel.objParticular;
            Preview.LeaseArea = yearlyNonCoalModel.GetLeasearea(yearlyReturnModel);
            #endregion

            #region Calling (Part 2)

            Preview.Staff = yearlyNonCoalModel.GetStaffandWork(yearlyReturnModel);
            Preview.SalaryWages = yearlyNonCoalModel.GetSalaryWagesPaid(yearlyReturnModel);
            Preview.CapitalStucture = yearlyNonCoalModel.GetCapitalStructure(yearlyReturnModel);
            Preview.SourceOfFinance = yearlyNonCoalModel.GetSourceOfFinance(yearlyReturnModel);
            #endregion

            #region Calling (Part 3)
            Preview.MaterialConsumed = yearlyNonCoalModel.GetMaterialConsumed(yearlyReturnModel);
            Preview.RoyaltyandRents = yearlyNonCoalModel.GetRoyaltyandRent(yearlyReturnModel);
            #endregion

            #region Calling (Part 4)
            Preview.Explosives = yearlyNonCoalModel.GetExplosives(yearlyReturnModel);

            #endregion

            #region Calling (Part 5)
            Preview.Exploration = yearlyNonCoalModel.GetExploration(yearlyReturnModel);
            Preview.Reserves = yearlyNonCoalModel.GetResources(yearlyReturnModel);
            Preview.RejectWaste = yearlyNonCoalModel.GetRejectWasteTreesPlanted(yearlyReturnModel);
            Preview.Furnish = yearlyNonCoalModel.GetFurnishDetails(yearlyReturnModel);
            #endregion

            #region Calling (Part 6)
            Preview.ProductionandStocks = yearlyNonCoalModel.GetProductionandStocks(yearlyReturnModel);
            Preview.Deductions = yearlyNonCoalModel.GetDetails_of_deductions(yearlyReturnModel);
            Preview.ReasonInc_Dec = yearlyNonCoalModel.GetReason_Inc_Dec(yearlyReturnModel);
            #endregion

            #region Calling (Part 7)
            Preview.CostOfProduction = yearlyNonCoalModel.GetCostOfProduction(yearlyReturnModel);
            #endregion
            ViewBag.ServerPath = configuration.GetSection("MySettings").GetValue<string>("ServerPath");
            ViewBag.DSCReadFilePath = configuration.GetSection("MySettings").GetValue<string>("DSCReadFilePath");
            return View(Preview);
        }

        public JsonResult GetParticularsofArea(string Year)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            yearlyReturnModel.UserId = profile.UserId; //132;
            yearlyReturnModel.Year = Year;
            annualReturnH1ViewModel.objParticular = yearlyNonCoalModel.GetParticularsofArea(yearlyReturnModel);
            return Json(annualReturnH1ViewModel);
        }

        public JsonResult GetWorkDetails(string Year)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            yearlyReturnModel.UserId = profile.UserId; //132;
            yearlyReturnModel.Year = Year;
            annualReturnH1PartTwoModel.objWork = yearlyNonCoalModel.GetWorkDetails(yearlyReturnModel);
            return Json(annualReturnH1PartTwoModel);
        }

        public JsonResult GetMachineryDetailsForPrint(string Year)
        {
            List<MachineryDetails> list = new List<MachineryDetails>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.UserId = profile.UserId; //132;
                yearlyReturnModel.Year = Year;
                list = yearlyNonCoalModel.GetMachineryDetails(yearlyReturnModel);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public JsonResult GetRecoveries_ForPrint(string Year)
        {
            List<RecoveriesModel> list = new List<RecoveriesModel>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.UserId = profile.UserId; //132;
                yearlyReturnModel.Year = Year;
                list = yearlyNonCoalModel.GetRecoveries(yearlyReturnModel);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public JsonResult GetRecoveriesSmelter_ForPrint(string Year)
        {
            List<Recovery_atSmelterModel> list = new List<Recovery_atSmelterModel>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.UserId = profile.UserId; //132;
                yearlyReturnModel.Year = Year;
                list = yearlyNonCoalModel.GetRecoveriesSmelter(yearlyReturnModel);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public JsonResult GetSaleProduct_ForPrint(string Year)
        {
            List<SaleProductModel> list = new List<SaleProductModel>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.UserId = profile.UserId; //132;
                yearlyReturnModel.Year = Year;
                list = yearlyNonCoalModel.GetSaleProduct(yearlyReturnModel);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public JsonResult GetSaleDispatch_G2_ForPrint(string Year)
        {
            List<SalesDispatchOf_OreModel> list = new List<SalesDispatchOf_OreModel>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                yearlyReturnModel.UserId = profile.UserId; //132;
                yearlyReturnModel.Year = Year;
                list = yearlyNonCoalModel.GetSaleDispatch(yearlyReturnModel);
                return Json(list);

            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion
        #endregion
    }
}
