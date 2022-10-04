using Microsoft.AspNetCore.Mvc;
using HomeEF;
using HomeApp.Web;
using HomeApp.Areas.Website.Models.FinancialYear;
using HomeApp.Areas.Website.Models.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class ProductionController : Controller
    {
        IProduction _objIproductionModel;
        IFinancialYearModel _objIfinancialyearmodel;
        IMineral _objImineralModel;


        MineralGradeModel mineralGradeModel = new MineralGradeModel();
        List<MineralGradeModel> listMineralGrade = new List<MineralGradeModel>();
        EditProductionModel editproductionmodel = new EditProductionModel();
        ViewProductionModel viewproductionmodel = new ViewProductionModel();
        List<ViewProductionModel> viewproductionmodellist = new List<ViewProductionModel>();

        MessageEF objmessage = new MessageEF();
        public ProductionController(IProduction objIproductionModel, IFinancialYearModel objIfinancialyearmodel, IMineral objImineralModel)
        {
            _objIproductionModel = objIproductionModel;
            _objIfinancialyearmodel = objIfinancialyearmodel;
            _objImineralModel = objImineralModel;
        }
        public IActionResult Add()
        {
            ViewData["financialyear"] = _objIfinancialyearmodel.GetFinancialYear();
            ViewData["MineralCategory"] = _objImineralModel.ViewMineralCategory(mineralGradeModel);
            ViewBag.submit = "SAVE";
            return View(editproductionmodel);
        }
        [HttpPost]
        public IActionResult Add(EditProductionModel obj, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.Updated_By = profile.UserId;
            if (ModelState.IsValid)
            {
                if (submit == "SAVE")
                {
                    objmessage = _objIproductionModel.Check(obj);
                    if (objmessage.Satus == "1")
                    {
                        TempData["Message"] = "3";
                    }
                    else
                    {
                        objmessage = _objIproductionModel.Add(obj);
                        if (objmessage.Satus == "1")
                            TempData["Message"] = 1;
                        else
                            TempData["Message"] = 4;
                    }
                }
                else
                {

                    objmessage = _objIproductionModel.Edit(obj);
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
            List<ViewProductionModel> list = new List<ViewProductionModel>();
            list = _objIproductionModel.View(viewproductionmodel);
            ViewData["list"] = list;

            ViewData["financialyear"] = _objIfinancialyearmodel.GetFinancialYear();
            return View();
        }
        public IActionResult ViewByID(int id)
        {
            ViewData["MineralCategory"] = _objImineralModel.ViewMineralCategory(mineralGradeModel);

            viewproductionmodel.ID = id;
            editproductionmodel = _objIproductionModel.ViewByID(viewproductionmodel);
            ViewBag.submit = "UPDATE";
            ViewData["financialyear"] = _objIfinancialyearmodel.GetFinancialYear();
            return View("Add", editproductionmodel);
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
            viewproductionmodel.FinancialYear = financialyear;
            viewproductionmodellist = _objIproductionModel.ViewByFinancialYear(viewproductionmodel);
            ViewData["list"] = viewproductionmodellist;
            ViewData["financialyear"] = _objIfinancialyearmodel.GetFinancialYear();
            ViewBag.selectedfinancialyear = financialyear;
            return View("ViewEdit");
        }
    }
}
