using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermitApp.Areas.Permit.Models.Lessee;
using PermitApp.Areas.Permit.Models.CoalEPermit;
using PermitApp.Areas.Permit.Models.PaymentConfig;
using PermitEF;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using PermitApp.Helper;
using PermitApp.Web;
using PermitApp.ActionFilter;

namespace PermitApp.Areas.Permit.Controllers
{
    [Area("Permit")]
    public class ePermitController : Controller
    {
        ILesseePermitModel _userPemit;
        ICoalEPermitModel _userCoalPermit;
        IPaymentConfigModel _userPayment;
        MessageEF objMSmodel = new MessageEF();
        public object JsonRequestBehavior { get; private set; }
        IWebHostEnvironment _hostingEnvironment;
        string OutputResult = "";
        string UserType = "Lessee";//it will comes from session variable
        private IConfiguration Configuration;



        public ePermitController(ILesseePermitModel objPermit, ICoalEPermitModel objCoalPermit, IPaymentConfigModel objPayment, IWebHostEnvironment hostingEnvironment, IConfiguration _configuration)
        {
            _userPemit = objPermit;
            _userPayment = objPayment;
            _userCoalPermit = objCoalPermit;
            _hostingEnvironment = hostingEnvironment;
            Configuration = _configuration;
        }



        public IActionResult List(string request)
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();

