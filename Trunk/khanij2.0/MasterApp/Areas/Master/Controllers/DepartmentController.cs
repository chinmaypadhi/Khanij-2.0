using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Department;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentMasterModel departmentMasterModel;
        RoleTypeModel roleTypeModel = new RoleTypeModel();
        List<RoleTypeModel> listRoleTypeModel = new List<RoleTypeModel>();
        MessageEF messageEF = new MessageEF();

        #region Constructor
        public DepartmentController(IDepartmentMasterModel departmentMasterModel)
        {
            this.departmentMasterModel = departmentMasterModel;
        }
        #endregion

        #region Add/Update
        [Decryption]
        public IActionResult Add(string id ="0" )
        {
            ViewData["UserType"] = GetUserTypeDetails();
            if (!string.IsNullOrEmpty(id) &&  id !="0" )
            {
                roleTypeModel.RoleTypeId = Convert.ToInt32(id);
                roleTypeModel = departmentMasterModel.Edit(roleTypeModel);
                roleTypeModel.IsActive = roleTypeModel.Status == "Active" ? true : false;
                ViewBag.Button = "Update";
                return View(roleTypeModel);
            }
            else
            {


                roleTypeModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(roleTypeModel);
            }
        }

        private List<RoleTypeModel> GetUserTypeDetails()
        {
            listRoleTypeModel = departmentMasterModel.View(roleTypeModel);
            return listRoleTypeModel;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(RoleTypeModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if (string.IsNullOrEmpty(objmodel.UserTypeId.ToString()))
                {
                    ModelState.AddModelError("UserTypeId", "Please Select User Type");
                }
                if (string.IsNullOrEmpty(objmodel.RoleTypeName))
                {
                    ModelState.AddModelError("RoleTypeName", "Please Enter Department");
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy =  profile.UserId;

                    if (submit == "Submit")
                    {
                        messageEF = departmentMasterModel.Add(objmodel);
                        if (messageEF.Satus == "1")
                        {
                            TempData["msg"] = "Data Saved Sucessfully";
                            return RedirectToAction("Add");
                        }
                        else if(messageEF.Satus=="2")
                        {
                            TempData["msg"] = "Department Name Already Exists";
                            return RedirectToAction("ViewList");
                        }
                        else
                        {
                            ViewBag.msg = "Data not Saved Sucessfully";
                            ViewData["UserType"] = GetUserTypeDetails();
                            return View(objmodel);
                        }
                    }
                    else
                    {
                        messageEF = departmentMasterModel.Update(objmodel);
                        if (messageEF.Satus == "1")
                        {
                            TempData["msg"] = "Data Updated Sucessfully";
                            return RedirectToAction("ViewList");
                        }
                        
                        else
                        {
                            ViewBag.msg = "Data not Updated Sucessfully";
                            ViewData["UserType"] = GetUserTypeDetails();
                            return View(objmodel);
                        }
                    }
                    
                }
                else
                {
                    ViewData["UserType"] = GetUserTypeDetails();
                    return View(objmodel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region View
        public IActionResult ViewList(RoleTypeModel roleTypeModel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }

                listRoleTypeModel = departmentMasterModel.View(roleTypeModel);
                return View(listRoleTypeModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        [Decryption]
        public IActionResult Delete(string id ="0" )
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            roleTypeModel.CreatedBy = profile.UserId;
            roleTypeModel.RoleTypeId = Convert.ToInt32(id);
            messageEF = departmentMasterModel.Delete(roleTypeModel);

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