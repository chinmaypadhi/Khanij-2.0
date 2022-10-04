using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApp.Areas.Website.Models.Graph;
using HomeEF;
using HomeApp.Web;
using HomeApp.ActionFilter;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class ResourcesController : Controller
    {
        IResources _objIResourcesModel;
        EditResourcesModel editresourcesmodel = new EditResourcesModel();
        ViewResourcesModel viewresourcesmodel = new ViewResourcesModel();
        MessageEF objmessage = new MessageEF();
        public ResourcesController(IResources objIResourcesModel)
        {
            _objIResourcesModel = objIResourcesModel;
        }
        public IActionResult ViewEdit()
        {
            viewresourcesmodel = _objIResourcesModel.View(viewresourcesmodel);
            return View(viewresourcesmodel);
        }
        public IActionResult Edit()
        {
            ViewBag.submit = "SAVE";
            return View(editresourcesmodel);
        }
        [HttpPost]
        public IActionResult Edit(EditResourcesModel obj, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.Updated_By = profile.UserId;
            if (ModelState.IsValid)
            {
                if (submit == "SAVE")
                {
                    //objmessage = _objgraphModel.Add(obj);
                    //if (objmessage.Satus == "1")
                    //{
                    //    TempData["Message"] = 1;
                    //}
                }
                else
                {

                    objmessage = _objIResourcesModel.Edit(obj);
                    if (objmessage.Satus == "1")
                    {
                        TempData["Message"] = 2;
                    }
                }
                viewresourcesmodel = _objIResourcesModel.View(viewresourcesmodel);
                return View("ViewEdit", viewresourcesmodel);
            }
            else
            {
                return View(obj);
            }
            
        }
        [Decryption]
        public IActionResult ViewByID(string id="0")
        {
            viewresourcesmodel.ID = Convert.ToInt32(id);
            editresourcesmodel = _objIResourcesModel.ViewByID(viewresourcesmodel);
            ViewBag.submit = "UPDATE";
            return View("Edit", editresourcesmodel);
        }
    }
}
