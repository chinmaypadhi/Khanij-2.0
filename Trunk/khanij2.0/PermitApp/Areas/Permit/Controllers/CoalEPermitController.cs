using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermitApp.Areas.Permit.Models.CoalEPermit;
using PermitApp.Areas.Permit.Models.Lessee;
using PermitEF;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using PermitApp.Helper;
using PermitApp.Web;
using PermitApp.ActionFilter;
using PermitApp.Areas.Permit.Models.GradeUpdate;

namespace PermitApp.Areas.Permit.Controllers
{
    [Area("Permit")]
    public class CoalEPermitController : Controller
    {
        string SBIAPIPath = "";
        ICoalEPermitModel _userPemit;
        ILesseePermitModel _userPemitLessee;
        IUpgradeGrade _userUpgrade;
        MessageEF objMSmodel = new MessageEF();
        public object JsonRequestBehavior { get; private set; }
        IHostingEnvironment _hostingEnvironment;
        string OutputResult = "";
        string UserType = "Lessee";//it will comes from session variable
        private IConfiguration Configuration;



        public CoalEPermitController(ICoalEPermitModel objPermit, IHostingEnvironment hostingEnvironment, IConfiguration _configuration,ILesseePermitModel objLesseePermit, IUpgradeGrade userUpgrade)
        {
            _userPemit = objPermit;
            _userPemitLessee = objLesseePermit;
            _hostingEnvironment = hostingEnvironment;
            Configuration = _configuration;
            _userUpgrade = userUpgrade;
        }
        [SkipImportantTask]
        public IActionResult CoalEPermit(string BulkPermitId)
        {
            ePermitModel objmodel = new ePermitModel();
            ePermitModel objmodelGrade = new ePermitModel();
            ePermitResult objTotalAppl = new ePermitResult();
            ePermitResult objDetailsAppl = new ePermitResult();
            ePermitResult objOperationAppl = new ePermitResult();
            ePermitResult MINEDET = new ePermitResult();
            ePermitResult objOperationBulkAppl = new ePermitResult();
            ePermitModel objmodelless = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            MINEDET = _userPemit.GetMinesDetails(objmodel);
            if(MINEDET != null && MINEDET.CheckList.Count > 0)
            {
                foreach (var a in MINEDET.CheckList)
                {
                    ViewBag.Auct = a.eAuctionTypeId;
                    ViewBag.Leaseext = a.LeaseExtendText;
                    ViewBag.capt = a.CaptiveText;
                    ViewBag.Mlgrd = a.MLGrantedDateText;

                }
            }
            objmodelless = _userPemit.GetComapny(objmodel);
            if(objmodelless.COMPANY=="1")
            {
                ViewBag.read = "readonly";
            }
            else
            {
                ViewBag.read = null;
            }
            //objmodel.UserID = 64;
            string UserType = "Lessee";
            int count = 0;
            decimal walletcount = 0;

            if (BulkPermitId != "" && BulkPermitId != null && BulkPermitId != "0")
            {
                objmodel.BulkPermitId = Convert.ToInt32(BulkPermitId);
                objmodel.UserCode = "Lessee";
                objTotalAppl = _userPemit.GetCheckOutPermitPayment(objmodel);

                if (objTotalAppl != null && objTotalAppl.PermitOperationLst.Count > 0)
                {
                    for (int i = 0; i < objTotalAppl.PermitPaymentLst.Count; i++)
                    {
                        count = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].OrderNStatus);
                        walletcount = Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].WalletAdjustedAmount);
                        if (count == 1 || walletcount != 0)
                        {
                            var dataString = CustomQueryStringHelper.
                               EncryptString("Permit", "ePermitPaymentCheckOut", "Lessee", new { id = BulkPermitId });
                            return new RedirectResult(dataString);
                        }
                        objmodel.BulkPermitId = 0;
                        objmodel.UserCode = null;
                    }
                }
            }
            objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
            var x = _userPemit.GetTypeOfCoal(objmodel);
            if (x.TypeOfCoalLst != null)
            {
                ViewBag.ViewCoalTypeList = x.TypeOfCoalLst.Select(c => new SelectListItem
                {
                    Text = c.ProductionFrom,
                    Value = c.Production_Id.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewCoalTypeList = Enumerable.Empty<SelectListItem>();
            }

            var y = _userPemit.GetCoalMineralNatureList(objmodel);
            if (y.MineralNatureLst != null)
            {
                ViewBag.ViewMineralNatureList = y.MineralNatureLst.Select(c => new SelectListItem
                {
                    Text = c.MineralNature,
                    Value = c.MineralNatureId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewMineralNatureList = Enumerable.Empty<SelectListItem>();
            }
            ViewBag.MineralGradeList = Enumerable.Empty<SelectListItem>();

            var Do = _userPemitLessee.GetSECLDODetails(objmodel);
            if (Do.GetSECLDODetails != null)
            {
                ViewBag.ViewDONumber = Do.GetSECLDODetails.Select(c => new SelectListItem
                {
                    Text = c.DONumber,
                    Value = c.DONumber.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewDONumber = Enumerable.Empty<SelectListItem>();
            }

            objTotalAppl = _userPemit.CheckTotalPermitByUser(objmodel);
            // DataTable dataTable1 = objDb.ExecuteStoreProcedure(sqcmd);

            if (objTotalAppl != null)
            {

                if (objTotalAppl.TotalPermitLstByUserID.Count > 0)
                {
                    //SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand();
                    //cmd1.CommandText = "getDetailsByUserID";
                    //cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd1.Parameters.AddWithValue("@UserID", SessionWrapper.UserId);

                    //DataTable dt1 = objDb.ExecuteStoreProcedure(cmd1);
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
                            if(Convert.ToDecimal(model.ChangeBiggerMining) < Convert.ToDecimal(model.ChangeBiggerEC))
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
                            if (Convert.ToInt32(BulkPermitId) == 0)
                            {
                                objOperationAppl = _userPemit.GetPermitOperation(objmodel);

                                //using (SqlCommand cmd = new SqlCommand())
                                //{
                                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                //    cmd.CommandText = "uspEPermitOperation";

                                //    cmd.Parameters.AddWithValue("@UserID", SessionWrapper.UserId);

                                //using (DataTable dt = objDb.ExecuteStoreProcedure(cmd))
                                //{
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

                                            model.MineralTypeId = !string.IsNullOrEmpty(app1.MineralTypeId.ToString()) ? Convert.ToInt32(app1.MineralTypeId) : 0;
                                            model.MineralSizeName = Convert.ToString(app1.MineralSize.ToString());
                                            model.EAuctionType = "";
                                            model.TypeOfCoalDispatched = "";
                                            model.GeneratedBy = Convert.ToString(app1.GeneratedBy);
                                            model.GeneratedDesignation = Convert.ToString(app1.GeneratedDesignation);
                                            model.GeneratedDSC = "";

                                            model.ISAdjustmentCess = (app1.ISAdjustmentCess is null) ? 0 : Convert.ToInt32(app1.ISAdjustmentCess);
                                            model.OrderDate = Convert.ToString(app1.OrderDate);
                                            model.OrderNo = Convert.ToString(app1.OrderNo);
                                            model.OrderOf = Convert.ToString(app1.OrderOf);
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
                                objmodel.BulkPermitId =Convert.ToInt32(BulkPermitId);
                                objOperationBulkAppl = _userPemit.GetPermitOperationByBulkId(objmodel);
                               
                                if (objOperationBulkAppl != null)
                                {
                                    foreach (var app1 in objOperationBulkAppl.PermitOperationBulkIDLst)
                                    {
                                        
                                        model.TransactionalID = Convert.ToString(app1.TransactionalID);
                                        model.MobileNo = Convert.ToString(app1.MobileNo);
                                        model.EmailId = Convert.ToString(app1.EMailId);
                                        model.LesseeName = Convert.ToString(app1.ApplicantName);
                                        model.LesseeAddress = Convert.ToString(app1.Address);
                                        if(model.DONumber!=null || model.DONumber!="")
                                        {
                                            model.DONumber= Convert.ToString(app1.DONumber);
                                            model.DODate = Convert.ToString(app1.DODate);
                                        }
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

                                        //ePermitModel objPermit = null;
                                        //objPermit = new ePermitModel();
                                        //objPermit.UserID = 150;
                                        //objPermit.MineralId = model.MineralNatureId;

                                        
                                         var   z = _userPemit.GetMineralGradeListOnNatureList(objmodel);
                                        if (z.MineralGradeLst != null)
                                        {
                                            ViewBag.MineralGradeList = z.MineralGradeLst.Select(c => new SelectListItem
                                            {
                                                Text = c.MineralGrade,
                                                Value = c.MineralGradeId.ToString(),
                                            }).ToList();
                                        }
                                        else
                                        {
                                            ViewBag.MineralGradeList = Enumerable.Empty<SelectListItem>();
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

                                        model.GeneratedDSC = "";

                                        model.ISAdjustmentCess = (app1.ISAdjustmentCess is null) ? 0 : Convert.ToInt32(app1.ISAdjustmentCess);
                                        model.OrderDate = Convert.ToString(app1.OrderDate);
                                        model.OrderNo = Convert.ToString(app1.OrderNo);
                                        model.OrderOf = Convert.ToString(app1.OrderOf);
                                        model.BasicRate = String.IsNullOrEmpty(app1.BasicRate.ToString()) == false ? Convert.ToDecimal(app1.BasicRate) : 0;
                                        model.TypeOfCoalDispatched = Convert.ToString(app1.eAuctionTypeId.ToString());
                                        TempData["LeaseTypeId"] = model.LeaseTypeId;


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
            //return View();
        }
        public JsonResult GetMineralGrade(int NatureID)
        {
            ePermitModel objPermit = null;
            try
            {
                objPermit = new ePermitModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objPermit.UserID = Convert.ToInt32(profile.UserId);
                //objPermit.UserID = 64;
                objPermit.MineralNatureId = NatureID;
                var x = _userPemit.GetMineralGradeListOnNatureList(objPermit);
                var SList = x.MineralGradeLst.ToList();
                //var UserList = SList.Where(item => item.Value != "68").ToList();
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

        public JsonResult GetDODate(string DoNumber)
        {
            ePermitModel objPermit = null;
            try
            {
                objPermit = new ePermitModel();
                objPermit.DONumber = DoNumber;
                objPermit = _userPemitLessee.GetTaggedDetails(objPermit);
                //var UserList = SList.Where(item => item.Value != "68").ToList();
                return Json(objPermit);
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

        [HttpPost]
        public IActionResult CoalEPermit(ePermitModel model, string cmdPreview)
        {
            //var previewRequest = Convert.ToString(Request["cmdPreview"]);
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 64;
            model.IsCoal = 1;
            ePermitResult objTotalAppl = new ePermitResult();
            if (cmdPreview != null)
            {
                try
                {
                    objTotalAppl = _userPemit.GetCoalMineralNatureList(model);
                    foreach (var app in objTotalAppl.MineralNatureLst)
                    {
                        model.MineralName = Convert.ToString(app.MineralName);
                        model.MineralNature = Convert.ToString(app.MineralNature);
                        model.MineralGradeName = Convert.ToString(app.MineralGrade);
                    }


                }
                catch { }
                //return View("EPermitPreivewWihtoutDSC", model);

                return RedirectToAction("ePermitViewWithoutDSC", "CoalEPermit", new { id = model.BulkPermitId });
            }
            else
            {
                if (model.ProposedQty > Convert.ToDecimal(model.RemainingProduction))
                {
                    TempData["SuccMessage"] = "Your Request Regarding Coal Permit has not been saved due fewer Production Cap.";
                    TempData.Keep();
                    return View("CoalEPermit", model);
                }
                else
                {
                    if (model.MineralId == 0 || model.MineralNatureId == 0 || model.MineralNatureId == 0)
                    {
                        TempData["SuccMessage"] = "Enter All require fields for e-Permit.";
                        TempData.Keep();
                        return View("CoalEPermit", model);
                    }
                    else
                    {
                        objMSmodel = _userPemit.AddBulkPermit(model);
                        OutputResult = objMSmodel.Satus;
                        if (!string.IsNullOrEmpty(OutputResult))

                        {
                            if (model.isForwarded == null || model.isForwarded == 0)
                            {
                                TempData["SuccMessage"] = "Your Request Regarding Coal Permit has been saved successfully.";
                                TempData.Keep();
                                return RedirectToAction("CoalEPermit", "CoalEPermit");
                            }
                            else
                            {
                                if (OutputResult == "0" && model.BulkPermitId != 0)
                                {
                                    OutputResult = model.BulkPermitId.ToString();
                                }
                                var dataString = CustomQueryStringHelper.
                                EncryptString("Permit", "CoalPayment", "CoalEPermit", new { BulkPermitId = OutputResult });
                                return new RedirectResult(dataString);
                                //return RedirectToAction("CoalPayment", "CoalEPermit", new { BulkPermitId = OutputResult });
                            }
                        }
                        else
                        {
                            TempData["SuccMessage"] = "Your Request Regarding Coal Permit been not Proceed.";
                            TempData.Keep();
                            return View("CoalEPermit", model);
                        }
                    }
                }
            }
        }
        public ActionResult MakeCoalPayment(int BulkPermitId = 0)
        {
            ePermitModel model = new ePermitModel();
            string UserType = "Lessee";
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 64;
           model.UserCode = "Lessee";
            model.BulkPermitId = BulkPermitId;
            ePermitResult objTotalAppl = new ePermitResult();
            if (BulkPermitId == 0)
            {
                if (TempData["result"] != null)
                {
                    ViewBag.DisplayMsg = Convert.ToString(TempData["result"]);
                    ViewBag.ResultMsg = Convert.ToString(TempData["ResultMsg"]);
                }
                return View(new ePermitModel { });
            }
            else
            {
                if (TempData["result"] != null)
                {
                    ViewBag.DisplayMsg = Convert.ToString(TempData["result"]);
                    ViewBag.ResultMsg = Convert.ToString(TempData["ResultMsg"]);
                    return View(new ePermitModel { });
                }
               
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
                        model.BPLesseeDSCPath = Convert.ToString(app.DSCLesseeFilePath);
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
                        model.TypeOfCoalDispatched = Convert.ToString(app.TypeOfCoalDispatched.ToString());
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
                            objPayment.AdjustmentAmount =Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].AdjustmentAmount);
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
                //}
                //}
            }


            return View(new ePermitModel { });

        }
        [HttpGet]
        [SkipImportantTask]
        public IActionResult CoalPayment(string BulkPermitId)
        {
            try
            {
                ePermitModel objmodel = new ePermitModel();
                ePermitResult objresult = new ePermitResult();
                ePermitModel model = new ePermitModel();
                string UserType = "Lessee";
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserID = Convert.ToInt32(profile.UserId);
                //model.UserID = 64;
                model.UserCode = "Lessee";
                model.BulkPermitId = Convert.ToInt32(BulkPermitId);

                int count = 0;
                decimal walletcount = 0;
                if (BulkPermitId != "" && BulkPermitId != null && BulkPermitId != "0")
                {
                    objmodel.BulkPermitId = Convert.ToInt32(BulkPermitId);
                    objmodel.UserCode = "Lessee";
                    objmodel.UserID = Convert.ToInt32(profile.UserId);
                    objresult = _userPemit.GetCheckOutPermitPayment(objmodel);

                    if (objresult != null && objresult.PermitOperationLst.Count > 0)
                    {
                        for (int i = 0; i < objresult.PermitPaymentLst.Count; i++)
                        {
                            count = Convert.ToInt32(objresult.PermitPaymentLst[i].OrderNStatus);
                            walletcount = Convert.ToDecimal(objresult.PermitPaymentLst[i].WalletAdjustedAmount);
                            if (count == 1 || walletcount != 0)
                            {
                                var dataString = CustomQueryStringHelper.
                                   EncryptString("Permit", "ePermitPaymentCheckOut", "Lessee", new { id = BulkPermitId });
                                return new RedirectResult(dataString);
                            }
                            objmodel.BulkPermitId = 0;
                            objmodel.UserCode = null;
                        }
                    }
                }


                ePermitResult objTotalAppl = new ePermitResult();
                
                    model.PaymentBank = "SBI";
               
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
                                objPayment.IsApplicable = Convert.ToBoolean(objTotalAppl.PermitPaymentLst[i].IsApplicable);
                                objPayment.ApplicableId = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].ApplicableId);
                                if (objPayment.PaymentType== "Royalty" && objPayment.IsApplicable==true)
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
                                objPayment.TotalAmount = Convert.ToString(objTotalAppl.PermitPaymentLst[i].TotalAmount);
                                objPayment.IsWalletAdjusted = Convert.ToString(objTotalAppl.PermitPaymentLst[i].IsWalletAdjusted);
                                objPayment.PayDeptId = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].PayDeptId);
                                objPayment.WalletAdjustedAmount = Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].WalletAdjustedAmount);
                                objPayment.OrderNStatus = Convert.ToInt32(objTotalAppl.PermitPaymentLst[i].OrderNStatus);

                                if (objPayment.PayDeptId == 1 && objPayment.ApplicableId == 1)
                                {
                                    ViewBag.CheckMiningRecord = "ok";
                                }
                                else if(objPayment.PayDeptId == 2 && objPayment.ApplicableId == 1)
                                {
                                    ViewBag.CheckIncomeRecord = "ok";
                                }
                                else if (objPayment.PayDeptId == 3 && objPayment.ApplicableId == 1)
                                {
                                    ViewBag.CheckEVSRecord = "ok";
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
        public IActionResult CoalPayment(ePermitModel model)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.SubUserID = Convert.ToInt32(profile.SubUserID);
            //model.UserID = 64;

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
                    //var dataString = CustomQueryStringHelper.
                    //EncryptString("Permit", "CoalPaymentCheckOut", "CoalEPermit", new { id = model.BulkPermitId });
                    //return new RedirectResult(dataString);
                    var dataString = CustomQueryStringHelper.
                    EncryptString("Permit", "ePermitPaymentCheckOut", "Lessee", new { id = model.BulkPermitId });
                    return new RedirectResult(dataString);
                    //return RedirectToAction("ePermitPaymentCheckOut", "Lessee", new { id = model.BulkPermitId });
                }
                else
                {
                    //return RedirectToAction("ePermitPayment", "Lessee", new { id = OutputResult });
                    //var dataString = CustomQueryStringHelper.
                    //EncryptString("Permit", "CoalPaymentCheckOut", "CoalEPermit", new { id = OutputResult });
                    //return new RedirectResult(dataString);
                    var dataString = CustomQueryStringHelper.
                    EncryptString("Permit", "ePermitPaymentCheckOut", "Lessee", new { id = model.BulkPermitId });
                    return new RedirectResult(dataString);
                    //return RedirectToAction("ePermitPaymentCheckOut", "Lessee", new { id = OutputResult });
                }




            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public IActionResult CoalSavedEPermit(String Request, string From, string To)
        {

            try
            {
                
                List<ListCoalPermit> ListCoalPermit = new List<ListCoalPermit>();
                List<ListCoalPermit> modelList = new List<ListCoalPermit>();
                List<ePermitModel> List = new List<ePermitModel>();
                ePermitModel objmodel = new ePermitModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = Convert.ToInt32(profile.UserId);
                //objmodel.UserID = 64;
                objmodel.FromDATE = null;
                objmodel.ToDATE = null;
                
                modelList = _userPemit.GetSavedCoalPermit(objmodel);
                if (modelList != null && modelList.Count > 0)
                {
                    int cnt = 1;
                    for (var i = 0; i < modelList.Count; i++)
                    {
                        
                        ListCoalPermit lst = new ListCoalPermit();
                        lst.SrNo = cnt;
                        lst.BulkPermitId = Convert.ToInt32(modelList[i].BulkPermitId);
                        lst.TransactionId = Convert.ToString(modelList[i].TransactionalID);
                        lst.MineralName = Convert.ToString(modelList[i].MineralName);
                        lst.MineralGrade = Convert.ToString(modelList[i].MineralGrade);
                        lst.MineralNature = Convert.ToString(modelList[i].MineralNature);
                        lst.Status = Convert.ToString(modelList[i].Status);
                        lst.ProposedQty = Convert.ToString(modelList[i].ProposedQty);
                        lst.DateOfApplication = Convert.ToString(modelList[i].DateOfApplication);
                        lst.MergeEPermitCount = Convert.ToString(modelList[i].MergePermitCount);
                        ListCoalPermit.Add(lst);
                        cnt++;

                        //    }
                        //}
                    }
                }
                // }
                //  }
                // return Json(ListCoalPermit.ToDataSourceResult(Request), JsonRequestBehavior.AllowGet);
                ViewBag.ViewList = ListCoalPermit;
                return View();

            }
            catch
            {
                return Json(null);
            }
        }
        public IActionResult ePermitCoalOption()
        {
            return View();
        }
        [SkipImportantTask]
        [HttpGet]
        public IActionResult CoalPaymentCheckOut(string id)
        {
            try
            {
                ePermitModel model = new ePermitModel();

                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserID = Convert.ToInt32(profile.UserId);
                string UserType = profile.UserType;
                //model.UserID = 64;
                //string UserType = "Lessee";
                model.UserCode = "Lessee";
                model.BulkPermitId = Convert.ToInt32(id);

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
                                objPayment.WalletAdjustedAmount = Convert.ToDecimal(objTotalAppl.PermitPaymentLst[i].WalletAdjustedAmount);
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
        public ActionResult MakeEndUserPayment(string Request, ePermitModel model)
        {
            var dataString = CustomQueryStringHelper.
            EncryptString("Payment", "SBIPayment", "SBIPayment", new { Id = model.BulkPermitId, Prefix = "BP", total = model.TotalPayableAmount });
            SBIAPIPath = Configuration.GetSection("Path").GetSection("APIUrl").Value + dataString;
            return new RedirectResult(SBIAPIPath);
           
        }
        #region Delete e-Permit
        //public JsonResult DeleteData(string request, ListCoalPermit model)
        //{
        //    List<ListCoalPermit> modelList = new List<ListCoalPermit>();
        //    ePermitModel objmodel = new ePermitModel();
        //    objmodel.UserID = 150;
        //    objmodel.BulkPermitId = model.BulkPermitId;
        //    objmodel.FromDATE = null;
        //    objmodel.ToDATE = null;


        //    modelList = _userPemit.CoalDeleteData(objmodel);

        //    using (var cmd = new SqlCommand())
        //    {
        //        string OutputResult;

        //        cmd.CommandText = "uspDeletePermit";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
        //        cmd.Parameters.AddWithValue("@BulkPermitId", model.BulkPermitId);
        //        OutputResult = Convert.ToString(objDb.GetSingleValue(cmd));
        //        if (OutputResult == "1")
        //        {
        //            OutputResult = "1";
        //        }
        //        else
        //        {
        //            OutputResult = "3";
        //        }
        //        return Json(OutputResult.ToDataSourceResult(request));
        //    }
        //}
        #endregion
        /// <summary>
        /// Get the details of Generate ,Generated,Archive permit list with payment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="permittype"></param>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ePayment(string request, string permittype, string From, string To, string id)
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID =Convert.ToInt32(profile.SubUserID);
            //ViewBag.ePermitType = "GeneratePermit";
            //objmodel.permittype = "GeneratePermit";
            //ViewBag.ePermitType = "GeneratedPermit";
            //objmodel.permittype = "GeneratedPermit";
            // ViewBag.ePermitType = "ArchivePermit";
            // objmodel.permittype = "ArchivePermit";
            ViewBag.ePermitType = id;
            objmodel.permittype = id;
            try
            {

                modelList = _userPemitLessee.GetApprovedBulkPermitDetails(objmodel);
                if (modelList != null && modelList.Count > 0)
                {
                    for (var i = 0; i < modelList.Count; i++)
                    {
                        ePermitModel model = new ePermitModel();
                        if (!string.IsNullOrEmpty(modelList[i].SRNumber.ToString()))
                        {
                            model.SRNumber = Convert.ToInt32(modelList[i].SRNumber);
                        }
                        if (!string.IsNullOrEmpty(modelList[i].CreateOn.ToString()))
                        {
                            model.CreateOn = Convert.ToDateTime(modelList[i].CreateOn);
                        }
                        model.TransactionalID = Convert.ToString(modelList[i].TransactionalID);
                        model.PaymentReceiptID = Convert.ToString(modelList[i].PaymentReceiptID);
                        model.ApprovedQty = Convert.ToDecimal(modelList[i].ApprovedQty);
                        model.ActiveStatus = Convert.ToInt32(modelList[i].ActiveStatus);
                        model.ApprovedDateText = Convert.ToString(modelList[i].ApprovedDate);
                        model.BulkPermitId = Convert.ToInt32(modelList[i].BulkPermitId);
                        model.BulkPermitNo = Convert.ToString(modelList[i].BulkPermitNo);
                        model.Cess = Convert.ToDecimal(modelList[i].Cess);
                        model.eCess = Convert.ToDecimal(modelList[i].eCess);
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
                        model.MineralNature = Convert.ToString(modelList[i].MineralNatureName);

                        if (UserType.ToUpper() != "TAILING DAM")
                        {
                            model.GrantOrderNo = Convert.ToString(modelList[i].GrantOrderNo);
                            model.DateOfGrant = Convert.ToString(modelList[i].DateOfGrant);
                            model.PeriodOfLeaseFrom = Convert.ToString(modelList[i].PeriodOfLeaseFrom);
                            model.PeriodOfLeaseTo = Convert.ToString(modelList[i].PeriodOfLeaseTo);
                            model.LeaseTypeId = Convert.ToInt32(modelList[i].LeaseTypeID);
                            model.LeaseTypeName = Convert.ToString(modelList[i].LeaseTypeName);
                            model.MineralGradeName = Convert.ToString(modelList[i].MineralGrade);
                        }
                        else
                        {
                            model.MineralGradeName = Convert.ToString(modelList[i].MineralGrade + " ( " + Convert.ToString(modelList[i].ActualGrade) + " )");
                        }

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
                        model.MergeEPermitCount = Convert.ToString(modelList[i].MergePermitCount);
                        if (!string.IsNullOrEmpty(modelList[i].ISCessAdjusted.ToString()))
                        {
                            model.ISCessAdjusted = Convert.ToInt32(modelList[i].ISCessAdjusted);
                        }
                        model.NoOfRunningPass = Convert.ToInt32(modelList[i].NoOfRunningPass);
                        if (modelList[i].LesseeDSCPath == null || modelList[i].LesseeDSCPath.ToString() == "")
                        {
                            model.DSCLesseeFilePath = "";
                        }
                        else
                        {
                            model.DSCLesseeFilePath = this.Configuration.GetSection("AppSettings")["ServerPath"] + Convert.ToString(modelList[i].LesseeDSCPath);
                        }


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
        public IActionResult GenerateCoalPermit()
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
            ViewBag.ePermitType = "GeneratePermit";
            objmodel.permittype = "GeneratePermit";
            //ViewBag.ePermitType = "GeneratedPermit";
            //objmodel.permittype = "GeneratedPermit";
            // ViewBag.ePermitType = "ArchivePermit";
            // objmodel.permittype = "ArchivePermit";

            try
            {

                modelList = _userPemitLessee.GetApprovedBulkPermitDetails(objmodel);
                if (modelList != null && modelList.Count > 0)
                {
                    for (var i = 0; i < modelList.Count; i++)
                    {
                        ePermitModel model = new ePermitModel();
                        if (!string.IsNullOrEmpty(modelList[i].SRNumber.ToString()))
                        {
                            model.SRNumber = Convert.ToInt32(modelList[i].SRNumber);
                        }
                        if (!string.IsNullOrEmpty(modelList[i].CreateOn.ToString()))
                        {
                            model.CreateOn = Convert.ToDateTime(modelList[i].CreateOn);
                        }
                        model.TransactionalID = Convert.ToString(modelList[i].TransactionalID);
                        model.PaymentReceiptID = Convert.ToString(modelList[i].PaymentReceiptID);
                        model.ApprovedQty = Convert.ToDecimal(modelList[i].ApprovedQty);
                        model.ActiveStatus = Convert.ToInt32(modelList[i].ActiveStatus);
                        model.ApprovedDateText = Convert.ToString(modelList[i].ApprovedDate);
                        model.BulkPermitId = Convert.ToInt32(modelList[i].BulkPermitId);
                        model.BulkPermitNo = Convert.ToString(modelList[i].BulkPermitNo);
                        model.Cess = Convert.ToDecimal(modelList[i].Cess);
                        model.eCess = Convert.ToDecimal(modelList[i].eCess);
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
                        model.MineralNature = Convert.ToString(modelList[i].MineralNatureName);

                        if (UserType.ToUpper() != "TAILING DAM")
                        {
                            model.GrantOrderNo = Convert.ToString(modelList[i].GrantOrderNo);
                            model.DateOfGrant = Convert.ToString(modelList[i].DateOfGrant);
                            model.PeriodOfLeaseFrom = Convert.ToString(modelList[i].PeriodOfLeaseFrom);
                            model.PeriodOfLeaseTo = Convert.ToString(modelList[i].PeriodOfLeaseTo);
                            model.LeaseTypeId = Convert.ToInt32(modelList[i].LeaseTypeID);
                            model.LeaseTypeName = Convert.ToString(modelList[i].LeaseTypeName);
                            model.MineralGradeName = Convert.ToString(modelList[i].MineralGrade);
                        }
                        else
                        {
                            model.MineralGradeName = Convert.ToString(modelList[i].MineralGrade + " ( " + Convert.ToString(modelList[i].ActualGrade) + " )");
                        }

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
                        model.MergeEPermitCount = Convert.ToString(modelList[i].MergePermitCount);
                        if (!string.IsNullOrEmpty(modelList[i].ISCessAdjusted.ToString()))
                        {
                            model.ISCessAdjusted = Convert.ToInt32(modelList[i].ISCessAdjusted);
                        }
                        model.NoOfRunningPass = Convert.ToInt32(modelList[i].NoOfRunningPass);
                        if (modelList[i].LesseeDSCPath == null || modelList[i].LesseeDSCPath.ToString() == "")
                        {
                            model.DSCLesseeFilePath = "";
                        }
                        else
                        {
                            model.DSCLesseeFilePath = this.Configuration.GetSection("AppSettings")["ServerPath"] + Convert.ToString(modelList[i].LesseeDSCPath);
                        }


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
        public IActionResult GeneratedCoalPermit()
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);

            ViewBag.ePermitType = "GeneratedPermit";
            objmodel.permittype = "GeneratedPermit";
            // ViewBag.ePermitType = "ArchivePermit";
            // objmodel.permittype = "ArchivePermit";

            try
            {

                modelList = _userPemitLessee.GetApprovedBulkPermitDetails(objmodel);
                if (modelList != null && modelList.Count > 0)
                {
                    for (var i = 0; i < modelList.Count; i++)
                    {
                        ePermitModel model = new ePermitModel();
                        if (!string.IsNullOrEmpty(modelList[i].SRNumber.ToString()))
                        {
                            model.SRNumber = Convert.ToInt32(modelList[i].SRNumber);
                        }
                        if (!string.IsNullOrEmpty(modelList[i].CreateOn.ToString()))
                        {
                            model.CreateOn = Convert.ToDateTime(modelList[i].CreateOn);
                        }
                        model.TransactionalID = Convert.ToString(modelList[i].TransactionalID);
                        model.PaymentReceiptID = Convert.ToString(modelList[i].PaymentReceiptID);
                        model.ApprovedQty = Convert.ToDecimal(modelList[i].ApprovedQty);
                        model.ActiveStatus = Convert.ToInt32(modelList[i].ActiveStatus);
                        model.ApprovedDateText = Convert.ToString(modelList[i].ApprovedDate);
                        model.BulkPermitId = Convert.ToInt32(modelList[i].BulkPermitId);
                        model.BulkPermitNo = Convert.ToString(modelList[i].BulkPermitNo);
                        model.Cess = Convert.ToDecimal(modelList[i].Cess);
                        model.eCess = Convert.ToDecimal(modelList[i].eCess);
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
                        model.MineralNature = Convert.ToString(modelList[i].MineralNatureName);

                        if (UserType.ToUpper() != "TAILING DAM")
                        {
                            model.GrantOrderNo = Convert.ToString(modelList[i].GrantOrderNo);
                            model.DateOfGrant = Convert.ToString(modelList[i].DateOfGrant);
                            model.PeriodOfLeaseFrom = Convert.ToString(modelList[i].PeriodOfLeaseFrom);
                            model.PeriodOfLeaseTo = Convert.ToString(modelList[i].PeriodOfLeaseTo);
                            model.LeaseTypeId = Convert.ToInt32(modelList[i].LeaseTypeID);
                            model.LeaseTypeName = Convert.ToString(modelList[i].LeaseTypeName);
                            model.MineralGradeName = Convert.ToString(modelList[i].MineralGrade);
                        }
                        else
                        {
                            model.MineralGradeName = Convert.ToString(modelList[i].MineralGrade + " ( " + Convert.ToString(modelList[i].ActualGrade) + " )");
                        }

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
                        model.MergeEPermitCount = Convert.ToString(modelList[i].MergePermitCount);
                        if (!string.IsNullOrEmpty(modelList[i].ISCessAdjusted.ToString()))
                        {
                            model.ISCessAdjusted = Convert.ToInt32(modelList[i].ISCessAdjusted);
                        }
                        model.NoOfRunningPass = Convert.ToInt32(modelList[i].NoOfRunningPass);
                        if (modelList[i].LesseeDSCPath == null || modelList[i].LesseeDSCPath.ToString() == "")
                        {
                            model.DSCLesseeFilePath = "";
                        }
                        else
                        {
                            model.DSCLesseeFilePath = this.Configuration.GetSection("AppSettings")["ServerPath"] + Convert.ToString(modelList[i].LesseeDSCPath);
                        }


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
        public IActionResult ArchivedCoalPermit()
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
            ViewBag.ePermitType = "ArchivePermit";
            objmodel.permittype = "ArchivePermit";

            try
            {

                modelList = _userPemitLessee.GetApprovedBulkPermitDetails(objmodel);
                if (modelList != null && modelList.Count > 0)
                {
                    for (var i = 0; i < modelList.Count; i++)
                    {
                        ePermitModel model = new ePermitModel();
                        if (!string.IsNullOrEmpty(modelList[i].SRNumber.ToString()))
                        {
                            model.SRNumber = Convert.ToInt32(modelList[i].SRNumber);
                        }
                        if (!string.IsNullOrEmpty(modelList[i].CreateOn.ToString()))
                        {
                            model.CreateOn = Convert.ToDateTime(modelList[i].CreateOn);
                        }
                        model.TransactionalID = Convert.ToString(modelList[i].TransactionalID);
                        model.PaymentReceiptID = Convert.ToString(modelList[i].PaymentReceiptID);
                        model.ApprovedQty = Convert.ToDecimal(modelList[i].ApprovedQty);
                        model.ActiveStatus = Convert.ToInt32(modelList[i].ActiveStatus);
                        model.ApprovedDateText = Convert.ToString(modelList[i].ApprovedDate);
                        model.BulkPermitId = Convert.ToInt32(modelList[i].BulkPermitId);
                        model.BulkPermitNo = Convert.ToString(modelList[i].BulkPermitNo);
                        model.Cess = Convert.ToDecimal(modelList[i].Cess);
                        model.eCess = Convert.ToDecimal(modelList[i].eCess);
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
                        model.MineralNature = Convert.ToString(modelList[i].MineralNatureName);

                        if (UserType.ToUpper() != "TAILING DAM")
                        {
                            model.GrantOrderNo = Convert.ToString(modelList[i].GrantOrderNo);
                            model.DateOfGrant = Convert.ToString(modelList[i].DateOfGrant);
                            model.PeriodOfLeaseFrom = Convert.ToString(modelList[i].PeriodOfLeaseFrom);
                            model.PeriodOfLeaseTo = Convert.ToString(modelList[i].PeriodOfLeaseTo);
                            model.LeaseTypeId = Convert.ToInt32(modelList[i].LeaseTypeID);
                            model.LeaseTypeName = Convert.ToString(modelList[i].LeaseTypeName);
                            model.MineralGradeName = Convert.ToString(modelList[i].MineralGrade);
                        }
                        else
                        {
                            model.MineralGradeName = Convert.ToString(modelList[i].MineralGrade + " ( " + Convert.ToString(modelList[i].ActualGrade) + " )");
                        }

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
                        model.MergeEPermitCount = Convert.ToString(modelList[i].MergePermitCount);
                        if (!string.IsNullOrEmpty(modelList[i].ISCessAdjusted.ToString()))
                        {
                            model.ISCessAdjusted = Convert.ToInt32(modelList[i].ISCessAdjusted);
                        }
                        model.NoOfRunningPass = Convert.ToInt32(modelList[i].NoOfRunningPass);
                        if (modelList[i].LesseeDSCPath == null || modelList[i].LesseeDSCPath.ToString() == "")
                        {
                            model.DSCLesseeFilePath = "";
                        }
                        else
                        {
                            model.DSCLesseeFilePath = this.Configuration.GetSection("AppSettings")["ServerPath"] + Convert.ToString(modelList[i].LesseeDSCPath);
                        }


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
        /// <summary>
        /// Delete saved Coal permit
        /// </summary>
        /// <param name="request"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [SkipImportantTask]
        public IActionResult DeleteData(string request, string id)
        {
            ePermitModel objPermit = null;
            try
            {
                objPermit = new ePermitModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objPermit.UserID = Convert.ToInt32(profile.UserId);
                objPermit.BulkPermitId =Convert.ToInt32(id);
                objMSmodel = _userPemit.DeleteCoalData(objPermit);
                OutputResult = objMSmodel.Satus;
                ModelState.AddModelError("", "Draft Application deleted successfully.");
                return RedirectToAction("CoalSavedEPermit", "CoalEPermit");
               
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
        /// Download Draft coal permit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        #region e-Permit Download View Without DSC
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
            model.UserLoginId = Convert.ToString(profile.UserLoginId);
            //model.UserID = 83;
            //model.UserType = "Lessee";
            model.UserType = profile.UserType;
            model.BulkPermitId = Convert.ToInt32(id);
            //string UserType = profile.UserType;
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
                    if (UserType.ToUpper() != "TAILING DAM")
                    {
                        model.LeaseTypeId = Convert.ToInt32(app.LeaseTypeId);
                        model.MineralGradeName = Convert.ToString(app.MineralGrade);
                        TempData["LeaseTypeId"] = model.LeaseTypeId;
                    }
                    else
                    {
                        model.MineralGradeName = Convert.ToString(app.MineralGrade + " ( " + Convert.ToString(app.ActualGrade) + " )");
                    }



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
                    model.GeneratedDesignation = Convert.ToString(app.GeneratedDesignation);

                    model.DSCLesseeFilePath = Convert.ToString(app.DSCLesseeFilePath);
                    model.DSCDDFilePath = Convert.ToString(app.DSCDDFilePath);

                    TempData["LeaseTypeId"] = model.LeaseTypeId;
                    model.TypeOfCoalDispatched = Convert.ToString(app.TypeOfCoalDispatched);
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
                        if (Convert.ToString(app1.PaymentType) == "Royalty")
                        {
                            model.CalValue = Convert.ToString(app1.CalValue);
                        }
                        objPaymentList.Add(objPayment);
                    }


                    model.PaymentDetails = objPaymentList;
                }

            }
            catch
            { }
            return View(model);
        }
        #endregion

        #region Sampeling of Coal Grade

        public ActionResult SampleGrade()
        {
            try
            {
                SampleGradeModel obj = new SampleGradeModel();
                List<SampleGradeModel> objlist = new List<SampleGradeModel>();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                obj.CreatedBy = Convert.ToInt32(profile.UserId);
                objlist = _userUpgrade.GetGradeDetails(obj);
                ViewBag.ViewList = objlist;
            }
            catch(Exception)
            {
                return null;
            }
            return View();
        }

        [SkipImportantTask]
        public ActionResult UpdateSampleGrade(string BulkPermitId = "0")
        {
            ePermitModel model = new ePermitModel();
            ePermitModel Result = new ePermitModel();

            if (BulkPermitId != "0")
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserID = Convert.ToInt32(profile.UserId);
                model.BulkPermitId = Convert.ToInt32(BulkPermitId);
                Result = _userPemit.GetDetailsOfUpgrade(model);
                model.MineralNatureId = Result.MineralNatureId;
                var z = _userPemit.GetMineralGradeListOnNatureList(model);
                if (z.MineralGradeLst != null)
                {
                    ViewBag.MineralGradeList = z.MineralGradeLst.Select(c => new SelectListItem
                    {
                        Text = c.MineralGrade,
                        Value = c.MineralGradeId.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.MineralGradeList = Enumerable.Empty<SelectListItem>();
                }
                return View(Result);
            }
            else
            {
                ViewBag.MineralGradeList = Enumerable.Empty<SelectListItem>();
                return View(Result);
            }
        }

        #endregion

        public JsonResult GetBasicprice(int? MineralNatureId, int? MineralGrade, int? Mineral, int? DistrictId)
        {
            try
            {
                ePermitModel objmodel = new ePermitModel();
                ePermitModel objmodelcoal = new ePermitModel();
                ePermitModel objmodelless = new ePermitModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID =Convert.ToInt32(profile.UserId);
                objmodelless = _userPemit.GetComapny(objmodel);
                objmodel.MineralId = Mineral;
                objmodel.MineralNatureId = MineralNatureId;
                objmodel.MineralGradeId = Convert.ToInt32(MineralGrade);
                objmodel.DistrictId = DistrictId;
                if (objmodelless.COMPANY == "1")
                {
                    objmodelcoal = _userPemit.GetCoalRoyalty(objmodel);
                }
                return Json(objmodelcoal);
            }
            catch
            {
                return null;
            }
        }
        [SkipImportantTask]
        public IActionResult GetPendingStatus(string id,string Status,string Prefix)
        {
            try
            {
                if(Status== "SUCCESS")
                {
                    ViewBag.SUCCESS = "Your Payment Status Changes to SUCCESS";
                }
                else if(Status== "AWAITED" || Status == "PENDING")
                {
                    ViewBag.SUCCESS = "Your payment status is still in awaited mode, please check after some time for update.";
                }
                else if(Status == "FAILED")
                {
                    ViewBag.SUCCESS = "Your payment is failed please go to the save permit and do payment";
                }
                else
                {
                    ViewBag.SUCCESS = null;
                }
                ePermitModel model = new ePermitModel();
                List<ePaymentData> LISTpayment = new List<ePaymentData>();
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
                LISTpayment = _userPemit.GetPaymentStatus(model);
                ViewBag.MiningDp = null;
                ViewBag.IncomeDp = null;
                ViewBag.EVSDp = null;

                if (Status == "FAILED" && Prefix=="ORDMIN")
                {
                    ViewBag.MINGetStatus = "Your Payment Has Been Failed";
                    ViewBag.MiningDp = "ok";
                   
                }
               else if (Status == "FAILED" && Prefix == "ORDINC")
                {
                    ViewBag.INCGetStatus = "Your Payment Has Been Failed";
                    ViewBag.IncomeDp = "ok";
                    
                }
               else if (Status == "FAILED" && Prefix == "ORDEVS")
                {
                    ViewBag.EVSGetStatus = "Your Payment Has Been Failed";
                    ViewBag.EVSDp = "ok";
                }
                else
                {
                    ViewBag.MINGetStatus = null;
                    ViewBag.INCGetStatus = null;
                    ViewBag.EVSGetStatus = null;
                }
                if (LISTpayment.Count > 0)
                {
                    foreach (var a in LISTpayment)
                    {
                        if(a.CLNT_TXN_REF.Contains("ORDMIN"))
                        {
                            ViewBag.MiningDp = "ORDMIN";
                            
                        }
                        else if(a.CLNT_TXN_REF.Contains("ORDINC"))
                        {
                            ViewBag.IncomeDp = "ORDINC";
                        }
                        else if (a.CLNT_TXN_REF.Contains("ORDEVS"))
                        {
                            ViewBag.EVSDp = "ORDEVS";
                        }
                        else
                        {
                            ViewBag.MiningDp = null;
                            ViewBag.IncomeDp = null;
                            ViewBag.EVSDp = null;
                        }
                    }
                }
                else
                {
                    ViewBag.GenaratePer = "Ok";
                }

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

                    objTotalAppl = _userPemitLessee.GetCheckOutPermitPayment(model);
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
        [SkipImportantTask]
        public ActionResult PostPaymenyStatus(string id,string PaymentType)
        {
            var dataString = CustomQueryStringHelper.
                EncryptString("Payment", "PaymentStatusFromGateway_New", "SBIPayment", new { id = id, PaymentType= PaymentType });
            SBIAPIPath = Configuration.GetSection("Path").GetSection("APIUrl").Value + dataString;
            return new RedirectResult(SBIAPIPath);

        }

    }
}