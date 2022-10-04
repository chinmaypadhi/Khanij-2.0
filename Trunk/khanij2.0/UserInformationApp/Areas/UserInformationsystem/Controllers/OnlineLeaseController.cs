// ***********************************************************************
//  Controller Name          : OnlineLeaseController
//  Desciption               : Used to manage Lessee information
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 11-apr-2021
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInformationEF;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.IO;

using UserInformationApp.Models.LesseeProfile;
using System.Data.OleDb;
using System.Xml;
using UserInformationApp.Areas.UserInformationsystem.Models.Mineral;
using System.Text;
using Appkey;
using UserInformationApp.Web;

namespace UserInformationApp.Areas.UserInformationsystem.Controllers
{
    [Area("UserInformationsystem")]
    public class OnlineLeaseController : Controller
    {
        ILesseprofile _objIticketmodel;

       
        private readonly IHostingEnvironment hostingEnvironment;
        public OnlineLeaseController(ILesseprofile objtickettypemastermodel, IHostingEnvironment hostingEnvironment)
        {
            _objIticketmodel = objtickettypemastermodel;
            this.hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// Added by suroj on 11-may-2021 to load profile creation page
        /// </summary>
        /// <param name="FOR"></param>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult OnlineLease(string FOR, int? id)
        {
            List<LeaseApplicationModel> objTicket = null;
           
            LeaseApplicationModel objmodel = null;
            try
            {
                objmodel = new LeaseApplicationModel();
                objTicket = new List<LeaseApplicationModel>();

                objTicket = _objIticketmodel.GetCompMasterData(objmodel);

                if (objTicket.Count > 0)
                {
                    ViewBag.Companylist = new SelectList(objTicket, "CompanyId", "CompanyName");

                }
                objmodel = null;
                objmodel = new LeaseApplicationModel();
                objmodel.LesseeLOI = Convert.ToInt16(id);
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = Convert.ToInt16(profile.UserId);//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                objmodel.SpMode = "GETMajorMineralNonCoalML";


                List<ChekcboxListModel> chkList = new List<ChekcboxListModel>();
                chkList.Add(new ChekcboxListModel() { IsSelected = false, Text = "Government", Value = "Government", id = "GovernmentLand" });
                chkList.Add(new ChekcboxListModel() { IsSelected = false, Text = "Private", Value = "Private", id = "PrivateLand" });

                objmodel.TypeOfLand = chkList;
                objmodel = _objIticketmodel.GetlesseEditdata(objmodel);
                if (objmodel.Status == 1)
                {
                    objmodel.CategoryOfLicensee = "Individual";
                }
                objmodel.FOR = FOR;
                return View(objmodel);
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
        }
        /// <summary>
        /// Added by suroj on 13-may-2021 to create profile for preferred lessee
        /// </summary>
        /// <param name="model"></param>
        /// <param name="StatutoryDocuments"></param>
        /// <param name="TypeOfLands"></param>
        /// <param name="btnValue"></param>
        /// <param name="ExcelKharsa"></param>
        /// <param name="PerformanceSecurity_Installment_Amount"></param>
        /// <param name="PerformanceSecurity_Installment_ScheduleDate"></param>
        /// <param name="PerformanceSecurity_Installment_SubmissionDate"></param>
        /// <param name="DocumentName"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult OnlineLease(LeaseApplicationModel model,List<int> StatutoryDocuments, List<string> TypeOfLands, string btnValue, IFormFile ExcelKharsa, List<string> PerformanceSecurity_Installment_Amount, List<string> PerformanceSecurity_Installment_ScheduleDate, List<string> PerformanceSecurity_Installment_SubmissionDate, List<string> DocumentName)
        {
            #region"server side validation"
            if (Convert.ToInt16(model.CompanyId) == 0)
            {
                ModelState.AddModelError("CompanyId", "Company Name is required");
            }
            else if (string.IsNullOrEmpty(model.NameOfApplicant))
            {
                ModelState.AddModelError("NameOfApplicant", "Authorized Person is required");

            }
            else if (string.IsNullOrEmpty(model.Designation))
            {
                ModelState.AddModelError("Designation", "Designation is required");

            }
            else if (string.IsNullOrEmpty(model.ApplicantMobileNo))
            {
                ModelState.AddModelError("ApplicantMobileNo", "Contact No is required");

            }
            else if (string.IsNullOrEmpty(model.ApplicantEmailId))
            {
                ModelState.AddModelError("ApplicantEmailId", "Email id is required");

            }
            else if (string.IsNullOrEmpty(model.AddressOfApplicant))
            {
                ModelState.AddModelError("AddressOfApplicant", "Address is required");

            }
           
            
           
            else if (string.IsNullOrEmpty(model.Pincode))
            {
                ModelState.AddModelError("Pincode", "Pincode is required");

            }
            else if (string.IsNullOrEmpty(model.AreaInHect))
            {
                ModelState.AddModelError("AreaInHect", "AreaInHect is required");

            }

            #endregion
            if (ModelState.IsValid && User != null)
            {
                DataSet ds_Khasra = new DataSet();
                StringBuilder sb = new StringBuilder();
                if (TypeOfLands != null && TypeOfLands.Count > 0)
                {
                    foreach (var i in TypeOfLands)
                    {
                        sb.Append(i);
                        sb.Append(",");
                    }
                    sb.Length--;
                }
                model.Lands = sb.ToString();
                if (StatutoryDocuments != null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("DocId");
                    foreach (int i in StatutoryDocuments)
                    {
                        dt.Rows.Add(i);
                    }
                    model.dt = dt;
                }
                if (DocumentName != null)
                {
                    DataTable dataTable = new DataTable("Document");
                    dataTable.Columns.Add("Id");
                    dataTable.Columns.Add("Name");
                    dataTable.Columns.Add("IsSelected");
                    for (int i = 0; i < DocumentName.Count(); i++)
                    {
                        dataTable.Rows.Add(i + 1, DocumentName[i], 1);
                    }


                    model.DocumentName = dataTable;
                }

                string uniqueFileName = null; string filePath = null;
                //if (ExcelKharsa != null)
                //{
                //    string fileExtension =
                //                         System.IO.Path.GetExtension(ExcelKharsa.FileName);
                //    //string Filename = SessionWrapper.UserId.ToString() + '_' + ExcelKharsa.FileName;
                //    string Filename = "1" + '_' + DateTime.Now.Ticks + '_' + ExcelKharsa.FileName;

                //    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                //    {

                //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "KharsaExcel");
                //        uniqueFileName = Guid.NewGuid().ToString() + "_" + ExcelKharsa.FileName;
                //        filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //        using (var fileStream = new FileStream(filePath, FileMode.Create))
                //            ExcelKharsa.CopyTo(fileStream);
                //        TempData["ExcelKharsa_FILENAME"] = uniqueFileName;
                //        TempData["ExcelKharsa_FILEPATH"] = filePath;

                //        // Commented Code Snippet

                //        string excelConnectionString = string.Empty;
                //        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                //        //connection String for xls file format.
                //        if (fileExtension == ".xls")
                //        {
                //            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                //        }
                //        //connection String for xlsx file format.
                //        else if (fileExtension == ".xlsx")
                //        {
                //            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                //        }
                //        //Create Connection to Excel work book and add oledb namespace
                //        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                //        excelConnection.Open();
                //        DataTable dt = new DataTable();

                //        dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                //        if (dt == null)
                //        {
                //            return null;
                //        }
                //        String[] excelSheets = new String[dt.Rows.Count];
                //        int t = 0;
                //        //excel data saves in temp file here.
                //        foreach (DataRow row in dt.Rows)
                //        {
                //            excelSheets[t] = row["TABLE_NAME"].ToString();
                //            t++;
                //        }
                //        OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);

                //        string query = string.Format("Select * from [{0}]", excelSheets[0]);
                //        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                //        {
                //            dataAdapter.Fill(ds_Khasra);
                //        }

                //        // Ending Here
                //    }
                //    //if (fileExtension.ToString().ToLower().Equals(".xml"))
                //    //{
                //    //    string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                //    //    if (System.IO.File.Exists(fileLocation))
                //    //    {
                //    //        System.IO.File.Delete(fileLocation);
                //    //    }

                //    //    Request.Files["FileUpload"].SaveAs(fileLocation);
                //    //    XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                //    //    // DataSet ds_Khasra = new DataSet();
                //    //    ds_Khasra.ReadXml(xmlreader);
                //    //    xmlreader.Close();
                //    //}



                //}
                if (model.PAN_Card_File != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "PAN");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PAN_Card_File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.PAN_Card_File.CopyTo(fileStream);
                    model.Path_PAN_Card = filePath;
                    model.File_PAN_Card = uniqueFileName;
                }
                model.PAN_Card_File = null;
                if (model.TIN_Card_File != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "TIN");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.TIN_Card_File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.TIN_Card_File.CopyTo(fileStream);
                    model.Path_TIN_Card = filePath;
                    model.File_TIN_Card = uniqueFileName;
                }
                model.TIN_Card_File = null;
                if (model.DemarcationReport_File != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Demarcation");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.DemarcationReport_File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.DemarcationReport_File.CopyTo(fileStream);
                    model.Path_DemarcationReport = filePath;
                    model.File_DemarcationReport = uniqueFileName;
                }
                model.DemarcationReport_File = null;
                if (model.KhasraNo_File != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "KHASARA_PANCHASALA");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.KhasraNo_File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.KhasraNo_File.CopyTo(fileStream);
                    model.ExcelKhasraNo_FilePath = filePath;
                    model.KhasraNo = uniqueFileName;
                }
                model.KhasraNo_File = null;
                if (model.Coordinates_File != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Coordinates");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Coordinates_File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.Coordinates_File.CopyTo(fileStream);
                    model.Coordinates_FilePath = filePath;
                    model.Coordinates = uniqueFileName;
                }
                model.Coordinates_File = null;
                if (model.TopoSheetNo_File != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "TopoSheetNo");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.TopoSheetNo_File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.TopoSheetNo_File.CopyTo(fileStream);
                    //model.Coordinates_FilePath = filePath;
                    model.TopoSheetNo = uniqueFileName;
                }
                model.TopoSheetNo_File = null;
                if (string.IsNullOrEmpty(model.PerformanceSecurity_Installment_Amount))
                {
                    foreach (string i in PerformanceSecurity_Installment_Amount)
                    {
                        if (!string.IsNullOrEmpty(i))
                        {
                            model.PerformanceSecurity_Installment_Amount = i;
                        }
                    }
                }
                if (string.IsNullOrEmpty(model.PerformanceSecurity_Installment_ScheduleDate))
                {
                    foreach (string i in PerformanceSecurity_Installment_ScheduleDate)
                    {
                        if (!string.IsNullOrEmpty(i))
                        {
                            model.PerformanceSecurity_Installment_ScheduleDate = i;
                        }
                    }
                }
                if (string.IsNullOrEmpty(model.PerformanceSecurity_Installment_SubmissionDate))
                {
                    foreach (string i in PerformanceSecurity_Installment_SubmissionDate)
                    {
                        if (!string.IsNullOrEmpty(i))
                        {
                            model.PerformanceSecurity_Installment_SubmissionDate = i;
                        }
                    }
                }

