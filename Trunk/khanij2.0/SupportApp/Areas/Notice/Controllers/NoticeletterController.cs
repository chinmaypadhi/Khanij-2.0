using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SupportApp.Areas.Notice.Models.NoticeLetter;
using SupportEF;
using System.IO;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Microsoft.AspNetCore.Http;
using SupportApp.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using SupportApp.ActionFilter;
using Microsoft.Extensions.Options;

namespace SupportApp.Areas.Notice.Controllers
{
    [Area("Notice")]
    public class NoticeletterController : Controller
    {
        INoticeLetterModel _objNoticeModel;
        MessageEF objobjmodel = new MessageEF();
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        public object JsonRequestBehavior { get; private set; }
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;

        public NoticeletterController(INoticeLetterModel objNotice, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _objNoticeModel = objNotice;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        public IActionResult SendNoticeLetter(int id = 0)
        {
            NoticeLetterEF objmodel = new NoticeLetterEF();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            if (id != 0)
            {
                return View();
            }
            else
            {
                //*-------TO FILL Office Type DROPDOWN---------
                //  objOfcType.ActionFlag = "OT";
                objmodel.UserID = profile.UserId;
                //objmodel.UserID =7;
                //ViewBag.ViewUserList=  _objNoticeModel.ViewUserType(objmodel);
                var x = _objNoticeModel.ManageUserTypeView(objmodel);
                if (x != null)
                {
                    ViewBag.ViewUserTypeList = x.Select(c => new SelectListItem
                    {
                        Text = c.RoleTypeName,
                        Value = c.RoleTypeId.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewUserTypeList = Enumerable.Empty<SelectListItem>();
                }
                ////---------------------------------------------*/
                ////objmodel.IsActive = true;
                ////ViewBag.Button = "Submit";
                ////return View(objmodel);
                return View();
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult SendNoticeLetter(NoticeLetterEF objmodel, string submit, string[] userIds, List<IFormFile> UploadFile)
        {
            objmodel.NoticeDescription = objmodel.NoticeDescription.Replace("<p>", "").Replace("</p>", "");
            List<string> FilePathList = new List<string>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy = Convert.ToInt32(profile.UserId);
            objmodel.UserLoginId = profile.UserLoginId;
            //objmodel.CreatedBy = 7;
            //objmodel.UserLoginId = 7;
            #region Create Multiple UserId string
            string users = string.Empty;
            for (int i = 0; i <= userIds.Length - 1; i++)
            {
                users = users + userIds[i].ToString() + ',';
            }
            string ss = users.Remove(users.Length - 1, 1);
            objmodel.User_ID = ss;
            objmodel.UsersCount = userIds.Length;
            #endregion
            if (submit == "Submit")
            {
                if (objmodel.RoleTypeId == 0 || objmodel.RoleTypeId.ToString() == "")
                {
                    ViewBag.msg = "Please select Role type";
                    return View(objmodel);
                }
                else if (objmodel.User_ID == "" || objmodel.User_ID == "")
                {
                    ViewBag.msg = "Please select User Name";
                    return View(objmodel);
                }
                else if (objmodel.NoticeSubject == "")
                {
                    ViewBag.msg = "Please Enter Notice Subject";
                    return View(objmodel);
                }
                else if (objmodel.NoticeDescription == "")
                {
                    ViewBag.msg = "Please Enter Notice Description";
                    return View(objmodel);
                }
                else
                {
                    #region old code
                    //string userId = ddlUserName;
                    //#region Create Data table As Sp  Parameter for File Upload
                    //DataTable dt = new DataTable("MultipleFileUpload");
                    //long size = UploadFile.Sum(f => f.Length);
                    //var filePaths = new List<string>();
                    //dt.Columns.Add("FileName");
                    //dt.Columns.Add("FilePath");
                    //int FileCount = 0;
                    //foreach (var formFile in UploadFile)
                    //{
                    //    if (formFile != null && formFile.Length > 0)
                    //    {
                    //        if (!string.IsNullOrEmpty(formFile.FileName))
                    //        {
                    //            string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                    //            //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photo", strName + formFile.FileName);
                    //            var path = Path.Combine(configuration.GetSection("Path").GetSection("UploadPath").Value, strName + formFile.FileName);
                    //            var fileName = strName + "_" + formFile.FileName;
                    //            DataRow dr = dt.NewRow();
                    //            using (var stream = new FileStream(path, FileMode.Create))
                    //            {
                    //                formFile.CopyTo(stream);
                    //            }
                    //            objmodel.AttatchmentPath = fileName;
                    //            FilePathList.Add(path);
                    //            dr["FileName"] = fileName;
                    //            dr["FilePath"] = path;
                    //            dt.Rows.Add(dr);
                    //            dt.AcceptChanges();
                    //            //dt.Rows.Add(fileName, objmodel.AttatchmentPath);
                    //            FileCount += 1;
                    //        }
                    //        else
                    //        {
                    //            ModelState.Clear();
                    //            return View("Notice", new NoticeLetterEF { });
                    //        }
                    //        // }
                    //    }
                    //}
                    #endregion
                    #region File Upload
                    DataTable dt = new DataTable("MultipleFileUpload");
                    long size = UploadFile.Sum(f => f.Length);
                    var filePaths = new List<string>();
                    dt.Columns.Add("FileName");
                    dt.Columns.Add("FilePath");
                    int FileCount = 0;
                    if (UploadFile != null)
                    {
                        foreach (var formFile in UploadFile)
                        {
                            if (formFile != null && formFile.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(formFile.FileName))
                                {
                                    string strName = DateTime.Now.Date.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                    uniqueFileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(formFile.FileName);
                                    filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadSamplesPath"), uniqueFileName);
                                    var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadSamplesPath"));
                                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                                    if (!Directory.Exists(RootPath))
                                        Directory.CreateDirectory(RootPath);
                                    DirectoryInfo di = new DirectoryInfo(RootPath);
                                    di.Attributes = FileAttributes.Normal;
                                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                                        formFile.CopyTo(fileStream);
                                    dt.Rows.Add(uniqueFileName, filePath);//
                                }
                            }
                            FileCount++;
                        }
                        objmodel.MultipleFile = dt;
                    }
                    #endregion
                    objmodel.FileCount = FileCount.ToString();
                    objobjmodel = _objNoticeModel.SendNoticeLetter(objmodel);
                }
            }
            if (objobjmodel.Satus == "1")
            {
                TempData["SuccMessage"] = "Notice/Letter Sent Successfully.";
                return RedirectToAction("SendNoticeLetter", "Noticeletter", new { Area = "Notice" });
            }
            else
            {
                TempData["SuccMessage"] = "Data not Saved Sucessfully.";
                return View(objmodel);
            }
        }
        public JsonResult GetUserList(int intRoleTypeID)
        {
            NoticeLetterEF objNotice = null;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                objNotice = new NoticeLetterEF();
                //objNotice.UserID = 7;
                objNotice.UserID = profile.UserId;
                objNotice.RoleTypeId = intRoleTypeID;

                var x = _objNoticeModel.GetUserListByRoleType(objNotice);
                var SList = x.ToList();
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
                objNotice = null;
            }

        }
        public IActionResult SubmittedNotice(int NoticeID = 0)
        {
            try
            {
                if (TempData["SuccMessage"] !=null )
                {
                    ViewBag.msg = TempData["SuccMessage"];
                }
                    NoticeLetterEF objmodel = new NoticeLetterEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = profile.UserId;
                //objmodel.UserID = 7;
                objmodel.NoticeID = NoticeID;
                ViewBag.ViewList = _objNoticeModel.GetSubmittedNotice(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [SkipImportantTask]
        public IActionResult SubmittedNoticeDetails(string id = "0", string Type = "")
        {
            //List<NoticeLetterEF> data = null;
            NoticeLetterEF objmodel = new NoticeLetterEF();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = profile.UserId;
            //objmodel.UserID =7;
            objmodel.NoticeID = Convert.ToInt32(id);
            try
            {
                if (objmodel.NoticeID != null && objmodel.NoticeID != 0)
                {
                    if (Type == "Send")
                        ViewBag.NoticeDetails = _objNoticeModel.GetSendNotice(objmodel);
                    else
                        ViewBag.NoticeDetails = _objNoticeModel.GetSubmittedNotice(objmodel);
                    ViewBag.NoticeFileList = _objNoticeModel.GetUploadedFilesByNoticeID(objmodel);
                }
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [SkipImportantTask]
        public IActionResult Notice_Replay(string NoticeID = "0", string Subject = "", string Type = "")
        {
            //List<NoticeLetterEF> data = null;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            NoticeLetterEF objmodel = new NoticeLetterEF();
            ReplyNotice replyNotice = new ReplyNotice();
            objmodel.UserID = profile.UserId;
            objmodel.CreatedBy = Convert.ToInt32(profile.UserId);
            //objmodel.UserID = 1;
            //objmodel.CreatedBy = 1;
            objmodel.NoticeID = Convert.ToInt32(NoticeID);
            try
            {
                if (objmodel.NoticeID != null && objmodel.NoticeID != 0 && Type != "Reply")
                {
                    replyNotice = _objNoticeModel.Reply_GetUploadedFiles(objmodel);
                    
                    
                    List<UserTypeResult> List = new List<UserTypeResult>();
                    if (replyNotice != null)
                    {
                        ViewBag.NoticeDetails = replyNotice.UserTypeLst;
                        ViewBag.noticeId = objmodel.NoticeID;
                        ViewBag.NoticeFileList = replyNotice.FileType;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Notice_Replay(NoticeLetterEF model, List<IFormFile> UploadFile)
        {
            List<string> FilePathList = new List<string>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserID = profile.UserId;
            model.UserLoginId = profile.UserLoginId;
            //InspectionSubmittedModelRepository objRepository = new InspectionSubmittedModelRepository();

            #region Create Data table As Sp  Parameter for File Upload
            DataTable dt = new DataTable("MultipleFileUpload");
            long size = UploadFile.Sum(f => f.Length);
            var filePaths = new List<string>();

            dt.Columns.Add("FileName");
            dt.Columns.Add("FilePath");

            int FileCount = 0;

            if (model.NoticeDescription == "")
            {
                ViewBag.msg = "Please Enter Notice Description";
                //return View();
            }
            else
            {
                foreach (var formFile in UploadFile)
                {
                    if (formFile != null && formFile.Length > 0)
                    {
                        //foreach (var file in UploadFile)
                        //{
                        if (!string.IsNullOrEmpty(formFile.FileName))
                        {
                            string strName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photo", strName + formFile.FileName);
                            var fileName = strName + "_" + formFile.FileName;

                            DataRow dr = dt.NewRow();
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                formFile.CopyTo(stream);
                            }
                            model.AttatchmentPath = fileName;

                            FilePathList.Add(path);
                            dr["FileName"] = fileName;
                            dr["FilePath"] = path;
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();

                            //dt.Rows.Add(fileName, objmodel.AttatchmentPath);

                            FileCount += 1;
                        }
                        else
                        {
                            ModelState.Clear();
                            return View("Notice", new NoticeLetterEF { });
                        }

                        // }
                    }
                }
                #endregion
                model.MultipleFile = dt;
                model.FileCount = FileCount.ToString();

                objobjmodel = _objNoticeModel.InsertNoticeReplay(model);
            }
            if (objobjmodel.Satus == "1")
            {

                

                TempData["SuccMessage"] = "Notice/Letter Replied Successfully";
                ModelState.Clear();
                return RedirectToAction("SubmittedNotice", "Noticeletter", new { Area = "Notice" });
            }
            else
            {
                ViewBag.msg = "Data not Save Sucessfully";
                return View(model);
            }
        }
        public ActionResult Received_Reply()
        {
            NoticeLetterEF objmodel = new NoticeLetterEF();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = profile.UserId;
            objmodel.NoticeID = null;
            ViewBag.NoticeDetails = _objNoticeModel.GetSendNotice(objmodel);
            ViewBag.RipMsg = TempData["SuccMessageVal"];
            return View();
        }
        [SkipImportantTask]
        public ActionResult Received_Reply_Sub(string NoticeID = "0")
        {
            NoticeLetterEF objmodel = new NoticeLetterEF();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = profile.UserId;
            objmodel.NoticeID = Convert.ToInt32(NoticeID);
            ViewBag.NoticeDetails = _objNoticeModel.GetNoticeReply(objmodel);
            return View();
        }
        [SkipImportantTask]
        public IActionResult Reply_GetRepliedData(string NoticeID = "0", string Subject = "", string Type = "", string UserID = "0")
        {
            //List<NoticeLetterEF> data = null;
            NoticeLetterEF objmodel = new NoticeLetterEF();
            ReplyNotice replyNotice = new ReplyNotice();
            objmodel.UserID = Convert.ToInt32(UserID);
            objmodel.CreatedBy = Convert.ToInt32(UserID);
            objmodel.NoticeID = Convert.ToInt32(NoticeID);
            ViewBag.NoticeID = NoticeID;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if (objmodel.NoticeID != null && objmodel.NoticeID != 0)
                {
                    replyNotice = _objNoticeModel.Reply_GetUploadedFiles(objmodel);
                    List<UserTypeResult> List = new List<UserTypeResult>();
                    if (replyNotice != null)
                    {
                        ViewBag.NoticeDetails = replyNotice.UserTypeLst;
                        ViewBag.NoticeFileList = replyNotice.FileType;
                        return View("Replay_DisplayNoticeText", objmodel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Replay_DisplayNoticeText(NoticeLetterEF model, List<IFormFile> UploadFile)
        {
            List<string> FilePathList = new List<string>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.UserId = TempData["userId"];

            //model.UserID = model.UserID;// profile.UserId;
            //model.UserLoginId = model.UserID;

            //InspectionSubmittedModelRepository objRepository = new InspectionSubmittedModelRepository();

            #region Create Data table As Sp  Parameter for File Upload
            //DataTable dt = new DataTable("MultipleFileUpload");
            //long size = UploadFile.Sum(f => f.Length);
            //var filePaths = new List<string>();

            //dt.Columns.Add("FileName");
            //dt.Columns.Add("FilePath");

            int FileCount = 0;
            foreach (var formFile in UploadFile)
            {
                if (formFile != null && formFile.Length > 0)
                {
                    //foreach (var file in UploadFile)
                    //{
                    if (!string.IsNullOrEmpty(formFile.FileName))
                    {
                        string strName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photo", strName + formFile.FileName);
                        var fileName = strName + "_" + formFile.FileName;

                        // DataRow dr = dt.NewRow();
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                        model.FileCopy = fileName;
                        model.FilePath = path;
                        //FilePathList.Add(path);
                        //dr["FileName"] = fileName;
                        //dr["FilePath"] = path;
                        //dt.Rows.Add(dr);
                        //dt.AcceptChanges();

                        //dt.Rows.Add(fileName, objmodel.AttatchmentPath);

                        //model.UserID = profile.UserId;
                        model.UserLoginId = profile.UserLoginId;
                        model.NoticeID = model.NoticeID;


                        FileCount += 1;
                    }
                    else
                    {
                        ModelState.Clear();
                        return View("Received_Reply", new NoticeLetterEF { });
                    }

                    // }
                }
            }
            #endregion
            // model.MultipleFile = dt;
            // model.FileCount = FileCount.ToString();

            objobjmodel = _objNoticeModel.UpdateStatusResult(model);
            if (objobjmodel.Satus == "1")
            {
                TempData["SuccMessageVal"] = "Penalty given Successfully.";
                ModelState.Clear();
                return RedirectToAction("Received_Reply", "Noticeletter", new { Area = "Notice" });
            }
            else
            {
                TempData["SuccMessageVal"] = "Data not Saved Sucessfully";
                return View(model);
            }
        }
        public IActionResult NoticePenalty()
        {
            try
            {
                NoticeLetterEF objmodel = new NoticeLetterEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = profile.UserId;
                ViewBag.ViewList = _objNoticeModel.GetNoticePenaltyReplyGrid(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public JsonResult NoticePenaltyPayment(string arr, string totalPayableAmt, string PaymentType, string ArrtotalPayableAmt)
        {
            try
            { 
                var dataString = CustomQueryStringHelper.EncryptString("Payment","NoticeLtrPenalty","NoticeAndletter", new { arr = arr, totalPayableAmt = totalPayableAmt,PaymentType= PaymentType, ArrtotalPayableAmt = ArrtotalPayableAmt });
                //string url = Convert.ToString(configuration.GetSection("KeyList").GetSection("Paymenturl").Value) + dataString;
                return  Json(Convert.ToString(configuration.GetSection("KeyList").GetSection("Paymenturl").Value) + dataString);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}