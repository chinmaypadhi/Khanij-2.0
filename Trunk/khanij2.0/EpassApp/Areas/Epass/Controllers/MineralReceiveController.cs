using EpassApp.Areas.Epass.Models.MineralReceive;
using EpassApp.KhanijSecurity;
using EpassApp.Web;
using EpassEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Controllers
{
    [Area("EPass")]
    public class MineralReceiveController : Controller
    {
        private IMineralReceiveNew _objIMineralReceive;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly KhanijIDataProtection protector;
        int userid = 0;//194;//387;
        string usertype = string.Empty;//  "Licensee";
        public MineralReceiveController(IMineralReceiveNew objIMineralReceive, IHostingEnvironment hostingEnvironment, KhanijIDataProtection khanijIDataProtection)
        {
            protector = khanijIDataProtection;
            _objIMineralReceive = objIMineralReceive;
            
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult MineralReceive() 
        {
            List<EndUser_ETransitPassModel> objtransit = new List<EndUser_ETransitPassModel>();
            EndUser_ETransitPassModel objmodel = new EndUser_ETransitPassModel();
            try
            {

                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                userid = Convert.ToInt32(profile.UserId);
                objmodel.userid = userid;
                var epermit = _objIMineralReceive.MineralReceiveData(objmodel);
                //foreach (var _value in epermit)
                //{
                //    objmodel = new EndUser_ETransitPassModel();
                //    objmodel.userid = userid;
                //    objmodel.EcQuantity = _value.EcQuantity;
                //}

                
                //return View(objmodel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            //finally
            //{
            //    objtransit = null;

            //}
            return View(objmodel);

        }
        public JsonResult PermitNoBind()
        {
            List<EndUser_ETransitPassModel> objtransit = new List<EndUser_ETransitPassModel>();
            EndUser_ETransitPassModel objmodel = new EndUser_ETransitPassModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            try
            {
                

                objmodel.userid = userid;
                var epermit = _objIMineralReceive.BindReceivePermit(objmodel);
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
            List<EndUser_ETransitPassModel> objtransit = new List<EndUser_ETransitPassModel>();
            EndUser_ETransitPassModel objmodel = new EndUser_ETransitPassModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            try
            {

                objmodel.userid = userid;
                objmodel.TransitPassNo = TrnasitPassNO;
                var epermit = _objIMineralReceive.GetGridData(objmodel);


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

        public ActionResult ReceiveMineral(EndUser_ETransitPassModel model)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            if (model.ReceivedWeight == 0)
            {
                TempData["UserMessage"] = "Enter Received Qty.";
                return RedirectToAction("MineralReceive");
            }
            else
            {

                //decimal? totalReceive = model.TotalReceivedQuantity + Convert.ToDecimal(model.ReceivedWeight); ;
                //update start Shyam sir 16-3-22
                //if (totalReceive > model.EcQuantity)
                //{

                //    string msg = "Received quantity (" + totalReceive + ") exceeds the limit of EC Quantity (" + model.EcQuantity + ") !";
                //    TempData["UserMessage"] = msg;
                //    return RedirectToAction("MineralReceive");
                //   // return RedirectToAction("MineralReceive", new { AlertMsg = msg });

                //}
                //update end Shyam sir 16-3-22
                model.userid = userid;
                string OutputResult = _objIMineralReceive.UpdateMineralReceipt(model);
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
                    TempData["UserMessage"] = "Mineral is not received.Please try again!";
                }
                ModelState.Clear();
                return RedirectToAction("MineralReceive");
            }

        }

        public ActionResult MineralReceiptReports(MineralReceiveModel objmodel)
        {

            List<EndUser_ETransitPassModel> objtransit = new List<EndUser_ETransitPassModel>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = Convert.ToInt32(profile.UserId);
            usertype = profile.UserType;
            // MineralReceiveModel objmodel = new MineralReceiveModel();
            try
            {

                objmodel.userid = userid;//528;//
                objmodel.UserType = usertype;//"Licensee";
                 var epermit = _objIMineralReceive.GetClosedGridData(objmodel);

                return View(epermit);
                //return Json(epermit);
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

    }
}
