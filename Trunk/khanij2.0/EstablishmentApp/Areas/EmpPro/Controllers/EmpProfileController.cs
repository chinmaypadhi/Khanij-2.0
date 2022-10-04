using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentApp.Areas.EmpPro.Models.EmpProfile;
using EstablishmentEf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

using EstablishmentApp.ActionFilter;
using EstablishmentApp.Web;
using System.Security.Cryptography;
using System.Text;

namespace EstablishmentApp.Areas.EmpPro.Controllers
{
    [Area("EmpPro")]
    public class EmpProfileController : Controller
    {
        
        private IEmpProfileModel _EmpProfileModel;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration configuration;

        //private readonly KhanijSecurity.KhanijIDataProtection protector;

        public EmpProfileController(IEmpProfileModel EmpProfileModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _EmpProfileModel = EmpProfileModel;
            this._hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;

            //protector = khanijIDataProtection;

        }
        [Decryption]
        public IActionResult EmpDetail(string id = "0")
        {
            try
            {
                EmpProfileEf objEmpProfileEf = new EmpProfileEf();


                ViewBag.EmployeeType = Enumerable.Empty<SelectListItem>();
                ViewBag.Designation = Enumerable.Empty<SelectListItem>();
                ViewBag.Category = Enumerable.Empty<SelectListItem>();
                ViewBag.Class = Enumerable.Empty<SelectListItem>();
                ViewBag.HomeSate = Enumerable.Empty<SelectListItem>();
                ViewBag.HomeDistrict = Enumerable.Empty<SelectListItem>();
                ViewBag.PresentDistrict = Enumerable.Empty<SelectListItem>();
                ViewBag.PerDistrict = Enumerable.Empty<SelectListItem>();
                ViewBag.Gender = Enumerable.Empty<SelectListItem>();
                ViewBag.MaritalStatus = Enumerable.Empty<SelectListItem>();
                ViewBag.PostingDistrict = Enumerable.Empty<SelectListItem>();

                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objEmpProfileEf.intCreatedBy = profile.UserId;
                objEmpProfileEf.UserLoginId = profile.UserLoginId;

                if (id != "0")
                {
                    //int iId = Convert.ToInt32(protector.Encode(id));
                    int iId = Convert.ToInt32(id);
                    objEmpProfileEf.intEmployeeid = iId;
                    objEmpProfileEf = _EmpProfileModel.ViewDetails(objEmpProfileEf);
                }
                #region bind user info
                else if (id == "0")
                {

                    objEmpProfileEf.Satus = "2";
                    objEmpProfileEf = _EmpProfileModel.ViewUserInformation(objEmpProfileEf);
                    if (objEmpProfileEf.VchName == null)
                    {
                        TempData["msg"] = "0";//profile applied/approved
                        //return View(objEmpProfileEf);
                    }
                }
                #endregion
                
                


                //ViewBag.EmployeeType =
                EmpDropDown objEmpDropDown = new EmpDropDown();
                objEmpDropDown.Action = "empType";
                var EmployeeType = _EmpProfileModel.Dropdown(objEmpDropDown);
                objEmpDropDown.Action = "Designation";
                var Designation = _EmpProfileModel.Dropdown(objEmpDropDown);
                objEmpDropDown.Action = "Category";
                var Category = _EmpProfileModel.Dropdown(objEmpDropDown);
                objEmpDropDown.Action = "Class";
                var Class = _EmpProfileModel.Dropdown(objEmpDropDown);
                objEmpDropDown.Action = "State";
                var HomeSate = _EmpProfileModel.Dropdown(objEmpDropDown);
                objEmpDropDown.Action = "District";
                //objEmpDropDown.Stateid = 7;
                var HomeDistrict = _EmpProfileModel.Dropdown(objEmpDropDown);
                objEmpDropDown.Action = "Gender";
                var Gender = _EmpProfileModel.Dropdown(objEmpDropDown);
                objEmpDropDown.Action = "Marital";
                var MaritalStatus = _EmpProfileModel.Dropdown(objEmpDropDown);


                objEmpDropDown.Action = "District";
                objEmpDropDown.Stateid = 7;
                var PresentDistrict = _EmpProfileModel.Dropdown(objEmpDropDown);
                objEmpDropDown.Action = "District";
                objEmpDropDown.Stateid = 7;
                var PerDistrict = _EmpProfileModel.Dropdown(objEmpDropDown);

                objEmpDropDown.Action = "Department";
                var Department = _EmpProfileModel.Dropdown(objEmpDropDown);

                objEmpDropDown.Action = "District";
                objEmpDropDown.Stateid = 7;
                var PostingDistrict = _EmpProfileModel.Dropdown(objEmpDropDown);

                objEmpDropDown.Action = "Level";
                var Level = _EmpProfileModel.Dropdown(objEmpDropDown);

                objEmpDropDown.Action = "Establishment";
                var Establishmentoffice = _EmpProfileModel.Dropdown(objEmpDropDown);


                objEmpDropDown.Action = "Recruitment";
                var Recruitment = _EmpProfileModel.Dropdown(objEmpDropDown);

                objEmpDropDown.Action = "Section";
                var Section = _EmpProfileModel.Dropdown(objEmpDropDown);


                ViewBag.EmployeeType = EmployeeType.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();
                ViewBag.Designation = Designation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();
                ViewBag.Category = Category.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();
                ViewBag.Class = Class.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();
                ViewBag.HomeSate = HomeSate.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();

                if (objEmpProfileEf.IntHomeSate > 0)
                {
                    //EmpDropDown objEmpDropDown = new EmpDropDown();
                    objEmpDropDown.Action = "District";
                    objEmpDropDown.Stateid = objEmpProfileEf.IntHomeSate;
                    var HomeDistrictt = _EmpProfileModel.Dropdown(objEmpDropDown);
                    ViewBag.HomeDistrict = HomeDistrictt.ToList().Select(c => new SelectListItem
                    {
                        Text = c.Text,
                        Value = c.value.ToString(),

                    }).ToList();
                }


                ViewBag.PresentDistrict = PresentDistrict.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();
                ViewBag.PerDistrict = PerDistrict.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();


                ViewBag.Gender = Gender.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();
                ViewBag.MaritalStatus = MaritalStatus.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();
                ViewBag.Department = Department.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();

                ViewBag.PostingDistrict = PostingDistrict.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();


                ViewBag.Level = Level.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();

                ViewBag.Establishmentoffice = Establishmentoffice.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();

                ViewBag.Recruitment = Recruitment.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();

                ViewBag.Section = Section.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),

                }).ToList();

