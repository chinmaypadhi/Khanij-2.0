using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using userregistrationApp.ActionFilter;
using userregistrationApp.Areas.Contractor.Models.ContractorBuilders;
using userregistrationApp.Areas.Contractor.Models.TailingDam;
using userregistrationApp.Areas.Contractor.Models.VTDVendor;
using userregistrationApp.Models.EncryptDecrypt;
using userregistrationApp.Models.MailService;
using userregistrationApp.Models.SMSService;
using userregistrationApp.Models.WebsiteMenu;
using userregistrationApp.Web;
using userregistrationEF;

namespace userregistrationApp.Areas.Contractor.Controllers
{
    [Area("Contractor")]
    public class ContractorController : Controller
    {
        private readonly IWebsiteMenuModel websiteMenuModel;
        private readonly IVTDVendor vTDVendor;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ISMSModel sMSModel;
        private readonly IMailModel mailModel;
        private readonly IContractorBuilder contractorBuilder;
        private readonly ITailingDamModel tailingDamModel;
        private readonly IConfiguration configuration;
        string uniqueTransport_Department_Approval_Letter = null;
        string fileTransport_Department_ApprovalPath = null;
        MessageEF messageEF = new MessageEF();
        List<cls_TailingDam> objlistmodel = new List<cls_TailingDam>();
        VTDVendorProfileModel objVTDVendorProfileModel = new VTDVendorProfileModel();
        public ContractorController(IWebsiteMenuModel websiteMenuModel, IVTDVendor vTDVendor,
            IHostingEnvironment hostingEnvironment, ISMSModel sMSModel, IMailModel mailModel,
            IContractorBuilder contractorBuilder, ITailingDamModel tailingDamModel, IConfiguration configuration)
        {
            this.websiteMenuModel = websiteMenuModel;
            this.vTDVendor = vTDVendor;
            this.hostingEnvironment = hostingEnvironment;
            this.sMSModel = sMSModel;
            this.mailModel = mailModel;
            this.contractorBuilder = contractorBuilder;
            this.tailingDamModel = tailingDamModel;
            this.configuration = configuration;
        }

        #region Contractor Builder Registration
        [SkipImportantTask]
        public IActionResult ContractorBuilderReg()
        {
            ViewData["MainmenuTable"] = websiteMenuModel.GetMainmenulist();
            ViewData["FootermenuTable"] = websiteMenuModel.GetFootermenulist();
            ViewData["StateDetails"] = vTDVendor.GetStateDetails(new CommonAddressDetails { });
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            return View();
        }

