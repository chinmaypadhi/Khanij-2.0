using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermitApp.Areas.Permit.Models.PaymentConfig;
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

namespace PermitApp.Areas.Permit.Controllers
{
    [Area("Permit")]
    public class PaymentConfigController : Controller
    {
        IPaymentConfigModel _userPayment;
        ILesseePermitModel _userPemit;
        private IConfiguration Configuration;
        MessageEF objMSmodel = new MessageEF();
        public object JsonRequestBehavior { get; private set; }
        IWebHostEnvironment _hostingEnvironment;
        string OutputResult = "";
        public PaymentConfigController(ILesseePermitModel objPermit,IPaymentConfigModel objPayment, IConfiguration _configuration)
        {
            _userPayment = objPayment;
            _userPemit = objPermit;
            Configuration = _configuration;
        }
        [HttpPost]
        public IActionResult PaymentConfigCheck(ePermitModel model)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
           
            try
            {
                string URL = string.Empty;
                if (model.GeneratedBy == "TP")
                {
                    var dataString = CustomQueryStringHelper.
                    EncryptString("Epass", "TransitPassTP", "eTransitpass", new {});
                    URL = Configuration.GetSection("Path").GetSection("TPAPIURL").Value + dataString;
                    return new RedirectResult(URL);
                }
                else if (model.command == "Merge")
                {
                    return RedirectToAction("MergeEPermit", "ePermit", new { Areas = "Permit" });
                }
                else
                {
                    if (profile.MineralName == "COAL")
                    {
                        return RedirectToAction("CoalEPermit", "CoalEPermit", new { Areas = "Permit" });
                    }
                    else
                    {
                        return RedirectToAction("ePermitApplication", "Lessee", new { Areas = "Permit" });
                    }
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult FifthScheduleAdd(int? id)
        {
            ePermitModel objmodel = new ePermitModel();
            List<ePermitModel> List = new List<ePermitModel>();
            var x = _userPayment.GetMineralList(objmodel);
            if (x.MineralLst != null)
            {
                ViewBag.ViewMineralList = x.MineralLst.Select(c => new SelectListItem
                {
                    Text = c.MineralName,
                    Value = c.MineralId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewMineralList = Enumerable.Empty<SelectListItem>();
            }
            if (id != null)
            {

                objmodel.FifthSchId = Convert.ToInt32(id);
                List = _userPayment.EditFifthSchedule(objmodel);
                if (List != null && List.Count > 0)
                {
                    for (var i = 0; i < List.Count; i++)
                    {
                        ePermitModel lst = new ePermitModel();
                        objmodel.FifthSchId = (List[i].FifthSchId);
                        objmodel.MineralId = (List[i].MineralId);
                        objmodel.Description = (List[i].Description);
                        objmodel.AddtionalRate = Convert.ToDecimal(List[i].AddtionalRate);
                        objmodel.IsActive = List[i].IsActive;
                    }
                }
                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = 1;
                ViewBag.Button = "Submit";
                return View(objmodel);
            }

        }
        [HttpPost]
        public IActionResult FifthScheduleAdd(ePermitModel model, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.SubUserID = Convert.ToInt32(profile.SubUserID);
            try
            {

                //if (ModelState.IsValid)
                //{
                if (submit == "Submit")
                {
                    objMSmodel = _userPayment.SaveFifthPaymentConfig(model);
                    OutputResult = objMSmodel.Satus;
                }
                else
                {
                    objMSmodel = _userPayment.UpdateFifthPaymentConfig(model);
                    OutputResult = objMSmodel.Satus;
                }
                if (OutputResult == "1")
                {
                    TempData["SuccMessage"] = "Application of Fifth Schedule has been saved successfully.";
                    return RedirectToAction("FifthScheduleView");
                }
               else if (OutputResult == "2")
                {
                    TempData["SuccMessage"] = "Application of Fifth Schedule has been updated successfully.";
                    return RedirectToAction("FifthScheduleView");
                }
                return View(model);
                //}
                //else
                //{
                //    return View(model);
                //}
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult FifthScheduleView()
        {
            List<ePermitModel> FifthList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);

            FifthList = _userPayment.GetFifthSchedule(objmodel);
            if (FifthList != null && FifthList.Count > 0)
            {
                int cnt = 1;
                for (var i = 0; i < FifthList.Count; i++)
                {
                    ePermitModel lst = new ePermitModel();
                    lst.FifthSchId = (FifthList[i].FifthSchId);
                    lst.MineralName = (FifthList[i].MineralName);
                    lst.Description = (FifthList[i].Description);
                    lst.AddtionalRate = Convert.ToDecimal(FifthList[i].AddtionalRate);

                    lst.IsActiveStatus = FifthList[i].IsActiveStatus;

                    List.Add(lst);
                    cnt++;
                }
            }
            ViewBag.ViewList = List;
            return View();
        }
        /// <summary>
        /// Delete fifth schedule
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteFifth(int? id)
        {
            ePermitModel objmodel = new ePermitModel();
            List<ePermitModel> List = new List<ePermitModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            if (id != null)
            {

                objmodel.FifthSchId = Convert.ToInt32(id);
                objMSmodel = _userPayment.DeleteFifthPaymentConfig(objmodel);
                OutputResult = objMSmodel.Satus;
                if (OutputResult == "1")
                {
                    TempData["SuccMessage"] = "Fifth Schedule has been deleted successfully.";
                    return RedirectToAction("FifthScheduleView");
                }
            }
            return View();

        }
        [HttpGet]
        public IActionResult SixthScheduleAdd(int? id)
        {
            ePermitModel objmodel = new ePermitModel();
            List<ePermitModel> List = new List<ePermitModel>();
            var x = _userPayment.GetMineralList(objmodel);
            if (x.MineralLst != null)
            {
                ViewBag.ViewMineralList = x.MineralLst.Select(c => new SelectListItem
                {
                    Text = c.MineralName,
                    Value = c.MineralId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewMineralList = Enumerable.Empty<SelectListItem>();
            }
            ViewBag.ViewMineralNatureList = Enumerable.Empty<SelectListItem>();
            if (id != null)
            {

                objmodel.SixthSchId = Convert.ToInt32(id);
                List = _userPayment.EditSixthSchedule(objmodel);
                if (List != null && List.Count > 0)
                {
                    for (var i = 0; i < List.Count; i++)
                    {
                        ePermitModel lst = new ePermitModel();
                        objmodel.SixthSchId = (List[i].SixthSchId);
                        objmodel.MineralId = (List[i].MineralId);

                        objmodel.Description = (List[i].Description);
                        objmodel.AddtionalRate = Convert.ToDecimal(List[i].AddtionalRate);
                        objmodel.IsActive = List[i].IsActive;
                        objmodel.MineralNatureId = (List[i].MineralNatureId);


                    }
                    var y = _userPayment.GetMineralNatureList(objmodel);
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
                }

                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = 1;
                ViewBag.Button = "Submit";
                return View(objmodel);
            }

        }
       
        /// <summary>
        /// To Save and update of sixth schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult SixthScheduleAdd(ePermitModel model, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.SubUserID = Convert.ToInt32(profile.SubUserID);

            try
            {
                if (submit == "Submit")
                {
                    objMSmodel = _userPayment.SaveSixthPaymentConfig(model);
                    OutputResult = objMSmodel.Satus;
                }
                else
                {
                    objMSmodel = _userPayment.UpdateSixthPaymentConfig(model);
                    OutputResult = objMSmodel.Satus;
                }
                if (OutputResult == "1")
                {
                    TempData["SuccMessage"] = "Application of Sixth Schedule has been saved successfully.";
                    return RedirectToAction("SixthScheduleView");
                }
                else if (OutputResult == "2")
                {
                    TempData["SuccMessage"] = "Application of Sixth Schedule has been updated successfully.";
                    return RedirectToAction("SixthScheduleView");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult SixthScheduleView()
        {
            List<ePermitModel> FifthList = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);

            FifthList = _userPayment.GetSixthSchedule(objmodel);
            if (FifthList != null && FifthList.Count > 0)
            {
                int cnt = 1;
                for (var i = 0; i < FifthList.Count; i++)
                {
                    ePermitModel lst = new ePermitModel();
                    lst.SixthSchId = (FifthList[i].SixthSchId);
                    lst.MineralName = (FifthList[i].MineralName);
                    lst.MineralNature = (FifthList[i].MineralNature);
                    lst.Description = (FifthList[i].Description);
                    lst.AddtionalRate = Convert.ToDecimal(FifthList[i].AddtionalRate);
                    lst.IsActiveStatus = FifthList[i].IsActiveStatus;
                    List.Add(lst);
                    cnt++;
                }
            }
            ViewBag.ViewList = List;
            return View();
        }

        /// <summary>
        /// Delete sixth schedule
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteSixth(int? id)
        {
            ePermitModel objmodel = new ePermitModel();
            List<ePermitModel> List = new List<ePermitModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            if (id != null)
            {

                objmodel.SixthSchId = Convert.ToInt32(id);
                objMSmodel = _userPayment.DeleteSixthPaymentConfig(objmodel);
                OutputResult = objMSmodel.Satus;
                if (OutputResult == "1")
                {
                    TempData["SuccMessage"] = "Delete Sixth has been deleted successfully.";
                    return RedirectToAction("SixthScheduleView");
                }
            }
            return View();

        }
       
        public IActionResult PaymentConfiguration()
        {

            ePermitModel objmodel = new ePermitModel();
            List<ePermitModel> List = new List<ePermitModel>();
            var x = _userPayment.GetMineralList(objmodel);
            if (x.MineralLst != null)
            {
                ViewBag.ViewMineralList = x.MineralLst.Select(c => new SelectListItem
                {
                    Text = c.MineralName,
                    Value = c.MineralId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewMineralList = Enumerable.Empty<SelectListItem>();
            }
            var y = _userPayment.BindFifthSchedule(objmodel);
            if (y.FifthSchedule != null)
            {
                ViewBag.ViewFifthList = y.FifthSchedule.Select(c => new SelectListItem
                {
                    Text = c.Description,
                    Value = c.FifthSchId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewFifthList = Enumerable.Empty<SelectListItem>();
            }

            var z = _userPayment.BindSixthSchedule(objmodel);
            if (z.SixthSchedule != null)
            {
                ViewBag.ViewSixthList = z.SixthSchedule.Select(c => new SelectListItem
                {
                    Text = c.Description,
                    Value = c.SixthSchId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewSixthList = Enumerable.Empty<SelectListItem>();
            }
            ViewBag.ViewMineralNatureList = Enumerable.Empty<SelectListItem>();
            ViewBag.Message = "abcd";
            return View();
        }
        [HttpPost]
        public IActionResult PaymentConfiguration(ePermitModel model,int MinesType,int Captive,int Company,int Lease,int Premium)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.SubUserID = Convert.ToInt32(profile.SubUserID);
            //model.UserID = 1;
            model.MinesType = MinesType;
            model.Captive = Captive;
            model.CompanyType = Company;
            model.LeaseExtend = Lease;
            model.AuctionPremium = Premium;

            try
            {
                objMSmodel = _userPayment.SavePaymentConfig(model);
                OutputResult = objMSmodel.Satus;
                if (OutputResult == "1")
                {
                    ViewBag.Message = "Payment configuration has been saved successfully.";
                    return RedirectToAction("PaymentConfiguration");
                }
               else if (OutputResult == "2")
                {
                    ViewBag.Message = "Duplicate Payment configuration is not allowed.";
                    return RedirectToAction("PaymentConfiguration");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        /// <summary>
        /// Check payment config
        /// </summary>
        /// <param name="ForwardingNoteId"></param>
        /// <returns></returns>
        public IActionResult PaymentConfigCheck(string idd, string Status,int? id = 0)
        {
            ePermitModel objmodel = new ePermitModel();
            ePermitResult objDetailsAppl = new ePermitResult();
            ePermitResult objOperationAppl = new ePermitResult();
            List<ePermitModel> PermitQtyList = new List<ePermitModel>();
            List<ePermitModel> PermitClosingQtyList = new List<ePermitModel>();
            ePermitModel model = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
            //objmodel.UserID = 103;
            //string UserType = "Lessee";
            //objDetailsAppl = _userPemit.GetPermitDetailsByUserID(objmodel);
            //if (objDetailsAppl != null && objDetailsAppl.DetailsPermitLstByUserID.Count > 0)
            //{
            PermitClosingQtyList = _userPemit.GetPermitColosingDtls(objmodel);
            if (PermitClosingQtyList != null)
            {
                if (PermitClosingQtyList.Count > 0)
                {
                    //if (profile.MineralName.ToUpper() == "COAL")
                    //{
                    //    if (profile.UserType.ToUpper() == "LESSEE")
                    //        return RedirectToAction("ePermitCoalOption", "ePermitOption", new { Area = "ePermit" });
                    //    else
                    //        return RedirectToAction("RPTPDashboard", "ePermit", new { Area = "ePermit" });
                    //}
                    //else
                    //{
                    if (profile.UserType.ToUpper() == "LESSEE")
                        //if (UserType.ToUpper() == "LESSEE")
                        try
                        {
                            if (id == 0)
                            {
                                objOperationAppl = _userPemit.GetPermitOperation(objmodel);
                                if (objOperationAppl != null && objOperationAppl.DetailsPermitLstByUserID.Count > 0)
                                {
                                    foreach (var app1 in objOperationAppl.DetailsPermitLstByUserID)
                                    {
                                        if (Convert.ToString(app1.GrantOrderNumber) == null)
                                        {
                                            TempData["SuccMessage"] = "Details not found !";
                                        }
                                        else
                                        {
                                            model.LesseeName = Convert.ToString(app1.ApplicantName);

                                            if (!(app1.MINERAL_ID is null))
                                            {
                                                model.MineralId = Convert.ToInt32(app1.MINERAL_ID);
                                                objmodel.MineralId = Convert.ToInt32(app1.MINERAL_ID);
                                            }
                                            model.MineralName = Convert.ToString(app1.MineralName);
                                            if (!(app1.MineralNatureId is null))
                                            {
                                                model.MineralNatureId = Convert.ToInt32(app1.MineralNatureId);
                                                objmodel.MineralNatureId = Convert.ToInt32(app1.MineralNatureId);
                                            }
                                            model.Production = Convert.ToString(app1.Production);
                                            objmodel.DistrictId = app1.DistrictId;
                                            objmodel.UserTypeId = profile.UserTypeId;
                                            break;
                                        }


                                    }
                                    PermitQtyList = _userPemit.GetPermitQuantity(objmodel);
                                    if (PermitQtyList != null)
                                    {
                                        model.Production = Convert.ToString(PermitQtyList[0].Production);
                                        model.ProductionCap = Convert.ToString(PermitQtyList[0].ProductionCap);
                                        model.RunningQty = Convert.ToString(PermitQtyList[0].RunningQty);
                                        model.Dispatch = Convert.ToString(PermitQtyList[0].Dispatch);
                                    }
                                    
                                    ViewBag.ViewList = _userPayment.GetRiderList(objmodel).ToList();
                                    model.command = idd;
                                    model.GeneratedBy = Status;
                                    return View(model);

                                }
                                else
                                {
                                    TempData["SuccMessage"] = "Details not found !";
                                    return View(model);
                                }
                            }

                            return View(model);
                        }
                        catch (Exception ex)
                        {
                            return View(model);
                        }
                    else if (profile.UserType.ToUpper() == "TAILING DAM")
                            return View();
                        else
                            return RedirectToAction("RPTPDashboard", "ePermit", new { Area = "Permit" });
                   // }
                }
                else
                {

                    if (profile.UserType.ToUpper() == "LESSEE")
                        //if (UserType.ToUpper() == "LESSEE")
                        return RedirectToAction("ePermitRequiredFields", "ePermit", new { Area = "Permit" });
                    else if (profile.UserType.ToUpper() == "TAILING DAM")
                        return View();
                    else
                        return RedirectToAction("RequiredFields", "RequiredFields", new { Area = "Licensee" });
                }
            }
            else
            {
                if (profile.UserType.ToUpper() == "LESSEE")
                    return RedirectToAction("ePermitRequiredFields", "ePermit", new { Area = "Permit" });
                else if (profile.UserType.ToUpper() == "TAILING DAM")
                    return View();
                else
                    return RedirectToAction("RequiredFields", "RequiredFields", new { Area = "Licensee" });
            }

           
               
            //}
            //else
            //{
            //    objmodel.LesseeName = "";
            //    objmodel.MineralName = "";
            //    objmodel.Production = "";
            //    ViewBag.ViewList = "";
            //}
            //return View(objmodel);
        }
        public JsonResult GetMineralGrade(int NatureID,int MineralId)
        {
            ePermitModel objPermit = null;
            try
            {
                objPermit = new ePermitModel();
                //UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                //objPermit.UserID = Convert.ToInt32(profile.UserId);
              
                objPermit.MineralNatureId = NatureID;
                objPermit.MineralId = MineralId;
                var x = _userPayment.GetMineralGradeListOnNatureList(objPermit);
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
        public JsonResult GetMineralForm(int MineralId)
        {
            ePermitModel objPermit = null;
            try
            {
                objPermit = new ePermitModel();
                objPermit.MineralId = MineralId;
                var x = _userPayment.GetMineralNatureList(objPermit);
                var SList = x.MineralNatureLst.ToList();
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
        /// <summary>
        /// Get Data
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public ActionResult DynamicPaymentConfiguration(string q="0")
        {
            ePermitModel model = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ePermitResult objDetailsAppl = new ePermitResult();
            List<ePermitPaymentHead> lst = new List<ePermitPaymentHead>();
            model.UserID = Convert.ToInt32(profile.UserId);
            model.UserLoginId = Convert.ToString(profile.UserLoginId);
            model.PaymentConfigID = Convert.ToInt32(q);
            model = _userPayment.GetPaymentDetails(model);
            //model.UserID = 1;
            if (q != "0")
            {
                model.LesseeId = model.UserID;
            }


                var x = _userPayment.FillDistrict(model);
            if (x.DistrictLst != null)
            {
                ViewBag.ViewDistrictList = x.DistrictLst.Select(c => new SelectListItem
                {
                    Text = c.DistrictName,
                    Value = c.DistrictId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewDistrictList = Enumerable.Empty<SelectListItem>();
            }
            
            var z = _userPayment.FillUserType(model);
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
            var y = _userPayment.FillLeaseType(model);
            if (y.LeaseTypeLst != null)
            {
                ViewBag.ViewLeaseTypeList = y.LeaseTypeLst.Select(c => new SelectListItem
                {
                    Text = c.LeaseTypeName,
                    Value = c.LeaseTypeId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewLeaseTypeList = Enumerable.Empty<SelectListItem>();
            }
            var mincat = _userPayment.GetMineralCategory(model);
            if (mincat != null)
            {
                ViewBag.ViewMineralCategory = mincat.Select(c => new SelectListItem
                {
                    Text = c.MineralTypeName,
                    Value = c.MineralTypeId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewMineralCategory = Enumerable.Empty<SelectListItem>();
            }
            var xx = _userPayment.GetMineralList(model);
            if (xx.MineralLst != null)
            {
                ViewBag.ViewMineralList = xx.MineralLst.Select(c => new SelectListItem
                {
                    Text = c.MineralName,
                    Value = c.MineralId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewMineralList = Enumerable.Empty<SelectListItem>();
            }

            
            //var yy = _userPayment.BindFifthSchedule(model);
            //if (yy.FifthSchedule != null)
            //{
            //    ViewBag.ViewFifthSchudelList = yy.FifthSchedule.Select(c => new SelectListItem
            //    {
            //        Text = c.Description,
            //        Value = c.FifthSchId.ToString(),
            //    }).ToList();
            //}
            //else
            //{
            //    ViewBag.ViewFifthSchudelList = Enumerable.Empty<SelectListItem>();
            //}
            //var xx = _userPayment.BindSixthSchedule(model);
            //if (xx.SixthSchedule != null)
            //{
            //    ViewBag.ViewSixthSchudelList = xx.SixthSchedule.Select(c => new SelectListItem
            //    {
            //        Text = c.Description,
            //        Value = c.SixthSchId.ToString(),
            //    }).ToList();
            //}
            //else
            //{
            //    ViewBag.ViewSixthSchudelList = Enumerable.Empty<SelectListItem>();
            //}
            var PayHead = _userPayment.FillPaymentHeadType(model);
            if (PayHead.PaymnetHeadLst != null)
            {
                ViewBag.ViewPayHeadTypeList = PayHead.PaymnetHeadLst.Select(c => new SelectListItem
                {
                    Text = c.PaymentType,
                    Value = c.PaymentTypeId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewPayHeadTypeList = Enumerable.Empty<SelectListItem>();
            }
            var PayDept = _userPayment.FillPaymentDept(model);
            if (PayDept.PayDeptLst != null)
            {
                ViewBag.ViewpayDeptList = PayDept.PayDeptLst.Select(c => new SelectListItem
                {
                    Text = c.PaymentDept,
                    Value = c.PayDeptId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewpayDeptList = Enumerable.Empty<SelectListItem>();
            }
            var PaySche = _userPayment.FillScheduleType(model);
            if (PaySche.ScheduleLst != null)
            {
                ViewBag.ViewScheduleTypeList = PaySche.ScheduleLst.Select(c => new SelectListItem
                {
                    Text = c.ScheduleText,
                    Value = c.ScheduleId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewScheduleTypeList = Enumerable.Empty<SelectListItem>();
            }
            if (q != "0")
            {
                ViewBag.Button = "Update";
                ViewBag.PcId = q;
                var usern = _userPayment.FillUserName(model);
                if (usern.UserList != null)
                {
                    ViewBag.ViewUserNameList = usern.UserList.Select(c => new SelectListItem
                    {
                        Text = c.ApplicantName + "/UserId-" + c.LesseeId.ToString(),
                        Value = c.LesseeId.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewUserNameList = Enumerable.Empty<SelectListItem>();
                }
                
            }
            else
            {

                ViewBag.ViewUserNameList = Enumerable.Empty<SelectListItem>();
                
                ViewBag.Button = "Submit";
                model.IsAdditionalAmt = 0;
                model.IsSchedule = 1;
                model.IsPremium = 0;
                model.RiderType = 2;
                lst = _userPayment.GetPaymentTypeHead(model);
                ViewBag.PaymentHeadList = lst.ToList();
                model.datatable= lst.ToList();
            }
               
            return View(model);

        }
        [HttpPost]
        public ActionResult DynamicPaymentConfiguration(ePermitModel model, int MinesType, int CalTypeId, IFormCollection form)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.SubUserID = Convert.ToInt32(profile.SubUserID);
            //model.UserID = 1;

            string []str= model.CheckListDescription.Split('/');
            List<ePermitPaymentHead> ltHead = new List<ePermitPaymentHead>();
            for(int i=2;i<str.Length;i++)
            {
                string data = str[i];
                if(data.Length>1)
                {
                    string[] Payment = data.Split(',');
                    ePermitPaymentHead head = new ePermitPaymentHead()
                    {
                        PaymentTypeId = Convert.ToInt32(Payment[0].ToString()),
                        IsPaymentApplicable = Convert.ToInt32(Payment[1].ToString()),
                        IsSchedule = Convert.ToInt32(Payment[2].ToString()),
                        CalTypeId = Convert.ToInt32(Payment[3].ToString()),
                        PaymentPercent = Convert.ToDecimal(Payment[4].ToString()),
                        IsMakePayment = Convert.ToInt32(Payment[5].ToString()),
                      
                        PayDeptId = Convert.ToInt32(Payment[6].ToString()),
                        IsAdjustable = Convert.ToInt32(Payment[7].ToString())
                    };
                    ltHead.Add(head);
                }
            }
            model.datatable = ltHead;
           
            model.MinesType = MinesType;
            model.CalTypeId = CalTypeId;
            try
            {
                if(model.PaymentConfigID ==null || model.PaymentConfigID == 0)
                {
                    objMSmodel = _userPayment.SaveDynamicPaymentConfig(model);
                }
                else
                {
                    objMSmodel = _userPayment.UpdateDynamicPaymentConfig(model);
                }
               
                OutputResult = objMSmodel.Satus;
                if (OutputResult == "1" && model.PaymentConfigID != null)
                {
                    TempData["SuccMessage"] = "Payment configuration has been updated successfully.";
                    return RedirectToAction("DynamicPaymentConfiguration");
                }
                else if(OutputResult == "1")
                {
                    TempData["SuccMessage"] = "Payment configuration has been saved successfully.";
                    return RedirectToAction("DynamicPaymentConfiguration");
                }
                else if (OutputResult == "2")
                {
                    TempData["SuccMessage"] = "Duplicate Payment configuration is not allowed.";
                    return RedirectToAction("DynamicPaymentConfiguration");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public ActionResult DynamicPaymentView(int? id)
        {
            ePermitResult result = new ePermitResult();
            ePermitModel objmodel = new ePermitModel();
            List<ePermitModel> List = new List<ePermitModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            //objmodel.UserID = 1;
            result = _userPayment.ViewDynamicPayment(objmodel);
            if (result.DynamicPaymnetLst != null && result.DynamicPaymnetLst.Count > 0)
            {
                int cnt = 1;
                for (var i = 0; i < result.DynamicPaymnetLst.Count; i++)
                {
                    ePermitModel lst = new ePermitModel();
                    lst.PaymentConfigID = (result.DynamicPaymnetLst[i].PaymentConfigID);
                    lst.DistrictName = (result.DynamicPaymnetLst[i].DistrictName);
                    lst.UserType = (result.DynamicPaymnetLst[i].UserType);
                    lst.ApplicantName = (result.DynamicPaymnetLst[i].ApplicantName);
                    lst.LeaseTypeName = result.DynamicPaymnetLst[i].LeaseTypeName;
                    lst.MinesTypeName = result.DynamicPaymnetLst[i].MinesTypeName;
                    lst.LeaseExtendText = result.DynamicPaymnetLst[i].LeaseExtendText;
                    lst.CaptiveText = result.DynamicPaymnetLst[i].CaptiveText;
                    lst.ScheduleText = result.DynamicPaymnetLst[i].ScheduleText;
                    lst.FifthDesc = result.DynamicPaymnetLst[i].FifthDesc;
                    lst.SixthDesc = result.DynamicPaymnetLst[i].SixthDesc;
                    lst.CalTypeText = result.DynamicPaymnetLst[i].CalTypeText;
                    lst.CalculationValue = result.DynamicPaymnetLst[i].CalculationValue;
                    lst.RiderTypeName = result.DynamicPaymnetLst[i].RiderTypeName;
                    lst.MineralName = result.DynamicPaymnetLst[i].MineralName;
                    lst.MLGrantedDateText = result.DynamicPaymnetLst[i].MLGrantedDateText;
                    lst.DateOfGrant = result.DynamicPaymnetLst[i].DateOfGrant;
                    List.Add(lst);
                    cnt++;
                }
            }
            ViewBag.ViewList = List;
           
            return View();
           
        }
        public JsonResult GetUserName(int UserTypeId,int DistrictId, int Configtype)
        {
            if (Configtype == 2)
            {
                ePermitModel objPermit = null;
                try
                {
                    objPermit = new ePermitModel();
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    //objPermit.UserID = Convert.ToInt32(profile.UserId);
                    objPermit.UserID = 1;
                    objPermit.UserTypeId = UserTypeId;
                    objPermit.DistrictId = DistrictId;
                    var x = _userPayment.FillUserName(objPermit);

                    //var SList = x.UserList.ToList();
                    //return Json(SList);
                    //null handled exception by Kautilya 11-May-2022
                    if (x.UserList != null)
                    {
                        var SList = x.UserList.ToList();
                        return Json(SList);
                    }
                    else
                    {
                        return Json(null);
                    }
                    //end of null handled exception by Kautilya 11-May-2022
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
        public JsonResult GetLesseeDetails(int intUserID)
        {
            ePermitModel objPermit = null;
            try
            {
                objPermit = new ePermitModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objPermit.UserID = Convert.ToInt32(profile.UserId);
                //objPermit.UserID = 1;
                objPermit.CreatedBy = intUserID;
                var x = _userPayment.GetDynamicConfigWithourId(objPermit);

                var SList = x.ToList();
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

        public JsonResult GetMineral(int MineralTypeId)
        {
            ePermitModel objPermit = null;
            try
            {
                objPermit = new ePermitModel();
                //objPermit.UserID = 1;
                objPermit.MineralTypeId = MineralTypeId;
                var x = _userPayment.GetMineralList(objPermit);

                var SList = x.MineralLst.ToList();
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
        /// <summary>
        /// Delete Dynamic payment schedule
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult DeleteDynamicPayment(string q="0")
        {
            ePermitModel objmodel = new ePermitModel();
            List<ePermitModel> List = new List<ePermitModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            //objmodel.UserID = 1;
            if (q != null)
            {

                objmodel.PaymentConfigID = Convert.ToInt32(q);
                objMSmodel = _userPayment.DeleteDynamicPaymentConfig(objmodel);
                OutputResult = objMSmodel.Satus;
                if (OutputResult == "1")
                {
                    TempData["SuccMessage"] = "Dynamic Payment configuration master has been deleted successfully.";
                    return RedirectToAction("DynamicPaymentView");
                }
            }
            return View();

        }
        [HttpGet]
        public IActionResult ScheduleRateMaster(int? id)
        {
            ePermitModel objmodel = new ePermitModel();
            List<ePermitModel> List = new List<ePermitModel>();
            var x = _userPayment.GetMineralList(objmodel);
            if (x.MineralLst != null)
            {
                ViewBag.ViewMineralList = x.MineralLst.Select(c => new SelectListItem
                {
                    Text = c.MineralName,
                    Value = c.MineralId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewMineralList = Enumerable.Empty<SelectListItem>();
            }
            ViewBag.ViewMineralNatureList = Enumerable.Empty<SelectListItem>();
            var PaySche = _userPayment.FillScheduleType(objmodel);
            if (PaySche.ScheduleLst != null)
            {
                ViewBag.ViewScheduleTypeList = PaySche.ScheduleLst.Select(c => new SelectListItem
                {
                    Text = c.ScheduleText,
                    Value = c.ScheduleId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewScheduleTypeList = Enumerable.Empty<SelectListItem>();
            }
            if (id != null)
            {

                objmodel.ScheduleRateId = Convert.ToInt32(id);
                List = _userPayment.EditScheduleRateMaster(objmodel);
                if (List != null && List.Count > 0)
                {
                    for (var i = 0; i < List.Count; i++)
                    {
                        ePermitModel lst = new ePermitModel();
                        objmodel.ScheduleRateId = (List[i].ScheduleRateId);
                        objmodel.ScheduleId = (List[i].ScheduleId);
                        objmodel.MineralId = (List[i].MineralId);
                        objmodel.Description = (List[i].Description);
                        objmodel.AddtionalRate = Convert.ToDecimal(List[i].AddtionalRate);
                        objmodel.IsActive = List[i].IsActive;
                        objmodel.MineralNatureId = (List[i].MineralNatureId);
                    }
                    var y = _userPayment.GetMineralNatureList(objmodel);
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
                }

                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = 1;
                ViewBag.Button = "Submit";
                return View(objmodel);
            }

        }

        /// <summary>
        /// To Save and update of sixth schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ScheduleRateMaster(ePermitModel model, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
            model.SubUserID = Convert.ToInt32(profile.SubUserID);

            try
            {
                if (submit == "Submit")
                {
                    objMSmodel = _userPayment.SaveScheduleRateMaster(model);
                    OutputResult = objMSmodel.Satus;
                }
                else
                {
                    objMSmodel = _userPayment.UpdateScheduleRateMaster(model);
                    OutputResult = objMSmodel.Satus;
                }
                if (OutputResult == "1")
                {
                    TempData["SuccMessage"] = "Application of Schedule Rate Master has been saved successfully.";
                    return RedirectToAction("ScheduleRateMasterView");
                }
                else if (OutputResult == "2")
                {
                    TempData["SuccMessage"] = "Application of Schedule Rate Master has been updated successfully.";
                    return RedirectToAction("ScheduleRateMasterView");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        /// <summary>
        /// Delete  schedule rate  master
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteScheduleRate(int? id)
        {
            ePermitModel objmodel = new ePermitModel();
            List<ePermitModel> List = new List<ePermitModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
           // objmodel.UserID = 1;
            if (id != null)
            {

                objmodel.ScheduleRateId = Convert.ToInt32(id);
                objMSmodel = _userPayment.DeleteScheduleRateMaster(objmodel);
                OutputResult = objMSmodel.Satus;
                if (OutputResult == "1")
                {
                    TempData["SuccMessage"] = "Schedule rate master has been deleted successfully.";
                    return RedirectToAction("ScheduleRateMasterView");
                }
            }
            return View();

        }
        public IActionResult ScheduleRateMasterView()
        {
            List<ePermitModel> ScheduleLst = new List<ePermitModel>();
            List<ePermitModel> List = new List<ePermitModel>();
            ePermitModel objmodel = new ePermitModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
          //  objmodel.UserID = 1;
            ScheduleLst = _userPayment.ViewScheduleRateMaster(objmodel);
            if (ScheduleLst != null && ScheduleLst.Count > 0)
            {
                int cnt = 1;
                for (var i = 0; i < ScheduleLst.Count; i++)
                {
                    ePermitModel lst = new ePermitModel();
                    lst.ScheduleRateId = (ScheduleLst[i].ScheduleRateId);
                    lst.ScheduleText = (ScheduleLst[i].ScheduleText);
                    lst.MineralName = (ScheduleLst[i].MineralName);
                    lst.MineralNature = (ScheduleLst[i].MineralNature);
                    lst.Description = (ScheduleLst[i].Description);
                    lst.AddtionalRate = Convert.ToDecimal(ScheduleLst[i].AddtionalRate);
                    lst.IsActiveStatus = ScheduleLst[i].IsActiveStatus;
                    List.Add(lst);
                    cnt++;
                }
            }
            ViewBag.ViewList = List;
            return View();
        }
       
        public JsonResult DetailsPayment(int id)
        {
            ePermitResult objresult = new ePermitResult();
            ePermitModel objmodel = new ePermitModel();
            List<ePermitModel> List = new List<ePermitModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = Convert.ToInt32(profile.UserId);
            //objmodel.UserID = 1;
            objmodel.PaymentConfigID = Convert.ToInt32(id);
            objresult = _userPayment.DetailsDynamicPayment(objmodel);
            var result = objresult.PermitPaymentHead.ToList();
            return Json(result);
           

        }
    }
}
