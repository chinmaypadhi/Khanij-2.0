using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using userregistrationEF;
using userregistrationApp.Areas.CommonRailwaySiding.Models;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

using userregistrationApp.Web;
using userregistrationApp.ActionFilter;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace userregistrationApp.Areas.CommonRailwaySiding.Controllers
{
    [Area("CommonRailwaySiding")]
    public class CommonRailwaySidingController : Controller
    {
        MessageEF messageEF = new MessageEF();
        private ICommonRailwaySidingModel _iCommon;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        string filePath = string.Empty;
        public CommonRailwaySidingController(ICommonRailwaySidingModel iCommon, IHostingEnvironment hostingEnvironment,
             IConfiguration configuration)
        {
            _iCommon = iCommon;
            this._hostingEnvironment = hostingEnvironment;
            this._configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [SkipEncryptedTask]
        public ActionResult AddCommonRailwaySiding(string id)
        {
            try
            {

                userregistrationEF.CommonRailwaySidingModel objCommonModel = new userregistrationEF.CommonRailwaySidingModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objCommonModel.intCreatedBy = profile.UserId;

                CRSDropDown objCommonDDL = new CRSDropDown();
                ViewBag.RailwaySiding = Enumerable.Empty<SelectListItem>();
                ViewBag.RailwayZone = Enumerable.Empty<SelectListItem>();
                ViewBag.RSGrade = Enumerable.Empty<SelectListItem>();
                ViewBag.Lessee = Enumerable.Empty<SelectListItem>();

                //----Railway zone-----
                objCommonDDL.Check = 1;
                var varRailwayZone = _iCommon.BindCRSDDL(objCommonDDL);
                ViewBag.RailwayZone = varRailwayZone.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //----Railway Siding-------
                objCommonDDL.Check = 2;
                var varRailwaySiding = _iCommon.BindCRSDDL(objCommonDDL);
                ViewBag.RailwaySiding = varRailwaySiding.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //----Grade-------
                objCommonDDL.Check = 3;
                var varRSGrade = _iCommon.BindCRSDDL(objCommonDDL);
                ViewBag.RSGrade = varRSGrade.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();


                //----Lessee-------
                objCommonDDL.Check = 4;
                objCommonDDL.Id = profile.UserId;
                var varLessee = _iCommon.BindCRSDDL(objCommonDDL);
                ViewBag.Lessee = varLessee.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                //----District-------
                objCommonDDL.Check = 5;
                objCommonDDL.Id = profile.UserId;
                var district = _iCommon.BindCRSDDL(objCommonDDL);
                ViewBag.dist = district.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();



                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    objCommonModel.Check = 6;
                    objCommonModel.CRSId = Convert.ToInt32(id);
                    objCommonModel = _iCommon.ViewCommonRailwaySidingDetails(objCommonModel);
                    ViewBag.Button = "Update";
                    ViewBag.Button1 = "Cancel";
                    return View(objCommonModel);
                }
                else
                {
                    ViewBag.Button = "Submit";
                    ViewBag.Button1 = "Reset";
                    return View(objCommonModel);

                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        [HttpPost]
        public JsonResult BindRailwaySiding(int RailwayZoneId)
        {
            try
            {
                userregistrationEF.CRSDropDown objCommonDDL = new userregistrationEF.CRSDropDown();
                //----Railway Siding-------
                objCommonDDL.Check = 2;
                objCommonDDL.Id = RailwayZoneId;
                var varRailwaySiding = _iCommon.BindCRSDDL(objCommonDDL);
                return Json(varRailwaySiding);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult BindLessee(int? Id)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                Id = profile.UserId;

                userregistrationEF.CRSDropDown objCommonDLL = new CRSDropDown();
                objCommonDLL.Check = 4;
                objCommonDLL.Id = Id;
                var varLessee = _iCommon.BindCRSDDL(objCommonDLL);
                return Json(varLessee);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult AddCommonRailwaySiding(userregistrationEF.CommonRailwaySidingModel objmodel, string submit, IFormFile selectedFile)
        {

            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.intCreatedBy = profile.UserId;

                if (string.IsNullOrEmpty(objmodel.Area))
                {
                    ModelState.AddModelError("Area", "Area is required");
                }
                if (Convert.ToInt32(objmodel.RailwayZoneId) <= 0)
                {
                    ModelState.AddModelError("RailwayZoneId", "RailwayZone is required");
                }
                if (Convert.ToInt32(objmodel.RSId) <= 0)
                {
                    ModelState.AddModelError("RSId", "Railway Siding is required");
                }
                if (string.IsNullOrEmpty(objmodel.RSAddress))
                {
                    ModelState.AddModelError("RSAddress", "Address is required");
                }

                if (string.IsNullOrEmpty(objmodel.RSLatitute))
                {
                    ModelState.AddModelError("RSLatitute", "Latitute is required");
                }
                if (string.IsNullOrEmpty(objmodel.RSLongitute))
                {
                    ModelState.AddModelError("RSLongitute", "Longitute is required");
                }
                if (Convert.ToInt32(objmodel.RSGradeid) <= 0)
                {
                    ModelState.AddModelError("RSGradeid", "Grade is required");
                }

                if (objmodel.LesseeCount == null)
                {
                    ModelState.AddModelError("LesseeCount", "Lessee Name is required");
                }


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
                            filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("CommonRailwaySiding"), fileName);
                            var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("CommonRailwaySiding"));
                            string UploadFolderPath = Path.Combine(RootPath, fileName);
                            if (!Directory.Exists(RootPath))
                                Directory.CreateDirectory(RootPath);
                            DirectoryInfo di = new DirectoryInfo(RootPath);
                            di.Attributes = FileAttributes.Normal;
                            using (var stream = new FileStream(UploadFolderPath, FileMode.Create))
                            {
                                selectedFile.CopyTo(stream);
                            }
                            objmodel.RsGradeDocPath = filePath;
                            objmodel.RSGradeDoc = fileName;
                        }
                    }
                    #endregion


                    string _actionId = "";

                    if (objmodel.LesseeCount != null && objmodel.LesseeCount.Count > 0)
                    {
                        for (int i = 0; i < objmodel.LesseeCount.Count; i++)
                        {
                            _actionId += objmodel.LesseeCount[i].ToString();
                            _actionId += ",";
                        }
                    }
                    objmodel.LesseeList = _actionId;

                    if (objmodel.CRSId == null)
                    {
                        objmodel.Check = 1;
                        objMessageEF = _iCommon.AddCommonRailwaySiding(objmodel);
                    }
                    else
                    {
                        objmodel.Check = 2;
                        objMessageEF = _iCommon.AddCommonRailwaySiding(objmodel);
                    }
                    if (objMessageEF.Satus == "1" && objmodel.CRSId == null)
                    {
                       

                        TempData["msg"] = "1";//data Details Saved Successfully
                        return RedirectToAction("AddCommonRailwaySiding");
                    }
                    if (objMessageEF.Satus == "3" && objmodel.CRSId != null)
                    {
                        TempData["msg"] = "3";//data Updated Sucessfully
                        return RedirectToAction("ViewCommonRailwaySiding");
                    }
                    else if (objMessageEF.Satus == "2")
                    {
                        TempData["msg"] = "2";//data Details allready exists
                    }
                    else
                    {
                        TempData["msg"] = "Error ! while Saving common railway siding Details";
                    }
                }
                return RedirectToAction("ViewCommonRailwaySiding");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objMessageEF = null;
            }


            //return View();
        }

        public ViewResult ViewCommonRailwaySiding()
        {
            CommonRailwaySidingModel_Query objCommon = new CommonRailwaySidingModel_Query();
            List<CommonRailwaySidingModel_Query> listCommon = new List<CommonRailwaySidingModel_Query>();

            try
            {
                objCommon.Check = 6;
                listCommon = _iCommon.ViewCommonRailwaySiding(objCommon);
            }
            catch (Exception)
            {

                throw;
            }
            return View(listCommon);
        }
        [SkipEncryptedTask]
        public ActionResult DeleteCommonRailwaySiding(string Id)
        {
            try
            {

                MessageEF objMessage = new MessageEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                userregistrationEF.CommonRailwaySidingModel objModel = new userregistrationEF.CommonRailwaySidingModel();
                objModel.intCreatedBy = profile.UserId;
                objModel.CRSId = Convert.ToInt32(Id);
                objModel.Check = 3;
                objMessage = _iCommon.DeleteCommonRailwaySiding(objModel);
                if (objMessage.Satus == "1")
                {
                    TempData["msg"] = "4";// "Data Deleted Sucessfully";
                    return RedirectToAction("ViewCommonRailwaySiding");
                }
                else
                {
                    TempData["msg"] = "Data not Deleted Sucessfully";
                    return RedirectToAction("ViewCommonRailwaySiding");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region inbox
        public ActionResult CommonRailwaySidingInbox()
        {
            CommonRailwaySidingInboxEF_Query objCommon = CommonRailwaySidingInboxEF_Query.GetInstance;
            List<CommonRailwaySidingInboxEF_Query> listCommon = new List<CommonRailwaySidingInboxEF_Query>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

            try
            {
                objCommon.Check = 1;
                objCommon.intCreatedBy = profile.UserId;
                listCommon = _iCommon.CommonRailwaySidinginbox(objCommon);
                return View(listCommon);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public JsonResult TakeAction(int? CRSId,int? StatusId, string Remarks,int? districtid, string representname, string mobile, string Email, string createdby)
        {
            CommonRailwaySidingTakeAction objCommon = CommonRailwaySidingTakeAction.GetInstance;
            MessageEF objmessage = new MessageEF();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objCommon.intCreatedBy = profile.UserId;
            objCommon.UserName = profile.UserName;
            try
            {
                objCommon.Check = 1;
                objCommon.CRSId = CRSId;
                objCommon.intStatus = StatusId;
                objCommon.vchRemarks = Remarks;
                objCommon.DistrictId = districtid;
                objCommon.EmailId = Email;
                objCommon.MobileNo = mobile;
                objCommon.RepresentitiveName = representname;
                objCommon.CreatedBy = createdby;
                objCommon.UserName = representname;
                objCommon.UserId = profile.UserId;
                objCommon.UserLoginId = profile.UserLoginId;
                objCommon.Password = profile.Password;
                objCommon.UserId = profile.RoleId;
                objmessage = _iCommon.TakeAction(objCommon);

                objCommon.Check = 2;
                objmessage = _iCommon.CreatenewUser(objCommon);

                #region Send Mail Message
                if (!string.IsNullOrEmpty(objCommon.MobileNo))
                {
                   
                    SMS obj = new SMS();
                    string msg = "Dear" + objCommon.RepresentitiveName + "," + Environment.NewLine + Environment.NewLine + "You have successfully register to khanij online please login to system by below credentials, " + Environment.NewLine + Environment.NewLine + "User Name : " + objCommon.UserName + Environment.NewLine + "Password : " + objCommon.Password + " CHiMMS, GoCG";
                    string templateid = "1307161883241105388";
                    obj.mobileNo = objCommon.MobileNo;
                    obj.message = msg;
                    obj.templateid = templateid;
                    messageEF = _iCommon.Main(obj);

                }

                if (!string.IsNullOrEmpty(objCommon.EmailId))
                {
                    //MailService dmoMail = new MailService();
                    //dmoMail.SendUserRegistrationMail(model);
                }
                #endregion



             


                return Json(messageEF);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public ActionResult CommonRailwaySidingInboxView()
        {
            CommonRailwaySidingInboxEF_Query objCommon = CommonRailwaySidingInboxEF_Query.GetInstance;
            List<CommonRailwaySidingInboxEF_Query> listCommon = new List<CommonRailwaySidingInboxEF_Query>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

            try
            {
                objCommon.Check = 2;
                objCommon.intCreatedBy = profile.UserId;
                listCommon = _iCommon.CommonRailwaySidinginbox(objCommon);
                return View(listCommon);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        public ActionResult Fileupload()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Fileupload(IFormFile postedFile)
        {
            CommonRailwaySidingFile_Upload model = new CommonRailwaySidingFile_Upload();
            DataSet ds_Khasra = new DataSet();
            StringBuilder sb = new StringBuilder();
            string uniqueFileName = null; string filePath = null;
            if (postedFile != null)
            {
                string fileExtension = System.IO.Path.GetExtension(postedFile.FileName);
                //string Filename = SessionWrapper.UserId.ToString() + '_' + ExcelKharsa.FileName;
                string Filename = "1" + '_' + DateTime.Now.Ticks + '_' + postedFile.FileName;

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "KharsaExcel");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + postedFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        postedFile.CopyTo(fileStream);
                    TempData["ExcelKharsa_FILENAME"] = uniqueFileName;
                    TempData["ExcelKharsa_FILEPATH"] = filePath;

                    // Commented Code Snippet

                    string excelConnectionString = string.Empty;
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    //connection String for xls file format.
                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExtension == ".xlsx")
                    {
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    //Create Connection to Excel work book and add oledb namespace
                    //using (OleDbConnection conn = new OleDbConnection(excelConnectionString))
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dt = new DataTable();

                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }
                    String[] excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    //excel data saves in temp file here.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[t] = row["TABLE_NAME"].ToString();
                        t++;
                    }
                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);

                    string query = string.Format("Select * from [{0}]", excelSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(ds_Khasra);

                    }

                    DataTable dt1 = ds_Khasra.Tables[0];
                    List<CommonRailwaySidingFile_Upload> objlist = new List<CommonRailwaySidingFile_Upload>();

                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        #region ReadColumn
                        //for (int i = 0; i < dt1.Rows.Count; i++)
                        //{
                        //    CommonRailwaySidingFile_Upload model1 = new CommonRailwaySidingFile_Upload();

                        //    model1.UniqNumber = Convert.ToString(dt1.Rows[i]["UniqNumber"]);
                        //    model1.DONumber = Convert.ToString(dt1.Rows[i]["DONumber"]);
                        //    model1.DODate = Convert.ToString(dt1.Rows[i]["DODate"]);
                        //     model1.SCH = Convert.ToString(dt1.Rows[i]["SCH"]);

                        //    if(!(dt1.Rows[i]["DOQty"] is DBNull))
                        //    {
                        //        model1.DOQty = Convert.ToDecimal(dt1.Rows[i]["DOQty"]);
                        //    }

                        //    model1.PartyCode = Convert.ToString(dt1.Rows[i]["PartyCode"]);
                        //    model1.PartyName = Convert.ToString(dt1.Rows[i]["PartyName"]);
                        //    model1.CollieryCode = Convert.ToString(dt1.Rows[i]["CollieryCode"]);
                        //    model1.CollieryName = Convert.ToString(dt1.Rows[i]["CollieryName"]);
                        //    model1.MineralForm = Convert.ToString(dt1.Rows[i]["MineralForm"]);
                        //    model1.MineralGrade = Convert.ToString(dt1.Rows[i]["MineralGrade"]);
                        //    if (!(dt1.Rows[i]["MineralSize"] is DBNull))
                        //    {
                        //        model1.MineralSize = Convert.ToInt32(dt1.Rows[i]["MineralSize"]);
                        //    }

                        //   model1.DOStartDate = Convert.ToString(dt1.Rows[i]["DOStartDate"]);
                        //   model1.DOEndDate = Convert.ToString(dt1.Rows[i]["DOEndDate"]);
                        //    if (!(dt1.Rows[i]["SalePrice"] is DBNull))
                        //    {
                        //        model1.SalePrice = Convert.ToDecimal(dt1.Rows[i]["SalePrice"]);
                        //    }
                        //    objlist.Add(model1);

                        //}
                        #endregion

                        ExcelDataValues objmodel2 = new ExcelDataValues();
                        objmodel2.CommonRailwaySidingFile_Upload = dt1;
                        messageEF = _iCommon.fileupload(objmodel2);
                        //if (messageEF.Satus == "SUCCESS")
                        //{
                        //    TempData["Message"] = "1";
                        //}
                        //else
                        //{
                        //    TempData["Message"] = "2";
                        //}
                    }
                }

            }
            return Json(messageEF);
        }



    }
}
