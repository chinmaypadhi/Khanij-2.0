using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermitApp.Areas.Permit.Models.MergePermit;
using PermitApp.Areas.Permit.Models.Lessee;
using PermitEF;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using PermitApp.Helper;
using PermitApp.Web;

namespace PermitApp.Areas.Permit.Controllers
{
    [Area("Permit")]
    public class MergePermitController : Controller
    {
        IMergePermitModel _userPemit;
        ILesseePermitModel _userLesseePemit;
        MessageEF objMSmodel = new MessageEF();
        public object JsonRequestBehavior { get; private set; }
        IHostingEnvironment _hostingEnvironment;
        string OutputResult = "";
        string MineralName;
        string UserType = "Licensee";//it will comes from session variable
        private IConfiguration Configuration;



        public MergePermitController(IMergePermitModel objPermit,ILesseePermitModel objLesseePermit, IHostingEnvironment hostingEnvironment, IConfiguration _configuration)
        {
            _userPemit = objPermit;
            _userLesseePemit = objLesseePermit;
            _hostingEnvironment = hostingEnvironment;
            Configuration = _configuration;
        }
        public IActionResult List(string request)
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            //objmodel.UserID = 59; //For lessee permit
            //objmodel.UserID = 150;//For coal permit
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
        [HttpPost]
        public IActionResult List(ePermitModel objmodel)
        {
            List<ePermitModel> modelList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            // ePermitModel objmodel = new ePermitModel();
            //objmodel.UserID = 59; //For lessee permit
            //objmodel.UserID = 150;//For coal permit
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
        [HttpGet]
        public JsonResult StopRPTPPermit(int? mineralid, int? mineralGradeid, int? mineralFormid, decimal? pendingQty, int? bulkpermitid)
        {
            ePermitModel model = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.SubUserID = Convert.ToInt32(profile.SubUserID);
            model.UserType = "Licensee";
            string UserType = "Licensee";
            model.MineralId = mineralid;
            model.MineralGradeId = Convert.ToInt32(mineralGradeid);
            model.MineralNatureId = mineralFormid;
            model.PendingQty = pendingQty;
            model.BulkPermitId = Convert.ToInt32(bulkpermitid);

            try
            {
                objMSmodel = _userPemit.ClosePermit(model);
                OutputResult = objMSmodel.Satus;


                if (OutputResult != null && !string.IsNullOrEmpty(Convert.ToString(OutputResult)))
                {
                    // "Applicaation of RPTP has been saved successfully."
                    return Json(true);
                }
                else
                {

                    return Json(false);
                }

            }
            catch (Exception e)
            {
                return Json(false);
            }
        }
        /// <summary>
        /// Save and generate permit in case of merge permit with wallet adjustment
        /// </summary>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveAndGenerateEpermit(int BulkPermitId)
        {
            ePermitModel objmodel = new ePermitModel();
            var str = string.Empty;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = Convert.ToInt32(profile.UserId);
                objmodel.BulkPermitId = BulkPermitId;
                objMSmodel = _userPemit.SaveAndGenerateEpermit(objmodel);
                OutputResult = objMSmodel.Satus;
                if (OutputResult == null)
                {
                    str = "FAILED";
                }
                else
                {
                    str = "SUCCESS";
                }
                return Json(str);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }


        }
        /// <summary>
        /// Save Merge Permit data
        /// </summary>
        /// <param name="model"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public IActionResult AddBulkPermitData(ePermitModel model, string request,string cmdTransfer)
        {
            model.ProposedQty = model.ProposedQty + Convert.ToDecimal(model.RemainingProduction);
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            //model.UserID = 72;
            ePermitResult objDetailsAppl = new ePermitResult();
            if (request != null)
            {
                if (model.MineralName.Contains("Coal"))
                {
                    try
                    {
                        objDetailsAppl = _userPemit.GetMineralName(model);
                        if (objDetailsAppl != null && objDetailsAppl.MineralNatureLst.Count > 0)
                        {
                            ePermitModel objmodel = new ePermitModel();
                            foreach (var app in objDetailsAppl.DetailsPermitLstByUserID)
                            {
                                objmodel.MineralName = Convert.ToString(app.MineralName);
                                objmodel.MineralNature = Convert.ToString(app.MineralNature);
                                objmodel.MineralGradeName = Convert.ToString(app.MineralGrade);
                            }
                        }
                    }
                    catch { }

                    return RedirectToAction("ePermitViewWithoutDSC", "CoalEPermit", new { id = model.BulkPermitId, Area = "Permit" });
                }
                else
                {
                    return RedirectToAction("ePermitViewWithoutDSC", "BulkPermit", new { id = model.BulkPermitId, Area = "Lessee" });
                }
            }
            else
            {
               // var TransferRequest = Convert.ToString(Request["cmdTransfer"]);
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
                                
                                objMSmodel = _userLesseePemit.AddBulkPermit(model);
                                OutputResult = objMSmodel.Satus;
                            }
                            else
                            {
                                objMSmodel = _userLesseePemit.AddBulkPermit(model);
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
                            objMSmodel = _userLesseePemit.AddBulkPermit(model);
                            OutputResult = objMSmodel.Satus;
                        }
                        else
                        {
                            objMSmodel = _userLesseePemit.AddBulkPermit(model);
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
                                    //return RedirectToAction("MergeEPermitPayment", "MergePermit", new { id = model.BulkPermitId });
                                    var dataString = CustomQueryStringHelper.
                                   EncryptString("Permit", "CoalPayment", "CoalEPermit", new { BulkPermitId = OutputResult });
                                    return new RedirectResult(dataString);
                                }
                                else
                                {
                                    //return RedirectToAction("MergeEPermitPayment", "MergePermit", new { id = OutputResult });
                                    var dataString = CustomQueryStringHelper.
                               EncryptString("Permit", "CoalPayment", "CoalEPermit", new { BulkPermitId = OutputResult });
                                    return new RedirectResult(dataString);
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
        /// <summary>
        /// Make payment of merge permit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult MergeEPermitPayment(int? id)
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

            objDetailsAppl = _userLesseePemit.CheckMergePermitDetails(objmodel);
            //SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand();
            //if (SessionWrapper.UserType.ToUpper() == "TAILING DAM")
            //{
            //    cmd1.CommandText = "getDetailsByTailingDamUserID";
            //}
            //else
            //{
            //    cmd1.CommandText = "getDetailsByUserID";
            //}
            //cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd1.Parameters.AddWithValue("@UserID", SessionWrapper.UserId);

            //DataTable dt1 = objDb.ExecuteStoreProcedure(cmd1);

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

                    if (id == null || id == 0)
                    {
                        return View(new ePermitModel { });
                    }
                    else
                    {
                        //using (SqlCommand cmd = new SqlCommand())
                        //{
                        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //    cmd.CommandText = "uspEPermitOperation";

                        //    cmd.Parameters.AddWithValue("@UserID", SessionWrapper.UserId);
                        //    cmd.Parameters.AddWithValue("@Check", 1);
                        //    cmd.Parameters.AddWithValue("@BulkPermitID", id);

                        //
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
                                //if (ds.Tables.Count >= 2)
                                //{
                                //    DataTable dtPayment = ds.Tables[1];
                                //    if (dtPayment != null && dtPayment.Rows.Count > 0)
                                //    {
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
    }
}