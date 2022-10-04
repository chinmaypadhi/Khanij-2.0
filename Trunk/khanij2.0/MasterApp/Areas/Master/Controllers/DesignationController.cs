using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Department;
using MasterApp.Areas.Master.Models.Designation;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Master.Controllers
{
    [Area("master")]
    public class DesignationController : Controller
    {
        private readonly IDesignationModel designationModel;
        private readonly IDepartmentMasterModel departmentMasterModel;
        List<RoleTypeModel> listRoleTypeModel = new List<RoleTypeModel>();
        RoleListModel roleListModel = new RoleListModel();
        RoleTypeModel roleTypeModel = new RoleTypeModel();
        MessageEF objobjmodel = new MessageEF();
        #region Constructor
        public DesignationController(IDesignationModel designationModel,
            IDepartmentMasterModel departmentMasterModel)
        {
            this.designationModel = designationModel;
            this.departmentMasterModel = departmentMasterModel;
        }
        #endregion

        #region Add/Update
        [HttpGet, Decryption]
        
        public IActionResult Add(string id = "0")
        {
            
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                roleListModel.RoleId = Convert.ToInt32(id);
                roleListModel = designationModel.Edit(roleListModel);
                roleListModel.IsActive = roleListModel.Status == "Active" ? true : false;
                ViewBag.Departments = GetRoleType(roleListModel.RoleId);

                ViewBag.Button = "Update";
                return View(roleListModel);
            }
            else
            {
                 
                ViewBag.Departments = GetRoleType(null);
                roleListModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(roleListModel);
            }
           
        }

        private SelectList GetRoleType(int? RoleTypeId)
        {
            listRoleTypeModel = departmentMasterModel.View(roleTypeModel);
            return new SelectList(listRoleTypeModel, "RoleTypeId", "RoleTypeName",RoleTypeId);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(RoleListModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {

                if (string.IsNullOrEmpty(objmodel.RoleTypeId.ToString()))
                {
                    ModelState.AddModelError("RoleTypeId", "Please Select Department");
                    ViewBag.Departments = GetRoleType(null);
                }
                if (string.IsNullOrEmpty(objmodel.RoleName))
                {
                    ModelState.AddModelError("RoleName", "Please Enter Designation");
                }
                if (!string.IsNullOrEmpty(objmodel.RoleName))
                {
                    if (objmodel.RoleName.Length > 50)
                    {
                        ModelState.AddModelError("RoleName", "Maximum 50 Characters Allowed");
                    }
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy = profile.UserId;

                    if (submit == "Submit")
                    {
                        objobjmodel = designationModel.Add(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Data Saved Sucessfully";

                            return RedirectToAction("ViewList");
                        }
                        else if(objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Designation Name Already Exists !!";

                            return RedirectToAction("Add");
                        }
                        else
                        {
                            ViewBag.msg = "Data not Saved Sucessfully";
                            ViewBag.Departments = GetRoleType(null);
                            return View();
                        }
                    }
                    else
                    {
                        objobjmodel = designationModel.Update(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Data Updated Sucessfully";

                            return RedirectToAction("ViewList");
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Designation Name Already Exists !!";

                            return RedirectToAction("Add");
                        }
                        else
                        {
                            ViewBag.msg = "Data not Updated Sucessfully";
                            ViewBag.Departments = GetRoleType(null);
                            return View();
                        }
                    }
                    
                }
                else
                {
                    ViewBag.Departments = GetRoleType(null);
                    return View(objmodel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region View
        [HttpGet]
        public IActionResult ViewList(RoleListModel roleListModel)
        {
            try
            { 
                if (TempData["Message"]!=null)
                {
                    ViewBag.msg = TempData["Message"].ToString();
                    TempData["Message"] = null;
                }
                List<RoleListModel> lstRoleListModel = designationModel.View(roleListModel);
                return View(lstRoleListModel);
            }
            catch (Exception ex)
            {

                throw;
            } 
        }
        #endregion

        #region Delete
        [Decryption]
        public IActionResult Delete(string id ="0" )
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            RoleListModel objmodel = new RoleListModel();
            objmodel.CreatedBy = (int)profile.UserId;
            objmodel.RoleId = Convert.ToInt32(id);
            objobjmodel = designationModel.Delete(objmodel);

            if (objobjmodel.Satus == "1")
            {
                TempData["Message"] = "Data Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["Message"] = "Data not Deleted Sucessfully";

                return RedirectToAction("ViewList");
            }


        }
        #endregion
    }
}