                return View(objEmpProfileEf);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult EmpPerDetail(EmpProfileEf objEmpProfileEf)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objEmpProfileEf.intCreatedBy = profile.UserId;
                objEmpProfileEf.UserLoginId = profile.UserLoginId;

                string AadharCard = string.Empty;
                string AadharCardPath = string.Empty;
                string Signature = string.Empty;
                string SignaturePath = string.Empty;
                string Photo = string.Empty;
                string PhotoPath = string.Empty;


                //objEmpProfileEf.intCreatedBy = 1;


                if (TempData["AadharCard"] != null)
                {
                    AadharCard = Convert.ToString(TempData["AadharCard"]);
                    AadharCardPath = Convert.ToString(TempData["AadharCardPath"]);
                    objEmpProfileEf.VchAadharCard = AadharCard;
                    objEmpProfileEf.VchAadharCardPath = AadharCardPath;
                }

                if (TempData["Signature"] != null)
                {
                    Signature = Convert.ToString(TempData["Signature"]);
                    SignaturePath = Convert.ToString(TempData["SignaturePath"]);

                    objEmpProfileEf.VchSignature = Signature;
                    objEmpProfileEf.VchSignaturePath = SignaturePath;
                }


                if (TempData["Photo"] != null)
                {
                    Photo = Convert.ToString(TempData["Photo"]);
                    PhotoPath = Convert.ToString(TempData["PhotoPath"]);

                    objEmpProfileEf.VchPhoto = Photo;
                    objEmpProfileEf.VchPhotoPath = PhotoPath;
                }
                //if (HttpContext.Session.GetString("AadharCard") != null)
                //{
                //    AadharCard = HttpContext.Session.GetString("AadharCard");
                //    AadharCardPath = HttpContext.Session.GetString("AadharCardPath");
                //    objEmpProfileEf.VchAadharCard = AadharCard;
                //    objEmpProfileEf.VchAadharCardPath = AadharCardPath;
                //}


