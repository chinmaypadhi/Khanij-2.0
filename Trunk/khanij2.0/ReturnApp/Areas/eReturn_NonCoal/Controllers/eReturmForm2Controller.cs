// ***********************************************************************
//  Controller Name          : eReturmForm2
//  Desciption               : eReturn Form2 Details 
//  Created By               : Debaraj Swain
//  Created On               : 20 June 2021
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
    public class eReturmForm2Controller : Controller
    {
        IeReturnNonCoalForm2Model _objIeReturnNonCoalForm2Model;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        private readonly IDataProtectionProvider dataProtectionProvider;
        private readonly IDataProtector protector;
        MessageEF objobjmodel = new MessageEF();
       
        int SessionUID = int.Parse(ConfigurationManager.MySettings["MySettings:SessionUID"]);
        public eReturmForm2Controller(IeReturnNonCoalForm2Model objeReturnNonCoalFormM2odel, IHostingEnvironment hostingEnvironment, IConfiguration configuration, IDataProtectionProvider dataProtectionProvider)
        {
            _objIeReturnNonCoalForm2Model = objeReturnNonCoalFormM2odel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            this.dataProtectionProvider = dataProtectionProvider;
            protector = dataProtectionProvider.CreateProtector(configuration.GetSection("Encryption").GetValue<string>("EncryptionKey"));
        }
        /// <summary>
        /// Part1 form2 Details
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <returns>View</returns>
        public ActionResult PartOneForm2(string MonthYear)
        {
            MonthlyReturnModelNonCoal objmodel = new MonthlyReturnModelNonCoal();
            GetFormF1DetailsModel data = new GetFormF1DetailsModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.Uid = profile.UserId;
            //objmodel.Uid =132;
            data = _objIeReturnNonCoalForm2Model.GetLesseMineDeatils(objmodel); 
            TempData["M_Y"] = MonthYear;
            TempData.Keep("MonthYear");
            ViewBag.Month_Year = protector.Unprotect(MonthYear);
            return View(data);
        }

        /// <summary>
        /// Get Return 
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <returns>Json String</returns>
        public JsonResult GetReturn(string Month_Year)
        {
            MonthlyReturnModelNonCoal objmodel = new MonthlyReturnModelNonCoal();
            GetFormF1DetailsModel data = new GetFormF1DetailsModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.Uid = profile.UserId;
            //objmodel.Uid =132;
            objmodel.MonthYear = Month_Year;
            data = _objIeReturnNonCoalForm2Model.GeteReturnSubmittedDetails(objmodel);
            return Json(data);
        }

        /// <summary>
        /// Get Lessee Monthly Rent Royalty Details
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <returns>Json String</returns>
        public JsonResult GetLesseeMonthRentRoyaltyDetails(string Month_Year)
        {
            MonthlyReturnModelNonCoal objmodel = new MonthlyReturnModelNonCoal();
            GetRentRoyaltyDetailsModel data = new GetRentRoyaltyDetailsModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.Uid = profile.UserId;
            //objmodel.Uid =132;
            objmodel.MonthYear = Month_Year;
            data = _objIeReturnNonCoalForm2Model.GetRentRoyalty(objmodel);
            return Json(data);
        }

        /// <summary>
        /// Post portion of part1 form1
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
                //data.UserID =132;
                data.intwork = Work_Id;
                data.intwork = NoOfDaysWorkStop;
                data.intNoOfDaysWorkStop = NoOfDaysWorkStop;
                data.strReason = Reason;
                objobjmodel = _objIeReturnNonCoalForm2Model.UpdateRoyaltyDetails(data);
                TempData["result"] = objobjmodel.Msg;
                return RedirectToAction("eReturnDashboard", "eReturnProcess");
            }
            else
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                data.UserID = profile.UserId;
                data.intwork = NoOfDaysWorkStop;
                data.intNoOfDaysWorkStop = NoOfDaysWorkStop;
                data.strReason = Reason;
                objobjmodel = _objIeReturnNonCoalForm2Model.AddRoyaltyDetails(data);
                TempData["result"] = objobjmodel.Msg;
                return RedirectToAction("eReturnDashboard", "eReturnProcess");

            }
        }

        /// <summary>
        /// Get Portion of Part2 form2
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns>View</returns>
        public ActionResult PartTwoForm2(string MonthYear, int? UserId)
        {
            if (TempData["result"] != null)
            {
               // Response.Write("<script>alert('" + TempData["result"].ToString() + "')</script>");
            }
            TempData["M_Y"] = MonthYear;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            TempData["UID"] = profile.UserId;
            //TempData["UID"] =132;
            ViewBag.UID = profile.UserId;
            //ViewBag.UID = 132;

            TempData.Keep("M_Y");
            TempData.Keep("UID");

            GetFormF1DetailsModel data = new GetFormF1DetailsModel();
            MonthlyReturnModelNonCoal objmodel = new MonthlyReturnModelNonCoal();
            objmodel.Uid = profile.UserId;
            //objmodel.Uid = 132;
            data = _objIeReturnNonCoalForm2Model.GetMineralInfo(objmodel);
            string str = data.MineralName;
            int MineralId = data.MineralID;
            ViewBag.Mineral = str;
            ViewBag.MineralId = MineralId;
            ViewBag.Month_Year = protector.Unprotect(MonthYear);
            TempData["Temp_MineralId"] = MineralId;
            TempData.Keep("Temp_MineralId");

            List<Recovery_atSmelterModel> ListDP = new List<Recovery_atSmelterModel>();
            ListDP = _objIeReturnNonCoalForm2Model.GetMineralGradeForTinMineral(objmodel);
            if (ListDP.Count > 0)
            {
                ViewBag.Grade = ListDP.Select(c => new SelectListItem
                {
                    Text = c.MineralName,
                    Value = c.MineralId3.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.Grade = Enumerable.Empty<SelectListItem>();
            }

            List<SalesDispatchOf_OreModel> ListDP1 = new List<SalesDispatchOf_OreModel>();
            ListDP1 = _objIeReturnNonCoalForm2Model.GetMineralFormProduction(objmodel);
            if (ListDP1.Count > 0)
            {
                ViewBag.MineralNatureProd = ListDP1.Select(D => new SelectListItem
                {
                    Text = D.MineralNature,
                    Value = D.MineralNatureId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.MineralNatureProd = Enumerable.Empty<SelectListItem>();
            }

            SalesDispatchModel objsd = new SalesDispatchModel();
            List<SalesDispatchModel> ListDP2 = new List<SalesDispatchModel>();
            ListDP2 = _objIeReturnNonCoalForm2Model.GetNatureOfDispatch(objsd);
            if (ListDP2.Count > 0)
            {
                ViewBag.NatureofDisp = ListDP2.Select(c => new SelectListItem
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
            //objmodel.Uid =132;
            List<SalesDispatchModel> ListDP3 = new List<SalesDispatchModel>();
            ListDP3 = _objIeReturnNonCoalForm2Model.GetPurchaserConsignee(objmodel);
            if (ListDP3.Count > 0)
            {
                ViewBag.PurcConsig = ListDP3.Select(c => new SelectListItem
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
        /// Add Recoveries Concentrator Details
        /// </summary>
        /// <param name="MineralId2"></param>
        /// <param name="OS_qty"></param>
        /// <param name="OS_grade"></param>
        /// <param name="OreReceived_qty"></param>
        /// <param name="OreReceived_grade"></param>
        /// <param name="OreTreated_qty"></param>
        /// <param name="OreTreated_grade"></param>
        /// <param name="Concentrates_qty"></param>
        /// <param name="Concentrates_grade"></param>
        /// <param name="Concentrates_Value"></param>
        /// <param name="Tailings_Qty"></param>
        /// <param name="Tailing_grade"></param>
        /// <param name="CS_qty"></param>
        /// <param name="CS_grade"></param>
        /// <param name="Month_Year"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
     
        public JsonResult ADDRecoveries_Concentrator(int MineralId2,decimal OS_qty,string OS_grade,decimal OreReceived_qty,string OreReceived_grade, decimal OreTreated_qty,string OreTreated_grade,decimal Concentrates_qty,string Concentrates_grade,decimal Concentrates_Value,decimal Tailings_Qty,string Tailing_grade,decimal CS_qty,string CS_grade,string Month_Year,int UID)
        {
            try
            {
                string result;
                RecoveriesModel objModel = new RecoveriesModel();
                objModel.MineralId2 = MineralId2;
                objModel.OS_qty = OS_qty;
                objModel.OS_grade = OS_grade;
                objModel.OreReceived_qty = OreReceived_qty;
                objModel.OreReceived_grade = OreReceived_grade;
                objModel.OreTreated_qty = OreTreated_qty;
                objModel.OreTreated_grade = OreTreated_grade;
                objModel.Concentrates_qty = Concentrates_qty;
                objModel.Concentrates_grade = Concentrates_grade;
                objModel.Concentrates_Value = Concentrates_Value;
                objModel.Tailings_Qty = Tailings_Qty;
                objModel.Tailing_grade = Tailing_grade;
                objModel.CS_qty = CS_qty;
                objModel.CS_grade = CS_grade;
                objModel.Month_Year = Month_Year;
                objModel.UID = UID;
                objobjmodel = _objIeReturnNonCoalForm2Model.AddRecoveries(objModel);
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
        /// Get 1st Table of Form2 Part2
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns>Json String</returns>
        public JsonResult Get1sttable(string MonthYear, int? UserId)
        {
            List<RecoveriesModel> list = new List<RecoveriesModel>();
            try
            {
                MonthlyReturnModelNonCoal model = new MonthlyReturnModelNonCoal();
                model.MonthYear = MonthYear;
                model.Uid = UserId;

                list = _objIeReturnNonCoalForm2Model.GetRecoveries(model);
                return Json(list);

            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// Update Recoveries at concentrator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="MineralId2"></param>
        /// <param name="OS_qty"></param>
        /// <param name="OS_grade"></param>
        /// <param name="OreReceived_qty"></param>
        /// <param name="OreReceived_grade"></param>
        /// <param name="OreTreated_qty"></param>
        /// <param name="OreTreated_grade"></param>
        /// <param name="Concentrates_qty"></param>
        /// <param name="Concentrates_grade"></param>
        /// <param name="Concentrates_Value"></param>
        /// <param name="Tailings_Qty"></param>
        /// <param name="Tailing_grade"></param>
        /// <param name="CS_qty"></param>
        /// <param name="CS_grade"></param>
        /// <param name="Month_Year"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult UpdateRecoveries_Concentrator(int id,int MineralId2, decimal OS_qty, string OS_grade, decimal OreReceived_qty, string OreReceived_grade, decimal OreTreated_qty, string OreTreated_grade, decimal Concentrates_qty, string Concentrates_grade, decimal Concentrates_Value, decimal Tailings_Qty, string Tailing_grade, decimal CS_qty, string CS_grade, string Month_Year,int UID)
        {
            try
            {
                string result;
                RecoveriesModel objModel = new RecoveriesModel();
                objModel.Recoverie_Id = id;
                objModel.MineralId2 = MineralId2;
                objModel.OS_qty = OS_qty;
                objModel.OS_grade = OS_grade;
                objModel.OreReceived_qty = OreReceived_qty;
                objModel.OreReceived_grade = OreReceived_grade;
                objModel.OreTreated_qty = OreTreated_qty;
                objModel.OreTreated_grade = OreTreated_grade;

                objModel.Concentrates_qty = Concentrates_qty;
                objModel.Concentrates_grade = Concentrates_grade;
                objModel.Concentrates_Value = Concentrates_Value;
                objModel.Tailings_Qty = Tailings_Qty;
                objModel.Tailing_grade = Tailing_grade;
                objModel.CS_qty = CS_qty;
                objModel.CS_grade = CS_grade;
                objModel.Month_Year = Month_Year;
                objModel.UID = UID;

                objobjmodel = _objIeReturnNonCoalForm2Model.UpdateRecoveries(objModel);
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
        /// Delete Recoveries
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult DeleteRecoveries(int ID, int UID)
        {
            try
            {
                string result;
                RecoveriesModel objModel = new RecoveriesModel();
                objModel.Recoverie_Id = ID;
                objModel.UID = UID;

                objobjmodel = _objIeReturnNonCoalForm2Model.DeleteRecoveries(objModel);
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
        /// Add Recoveries at Smelter
        /// </summary>
        /// <param name="MineralId3"></param>
        /// <param name="OS_qty"></param>
        /// <param name="OS_grade"></param>
        /// <param name="Concentratesreceived_qty"></param>
        /// <param name="Concentratesreceived_grade"></param>
        /// <param name="Concentrates_othersources_qty"></param>
        /// <param name="Concentrates_othersources_grade"></param>
        /// <param name="Concentrates_sold_qty"></param>
        /// <param name="Concentrates_sold_grade"></param>
        /// <param name="Concentrates_treated_qty"></param>
        /// <param name="Concentrates_treated_grade"></param>
        /// <param name="CS_qty"></param>
        /// <param name="CS_grade"></param>
        /// <param name="Metalsrecovered_qty"></param>
        /// <param name="Metalsrecovered_grade"></param>
        /// <param name="Metalsrecovered_Value"></param>
        /// <param name="Other_byproducts_qty"></param>
        /// <param name="Other_byproducts_grade"></param>
        /// <param name="Other_byproducts_Value"></param>
        /// <param name="Month_Year"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult AddRecoveriesSmelter(int MineralId3, decimal OS_qty, string OS_grade, decimal Concentratesreceived_qty, string Concentratesreceived_grade, decimal Concentrates_othersources_qty, string Concentrates_othersources_grade, decimal Concentrates_sold_qty, string Concentrates_sold_grade, decimal Concentrates_treated_qty, string Concentrates_treated_grade, decimal CS_qty, string CS_grade, decimal Metalsrecovered_qty, string Metalsrecovered_grade, decimal Metalsrecovered_Value, decimal Other_byproducts_qty, string Other_byproducts_grade, decimal Other_byproducts_Value, string Month_Year, int UID)
        {
            try
            {
                string result;
                Recovery_atSmelterModel objModel = new Recovery_atSmelterModel();
                objModel.MineralId3 = MineralId3;
                objModel.OS_qty = OS_qty;
                objModel.OS_grade = OS_grade;
                objModel.Concentratesreceived_qty = Concentratesreceived_qty;
                objModel.Concentratesreceived_grade = Concentratesreceived_grade;
                objModel.Concentrates_othersources_qty = Concentrates_othersources_qty;
                objModel.Concentrates_othersources_grade = Concentrates_othersources_grade;
                objModel.Concentrates_sold_qty = Concentrates_sold_qty;
                objModel.Concentrates_sold_grade = Concentrates_sold_grade;
                objModel.Concentrates_treated_qty = Concentrates_treated_qty;
                objModel.Concentrates_treated_grade = Concentrates_treated_grade;
                objModel.CS_qty = CS_qty;
                objModel.CS_grade = CS_grade;
                objModel.Metalsrecovered_qty = Metalsrecovered_qty;
                objModel.Metalsrecovered_grade = Metalsrecovered_grade;
                objModel.Metalsrecovered_Value = Metalsrecovered_Value;
                objModel.Other_byproducts_qty = Other_byproducts_qty;
                objModel.Other_byproducts_grade = Other_byproducts_grade;
                objModel.Other_byproducts_Value = Other_byproducts_Value;
                objModel.Month_Year = Month_Year;
                objModel.UID = UID;

                objobjmodel = _objIeReturnNonCoalForm2Model.AddRecoveriesSmelter(objModel);
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
        /// Get Recoveries Smelter
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetRecoveriesSmelter(string MonthYear, int? UserId)
        {
            List<Recovery_atSmelterModel> list = new List<Recovery_atSmelterModel>();
            try
            {
                MonthlyReturnModelNonCoal model = new MonthlyReturnModelNonCoal();
                model.MonthYear = MonthYear;
                model.Uid = UserId;

                list = _objIeReturnNonCoalForm2Model.GetRecoveriesSmelter(model);
                return Json(list);

            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// Update Recoveries Smelter
        /// </summary>
        /// <param name="Recovery_atSmelter_Id"></param>
        /// <param name="MineralId3"></param>
        /// <param name="OS_qty"></param>
        /// <param name="OS_grade"></param>
        /// <param name="Concentratesreceived_qty"></param>
        /// <param name="Concentratesreceived_grade"></param>
        /// <param name="Concentrates_othersources_qty"></param>
        /// <param name="Concentrates_othersources_grade"></param>
        /// <param name="Concentrates_sold_qty"></param>
        /// <param name="Concentrates_sold_grade"></param>
        /// <param name="Concentrates_treated_qty"></param>
        /// <param name="Concentrates_treated_grade"></param>
        /// <param name="CS_qty"></param>
        /// <param name="CS_grade"></param>
        /// <param name="Metalsrecovered_qty"></param>
        /// <param name="Metalsrecovered_grade"></param>
        /// <param name="Metalsrecovered_Value"></param>
        /// <param name="Other_byproducts_qty"></param>
        /// <param name="Other_byproducts_grade"></param>
        /// <param name="Other_byproducts_Value"></param>
        /// <param name="Month_Year"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult UpdateRecoveriesSmelter(int Recovery_atSmelter_Id, int MineralId3, decimal OS_qty, string OS_grade, decimal Concentratesreceived_qty, string Concentratesreceived_grade, decimal Concentrates_othersources_qty, string Concentrates_othersources_grade, decimal Concentrates_sold_qty, string Concentrates_sold_grade, decimal Concentrates_treated_qty, string Concentrates_treated_grade, decimal CS_qty, string CS_grade, decimal Metalsrecovered_qty, string Metalsrecovered_grade, decimal Metalsrecovered_Value, decimal Other_byproducts_qty, string Other_byproducts_grade, decimal Other_byproducts_Value, string Month_Year, int UID)
        {
            try
            {
                string result;
                Recovery_atSmelterModel objModel = new Recovery_atSmelterModel();
                objModel.Recovery_atSmelter_Id = Recovery_atSmelter_Id;
                objModel.MineralId3 = MineralId3;
                objModel.OS_qty = OS_qty;
                objModel.OS_grade = OS_grade;
                objModel.Concentratesreceived_qty = Concentratesreceived_qty;
                objModel.Concentratesreceived_grade = Concentratesreceived_grade;
                objModel.Concentrates_othersources_qty = Concentrates_othersources_qty;
                objModel.Concentrates_othersources_grade = Concentrates_othersources_grade;
                objModel.Concentrates_sold_qty = Concentrates_sold_qty;
                objModel.Concentrates_sold_grade = Concentrates_sold_grade;
                objModel.Concentrates_treated_qty = Concentrates_treated_qty;
                objModel.Concentrates_treated_grade = Concentrates_treated_grade;
                objModel.CS_qty = CS_qty;
                objModel.CS_grade = CS_grade;
                objModel.Metalsrecovered_qty = Metalsrecovered_qty;
                objModel.Metalsrecovered_grade = Metalsrecovered_grade;
                objModel.Metalsrecovered_Value = Metalsrecovered_Value;
                objModel.Other_byproducts_qty = Other_byproducts_qty;
                objModel.Other_byproducts_grade = Other_byproducts_grade;
                objModel.Other_byproducts_Value = Other_byproducts_Value;
                objModel.Month_Year = Month_Year;
                objModel.UID = UID;
                objobjmodel = _objIeReturnNonCoalForm2Model.UpdateRecoveriesSmelter(objModel);
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
        /// Delete Recoveries Smelter
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult DeleteRecoveriesSmelter(int ID, int UID)
        {
            try
            {
                string result;
                Recovery_atSmelterModel objModel = new Recovery_atSmelterModel();
                objModel.Recovery_atSmelter_Id = ID;
                objModel.UID = UID;

                objobjmodel = _objIeReturnNonCoalForm2Model.DeleteRecoveriesSmelter(objModel);
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
        /// Add Sale Product
        /// </summary>
        /// <param name="MineralId"></param>
        /// <param name="Product"></param>
        /// <param name="OS_Grade"></param>
        /// <param name="OS_Qty"></param>
        /// <param name="Sold_Qty"></param>
        /// <param name="Sold_Value"></param>
        /// <param name="PlaceOfSale"></param>
        /// <param name="CS_Qty"></param>
        /// <param name="Month_Year"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult AddSaleProduct(int MineralId,string Product,string OS_Grade, string OS_Qty, string Sold_Qty, string Sold_Value, string PlaceOfSale, string CS_Qty, string Month_Year, int UID)
        {
            try
            {
                string result;
                SaleProductModel objModel = new SaleProductModel();
                objModel.MineralId = MineralId;
                objModel.Product = Product;
                objModel.OS_Qty = OS_Qty;
                objModel.Sold_Qty = Sold_Qty;
                objModel.Sold_Value = Sold_Value;
                objModel.PlaceOfSale = PlaceOfSale;
                objModel.CS_Qty = CS_Qty;
                objModel.OS_Grade = OS_Grade;
                objModel.Sold_Grade = OS_Grade;
                objModel.CS_Grade = OS_Grade;
                objModel.Month_Year = Month_Year;
                objModel.UID = UID;

                objobjmodel = _objIeReturnNonCoalForm2Model.AddSaleProduct(objModel);
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
        /// Get Sale Product
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns>Json Result</returns>
        public JsonResult GetSaleProduct(string MonthYear, int? UserId)
        {
            List<SaleProductModel> list = new List<SaleProductModel>();
            try
            {
                MonthlyReturnModelNonCoal model = new MonthlyReturnModelNonCoal();
                model.MonthYear = MonthYear;
                model.Uid = UserId;

                list = _objIeReturnNonCoalForm2Model.GetSaleProduct(model);
                return Json(list);

            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        /// <summary>
        /// Update Sale Product
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="MineralId"></param>
        /// <param name="Product"></param>
        /// <param name="OS_Grade"></param>
        /// <param name="OS_Qty"></param>
        /// <param name="Sold_Qty"></param>
        /// <param name="Sold_Value"></param>
        /// <param name="PlaceOfSale"></param>
        /// <param name="CS_Qty"></param>
        /// <param name="Month_Year"></param>
        /// <param name="UID"></param>
        /// <returns>Json Result</returns>
        public JsonResult UpdateSaleProduct(int Id, int MineralId, string Product, string OS_Grade, string OS_Qty, string Sold_Qty, string Sold_Value, string PlaceOfSale, string CS_Qty, string Month_Year, int UID)
        {
            try
            {
                string result;
                SaleProductModel objModel = new SaleProductModel();
                objModel.SaleProductId = Id;
                objModel.MineralId = MineralId;
                objModel.Product = Product;
                objModel.OS_Qty = OS_Qty;
                objModel.Sold_Qty = Sold_Qty;
                objModel.Sold_Value = Sold_Value;
                objModel.PlaceOfSale = PlaceOfSale;
                objModel.CS_Qty = CS_Qty;

                objModel.OS_Grade = OS_Grade;
                objModel.Sold_Grade = OS_Grade;
                objModel.CS_Grade = OS_Grade;
                objModel.Month_Year = Month_Year;
                objModel.UID = UID;

                objobjmodel = _objIeReturnNonCoalForm2Model.UpdateSaleProduct(objModel);
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
        /// Delete Sale Product
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="UID"></param>
        /// <returns>Json String</returns>
        public JsonResult DeleteSaleProduct(int ID, int UID)
        {
            try
            {
                string result;
                SaleProductModel objModel = new SaleProductModel();
                objModel.SaleProductId = ID;
                objModel.UID = UID;

                objobjmodel = _objIeReturnNonCoalForm2Model.DeleteSaleProduct(objModel);
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
        /// <param name="MineralId9"></param>
        /// <param name="MineralNatureId"></param>
        /// <param name="MineralGradeId"></param>
        /// <param name="MineralGrade"></param>
        /// <param name="NatureofDispatch"></param>
        /// <param name="RegistrationNo"></param>
        /// <param name="PurchaserConsinee"></param>
        /// <param name="DomesticPurposes_Quantity"></param>
        /// <param name="SaleValue"></param>
        /// <param name="Country"></param>
        /// <param name="Export_Quantity"></param>
        /// <param name="FOBValue"></param>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns>Json Result</returns>
        public JsonResult AddSaleDispatch(int MineralId9, int MineralNatureId, int MineralGradeId, string MineralGrade, string NatureofDispatch, string RegistrationNo, string PurchaserConsinee, decimal DomesticPurposes_Quantity, decimal SaleValue, string Country, decimal Export_Quantity, string FOBValue, string Month_Year, int UserId)
        {
            try
            {
                string result;
                SalesDispatchOf_OreModel objModel = new SalesDispatchOf_OreModel();
                objModel.MineralId9 = MineralId9;
                objModel.MineralNatureId = MineralNatureId;
                objModel.MineralGradeId = MineralGradeId;
                objModel.MineralGrade = MineralGrade;
                objModel.NatureofDispatch = NatureofDispatch;
                objModel.RegistrationNo = RegistrationNo;
                objModel.PurchaserConsinee = PurchaserConsinee;
                objModel.DomesticPurposes_Quantity = DomesticPurposes_Quantity;
                objModel.SaleValue = SaleValue;
                objModel.Country = Country;
                objModel.Export_Quantity = Export_Quantity;
                objModel.FOBValue = FOBValue;
                objModel.Month_Year = Month_Year;
                objModel.UID = UserId;
                objobjmodel = _objIeReturnNonCoalForm2Model.AddSaleDispatch(objModel);
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
        /// <returns>Json Result</returns>
        public JsonResult GetSaleDispatch(string MonthYear, int? UserId)
        {
            List<SalesDispatchOf_OreModel> list = new List<SalesDispatchOf_OreModel>();
            try
            {
                MonthlyReturnModelNonCoal model = new MonthlyReturnModelNonCoal();
                model.MonthYear = MonthYear;
                model.Uid = UserId;
                list = _objIeReturnNonCoalForm2Model.GetSaleDispatch(model);
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
        /// <param name="Id"></param>
        /// <param name="MineralId9"></param>
        /// <param name="MineralNatureId"></param>
        /// <param name="MineralGradeId"></param>
        /// <param name="MineralGrade"></param>
        /// <param name="NatureofDispatch"></param>
        /// <param name="RegistrationNo"></param>
        /// <param name="PurchaserConsinee"></param>
        /// <param name="DomesticPurposes_Quantity"></param>
        /// <param name="SaleValue"></param>
        /// <param name="Country"></param>
        /// <param name="Export_Quantity"></param>
        /// <param name="FOBValue"></param>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns>Json Result</returns>
        public JsonResult UpdateSaleDispatch(int Id, int MineralId9, int MineralNatureId, int MineralGradeId, string MineralGrade, string NatureofDispatch, string RegistrationNo, string PurchaserConsinee, decimal DomesticPurposes_Quantity, decimal SaleValue, string Country, decimal Export_Quantity, string FOBValue, string Month_Year, int UserId)
        {
            try
            {
                string result;
                SalesDispatchOf_OreModel objModel = new SalesDispatchOf_OreModel();
                objModel.Sale_Dispatch_Id = Id;
                objModel.MineralId9 = MineralId9;
                objModel.MineralNatureId = MineralNatureId;
                objModel.MineralGradeId = MineralGradeId;
                objModel.MineralGrade = MineralGrade;
                objModel.NatureofDispatch = NatureofDispatch;
                objModel.RegistrationNo = RegistrationNo;
                objModel.PurchaserConsinee = PurchaserConsinee;
                objModel.DomesticPurposes_Quantity = DomesticPurposes_Quantity;
                objModel.SaleValue = SaleValue;
                objModel.Country = Country;
                objModel.Export_Quantity = Export_Quantity;
                objModel.FOBValue = FOBValue;
                objModel.Month_Year = Month_Year;
                objModel.UID = UserId;

                objobjmodel = _objIeReturnNonCoalForm2Model.UpdateSaleDispatch(objModel);
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
        /// <param name="ID"></param>
        /// <param name="UID"></param>
        /// <returns>Json Result</returns>
        public JsonResult DeleteSaleDispatch(int ID, int UID)
        {
            try
            {
                string result;
                SalesDispatchOf_OreModel objModel = new SalesDispatchOf_OreModel();
                objModel.Sale_Dispatch_Id = ID;
                objModel.UID = UID;

                objobjmodel = _objIeReturnNonCoalForm2Model.DeleteSaleDispatch(objModel);
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
        /// Post of Part2 from2 
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult PartTwoForm2(FormF2PartTwoViewModel objModel)
        {
            if (objModel.objProduction.Flag == 1)
            {
                ProductionandStocksModel objModel1 = new ProductionandStocksModel();
                objModel1.MineralId1 = (int)TempData["Temp_MineralId"];
                objModel1.ProductionandStocks_Id = objModel.objProduction.ProductionandStocks_Id;
                objModel1.Development_OS_Qty = objModel.objProduction.Development_OS_Qty;
                objModel1.Development_OS_grade = objModel.objProduction.Development_OS_grade;
                objModel1.Development_Production_Qty = objModel.objProduction.Development_Production_Qty;
                objModel1.Development_Production_grade = objModel.objProduction.Development_Production_grade;
                objModel1.Development_CS_Qty = objModel.objProduction.Development_CS_Qty;
                objModel1.Development_CS_grade = objModel.objProduction.Development_CS_grade;
                objModel1.Stoping_OS_Qty = objModel.objProduction.Stoping_OS_Qty;
                objModel1.Stoping_OS_grade = objModel.objProduction.Stoping_OS_grade;
                objModel1.Stoping_Production_Qty = objModel.objProduction.Stoping_Production_Qty;
                objModel1.Stoping_Production_grade = objModel.objProduction.Stoping_Production_grade;
                objModel1.Stoping_CS_Qty = objModel.objProduction.Stoping_CS_Qty;
                objModel1.Stoping_CS_grade = objModel.objProduction.Stoping_CS_grade;
                objModel1.OpenCastWork_OS_Qty = objModel.objProduction.OpenCastWork_OS_Qty;
                objModel1.OpenCastWork_OS_grade = objModel.objProduction.OpenCastWork_OS_grade;
                objModel1.OpenCastWork_Production_Qty = objModel.objProduction.OpenCastWork_Production_Qty;
                objModel1.OpenCastWork_Production_grade = objModel.objProduction.OpenCastWork_Production_grade;
                objModel1.OpenCastWork_CS_Qty = objModel.objProduction.OpenCastWork_CS_Qty;
                objModel1.OpenCastWork_CS_grade = objModel.objProduction.OpenCastWork_CS_grade;
                objModel1.Total_OS_Qty = objModel.objProduction.Total_OS_Qty;
                objModel1.Total_OS_grade = objModel.objProduction.Total_OS_grade;
                objModel1.Total_Production_Qty = objModel.objProduction.Total_Production_Qty;
                objModel1.Total_Production_grade = objModel.objProduction.Total_Production_grade;
                objModel1.Total_CS_Qty = objModel.objProduction.Total_CS_Qty;
                objModel1.Total_CS_grade = objModel.objProduction.Total_CS_grade;
                objModel1.ExMinePrice = objModel.objProduction.ExMinePrice;
                objModel1.Month_Year = objModel.objProduction.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel1.UID = profile.UserId;
                //objModel1.UID = 132;

                objobjmodel = _objIeReturnNonCoalForm2Model.UpdateProductionandStocks(objModel1);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }
            else if (objModel.objProduction.Flag == 2)
            {
                ProductionandStocksModel objModel1 = new ProductionandStocksModel();
                objModel1.MineralId1 = (int)TempData["Temp_MineralId"];
                objModel1.Development_OS_Qty = objModel.objProduction.Development_OS_Qty;
                objModel1.Development_OS_grade = objModel.objProduction.Development_OS_grade;
                objModel1.Development_Production_Qty = objModel.objProduction.Development_Production_Qty;
                objModel1.Development_Production_grade = objModel.objProduction.Development_Production_grade;
                objModel1.Development_CS_Qty = objModel.objProduction.Development_CS_Qty;
                objModel1.Development_CS_grade = objModel.objProduction.Development_CS_grade;
                objModel1.Stoping_OS_Qty = objModel.objProduction.Stoping_OS_Qty;
                objModel1.Stoping_OS_grade = objModel.objProduction.Stoping_OS_grade;
                objModel1.Stoping_Production_Qty = objModel.objProduction.Stoping_Production_Qty;
                objModel1.Stoping_Production_grade = objModel.objProduction.Stoping_Production_grade;
                objModel1.Stoping_CS_Qty = objModel.objProduction.Stoping_CS_Qty;
                objModel1.Stoping_CS_grade = objModel.objProduction.Stoping_CS_grade;
                objModel1.OpenCastWork_OS_Qty = objModel.objProduction.OpenCastWork_OS_Qty;
                objModel1.OpenCastWork_OS_grade = objModel.objProduction.OpenCastWork_OS_grade;
                objModel1.OpenCastWork_Production_Qty = objModel.objProduction.OpenCastWork_Production_Qty;
                objModel1.OpenCastWork_Production_grade = objModel.objProduction.OpenCastWork_Production_grade;
                objModel1.OpenCastWork_CS_Qty = objModel.objProduction.OpenCastWork_CS_Qty;
                objModel1.OpenCastWork_CS_grade = objModel.objProduction.OpenCastWork_CS_grade;
                objModel1.Total_OS_Qty = objModel.objProduction.Total_OS_Qty;
                objModel1.Total_OS_grade = objModel.objProduction.Total_OS_grade;
                objModel1.Total_Production_Qty = objModel.objProduction.Total_Production_Qty;
                objModel1.Total_Production_grade = objModel.objProduction.Total_Production_grade;
                objModel1.Total_CS_Qty = objModel.objProduction.Total_CS_Qty;
                objModel1.Total_CS_grade = objModel.objProduction.Total_CS_grade;
                objModel1.ExMinePrice = objModel.objProduction.ExMinePrice;
                objModel1.Month_Year = objModel.objProduction.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel1.UID = profile.UserId;
                //objModel1.UID =132;
                objobjmodel = _objIeReturnNonCoalForm2Model.AddProductionandStocks(objModel1);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }
            if (objModel.objDeduction_made.Flag == 1)
            {
                Details_of_deductions_sale_computation objModel1 = new Details_of_deductions_sale_computation();
                objModel1.MineralId8 = (int)TempData["Temp_MineralId"];
                objModel1.DeductionMade_Id = objModel.objDeduction_made.DeductionMade_Id;
                objModel1.Deduction_claimedType7 = objModel.objDeduction_made.Deduction_claimedType7;
                objModel1.Amount1 = objModel.objDeduction_made.Amount1;
                objModel1.Amount2 = objModel.objDeduction_made.Amount2;
                objModel1.Amount3 = objModel.objDeduction_made.Amount3;
                objModel1.Amount4 = objModel.objDeduction_made.Amount4;
                objModel1.Amount5 = objModel.objDeduction_made.Amount5;
                objModel1.Amount6 = objModel.objDeduction_made.Amount6;
                objModel1.Amount7 = objModel.objDeduction_made.Amount7;
                objModel1.Remarks1 = objModel.objDeduction_made.Remarks1;
                objModel1.Remarks2 = objModel.objDeduction_made.Remarks2;
                objModel1.Remarks3 = objModel.objDeduction_made.Remarks3;
                objModel1.Remarks4 = objModel.objDeduction_made.Remarks4;
                objModel1.Remarks5 = objModel.objDeduction_made.Remarks5;
                objModel1.Remarks6 = objModel.objDeduction_made.Remarks6;
                objModel1.Remarks7 = objModel.objDeduction_made.Remarks7;
                objModel1.TotalAmount = objModel.objDeduction_made.TotalAmount;
                objModel1.CExMineSale = objModel.objDeduction_made.CExMineSale;
                objModel1.ex_mineSale = objModel.objDeduction_made.ex_mineSale;
                objModel1.Month_Year = objModel.objDeduction_made.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel1.UID = profile.UserId;
                //objModel1.UID = 132;
                objobjmodel = _objIeReturnNonCoalForm2Model.UpdateDetails_of_deductions(objModel1);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }
            else if (objModel.objDeduction_made.Flag == 2)
            {
                Details_of_deductions_sale_computation objModel1 = new Details_of_deductions_sale_computation();
                objModel1.MineralId8 = (int)TempData["Temp_MineralId"];
                objModel1.Deduction_claimedType7 = objModel.objDeduction_made.Deduction_claimedType7;
                objModel1.Amount1 = objModel.objDeduction_made.Amount1;
                objModel1.Amount2 = objModel.objDeduction_made.Amount2;
                objModel1.Amount3 = objModel.objDeduction_made.Amount3;
                objModel1.Amount4 = objModel.objDeduction_made.Amount4;
                objModel1.Amount5 = objModel.objDeduction_made.Amount5;
                objModel1.Amount6 = objModel.objDeduction_made.Amount6;
                objModel1.Amount7 = objModel.objDeduction_made.Amount7;
                objModel1.Remarks1 = objModel.objDeduction_made.Remarks1;
                objModel1.Remarks2 = objModel.objDeduction_made.Remarks2;
                objModel1.Remarks3 = objModel.objDeduction_made.Remarks3;
                objModel1.Remarks4 = objModel.objDeduction_made.Remarks4;
                objModel1.Remarks5 = objModel.objDeduction_made.Remarks5;
                objModel1.Remarks6 = objModel.objDeduction_made.Remarks6;
                objModel1.Remarks7 = objModel.objDeduction_made.Remarks7;
                objModel1.TotalAmount = objModel.objDeduction_made.TotalAmount;
                objModel1.CExMineSale = objModel.objDeduction_made.CExMineSale;
                objModel1.ex_mineSale = objModel.objDeduction_made.ex_mineSale;
                objModel1.Month_Year = objModel.objDeduction_made.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel1.UID = profile.UserId;
                //objModel1.UID = 132;
                objobjmodel = _objIeReturnNonCoalForm2Model.AddDetails_of_deductions(objModel1);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }
            if (objModel.objReason_Inc_Dec.Flag == 1)
            {
                Reason_Inc_Dec_Monthly_FormF2 objModelR = new Reason_Inc_Dec_Monthly_FormF2();
                objModelR.Reason_Inc_Dec_Id = objModel.objReason_Inc_Dec.Reason_Inc_Dec_Id;
                objModelR.productionIncrDecResion = objModel.objReason_Inc_Dec.productionIncrDecResion;
                objModelR.ex_minepriceIncrDecResion = objModel.objReason_Inc_Dec.ex_minepriceIncrDecResion;
                objModelR.certify = objModel.objReason_Inc_Dec.certify;
                objModelR.MineralId = (int)TempData["Temp_MineralId"];
                objModelR.Month_Year = objModel.objReason_Inc_Dec.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID = 132;
                objobjmodel = _objIeReturnNonCoalForm2Model.UpdateReasonForInDc(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }
            else if (objModel.objReason_Inc_Dec.Flag == 2)
            {
                Reason_Inc_Dec_Monthly_FormF2 objModelR = new Reason_Inc_Dec_Monthly_FormF2();
                objModelR.productionIncrDecResion = objModel.objReason_Inc_Dec.productionIncrDecResion;
                objModelR.ex_minepriceIncrDecResion = objModel.objReason_Inc_Dec.ex_minepriceIncrDecResion;
                objModelR.certify = objModel.objReason_Inc_Dec.certify;
                objModelR.MineralId = (int)TempData["Temp_MineralId"];
                objModelR.Month_Year = objModel.objReason_Inc_Dec.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID =132;
                objobjmodel = _objIeReturnNonCoalForm2Model.AddReasonForInDc(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
            }
            else if (objModel.objReason_Inc_Dec.FinalSubmitFlag == 1)
            {
                Reason_Inc_Dec_Monthly_FormF2 objModelR = new Reason_Inc_Dec_Monthly_FormF2();
                
                objModelR.Month_Year = objModel.objReason_Inc_Dec.Month_Year;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModelR.UID = profile.UserId;
                //objModelR.UID =132;
                objobjmodel = _objIeReturnNonCoalForm2Model.Update_FinalSubmit(objModelR);
                string result = objobjmodel.Msg;
                TempData["result"] = result;
               return RedirectToAction("eReturnDashboard", "eReturnProcess", new { area = "eReturn_NonCoal" });
            }

            return RedirectToAction("PartTwoForm2", new { MonthYear = TempData["M_Y"] });
        }

        /// <summary>
        /// Get Productionand Stock
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <returns>Json String</returns>
        public JsonResult GetProductionandStocks(string MonthYear)
        {
            try
            {
                string result;
                MonthlyReturnModelNonCoal objModel = new MonthlyReturnModelNonCoal();
                ProductionandStocksModel objViewModel = new ProductionandStocksModel();
                objModel.MonthYear = MonthYear;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.Uid = profile.UserId;
                //objModel.Uid = 132;
                objViewModel = _objIeReturnNonCoalForm2Model.GetProductionandStocks(objModel);
                result = objobjmodel.Satus;
                return Json(objViewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Get Details of Deduction
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="MineralId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetDetails_of_deductions(string MonthYear, int? MineralId)
        {
            try
            {
                string result;
                MonthlyReturnModelNonCoal objModel = new MonthlyReturnModelNonCoal();
                Details_of_deductions_sale_computation objViewModel = new Details_of_deductions_sale_computation();
                objModel.MonthYear = MonthYear;
                objModel.MineralId = MineralId;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.Uid = profile.UserId;
                //objModel.Uid =132;
                objViewModel = _objIeReturnNonCoalForm2Model.GetDetails_of_deductions(objModel);
                result = objobjmodel.Satus;
                return Json(objViewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Get Reason
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="MineralId"></param>
        /// <returns>Json Result</returns>
        public JsonResult GetReason_Inc_Dec(string MonthYear, int? MineralId)
        {
            try
            {
                string result;
                MonthlyReturnModelNonCoal objModel = new MonthlyReturnModelNonCoal();
                Reason_Inc_Dec_Monthly_FormF2 objViewModel = new Reason_Inc_Dec_Monthly_FormF2();
                objModel.MonthYear = MonthYear;
                objModel.MineralId = MineralId;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objModel.Uid = profile.UserId;
                //objModel.Uid =132;
                objViewModel = _objIeReturnNonCoalForm2Model.GetReason_Inc_Dec(objModel);
                result = objobjmodel.Satus;
                return Json(objViewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Print Form2
        /// </summary>
        /// <param name="MonthYear"></param>
        /// <param name="UserId"></param>
        /// <returns>View</returns>
        public ActionResult PrintFormF2(string MonthYear, int? UserId)
        {
            LesseeFormF2Part1Model data = new LesseeFormF2Part1Model();
            MonthlyReturnModelNonCoal Model = new MonthlyReturnModelNonCoal();
            Model.MonthYear = protector.Unprotect(MonthYear);
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            Model.Uid = profile.UserId;
            //Model.Uid =132;
            data = _objIeReturnNonCoalForm2Model.GetFormF2ForPrint(Model);
            ViewBag.UserId = profile.UserId;
            //ViewBag.UserId = 132;
            return View(data);


        }

        /// <summary>
        /// Get Mine Work Details
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns>Json Result</returns>
        public JsonResult GetMineWorkDetails(string Month_Year, int? UserId)
        {
            List<Working_of_Mine> data = new List<Working_of_Mine>();
            MonthlyReturnModelNonCoal Model = new MonthlyReturnModelNonCoal();
            Model.MonthYear = Month_Year;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            Model.Uid = profile.UserId;
            //Model.Uid =132;
            data = _objIeReturnNonCoalForm2Model.GetMineWorkDetails(Model);
            return Json(data);


        }

        /// <summary>
        /// Get Recoveries Concentrator For Print
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns>Json Result</returns>
        public JsonResult GetRecoveries_ConcentratorForPrint(string Month_Year, int? UserId)
        {
            List<RecoveriesModel> data = new List<RecoveriesModel>();
            MonthlyReturnModelNonCoal Model = new MonthlyReturnModelNonCoal();
            Model.MonthYear = Month_Year;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            Model.Uid = profile.UserId;
            //Model.Uid = 132;
            data = _objIeReturnNonCoalForm2Model.GetRecoveries_ConcentratorForPrint(Model);
            return Json(data);


        }

        /// <summary>
        /// Get Recoveries Smelter For Print
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetRecovery_SmelterForPrint(string Month_Year, int? UserId)
        {
            List<Recovery_atSmelterModel> data = new List<Recovery_atSmelterModel>();
            MonthlyReturnModelNonCoal Model = new MonthlyReturnModelNonCoal();
            Model.MonthYear = Month_Year;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            Model.Uid = profile.UserId;
            //Model.Uid =132;
            data = _objIeReturnNonCoalForm2Model.GetRecoveriesSmelter(Model);
            return Json(data);


        }

        /// <summary>
        /// Get Sales For Print
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetSalesForPrint(string Month_Year, int? UserId)
        {
            List<SaleProductModel> data = new List<SaleProductModel>();
            MonthlyReturnModelNonCoal Model = new MonthlyReturnModelNonCoal();
            Model.MonthYear = Month_Year;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            Model.Uid = profile.UserId;
            //Model.Uid =132;
            data = _objIeReturnNonCoalForm2Model.GetSaleProduct(Model);
            return Json(data);


        }

        /// <summary>
        /// Get Sales Dispatch
        /// </summary>
        /// <param name="Month_Year"></param>
        /// <param name="UserId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetSales_Dispatches(string Month_Year, int? UserId)
        {
            List<SalesDispatchOf_OreModel> data = new List<SalesDispatchOf_OreModel>();
            MonthlyReturnModelNonCoal Model = new MonthlyReturnModelNonCoal();
            Model.MonthYear = Month_Year;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            Model.Uid = profile.UserId;
            //Model.Uid = 132;
            data = _objIeReturnNonCoalForm2Model.GetSaleDispatch(Model);
            return Json(data);


        }

        #region DSC Response Verify
        string Signature = string.Empty;
        string OutputResult = string.Empty;
        /// <summary>
        /// Check Verify Response for print
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
        /// FOr Print Pages
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
        /// Save PDF file
        /// </summary>
        /// <param name="base64BinaryStr"></param>
        /// <param name="fileName"></param>
        /// <param name="ID"></param>
        /// <param name="UpdateIn"></param>
        /// <param name="Month_Year"></param>
        /// <returns>Json String</returns>
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

                    objobjmodel = _objIeReturnNonCoalForm2Model.Update_Filepath(objModel);
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
        /// Save Normal PDF File
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