        [SkipImportantTask]
        [HttpPost]
        public IActionResult ContractorBuilderReg(ContractorBuilderModel contractorBuilderModel)
        {
            contractorBuilderModel.RegistrationNo = "CB" + string.Format("{0:yyyyMMdd}", DateTime.Now);

            #region Upload ID Proof 
            string uniqueIDProof = null;
            string fileIDProofPath = null;
            if (contractorBuilderModel.IDProof != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/ContractorBuilderDocument");
                uniqueIDProof = Guid.NewGuid().ToString() + "_" + contractorBuilderModel.IDProof.FileName;
                fileIDProofPath = Path.Combine(uploadsFolder, uniqueIDProof);
                contractorBuilderModel.IDProof.CopyTo(new FileStream(fileIDProofPath, FileMode.Create));
            }
            contractorBuilderModel.IDProof = null;
            contractorBuilderModel.UploadIDProof = uniqueIDProof;
            contractorBuilderModel.UploadIDProofPath = fileIDProofPath;
            #endregion

            #region Upload RERA Registration  
            if (contractorBuilderModel.RegistrationType == "Builder")
            {
                string uniqueRERARegistration = null;
                string fileRERARegistrationPath = null;
                if (contractorBuilderModel.RERARegistration != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/ContractorBuilderDocument");
                    uniqueRERARegistration = Guid.NewGuid().ToString() + "_" + contractorBuilderModel.RERARegistration.FileName;
                    fileRERARegistrationPath = Path.Combine(uploadsFolder, uniqueRERARegistration);
                    contractorBuilderModel.RERARegistration.CopyTo(new FileStream(fileRERARegistrationPath, FileMode.Create));
                }
                contractorBuilderModel.RERARegistration = null;
                contractorBuilderModel.UploadRERARegistration = uniqueRERARegistration;
                contractorBuilderModel.UploadRERARegistrationPath = fileRERARegistrationPath;
            }
            #endregion

            messageEF = contractorBuilder.AddContractorBuilder(contractorBuilderModel);
            int Outputres = Convert.ToInt32(messageEF.Satus);
            if (Outputres > 0)
            {
                contractorBuilderModel.UserId = Convert.ToInt32(messageEF.Satus);
                contractorBuilderModel = contractorBuilder.GetContractorBuilderUserDetailsByUserId(contractorBuilderModel);
                TempData["SuccessMessage"] = " Your Registration Number is " + contractorBuilderModel.RegistrationNo + ".Your User Name is " + contractorBuilderModel.UserName + " and Password is " + contractorBuilderModel.Password + ".Please check your e-mail for details of registration. CHiMMS, GoCG";
                if (contractorBuilderModel.UserName != null && contractorBuilderModel.Password != null)
                {
                    if (contractorBuilderModel.UserName != "" && contractorBuilderModel.Password != "")
                    {
                        #region encryptPassword

                        string s = EncryptDecryptSha256.ComputeSha256Hash(contractorBuilderModel.Password).ToUpper();
                        string s1 = EncryptDecryptSha256.ComputeSha256Hash(s).ToUpper();
                        contractorBuilder.UpdateEncryptPassword(new UpdateEncryptPasswordModel() { UserName = contractorBuilderModel.UserName, EncryptPassword = s1 });

                        #endregion

                        #region Send SMS
                        try
                        {
                            string message = "";

                            message = "Contractor Builder Registration, " + Environment.NewLine + Environment.NewLine + "You have successfully applied for Registration with Khanij Online Portal. Your Registration Number is " + contractorBuilderModel.RegistrationNo + " Dated " + System.DateTime.Now + Environment.NewLine + Environment.NewLine +
                                   "Please check your e-mail for details of registration";
                            string templateid = "1307161883515998678";
                            sMSModel.Main(new SMS() { mobileNo = contractorBuilderModel.MobileNumber, message = message, templateid = templateid });
                        }
                        catch (Exception)
                        {

                        }
                        #endregion

                        #region Send Mail
                        try
                        {

                            mailModel.SendMail_EUP(new TransporterMail()
                            {
                                EmailId = contractorBuilderModel.EmailId,
                                TransporterName = contractorBuilderModel.ContractorBuilderName,
                                UserName = contractorBuilderModel.UserName,
                                Password = contractorBuilderModel.Password,
                                UserCode = contractorBuilderModel.UserName,
                                RegistrationNo = contractorBuilderModel.RegistrationNo,
                                Type = "REGISTRATION"
                            });
                        }
                        catch (Exception)
                        {

                            return RedirectToAction("ContractorBuilderReg", "Contractor");
                        }
                        #endregion

                    }
                }
            }
            return RedirectToAction("ContractorBuilderReg", "Contractor");
        }
        //added by ranjan for contractor profiles
        [SkipImportantTask]
        public IActionResult ContractorBuilderProfileView()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ContractorBuilderModel contractorbuildermodel = new ContractorBuilderModel();
            contractorbuildermodel= contractorBuilder.GetContractorBuilderUserDetailsByUserId(new ContractorBuilderModel { UserId = profile.UserId });
            return View(contractorbuildermodel);
        }
        [SkipImportantTask]
        [HttpPost]
        public IActionResult ContractorBuilderProfileEdit(ContractorBuilderModel contractorbuildermodel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewData["StateDetails"] = vTDVendor.GetStateDetails(new CommonAddressDetails { });
            contractorbuildermodel = contractorBuilder.GetContractorBuilderUserDetailsByUserId(new ContractorBuilderModel { UserId = profile.UserId });
            return View(contractorbuildermodel);
        }
        [HttpPost]
        public IActionResult ContractorBuilderProfileEditPost(ContractorBuilderModel contractorBuilderModel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            contractorBuilderModel.UserId = profile.UserId;
            contractorBuilderModel.IDProof = null;
            contractorBuilderModel.RERARegistration = null;
           // messageEF = contractorBuilder.EditContractorBuilder(contractorBuilderModel);
            int Outputres = Convert.ToInt32(messageEF.Satus);
            if (Outputres > 0)
            {
                
            }
            return RedirectToAction("ContractorBuilderProfileView", "ContractorBuilder");
        }
        //ranjan code ended
        #endregion