                //if (HttpContext.Session.GetString("Signature") != null)
                //{
                //    Signature = HttpContext.Session.GetString("Signature");
                //    SignaturePath = HttpContext.Session.GetString("SignaturePath");

                //    objEmpProfileEf.VchSignature = Signature;
                //    objEmpProfileEf.VchSignaturePath = SignaturePath;
                //}


                //if (HttpContext.Session.GetString("Photo") != null)
                //{
                //    Photo = HttpContext.Session.GetString("Photo");
                //    PhotoPath = HttpContext.Session.GetString("PhotoPath");

                //    objEmpProfileEf.VchPhoto = Photo;
                //    objEmpProfileEf.VchPhotoPath = PhotoPath;
                //}


                if (objEmpProfileEf.intEmployeeid == 0 || objEmpProfileEf.intEmployeeid == null)
                {
                    //if (objEmpProfileEf.Password != null)
                    //{
                    //    if ( objEmpProfileEf.Password.Trim() != "")
                    //    {
                    //        string s = ComputeSha256Hash(objEmpProfileEf.Password).ToUpper();
                    //        string s1 = ComputeSha256Hash(s).ToUpper();
                    //        objEmpProfileEf.EncryptPassword = s1;
                    //    }
                    //}
                    objEmpProfileEf.Satus = "A";
                }
                else
                {
                    objEmpProfileEf.Satus = "U";

                }
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = _EmpProfileModel.AddEmpProfile(objEmpProfileEf);



                if (TempData["AadharCard"] != null)
                {
                    TempData["AadharCard"] = null;
                    TempData["AadharCardPath"] = null;
                }

                if (TempData["Signature"] != null)
                {
                    TempData["Signature"] = null;
                    TempData["SignaturePath"] = null;
                }

                if (TempData["Photo"] != null)
                {
                    TempData["Photo"] = null;
                    TempData["PhotoPath"] = null;
                }
                //if (HttpContext.Session.GetString("AadharCard") != null)
                //{
                //    HttpContext.Session.Remove("AadharCard");
                //    HttpContext.Session.Remove("AadharCardPath");
                //}
                //if (HttpContext.Session.GetString("Signature") != null)
                //{
                //    HttpContext.Session.Remove("Signature");
                //    HttpContext.Session.Remove("SignaturePath");
                //}
                //if (HttpContext.Session.GetString("Photo") != null)
                //{
                //    HttpContext.Session.Remove("Photo");
                //    HttpContext.Session.Remove("PhotoPath");
                //}

                return Json(objMessageEF);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        [HttpPost]

