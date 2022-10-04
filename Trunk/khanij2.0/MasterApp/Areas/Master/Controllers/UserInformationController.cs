using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MasterApp.Areas.Master.Models.UserInformation;
using MasterEF;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class UserInformationController : Controller
    {
        IUserInformationModel _userInformation;
        MessageEF objMSmodel = new MessageEF();
        public object JsonRequestBehavior { get; private set; }
        IHostingEnvironment _hostingEnvironment;

        public UserInformationController(IUserInformationModel objUserInformation, IHostingEnvironment hostingEnvironment)
        {
            _userInformation = objUserInformation;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult LesseeDetails(int id = 0)
        {
            UserInformationEF objmodel = new UserInformationEF();
            ApplicationResult objAppl = new ApplicationResult(); 
            objmodel.UserID = 58;
            objmodel.btnId = 1;
            if (id != 0)
            {

                return View();
            }
            else
            {
                objmodel.UserID = 58;
                //ViewBag.ViewUserList=  _objNoticeModel.ViewUserType(objmodel);
                var x = _userInformation.LeaseTypeView(objmodel);
                if (x.LesseeLst != null)
                {
                    ViewBag.ViewUserList = x.LesseeLst.Select(c => new SelectListItem
                    {
                        Text = c.APPLICATION_TYPE_Name,
                        Value = c.APPLICATION_TYPE_ID.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewUserList = Enumerable.Empty<SelectListItem>();
                }
                //Fill Auction type list
                var y = _userInformation.GetAuctionIDList(objmodel);
                if (y.LesseeLst != null)
                {
                    ViewBag.ViewAuctionList = y.LesseeLst.Select(c => new SelectListItem
                    {
                        Text = c.AuctionName,
                        Value = c.AuctionTypeId.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewAuctionList = Enumerable.Empty<SelectListItem>();
                }
                objAppl = _userInformation.GetApplicationData(objmodel);

                List<ApplicationResult> List = new List<ApplicationResult>();

                if (objAppl != null)
                {
                    foreach (var app in objAppl.ApplicationLst)
                    {
                        objmodel.APPLICATION_ID = Convert.ToInt32(app.APPLICATION_ID);
                        objmodel.APPLICATION_TYPE_ID = Convert.ToInt32(app.APPLICATION_TYPE_ID);
                        objmodel.APPLICATION_NUMBER = Convert.ToString(app.APPLICATION_NUMBER);
                        objmodel.APPLICATION_FORM_FILE_NAME = Convert.ToString(app.APPLICATION_FORM_COPY_FILE_NAME);
                        objmodel.APPLICATION_FORM_FILE_PATH = Convert.ToString(app.APPLICATION_FORM_COPY_FILE_PATH);

                        objmodel.RECONNAISSANCE_LICENSE_NAME = Convert.ToString(app.RECONNAISSANCE_LICENSE_NAME);

                        objmodel.RECONNAISSANCE_LICENSE_ADDRESS = Convert.ToString(app.RECONNAISSANCE_LICENSE_ADDRESS);

                        objmodel.PROSPECTING_VALIDITY_FROM = Convert.ToDateTime(app.PROSPECTING_VALIDITY_FROM);

                        objmodel.PROSPECTING_VALIDITY_TO = Convert.ToDateTime(app.PROSPECTING_VALIDITY_TO);

                        objmodel.PAN_CARD_NO = Convert.ToString(app.PAN_CARD_NO);

                        objmodel.PAN_CARD_COPY_FILE_NAME = Convert.ToString(app.PAN_CARD_COPY_FILE_NAME);

                        objmodel.PAN_CARD_COPY_FILE_PATH = Convert.ToString(app.PAN_CARD_COPY_FILE_PATH);

                        objmodel.ADHAR_CARD = Convert.ToString(app.ADHAR_CARD);

                        objmodel.ADHAR_CARD_SCAN_COPY_FILE_NAME = Convert.ToString(app.ADHAR_CARD_SCAN_COPY_FILE_NAME);

                        objmodel.ADHAR_CARD_SCAN_COPY_FILE_PATH = Convert.ToString(app.ADHAR_CARD_SCAN_COPY_FILE_PATH);

                        objmodel.MINE_CODE = Convert.ToString(app.MINE_CODE);

                        objmodel.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_NAME = Convert.ToString(app.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_NAME);

                        objmodel.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_PATH = Convert.ToString(app.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_PATH);

                        objmodel.AuctionTypeId = Convert.ToInt32(app.AuctionApplicationTypeID);
                        objmodel.AuctionName = Convert.ToString(app.AuctionApplicationTypeName);
                        objmodel.MonthlyPeriodicAmt = Convert.ToString(app.MonthlyPeriodicAmount);

                        objmodel.POWER_OF_ATORNY_FILE_NAME = Convert.ToString(app.POWER_OF_ATORNY_FILE_NAME);

                        objmodel.POWER_OF_ATORNY_FILE_PATH = Convert.ToString(app.POWER_OF_ATORNY_FILE_PATH);

                        objmodel.MAP_PLAN_OF_APPLIED_AREA_FILE_NAME = Convert.ToString(app.MAP_PLAN_OF_APPLIED_AREA_FILE_NAME);

                        objmodel.MAP_PLAN_OF_APPLIED_AREA_FILE_PATH = Convert.ToString(app.MAP_PLAN_OF_APPLIED_AREA_FILE_PATH);

                        objmodel.KHASARA_PANCHSALA_FILE_NAME = Convert.ToString(app.KHASARA_PANCHSALA_FILE_NAME);

                        objmodel.KHASARA_PANCHSALA_FILE_PATH = Convert.ToString(app.KHASARA_PANCHSALA_FILE_PATH);

                        objmodel.REVENUE_OFFICER_REPORT_FILE_NAME = Convert.ToString(app.REVENUE_OFFICER_REPORT_FILE_NAME);

                        objmodel.REVENUE_OFFICER_REPORT_FILE_PATH = Convert.ToString(app.REVENUE_OFFICER_REPORT_FILE_PATH);

                        objmodel.FOREST_REPORT_FILE_NAME = Convert.ToString(app.FOREST_REPORT_FILE_NAME);
                        objmodel.FOREST_REPORT_FILE_PATH = Convert.ToString(app.FOREST_REPORT_FILE_PATH);

                        objmodel.MINING_INSPECTOR_REPORT_FILE_NAME = Convert.ToString(app.MINING_INSPECTOR_REPORT_FILE_NAME);

                        objmodel.MINING_INSPECTOR_REPORT_FILE_PATH = Convert.ToString(app.MINING_INSPECTOR_REPORT_FILE_PATH);

                        objmodel.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME = Convert.ToString(app.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME);

                        objmodel.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_PATH = Convert.ToString(app.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_PATH);

                        objmodel.GRAM_PANCHAYAT_PROPOSAL_FILE_NAME = Convert.ToString(app.GRAM_PANCHAYAT_PROPOSAL_FILE_NAME);

                        objmodel.GRAM_PANCHAYAT_PROPOSAL_FILE_PATH = Convert.ToString(app.GRAM_PANCHAYAT_PROPOSAL_FILE_PATH);

                        objmodel.MinorMineralFormAttachment_FILE = Convert.ToString(app.File_Minor_Mineral);

                        objmodel.MinorMineralFormAttachment_PATH = Convert.ToString(app.Path_Minor_Mineral);

                        objmodel.TIN_CARD = Convert.ToString(app.TIN_CARD);

                        objmodel.TIN_CARD_SCAN_COPY_FILE_NAME = Convert.ToString(app.TIN_CARD_SCAN_COPY_FILE_NAME);

                        objmodel.TIN_CARD_SCAN_COPY_FILE_PATH = Convert.ToString(app.TIN_CARD_SCAN_COPY_FILE_PATH);

                        objmodel.FIRMREGISTRATION_DEED_NUMBER = Convert.ToString(app.FIRMREGISTRATION_DEED_NUMBER);

                        objmodel.FIRM_REGISTRATION_DEED_FILE_NAME = Convert.ToString(app.FIRM_REGISTRATION_DEED_FILE_NAME);

                        objmodel.FIRM_REGISTRATION_DEED_FILE_PATH = Convert.ToString(app.FIRM_REGISTRATION_DEED_FILE_PATH);

                        objmodel.CERTIFICATE_OF_INCORPORATION_NUMBER = Convert.ToString(app.CERTIFICATE_OF_INCORPORATION_NUMBER);

                        objmodel.CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME = Convert.ToString(app.CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME);

                        objmodel.CERTIFICATE_OF_INCORPORATION_DOC_FILE_PATH = Convert.ToString(app.CERTIFICATE_OF_INCORPORATION_DOC_FILE_PATH);

                        objmodel.APPLICATION_FEES_DATE = Convert.ToDateTime(app.APPLICATION_FEES_DATE);

                        objmodel.APPLICATION_FEES = Convert.ToString(app.APPLICATION_FEES);

                        objmodel.APPLICATION_FEES_COPY_FILE_NAME = Convert.ToString(app.APPLICATION_FEES_COPY_FILE_NAME);

                        objmodel.APPLICATION_FEES_COPY_FILE_PATH = Convert.ToString(app.APPLICATION_FEES_COPY_FILE_PATH);

                        objmodel.CHALLAN_DD_AMOUNT_DATE = Convert.ToDateTime(app.CHALLAN_DD_AMOUNT_DATE);

                        objmodel.CHALLAN_DD_AMOUNT = Convert.ToString(app.CHALLAN_DD_AMOUNT);

                        objmodel.CHALLAN_DD_AMOUNT_COPY_FILE_NAME = Convert.ToString(app.CHALLAN_DD_AMOUNT_COPY_FILE_NAME);

                        objmodel.CHALLAN_DD_AMOUNT_COPY_FILE_PATH = Convert.ToString(app.CHALLAN_DD_AMOUNT_COPY_FILE_PATH);

                        objmodel.BANK_GUARRANTEE_AMOUNT = Convert.ToString(app.BANK_GUARRANTEE_AMOUNT);

                        objmodel.BANK_GUARRANTEE_COPY_FILE_NAME = Convert.ToString(app.BANK_GUARRANTEE_COPY_FILE_NAME);

                        objmodel.BANK_GUARRANTEE_COPY_FILE_PATH = Convert.ToString(app.BANK_GUARRANTEE_COPY_FILE_PATH);
                        objmodel.BANK_GUARRANTEE_DATE = Convert.ToDateTime(app.BANK_GUARRANTEE_DATE);
                        objmodel.SURITY_BOND_AMOUNT = Convert.ToString(app.SURITY_BOND_AMOUNT);
                        objmodel.SURITY_BOND_DATE = Convert.ToDateTime(app.SURITY_BOND_DATE);

                        objmodel.SURITY_BOND_COPY_FILE_NAME = Convert.ToString(app.SURITY_BOND_COPY_FILE_NAME);

                        objmodel.SURITY_BOND_COPY_FILE_PATH = Convert.ToString(app.SURITY_BOND_COPY_FILE_PATH);

                        objmodel.ADHAR_CARD = Convert.ToString(app.ADHAR_CARD);

                        objmodel.ADHAR_CARD = Convert.ToString(app.ADHAR_CARD);

                        objmodel.ADHAR_CARD_SCAN_COPY_FILE_NAME = Convert.ToString(app.ADHAR_CARD_SCAN_COPY_FILE_NAME);

                        objmodel.ADHAR_CARD_SCAN_COPY_FILE_PATH = Convert.ToString(app.ADHAR_CARD_SCAN_COPY_FILE_PATH);
                        objmodel.STATUS = Convert.ToInt32(app.STATUS);
                        objmodel.CREATED_BY = Convert.ToInt32(app.CREATED_BY);

                        objmodel.NAME_OF_TRANSFEREE = Convert.ToString(app.NAME_OF_TRANSFEREE);

                        objmodel.ADDRESS_OF_TRANSFEREE = Convert.ToString(app.ADDRESS_OF_TRANSFEREE);

                        objmodel.TRANSFER_GRANT_ORDER_COPY_FILE_NAME = Convert.ToString(app.TRANSFER_GRANT_ORDER_COPY_FILE_NAME);

                        objmodel.TRANSFER_GRANT_ORDER_COPY_FILE_PATH = Convert.ToString(app.TRANSFER_GRANT_ORDER_COPY_FILE_PATH);

                        objmodel.TRANSFER_LEASE_DEED_COPY_FILE_NAME = Convert.ToString(app.TRANSFER_LEASE_DEED_COPY_FILE_NAME);

                        objmodel.TRANSFER_LEASE_DEED_COPY_FILE_PATH = Convert.ToString(app.TRANSFER_LEASE_DEED_COPY_FILE_PATH);

                        objmodel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME = Convert.ToString(app.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME);

                        objmodel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH = Convert.ToString(app.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH);

                        objmodel.DATE_OF_TRANSFER = Convert.ToDateTime(app.DATE_OF_TRANSFER);

                        //  objmodel.MINERAL_NAME = Convert.ToString(ds.Tables[1].Rows[0]["MineralName);

                        objmodel.Remarks = Convert.ToString(app.Remarks);

                        objmodel.UpfrontPaymentDeposited = Convert.ToDecimal(app.UpfrontPaymentDeposited);

                        objmodel.TillDateBalanceUpfrontPayment = Convert.ToDecimal(app.TillDateBalanceUpfrontPayment);

                        objmodel.IsInterNetConnectionAtDistpatch = Convert.ToInt32(app.IsInterNetConnectionAtDistpatch);

                        objmodel.TillDateDispatchQty = Convert.ToDecimal(app.TillDateDispatchQty);

                        objmodel.MonthlyPeriodicAmt = Convert.ToString(app.MonthlyPeriodicAmount);

                        objmodel.TRANSFER_LEASE_DEED_COPY_FILE_PATH = Convert.ToString(app.TRANSFER_LEASE_DEED_COPY_FILE_PATH);
                        objmodel.MonthlyPeriodicAmtRate = Convert.ToString(app.MonthlyPeriodAmountRate);

                        objmodel.PerformanceSecurity_FILE = Convert.ToString(app.File_PerformanceSecurity);
                        objmodel.PerformanceSecurity_PATH = Convert.ToString(app.Path_PerformanceSecurity);
                        objmodel.FinancialAssuranceAttachment_FILE = Convert.ToString(app.File_FinancialAssurance);
                        objmodel.FinancialAssuranceAttachment_PATH = Convert.ToString(app.Path_FinancialAssurance);

                        objmodel.StorageCrusherAttachment_FILE = Convert.ToString(app.File_LicenseStorageCrusher);
                        objmodel.StorageCrusherAttachment_PATH = Convert.ToString(app.Path_LicenseStorageCrusher);


                        objmodel.AdjustCess = Convert.ToString(app.AdjustCESSFromRoyalty);
                        objmodel.OrderNo = Convert.ToString(app.OrderNo);
                        objmodel.OrderOf = Convert.ToString(app.OrderOf);
                        objmodel.OrderDate = Convert.ToString(app.OrderDate);
                        objmodel.OrderAttachment_File = Convert.ToString(app.OrderAttachment_File);
                        //   objmodel.OrderAttachment_Path = System.Configuration.ConfigurationManager.AppSettings["ServerPath + @"/Upload/" + Convert.ToString(app.OrderAttachment_Path);

                        objmodel.CrusherInstalled = Convert.ToString(app.CrusherInstalled);
                        objmodel.StorageCrusher = Convert.ToString(app.StorageCrusher);
                        objmodel.PaymentModeType = Convert.ToString(app.PaymentModeType);
                        objmodel.BG_ValidityUpto = Convert.ToString(app.BG_ValidityUpto);
                        objmodel.SecurityDeposit = Convert.ToDecimal(app.SecurityDeposit);
                        objmodel.FinancialAmountAssurance = Convert.ToDecimal(app.FinancialAmountAssurance);

                        objmodel.AmountOfDD = Convert.ToDecimal(app.AmountOfDD);
                        objmodel.WBStampDate = Convert.ToString(app.WBStampDate);
                        objmodel.WBValidUpto = Convert.ToString(app.WBValidUpto);
                        objmodel.WBInstalled = Convert.ToString(app.WBInstalled);
                        objmodel.WBExemption_FILE = Convert.ToString(app.WBExemption_FILE);
                        // objmodel.WBExemption_PATH = System.Configuration.ConfigurationManager.AppSettings["ServerPath + @"/Upload/" + Convert.ToString(app.WBExemption_PATH);
                        objmodel.LabEstablished = Convert.ToString(app.LabEstablished);
                        objmodel.LabExemption_FILE = Convert.ToString(app.LabExemption_FILE);
                        // objmodel.LabExemption_PATH = System.Configuration.ConfigurationManager.AppSettings["ServerPath + @"/Upload/" + Convert.ToString(app.LabExemption_PATH);

                    }
                    if (objAppl != null)
                    {
                        foreach (var app1 in objAppl.MineralLst)
                        {
                            objmodel.MINERAL_NAME = Convert.ToString(app1.MineralIdList);
                        }
                    }
                    // ViewBag.NoticeDetails = objAppl.ApplicationLst;
                    // ViewBag.NoticeFileList = objAppl.MineralLst;


                }
                return View(objmodel);
            }
        }
        [HttpPost]

        public IActionResult LesseeDetails(UserInformationEF objmodel, string cmd, List<int> MineralCount, string approve, string reject, string submit, string[] userIds, List<IFormFile> flApplForm, List<IFormFile> flPanCard, List<IFormFile> flAadhar, List<IFormFile> flTinCard, List<IFormFile> flDeedNo, List<IFormFile> flIncorporation, List<IFormFile> flInspection, List<IFormFile> flWBExemp, List<IFormFile> flLicenseCursher, List<IFormFile> flAtorny, List<IFormFile> flDueCertificate, List<IFormFile> flKhasara, List<IFormFile> flMap, List<IFormFile> flForestRpt, List<IFormFile> flRevenue, List<IFormFile> flSpot, List<IFormFile> flMI, List<IFormFile> flGramPanchayat, List<IFormFile> flMinorMineral, List<IFormFile> flApplFee, List<IFormFile> flSecurityDD, List<IFormFile> flBG, List<IFormFile> flSecurityBond, List<IFormFile> flFD, List<IFormFile> flFinancialAssurance, List<IFormFile> flTRCopy, List<IFormFile> flTRLeaseDeed, List<IFormFile> flOrder, List<IFormFile> flOrder1)
        {
            var checkDMO = "Forward To DD";
           
            if (objmodel.SubResion == "Forward To DD")
            {
                cmd = "Forward To DD";
            }
            if (objmodel.SubApprove == "Approve")
            {
                approve = "Approve";
            }
            if (objmodel.SubReject == "Reject")
            {
                reject = "Reject";
            }
            string Mineral = string.Empty;
            for (int i = 0; i <= MineralCount.Count - 1; i++)
            {
                Mineral = Mineral + MineralCount[i].ToString() + ',';
            }
            if (Mineral != string.Empty)
            {
                string ss = Mineral.Remove(Mineral.Length - 1, 1);
                objmodel.MineralIdList = ss;
            }
            //if (submit == "Submit")
            //{
            if (approve == null && reject == null)
            {
                #region Upload File in APPLICATION_FORM_FILE_NAME
                long size = flApplForm.Sum(f => f.Length);
                var filePaths = new List<string>();

                int FileCount = 0;
                foreach (var formFile in flApplForm)
                {
                    if (formFile != null && formFile.Length > 0)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(formFile.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                            var fileName = strName + "_" + formFile.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                formFile.CopyTo(stream);
                            }
                            objmodel.APPLICATION_FORM_FILE_PATH = path;
                            objmodel.APPLICATION_FORM_FILE_NAME = fileName;


                        }

                    }
                }
                #endregion
                #region Upload File in PAN_CARD_COPY_FILE_NAME
                long size1 = flPanCard.Sum(f => f.Length);
                foreach (var FilePan in flPanCard)
                {
                    if (FilePan != null && FilePan.Length > 0 && FilePan.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FilePan.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FilePan.FileName);
                            var fileName = strName + "_" + FilePan.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FilePan.CopyTo(stream);
                            }
                            objmodel.PAN_CARD_COPY_FILE_PATH = path;
                            objmodel.PAN_CARD_COPY_FILE_NAME = fileName;
                        }

                    }
                }
                #endregion
                #region Upload File in ADHAR_CARD_SCAN_COPY_FILE_NAME
                long size2 = flAadhar.Sum(f => f.Length);
                foreach (var FileAadhar in flAadhar)
                {
                    if (FileAadhar != null && FileAadhar.Length > 0 && FileAadhar.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileAadhar.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileAadhar.FileName);
                            var fileName = strName + "_" + FileAadhar.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileAadhar.CopyTo(stream);
                            }
                            objmodel.ADHAR_CARD_SCAN_COPY_FILE_PATH = path;
                            objmodel.ADHAR_CARD_SCAN_COPY_FILE_NAME = fileName;
                        }

                    }
                }
                #endregion
                #region Upload File in TIN_CARD_SCAN_COPY_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileTin in flTinCard)
                {
                    if (FileTin != null && FileTin.Length > 0 && FileTin.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileTin.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileTin.FileName);
                            var fileName = strName + "_" + FileTin.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileTin.CopyTo(stream);
                            }
                            objmodel.TIN_CARD_SCAN_COPY_FILE_PATH = path;
                            objmodel.TIN_CARD_SCAN_COPY_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in FIRM_REGISTRATION_DEED_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileDeed in flDeedNo)
                {
                    if (FileDeed != null && FileDeed.Length > 0 && FileDeed.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileDeed.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileDeed.FileName);
                            var fileName = strName + "_" + FileDeed.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileDeed.CopyTo(stream);
                            }
                            objmodel.FIRM_REGISTRATION_DEED_FILE_PATH = path;
                            objmodel.FIRM_REGISTRATION_DEED_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileIncorporation in flIncorporation)
                {
                    if (FileIncorporation != null && FileIncorporation.Length > 0 && FileIncorporation.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileIncorporation.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileIncorporation.FileName);
                            var fileName = strName + "_" + FileIncorporation.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileIncorporation.CopyTo(stream);
                            }
                            objmodel.CERTIFICATE_OF_INCORPORATION_DOC_FILE_PATH = path;
                            objmodel.CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in APPLICATION_FEES_COPY_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileAppl in flApplFee)
                {
                    if (FileAppl != null && FileAppl.Length > 0 && FileAppl.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileAppl.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileAppl.FileName);
                            var fileName = strName + "_" + FileAppl.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileAppl.CopyTo(stream);
                            }
                            objmodel.APPLICATION_FEES_COPY_FILE_PATH = path;
                            objmodel.APPLICATION_FEES_COPY_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in POWER_OF_ATORNY_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileAtorny in flAtorny)
                {
                    if (FileAtorny != null && FileAtorny.Length > 0 && FileAtorny.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileAtorny.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileAtorny.FileName);
                            var fileName = strName + "_" + FileAtorny.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileAtorny.CopyTo(stream);
                            }
                            objmodel.POWER_OF_ATORNY_FILE_PATH = path;
                            objmodel.POWER_OF_ATORNY_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in KHASARA_PANCHSALA_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileKhasara in flKhasara)
                {
                    if (FileKhasara != null && FileKhasara.Length > 0 && FileKhasara.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileKhasara.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileKhasara.FileName);
                            var fileName = strName + "_" + FileKhasara.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileKhasara.CopyTo(stream);
                            }
                            objmodel.KHASARA_PANCHSALA_FILE_PATH = path;
                            objmodel.KHASARA_PANCHSALA_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in FOREST_REPORT_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileForest in flForestRpt)
                {
                    if (FileForest != null && FileForest.Length > 0 && FileForest.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileForest.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileForest.FileName);
                            var fileName = strName + "_" + FileForest.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileForest.CopyTo(stream);
                            }
                            objmodel.FOREST_REPORT_FILE_PATH = path;
                            objmodel.FOREST_REPORT_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileSpot in flSpot)
                {
                    if (FileSpot != null && FileSpot.Length > 0 && FileSpot.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileSpot.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileSpot.FileName);
                            var fileName = strName + "_" + FileSpot.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileSpot.CopyTo(stream);
                            }
                            objmodel.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_PATH = path;
                            objmodel.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in GRAM_PANCHAYAT_PROPOSAL_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FilePanchayat in flGramPanchayat)
                {
                    if (FilePanchayat != null && FilePanchayat.Length > 0 && FilePanchayat.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FilePanchayat.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FilePanchayat.FileName);
                            var fileName = strName + "_" + FilePanchayat.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FilePanchayat.CopyTo(stream);
                            }
                            objmodel.GRAM_PANCHAYAT_PROPOSAL_FILE_PATH = path;
                            objmodel.GRAM_PANCHAYAT_PROPOSAL_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileDueCert in flDueCertificate)
                {
                    if (FileDueCert != null && FileDueCert.Length > 0 && FileDueCert.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileDueCert.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileDueCert.FileName);
                            var fileName = strName + "_" + FileDueCert.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileDueCert.CopyTo(stream);
                            }
                            objmodel.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_PATH = path;
                            objmodel.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in MAP_PLAN_OF_APPLIED_AREA_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileMap in flMap)
                {
                    if (FileMap != null && FileMap.Length > 0 && FileMap.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileMap.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileMap.FileName);
                            var fileName = strName + "_" + FileMap.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileMap.CopyTo(stream);
                            }
                            objmodel.MAP_PLAN_OF_APPLIED_AREA_FILE_PATH = path;
                            objmodel.MAP_PLAN_OF_APPLIED_AREA_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in REVENUE_OFFICER_REPORT_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileRevenue in flRevenue)
                {
                    if (FileRevenue != null && FileRevenue.Length > 0 && FileRevenue.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileRevenue.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileRevenue.FileName);
                            var fileName = strName + "_" + FileRevenue.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileRevenue.CopyTo(stream);
                            }
                            objmodel.REVENUE_OFFICER_REPORT_FILE_PATH = path;
                            objmodel.REVENUE_OFFICER_REPORT_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in MINING_INSPECTOR_REPORT_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileMI in flMI)
                {
                    if (FileMI != null && FileMI.Length > 0 && FileMI.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileMI.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileMI.FileName);
                            var fileName = strName + "_" + FileMI.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileMI.CopyTo(stream);
                            }
                            objmodel.MINING_INSPECTOR_REPORT_FILE_PATH = path;
                            objmodel.MINING_INSPECTOR_REPORT_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in CHALLAN_DD_AMOUNT_COPY_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileSecurityDD in flSecurityDD)
                {
                    if (FileSecurityDD != null && FileSecurityDD.Length > 0 && FileSecurityDD.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileSecurityDD.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileSecurityDD.FileName);
                            var fileName = strName + "_" + FileSecurityDD.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileSecurityDD.CopyTo(stream);
                            }
                            objmodel.CHALLAN_DD_AMOUNT_COPY_FILE_PATH = path;
                            objmodel.CHALLAN_DD_AMOUNT_COPY_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in BANK_GUARRANTEE_COPY_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileBG in flBG)
                {
                    if (FileBG != null && FileBG.Length > 0 && FileBG.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileBG.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileBG.FileName);
                            var fileName = strName + "_" + FileBG.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileBG.CopyTo(stream);
                            }
                            objmodel.BANK_GUARRANTEE_COPY_FILE_PATH = path;
                            objmodel.BANK_GUARRANTEE_COPY_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in SURITY_BOND_COPY_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileSecurityBond in flSecurityBond)
                {
                    if (FileSecurityBond != null && FileSecurityBond.Length > 0 && FileSecurityBond.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileSecurityBond.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileSecurityBond.FileName);
                            var fileName = strName + "_" + FileSecurityBond.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileSecurityBond.CopyTo(stream);
                            }
                            objmodel.SURITY_BOND_COPY_FILE_PATH = path;
                            objmodel.SURITY_BOND_COPY_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in MinorMineralFormAttachment_PATH
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileMineral in flMinorMineral)
                {
                    if (FileMineral != null && FileMineral.Length > 0 && FileMineral.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileMineral.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileMineral.FileName);
                            var fileName = strName + "_" + FileMineral.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileMineral.CopyTo(stream);
                            }
                            objmodel.MinorMineralFormAttachment_FILE = path;
                            objmodel.MinorMineralFormAttachment_PATH = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in TRANSFER_GRANT_ORDER_COPY_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileTR in flTRCopy)
                {
                    if (FileTR != null && FileTR.Length > 0 && FileTR.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileTR.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileTR.FileName);
                            var fileName = strName + "_" + FileTR.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileTR.CopyTo(stream);
                            }
                            objmodel.TRANSFER_GRANT_ORDER_COPY_FILE_PATH = path;
                            objmodel.TRANSFER_GRANT_ORDER_COPY_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in TRANSFER_LEASE_DEED_COPY_FILE_NAME
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileTRLease in flTRLeaseDeed)
                {
                    if (FileTRLease != null && FileTRLease.Length > 0 && FileTRLease.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileTRLease.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileTRLease.FileName);
                            var fileName = strName + "_" + FileTRLease.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileTRLease.CopyTo(stream);
                            }
                            objmodel.TRANSFER_LEASE_DEED_COPY_FILE_PATH = path;
                            objmodel.TRANSFER_LEASE_DEED_COPY_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileFD in flFD)
                {
                    if (FileFD != null && FileFD.Length > 0 && FileFD.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileFD.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileFD.FileName);
                            var fileName = strName + "_" + FileFD.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileFD.CopyTo(stream);
                            }
                            objmodel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH = path;
                            objmodel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in WBExemption_FILE
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileWBExemp in flWBExemp)
                {
                    if (FileWBExemp != null && FileWBExemp.Length > 0 && FileWBExemp.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileWBExemp.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileWBExemp.FileName);
                            var fileName = strName + "_" + FileWBExemp.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileWBExemp.CopyTo(stream);
                            }
                            objmodel.WBExemption_PATH = path;
                            objmodel.WBExemption_FILE = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in LabExemption_FILE
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileLabExemp in flInspection)
                {
                    if (FileLabExemp != null && FileLabExemp.Length > 0 && FileLabExemp.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileLabExemp.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileLabExemp.FileName);
                            var fileName = strName + "_" + FileLabExemp.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileLabExemp.CopyTo(stream);
                            }
                            objmodel.LabExemption_PATH = path;
                            objmodel.LabExemption_FILE = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in OrderAttachment_File
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileOrder in flOrder)
                {
                    if (FileOrder != null && FileOrder.Length > 0 && FileOrder.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileOrder.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileOrder.FileName);
                            var fileName = strName + "_" + FileOrder.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileOrder.CopyTo(stream);
                            }
                            objmodel.OrderAttachment_Path = path;
                            objmodel.OrderAttachment_File = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in OrderAttachment_File1
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileOrder in flOrder1)
                {
                    if (FileOrder != null && FileOrder.Length > 0 && FileOrder.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileOrder.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileOrder.FileName);
                            var fileName = strName + "_" + FileOrder.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileOrder.CopyTo(stream);
                            }
                            objmodel.OrderAttachment_Path = path;
                            objmodel.OrderAttachment_File = fileName;
                        }

                    }

                }
                #endregion
                #region Upload File in OrderAttachment_File1
                //long size2 = flPanCard.Sum(f => f.Length);
                foreach (var FileOrder in flOrder1)
                {
                    if (FileOrder != null && FileOrder.Length > 0 && FileOrder.Length < 2048 * 1024)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(FileOrder.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + FileOrder.FileName);
                            var fileName = strName + "_" + FileOrder.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                FileOrder.CopyTo(stream);
                            }
                            objmodel.OrderAttachment_Path = path;
                            objmodel.OrderAttachment_File = fileName;
                        }

                    }

                }
                #endregion
                if (checkDMO == cmd)
                {
                    objmodel.STATUS = 1;
                    objmodel.UserID = 58;
                    objmodel.CREATED_BY = 58;
                    //CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    //objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeApplication-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                    objMSmodel = _userInformation.SaveApplication(objmodel);

                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Application Details forwarded to DD/DMO successfully";
                    }
                    else if (objMSmodel.Satus == "2")
                    {
                        ViewBag.msg = "Lessee Application Details forwarded to DD/DMO successfully";
                    }
                    else
                    {
                        ViewBag.msg = "Error ! while forwarding Lessee Application Details to DD/DMO";
                    }
                }
                else
                {
                    objmodel.UserID = 58;
                    objmodel.CREATED_BY = 58;
                    objmodel.STATUS = 0;

                    objMSmodel = _userInformation.SaveApplication(objmodel);

                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Application Details Saved successfully";
                    }
                    else if (objMSmodel.Satus == "2")
                    {
                        ViewBag.msg = "Lessee Application Details updated successfully";
                    }
                    else
                    {
                        ViewBag.msg = "Error ! while Updating Lessee Application Details";
                    }
                }
            }
            else

            {
                //Acceptance of Profile o Rejection of Profile
                if (approve == "Approve")
                {
                    objmodel.Actionstatus = "APPROVE";
                    //Approved Profile Code

                    //CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    //objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeApplication-Approve", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                    objMSmodel = _userInformation.ApproveLesseeApplicationDetails(objmodel);
                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Application Details Approved successfully";
                    }
                    else
                        ViewBag.msg = "Error ! while Approving Lessee Application Details";
                }
                else
                {
                    objmodel.Actionstatus = "REJECT";
                    //Rejection Profile Code

                    // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    //objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeApplication-Reject", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                    objMSmodel = _userInformation.RejectLesseeApplicationDetails(objmodel);
                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Application Details Rejected successfully";
                    }
                    else
                    {
                        ViewBag.msg = "Error ! while Rejecting Lessee Application Details";
                        return Redirect("~/DMO/LicenseeProfileRequest/Index");
                    }
                }
            }



            return RedirectToAction("LesseeDetails");
           
            //return View(objmodel);
        }
        public FileResult Download(string fileName)
        {
            string hosting = _hostingEnvironment.ContentRootPath;
            try
            {

                var absolutePath = Path.Combine(hosting, ("~/wwwroot/Upload/"), fileName);

                if (System.IO.File.Exists(absolutePath))
                {
                    return File(new FileStream(absolutePath, FileMode.Open), "application/octetstream", fileName);
                }
                return null;
            }

            catch (Exception ex)
            {
                throw ex;
                //return null;
            }
        }
        public IActionResult GrantOrderDetails(int? id)
        {

            UserInformationEF model = new UserInformationEF();
            ApplicationResult objAppl = new ApplicationResult();
            ApplicationResult objProfile = new ApplicationResult();
            model.UserID = 58;
            model.MINERAL_NAME = "Minor Mineral";
            //if (SessionWrapper.UserId > 0)
            //{
            if (id == null)
            {
                objAppl = _userInformation.GetGrantOrder(model);
                objProfile = _userInformation.GetProfileCount(model);
                if (objProfile != null)
                {
                    foreach (var app in objProfile.ApplicationLst)
                    {
                        ViewBag.completionCount = app.PERCENTAGES;
                    }
                }
                if (objAppl != null)
                {
                    foreach (var app in objAppl.GrantOrderLst)
                    {
                        model.GrantOrderId = Convert.ToInt32(app.GrantOrderId);
                        if (!(app.CREATED_BY is null))
                        {
                            model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        }
                        if (!(app.GrantOrderNumber is null))
                        {
                            model.GrantOrderNumber = Convert.ToString(app.GrantOrderNumber.ToString());
                        }
                        if (!(app.GrantOrderDate is null))
                        {
                            model.GrantOrderDate = Convert.ToDateTime(app.GrantOrderDate.ToString());
                        }
                        if (!(app.FromValidity is null))
                        {
                            model.FromValidity = Convert.ToDateTime(app.FromValidity.ToString());
                        }
                        if (!(app.ToValidity is null))
                        {
                            model.ToValidity = Convert.ToDateTime(app.ToValidity.ToString());
                        }
                        if (!(app.ExecutionOfDeedNumber is null))
                        {
                            model.ExecutionOfDeedNumber = Convert.ToString(app.ExecutionOfDeedNumber.ToString());
                        }
                        if (!(app.ExecutionOfDeedDate is null))
                        {
                            model.ExecutionOfDeedDate = Convert.ToDateTime(app.ExecutionOfDeedDate.ToString());
                        }
                        if (!(app.GrantOrderFileName is null))
                        {
                            model.GrantOrderFileName = Convert.ToString(app.GrantOrderFileName.ToString());
                        }
                        if (!(app.GrantOrderFilePath is null))
                        {
                            model.GrantOrderFilePath = Convert.ToString(app.GrantOrderFilePath.ToString());
                        }
                        if (!(app.ExecutionOfDeedFileName is null))
                        {
                            model.ExecutionOfDeedFileName = Convert.ToString(app.ExecutionOfDeedFileName.ToString());
                        }
                        if (!(app.ExecutionOfDeedFilePath is null))
                        {
                            model.ExecutionOfDeedFilePath = Convert.ToString(app.ExecutionOfDeedFilePath.ToString());
                        }
                        if (!(app.Lease_Period is null))
                        {
                            model.Lease_Period = Convert.ToString(app.Lease_Period.ToString());
                        }
                        if (!(app.STATUS is null))
                        {
                            model.STATUS = Convert.ToInt32(app.STATUS);
                        }
                        else
                        {
                            model.STATUS = 0;
                        }
                        if (!(app.Remarks is null))
                            model.Remarks = Convert.ToString(app.Remarks);
                        if (!(app.TodateIntimation is null))
                        {
                            model.TodateIntimation = Convert.ToString(app.TodateIntimation);

                        }
                    }
                }
            }
            else
            {
                model.UserID = Convert.ToInt32(id);
                objAppl = _userInformation.GetGrantOrder(model);
                objProfile = _userInformation.GetProfileCount(model);
                if (objProfile != null)
                {
                    foreach (var app in objProfile.ApplicationLst)
                    {
                        ViewBag.completionCount = app.PERCENTAGES;
                    }
                }
                if (objAppl != null)
                {
                    foreach (var app in objAppl.GrantOrderLst)
                    {
                        model.GrantOrderId = Convert.ToInt32(app.GrantOrderId);
                        if (!(app.CREATED_BY is null))
                        {
                            model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        }
                        if (!(app.GrantOrderNumber is null))
                        {
                            model.GrantOrderNumber = Convert.ToString(app.GrantOrderNumber.ToString());
                        }
                        if (!(app.GrantOrderDate is null))
                        {
                            model.GrantOrderDate = Convert.ToDateTime(app.GrantOrderDate.ToString());
                        }
                        if (!(app.FromValidity is null))
                        {
                            model.FromValidity = Convert.ToDateTime(app.FromValidity.ToString());
                        }
                        if (!(app.ToValidity is null))
                        {
                            model.ToValidity = Convert.ToDateTime(app.ToValidity.ToString());
                        }
                        if (!(app.ExecutionOfDeedNumber is null))
                        {
                            model.ExecutionOfDeedNumber = Convert.ToString(app.ExecutionOfDeedNumber.ToString());
                        }
                        if (!(app.ExecutionOfDeedDate is null))
                        {
                            model.ExecutionOfDeedDate = Convert.ToDateTime(app.ExecutionOfDeedDate.ToString());
                        }
                        if (!(app.GrantOrderFileName is null))
                        {
                            model.GrantOrderFileName = Convert.ToString(app.GrantOrderFileName.ToString());
                        }
                        if (!(app.GrantOrderFilePath is null))
                        {
                            model.GrantOrderFilePath = Convert.ToString(app.GrantOrderFilePath.ToString());
                        }
                        if (!(app.ExecutionOfDeedFileName is null))
                        {
                            model.ExecutionOfDeedFileName = Convert.ToString(app.ExecutionOfDeedFileName.ToString());
                        }
                        if (!(app.ExecutionOfDeedFilePath is null))
                        {
                            model.ExecutionOfDeedFilePath = Convert.ToString(app.ExecutionOfDeedFilePath.ToString());
                        }
                        if (!(app.Lease_Period is null))
                        {
                            model.Lease_Period = Convert.ToString(app.Lease_Period.ToString());
                        }
                        if (!(app.STATUS is null))
                        {
                            model.STATUS = Convert.ToInt32(app.STATUS);
                        }
                        else
                        {
                            model.STATUS = 0;
                        }
                        if (!(app.Remarks is null))
                            model.Remarks = Convert.ToString(app.Remarks);
                        if (!(app.TodateIntimation is null))
                        {
                            model.TodateIntimation = Convert.ToString(app.TodateIntimation);

                        }
                    }
                }


            }



            //  }
            if (model == null)
                return View(model);
            return View(model);
        }
        [HttpPost]

        public IActionResult GrantOrderDetails(UserInformationEF model, string cmd, string approve, string reject, List<IFormFile> flGrantOrderCopy, List<IFormFile> flLeaseDeedDoc)
        {



            var checkDMO = "Forward To DD";

            if (model.SubResion == "Forward To DD")
            {
                cmd = "Forward To DD";
            }
            if (model.SubApprove == "Approve")
            {
                approve = "Approve";
            }
            if (model.SubReject == "Reject")
            {
                reject = "Reject";
            }
            bool Flag = false;
            if (approve == null && reject == null)
            {
                if (ModelState.IsValid)
                {
                    #region Upload File in flGrantOrderCopy
                    long size = flGrantOrderCopy.Sum(f => f.Length);
                    var filePaths = new List<string>();

                    int FileCount = 0;
                    foreach (var formFile in flGrantOrderCopy)
                    {
                        if (formFile != null && formFile.Length > 0)
                        {
                            //foreach (var file in UploadFile)
                            //{
                            if (!string.IsNullOrEmpty(formFile.FileName))
                            {

                                string hosting = _hostingEnvironment.ContentRootPath;
                                string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                                var fileName = strName + "_" + formFile.FileName;

                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    formFile.CopyTo(stream);
                                }
                                model.GrantOrderFilePath = path;
                                model.GrantOrderFileName = fileName;


                            }

                        }
                    }
                    #endregion
                    #region Upload File in flLeaseDeedDoc
                    size = flLeaseDeedDoc.Sum(f => f.Length);
                    filePaths = new List<string>();


                    foreach (var formFile in flLeaseDeedDoc)
                    {
                        if (formFile != null && formFile.Length > 0)
                        {
                            //foreach (var file in UploadFile)
                            //{
                            if (!string.IsNullOrEmpty(formFile.FileName))
                            {

                                string hosting = _hostingEnvironment.ContentRootPath;
                                string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                                var fileName = strName + "_" + formFile.FileName;

                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    formFile.CopyTo(stream);
                                }
                                model.ExecutionOfDeedFilePath = path;
                                model.ExecutionOfDeedFileName = fileName;


                            }

                        }
                    }
                    #endregion
                    if (checkDMO == cmd)
                    {
                        model.STATUS = 1;
                        model.UserID = 58;
                        model.UserLoginId = "1513081";
                        // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeGrantOrder-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.SaveGrantDetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Lessee Grant Order Details forwarded to DD/DMO successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            ViewBag.msg = "Lessee Grant Order Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while forwarding Lessee Grant Order Details to DD/DMO";
                        }
                    }

                    else
                    {
                        model.STATUS = 0;
                        model.UserID = 58;
                        model.UserLoginId = "1513081";
                        //CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        //objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeGrantOrder-Save", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.SaveGrantDetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Lessee Grant Order Details Saved successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            ViewBag.msg = "Lessee Grant Order  Details Updated successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while Updating Lessee Grant Order Details";
                        }

                    }
                }
            }
            else

            {
                //Acceptance of Profile o Rejection of Profile
                if (approve == "Approve")
                {
                    model.Actionstatus = "APPROVE";
                    model.UserID = 58;
                    model.CREATED_BY = 58;
                    //Approved Profile Code
                    // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeGrantOrder-Approve", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                    objMSmodel = _userInformation.ApproveLesseeGrantDetails(model);
                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Grant Order Details Approved successfully";
                    }
                    else
                        ViewBag.msg = "Error ! while Approving Lessee Grant Order Details";
                }
                else
                {
                    model.UserID = 58;
                    model.CREATED_BY = 58;
                    //Rejection Profile Code
                    // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeGrantOrder-Reject", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                    objMSmodel = _userInformation.RejectLesseeGrantDetails(model);
                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Grant Order Details Rejected successfully";
                    }
                    else
                    {
                        ViewBag.msg = "Error ! while Rejecting Lessee Grant Order Details";
                        // return Redirect("~/DMO/LesseeProfileRequest/Index");
                    }
                }

            }
            return RedirectToAction("GrantOrderDetails");
        }
        public IActionResult LeaseInformationDetails(int? id)
        {

            UserInformationEF model = new UserInformationEF();
            ApplicationResult objAppl = new ApplicationResult();
            ApplicationResult objProfile = new ApplicationResult();
            //*-------TO FILL Office Type DROPDOWN---------


            //ViewBag.ViewUserList=  _objNoticeModel.ViewUserType(objmodel);
            var x = _userInformation.GetStateList(model);
            if (x.StateLst != null)
            {
                ViewBag.ViewStateList = x.StateLst.Select(c => new SelectListItem
                {
                    Text = c.STATE_NAME,
                    Value = c.STATE_ID.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewStateList = Enumerable.Empty<SelectListItem>();
            }

            x = _userInformation.GetDistrictList(model);
            if (x.DistrictLst != null)
            {
                ViewBag.ViewDistrictList = x.DistrictLst.Select(c => new SelectListItem
                {
                    Text = c.DistrictName,
                    Value = c.DISTRICT_ID.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewDistrictList = Enumerable.Empty<SelectListItem>();
            }
            x = _userInformation.GetTehsilList(model);
            if (x.TehsilLst != null)
            {
                ViewBag.ViewTehsilList = x.TehsilLst.Select(c => new SelectListItem
                {
                    Text = c.TehsilName,
                    Value = c.TEHSIL_FOREST_DIVISION.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewTehsilList = Enumerable.Empty<SelectListItem>();
            }
            x = _userInformation.GetVillageList(model);
            if (x.VillageLst != null)
            {
                ViewBag.ViewVillageList = x.VillageLst.Select(c => new SelectListItem
                {
                    Text = c.VillageName,
                    Value = c.VILLAGE_ID.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewVillageList = Enumerable.Empty<SelectListItem>();
            }
            ////---------------------------------------------*/
            model.UserID = 58;
            model.MINERAL_NAME = "Minor Mineral";
            if (id == null)
            {
                objAppl = _userInformation.GetLeaseArea(model);
                objProfile = _userInformation.GetLesseeProfileStatus(model);
                if (objProfile != null)
                {
                    foreach (var app in objProfile.ApplicationLst)
                    {
                        //ViewBag.completionCount = app.PERCENTAGES;
                    }
                }
                if (objAppl != null)
                {
                    foreach (var app in objAppl.LeaseAreaDetailsLst)
                    {
                        if (!(app.LICENSE_AREA_ID is null))
                            model.LICENSE_AREA_ID = Convert.ToInt32(app.LICENSE_AREA_ID);
                        if (!(app.VILLAGE_ID is null))
                            model.VILLAGE_ID = Convert.ToInt32(app.VILLAGE_ID);
                        if (!(app.BLOCK_FOREST_RANGE is null))
                            model.BLOCK_FOREST_RANGE = Convert.ToString(app.BLOCK_FOREST_RANGE);
                        if (!(app.TEHSIL_FOREST_DIVISION is null))
                            model.TEHSIL_FOREST_DIVISION = Convert.ToInt32(app.TEHSIL_FOREST_DIVISION);
                        if (!(app.DISTRICT_ID is null))
                            model.DISTRICT_ID = Convert.ToInt32(app.DISTRICT_ID);
                        if (!(app.STATE_ID is null))
                            model.STATE_ID = Convert.ToInt32(app.STATE_ID);
                        if (!(app.PIN_CODE is null))
                            model.PIN_CODE = Convert.ToString(app.PIN_CODE);
                        if (!(app.TYPE_OF_LAND is null))
                            model.TYPE_OF_LAND = Convert.ToString(app.TYPE_OF_LAND);
                        if (!(app.AREA_IN_HECT is null))
                            model.AREA_IN_HECT = Convert.ToDecimal(app.AREA_IN_HECT);
                        if (!(app.TOPOSHEET_NO is null))
                            model.TOPOSHEET_NO = Convert.ToString(app.TOPOSHEET_NO);
                        if (!(app.COORDINATES is null))
                            model.COORDINATES = Convert.ToString(app.COORDINATES);
                        if (!(app.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME is null))
                            model.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME = Convert.ToString(app.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME);
                        if (!(app.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH is null))
                            model.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH = Convert.ToString(app.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH);
                        if (!(app.WORKING_PERMISSION_DATE is null))
                            model.WORKING_PERMISSION_DATE = Convert.ToDateTime(app.WORKING_PERMISSION_DATE);
                        if (!(app.WORKING_PERMISSION_COPY_NAME is null))
                            model.WORKING_PERMISSION_COPY_NAME = Convert.ToString(app.WORKING_PERMISSION_COPY_NAME);
                        if (!(app.WORKING_PERMISSION_COPY_PATH is null))
                            model.WORKING_PERMISSION_COPY_PATH = Convert.ToString(app.WORKING_PERMISSION_COPY_PATH);
                        if (!(app.GRAM_PANCHAYAT is null))
                            model.GRAM_PANCHAYAT = Convert.ToString(app.GRAM_PANCHAYAT);
                        if (!(app.POLICE_STATION is null))
                            model.POLICE_STATION = Convert.ToString(app.POLICE_STATION);
                        if (!(app.COMENCEMENT_OF_MINING_DATE is null))
                        {
                            model.COMENCEMENT_OF_MINING_DATE = Convert.ToDateTime(app.COMENCEMENT_OF_MINING_DATE);
                        }
                        if (!(app.COMENCEMENT_OF_MINING_FILE_NAME is null))
                            model.COMENCEMENT_OF_MINING_FILE_NAME = Convert.ToString(app.COMENCEMENT_OF_MINING_FILE_NAME);
                        if (!(app.COMENCEMENT_OF_MINING_FILE_PATH is null))
                            model.COMENCEMENT_OF_MINING_FILE_PATH = Convert.ToString(app.COMENCEMENT_OF_MINING_FILE_PATH);
                        if (!(app.DATE_OF_EXECUTION is null))
                            model.DATE_OF_EXECUTION = Convert.ToDateTime(app.DATE_OF_EXECUTION);
                        if (!(app.STATUS is null))
                        {
                            model.STATUS = Convert.ToInt32(app.STATUS);
                        }

                        if (!(app.CREATED_BY is null))
                        {
                            model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        }
                        if (!(app.Remarks is null))
                            model.Remarks = Convert.ToString(app.Remarks);

                        if (!(app.Forest is null))
                            model.Forest = Convert.ToDecimal(app.Forest);
                        if (!(app.Revenue_Forest is null))
                            model.Revenue_Forest = Convert.ToDecimal(app.Revenue_Forest);
                        // if (!(app.Revenue_Government_Land is null))
                        model.Revenue_Government_Land = Convert.ToDecimal(app.Revenue_Government_Land);
                        if (!(app.Private_Tribal is null))
                            model.Private_Tribal = Convert.ToDecimal(app.Private_Tribal);
                        //  if (!(app.Private_Non_Tribal is null))
                        model.Private_Non_Tribal = Convert.ToDecimal(app.Private_Non_Tribal);
                        if (!(app.Land_Under_Vidhansabha_kshetra is null))
                            model.Land_Under_Vidhansabha_kshetra = Convert.ToString(app.Land_Under_Vidhansabha_kshetra);
                    }
                }

                //ViewBag.completionCount = dbR.GetProfileCount(SessionWrapper.UserId);

            }
            else
            {
                model.UserID = Convert.ToInt32(id);
                objAppl = _userInformation.GetLeaseArea(model);
                objProfile = _userInformation.GetLesseeProfileStatus(model);
                if (objProfile != null)
                {
                    foreach (var app in objProfile.ApplicationLst)
                    {
                        //ViewBag.completionCount = app.PERCENTAGES;
                    }
                }
                if (objAppl != null)
                {
                    foreach (var app in objAppl.GrantOrderLst)
                    {
                        if (!(app.LICENSE_AREA_ID is null))
                            model.LICENSE_AREA_ID = Convert.ToInt32(app.LICENSE_AREA_ID);
                        if (!(app.VILLAGE_ID is null))
                            model.VILLAGE_ID = Convert.ToInt32(app.VILLAGE_ID);
                        if (!(app.BLOCK_FOREST_RANGE is null))
                            model.BLOCK_FOREST_RANGE = Convert.ToString(app.BLOCK_FOREST_RANGE);
                        if (!(app.TEHSIL_FOREST_DIVISION is null))
                            model.TEHSIL_FOREST_DIVISION = Convert.ToInt32(app.TEHSIL_FOREST_DIVISION);
                        if (!(app.DISTRICT_ID is null))
                            model.DISTRICT_ID = Convert.ToInt32(app.DISTRICT_ID);
                        if (!(app.STATE_ID is null))
                            model.STATE_ID = Convert.ToInt32(app.STATE_ID);
                        if (!(app.PIN_CODE is null))
                            model.PIN_CODE = Convert.ToString(app.PIN_CODE);
                        if (!(app.TYPE_OF_LAND is null))
                            model.TYPE_OF_LAND = Convert.ToString(app.TYPE_OF_LAND);
                        if (!(app.AREA_IN_HECT is null))
                            model.AREA_IN_HECT = Convert.ToDecimal(app.AREA_IN_HECT);
                        if (!(app.TOPOSHEET_NO is null))
                            model.TOPOSHEET_NO = Convert.ToString(app.TOPOSHEET_NO);
                        if (!(app.COORDINATES is null))
                            model.COORDINATES = Convert.ToString(app.COORDINATES);
                        if (!(app.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME is null))
                            model.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME = Convert.ToString(app.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME);
                        if (!(app.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH is null))
                            model.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH = Convert.ToString(app.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH);
                        if (!(app.WORKING_PERMISSION_DATE is null))
                            model.WORKING_PERMISSION_DATE = Convert.ToDateTime(app.WORKING_PERMISSION_DATE);
                        if (!(app.WORKING_PERMISSION_COPY_NAME is null))
                            model.WORKING_PERMISSION_COPY_NAME = Convert.ToString(app.WORKING_PERMISSION_COPY_NAME);
                        if (!(app.WORKING_PERMISSION_COPY_PATH is null))
                            model.WORKING_PERMISSION_COPY_PATH = Convert.ToString(app.WORKING_PERMISSION_COPY_PATH);
                        if (!(app.GRAM_PANCHAYAT is null))
                            model.GRAM_PANCHAYAT = Convert.ToString(app.GRAM_PANCHAYAT);
                        if (!(app.POLICE_STATION is null))
                            model.POLICE_STATION = Convert.ToString(app.POLICE_STATION);
                        if (!(app.COMENCEMENT_OF_MINING_DATE is null))
                        {
                            model.COMENCEMENT_OF_MINING_DATE = Convert.ToDateTime(app.COMENCEMENT_OF_MINING_DATE);
                        }
                        if (!(app.COMENCEMENT_OF_MINING_FILE_NAME is null))
                            model.COMENCEMENT_OF_MINING_FILE_NAME = Convert.ToString(app.COMENCEMENT_OF_MINING_FILE_NAME);
                        if (!(app.COMENCEMENT_OF_MINING_FILE_PATH is null))
                            model.COMENCEMENT_OF_MINING_FILE_PATH = Convert.ToString(app.COMENCEMENT_OF_MINING_FILE_PATH);
                        if (!(app.DATE_OF_EXECUTION is null))
                            model.DATE_OF_EXECUTION = Convert.ToDateTime(app.DATE_OF_EXECUTION);
                        if (!(app.STATUS is null))
                        {
                            model.STATUS = Convert.ToInt32(app.STATUS);
                        }

                        if (!(app.CREATED_BY is null))
                        {
                            model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        }
                        if (!(app.Remarks is null))
                            model.Remarks = Convert.ToString(app.Remarks);

                        if (!(app.Forest is null))
                            model.Forest = Convert.ToDecimal(app.Forest);
                        if (!(app.Revenue_Forest is null))
                            model.Revenue_Forest = Convert.ToDecimal(app.Revenue_Forest);
                        // if (!(app.Revenue_Government_Land is null))
                        model.Revenue_Government_Land = Convert.ToDecimal(app.Revenue_Government_Land);
                        if (!(app.Private_Tribal is null))
                            model.Private_Tribal = Convert.ToDecimal(app.Private_Tribal);
                        //if (!(app.Private_Non_Tribal is null))
                        model.Private_Non_Tribal = Convert.ToDecimal(app.Private_Non_Tribal);
                        if (!(app.Land_Under_Vidhansabha_kshetra is null))
                            model.Land_Under_Vidhansabha_kshetra = Convert.ToString(app.Land_Under_Vidhansabha_kshetra);
                    }
                }
                // model = db.Getmodel(id.Value);
                //ViewBag.completionCount = dbR.GetProfileCount(id.Value);
            }
            if (model == null)
                return View(new UserInformationEF());
            return View(model);

        }
        [HttpPost]
        public IActionResult LeaseInformationDetails(UserInformationEF model, string cmd, string approve, string reject, List<IFormFile> flCoordinates, List<IFormFile> flPermission)
        {
            var checkDMO = "Forward To DD";

            if (model.SubResion == "Forward To DD")
            {
                cmd = "Forward To DD";
            }
            if (model.SubApprove == "Approve")
            {
                approve = "Approve";
            }
            if (model.SubReject == "Reject")
            {
                reject = "Reject";
            }

            if (approve == null && reject == null)
            {
                #region Upload File in flCoordinates
                long size = flCoordinates.Sum(f => f.Length);
                var filePaths = new List<string>();

                int FileCount = 0;
                foreach (var formFile in flCoordinates)
                {
                    if (formFile != null && formFile.Length > 0)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(formFile.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                            var fileName = strName + "_" + formFile.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                formFile.CopyTo(stream);
                            }
                            model.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH = path;
                            model.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME = fileName;


                        }

                    }
                }
                #endregion
                #region Upload File in flCoordinates
                long size2 = flPermission.Sum(f => f.Length);
                var filePaths2 = new List<string>();


                foreach (var formFile in flPermission)
                {
                    if (formFile != null && formFile.Length > 0)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(formFile.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                            var fileName = strName + "_" + formFile.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                formFile.CopyTo(stream);
                            }
                            model.WORKING_PERMISSION_COPY_PATH = path;
                            model.WORKING_PERMISSION_COPY_NAME = fileName;


                        }

                    }
                }
                #endregion


                if (ModelState.IsValid)
                {
                    if (checkDMO == cmd)
                    {
                        model.STATUS = 1;
                        model.UserID = 58;
                        model.UserLoginId = "1513081";
                        // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        //  objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeAreaDetails-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.SaveLeaseArea(model);

                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Lessee Area Details forwarded to DD/DMO successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            ViewBag.msg = "Lessee Area Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while forwarding Lessee License Area Details to DD/DMO";
                        }
                    }
                    else
                    {
                        model.STATUS = 0;
                        model.UserID = 58;
                        model.UserLoginId = "1513081";
                        objMSmodel = _userInformation.SaveLeaseArea(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Lessee Area Details Saved successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            ViewBag.msg = "Lessee Area Details updated successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while Updating Lessee License Area Details";
                        }
                    }
                }
            }
            else
            {
                //Acceptance of Profile o Rejection of Profile
                if (approve == "Approve")
                {

                    model.UserID = 58;
                    model.CREATED_BY = 58;
                    //Approved Profile Code
                    //CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeAreaDetails-Approve", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                    objMSmodel = _userInformation.ApproveLesseeAreaDetails(model);
                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Area  Details Approved successfully";
                    }
                    else
                        ViewBag.msg = "Error ! while Approving Lessee License Area Details";
                }
                else
                {
                    model.UserID = 58;
                    model.CREATED_BY = 58;
                    //Rejection Profile Code
                    // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    //  objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeAreaDetails-Reject", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID

                    objMSmodel = _userInformation.RejectLesseeAreaDetails(model);
                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Area  Details Rejected successfully";
                    }
                    else
                    {
                        ViewBag.msg = "Error ! while Rejecting Lessee License Area Details";
                        //return Redirect("~/DMO/LicenseeProfileRequest/Index");
                    }
                }
            }
            return RedirectToAction("LeaseInformationDetails");
        }
        public JsonResult FillDistrict(string StateID)
        {
            UserInformationEF model = new UserInformationEF();
            model.STATE_ID = Convert.ToInt32(StateID);
            try
            {
                var x = _userInformation.GetDistrictList(model);

                if (x.DistrictLst != null)
                {
                    //ViewBag.ViewDistrictList
                    var SList = x.DistrictLst.ToList();
                    return Json(SList);
                }
                else
                {
                    var SList = Enumerable.Empty<SelectListItem>();
                    return Json(SList);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                model = null;
            }

        }
        public JsonResult FillTehsil(string DistId, string StateId)
        {
            UserInformationEF model = new UserInformationEF();
            model.STATE_ID = Convert.ToInt32(StateId);
            model.DISTRICT_ID = Convert.ToInt32(DistId);
            try
            {
                var x = _userInformation.GetTehsilList(model);

                if (x.TehsilLst != null)
                {
                    //ViewBag.ViewDistrictList
                    var SList = x.TehsilLst.ToList();
                    return Json(SList);
                }
                else
                {
                    var SList = Enumerable.Empty<SelectListItem>();
                    return Json(SList);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                model = null;
            }

        }
        public JsonResult FillVillage(string DistId, string StateId, string TehsilId)
        {
            UserInformationEF model = new UserInformationEF();
            model.STATE_ID = Convert.ToInt32(StateId);
            model.DISTRICT_ID = Convert.ToInt32(DistId);
            model.TEHSIL_FOREST_DIVISION = Convert.ToInt32(TehsilId);
            try
            {
                var x = _userInformation.GetVillageList(model);

                if (x.VillageLst != null)
                {
                    //ViewBag.ViewDistrictList
                    var SList = x.VillageLst.ToList();
                    return Json(SList);
                }
                else
                {
                    var SList = Enumerable.Empty<SelectListItem>();
                    return Json(SList);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                model = null;
            }

        }
        public IActionResult MineralInformation(int? id)
        {
            UserInformationEF model = new UserInformationEF();
            if (id == null)
            {
                model.UserID = 58;
                var x = _userInformation.GetMineralCategory(model);
                if (x.MineralLst != null)
                {
                    ViewBag.ViewMineralCategoryList = x.MineralLst.Select(c => new SelectListItem
                    {
                        Text = c.MINERAL_CATEGORY_NAME,
                        Value = c.MINERAL_CATEGORY_ID.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewMineralCategoryList = Enumerable.Empty<SelectListItem>();
                }
                // model = objRepository.GetLesseeInformationDetail(SessionWrapper.UserId);
                // ViewBag.completionCount = dbR.GetProfileCount(SessionWrapper.UserId);
            }
            else
            {
                //  model = objRepository.GetLesseeInformationDetail(id);
                //  ViewBag.completionCount = dbR.GetProfileCount(id.Value);
            }
            if (model == null)
                return View(new UserInformationEF());
            return View(model);

        }
        public JsonResult GetMinealList(int intMineralCatID)
        {
            UserInformationEF model = null;
            try
            {
                model = new UserInformationEF();
                model.UserID = 58;
                model.MINERAL_CATEGORY_ID = intMineralCatID;

                var x = _userInformation.GetMineralNameFromMineralType(model);
                var SList = x.MineralLst.ToList();
                //var UserList = SList.Where(item => item.Value != "68").ToList();
                return Json(SList);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                model = null;
            }

        }
        public IActionResult IBMDetails(int? id)
        {
            UserInformationEF model = new UserInformationEF();
            ApplicationResult objAppl = new ApplicationResult();
            ApplicationResult objProfile = new ApplicationResult();
            model.UserID = 58;
            if (id == null)
            {
                objAppl = _userInformation.GetLicenseeIBMDetail(model);
                if (objAppl != null)
                {
                    foreach (var app in objAppl.IBMDetailsLst)
                    {
                        model.IBM_NUMBER = Convert.ToString(app.IBM_NUMBER);
                        model.LICENSEE_IBM_ID = Convert.ToInt32(app.LICENSEE_IBM_ID);
                        model.IBM_APPLICATION_NUMBER = Convert.ToString(app.IBM_APPLICATION_NUMBER);
                        model.STATUS = Convert.ToInt32(app.STATUS);
                        model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        model.IBM_APPLICATON_DATE = Convert.ToDateTime(app.IBM_APPLICATON_DATE);
                        model.FILE_IBM_REGISTRATION_FORM = Convert.ToString(app.FILE_IBM_REGISTRATION_FORM);
                        model.IBM_REGISTRATION_FORM_PATH = Convert.ToString(app.IBM_REGISTRATION_FORM_PATH);
                        model.Remarks = Convert.ToString(app.Remarks);

                    }
                }

                // ViewBag.completionCount = db.GetProfileCount(SessionWrapper.UserId);
            }
            else
            {
                model.UserID = Convert.ToInt32(id);
                objAppl = _userInformation.GetLicenseeIBMDetail(model);
                if (objAppl != null)
                {
                    foreach (var app in objAppl.ApplicationLst)
                    {
                        model.IBM_NUMBER = Convert.ToString(app.IBM_NUMBER);
                        model.IBM_APPLICATON_DATE = Convert.ToDateTime(app.IBM_APPLICATON_DATE);
                        model.FILE_IBM_REGISTRATION_FORM = Convert.ToString(app.FILE_IBM_REGISTRATION_FORM);
                        model.IBM_REGISTRATION_FORM_PATH = Convert.ToString(app.IBM_REGISTRATION_FORM_PATH);
                        model.Remarks = Convert.ToString(app.Remarks);

                    }
                }

                // ViewBag.completionCount = db.GetProfileCount(id.Value);
            }
            if (model == null)
                return View(new UserInformationEF());
            return View(model);
        }
        [HttpPost]
        public IActionResult IBMDetails(UserInformationEF model, string cmd, string approve, string reject, int? id, List<IFormFile> flRegistrationCopy)
        {
            var DD_DMO = "Forward To DD";

            if (model.SubResion == "Forward To DD")
            {
                cmd = "Forward To DD";
            }
            if (model.SubApprove == "Approve")
            {
                approve = "Approve";
            }
            if (model.SubReject == "Reject")
            {
                reject = "Reject";
            }

            if (ModelState.IsValid)
            {
                if (approve == null && reject == null)
                {
                    #region Upload File in flRegistrationCopy
                    long size = flRegistrationCopy.Sum(f => f.Length);
                    var filePaths = new List<string>();

                    int FileCount = 0;
                    foreach (var formFile in flRegistrationCopy)
                    {
                        if (formFile != null && formFile.Length > 0)
                        {
                            //foreach (var file in UploadFile)
                            //{
                            if (!string.IsNullOrEmpty(formFile.FileName))
                            {

                                string hosting = _hostingEnvironment.ContentRootPath;
                                string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                                var fileName = strName + "_" + formFile.FileName;

                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    formFile.CopyTo(stream);
                                }
                                model.IBM_REGISTRATION_FORM_PATH = path;
                                model.FILE_IBM_REGISTRATION_FORM = fileName;


                            }

                        }
                    }
                    #endregion
                    if (model.LICENSEE_IBM_ID == 0)
                    {
                        if (cmd == DD_DMO)
                        {
                            model.STATUS = 1;
                            model.UserID = 58;
                            model.UserLoginId = "1513081";
                            // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                            //   objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeIBMDetails-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                            objMSmodel = _userInformation.NewLicenseeIBMDetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "IBM Details forwarded to DD/DMO successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while forwarding IBM Details to DD/DMO";
                        }
                        else
                        {
                            model.STATUS = 0;
                            model.UserID = 58;
                            model.UserLoginId = "1513081";

                            objMSmodel = _userInformation.NewLicenseeIBMDetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "IBM Details Saved Successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while Saving IBM Details";
                        }
                    }
                    else
                    {
                        if (cmd == DD_DMO)
                        {
                            model.STATUS = 1;
                            model.UserID = 58;
                            model.UserLoginId = "1513081";
                            objMSmodel = _userInformation.UpdateLicenseeIBMDetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                                // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeIBMDetails-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                                ViewBag.msg = "IBM Details forwarded to DD/DMO successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while forwarding IBM Details to DD/DMO";
                        }
                        else
                        {
                            model.STATUS = 0;
                            model.UserID = 58;
                            model.UserLoginId = "1513081";
                            objMSmodel = _userInformation.UpdateLicenseeIBMDetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "IBM Details Updated Successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while Updating IBM Details";
                        }
                    }
                }
                else
                {
                    //Acceptance of Profile or Rejection of Profile

                    if (approve == "Approve")
                    {
                        model.UserID = 58;
                        model.UserLoginId = "1513081";
                        //Approved Profile Code
                        // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        //  objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeIBMDetails-Approve", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID

                        objMSmodel = _userInformation.ApproveLicenseeIBMDetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Lessee IBM Details Approved successfully";
                        }
                        else
                            ViewBag.msg = "Error ! while Approving Licensee IBM Details";
                    }
                    else
                    {
                        model.UserID = 58;
                        model.UserLoginId = "1513081";
                        //Rejection Profile Code
                        // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        //  objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeIBMDetails-Reject", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID

                        objMSmodel = _userInformation.RejectLicenseeIBMDetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Lessee IBM Details Rejected successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while Rejecting Lessee IBM Details";
                            //return Redirect("~/DMO/LicenseeProfileRequest/Index");
                        }
                    }
                }
                return RedirectToAction("IBMDetails");


            }
            return View(model);

        }
        public IActionResult MiningPlan(int? id)
        {
            UserInformationEF model = new UserInformationEF();
            ApplicationResult objAppl = new ApplicationResult();
            ProductionModel proModel = new ProductionModel();
            model.UserID = 58;
            try
            {
                var x = _userInformation.GetMiningPlanYearList(model);

                if (x.YearLst != null)
                {
                    ViewBag.ViewYearList = x.YearLst.Select(c => new SelectListItem
                    {
                        Text = c.YEAR,
                        Value = c.YEAR.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewYearList = Enumerable.Empty<SelectListItem>();
                }
                objAppl = _userInformation.GetMiningPlanData(model);

                List<ApplicationResult> List = new List<ApplicationResult>();

                if (objAppl != null)
                {
                    foreach (var app in objAppl.MiningPlanDetailsLst)
                    {
                        if (app.MP_APPROVE_DATE != null)
                            model.MP_APPROVE_DATE = Convert.ToDateTime(app.MP_APPROVE_DATE);
                        //  model.MP_EXPIRY_DATE = Convert.ToDateTime(app.MP_EXPIRY_DATE);
                        if (app.MP_VALID_FORM != null)
                            model.MP_VALID_FORM = Convert.ToDateTime(app.MP_VALID_FORM);
                        if (app.MP_VALID_TO != null)
                            model.MP_VALID_TO = Convert.ToDateTime(app.MP_VALID_TO);
                        if (app.STATUS != null)
                            model.STATUS = Convert.ToInt32(app.STATUS);
                        if (app.CREATED_BY != null)
                            model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        if (app.MP_APPROVAL_NO != null)
                            model.MP_APPROVAL_NO = Convert.ToString(app.MP_APPROVAL_NO);
                        if (app.MP_SOM_FilePath != null)
                            model.MP_SOM_FilePath = Convert.ToString(app.MP_SOM_FilePath);
                        if (app.MP_SOM_FilePath != null)
                            model.MP_SOM_FileName = Convert.ToString(app.MP_SOM_FileName);
                        if (app.Remarks != null)
                            model.Remarks = Convert.ToString(app.Remarks);
                        if (app.TodateIntimation != null)
                            model.MP_VALID_TO_INTIMATION = Convert.ToString(app.TodateIntimation);
                        if (app.EC_APPROVED_CAPACITY != null)
                            model.EC_APPROVED_CAPACITY = Convert.ToDecimal(app.EC_APPROVED_CAPACITY);

                    }
                    ViewBag.ViewList = objAppl.MiningPlanProductLst;
                    //if (objAppl != null)
                    //{
                    //    foreach (var app1 in objAppl.MiningPlanProductLst)
                    //    {
                    //        proModel.PRODUCTION = Convert.ToInt32(app1.PRODUCTION);



                    //        proModel.UNIT_ID = Convert.ToString(app1.UNIT_ID);
                    //        proModel.FromToYear = Convert.ToString(app1.FromToYear);

                    //       // pmodel.Add(ObjProductModel);


                    //    }
                    //}
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult MiningPlan(UserInformationEF model, string cmd, List<int> PRODUCTIONS, List<string> YEARS, List<string> Units, string approve, string reject, List<IFormFile> flApproval)
        {
            model.UserID = 58;
            model.CREATED_BY = 58;
            model.UserLoginId = "1513081";

            model.STATUS = 0;
            model.UserID = 58;
            model.UserLoginId = "1513081";
            model.ProductList = PRODUCTIONS;
            model.YearList = YEARS;
            model.UnitList = Units;
            ProductionModel _productModel;
            List<ProductionModel> _objListModel = new List<ProductionModel>();
            for (var j = 0; j < PRODUCTIONS.Count; j++)
            {
                _productModel = new ProductionModel();
                _productModel.PRODUCTION = PRODUCTIONS[j];
                _productModel.YEAR = YEARS[j];
                if (Units != null && Units.Count!=0)
                    _productModel.Units = Units[j];
                else
                    _productModel.Units = "0";
                _productModel.CREATED_BY = 58;
                _objListModel.Add(_productModel);
            }
            model.Product = (_objListModel != null) ? _objListModel : null;
            var checkDMO = "Forward To DD";

            if (model.SubResion == "Forward To DD")
            {
                cmd = "Forward To DD";
            }
            if (model.SubApprove == "Approve")
            {
                approve = "Approve";
            }
            if (model.SubReject == "Reject")
            {
                reject = "Reject";
            }

            if (approve == null && reject == null)
            {
                #region Upload File in flApproval
                long size = flApproval.Sum(f => f.Length);
                var filePaths = new List<string>();

              
                foreach (var formFile in flApproval)
                {
                    if (formFile != null && formFile.Length > 0)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(formFile.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                            var fileName = strName + "_" + formFile.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                formFile.CopyTo(stream);
                            }
                            model.MP_SOM_FilePath = path;
                            model.MP_SOM_FileName = fileName;


                        }

                    }
                }
                #endregion
               
                if (ModelState.IsValid)
                {
                    if (checkDMO == cmd)
                    {
                        model.STATUS = 1;
                        //CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        //objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeMiningPlan-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.SaveMiningPlanData(model);
                       // int totalResult = db.SaveData(model, PRODUCTIONS, YEARS, Units);

                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Lessee Mining Plan Details forwarded to DD/DMO successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            ViewBag.msg = "Lessee Mining Plan Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while forwarding Lessee Mining Plan Details to DD/DMO";
                        }
                    }
                    else
                    {
                        model.STATUS = 0;
                        objMSmodel = _userInformation.SaveMiningPlanData(model);

                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Lessee Mining Plan Details Saved successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            ViewBag.msg = "Lessee Mining Plan Details updated successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while Updating Lessee Mining Plan Details";
                        }
                    }
                }
            }
            else
            {

                //Acceptance of Profile o Rejection of Profile
                if (approve == "Approve")
                {
                    //Approved Profile Code
                    // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    //  objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeMiningPlan-Approve", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                    objMSmodel = _userInformation.ApproveLesseeMiningDetails(model);
                    //   Flag = db.ApproveLesseeMiningDetails(SessionWrapper.UserId, "APPROVE", model.miningPlan.CREATED_BY, model.Remarks);
                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Mining Plan Details Approved successfully";
                    }
                    else
                        ViewBag.msg = "Error ! while Approving Lessee Mining Plan Details";
                }
                else
                {
                    //Rejection Profile Code
                    // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    //objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeMiningPlan-Reject", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                    objMSmodel = _userInformation.RejectLesseeMiningDetails(model);
                    //     Flag = db.RejectLesseeMiningDetails(SessionWrapper.UserId, "REJECT", model.miningPlan.CREATED_BY, model.Remarks);
                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Mining Plan Details Rejected successfully";
                    }
                    else
                    {
                        ViewBag.msg  = "Error ! while Rejecting Lessee Mining Plan Details";
                       // return Redirect("~/DMO/LesseeProfileRequest/Index");
                    }
                }
            }


            return RedirectToAction("MiningPlan");
        }

        public IActionResult ForestClearenceDetails(int? id)
        {
            UserInformationEF model = new UserInformationEF();
            ApplicationResult objAppl = new ApplicationResult();
            ApplicationResult objProfile = new ApplicationResult();
            model.UserID = 58;
            if (id == null)
            {
                objAppl = _userInformation.GetForestClearence(model);
                if (objAppl != null)
                {
                    foreach (var app in objAppl.ForestClearenceLst)
                    {
                        model.FC_APPROVAL_NUMBER = Convert.ToString(app.FC_APPROVAL_NUMBER);
                        model.FC_LETTER_FILE_NAME = Convert.ToString(app.FC_LETTER_FILE_NAME);
                        model.FC_LETTER_FILE_PATH = Convert.ToString(app.FC_LETTER_FILE_PATH);
                        if (!(app.VALID_FROM is null))
                            model.VALID_FROM = Convert.ToDateTime(app.VALID_FROM);
                        if (!(app.VALID_TO is null))
                            model.VALID_TO = Convert.ToDateTime(app.VALID_TO);
                        model.TodateIntimation = Convert.ToString(app.TodateIntimation);
                        if (!(app.FC_APPROVAL_DATE is null))
                            model.FC_APPROVAL_DATE = Convert.ToDateTime(app.FC_APPROVAL_DATE);
                        model.STATUS = Convert.ToInt32(app.STATUS);
                        model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        model.Remarks = Convert.ToString(app.Remarks);

                    }
                }

                // ViewBag.completionCount = db.GetProfileCount(SessionWrapper.UserId);
            }
            else
            {
                objAppl = _userInformation.GetForestClearence(model);
                if (objAppl != null)
                {
                    foreach (var app in objAppl.ForestClearenceLst)
                    {
                        model.FC_APPROVAL_NUMBER = Convert.ToString(app.FC_APPROVAL_NUMBER);
                        model.FC_LETTER_FILE_NAME = Convert.ToString(app.FC_LETTER_FILE_NAME);
                        model.FC_LETTER_FILE_PATH = Convert.ToString(app.FC_LETTER_FILE_PATH);
                        model.VALID_FROM = Convert.ToDateTime(app.VALID_FROM);
                        model.VALID_TO = Convert.ToDateTime(app.VALID_TO);
                        model.TodateIntimation = Convert.ToString(app.TodateIntimation);
                        model.FC_APPROVAL_DATE = Convert.ToDateTime(app.FC_APPROVAL_DATE);
                        model.STATUS = Convert.ToInt32(app.STATUS);
                        model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        model.Remarks = Convert.ToString(app.Remarks);

                    }
                }
                //ViewBag.completionCount = dbR.GetProfileCount(id.Value);
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult ForestClearenceDetails(UserInformationEF model, string cmd, string approve, string reject, List<IFormFile> flFCLetter)
        {
            var checkDMO = "Forward To DD";

            if (model.SubResion == "Forward To DD")
            {
                cmd = "Forward To DD";
            }
            if (model.SubApprove == "Approve")
            {
                approve = "Approve";
            }
            if (model.SubReject == "Reject")
            {
                reject = "Reject";
            }
            if (approve == null && reject == null)
            {
                #region Upload File in flFCLetter
                long size = flFCLetter.Sum(f => f.Length);
                var filePaths = new List<string>();

                int FileCount = 0;
                foreach (var formFile in flFCLetter)
                {
                    if (formFile != null && formFile.Length > 0)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(formFile.FileName))
                        {

                            string hosting = _hostingEnvironment.ContentRootPath;
                            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                            var fileName = strName + "_" + formFile.FileName;

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                formFile.CopyTo(stream);
                            }
                            model.FC_LETTER_FILE_PATH = path;
                            model.FC_LETTER_FILE_NAME = fileName;
                        }

                    }
                }
                #endregion
                if (ModelState.IsValid)
                {
                    if (checkDMO == cmd)
                    {
                        model.STATUS = 1;
                        model.UserID = 58;
                        model.CREATED_BY = 58;
                        // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeForestClearanceMaster-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID

                        objMSmodel = _userInformation.SaveForestClearenceDetails(model);

                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Lessee Forest Clearance Details forwarded to DD/DMO successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            ViewBag.msg = "Lessee Forest Clearance Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while forwarding Lessee Forest Clearance Details to DD/DMO";
                        }
                    }
                    else
                    {
                        model.STATUS = 0;
                        model.UserID = 58;
                        model.CREATED_BY = 58;
                        objMSmodel = _userInformation.SaveForestClearenceDetails(model);

                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Lessee Forest Clearance Details Saved successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            ViewBag.msg = "Lessee Forest Clearance Details updated successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while Updating Lessee Forest Clearance Details";
                        }
                    }
                }
            }
            else
            {
                //Acceptance of Profile o Rejection of Profile
                if (approve == "Approve")
                {
                    model.UserID = 58;
                    model.CREATED_BY = 58;

                    //Approved Profile Code
                    //  CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeForestClearanceMaster-Approve", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                    objMSmodel = _userInformation.ApproveLesseeForestDetails(model);
                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Forest Clearance Details Approved successfully";
                    }
                    else
                        ViewBag.msg = "Error ! while Approving Lessee Forest Clearance Details";
                }
                else
                {
                    model.UserID = 58;
                    model.CREATED_BY = 58;
                    //Rejection Profile Code

                    // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                    //objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeForestClearanceMaster-Reject", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                    objMSmodel = _userInformation.RejectLesseeForestDetails(model);
                    if (objMSmodel.Satus == "1")
                    {
                        ViewBag.msg = "Lessee Forest Clearance Details Rejected successfully";
                    }
                    else
                    {
                        ViewBag.msg = "Error ! while Rejecting Lessee Forest Clearance Details";
                        //return Redirect("~/DMO/LesseeProfileRequest/Index");
                    }
                }
            }
            return RedirectToAction("ForestClearenceDetails");
        }
        public IActionResult EnvironmentClearanceDetails(int? id)
        {
            UserInformationEF model = new UserInformationEF();
            ApplicationResult objAppl = new ApplicationResult();
            ApplicationResult objProfile = new ApplicationResult();
            model.UserID = 58;
            if (id == null)
            {
                objAppl = _userInformation.GetLicenseeEnvDetail(model);
                if (objAppl != null)
                {
                    foreach (var app in objAppl.EnvClearenceLst)
                    {
                        if (!(app.CREATED_BY is null))
                        {
                            model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        }
                        if (!(app.LICENSEE_EC_ID is null))
                        {
                            model.LICENSEE_EC_ID = Convert.ToInt32(app.LICENSEE_EC_ID);
                        }
                        if (!(app.EC_ORDRER_NUMBER is null))
                        {
                            model.EC_ORDRER_NUMBER = Convert.ToString(app.EC_ORDRER_NUMBER);
                        }
                        if (!(app.EC_CLEARANCE_PATH is null))
                        {
                            model.EC_CLEARANCE_PATH = Convert.ToString(app.EC_CLEARANCE_PATH);
                        }
                        if (!(app.FILE_EC_CLEARANCE is null))
                        {
                            model.FILE_EC_CLEARANCE = Convert.ToString(app.FILE_EC_CLEARANCE);
                        }
                        if (!(app.STATUS is null))
                        {
                            model.STATUS = Convert.ToInt32(app.STATUS);
                        }
                        if (!(app.EC_APPLICATON_DATE is null))
                        {
                            model.EC_APPLICATON_DATE = Convert.ToDateTime(app.EC_APPLICATON_DATE);
                        }


                        if (!(app.EC_VALID_TO is null))
                        {
                            model.EC_VALID_TO = Convert.ToDateTime(app.EC_VALID_TO);
                        }

                        if (!(app.EC_VALID_FROM is null))
                        {
                            model.EC_VALID_FROM = Convert.ToDateTime(app.EC_VALID_FROM);
                        }

                        if (!(app.EC_APPROVED_CAPACITY is null))
                        {
                            model.EC_APPROVED_CAPACITY = Convert.ToDecimal(app.EC_APPROVED_CAPACITY);
                        }
                        else
                        {
                            model.EC_APPROVED_CAPACITY = 0;
                        }
                        if (!(app.EC_APPLICATON_DATE is null))
                        {
                            model.EC_APPLICATON_DATE = Convert.ToDateTime(app.EC_APPLICATON_DATE);
                        }
                        if (!(app.Remarks is null))
                        {
                            model.Remarks = Convert.ToString(app.Remarks);
                        }
                        if (!(app.TodateIntimation is null))
                            model.VALID_TO_INTIMATION = Convert.ToString(app.TodateIntimation);
                    }
                }
                //ViewBag.completionCount = db.GetProfileCount(SessionWrapper.UserId);
            }
            else
            {
                model.UserID = Convert.ToInt32(id);
                objAppl = _userInformation.GetLicenseeEnvDetail(model);
                if (objAppl != null)
                {
                    foreach (var app in objAppl.EnvClearenceLst)
                    {
                        if (!(app.CREATED_BY is null))
                        {
                            model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        }
                        if (!(app.LICENSEE_EC_ID is null))
                        {
                            model.LICENSEE_EC_ID = Convert.ToInt32(app.LICENSEE_EC_ID);
                        }
                        if (!(app.EC_ORDRER_NUMBER is null))
                        {
                            model.EC_ORDRER_NUMBER = Convert.ToString(app.EC_ORDRER_NUMBER);
                        }
                        if (!(app.EC_CLEARANCE_PATH is null))
                        {
                            model.EC_CLEARANCE_PATH = Convert.ToString(app.EC_CLEARANCE_PATH);
                        }
                        if (!(app.FILE_EC_CLEARANCE is null))
                        {
                            model.FILE_EC_CLEARANCE = Convert.ToString(app.FILE_EC_CLEARANCE);
                        }
                        if (!(app.STATUS is null))
                        {
                            model.STATUS = Convert.ToInt32(app.STATUS);
                        }
                        if (!(app.EC_APPLICATON_DATE is null))
                        {
                            model.EC_APPLICATON_DATE = Convert.ToDateTime(app.EC_APPLICATON_DATE);
                        }


                        if (!(app.EC_VALID_TO is null))
                        {
                            model.EC_VALID_TO = Convert.ToDateTime(app.EC_VALID_TO);
                        }

                        if (!(app.EC_VALID_FROM is null))
                        {
                            model.EC_VALID_FROM = Convert.ToDateTime(app.EC_VALID_FROM);
                        }

                        if (!(app.EC_APPROVED_CAPACITY is null))
                        {
                            model.EC_APPROVED_CAPACITY = Convert.ToDecimal(app.EC_APPROVED_CAPACITY);
                        }
                        else
                        {
                            model.EC_APPROVED_CAPACITY = 0;
                        }
                        if (!(app.EC_APPLICATON_DATE is null))
                        {
                            model.EC_APPLICATON_DATE = Convert.ToDateTime(app.EC_APPLICATON_DATE);
                        }
                        if (!(app.Remarks is null))
                        {
                            model.Remarks = Convert.ToString(app.Remarks);
                        }
                        if (!(app.TodateIntimation is null))
                            model.VALID_TO_INTIMATION = Convert.ToString(app.TodateIntimation);
                    }
                }
                // ViewBag.completionCount = db.GetProfileCount(id.Value);
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult EnvironmentClearanceDetails(UserInformationEF model, string cmd, string approve, string reject, int? id, List<IFormFile> flApprovalLetter)
        {

            model.UserID = 58;
            model.CREATED_BY = 58;
            model.UserLoginId = "1513081";
            if (ModelState.IsValid)
            {
                var DD_DMO = "Forward To DD";

                if (model.SubResion == "Forward To DD")
                {
                    cmd = "Forward To DD";
                }
                if (model.SubApprove == "Approve")
                {
                    approve = "Approve";
                }
                if (model.SubReject == "Reject")
                {
                    reject = "Reject";
                }

                if (approve == null && reject == null)
                {
                    #region Upload File in flApprovalLetter
                    long size = flApprovalLetter.Sum(f => f.Length);
                    var filePaths = new List<string>();


                    foreach (var formFile in flApprovalLetter)
                    {
                        if (formFile != null && formFile.Length > 0)
                        {
                            //foreach (var file in UploadFile)
                            //{
                            if (!string.IsNullOrEmpty(formFile.FileName))
                            {

                                string hosting = _hostingEnvironment.ContentRootPath;
                                string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                                var fileName = strName + "_" + formFile.FileName;

                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    formFile.CopyTo(stream);
                                }
                                model.EC_CLEARANCE_PATH = path;
                                model.FILE_EC_CLEARANCE = fileName;
                            }

                        }
                    }
                    #endregion

                    if (model.LICENSEE_EC_ID == null || model.LICENSEE_EC_ID == 0)
                    {
                        if (cmd == DD_DMO)
                        {
                            model.STATUS = 1;

                            //  CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                            // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeEnvironmentClearance-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                            objMSmodel = _userInformation.NewLicenseeEnvDetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Environmental Clearance forwarded to DD/DMO successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while forwarding Environmental Clearance to DD/DMO";
                        }
                        else
                        {

                            model.STATUS = 0;
                            objMSmodel = _userInformation.NewLicenseeEnvDetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Environmental Clearance Saved Successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while Saving Environmental Clearance";
                        }
                    }
                    else
                    {
                        if (cmd == DD_DMO)
                        {
                            model.STATUS = 1;
                            // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                            //  objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeEnvironmentClearance-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                            objMSmodel = _userInformation.UpdateLicenseeEnvironmentDetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Environmental Clearance forwarded to DD/DMO successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while forwarding Environmental Clearance to DD/DMO";
                        }
                        else
                        {
                            model.STATUS = 0;
                            objMSmodel = _userInformation.UpdateLicenseeEnvironmentDetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Environmental Clearance Updated Successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while Updating Environmental Clearance";
                        }
                    }
                    return RedirectToAction("EnvironmentClearanceDetails");
                }
                else
                {
                    //Acceptance of Profile or Rejection of Profile

                    if (approve == "Approve")
                    {
                        //Approved Profile Code

                        // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        //  objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeEnvironmentClearance-Approve", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.ApproveLicenseeECDetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Environmental Clearance  Details Approved successfully";
                        }
                        else
                            ViewBag.msg = "Error ! while Approving Licensee Environmental Clearance  Details";
                    }
                    else
                    {
                        //Rejection Profile Code
                        // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        //  objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeEnvironmentClearance-Reject", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.RejectLicenseeECDetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Environmental Clearance  Details Rejected successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while Rejecting  Environmental Clearance  Details";
                            // return Redirect("~/DMO/LesseeProfileRequest/Index");
                        }

                    }

                }
                return RedirectToAction("EnvironmentClearanceDetails");

            }
            return View(model);
        }
        public IActionResult CTEDetails(int? id)
        {
            UserInformationEF model = new UserInformationEF();
            ApplicationResult objAppl = new ApplicationResult();
            ApplicationResult objProfile = new ApplicationResult();
            model.UserID = 58;
            if (id == null)
            {
                objAppl = _userInformation.GetLicenseeCTEDetail(model);
                if (objAppl != null)
                {
                    foreach (var app in objAppl.CTEDetailsLst)
                    {
                        if (!(app.CTE_ID is null))
                        {
                            model.CTE_ID = Convert.ToInt32(app.CTE_ID);
                        }
                        if (!(app.CTE_ORDER_DATE is null))
                        {
                            model.CTE_ORDER_DATE = Convert.ToDateTime(app.CTE_ORDER_DATE);
                        }
                        if (!(app.CTE_ORDER_NO is null))
                        {
                            model.CTE_ORDER_NO = Convert.ToString(app.CTE_ORDER_NO);
                        }
                        if (!(app.CTE_VALID_FROM is null))
                        {
                            model.CTE_VALID_FROM = Convert.ToDateTime(app.CTE_VALID_FROM);
                        }
                        if (!(app.CTE_VALID_TO is null))
                        {
                            model.CTE_VALID_TO = Convert.ToDateTime(app.CTE_VALID_TO);
                        }
                        if (!(app.CTE_LETTER_PATH is null))
                        {
                            model.CTE_LETTER_PATH = Convert.ToString(app.CTE_LETTER_PATH);
                        }
                        if (!(app.FILE_CTE_LETTER is null))
                        {
                            model.FILE_CTE_LETTER = Convert.ToString(app.FILE_CTE_LETTER);
                        }
                        if (!(app.Remarks is null))
                        {
                            model.Remarks = Convert.ToString(app.Remarks);
                        }
                        if (!(app.STATUS is null))
                        {
                            model.STATUS = Convert.ToInt32(app.STATUS);
                        }
                        if (!(app.CREATED_BY is null))
                        {
                            model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        }
                        if (!(app.TodateIntimation is null))
                            model.CTE_VALID_TO_INTIMATION = Convert.ToString(app.TodateIntimation);

                    }
                }
                //ViewBag.completionCount = db.GetProfileCount(SessionWrapper.UserId);
            }


            return View(model);
        }
        [HttpPost]
        public IActionResult CTEDetails(UserInformationEF model, string cmd, string approve, string reject, int? id, List<IFormFile> flCTELetter)
        {
            model.UserID = 58;
            model.CREATED_BY = 58;
            model.UserLoginId = "1513081";
            if (ModelState.IsValid)
            {
                var DD_DMO = "Forward To DD";

                if (model.SubResion == "Forward To DD")
                {
                    cmd = "Forward To DD";
                }
                if (model.SubApprove == "Approve")
                {
                    approve = "Approve";
                }
                if (model.SubReject == "Reject")
                {
                    reject = "Reject";
                }


                if (approve == null && reject == null)
                {
                    #region Upload File in flCTELetter
                    long size = flCTELetter.Sum(f => f.Length);
                    var filePaths = new List<string>();


                    foreach (var formFile in flCTELetter)
                    {
                        if (formFile != null && formFile.Length > 0)
                        {
                            //foreach (var file in UploadFile)
                            //{
                            if (!string.IsNullOrEmpty(formFile.FileName))
                            {

                                string hosting = _hostingEnvironment.ContentRootPath;
                                string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                                var fileName = strName + "_" + formFile.FileName;

                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    formFile.CopyTo(stream);
                                }
                                model.CTE_LETTER_PATH = path;
                                model.FILE_CTE_LETTER = fileName;
                            }

                        }
                    }
                    #endregion
                    if (model.CTE_ID == null || model.CTE_ID == 0)
                    {
                        if (cmd == DD_DMO)
                        {
                            model.STATUS = 1;
                            objMSmodel = _userInformation.NewLicenseeCTEDetail(model);
                           // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                           // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeCTEDetails-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID

                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Consent to Establish Details forwarded to DD/DMO successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while forwarding Consent to Establish Details to DD/DMO";
                        }
                        else
                        {

                            model.STATUS = 0;
                            objMSmodel = _userInformation.NewLicenseeCTEDetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Consent to Establish Details Saved Successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while Saving Consent to Establish Details";
                        }
                    }
                    else
                    {
                        if (cmd == DD_DMO)
                        {
                            model.STATUS = 1;
                            //  CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                            // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeCTEDetails-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                            objMSmodel = _userInformation.UpdateLicenseeCTEDetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Consent to Establish Details forwarded to DD/DMO successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while forwarding Consent to Establish Details to DD/DMO";
                        }
                        else
                        {
                            model.STATUS = 0;
                            objMSmodel = _userInformation.UpdateLicenseeCTEDetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Consent to Establish Details Updated Successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while Updating Consent to Establish Details ";
                        }
                    }

                }
                else
                {
                    //Acceptance of Profile or Rejection of Profile

                    if (approve == "Approve")
                    {
                        //Approved Profile Code

                        // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeCTEDetails-Approve", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.ApproveLicenseeCTEDetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Consent to Establish Details Approved successfully";
                        }
                        else
                            ViewBag.msg = "Error ! while Approving Licensee CTE Details";
                    }
                    else
                    {
                        //Rejection Profile Code

                        //CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeCTEDetails-Reject", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.RejectLicenseeCTEDetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Consent to Establish Details Rejected successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while Rejecting Licensee CTE Details";
                            //return Redirect("~/DMO/LesseeProfileRequest/Index");
                        }
                    }

                }
                return RedirectToAction("CTEDetails");

            }
            return View(model);
        }
        public IActionResult CTODetails(int? id)
        {
            UserInformationEF model = new UserInformationEF();
            ApplicationResult objAppl = new ApplicationResult();
            ApplicationResult objProfile = new ApplicationResult();
            model.UserID = 58;
            if (id == null)
            {
                objAppl = _userInformation.GetLicenseeCTODetail(model);
                if (objAppl != null)
                {
                    foreach (var app in objAppl.CTODetailsLst)
                    {
                        if (!(app.CREATED_BY is null))
                        {
                            model.CREATED_BY = Convert.ToInt32(app.CREATED_BY);
                        }
                        if (!(app.CTO_ID is null))
                        {
                            model.CTO_ID = Convert.ToInt32(app.CTO_ID);
                        }
                        if (!(app.CTO_ORDER_NO is null))
                        {
                            model.CTO_ORDER_NO = Convert.ToString(app.CTO_ORDER_NO);
                        }
                        if (!(app.CTO_ORDER_DATE is null))
                        {
                            model.CTO_ORDER_DATE = Convert.ToDateTime(app.CTO_ORDER_DATE);
                        }
                        if (!(app.CTO_VALID_FROM is null))
                        {
                            model.CTO_VALID_FROM = Convert.ToDateTime(app.CTO_VALID_FROM);
                        }
                        if (!(app.CTO_VALID_TO is null))
                        {
                            model.CTO_VALID_TO = Convert.ToDateTime(app.CTO_VALID_TO);
                        }
                        if (!(app.CTO_LETTER_PATH is null))
                        {
                            model.CTO_LETTER_PATH = Convert.ToString(app.CTO_LETTER_PATH);
                        }
                        if (!(app.FILE_CTO_LETTER is null))
                        {
                            model.FILE_CTO_LETTER = Convert.ToString(app.FILE_CTO_LETTER);
                        }
                        if (!(app.STATUS is null))
                        {
                            model.STATUS = Convert.ToInt32(app.STATUS);
                        }
                        if (!(app.TodateIntimation is null))
                            model.CTO_VALID_TO_INTIMATION = Convert.ToString(app.TodateIntimation);
                         if (!(app.Remarks is null))
                            model.Remarks = Convert.ToString(app.Remarks);

                    }
                }
                //ViewBag.completionCount = db.GetProfileCount(SessionWrapper.UserId);
            }


            return View(model);
        }
        [HttpPost]
        public IActionResult CTODetails(UserInformationEF model, string cmd, string approve, string reject, int? id, List<IFormFile> flCTOLetter)
        {
            model.UserID = 58;
            model.CREATED_BY = 58;
            model.UserLoginId = "1513081";
            if (ModelState.IsValid)
            {
                var DD_DMO = "Forward To DD";

                if (model.SubResion == "Forward To DD")
                {
                    cmd = "Forward To DD";
                }
                if (model.SubApprove == "Approve")
                {
                    approve = "Approve";
                }
                if (model.SubReject == "Reject")
                {
                    reject = "Reject";
                }


                if (approve == null && reject == null)
                {
                    #region Upload File in flCTOLetter
                    long size = flCTOLetter.Sum(f => f.Length);
                    var filePaths = new List<string>();


                    foreach (var formFile in flCTOLetter)
                    {
                        if (formFile != null && formFile.Length > 0)
                        {
                            //foreach (var file in UploadFile)
                            //{
                            if (!string.IsNullOrEmpty(formFile.FileName))
                            {

                                string hosting = _hostingEnvironment.ContentRootPath;
                                string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                                var fileName = strName + "_" + formFile.FileName;

                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    formFile.CopyTo(stream);
                                }
                                model.CTO_LETTER_PATH = path;
                                model.FILE_CTO_LETTER = fileName;
                            }

                        }
                    }
                    #endregion
                    if (model.CTO_ID == null || model.CTO_ID == 0)
                    {
                        if (cmd == DD_DMO)
                        {
                            model.STATUS = 1;

                            // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                            // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeCTODetails-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                            objMSmodel = _userInformation.NewLicenseeCTODetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Consent to Operate Details forwarded to DD/DMO successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while forwarding Consent to Operate Details to DD/DMO";
                        }
                        else
                        {

                            model.STATUS = 0;
                            objMSmodel = _userInformation.NewLicenseeCTODetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Consent to Operate Details Saved Successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while Saving Consent to Operate Details";
                        }
                    }
                    else
                    {
                        if (cmd == DD_DMO)
                        {
                            model.STATUS = 1;
                            objMSmodel = _userInformation.UpdateLicenseeCTODetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                               // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                               // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeCTODetails-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                                ViewBag.msg = "Consent to Operate Details forwarded to DD/DMO successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while forwarding Consent to Operate Details to DD/DMO";
                        }
                        else
                        {
                            model.STATUS = 0;
                            objMSmodel = _userInformation.UpdateLicenseeCTODetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Consent to Operate Details Updated Successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while Updating Consent to Operate Details";
                        }
                    }

                }
                else
                {
                    //Acceptance of Profile or Rejection of Profile

                    if (approve == "Approve")
                    {
                        //Approved Profile Code
                        //  CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        // objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeCTODetails-Approve", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.ApproveLicenseeCTODetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Consent to Operate Details Approved successfully";
                        }
                        else
                            ViewBag.msg = "Error ! while Approving Lessee CTO Details";
                    }
                    else
                    {
                        //Rejection Profile Code

                      //  CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                      //  objDSCResponse.getDSCResponse(model.DSCResponse, "LesseeCTODetails-Reject", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.RejectLicenseeCTODetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Consent to Operate Details Rejected successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while Rejecting Lessee CTO Details";
                           // return Redirect("~/DMO/LesseProfileRequest/Index");
                        }
                    }
                }
                return RedirectToAction("CTODetails");
            }
            return View(model);

        }
        public IActionResult AssessmentReport (int? id)
        {
            UserInformationEF model = new UserInformationEF();
            ApplicationResult objAppl = new ApplicationResult();
            ApplicationResult objProfile = new ApplicationResult();
            model.UserID = 58;
            if (id == null)
            {
                objAppl = _userInformation.GetAssesmentReport(model);
                if (objAppl != null)
                {
                    foreach (var app in objAppl.AssessmentRptLst)
                    {
                        if (!(app.AssessmentID is null))
                            model.AssessmentID = Convert.ToInt32(app.AssessmentID);
                        if (!(app.Assessmentdate is null))
                            model.Assessmentdate = Convert.ToDateTime(app.Assessmentdate);
                        if (!(app.RecoveryReportFilePath is null))
                            model.RecoveryReportFilePath = Convert.ToString(app.RecoveryReportFilePath);
                        if (!(app.RecoveryReportFileName is null))
                            model.RecoveryReportFileName = Convert.ToString(app.RecoveryReportFileName);
                        if (!(app.HalfYearAssesmentDate is null))
                            model.HalfYearAssesmentDate = Convert.ToDateTime(app.HalfYearAssesmentDate);
                        if (!(app.HalfyearassesmentFileName is null))
                            model.HalfyearassesmentFileName = Convert.ToString(app.HalfyearassesmentFileName);
                        if (!(app.HalfyearassesmentFilePath is null))
                            model.HalfyearassesmentFilePath = Convert.ToString(app.HalfyearassesmentFilePath);

                        if (!(app.STATUS is null))
                            model.STATUS = Convert.ToInt32(app.STATUS);
                        if (!(app.Remarks is null))
                            model.Remarks = Convert.ToString(app.Remarks);
                    }
                }
                //ViewBag.completionCount = db.GetProfileCount(SessionWrapper.UserId);
            }


            return View(model);
        }
        [HttpPost]
        public IActionResult AssessmentReport(UserInformationEF model, string cmd, string approve, string reject, int? id, List<IFormFile> flRRAssessment, List<IFormFile> flHYAssessment)
        {
            ApplicationResult objAppl = new ApplicationResult();
            model.UserID = 58;
            model.CREATED_BY = 58;
            model.UserLoginId = "1513081";
            if (ModelState.IsValid)
            {
                var DD_DMO = "Forward To DD";

                if (model.SubResion == "Forward To DD")
                {
                    cmd = "Forward To DD";
                }
                if (model.SubApprove == "Approve")
                {
                    approve = "Approve";
                }
                if (model.SubReject == "Reject")
                {
                    reject = "Reject";
                }


                if (approve == null && reject == null)
                {
                    #region Upload File in flRRAssessment
                    long size = flRRAssessment.Sum(f => f.Length);
                    var filePaths = new List<string>();


                    foreach (var formFile in flRRAssessment)
                    {
                        if (formFile != null && formFile.Length > 0)
                        {
                            //foreach (var file in UploadFile)
                            //{
                            if (!string.IsNullOrEmpty(formFile.FileName))
                            {

                                string hosting = _hostingEnvironment.ContentRootPath;
                                string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                                var fileName = strName + "_" + formFile.FileName;

                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    formFile.CopyTo(stream);
                                }
                                model.RecoveryReportFilePath = path;
                                model.RecoveryReportFileName = fileName;
                            }

                        }
                    }
                    #endregion
                    #region Upload File in flHYAssessment
                     size = flHYAssessment.Sum(f => f.Length);
                     filePaths = new List<string>();


                    foreach (var formFile in flHYAssessment)
                    {
                        if (formFile != null && formFile.Length > 0)
                        {
                            //foreach (var file in UploadFile)
                            //{
                            if (!string.IsNullOrEmpty(formFile.FileName))
                            {

                                string hosting = _hostingEnvironment.ContentRootPath;
                                string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var path = Path.Combine(hosting, "wwwroot/Upload", strName + formFile.FileName);
                                var fileName = strName + "_" + formFile.FileName;

                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    formFile.CopyTo(stream);
                                }
                                model.HalfyearassesmentFilePath = path;
                                model.HalfyearassesmentFileName = fileName;
                            }

                        }
                    }
                    #endregion
                   
                    if (model.AssessmentID == null || model.AssessmentID == 0)
                    {
                        if (cmd == DD_DMO)
                        {
                            model.STATUS = 1;
                            //  CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                            // objDSCResponse.getDSCResponse(model.DSCResponse, "AssessmentReport-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                            objMSmodel = _userInformation.NewAssesmentReport(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Assessment Details forwarded to DD/DMO successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while forwarding Assessment Details to DD/DMO";
                        }
                        else
                        {

                            model.STATUS = 0;
                            objMSmodel = _userInformation.NewAssesmentReport(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Assessment Details Saved Successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while Saving Assessment Details";
                        }
                    }
                    else
                    {
                        if (cmd == DD_DMO)
                        {
                            model.STATUS = 1;
                            objMSmodel = _userInformation.UpdateAssessmentReport(model);
                            if (objMSmodel.Satus == "1")
                            {
                                model.STATUS = 1;
                               // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                               // objDSCResponse.getDSCResponse(model.DSCResponse, "AssessmentReport-Forward", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                                ViewBag.msg = "Assessment Details forwarded to DD/DMO successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while forwarding Assessment Details to DD/DMO";
                        }
                        else
                        {
                            model.STATUS = 0;
                            objMSmodel = _userInformation.UpdateAssessmentReport(model);
                            if (objMSmodel.Satus == "1")
                            {
                                ViewBag.msg = "Assessment Details Updated Successfully";
                            }
                            else
                                ViewBag.msg = "Error ! while Updating Assessment Details ";
                        }
                    }
                }
                else
                {
                    //Acceptance of Profile or Rejection of Profile

                    if (approve == "Approve")
                    {
                        //Approved Profile Code

                        // CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        // objDSCResponse.getDSCResponse(model.DSCResponse, "AssessmentReport-Approve", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.ApproveLicenseeCTEDetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Assessment Details Approved successfully";
                        }
                        else
                            ViewBag.msg = "Error ! while Approving Assessment Details";
                    }
                    else
                    {
                        //Rejection Profile Code

                        //  CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        //  objDSCResponse.getDSCResponse(model.DSCResponse, "AssessmentReport-Reject", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        objMSmodel = _userInformation.RejectLicenseeCTEDetails(model);
                        if (objMSmodel.Satus == "1")
                        {
                            ViewBag.msg = "Assessment Details Rejected successfully";
                        }
                        else
                        {
                            ViewBag.msg = "Error ! while Rejecting Assessment Details";
                           // return Redirect("~/DMO/LesseeProfileRequest/Index");
                        }
                    }

                }
                if (id != null && id != 0)
                {
                    model.UserID = id.Value;
                    objAppl = _userInformation.GetAssesmentReport(model);
                }
                else
                {
                    model.UserID = 58;
                    objAppl = _userInformation.GetAssesmentReport(model);
                }
                return RedirectToAction("AssessmentReport");
            }
            return View(model);
        }
    }
}
