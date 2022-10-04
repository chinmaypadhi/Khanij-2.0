using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using userregistrationApp.ActionFilter;
using userregistrationApp.Areas.Contractor.Models.ContractorBuilders;
using userregistrationApp.Areas.Contractor.Models.TailingDam;
using userregistrationApp.Areas.Contractor.Models.VTDVendor;
using userregistrationApp.Areas.WeightBridge.Models;
using userregistrationApp.Models.EncryptDecrypt;
using userregistrationApp.Models.MailService;
using userregistrationApp.Models.SMSService;
using userregistrationApp.Models.WebsiteMenu;
using userregistrationApp.Web;
using userregistrationEF;

namespace userregistrationApp.Areas.WeightBridge.Controllers
{
    [Area("WeightBridge")]
    public class WBIndependentController : Controller
    {
        private readonly IWebsiteMenuModel websiteMenuModel;
        private readonly IVTDVendor vTDVendor;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ISMSModel sMSModel;
        private readonly IMailModel mailModel;
        private readonly ITailingDamModel tailingDamModel;
        private readonly IAreaType objIareaType;
        private readonly IWeighbridgeMake objIwbmake;
        private readonly IWeighBridgeModelType objIwbmodeltype;
        private readonly IWeighBridge objIweighbridge;

        ViewWeighBridgeModel objviewweighbridge = new ViewWeighBridgeModel();
        MessageEF messageEF = new MessageEF();
        public WBIndependentController(IWebsiteMenuModel websiteMenuModel, IVTDVendor vTDVendor,
            IHostingEnvironment hostingEnvironment, ISMSModel sMSModel, IMailModel mailModel, ITailingDamModel tailingDamModel,
            IAreaType objIareaType, IWeighbridgeMake objIwbmake, IWeighBridgeModelType objIwbmodeltype, IWeighBridge objIweighbridge)
        {
            this.websiteMenuModel = websiteMenuModel;
            this.vTDVendor = vTDVendor;
            this.hostingEnvironment = hostingEnvironment;
            this.sMSModel = sMSModel;
            this.mailModel = mailModel;
            this.tailingDamModel = tailingDamModel;
            this.objIareaType = objIareaType;
            this.objIwbmake = objIwbmake;
            this.objIwbmodeltype = objIwbmodeltype;
            this.objIweighbridge = objIweighbridge;
        }
        [SkipImportantTask]
        public IActionResult IndependentRegistration()
        {
            ViewData["MainmenuTable"] = websiteMenuModel.GetMainmenulist();
            ViewData["FootermenuTable"] = websiteMenuModel.GetFootermenulist();
            List<CommonAddressDetails> lstDistrictDetails = tailingDamModel.GetStateDistrictList(new CommonAddressDetails() { });
            ViewData["DistrictDetails"] = lstDistrictDetails;
            AreaDetails objareadetails = new AreaDetails();
            ViewData["AreaType"] = objIareaType.GetLandTypeList(objareadetails);
            ViewWeighBridgeMakeModel objmakemodel = new ViewWeighBridgeMakeModel();
            ViewData["WBMake"] = objIwbmake.View(objmakemodel);
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            return View();
        }
        [SkipImportantTask]
        [HttpPost]
        public IActionResult IndependentRegistration(AddIndependentWeighBridgeModel obj)
        {
            //objviewweighbridge.WeighBridgeName = obj.WeighBridgeName;
            //messageEF = objIweighbridge.WBCheck(objviewweighbridge);
            obj.Location = "Outside Lease";
            obj.WeighBridgeType = "Independent";
            obj.UserID = 1;
            obj.District = "Test";
            obj.UserType = "Weighbridge Owner";
            string uniquestampcopy = "";
            string uniquestampcopypath = "";
            if (obj.StampCopy != null)
            {

                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/WeighBridge");
                uniquestampcopy = Guid.NewGuid().ToString() + "_" + obj.StampCopy.FileName;
                uniquestampcopypath = Path.Combine(uploadsFolder, uniquestampcopy);
                obj.StampCopy.CopyTo(new FileStream(uniquestampcopypath, FileMode.Create));
                obj.StampCopyFilePath = uniquestampcopy;
            }
            obj.StampCopy = null;
            messageEF = objIweighbridge.WBIndependentRegister(obj);
            int Outputres = Convert.ToInt32(messageEF.Satus);
            TempData["SuccessMessage"] = " Your Application Number is " + messageEF.Msg + ". Approval of your Application is Pending at Directorate of Geology and Mining, Chhattisgarh";
            return RedirectToAction("IndependentRegistration", "WBIndependent");
            
        }
        [SkipImportantTask]
        public JsonResult GetWBModelByMake(string makeid)
        {
            ViewWeighBridgeModelTypeModel obj = new ViewWeighBridgeModelTypeModel();
            obj.WeighBridgeMakeID = makeid;
            List<ViewWeighBridgeModelTypeModel> list = objIwbmodeltype.ViewByMake(obj);
            return Json(list);
        }
    }
}
