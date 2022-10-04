using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Areas.Master.Models.PaymentHead;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class PaymentHeadMasterController : Controller
    {
        private readonly ISinglePaymentHeadMasterModel singlePaymentHeadMasterModel;
        SinglePaymentHeadModel singlePaymentHeadModel = new SinglePaymentHeadModel();
        PaymentHeadViewModel paymentHeadViewModel = new PaymentHeadViewModel();
        MessageEF messageEF = new MessageEF();
        public PaymentHeadMasterController(ISinglePaymentHeadMasterModel singlePaymentHeadMasterModel)
        {
            this.singlePaymentHeadMasterModel = singlePaymentHeadMasterModel;
        }

        #region Single Account
        public IActionResult Add()
        {

            singlePaymentHeadModel.Check = 4;
            List<SinglePaymentHeadModel> singlePaymentHeadModels = singlePaymentHeadMasterModel.View(singlePaymentHeadModel);
            ViewData["PaymentType"] = singlePaymentHeadModels;

            paymentHeadViewModel.objPaymentHead = singlePaymentHeadMasterModel.District(singlePaymentHeadModel);
            ViewData["District"] = paymentHeadViewModel;

            ViewBag.Button = "Submit";
            return View();
        }

        [HttpPost]
        public JsonResult AddSinglePayment(int? PaymentHeadId, int? PaymentTypeId, string AccountType, int? DistrictId, string HeadOFAccount, string SBISchemeCode, string HDFCSchemeCode, string ICICISchemeCode)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                SinglePaymentHeadModel objmodel = new SinglePaymentHeadModel()
                {
                    PaymentHeadId = PaymentHeadId,
                    PaymentTypeId = PaymentTypeId,
                    AccountType = AccountType,
                    DistrictId = DistrictId,
                    HeadOFAccount = HeadOFAccount,
                    SBISchemeCode = SBISchemeCode,
                    HDFCSchemeCode = HDFCSchemeCode,
                    ICICISchemeCode = ICICISchemeCode
                };
                objmodel.CreatedBy =  profile.UserId;

                if (objmodel.PaymentHeadId == 0)
                {
                    messageEF = singlePaymentHeadMasterModel.Add(objmodel);
                }
                else
                {
                    messageEF = singlePaymentHeadMasterModel.Update(objmodel);
                }
                return Json(messageEF.Satus);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public IActionResult ViewList()
        {
            singlePaymentHeadModel.Check = 1;
            List<SinglePaymentHeadModel> singlePaymentHeadModels = singlePaymentHeadMasterModel.View(singlePaymentHeadModel);
            return View(singlePaymentHeadModels);
        }

        public IActionResult EditSinglePaymentHead(int id = 0)
        {
            singlePaymentHeadModel.Check = 4;
            List<SinglePaymentHeadModel> singlePaymentHeadModels = singlePaymentHeadMasterModel.View(singlePaymentHeadModel);
            ViewData["PaymentType"] = singlePaymentHeadModels;

            singlePaymentHeadModel.PaymentHeadId = id;
            singlePaymentHeadModel = singlePaymentHeadMasterModel.Edit(singlePaymentHeadModel);
            //ViewData["PaymentTypeID"] = singlePaymentHeadModel;
            ViewBag.Button = "Update";
            return View(singlePaymentHeadModel);
        }

        public IActionResult DeleteSinglePaymentHead(int? id, string AccountType)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            singlePaymentHeadModel.CreatedBy = profile.UserId;
            singlePaymentHeadModel.PaymentHeadId = id;
            singlePaymentHeadModel.AccountType = AccountType;
            singlePaymentHeadModel.Check = 3;
            messageEF = singlePaymentHeadMasterModel.Delete(singlePaymentHeadModel);

            if (messageEF.Satus == "1")
            {
                TempData["msg"] = "Data Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully";

                return RedirectToAction("ViewList");
            }


        }

        #endregion

        #region District wise Account
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public ActionResult Add(PaymentHeadViewModel model, List<SinglePaymentHeadModel> objModel, int? PaymentTypeId)
        {
            string msg = "";
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.objPaymentHead = objModel;
            for (int i = 0; i < model.objPaymentHead.Count; i++)
            {
                if (PaymentTypeId != null && model.objPaymentHead[i].SBISchemeCode != null && model.objPaymentHead[i].HDFCSchemeCode != null && model.objPaymentHead[i].ICICISchemeCode != null && model.objPaymentHead[i].HeadOFAccount != null)
                {
                    singlePaymentHeadModel.PaymentTypeId = PaymentTypeId;
                    singlePaymentHeadModel.AccountType = "District Wise Account";
                    singlePaymentHeadModel.DistrictId = model.objPaymentHead[i].DistrictId;
                    singlePaymentHeadModel.HeadOFAccount = model.objPaymentHead[i].HeadOFAccount;
                    singlePaymentHeadModel.SBISchemeCode = model.objPaymentHead[i].SBISchemeCode;
                    singlePaymentHeadModel.HDFCSchemeCode = model.objPaymentHead[i].HDFCSchemeCode;
                    singlePaymentHeadModel.ICICISchemeCode = model.objPaymentHead[i].ICICISchemeCode;
                    singlePaymentHeadModel.CreatedBy = profile.UserId;
                    messageEF = singlePaymentHeadMasterModel.Add(singlePaymentHeadModel);
                }
            }

            if (messageEF.Satus == "1")
            {
                msg = "Record has been submitted successfully.";
                return RedirectToAction("ViewList");
            }
            else
            {
                msg = "Record already existed.";
                return View();
            }



        }

        public IActionResult UpdateDistrictWise(int? PaymentHeadId, string AccountType)
        {
            if (PaymentHeadId != null && AccountType != "")
            {

                if (AccountType == "District Wise Account")
                {
                    singlePaymentHeadModel.Check = 4;
                    List<SinglePaymentHeadModel> singlePaymentHeadModels = singlePaymentHeadMasterModel.View(singlePaymentHeadModel);
                    ViewData["PaymentType"] = singlePaymentHeadModels;

                    ViewBag.PaymentHeadId = PaymentHeadId;
                    singlePaymentHeadModel.AccountType = AccountType;
                    paymentHeadViewModel.objPaymentHead = singlePaymentHeadMasterModel.PaymentHead(singlePaymentHeadModel);

                    ViewBag.PaymentTypeId = paymentHeadViewModel.objPaymentHead[0].PaymentTypeId;
                    ViewBag.Button = "Update";
                }
            }
            return View(paymentHeadViewModel);
        }

        [HttpPost]
        public IActionResult UpdatePaymentHead(PaymentHeadViewModel model, List<SinglePaymentHeadModel> objModel, int? PaymentTypeId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            for (int i = 0; i < model.objPaymentHead.Count; i++)
            {
                if (PaymentTypeId != null && model.objPaymentHead[i].SBISchemeCode != null && model.objPaymentHead[i].HDFCSchemeCode != null && model.objPaymentHead[i].ICICISchemeCode != null && model.objPaymentHead[i].HeadOFAccount != null)
                {
                    singlePaymentHeadModel.PaymentHeadId = model.objPaymentHead[i].PaymentHeadId;
                    singlePaymentHeadModel.PaymentTypeId = PaymentTypeId;
                    singlePaymentHeadModel.AccountType = "District Wise Account";
                    singlePaymentHeadModel.DistrictId = model.objPaymentHead[i].DistrictId;
                    singlePaymentHeadModel.HeadOFAccount = model.objPaymentHead[i].HeadOFAccount;
                    singlePaymentHeadModel.SBISchemeCode = model.objPaymentHead[i].SBISchemeCode;
                    singlePaymentHeadModel.HDFCSchemeCode = model.objPaymentHead[i].HDFCSchemeCode;
                    singlePaymentHeadModel.ICICISchemeCode = model.objPaymentHead[i].ICICISchemeCode;
                    singlePaymentHeadModel.CreatedBy = profile.UserId;
                    messageEF = singlePaymentHeadMasterModel.Update(singlePaymentHeadModel);


                }
            }
            if (messageEF.Satus == "1")
            {

                return RedirectToAction("ViewList");
            }
            else
            {
                return RedirectToAction("ViewList");
            }


        }

        public ActionResult DeletePaymentHead(int? PaymentHeadId,string AccountType)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            singlePaymentHeadModel.CreatedBy = profile.UserId;
            singlePaymentHeadModel.PaymentHeadId = PaymentHeadId;
            singlePaymentHeadModel.AccountType = AccountType;
            singlePaymentHeadModel.Check = 4;
            messageEF = singlePaymentHeadMasterModel.Delete(singlePaymentHeadModel);

            if (messageEF.Satus == "1")
            {
                TempData["msg"] = "Data Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully";

                return RedirectToAction("ViewList");
            }

           
                   
        }
        #endregion
    }
}