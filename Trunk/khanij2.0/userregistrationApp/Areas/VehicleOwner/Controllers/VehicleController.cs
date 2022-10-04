// ***********************************************************************
//  Controller Name          : Vehicle
//  Desciption               : Vehicle  Add,Update,Delete,View,Trips,Renewal
//  Created By               : Akshaya Dalei
//  Created On               : 25 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using userregistrationApp.ActionFilter;
using userregistrationApp.Areas.VehicleOwner.Models.Vehicles;
using userregistrationApp.Helper;
using userregistrationApp.Web;
using userregistrationEF;

namespace userregistrationApp.Areas.VehicleOwner.Controllers
{
    [Area("VehicleOwner")]
    public class VehicleController : Controller
    {
        private readonly IVehicleModel vehicleModel;
        private readonly IHostingEnvironment hostingEnvironment;
        IOptions<KeyList> _objKeyList;
        List<Vehicle> lstVehicles = new List<Vehicle>();
        VehicleCreateModel vehicleCreateModel = new VehicleCreateModel();
        Vehicle vehicle = new Vehicle();
        VehicleBreakdown vehicleBreakdown = new VehicleBreakdown();
        MessageEF messageEF = new MessageEF();
        public VehicleController(IVehicleModel vehicleModel, IHostingEnvironment hostingEnvironment,
            IOptions<KeyList> objKeyList, IDataProtectionProvider dataProtectionProvider)
        {
            this.vehicleModel = vehicleModel;
            this.hostingEnvironment = hostingEnvironment;
            _objKeyList = objKeyList;
        }

        #region Add Vehicle
        #region Add Vehicle View Page
        /// <summary>
        /// To View Add Vehicle
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IActionResult AddVehicle()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.msg = TempData["Message"].ToString();
            }
            lstVehicles = vehicleModel.ViewVehicleType(vehicleCreateModel);
            ViewData["VehicleType"] = lstVehicles;

            lstVehicles = vehicleModel.ViewVehicleUnit(vehicleCreateModel);
            ViewData["VehicleUnit"] = lstVehicles;

