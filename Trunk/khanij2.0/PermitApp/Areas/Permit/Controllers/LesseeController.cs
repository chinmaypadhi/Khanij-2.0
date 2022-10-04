using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermitApp.Areas.Permit.Models.Lessee;
using PermitEF;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using PermitApp.Helper;
using PermitApp.Web;
using Microsoft.Extensions.Configuration;
using PermitApp.ActionFilter;
using PermitApp.Areas.Permit.Models.CoalEPermit;

namespace PermitApp.Areas.Permit.Controllers
{
    [Area("Permit")]
    public class LesseeController : Controller
    {
        ILesseePermitModel _userPemit;
        ICoalEPermitModel _userCoalPemit;
        private IConfiguration configuration;
        string SBIAPIPath = "";
        MessageEF objMSmodel = new MessageEF();
        public object JsonRequestBehavior { get; private set; }
        IHostingEnvironment _hostingEnvironment;
        string OutputResult = "";


        public LesseeController(ILesseePermitModel objPermit, IHostingEnvironment hostingEnvironment, IConfiguration _configuration, ICoalEPermitModel userCoalPemit)
        {
            _userPemit = objPermit;
            _hostingEnvironment = hostingEnvironment;
            this.configuration = _configuration;
            _userCoalPemit = userCoalPemit;
        }
        public ActionResult AddBulkPermitData(ePermitModel model, string cmdPreview, string cmdTransfer)
        {

            // var previewRequest = Convert.ToString(Request.["cmdPreview"]);
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 83;
            model.PaymentBank = "SBI";
            if (cmdPreview != null)
            {
                var dataString = CustomQueryStringHelper.
            EncryptString("Permit", "ePermitViewWithoutDSC", "Lessee", new { id = model.BulkPermitId });
                // SBIAPIPath = configuration.GetSection("Path").GetSection("APIUrl").Value + dataString;
                return new RedirectResult(dataString);
                // return RedirectToAction("ePermitViewWithoutDSC", "Lessee", new { id = model.BulkPermitId });
            }
            else
            {
                if (model.ProposedQty > Convert.ToDecimal(model.RemainingProduction))
                {
                    OutputResult = "2";
                    TempData["Acknowledgement"] = OutputResult;
                    return RedirectToAction("ePermitApplication", "Lessee");
                }
                else
                {
                    // var TransferRequest = Convert.ToString(Request["cmdTransfer);
                    if (cmdTransfer != null)
                    {
                        if (ModelState.IsValid)
                        {
                            if (model.MineralId == 0 || model.MineralNatureId == 0 || model.MineralNatureId == 0)
                            {
                                OutputResult = "3";
                                TempData["Acknowledgement"] = OutputResult;
                                return RedirectToAction("ePermitApplication", "Lessee");
                            }
                            else
                            {
                                model.isForwarded = 1;
                                objMSmodel = _userPemit.AddBulkPermit(model);
                                OutputResult = objMSmodel.Satus;
                                if (OutputResult != "-1")
                                {
                                    TempData["Acknowledgement"] = OutputResult;
                                    return RedirectToAction("ePermitApplication", "Lessee");
                                }
                                else
                                {
                                    OutputResult = "2";
                                    TempData["Acknowledgement"] = OutputResult;
                                    return RedirectToAction("ePermitApplication", "Lessee");
                                }
                                //return Json(OutputResult.ToDataSourceResult(request));
                            }
                        }
                        else
                        {
                            OutputResult = "3";
                            TempData["Acknowledgement"] = OutputResult;
                            return RedirectToAction("ePermitApplication", "Lessee");
                            //return Json(OutputResult.ToDataSourceResult(request));
                        }
                    }
                    else
                    {
                        if (model.MineralId == 0 || model.MineralNatureId == 0 || model.MineralNatureId == 0)
                        {
                            OutputResult = "3";
                            TempData["Acknowledgement"] = OutputResult;
                            return RedirectToAction("ePermitApplication", "Lessee");
                        }
                        else
                        {
                            objMSmodel = _userPemit.AddBulkPermit(model);
                            OutputResult = objMSmodel.Satus;
                            if (OutputResult == "-1")
                            {
                                OutputResult = "2";
                                TempData["Acknowledgement"] = OutputResult;
                                return RedirectToAction("ePermitApplication", "Lessee");
                            }
                            else
                            {
                                if (model.isForwarded == 1)
                                {
                                    if (model.BulkPermitId != 0)
                                    {
                                        //return RedirectToAction("ePermitPayment", "Lessee", new { id = model.BulkPermitId });
                                        var dataString = CustomQueryStringHelper.
                                EncryptString("Permit", "CoalPayment", "CoalEPermit", new { BulkPermitId = OutputResult });
                                        return new RedirectResult(dataString);
                                        //return RedirectToAction("ePermitPaymentTest", "Lessee", new { id = model.BulkPermitId });
                                    }
                                    else
                                    {
                                        //return RedirectToAction("ePermitPayment", "Lessee", new { id = OutputResult });
                                        var dataString = CustomQueryStringHelper.
                                EncryptString("Permit", "CoalPayment", "CoalEPermit", new { BulkPermitId = OutputResult });
                                        return new RedirectResult(dataString);
                                        //return RedirectToAction("ePermitPaymentTest", "Lessee", new { id = OutputResult });
                                    }
                                }
                                else
                                {
                                    TempData["Acknowledgement"] = 1;
                                    return RedirectToAction("ePermitApplication", "Lessee");
                                }
                            }
                        }
                    }
                }

            }
        }
        [SkipImportantTask]
        public IActionResult ePermitApplication(string id)
        {
            ePermitModel objmodeltwo = new ePermitModel();
            ePermitModel objmodel = new ePermitModel();
            ePermitResult objTotalAppl = new ePermitResult();
            ePermitResult objDetailsAppl = new ePermitResult();
            ePermitResult objOperationAppl = new ePermitResult();
            ePermitResult objOperationBulkAppl = new ePermitResult();
            ePermitResult MINEDET = new ePermitResult();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            MINEDET = _userCoalPemit.GetMinesDetails(objmodel);
            if (MINEDET != null && MINEDET.CheckList.Count > 0)
            {
                foreach (var a in MINEDET.CheckList)
                {
                    ViewBag.Auct = a.eAuctionTypeId;
                    ViewBag.Leaseext = a.LeaseExtendText;
                    ViewBag.capt = a.CaptiveText;
                    ViewBag.Mlgrd = a.MLGrantedDateText;

                }
            }
            objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
            string UserType = profile.UserType;
            objmodeltwo.UserID = Convert.ToInt32(profile.UserId);

            if (id != "" && id != null && id != "0")
            {
                objmodeltwo.BulkPermitId = Convert.ToInt32(id);
                objmodeltwo.UserCode = "Lessee";
                objTotalAppl = _userPemit.GetCheckOutPermitPayment(objmodeltwo);
                int count = 0;
                decimal walletcount = 0;
                if (objTotalAppl != null && objTotalAppl.PermitOperationLst.Count > 0)
                {
                    for (int i = 0; i < objTotalAppl.PermitPaymentLst.Count; i++)
                    {
                        count = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].OrderNStatus);
                        walletcount = Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].WalletAdjustedAmount);
                        if (count == 1 || walletcount != 0)
                        {
                            var dataString = CustomQueryStringHelper.
                               EncryptString("Permit", "ePermitPaymentCheckOut", "Lessee", new { id = id });
                            return new RedirectResult(dataString);
                        }
                        objmodeltwo.BulkPermitId = 0;
                        objmodeltwo.UserCode = null;
                    }
                }
            }
            //objmodel.UserID = 83;
            //objmodel.UserLoginId = "740";

            //string UserType = "Lessee";

            var x = _userPemit.GetCoalMineralNatureList(objmodel);
            if (x.MineralNatureLst != null)
            {
                ViewBag.ViewMineralNatureList = x.MineralNatureLst.Select(c => new SelectListItem
                {
                    Text = c.MineralNature,
                    Value = c.MineralNatureId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewMineralNatureList = Enumerable.Empty<SelectListItem>();
            }


            if (UserType.ToUpper() == "TAILING DAM")
            {
                return RedirectToAction("TailingDamePermitApplication", new { BulkpermitId = id });
            }
            objTotalAppl = _userPemit.CheckTotalPermitByUser(objmodel);
            // DataTable dataTable1 = objDb.ExecuteStoreProcedure(sqcmd);

            if (objTotalAppl != null)
            {
                if (objTotalAppl.TotalPermitLstByUserID.Count > 0)
                {

                    objDetailsAppl = _userPemit.GetPermitDetailsByUserID(objmodel);
                    if (objDetailsAppl != null && objDetailsAppl.DetailsPermitLstByUserID.Count > 0)
                    {
                        ePermitModel model = new ePermitModel();
                        foreach (var app in objDetailsAppl.DetailsPermitLstByUserID)
                        {
                            model.TillDateDispatched = Convert.ToString(app.TotalDispatched);
                            model.MPValidity = Convert.ToString(app.LeaseValidity);

                            model.RoadDispatch = (app.RoadDispatch is null) ? "0.0" : Convert.ToString(app.RoadDispatch);
                            model.RoadRailDispatch = (app.RoadRailDispatch is null) ? "0.0" : Convert.ToString(app.RoadRailDispatch);
                            model.InsideRailwaySidingDispatch = (app.InsideRailwaySidingDispatch is null) ? "0.0" : Convert.ToString(app.InsideRailwaySidingDispatch);
                            model.ConveyorBeltDispatch = (app.ConveyorBeltDispatch is null) ? "0.0" : Convert.ToString(app.ConveyorBeltDispatch);
                            model.MGROWNWagonDispatch = (app.MGROWNWagonDispatch is null) ? "0.0" : Convert.ToString(app.MGROWNWagonDispatch);
                            model.EndUsePlantinsIdetheLeaseAreaDispatch = (app.EndUsePlantinsIdetheLeaseAreaDispatch is null) ? "0.0" : Convert.ToString(app.EndUsePlantinsIdetheLeaseAreaDispatch);
                            model.RopewayDispatch = (app.RopewayDispatch is null) ? "0.0" : Convert.ToString(app.RopewayDispatch);
                            model.UserTotalDispatch = (app.UserTotalDispatch is null) ? "0.0" : Convert.ToString(app.UserTotalDispatch);

                            model.TotalMiningProductionQty = (app.MiningQty is null) ? "0.0" : Convert.ToString(app.MiningQty);
                            model.TotalECApprovedQty = (app.ECQty is null) ? "0.0" : Convert.ToString(app.ECQty);
                            model.ECValidity = (app.LeaseValidity is null) ? "0.0" : Convert.ToString(app.LeaseValidity);
                            model.ChangeBiggerEC = (app.ChangeBiggerEC is null) ? "0.0" : Convert.ToString(app.ChangeBiggerEC);
                            model.ChangeBiggerMining = (app.ChangeBiggerMining is null) ? "0.0" : Convert.ToString(app.ChangeBiggerMining);
                            if (Convert.ToDecimal(model.ChangeBiggerMining) < Convert.ToDecimal(model.ChangeBiggerEC))
                            {
                                ViewBag.Mining = " + Opening Stock";
                                ViewBag.EC = null;
                            }
                            else
                            {
                                ViewBag.EC = " + Opening Stock";
                                ViewBag.Mining = null;
                            }
                        }
                        if (TempData["Acknowledgement"] != null)
                        {
                            ViewBag.Acknowledgement = Convert.ToString(TempData["Acknowledgement"]);
                        }
                        try
                        {
                            if (Convert.ToInt32(id) == 0)
                            {
                                objOperationAppl = _userPemit.GetPermitOperation(objmodel);
                                ViewBag.ViewMineralGrade = Enumerable.Empty<SelectListItem>();

                                if (objOperationAppl != null && objOperationAppl.DetailsPermitLstByUserID.Count > 0)
                                {
                                    foreach (var app1 in objOperationAppl.DetailsPermitLstByUserID)
                                    {
                                        if (Convert.ToString(app1.GrantOrderNumber) == null)
                                        {
                                            TempData["AlertMsg"] = "Details not found !";
                                        }
                                        else
                                        {
                                            model.LesseeName = Convert.ToString(app1.ApplicantName);
                                            model.LesseeAddress = Convert.ToString(app1.Address);
                                            if (!(app1.DistrictId is null))
                                            {
                                                model.DistrictId = Convert.ToInt32(app1.DistrictId);
                                            }
                                            model.District = Convert.ToString(app1.DistrictName);
                                            if (!(app1.TehsilID is null))
                                            {
                                                model.TehsilId = Convert.ToInt32(app1.TehsilID);
                                            }
                                            model.Tehsil = Convert.ToString(app1.TehsilName);
                                            if (!(app1.VILLAGE_ID is null))
                                            {
                                                model.VillageId = Convert.ToInt32(app1.VILLAGE_ID);
                                            }
                                            model.Village = Convert.ToString(app1.VillageName);
                                            model.GrantOrderNo = Convert.ToString(app1.GrantOrderNumber);
                                            model.DateOfGrant = Convert.ToString(app1.GrantOrderDate);
                                            if (!(app1.MINERAL_ID is null))
                                            {
                                                model.MineralId = Convert.ToInt32(app1.MINERAL_ID);
                                            }
                                            model.MineralName = Convert.ToString(app1.MineralName);
                                            //  model.MineralGradeId = Convert.ToInt32(app1.MINERAL_GRADE_ID);
                                            // model.MineralGradeName = Convert.ToString(app1.MineralGrade);
                                            model.MineralGradeName = Convert.ToString(app1.MineralGrade);
                                            model.MineralNature = Convert.ToString(app1.MineralNature);
                                            if (!(app1.UnitId is null))
                                            {
                                                model.UnitId = Convert.ToInt32(app1.UnitId);
                                            }
                                            model.UnitName = Convert.ToString(app1.UnitName);
                                            model.RoyaltyRate = String.IsNullOrEmpty(app1.RoyaltyRate.ToString()) == false ? Convert.ToDecimal(app1.RoyaltyRate) : 0;
                                            model.PeriodOfLeaseFrom = Convert.ToString(app1.PROSPECTING_VALIDITY_FROM);
                                            model.PeriodOfLeaseTo = Convert.ToString(app1.PROSPECTING_VALIDITY_TO);
                                            model.PeriodOfLease = Convert.ToString(app1.PeriodOfLease);
                                            if (!(app1.LeaseTypeId is null))
                                            {
                                                model.LeaseTypeId = Convert.ToInt32(app1.LeaseTypeId);
                                            }
                                            model.LeaseTypeName = Convert.ToString(app1.LeaseTypeName);
                                            model.PoliceStation = Convert.ToString(app1.POLICE_STATION);
                                            model.Panchayat = Convert.ToString(app1.GRAM_PANCHAYAT);
                                            model.ProductionYear = Convert.ToString(app1.ProductionYear);
                                            model.Production = Convert.ToString(app1.Production);
                                            model.RemainingProduction = Convert.ToString(app1.RemainingProduction);

                                            model.GeneratedBy = Convert.ToString(app1.GeneratedBy);
                                            model.GeneratedDesignation = Convert.ToString(app1.GeneratedDesignation);

                                            model.IsWalletAdjusted = Convert.ToString(app1.IsWalletAdjusted);

                                            TempData["LeaseTypeId"] = model.LeaseTypeId;
                                        }
                                        return View(model);
                                    }
                                }
                                else
                                {
                                    TempData["AlertMsg"] = "Details not found !";
                                    return View(model);
                                    //return RedirectToAction("ValidityExpired", "ValidityExpired", new { Area = "" });
                                }
                                // }
                                // }
                            }
                            else
                            {
                                objmodel.BulkPermitId = Convert.ToInt32(id);
                                objOperationBulkAppl = _userPemit.GetPermitOperationByBulkId(objmodel);

                                if (objOperationBulkAppl != null)
                                {
                                    foreach (var app1 in objOperationBulkAppl.PermitOperationBulkIDLst)
                                    {
                                        // DataTable dt = ds.Tables[0];
                                        //if (dt != null && modelList.Count > 0)
                                        //{
                                        model.TransactionalID = Convert.ToString(app1.TransactionalID);
                                        model.MobileNo = Convert.ToString(app1.MobileNo);
                                        model.EmailId = Convert.ToString(app1.EMailId);
                                        model.LesseeName = Convert.ToString(app1.ApplicantName);
                                        model.LesseeAddress = Convert.ToString(app1.Address);
                                        if (!(app1.DistrictId is null))
                                        {
                                            model.DistrictId = Convert.ToInt32(app1.DistrictId);
                                        }
                                        model.District = Convert.ToString(app1.DistrictName);
                                        if (!(app1.TehsilID is null))
                                        {
                                            model.TehsilId = Convert.ToInt32(app1.TehsilID);
                                        }
                                        model.Tehsil = Convert.ToString(app1.TehsilName);
                                        if (!(app1.VILLAGE_ID is null))
                                        {
                                            model.VillageId = Convert.ToInt32(app1.VILLAGE_ID);
                                        }
                                        model.Village = Convert.ToString(app1.VillageName);
                                        model.GrantOrderNo = Convert.ToString(app1.GrantOrderNumber);
                                        model.DateOfGrant = Convert.ToString(app1.GrantOrderDate);
                                        if (!(app1.MINERAL_ID is null))
                                        {
                                            model.MineralId = Convert.ToInt32(app1.MINERAL_ID);
                                        }
                                        model.MineralName = Convert.ToString(app1.MineralName);
                                        if (!(app1.MineralNatureId is null))
                                        {
                                            model.MineralNatureId = Convert.ToInt32(app1.MineralNatureId);
                                            objmodel.MineralNatureId = Convert.ToInt32(app1.MineralNatureId);
                                        }
                                        // GetMineralGrade(Convert.ToInt32(model.MineralNatureId));
                                        var y = _userPemit.GetMineralGradeListOnNatureList(objmodel);
                                        if (y.MineralGradeLst != null)
                                        {
                                            ViewBag.ViewMineralGrade = y.MineralGradeLst.Select(c => new SelectListItem
                                            {
                                                Text = c.MineralGrade,
                                                Value = c.MineralGradeId.ToString(),
                                            }).ToList();
                                        }
                                        else
                                        {
                                            ViewBag.ViewMineralGrade = Enumerable.Empty<SelectListItem>();
                                        }
                                        if (!(app1.MINERAL_GRADE_ID is null))
                                        {
                                            model.MineralGradeId = Convert.ToInt32(app1.MINERAL_GRADE_ID);
                                        }
                                        model.MineralGradeName = Convert.ToString(app1.MineralGrade);
                                        if (!(app1.UnitId is null))
                                        {
                                            model.UnitId = Convert.ToInt32(app1.UnitId);
                                        }
                                        model.UnitName = Convert.ToString(app1.UnitName);
                                        model.RoyaltyRate = String.IsNullOrEmpty(app1.RoyaltyRate.ToString()) == false ? Convert.ToDecimal(app1.RoyaltyRate) : 0;
                                        model.PeriodOfLeaseFrom = Convert.ToString(app1.PROSPECTING_VALIDITY_FROM);
                                        model.PeriodOfLeaseTo = Convert.ToString(app1.PROSPECTING_VALIDITY_TO);
                                        model.PeriodOfLease = Convert.ToString(app1.PeriodOfLease);
                                        if (!(app1.LeaseTypeId is null))
                                        {
                                            model.LeaseTypeId = Convert.ToInt32(app1.LeaseTypeId);
                                        }
                                        model.LeaseTypeName = Convert.ToString(app1.LeaseTypeName);
                                        if (!(app1.BulkPermitId == 0))
                                        {
                                            model.BulkPermitId = Convert.ToInt32(app1.BulkPermitId);
                                        }
                                        model.TCS = Convert.ToDecimal(app1.TCS);
                                        model.Cess = Convert.ToDecimal(app1.Cess);
                                        model.eCess = Convert.ToDecimal(app1.eCess);
                                        model.DMF = Convert.ToDecimal(app1.DMF);
                                        model.NMET = Convert.ToDecimal(app1.NMET);
                                        model.PayableRoyalty = Convert.ToDecimal(app1.PayableRoyalty);
                                        model.TotalPayableAmount = Convert.ToDecimal(app1.TotalPayableAmount);
                                        model.ProposedQty = Convert.ToDecimal(app1.ProposedQty);
                                        model.AluminaContent = Convert.ToDecimal(app1.AluminaContent);
                                        model.TinContent = Convert.ToDecimal(app1.TinContent);

                                        model.PoliceStation = Convert.ToString(app1.POLICE_STATION);
                                        model.Panchayat = Convert.ToString(app1.GRAM_PANCHAYAT);
                                        model.ProductionYear = Convert.ToString(app1.ProductionYear);
                                        model.Production = Convert.ToString(app1.Production);
                                        model.RemainingProduction = Convert.ToString(app1.RemainingProduction);

                                        model.GeneratedBy = Convert.ToString(app1.GeneratedBy);
                                        model.GeneratedDesignation = Convert.ToString(app1.GeneratedDesignation);
                                        model.IsWalletAdjusted = Convert.ToString(app1.IsWalletAdjusted);

                                        TempData["LeaseTypeId"] = model.LeaseTypeId;

                                        List<ePaymentData> objPaymentList = new List<ePaymentData>();

                                        foreach (var app2 in objOperationBulkAppl.PermitPaymentLst)
                                        {
                                            ePaymentData objPayment = new ePaymentData();
                                            objPayment.PaymentType = Convert.ToString(app2.PaymentType);

                                            objPayment.CalType = Convert.ToString(app2.CalType);

                                            objPayment.CalValue = Convert.ToString(app2.CalValue);


                                            objPayment.MappingValue = Convert.ToString(app2.MappingValue);


                                            objPayment.RoyaltyRate = Convert.ToString(app2.RoyaltyRate);

                                            objPayment.BasisRate = Convert.ToString(app2.BasicPrice);

                                            objPayment.TotalPayableAmount = Convert.ToString(app2.TotalPayableAmount);

                                            objPayment.HeadAccount = Convert.ToString(app2.HeadAccount);
                                            model.CheckoutStatus = Convert.ToInt32(app2.CheckoutStatus);

                                            objPaymentList.Add(objPayment);
                                        }
                                        //        }
                                        //    }
                                        //}

                                        model.PaymentDetails = objPaymentList;
                                        return View(model);
                                        //}
                                    }
                                }
                                //}
                                // }
                            }
                            return View(model);
                        }
                        catch (Exception)
                        {
                            return View(model);
                        }
                    }
                    else
                    {
                        return RedirectToAction("ValidityExpired", "ValidityExpired", new { Area = "" });
                    }
                }
                else
                {
                    if (UserType.ToUpper() == "LESSEE")
                        return RedirectToAction("ePermitRequiredFields", "Lessee");
                    else
                        return RedirectToAction("RequiredFields", "RequiredFields", new { Area = "Licensee" });

                }
            }
            else
            {
                if (UserType.ToUpper() == "LESSEE")
                    return RedirectToAction("ePermitRequiredFields", "BulkPermit");
                else
                    return RedirectToAction("RequiredFields", "RequiredFields", new { Area = "Licensee" });
            }
        }
        public JsonResult GetMineralGrade(int NatureID)
        {
            ePermitModel objPermit = null;
            try
            {
                objPermit = new ePermitModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objPermit.UserID = Convert.ToInt32(profile.UserId);
                //objPermit.UserID = 83;
                objPermit.MineralNatureId = NatureID;
                var x = _userPemit.GetMineralGradeListOnNatureList(objPermit);
                var SList = x.MineralGradeLst.ToList();
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
        public JsonResult GradeWiseCheckECQTY(string MineralGradeId)

        {
            try
            {
                decimal PCap = 0;
                ePermitModel objPermit = null;
                objPermit = new ePermitModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objPermit.UserID = Convert.ToInt32(profile.UserId);
                //objPermit.UserID = 64;//83;
                objPermit.MineralGradeId = Convert.ToInt32(MineralGradeId);
                List<ePermitModel> ltePermit = new List<ePermitModel>();
                ltePermit = _userPemit.GradeWiseCheckECQTY(objPermit);
                PCap = Convert.ToDecimal(ltePermit[0].RemainingProduction.ToString());

                //PCap = Convert.ToDecimal(x.Select(item => item.RemainingProduction).ToString());

                // PCap = Convert.ToDecimal(app.RemainingProduction"].ToString());

                return Json(PCap);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public JsonResult RevisedCalculation(int? MineralNatureId, int? MineralGradeId, int? MineralId, decimal? Quantity, decimal? RoyaltyRate, int BulkPermitId, decimal? AluminaContent, decimal? TinContent,int? DistrictId)
        {
            try
            {
                List<ePaymentData> List = new List<ePaymentData>();
                ePaymentData model = new ePaymentData();
                ePermitModel objmodel = new ePermitModel();
                ePermitModel objmodelcoal = new ePermitModel();
                ePermitModel objmodelless = new ePermitModel();
                objmodel.MineralNatureId = Convert.ToInt32(MineralNatureId);
                objmodel.MineralGradeId = Convert.ToInt32(MineralGradeId);
                objmodel.MineralId = MineralId;
                objmodel.Quantity = Quantity;
                objmodel.RoyaltyRate = RoyaltyRate;
                objmodel.BulkPermitId = BulkPermitId;
                objmodel.AluminaContent = AluminaContent;
                objmodel.TinContent = TinContent;
                objmodel.DistrictId = DistrictId;
                objmodel.UserCode = "Lessee";//Get data from userlogin
                                             //objmodel.UserID = 59;//for non lessee


                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = Convert.ToInt32(profile.UserId);
                //objmodel.UserID = 64;// 83;
                List<ePaymentData> ltePermit = new List<ePaymentData>();
                List = _userPemit.RevisedPayableRoyaltyRate(objmodel);

                ePermitModel objpermitmodel = new ePermitModel();
                objpermitmodel.UserID = Convert.ToInt32(profile.UserId);
                List<ePaymentData> lstpermit = new List<ePaymentData>();
                int count = 0;

                for (var i = 0; i < List.Count; i++)
                {
                    model = new ePaymentData();

                    if (Convert.ToString(List[i].MappingCount) == "0")
                    {
                        break;
                    }
                    else
                    {

                        if(List[i].MakePayementId== 1 && List[i].IsApplicable == false)
                        {
                            model.PaymentTypeID = Convert.ToString(List[i].PaymentTypeID);
                            model.PaymentType = Convert.ToString(List[i].PaymentType);
                            model.CalType = Convert.ToString(List[i].CalType);
                            model.CalValue = Convert.ToString(List[i].CalValue);
                            model.MappingValue = Convert.ToString(List[i].MappingValue);
                            model.HeadAccount = Convert.ToString(List[i].HeadAccount);

                                model.IsApplicable = true;
                            
                            if (i == 0 && List.Count > 1)
                            {
                                model.RoyaltyRate = Convert.ToString(List[i].RoyaltyRate);
                                model.PayableRoyalty = Convert.ToString(List[i].MappingValue);
                                model.BasisRate = Convert.ToString(List[i].BasicPrice);
                                model.TotalPayableAmount = Convert.ToString(List[i + 1].TotalPayableAmount);
                            }
                            else
                            {
                                model.RoyaltyRate = Convert.ToString(List[0].RoyaltyRate);
                                model.PayableRoyalty = Convert.ToString(List[0].MappingValue);
                                model.BasisRate = Convert.ToString(List[0].BasicPrice);
                                model.TotalPayableAmount = Convert.ToString(List[0].TotalPayableAmount);
                            }
                        }
                        else if(List[i].MakePayementId == 0 && List[i].IsApplicable == true)
                        {
                            model.PaymentTypeID = Convert.ToString(List[i].PaymentTypeID);
                            model.PaymentType = Convert.ToString(List[i].PaymentType);
                            model.CalType = Convert.ToString(List[i].CalType);
                            model.CalValue = Convert.ToString(List[i].CalValue);
                            model.MappingValue = Convert.ToString(List[i].MappingValue);
                            model.HeadAccount = Convert.ToString(List[i].HeadAccount);

                            model.IsApplicable = false;

                            if (i == 0 && List.Count > 1)
                            {
                                model.RoyaltyRate = Convert.ToString(List[i].RoyaltyRate);
                                model.PayableRoyalty = Convert.ToString(List[i].MappingValue);
                                model.BasisRate = Convert.ToString(List[i].BasicPrice);
                                model.TotalPayableAmount = Convert.ToString(List[i + 1].TotalPayableAmount);
                            }
                            else
                            {
                                model.RoyaltyRate = Convert.ToString(List[0].RoyaltyRate);
                                model.PayableRoyalty = Convert.ToString(List[0].MappingValue);
                                model.BasisRate = Convert.ToString(List[0].BasicPrice);
                                model.TotalPayableAmount = Convert.ToString(List[0].TotalPayableAmount);
                            }
                        }
                        else if (List[i].MakePayementId == 0 && List[i].IsApplicable == false)
                        {
                            model.PaymentTypeID = Convert.ToString(List[i].PaymentTypeID);
                            model.PaymentType = Convert.ToString(List[i].PaymentType);
                            model.CalType = Convert.ToString(List[i].CalType);
                            model.CalValue = Convert.ToString(List[i].CalValue);
                            model.MappingValue = Convert.ToString(List[i].MappingValue);
                            model.HeadAccount = Convert.ToString(List[i].HeadAccount);

                            model.IsApplicable = false;

                            if (i == 0 && List.Count > 1)
                            {
                                model.RoyaltyRate = Convert.ToString(List[i].RoyaltyRate);
                                model.PayableRoyalty = Convert.ToString(List[i].MappingValue);
                                model.BasisRate = Convert.ToString(List[i].BasicPrice);
                                model.TotalPayableAmount = Convert.ToString(List[i + 1].TotalPayableAmount);
                            }
                            else
                            {
                                model.RoyaltyRate = Convert.ToString(List[0].RoyaltyRate);
                                model.PayableRoyalty = Convert.ToString(List[0].MappingValue);
                                model.BasisRate = Convert.ToString(List[0].BasicPrice);
                                model.TotalPayableAmount = Convert.ToString(List[0].TotalPayableAmount);
                            }
                        }
                        else if (List[i].MakePayementId == 1 && List[i].IsApplicable == true)
                        {
                            model.PaymentTypeID = Convert.ToString(List[i].PaymentTypeID);
                            model.PaymentType = Convert.ToString(List[i].PaymentType);
                            model.CalType = Convert.ToString(List[i].CalType);
                            model.CalValue = Convert.ToString(List[i].CalValue);
                            model.MappingValue = Convert.ToString(List[i].MappingValue);
                            model.HeadAccount = Convert.ToString(List[i].HeadAccount);

                            model.IsApplicable = true;

                            if (i == 0 && List.Count > 1)
                            {
                                model.RoyaltyRate = Convert.ToString(List[i].RoyaltyRate);
                                model.PayableRoyalty = Convert.ToString(List[i].MappingValue);
                                model.BasisRate = Convert.ToString(List[i].BasicPrice);
                                model.TotalPayableAmount = Convert.ToString(List[i + 1].TotalPayableAmount);
                            }
                            else
                            {
                                model.RoyaltyRate = Convert.ToString(List[0].RoyaltyRate);
                                model.PayableRoyalty = Convert.ToString(List[0].MappingValue);
                                model.BasisRate = Convert.ToString(List[0].BasicPrice);
                                model.TotalPayableAmount = Convert.ToString(List[0].TotalPayableAmount);
                            }
                        }
                        else
                        {
                            count = 1;
                        }
                    }
                    if (count == 0)
                    {
                        ltePermit.Add(model);
                    }
                   
                  
                    // }
                }
                //    }
                //}
                // }
                return Json(ltePermit);
            }
            catch
            {
                return null;
            }
        }
        public IActionResult ePermitPayment(int id)
        {
            try
            {
                ePermitModel model = new ePermitModel();

                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserID = Convert.ToInt32(profile.UserId);
                string UserType = profile.UserType;
                model.UserCode = profile.UserType;
                //model.UserID = 95;

                model.BulkPermitId = id;

                ePermitResult objTotalAppl = new ePermitResult();
                if (TempData["result"] != null)
                {
                    ViewBag.DisplayMsg = Convert.ToString(TempData["result"]);
                    ViewBag.ResultMsg = Convert.ToString(TempData["ResultMsg"]);
                }

                if (id == null || id == 0)
                {
                    return View(new ePermitModel { });
                }
                else
                {

                    objTotalAppl = _userPemit.GetePermitPayment(model);
                    //using (DataSet ds = objDb.getDataBy_SqlCommand_CB(cmd))
                    //    {
                    if (objTotalAppl != null && objTotalAppl.PermitOperationLst.Count > 0)
                    {
                        //  DataTable dt = ds.Tables[0];
                        //if (dt != null && modelList.Count > 0)
                        //{
                        foreach (var app in objTotalAppl.PermitOperationLst)
                        {
                            model.TransactionalID = Convert.ToString(app.TransactionalID);
                            model.MobileNo = Convert.ToString(app.MobileNo);
                            model.EmailId = Convert.ToString(app.EMailId);
                            model.LesseeName = Convert.ToString(app.ApplicantName);
                            model.LesseeAddress = Convert.ToString(app.Address);
                            model.DistrictId = Convert.ToInt32(app.DistrictId);
                            model.District = Convert.ToString(app.DistrictName);
                            model.DistrictCode = Convert.ToString(app.DistrictCode);
                            model.TehsilId = Convert.ToInt32(app.TehsilID);
                            model.Tehsil = Convert.ToString(app.TehsilName);
                            model.VillageId = Convert.ToInt32(app.VILLAGE_ID);
                            //if (dt.Columns.Contains("VILLAGE_ID"))
                            //{
                            //    model.Village = Convert.ToString(app.VILLAGE_ID"]);
                            //}
                            //else
                            //{
                            //    model.Village = "Not Mentioned";
                            //}
                            model.Village = Convert.ToString(app.VillageName);
                            if (!string.IsNullOrEmpty(model.Village))
                            {
                                model.Village = Convert.ToString(app.VillageName);
                            }
                            else
                            {
                                model.Village = "Not Mentioned";
                            }
                            //model.Village = Convert.ToString(app.VillageName"]);

                            if (UserType.ToUpper() != "TAILING DAM")
                            {

                                model.LeaseTypeId = Convert.ToInt32(app.LeaseTypeId);
                                model.ActiveStatus = Convert.ToInt32(app.ActiveStatus);
                                model.EAuctionType = Convert.ToString(app.EAuctionType.ToString());
                                model.TillDateBalanceUpfrontPayment = !string.IsNullOrEmpty(app.TillDateBalanceUpfrontPayment.ToString()) ? Convert.ToDecimal(app.TillDateBalanceUpfrontPayment) : 0;
                                model.MineralGradeName = Convert.ToString(app.MineralGrade);
                                TempData["LeaseTypeId"] = model.LeaseTypeId;
                            }
                            else
                            {
                                model.MineralGradeName = Convert.ToString(app.MineralGrade + " ( " + Convert.ToString(app.ActualGrade) + " )");
                            }

                            model.GrantOrderNo = Convert.ToString(app.GrantOrderNumber);
                            model.DateOfGrant = Convert.ToString(app.GrantOrderDate);
                            model.PeriodOfLeaseFrom = Convert.ToString(app.PROSPECTING_VALIDITY_FROM);
                            model.PeriodOfLeaseTo = Convert.ToString(app.PROSPECTING_VALIDITY_TO);
                            model.PeriodOfLease = Convert.ToString(app.PeriodOfLease);
                            model.LeaseTypeName = Convert.ToString(app.LeaseTypeName);
                            model.PoliceStation = Convert.ToString(app.POLICE_STATION);
                            model.Panchayat = Convert.ToString(app.GRAM_PANCHAYAT);

                            if (!(app.MINERAL_ID == null))
                            {
                                model.MineralId = Convert.ToInt32(app.MINERAL_ID);
                            }
                            model.PaymentStatus = Convert.ToInt32(app.PaymentStatus);
                            model.MineralName = Convert.ToString(app.MineralName);
                            model.MineralGradeId = Convert.ToInt32(app.MINERAL_GRADE_ID);

                            model.MineralNatureId = Convert.ToInt32(app.MineralNatureId);
                            model.MineralNature = Convert.ToString(app.MineralNature);

                            model.UnitId = Convert.ToInt32(app.UnitId);
                            model.UnitName = Convert.ToString(app.UnitName);
                            model.RoyaltyRate = Convert.ToDecimal(app.RoyaltyRate);

                            model.BulkPermitId = Convert.ToInt32(app.BulkPermitId);
                            model.TCS = Convert.ToDecimal(app.TCS);
                            model.Cess = Convert.ToDecimal(app.Cess);
                            model.eCess = Convert.ToDecimal(app.eCess);
                            model.DMF = Convert.ToDecimal(app.DMF);
                            model.NMET = Convert.ToDecimal(app.NMET);
                            model.PayableRoyalty = Convert.ToDecimal(app.PayableRoyalty);
                            model.TotalPayableAmount = Convert.ToDecimal(app.TotalPayableAmount);
                            model.ProposedQty = Convert.ToDecimal(app.ProposedQty);
                            model.ApprovedQty = Convert.ToDecimal(app.ApprovedQty);

                            model.GeneratedBy = Convert.ToString(app.GeneratedBy);
                            model.GeneratedDesignation = Convert.ToString(app.GeneratedDesignation);

                            model.ChallanNumber = Convert.ToString(app.ChallanNumber);
                            model.ChallanDate = Convert.ToString(app.ChallanDate);
                            model.ChallanFileName = Convert.ToString(app.ChallanCopyPath);

                            if (!string.IsNullOrEmpty(model.ChallanFileName))
                            {
                                model.ChallanCopyFilePath = model.ChallanFileName.Replace("PaymentDocuments", string.Empty).Replace(model.TransactionalID, "").Replace("\\_", "");
                            }
                            //decimal totalCheck = 0;
                            //decimal adjustCheck = 0;
                            string IspayOnline = "NO";
                            List<ePaymentData> objPaymentList = new List<ePaymentData>();
                            //if (ds.Tables.Count >= 2)
                            //{
                            //    DataTable dtPayment = ds.Tables[1];
                            //    if (dtPayment != null && dtPayment.Rows.Count > 0)
                            //    {
                            for (int i = 0; i < objTotalAppl.PermitPaymentLst.Count; i++)
                            {
                                ePaymentData objPayment = new ePaymentData();
                                objPayment.PaymentType = Convert.ToString(objTotalAppl.PermitPaymentLst[i].PaymentType);
                                if (Convert.ToString(objTotalAppl.PermitPaymentLst[i].PaymentType) == "Infrastructure & Development Cess")
                                {
                                    model.Cess = Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].MappingValue);
                                }
                                objPayment.CalType = Convert.ToString(objTotalAppl.PermitPaymentLst[i].CalType);
                                objPayment.CalValue = Convert.ToString(objTotalAppl.PermitPaymentLst[i].CalValue);

                                objPayment.MappingValue = Convert.ToString(objTotalAppl.PermitPaymentLst[i].MappingValue);
                                objPayment.IsApplicable = Convert.ToBoolean(objTotalAppl.PermitPaymentLst[i].IsApplicable);

                                objPayment.RoyaltyRate = Convert.ToString(objTotalAppl.PermitPaymentLst[i].RoyaltyRate);
                                objPayment.BasisRate = Convert.ToString(objTotalAppl.PermitPaymentLst[i].BasicPrice);
                                objPayment.TotalPayableAmount = Convert.ToString(objTotalAppl.PermitPaymentLst[i].TotalPayableAmount);
                                objPayment.HeadAccount = Convert.ToString(objTotalAppl.PermitPaymentLst[i].HeadAccount);
                                objPayment.AdjustmentAmount = Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].AdjustmentAmount);
                                objPayment.TotalAmount = Convert.ToString(objTotalAppl.PermitPaymentLst[i].TotalAmount);
                                objPayment.IsWalletAdjusted = Convert.ToString(app.IsWalletAdjusted);
                                if (Convert.ToBoolean(objTotalAppl.PermitPaymentLst[i].IsApplicable) == true)
                                {
                                    //totalCheck += Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].TotalAmount"]);
                                    //adjustCheck += Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].AdjustmentAmount"]);
                                    if ((Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].TotalAmount) > Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].AdjustmentAmount)) && IspayOnline == "NO")
                                    {
                                        IspayOnline = "YES";
                                    }
                                }
                                objPaymentList.Add(objPayment);
                            }
                            //    }
                            //}
                            if ((!(app.IsWalletAdjusted == null) && Convert.ToString(app.IsWalletAdjusted) == "0") || IspayOnline == "YES")
                            {
                                //TempData["Adjustment"] = "NO";
                                ViewBag.Adjustment = "NO";
                                IspayOnline = "NO";
                            }
                            else
                            {
                                //TempData["Adjustment"] = "YES";
                                ViewBag.Adjustment = "YES";
                            }


                            model.PaymentDetails = objPaymentList;

                            return View(model);
                        }
                    }
                    // }
                    // }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(new ePermitModel { });
            }

        }
        [SkipImportantTask]
        [HttpGet]
        public IActionResult ePermitPaymentTest(string BulkPermitId)
        {
            try
            {
                ePermitModel model = new ePermitModel();
                string UserType = "Lessee";
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserID = Convert.ToInt32(profile.UserId);
                //model.UserID = 83;
                model.UserCode = "Lessee";
                model.BulkPermitId = Convert.ToInt32(BulkPermitId);
                model.PaymentBank = "SBI";
                ePermitResult objTotalAppl = new ePermitResult();
                if (TempData["result"] != null)
                {
                    ViewBag.DisplayMsg = Convert.ToString(TempData["result"]);
                    ViewBag.ResultMsg = Convert.ToString(TempData["ResultMsg"]);
                }

                if (BulkPermitId == null || Convert.ToInt32(BulkPermitId) == 0)
                {
                    return View(new ePermitModel { });
                }
                else
                {

                    objTotalAppl = _userPemit.GetePermitPayment(model);

                    if (objTotalAppl != null && objTotalAppl.PermitOperationLst.Count > 0)
                    {

                        foreach (var app in objTotalAppl.PermitOperationLst)
                        {
                            model.TransactionalID = Convert.ToString(app.TransactionalID);
                            model.MobileNo = Convert.ToString(app.MobileNo);
                            model.EmailId = Convert.ToString(app.EMailId);
                            model.LesseeName = Convert.ToString(app.ApplicantName);
                            model.LesseeAddress = Convert.ToString(app.Address);
                            model.DistrictId = Convert.ToInt32(app.DistrictId);
                            model.District = Convert.ToString(app.DistrictName);
                            model.DistrictCode = Convert.ToString(app.DistrictCode);
                            model.TehsilId = Convert.ToInt32(app.TehsilID);
                            model.Tehsil = Convert.ToString(app.TehsilName);
                            model.VillageId = Convert.ToInt32(app.VILLAGE_ID);
                            //if (dt.Columns.Contains("VILLAGE_ID"))
                            //{
                            //    model.Village = Convert.ToString(app.VILLAGE_ID"]);
                            //}
                            //else
                            //{
                            //    model.Village = "Not Mentioned";
                            //}
                            model.Village = Convert.ToString(app.VillageName);
                            if (!string.IsNullOrEmpty(model.Village))
                            {
                                model.Village = Convert.ToString(app.VillageName);
                            }
                            else
                            {
                                model.Village = "Not Mentioned";
                            }
                            //model.Village = Convert.ToString(app.VillageName"]);

                            if (UserType.ToUpper() != "TAILING DAM")
                            {

                                model.LeaseTypeId = Convert.ToInt32(app.LeaseTypeId);
                                model.ActiveStatus = Convert.ToInt32(app.ActiveStatus);
                                model.EAuctionType = Convert.ToString(app.EAuctionType.ToString());
                                model.TillDateBalanceUpfrontPayment = !string.IsNullOrEmpty(app.TillDateBalanceUpfrontPayment.ToString()) ? Convert.ToDecimal(app.TillDateBalanceUpfrontPayment) : 0;
                                model.MineralGradeName = Convert.ToString(app.MineralGrade);
                                TempData["LeaseTypeId"] = model.LeaseTypeId;
                            }
                            else
                            {
                                model.MineralGradeName = Convert.ToString(app.MineralGrade + " ( " + Convert.ToString(app.ActualGrade) + " )");
                            }

                            model.GrantOrderNo = Convert.ToString(app.GrantOrderNumber);
                            model.DateOfGrant = Convert.ToString(app.GrantOrderDate);
                            model.PeriodOfLeaseFrom = Convert.ToString(app.PROSPECTING_VALIDITY_FROM);
                            model.PeriodOfLeaseTo = Convert.ToString(app.PROSPECTING_VALIDITY_TO);
                            model.PeriodOfLease = Convert.ToString(app.PeriodOfLease);
                            model.LeaseTypeName = Convert.ToString(app.LeaseTypeName);
                            model.PoliceStation = Convert.ToString(app.POLICE_STATION);
                            model.Panchayat = Convert.ToString(app.GRAM_PANCHAYAT);

                            if (!(app.MINERAL_ID == null))
                            {
                                model.MineralId = Convert.ToInt32(app.MINERAL_ID);
                            }
                            model.PaymentStatus = Convert.ToInt32(app.PaymentStatus);
                            model.MineralName = Convert.ToString(app.MineralName);
                            model.MineralGradeId = Convert.ToInt32(app.MINERAL_GRADE_ID);

                            model.MineralNatureId = Convert.ToInt32(app.MineralNatureId);
                            model.MineralNature = Convert.ToString(app.MineralNature);

                            model.UnitId = Convert.ToInt32(app.UnitId);
                            model.UnitName = Convert.ToString(app.UnitName);
                            model.RoyaltyRate = Convert.ToDecimal(app.RoyaltyRate);

                            model.BulkPermitId = Convert.ToInt32(app.BulkPermitId);
                            model.TCS = Convert.ToDecimal(app.TCS);
                            model.Cess = Convert.ToDecimal(app.Cess);
                            model.eCess = Convert.ToDecimal(app.eCess);
                            model.DMF = Convert.ToDecimal(app.DMF);
                            model.NMET = Convert.ToDecimal(app.NMET);
                            model.PayableRoyalty = Convert.ToDecimal(app.PayableRoyalty);
                            model.TotalPayableAmount = Convert.ToDecimal(app.TotalPayableAmount);
                            model.ProposedQty = Convert.ToDecimal(app.ProposedQty);
                            model.ApprovedQty = Convert.ToDecimal(app.ApprovedQty);

                            model.GeneratedBy = Convert.ToString(app.GeneratedBy);
                            model.GeneratedDesignation = Convert.ToString(app.GeneratedDesignation);

                            model.ChallanNumber = Convert.ToString(app.ChallanNumber);
                            model.ChallanDate = Convert.ToString(app.ChallanDate);
                            model.ChallanFileName = Convert.ToString(app.ChallanCopyPath);

                            if (!string.IsNullOrEmpty(model.ChallanFileName))
                            {
                                model.ChallanCopyFilePath = model.ChallanFileName.Replace("PaymentDocuments", string.Empty).Replace(model.TransactionalID, "").Replace("\\_", "");
                            }
                            //decimal totalCheck = 0;
                            //decimal adjustCheck = 0;
                            string IspayOnline = "NO";
                            List<ePaymentData> objPaymentList = new List<ePaymentData>();
                            //if (ds.Tables.Count >= 2)
                            //{
                            //    DataTable dtPayment = ds.Tables[1];
                            //    if (dtPayment != null && dtPayment.Rows.Count > 0)
                            //    {
                            for (int i = 0; i < objTotalAppl.PermitPaymentLst.Count; i++)
                            {
                                ePaymentData objPayment = new ePaymentData();
                                objPayment.BulkPaymentId = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].BulkPaymentId);
                                objPayment.PaymentType = Convert.ToString(objTotalAppl.PermitPaymentLst[i].PaymentType);
                                if (Convert.ToString(objTotalAppl.PermitPaymentLst[i].PaymentType) == "Infrastructure & Development Cess")
                                {
                                    model.Cess = Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].MappingValue);
                                }
                                objPayment.CalType = Convert.ToString(objTotalAppl.PermitPaymentLst[i].CalType);
                                objPayment.CalValue = Convert.ToString(objTotalAppl.PermitPaymentLst[i].CalValue);

                                objPayment.MappingValue = Convert.ToString(objTotalAppl.PermitPaymentLst[i].MappingValue);
                                objPayment.IsApplicable = Convert.ToBoolean(objTotalAppl.PermitPaymentLst[i].IsApplicable);

                                if (objPayment.PaymentType == "Royalty" || objPayment.PaymentType == "Monthly Periodic Amount" && objPayment.IsApplicable == true)
                                {
                                    objPayment.MakePayementId = 1;
                                }
                                else
                                {
                                    objPayment.MakePayementId = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].MakePayementId);
                                }

                                objPayment.RoyaltyRate = Convert.ToString(objTotalAppl.PermitPaymentLst[i].RoyaltyRate);
                                objPayment.BasisRate = Convert.ToString(objTotalAppl.PermitPaymentLst[i].BasicPrice);
                                objPayment.TotalPayableAmount = Convert.ToString(objTotalAppl.PermitPaymentLst[i].TotalPayableAmount);
                                objPayment.HeadAccount = Convert.ToString(objTotalAppl.PermitPaymentLst[i].HeadAccount);
                                objPayment.AdjustmentAmount = Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].AdjustmentAmount);
                                objPayment.TotalAmount = Convert.ToString(objTotalAppl.PermitPaymentLst[i].TotalAmount);
                                objPayment.IsWalletAdjusted = Convert.ToString(objTotalAppl.PermitPaymentLst[i].IsWalletAdjusted);
                                objPayment.PayDeptId = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].PayDeptId);
                                if (Convert.ToBoolean(objTotalAppl.PermitPaymentLst[i].IsApplicable) == true)
                                {
                                    //totalCheck += Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].TotalAmount"]);
                                    //adjustCheck += Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].AdjustmentAmount"]);
                                    if ((Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].TotalAmount) > Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].AdjustmentAmount)) && IspayOnline == "NO")
                                    {
                                        IspayOnline = "YES";
                                    }
                                }
                                objPaymentList.Add(objPayment);
                            }
                            //    }
                            //}
                            if ((!(app.IsWalletAdjusted == null) && Convert.ToString(app.IsWalletAdjusted) == "0") || IspayOnline == "YES")
                            {
                                //TempData["Adjustment"] = "NO";
                                ViewBag.Adjustment = "NO";
                                IspayOnline = "NO";
                            }
                            else
                            {
                                //TempData["Adjustment"] = "YES";
                                ViewBag.Adjustment = "YES";
                            }
                            //Added by sanjay for whowing wallet in payment
                            //if(objTotalAppl.WalletLst.Count>0)
                            //{
                            //    ViewBag.Wallet = objTotalAppl.WalletLst.ToList();
                            //}
                            model.PaymentDetails = objPaymentList;

                            return View(model);
                        }
                    }
                    // }
                    // }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(new ePermitModel { });
            }

        }

        [HttpPost]
        public IActionResult ePermitPaymentTest(ePermitModel model)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.SubUserID = Convert.ToInt32(profile.SubUserID);
            //model.UserID = 83;

            if (model.CheckListDescription != null)
            {
                string[] str = model.CheckListDescription.Split('/');
                List<ePaymentData> ltCheckOut = new List<ePaymentData>();
                for (int i = 0; i < str.Length; i++)
                {
                    string data = str[i];
                    if (data.Length > 1)
                    {
                        string[] Payment = data.Split(',');
                        ePaymentData head = new ePaymentData()
                        {
                            BulkPaymentId = Convert.ToInt32(Payment[0].ToString()),
                            WalletAmount = Convert.ToDecimal(Payment[1].ToString()),
                            AdjustmentAmount = Convert.ToDecimal(Payment[2].ToString()),
                            Amount = Convert.ToInt32(Payment[3].ToString()),
                        };
                        ltCheckOut.Add(head);
                    }
                }
                model.PaymentDetails = ltCheckOut;
            }
            try
            {
                objMSmodel = _userPemit.CheckOutPayment(model);
                OutputResult = objMSmodel.Satus;
                if (model.BulkPermitId != 0)
                {
                    //return RedirectToAction("ePermitPayment", "Lessee", new { id = model.BulkPermitId });
                    var dataString = CustomQueryStringHelper.
                    EncryptString("Permit", "ePermitPaymentCheckOut", "Lessee", new { id = model.BulkPermitId });
                    return new RedirectResult(dataString);
                    //return RedirectToAction("ePermitPaymentCheckOut", "Lessee", new { id = model.BulkPermitId });
                }
                else
                {
                    //return RedirectToAction("ePermitPayment", "Lessee", new { id = OutputResult });
                    var dataString = CustomQueryStringHelper.
                    EncryptString("Permit", "ePermitPaymentCheckOut", "Lessee", new { id = OutputResult });
                    return new RedirectResult(dataString);
                    //return RedirectToAction("ePermitPaymentCheckOut", "Lessee", new { id = OutputResult });
                }




            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public IActionResult ePermitList(string request)
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            //objmodel.UserID = 83;
            objmodel.FromDATE = null;
            objmodel.ToDATE = null;

            try
            {

                modelList = _userPemit.GetBulkPermitDetails(objmodel);
                if (modelList != null && modelList.Count > 0)
                {
                    int count = 1;
                    for (var i = 0; i < modelList.Count; i++)
                    {
                        ePermitModel model = new ePermitModel();

                        model.SRNumber = count;


                        model.TransactionalID = Convert.ToString(modelList[i].TransactionalID);
                        model.PaymentReceiptID = Convert.ToString(modelList[i].PaymentReceiptID);
                        model.ApprovedQty = Convert.ToDecimal(modelList[i].ApprovedQty);
                        model.ActiveStatus = Convert.ToInt32(modelList[i].ActiveStatus);
                        // model.ApprovedDateText = Convert.ToString(modelList[i].ApprovedDate);
                        model.BulkPermitId = Convert.ToInt32(modelList[i].BulkPermitId);
                        model.BulkPermitNo = Convert.ToString(modelList[i].BulkPermitNo);
                        model.Cess = Convert.ToDecimal(modelList[i].Cess);
                        // model.eCess = Convert.ToDecimal(modelList[i].eCess);
                        model.DMF = Convert.ToDecimal(modelList[i].DMF);
                        model.IsApproved = Convert.ToInt32(modelList[i].IsApproved);
                        model.LeaseInfoId = Convert.ToInt32(modelList[i].LeaseInfoId);
                        model.LesseeId = Convert.ToInt32(modelList[i].LesseeId);
                        model.MineralGradeId = Convert.ToInt32(modelList[i].MineralGradeId);
                        model.MineralGradeName = Convert.ToString(modelList[i].MineralGrade);
                        model.MineralId = Convert.ToInt32(modelList[i].MineralId);
                        model.MineralTypeId = Convert.ToInt32(modelList[i].MineralTypeId);

                        model.MineralName = Convert.ToString(modelList[i].MineralName);

                        model.MineralNatureId = Convert.ToInt32(modelList[i].MineralNatureID);
                        model.MineralNature = Convert.ToString(modelList[i].MineralNature);

                        model.NMET = Convert.ToDecimal(modelList[i].NMET);
                        model.PayableRoyalty = Convert.ToDecimal(modelList[i].PayableRoyalty);
                        model.PaymentStatus = Convert.ToInt32(modelList[i].PaymentStatus);
                        model.ProposedQty = Convert.ToDecimal(modelList[i].ProposedQty);
                        model.Remark = Convert.ToString(modelList[i].Remark);
                        model.TCS = Convert.ToDecimal(modelList[i].TCS);
                        model.TotalPayableAmount = Convert.ToDecimal(modelList[i].TotalPayableAmount);
                        model.LesseeName = Convert.ToString(modelList[i].LesseeName);
                        model.LesseeAddress = Convert.ToString(modelList[i].LesseeAddress);
                        model.GrantOrderNo = Convert.ToString(modelList[i].GrantOrderNo);
                        model.DateOfGrant = Convert.ToString(modelList[i].DateOfGrant);
                        model.UnitName = Convert.ToString(modelList[i].UnitName);
                        model.UnitId = Convert.ToInt32(modelList[i].UnitId);
                        model.PeriodOfLeaseFrom = Convert.ToString(modelList[i].PeriodOfLeaseFrom);
                        model.PeriodOfLeaseTo = Convert.ToString(modelList[i].PeriodOfLeaseTo);
                        model.LeaseTypeId = Convert.ToInt32(modelList[i].LeaseTypeID);
                        model.LeaseTypeName = Convert.ToString(modelList[i].LeaseTypeName);
                        model.EmailId = Convert.ToString(modelList[i].EmailId);
                        model.MobileNo = Convert.ToString(modelList[i].MobileNo);
                        model.StatusText = Convert.ToString(modelList[i].StatusText);
                        model.PendingQty = Convert.ToDecimal(modelList[i].PendingQty);
                        model.AdjustedQty = Convert.ToDecimal(modelList[i].AdjustedQty);
                        model.AluminaContent = Convert.ToDecimal(modelList[i].ExtraContent);
                        model.CheckoutStatus = Convert.ToInt32(modelList[i].CheckoutStatus);
                        if (!string.IsNullOrEmpty(modelList[i].ISCessAdjusted.ToString()))
                        {
                            model.ISCessAdjusted = Convert.ToInt32(modelList[i].ISCessAdjusted);
                        }
                        model.NoOfRunningPass = Convert.ToInt32(modelList[i].NoOfRunningPass);
                        model.MergeEPermitCount = Convert.ToString(modelList[i].MergePermitCount);
                        model.EVSOrder= Convert.ToString(modelList[i].EVSOrder);
                        count++;
                        //if (modelList.Contains.("NoOfRunningPass"))
                        //        {
                        //            model.NoOfRunningPass = Convert.ToInt32(modelList[i].NoOfRunningPass);
                        //        }

                        List.Add(model);
                    }
                }
                //    }
                //}
            }
            catch (Exception)
            {
                return null;
            }
            // return Json(modelList.ToDataSourceResult(request));
            ViewBag.ViewList = List;
            return View();
            //  return Json(modelList);
        }

        public ActionResult MakeEndUserPayment(ePermitModel model, string MiningPayment, string Bulkid, string Order, string Total)
        {

            decimal totalAmt = 0;
            string orderNo = string.Empty;
            if (MiningPayment == "1")
            {
                totalAmt = Convert.ToDecimal(Total);
                orderNo = Order;
            }
            if (MiningPayment == "2")
            {
                totalAmt = Convert.ToDecimal(Total);
                orderNo = Order;
            }
            if (MiningPayment == "3")
            {
                totalAmt = Convert.ToDecimal(Total);
                orderNo = Order;
            }
            if (MiningPayment == "0" || MiningPayment == null || MiningPayment == "")
            {
                Bulkid = model.BulkPermitId.ToString();
                totalAmt = Convert.ToDecimal(model.TotalPayableAmount);
            }
            var dataString = CustomQueryStringHelper.
                EncryptString("Payment", "SBIPayment", "SBIPayment", new { Id = Bulkid, Prefix = "BP", total = totalAmt, OrderNo = orderNo, PaymentHead = MiningPayment });
            //var dataString = CustomQueryStringHelper.
            //    EncryptString("Payment", "SBIPayment", "SBIPayment", new { Id = model.BulkPermitId, Prefix = "BP", total=model.TotalPayableAmount });
            SBIAPIPath = configuration.GetSection("Path").GetSection("APIUrl").Value + dataString;
            return new RedirectResult(SBIAPIPath);

        }
        [SkipImportantTask]
        public IActionResult ePermitViewWithoutDSC(string id)
        {
            ePermitModel model = new ePermitModel();

            ePermitResult objTotalAppl = new ePermitResult();
            ePermitResult objDetailsAppl = new ePermitResult();
            ePermitResult objOperationAppl = new ePermitResult();
            ePermitResult objOperationBulkAppl = new ePermitResult();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 95;
            model.UserLoginId = Convert.ToString(profile.UserLoginId);
            model.UserType = profile.UserType;
            model.BulkPermitId = Convert.ToInt32(id);

            try
            {
                objDetailsAppl = _userPemit.GetPermitViewWithoutDSC(model);
                foreach (var app in objDetailsAppl.PermitOperationBulkIDLst)
                {
                    model.TransactionalID = Convert.ToString(app.TransactionalID);
                    model.MobileNo = Convert.ToString(app.MobileNo);
                    model.EmailId = Convert.ToString(app.EMailId);
                    model.LesseeName = Convert.ToString(app.ApplicantName);
                    model.LesseeAddress = Convert.ToString(app.Address);
                    model.DistrictId = Convert.ToInt32(app.DistrictId);
                    model.District = Convert.ToString(app.DistrictName);
                    model.TehsilId = Convert.ToInt32(app.TehsilID);
                    model.Tehsil = Convert.ToString(app.TehsilName);
                    model.VillageId = Convert.ToInt32(app.VILLAGE_ID);
                    model.Village = Convert.ToString(app.VillageName);

                    model.GrantOrderNo = Convert.ToString(app.GrantOrderNumber);
                    model.DateOfGrant = Convert.ToString(app.GrantOrderDate);
                    model.MineralId = Convert.ToInt32(app.MINERAL_ID);
                    model.MineralName = Convert.ToString(app.MineralName);
                    model.MineralGradeId = Convert.ToInt32(app.MINERAL_GRADE_ID);
                    model.MineralGradeName = Convert.ToString(app.MineralGrade);

                    model.MineralNature = Convert.ToString(app.MineralNature);

                    model.UnitId = Convert.ToInt32(app.UnitId);
                    model.UnitName = Convert.ToString(app.UnitName);
                    model.RoyaltyRate = String.IsNullOrEmpty(app.RoyaltyRate.ToString()) == false ? Convert.ToDecimal(app.RoyaltyRate) : 0;
                    model.PeriodOfLeaseFrom = Convert.ToString(app.PROSPECTING_VALIDITY_FROM);
                    model.PeriodOfLeaseTo = Convert.ToString(app.PROSPECTING_VALIDITY_TO);
                    model.PeriodOfLease = Convert.ToString(app.PeriodOfLease);
                    model.LeaseTypeId = Convert.ToInt32(app.LeaseTypeId);
                    model.LeaseTypeName = Convert.ToString(app.LeaseTypeName);
                    model.ActiveStatus = Convert.ToInt32(app.ActiveStatus);

                    model.BulkPermitId = Convert.ToInt32(app.BulkPermitId);
                    model.BulkPermitNo = Convert.ToString(app.BulkPermitNo);
                    model.TCS = Convert.ToDecimal(app.TCS);
                    model.Cess = Convert.ToDecimal(app.Cess);
                    model.eCess = Convert.ToDecimal(app.eCess);
                    model.DMF = Convert.ToDecimal(app.DMF);
                    model.NMET = Convert.ToDecimal(app.NMET);
                    model.PayableRoyalty = Convert.ToDecimal(app.PayableRoyalty);
                    model.TotalPayableAmount = Convert.ToDecimal(app.TotalPayableAmount);
                    model.ProposedQty = Convert.ToDecimal(app.ProposedQty);

                    model.PoliceStation = Convert.ToString(app.POLICE_STATION);
                    model.Panchayat = Convert.ToString(app.GRAM_PANCHAYAT);
                    model.ProductionYear = Convert.ToString(app.ProductionYear);
                    model.Production = Convert.ToString(app.Production);
                    model.RemainingProduction = Convert.ToString(app.RemainingProduction);
                    model.MineralNatureId = Convert.ToInt32(app.MineralNatureId);

                    model.GeneratedBy = Convert.ToString(app.GeneratedBy);
                    model.TypeOfCoalDispatched = Convert.ToString(app.TypeOfCoalDispatched);
                    model.GeneratedDesignation = Convert.ToString(app.GeneratedDesignation);

                    model.DSCLesseeFilePath = Convert.ToString(app.DSCLesseeFilePath);
                    model.DSCDDFilePath = Convert.ToString(app.DSCDDFilePath);

                    TempData["LeaseTypeId"] = model.LeaseTypeId;

                    List<ePaymentData> objPaymentList = new List<ePaymentData>();
                    foreach (var app1 in objDetailsAppl.PermitPaymentLst)
                    {
                        ePaymentData objPayment = new ePaymentData();
                        objPayment.PaymentType = Convert.ToString(app1.PaymentType);
                        objPayment.CalType = Convert.ToString(app1.CalType);
                        objPayment.CalValue = Convert.ToString(app1.CalValue);

                        objPayment.MappingValue = Convert.ToString(app1.MappingValue);
                        objPayment.IsApplicable = Convert.ToBoolean(app1.IsApplicable);

                        objPayment.RoyaltyRate = Convert.ToString(app1.RoyaltyRate);
                        objPayment.BasisRate = Convert.ToString(app1.BasicPrice);
                        objPayment.TotalPayableAmount = Convert.ToString(app1.TotalPayableAmount);
                        objPayment.HeadAccount = Convert.ToString(app1.HeadAccount);
                        objPaymentList.Add(objPayment);
                        if (Convert.ToString(app1.PaymentType) == "Royalty")
                        {
                            model.CalValue = Convert.ToString(app1.CalValue);
                        }
                    }


                    model.PaymentDetails = objPaymentList;
                }

            }
            catch
            { }
            return View(model);
        }
        [SkipImportantTask]
        [HttpGet]
        public IActionResult ePermitPaymentCheckOut(string id)
        {
            try
            {
                ePermitModel model = new ePermitModel();

                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserID = Convert.ToInt32(profile.UserId);
                string UserType = profile.UserType;
                //model.UserID = 83;
                //string UserType = "Lessee";
                model.UserCode = "Lessee";
                model.BulkPermitId = Convert.ToInt32(id);
                decimal TotalMiningAmt = 0;
                decimal TotalEvsAmt = 0;
                decimal TotalIncomeAmt = 0;

                ePermitResult objTotalAppl = new ePermitResult();
                if (TempData["result"] != null)
                {
                    ViewBag.DisplayMsg = Convert.ToString(TempData["result"]);
                    ViewBag.ResultMsg = Convert.ToString(TempData["ResultMsg"]);
                }

                if (id == null || Convert.ToInt32(id) == 0)
                {
                    return View(new ePermitModel { });
                }
                else
                {

                    objTotalAppl = _userPemit.GetCheckOutPermitPayment(model);
                    //using (DataSet ds = objDb.getDataBy_SqlCommand_CB(cmd))
                    //    {
                    if (objTotalAppl != null && objTotalAppl.PermitOperationLst.Count > 0)
                    {
                        //  DataTable dt = ds.Tables[0];
                        //if (dt != null && modelList.Count > 0)
                        //{
                        foreach (var app in objTotalAppl.PermitOperationLst)
                        {
                            if (app.ActiveStatus == 6 || app.ActiveStatus == 7 || app.ActiveStatus == 11)
                            {
                                ViewBag.payst = "Success";
                            }
                            model.TransactionalID = Convert.ToString(app.TransactionalID);
                            model.MobileNo = Convert.ToString(app.MobileNo);
                            model.EmailId = Convert.ToString(app.EMailId);
                            model.LesseeName = Convert.ToString(app.ApplicantName);
                            model.LesseeAddress = Convert.ToString(app.Address);
                            model.DistrictId = Convert.ToInt32(app.DistrictId);
                            model.District = Convert.ToString(app.DistrictName);
                            model.DistrictCode = Convert.ToString(app.DistrictCode);
                            model.TehsilId = Convert.ToInt32(app.TehsilID);
                            model.Tehsil = Convert.ToString(app.TehsilName);
                            model.VillageId = Convert.ToInt32(app.VILLAGE_ID);
                            //if (dt.Columns.Contains("VILLAGE_ID"))
                            //{
                            //    model.Village = Convert.ToString(app.VILLAGE_ID"]);
                            //}
                            //else
                            //{
                            //    model.Village = "Not Mentioned";
                            //}
                            model.Village = Convert.ToString(app.VillageName);
                            if (!string.IsNullOrEmpty(model.Village))
                            {
                                model.Village = Convert.ToString(app.VillageName);
                            }
                            else
                            {
                                model.Village = "Not Mentioned";
                            }
                            //model.Village = Convert.ToString(app.VillageName"]);

                            if (UserType.ToUpper() != "TAILING DAM")
                            {

                                model.LeaseTypeId = Convert.ToInt32(app.LeaseTypeId);
                                model.ActiveStatus = Convert.ToInt32(app.ActiveStatus);
                                model.EAuctionType = Convert.ToString(app.EAuctionType.ToString());
                                model.TillDateBalanceUpfrontPayment = !string.IsNullOrEmpty(app.TillDateBalanceUpfrontPayment.ToString()) ? Convert.ToDecimal(app.TillDateBalanceUpfrontPayment) : 0;
                                model.MineralGradeName = Convert.ToString(app.MineralGrade);
                                TempData["LeaseTypeId"] = model.LeaseTypeId;
                            }
                            else
                            {
                                model.MineralGradeName = Convert.ToString(app.MineralGrade + " ( " + Convert.ToString(app.ActualGrade) + " )");
                            }

                            model.GrantOrderNo = Convert.ToString(app.GrantOrderNumber);
                            model.DateOfGrant = Convert.ToString(app.GrantOrderDate);
                            model.PeriodOfLeaseFrom = Convert.ToString(app.PROSPECTING_VALIDITY_FROM);
                            model.PeriodOfLeaseTo = Convert.ToString(app.PROSPECTING_VALIDITY_TO);
                            model.PeriodOfLease = Convert.ToString(app.PeriodOfLease);
                            model.LeaseTypeName = Convert.ToString(app.LeaseTypeName);
                            model.PoliceStation = Convert.ToString(app.POLICE_STATION);
                            model.Panchayat = Convert.ToString(app.GRAM_PANCHAYAT);

                            if (!(app.MINERAL_ID == null))
                            {
                                model.MineralId = Convert.ToInt32(app.MINERAL_ID);
                            }
                            model.PaymentStatus = Convert.ToInt32(app.PaymentStatus);
                            model.MineralName = Convert.ToString(app.MineralName);
                            model.MineralGradeId = Convert.ToInt32(app.MINERAL_GRADE_ID);

                            model.MineralNatureId = Convert.ToInt32(app.MineralNatureId);
                            model.MineralNature = Convert.ToString(app.MineralNature);

                            model.UnitId = Convert.ToInt32(app.UnitId);
                            model.UnitName = Convert.ToString(app.UnitName);
                            model.RoyaltyRate = Convert.ToDecimal(app.RoyaltyRate);

                            model.BulkPermitId = Convert.ToInt32(app.BulkPermitId);
                            model.TCS = Convert.ToDecimal(app.TCS);
                            model.Cess = Convert.ToDecimal(app.Cess);
                            model.eCess = Convert.ToDecimal(app.eCess);
                            model.DMF = Convert.ToDecimal(app.DMF);
                            model.NMET = Convert.ToDecimal(app.NMET);
                            model.PayableRoyalty = Convert.ToDecimal(app.PayableRoyalty);

                            model.TotalMiningPayableAmount = Convert.ToDecimal(app.TotalMiningPayableAmount);
                            model.ProposedQty = Convert.ToDecimal(app.ProposedQty);
                            model.ApprovedQty = Convert.ToDecimal(app.ApprovedQty);

                            model.GeneratedBy = Convert.ToString(app.GeneratedBy);
                            model.GeneratedDesignation = Convert.ToString(app.GeneratedDesignation);

                            model.ChallanNumber = Convert.ToString(app.ChallanNumber);
                            model.ChallanDate = Convert.ToString(app.ChallanDate);
                            model.ChallanFileName = Convert.ToString(app.ChallanCopyPath);

                            if (!string.IsNullOrEmpty(model.ChallanFileName))
                            {
                                model.ChallanCopyFilePath = model.ChallanFileName.Replace("PaymentDocuments", string.Empty).Replace(model.TransactionalID, "").Replace("\\_", "");
                            }

                            string IspayOnline = "NO";
                            List<ePaymentData> objPaymentList = new List<ePaymentData>();

                            for (int i = 0; i < objTotalAppl.PermitPaymentLst.Count; i++)
                            {
                                ePaymentData objPayment = new ePaymentData();
                                objPayment.PaymentType = Convert.ToString(objTotalAppl.PermitPaymentLst[i].PaymentType);
                                objPayment.IsApplicable = Convert.ToBoolean(objTotalAppl.PermitPaymentLst[i].IsApplicable);
                                objPayment.ApplicableId = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].ApplicableId);
                                if (objPayment.PaymentType == "Royalty" || objPayment.PaymentType == "Paid Royalty" || objPayment.PaymentType == "Monthly Periodic Amount" && objPayment.IsApplicable == true)
                                {
                                    objPayment.MakePayementId = 1;
                                    objPayment.ApplicableId = 1;
                                }
                                else
                                {
                                    objPayment.MakePayementId = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].MakePayementId);
                                }
                                if (Convert.ToString(objTotalAppl.PermitPaymentLst[i].PaymentType) == "Infrastructure & Development Cess")
                                {
                                    model.Cess = Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].MappingValue);
                                }
                                objPayment.CalType = Convert.ToString(objTotalAppl.PermitPaymentLst[i].CalType);
                                objPayment.CalValue = Convert.ToString(objTotalAppl.PermitPaymentLst[i].CalValue);

                                objPayment.MappingValue = Convert.ToString(objTotalAppl.PermitPaymentLst[i].MappingValue);

                                objPayment.RoyaltyRate = Convert.ToString(objTotalAppl.PermitPaymentLst[i].RoyaltyRate);
                                objPayment.BasisRate = Convert.ToString(objTotalAppl.PermitPaymentLst[i].BasicPrice);
                                objPayment.TotalPayableAmount = Convert.ToString(objTotalAppl.PermitPaymentLst[i].TotalPayableAmount);
                                objPayment.HeadAccount = Convert.ToString(objTotalAppl.PermitPaymentLst[i].HeadAccount);
                                objPayment.AdjustmentAmount = Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].AdjustmentAmount);
                                objPayment.WalletAdjustedAmount = Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].WalletAdjustedAmount);
                                objPayment.TotalAmount = Convert.ToString(objTotalAppl.PermitPaymentLst[i].TotalAmount);
                                objPayment.IsWalletAdjusted = Convert.ToString(objTotalAppl.PermitPaymentLst[i].IsWalletAdjusted);
                                objPayment.PayDeptId = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].PayDeptId);
                                objPayment.OrderNStatus = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].OrderNStatus);
                                if (objPayment.PayDeptId == 1 && objPayment.ApplicableId == 1)
                                {
                                    ViewBag.CheckMiningRecord = "ok";
                                }
                                else if (objPayment.PayDeptId == 2 && objPayment.ApplicableId == 1)
                                {
                                    ViewBag.CheckIncomeRecord = "ok";
                                }
                                else if (objPayment.PayDeptId == 3 && objPayment.ApplicableId == 1)
                                {
                                    ViewBag.CheckEVSRecord = "ok";
                                }
                                if (Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].PayDeptId) == 1)
                                {
                                    TotalMiningAmt = TotalMiningAmt + Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].MappingValue);
                                    model.MiningOrder = objTotalAppl.PermitPaymentLst[i].OrderNo;
                                }
                                else if (Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].PayDeptId) == 2)
                                {
                                    TotalIncomeAmt = TotalIncomeAmt + Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].MappingValue);
                                    model.IncomeTaxOrder = objTotalAppl.PermitPaymentLst[i].OrderNo;
                                }
                                else if (Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].PayDeptId) == 3)
                                {
                                    TotalEvsAmt = TotalEvsAmt + Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].MappingValue);
                                    model.EVSOrder = objTotalAppl.PermitPaymentLst[i].OrderNo;
                                }
                                if (Convert.ToBoolean(objTotalAppl.PermitPaymentLst[i].IsApplicable) == true)
                                {
                                    //totalCheck += Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].TotalAmount"]);
                                    //adjustCheck += Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].AdjustmentAmount"]);
                                    if ((Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].TotalAmount) > Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].AdjustmentAmount)) && IspayOnline == "NO")
                                    {
                                        IspayOnline = "YES";
                                    }
                                }
                                objPaymentList.Add(objPayment);
                            }
                            //    }
                            //}
                            if ((!(app.IsWalletAdjusted == null) && Convert.ToString(app.IsWalletAdjusted) == "0") || IspayOnline == "YES")
                            {
                                //TempData["Adjustment"] = "NO";
                                ViewBag.Adjustment = "NO";
                                IspayOnline = "NO";
                            }
                            else
                            {
                                //TempData["Adjustment"] = "YES";
                                ViewBag.Adjustment = "YES";
                            }


                            model.PaymentDetails = objPaymentList;
                            model.TotalMiningPayableAmount = Convert.ToDecimal(TotalMiningAmt);
                            model.TotalEVSPayableAmount = Convert.ToDecimal(TotalEvsAmt);
                            model.TotalIncomTaxPayableAmount = Convert.ToDecimal(TotalIncomeAmt);
                            return View(model);
                        }
                    }
                    // }
                    // }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(new ePermitModel { });
            }

        }
    }
}