using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApp.Areas.Website.Models.FinancialYear;
using HomeApp.Areas.Website.Models.Graph;
using HomeEF;
using HomeApp.Web;
using HomeApp.ActionFilter;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class RevenueController : Controller
    {
        IRevenue _objIrevenueModel;
        IFinancialYearModel _objIfinancialyearmodel;
        IMineral _objImineralModel;

        
        MineralGradeModel mineralGradeModel = new MineralGradeModel();
        List<MineralGradeModel> listMineralGrade = new List<MineralGradeModel>();
        EditRevenueModel editrevenuemodel = new EditRevenueModel();
        ViewRevenueModel viewrevenuemodel = new ViewRevenueModel();
        List<ViewRevenueModel> viewrevenuemodellist = new List<ViewRevenueModel>();

        MessageEF objmessage = new MessageEF();
        public RevenueController(IRevenue objIrevenueModel, IFinancialYearModel objIfinancialyearmodel, IMineral objImineralModel)
        {
            _objIrevenueModel = objIrevenueModel;
            _objIfinancialyearmodel = objIfinancialyearmodel;
            _objImineralModel = objImineralModel;
        }
        public IActionResult Add()
        {
            ViewData["financialyear"] = _objIfinancialyearmodel.GetFinancialYear();
            ViewData["MineralCategory"] = _objImineralModel.ViewMineralCategory(mineralGradeModel);
            ViewBag.submit = "SAVE";
            return View(editrevenuemodel);
        }
        [HttpPost]
        public IActionResult Add(EditRevenueModel obj, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.Updated_By = profile.UserId;
            if (ModelState.IsValid)
            {
                if (submit == "SAVE")
                {
                    objmessage = _objIrevenueModel.Check(obj);
                    if (objmessage.Satus == "1")
                    {
                        TempData["Message"] = "3";
                    }
                    else
                    {
                        objmessage = _objIrevenueModel.Add(obj);
                        if (objmessage.Satus == "1")
                        {
                            TempData["Message"] = 1;
                        }
                    }

                }
                else
                {

                    objmessage = _objIrevenueModel.Edit(obj);
                    if (objmessage.Satus == "1")
                    {
                        TempData["Message"] = 2;
                    }
                }
            }
            ViewData["financialyear"] = _objIfinancialyearmodel.GetFinancialYear();
            ViewData["MineralCategory"] = _objImineralModel.ViewMineralCategory(mineralGradeModel);
            return View(obj);
        }
        public IActionResult ViewEdit()
        {
            List<ViewRevenueModel> list = new List<ViewRevenueModel>();
            list = _objIrevenueModel.View(viewrevenuemodel);
            ViewData["list"] = list;

            ViewData["financialyear"] = _objIfinancialyearmodel.GetFinancialYear();
            return View();
        }
        public IActionResult ViewByID(string id="0")
        {
            ViewData["MineralCategory"] = _objImineralModel.ViewMineralCategory(mineralGradeModel);
            viewrevenuemodel.ID = Convert.ToInt32(id);
            editrevenuemodel = _objIrevenueModel.ViewByID(viewrevenuemodel);
            ViewBag.submit = "UPDATE";
            ViewData["financialyear"] = _objIfinancialyearmodel.GetFinancialYear();
            return View("Add", editrevenuemodel);
        }
        private List<MineralGradeModel> GetMineralNameByMineralCategory(int? mineralType)
        {
            if (mineralType != 0)
            {
                mineralGradeModel.CHK = 9;
                mineralGradeModel.MineralTypeId = mineralType;
                listMineralGrade = _objImineralModel.ViewMineral(mineralGradeModel);
            }
            else
            {
                listMineralGrade = null;
            }
            return listMineralGrade;
        }
        public JsonResult GetMineralMasterDataByMineralTypeId(int? mineralType)
        {
            try
            {
                listMineralGrade = GetMineralNameByMineralCategory(mineralType);
                return Json(listMineralGrade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult ViewByFinancialyear(string financialyear)
        {
            viewrevenuemodel.FinancialYear = financialyear;
            viewrevenuemodellist = _objIrevenueModel.ViewByFinancialYear(viewrevenuemodel);
            ViewData["list"] = viewrevenuemodellist;

            ViewData["financialyear"] = _objIfinancialyearmodel.GetFinancialYear();
            ViewBag.selectedfinancialyear = financialyear;
            return View("ViewEdit");
        }
    }
}