                if (model.MineralType == "Major Mineral")
                {
                    if (model.LeaseType == "CL")
                    {
                        model.Reserve = null;
                        model.EVR = null;
                        model.FinalPriceOffer = null;
                        model.TotalUpfrontPayment = null;
                        model.PerformanceSecurity = null;
                        model.First_Installment_Amount = null;
                        model.First_Installment_ScheduleDate = null;
                        model.First_Installment_DateOfDiposite = null;
                        //model.First_Installment_Upload = null;
                        model.Second_Installment_Amount = null;
                        model.Second_Installment_ScheduleDate = null;
                        model.Second_Installment_DateOfDiposite = null;
                        //model.Second_Installment_Upload = null;
                        model.Third_Installment_Amount = null;
                        model.Third_Installment_ScheduleDate = null;
                        model.Third_Installment_DateOfDiposite = null;
                       
                    }
                    if (model.LeaseType == "ML")
                    {
                        model.MajorMineral_CL_Reserve = null;
                        model.MajorMineral_CL_EVR = null;
                        model.MajorMineral_CL_FinalPriceOffer = null;
                        model.MajorMineral_CL_PerformanceSecurity_Installment_Amount = null;
                        model.MajorMineral_CL_PerformanceSecurity_Installment_ScheduleDate = null;
                        model.MajorMineral_CL_PerformanceSecurity_Installment_SubmissionDate = null;
                        //model.MajorMineral_CL_PerformanceSecurity_Installment_Upload = null;

                    }
                }
                MessageEF objMessage = new MessageEF();
                objMessage = _objIticketmodel.Add(model);
                if (!string.IsNullOrEmpty(objMessage.Satus))
                {
                    try
                    {
                        //CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        //objDSCResponse.getDSCResponse(model.DSCResponse, "LOI-DGMProfileCreation", Convert.ToInt32(SessionWrapper.UserId)); // Response, For which purpose DSC Used , Return ID
                        if (model.FOR == "View")
                        {
                            TempData["LOIAckMessage"] = "Profile Updated Successfully";
                        }
                        else
                        {
                            TempData["LOIAckMessage"] = objMessage.Msg;
                        }
                        ModelState.Clear();
                        int? idd = null;
                        return RedirectToAction("PreferredBidderRequest", "LeaseApplication", new { id = idd });
                        //return RedirectToAction("PreferredBidderRequest");
                    }
                    catch (Exception)
                    {

                    }

                }
                return View();
            }
            else
            {
                List<LeaseApplicationModel> objTicket = null;

                LeaseApplicationModel objmodel = null;
                try
                {
                    objmodel = new LeaseApplicationModel();
                    objTicket = new List<LeaseApplicationModel>();

                    objTicket = _objIticketmodel.GetCompMasterData(objmodel);

                    if (objTicket.Count > 0)
                    {
                        ViewBag.Companylist = new SelectList(objTicket, "CompanyId", "CompanyName");

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
                    objTicket = null;
                }
                
            }
                
            
        }
/// <summary>
/// Added by suroj on 2-sep-2021 to download particular files
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



