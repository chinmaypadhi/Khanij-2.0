// ***********************************************************************
//  Controller Name          : DailyProduction
//  Desciption               : Add/View/Delete Daily Production Details 
//  Created By               : Debaraj Swain
//  Created On               : 01 April 2021
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReturnApp.Web;
using ReturnEF;
using Microsoft.AspNetCore.Mvc;
using ReturnApp.Areas.Dailyproduction.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Appkey;
using Newtonsoft.Json;

namespace ReturnApp.Areas.Dailyproduction.Controllers
{
    [Area("DailyProduction")]
    public class DailyProductionController : Controller
    {
        string SBIENCKeyPath = "";
        EncryptDecrypt objencdec = new EncryptDecrypt();
        IDailyProductionModel _objIDailyProductionModel;
        MessageEF objobjmodel = new MessageEF();
        public DailyProductionController(IDailyProductionModel objDailyProductionModel)
        {
            _objIDailyProductionModel = objDailyProductionModel;
        }

        /// <summary>
        /// Get Portion of Add Dailly Production Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public IActionResult Add(int id = 0)
        {
            DailyProductionModel objmodel = new DailyProductionModel();
            DailyProductionModel objDP = new DailyProductionModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objDP.UserId = profile.UserId;
            objDP = _objIDailyProductionModel.GetMineralName(objDP);
            ViewBag.MineralID = objDP.MineralId;
            ViewBag.MineralName = objDP.MineralName;
            ViewBag.TotalQty = objDP.TotalQty;
            objDP = _objIDailyProductionModel.GetTotalCap(objDP);
            objDP.MineralId = ViewBag.MineralID;
            objDP.MineralName = ViewBag.MineralName;
            objDP.TotalQty = ViewBag.TotalQty;
            TempData["MineralId"] = objDP.MineralId;
            objDP.ProductionDataAvailableStatus = "Yes";
            objmodel.UserId = profile.UserId;
            objmodel.MineralId = profile.MineralId;
            //objmodel.MineralId =34;
            var x = _objIDailyProductionModel.GetMineralDDL(objmodel);

            if (x.GetMineralLst != null)
            {
                ViewBag.ViewMineralList = x.GetMineralLst.Select(c => new SelectListItem
                {
                    Text = c.MineralForm,
                    Value = c.MineralFormID.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewMineralList = Enumerable.Empty<SelectListItem>();
            }
            return View(objDP);
        }

        /// <summary>
        /// Get Grade list by Mineral form ID
        /// </summary>
        /// <param name="intMineralFormID"></param>
        /// <returns>Json String</returns>
        public JsonResult GetGradeList(int intMineralFormID)
        {
            DailyProductionModel objGrade = null;
            try
            {
                objGrade = new DailyProductionModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objGrade.UserId = profile.UserId;
                objGrade.MineralNatureId = intMineralFormID;
                var x = _objIDailyProductionModel.GetGradeDDL(objGrade);
                var SList = x.GetMineralLst.ToList();
                return Json(SList);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objGrade = null;
            }

        }

        /// <summary>
        /// Save Dailly Production Data
        /// </summary>
        /// <param name="QtyArray"></param>
        /// <param name="dtArray"></param>
        /// <param name="mineralformidArray"></param>
        /// <param name="mineralgradeidArray"></param>
        /// <returns>Json String</returns>
        [HttpPost]
        public JsonResult SaveDailyProductionGrid(string QtyArray, string dtArray, string mineralformidArray, string mineralgradeidArray)
        {
            string[] Quantity_Array = QtyArray.TrimEnd(',').Split(',');
            string[] Date_Array = dtArray.TrimEnd(',').Split(',');
            string[] MineralFormId_Array = mineralformidArray.TrimEnd(',').Split(',');
            string[] MineralGradeId_Array = mineralgradeidArray.TrimEnd(',').Split(',');
            try
            {
                if (QtyArray != null && dtArray != null && mineralformidArray != null && mineralgradeidArray != null)
                {
                    DailyProductionModel objDP = new DailyProductionModel();
                    DataTable dataTable = new DataTable("Daily_Production_TypeTable");
                    //we create column names as per the type in DB 
                    dataTable.Columns.Add("ID", typeof(int));
                    dataTable.Columns.Add("MineralId", typeof(int));
                    dataTable.Columns.Add("Date", typeof(string));
                    dataTable.Columns.Add("MineralFormId", typeof(int));
                    dataTable.Columns.Add("MineralGradeId", typeof(int));
                    dataTable.Columns.Add("Quantity", typeof(decimal));

                    //and fill in some values
                    for (var i = 0; i < Quantity_Array.Count(); i++)
                    {
                        if (MineralFormId_Array[i] == "")
                        {
                            MineralFormId_Array[i] = "0";
                        }
                        if (MineralGradeId_Array[i] == "")
                        {
                            MineralGradeId_Array[i] = "0";
                        }
                        if (Quantity_Array[i] == "")
                        {
                            Quantity_Array[i] = "0";
                        }
                        dataTable.Rows.Add(i + 1, 11, Date_Array[i].ToString(), Convert.ToInt32(MineralFormId_Array[i]), Convert.ToInt32(MineralGradeId_Array[i]), Convert.ToDecimal(Quantity_Array[i]));
                    }
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    objDP.UserId = profile.UserId;
                    string jsonSerialize = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
                    objDP.jsonSerialize = jsonSerialize;
                   // objDP.DT = dataTable;
                    objobjmodel = _objIDailyProductionModel.InsertDailyProd(objDP);
                    string result = objobjmodel.Msg;
                    return Json(result);
                }
                return Json("Please fill the required fields");
            }
            catch (Exception ex)
            {
                return Json("Record Already Present/Something went wrong!");
            }
        }

        /// <summary>
        /// Get portion of Dailly Production Summary Report
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns>View</returns>
        public IActionResult DailyProductionSummaryReport(DailyProductionModel objmodel)
        {
            try
            {

                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                ViewBag.DailyProductionSummaryReport = _objIDailyProductionModel.ViewSReport(objmodel);
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

        /// <summary>
        /// Get Portion of Daily Production Details Report
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns>View</returns>
        public IActionResult DailyProductionDetailsReport(DailyProductionModel objmodel)
        {
            try
            {

                DailyProductionModel Objmonth = new DailyProductionModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                Objmonth.UserId = profile.UserId;
                Objmonth = _objIDailyProductionModel.GetMonth(objmodel);
                ViewBag.Month = Objmonth.ProductionMonth;
                Objmonth = null;
                DailyProductionModel ObjYear = new DailyProductionModel();
                Objmonth.UserId = profile.UserId;
                ObjYear = _objIDailyProductionModel.GetYear(ObjYear);
                ViewBag.Year = ObjYear.ProductionYear;
                ObjYear = null;
                string month = ViewBag.Month;
                string Year = ViewBag.Year;
                string MONTHYEAR = month + ' ' + Year;
                objmodel.MonthYear = MONTHYEAR;
                Objmonth.UserId = profile.UserId;
                objmodel.ProductionMonth = ViewBag.Month;
                objmodel.ProductionYear = ViewBag.Year;
                ViewBag.DailyProductionDetailsReport = _objIDailyProductionModel.ViewDetailsReport(objmodel);
                int x = ViewBag.DailyProductionDetailsReport.Count;
                ViewBag.tablerecordconnt = x;
                if (TempData["submitmsgp"] != null)
                {
                    ViewBag.submitmsgp = TempData["submitmsgp"].ToString();
                }
                if (TempData["msg"] != null)
                {
                    ViewBag.delmsg = TempData["msg"].ToString();
                }
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

        /// <summary>
        /// Delete Dailly Production details Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public IActionResult Delete(int id = 0)
        {
            DailyProductionModel objmodel = new DailyProductionModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = profile.UserId;
            objmodel.DailyProductionMasterId = id;
            objobjmodel = _objIDailyProductionModel.Delete(objmodel);
            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Data Deleted Sucessfully";
                return RedirectToAction("DailyProductionDetailsReport");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully";
                return RedirectToAction("DailyProductionDetailsReport");
            }
        }

        /// <summary>
        /// Post portion of Dailly Production Details Report
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns>View</returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult DailyProductionDetailsReport(DailyProductionModel objmodel, string submit)
        {
            try
            {
                DailyProductionModel Objmonth = new DailyProductionModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                Objmonth.UserId = profile.UserId;
                Objmonth = _objIDailyProductionModel.GetMonth(objmodel);
                ViewBag.Month = Objmonth.ProductionMonth;
                Objmonth = null;
                DailyProductionModel ObjYear = new DailyProductionModel();
                ObjYear.UserId = profile.UserId;
                ObjYear = _objIDailyProductionModel.GetYear(ObjYear);
                ViewBag.Year = ObjYear.ProductionYear;
                ObjYear = null;
                objmodel.UserId = profile.UserId;
                objmodel.ProductionMonth = ViewBag.Month;
                objmodel.ProductionYear = ViewBag.Year;
                objobjmodel = _objIDailyProductionModel.SubmitDp(objmodel);
                TempData["submitmsgp"]= objobjmodel.Msg;
                return RedirectToAction("DailyProductionDetailsReport");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Portion of Monthly coal Production Payment
        /// </summary>
        /// <returns>View</returns>
        public IActionResult MonthlyCoalProductionPayment()
        {
            DailyProductionModel objDP = new DailyProductionModel();
            var x = _objIDailyProductionModel.GetMonthDDL(objDP);

            if (x.GetMonthLst != null)
            {
                ViewBag.ViewMonthList = x.GetMonthLst.Select(c => new SelectListItem
                {
                    Text = c.Months,
                    Value = c.Months.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewMonthList = Enumerable.Empty<SelectListItem>();
            }

            var y = _objIDailyProductionModel.GetYearDDL(objDP);

            if (y.GetYearLst != null)
            {
                ViewBag.ViewYearList = y.GetYearLst.Select(c => new SelectListItem
                {
                    Text = c.Year,
                    Value = c.Year.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewYearList = Enumerable.Empty<SelectListItem>();
            }
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objDP.UserId = profile.UserId;
            objDP = _objIDailyProductionModel.GetMineralName(objDP);
            ViewBag.MineralID = objDP.MineralId;
            ViewBag.MineralName = objDP.MineralName;
            objDP.UserId = profile.UserId;
            objDP = _objIDailyProductionModel.GetPaymentDetails(objDP);
            objDP.MineralId = ViewBag.MineralID;
            objDP.MineralName = ViewBag.MineralName;

            DailyProductionModel Objmonth = new DailyProductionModel();
            Objmonth.UserId = profile.UserId;
            Objmonth = _objIDailyProductionModel.GetMonth(Objmonth);
            ViewBag.Month = Objmonth.ProductionMonth;
            Objmonth = null;
            DailyProductionModel ObjYear = new DailyProductionModel();
            ObjYear.UserId = profile.UserId;
            ObjYear = _objIDailyProductionModel.GetYear(ObjYear);
            ViewBag.Year = ObjYear.ProductionYear;
            ObjYear = null;
            objDP.ProductionMonth = ViewBag.Month;
            objDP.ProductionYear = ViewBag.Year;

            return View(objDP);
        }

        /// <summary>
        /// Get Monthly coal Production Payment
        /// </summary>
        /// <param name="ProductionYear"></param>
        /// <param name="ProductionMonth"></param>
        /// <returns>Json String</returns>
        public JsonResult GetMonthlyCoalProductionPayment(string ProductionYear, string ProductionMonth)
        {
            DailyProductionModel model = new DailyProductionModel();
            string MonthYear = null;
            if (!(string.IsNullOrEmpty(ProductionMonth) && string.IsNullOrEmpty(ProductionYear)))
            {
                MonthYear = ProductionMonth + ' ' + ProductionYear;
            }
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserId = profile.UserId;
            model.MonthYear = MonthYear;
            model = _objIDailyProductionModel.GetPaymentDetailsMonthYear(model);
            if (model.TotalProduction != null && model.ProductionMonthlyAmount != null && model.TotalPayableProductionMonthlyAmount != null)
            {
                return Json(model);
            }

            else
            {
                return Json(model);
            }



        }

        /// <summary>
        /// Get Month in Number
        /// </summary>
        /// <param name="monthname"></param>
        /// <returns>Int</returns>
        public int GetMonthNumber(string monthname)
        {
            int monthNumber = 0;
            switch (monthname)
            {
                case "April":
                    monthNumber = 05;
                    break;
                case "May":
                    monthNumber = 06;
                    break;
                case "June":
                    monthNumber = 07;
                    break;
                case "July":
                    monthNumber = 08;
                    break;
                case "August":
                    monthNumber = 09;
                    break;
                case "September":
                    monthNumber = 10;
                    break;
                case "October":
                    monthNumber = 11;
                    break;
                case "November":
                    monthNumber = 12;
                    break;
                case "December":
                    monthNumber = 01;
                    break;
                case "January":
                    monthNumber = 02;
                    break;
                case "February":
                    monthNumber = 03;
                    break;
                case "March":
                    monthNumber = 04;
                    break;
                default:
                    monthNumber = 00;
                    break;
            }
            return monthNumber;
        }

        /// <summary>
        /// Get Year
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns>Int</returns>
        public int GetYear(string month, string year)
        {
            int returnyear = 0;
            switch (month)
            {
                case "December":
                    returnyear = Convert.ToInt32(year) + 1;
                    break;
                default:
                    returnyear = Convert.ToInt32(year);
                    break;
            }
            return returnyear;
        }

        /// <summary>
        /// Get MD5 Hash Code
        /// </summary>
        /// <param name="name"></param>
        /// <returns>String</returns>
        protected string GetMD5Hash(string name)
        {

            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encode = new UTF8Encoding();
            byte[] ba = md5.ComputeHash(encode.GetBytes(name));
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        Byte[] GetFileBytes(String filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;
                buffer = new byte[length];
                int count;
                int sum = 0;
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        /// <summary>
        /// Encrypt Data
        /// </summary>
        /// <param name="textToEncrypt"></param>
        /// <returns>String</returns>
        string Encrypt(string textToEncrypt)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] pwdBytes = GetFileBytes(SBIENCKeyPath);
            byte[] keyBytes = new byte[0x10];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
            return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
        }

        /// <summary>
        /// Get Monthly coal production Payment
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View</returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult MonthlyCoalProductionPayment(DailyProductionModel model)
        {
            object retID = 0;
            int monthInDigit = 0;
            int Year = 0;

             try
                {
                    if (!string.IsNullOrEmpty(model.ProductionMonth))
                    {
                        try
                        {
                            string currentdatetime = DateTime.Now.ToString("yyyy-MM-dd");
                            string[] monthYear = model.ProductionMonth.Split(' ');
                            monthInDigit = GetMonthNumber(monthYear[0]);
                            Year = GetYear(monthYear[0], monthYear[1]);


                            DateTime currentDate = Convert.ToDateTime(currentdatetime);
                            DateTime compareDate = Convert.ToDateTime(Year.ToString() + '-' + monthInDigit.ToString() + '-' + "20");

                            DateTime AllowDate = Convert.ToDateTime("2020-05-31");
                            if (currentDate > compareDate && compareDate > AllowDate)
                            {
                                TempData["Message"] = "Payment of the Month " + monthYear[0] + " is submitted till 20th of Succeeding Month.";
                                return View();
                            }

                        }
                        catch (Exception ex)
                        {
                            TempData["Message"] = "Something went wrong !";
                            return View();
                        }

                    }

                    {
                        if (model.PaymentMode != 0) // for offline payment mode
                        {
                        string propertyPath = ConfigurationManager.MySettings["MySettings:PropertyPath"];
                        DailyProductionModel DP = new DailyProductionModel();
                        UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                        DP.UserId = profile.UserId;
                            DP = _objIDailyProductionModel.GetUniqueID(DP);
                            ViewBag.retID = DP.UniqueID;
                            DP = null;
                            PaymentModel payment = new PaymentModel();
                            RequestURL objRequestURL = new RequestURL();
                            String response = string.Empty;
                        model.UserId = profile.UserId;
                            model.UniqueID = ViewBag.retID;
                            payment = _objIDailyProductionModel.GetPaymentGateWay(model);
                            if (payment.RequestType != null && payment.MerchantCode != null)
                            {



                                payment.MerchantTxnRefNumber = Convert.ToString(ViewBag.retID);
                                #region ICICI
                                if (model.PaymentBank.ToUpper() == "ICICI")
                                {
                       
                                    TempData["Bank"] = "ICICI";
                                    var isNEFT = false;
                                    if (model.P_Mode.ToUpper() == "NEFT")
                                    {
                                        isNEFT = true;
                                    }
                                    else    // ADD by Kavita
                                    {
                                        if (model.NetBanking_mode.ToUpper() == "CORPORATE")
                                        {
                                            string Nmode = model.NetBanking_mode;
                                            isNEFT = false;
                                        }
                                        else
                                        {
                                            string Nmode = model.NetBanking_mode;
                                            isNEFT = false;
                                        }
                                    }
                                    //-------------------------------
                                    TempData["isNEFT"] = isNEFT;
                                    payment.TPSLTXNID = Convert.ToString(ViewBag.retID);
                                   

                                        payment.Amount = Convert.ToDecimal(payment.TotalPayableAmount).ToString("0.00");
                                        payment.Shoppingcartdetails = ("test_" + Convert.ToDecimal(payment.TotalPayableAmount).ToString("0.00") + "_0.0").ToUpper();

                                        string strITC = string.Empty;
                                        decimal total = 0;
                                        payment.Amount = total.ToString("0.00");
                                        payment.Shoppingcartdetails = ("test_" + total.ToString("0.00") + "_0.0").ToUpper();
                                    payment.ITC = payment.KOCODE + ":" + model.TotalPayableProductionMonthlyAmount.ToString();
                                    payment.Amount = model.TotalPayableProductionMonthlyAmount.ToString();
                                    payment.Shoppingcartdetails = ("test_" + model.TotalPayableProductionMonthlyAmount.ToString() + "_0.0").ToUpper();

                                    #region NEFT / RTGS
                                    if (isNEFT)
                                    {
                                        var dat = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                                        var dat1 = dat.Replace("-", "/");
                                        string finalSent = string.Empty;

                                        #region Old ICICI bank code

                                       
                                        #endregion

                                        #region New ICICI Bank Code

                                        //string GIB_URL = "https://gibtaxadm.icicibankltd.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H&IsCORDYS=Y&PID=220";
                                        string GIB_URL = "https://gibtax.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H&IsCORDYS=Y&PID=220";
                                        string GIB_Parm = "";
                                        string GIB_encrpt = objencdec.EncryptAES(GIB_Parm);
                                        finalSent = GIB_URL + "&encdata=" + GIB_encrpt;
                                        payment.finalSent = finalSent;
                                        payment.PaymentMode = "NEFT/RTGS";
                                        #endregion

                                        #region Insert Payment Request Data
                                       
                                        objobjmodel = _objIDailyProductionModel.InsertPaymentStatus(payment);
                                        #endregion


                                    }
                                    #endregion

                                    #region NetBanking
                                    else
                                    {
                                        var ICICINETBankingURL = "";
                                        payment.finalSent = ICICINETBankingURL;
                                        payment.PaymentMode = "NET-BANKING";
                                        #region Insert Payment Request Data
                                        objobjmodel = _objIDailyProductionModel.InsertPaymentStatus(payment);
                                        #endregion



                                    }
                                    #endregion
                                }
                                #endregion

                                #region SBI

                                else
                                {
                                    TempData["Bank"] = "SBI";

                                    var SBIRequestString = string.Empty;
                                    decimal total = 0;
                                    objRequestURL.LogFilePath = string.Empty;
                                    objRequestURL.ErrorFile = string.Empty;

                                    
                                    payment.TPSLTXNID = Convert.ToString(retID);
                                 

                                        payment.Amount = Convert.ToDecimal(payment.TotalPayableAmount).ToString("0.00");

                                        payment.Shoppingcartdetails = ("test_" + Convert.ToDecimal(payment.TotalPayableAmount).ToString("0.00") + "_0.0").ToUpper();

                                        string strITC = string.Empty;

                                       

                                        payment.ITC = payment.KOCODE + ":" + model.TotalPayableProductionMonthlyAmount.ToString();
                                        payment.Amount = model.TotalPayableProductionMonthlyAmount.ToString();
                                        payment.Shoppingcartdetails = ("test_" + model.TotalPayableProductionMonthlyAmount.ToString() + "_0.0").ToUpper();



                                    SBIRequestString = "ApplicantName=" + payment.customerName.ToString() //ApplicantName
                                                       + "|EmailId=" + payment.Email.ToString() //EmailId
                                                       + "|MobileNo=" + payment.mobileNo.ToString() //MobileNo
                                                       + "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                       + "|Amount=" + Convert.ToDecimal(payment.Amount).ToString("0.00") //TXN_AMOUNT
                                                       + "|Payment_Bifurcation=" + payment.ITC;
                                              




                                    string Result = GetMD5Hash(SBIRequestString);
                                    string str1 = SBIRequestString + "|checkSum=" + Result;
                                    string SBIPostRequest = Encrypt(str1);
                             

                                    payment.finalSent = SBIPostRequest;
                                    payment.PaymentMode = "NET-BANKING";
                                    #region Insert Payment Request Data
                                    objobjmodel = _objIDailyProductionModel.InsertPaymentStatus(payment);
                                    #endregion


                                    return null;



                                    #endregion

                                }
                            }

                            return null;
                        }
                        return null;
                    }
                }

                catch (Exception ex)
                {
                    TempData["Message"] = "Something went wrong !";
                    return RedirectToAction("MonthlyCoalProductionPayment");
                }
           

           




















        }

        /// <summary>
        /// Get Daily Production Amount Details Report
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public IActionResult DPSummaryReportAmountDetails(DailyProductionModel objmodel,string id)
        {
            try
            {
                objmodel.UserId = 153;
                objmodel.MonthYear = id;
                ViewBag.DailyProductionSummaryReportDetails = _objIDailyProductionModel.SummeryDetails(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
