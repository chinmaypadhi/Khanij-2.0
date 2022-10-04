// ***********************************************************************
//  Controller Name          : RaiseTicket
//  Desciption               : Used to Add,view,Take Action Raise Ticket 
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 5-feb-2021
// ***********************************************************************
using HelpdeskApp.ActionFilter;
using HelpdeskApp.Areas.Helpdesk.Models.Ticket;
using HelpdeskApp.Web;
using HelpDeskEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace HelpdeskApp.Areas.Helpdesk.Controllers
{
    [Area("Helpdesk")]
    public class RaiseTicketController : Controller
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        ITicketModel _objIticketmodel;
        MessageEF objobjmodel = new MessageEF();
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration _config;
        //string usertype = "Lessee";//"Lessee";
        //int userid = 59;//7;//59;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objtickettypemastermodel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="config"></param>
        public RaiseTicketController(ITicketModel objtickettypemastermodel, IHostingEnvironment hostingEnvironment, IConfiguration config)
        {
            _objIticketmodel = objtickettypemastermodel;
            this.hostingEnvironment = hostingEnvironment;
            _config = config;
        }
        /// <summary>
        /// Added by suroj on 10-feb-2021 to load Raiseticket 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// double? id
        [Decryption]
        public IActionResult Add(string id="0")       
        {
            //UserLoginSession profile = new UserLoginSession();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            //profile.UserType = "HELPDESK USER";
            //profile.UserId = 2077;//profile.UserId;
            //profile.UserType = "Lessee";
            //profile.UserId = 59;//profile.UserId;
            ViewBag.userType = profile.UserType;
            RaiseTicket objmodel = null;
            List<RaiseTicket> objTicket = null;
            try
            {
                objmodel = new RaiseTicket();
                objTicket = new List<RaiseTicket>();
                objmodel.Action = "GetAllModuleNew";
                objTicket = _objIticketmodel.ModuleBind(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.ModuleList = new SelectList(objTicket, "ModuleID", "ModuleName");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
                objTicket = null;
            }
            try
            {
                objmodel = new RaiseTicket();
                objTicket = new List<RaiseTicket>();
                objmodel.Action = "GetAllModuleNew1";
                objTicket = _objIticketmodel.ModuleBind(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.ModuleListNonuser = new SelectList(objTicket, "OtherThanHelpdesk_ModuleID", "OtherThanHelpdesk_ModuleName");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTicket = null;
                objmodel = null;
            }
            Proritybind();
            try
            {
                objmodel = new RaiseTicket();
                objTicket = new List<RaiseTicket>();
                objmodel.Action = "StateBind";
                objTicket = _objIticketmodel.BindState(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.Statelist = new SelectList(objTicket, "StateID", "StateName", objmodel.StateID);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTicket = null;
                objmodel = null;
            }
            try
            {
                objmodel = new RaiseTicket();
                objTicket = new List<RaiseTicket>();
                objmodel.Action = "StateBindNonuser";
                objTicket = _objIticketmodel.BindState(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.Statelist2 = new SelectList(objTicket, "OtherThenNonUser_StateName2id", "OtherThenNonUser_StateName2", objmodel.OtherThenNonUser_StateName2id);
                }
                ViewBag.did = objmodel.DistrictID;
                ViewBag.dname = objmodel.DistrictName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTicket = null;
                objmodel = null;
            }
            try
            {
                objmodel = new RaiseTicket();
                objTicket = new List<RaiseTicket>();
                objmodel.Userid = Convert.ToInt16(profile.UserId);
                objTicket = _objIticketmodel.GetCategoryMaster(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.Categorylist = new SelectList(objTicket, "CategoryID", "CategoryName");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTicket = null;
                objmodel = null;
            }
            if (Convert.ToDouble(id) == 0 || id == null)
            {
                objmodel = new RaiseTicket();
                objmodel.Userid = Convert.ToInt16(profile.UserId);
                objmodel.Photo = null;
                objmodel = _objIticketmodel.FetchDetails(objmodel);
                objmodel.ComplainerName = objmodel.ApplicantName;
                objmodel.ComplainerUserName = objmodel.UserName;
                ViewBag.MobileNo = objmodel.ComplainerMobileNumber;
                ViewBag.Email = objmodel.ComplainerEmailID;
                return View(objmodel);
            }
            else
            {
                objmodel = new RaiseTicket();
                //TempData["Ticketid"] = id;
                ViewBag.Button = "Update";
                objmodel.TicketID = Convert.ToDouble(id);
                objmodel.Userid = Convert.ToInt16(profile.UserId);
                objmodel.Action = "GetTicketHistory_Edit";
                objmodel = _objIticketmodel.EditDetails(objmodel);
                ViewBag.tid = id;
                return View(objmodel);
            }
            //return View(objmodel);
        }
        /// <summary>
        /// Added by suroj kumar pradhan on 15-feb-2021 to Bind Priority
        /// </summary>
        public void Proritybind()
        {
            RaiseTicket objmodel = new RaiseTicket();
            List<RaiseTicket> objTicket = new List<RaiseTicket>();
            try
            {
                objmodel.Action = "PriorityMasterNEW";
                objTicket = _objIticketmodel.ModuleBind(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.PriorityList = new SelectList(objTicket, "PriorityID", "PriorityName");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTicket = null;
            }
        }
        /// <summary>
        /// Added by suroj kumar pradhan on 21-feb-2021 to view Ticketlist
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult Nxtview(RaiseTicket objmodel)
        {
            List<RaiseTicket> objTicket = null;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                                                              //profile.UserId = 2077;
                                                              //profile.UserType = "HELPDESK USER";
                                                              //profile.UserTypeId = 13;
            //profile.UserId = 59;
            //profile.UserType = "Lessee";
            //profile.UserTypeId = 7;
            ViewBag.userType = profile.UserType;
            ViewBag.UserTypeId = profile.UserTypeId;
            if (TempData["message"] != null)
            {
                ViewBag.Takeactionmsg = TempData["message"];
            }
            try
            {
                objTicket = new List<RaiseTicket>();
                objmodel.Action = "GetData";
                objmodel.Userid = Convert.ToInt16(profile.UserId);
                DateTime expiryDate = DateTime.Now.AddDays(-30);
                if (objmodel.fromdate == null)
                {
                    objmodel.fromdate = Convert.ToDateTime(expiryDate).ToString("dd/MM/yyyy");
                }
                ViewBag.fromdate = objmodel.fromdate;
                if (objmodel.todate == null)
                {
                    objmodel.todate = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
                }
                ViewBag.todate = objmodel.todate;
                objTicket = _objIticketmodel.FetchComplain(objmodel);
                ViewBag.ViewList = objTicket;
                objmodel.fromdate = ViewBag.fromdate;
                objmodel.todate = ViewBag.todate;
                return View(objmodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTicket = null;
            }
        }
        /// <summary>
        /// Added by suroj kumar pradhan on 15-feb-2021 to add Raise Ticket details
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <param name="id"></param>
        /// <param name="OnBehalfOfNamevalue"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(RaiseTicket objmodel, string submit, int ItemID, string OnBehalfOfNamevalue,string OtherThenNonUserStateName2,string OtherThenNonUserDistrictName2,string OtherThenNonUserComplainerName2)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            //profile.UserType = "HELPDESK USER";
            //profile.UserId = 2077;//profile.UserId;
            ViewBag.userType = profile.UserType;          
            if (submit == "Cancel")
            {
                return RedirectToAction("Nxtview", "RaiseTicket");
            }
            #region"Server side Validation"
            if (profile.UserType.Contains("HELPDESK USER"))
            {
                if (Convert.ToInt16(objmodel.ModuleID) == 0)
                {
                    ModelState.AddModelError("ModuleID", "Module Name is required");
                }
                else if (Convert.ToInt16(objmodel.PriorityID) == 0)
                {
                    ModelState.AddModelError("PriorityID", "Priority Name is required");
                }
                else if (string.IsNullOrEmpty(objmodel.ProblemDescription))
                {
                    ModelState.AddModelError("ProblemDescription", "Problem description is required");
                }
            }
            else
            {
                if (Convert.ToInt16(objmodel.OtherThanHelpdesk_ModuleID) == 0)
                {
                    ModelState.AddModelError("OtherThanHelpdesk_ModuleID", "Module Name is required");
                }
            }        
            #endregion
            if (ModelState.IsValid && User != null)
            {
                #region added by Lingaraj on 17-Mar-2022
                objmodel.OnBehalfOfName = OnBehalfOfNamevalue;
                objmodel.OtherThenNonUser_StateName2 = OtherThenNonUserStateName2;
                objmodel.OtherThenNonUser_DistrictName2 = OtherThenNonUserDistrictName2;
                objmodel.OtherThenNonUser_ComplainerName2 = OtherThenNonUserComplainerName2;
                #endregion
                if (objmodel.OnBehalfOfName == "Non User")//If onBehalfOf is selected as Non User
                {
                    objmodel.StateName = objmodel.NonUser_StateName1;
                    objmodel.DistrictName = objmodel.NonUser_DistrictName1;
                    objmodel.ComplainerName = objmodel.NonUser_ComplainerName1;
                    objmodel.ComplainerMobileNumber = objmodel.NonUser_ComplainerMobileNumber1;
                    objmodel.ComplainerEmailID = objmodel.NonUser_ComplainerEmailID1;
                    objmodel.ComplainerUserName = objmodel.NonUser_ComplainerUserName1;
                }

                else if (objmodel.OnBehalfOfName == "Check Post In-Charge"
                    || objmodel.OnBehalfOfName == "End User"
                    || objmodel.OnBehalfOfName == "Lessee"
                    || objmodel.OnBehalfOfName == "Licensee"
                    || objmodel.OnBehalfOfName == "Non User"
                    || objmodel.OnBehalfOfName == "Vehicle Owner"
                    ) //If onBehalfOf is selected as other then Non User
                {
                    objmodel.StateName = objmodel.OtherThenNonUser_StateName2 ?? objmodel.StateName;
                    objmodel.DistrictName = objmodel.OtherThenNonUser_DistrictName2 ?? objmodel.DistrictName;
                    objmodel.ComplainerName = objmodel.OtherThenNonUser_ComplainerName2 ?? objmodel.ComplainerName;
                    objmodel.ComplainerMobileNumber = objmodel.OtherThenNonUser_ComplainerMobileNumber2 ?? objmodel.ComplainerMobileNumber;
                    objmodel.ComplainerEmailID = objmodel.OtherThenNonUser_ComplainerEmailID2 ?? objmodel.ComplainerEmailID;
                    objmodel.ComplainerUserName = objmodel.OtherThenNonUser_ComplainerUserName2 ?? objmodel.ComplainerUserName;
                }
                if (objmodel.TicketID == 0 || objmodel.TicketID == null)
                {
                    objmodel.Action = "Insert";
                }
                else
                {
                    objmodel.Action = "Edit";
                }
                DataTable dt = new DataTable("MultipleFileUpload");
                dt.Columns.Add("FileName");
                dt.Columns.Add("FilePath");
                string uniqueFileName = null; string filePath = null;
                //if (objmodel.Photo != null)
                //{
                //    foreach (IFormFile photo in objmodel.Photo)
                //    {
                //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "HepldeskFile");
                //        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                //        filePath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot/HepldeskFile", uniqueFileName);
                //        using (var fileStream = new FileStream(filePath, FileMode.Create))
                //            photo.CopyTo(fileStream);
                //        dt.Rows.Add(uniqueFileName, filePath);//
                //    }
                //    objmodel.Document = dt;
                //}
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
                objmodel.Userid = Convert.ToInt16(profile.UserId);
                objmodel.Photo = null;
                MessageEF objmessage = new MessageEF();
                objmessage = _objIticketmodel.Add(objmodel);
                TempData["Message"] = objmessage.Satus;
                ModelState.Clear();
                objmodel.Action = "StateBind";
                List<RaiseTicket> objTicket = new List<RaiseTicket>();
                objTicket = _objIticketmodel.BindState(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.Statelist = new SelectList(objTicket, "StateID", "StateName", objmodel.StateID);
                }
                objmodel.Action = "StateBindNonuser";
                objTicket = _objIticketmodel.BindState(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.Statelist2 = new SelectList(objTicket, "OtherThenNonUser_StateName2id", "OtherThenNonUser_StateName2", objmodel.StateID);
                }
                objmodel.Action = "GetAllModuleNew1";
                objTicket = _objIticketmodel.ModuleBind(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.ModuleListNonuser = new SelectList(objTicket, "OtherThanHelpdesk_ModuleID", "OtherThanHelpdesk_ModuleName");
                }
                Proritybind();
                if (string.IsNullOrEmpty(objmodel.OnBehalfOfName) && ItemID == 0)
                {
                    RaiseTicket m = new RaiseTicket();
                    m.StateID = objmodel.StateID;
                    m.StateName = objmodel.StateName;
                    m.DistrictName = objmodel.DistrictName;
                    m.ComplainerName = objmodel.ComplainerName;
                    m.ComplainerMobileNumber = objmodel.ComplainerMobileNumber;
                    m.ComplainerEmailID = objmodel.ComplainerEmailID;
                    m.ComplainerUserName = objmodel.ComplainerUserName;
                    return View(m);
                }
                else
                {
                    //int? idd = null;
                    //return RedirectToAction("Add", "RaiseTicket", new { id = idd });
                    string EncryptUrl = CustomQueryStringHelper.EncryptString("Helpdesk", "Add", "RaiseTicket", new { id = objmodel.ItemID });
                    return LocalRedirect(EncryptUrl);
                }
            }
            else
            {
                RaiseTicket objmodel1 = null;
                List<RaiseTicket> objTicket = null;
                try
                {
                    objmodel1 = new RaiseTicket();
                    objTicket = new List<RaiseTicket>();
                    objmodel1.Action = "GetAllModuleNew";
                    objTicket = _objIticketmodel.ModuleBind(objmodel1);
                    if (objTicket.Count > 0)
                    {
                        ViewBag.ModuleList = new SelectList(objTicket, "ModuleID", "ModuleName");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    objmodel1 = null;
                    objTicket = null;
                }
                try
                {
                    objmodel1 = new RaiseTicket();
                    objTicket = new List<RaiseTicket>();
                    objmodel1.Action = "GetAllModuleNew1";
                    objTicket = _objIticketmodel.ModuleBind(objmodel1);
                    if (objTicket.Count > 0)
                    {
                        ViewBag.ModuleListNonuser = new SelectList(objTicket, "OtherThanHelpdesk_ModuleID", "OtherThanHelpdesk_ModuleName");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    objTicket = null;
                    objmodel1 = null;
                }
                Proritybind();
                try
                {
                    objmodel1 = new RaiseTicket();
                    objTicket = new List<RaiseTicket>();
                    objmodel1.Action = "StateBind";
                    objTicket = _objIticketmodel.BindState(objmodel1);
                    if (objTicket.Count > 0)
                    {
                        ViewBag.Statelist = new SelectList(objTicket, "StateID", "StateName", objmodel1.StateID);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    objTicket = null;
                    objmodel1 = null;
                }
                try
                {
                    objmodel1 = new RaiseTicket();
                    objTicket = new List<RaiseTicket>();
                    objmodel1.Action = "StateBindNonuser";
                    objTicket = _objIticketmodel.BindState(objmodel1);
                    if (objTicket.Count > 0)
                    {
                        ViewBag.Statelist2 = new SelectList(objTicket, "OtherThenNonUser_StateName2id", "OtherThenNonUser_StateName2", objmodel1.OtherThenNonUser_StateName2id);
                    }
                    ViewBag.did = objmodel1.DistrictID;
                    ViewBag.dname = objmodel1.DistrictName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    objTicket = null;
                    objmodel1 = null;
                }
                try
                {
                    objmodel1 = new RaiseTicket();
                    objTicket = new List<RaiseTicket>();
                    objmodel1.Userid = Convert.ToInt16(profile.UserId);
                    objTicket = _objIticketmodel.GetCategoryMaster(objmodel1);
                    if (objTicket.Count > 0)
                    {
                        ViewBag.Categorylist = new SelectList(objTicket, "CategoryID", "CategoryName");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    objTicket = null;
                    objmodel1 = null;
                }
                if (ItemID == 0 || ItemID == null)
                {
                    objmodel = new RaiseTicket();
                    objmodel.Userid = Convert.ToInt16(profile.UserId);
                    objmodel.Photo = null;
                    objmodel = _objIticketmodel.FetchDetails(objmodel);
                    objmodel.ComplainerName = objmodel.ApplicantName;
                    objmodel.ComplainerUserName = objmodel.UserName;
                    ViewBag.MobileNo = objmodel.ComplainerMobileNumber;
                    ViewBag.Email = objmodel.ComplainerEmailID;
                    return View(objmodel);
                }
                return View();
            }
        }
        /// <summary>
        /// Added by suroj on 28-mar-2021 to bind DistrictName
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public JsonResult DistrictBind(int sid)
        {
            List<RaiseTicket> objraise = new List<RaiseTicket>();
            RaiseTicket objticket = new RaiseTicket();
            try
            {
                objticket.Action = "DBindNonuser";
                objticket.StateID = sid;
                objraise = _objIticketmodel.DBind(objticket);
                return Json(objraise);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objraise = null;
                objticket = null;
            }
        }
        /// <summary>
        /// Added by suroj on 14-mar-2021 to update missing files
        /// </summary>
        /// <param name="hid"></param>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult CreateEdit(int hid, RaiseTicket objmodel)
        {
            try
            {
                DataTable dt = new DataTable("MultipleFileUpload");
                dt.Columns.Add("FileName");
                dt.Columns.Add("FilePath");
                string uniqueFileName = null; string filePath = null;
                //if (objmodel.Photo != null)
                //{
                //    foreach (IFormFile photo in objmodel.Photo)
                //    {
                //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "HepldeskFile");
                //        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                //        filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //        using (var fileStream = new FileStream(filePath, FileMode.Create))
                //            photo.CopyTo(fileStream);
                //        dt.Rows.Add(uniqueFileName, filePath);//
                //    }
                //    objmodel.Document = dt;
                //}
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
                objmodel.Userid = Convert.ToInt16(profile.UserId);
                objmodel.Action = "Helpdesk_UpdateRemarks";
                objmodel.TicketID = hid;
                objmodel.Photo = null;
                objobjmodel = _objIticketmodel.Add(objmodel);
                if (objobjmodel.Satus == "1")
                {
                    TempData["message"] = "Data Save Sucessfully";
                }
                return RedirectToAction("Add", "RaiseTicket");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj 16-mar-2021 to edit raiseticket details in Helpdesk Login
        /// </summary>
        /// <param name="REVIEWID"></param>
        /// <returns></returns>
        public JsonResult EdittComponent(int REVIEWID)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            RaiseTicket objRaise = null;
            List<RaiseTicket> objTicket = null;
            try
            {
                objRaise = new RaiseTicket();
                objTicket = new List<RaiseTicket>();
                objRaise.Userid = Convert.ToInt16(profile.UserId);
                objRaise.TicketID = REVIEWID;
                objTicket = _objIticketmodel.GetpopupDetails(objRaise);

                return Json(objTicket);
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
        /// <summary>
        /// Added by suroj on 24-mar-2021 to view District Data userwise
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDistrictDataForUser()
        {
            List<RaiseTicket> objraise = new List<RaiseTicket>();
            RaiseTicket objticket = new RaiseTicket();
            try
            {
                objraise = _objIticketmodel.GetDistrictDataForUser(objticket);
                return Json(objraise);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objraise = null;
                objticket = null;
            }
        }
        /// <summary>
        /// Added by suroj 20-mar-2021 to get FMS Userlist
        /// </summary>
        /// <param name="Usertype"></param>
        /// <param name="Districtid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public JsonResult GetFMSUsersList(int Usertype, int Districtid, string type)
        {
            List<RaiseTicket> objraise = null;
            RaiseTicket objticket = null;
            try
            {
                objraise = new List<RaiseTicket>();
                objticket = new RaiseTicket();
                objticket.intUsertypeid = Usertype;
                objticket.DistrictID = Districtid;
                if (type == "1")
                { objticket.Action = "FMS"; }
                else
                {
                    objticket.Action = "OSU";
                }
                objraise = _objIticketmodel.GetFMSUsersList(objticket);
                return Json(objraise);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objraise = null;
                objticket = null;
            }
        }
        /// <summary>
        /// Added by suroj on 26-mar-2021 to update ticket to forward user
        /// </summary>
        /// <param name="TicketId"></param>
        /// <param name="UserTypeId"></param>
        /// <param name="DistrictId"></param>
        /// <param name="remarks"></param>
        /// <param name="FMSUserId"></param>
        /// <param name="OSUUserId"></param>
        /// <returns></returns>
        public JsonResult Update(int TicketId, int UserTypeId, int DistrictId, string remarks, int FMSUserId, int OSUUserId)
        {
            List<RaiseTicket> objraise = null;
            RaiseTicket objticket = null;
            try
            {
                objraise = new List<RaiseTicket>();
                objticket = new RaiseTicket();
                objticket.TicketID = TicketId;
                objticket.intUsertypeid = UserTypeId;
                objticket.DistrictID = DistrictId;
                objticket.Remarks = remarks;
                objticket.Fmuserid = FMSUserId;
                objticket.Osuuserid = OSUUserId;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objticket.Userid = Convert.ToInt16(profile.UserId);
                int response;
                response = _objIticketmodel.Update(objticket);
                return Json(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objraise = null;
                objticket = null;
            }
        }
        /// <summary>
        /// Added by suroj on 25-mar-2021 to Pull Ticket
        /// </summary>
        /// <param name="TicketId"></param>
        /// <param name="remarks"></param>
        /// <returns></returns>
        public JsonResult PullTicket(int TicketId, string remarks)
        {
            List<RaiseTicket> objraise = new List<RaiseTicket>();
            RaiseTicket objticket = new RaiseTicket();
            try
            {
                objticket.TicketID = TicketId;
                objticket.Action = "PullBack";
                objticket.Remark = remarks;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objticket.Userid = Convert.ToInt16(profile.UserId);
                int response;
                response = _objIticketmodel.PullTicket(objticket);
                return Json(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objraise = null;
                objticket = null;
            }
        }
        /// <summary>
        /// Added by suroj on 28-mar-2021 to Close ticket
        /// </summary>
        /// <param name="hidclose"></param>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Close(int hidclose, RaiseTicket objmodel)
        {
            try
            {
                DataTable dt = new DataTable("MultipleFileUpload");
                dt.Columns.Add("FileName");
                dt.Columns.Add("FilePath");
                string uniqueFileName = null; string filePath = null;
                //if (objmodel.Photo != null)
                //{
                //    foreach (IFormFile photo in objmodel.Photo)
                //    {
                //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "HepldeskFile");
                //        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                //        filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //        using (var fileStream = new FileStream(filePath, FileMode.Create))
                //            photo.CopyTo(fileStream);
                //        dt.Rows.Add(uniqueFileName, filePath);//
                //    }
                //    objmodel.Document = dt;
                //}
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
                objmodel.Userid = Convert.ToInt16(profile.UserId);
                objmodel.Action = "Helpdesk_CloseTicket";
                objmodel.TicketID = hidclose;
                objmodel.Photo = null;
                objobjmodel = _objIticketmodel.CloseTicket(objmodel);
                if (objobjmodel.Satus == "1")
                {
                    TempData["message"] = "Ticket Closed Sucessfully";
                }
                return RedirectToAction("Nxtview", "RaiseTicket");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj kumar pradhan on 17-feb-2021 to save Reopen Ticket
        /// </summary>
        /// <param name="hidReopen"></param>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ReopenTicket(int hidReopen, RaiseTicket objmodel)
        {
            try
            {
                DataTable dt = new DataTable("MultipleFileUpload");
                dt.Columns.Add("FileName");
                dt.Columns.Add("FilePath");
                string uniqueFileName = null; string filePath = null;
                //if (objmodel.Photo != null)
                //{
                //    foreach (IFormFile photo in objmodel.Photo)
                //    {
                //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "HepldeskFile");
                //        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                //        filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //        using (var fileStream = new FileStream(filePath, FileMode.Create))
                //            photo.CopyTo(fileStream);
                //        dt.Rows.Add(uniqueFileName, filePath);//
                //    }
                //    objmodel.Document = dt;
                //}
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
                objmodel.Userid = Convert.ToInt16(profile.UserId);
                objmodel.Action = "Helpdesk_ReOpen";
                objmodel.TicketID = hidReopen;
                objmodel.Photo = null;
                objobjmodel = _objIticketmodel.CloseTicket(objmodel);
                if (objobjmodel.Satus == "4")
                {
                    TempData["message"] = "Ticket Reopen Sucessfully";
                }
                return RedirectToAction("Nxtview", "RaiseTicket");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj kumar pradhan on 17-feb-2021 to upload missing file
        /// </summary>
        /// <param name="hidupdate"></param>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Updatestatus(int hidupdate, RaiseTicket objmodel)
        {
            try
            {
                DataTable dt = new DataTable("MultipleFileUpload");
                dt.Columns.Add("FileName");
                dt.Columns.Add("FilePath");
                string uniqueFileName = null; string filePath = null;
                //if (objmodel.Photo != null)
                //{
                //    foreach (IFormFile photo in objmodel.Photo)
                //    {
                //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "HepldeskFile");
                //        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                //        filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //        using (var fileStream = new FileStream(filePath, FileMode.Create))
                //            photo.CopyTo(fileStream);
                //        dt.Rows.Add(uniqueFileName, filePath);//
                //    }
                //    objmodel.Document = dt;
                //}
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
                objmodel.Userid = Convert.ToInt16(profile.UserId);
                objmodel.Action = "Helpdesk_StatusUpdate_From_OsuFms";
                objmodel.TicketID = hidupdate;
                objmodel.Photo = null;
                objobjmodel = _objIticketmodel.CloseTicket(objmodel);
                if (objobjmodel.Satus == "1")
                {
                    TempData["message"] = "Data Saved Sucessfully";
                }
                return RedirectToAction("Nxtview", "RaiseTicket");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj kumar pradhan on fetch ticket details against usercode
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public JsonResult GetUserDetailsByUserCode(string UserCode)
        {
            List<RaiseTicket> objraise = new List<RaiseTicket>();
            RaiseTicket objticket = new RaiseTicket();
            try
            {
                objticket.FetchUserCode = UserCode;
                objraise = _objIticketmodel.GetUserDetailsByUserCode(objticket);
                return Json(objraise);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objraise = null;
                objticket = null;
            }
        }
        /// <summary>
        /// Added by suroj kumar pradhan on 21-mar-2021 to Bind Items
        /// </summary>
        /// <param name="Moduleid"></param>
        /// <param name="Categoryid"></param>
        /// <returns></returns>
        public JsonResult Itembind(int Moduleid, int Categoryid)
        {
            List<RaiseTicket> objraise = new List<RaiseTicket>();
            RaiseTicket objticket = new RaiseTicket();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objticket.Userid = Convert.ToInt16(profile.UserId);
                objticket.CategoryID = Categoryid;
                objticket.ModuleID = Moduleid;
                objraise = _objIticketmodel.GetItemMaster(objticket);
                return Json(objraise);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objraise = null;
                objticket = null;
            }
        }
        /// <summary>
        /// Added by suroj kumar pradhan on 26-mar-2021 to fetch complainer details
        /// </summary>
        /// <param name="ticketid"></param>
        /// <returns></returns>
        public JsonResult FetchComplinerdtls(int ticketid)
        {
            RaiseTicket objmodel = new RaiseTicket();
            try
            {
                objmodel.TicketID = ticketid;
                objmodel = _objIticketmodel.Fetchuserdetailshistory(objmodel);
                return Json(objmodel);
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
        /// Added by suroj on 28-mar-2021 to download files
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="foldername"></param>
        /// <returns></returns>
        public IActionResult DownloadFiles(string filename, string foldername)
        {
            string filepath = null;
            var absolutePath = filename;
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, foldername);
            if (filename != null)
            {
                if (filepath == null)
                    filepath = Path.Combine(uploadsFolder, filename);
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
        /// <summary>
        /// Added by Lingaraj on 17-mar-2022 to bind ComplainerName against District,UserType
        /// </summary>
        /// <param name="DistrictName"></param>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        public JsonResult GetUserByDistrictAndType(string DistrictName,string UserType)
        {
            List<RaiseTicket> objraise = new List<RaiseTicket>();
            RaiseTicket objticket = new RaiseTicket();
            try
            {
                objticket.DistrictName = DistrictName;
                objticket.UserType = UserType;
                objraise = _objIticketmodel.GetUserByDistrictAndRoleType(objticket);
                return Json(objraise);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objraise = null;
                objticket = null;
            }
        }
        /// <summary>
        /// Added by Lingaraj on 17-mar-2022 to bind ComplainerDetails against ApplicantName
        /// </summary>
        /// <param name="ApplicantName"></param>
        /// <returns></returns>
        public JsonResult GetUserDetails(string ApplicantName)
        {
            List<RaiseTicket> objraise = new List<RaiseTicket>();
            RaiseTicket objticket = new RaiseTicket();
            try
            {
                objticket.ApplicantName = ApplicantName;
                objraise = _objIticketmodel.GetUserDetails(objticket);
                return Json(objraise);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objraise = null;
                objticket = null;
            }
        }
    }
}
