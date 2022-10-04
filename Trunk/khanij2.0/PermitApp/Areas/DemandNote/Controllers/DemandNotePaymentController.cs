using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PermitApp.Areas.DemandNote.Models;
using PermitApp.Helper;
using PermitApp.Web;
using PermitEF;

namespace PermitApp.Areas.DemandNote.Controllers
{
    [Area("DemandNote")]
    public class DemandNotePaymentController : Controller
    {
        #region Global object,variable & constructor declaration
        private IDemandNote objIDemandNote;
        private readonly IHostingEnvironment hostingEnvironment;
        DemandNotePaymentModel objdemandnotepaymentmodel = new DemandNotePaymentModel();
        DemandNoteCodePayment objdemandnotecodepaymentmodel = new DemandNoteCodePayment();
        List<DemandNotePaymentModel> objdemandnotelist = new List<DemandNotePaymentModel>();
        MessageEF objmessage = new MessageEF();
        private readonly IConfiguration configuration;
        public DemandNotePaymentController(IDemandNote objIDemandNote, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            this.objIDemandNote = objIDemandNote;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        #endregion
        /// <summary>
        /// Bind Demand note summary data details in view
        /// </summary>
        /// <returns></returns>
        public IActionResult DemandNoteSummary()
        {
            try
            {
                ViewBag.url = configuration.GetSection("Path").GetSection("APIUrl").Value;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                DemandNoteCodePayment objmodel = new DemandNoteCodePayment();
                objmodel.UserID = profile.UserId;
               // objmodel.FromDate = DateTime.Today.ToString();
               // objmodel.ToDate = DateTime.Today.ToString();
                return View(objIDemandNote.getDemandNoteSummaryData(objmodel));
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objdemandnotecodepaymentmodel = null;
            }
        }
        /// <summary>
        /// Bind Demand note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DemandNoteSummary(DemandNoteCodePayment objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = profile.UserId;
                
                return View(objIDemandNote.getDemandNoteSummaryData(objmodel));
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
            /// <summary>
            /// Bind Demand note summary data details in view
            /// </summary>
            /// <returns></returns>
            public IActionResult CreditNoteSummary()
        {
            try
            {
                ViewData["list"] = objIDemandNote.getCreditNoteSummaryData(objdemandnotecodepaymentmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objdemandnotecodepaymentmodel = null;
            }
        }
        /// <summary>
        /// Bind Credit note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreditNoteSummary(DemandNoteCodePayment objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = profile.UserId;
                ViewData["list"] = objIDemandNote.getCreditNoteSummaryData(objmodel);
                return View();
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
        public IActionResult PaymentDemandNoteView()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
          //  ViewData["list"] = objIDemandNote.GetPaymentDemandNote(new DemandNoteCodePayment { UserID = profile.UserId.ToString() });
            return View();
        }

        public ActionResult Payment(string id)
        {

            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);


            DemandNoteCodePayment obj = new DemandNoteCodePayment() { DemandNoteCode = id };
            List<DemandNoteCodePayment> objReturnData = new List<DemandNoteCodePayment>();
            obj.UserID = profile.UserId;
            ViewBag.DemandID = id;
            objReturnData = objIDemandNote.ViewPaymentDetails(obj);
            //string strData = Convert.ToString(objReturnData[0].IsPaymentDone);
            //  ViewBag.PaymentData = strData;
            //   DemandNoteCodePayment objReq = new DemandNoteCodePayment();
            // UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            DemandNoteCodePayment objReq = new DemandNoteCodePayment();
            objReq.UserID = profile.UserId;
            objReq.DemandNoteCode = id;
            List<DemandNotePaymentModel> notePaymentModel = new List<DemandNotePaymentModel>();
            notePaymentModel = objIDemandNote.ViewPaymentDetailsData(objReq);
            return View(notePaymentModel);
        }


        //[HttpPost]
        //public JsonResult ViewDetailsData(string DemandNoteCode)
        //{
        //    try
        //    {

        //        DemandNoteCodePayment objReq = new DemandNoteCodePayment();
        //        UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
        //        objReq.UserID = profile.UserId;
        //        objReq.DemandNoteCode = DemandNoteCode;
        //       List<DemandNotePaymentModel> notePaymentModel = new List<DemandNotePaymentModel>();
        //        notePaymentModel = objIDemandNote.ViewPaymentDetailsData(objReq);
        //        return Json(notePaymentModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }           
        //}

        public IActionResult CreditNoteDetailsView()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            DemandNoteCodePayment objReq = new DemandNoteCodePayment();
            objReq.UserID = profile.UserId;
            DemandNoteCodePayment objParam = new DemandNoteCodePayment();
            //objReq.FromDate = DateTime.Today.ToString();
            //objReq.ToDate = DateTime.Today.ToString();
            List<DemandNoteCodePayment> notePaymentModel = new List<DemandNoteCodePayment>();
            notePaymentModel = objIDemandNote.ViewCreditDetails(objReq);
            return View(notePaymentModel);
        }

