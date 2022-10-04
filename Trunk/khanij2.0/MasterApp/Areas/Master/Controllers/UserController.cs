using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MasterEF;
using MasterApp.Areas.Master.Models.User;
using Microsoft.AspNetCore.Mvc.Rendering;
using MasterApp.ActionFilter;
using MasterApp.Web;
using System.Text;
using System.Security.Cryptography;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("Master")]
    public class UserController : Controller
    {
        #region 
        IUserModel _userModel;
        MessageEF messageEF = new MessageEF();
        UserCreationModel objuserCreation= new UserCreationModel();
        List<UserCreationModel> userCreationList = new List<UserCreationModel>();
        List<ViewUserCreationModel> userViewCreationList = new List<ViewUserCreationModel>();
        #endregion
        #region Constructor Dependency Injection
        public UserController(IUserModel userModel)
        {
            _userModel = userModel;
        }
        #endregion
        [Decryption]
        public IActionResult Add( string id="0")
        {
            if(!string.IsNullOrEmpty(id) && id!="0")
            {
                objuserCreation.UserId = Convert.ToInt32(id);
                UserCreationModel objmodel = _userModel.Edit(objuserCreation);
                ViewBag.State = GetStateList();
                ViewBag.UserTypes = GetUserTypeList();
                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objuserCreation.IsActive = true;
                ViewBag.State = GetStateList();
                ViewBag.UserTypes = GetUserTypeList();
                ViewBag.Button = "Submit";
                return View(objuserCreation);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(UserCreationModel userCreationModel, string submit)
        {
            try
            {
                #region Serverside Validation
                if(string.IsNullOrEmpty(userCreationModel.UserName.ToString()))
                {
                    ModelState.AddModelError("UserName", "Username Field Required !");
                }
                if(string.IsNullOrEmpty(userCreationModel.ApplicantName))
                {
                    ModelState.AddModelError("ApplicantName", "User Full Name Field is Required !");
                }
                if(userCreationModel.UsertypeId==null)
                {
                    ModelState.AddModelError("UsertypeId", "User Type Field is Required !");
                }
                if(userCreationModel.RoleTypeId==null)
                {
                    ModelState.AddModelError("RoleTypeId", "Department Field is Required !");
                }
                if (userCreationModel.RoleId == null)
                {
                    ModelState.AddModelError("RoleId", "Designation Field is Required !");
                }
                if (string.IsNullOrEmpty(userCreationModel.Password))
                {
                    ModelState.AddModelError("Password", "Password Field is Required !");
                }
                if (userCreationModel.StateId == null)
                {
                    ModelState.AddModelError("StateId", "State Field is Required !");
                }
                if (userCreationModel.DistrictID == null)
                {
                    ModelState.AddModelError("DistrictID", "District Field is Required !");
                }
                if(string.IsNullOrEmpty(userCreationModel.MobileNo))
                {
                    ModelState.AddModelError("MobileNo", "Mobile Field is Required !");
                }
                if (string.IsNullOrEmpty(userCreationModel.EMailId))
                {
                    ModelState.AddModelError("EMailId", "EMailId Field is Required !");
                }
                if (string.IsNullOrEmpty(userCreationModel.Address))
                {
                    ModelState.AddModelError("Address", "Address Field is Required !");
                }
                if (string.IsNullOrEmpty(userCreationModel.PinCode.ToString()))
                {
                    ModelState.AddModelError("PinCode", "Pincode Field is Required !");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    if (submit == "Submit")
                    {
                        
                        userCreationModel.UserId = profile.UserId;
                        string s = ComputeSha256Hash(userCreationModel.Password).ToUpper();
                        string s1 = ComputeSha256Hash(s).ToUpper();
                        userCreationModel.EncryptPassword = s1;
                        userCreationModel.UserLoginId = profile.UserLoginId;
                        messageEF = _userModel.AddNewUser(userCreationModel);
                    }
                    else
                    {
                        if(userCreationModel.EncryptPassword == null)
                        {
                            string s = ComputeSha256Hash(userCreationModel.Password).ToUpper();
                            string s1 = ComputeSha256Hash(s).ToUpper();
                            userCreationModel.EncryptPassword = s1;
                        }
                        
                        messageEF = _userModel.Update(userCreationModel);
                    }
                    
                    if (submit == "Submit" && messageEF.Satus=="1")
                    {
                        //userCreationModel.IsActive = true;
                        #region Send Mail Message
                        if (!string.IsNullOrEmpty(userCreationModel.MobileNo))
                        {
                            SMS obj = new SMS();
                            string msg = "Dear" + userCreationModel.ApplicantName + "," + Environment.NewLine + Environment.NewLine + "You have successfully register to khanij online please login to system by below credentials, " + Environment.NewLine + Environment.NewLine + "User Name : " + userCreationModel.UserName + Environment.NewLine + "Password : " + userCreationModel.Password + " CHiMMS, GoCG";
                            string templateid = "1307161883241105388";
                            obj.mobileNo = userCreationModel.MobileNo;
                            obj.message = msg;
                            obj.templateid = templateid;
                            messageEF = _userModel.Main(obj);

                        }

                        if (!string.IsNullOrEmpty(userCreationModel.EMailId))
                        {
                            //MailService dmoMail = new MailService();
                            //dmoMail.SendUserRegistrationMail(model);
                        }
                        #endregion
                        TempData["msg"] = "User Created Sucessfully ";

                        return RedirectToAction("Add", "User", new { Area = "master" });
                    }
                    else if (submit == "Submit" && messageEF.Satus == "2")
                    {
                        //userCreationModel.IsActive = true;
                        TempData["msg"] = "User Already Exists ";
                        return RedirectToAction("Add", "User", new { Area = "master" });
                    }
                    else if (submit == "Submit" && messageEF.Satus == "3")
                    {
                        TempData["msg"] = "Moble No Or Email Exists ";
                        return RedirectToAction("Add", "User", new { Area = "master" });
                    }
                    if (messageEF.Satus == "1")
                    {
                        TempData["msg"] = "User Updated Sucessfully ";
                        return RedirectToAction("Viewlist", "User", new { Area = "master" });
                    }
                    else
                    {
                        return RedirectToAction("Viewlist", "User", new { Area = "master" });
                    }
                }
                else
                {
                    if(userCreationModel.UserId !=0 && userCreationModel.UserId != null)
                    {
                        ViewBag.State = GetStateList();
                        ViewBag.UserTypes = GetUserTypeList();
                        ViewBag.Button = "Update";
                        return View();
                    }
                    else
                    {
                        ViewBag.State = GetStateList();
                        ViewBag.UserTypes = GetUserTypeList();
                        ViewBag.Button = "Submit";
                        return View();
                    }
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { userCreationModel = null; }
            
        }
        public IActionResult ViewList()
        {
            try
            {
                ViewUserCreationModel viewUserCreationModel = new ViewUserCreationModel();
                userViewCreationList = _userModel.View(viewUserCreationModel);
                return View(userViewCreationList);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userCreationList = null;
                objuserCreation = null;
            }
        }
        [Decryption]
        public IActionResult Delete(string id="0")
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objuserCreation.UserId = profile.UserId;
                objuserCreation.Userid1 = Convert.ToInt32(id);
                messageEF = _userModel.Delete(objuserCreation);
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
            catch (Exception)
            {
                throw;
            }
            finally {
                objuserCreation = null;
                messageEF = null;
            }
        }

        #region To Bind Dropdowns
        /// <summary>
        /// To Bind UserType Dropdownlist
        /// </summary>
        /// <returns></returns>
        public SelectList GetUserTypeList()
        {
            try
            {
                userCreationList = _userModel.GetUserTypeList();
                return new SelectList(userCreationList, "UsertypeId", "Usertype");
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// To Bind States in Dropdown
        /// </summary>
        /// <returns></returns>
        private SelectList GetStateList()
        {
            try
            {
                userCreationList = _userModel.StateList();
                return new SelectList(userCreationList, "StateId", "StateName");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// To Fill District Dropdownlist by selecting State
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public JsonResult GetDistrictByStateId(int? StateId)
        {
            try
            {
                UserCreationModel userCreationModel = new UserCreationModel();
                List<UserCreationModel> districtModels = new List<UserCreationModel>();
                userCreationModel.StateId = StateId;
                districtModels = _userModel.GetDistrictList(userCreationModel);
                return Json(districtModels);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// To Bind Department Dropdownlist by selecting usertype
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        public JsonResult GetRoleTypeListByUserTypeId(int? UserTypeId)
        {
            try
            {
                UserCreationModel userCreationModel = new UserCreationModel();
                userCreationModel.UsertypeId = UserTypeId;
                List<UserCreationModel> userCreationList = new List<UserCreationModel>();
                userCreationList = _userModel.GetRoleTypeListByUserType(userCreationModel);
                return Json(userCreationList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// To Bind Designation Dropdwon by selecting Department
        /// </summary>
        /// <param name="RoleTypeId"></param>
        /// <returns></returns>
        public JsonResult GetRoleListByRoleTypeId(int? RoleTypeId)
        {
            try
            {
                UserCreationModel userCreationModel = new UserCreationModel();
                userCreationModel.RoleTypeId = RoleTypeId;
                List<UserCreationModel> userCreationList = new List<UserCreationModel>();
                userCreationList = _userModel.GetRoleListByRoleType(userCreationModel);
                return Json(userCreationList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i <= bytes.Length - 1; i++)
                    builder.Append(bytes[i].ToString("x2"));

                return builder.ToString();
            }
        }

    }
}