        #region DSC Response Verify
        string Signature = string.Empty;
        string OutputResult = "";
        public string CheckVerifyResponse(String contentType, String signDataBase64Encoded, String responseType)
        {
            try
            {
                if (signDataBase64Encoded.Contains("signing canceled"))
                {
                    OutputResult = "";
                }
                else
                {
                    signDataBase64Encoded = signDataBase64Encoded.Replace("IssuerCommonName", " Issuer");
                    signDataBase64Encoded = signDataBase64Encoded.Replace("CommonName", " CommonName").Replace("SerialNo", " SerialNo").Replace("IssuedDate", " IssuedDate").Replace("ExpiryDate", " ExpiryDate").Replace("Email", " Email").Replace("Country", " Country").Replace("CertificateClass", " CertificateClass").Replace("\r\n", "");
                    string[] tokens = signDataBase64Encoded.Split(new[] { " " }, StringSplitOptions.None);

                    string strSign = GetDSCRespnseData(tokens);

                    TempData["DSCResponse"] = signDataBase64Encoded;
                    TempData["Base64Data"] = strSign;

                    // OutputResult = dsv.verify(contentType, strSign, responseType);

                    OutputResult = "SUCCESS";
                }
            }
            catch
            {
            }
            return OutputResult.ToUpper();
        }

        public string GetDSCRespnseData(string[] parameters)
        {
            string strSign = string.Empty;
            string[] strGetMerchantParamForCompare;
            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "SIGNATURE")
                {
                    Signature = Convert.ToString(strGetMerchantParamForCompare[1]);
                    break;
                }
            }
            strSign = Signature;
            return strSign;
        }

      
        #endregion
    }



}