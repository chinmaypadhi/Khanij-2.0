// ***********************************************************************
//  Controller  Name         : BackendTicketController.cs
//  Desciption               : Used to Edit,Query execution of Backend Ticket
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 5-feb-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using HelpDeskEF;
using Microsoft.AspNetCore.Mvc;
using HelpdeskApp.Areas.Helpdesk.Models.Ticket;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Text;
using HelpdeskApp.Web;
using Microsoft.Extensions.Configuration;
using HelpdeskApp.ActionFilter;

namespace HelpdeskApp.Areas.Helpdesk.Controllers
{
    [Area("Helpdesk")]
    public class BackendController : Controller
    {
        ITicketModel _objIticketmodel;
        MessageEF objobjmodel = new MessageEF();
        private readonly IHostingEnvironment hostingEnvironment;
        BackendModel objmodel = null;
        private readonly IConfiguration _config;
        //string usertype = "OSU";//"Lessee";//"HELPDESK USER";
        //int userid = 28791;//59;//29279;
        public BackendController(ITicketModel objtickettypemastermodel, IHostingEnvironment hostingEnvironment, IConfiguration config)
        {
            _objIticketmodel = objtickettypemastermodel;
            this.hostingEnvironment = hostingEnvironment;
            _config = config;
        }
        /// <summary>
        /// Added by suroj on 12-mar-2021 to load page contains User Severity,problem type 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Add(string id="0")
        {
            ViewBag.Ticketid = id;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            //profile.UserType= "OSU";
            //profile.UserId = 5212;
            ViewBag.usertype = profile.UserType;
            List<BackendModel> objTicket = new List<BackendModel>();
            try
            {
                objmodel = new BackendModel();
                objmodel.userid = Convert.ToInt16(profile.UserId);
                objTicket = _objIticketmodel.GetSeverity(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.ModuleList = new SelectList(objTicket, "id", "Severity");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
            }
            try
            {
                objmodel = new BackendModel();
                objmodel.userid = Convert.ToInt16(profile.UserId);
                objTicket = _objIticketmodel.GetForwardedTo(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.Forwardlist = new SelectList(objTicket, "UserTypeId", "UserType");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                objmodel = null;
            }
            try
            {
                objmodel = new BackendModel();
                objTicket = _objIticketmodel.GetStateDistrictList(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.District = new SelectList(objTicket, "DistrictId", "Districtname");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                objmodel = null;
            }
            if (Convert.ToInt32(id) != 0)
            {
                objmodel = new BackendModel();
                objmodel.userid = Convert.ToInt16(profile.UserId);
                objmodel.TicketID = Convert.ToInt32(id);
                objmodel = _objIticketmodel.GetDataBackend(objmodel);
            }
            else
            {
                objmodel.TicketID = Convert.ToInt32(id);
                objmodel.ProblemDescription = "Sir/Madam,";
            }
            return View(objmodel);
        }
        /// <summary>
        /// Added by suroj on 14-mar-2021 to load Backend Quey execution page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult SRExecution(string id="0")
        {
            objmodel = new BackendModel();
            List<BackendModel> objTicket = new List<BackendModel>();
            try
            {
                objmodel.Action = "GetTicketNo_New";
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.userid = Convert.ToInt16(profile.UserId);
                objmodel.TicketID = Convert.ToInt32(id);
                objmodel = _objIticketmodel.FetchTicketNo(objmodel);
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
        /// <summary>
        /// Added by suroj on 12-mar-2021 to generate Random No
        /// </summary>
        /// <returns></returns>
        private string GetRandomText()
        {
            StringBuilder randomText = new StringBuilder();
            string alphabets = "012345679ACEFGHKLMNPRSWXZabcdefghijkhlmnopqrstuvwxyz";
            Random r = new Random();
            for (int j = 0; j <= 5; j++)
            {
                randomText.Append(alphabets[r.Next(alphabets.Length)]);
            }
            return randomText.ToString();
        }
        /// <summary>
        /// Added by suroj to get  Capcha Image
        /// </summary>
        /// <returns></returns>
        public JsonResult CaptchaImage()
        {
            var rand = new Random((int)DateTime.Now.Ticks);
            //generate new question 
            int a = rand.Next(10, 99);
            int b = rand.Next(0, 9);
            //var captcha = string.Format("{0} + {1} = ?", a, b);
            var captcha = GetRandomText();
            return Json(captcha);
        }
        /// <summary>
        /// Added by suroj on 20-mar-2021 to get Query data in Query window
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="TicketNo"></param>
        /// <param name="qrytype"></param>
        /// <returns></returns>
        public JsonResult GetData(string qry, string TicketNo, int qrytype)
        {
            BackendModel objmodel = new BackendModel();
            objmodel.qry = qry;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            if (qrytype == 1)
            {
                string Query = _objIticketmodel.FetchQuerydtls(qry, objmodel);
                objmodel.userid = Convert.ToInt16(profile.UserId);
                objmodel.TicketNo = TicketNo;
                objmodel.qry = qry;
                objmodel.Qrytype = qrytype;
                int _result = _objIticketmodel.InsertExecution(objmodel);
                Query = Query.Replace(@"\", "");
                return Json(Query);
            }
            else
            {
                int result = _objIticketmodel.Queryinsert(objmodel);
                objmodel.userid = Convert.ToInt16(profile.UserId);
                objmodel.TicketNo = TicketNo;
                objmodel.qry = qry;
                objmodel.Qrytype = qrytype;
                int _result = _objIticketmodel.InsertExecution(objmodel);
                return Json(result);
            }
        }
        /// <summary>
        /// Added by suroj on 16-mar-2021 to to submit backend Query data
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BackendTicket(BackendModel objmodel, string submit)
        {
            DataTable dt = new DataTable("MultipleFileUpload");
            try
            {
                dt.Columns.Add("FileName");
                dt.Columns.Add("FilePath");
                string uniqueFileName = null; string filePath = null;
                if (objmodel.Photo != null)
                {
                    foreach (IFormFile photo in objmodel.Photo)
                    {
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        filePath = Path.Combine(_config.GetSection("Path").GetValue<string>("HepldeskFile"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, _config.GetSection("Path").GetValue<string>("HepldeskFile"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            photo.CopyTo(fileStream);
                        dt.Rows.Add(uniqueFileName, filePath);//
                    }
                    objmodel.Document = dt;
                }
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.userid = Convert.ToInt16(profile.UserId);//5212 OSU ----19 DGM
                objmodel.Action = "BackendTicket";
                objmodel.Photo = null;
                int _value = _objIticketmodel.TakeAction(objmodel);
                if (_value == 1)
                {
                    TempData["message"] = "Your Ticket Forwarded Sucessfully";
                    return RedirectToAction("Nxtview", "RaiseTicket");
                }
                return View(objmodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dt = null;
            }
        }
        /// <summary>
        /// Added by suroj on 23-mar-2021 to fetch all type of user
        /// </summary>
        /// <param name="Forwardto"></param>
        /// <param name="Ticketid"></param>
        /// <param name="Districtid"></param>
        /// <returns></returns>
        public JsonResult FetchUser(string Forwardto, int Ticketid, int Districtid)
        {
            BackendModel objRaise = new BackendModel();
            List<BackendModel> objTicket = new List<BackendModel>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objRaise.userid = Convert.ToInt16(profile.UserId);
                objRaise.TicketID = Ticketid;
                objRaise.ForwardedTo = Forwardto;
                objRaise.DistrictId = Districtid.ToString();
                objTicket = _objIticketmodel.GetForwardedbyId(objRaise);
                return Json(objTicket);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRaise = null;
            }
        }
        /// <summary>
        /// Added by suroj on 25-mar-2021 for DGM Approval
        /// </summary>
        /// <param name="Ticketid"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="Forwardto"></param>
        /// <param name="ForwardedId"></param>
        /// <returns></returns>
        public JsonResult DgmApproval(int Ticketid, string description, int type, int? Forwardto, int? ForwardedId)
        {
            BackendModel objRaise = new BackendModel();
            List<BackendModel> objTicket = new List<BackendModel>();
            try
            {
                if (type == 1)
                {
                    objRaise.Action = "DgmApprove";
                }
                else if (type == 2)
                {
                    objRaise.Action = "DgmReject";
                }
                else
                {
                    objRaise.Action = "DgmForward";
                    objRaise.ForwardedTo = Forwardto.ToString();
                    objRaise.ForwardedId = ForwardedId;
                }
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objRaise.userid = Convert.ToInt16(profile.UserId);
                objRaise.TicketID = Ticketid;
                int result = _objIticketmodel.DgmApproval(objRaise);
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRaise = null;
                objTicket = null;
            }
        }
    }
}