        #region Sand Stone Booking
        [SkipImportantTask]
        public IActionResult StoneSandBooking()
        {
            ViewData["MainmenuTable"] = websiteMenuModel.GetMainmenulist();
            ViewData["FootermenuTable"] = websiteMenuModel.GetFootermenulist();
            return View();
        }

        [SkipImportantTask]
        public IActionResult StoneSandBookingStatus()
        {
            ViewData["MainmenuTable"] = websiteMenuModel.GetMainmenulist();
            ViewData["FootermenuTable"] = websiteMenuModel.GetFootermenulist();
            return View();
        }

        #endregion

        #region VTD Vendor Registration
        [SkipImportantTask]
        public IActionResult VTDVendorReg()
        {
            ViewData["MainmenuTable"] = websiteMenuModel.GetMainmenulist();
            ViewData["FootermenuTable"] = websiteMenuModel.GetFootermenulist();
            ViewData["StateDetails"] = vTDVendor.GetStateDetails(new CommonAddressDetails { });
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            return View();
        }

        [SkipImportantTask]
        [HttpPost]
        public IActionResult VTDVendorReg(VTDVendorModel vTDVendorModel)
        {
            vTDVendorModel.RegistrationNo = "VTD" + string.Format("{0:yyyyMMdd}", DateTime.Now);           
            #region Transport Department Approval Letter 
            if (vTDVendorModel.ApprovalLetter != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/VTDVendorDocument");
                uniqueTransport_Department_Approval_Letter = Guid.NewGuid().ToString() + "_" + vTDVendorModel.ApprovalLetter.FileName;
                fileTransport_Department_ApprovalPath = Path.Combine(uploadsFolder, uniqueTransport_Department_Approval_Letter);
                vTDVendorModel.ApprovalLetter.CopyTo(new FileStream(fileTransport_Department_ApprovalPath, FileMode.Create));
            }
            #endregion
            vTDVendorModel.ApprovalLetter = null;
            vTDVendorModel.Transport_Dept_ApprovalLetter = uniqueTransport_Department_Approval_Letter;
            vTDVendorModel.Transport_Dept_ApprovalLetter_Path = fileTransport_Department_ApprovalPath;
            messageEF = vTDVendor.AddVTDVendor(vTDVendorModel);
            int Outputres = Convert.ToInt32(messageEF.Satus);
            if (Outputres > 0)
            {
                vTDVendorModel.UserId = Convert.ToInt32(messageEF.Satus);
                vTDVendorModel = vTDVendor.GetVTDUserDetailsByUserId(vTDVendorModel);
                TempData["SuccessMessage"] = " Your Registration Number is " + vTDVendorModel.RegistrationNo + ". Approval of your Application is Pending at Directorate of Geology and Mining, Chhattisgarh";
                if (vTDVendorModel.UserName != null && vTDVendorModel.Password != null)
                {
                    if (vTDVendorModel.UserName != "" && vTDVendorModel.Password != "")
                    {
                        #region encryptPassword

                        string s = EncryptDecryptSha256.ComputeSha256Hash(vTDVendorModel.Password).ToUpper();
                        string s1 = EncryptDecryptSha256.ComputeSha256Hash(s).ToUpper();
                        vTDVendor.UpdateEncryptPassword(new UpdateEncryptPasswordModel() { UserName = vTDVendorModel.UserName, EncryptPassword = s1 });

                        #endregion

                        #region Send SMS
                        try
                        {
                            string message = "";

                            message = "VTD User Registration, " + Environment.NewLine + Environment.NewLine + "You have successfully applied for Registration with Khanij Online Portal. Your Registration Number is " + vTDVendorModel.RegistrationNo + " Dated " + System.DateTime.Now + Environment.NewLine + Environment.NewLine +
                                  "Approval of your Application is Pending at Directorate of Geology and Mining, Chhattisgarh." + Environment.NewLine + Environment.NewLine +
                                   "Please check your e-mail for details of registration";

                            string templateid = "1307161883515998678";
                            sMSModel.Main(new SMS() { mobileNo = vTDVendorModel.Contact_Person_MobileNo, message = message, templateid = templateid });
                        }
                        catch (Exception)
                        {

                        }
                        #endregion

                        #region Send Mail
                        try
                        {

                            mailModel.SendMail_EUP(new TransporterMail()
                            {
                                EmailId = vTDVendorModel.Contact_Person_EmailId,
                                TransporterName = vTDVendorModel.CompanyName,
                                UserName = "",
                                Password = "",
                                UserCode = "",
                                RegistrationNo = vTDVendorModel.RegistrationNo,
                                Type = "REGISTRATION"
                            });
                        }
                        catch (Exception)
                        {

                            return RedirectToAction("VTDVendorReg", "Contractor");
                        }
                        #endregion

                    }
                }
            }
            return RedirectToAction("VTDVendorReg", "Contractor");
        }

