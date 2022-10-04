using DotNetIntegrationKit;
using IntegrationApp.ActionFilter;
using IntegrationApp.Areas.Payment.Models.LicensePaymentDetails;
using IntegrationApp.Areas.Payment.Models.MineralConcession;
using IntegrationApp.Helper;
using IntegrationApp.Models.SBIEncryptDecryptKey;
using IntegrationApp.Web;
using IntegrationEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class MineralConcessionPaymentController : Controller
    {
        IMineralConcessionModel _objIticketmodel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        List<PreferredBidder> objraise = null;
        PreferredBidder objticket = null;
        private readonly ILicensePaymentModel licensePaymentModel;
        RequestURL objRequestURL = new RequestURL();
        private readonly IsbiIncriptDecript sbiIncriptDecript;
        public MineralConcessionPaymentController(IMineralConcessionModel objtickettypemastermodel, IHostingEnvironment hostingEnvironment, IConfiguration configuration, ILicensePaymentModel licensePaymentModel, IsbiIncriptDecript sbiIncriptDecript)
        {
            _objIticketmodel = objtickettypemastermodel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            this.licensePaymentModel = licensePaymentModel;
            this.sbiIncriptDecript = sbiIncriptDecript;
        }
        /// <summary>
        /// Added by suroj first installment label data fetch
        /// </summary>
        /// <param name="id"></param>
        /// <returns
        /// ></returns>
        [SkipImportantTask]
        public ActionResult Submission(string id)
        {
            LeaseApplicationModel objmodel = new LeaseApplicationModel();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = Convert.ToInt16(profile.UserId);// Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                objmodel.LesseeLOI = Convert.ToInt32(id);
                objmodel = _objIticketmodel.GetFirstinstallment(objmodel);
                if (objmodel.DateOfLOI != "")
                {
                    objmodel.DateOfLOI = Convert.ToDateTime(objmodel.DateOfLOI).ToString("dd/MM/yyyy");
                }
                return View(objmodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
            }
        }
        [HttpPost]
        public ActionResult Submission(LeaseApplicationModel model, string totalPayable, string PaymentMode, string PaymentBank, string TransactionalID, string ChallanNumber,
           DateTime? ChallanDate, string PMode, string NetBanking_mode, List<int> DocId,string BankSelection,string ModeSelection)
        {
            PaymentModel payment = new PaymentModel();
            LicensePaymentDetail licensePaymentDetail = new LicensePaymentDetail();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            licensePaymentDetail.UserId = profile.UserId;//30742;
            licensePaymentDetail.UserLoginId = profile.UserLoginId;//1599804;
            licensePaymentDetail.LicenseAppId = model.LesseeLOI;
            licensePaymentDetail.TotalPayment = model.totalPayable;
            licensePaymentDetail.PaymentBank = (model.PaymentBank == "DEMOBANK" ? "SBI" : model.PaymentBank);
            licensePaymentDetail.PaymentMode = model.PaymentMode;
            //messageEF = licensePaymentModel.GetLicensePaymentDetails(licensePaymentDetail);
            //if (string.IsNullOrEmpty(messageEF.Satus))
            //{
            //    TempData["AckMessage"] = "Payment cannot done.Please try again!";
            //    return Redirect(_objKeyList.Value.Redirecturl + "Licensee/LicenseApplication/LicensePaymentProcess?LicenseAppId=" + licenseApplication.LicenseAppId);
            //}
            //else
            //{

            string response = string.Empty;
            //licensePaymentDetail.PaymentRefId = messageEF.Satus;
            payment = licensePaymentModel.GetLicensePaymentGateway(licensePaymentDetail);

            #region SBI
            if (BankSelection == "SBI")
            {
                var SBIRequestString = string.Empty;


                objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value); //Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                objRequestURL.LogFilePath = string.Empty;
                objRequestURL.ErrorFile = string.Empty;

                //payment.TPSLTXNID = licensePaymentDetail.PaymentRefId;
                payment.TPSLTXNID = model.ClientTransactionID;
                payment.MerchantTxnRefNumber= model.ClientTransactionID;
                payment.Amount = Convert.ToDecimal(totalPayable).ToString("0.00");
                payment.Shoppingcartdetails = "TEST_" + totalPayable + "_0.0";


                SBIRequestString = "ApplicantName=" + payment.customerName.ToString() //ApplicantName
                                                      + "|EmailId=" + payment.Email.ToString() //EmailId
                                                      + "|MobileNo=" + payment.mobileNo.ToString() //MobileNo
                                                      //+ "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                      + "|CLNT_TXN_NO=" + model.ClientTransactionID.ToString()
                                                      + "|Amount=" + Convert.ToDecimal(totalPayable).ToString("0.00") //TXN_AMOUNT
                                                      + "|Payment_Bifurcation=" + payment.ITC
                                                      + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);

                string checksum = sbiIncriptDecript.GetSHA256(SBIRequestString);
                SBIRequestString += "|checkSum=" + checksum;
                string SBIPostRequest = sbiIncriptDecript.EncryptWithKey(SBIRequestString);

                string SBIURL = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value);

                #region Insert Payment Request Data
                payment.UserId = profile.UserId;
                payment.returnURL = Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);
                payment.S2SReturnURL = Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURL").Value);
                payment.PropertyPath = Convert.ToString(configuration.GetSection("Path").GetSection("SBIPropertyPath").Value);
                payment.PaymentEncryptedData = SBIPostRequest;
                payment.Currencycode = "INR";
                licensePaymentModel.InsertLicensePaymentRequest(payment);
                #endregion

                var msgdisp = "<html><form name='s1_2' id='s1_2' action='" + SBIURL + "' method='post'> ";
                msgdisp += "<input name='encdata' value='" + SBIPostRequest + "' type='hidden'>";
                msgdisp += "<input name='merchant_code' value='MINERAL_DEPT' type='hidden'>";
                msgdisp += "<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();";
                msgdisp += "</script>";
                msgdisp += "<script language='javascript' >";
                msgdisp += "</ script >";
                msgdisp += "</form></html> ";
                return Content(msgdisp, "text/html");
            }
            #endregion


            MessageEF objMessage = new MessageEF();
            //try
            //{
            //    string uniqueFileName = string.Empty;
            //    string filePath = string.Empty;
            //    if (model.MLA != null)
            //    {
            //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "MLApplication");
            //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.MLA.FileName;
            //        filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //        using (var fileStream = new FileStream(filePath, FileMode.Create))
            //            model.MLA.CopyTo(fileStream);

            //        model.MLApplication = uniqueFileName;
            //    }
            //    model.MLA = null;

            //    //when STATUS=102
            //    if (model.WorkingPermissionFile != null)
            //    {
            //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\WorkingPermission");
            //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.WorkingPermissionFile.FileName;
            //        filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //        using (var fileStream = new FileStream(filePath, FileMode.Create))
            //            model.WorkingPermissionFile.CopyTo(fileStream);

            //        model.WorkingPermission = uniqueFileName;
            //    }
            //    model.WorkingPermissionFile = null;
            //    //when STATUS=102
            //    if (model.MDPAFile != null)
            //    {
            //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\MDPA");
            //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.MDPAFile.FileName;
            //        filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //        using (var fileStream = new FileStream(filePath, FileMode.Create))
            //            model.MDPAFile.CopyTo(fileStream);

            //        model.MDPA = uniqueFileName;
            //    }
            //    model.MDPAFile = null;
            //    if (model.LeaseDeedAgreementFile != null)
            //    {
            //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\LeaseDeedAgreement");
            //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.LeaseDeedAgreementFile.FileName;
            //        filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //        using (var fileStream = new FileStream(filePath, FileMode.Create))
            //            model.LeaseDeedAgreementFile.CopyTo(fileStream);

            //        model.LeaseDeedAgreement = uniqueFileName;
            //    }
            //    model.LeaseDeedAgreementFile = null;
            //    //UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            //    model.UserId = Convert.ToInt16(profile.UserId);//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);

                objMessage = _objIticketmodel.AddPayment(model);
            //    objMessage.Satus = "1";
            //    if (objMessage.Satus == "1" && model.SpMode == "FirstInstallment")
            //    {
            //        TempData["LOIAckMessage"] = "First Installment Done successfully.";
            //        return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

            //    }
            //    //if (objMessage.Satus == "1" && model.SpMode == "DGMForward")
            //    //{
            //    //    try
            //    //    {
            //    //        MineralConcessionApp.Areas.MajorMineral.Controllers.DSCResponseController objDSCResponse = new DSCResponseController(_objIticketmodel, hostingEnvironment, configuration);
            //    //        objDSCResponse.getDSCResponse(model.DSCResponse, "LOI-DGMForward-ToGov", Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]));
            //    //        //_objIticketmodel.getDSCResponse(model.DSCResponse, "LOI-DGMForward-ToGov", Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]); // Response, For which purpose DSC Used , Return ID

            //    //    }
            //    //    catch (Exception)
            //    //    {
            //    //    }
            //    //    TempData["LOIAckMessage"] = "Preferred Bidder Order Approved.";
            //    //    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

            //    //}
            //    if (objMessage.Satus == "1" && model.SpMode == "GovApprove")
            //    {
            //        TempData["LOIAckMessage"] = "Issuance of LOI Holder Approved.";
            //        return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

            //    }
            //    if (objMessage.Satus == "1" && model.SpMode == "GovReject")
            //    {
            //        TempData["LOIAckMessage"] = "Issuance of LOI Holder Rejected.";
            //        return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

            //    }
            //    //else if (objMessage.Satus == "1" && model.SpMode == "Forward")
            //    //{
            //    //    MineralConcessionApp.Areas.MajorMineral.Controllers.DSCResponseController objDSCResponse = new DSCResponseController(_objIticketmodel, hostingEnvironment, configuration);
            //    //    objDSCResponse.getDSCResponse(model.DSCResponse, "LOI-DGMForward-ToHolder", Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]));

            //    //    TempData["LOIAckMessage"] = "Request Forwarded successfully";
            //    //    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
            //    //}
            //    else if (objMessage.Satus == "1" && model.SpMode == "Issuance Forwarding")
            //    {


            //        TempData["LOIAckMessage"] = "Issuance Forwarded successfully";
            //        return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
            //    }
            //    else if (objMessage.Satus == "1" && model.SpMode == "Issuance Approval Approve")
            //    {


            //        TempData["LOIAckMessage"] = "Issuance Approval successfully";
            //        return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
            //    }
            //    else if (objMessage.Satus == "1" && model.SpMode == "Issuance Approval Reject")
            //    {


            //        TempData["LOIAckMessage"] = "Issuance Reject successfully";
            //        return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
            //    }
            //    else if (objMessage.Satus == "1" && model.SpMode == "Issuance")
            //    {


            //        TempData["LOIAckMessage"] = "Issuance of Successful Bidder Order successfully";
            //        return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
            //    }
            //    else if (objMessage.Satus == "1" && model.SpMode == "MDPA")
            //    {


            //        TempData["LOIAckMessage"] = "Your request submitted successfully";
            //        return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
            //    }
            //    else if (objMessage.Satus == "1" && model.SpMode == "ThirdInstallment")
            //    {


            //        TempData["LOIAckMessage"] = "Your ThirdInstallment submitted successfully";
            //        return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
            //    }
            //    else if (objMessage.Satus == "1" && model.SpMode == "LeaseDeed")
            //    {


            //        TempData["LOIAckMessage"] = "Your request submitted successfully";
            //        return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{

            //    objMessage = null;
            //}
            return View();
        }
    }
}
