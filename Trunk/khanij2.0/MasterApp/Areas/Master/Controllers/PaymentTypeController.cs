// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Models.MIneral;
using MasterApp.Areas.Master.Models.StateMaster;
using MasterApp.Areas.Master.Models.PaymentTypeMaster;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class PaymentTypeController : Controller
    {
        IPaymentTypeMasterModel _objPaymentTypemasterModel;
        MessageEF objobjmodel = new MessageEF();
        public PaymentTypeController(IPaymentTypeMasterModel objPaymentTypemasterModel)
        {
            _objPaymentTypemasterModel = objPaymentTypemasterModel;
        }
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            PaymenttypeMaster objmodel = new PaymenttypeMaster();
            if (!string.IsNullOrEmpty(id) &&  id != "0")
            {
           
                objmodel.PaymentTypeId = Convert.ToInt32(id);
                objmodel = _objPaymentTypemasterModel.Edit(objmodel);
                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = true;
                objmodel.IsOnline = true;
                objmodel.RoyaltyMaping = true;               
                ViewBag.Button = "Submit";
                return View(objmodel);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(PaymenttypeMaster objmodel, string submit)
        {
            if (string.IsNullOrEmpty(objmodel.PaymentType))
            {
                ModelState.AddModelError("PaymentType", "Payment Type is required");
            }


            if (ModelState.IsValid)
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy = profile.UserId;
                if (submit == "Submit")
                {
                    objobjmodel = _objPaymentTypemasterModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objPaymentTypemasterModel.Update(objmodel);
                }
                if (objobjmodel.Satus == "1" && submit== "Submit")
                {
                    TempData["msg"] = "Data Saved Sucessfully";
                    return RedirectToAction("ViewList");
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Data Updated Sucessfully";
                    return RedirectToAction("ViewList");
                }
                if (objobjmodel.Satus == "2")
                {
                    TempData["msg"] = "Payment Type Already Exists";
                    return RedirectToAction("Add");
                }
                else
                {
                    TempData["msg"] = "Data not Saved Sucessfully";
                    return View(objmodel);
                }
            }
            return View();
        }
        public IActionResult ViewList(PaymenttypeMaster objmodel)
        {
            try
            {
                if (TempData["msg"]!=null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objPaymentTypemasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Decryption]
        public IActionResult Delete(string id = "0" )
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            PaymenttypeMaster objmodel = new PaymenttypeMaster();
            objmodel.CreatedBy = (int)profile.UserId;
           
            objmodel.PaymentTypeId = Convert.ToInt32(id);

            objobjmodel = _objPaymentTypemasterModel.Delete(objmodel);

            if (objobjmodel.Satus == "1")
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

    }
}