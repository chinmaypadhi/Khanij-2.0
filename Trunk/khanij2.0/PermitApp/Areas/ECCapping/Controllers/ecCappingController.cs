using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using PermitApp.Areas.ECCapping.Models.ECCapping;
using PermitApp.Helper;
using PermitApp.Web;
using PermitEF;

namespace PermitApp.Areas.ECCapping.Controllers
{
    [Area("ECCapping")]
    public class ecCappingController : Controller
    {
        IECCappingModel _capping;
        private IConfiguration Configuration;
        public object JsonRequestBehavior { get; private set; }
        IWebHostEnvironment _hostingEnvironment;
        string OutputResult = "";
        MessageEF objMSmodel = new MessageEF();
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;

        public ecCappingController(IECCappingModel objPermit, IConfiguration _configuration, IHostingEnvironment hostingEnvironment)
        {
            
            Configuration = _configuration;
            _capping = objPermit;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult CapingScreen()
        {
            try
            {
                ECCappingEF objmodel = new ECCappingEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = Convert.ToInt32(profile.UserId);
                objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
                var yr = _capping.GetYear(objmodel);
                var stocks = _capping.GetAllGradeWiseOpeningStock(objmodel);
                ViewBag.msg = 0;
                if (yr != null)
                {
                    ViewBag.Year = yr.CurrentYear[0].Year;
                }
                if (stocks != null)
                {
                    if (stocks.AllStockes != null)
                    {
                        if (stocks.AllStockes[0].MineralGrade != null)
                        {
                            ViewBag.Stock = stocks.AllStockes;
                        }
                        if (stocks.AllStockes[0].MineralGrade == null)
                        {
                            ViewBag.msg = 1;
                        }
                    }
                }
            }

            catch(Exception )
            {

                throw;

            }

           
            return View();
        }


        [HttpPost]
        public IActionResult CapingScreen(ECCappingEF eCCappingEF, List<decimal> GradeWise_OpeningStock, List<int> MineralGradeId)
        {

            try
            {
                ECCappingEF objmodel = new ECCappingEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                objmodel.UserID = Convert.ToInt32(profile.UserId);
                objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
                objmodel.FinancialYear = eCCappingEF.FinancialYear;
                objmodel.MineralGradeId = eCCappingEF.MineralGradeId;
                var yr = _capping.GetYear(objmodel);
                var stocks = _capping.GetAllGradeWiseOpeningStock(objmodel);
                if (yr != null)
                {
                    ViewBag.Year = yr.CurrentYear[0].Year;
                }
                if (stocks != null)
                {
                    ViewBag.Stock = stocks.AllStockes;
                }
                DataTable OpeningStockTable = new DataTable("OpeningStockTable");
                OpeningStockTable.Columns.Add("MineralGradeId", typeof(Int32));
                OpeningStockTable.Columns.Add("GradeWiseStock", typeof(String));

                for (int i = 0; i < GradeWise_OpeningStock.Count; i++)
                {
                    OpeningStockTable.Rows.Add(MineralGradeId[i], GradeWise_OpeningStock[i]);
                }
                objmodel.OpeningStockTable = OpeningStockTable;

                var msg = _capping.AddEccapping(objmodel);
                ViewBag.msg = msg.Satus;
                //return View();
                if (ViewBag.msg == "1")
                {
                    return RedirectToAction("CapingScreenView", "ecCapping");
                }
                if (ViewBag.msg == "2")
                {
                    return View();
                }
            }

            catch(Exception)
            {
                throw;

            }

            return View();
        }


        [HttpGet]
        public IActionResult CapingScreenView()
        {
            try
            {
                ECCappingEF objmodel = new ECCappingEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                objmodel.UserID = Convert.ToInt32(profile.UserId);
                objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
                var Result = _capping.GetAllCappingData(objmodel);
                if (Result != null)
                {
                    ViewBag.Result = Result;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }


        //Update Start
        [HttpGet]
        public IActionResult EditECcapping(int? id)
        {
            try
            {
                ECCappingEF objmodel = new ECCappingEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                objmodel.UserID = Convert.ToInt32(profile.UserId);
                objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
                var yr = _capping.GetYear(objmodel);
                ViewBag.msg = 0;
                if (id != 0)
                {
                    var stocks = _capping.GetGradeOpeningStockById(objmodel);
                    if (yr != null)
                    {
                        ViewBag.Year = yr.CurrentYear[0].Year;
                    }
                    if (stocks.AllStockes != null)
                    {
                        ViewBag.Stock = stocks.AllStockes;
                    }

                }
                else
                {

                    if (yr != null)
                    {
                        ViewBag.Year = yr.CurrentYear[0].Year;
                    }




                }
            }

            catch (Exception)
            {
                throw;
            
            }



            return View();
        }

        [HttpPost]
        public IActionResult EditECcapping(ECCappingEF eCCappingEF, List<decimal> GradeWise_OpeningStock, List<int> MineralGradeId)
        {

            try
            {
                ECCappingEF objmodel = new ECCappingEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                objmodel.UserID = Convert.ToInt32(profile.UserId);

                objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);

                objmodel.FinancialYear = eCCappingEF.FinancialYear;
                objmodel.MineralGradeId = eCCappingEF.MineralGradeId;
                var yr = _capping.GetYear(objmodel);
                var stocks = _capping.GetAllGradeWiseOpeningStock(objmodel);
                if (yr != null)
                {
                    ViewBag.Year = yr.CurrentYear[0].Year;
                }
                if (stocks != null)
                {
                    ViewBag.Stock = stocks.AllStockes;
                }
                DataTable OpeningStockTable = new DataTable("OpeningStockTable");
                OpeningStockTable.Columns.Add("MineralGradeId", typeof(Int32));
                OpeningStockTable.Columns.Add("GradeWiseStock", typeof(String));

                for (int i = 0; i < GradeWise_OpeningStock.Count; i++)
                {
                    OpeningStockTable.Rows.Add(MineralGradeId[i], GradeWise_OpeningStock[i]);
                }
                objmodel.OpeningStockTable = OpeningStockTable;



                var msg = _capping.AddEccapping(objmodel);
                ViewBag.msg = msg.Satus;
                //return View();
                if (ViewBag.msg == "1")
                {
                    return RedirectToAction("CapingScreenView", "ecCapping");
                }
                if (ViewBag.msg == "2")
                {
                    return View();
                }
            }

            catch (Exception)
            {
                throw;
            }

            return View();
        }












        //Update End
        [HttpGet]
        public IActionResult DMOApproval()
        {

            try
            {


                ECCappingEF objmodel = new ECCappingEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                objmodel.UserID = Convert.ToInt32(profile.UserId);
                objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
                var Result = _capping.GetAllApprovalCappingData(objmodel);
                if (Result != null)
                {
                    ViewBag.Result = Result;
                }
            }

            catch (Exception)
            {
                throw;
            }

            return View();

        }

        [HttpPost]
        public JsonResult DMOApproval(string ECCappingID, string Remarks, string IsApproved)
        {

            try
            {

                ECCappingEF objmodel = new ECCappingEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                objmodel.UserID = Convert.ToInt32(profile.UserId);
                objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
                objmodel.ECCappingID = Convert.ToInt32(ECCappingID);
                objmodel.Remarks = Remarks;
                objmodel.ActiveStatus = Convert.ToInt32(IsApproved);

                var Result = _capping.SubmitApproval(objmodel);

                if (Result.Satus == "1")
                {
                    return Json("Ok");

                }
            }

            catch (Exception)

            {
                throw;
            
            }

            return Json("");

        }

        [HttpPost]
        public JsonResult ECCappingPreviousDetails(int id)
        {

            try
            {

                ECCappingEF objmodel = new ECCappingEF();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                objmodel.UserID = Convert.ToInt32(profile.UserId);
                objmodel.UserLoginId = Convert.ToString(profile.UserLoginId);
                objmodel.LesseeID = Convert.ToInt32(id);

                var Result = _capping.GetAllPreviousDetails(objmodel);
                if (Result != null && Result[0].FinancialYear != null )
                {
                    return Json(Result);
                }
            }

            catch (Exception)
            {
                throw;
            }

            return Json("");
        }


















        // DSC Controller Start
        string Signature = string.Empty;
        /// <summary>
        /// Check Verify DSC Response
        /// </summary>
        /// <param name="contentType,signDataBase64Encoded,responseType"></param>
        /// <returns></returns>
        public string CheckVerifyResponse(string contentType, string signDataBase64Encoded, string responseType)
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
                    OutputResult = "SUCCESS";
                }
            }
            catch
            {
            }
            return OutputResult.ToUpper();
        }

