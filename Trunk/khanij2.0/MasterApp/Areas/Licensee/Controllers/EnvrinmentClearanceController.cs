// ***********************************************************************
//  Controller Name          : EnvrinmentClearance
//  Desciption               : EnvrinmentClearance Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 25 June 2021
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Microsoft.AspNetCore.Hosting;
using MasterApp.Areas.Licensee.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MasterApp.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Licensee.Controllers
{
    [Area("Licensee")]
    public class EnvrinmentClearanceController : Controller
    {
        #region Global Declaration
        IUserInformationLicenseeModel _userInformation;
        MessageEF objMSmodel = new MessageEF();
        List<ECDetails> objlistmodel = new List<ECDetails>();
        public object JsonRequestBehavior { get; private set; }
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        #endregion
        /// <summary>
        ///Create Dependency Injection IUserInformationLicenseeModel, IHostingEnvironment
        /// </summary>
        /// <param name="objUserInformation"></param>
        /// <param name="hostingEnvironment"></param>
        public EnvrinmentClearanceController(IUserInformationLicenseeModel objUserInformation, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _userInformation = objUserInformation;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        public async Task<ActionResult> ECDetail()
        {
            ECDetails model = new ECDetails();
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            LicenseeResult licenseeResult = new LicenseeResult();
            //int UserId = 461;
            try
            {
                if (session.UserId != 0)
                {
                    model.UserLoginId = "1";
                    model.UserID = session.UserId;
                    model.CREATED_BY = session.UserId;
                    ViewBag.Minerals = await GetmineralNameList(session.UserId);
                    licenseeResult = await _userInformation.GetECDetails(model);
                    //objAppl.ECDetailsList = _userInformation.GetECDetails(model).ECDetailsList;
                    if (licenseeResult.ECDetailsList != null)
                    {
                        return View(licenseeResult.ECDetailsList.FirstOrDefault());
                    }
                    else
                    {
                        return View(new ECDetails());
                    }

                }
                else
                {
                    return View(new ECDetails());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { model = null; };

        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ECDetail(ECDetails model, string cmd, string delete, IFormFile selectedFile)
        {
            try
            {
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                

                #region Server Side Validation
                if (string.IsNullOrEmpty(model.EC_ORDRER_NUMBER))
                {
                    ModelState.AddModelError("EC_ORDRER_NUMBER", "EC Order Number is required");
                }
                #endregion

                if (ModelState.IsValid)
                {
                    #region Upload File 

                    if (selectedFile != null && selectedFile.Length > 0)
                    {

                        if (!string.IsNullOrEmpty(selectedFile.FileName))
                        {
                            string hosting = _hostingEnvironment.ContentRootPath;
                            string wwwPath = this._hostingEnvironment.WebRootPath;
                            string strName = DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var fileName = strName + "_" + selectedFile.FileName;
                            filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("ECPath"), fileName);
                            var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("ECPath"));
                            string UploadFolderPath = Path.Combine(RootPath, fileName);
                            if (!Directory.Exists(RootPath))
                                Directory.CreateDirectory(RootPath);
                            DirectoryInfo di = new DirectoryInfo(RootPath);
                            di.Attributes = FileAttributes.Normal;
                            using (var stream = new FileStream(UploadFolderPath, FileMode.Create))
                            {
                                selectedFile.CopyTo(stream);
                            }
                            model.EC_CLEARANCE_PATH = filePath;
                            model.FILE_EC_CLEARANCE = fileName;
                        }

                    }
                    #endregion
                    var checkDMO = "Forward To DD";
                    if (model.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (cmd == checkDMO)
                    {
                        model.STATUS = 1;
                        model.UserID = session.UserId;
                        model.CREATED_BY = session.UserId;
                        model.UserLoginId = session.UserLoginId.ToString();
                        objMSmodel = _userInformation.UpdateECDetail(model);
                        if (objMSmodel.Satus == "1")
                        {
                            TempData["Message"] = "EC Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding EC Details to DD/DMO";
                        }

                        return RedirectToAction("ECDetail", "EnvrinmentClearance", new { Area = "Licensee" });
                    }
                    else if (delete == "Delete")
                    {
                        model.UserID = session.UserId;
                        model.CREATED_BY = session.UserId;
                        model.UserLoginId = session.UserLoginId.ToString();
                        objMSmodel = _userInformation.DeleteECDetail(model);
                        if (objMSmodel.Satus == "1")
                        {
                            TempData["Message"] = "EC Details Deleted Successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Deleting EC Details";
                        }
                        return RedirectToAction("ECDetail", "EnvrinmentClearance", new { Area = "Licensee" });
                    }
                    else
                    {
                        model.STATUS = 0;
                        model.UserID = session.UserId;
                        model.CREATED_BY = session.UserId;
                        model.UserLoginId = session.UserLoginId.ToString();
                        objMSmodel = _userInformation.UpdateECDetail(model);
                        if (objMSmodel.Satus == "1")
                        {
                            TempData["Message"] = "EC Details Saved Successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Saving EC Details";
                        }

                        return RedirectToAction("ECDetail", "EnvrinmentClearance", new { Area = "Licensee" });
                    }

                }
                else
                {
                    return View(new ECDetails());
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// To Compare Enviornment Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Decryption]
        public IActionResult CompareECDetails(string id="0")
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ECDetails obj = new ECDetails();
            List<ECDetails> listobj = new List<ECDetails>();
            try
            {
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    obj.UserID = Convert.ToInt32(id);
                    obj.CREATED_BY = Convert.ToInt32(id);
                    obj.UserLoginId = session.UserLoginId.ToString();
                    listobj = _userInformation.CompareECDetails(obj);
                    return View(listobj);
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
                obj = null;
                listobj = null;
            }

        }
        /// <summary>
        /// To Approve and Reject EC Details of Licensee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CompareECDetails(ECDetails eCDetails)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            eCDetails.UserLoginId = session.UserLoginId.ToString();
            try
            {
                if (eCDetails.SubApprove == "Approve")
                {
                    eCDetails.UserID = session.UserId;
                    
                    objMSmodel = _userInformation.ApproveECDetails(eCDetails);
                    if (objMSmodel.Satus == "1")
                    {
                        TempData["Message"] = "EC Details Approved successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Error ! while Approving Licensee EC Details";
                    }
                }
                else if (eCDetails.SubReject == "Reject")
                {
                    eCDetails.UserID = session.UserId;
                   
                    objMSmodel = _userInformation.RejectECDetails(eCDetails);
                    if (objMSmodel.Satus == "1")
                    {
                        TempData["Message"] = "EC Details Rejected successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Error ! while Rejecting EC Details";
                    }
                }
                //return RedirectToAction("CompareECDetails", "EnvrinmentClearance", new { Area = "Licensee" });
                string EncryptUrl = CustomQueryStringHelper.EncryptString("Licensee", "CompareECDetails", "EnvrinmentClearance", new { id = eCDetails.CREATED_BY });
                return LocalRedirect(EncryptUrl);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IActionResult> ViewList()
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ECDetails eCDetails = new ECDetails();
            try
            {

                eCDetails.UserID = session.UserId;
                eCDetails.CREATED_BY = session.UserId;
                eCDetails.UserLoginId = session.UserLoginId.ToString();

                //ViewData["tableA"] = await ECTable(eCDetails.CREATED_BY);
                LicenseeResult listobj = await _userInformation.GetECDetails(eCDetails);
                if (listobj.ECDetailsList != null)
                {
                    ViewBag.tableA = await ECTable(eCDetails.CREATED_BY);
                    return View(listobj.ECDetailsList.FirstOrDefault());
                }
                else
                {
                    return View(new ECDetails());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { eCDetails = null; }
        }
        public async Task<string> ECTable(int? id)
        {
            string div = "";
            ECDetails objmodel = new ECDetails();
            objmodel.CREATED_BY = id;
            objlistmodel = await _userInformation.GetECLogDetails(objmodel);
            foreach (var item in objlistmodel)
            {
                div += "<li class='timeline-item'>";
                div += "<div class='date-box'>";
                div += "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div += "</div>";
                if (item.STATUS == 2)
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else
                {
                    div = div + "<div class='message-highlighter draft'>";
                }
                div += "<div class='row'>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Approval Number</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.EC_ORDRER_NUMBER + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Approval Date</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.EC_APPLICATON_DATE + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Valid From</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.EC_VALID_FROM + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Valid Upto</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.EC_VALID_TO + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Approved Quantity</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.EC_APPROVED_CAPACITY + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Approval Letter</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.FILE_EC_CLEARANCE + "";
                if (item.FILE_EC_CLEARANCE != null && item.FILE_EC_CLEARANCE != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.EC_CLEARANCE_PATH) + "' class='ml-2' data-original-title='Download Approval Letter' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Remarks</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.Remarks + "</label>";
                div += "</div>";
                div += "</div>";
                div += "</div>";
                div += "</li>";
            }
            return div;
        }

        private async Task<SelectList> GetmineralNameList(int? id)
        {
            ECDetails model = new ECDetails();
            model.CREATED_BY = id;
            objlistmodel = await _userInformation.GetMineralNames(model);
            return new SelectList(objlistmodel, "MineralId", "MineralName", id);

        }
    }
}
