// ***********************************************************************
//  Controller Name          : ValidityExpiredController
//  Desciption               : Validity expired
//  Created By               : sanjay kumar
//  Created On               : 17 Dec 2021
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermitApp.Models.ValidityExpired;
using PermitEF;
using Microsoft.AspNetCore.Authentication;
using PermitApp.Helper;
using Microsoft.AspNetCore.Http;
using PermitApp.Web;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace PermitApp.Controllers
{
    [Route("[controller]/[action]")]
    public class ValidityExpiredController : Controller
    {
        IValidityExpiredModel _objValidity;
        
        public ValidityExpiredController(IValidityExpiredModel objValidity)
        {
            _objValidity = objValidity;
           
        }
        #region Validity of Lesee
        public ActionResult ValidityExpired()
        {
           
                ValidityExpiredEF model = new ValidityExpiredEF();
            List<ValidityExpiredEF> modelList = new List<ValidityExpiredEF>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserID = Convert.ToInt32(profile.UserId);
                //model.UserID = 208;
                modelList = _objValidity.GetValidityExpiredDetails(model);
            if (modelList != null && modelList.Count > 0)
            {
                for (var i = 0; i < modelList.Count; i++)
                {
                    model.TotalMiningProductionQty = Convert.ToString(modelList[i].Production);
                    model.TotalECApprovedQty = Convert.ToString(modelList[i].ECApprovedQuantity);
                    model.ECValidity = Convert.ToString(modelList[i].ECValidity);
                    model.MPValidity = Convert.ToString(modelList[i].MiningValidity);
                    model.LeaseValidity = Convert.ToString(modelList[i].LeaseValidity);
                    model.TotalDispatched = Convert.ToString(modelList[i].TotalDispatched);
                }
            }
            }
            catch (Exception)
            {
                return null;
            }

            return View(model);
        }
        #endregion
    }
}