            return View(vehicleCreateModel);
        }
        #endregion

        #region Save Vehicle
        /// <summary>
        /// To Save Vehicle
        /// </summary>
        /// <param name="vehicleCreateModel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddVehicle(VehicleCreateModel vehicleCreateModel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            vehicleCreateModel.VehicleID = vehicleCreateModel.VehicleID ?? 0;
            vehicleCreateModel.ActiveStatus = (vehicleCreateModel.ActiveStatus == null ? true : vehicleCreateModel.ActiveStatus);
            vehicleCreateModel.IsGPSDevice = (vehicleCreateModel.IsGPSDevice == null ? 0 : vehicleCreateModel.IsGPSDevice);


            string uniqueRCBook = null;
            string uniquePermit = null;
            string fileRCBookPath = null;
            string filePermitPath = null;
            #region RCBook
            if (vehicleCreateModel.RCBook != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "VehicleOwner");
                uniqueRCBook = Guid.NewGuid().ToString() + "_" + vehicleCreateModel.RCBook.FileName;
                fileRCBookPath = Path.Combine(uploadsFolder, uniqueRCBook);
                vehicleCreateModel.RCBook.CopyTo(new FileStream(fileRCBookPath, FileMode.Create));
            }
            #endregion

            #region PermitCopy
            if (vehicleCreateModel.PermitCopy != null)
            {

                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "VehicleOwner");
                uniquePermit = Guid.NewGuid().ToString() + "_" + vehicleCreateModel.PermitCopy.FileName;
                filePermitPath = Path.Combine(uploadsFolder, uniquePermit);
                vehicleCreateModel.PermitCopy.CopyTo(new FileStream(filePermitPath, FileMode.Create));
            }
            #endregion

            vehicle.VehicleID = vehicleCreateModel.VehicleID ?? 0;
            vehicle.VehicleNumber = vehicleCreateModel.VehicleNumber;
            vehicle.UserLoginID = profile.UserId;
            vehicle.VehicleTypeId = vehicleCreateModel.VehicleTypeId;
            vehicle.MaxNetWeight = vehicleCreateModel.MaxNetWeight;
            vehicle.RCBookNumber = vehicleCreateModel.RCBookNumber;
            vehicle.RegistrationFeesId = vehicleCreateModel.RegistrationFeesId;
            vehicle.RegistraionFees = vehicleCreateModel.RegistraionFees;
            vehicle.ActiveStatus = vehicleCreateModel.ActiveStatus;
            vehicle.UnitId1 = vehicleCreateModel.UnitId1;
            vehicle.GPSDeviceID = vehicleCreateModel.GPSDeviceID;
            vehicle.IsGPSDevice = vehicleCreateModel.IsGPSDevice;
            vehicle.CarryingCapacity = vehicleCreateModel.CarryingCapacity;
            vehicle.UnitId2 = vehicleCreateModel.UnitId2;
            vehicle.RcFile_Name = uniqueRCBook;
            vehicle.RcFile_Path = fileRCBookPath;
            vehicle.PermitFile_Name = uniquePermit;
            vehicle.PermitFile_Path = filePermitPath;

            messageEF = vehicleModel.Add(vehicle);

            if (messageEF.Satus == "1")
            {

                if (vehicleCreateModel.VehicleID == 0)
                    TempData["Message"] = "Vehicle details added successfully";
                else
                    TempData["Message"] = "Vehicle details updated successfully";

                if (vehicleCreateModel.FlagType == "Edit")
                {
                    return RedirectToAction("VehicleDetails");
                }
            }
            else
            {
                TempData["Message"] = "Vehicle details is not added.Please try again!";
            }

            return RedirectToAction("AddVehicle", "Vehicle");
        }
        #endregion

        #region Check Vehicle No
        /// <summary>
        /// To Check Vehicle No
        /// </summary>
        /// <param name="VehicleNo"></param>
        /// <returns></returns>
        public JsonResult CheckVehicleNo(string VehicleNo)
        {
            string msg = string.Empty;
            vehicle.VehicleNumber = VehicleNo;
            messageEF = vehicleModel.IsVehicleExist(vehicle);
            if (messageEF.Satus == null)
            {
                msg = "Vehicle No Not Exist";
            }
            else
            {
                msg = "Vehicle No Already Exist.Duplicate Not Allowed";
            }
            return Json(msg);
        }
        #endregion

        #region Vehicle Details
        /// <summary>
        /// To View Vehicle Details
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IActionResult VehicleDetails()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.msg = TempData["Message"].ToString();
            }
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            vehicle.UserLoginID = profile.UserId;
            lstVehicles = vehicleModel.View(vehicle);
            return View(lstVehicles);
        }
        #endregion

        #region Edit Vehicle
        /// <summary>
        /// To Edit Vehicle
        /// </summary>
        /// <param name="VehicleID,Flag"></param>
        /// <returns></returns>
        [SkipEncryptedTask]
        public IActionResult EditVehicle(string VehicleID, string Flag)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            lstVehicles = vehicleModel.ViewVehicleType(vehicleCreateModel);
            ViewData["VehicleType"] = lstVehicles;

            lstVehicles = vehicleModel.ViewVehicleUnit(vehicleCreateModel);
            ViewData["VehicleUnit"] = lstVehicles;

            vehicle.VehicleID =Convert.ToInt32(VehicleID);
            vehicle.UserLoginID = profile.UserId;
            vehicle.Check = 2;
            vehicle = vehicleModel.Edit(vehicle);
            vehicle.FlagType = Flag;
            vehicleCreateModel.VehicleID = vehicle.VehicleID;
            vehicleCreateModel.VehicleNumber = vehicle.VehicleNumber;
            vehicleCreateModel.FlagType = vehicle.FlagType;
            vehicleCreateModel.RcFile_Name = vehicle.RcFile_Name;
            vehicleCreateModel.RcFile_Path = vehicle.RcFile_Path;
            vehicleCreateModel.PermitFile_Name = vehicle.PermitFile_Name;
            vehicleCreateModel.PermitFile_Path = vehicle.PermitFile_Path;
            vehicleCreateModel.VehicleTypeId = vehicle.VehicleTypeId;
            vehicleCreateModel.CarryingCapacity = vehicle.CarryingCapacity;
            vehicleCreateModel.UnitID = vehicle.UnitID;
            vehicleCreateModel.MaxNetWeight = vehicle.MaxNetWeight;
            vehicleCreateModel.CarryingCapacity_UnitId = vehicle.CarryingCapacity_UnitId;
            vehicleCreateModel.IsGPSDevice = vehicle.IsGPSDevice;
            vehicleCreateModel.GPSDeviceID = vehicle.GPSID;

            return View(vehicleCreateModel);
        }
        #endregion

        #region Delete Vehicle
        /// <summary>
        /// To Delete Vehicle
        /// </summary>
        /// <param name="VehicleID"></param>
        /// <returns></returns>
        [SkipEncryptedTask]
        public IActionResult DeleteVehicle(string VehicleID)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            vehicle.UserLoginID = profile.UserId;
            vehicle.VehicleID =Convert.ToInt32(VehicleID);
            messageEF = vehicleModel.Delete(vehicle);
            if (messageEF.Satus == "1")
            {
                TempData["Message"] = "Vehicle Number deleted successfully.";
            }
            else
            {
                TempData["Message"] = "Vehicle Number is not Deleted.Please try again!";
            }
            return RedirectToAction("VehicleDetails");
        }
        #endregion

        #region Print Vehicle Details
        /// <summary>
        /// To Print Vehicle Details
        /// </summary>
        /// <param name="id,Type"></param>
        /// <returns></returns>
        [SkipEncryptedTask]
        public ActionResult PrintVehicleDetails(string VehicleID, string Type)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.Type = Type;
            vehicle.VehicleID =Convert.ToInt32(VehicleID);
            vehicle.UserLoginID = profile.UserId;
            vehicle.Check = 1;
            vehicle = vehicleModel.Edit(vehicle);
            return View(vehicle);
        }
        #endregion

        #region Vehicle Sticker
        /// <summary>
        /// To View Vehicle Sticker
        /// </summary>
        /// <param name="id,Type"></param>
        /// <returns></returns>
        [SkipEncryptedTask]
        public ActionResult VehicleSticker(string id, string Type)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.Type = Type;
            vehicle.VehicleID =Convert.ToInt32(id);
            vehicle.UserLoginID = profile.UserId;
            vehicle.Check = 1;
            vehicle.Type = Type;
            vehicle = vehicleModel.Edit(vehicle);
            return View(vehicle);
        }
        #endregion

        #region Vehicle Renewal
        /// <summary>
        /// Vehicle Renewal Details
        /// </summary>
        /// <param name="VehicleID"></param>
        /// <returns></returns>
        [SkipEncryptedTask]
        public IActionResult VehicelRenewal(string VehicleID)
        {
            vehicle.VehicleID =Convert.ToInt32(VehicleID);
            lstVehicles = vehicleModel.ViewVehicleRenewal(vehicle);
            return View(lstVehicles);
        }
        #endregion

        #region Vehicles Payment Details
        /// <summary>
        /// Vehicles Payment Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public IActionResult VehiclesPayment()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            lstVehicles = vehicleModel.IndivisualVehicleFees(vehicle);
            ViewBag.RegistrationFees = lstVehicles[0].RegistrationFees;

            vehicle.UserLoginID = profile.UserId; //29576; //profile.UserId;
            lstVehicles = vehicleModel.PaymentRemainingVehicle(vehicle);

            return View(lstVehicles);
        }
        public JsonResult Payment(string arr, string Fees, string total)
        {
            messageEF = vehicleModel.getRecordForReport(messageEF);
            ViewBag.arr = arr;
            ViewBag.total = total;

            var dataString = CustomQueryStringHelper.
            EncryptString("Payment", "VehiclePayment", "VehiclePayment", new { arr = arr, total = total, tranid = messageEF.Satus });
            return Json(new { result = "Redirect", url = _objKeyList.Value.Paymenturl + dataString });
            //return Json(new { result = "Redirect", url =_objKeyList.Value.Paymenturl+"/Payment/VehiclePayment/VehiclePayment?arr=" + ViewBag.arr + "&&total=" + ViewBag.total + "&&tranid=" + messageEF.Satus });

        }
        #endregion

        #region Vehicle Trips
        /// <summary>
        /// Vehicle Trips
        /// </summary>
        /// <param name="trip_Status,VehicleNo,From,To"></param>
        /// <returns></returns>
        public IActionResult VehicleTrips(int? trip_Status, string VehicleNo, string From, string To)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ETransitPassModel eTransitPassModel = new ETransitPassModel();
            eTransitPassModel.UserId = profile.UserId;
            eTransitPassModel.TripStatus = trip_Status;
            eTransitPassModel.VehicleNumber = VehicleNo;
            eTransitPassModel.FromDate = From;
            eTransitPassModel.ToDate = To;
            List<ETransitPassModel> lstETransitPassModel = vehicleModel.GetRunningClosedTripGridData(eTransitPassModel);
            return View(lstETransitPassModel);
        }
        #endregion

        #region Vehicle Break Down
        /// <summary>
        /// To View & Create Vehicle Break Down
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult VehicleBreakDown()
        {
            return View();
        }
        #endregion

        #region Get Break Down Details By TP No
        /// <summary>
        /// Get BreakDown Details By TP No
        /// </summary>
        /// <param name="TransitPassNo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDataByTp(string TransitPassNo)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            VehicleBreakdownTpDetails vehicleBreakdownTpDetails = new VehicleBreakdownTpDetails();
            if (!string.IsNullOrEmpty(TransitPassNo))
            {
                vehicleBreakdownTpDetails.TransitPassNo = TransitPassNo;
                vehicleBreakdownTpDetails.UserId = profile.UserId;
                vehicleBreakdownTpDetails = vehicleModel.GetTransitPassNoWiseData(vehicleBreakdownTpDetails); ;
            }
            return Json(vehicleBreakdownTpDetails);
        }
        #endregion

        #region Vehicle BreakDown Approval Letter
        /// <summary>
        /// Vehicle BreakDown Approval Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ApprovalLetter(string FromDate, string ToDate)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            List<VehicleBreakdown> lstVehicleBreakdown = new List<VehicleBreakdown>();
            vehicleBreakdown.FromDate = FromDate;
            vehicleBreakdown.ToDate = ToDate;
            vehicleBreakdown.UserId = profile.UserId;
            vehicleBreakdown.BreakDownId = 0;
            lstVehicleBreakdown = vehicleModel.GetApprovalLetter(vehicleBreakdown);
            return View(lstVehicleBreakdown);
        }
        #endregion

        #region Download Vehicle BreakDown Letter
        /// <summary>
        /// Download Vehicle BreakDown Letter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DownloadLetter(int? id)
        {
            List<VehicleBreakdown> lstVehicleBreakdown = new List<VehicleBreakdown>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                vehicleBreakdown.UserId = profile.UserId;
                vehicleBreakdown.BreakDownId = id;
                lstVehicleBreakdown = vehicleModel.GetApprovalLetter(vehicleBreakdown);
                vehicleBreakdown.TransitPassNo = lstVehicleBreakdown[0].TransitPassNo;
                vehicleBreakdown.ReasonOfBreakDown = lstVehicleBreakdown[0].ReasonOfBreakDown;
                vehicleBreakdown.LocationOfBreakDown = lstVehicleBreakdown[0].LocationOfBreakDown;
                vehicleBreakdown.VehicleNumber = lstVehicleBreakdown[0].VehicleNumber;
                vehicleBreakdown.BreakDownId = id;
            }
            catch (Exception)
            {

            }
            return View(vehicleBreakdown);
        }
        #endregion

        public IActionResult ManageVehicle()
        {
            return View();
        }

        /// <summary>
        /// for cancellation of all kind of payment.
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="paymentReqId"></param>
        /// <returns></returns>
        public JsonResult CancelPaymentTransaction(string paymentReqId, string PaymentType)
        {
            string OutputResult = string.Empty;
            if (!string.IsNullOrEmpty(paymentReqId) && !string.IsNullOrEmpty(PaymentType))
            {
                try
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    CancelVehiclePayment cancelVehiclePayment = new CancelVehiclePayment();
                    cancelVehiclePayment.paymentReqId = paymentReqId;
                    cancelVehiclePayment.PaymentType = PaymentType;
                    cancelVehiclePayment.UserId = profile.UserId;
                    #region if no payment response
                    messageEF = vehicleModel.CancelVehiclePaymentTransaction(cancelVehiclePayment);
                    if (!string.IsNullOrEmpty(Convert.ToString(messageEF.Satus)))
                    {
                        OutputResult = "SUCCESS";
                        return Json(OutputResult);
                    }
                    else
                    {
                        OutputResult = "FAILED";
                        return Json(OutputResult);
                    }

                    #endregion
                }

                catch (Exception ex)
                {
                    OutputResult = "FAILED";
                    return Json(OutputResult);

                }
            }
            else
            {
                OutputResult = "FAILED";
                return Json(OutputResult);
            }

        }

        /// <summary>
        /// This action check the current status of payment which are awaited. 
        /// Here we need to call web api for the payment gateway and update respected bulkpermit.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="PaymentType"></param>
        /// <returns></returns>
        public JsonResult CheckPaymentCurrentStatus(string id, string PaymentType)
        {
            //PaymentRequest PM = new PaymentRequest();
            //string OutputResult = PM.PaymentStatusFromGateway(id, PaymentType);
            return Json("");
        }
        #endregion


    }
}