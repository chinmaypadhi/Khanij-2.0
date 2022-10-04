using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PermitApp.Areas.CoalGrade.Models;
using PermitApp.Helper;
using PermitApp.Web;
using PermitEF;
using PermitApp.ActionFilter;

namespace PermitApp.Areas.CoalGrade.Controllers
{
    [Area("CoalGrade")]
    public class CoalGradeController : Controller
    {
        ICoalGrade objICoalGrade;
        public CoalGradeController(ICoalGrade objICoalGrade)
        {
            this.objICoalGrade = objICoalGrade;
        }
        public IActionResult SampleGrade()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewData["list"] = objICoalGrade.CoalGradeDetailsByUserID(new SampleGradeModel { LesseeId = Convert.ToInt32(profile.UserId) });
            return View();
        }
        [SkipImportantTask]
        public IActionResult UpdateSampleGrade(int BulkPermitId = 0)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ePermitModel obj = objICoalGrade.CoalGradeDetailsByPermitID(new ePermitModel { BulkPermitId = BulkPermitId, UserID = Convert.ToInt32(profile.UserId) });
            ViewData["MineralGrade"] = objICoalGrade.GetMineralGradeCascadFromMineralNature(new ePermitModel { UserID = Convert.ToInt32(profile.UserId), MineralNatureId = obj.MineralNatureId });
            return View(obj);
        }
        public JsonResult RevisedCalculation(string MineralNatureId, int MineralGradeId, int MineralId, decimal Quantity, decimal RoyaltyRate, int BulkPermitId, decimal AluminaContent, decimal TinContent)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            List<ePaymentData> List = new List<ePaymentData>();
            List = objICoalGrade.RevisedPayableRoyaltyRate(new RevisedPayableRoyaltyRate { MineralGradeId = Convert.ToInt32(MineralNatureId), MineralId = MineralId, Quantity = Quantity, RoyaltyRate = RoyaltyRate, BulkPermitId = BulkPermitId, AluminaContent = AluminaContent, TinContent = TinContent, UserID = profile.UserId });
            return Json(List);
        }
        [HttpPost, SkipImportantTask]
        public JsonResult RevisedCalculation(RevisedPayableRoyaltyRate obj)
        {
            //string MineralNatureId, string MineralGradeId, string MineralId, string Quantity, string RoyaltyRate, string BulkPermitId, string AluminaContent, string TinContent
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            List<ePaymentData> List = new List<ePaymentData>();
            obj.UserID = profile.UserId;
            List = objICoalGrade.RevisedPayableRoyaltyRate(obj);
            return Json(List);
        }
    }
}