        [HttpPost]
        public IActionResult CreditNoteDetailsView(DemandNoteCodePayment objParam)
        {
            try
            {

                DemandNoteCodePayment objReq = new DemandNoteCodePayment();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objReq.UserID = profile.UserId;
                objReq.FromDate = objParam.FromDate;
                objReq.ToDate = objParam.ToDate;
                List<DemandNoteCodePayment> notePaymentModel = new List<DemandNoteCodePayment>();
                notePaymentModel = objIDemandNote.ViewCreditDetails(objReq);
                return View(notePaymentModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult MannualCreditAmount()
        {
            DemandNoteCodePayment objReq = new DemandNoteCodePayment();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objReq.UserID = profile.UserId;

            List<CreditAmountModel> notePaymentModel = new List<CreditAmountModel>();
            notePaymentModel = objIDemandNote.ViewCreditAmountDetails(objReq);
            return View(notePaymentModel);
        }


        //[HttpPost]
        //public JsonResult ViewCreditAmountDetails(DemandNoteCodePayment objParam)
        //{
        //    try
        //    {
        //        DemandNoteCodePayment objReq = new DemandNoteCodePayment();
        //        UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
        //        objReq.UserID = profile.UserId;               
                              
        //        List<CreditAmountModel> notePaymentModel = new List<CreditAmountModel>();
        //        notePaymentModel = objIDemandNote.ViewCreditAmountDetails(objReq);
        //        return Json(notePaymentModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}


        [HttpPost]
        public ActionResult ManualCreditAmount(IFormFile FileData)
        {
            try
            {
                MessageEF objobjmodel = new MessageEF();
                CreditAmountModel obj = new CreditAmountModel();
                CreditAmountData obj1 = JsonConvert.DeserializeObject<CreditAmountData>(Request.Form["alldata"].ToString());
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);


                string[] arrExtension = { ".pdf" };
                string folderName = "";
                folderName = "\\CreditAmountAssessment\\";
                string webRootPath = hostingEnvironment.WebRootPath;
                //string newPath = Path.Combine(webRootPath, folderName);
                string newPath = webRootPath+folderName;
                string FileName = string.Empty;


                if (FileData.Length > 0)
                {
                    string sFileExtension = Path.GetExtension(FileData.FileName).ToLower();
                    long filesize = FileData.Length;
                    if (!arrExtension.Contains(sFileExtension))
                    {
                        return Json(new { message = "Please upload Pdf files only" });
                    }
                    //else if (filesize > (15 * 1024 * 1024))
                    //{
                    //    return Content(new AjaxResult { state = nameof(ResultType.error), message = "File size cannot be greater than 15 mb", controlid = "inputGroupFile" }.ToJson());
                    //}


                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }

                    FileName = "datcol-" + System.DateTime.Now.ToString("ddMMyyyyHHmmssfff") + sFileExtension;
                    string fullPath = Path.Combine(newPath, FileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        FileData.CopyTo(stream);
                    }
                    obj.UserId = profile.UserId;
                    obj.LesseeId = obj1.LesseeName;
                    obj.PaymentTypeHeadId = obj1.PaymentType;
                    obj.CreditedAmmount = obj1.txtCreditAmount;
                    obj.AssessmentCopyName = FileName;
                    obj.AssessmentCopyPath = folderName+ FileName;
                    obj.UserLoginId = profile.UserLoginId;
                    objobjmodel = objIDemandNote.AddManualCreditAmount(obj);
                    if (objobjmodel.Msg == "1")
                    {
                        return Json(new { message = "Data saved Successfully" });
                    }
                    else
                    {
                        return Json(new { message = "Something went wrong." });
                    }
                }
                else
                {

                    //if there is no file
                    return Json(new { message = "Please provide file to upload" });

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json(new { });
        }


        [HttpPost]
        public JsonResult ViewPaymentType(DemandNoteCodePayment objParam)
        {
            try
            {
                DemandNoteCodePayment objReq = new DemandNoteCodePayment();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);              
                objReq.UserID = profile.UserId;
                List<CreditAmountModel> notePaymentModel = new List<CreditAmountModel>();
                notePaymentModel = objIDemandNote.ViewPaymentType(objReq);
                return Json(notePaymentModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        [HttpPost]
        public JsonResult ViewLesseeDetails(DemandNoteCodePayment objParam)
        {
            try
            {
                DemandNoteCodePayment objReq = new DemandNoteCodePayment();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objReq.UserID = profile.UserId;
                List<CreditAmountModel> notePaymentModel = new List<CreditAmountModel>();
                notePaymentModel = objIDemandNote.ViewLessee(objReq);
                return Json(notePaymentModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult DemandPayment(string DemandCodeId)
        {
            try
            {
                var dataString = CustomQueryStringHelper.EncryptString("payment", "Paymentss", "DemandNotePayment", new { DemandnoteId = DemandCodeId });
                //string url = Convert.ToString(configuration.GetSection("KeyList").GetSection("Paymenturl").Value) + dataString;
                return Json(Convert.ToString(configuration.GetSection("Path").GetSection("APIUrl").Value) + dataString);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult VerifyDemandNoteS(objDemandListData objAllData)
        {
            try
            {
                MessageEF objobjmodel = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objAllData.UserID = profile.UserId;
                objobjmodel = objIDemandNote.VerifyDemandNoteS(objAllData);            
                return Json(new { data= objobjmodel.Msg });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        


    }
}