        public IActionResult EmpAdrDetail(EmpProfileEf objEmpProfileEf)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objEmpProfileEf.intCreatedBy = profile.UserId;
                objEmpProfileEf.UserLoginId = profile.UserLoginId;
                objEmpProfileEf.Satus = "A";
                //objEmpProfileEf.intCreatedBy = 1;
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = _EmpProfileModel.AddAddress(objEmpProfileEf);
                return Json(objMessageEF);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        [HttpPost]
        public IActionResult EmpPostDetail(EmpProfileEf objEmpProfileEf)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objEmpProfileEf.intCreatedBy = profile.UserId;
                objEmpProfileEf.UserLoginId = profile.UserLoginId;
                objEmpProfileEf.Satus = "A";
                //objEmpProfileEf.intCreatedBy = 1;
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = _EmpProfileModel.AddPostingAddress(objEmpProfileEf);
                return Json(objMessageEF);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        [HttpPost]
        public JsonResult District(int Stateid)
        {
            EmpDropDown objEmpDropDown = new EmpDropDown();
            objEmpDropDown.Action = "District";
            objEmpDropDown.Stateid = Stateid;
            var HomeDistrict = _EmpProfileModel.Dropdown(objEmpDropDown);
            return Json(HomeDistrict);
        }
        //[HttpPost]
        //public JsonResult GetUserId(string userName)
        //{
        //    try
        //    {
        //        EmpProfileEf objEmp = new EmpProfileEf();
        //        objEmp.Satus = "B";
        //        objEmp.UserName = userName;
        //        var UserDetails = _EmpProfileModel.GetUserId(objEmp);
        //        return Json(UserDetails);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpPost]
        public JsonResult UploadPerFIle(List<IFormFile> files)
        {

            string uniqueFileName = string.Empty;
            string filePath = string.Empty;
            string ExtensionId = string.Empty;

            string uploadsFolder = string.Empty;
            var RootPath=string.Empty;


            dynamic FilePath = new List<dynamic>();

            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                string name = Request.Form.Files[i].Name;
                var file = Request.Form.Files[i];//Uploaded file
                                                 
                long fileSize = file.Length;
                uniqueFileName = name + DateTime.Now.ToString("ddMMyyyHHmmss") + Path.GetExtension(file.FileName).ToLowerInvariant();

                string mimeType = file.ContentType;
                //System.IO.Stream fileContent = file.CopyToAsync(;
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), name)))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), name));
                }
                ////To save file, use SaveAs method
                if (name.Trim() == "AadharCard")
                {
                    filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("EmployeeAadhar"), uniqueFileName);
                    RootPath = Path.Combine(_hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("EmployeeAadhar"));
                    uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    TempData["AadharCard"] = uniqueFileName.Trim();
                    TempData["AadharCardPath"] = filePath.Trim();
                    //HttpContext.Session.SetString("AadharCard", uniqueFileName.Trim());
                    //HttpContext.Session.SetString("AadharCardPath", filePath.Trim());
                }
                else if (name.Trim() == "Signature")
                {
                    filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("EmployeeSignature"), uniqueFileName);
                    RootPath = Path.Combine(_hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("EmployeeSignature"));
                    uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    TempData["Signature"] = uniqueFileName.Trim();
                    TempData["SignaturePath"] = filePath.Trim();

                    //HttpContext.Session.SetString("Signature", uniqueFileName.Trim());
                    //HttpContext.Session.SetString("SignaturePath", filePath.Trim());
                }
                else if (name.Trim() == "Photo")
                {
                    filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("EmployeePhoto"), uniqueFileName);
                    RootPath = Path.Combine(_hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("EmployeePhoto"));
                    uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    TempData["Photo"] = uniqueFileName.Trim();
                    TempData["PhotoPath"] = filePath.Trim();

                    //HttpContext.Session.SetString("Photo", uniqueFileName.Trim());
                    //HttpContext.Session.SetString("PhotoPath", filePath.Trim());
                }

                using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                //filePath = Path.Combine(Directory.GetCurrentDirectory(), name, fileName);
                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    file.CopyTo(fileStream);
                //}
                dynamic path = new JObject();
                path.Name = name;
                path.Value = Path.Combine(name, uniqueFileName);
                FilePath.Add(path);
             
            }
            return Json(FilePath);
            #region File Upload
            //if (objmodel.CTO_FORM_UPLOAD != null) 
            //{
            //    uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.CTO_FORM_UPLOAD.FileName);
            //    filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadCTOPath"), uniqueFileName);
            //    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadCTOPath"));
            //    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
            //    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
            //    objmodel.CTO_FORM_UPLOAD.CopyTo(fileStream);
            //    objmodel.FILE_CTO_LETTER = uniqueFileName;
            //    objmodel.CTO_LETTER_PATH = filePath;
            //    uniqueFileName = null;
            //    filePath = null;
            //}
            //objmodel.CTO_FORM_UPLOAD = null;
            #endregion
        }
        public IActionResult ViewEmp()
        {
            List<EmpProfileEf> objListEmpProfileEf = new List<EmpProfileEf>();
            EmpProfileEf objEmpProfileEf = new EmpProfileEf();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objEmpProfileEf.intCreatedBy = profile.UserId;
                objEmpProfileEf.UserLoginId = profile.UserLoginId;
                objEmpProfileEf.Satus = "V";
                objListEmpProfileEf = _EmpProfileModel.getList(objEmpProfileEf);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(objListEmpProfileEf);
        }
        public IActionResult ViewDetails(EmpProfileEf objEmpProfileEf)
        {
            try
            {
                objEmpProfileEf.intEmployeeid  = objEmpProfileEf.intEmployeeid;
                objEmpProfileEf = _EmpProfileModel.ViewDetails(objEmpProfileEf);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(objEmpProfileEf);
        }
        //public static string ComputeSha256Hash(string rawData)
        //{
        //    using (SHA256 sha256Hash = SHA256.Create())
        //    {
        //        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        //        StringBuilder builder = new StringBuilder();

        //        for (int i = 0; i <= bytes.Length - 1; i++)
        //            builder.Append(bytes[i].ToString("x2"));

        //        return builder.ToString();
        //    }
        //}

        #region EmployeeProfileInbox

        /// <summary>
        /// leave inbox details
        /// </summary>
        /// <returns></returns>
        public IActionResult EmployeeProfileInbox()
        {

            EmployeeProfileInboxQuery objApplyLeave =  EmployeeProfileInboxQuery.GetInstance();
            List<EmployeeProfileInboxQuery> listAuthoritySetting = new List<EmployeeProfileInboxQuery>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objApplyLeave.intCreatedBy = profile.UserId;

                objApplyLeave.Check = 1;
                objApplyLeave.intModuleId = 30;
                objApplyLeave.intSubModuleId = 3;
                listAuthoritySetting = _EmpProfileModel.ViewEmployeeProfileInbox(objApplyLeave);
                return View(listAuthoritySetting);

            }
            catch (Exception)
            {

                throw;
            }
       
        }
        /// <summary>
        /// leave take action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult ProfileTakeAction(string id = "0")
        {
            EmployeeProfileInboxDetails objInboxDetails = EmployeeProfileInboxDetails.GetInstance();
            //LeaveInboxDetails objInboxDetails = new LeaveInboxDetails();
            //LeaveDropDown objAction = new LeaveDropDown();
            WorkFlowDropDown objAction = new WorkFlowDropDown();
            try
            {
                ViewBag.ActionType = Enumerable.Empty<SelectListItem>();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objInboxDetails.intCreatedBy = profile.UserId;

                int iId = Convert.ToInt32(id);
                objInboxDetails.Check = 1;
                objInboxDetails.intEmployeeid = iId;
                objInboxDetails.intModuleId = 30;//----Establishment Module id
                objInboxDetails.intSubModuleId = 3;//---employee profile submodule id
                objInboxDetails =  _EmpProfileModel.ViewEmployeeProfileInboxDetails(objInboxDetails);


                objAction.Check = 1;
                objAction.Id = iId;
                objAction.Id2 = 30;//----Leave Module id
                objAction.Id3 = 3;//---employee profile submodule id
                var varACtionType = _EmpProfileModel.BindActionType(objAction);
                //var varACtionType = _LeaveManagementModel.BindActionType(new WorkFlowDropDown() { Check = 3, Id = iId, Id2 = 30, Id3 = 2 });

                ViewBag.ActionType = varACtionType.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),
                }

                    ).ToList();

                return View(objInboxDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// take leave action approve/reject
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ProfileTakeAction(EmployeeProfileInboxDetails objmodel)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;
                objmodel.Check = 2;//---1
                objMessageEF = _EmpProfileModel.ProfileTakeAction(objmodel);
                if (objMessageEF.Satus == "1")
                {
                    if (objmodel.IntActionId == 1)
                    {
                        TempData["msg"] = "1";//forwaded Successfully

                    }
                    if (objmodel.IntActionId == 2)
                    {
                        TempData["msg"] = "2";//Approved Successfully
                        //Notification objNotification = new Notification(new MailNotification());
                        //objNotification.SendNotification("9937218715", "Approved Successfully");
                    }
                    if (objmodel.IntActionId == 4)
                    {
                        TempData["msg"] = "4";//rejected Successfully
                    }
                    return RedirectToAction("ViewEmployeeProfileInbox");

                }
                else
                {
                    TempData["msg"] = "Error ! while Saving Leave Details";

                }
                return RedirectToAction("ViewEmployeeProfileInbox");
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        /// View leave inbox details
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewEmployeeProfileInbox()
        {

            EmployeeProfileInboxQuery objApplyLeave = EmployeeProfileInboxQuery.GetInstance();
            List<EmployeeProfileInboxQuery> listAuthoritySetting = new List<EmployeeProfileInboxQuery>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objApplyLeave.intCreatedBy = profile.UserId;

                objApplyLeave.Check = 2;
                objApplyLeave.intModuleId = 30;//establishment
                objApplyLeave.intSubModuleId = 3;//employee profile
                listAuthoritySetting =  _EmpProfileModel.ViewEmployeeProfileInbox(objApplyLeave);
                return View(listAuthoritySetting);

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}