        [SkipImportantTask]
        public JsonResult GetDistrictByStateId(int StateId)
        {
            return Json(vTDVendor.GetDistrictDetailsByStateId(new CommonAddressDetails { StateID = StateId }));
        }

        [SkipImportantTask]
        public JsonResult GetBlockByDistrictId(int DistrictId)
        {
            return Json(vTDVendor.GetBlockDetailsByDistrictId(new CommonAddressDetails { DistrictID = DistrictId }));
        }

        public IActionResult VTDAllRequest()
        {
            try
            {
                return View(vTDVendor.ViewVTDAllRequest(messageEF));
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [SkipEncryptedTask]
        public IActionResult VTDUserForceDataView(string id = "0")
        {
            try
            {
                return View(vTDVendor.GetVTDNewRequestDetails(new VTDVendorModel() { VTDVendorId = Convert.ToInt32(id), ApprovalLetter = null }));
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public IActionResult VTDUserForceDataView(VTDVendorModel vTDVendorModel, string approve, string reject)
        {
            if (!string.IsNullOrEmpty(approve))
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                vTDVendorModel.UserId = profile.UserId; //1;
                messageEF = vTDVendor.ApproveVTDUser(vTDVendorModel);
                int output = 0;
                output = int.Parse(messageEF.Msg);
                if (output >= 1)
                {
                    vTDVendorModel.UserId = output;
                    vTDVendorModel = vTDVendor.GetVTDUserDetailsByUserId(vTDVendorModel);
                    TempData["UserName"] = vTDVendorModel.UserName;
                    TempData["Password"] = vTDVendorModel.Password;
                    TempData["RegistrationNo"] = vTDVendorModel.RegistrationNo;
                    if (vTDVendorModel.UserName != null && vTDVendorModel.Password != null)
                    {
                        if (vTDVendorModel.UserName != "" && vTDVendorModel.Password != "")
                        {
                            #region Send SMS
                            try
                            {
                                string message = "VTD User Registration" + Environment.NewLine + Environment.NewLine + "You have successfully registered with Khanij Online Portal. Your Registration Number is " + vTDVendorModel.UserName + " Dated " + System.DateTime.Now + Environment.NewLine + Environment.NewLine +
                                                    "You can login into Khanij Online Portal using below login credential" + Environment.NewLine + Environment.NewLine +
                                                     "User Name : " + vTDVendorModel.UserName + Environment.NewLine + "Password : " + vTDVendorModel.Password + Environment.NewLine + Environment.NewLine +
                                                     "Please check your e-mail for details of registration";

                                string templateid = "1307161883515998678";
                                sMSModel.Main(new SMS() { mobileNo = vTDVendorModel.Contact_Person_MobileNo, message = message, templateid = templateid });

                            }
                            catch (Exception)
                            {

                            }
                            #endregion


                        }
                    }

                    ViewBag.AcknowledgementMessage = "1";
                    TempData["AcknowledgementMessage"] = "1";
                }
                else
                {
                    ViewBag.AcknowledgementMessage = "0";
                    TempData["AcknowledgementMessage"] = "0";
                }
            }

            if (!string.IsNullOrEmpty(reject))
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                vTDVendorModel.UserId = profile.UserId; //1;
                messageEF = vTDVendor.RejectVTDUser(vTDVendorModel);
                int output = 0;
                output = int.Parse(messageEF.Msg);
                if (output >= 1)
                {
                    vTDVendorModel.UserId = output;
                    vTDVendorModel = vTDVendor.GetVTDUserDetailsByUserId(vTDVendorModel);
                    TempData["UserCode"] = vTDVendorModel.UserName;
                    TempData["UserName"] = vTDVendorModel.UserName;
                    TempData["Password"] = vTDVendorModel.Password;
                    TempData["RegistrationNo"] = vTDVendorModel.RegistrationNo;
                    if (vTDVendorModel.UserName != null && vTDVendorModel.Password != null)
                    {
                        if (vTDVendorModel.UserName != "" && vTDVendorModel.Password != "")
                        {
                            #region Send SMS
                            try
                            {
                                string message = "";
                                message = "VTD User Registration, " + Environment.NewLine + Environment.NewLine + "Your End User registration in Khanij Online with Registration Number " + vTDVendorModel.RegistrationNo + " has been rejected by Directorate of Geology and Mining, Chhattisgarh.";
                                string templateid = "1307161883515998678";
                                sMSModel.Main(new SMS() { mobileNo = vTDVendorModel.Contact_Person_MobileNo, message = message, templateid = templateid });

                            }
                            catch (Exception)
                            {

                            }
                            #endregion

                        }
                    }

                    ViewBag.AcknowledgementMessage = "2";
                    TempData["AcknowledgementMessage"] = "2";
                }
                else
                {
                    ViewBag.AcknowledgementMessage = "0";
                    TempData["AcknowledgementMessage"] = "0";
                }


            }

            TempData.Keep("AcknowledgementMessage");
            TempData.Keep("RegistrationNo");
            return View("VTDUserForceDataView", vTDVendorModel);
        }

        public IActionResult VTDActionTakenRequest()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                return View(vTDVendor.VTDActionTakenRequest(new VTDVendorModel() { UserId = profile.UserId, ApprovalLetter = null }));
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [SkipEncryptedTask]
        public IActionResult VTDUserDataView(string id)
        {
            try
            {
                return View(vTDVendor.VTDUserDataView(new VTDVendorModel() { VTDVendorId = Convert.ToInt32(id), ApprovalLetter = null }));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region Tailing Dam Registration
        [SkipImportantTask]
        public IActionResult TailingDamRegistration()
        {
            ViewData["MainmenuTable"] = websiteMenuModel.GetMainmenulist();
            ViewData["FootermenuTable"] = websiteMenuModel.GetFootermenulist();
            //-------Company Details------------
            List<CompanyDetails> lstCompanyDetails = tailingDamModel.GetCompanyList(new CompanyDetails() { });
            ViewData["CompanyDetails"] = lstCompanyDetails;
            //-------------------------------
            //---------------District Details----------------
            List<CommonAddressDetails> lstDistrictDetails = tailingDamModel.GetStateDistrictList(new CommonAddressDetails() { });
            ViewData["DistrictDetails"] = lstDistrictDetails;
            //--------------------------------------------------
            //------------------Type Of Site Details-----------
            List<TypeOfSite> lstTypeOfSite = tailingDamModel.GetTypeOfSiteList(messageEF);
            ViewData["TypeOfSiteDetails"] = lstTypeOfSite;
            //------------------------------------------------------
            //-----------------Mineral Type--------------------------
            List<MineralType> lstMineralType = tailingDamModel.GetMineralTypeList_TailingDam(new MineralType() { });
            ViewData["MineralType"] = lstMineralType;
            //-------------------------------------------------------
            return View();
        }

        [SkipImportantTask]
        [HttpPost]
        public IActionResult TailingDamRegistration(cls_TailingDam tailingDam, string DistrictName)
        {
            string mymsg = "";
            try
            {
                //----added on 2-dec-2021 for password encrypt
                #region encryptPassword
                string s = EncryptDecryptSha256.ComputeSha256Hash("khanij@123").ToUpper();
                string s1 = EncryptDecryptSha256.ComputeSha256Hash(s).ToUpper();
                #endregion
                //-----end------

                string uniqueTailingDamUploadorderCopy = null;
                string fileTailingDamUploadorderCopyPath = null;

                #region Upload order Copy
                if (tailingDam.Tailing_SCAN_COPY != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload\\TailingDamDocument");
                    uniqueTailingDamUploadorderCopy = Guid.NewGuid().ToString() + "_" + tailingDam.Tailing_SCAN_COPY.FileName;
                    fileTailingDamUploadorderCopyPath = Path.Combine(uploadsFolder, uniqueTailingDamUploadorderCopy);
                    tailingDam.Tailing_SCAN_COPY.CopyTo(new FileStream(fileTailingDamUploadorderCopyPath, FileMode.Create));
                }
                #endregion

                tailingDam.Tailing_SCAN_COPY = null;
                tailingDam.TailingCopyPath = fileTailingDamUploadorderCopyPath;
                tailingDam.s1 = s1;
                messageEF = tailingDamModel.AddTailingDam(tailingDam);
                if (Convert.ToString(messageEF.Satus) != "2" && Convert.ToString(messageEF.Satus) != "0")
                {
                    mymsg = "You have successfully registered with Khanij Online Portal.";
                    TempData["Message"] = mymsg;

                    #region Send SMS
                    try
                    {
                        string message = "Dear " + tailingDam.OwnerName + "," + Environment.NewLine + Environment.NewLine + "Your application for Registration has been successfully forwarded to " + Convert.ToString(DistrictName) + " District Mining Office for Approval. " + Environment.NewLine +
                                            "Your Application No : " + Convert.ToString(messageEF.Satus) + " Dated " + System.DateTime.Now + Environment.NewLine + " CHiMMS, GoCG";
                        string templateid = "1307161883468436619";
                        sMSModel.Main(new SMS() { mobileNo = tailingDam.MobileNo, message = message, templateid = templateid });

                    }
                    catch (Exception ex)
                    {

                    }
                    #endregion

                    #region Send Mail
                    try
                    {
                        mailModel.SendTailingDamMail(new UserMasterModel()
                        {
                            EMailId = tailingDam.EmailID,
                            ApplicantName = tailingDam.OwnerName,
                            UserName = Convert.ToString(messageEF.Satus),
                            Password = "khanij@123",
                            UserCode = Convert.ToString(messageEF.Satus),
                            DistrictName = DistrictName
                        });
                    }
                    catch (Exception ex)
                    {

                    }
                    #endregion
                }
                else if (Convert.ToString(messageEF.Satus) == "2")
                {
                    mymsg = "Something went wrong. Please try again !";
                    TempData["Message"] = mymsg;
                }
                else if (Convert.ToString(messageEF.Satus) == "0")
                {
                    mymsg = "Record already existed with either owner name or mobile number or e-mail id.";
                    TempData["Message"] = mymsg;
                }
            }
            catch (Exception ex)
            {
                mymsg = "Something went wrong. Please try again !";
                TempData["Message"] = mymsg;
            }
            return RedirectToAction("TailingDamRegistration");
        }

        [SkipImportantTask]
        public JsonResult GetTehsilDataFromDistrictID(int? DistrictId)
        {
            try
            {
                if (DistrictId != null && DistrictId != 0)
                {
                    return Json(tailingDamModel.GetTehsilListByDistrictID(new CommonAddressDetails() { DistrictID = DistrictId }));
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception)
            {
                return Json(null);
            }
        }

        [SkipImportantTask]
        public JsonResult GetVillageDataFromTehsilID(int? TehsilId)
        {
            try
            {
                if (TehsilId != null && TehsilId != 0)
                {
                    return Json(tailingDamModel.GetvillageFromTehsilID(new CommonAddressDetails() { TehsilID = TehsilId }));
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception)
            {
                return Json(null);
            }
        }

        [SkipImportantTask]
        public JsonResult GetCascadeMineral(int? mineraltypeid)
        {
            try
            {
                if (mineraltypeid != null && mineraltypeid != 0)
                {
                    return Json(tailingDamModel.GetCascadeMineral(new MineralDetails() { MineralTypeId = mineraltypeid }));
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception)
            {
                return Json(null);
            }
        }

        [SkipImportantTask]
        public JsonResult GetCascadeMineralNature(int? mineral)
        {
            try
            {
                if (mineral != null && mineral != 0)
                {
                    return Json(tailingDamModel.GetCascadeMineralNature(new MineralDetails() { MineralID = mineral }));
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception)
            {
                return Json(null);
            }
        }

        [SkipImportantTask]
        public JsonResult GetCascadeMineralGrade(int? mineralNature)
        {
            try
            {
                if (mineralNature != null && mineralNature != 0)
                {
                    return Json(tailingDamModel.GetCascadeMineralGrade(new MineralDetails() { MineralNatureId = mineralNature }));
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception)
            {
                return Json(null);
            }
        }

        [SkipImportantTask]
        public JsonResult GetExistingUserDetails(string UserName, string Password)
        {
            try
            {
                if (UserName != null && Password != "")
                {
                    return Json(tailingDamModel.GetExistingUserDetails(new cls_TailingDam() { UserName = UserName, Password = Password }));
                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception)
            {
                return Json(null);
            }
        }
        #endregion

        #region Profile details
        public ActionResult Profile()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            cls_TailingDam objcls_TailingDam = new cls_TailingDam();
            try
            {
                objcls_TailingDam.UserId = profile.UserId;
                objcls_TailingDam = tailingDamModel.GetProfileDetails(objcls_TailingDam);
                ViewBag.Button = "Edit";
                return View(objcls_TailingDam);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objcls_TailingDam = null;
            }
        }
        [SkipEncryptedTask]
        public ActionResult EditProfile(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            cls_TailingDam objcls_TailingDam = new cls_TailingDam();
            try
            {
                if (id == "0")
                {
                    objcls_TailingDam.UserId = profile.UserId;
                }
                else
                {
                    objcls_TailingDam.UserId = Convert.ToInt32(id);
                }
                objcls_TailingDam = tailingDamModel.GetProfileDetails(objcls_TailingDam);
                //-------Company Details------------
                List<CompanyDetails> lstCompanyDetails = tailingDamModel.GetCompanyList(new CompanyDetails() { });
                ViewData["CompanyDetails"] = lstCompanyDetails;
                //-------------------------------
                //---------------District Details----------------
                List<CommonAddressDetails> lstDistrictDetails = tailingDamModel.GetStateDistrictList(new CommonAddressDetails() { });
                ViewData["DistrictDetails"] = lstDistrictDetails;
                //--------------------------------------------------
                //------------------Type Of Site Details-----------
                List<TypeOfSite> lstTypeOfSite = tailingDamModel.GetTypeOfSiteList(messageEF);
                ViewData["TypeOfSiteDetails"] = lstTypeOfSite;
                //------------------------------------------------------
                //-----------------Mineral Type--------------------------
                List<MineralType> lstMineralType = tailingDamModel.GetMineralTypeList_TailingDam(new MineralType() { });
                ViewData["MineralType"] = lstMineralType;
                //-------------------------------------------------------
                return View(objcls_TailingDam);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objcls_TailingDam = null;
            }
        }
        [HttpPost]
        public ActionResult EditProfile(cls_TailingDam tailingDam)
        {
            try
            {
                messageEF = tailingDamModel.UpdateTailingDam(tailingDam);
                TempData["Message"] = Convert.ToString(messageEF.Satus);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                tailingDam = null;
            }
            return RedirectToAction("Profile");
        }
        #endregion

        #region Tailing Dam Royalty Pay details
        [SkipEncryptedTask]
        public ActionResult RoyaltyPay()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            cls_TailingDam objcls_TailingDam = new cls_TailingDam();
            try
            {
                objcls_TailingDam.UserId = profile.UserId;
                objcls_TailingDam = tailingDamModel.GetProfileDetails(objcls_TailingDam);
                //-----------------Mineral Type--------------------------
                List<MineralType> lstMineralType = tailingDamModel.GetMineralTypeList_TailingDam(new MineralType() { });
                ViewData["MineralType"] = lstMineralType;
                //-------------------------------------------------------
                return View(objcls_TailingDam);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objcls_TailingDam = null;
            }
        }
        [HttpPost]
        public ActionResult RoyaltyPay(cls_TailingDam tailingDam)
        {
            string uniqueFileName = string.Empty;
            string filePath = string.Empty;
            string ExtensionId = string.Empty;
            try
            {
                #region Supporting document Copy
                if (tailingDam.SUPPORTING_DOCUMENT != null)
                {
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(tailingDam.SUPPORTING_DOCUMENT.FileName);
                    filePath = Path.Combine(configuration.GetSection("UploadPath").GetValue<string>("TailingdamPath"), uniqueFileName);
                    var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("UploadPath").GetValue<string>("TailingdamPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        tailingDam.SUPPORTING_DOCUMENT.CopyTo(fileStream);
                    tailingDam.SUPPORTING_DOCUMENTFILENAME = uniqueFileName;
                    tailingDam.SUPPORTING_DOCUMENTPath = filePath;
                    tailingDam.SUPPORTING_DOCUMENT = null;
                    uniqueFileName = null;
                    filePath = null;
                }
                #endregion
                messageEF = tailingDamModel.UpdateRoyaltyPay(tailingDam);
                TempData["Message"] = Convert.ToString(messageEF.Satus);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                tailingDam = null;
            }
            return RedirectToAction("RoyaltyPay");
        }
        public ActionResult RoyaltyPayProfile()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            cls_TailingDam objcls_TailingDam = new cls_TailingDam();
            try
            {
                objcls_TailingDam.UserId = profile.UserId;
                objcls_TailingDam = tailingDamModel.GetProfileDetails(objcls_TailingDam);
                ViewBag.Button = "Edit";
                return View(objcls_TailingDam);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objcls_TailingDam = null;
            }
        }

         #region DD Approve
        /// <summary>
        /// Get TailingDumpDDApprove
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public ActionResult ViewList(cls_TailingDam objmodel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            cls_TailingDam objcls_TailingDam = new cls_TailingDam();
            try
            {
                objcls_TailingDam.UserId = profile.UserId;
                objlistmodel = tailingDamModel.ViewTailingDumpDDApprove(objcls_TailingDam);
                return View(objlistmodel);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objcls_TailingDam = null;
                objlistmodel = null;
            }
        }
        /// <summary>
        /// Approve Tailing dam details by DD
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ViewList(cls_TailingDam objmodel, string Show1)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                objmodel.UserId = profile.UserId;
                messageEF = tailingDamModel.TailingDumpDDApprove(objmodel);
                TempData["Message"] = Convert.ToString(messageEF.Satus);
                return RedirectToAction("ViewList");
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        #endregion
        #endregion

        #region VTD Vendor Profile details
        /// <summary>
        /// View VTD Vendor Profile details in view
        /// </summary>
        /// <returns></returns>
        public ActionResult VTDVendorProfile()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                objVTDVendorProfileModel.UserName = profile.UserName;
                objVTDVendorProfileModel = vTDVendor.VTDUserProfileDataView(objVTDVendorProfileModel);
                ViewBag.Button = "Edit";
                return View(objVTDVendorProfileModel);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objVTDVendorProfileModel = null;
            }
        }
        /// <summary>
        /// Edit VTD Vendor Profile details
        /// </summary>
        /// <returns></returns>
        public ActionResult EditVTDVendorProfile()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                objVTDVendorProfileModel.UserName = profile.UserName;
                objVTDVendorProfileModel = vTDVendor.VTDUserProfileDataView(objVTDVendorProfileModel);
                ViewData["StateDetails"] = vTDVendor.GetStateDetails(new CommonAddressDetails { });
                if (TempData["SuccessMessage"] != null)
                {
                    ViewBag.SuccessMessage = TempData["SuccessMessage"];
                }
                return View(objVTDVendorProfileModel);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objVTDVendorProfileModel = null;
            }
        }
        [HttpPost]
        public ActionResult EditVTDVendorProfile(VTDVendorProfileModel objVTDVendorProfileModel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                objVTDVendorProfileModel.UserId = profile.UserId;
                objVTDVendorProfileModel.UserLoginId = profile.UserLoginId;
                messageEF = vTDVendor.UpdateVTDVendor(objVTDVendorProfileModel);
                int Outputres = Convert.ToInt32(messageEF.Satus);
                if (Outputres > 0 && Outputres==1)
                {
                    TempData["Message"] = "Profile Updated Successfully";
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                objVTDVendorProfileModel = null;
            }
            return RedirectToAction("VTDVendorProfile");
        }
        #endregion
    }
}
