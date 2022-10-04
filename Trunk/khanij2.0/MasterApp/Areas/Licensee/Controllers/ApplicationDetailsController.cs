// ***********************************************************************
//  Controller Name          : ApplicationDetails
//  Desciption               : Liecensee Grant Order Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 01 July 2021
// ***********************************************************************
using MasterApp.ActionFilter;
using MasterApp.Areas.Licensee.Models;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Licensee.Controllers
{
    [Area("Licensee")]
    public class ApplicationDetailsController : Controller
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        IUserInformationLicenseeModel _userInformation;
        MessageEF objMsgmodel = new MessageEF();
        List<ApplicationDetails> objlistmodel = new List<ApplicationDetails>();
        ApplicationDetails objAppliacationDetails = new ApplicationDetails();
        LicenseeResult objlicenseeResult = new LicenseeResult();
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor Dependency Injection
        /// </summary>
        /// <param name="userInformationLicenseeModel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        public ApplicationDetailsController(IUserInformationLicenseeModel userInformationLicenseeModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _userInformation = userInformationLicenseeModel;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;

        }
        public async Task<IActionResult> Create()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                
                objAppliacationDetails.UserID = profile.UserId;
                objAppliacationDetails.CREATED_BY = profile.UserId;
                //ViewBag.MineralCategory = await GetMineralCategoryDetails(null);
                ViewBag.Mineralunits = await GetUnitTypesList();
                ViewBag.Licenesetype = await GetLicenseeTypesList();
                objlicenseeResult = await _userInformation.GetLicenseeApplicationDetails(objAppliacationDetails);

                if (objlicenseeResult.ApplicationDetailsList != null)
                {
                    return View(objlicenseeResult.ApplicationDetailsList.FirstOrDefault());
                }
                else
                {
                    return View(new ApplicationDetails());
                }
                //return View(new ApplicationDetails());
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objlicenseeResult = null;
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationDetails applicationDetails, string cmd, string delete)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            applicationDetails.CREATED_BY = profile.UserId;
            applicationDetails.UserID = profile.UserId;
            ExtensionId = Convert.ToString(applicationDetails.CREATED_BY);
            #region Servrside Validation
            #endregion

            if (ModelState.IsValid)
            {
                #region Licensee Infromation Upload
                if (applicationDetails.APPLICATION_FORM_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.APPLICATION_FORM_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("AppFormPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("AppFormPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.APPLICATION_FORM_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_APPLICATION_FORM_COPY = uniqueFileName;
                    applicationDetails.APPLICATION_FORM_COPY_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.PAN_CARD_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.PAN_CARD_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("PanCardPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("PanCardPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.PAN_CARD_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_PAN_CARD = uniqueFileName;
                    applicationDetails.PAN_CARD_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.ADHAR_CARD_SCAN_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.ADHAR_CARD_SCAN_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("AadharCardPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("AadharCardPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.ADHAR_CARD_SCAN_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_ADHAR_CARD = uniqueFileName;
                    applicationDetails.ADHAR_CARD_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.TIN_CARD_SCAN_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.TIN_CARD_SCAN_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("TincardPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("TincardPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.TIN_CARD_SCAN_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_TIN_CARD = uniqueFileName;
                    applicationDetails.TIN_CARD_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.FIRM_REGISTRATION_DEED != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.FIRM_REGISTRATION_DEED.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("FirmRegnPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("FirmRegnPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.FIRM_REGISTRATION_DEED.CopyTo(fileStream);
                    applicationDetails.FILE_FIRM_REGISTRATION_DEED = uniqueFileName;
                    applicationDetails.FIRM_REGISTRATION_DEED_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.CERTIFICATE_OF_INCORPORATION_DOC != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.CERTIFICATE_OF_INCORPORATION_DOC.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("IncorpPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("IncorpPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.CERTIFICATE_OF_INCORPORATION_DOC.CopyTo(fileStream);
                    applicationDetails.FILE_CERTIFICATE_OF_INCORPORATION = uniqueFileName;
                    applicationDetails.CERTIFICATE_OF_INCORPORATION_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }

                applicationDetails.APPLICATION_FORM_COPY = null;
                applicationDetails.PAN_CARD_COPY = null;
                applicationDetails.ADHAR_CARD_SCAN_COPY = null;
                applicationDetails.TIN_CARD_SCAN_COPY = null;
                applicationDetails.FIRM_REGISTRATION_DEED = null;
                applicationDetails.CERTIFICATE_OF_INCORPORATION_DOC = null;
                #endregion
                #region  Attachments Upload
                if (applicationDetails.POWER_OF_ATORNY_PATH_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.POWER_OF_ATORNY_PATH_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("PowerofAtornyPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("PowerofAtornyPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.POWER_OF_ATORNY_PATH_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_POWER_OF_ATORNY = uniqueFileName;
                    applicationDetails.POWER_OF_ATORNY_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.AFFIDAVITS_MINING_DUE_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.AFFIDAVITS_MINING_DUE_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("MiningDueCertificatePath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("MiningDueCertificatePath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.AFFIDAVITS_MINING_DUE_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_AFFIDAVITS_MINING_DUE = uniqueFileName;
                    applicationDetails.AFFIDAVITS_MINING_DUE_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.KHASARA_PANCHSALA_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.KHASARA_PANCHSALA_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("KhasraPanchsalaPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("KhasraPanchsalaPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.KHASARA_PANCHSALA_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_KHASARA_PANCHSALA = uniqueFileName;
                    applicationDetails.KHASARA_PANCHSALA_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.MAP_PLAN_OF_APPLIED_AREA_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.MAP_PLAN_OF_APPLIED_AREA_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("MapPlanPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("MapPlanPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.MAP_PLAN_OF_APPLIED_AREA_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_MAP_PLAN_OF_APPLIED_AREA = uniqueFileName;
                    applicationDetails.MAP_PLAN_OF_APPLIED_AREA_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.FOREST_REPORT_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.FOREST_REPORT_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("ForestReportPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("ForestReportPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.FOREST_REPORT_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_FOREST_REPORT = uniqueFileName;
                    applicationDetails.FOREST_REPORT_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.REVENUE_OFFICER_REPORT_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.REVENUE_OFFICER_REPORT_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("RevOffcPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("RevOffcPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.REVENUE_OFFICER_REPORT_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_REVENUE_OFFICER_REPORT = uniqueFileName;
                    applicationDetails.REVENUE_OFFICER_REPORT_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.SPOT_INSPECTION_AND_ANALYSIS_REPORT_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.SPOT_INSPECTION_AND_ANALYSIS_REPORT_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("SpotInspectionPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("SpotInspectionPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.SPOT_INSPECTION_AND_ANALYSIS_REPORT_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_SPOT_INSPECTION_AND_ANALYSIS_REPORT = uniqueFileName;
                    applicationDetails.SPOT_INSPECTION_AND_ANALYSIS_REPORT_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.MINING_INSPECTOR_REPORT_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.MINING_INSPECTOR_REPORT_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("MiningReportPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("MiningReportPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.MINING_INSPECTOR_REPORT_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_MININIG_INSPECTOR_REPORT = uniqueFileName;
                    applicationDetails.MINING_INSPECTOR_REPORT_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.GRAM_PANCHAYAT_PROPOSAL_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.GRAM_PANCHAYAT_PROPOSAL_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("GPProposalPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("GPProposalPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.GRAM_PANCHAYAT_PROPOSAL_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_GRAM_PANCHAYAT_PROPOSAL = uniqueFileName;
                    applicationDetails.GRAM_PANCHAYAT_PROPOSAL_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }

                applicationDetails.POWER_OF_ATORNY_PATH_COPY = null;
                applicationDetails.AFFIDAVITS_MINING_DUE_COPY = null;
                applicationDetails.KHASARA_PANCHSALA_COPY = null;
                applicationDetails.MAP_PLAN_OF_APPLIED_AREA_COPY = null;
                applicationDetails.FOREST_REPORT_COPY = null;
                applicationDetails.REVENUE_OFFICER_REPORT_COPY = null;
                applicationDetails.SPOT_INSPECTION_AND_ANALYSIS_REPORT_COPY = null;
                applicationDetails.MINING_INSPECTOR_REPORT_COPY = null;
                applicationDetails.GRAM_PANCHAYAT_PROPOSAL_COPY = null;
                #endregion
                #region Fees Details Upload
                if (applicationDetails.APPLICATION_FEES_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.APPLICATION_FEES_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("ApplicationFeesCopyPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("ApplicationFeesCopyPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.APPLICATION_FEES_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_APPLICATION_FEES_CHALLAN = uniqueFileName;
                    applicationDetails.APPLICATION_FEES_CHALLAN_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.CHALLAN_DD_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.CHALLAN_DD_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("ApplicationChallanPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("ApplicationChallanPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.CHALLAN_DD_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_CHALLAN_DD = uniqueFileName;
                    applicationDetails.CHALLAN_DD_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.BANK_GUARRANTEE_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.BANK_GUARRANTEE_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("BankGuaranteePath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("BankGuaranteePath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.BANK_GUARRANTEE_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_BANK_GUARRANTEE = uniqueFileName;
                    applicationDetails.BANK_GUARRANTEE_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.SURETY_BOND_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.SURETY_BOND_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("SuretyBondCopyPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("SuretyBondCopyPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.SURETY_BOND_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_SURETY_BOND = uniqueFileName;
                    applicationDetails.SURETY_BOND_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("FixedIncomeSchemePath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("FixedIncomeSchemePath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_COPY.CopyTo(fileStream);
                    applicationDetails.FILE_FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE = uniqueFileName;
                    applicationDetails.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }

                applicationDetails.APPLICATION_FEES_COPY = null;
                applicationDetails.CHALLAN_DD_COPY = null;
                applicationDetails.BANK_GUARRANTEE_COPY = null;
                applicationDetails.SURETY_BOND_COPY = null;
                applicationDetails.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_COPY = null;
                #endregion
                #region Renewal Uploads
                if (applicationDetails.Renewal_GrantOrder_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.Renewal_GrantOrder_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("RenewalGrantCopy"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("RenewalGrantCopy"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.Renewal_GrantOrder_COPY.CopyTo(fileStream);
                    applicationDetails.Renewal_GrantOrderCopy_File = uniqueFileName;
                    applicationDetails.Renewal_GrantOrderCopy_Path = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }

                applicationDetails.Renewal_GrantOrder_COPY = null;
                #endregion
                #region Transfer Uploads
                if (applicationDetails.Transfer_GrantOrder_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.Transfer_GrantOrder_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("TransferGranOrderPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("TransferGranOrderPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.Transfer_GrantOrder_COPY.CopyTo(fileStream);
                    applicationDetails.Transfer_GrantOrderCopy_File = uniqueFileName;
                    applicationDetails.Transfer_GrantOrderCopy_Path = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (applicationDetails.Transfer_LeaseDeed_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(applicationDetails.Transfer_LeaseDeed_COPY.FileName);
                    filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("TransferLeaseDeedPath"), uniqueFileName);
                    var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("TransferLeaseDeedPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        applicationDetails.Transfer_LeaseDeed_COPY.CopyTo(fileStream);
                    applicationDetails.Transfer_LeaseDeedCopy_File = uniqueFileName;
                    applicationDetails.Transfer_LeaseDeedCopy_Path = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                applicationDetails.Transfer_GrantOrder_COPY = null;
                applicationDetails.Transfer_LeaseDeed_COPY = null;
                #endregion

                var checkDMO = "Forward To DD";
                if (applicationDetails.SubResion == "Forward To DD")
                {
                    cmd = "Forward To DD";
                }
                if (checkDMO == cmd)
                {
                    applicationDetails.STATUS = 1;
                    objMsgmodel = _userInformation.UpdateLicenseeApplicationDetails(applicationDetails);
                    if (objMsgmodel.Satus == "1")
                    {
                        TempData["msg"] = "Licensee Application Details forwarded to DD/DMO successfully";
                    }
                    else if (objMsgmodel.Satus == "2")
                    {
                        TempData["msg"] = "Licensee Application Details forwarded to DD/DMO successfully";
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while forwarding Licensee Application Details to DD/DMO";
                    }
                }
                else if (delete == "Delete")
                {
                    objMsgmodel = _userInformation.DeleteLicenseeApplicationDetails(applicationDetails);
                    if (objMsgmodel.Satus == "1")
                    {
                        TempData["Message"] = "Licensee Application Details Deleted Sucessfully.";
                    }
                    else
                    {
                        TempData["Message"] = "Licensee Application Details not Deleted Sucessfully.";
                    }
                }
                else
                {
                    applicationDetails.STATUS = 0;
                    objMsgmodel = _userInformation.UpdateLicenseeApplicationDetails(applicationDetails);
                    if (objMsgmodel.Satus == "1")
                    {
                        TempData["msg"] = "Licensee Application Details Saved successfully";
                    }
                    else if (objMsgmodel.Satus == "2")
                    {
                        TempData["msg"] = "Licensee Application Details updated successfully";
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Updating Licensee Application Details";
                    }
                }
                return RedirectToAction("Create", "ApplicationDetails", new { Area = "Licensee" });
            }
            else
            {
                return View(new ApplicationDetails());
            }
        }

        public async Task<IActionResult> ViewList(ApplicationDetails applicationDetails)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                applicationDetails.CREATED_BY = profile.UserId;
                applicationDetails.UserID = profile.UserId;
                LicenseeResult listobj =await _userInformation.GetLicenseeApplicationDetails(applicationDetails);
                if(listobj.ApplicationDetailsList !=null)
                {
                    ViewBag.tableLA = LesseeInformationTable(applicationDetails.CREATED_BY);
                    ViewBag.tableLB = LesseeAttachmentsInformationTable(applicationDetails.CREATED_BY);
                    ViewBag.tableLC = LesseeFeesInformationTable(applicationDetails.CREATED_BY);
                    ViewBag.tableLD = LesseeTransferInformationTable(applicationDetails.CREATED_BY);
                    ViewBag.tableLE = LesseePurpose(applicationDetails.CREATED_BY);
                    return View(listobj.ApplicationDetailsList.FirstOrDefault());
                }
                else
                {
                    return View(new ApplicationDetails());
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //objmodel = null;
            }
        }
        [HttpGet, Decryption]
        public IActionResult CompareApplicationDetails(string id="0" )
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    objAppliacationDetails.UserID = Convert.ToInt32(id);
                    objAppliacationDetails.CREATED_BY = Convert.ToInt32(id);
                    objlistmodel = _userInformation.CompareLicenseeApplicationDetails(objAppliacationDetails);
                    return View(objlistmodel);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlistmodel = null;
                objAppliacationDetails = null;
            }
          
        }
        [HttpPost]
        public IActionResult CompareApplicationDetails(ApplicationDetails applicationDetails)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                applicationDetails.UserID = profile.UserId;
                if (applicationDetails.SubApprove == "Approve")
                {
                    objMsgmodel = _userInformation.ApproveLicenseeApplicationDetails(applicationDetails);
                }
                else
                {
                    objMsgmodel = _userInformation.RejectLicenseeApplicationDetails(applicationDetails);
                }
                if (objMsgmodel.Satus == "1")
                {
                    TempData["msg"] = "Licensee Application Details Approved successfully";
                }
                else if (objMsgmodel.Satus == "2")
                {
                    TempData["msg"] = "Licensee Application Details Rejected successfully";
                }
                else
                {
                    TempData["msg"] = "Error ! while Updating Licensee Application Details";
                }
                // return RedirectToAction("CompareApplicationDetails", "ApplicationDetails", new { Area = "Licensee" });
                string EncryptUrl = CustomQueryStringHelper.EncryptString("Licensee", "CompareApplicationDetails", "ApplicationDetails", new { id = applicationDetails.CREATED_BY });
                return LocalRedirect(EncryptUrl);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                applicationDetails = null;
                objMsgmodel = null;
            }
        }
        /// <summary>
        /// To bind Lessee Information tab log details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseeInformationTable(int? Created_By)
        {
            try
            {
                string div = "";
                objAppliacationDetails.CREATED_BY = Created_By;
                objlistmodel = _userInformation.GetLicenseeApplicationLogDetails(objAppliacationDetails);
                foreach (var item in objlistmodel)
                {
                    div = div + "<li class='timeline-item'>";
                    div = div + "<div class='date-box'>";
                    div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                    div = div + "</div>";
                    if (item.STATUS == 2)
                    {
                        div = div + "<div class='message-highlighter approved'>";
                    }
                    else
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }
                    div = div + "<div class='row'>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Type</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.STORAGE_CAPACITY + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Type</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.UnitName + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Application No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.APPLICATION_NUMBER + "</label>";
                    if (item.FILE_APPLICATION_FORM_COPY != null && item.FILE_APPLICATION_FORM_COPY != "")
                    {
                        div = div + "<label class='form-control-plaintext'><a href='" + @Url.Content("~/" + item.APPLICATION_FORM_COPY_PATH) + "' class='ml-2' data-original-title='Download Application Number Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                   
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>PAN Card No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.PAN_CARD_NO + "";
                    if (item.FILE_PAN_CARD != null && item.FILE_PAN_CARD != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.PAN_CARD_PATH) + "' class='ml-2' data-original-title='Download PAN Card Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Adhar Card No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.ADHAR_CARD_NO + "";
                    if (item.FILE_ADHAR_CARD != null && item.FILE_ADHAR_CARD != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.ADHAR_CARD_PATH) + "' class='ml-2' data-original-title='Download Aadhar Card Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Tin Card No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.TIN_CARD_NO + "";
                    if (item.FILE_TIN_CARD != null && item.FILE_TIN_CARD != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.TIN_CARD_PATH) + "' class='ml-2' data-original-title='Download Tin Card Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Firm Registration Deed No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.FIRM_REGISTRATION_DEED_NO + "";
                    if (item.FILE_FIRM_REGISTRATION_DEED != null && item.FILE_FIRM_REGISTRATION_DEED != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.FIRM_REGISTRATION_DEED_PATH) + "' class='ml-2' data-original-title='Download Firm Registration Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Incorporation Certification No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.CERTIFICATE_OF_INCORPORATION_NO + "";
                    if (item.FILE_CERTIFICATE_OF_INCORPORATION != null && item.FILE_CERTIFICATE_OF_INCORPORATION != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.CERTIFICATE_OF_INCORPORATION_PATH) + "' class='ml-2' data-original-title='Download Incorporation Certification Document' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Licensee Type</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.APPLICATION_TYPE_NAME + "</label>";
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
                return div;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlistmodel = null;
            }
        }
        /// <summary>
        /// To bind Lessee Attachments Information tab log details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseeAttachmentsInformationTable(int? Created_By)
        {
            try
            {
                string div = "";
                objAppliacationDetails.CREATED_BY = Created_By;
                objlistmodel = _userInformation.GetLicenseeApplicationLogDetails(objAppliacationDetails);
                foreach (var item in objlistmodel)
                {
                    div = div + "<li class='timeline-item'>";
                    div = div + "<div class='date-box'>";
                    div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                    div = div + "</div>";
                    if (item.STATUS == 2)
                    {
                        div = div + "<div class='message-highlighter approved'>";
                    }
                    else
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }
                    div = div + "<div class='row'>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Power of Attorney</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.POWER_OF_ATORNY_PATH_COPY + "";
                    if (item.FILE_POWER_OF_ATORNY != null && item.FILE_POWER_OF_ATORNY != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.POWER_OF_ATORNY_PATH) + "' class='ml-2' data-original-title='Download Power of Attorney Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Affidavits/Mining Due Certificate</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.AFFIDAVITS_MINING_DUE_COPY + "";
                    if (item.FILE_AFFIDAVITS_MINING_DUE != null && item.FILE_AFFIDAVITS_MINING_DUE != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.AFFIDAVITS_MINING_DUE_PATH) + "' class='ml-2' data-original-title='Download Affidavits/Mining Due Certificate Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Khasara Panchsala</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.KHASARA_PANCHSALA_COPY + "";
                    if (item.FILE_KHASARA_PANCHSALA != null && item.FILE_KHASARA_PANCHSALA != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.KHASARA_PANCHSALA_PATH) + "' class='ml-2' data-original-title='Download Khasara Panchsala Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Map/Plan of applied area</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.MAP_PLAN_OF_APPLIED_AREA_COPY + "";
                    if (item.FILE_MAP_PLAN_OF_APPLIED_AREA != null && item.FILE_MAP_PLAN_OF_APPLIED_AREA != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.MAP_PLAN_OF_APPLIED_AREA_PATH) + "' class='ml-2' data-original-title='Download Map/Plan of applied area Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Forest Report</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.FOREST_REPORT_COPY + "";
                    if (item.FILE_FOREST_REPORT != null && item.FILE_FOREST_REPORT != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.FOREST_REPORT_PATH) + "' class='ml-2' data-original-title='Download Forest Report Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Revenue Officer Report</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.REVENUE_OFFICER_REPORT_COPY + "";
                    if (item.FILE_REVENUE_OFFICER_REPORT != null && item.FILE_REVENUE_OFFICER_REPORT != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.REVENUE_OFFICER_REPORT_PATH) + "' class='ml-2' data-original-title='Download Revenue Officer Report Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Spot Inspection and Analysis Report</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.SPOT_INSPECTION_AND_ANALYSIS_REPORT_COPY + "";
                    if (item.FILE_SPOT_INSPECTION_AND_ANALYSIS_REPORT != null && item.FILE_SPOT_INSPECTION_AND_ANALYSIS_REPORT != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.FILE_SPOT_INSPECTION_AND_ANALYSIS_REPORT) + "' class='ml-2' data-original-title='Download Spot Inspection and Analysis Report Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mining Inspector Report</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.MINING_INSPECTOR_REPORT_COPY + "";
                    if (item.FILE_MININIG_INSPECTOR_REPORT != null && item.FILE_MININIG_INSPECTOR_REPORT != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.MINING_INSPECTOR_REPORT_PATH) + "' class='ml-2' data-original-title='Download Mining Inspector Report Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Gram Panchayat Proposal</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.GRAM_PANCHAYAT_PROPOSAL_COPY + "";
                    if (item.FILE_GRAM_PANCHAYAT_PROPOSAL != null && item.FILE_GRAM_PANCHAYAT_PROPOSAL != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.GRAM_PANCHAYAT_PROPOSAL_PATH) + "' class='ml-2' data-original-title='Download Gram Panchayat Proposal Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
                return div;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlistmodel = null;
            }
        }
        /// <summary>
        /// To bind Lessee Fees Information tab log details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseeFeesInformationTable(int? Created_By)
        {
            try
            {
                string div = "";
                objAppliacationDetails.CREATED_BY = Created_By;
                objlistmodel = _userInformation.GetLicenseeApplicationLogDetails(objAppliacationDetails);
                foreach (var item in objlistmodel)
                {
                    div = div + "<li class='timeline-item'>";
                    div = div + "<div class='date-box'>";
                    div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                    div = div + "</div>";
                    if (item.STATUS == 2)
                    {
                        div = div + "<div class='message-highlighter approved'>";
                    }
                    else
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }
                    div = div + "<div class='row'>";
                    
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Application Fees (in <i class='fas fa-rupee-sign'></i>)</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.APPLICATION_FEES + "";
                    if (item.FILE_APPLICATION_FEES_CHALLAN != null && item.FILE_APPLICATION_FEES_CHALLAN != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.APPLICATION_FEES_CHALLAN_PATH) + "' class='ml-2' data-original-title='Download Application Fees Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Application Fees Date</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.APPLICATION_FEES_DATE + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Security Deposit Challan/DD Amount (in <i class='fas fa-rupee-sign'></i>)</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.CHALLAN_DD_AMOUNT + "";
                    if (item.FILE_CHALLAN_DD != null && item.FILE_CHALLAN_DD != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.CHALLAN_DD_PATH) + "' class='ml-2' data-original-title='Download Security Deposit Challan/DD Amount Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Security Deposit Challan/DD Date</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.CHALLAN_DD_DATE + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Bank Guarrantee Amount (in <i class='fas fa-rupee-sign'></i>)</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.BANK_GUARRANTEE_AMOUNT + "";
                    if (item.FILE_BANK_GUARRANTEE != null && item.FILE_BANK_GUARRANTEE != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.BANK_GUARRANTEE_PATH) + "' class='ml-2' data-original-title='Download Bank Guarrantee Amount Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Bank Guarranty Date</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.BANK_GUARRANTEE_DATE + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Surety Bond Amount (in <i class='fas fa-rupee-sign'></i>)</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.SURETY_BOND_AMOUNT + "";
                    if (item.FILE_SURETY_BOND != null && item.FILE_SURETY_BOND != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.SURETY_BOND_PATH) + "' class='ml-2' data-original-title='Download Surety Bond Amount Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div += "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Surety Bond Amount Date</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.SURETY_BOND_DATE + "</label>";
                    div = div + "</div>";
                   
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Fixed Deposits Monthly Income Scheme Certificate</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.FILE_FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE + "";
                    if (item.FILE_FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE != null && item.FILE_FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_PATH) + "' class='ml-2' data-original-title='Download Fixed Deposits Monthly Income Scheme Certificate Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
                return div;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlistmodel = null;
            }
        }
        /// <summary>
        /// To bid Lessee Transfer Information tab log details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseeTransferInformationTable(int? Created_By)
        {
            try
            {
                string div = "";
                objAppliacationDetails.CREATED_BY = Created_By;
                objlistmodel = _userInformation.GetLicenseeApplicationLogDetails(objAppliacationDetails);
                foreach (var item in objlistmodel)
                {
                    div = div + "<li class='timeline-item'>";
                    div = div + "<div class='date-box'>";
                    div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                    div = div + "</div>";
                    if (item.STATUS == 2)
                    {
                        div = div + "<div class='message-highlighter approved'>";
                    }
                    else
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }
                    div = div + "<div class='row'>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Transferee Name</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.NameOfTransferee + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Transferee Address</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.AddressOfTransferee + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Transfer Grant Order Copy</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.Transfer_GrantOrderCopy_File + "";
                    if (item.Transfer_GrantOrderCopy_File != null && item.Transfer_GrantOrderCopy_File != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.Transfer_GrantOrderCopy_Path) + "' class='ml-2' data-original-title='Download Transfer Grant Order Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Transfer Lease Deed Copy</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.Transfer_LeaseDeedCopy_File + "";
                    if (item.Transfer_LeaseDeedCopy_File != null && item.Transfer_LeaseDeedCopy_File != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.Transfer_LeaseDeedCopy_Path) + "' class='ml-2' data-original-title='Download Transfer Lease Deed Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Transfer Date</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.DateOfTransfer + "</label>";
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
                return div;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlistmodel = null;
            }
        }
        /// <summary>
        /// To bid Lessee Purpose tab log details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseePurpose(int? Created_By)
        {
            try
            {
                string div = "";
                objAppliacationDetails.CREATED_BY = Created_By;
                objlistmodel = _userInformation.GetLicenseeApplicationLogDetails(objAppliacationDetails);
                foreach (var item in objlistmodel)
                {
                    div = div + "<li class='timeline-item'>";
                    div = div + "<div class='date-box'>";
                    div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                    div = div + "</div>";
                    if (item.STATUS == 2)
                    {
                        div = div + "<div class='message-highlighter approved'>";
                    }
                    else
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }
                    div = div + "<div class='row'>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Date Of Renewal</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.DateOfRenewal + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Renewal Grant Order Copy</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.Renewal_GrantOrderCopy_File + "";
                    if (item.Renewal_GrantOrderCopy_File != null && item.Renewal_GrantOrderCopy_File != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.Renewal_GrantOrderCopy_Path) + "' class='ml-2' data-original-title='Download Bank Guarrantee Amount Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Period Of Renewal From</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.PeriodOfRenewalFrom + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Period Of Renewal To</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.PeriodOfRenewalTo + "</label>";
                    div = div + "</div>";
                   
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
                return div;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlistmodel = null;
            }
        }
        #region Binddropdowns
        private async Task<SelectList> GetUnitTypesList()
        {
            try
            {
                objlicenseeResult = await _userInformation.MineralUnits(objAppliacationDetails);
                if (objlicenseeResult.ApplicationDetailsList != null)
                {
                    return new SelectList(objlicenseeResult.ApplicationDetailsList, "UnitId", "UnitName");
                }
                else
                {
                    return new SelectList(null, "", "");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<SelectList> GetLicenseeTypesList()
        {
            try
            {
                objlicenseeResult = await _userInformation.GetLicenseeType(objAppliacationDetails);
                if (objlicenseeResult.ApplicationDetailsList != null)
                {
                    return new SelectList(objlicenseeResult.ApplicationDetailsList, "APPLICATION_TYPE_ID", "APPLICATION_TYPE_NAME");
                }
                else
                {
                    return new SelectList(null, "", "");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
