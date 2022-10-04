using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Areas.EndUserProfile.Models;
using userregistrationApp.Web;
using userregistrationEF;

namespace userregistrationApp.Areas.EndUserProfile.Controllers
{
    [Area("EndUserProfile")]
    public class EndUserController : Controller
    {
        IEndUserModel _objIEndUserModel;
        private readonly IHostingEnvironment _hostingEnvironment;
        MessageEF objobjmodel = new MessageEF();
        EndUserProfileViewModel objprofile = new EndUserProfileViewModel();
        userregistrationEF.EndUserModel objmodel = new userregistrationEF.EndUserModel();

        public EndUserController(IEndUserModel endUserModel, IHostingEnvironment hostingEnvironment)
        {
            _objIEndUserModel = endUserModel;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            //ViewBag.EndUserflag = EndUserflag;
            objprofile.UserId = profile.UserId; //30756;
            EndUserProfileViewModel endUserProfileViewModel = _objIEndUserModel.ViewProfile(objprofile);
            
            if(endUserProfileViewModel.Is_Forwarded==1)
            {
                //TempData["VerifyProfile1"] = endUserProfileViewModel;
                return RedirectToAction("VerificationPending", "EndUser");
            }
            return View(endUserProfileViewModel);
        }
        public IActionResult EditProfile(int id = 0)
        {

            var x = _objIEndUserModel.GetIType(objmodel);

            if (x.IndustryType != null)
            {
                ViewBag.ViewIndustryList = x.IndustryType.Select(c => new SelectListItem
                {
                    Text = c.Type,
                    Value = c.EUP_Id.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewIndustryList = Enumerable.Empty<SelectListItem>();
            }

            var y = _objIEndUserModel.GetState(objmodel);

            if (y.ListOfState != null)
            {
                ViewBag.ViewStateList = y.ListOfState.Select(c => new SelectListItem
                {
                    Text = c.StateName,
                    Value = c.StateId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewStateList = Enumerable.Empty<SelectListItem>();
            }

            var Z = _objIEndUserModel.GetState_O(objmodel);

            if (Z.ListOfState != null)
            {
                ViewBag.ViewStateList_O = Z.ListOfState.Select(c => new SelectListItem
                {
                    Text = c.StateName_O,
                    Value = c.StateId_O.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewStateList_O = Enumerable.Empty<SelectListItem>();
            }

            var S = _objIEndUserModel.GetSQ(objmodel);

            if (S.ListOfState != null)
            {
                ViewBag.ViewSQ = S.ListOfState.Select(c => new SelectListItem
                {
                    Text = c.SQuestion,
                    Value = c.SQuestionId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewSQ = Enumerable.Empty<SelectListItem>();
            }

            objmodel.EndUserTypeStatus = "Individual/Proprietor";
            objmodel.Firm = "Partnership";
            objmodel.Company = "Private";
            var list = new SelectList(new[]
                    {
                        new { ID = "Captive", Name = "Captive" },
                        new { ID = "Non-Captive", Name = "Non-Captive" },

                    },
                    "ID", "Name", 1);
            ViewBag.ViewPuppose = list;
            objmodel.UserId = 30756;
            userregistrationEF.EndUserModel objenduser = _objIEndUserModel.EditEndUserProfile(objmodel);
            //ViewBag.EndUserflag = EndUserflag;
            return View(objenduser);
        }
        [HttpPost]
        public IActionResult EditProfile(userregistrationEF.EndUserModel endUserModel, List<int> MineralCount, List<int> MineralFormCount, List<int> MineralGradeCount, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            endUserModel.UserId = profile.UserId;
            //endUserModel.UserId = 30756;
            if (ModelState.IsValid)
            {
                string AAdharFileName = null; string AAdharfilePath = null;
                string PanFileName = null; string PanfilePath = null;
                string TinFileName = null; string TinfilePath = null;
                string GSTFileName = null; string GSTfilePath = null;
                string RCopyFileName = null; string RCopyfilePath = null;
                string AffitFileName = null; string AffitfilePath = null;
                string EBillFileName = null; string EBillfilePath = null;
                string CTOFileName = null; string CTOfilePath = null;
                string mineralid = "", mineralformid = "", mineralgradeid = "";

                endUserModel.RegistrationNo = "EUP" + string.Format("{0:yyyyMMdd}", DateTime.Now);
                if (endUserModel.AAdharDocument != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "EndUserRegistration\\Aadhar");
                    AAdharFileName = Guid.NewGuid().ToString() + "_" + endUserModel.AAdharDocument.FileName;
                    AAdharfilePath = Path.Combine(uploadsFolder, AAdharFileName);
                    using (var fileStream = new FileStream(AAdharfilePath, FileMode.Create))
                        endUserModel.AAdharDocument.CopyTo(fileStream);
                }
                if (endUserModel.PanDocument != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "EndUserRegistration\\Pan");
                    PanFileName = Guid.NewGuid().ToString() + "_" + endUserModel.PanDocument.FileName;
                    PanfilePath = Path.Combine(uploadsFolder, PanFileName);
                    using (var fileStream = new FileStream(PanfilePath, FileMode.Create))
                        endUserModel.PanDocument.CopyTo(fileStream);
                }
                if (endUserModel.TinDocument != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "EndUserRegistration\\Tin");
                    TinFileName = Guid.NewGuid().ToString() + "_" + endUserModel.TinDocument.FileName;
                    TinfilePath = Path.Combine(uploadsFolder, TinFileName);
                    using (var fileStream = new FileStream(TinfilePath, FileMode.Create))
                        endUserModel.TinDocument.CopyTo(fileStream);
                }
                if (endUserModel.GstDocument != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "EndUserRegistration\\GST");
                    GSTFileName = Guid.NewGuid().ToString() + "_" + endUserModel.GstDocument.FileName;
                    GSTfilePath = Path.Combine(uploadsFolder, GSTFileName);
                    using (var fileStream = new FileStream(GSTfilePath, FileMode.Create))
                        endUserModel.GstDocument.CopyTo(fileStream);
                }
                if (endUserModel.RcopyDocument != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "EndUserRegistration\\RCopy");
                    RCopyFileName = Guid.NewGuid().ToString() + "_" + endUserModel.RcopyDocument.FileName;
                    RCopyfilePath = Path.Combine(uploadsFolder, RCopyFileName);
                    using (var fileStream = new FileStream(RCopyfilePath, FileMode.Create))
                        endUserModel.RcopyDocument.CopyTo(fileStream);
                }
                if (endUserModel.AffitDocument != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "EndUserRegistration\\ADoc");
                    AffitFileName = Guid.NewGuid().ToString() + "_" + endUserModel.AffitDocument.FileName;
                    AffitfilePath = Path.Combine(uploadsFolder, AffitFileName);
                    using (var fileStream = new FileStream(AffitfilePath, FileMode.Create))
                        endUserModel.AffitDocument.CopyTo(fileStream);
                }
                if (endUserModel.EbillDocument != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "EndUserRegistration\\Ebill");
                    EBillFileName = Guid.NewGuid().ToString() + "_" + endUserModel.EbillDocument.FileName;
                    EBillfilePath = Path.Combine(uploadsFolder, EBillFileName);
                    using (var fileStream = new FileStream(EBillfilePath, FileMode.Create))
                        endUserModel.EbillDocument.CopyTo(fileStream);
                }
                if (endUserModel.CTODocument != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "EndUserRegistration\\CTO");
                    CTOFileName = Guid.NewGuid().ToString() + "_" + endUserModel.CTODocument.FileName;
                    CTOfilePath = Path.Combine(uploadsFolder, CTOFileName);
                    using (var fileStream = new FileStream(CTOfilePath, FileMode.Create))
                        endUserModel.CTODocument.CopyTo(fileStream);
                }

                if (AAdharFileName != null && AAdharfilePath != null)
                {
                    endUserModel.Aadhaar_FILE_PATH = AAdharfilePath;
                    endUserModel.Aadhaar_FILE_NAME = AAdharFileName;
                }

                if (PanFileName != null && PanfilePath != null)
                {
                    endUserModel.PAN_FILE_PATH = PanfilePath;
                    endUserModel.PAN_FILE_NAME = PanFileName;
                }

                if (TinFileName != null && TinfilePath != null)
                {
                    endUserModel.TIN_FILE_PATH = TinfilePath;
                    endUserModel.TIN_FILE_NAME = TinFileName;
                }

                if (GSTFileName != null && GSTfilePath != null)
                {
                    endUserModel.GST_FILE_PATH = GSTfilePath;
                    endUserModel.GST_FILE_NAME = GSTFileName;
                }

                if (CTOFileName != null && CTOfilePath != null)
                {
                    endUserModel.CTO_FILE_PATH = CTOfilePath;
                    endUserModel.CTO_FILE_NAME = CTOFileName;
                }

                if (AffitfilePath != null && AffitFileName != null)
                {
                    endUserModel.ProductionCertificate_FILE_PATH = AffitfilePath;
                    endUserModel.ProductionCertificate_FILE_NAME = AffitFileName;
                }

                if (EBillfilePath != null && EBillFileName != null)
                {
                    endUserModel.ElectricityBill_FILE_PATH = EBillfilePath;
                    endUserModel.ElectricityBill_FILE_NAME = EBillFileName;
                }

                if (RCopyFileName != null && RCopyfilePath != null)
                {
                    endUserModel.RegistrationCopy_FILE_PATH = RCopyfilePath;
                    endUserModel.RegistrationCopy_FILE_NAME = RCopyFileName;
                }


                if (MineralCount != null)
                {
                    if (MineralCount.Count > 0)
                    {
                        for (int i = 0; i < MineralCount.Count; i++)
                        {
                            mineralid += MineralCount[i].ToString();
                            mineralid += ",";
                        }
                    }
                }

                endUserModel.MineralCnt = (MineralCount != null ? MineralCount.Count : 0);
                endUserModel.MineralId = mineralid;
                if (MineralFormCount != null)
                {
                    if (MineralFormCount.Count > 0)
                    {
                        for (int i = 0; i < MineralFormCount.Count; i++)
                        {
                            mineralformid += MineralFormCount[i].ToString();
                            mineralformid += ",";
                        }
                    }
                }
                endUserModel.MineralFormCnt = (MineralFormCount != null ? MineralFormCount.Count : 0);
                endUserModel.MineralFormId = mineralformid;

                if (MineralGradeCount != null)
                {
                    if (MineralGradeCount.Count > 0)
                    {
                        for (int i = 0; i < MineralGradeCount.Count; i++)
                        {
                            mineralgradeid += MineralGradeCount[i].ToString();
                            mineralgradeid += ",";
                        }
                    }
                }
                endUserModel.MineralGradeCnt = (MineralGradeCount != null ? MineralGradeCount.Count : 0);
                endUserModel.MineralGradeId = mineralgradeid;

                endUserModel.AAdharDocument = null;
                endUserModel.PanDocument = null;
                endUserModel.TinDocument = null;
                endUserModel.GstDocument = null;
                endUserModel.RcopyDocument = null;
                endUserModel.AffitDocument = null;
                endUserModel.EbillDocument = null;
                endUserModel.CTODocument = null;

                MessageEF messageEF = _objIEndUserModel.UpdateEndUserProfile(endUserModel);
                if (messageEF.Satus == "1")
                {
                    TempData["Message"] = "End User Profile Updated Sucessfully";
                    return RedirectToAction("Profile", "EndUser", new { Area = "EndUserProfile" });
                }
                else if (messageEF.Satus == "2")
                {
                    TempData["Message"] = "This mobile number or email-id already in use! Please enter with new mobile number or email-id.";
                }
                else
                {
                    TempData["Message"] = "Profile not sent for approval !";
                }
               
            }
                       
            return RedirectToAction("Profile", "EndUser", new { Area = "EndUserProfile" });
            
        }
        [HttpGet]
        public IActionResult VerificationPending()
        {
            userregistrationEF.EndUserModel objModel = (userregistrationEF.EndUserModel)TempData["VerifyProfile1"];
            return View();
        }
    }
}
