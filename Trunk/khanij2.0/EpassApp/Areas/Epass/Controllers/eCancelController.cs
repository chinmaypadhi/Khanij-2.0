using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpassApp.Areas.Epass.Models.MineralReceive;
using EpassApp.KhanijSecurity;
using EpassApp.Web;
using EpassEF;
using Microsoft.AspNetCore.Hosting;
using EpassApp.Areas.Epass.Models.eCancel;

namespace EpassApp.Areas.Epass.Controllers
{
    [Area("EPass")]
    public class eCancelController : Controller
    {
       
        private IeCancel _objIeCancel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly KhanijIDataProtection protector;
        int userid = 0;//194;//387;
        string usertype = string.Empty;//  "Licensee";
        public eCancelController(IeCancel objeCancel, IHostingEnvironment hostingEnvironment, KhanijIDataProtection khanijIDataProtection)
        {
            protector = khanijIDataProtection;
            
            _objIeCancel = objeCancel;

            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult eCancel()
        {
            
            List<eCancelModel> list = new List<eCancelModel>();
            eCancelModel objmodel = new eCancelModel();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                userid = Convert.ToInt32(profile.UserId);
                objmodel.UserId = userid;
                var epermit = _objIeCancel.eCancelPermit(objmodel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View();
        }

        [HttpGet]  //Dinesh 27Apr22
        public IActionResult TP_Cancel()
        {
            TPCancelModelEF model = new TPCancelModelEF();
           //TPCancelModelDDEF model = new TPCancelModelDDEF();
            List<TPCancelModelEF> listmodel = new List<TPCancelModelEF>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId); ;//16743,27805,28516; 
            model.Check = "2";
            model.FromDate = ""; // "01/03/2018"
            model.ToDate =""; //   "19/05/2022"

            try
            {
                if (ModelState.IsValid)
                {
                    listmodel = _objIeCancel.GetTP_Cancel(model);
                      foreach (var app in listmodel) {

                        if (app.SrNo != null)
                            model.SrNo = Convert.ToInt32(app.SrNo);
                        if (app.TransitPassId != null)
                            model.TransitPassId = Convert.ToInt32(app.TransitPassId);
                        if (app.CancellationId != null)
                            model.CancellationId = Convert.ToInt32(app.CancellationId);

                        model.SourceUserCode = Convert.ToString(app.SourceUserCode);
                        model.SourceUserName = Convert.ToString(app.SourceUserName);
                        model.SourceAddress = Convert.ToString(app.SourceAddress);

                        model.DesinationUserCode = Convert.ToString(app.DesinationUserCode);
                        model.DestUserName = Convert.ToString(app.DestUserName);
                        model.DesinationAddress = Convert.ToString(app.DesinationAddress);
                        model.TransportaionMode = Convert.ToString(app.TransportaionMode);
                        model.TransitPassNo = Convert.ToString(app.TransitPassNo);
                        model.BulkPermitNo = Convert.ToString(app.BulkPermitNo);
                        model.VehicleNo = Convert.ToString(app.VehicleNo);
                        model.NetWeight = Convert.ToString(app.NetWeight);

                        model.UserRemarks = Convert.ToString(app.UserRemarks);
                        model.DDRemarks = Convert.ToString(app.DDRemarks);
                        if (!(app.Status is DBNull))
                            model.Status = Convert.ToInt32(app.Status);
                        model.TpType = Convert.ToString(app.TpType);


                        model.CancellationDateTime = Convert.ToString(app.CancellationDateTime);
                        model.ApproveRejectDateTime = Convert.ToString(app.ApproveRejectDateTime);

                        model.RePrintCount = Convert.ToInt32(app.RePrintCount);
                        model.TPDispatchTime = Convert.ToString(app.TPDispatchTime);
                        model.TripStatus = Convert.ToString(app.TripStatus);
                        model.TPid = Convert.ToInt32(app.TPid);
                        // listmodel.Add(model);

                    }        
                }            
        
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                
            }
                ViewBag.ViewList = listmodel;
                return View();
        }
       

    }
}
