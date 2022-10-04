// ***********************************************************************
//  Controller Name          : FPOApproverController
//  Desciption               : View,Update Field Program Order Approver
//  Created By               : Lingaraj Dalai
//  Created On               : 17 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using GeologyApp.Models.FPO;
using GeologyApp.Web;
using GeologyEF;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApp.Controllers
{
    [Area("Geology")]
    public class FPOApproverController : Controller
    {
        /// <summary>
        /// Global object and variable declaration
        /// </summary>
        IFPOModel _objFPOMasterModel;
        MessageEF objobjmodel = new MessageEF();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objFieldReportStatusMasterModel"></param>
        /// <param name="objInspectionReportMasterModel"></param>
        /// <param name="hostingEnvironment"></param>
        public FPOApproverController(IFPOModel objFPOMasterModel)
        {
            _objFPOMasterModel = objFPOMasterModel;
        }
        /// <summary>
        /// To bind Field Program Order status
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult ViewList(FPOOrdermaster objmodel)
        {
            try
            {
                List<FPOOrdermaster> lstFPOmaster = _objFPOMasterModel.ViewFPOApprover(objmodel);
                ViewBag.ViewList = lstFPOmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// To Update Field Program Order status
        /// </summary>
        /// <param name="FPOId"></param>
        /// <param name="Remarks"></param>
        /// <param name="IsApproved"></param>
        /// <returns></returns>
        public JsonResult UpdateFPOApproverSend(int? FPOId, string Remarks, int? IsApproved)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            FPOOrdermaster objmodel = new FPOOrdermaster();
            try
            {
                objmodel.CreatedBy = profile.UserId;
                objmodel.FPO_Id = FPOId;
                objmodel.Remarks = Remarks;
                objmodel.IsApproved = IsApproved;
                objobjmodel = _objFPOMasterModel.AddFPOApprover(objmodel);
                return Json(objobjmodel.Satus);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
            }
        }
    }
}