        /// <summary>
        /// Get DSC Response Data
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Save DSC PDF File
        /// </summary>
        /// <param name="base64BinaryStr,fileName,ID,UpdateIn"></param>
        /// <returns></returns>

        public JsonResult SavePdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn, string Month_Year)
        {
            string OutputResult = "SUCCESS";
            try
            {
                var ServerPath = "/DSC/WithDSC/" + fileName;
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration["FNDSCCreateFilePATH"]);
                var savepath = Path.Combine(RootPath, fileName);
                try
                {
                    string strFinalString = string.Empty;
                    if (base64BinaryStr.Contains("Signature="))
                    {
                        string strWithoutSign = base64BinaryStr.Replace("Signature=", string.Empty);
                        strFinalString = strWithoutSign.Substring(0, strWithoutSign.IndexOf("CommonName"));
                        strFinalString = strFinalString.Replace("==", string.Empty).Replace("\r", string.Empty);
                    }
                    else
                    {
                        strFinalString = base64BinaryStr.Substring(0, base64BinaryStr.IndexOf("CommonName"));
                        strFinalString = strFinalString.Replace("==", string.Empty).Replace("\r", string.Empty);
                    }

                    if ((System.IO.File.Exists(savepath)))
                    {
                        string file = "File Already Exists";
                    }
                    else
                    {
                        byte[] bytes = Convert.FromBase64String(strFinalString);
                        System.IO.FileStream stream = new FileStream(savepath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    OutputResult = "PDF File Save failed. Please try after some time";
                    return Json(OutputResult.ToUpper());
                }

              
            }
            catch (Exception ex)
            {
                OutputResult = "FAILED";
            }
            return Json(OutputResult.ToUpper());
        }

        /// <summary>
        /// Save Normal PDF File
        /// </summary>
        /// <param name="base64BinaryStr,fileName,ID,UpdateIn"></param>
        /// <returns></returns>

        public JsonResult SaveNormalPdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn)
        {
            string OutputResult = "SUCCESS";
            try
            {

                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration["FNDSCReadFilePATH"]);
                var savepath = Path.Combine(RootPath, fileName);
                using (FileStream fs = new FileStream(savepath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(base64BinaryStr);
                        bw.Write(data);
                        bw.Close();
                    }
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                OutputResult = "FAILED";
            }
            return Json(OutputResult.ToUpper());
        }

        // DSC Controller End








    }
}
