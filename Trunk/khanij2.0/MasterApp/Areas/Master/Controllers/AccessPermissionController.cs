using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.AccessPermission;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class AccessPermissionController : Controller
    {
        public IAccessPermission _IAccessPermission;
        public AccessPermissionController(IAccessPermission ObjIAccessPermission)
        {
             _IAccessPermission= ObjIAccessPermission;
        }
        public IActionResult ViewUserAccess()
        {
            List<UserRightsEF> ListUserRightsEF = new List<UserRightsEF>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                UserRightsEF objUserRightsEF = new UserRightsEF();
                objUserRightsEF.UserId = (int)profile.UserId;
                objUserRightsEF.Check = "0";
                ListUserRightsEF = _IAccessPermission.getview(objUserRightsEF);
                ViewBag.ViewList = ListUserRightsEF;
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }

        public IActionResult ViewUserTypeAcess()
        {
            List<UserRightsEF> ListUserRightsEF = new List<UserRightsEF>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                UserRightsEF objUserRightsEF = new UserRightsEF();
                objUserRightsEF.UserId = (int)profile.UserId;
                objUserRightsEF.Check = "2";
                ListUserRightsEF=_IAccessPermission.getview(objUserRightsEF);
                ViewBag.ViewList = ListUserRightsEF;
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }

        public JsonResult getTreeValue()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            TreeMenu objtreeMenu = new TreeMenu();
            objtreeMenu.userid =(int)profile.UserId;
            List<TreeMenu> objlistTreeMenu = new List<TreeMenu>();
            objlistTreeMenu = _IAccessPermission.getTreeValue(objtreeMenu);
            return Json(objlistTreeMenu);
        }
        [Decryption]
        public IActionResult AcessUserType(string id = "0")
        {
            ViewBag.UserType = Enumerable.Empty<SelectListItem>();
            Bindfild objBindfild = new Bindfild();
            objBindfild.CheckSatus = "UT";
            List<Bindfild> objListBindfild = new List<Bindfild>();
            objListBindfild= _IAccessPermission.FilldropDown(objBindfild);
            ViewBag.UserType = objListBindfild.ToList().Select(c => new SelectListItem
            {
                Text = c.Text,
                Value = c.Value.ToString(),
                Selected = (c.Value == id.ToString ())

            }).ToList();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AcessUserType(AcessUserTypeEF objAcessUserEF, string[] checkedFiles)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objAcessUserEF.Menuid = checkedFiles.ToList();
                objMessageEF=_IAccessPermission.AddUserType(objAcessUserEF);
                if(objMessageEF.Satus=="1")                
                {
                    TempData["Msg"] = "Data Updated sucessfully";
                    return RedirectToAction("ViewUserTypeAcess");
                }
                else
                {
                    TempData["Msg"] = "Data Updated sucessfully";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }

        public JsonResult BindUserTypeData(int usertypeid)
        {
            userRights objuserRights = new userRights();
            objuserRights.UserTypeId = usertypeid;
            objuserRights.Check = "3";
            List<userRights> objListuserRights = new List<userRights>();
            objListuserRights = _IAccessPermission.BindUserTypeData(objuserRights);
            return Json(objListuserRights);
        }

        [Decryption]
        public IActionResult AcessUserId(string id = "0")
        {
            AcessUserIdEf objAcessUserIdEf = new AcessUserIdEf();
            ViewBag.UserType = Enumerable.Empty<SelectListItem>();
            ViewBag.Role = Enumerable.Empty<SelectListItem>();
            ViewBag.User = Enumerable.Empty<SelectListItem>();
            if (!string.IsNullOrEmpty(id) && id == "0")
            {
                Bindfild objBindfild = new Bindfild();
                objBindfild.CheckSatus = "UT";
                List<Bindfild> objListBindfild = new List<Bindfild>();
                objListBindfild = _IAccessPermission.FilldropDown(objBindfild);
                ViewBag.UserType = objListBindfild.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),
                    

            }).ToList();
            }
            else
            {
                objAcessUserIdEf.Userid = id.ToString ();
               objAcessUserIdEf= _IAccessPermission.EditUserId(objAcessUserIdEf);
                Bindfild objBindfild = new Bindfild();
                objBindfild.CheckSatus = "UT";
                List<Bindfild> objListBindfild = new List<Bindfild>();
                objListBindfild = _IAccessPermission.FilldropDown(objBindfild);
                ViewBag.UserType = objListBindfild.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),
                    Selected = c.Value == objAcessUserIdEf.UserTypeid

                }).ToList();
                objBindfild.CheckSatus = "RL";
                objBindfild.Paramiterid = objAcessUserIdEf.UserTypeid;
                objListBindfild = _IAccessPermission.FilldropDown(objBindfild);
                ViewBag.Role = objListBindfild.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),
                    Selected = c.Value == objAcessUserIdEf.Roleid

                }).ToList();


                objBindfild.CheckSatus = "UN";
                objBindfild.Paramiterid = objAcessUserIdEf.Roleid;
                objListBindfild = _IAccessPermission.FilldropDown(objBindfild);
                ViewBag.User = objListBindfild.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),
                    Selected = c.Value == objAcessUserIdEf.Userid

                }).ToList();
            }
            return View();
        }

        public JsonResult getRole(string id="0")
        {
            Bindfild objBindfild = new Bindfild();
            objBindfild.CheckSatus = "RL";
            objBindfild.Paramiterid = id;
            List<Bindfild> objListBindfild = new List<Bindfild>();
            objListBindfild = _IAccessPermission.FilldropDown(objBindfild);
            return Json(objListBindfild);
        }

        public JsonResult GetUser(string id = "0")
        {
            Bindfild objBindfild = new Bindfild();
            objBindfild.CheckSatus = "UN";
            objBindfild.Paramiterid = id;
            List<Bindfild> objListBindfild = new List<Bindfild>();
            objListBindfild = _IAccessPermission.FilldropDown(objBindfild);
            return Json(objListBindfild);
        }
        

        public JsonResult BindUseridData(int userid)
        {
            userRights objuserRights = new userRights();
            objuserRights.UserID = userid;
            objuserRights.Check = "UR";
            List<userRights> objListuserRights = new List<userRights>();
            objListuserRights = _IAccessPermission.BindUseridData(objuserRights);
            return Json(objListuserRights);
        }
        [HttpPost]
        public IActionResult AcessUserId(AcessUserIdEf objAcessUserEF, string[] checkedFiles)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objAcessUserEF.Menuid = checkedFiles.ToList();
                objMessageEF = _IAccessPermission.AddUserId(objAcessUserEF);
                if (objMessageEF.Satus == "1")
                {
                    TempData["Msg"] = "Data Updated sucessfully";
                    return RedirectToAction("ViewUserAccess");
                }
                else
                {
                    TempData["Msg"] = "Data Updated sucessfully";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }
    }
}