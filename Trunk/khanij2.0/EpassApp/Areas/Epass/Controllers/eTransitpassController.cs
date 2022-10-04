// ***********************************************************************
//  Controller Name          : eTransitpassController
//  Desciption               : Used to generate eTransit Pass
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 11-jul-2021
// ***********************************************************************

using EpassApp.Areas.Epass.Models.eTransitpass;
using EpassEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Net.ConnectCode.Barcode;
using System.IO;
using EpassApp.Web;
using System.Drawing;
using System.Drawing.Imaging;
using EpassApp.Areas.Epass.Models.PurchaserConsignee;

namespace EpassApp.Areas.Epass.Controllers
{
    [Area("EPass")]

    public class eTransitpassController : Controller
    {
       
       
        private IPurchaserConsigneeProvider _objPurchaser;

        /// <summary>
        /// Added by suroj on 11-jul-2021 Dependency Injection For Etransitpass Controller
        /// </summary>
        private IeTransitpass _objIticketmodel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly KhanijSecurity.KhanijIDataProtection protector;
        int userid = 0;//194;//387;
        string usertype = string.Empty;//  "Licensee";
        int Tpoffline = 1;
        public eTransitpassController(IeTransitpass objtickettypemastermodel, IPurchaserConsigneeProvider objPurchaser, IHostingEnvironment hostingEnvironment, KhanijSecurity.KhanijIDataProtection khanijIDataProtection)
        {
            
            protector = khanijIDataProtection;
            _objIticketmodel = objtickettypemastermodel;
            _objPurchaser = objPurchaser;
            this.hostingEnvironment = hostingEnvironment;
        }

      

       
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Added by suroj on 12-jul-2021 to Fetch Districtname,Village Name and Details of Login User
        /// </summary>
        /// <returns></returns>

