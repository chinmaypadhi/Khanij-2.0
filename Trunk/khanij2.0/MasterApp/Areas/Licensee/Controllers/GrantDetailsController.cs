// ***********************************************************************
//  Controller Name          : GrantDetails
//  Desciption               : Liecensee Grant Order Details 
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
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Licensee.Controllers
{
    [Area("Licensee")]
    public class GrantDetailsController : Controller
    {
        #region Global Variables
        IUserInformationLicenseeModel _userInformation;
        private IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        MessageEF objMSmodel = new MessageEF();
        List<GrantDetails> objlistmodel = new List<GrantDetails>();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        public object JsonRequestBehavior { get; private set; }
        #endregion
        /// <summary>
        ///Create Dependency Injection IUserInformationLicenseeModel, IHostingEnvironment
        /// </summary>
        /// <param name="objUserInformation"></param>
        /// <param name="hostingEnvironment"></param>
        public GrantDetailsController(IUserInformationLicenseeModel objUserInformation, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _userInformation = objUserInformation;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        /// <summary>
        /// To Bind the Grant Order Details Data in View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<IActionResult> Create(int? id)
        {
            GrantDetails model = new GrantDetails();
            try
            {
                LicenseeResult objAppl = new LicenseeResult();
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (session.UserId != 0)
                {
                    model.UserLoginId = session.UserLoginId.ToString();
                    model.UserID = session.UserId;
                    model.CREATED_BY = session.UserId;
                    objAppl = await _userInformation.GetGrantOrderDetails(model);
                    return View(objAppl.GratnDetilsList.FirstOrDefault());
                }
                else
                {
                    return View(new GrantDetails());
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                model = null;
            }
        }
        /// <summary>
        /// To Perform Save , Forward to DD, Approve and Reject of Licensee Grant Order Details
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cmd"></param>
        /// <param name="approve"></param>
        /// <param name="reject"></param>
        /// <param name="id"></param>
        /// <param name="flRegistrationCopy"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(GrantDetails model, string cmd, string delete, IFormFile selectedFile)
        {
            try
            {
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                var DD_DMO = "Forward To DD";
                if (model.SubResion == "Forward To DD")
                {
                    cmd = "Forward To DD";
                }

                #region for Server Side Validation
                if (string.IsNullOrEmpty(model.GrantOrderNumber))
                {
                    ModelState.AddModelError("GrantOrderNumber", "Grant Order Number is required");
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
                            filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("GrantPath"), fileName);
                            var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("GrantPath"));
                            string UploadFolderPath = Path.Combine(RootPath, fileName);
                            if (!Directory.Exists(RootPath))
                                Directory.CreateDirectory(RootPath);
                            DirectoryInfo di = new DirectoryInfo(RootPath);
                            di.Attributes = FileAttributes.Normal;
                            using (var stream = new FileStream(UploadFolderPath, FileMode.Create))
                            {
                                selectedFile.CopyTo(stream);
                            }
                            model.GrantOrderFilePath = filePath;
                            model.GrantOrderFileName = fileName;
                        }
                    }
                    #endregion
                    if (DD_DMO == cmd)
                    {
                        model.STATUS = 1;
                        model.UserID = session.UserId;
                        model.CREATED_BY =session.UserId;
                        model.UserLoginId = session.UserLoginId.ToString();
                        objMSmodel = _userInformation.UpdateGrantOrderDetail(model);
                        if (objMSmodel.Satus == "1")
                        {
                            TempData["Message"] = "Grant Order Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Grant Order Details to DD/DMO";
                        }

                        return RedirectToAction("Create", "GrantDetails", new { Area = "Licensee" });
                    }
                    else if (delete == "Delete")
                    {
                        model.UserID = session.UserId;
                        model.CREATED_BY = session.UserId;
                        model.UserLoginId = session.UserLoginId.ToString();
                        objMSmodel = _userInformation.DeleteGrantOrderDetail(model);
                        if (objMSmodel.Satus == "1")
                        {
                            TempData["Message"] = "Grant Order Details Deleted Successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Deleting Grant Order Details";
                        }
                        return RedirectToAction("Create", "GrantDetails", new { Area = "Licensee" });
                    }
                    else
                    {
                        model.STATUS = 0;
                        model.UserID = session.UserId;
                        model.CREATED_BY = session.UserId;
                        model.UserLoginId = session.UserLoginId.ToString();
                        objMSmodel = _userInformation.UpdateGrantOrderDetail(model);
                        if (objMSmodel.Satus == "1")
                        {
                            TempData["Message"] = "Grant Order Details Updated Successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating Grant Order Details";
                        }
                        return RedirectToAction("Create", "GrantDetails", new { Area = "Licensee" });
                    }
                }
                else
                {
                    return View(model);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// For Comparision of Grant Order Old Data with New Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Decryption]
        public IActionResult Compare(string id = "0")
        {
            GrantDetails obj = new GrantDetails();
            List<GrantDetails> listobj = new List<GrantDetails>();
            try
            {
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    obj.UserID = Convert.ToInt32(id);
                    obj.CREATED_BY =Convert.ToInt32(id);
                    listobj = _userInformation.CompareGrantOrderDetails(obj);
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
        /// To Approve and Reject Grant Order Details of Licensee
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Compare(GrantDetails grantDetails)
        {
            try
            {
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                if (grantDetails.SubApprove == "Approve")
                {
                    grantDetails.UserID = Convert.ToInt32(session.UserId);
                    grantDetails.UserLoginId = session.UserLoginId.ToString();
                    objMSmodel = _userInformation.ApproveGrantOrderDetails(grantDetails);
                    if (objMSmodel.Satus == "1")
                    {
                        TempData["Message"] = "Grant Order Details Approved successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Error ! while Approving Grant Order Details";
                    }
                    //return RedirectToAction("ViewLicenseeGrantProfileRequests", "LicenseeProfile", new { area = "DMO" });
                }
                else if (grantDetails.SubReject == "Reject")
                {
                    grantDetails.UserID = Convert.ToInt32(grantDetails.CREATED_BY);
                    objMSmodel = _userInformation.RejectGrantOrderDetails(grantDetails);
                    if (objMSmodel.Satus == "1")
                    {
                        TempData["Message"] = "Grant Order Details Rejected successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Error ! while Rejecting Grant Order Details";
                    }
                }
                //return RedirectToAction("Compare", "GrantDetails", new { Area = "Licensee" });
                string EncryptUrl = CustomQueryStringHelper.EncryptString("Licensee", "Compare", "GrantDetails", new { id = grantDetails.CREATED_BY });
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
            GrantDetails objmodel = new GrantDetails();
            try
            {
                objmodel.UserID = session.UserId;
                objmodel.CREATED_BY = session.UserId;
                objmodel.UserLoginId = session.UserLoginId.ToString();
                LicenseeResult listobj = await _userInformation.GetGrantOrderDetails(objmodel);
                if (listobj.GratnDetilsList != null)
                {
                    ViewBag.tableLA = await GrantTable(objmodel.CREATED_BY);
                    return View(listobj.GratnDetilsList.FirstOrDefault());
                }
                else
                {
                    return View(new GrantDetails());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        public async Task<string> GrantTable(int? Created_By)
        {
            string div = "";
            GrantDetails objmodel = new GrantDetails();
            objmodel.UserID = Created_By;
            objmodel.CREATED_BY = Created_By;
            objlistmodel = await _userInformation.GetGrantLogDetails(objmodel);
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
                div = div + "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Order Number</label>";
                div = div + "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.GrantOrderNumber + "";
                if (item.GrantOrderFileName != null && item.GrantOrderFileName != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.GrantOrderFilePath) + "' class='ml-2' data-original-title='Download Grant Order' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div = div + "</div>";
                div = div + "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Order Date</label>";
                div = div + "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.GrantOrderDate + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Lease Validity From</label>";
                div = div + "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.FromValidity + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Lease Validity Upto</label>";
                div = div + "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.ToValidity + "</label>";
                div = div + "</div>";

                div = div + "</li>";
            }
            return div;
        }

        /// <summary>
        /// To Download the File
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="foldername"></param>
        /// <returns></returns>
        public IActionResult DownloadFiles(string filename, string foldername)
        {
            string filepath = null;
            var absolutePath = filename;
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, foldername);
            if (filename != null)
            {
                if (filepath == null)
                    filepath = Path.Combine(uploadsFolder, filename);
                //if (filename.Contains("_"))
                //{
                //    string[] splitFileName = filename.Split('_');
                //    filename = splitFileName[1];
                //}
                if (System.IO.File.Exists(filepath))
                {
                    return File(new FileStream(filepath, FileMode.Open), "application/octetstream", filename);
                }
                return null;
            }
            else
            {
                return null;
            }

        }

    }
}
