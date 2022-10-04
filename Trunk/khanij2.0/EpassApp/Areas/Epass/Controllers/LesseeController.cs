using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpassApp.Areas.Epass.Models.TPCancel;
using EpassApp.Web;
using EpassEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EpassApp.Areas.Epass.Controllers
{
    [Area("EPass")]
    public class LesseeController : Controller
    {
        TransitpassCancelEF objeTranitpassEF = new TransitpassCancelEF();
        MessageEF objobjmodel = new MessageEF();
        private ITranitPassDetail _objTransitmodel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly KhanijSecurity.KhanijIDataProtection protector;
        string OutputResult = "";

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult ePassConfiguration()
        //{
        //    return View();
        //}
        public LesseeController(ITranitPassDetail objeTransitpass, IHostingEnvironment hostingEnvironment, KhanijSecurity.KhanijIDataProtection khanijIDataProtection)
        {
            protector = khanijIDataProtection;
            _objTransitmodel = objeTransitpass;
            this.hostingEnvironment = hostingEnvironment;
        }
        
        [HttpGet]    ////Dinesh 25Apr2022 
        public IActionResult eTransitPassDetails(/*string id , string ePermit*/)
        {
            TransitpassCancelEF model = new TransitpassCancelEF();
            List<TransitpassCancelEF> listmodel = new List<TransitpassCancelEF>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);
           
            try
            {
                
                if (ModelState.IsValid)
                {
                    listmodel = _objTransitmodel.GeteTransitpassDetails(model);
                     foreach (var app in listmodel)
                    // for( var i=0;i<listmodel.Count;i++)
                    {
                        //model.SrNo = (i + 1);
                        if (app.TPID != null)
                        {
                            model.TPID = Convert.ToString(app.TPID);//Convert.ToInt32(app.TransitPassID);
                        }
                        if (app.DateOfDispatche != null)
                        {
                            model.str_DateOfDispatch = Convert.ToString(app.DateOfDispatche);
                        }
                        if (app.PurchaserConsigneeId != null)
                        {
                            model.PurchaserConsigneeId = Convert.ToInt32(app.PurchaserConsigneeId);
                        }
                        if (app.BulkPermitID != null)
                        {
                            model.BulkPermitID = Convert.ToInt32(app.BulkPermitID);
                        }
                        model.TransitPassNo = Convert.ToString(app.TransitPassNo);
                        model.BulkPermitNo = Convert.ToString(app.BulkPermitNo);
                        model.PurchaserConsigneeName = Convert.ToString(app.PurchaserConsigneeName);
                        model.DriverName = Convert.ToString(app.DriverName);
                        model.DONumber = Convert.ToString(app.DONumber);
                        model.Remarks = Convert.ToString(app.Remarks);
                       
                        if (app.Remarks != null)
                        {
                            model.Remarks = Convert.ToString(app.Remarks);
                        }
                        if (app.TareWeight != null)
                        {
                            model.TareWeight = Convert.ToDecimal(app.TareWeight);
                        }
                        if (app.GrossWeight != null)
                        {
                            model.GrossWeight = Convert.ToDecimal(app.GrossWeight);
                        }
                        if (app.TransporterId != null)
                        {
                            model.TransporterId = Convert.ToInt32(app.TransporterId);
                        }
                        if (app.TransportationModeId != null)
                        {
                            model.TransportationModeId = Convert.ToInt32(app.TransportationModeId);
                        }
                        model.VehicleNumber = Convert.ToString(app.VehicleNumber);
                        model.VehicleTypeName = Convert.ToString(app.VehicleTypeName);
                        if (app.NetWeight != null)
                        {
                            model.NetWeight = Convert.ToDecimal(app.NetWeight);
                        }
                        


                        model.MineralName = Convert.ToString(app.MineralName);
                        model.MineralNature = Convert.ToString(app.MineralNature);
                        model.UnitName = Convert.ToString(app.UnitName);
                        model.MineralGradeName = Convert.ToString(app.MineralGradeName);
                        model.TransportationMode = !string.IsNullOrEmpty(Convert.ToString(app.TransportationMode)) ? Convert.ToString(app.TransportationMode) : "";
                        model.INTTRIPSTATUS = !string.IsNullOrEmpty(Convert.ToString(app.INTTRIPSTATUS)) ? Convert.ToString(app.INTTRIPSTATUS) : "";
                        model.TRIPSTATUS = !string.IsNullOrEmpty(Convert.ToString(app.TRIPSTATUS)) ? Convert.ToString(app.TRIPSTATUS) : "";
                        if (app.RePrintStatus!=null)
                        {
                            model.RePrintStatus = !string.IsNullOrEmpty(Convert.ToString(app.RePrintStatus)) ? Convert.ToString(app.RePrintStatus) : "";
                        }
                        if (app.CancelStatus != null)
                        {
                            app.CancelStatus = Convert.ToInt32(app.CancelStatus);
                        }
                        if (app.CancellationDateTime==null)
                        {
                            model.CancellationDateTime = !string.IsNullOrEmpty(Convert.ToString(app.CancellationDateTime)) ? Convert.ToString(app.CancellationDateTime) : "-";
                            
                        }
                        if (app.ApproveRejectDateTime == null)
                        {
                            model.ApproveRejectDateTime = !string.IsNullOrEmpty(Convert.ToString(app.ApproveRejectDateTime)) ? Convert.ToString(app.ApproveRejectDateTime) : "";
                        }
                        
                    }
                 }

            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                
            }
           
            ViewBag.ViewList = listmodel;
            return View();

        }
       
        [HttpPost]////Dinesh 25Apr2022
        public JsonResult TPCancel(string Id, string Remarks, string BulkPermitNO)
        {
            //int Id, string Remarks, string BulkPermitNO
            TransitpassCancelEF model = new TransitpassCancelEF();
            MessageEF obj = new MessageEF();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = Convert.ToInt32(profile.UserId);        
            
            try
            {
                model.TPID = Id;
                model.Remarks = Remarks;
                model.BulkPermitNo = BulkPermitNO;
                model.UserLoginId = profile.UserLoginId;
                obj = _objTransitmodel.TPCancel(model);
                OutputResult = obj.Satus;
            }
            catch(Exception ex)
            {
                return Json(OutputResult);
            }
            return Json(OutputResult);
        }
    }
}