        public IActionResult TransitPassTP()
        {
            ViewBag.userid = userid;
            ViewBag.userType = usertype;
            ViewBag.userroleinfo = "ML";
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;

            TransitPassModel objPermitModel = new TransitPassModel();
            try
            {
                objPermitModel.userid = userid;
                var epermit = _objIticketmodel.GetApprovedBulkPermitList(objPermitModel);
                ViewBag.Permit = epermit.ToList().Select(c => new SelectListItem
                {
                    Text = c.BulkPermitNo,
                    Value = c.RPTPBulkPermitId.ToString(),

                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {

                objPermitModel = null;
            }



            TransitPassModel objPermitModel1 = new TransitPassModel();
            try
            {
                objPermitModel1.userid = userid;
                objPermitModel1.Usertype = usertype;
                var epermit = _objIticketmodel.getTransitpassdtls(objPermitModel1);
                ViewBag.Mineral_DateOfDispatch = DateTime.Now.ToString();
                return View(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {

                objPermitModel1 = null;
            }

        }
        /// <summary>
        /// Added by suroj on 08-jul-2021 to fetch details like mineral name,address agaiinst permit number change evt in Transit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>

        public JsonResult GetCascadePurchaserConsignee(int id)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            TransitPassModel objtransit = new TransitPassModel();

            try
            {
                objtransit.BulkPermitId = id;
                objtransit.userid = userid;
                var epermit = _objIticketmodel.GetCascadePurchaserConsignee(objtransit);

                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }
        /// <summary>
        /// Added by suroj on 08-jul-2021 to fetch details like mineral name,address agaiinst permit number change evt in Transit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>

        public JsonResult getBulkPermitDataByBulkPermitId(int id)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            TransitPassModel objtransit = new TransitPassModel();

            try
            {
                objtransit.BulkPermitId = id;
                var epermit = _objIticketmodel.getBulkPermitDataByBulkPermitId(objtransit);

                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }

        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        /// 
        public JsonResult GetDataByPurchaserConsigneeId(int bulkPermitId, int PcId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            TransitPassModel objtransit = new TransitPassModel();

            try
            {
                objtransit.BulkPermitId = bulkPermitId;
                objtransit.PurchaserConsigneeId = PcId;
                objtransit.userid = userid;
                var epermit = _objIticketmodel.GetDataByPurchaserConsigneeId(objtransit);

                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }
        
        /// <summary>
        /// Added by Sunny Krishna on 24-Mar-2022 to Get Transportation Mode Against Purchase consignee ID
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        /// 
        public JsonResult GetTransportationDataByPurchaserConsigneeId(int bulkPermitId, int PcId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            TransitPassModel objtransit = new TransitPassModel();

            try
            {
                objtransit.BulkPermitId = bulkPermitId;
                objtransit.PurchaserConsigneeId = PcId;
                objtransit.userid = userid;
                var epermit = _objIticketmodel.GetDataByPurchaserConsigneeId(objtransit);

                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }

        /// <summary>
        /// Added by Suroj on 13-jul-2021 to Fetch Autocomplete data Against Vhecle No
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public JsonResult OnPostAutoComplete(string prefix)
        {

            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;

            TransitPassModel objtransit = new TransitPassModel();

            try
            {
                objtransit.userid = userid;
                objtransit.VehicleNumber = prefix;

                var epermit = _objIticketmodel.GetAllVehicleInformation(objtransit);

                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }
        /// <summary>
        /// Added by suroj on 14-jul-2021 to generate Transit Pass
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult InsertTransitpassDetails(TransitPassModel model)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            ReturnOuputResult Output = new ReturnOuputResult();
            model.userid = userid;
            model.Tpoffline = Tpoffline.ToString();
            if (model.TransportationMode == "" || model.TransportationMode == null)
            {
                model.TransportationMode = "Road";
                model.TransportationModeId = 13;
            }

            if (model.PurchaserType == "Registered")
            {
                model.PurchaserType = null;
                model.PurchaserSubType = null;
                model.PurchaserName = null;
                model.PurchaserContactNumber = null;
                if (model.UnRegistredVehicleTypeId != "Tractor")
                {
                    model.UnRegistredWithTractorVehicleId = null;
                    model.UnRegistredWithTractorVehicleOwner = null;
                }
                else if (model.UnRegistredVehicleTypeId == "Tractor")
                {
                    model.UnRegistredWithoutTractorVehicleId = null;
                    model.UnRegistredWithoutTractorVehicleOwner = null;
                }
            }
            else if (model.PurchaserType == "Un-registered")
            {
                model.PurchaserConsigneeId = null;
                model.VehicleId = null;
            }
            if (model.TransportationMode.ToUpper() == "Conveyor Belt".ToUpper()
                   || model.TransportationMode.ToUpper() == "MGR/ OWN Wagon".ToUpper()
                   || model.TransportationMode.ToUpper() == "End Use Plant inside the lease area".ToUpper()
                   || model.TransportationMode.ToUpper() == "Ropeway".ToUpper()
                    || model.TransportationMode.ToUpper() == "Slurry Pipeline".ToUpper()
                 )
            {
                if (model.TotalQty == 0)
                {
                    TempData["AckMessage"] = "Total Weight should be non-zero";
                    return RedirectToAction("TransitPassTP", "eTransitPass");
                }
                else
                {
                    if (model.Remaining_Qty >= model.TotalQty)
                    {
                        model.Remarks = model.Remarks2;
                        Output = _objIticketmodel.AddTransitPassDetails(model);

                        if (Output.OutputResult == "1")
                        {
                            return RedirectToAction("TPConveyorMGRDesign", "eTransitPass", new { id = Output.TPID });
                        }
                        else
                        {
                            TempData["AckMessage"] = "Transit Pass Not Generated !";
                            return RedirectToAction("TransitPassTP", "eTransitPass");
                        }
                    }
                    else
                    {
                        TempData["AckMessage"] = "You have entered more qty than Bulk Permit Remaining Qty!";
                        return RedirectToAction("TransitPassTP", "eTransitPass");
                    }
                }
            }
            else if (model.TransportationMode.ToUpper() == "Inside Railway Siding".ToUpper())
            {
                if (model.RailQty == 0)
                {
                    TempData["AckMessage"] = "Total Weight should be non-zero";
                    return RedirectToAction("TransitPassTP", "eTransitPass");
                }
                else
                {
                    if (model.Remaining_Qty >= model.RailQty)
                    {
                        model.Remarks = model.Remarks3;
                        model.TotalQty = model.RailQty;
                        Output = _objIticketmodel.AddTransitPassDetails(model);

                        //if (Output == "1")
                        //{
                        //    return RedirectToAction("RailTPDesign", "TransitPass", new { id = Output.TPID });
                        //}
                        //else
                        //{
                        //    TempData["AckMessage"] = "Transit Pass Not Generated !";
                        //    return RedirectToAction("Pass", "TransitPass");
                        //}
                    }
                    else
                    {
                        TempData["AckMessage"] = "You have entered more qty than Bulk Permit Remaining Qty!";
                        return RedirectToAction("TransitPassTP", "eTransitPass");
                    }
                }
            }
            else if (Tpoffline == 0)
            {
                Output = _objIticketmodel.AddTransitPassDetails(model);

                if (Output.OutputResult == "1")
                {
                    if (Tpoffline == 0)
                    {
                        TempData["AckMessage"] = "Offline Transit Pass Generated Successfully.";
                        return RedirectToAction("TransitPassTP", "eTransitPass");
                    }
                    else
                    {
                        if (model.ForwardingNoteID > 0)
                        {
                            return RedirectToAction("PassReportDesignForwardingView", "eTransitPass", new { id = Output.TPID });
                        }
                        else
                        {
                            return RedirectToAction("PassReportDesignView", "eTransitPass", new { id = Output.TPID });
                        }
                    }
                }
                else
                {
                    TempData["AckMessage"] = "Transit Pass Not Generated !";
                    return RedirectToAction("TransitPassTP", "eTransitPass");
                }
            }
            else if (model.NetWeight_Qty == 0)
            {
                TempData["AckMessage"] = "Net weight should not be zero";
                return RedirectToAction("TransitPassTP", "eTransitPass");
            }
            else
            {
                if (model.ForwardingNoteID > 0)
                {
                    Output = _objIticketmodel.AddTransitPassDetails(model);

                    if (Output.OutputResult == "1")
                    {
                        return RedirectToAction("PassReportDesignForwardingView", "eTransitPass", new { id = Output.TPID });
                    }
                    else
                    {
                        TempData["AckMessage"] = "Transit Pass Not Generated !";
                        return RedirectToAction("TransitPassTP", "eTransitPass");
                    }
                }
                else
                {
                    if (model.Remaining_Qty >= model.NetWeight_Qty)
                    {
                        Output = _objIticketmodel.AddTransitPassDetails(model);

                        if (Output.OutputResult == "1")
                        {
                            if (model.ForwardingNoteID > 0)
                            {
                                return RedirectToAction("PassReportDesignForwardingView", "eTransitPass", new { id = Output.TPID });
                            }
                            else
                            {
                                return RedirectToAction("PassReportDesignView", "eTransitPass", new { id = Output.TPID });
                            }
                        }
                        else
                        {
                            TempData["AckMessage"] = "Transit Pass Not Generated !";
                            return RedirectToAction("TransitPassTP", "eTransitPass");
                        }
                    }
                    else
                    {
                        TempData["AckMessage"] = "Transit Pass not saved.Transit Pass exceeded the permited qty!";
                        return RedirectToAction("TransitPassTP", "eTransitPass");
                    }
                }
            }
            return View();
        }
        /// <summary>
        /// Added by suroj on 15-jul-2021 to print eTransit Pass
        /// </summary>
        /// <returns></returns>
        public IActionResult PassReportDesignView(int? id = 0)
        {
            int id1 =Convert.ToInt32( id);//Hardcoded by Shesansu
            ViewBag.userrole = "TP";
            ViewBag.usertype = "test";
            ViewBag.mineraltype = "Major Mineral";
            TransitPassModel objtransit = new TransitPassModel();
            try
            {
                objtransit.TransitPassId = id1;//Changed by shesansu 
                var epermit = _objIticketmodel.PassReportDesignView(objtransit);
                string barcode = epermit.TransitPassNumber;

                byte[] BarCode;

                Bitmap bitMap = new Bitmap(barcode.Length * 40, 80);

                //The Graphics library object is generated for the Image.
                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    //The installed Barcode font.
                    Font oFont = new Font("IDAutomationHC39M Free Version", 16);
                    PointF point = new PointF(2f, 2f);

                    //White Brush is used to fill the Image with white color.
                    SolidBrush whiteBrush = new SolidBrush(Color.White);
                    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                    //Black Brush is used to draw the Barcode over the Image.
                    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
                }

                using (MemoryStream Mmst = new MemoryStream())
                {
                    bitMap.Save(Mmst, ImageFormat.Png);
                    BarCode = Mmst.GetBuffer();
                    ViewBag.BarcodeImage = BarCode != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])BarCode) : "";

                }
                return View(epermit);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {

                objtransit = null;
            }

        }

        /// <summary>
        /// Added by suroj on 29-jul-2021 to fetch RTP Application no whose transportmode is inside railways and road-rail
        /// </summary>
        /// <param name="objtran"></param>
        /// <returns></returns>
        public JsonResult GetForwardingNote(int bulkPermitId, int purchaserconsigneeid)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            TransitPassModel objtransit = new TransitPassModel();

            try
            {
                objtransit.BulkPermitId = bulkPermitId;
                objtransit.PurchaserConsigneeId = purchaserconsigneeid;
                objtransit.userid = userid;
                objtransit.ForwardingNoteID = 0;
                var epermit = _objIticketmodel.GetForwardingNote(objtransit);

                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }
        public JsonResult GetPendingQty(int bulkPermitId, int purchaserconsigneeid, int ForwardingNoteid)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            TransitPassModel objtransit = new TransitPassModel();

            try
            {
                objtransit.BulkPermitId = bulkPermitId;
                objtransit.PurchaserConsigneeId = purchaserconsigneeid;
                objtransit.userid = userid;
                objtransit.ForwardingNoteID = ForwardingNoteid;
                var epermit = _objIticketmodel.GetForwardingNote(objtransit);

                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }

        public ActionResult TPConveyorMGRDesign(int id)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            ViewBag.usertype = "lessee";
            TransitPassModel objtransit = new TransitPassModel();
            try
            {
                objtransit.TransitPassId = id;
                objtransit.userid = userid;
                var epermit = _objIticketmodel.RailTPDataFetch(objtransit);

                return View(epermit);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {

                objtransit = null;
            }

        }
        public ActionResult PassReportDesignForwardingView(int id)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            ViewBag.usertype = "lessee";
            TransitPassModel objtransit = new TransitPassModel();
            try
            {
                objtransit.TransitPassId = id;
                objtransit.userid = userid;
                var epermit = _objIticketmodel.RailTPDataFetch(objtransit);
                
                return View(epermit);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {

                objtransit = null;
            }
            
        }

        public ActionResult MineralReceive()
        
        {
            //List<EndUser_ETransitPassModel> objtransit = new List<EndUser_ETransitPassModel>();
            EndUser_ETransitPassModel objmodel = new EndUser_ETransitPassModel();
            //try
            //{

            //    objmodel.userid = 387;
            //    var epermit = _objIticketmodel.MineralReceiveData(objmodel);
            //    foreach (var _value in epermit)
            //    {
            //       objmodel = new EndUser_ETransitPassModel();
            //        objmodel.EcQuantity = _value.EcQuantity;
            //    }
            //    return View(objmodel);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    throw;
            //}
            //finally
            //{
            //    objtransit = null;

            //}
            return View(objmodel);

        }
        public JsonResult PermitNoBind()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            List<EndUser_ETransitPassModel> objtransit = new List<EndUser_ETransitPassModel>();
            EndUser_ETransitPassModel objmodel = new EndUser_ETransitPassModel();
            try
            {

                objmodel.userid = userid;
                var epermit = _objIticketmodel.BindReceivePermit(objmodel);
                ViewBag.Upcomming_Trips = epermit.Count();
                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }


        public JsonResult GetEndUser_ETransitPassDetails(string TrnasitPassNO)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            List<EndUser_ETransitPassModel> objtransit = new List<EndUser_ETransitPassModel>();
            EndUser_ETransitPassModel objmodel = new EndUser_ETransitPassModel();
            try
            {

                objmodel.userid = userid;
                objmodel.TransitPassNo = TrnasitPassNO;
                var epermit = _objIticketmodel.GetGridData(objmodel);
               

                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }

        /// <summary>
        /// Added by suroj on 23-aug-2021 to add receive mineral
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult ReceiveMineral(EndUser_ETransitPassModel model)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;

            if (model.ReceivedWeight == 0)
            {
                TempData["UserMessage"] = "Enter Received Qty.";
                return RedirectToAction("MineralReceive");
            }
            else
            {
               
                decimal? totalReceive = model.TotalReceivedQuantity + Convert.ToDecimal(model.ReceivedWeight); ;

                if (totalReceive > model.EcQuantity)
                {

                    string msg = "Received quantity (" + totalReceive + ") exceeds the limit of EC Quantity (" + model.EcQuantity + ") !";
                    return RedirectToAction("MineralReceive", new { AlertMsg = msg });

                }
                model.userid = userid;
                string OutputResult = _objIticketmodel.UpdateMineralReceipt(model);
                if (OutputResult == "1")
                {
                    TempData["UserMessage"] = "Mineral received successfully.Your trip has been closed.";
                }
                else if (OutputResult == "2")
                {
                    TempData["UserMessage"] = "You cannot received this TP because this TP is in cancelled mode. For more info, please contact to your sender.";
                }
                else
                {
                    //TempData["UserMessage"] = "Mineral is not received.Please try again!";
                }
                ModelState.Clear();
                return RedirectToAction("MineralReceive");
            }
            
        }
        /// <summary>
        /// Added by suroj on 23-aug-2021 to show Royality Transit pass
        /// </summary>
        /// <returns></returns>
        public ActionResult RPTP()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            try
            {
                ViewBag.Permit=bindPermit();

                //ViewBag.Permit = epermit.ToList().Select(c => new SelectListItem
                //{
                //    Text = c.BulkPermitNo,
                //    Value = c.BulkPermitId.ToString(),

                //}).ToList();
                ViewBag.userid = userid;
                ViewBag.DateOfDispatche = DateTime.Now.ToString();
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
               

            }
            
        }
        private SelectList bindPermit()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            List<RPTPModel> objtransit = new List<RPTPModel>();
            RPTPModel objmodel = new RPTPModel();
            objmodel.UserId = userid;
            var epermit = _objIticketmodel.GetApprovedBulkPermitListRPTP(objmodel);
            return new SelectList(epermit, "BulkPermitId", "BulkPermitNo");
        }
        /// <summary>
        /// Added by suroj on 24-Aug-2021 to fetch details against permitNO RPTP
        /// </summary>
        /// <param name="objRPTP"></param>
        /// <returns></returns>
        public JsonResult GetDataByBulkPermitId(int id)
        {
            RPTPModel objtransit = new RPTPModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            try
            {
                objtransit.BulkPermitId = id.ToString();
                objtransit.UserId = userid;
                var epermit = _objIticketmodel.GetDataByBulkPermitId(objtransit);

                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }

        /// <summary>
        /// Added by suroj on 08-jul-2021 to fetch details like mineral name,address agaiinst permit number change evt in Transit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>

        public JsonResult GetCascadePurchaserConsigneeRPTP(int id)
        {
            RPTPModel objtransit = new RPTPModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            try
            {
                objtransit.BulkPermitId = id.ToString();
                objtransit.UserId = userid;
                var epermit = _objIticketmodel.GetCascadePurchaserConsigneeRPTP(objtransit);

                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }

        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID  RPTP
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        public JsonResult GetDataByPurchaserConsigneeIdRPTP(int bulkPermitId, int PcId)
        {
            RPTPModel objtransit = new RPTPModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;

            try
            {
                objtransit.BulkPermitId = bulkPermitId.ToString();
                objtransit.PurchaserConsigneeId = PcId;
                objtransit.UserId = userid;
                var epermit = _objIticketmodel.GetDataByPurchaserConsigneeIdRPTP(objtransit);

                return Json(epermit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }

        }
        /// <summary>
        /// Added by suroj on 25-aug-2021 to add RPTP details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RPTP(RPTPModel model, string RoyaltyPaidTransitPassId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            ReturnOuputResultRPTP objreturn = new ReturnOuputResultRPTP();
            if (string.IsNullOrEmpty(model.BulkPermitId))
            {
                ModelState.AddModelError("BulkPermitId", "E-Permit is required");
                ViewBag.Permit = null;
            }
            
            if (string.IsNullOrEmpty(model.PurchaserContactNumber))
            {
                ModelState.AddModelError("PurchaserContactNumber", "Purchaser ContactNumber Name is required");

            }
           
            
            if (ModelState.IsValid)
            {


                if (model.TransportationMode == "" || model.TransportationMode == null)
                {
                    model.TransportationMode = "Road";
                }

                if (model.PurchaserType == "Registered")
                {
                    model.PurchaserType = null;
                    model.PurchaserSubType = null;
                    model.PurchaserName = null;
                    model.PurchaserContactNumber = null;
                    if (model.UnRegistredVehicleTypeId != "Tractor")
                    {
                        model.UnRegistredWithTractorVehicleId = null;
                        model.UnRegistredWithTractorVehicleOwner = null;
                    }
                    else if (model.UnRegistredVehicleTypeId == "Tractor")
                    {
                        model.UnRegistredWithoutTractorVehicleId = null;
                        model.UnRegistredWithoutTractorVehicleOwner = null;
                    }
                }
                else if (model.PurchaserType == "Un-registered")
                {
                    model.PurchaserConsigneeId = null;
                    model.VehicleId = null;
                }
                model.UserId = userid;
                model.Tpoffline = 1;
                objreturn = _objIticketmodel.AddData(model);

                if (objreturn.OutputResult == "1")
                {
                    //TempData["AckMessage"] = "Royalty Paid Transit Pass Generated Successfully";
                }
                else
                {
                    TempData["AckMessage"] = "Something Went Wrong !";
                }
                return RedirectToAction("RPTPPassReportDesign", "eTransitPass", new { id = objreturn.RPTPID });
            }
            else
            {
                ViewBag.Permit=bindPermit();
                return View();
            }
           
        }
        /// <summary>
        /// Added by suroj on 26-08-21 to print RPTP
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult RPTPPassReportDesign(int id )
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            ViewBag.usertype = usertype;
            RPTPModel model = new RPTPModel();
            try
            {

                //  model.RoyaltyPaidTransitPassId = 874252;//Dinesh 6may22
                model.RoyaltyPaidTransitPassId = id;
                model.UserId = userid;
                model = _objIticketmodel.getRecordForReport(model);
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                model = null;
            }
            
            

        }

        //[HttpPost]
        //public ActionResult UserWiseTPConfiguration(UserWiseTPConfigurationViewModel model, string id = "0")
        //{
        //    if (id != "0")
        //    {
        //        model.ID = Convert.ToInt32(protector.Encode(id));

        //    }
        //        ReturnOuputResult Output = new ReturnOuputResult();
        //    model.CreatedBy = userid;
        //    if (string.IsNullOrEmpty(model.UserID))
        //    {
        //        ModelState.AddModelError("User Name", "User Name is required");
        //    }
        //    else //if (ModelState.IsValid)
        //    {
        //        Output = _objIticketmodel.AddUserWiseTPConfiguration(model);

        //        if (Output.OutputResult == "1")
        //        {
        //            TempData["Masg"] = "success !";                   
        //        }
        //        else
        //        {
        //            TempData["Masg"] = "Failed !";                   
        //        }
        //    }
        //    return RedirectToAction("UserWiseTPConfiguration", "eTransitPass");
        //}

        //[IgnoreAntiforgeryToken]
        //public ActionResult DeleteUserWiseTPConfiguration( string id="0")
        //{
        //    UserWiseTPConfigurationViewModel model = new UserWiseTPConfigurationViewModel();
        //     ReturnOuputResult Output = new ReturnOuputResult();
        //    model.CreatedBy = userid;
        //    model.ID = Convert.ToInt32(protector.Encode(id));
        //    model.Chk = 2;
        //    Output = _objIticketmodel.AddUserWiseTPConfiguration(model);

        //        if (Output.OutputResult == "1")
        //        {
        //            TempData["Masg"] = "success !";
        //        }
        //        else
        //        {
        //            TempData["Masg"] = "Failed !";
        //        }
            
        //    return RedirectToAction("ListUserWiseTPConfiguration", "eTransitPass");
        //}

        
        //public ActionResult UserWiseTPConfiguration(string id = "0")
        
        //{
        //    ViewBag.usertype = usertype;
        //    UserWiseTPConfigurationViewModel model = new UserWiseTPConfigurationViewModel();

                        

        //    try
        //    {
        //        if (id != "0")
        //        {
        //            int ID = Convert.ToInt32(protector.Encode(id));
        //            UserWiseTPConfigurationModel _UserWiseTPConfigurationModel = new UserWiseTPConfigurationModel();
        //            _UserWiseTPConfigurationModel.ID = ID;
        //            List<UserWiseTPConfigurationModel> ListUserWiseTPConfigurationModel = new List<UserWiseTPConfigurationModel>();
        //            ListUserWiseTPConfigurationModel = _objIticketmodel.ListUserWiseTPConfiguration(_UserWiseTPConfigurationModel);
        //            _UserWiseTPConfigurationModel = ListUserWiseTPConfigurationModel.FirstOrDefault();

        //            model.DistrictID = _UserWiseTPConfigurationModel.DistrictID;
        //            model.TransportationModeID = _UserWiseTPConfigurationModel.TransportationModeID;
        //            model.UserTypeID = _UserWiseTPConfigurationModel.UserTypeID;
        //            //model.UserName = _UserWiseTPConfigurationModel.UserName;
        //            model.UserID = _UserWiseTPConfigurationModel.UserID;

        //            model.IntigrationWithWB = _UserWiseTPConfigurationModel.WBIntegration;
        //            model.CheckStampingValidity = _UserWiseTPConfigurationModel.CheckStampingValidity;
        //            model.eTPGenrationMode = _UserWiseTPConfigurationModel.GenerationMode;
        //            model.ID = ID;



        //        }


        //        ViewBag.Button = "Submit";
        //        EmpDropDown objEmpDropDown = new EmpDropDown();
        //        PurchaserConsigneePermitModel PC = new PurchaserConsigneePermitModel();
        //        #region district
        //        ViewBag.District = Enumerable.Empty<SelectListItem>();

        //        objEmpDropDown.Action = "District";
        //        objEmpDropDown.Stateid = 7;
        //        var District = _objPurchaser.Dropdown(objEmpDropDown);

        //        ViewBag.DistrictList = District.ToList().Select(c => new SelectListItem
        //        {
        //            Text = c.Text,
        //            Value = c.value.ToString(),

        //        }).ToList();
        //        #endregion


        //        #region transportMode
        //        ViewBag.TransportationModeId = Enumerable.Empty<SelectListItem>();
        //        PC.UserId = userid;
        //        var TransportationModeId = _objPurchaser.GetTransportationModeList(PC);
        //        ViewBag.TransportationModeList = TransportationModeId.ToList().Select(c => new SelectListItem
        //        {

        //            Text = c.TransportationMode,
        //            Value = c.TransportationModeId.ToString(),

        //        }).ToList();

        //        #endregion

        //        List<SelectListItem> UserTypeList = new List<SelectListItem>();
        //        UserTypeList.Add(new SelectListItem { Value = "1", Text = "Lessee" });
        //        UserTypeList.Add(new SelectListItem { Value = "2", Text = "Licensee" });


        //        ViewBag.UserTypeList = UserTypeList;

        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        model = null;
        //    }

        //    }

        //public ActionResult ListUserWiseTPConfiguration()
        //{
        //    UserWiseTPConfigurationModel _UserWiseTPConfigurationModel = new UserWiseTPConfigurationModel();
        //    List<UserWiseTPConfigurationModel> ListUserWiseTPConfigurationModel = new List<UserWiseTPConfigurationModel>();
        //    try
        //    {
             
        //    ListUserWiseTPConfigurationModel = _objIticketmodel.ListUserWiseTPConfiguration(_UserWiseTPConfigurationModel);
        //    return View( ListUserWiseTPConfigurationModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        _UserWiseTPConfigurationModel = null;
        //        ListUserWiseTPConfigurationModel = null;
        //    }
        //}
    }
}