            //objmodel.UserID = 64; //For lessee permit
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            try
            {
                var x = _userPemit.GetMergePermitMineralGrade(objmodel);
                if (x.MineralGradeLst != null)
                {
                    ViewBag.MineralGradeLst = x.MineralGradeLst.Select(c => new SelectListItem
                    {
                        Text = c.MineralGrade,
                        Value = c.MineralGradeId.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.MineralGradeLst = Enumerable.Empty<SelectListItem>();
                }
                modelList = _userPemit.GetMergePermitList(objmodel);
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
                        if (!string.IsNullOrEmpty(modelList[i].ISCessAdjusted.ToString()))
                        {
                            model.ISCessAdjusted = Convert.ToInt32(modelList[i].ISCessAdjusted);
                        }
                        model.NoOfRunningPass = Convert.ToInt32(modelList[i].NoOfRunningPass);
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
        public JsonResult requestedMergeEPermit(string arr, string qty, string grade, string total)
        {
            try
            {
                if (!(string.IsNullOrEmpty(grade)))
                {
                    string strGrade = grade.Replace('[', ' ').Replace(']', ' ').Replace(" ", "");

                    string[] strAllGrade = strGrade.Split(',');
                    bool isSameGrade = true;
                    if (strAllGrade.Length > 0)
                    {
                        string lastGrade = string.Empty;
                        for (int i = 0; i < strAllGrade.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(strAllGrade[i]))
                            {
                                if (string.IsNullOrEmpty(lastGrade))
                                {
                                    lastGrade = strAllGrade[i];
                                }
                                else
                                {
                                    if (lastGrade != strAllGrade[i])
                                    {
                                        isSameGrade = false;
                                    }
                                }
                            }
                        }
                    }

                    if (isSameGrade == false)
                    {
                        TempData["BulkPermitIdList"] = "0";
                        TempData["BulkPermitQtyList"] = "0";
                        TempData["TotalQtyList"] = "0";

                        return Json(false);
                    }
                }

                if (!(string.IsNullOrEmpty(arr) && string.IsNullOrEmpty(qty) && string.IsNullOrEmpty(total)))
                {
                    TempData["BulkPermitIdList"] = arr.Replace('[', ' ').Replace(']', ' ').Replace(" ", "").Replace("\"", "");
                    TempData["BulkPermitQtyList"] = qty.Replace('[', ' ').Replace(']', ' ').Replace(" ", "").Replace("\"", "");
                    TempData["TotalQtyList"] = total;

                    //string BulkPermitIdList = TempData["BulkPermitIdList"].ToString();
                    //string BulkPermitQtyList = TempData["BulkPermitQtyList"].ToString();
                    //string TotalQtyList = TempData["TotalQtyList"].ToString();

                    //TempData.Keep("BulkPermitIdList");
                    //TempData.Keep("BulkPermitQtyList");
                    //TempData.Keep("TotalQtyList");
                    return Json(true);
                }
                else
                {
                    TempData["BulkPermitIdList"] = "0";
                    TempData["BulkPermitQtyList"] = "0";
                    TempData["TotalQtyList"] = "0";

                    return Json(false);
                }
            }
            catch (Exception)
            {
                return Json(false);
            }

        }
        [SkipImportantTask]
        public IActionResult MergeEPermit(string BulkpermitId = "0")
        {
            ePermitModel model = new ePermitModel();
            ePermitResult objDetailsAppl = new ePermitResult();
            ePermitResult objOperationAppl = new ePermitResult();
            ePermitResult MINEDET = new ePermitResult();
            ePermitModel objmodelless = new ePermitModel();
            ePermitModel objmodelcoal = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            MINEDET = _userCoalPermit.GetMinesDetails(model);
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

            // model.UserID = 72;//Coal Lessee
            model.UserLoginId = Convert.ToString(profile.UserLoginId);
            string UserType = profile.UserType;

            var x = _userCoalPermit.GetTypeOfCoal(model);
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

            objDetailsAppl = _userPemit.GetPermitDetailsByUserID(model);
            if (objDetailsAppl != null && objDetailsAppl.DetailsPermitLstByUserID.Count > 0)
            {
                // ePermitModel model = new ePermitModel();

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

                }

                if (TempData["Acknowledgement"] != null)
                {
                    ViewBag.Acknowledgement = Convert.ToString(TempData["Acknowledgement"]);
                }
                try
                {
                    if (BulkpermitId == "0")
                    {
                        if (TempData["BulkPermitIdList"] != null)
                        {
                            string lst = Convert.ToString(TempData["BulkPermitIdList"]);
                            model.BulkPermitIdList = lst.Replace(@"\", "");
                        }
                        objOperationAppl = _userPemit.MergeEpermitOperation(model);
                        foreach (var app1 in objOperationAppl.MergeEPermitLst)
                        {

                            if (objOperationAppl.MergeEPermitLst.Count > 0)
                            {
                                if (TempData["BulkPermitIdList"] != null && TempData["BulkPermitQtyList"] != null && TempData["TotalQtyList"] != null)
                                {
                                    model.BulkPermitIdList = Convert.ToString(TempData["BulkPermitIdList"]);
                                    ViewBag.BulkPermitQtyList = Convert.ToString(TempData["BulkPermitQtyList"]);
                                    ViewBag.TotalQtyList = Convert.ToString(TempData["TotalQtyList"]);
                                }

                                if (app1.GrantOrderNumber.ToString() == "" || app1.GrantOrderNumber.ToString() == null)
                                {
                                    TempData["AlertMsg"] = "Details not found !";
                                }
                                else
                                {

                                    model.MergePermitAmount = app1.MergePermitAmount;
                                    model.LesseeName = app1.ApplicantName;
                                    model.LesseeAddress = app1.Address;
                                    if (!(app1.DistrictId is null))
                                    {
                                        model.DistrictId = Convert.ToInt32(app1.DistrictId);
                                    }
                                    model.District = Convert.ToString(app1.DistrictName);
                                    // model.DistrictCode = Convert.ToString(app1.DistrictCode"]);
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
                                    model.ProductionCap = Convert.ToString(app1.ProductionCap);
                                    model.RemainingProduction = Convert.ToString(TempData["TotalQtyList"]);

                                    model.GeneratedBy = Convert.ToString(app1.GeneratedBy);
                                    model.GeneratedDesignation = Convert.ToString(app1.GeneratedDesignation);

                                    model.ISAdjustmentCess = (app1.ISAdjustmentCess is null) ? 0 : Convert.ToInt32(app1.ISAdjustmentCess);
                                    model.OrderDate = Convert.ToString(app1.OrderDate);
                                    model.OrderNo = Convert.ToString(app1.OrderNo);
                                    model.OrderOf = Convert.ToString(app1.OrderOf);
                                    model.IsWalletAdjusted = Convert.ToString(app1.IsWalletAdjusted);

                                    #region Mineral Infromation
                                    if (!(app1.MINERAL_ID is null))
                                    {
                                        model.MineralId = Convert.ToInt32(app1.MINERAL_ID);
                                        model.MineralName = Convert.ToString(app1.MineralName);
                                    }

                                    if (!(app1.UnitId is null))
                                    {
                                        model.UnitId = Convert.ToInt32(app1.UnitId);
                                        model.UnitName = Convert.ToString(app1.UnitName);
                                    }


                                    if (!(app1.MINERAL_GRADE_ID is null))
                                    {
                                        model.MineralGradeId = Convert.ToInt32(app1.MINERAL_GRADE_ID);
                                        model.MineralGradeName = Convert.ToString(app1.MineralGrade);
                                    }

                                    if (!(app1.MineralNatureID is null))//This entity used in non-coal
                                    {
                                        model.MineralNatureId = Convert.ToInt32(app1.MineralNatureID);
                                        model.MineralNature = Convert.ToString(app1.MineralNature);
                                    }
                                    if (!(app1.MineralNatureId is null))//This entity used in coal
                                    {
                                        model.MineralNatureId = Convert.ToInt32(app1.MineralNatureId);
                                        model.MineralNature = Convert.ToString(app1.MineralNature);
                                    }
                                    model.AluminaContent = Convert.ToDecimal(app1.AluminaContent);
                                    model.TinContent = Convert.ToDecimal(app1.TinContent);


                                    #endregion

                                    TempData["LeaseTypeId"] = model.LeaseTypeId;
                                }
                                if (model.MineralName.Contains("Coal"))
                                {
                                    objmodelless = _userCoalPermit.GetComapny(model);
                                    if (objmodelless.COMPANY == "1")
                                    {
                                        ViewBag.read = "readonly";
                                        objmodelcoal = _userCoalPermit.GetCoalRoyalty(model);
                                        model.BasicRate = objmodelcoal.SalePrice;
                                    }
                                    else
                                    {
                                        ViewBag.read = null;
                                    }
                                }
                                else
                                {
                                    ViewBag.read = null;
                                }
                                return View(model);
                            }
                            else
                            {
                                TempData["AlertMsg"] = "Details not found !";
                                return View(model);
                                //return RedirectToAction("ValidityExpired", "ValidityExpired", new { Area = "" });
                            }
                        }
                        //}
                    }
                    else
                    {
                        model.BulkPermitId = Convert.ToInt32(BulkpermitId);

                        objOperationAppl = _userPemit.MergeEpermitOperation(model);
                        foreach (var app1 in objOperationAppl.MergeEPermitLst)
                        {

                            if (objOperationAppl.MergeEPermitLst.Count > 0)
                            {
                                model.TransactionalID = Convert.ToString(app1.TransactionalID);
                                model.MobileNo = Convert.ToString(app1.MobileNo);
                                model.EmailId = Convert.ToString(app1.EMailId);

                                model.MergePermitAmount = Convert.ToString(app1.MergePermitAmount);
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
                                if (!(app1.TCS is null))
                                {
                                    model.TCS = Convert.ToDecimal(app1.TCS);
                                }
                                if (!(app1.Cess is null))
                                {
                                    model.Cess = Convert.ToDecimal(app1.Cess);
                                }
                                if (!(app1.eCess is null))
                                {
                                    model.eCess = Convert.ToDecimal(app1.eCess);
                                }
                                if (!(app1.DMF is null))
                                {
                                    model.DMF = Convert.ToDecimal(app1.DMF);
                                }
                                if (!(app1.NMET == 0))
                                {
                                    model.NMET = Convert.ToDecimal(app1.NMET);
                                }
                                if (!(app1.PayableRoyalty is null))
                                {
                                    model.PayableRoyalty = Convert.ToDecimal(app1.PayableRoyalty);
                                }
                                if (!(app1.TotalPayableAmount == 0))
                                {
                                    model.TotalPayableAmount = Convert.ToDecimal(app1.TotalPayableAmount);
                                }
                                if (!(app1.ProposedQty is null))
                                {
                                    model.ProposedQty = (Convert.ToDecimal(app1.ProposedQty) - Convert.ToDecimal(app1.RemainingProduction));
                                }
                                model.PoliceStation = Convert.ToString(app1.POLICE_STATION);
                                model.Panchayat = Convert.ToString(app1.GRAM_PANCHAYAT);
                                model.ProductionYear = Convert.ToString(app1.ProductionYear);
                                model.Production = Convert.ToString(app1.Production);

                                model.ProductionCap = Convert.ToString(app1.ProductionCap);

                                model.RemainingProduction = Convert.ToString(app1.RemainingProduction);
                                if (!(app1.MineralNatureId is null))
                                {
                                    model.MineralNatureId = Convert.ToInt32(app1.MineralNatureId);
                                    model.MineralNature = Convert.ToString(app1.MineralNature);
                                }
                                model.GeneratedBy = Convert.ToString(app1.GeneratedBy);
                                model.GeneratedDesignation = Convert.ToString(app1.GeneratedDesignation);

                                model.ISAdjustmentCess = (app1.ISAdjustmentCess is null) ? 0 : Convert.ToInt32(app1.ISAdjustmentCess);
                                model.OrderDate = Convert.ToString(app1.OrderDate);
                                model.OrderNo = Convert.ToString(app1.OrderNo);
                                model.OrderOf = Convert.ToString(app1.OrderOf);

                                model.AluminaContent = Convert.ToDecimal(app1.AluminaContent);
                                model.TinContent = Convert.ToDecimal(app1.TinContent);
                                model.IsWalletAdjusted = Convert.ToString(app1.IsWalletAdjusted);

                                TempData["LeaseTypeId"] = model.LeaseTypeId;

                                #region Mineral Infromation
                                if (!(app1.MINERAL_ID is null))
                                {
                                    model.MineralId = Convert.ToInt32(app1.MINERAL_ID);
                                    model.MineralName = Convert.ToString(app1.MineralName);

                                    if (model.MineralName.Contains("Coal"))
                                    {
                                        model.BasicRate = String.IsNullOrEmpty(app1.BasicRate.ToString()) == false ? Convert.ToDecimal(app1.BasicRate) : 0;
                                        if (app1.DONumber != null && app1.DONumber != "")
                                        {
                                            model.DONumber = app1.DONumber.ToString();
                                        }
                                        else
                                        {
                                            model.DONumber = "";
                                        }
                                        if (app1.DODate != null && app1.DODate != "")
                                        {
                                            model.DODate = String.IsNullOrEmpty(app1.DODate.ToString()) == false ? Convert.ToDateTime(app1.DODate).ToString("dd/MM/yyyy") : "";
                                        }
                                        else
                                        {
                                            model.DODate = "";
                                        }
                                        if (app1.EAuctionType != null && app1.EAuctionType != "")
                                        {
                                            model.EAuctionType = Convert.ToString(app1.EAuctionType.ToString());
                                        }
                                        else
                                        {
                                            model.EAuctionType = "";
                                        }
                                        if (model.TypeOfCoalDispatched != null && model.TypeOfCoalDispatched != "")
                                        {
                                            //model.TypeOfCoalDispatched = Convert.ToString(app1.TypeOfCoalDispatched"].ToString());
                                            model.TypeOfCoalDispatched = Convert.ToString(app1.eAuctionTypeId.ToString());
                                        }
                                        else
                                        {
                                            model.TypeOfCoalDispatched = "";
                                        }
                                    }
                                }

                                if (!(app1.UnitId is null))
                                {
                                    model.UnitId = Convert.ToInt32(app1.UnitId);
                                    model.UnitName = Convert.ToString(app1.UnitName);
                                }


                                if (!(app1.MINERAL_GRADE_ID is null))
                                {
                                    model.MineralGradeId = Convert.ToInt32(app1.MINERAL_GRADE_ID);
                                    model.MineralGradeName = Convert.ToString(app1.MineralGrade);
                                }

                                if (!(app1.MineralNatureID is null))
                                {
                                    model.MineralNatureId = Convert.ToInt32(app1.MineralNatureID);
                                    model.MineralNature = Convert.ToString(app1.MineralNature);
                                }
                                #endregion

                                if (model.MineralName.Contains("Coal"))
                                {
                                    objmodelless = _userCoalPermit.GetComapny(model);
                                    if (objmodelless.COMPANY == "1")
                                    {
                                        ViewBag.read = "readonly";
                                        objmodelcoal = _userCoalPermit.GetCoalRoyalty(model);
                                        model.BasicRate = objmodelcoal.SalePrice;
                                    }
                                    else
                                    {
                                        ViewBag.read = null;
                                    }
                                }
                                else
                                {
                                    ViewBag.read = null;
                                }

                                return View(model);
                            }
                            else
                            {
                                return View(model);
                            }
                        }
                        // }
                    }
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
            return View(model);
        }
        public IActionResult ePermitApplication(int id = 0)
        {
            ePermitModel objmodel = new ePermitModel();
            ePermitResult objTotalAppl = new ePermitResult();
            ePermitResult objDetailsAppl = new ePermitResult();
            ePermitResult objOperationAppl = new ePermitResult();
            ePermitResult objOperationBulkAppl = new ePermitResult();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
            string UserType = "Lessee";

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




            //System.Data.SqlClient.SqlCommand sqcmd = new System.Data.SqlClient.SqlCommand();
            //sqcmd.CommandText = "CheckTotalPermitByUser";
            //sqcmd.CommandType = System.Data.CommandType.StoredProcedure;
            //sqcmd.Parameters.AddWithValue("@USER_ID", SessionWrapper.UserId);

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

                        }
                        if (TempData["Acknowledgement"] != null)
                        {
                            ViewBag.Acknowledgement = Convert.ToString(TempData["Acknowledgement"]);
                        }
                        try
                        {
                            if (id == 0)
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
                                objmodel.BulkPermitId = id;
                                objOperationBulkAppl = _userPemit.GetPermitOperationByBulkId(objmodel);
                                //using (SqlCommand cmd = new SqlCommand())
                                //{
                                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                //    cmd.CommandText = "uspEPermitOperation";

                                //    cmd.Parameters.AddWithValue("@UserID", SessionWrapper.UserId);
                                //    cmd.Parameters.AddWithValue("@Check", 1);
                                //    cmd.Parameters.AddWithValue("@BulkPermitID", BulkpermitId);

                                //using (DataSet ds = objDb.getDataBy_SqlCommand_CB(cmd))
                                //{
                                if (objOperationBulkAppl != null)
                                {
                                    foreach (var app1 in objDetailsAppl.PermitOperationBulkIDLst)
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
                                        if (!(app1.MineralNatureId is null))
                                        {
                                            model.MineralNatureId = Convert.ToInt32(app1.MineralNatureId);
                                        }
                                        model.GeneratedBy = Convert.ToString(app1.GeneratedBy);
                                        model.GeneratedDesignation = Convert.ToString(app1.GeneratedDesignation);
                                        model.IsWalletAdjusted = Convert.ToString(app1.IsWalletAdjusted);

                                        TempData["LeaseTypeId"] = model.LeaseTypeId;

                                        List<ePaymentData> objPaymentList = new List<ePaymentData>();
                                        //if (ds.Tables.Count >= 2)
                                        //{
                                        //    DataTable dtPayment = ds.Tables[1];
                                        //    if (dtPayment != null && dtPayment.Rows.Count > 0)
                                        //    {
                                        //        for (int i = 0; i < dtPayment.Rows.Count; i++)
                                        //        {
                                        foreach (var app2 in objDetailsAppl.PermitPaymentLst)
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
        public JsonResult RevisedCalculation(int? MineralNatureId, int? MineralGradeId, int? MineralId, decimal? Quantity, decimal? RoyaltyRate, int? BulkPermitId, decimal? AluminaContent, decimal? TinContent)
        {
            try
            {
                List<ePaymentData> List = new List<ePaymentData>();
                ePaymentData model = new ePaymentData();
                ePermitModel objmodel = new ePermitModel();
                objmodel.MineralNatureId = MineralNatureId;
                objmodel.MineralGradeID = Convert.ToInt32(MineralGradeId);
                objmodel.MineralId = MineralId;
                objmodel.Quantity = Quantity;
                objmodel.RoyaltyRate = RoyaltyRate;
                objmodel.BulkPermitId = Convert.ToInt32(BulkPermitId);
                objmodel.AluminaContent = AluminaContent;
                objmodel.TinContent = TinContent;
                objmodel.UserCode = "Lessee";//Get data from userlogin
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = Convert.ToInt32(profile.UserId);

                List<ePaymentData> ltePermit = new List<ePaymentData>();
                List = _userPemit.MergeRevisedPayableRoyaltyRate(objmodel);

                for (var i = 0; i < List.Count; i++)
                {
                    model = new ePaymentData();

                    if (Convert.ToString(List[i].MappingCount) == "0")
                    {
                        break;
                    }
                    else
                    {
                        model.PaymentTypeID = Convert.ToString(List[i].PaymentTypeID);
                        model.PaymentType = Convert.ToString(List[i].PaymentType);
                        model.CalType = Convert.ToString(List[i].CalType);
                        model.CalValue = Convert.ToString(List[i].CalValue);
                        model.MappingValue = Convert.ToString(List[i].MappingValue);
                        model.HeadAccount = Convert.ToString(List[i].HeadAccount);


                        if (List[i].IsApplicable != false)
                        {
                            model.IsApplicable = Convert.ToBoolean(List[i].IsApplicable);
                        }
                        else
                        {
                            model.IsApplicable = false;
                        }

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
        public ActionResult AddBulkPermitData(ePermitModel model, string cmdPreview, string cmdTransfer)
        {
            ePermitResult objDetailsAppl = new ePermitResult();
            model.ProposedQty = model.ProposedQty + Convert.ToDecimal(model.RemainingProduction);
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.PaymentStatus = 0;
            // var previewRequest = Convert.ToString(Request["cmdPreview"]);
            if (cmdPreview != null)
            {
                if (model.MineralName.Contains("Coal"))
                {
                    try
                    {

                        objDetailsAppl = _userPemit.GetMineralNatureName(model);

                        if (objDetailsAppl != null && objDetailsAppl.MineralNatureLst.Count > 0)

                        {
                            foreach (var app in objDetailsAppl.MineralNatureLst)
                            {
                                model.MineralName = Convert.ToString(app.MineralName);
                                model.MineralNature = Convert.ToString(app.MineralNature);
                                model.MineralGradeName = Convert.ToString(app.MineralGrade);
                            }
                        }
                        // }
                        // }
                    }
                    catch { }

                    return RedirectToAction("ePermitViewWithoutDSC", "CoalEPermit", new { id = model.BulkPermitId, Area = "ePermit" });
                }
                else
                {
                    return RedirectToAction("ePermitViewWithoutDSC", "BulkPermit", new { id = model.BulkPermitId, Area = "Lessee" });
                }
            }
            else
            {
                //var TransferRequest = Convert.ToString(Request["cmdTransfer"]);
                if (cmdTransfer != null)
                {
                    if (ModelState.IsValid)
                    {
                        if (model.MineralId == 0 || model.MineralNatureId == 0 || model.MineralGradeId == 0)
                        {
                            OutputResult = "3";
                            TempData["Acknowledgement"] = OutputResult;
                            return RedirectToAction("MergeEPermit", "ePermit");
                        }
                        else if (Convert.ToDecimal(model.ProposedQty) > Convert.ToDecimal(model.ProductionCap))
                        {
                            OutputResult = "3";
                            TempData["Acknowledgement"] = OutputResult;
                            return RedirectToAction("MergeEPermit", "ePermit");
                        }
                        else
                        {
                            model.isForwarded = 1;

                            if (model.MineralName.Contains("Coal"))
                            {
                                model.IsCoal = 1;
                                objMSmodel = _userPemit.AddMergeBulkPermit(model);
                                OutputResult = objMSmodel.Satus;
                            }
                            else
                            {

                                objMSmodel = _userPemit.AddMergeBulkPermit(model);
                                OutputResult = objMSmodel.Satus;
                            }
                            if (OutputResult != "-1")
                            {
                                TempData["Acknowledgement"] = OutputResult;
                                return RedirectToAction("MergeEPermit", "ePermit");
                            }
                            else
                            {
                                OutputResult = "2";
                                TempData["Acknowledgement"] = OutputResult;
                                return RedirectToAction("MergeEPermit", "ePermit");
                            }

                        }
                    }
                    else
                    {
                        OutputResult = "3";
                        TempData["Acknowledgement"] = OutputResult;
                        return RedirectToAction("MergeEPermit", "ePermit");
                    }
                }
                else
                {
                    if (model.MineralId == 0 || model.MineralNatureId == 0 || model.MineralNatureId == 0)
                    {
                        OutputResult = "3";
                        TempData["Acknowledgement"] = OutputResult;
                        return RedirectToAction("MergeEPermit", "ePermit");
                    }
                    else
                    {
                        if (model.MineralName.Contains("Coal"))
                        {
                            model.IsCoal = 1;
                            objMSmodel = _userPemit.AddMergeBulkPermit(model);
                            OutputResult = objMSmodel.Satus;
                        }
                        else
                        {
                            objMSmodel = _userPemit.AddMergeBulkPermit(model);
                            OutputResult = objMSmodel.Satus;
                        }
                        if (OutputResult == "-1")
                        {
                            OutputResult = "2";
                            TempData["Acknowledgement"] = OutputResult;
                            return RedirectToAction("MergeEPermit", "ePermit");
                        }
                        else
                        {
                            if (model.isForwarded == 1)
                            {
                                if (model.BulkPermitId != 0)
                                {
                                    return RedirectToAction("MergeEPermitPayment", "ePermit", new { id = model.BulkPermitId });
                                }
                                else
                                {
                                    return RedirectToAction("MergeEPermitPayment", "ePermit", new { id = OutputResult });
                                }
                            }
                            else
                            {
                                TempData["Acknowledgement"] = 1;
                                return RedirectToAction("MergeEPermit", "ePermit");
                            }
                        }
                    }
                }
            }
        }

        public IActionResult ePermitPaymentList(string request, string permittype, string From, string To, string id)
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
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

                modelList = _userPemit.GetApprovedBulkPermitDetails(objmodel);
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
        public IActionResult GeneratePermit()
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
            //objmodel.UserID = 83;
            ViewBag.ePermitType = "GeneratePermit";
            objmodel.permittype = "GeneratePermit";
            try
            {

                modelList = _userPemit.GetApprovedBulkPermitDetails(objmodel);
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
                        model.ForwardedDate = Convert.ToString(modelList[i].ForwardedDate);
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
        public IActionResult GeneratedPermit()
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            PermitWeighBridgeMapp weignbr = new PermitWeighBridgeMapp();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
            weignbr.UserId = Convert.ToInt32(profile.UserId);
            //objmodel.UserID = 83;
            ViewBag.ePermitType = "GeneratedPermit";
            objmodel.permittype = "GeneratedPermit";
            try
            {
                //var weiList = _userPemit.ViewWeighbridge(weignbr);
                //if (weiList.Count > 0)
                //{
                //    ViewBag.ViewWeibr = weiList.Select(c => new SelectListItem
                //    {
                //        Text = c.WeighBridgeName,
                //        Value = c.WeighBridgeId.ToString(),
                //    }).ToList();
                //}
                //else
                //{
                //    ViewBag.ViewWeibr = Enumerable.Empty<SelectListItem>();
                //}
                modelList = _userPemit.GetApprovedBulkPermitDetails(objmodel);
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
                        model.ForwardedDate = Convert.ToString(modelList[i].ForwardedDate);
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
                            model.DSCLesseeFilePath = this.Configuration["DSCReadServer"] + Convert.ToString(modelList[i].LesseeDSCPath);
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
        public IActionResult ArchivedPermit()
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
            //ViewBag.ePermitType = "GeneratePermit";
            //objmodel.permittype = "GeneratePermit";
            //ViewBag.ePermitType = "GeneratedPermit";
            //objmodel.permittype = "GeneratedPermit";
            // ViewBag.ePermitType = "ArchivePermit";
            // objmodel.permittype = "ArchivePermit";
            ViewBag.ePermitType = "ArchivePermit";
            objmodel.permittype = "ArchivePermit";
            try
            {

                modelList = _userPemit.GetApprovedBulkPermitDetails(objmodel);
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
                        model.ForwardedDate = Convert.ToString(modelList[i].ForwardedDate);
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
                    }


                    model.PaymentDetails = objPaymentList;
                }

            }
            catch
            { }
            return View(model);
        }
        #endregion
        [SkipImportantTask]
        public IActionResult ePermitPayment(string BulkpermitId)
        {
            ePermitModel model = new ePermitModel();

            ePermitResult objTotalAppl = new ePermitResult();
            ePermitResult objDetailsAppl = new ePermitResult();
            ePermitResult objOperationAppl = new ePermitResult();
            ePermitResult objOperationBulkAppl = new ePermitResult();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.SubUserID = Convert.ToInt32(profile.SubUserID);
            model.BulkPermitId = Convert.ToInt32(BulkpermitId);
            string UserType = profile.UserType;
            model.UserType = profile.UserType;
            try
            {
                //  ePermitModel model = new ePermitModel();

                if (TempData["result"] != null)
                {
                    ViewBag.DisplayMsg = Convert.ToString(TempData["result"]);
                    ViewBag.ResultMsg = Convert.ToString(TempData["ResultMsg"]);
                }

                if (BulkpermitId == null || Convert.ToInt32(BulkpermitId) == 0)
                {
                    return View(new ePermitModel { });
                }
                else
                {

                    objDetailsAppl = _userPemit.GetPermitTransDetails(model);

                    foreach (var app in objDetailsAppl.PermitOperationBulkIDLst)

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

                        model.Village = Convert.ToString(app.VillageName);
                        if (!string.IsNullOrEmpty(model.Village))
                        {
                            model.Village = Convert.ToString(app.VillageName);
                        }
                        else
                        {
                            model.Village = "Not Mentioned";
                        }


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

                        if (!(app.MINERAL_ID is null))
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

                        string IspayOnline = "NO";
                        List<ePaymentData> objPaymentList = new List<ePaymentData>();

                        foreach (var app1 in objDetailsAppl.PermitPaymentLst)
                        {
                            ePaymentData objPayment = new ePaymentData();
                            objPayment.PaymentType = Convert.ToString(app1.PaymentType);
                            objPayment.IsApplicable = Convert.ToBoolean(app1.IsApplicable);
                            objPayment.ApplicableId = Convert.ToInt32(app1.ApplicableId);
                            if (objPayment.PaymentType == "Royalty" || objPayment.PaymentType == "Paid Royalty" || objPayment.PaymentType == "Monthly Periodic Amount" && objPayment.IsApplicable == true)
                            {
                                objPayment.MakePayementId = 1;
                                objPayment.ApplicableId = 1;
                            }
                            else
                            {
                                objPayment.MakePayementId = Convert.ToInt32(app1.MakePayementId);
                            }
                            if (Convert.ToString(app1.PaymentType) == "Infrastructure & Development Cess")
                            {
                                model.Cess = Convert.ToDecimal(app1.MappingValue);
                            }
                            objPayment.CalType = Convert.ToString(app1.CalType);
                            objPayment.CalValue = Convert.ToString(app1.CalValue);

                            objPayment.MappingValue = Convert.ToString(app1.MappingValue);

                            objPayment.RoyaltyRate = Convert.ToString(app1.RoyaltyRate);
                            objPayment.BasisRate = Convert.ToString(app1.BasicPrice);
                            objPayment.TotalPayableAmount = Convert.ToString(app1.TotalPayableAmount);
                            objPayment.HeadAccount = Convert.ToString(app1.HeadAccount);
                            objPayment.AdjustmentAmount = Convert.ToDecimal(app1.AdjustmentAmount);
                            objPayment.WalletAdjustedAmount = Convert.ToDecimal(app1.WalletAdjustedAmount);
                            objPayment.TotalAmount = Convert.ToString(app1.TotalAmount);
                            objPayment.IsWalletAdjusted = Convert.ToString(app1.IsWalletAdjusted);
                            objPayment.PayDeptId = Convert.ToInt32(app1.PayDeptId);
                            objPayment.OrderNStatus = Convert.ToInt32(app1.OrderNStatus);
                            if (Convert.ToInt32(app1.PayDeptId) == 1)
                            {
                                model.MiningOrder = app1.OrderNo;
                            }
                            else if (Convert.ToInt32(app1.PayDeptId) == 2)
                            {
                                model.IncomeTaxOrder = app1.OrderNo;
                            }
                            else if (Convert.ToInt32(app1.PayDeptId) == 3)
                            {
                                model.EVSOrder = app1.OrderNo;
                            }
                            if (Convert.ToBoolean(app1.IsApplicable) == true)
                            {
                                //totalCheck += Convert.ToDecimal(app1.TotalAmount"]);
                                //adjustCheck += Convert.ToDecimal(app1.AdjustmentAmount"]);
                                if ((Convert.ToDecimal(app1.TotalAmount) > Convert.ToDecimal(app1.AdjustmentAmount)) && IspayOnline == "NO")
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

                return View(model);
            }
            catch (Exception ex)
            {
                return View(new ePermitModel { });
            }

        }
        public IActionResult ePermitOption()
        {
            return View();
        }
        public IActionResult RPTPDashboard()
        {
            return View();
        }
        public IActionResult RPTPPermitList(string request)
        {
            List<LicenseInfoRPTP> PendingRPTP = new List<LicenseInfoRPTP>();
            List<LicenseInfoRPTP> List = new List<LicenseInfoRPTP>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
            //objmodel.UserID = 483;
            //objmodel.SubUserID = 483;
            PendingRPTP = _userPemit.GetRPTPPendingPermitList(objmodel);
            if (PendingRPTP != null && PendingRPTP.Count > 0)
            {
                int cnt = 1;
                for (var i = 0; i < PendingRPTP.Count; i++)
                {
                    LicenseInfoRPTP lst = new LicenseInfoRPTP();
                    lst.MineralId = Convert.ToInt32(PendingRPTP[i].MineralID);
                    lst.MineralName = Convert.ToString(PendingRPTP[i].MineralName);

                    lst.MineralNatureId = Convert.ToInt32(PendingRPTP[i].MineralNatureId);
                    lst.MineralNature = Convert.ToString(PendingRPTP[i].MineralNature);

                    lst.MineralGradeId = Convert.ToInt32(PendingRPTP[i].MineralGradeId);
                    lst.MineralGrade = Convert.ToString(PendingRPTP[i].MineralGrade);

                    lst.AvailableQuantityinStock = Convert.ToDecimal(PendingRPTP[i].TotalQty);
                    List.Add(lst);
                    cnt++;
                }
            }
            ViewBag.ViewList = List;
            return View();

        }
        public IActionResult RPTPPermit(string mineralid, string mineralGradeid, string mineralFormid)
        {
            LicenseInfoRPTP objmodel = new LicenseInfoRPTP();
            LicenseInfoRPTP model = new LicenseInfoRPTP();
            LicenseeRPTPResult objRPTPPermit = new LicenseeRPTPResult();
            LicenseeRPTPResult objRPTPClosingPermit = new LicenseeRPTPResult();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            string UserType = profile.UserType;
            //string UserType = "Licensee";
            //objmodel.UserID = 483;
            objmodel.MineralId = Convert.ToInt32(mineralid);
            objmodel.MineralGradeId = Convert.ToInt32(mineralGradeid);
            objmodel.MineralFormId = Convert.ToInt32(mineralFormid);



            //DataConnection objDb = new DataConnection();
            //DataTable data = new DataTable();
            //DataTable dt = new DataTable();

            try
            {
                if (mineralid != null && mineralGradeid != null && mineralFormid != null)
                {
                    objRPTPPermit = _userPemit.GetLicenseeRPTPPermit(objmodel);
                    objRPTPClosingPermit = _userPemit.GetLicenseeRPTPClosingPermit(objmodel);
                    foreach (var app in objRPTPClosingPermit.RPTPClosingPermitLst)
                    {
                        model.ClosingStock = app.TotalQty;
                        model.AvailableQuantityinStock = app.TotalQty;
                    }
                    foreach (var app1 in objRPTPPermit.RPTPPermitLst)
                    {
                        model.LicenseName = Convert.ToString(app1.ApplicantName);
                        model.Address = Convert.ToString(app1.Address);
                        model.LicenseeCode = Convert.ToString(app1.LicenseeCode);
                        model.ApprovedOn = Convert.ToString(app1.ApprovedOn);
                        model.Village = Convert.ToString(app1.VillageName);
                        model.PoliceStation = Convert.ToString(app1.PoliceStation);
                        model.Tehsil = Convert.ToString(app1.TehsilName);
                        model.District = Convert.ToString(app1.DistrictName);
                        model.State = Convert.ToString(app1.StateName);
                        model.GrantOrderDate = Convert.ToString(app1.GrantOrderDate);
                        model.GrantOrderNo = Convert.ToString(app1.GrantOrderNumber);
                        model.Panchayat = Convert.ToString(app1.Panchayat);
                        model.MineralName = Convert.ToString(app1.MineralName);
                        model.MineralId = app1.MineralID;
                        model.Unit = Convert.ToString(app1.UnitName);
                        model.MineralGradeId = app1.MineralGradeId;
                        model.MineralGrade = Convert.ToString(app1.MineralGrade);
                        model.MineralNatureId = app1.MineralNatureId;
                        model.MineralNature = Convert.ToString(app1.MineralNature);
                        model.PeriodOfLisense = Convert.ToString(app1.PeriodOfLisense);
                    }

                }

            }
            catch (Exception ex)
            {

            }
            return View(model);

        }
        public IActionResult RPTFFinal(string id, string FromDate, string ToDate)
        {
            List<LicenseInfoRPTP> PendingRPTP = new List<LicenseInfoRPTP>();
            List<ListofRPTP> List = new List<ListofRPTP>();
            LicenseInfoRPTP objmodel = new LicenseInfoRPTP();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
            objmodel.UserType = profile.UserType;
            //objmodel.UserID = 483;
            //objmodel.SubUserID = 483;
            //objmodel.UserType = "Licensee";
            ViewBag.ePermitType = Convert.ToString(id);
            TempData["dtFromDate"] = null;
            TempData["dtToDate"] = null;
            objmodel.permittype = Convert.ToString(id);

            objmodel.FromDate = FromDate;
            objmodel.ToDate = ToDate;

            PendingRPTP = _userPemit.GetDGMApprovedRPTPList(objmodel);
            if (PendingRPTP != null && PendingRPTP.Count > 0)
            {
                int cnt = 1;
                for (var i = 0; i < PendingRPTP.Count; i++)
                {
                    ListofRPTP lst = new ListofRPTP();
                    lst.SrNo = cnt;
                    lst.LicenseeCode = Convert.ToString(PendingRPTP[i].LicenseeCode);
                    lst.RPTPBulkPermitId = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].RPTPBulkPermitId)) ? 0 : Convert.ToInt32(PendingRPTP[i].RPTPBulkPermitId);
                    lst.ApplicationNo = Convert.ToString(PendingRPTP[i].BulkApplicationNo);
                    lst.BulkPermitNo = Convert.ToString(PendingRPTP[i].BulkPermitNo);
                    //lst.ApplicationDate = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].CreateOn)) ? "" : Convert.ToDateTime(PendingRPTP[i].CreateOn).ToString("dd/MM/yyyy");
                    lst.ApplicationDate = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].CreateOn)) ? "" : Convert.ToDateTime(PendingRPTP[i].CreateOn, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat).ToString("dd/MM/yyyy");
                    lst.AvailableQty = !string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].AvailableStock)) ? Convert.ToDecimal(PendingRPTP[i].AvailableStock.ToString()) : 0;
                    lst.MineralName = Convert.ToString(PendingRPTP[i].MineralName);
                    lst.MineralGrade = Convert.ToString(PendingRPTP[i].MineralGrade);
                    lst.ProposedQty = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].DispatchedQty)) ? 0 : Convert.ToDecimal(PendingRPTP[i].DispatchedQty);
                    lst.ApprovedQty = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].ApprovedQty)) ? 0 : Convert.ToDecimal(PendingRPTP[i].ApprovedQty);
                    lst.ApprovedOn = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].ApprovedRejectOn)) ? "" : Convert.ToDateTime(PendingRPTP[i].ApprovedRejectOn, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat).ToString("dd/MM/yyyy");
                    lst.Remarks = Convert.ToString(PendingRPTP[i].Remark);
                    lst.Status = "Approved";
                    if (PendingRPTP[i].DSCFilePath == null || PendingRPTP[i].DSCFilePath.ToString() == "")
                    {
                        lst.DSCLesseeFilePath = "";
                    }
                    else
                    {
                        lst.DSCLesseeFilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(PendingRPTP[i].DSCFilePath);
                    }
                    List.Add(lst);
                    cnt++;
                }
            }
            ViewBag.ViewList = List;
            return View(objmodel);

        }
        public IActionResult RPTPSavedPermit(string FromDate, string ToDate)
        {
            List<LicenseInfoRPTP> PendingRPTP = new List<LicenseInfoRPTP>();
            List<ListofRPTP> List = new List<ListofRPTP>();
            LicenseInfoRPTP objmodel = new LicenseInfoRPTP();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
            objmodel.UserType = profile.UserType;
            //objmodel.UserID = 483;
            //objmodel.SubUserID = 483;
            //objmodel.UserType = "Licensee";
            ViewBag.ePermitType = "GeneratePermit";
            TempData["dtFromDate"] = null;
            TempData["dtToDate"] = null;
            objmodel.permittype = "GeneratePermit";

            objmodel.FromDate = FromDate;
            objmodel.ToDate = ToDate;

            PendingRPTP = _userPemit.GetDGMApprovedRPTPList(objmodel);
            if (PendingRPTP != null && PendingRPTP.Count > 0)
            {
                int cnt = 1;
                for (var i = 0; i < PendingRPTP.Count; i++)
                {
                    ListofRPTP lst = new ListofRPTP();
                    lst.SrNo = cnt;
                    lst.LicenseeCode = Convert.ToString(PendingRPTP[i].LicenseeCode);
                    lst.RPTPBulkPermitId = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].RPTPBulkPermitId)) ? 0 : Convert.ToInt32(PendingRPTP[i].RPTPBulkPermitId);
                    lst.ApplicationNo = Convert.ToString(PendingRPTP[i].BulkApplicationNo);
                    lst.BulkPermitNo = Convert.ToString(PendingRPTP[i].BulkPermitNo);
                    //lst.ApplicationDate = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].CreateOn)) ? "" : Convert.ToDateTime(PendingRPTP[i].CreateOn).ToString("dd/MM/yyyy");
                    lst.ApplicationDate = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].CreateOn)) ? "" : Convert.ToDateTime(PendingRPTP[i].CreateOn, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat).ToString("dd/MM/yyyy");
                    lst.AvailableQty = !string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].AvailableStock)) ? Convert.ToDecimal(PendingRPTP[i].AvailableStock.ToString()) : 0;
                    lst.MineralName = Convert.ToString(PendingRPTP[i].MineralName);
                    lst.MineralGrade = Convert.ToString(PendingRPTP[i].MineralGrade);
                    lst.ProposedQty = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].DispatchedQty)) ? 0 : Convert.ToDecimal(PendingRPTP[i].DispatchedQty);
                    lst.ApprovedQty = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].ApprovedQty)) ? 0 : Convert.ToDecimal(PendingRPTP[i].ApprovedQty);
                    lst.ApprovedOn = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].ApprovedRejectOn)) ? "" : Convert.ToDateTime(PendingRPTP[i].ApprovedRejectOn, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat).ToString("dd/MM/yyyy");
                    lst.Remarks = Convert.ToString(PendingRPTP[i].Remark);
                    lst.Status = "Approved";
                    if (PendingRPTP[i].DSCFilePath == null || PendingRPTP[i].DSCFilePath.ToString() == "")
                    {
                        lst.DSCLesseeFilePath = "";
                    }
                    else
                    {
                        lst.DSCLesseeFilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(PendingRPTP[i].DSCFilePath);
                    }
                    List.Add(lst);
                    cnt++;
                }
            }
            ViewBag.ViewList = List;
            return View(objmodel);

        }
        public IActionResult RPTPGeneratedPermit(string FromDate, string ToDate)
        {
            List<LicenseInfoRPTP> PendingRPTP = new List<LicenseInfoRPTP>();
            List<ListofRPTP> List = new List<ListofRPTP>();
            LicenseInfoRPTP objmodel = new LicenseInfoRPTP();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
            objmodel.UserType = profile.UserType;
            //objmodel.UserID = 483;
            //objmodel.SubUserID = 483;
            //objmodel.UserType = "Licensee";
            ViewBag.ePermitType = "GeneratedPermit";
            TempData["dtFromDate"] = null;
            TempData["dtToDate"] = null;
            objmodel.permittype = "GeneratedPermit";

            objmodel.FromDate = FromDate;
            objmodel.ToDate = ToDate;

            PendingRPTP = _userPemit.GetDGMApprovedRPTPList(objmodel);
            if (PendingRPTP != null && PendingRPTP.Count > 0)
            {
                int cnt = 1;
                for (var i = 0; i < PendingRPTP.Count; i++)
                {
                    ListofRPTP lst = new ListofRPTP();
                    lst.SrNo = cnt;
                    lst.LicenseeCode = Convert.ToString(PendingRPTP[i].LicenseeCode);
                    lst.RPTPBulkPermitId = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].RPTPBulkPermitId)) ? 0 : Convert.ToInt32(PendingRPTP[i].RPTPBulkPermitId);
                    lst.ApplicationNo = Convert.ToString(PendingRPTP[i].BulkApplicationNo);
                    lst.BulkPermitNo = Convert.ToString(PendingRPTP[i].BulkPermitNo);
                    //lst.ApplicationDate = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].CreateOn)) ? "" : Convert.ToDateTime(PendingRPTP[i].CreateOn).ToString("dd/MM/yyyy");
                    lst.ApplicationDate = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].CreateOn)) ? "" : Convert.ToDateTime(PendingRPTP[i].CreateOn, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat).ToString("dd/MM/yyyy");
                    lst.AvailableQty = !string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].AvailableStock)) ? Convert.ToDecimal(PendingRPTP[i].AvailableStock.ToString()) : 0;
                    lst.MineralName = Convert.ToString(PendingRPTP[i].MineralName);
                    lst.MineralGrade = Convert.ToString(PendingRPTP[i].MineralGrade);
                    lst.ProposedQty = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].DispatchedQty)) ? 0 : Convert.ToDecimal(PendingRPTP[i].DispatchedQty);
                    lst.ApprovedQty = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].ApprovedQty)) ? 0 : Convert.ToDecimal(PendingRPTP[i].ApprovedQty);
                    lst.ApprovedOn = string.IsNullOrEmpty(Convert.ToString(PendingRPTP[i].ApprovedRejectOn)) ? "" : Convert.ToDateTime(PendingRPTP[i].ApprovedRejectOn, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat).ToString("dd/MM/yyyy");
                    lst.Remarks = Convert.ToString(PendingRPTP[i].Remark);
                    lst.Status = "Approved";
                    if (PendingRPTP[i].DSCFilePath == null || PendingRPTP[i].DSCFilePath.ToString() == "")
                    {
                        lst.DSCLesseeFilePath = "";
                    }
                    else
                    {
                        lst.DSCLesseeFilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(PendingRPTP[i].DSCFilePath);
                    }
                    List.Add(lst);
                    cnt++;
                }
            }
            ViewBag.ViewList = List;
            return View(objmodel);

        }

        [HttpPost]
        public IActionResult RPTPPermit(LicenseInfoRPTP model, string cmdPreview)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.SubUserID = Convert.ToInt32(profile.SubUserID);
            model.UserType = profile.UserType;
            //model.UserID = 483;
            //model.SubUserID = 483;
            //model.UserType = "Licensee";
            try
            {

                //if (ModelState.IsValid)
                //{
                int rptpid = 0;
                var previewRequest = Convert.ToString(cmdPreview);
                if (previewRequest != null)
                {
                    return View("RPTPPreview", model);
                }
                objMSmodel = _userPemit.AddRPTPBulkPermit(model);
                OutputResult = objMSmodel.Satus;
                if (OutputResult != null && !string.IsNullOrEmpty(Convert.ToString(OutputResult)))
                {
                    rptpid = Convert.ToInt32(OutputResult);
                    // TempData["SuccMessage"] = "Applicaation of RPTP has been saved successfully.";
                }
                else
                {
                    rptpid = Convert.ToInt32(model.BultPermitId);
                    if (model.isForwarded == 1)
                    {
                        TempData["SuccMessage"] = "Application of RPTP has been saved successfully.";
                    }
                    else
                    {
                        TempData["SuccMessage"] = " Application of RPTP has been forwarded successfully.";
                    }
                }
                if (model.DSCResponse == null || model.DSCResponse == "")
                {
                    if (TempData["DSCResponse"] != null && TempData["DSCResponse"].ToString() != "")
                        model.DSCResponse = TempData["DSCResponse"].ToString();

                }
                if (model.DSCResponse != "" && model.DSCResponse != null)
                {
                    // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    // objDSCResponse.getDSCResponse(model.DSCResponse, "RPTP-SAVE", rptpid); // Response, For which purpose DSC Used , Return ID
                }
                //END

                TempData.Keep();
                var mobile = "";
                var email = "";
                var TransactionId = "";


                return RedirectToAction("RPTPPreview", new { BulkPermitId = rptpid });
                //}
                //else
                //{
                //    return View(model);
                //}
                // var Retmodel = objRepository.getRPTPLicencee();
                //return View(Retmodel);

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult RPTPPreview(int? BulkPermitId)
        {
            List<LicenseInfoRPTP> RPTPdtls = new List<LicenseInfoRPTP>();
            List<ListofRPTP> List = new List<ListofRPTP>();
            LicenseInfoRPTP model = new LicenseInfoRPTP();
            LicenseInfoRPTP objmodel = new LicenseInfoRPTP();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
            objmodel.UserType = profile.UserType;
            ////objmodel.UserID = 483;
            ////objmodel.SubUserID = 483;
            //objmodel.UserType = "Licensee";
            objmodel.RPTPBulkPermitId = BulkPermitId;


            RPTPdtls = _userPemit.getRPTPDetails(objmodel);
            if (RPTPdtls != null && RPTPdtls.Count > 0)
            {
                int cnt = 1;
                for (var i = 0; i < RPTPdtls.Count; i++)
                {
                    if (profile.UserType.ToString() == "Licensee")
                    {
                        model.BultPermitId = string.IsNullOrEmpty(Convert.ToString(RPTPdtls[i].RPTPBulkPermitId)) ? 0 : Convert.ToInt32(RPTPdtls[i].RPTPBulkPermitId);
                    }
                    else if (profile.UserType.ToString() == "End User")
                    {
                        model.BultPermitId = string.IsNullOrEmpty(Convert.ToString(RPTPdtls[i].EndUser_RPTPBulkPermitId)) ? 0 : Convert.ToInt32(RPTPdtls[i].EndUser_RPTPBulkPermitId);
                    }
                    model.BulkPermitNo = Convert.ToString(RPTPdtls[i].BulkPermitNo);
                    model.LicenseId = Convert.ToInt32(RPTPdtls[i].UserId);
                    model.LicenseName = Convert.ToString(RPTPdtls[i].ApplicantName);
                    model.Address = Convert.ToString(RPTPdtls[i].Address);
                    model.LicenseNumber = Convert.ToString(RPTPdtls[i].LicenseeCode);
                    model.LicenseDate = string.IsNullOrEmpty(Convert.ToString(RPTPdtls[i].ApprovedOn)) ? "" : Convert.ToDateTime(RPTPdtls[i].ApprovedOn).ToString("MM/dd/yyyy");
                    model.Tehsil = Convert.ToString(RPTPdtls[i].TehsilName);
                    model.Village = Convert.ToString(RPTPdtls[i].VillageName);
                    model.PoliceStation = Convert.ToString(RPTPdtls[i].PoliceStation);
                    //model.Panchayat = Convert.ToString(RPTPdtls[i]VillageName);
                    model.Panchayat = Convert.ToString(RPTPdtls[i].Panchayat);
                    model.District = Convert.ToString(RPTPdtls[i].DistrictName);
                    //if (RPTPdtls.AsEnumerable().Select(r=>r.Fi))
                    //{
                    //    model.State = Convert.ToString(RPTPdtls[i].StateName);
                    //}
                    model.MineralId = string.IsNullOrEmpty(Convert.ToString(RPTPdtls[i].MineralId)) ? 0 : Convert.ToInt32(RPTPdtls[i].MineralId);
                    model.MineralName = Convert.ToString(RPTPdtls[i].MineralName);
                    model.MineralGradeId = string.IsNullOrEmpty(Convert.ToString(RPTPdtls[i].MineralGradeId)) ? 0 : Convert.ToInt32(RPTPdtls[i].MineralGradeId);
                    model.MineralGrade = Convert.ToString(RPTPdtls[i].MineralGrade);
                    model.MineralNature = Convert.ToString(RPTPdtls[i].MineralNature);
                    model.AvailableQuantityinStock = string.IsNullOrEmpty(Convert.ToString(RPTPdtls[i].AvailableStock)) ? 0 : Convert.ToDecimal(RPTPdtls[i].AvailableStock);
                    model.QuantitytobeDispatched = string.IsNullOrEmpty(Convert.ToString(RPTPdtls[i].DispatchedQty)) ? 0 : Convert.ToDecimal(RPTPdtls[i].DispatchedQty);
                    model.FromDate = string.IsNullOrEmpty(Convert.ToString(RPTPdtls[i].FromDate)) ? "" : Convert.ToDateTime(RPTPdtls[i].FromDate).ToString("MM/dd/yyyy");
                    model.ToDate = string.IsNullOrEmpty(Convert.ToString(RPTPdtls[i].ToDate)) ? "" : Convert.ToDateTime(RPTPdtls[i].ToDate).ToString("MM/dd/yyyy");
                    model.ApprovedQty = string.IsNullOrEmpty(Convert.ToString(RPTPdtls[i].DispatchedQty)) ? 0 : Convert.ToDecimal(RPTPdtls[i].DispatchedQty);
                    model.Unit = Convert.ToString(RPTPdtls[i].Unit);
                    model.TypeOfCoalTobeDispatch = Convert.ToString(RPTPdtls[i].TypeOfCoalTobeDispatch);
                    model.TypeOfCoal = Convert.ToString(RPTPdtls[i].TypeOfCoal);
                    //model.UserTypeId = SessionWrapper.UserTypeId;
                    model.isForwarded = Convert.ToInt32(RPTPdtls[i].isForwarded);
                    model.PeriodOfLisense = Convert.ToString(RPTPdtls[i].PeriodOfLisense);
                    model.GrantOrderDate = Convert.ToString(RPTPdtls[i].GrantOrderDate);
                    model.GrantOrderNo = Convert.ToString(RPTPdtls[i].GrantOrderNo);

                    if (RPTPdtls[i].DSCLesseeFilePath == null || RPTPdtls[i].DSCLesseeFilePath.ToString() == "")
                    {
                        model.DSCLesseeFilePath = "";
                    }
                    else
                    {
                        model.DSCLesseeFilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(RPTPdtls[i].DSCLesseeFilePath);
                    }
                }
                //        var model = objRepository.getRPTPDetails(BulkPermitId);
                //model.UserType = SessionWrapper.UserType;
                //model.Mineral = SessionWrapper.MineralName;


            }
            return View(model);
        }
        //#region Archive Permit
        public JsonResult ArchivePermit(int? BulkPermitId)
        {
            ePermitModel model = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.BulkPermitId = Convert.ToInt32(BulkPermitId);
            model.permittype = "ArchivePermit";
            try
            {

                objMSmodel = _userPemit.ArchviveUnArchivePermit(model);
                OutputResult = objMSmodel.Satus;
                return Json(OutputResult);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public JsonResult UnArchivePermit(int? BulkPermitId)
        {
            ePermitModel model = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.BulkPermitId = Convert.ToInt32(BulkPermitId);
            model.permittype = "UnArchivePermit";
            try
            {
                objMSmodel = _userPemit.ArchviveUnArchivePermit(model);
                OutputResult = objMSmodel.Satus;
                return Json(OutputResult);
            }
            catch (Exception)
            {
                return null;
            }
        }
        //#endregion
        /// <summary>
        /// Merge Permit payment option
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public ActionResult MergeEPermitPayment(string id)
        {
            ePermitModel objmodel = new ePermitModel();

            ePermitResult objTotalAppl = new ePermitResult();
            ePermitResult objDetailsAppl = new ePermitResult();
            ePermitResult objOperationAppl = new ePermitResult();
            ePermitResult objOperationBulkAppl = new ePermitResult();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.SubUserID = Convert.ToInt32(profile.SubUserID);
            objmodel.BulkPermitId = Convert.ToInt32(id);
            objmodel.UserType = profile.UserType;

            objDetailsAppl = _userPemit.CheckMergePermitDetails(objmodel);


            if (objDetailsAppl != null && objDetailsAppl.PermitOperationLst.Count > 0)
            {
                try
                {
                    ePermitModel model = new ePermitModel();

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
                        objOperationAppl = _userPemit.GetMergePermitTransDetails(objmodel);
                        if (objOperationAppl != null)
                        {
                            foreach (var app in objOperationAppl.DetailsPermitLstByUserID)

                            {

                                model.TransactionalID = Convert.ToString(app.TransactionalID);
                                model.MobileNo = Convert.ToString(app.MobileNo);
                                model.EmailId = Convert.ToString(app.EMailId);
                                model.LesseeName = Convert.ToString(app.ApplicantName);
                                model.LesseeAddress = Convert.ToString(app.Address);
                                if (!(app.DistrictId == null))
                                {
                                    model.DistrictId = Convert.ToInt32(app.DistrictId);
                                }
                                model.District = Convert.ToString(app.DistrictName);
                                model.DistrictCode = Convert.ToString(app.DistrictCode);
                                if (!(app.TehsilID == null))
                                {
                                    model.TehsilId = Convert.ToInt32(app.TehsilID);
                                }
                                model.Tehsil = Convert.ToString(app.TehsilName);
                                if (!(app.VILLAGE_ID == null))
                                {
                                    model.VillageId = Convert.ToInt32(app.VILLAGE_ID);
                                }
                                model.Village = Convert.ToString(app.VillageName);
                                model.GrantOrderNo = Convert.ToString(app.GrantOrderNumber);
                                model.DateOfGrant = Convert.ToString(app.GrantOrderDate);
                                if (!(app.MINERAL_ID == null))
                                {
                                    model.MineralId = Convert.ToInt32(app.MINERAL_ID);
                                }
                                model.MineralName = Convert.ToString(app.MineralName);
                                if (!(app.MINERAL_GRADE_ID == null))
                                {
                                    model.MineralGradeId = Convert.ToInt32(app.MINERAL_GRADE_ID);
                                }
                                model.MineralGradeName = Convert.ToString(app.MineralGrade);
                                model.MineralNature = Convert.ToString(app.MineralNature);
                                if (!(app.UnitId == null))
                                {
                                    model.UnitId = Convert.ToInt32(app.UnitId);
                                }
                                model.UnitName = Convert.ToString(app.UnitName);
                                model.RoyaltyRate = Convert.ToDecimal(app.RoyaltyRate);
                                model.PeriodOfLeaseFrom = Convert.ToString(app.PROSPECTING_VALIDITY_FROM);
                                model.PeriodOfLeaseTo = Convert.ToString(app.PROSPECTING_VALIDITY_TO);
                                model.PeriodOfLease = Convert.ToString(app.PeriodOfLease);
                                if (!(app.LeaseTypeId == null))
                                {
                                    model.LeaseTypeId = Convert.ToInt32(app.LeaseTypeId);
                                }
                                model.LeaseTypeName = Convert.ToString(app.LeaseTypeName);
                                //if (!(app.BulkPermitId == ))
                                // {
                                model.BulkPermitId = Convert.ToInt32(app.BulkPermitId);
                                //}
                                if (!(app.TCS == null))
                                {
                                    model.TCS = Convert.ToDecimal(app.TCS);
                                }
                                if (!(app.Cess == null))
                                {
                                    model.Cess = Convert.ToDecimal(app.Cess);
                                }
                                if (!(app.eCess == null))
                                {
                                    model.eCess = Convert.ToDecimal(app.eCess);
                                }
                                if (!(app.DMF == null))
                                {
                                    model.DMF = Convert.ToDecimal(app.DMF);
                                }
                                //if (!(app.NMET == null))
                                //{
                                model.NMET = Convert.ToDecimal(app.NMET);
                                //  }
                                if (!(app.PayableRoyalty == null))
                                {
                                    model.PayableRoyalty = Convert.ToDecimal(app.PayableRoyalty);
                                }
                                //if (!(app.TotalPayableAmount == null))
                                //{
                                model.TotalPayableAmount = Convert.ToDecimal(app.TotalPayableAmount);
                                // }
                                if (!(app.ProposedQty == null))
                                {
                                    model.ProposedQty = Convert.ToDecimal(app.ProposedQty);
                                }
                                if (!(app.ApprovedQty == null))
                                {
                                    model.ApprovedQty = Convert.ToDecimal(app.ApprovedQty);
                                }
                                if (!(app.ActiveStatus == null))
                                {
                                    model.ActiveStatus = Convert.ToInt32(app.ActiveStatus);
                                }
                                if (!(app.PaymentStatus == null))
                                {
                                    model.PaymentStatus = Convert.ToInt32(app.PaymentStatus);
                                }
                                model.PoliceStation = Convert.ToString(app.POLICE_STATION);
                                model.Panchayat = Convert.ToString(app.GRAM_PANCHAYAT);

                                model.GeneratedBy = Convert.ToString(app.GeneratedBy);
                                model.GeneratedDesignation = Convert.ToString(app.GeneratedDesignation);

                                model.ChallanNumber = Convert.ToString(app.ChallanNumber);
                                model.ChallanDate = Convert.ToString(app.ChallanDate);
                                model.ChallanFileName = Convert.ToString(app.ChallanCopyPath);
                                model.EAuctionType = Convert.ToString(app.EAuctionType.ToString());
                                model.TillDateBalanceUpfrontPayment = !string.IsNullOrEmpty(app.TillDateBalanceUpfrontPayment.ToString()) ? Convert.ToDecimal(app.TillDateBalanceUpfrontPayment) : 0;

                                model.ISAdjustmentCess = (app.ISAdjustmentCess == null) ? 0 : Convert.ToInt32(app.ISAdjustmentCess);

                                if (!string.IsNullOrEmpty(model.ChallanFileName))
                                {
                                    model.ChallanCopyFilePath = model.ChallanFileName.Replace("PaymentDocuments", string.Empty).Replace(model.TransactionalID, "").Replace("\\_", "");
                                }

                                TempData["LeaseTypeId"] = model.LeaseTypeId;

                                //decimal totalCheck = 0;
                                //decimal adjustCheck = 0;
                                string IspayOnline = "NO";
                                List<ePaymentData> objPaymentList = new List<ePaymentData>();
                                foreach (var app1 in objOperationAppl.PermitPaymentLst)
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
                                    objPayment.AdjustmentAmount = Convert.ToDecimal(app1.AdjustmentAmount);
                                    objPayment.TotalAmount = Convert.ToString(app1.TotalAmount);

                                    objPayment.IsWalletAdjusted = Convert.ToString(app1.IsWalletAdjusted);

                                    if (Convert.ToBoolean(app1.IsApplicable) == true)
                                    {
                                        //totalCheck += Convert.ToDecimal(app1.TotalAmount);
                                        //adjustCheck += Convert.ToDecimal(app1.AdjustmentAmount);
                                        if ((Convert.ToDecimal(app1.TotalAmount) > Convert.ToDecimal(app1.AdjustmentAmount)) && IspayOnline == "NO")
                                        {
                                            IspayOnline = "YES";
                                        }
                                    }

                                    objPaymentList.Add(objPayment);

                                    //  }


                                    if ((!(app1.IsWalletAdjusted == null) && Convert.ToString(app1.IsWalletAdjusted) == "0") || IspayOnline == "YES")
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

                                }

                                // }


                                //if (totalCheck > adjustCheck)
                                //{
                                //    TempData["Adjustment"] = "NO";
                                //}
                                //else
                                //{
                                //    TempData["Adjustment"] = "YES";
                                //}
                                model.PaymentDetails = objPaymentList;

                                return View(model);

                            }
                        }
                        //}
                        //}
                    }

                    return View(model);
                }
                catch (Exception)
                {
                    return View(new ePermitModel { });
                }
            }
            else
            {
                return RedirectToAction("ValidityExpired", "ValidityExpired", new { Area = "" });
            }
        }
        /// <summary>
        /// Rider configuration master
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [SkipImportantTask]
        public ActionResult RiderConfigMaster(string id)
        {
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ePermitResult objDetailsAppl = new ePermitResult();
            List<ePermitModel> lst = new List<ePermitModel>();
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
            //objmodel.UserID = 1;

            var distLst = _userPayment.FillDistrict(objmodel);
            if (distLst.DistrictLst != null)
            {
                ViewBag.ViewDistrictList = distLst.DistrictLst.Select(c => new SelectListItem
                {
                    Text = c.DistrictName,
                    Value = c.DistrictId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewDistrictList = Enumerable.Empty<SelectListItem>();
            }

            var x = _userPemit.FillState(objmodel);
            if (x.StateLst != null)
            {
                ViewBag.ViewStateList = x.StateLst.Where(s => s.StateName.Contains("Chhattisgarh")).Select(c => new SelectListItem
                {
                    Text = c.StateName,
                    Value = c.StateID.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewStateList = Enumerable.Empty<SelectListItem>();
            }

            var y = _userPemit.FillModuleType(objmodel);
            if (y.ModuleTypeLst != null)
            {
                ViewBag.ViewModuleTypeList = y.ModuleTypeLst.Select(c => new SelectListItem
                {
                    Text = c.ModuleName,
                    Value = c.ModuleId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewModuleTypeList = Enumerable.Empty<SelectListItem>();
            }
            var z = _userPemit.FillUserType(objmodel);
            if (z.UserTypeLst != null)
            {
                ViewBag.ViewUserTypeList = z.UserTypeLst.Where(s => s.UserType == "Lessee" || s.UserType == "Tailing Dam" || s.UserType == "Licensee" || s.UserType == "End User").Select(c => new SelectListItem
                {
                    Text = c.UserType,
                    Value = c.UserTypeId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewUserTypeList = Enumerable.Empty<SelectListItem>();
            }
            if (Convert.ToInt32(id) == 0)
            {
                objmodel.StateID = 7;
                objmodel.RiderType = 2;
                ViewBag.ViewSubModuleTypeList = Enumerable.Empty<SelectListItem>();
                ViewBag.ViewUserNameList = Enumerable.Empty<SelectListItem>();
                ViewBag.Button = "Submit";


            }
            else
            {
                objmodel.RiderConfigId = Convert.ToInt32(id);

                objDetailsAppl = _userPemit.EditRiderConfigMaster(objmodel);
                if (objDetailsAppl != null && objDetailsAppl.RiderLst.Count > 0)
                {
                    foreach (var app in objDetailsAppl.RiderLst)
                    {
                        objmodel.StateID = (app.StateID);
                        var xx = _userPemit.FillDistrict(objmodel);
                        xx.DistrictLst.Insert(0, new ePermitModel { DistrictId = 0, DistrictName = "All" });

                        if (xx.DistrictLst != null)
                        {
                            ViewBag.ViewDistrictList = xx.DistrictLst.Select(c => new SelectListItem
                            {
                                Text = c.DistrictName,
                                Value = c.DistrictId.ToString(),
                            }).ToList();
                        }
                        else
                        {
                            ViewBag.ViewDistrictList = Enumerable.Empty<SelectListItem>();
                        }
                        objmodel.ModuleId = app.ModuleId;
                        var flSubModule = _userPemit.FillSubModuleType(objmodel);
                        if (flSubModule.SubModuleTypeLst != null)
                        {
                            ViewBag.ViewSubModuleTypeList = flSubModule.SubModuleTypeLst.Select(c => new SelectListItem
                            {
                                Text = c.SubModuleName,
                                Value = c.SubModuleId.ToString(),
                            }).ToList();
                        }
                        else
                        {
                            ViewBag.ViewSubModuleTypeList = Enumerable.Empty<SelectListItem>();
                        }
                        objmodel.RiderConfigId = (app.RiderConfigId);
                        //objmodel.StateID = (app.StateID);
                        objmodel.DistrictId = (app.DistrictId);
                        objmodel.UserTypeId = (app.UserTypeId);
                        objmodel.SubModuleId = app.SubModuleId;
                        objmodel.RiderType = app.RiderType;
                        objmodel.MineralTypeId = app.MineralTypeId;

                        var flLessee = _userPayment.FillUserName(objmodel);
                        if (flLessee.UserList != null)
                        {
                            ViewBag.ViewUserNameList = flLessee.UserList.Select(c => new SelectListItem
                            {
                                Text = c.ApplicantName + "/UserId-" + c.LesseeId.ToString(),
                                Value = c.LesseeId.ToString(),
                            }).ToList();
                        }
                        else
                        {
                            ViewBag.ViewUserNameList = Enumerable.Empty<SelectListItem>();
                        }
                        objmodel.LesseeId = app.LesseeId;
                        lst.Add(objmodel);
                    }

                }
                ViewBag.Button = "Update";
                return View(objmodel);
            }

            return View(objmodel);
        }
        /// <summary>
        /// Save Rider config
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult RiderConfigMaster(ePermitModel model)
        {
            //ePermitModel objPermit = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 1;

            objMSmodel = _userPemit.AddRiderConfigMaster(model);
            OutputResult = objMSmodel.Satus;
            if (OutputResult == "1")
            {
                TempData["SuccMessage"] = "Rider configuration master has been saved successfully.";
                return RedirectToAction("RiderConfigMasterView");
            }
            else if (OutputResult == "2")
            {
                TempData["SuccMessage"] = "Rider configuration master has been updated successfully.";
                return RedirectToAction("RiderConfigMasterView");
            }
            else if (OutputResult == "3")
            {
                TempData["SuccMessage"] = "Duplicate record found.";
                return RedirectToAction("RiderConfigMaster");
            }
            else if (OutputResult == "4")
            {
                TempData["SuccMessage"] = "Duplicate record found.";
                return RedirectToAction("RiderConfigMasterView");
            }

            return View();
        }
        public ActionResult RiderConfigMasterView()
        {
            List<ePermitModel> RiderConfigList = new List<ePermitModel>();
            //List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            //objmodel.UserID = 1;
            RiderConfigList = _userPemit.ViewRiderConfigMaster(objmodel);

            //Commented by priyabrat das

            //if (RiderConfigList != null && RiderConfigList.Count > 0)
            //{
            //    int cnt = 1;
            //    for (var i = 0; i < RiderConfigList.Count; i++)
            //    {
            //        ePermitModel lst = new ePermitModel();
            //        lst.RiderConfigId = (RiderConfigList[i].RiderConfigId);
            //        lst.StateName = (RiderConfigList[i].StateName);
            //        lst.DistrictName = (RiderConfigList[i].DistrictName);
            //        lst.UserType = (RiderConfigList[i].UserType);
            //        lst.ModuleName = RiderConfigList[i].ModuleName;
            //        lst.SubModuleName = RiderConfigList[i].SubModuleName;
            //        lst.CheckListDescription = RiderConfigList[i].CheckListDescription;
            //        lst.CheckListId = RiderConfigList[i].CheckListId;
            //        lst.ApplicantName = RiderConfigList[i].ApplicantName;
            //        lst.RiderTypeName = RiderConfigList[i].RiderTypeName;
            //        lst.MineralName = RiderConfigList[i].MineralName;
            //        List.Add(lst);
            //        cnt++;
            //    }
            //}
            ViewBag.ViewList = RiderConfigList;
            return View();
        }
        public JsonResult GetUserName(int UserTypeId, int DistrictId, int Configtype)
        {
            if (Configtype == 2)
            {
                ePermitModel objPermit = null;
                try
                {
                    objPermit = new ePermitModel();
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    //objPermit.UserID = Convert.ToInt32(profile.UserId);
                    //objPermit.UserID = 1;
                    objPermit.UserTypeId = UserTypeId;
                    objPermit.DistrictId = DistrictId;
                    var x = _userPayment.FillUserName(objPermit);

                    var SList = x.UserList.ToList();
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
            else
            {
                return Json(null);
            }

        }
        public JsonResult GetSubModule(int ModuleId)
        {
            ePermitModel objPermit = null;
            try
            {
                objPermit = new ePermitModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objPermit.UserID = Convert.ToInt32(profile.UserId);
                //objPermit.UserID = 1;
                objPermit.ModuleId = ModuleId;
                var x = _userPemit.FillSubModuleType(objPermit);

                var SList = x.SubModuleTypeLst.ToList();
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
        public JsonResult GetCheckListData(int ModuleId, int RiderConfigId, int SubModuleId)

        {
            try
            {
                ePermitModel objPermit = null;
                objPermit = new ePermitModel();
                List<ePermitModel> Checklist = new List<ePermitModel>();
                // List<ChecklistModel> Checklist = new List<ChecklistModel>();
                objPermit.ModuleId = ModuleId;
                objPermit.RiderConfigId = RiderConfigId;
                objPermit.SubModuleId = SubModuleId;
                Checklist = _userPemit.GetCheckListData(objPermit);
                ViewBag.CheckListData = Checklist.ToList();
                return Json(Checklist);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Delete DeleteRiderConfigMaster 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [SkipImportantTask]
        public IActionResult DeleteRiderConfigMaster(string id)
        {
            ePermitModel objmodel = new ePermitModel();
            List<ePermitModel> List = new List<ePermitModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            //objmodel.UserID = 1;
            if (id != null)
            {

                objmodel.RiderConfigId = Convert.ToInt32(id);
                objMSmodel = _userPemit.DeleteRiderConfigMaster(objmodel);
                OutputResult = objMSmodel.Satus;
                if (OutputResult == "1")
                {
                    TempData["SuccMessage"] = "Rider configuration master has been deleted successfully.";
                    return RedirectToAction("RiderConfigMasterView");
                }
            }
            return View();

        }

        public ActionResult ePermitRequiredFields()
        {
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            List<ePermitModel> lstData = new List<ePermitModel>();
            List<ePermitModel> lst = new List<ePermitModel>();
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            //objmodel.UserID = 103;
            lstData = _userPemit.GetTotalPermitByUser(objmodel);
            if (lstData != null)
            {
                foreach (var app in lstData)
                {
                    if (Convert.ToString(app.AuctionTypeId) == "2")
                    {
                        ViewBag.WithAuction = true;
                    }
                    else
                    {
                        ViewBag.WithAuction = false;
                    }

                    ViewBag.UpfrontPaymentDeposited = Convert.ToDecimal(app.UpfrontPaymentDeposited).ToString("0.00");
                    ViewBag.ProductionCap = Convert.ToDecimal(app.ProductionCap).ToString("0.00");
                    ViewBag.LastDate = Convert.ToString(app.LastDate);
                    ViewBag.ApprovedUpfrontPayment = Convert.ToDecimal(app.TillDateBalanceUpfrontPayment).ToString("0.00");
                    ViewBag.PermittedQty = Convert.ToDecimal(app.PermittedQty).ToString("0.00");
                    ViewBag.TillDateDispatched = Convert.ToDecimal(app.TillDateDispatched).ToString("0.00");




                }

            }
            else
            {
                ViewBag.WithAuction = false;
            }
            return View();
        }
        [HttpPost]
        public ActionResult ePermitRequiredFields(ePermitModel model)
        {
            //ePermitModel objPermit = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 103;

            objMSmodel = _userPemit.AddTotalPermitByUser(model);
            OutputResult = objMSmodel.Satus;
            return RedirectToAction("PaymentConfigCheck", "PaymentConfig", new { Area = "Permit" });
            //if (OutputResult == "1")
            //{
            //    return RedirectToAction("PaymentConfigCheck", "PaymentConfig", new { Area = "Permit" });
            //}
            //return View();

        }

    }
}