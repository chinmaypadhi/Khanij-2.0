// ***********************************************************************
//  Controller Name          : LeaseapplicationController
//  Desciption               : Used to Add preferred Bidder information
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 11-apr-2021
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MineralConcessionEF;
using MineralConcessionApp.Areas.MajorMineral.Models.Mineral;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Appkey;
using Microsoft.Extensions.Configuration;
using MineralConcessionApp.Web;
using System.Security.Cryptography;
using System.Text;

namespace MineralConcessionApp.Areas.MajorMineral.Controllers
{
    [Area("MajorMineral")]
    public class LeaseApplicationController : Controller
    {
        Imineral _objIticketmodel;

        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        List<PreferredBidder> objraise = null;
        PreferredBidder objticket = null;


        /// <summary>
        /// used for Dependency Injection
        /// </summary>
        /// <param name="objtickettypemastermodel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        public LeaseApplicationController(Imineral objtickettypemastermodel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objIticketmodel = objtickettypemastermodel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// Added by suroj kumar pradhan on 14-mar-2021 to load preferred bidder 
        /// </summary>
        /// <param name="FOR"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PreferredBidder(string FOR, int? id)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.userType = profile.UserType;//ConfigurationManager.MySettings["MySettings:Usertype"];
            List<PreferredBidder> objTicket = null;

            PreferredBidder objmodel = new PreferredBidder();
            try
            {
                objTicket = new List<PreferredBidder>();
                objmodel.userid = Convert.ToInt16(profile.UserId);//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                objTicket = _objIticketmodel.GetAuctionType(objmodel);

                if (objTicket.Count > 0)
                {
                    ViewBag.AuctionList = new SelectList(objTicket, "Auctiontypeid", "Type");

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
            Leasetype();
            MineralNonCoal();
            DistrictBind();

            if (id > 0)
            {
                PreferredBidder objlease = new PreferredBidder();
                try
                {
                    objTicket = new List<PreferredBidder>();
                    
                    objlease.userid = Convert.ToInt16(profile.UserId);//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                    objlease.LesseeLOI = Convert.ToInt16(id);
                    objlease = _objIticketmodel.GetEditPreferredBidderRequest(objlease);

                    ViewBag.For = FOR;
                    objlease.PeriodFrom = Convert.ToDateTime(objlease.PeriodFrom).ToString("DD/MM/YYYY");
                    objlease.PeriodTo = Convert.ToDateTime(objlease.PeriodTo).ToString("DD/MM/YYYY");
                    ViewBag.villageid = objlease.VillageId;
                    ViewBag.Tehsilid = objlease.TehsilId;
                    Tehislbindedit(Convert.ToInt16(objlease.DistrictId));
                    villagebindedit(Convert.ToInt16(objlease.TehsilId));
                    objlease.For = FOR;
                    return View(objlease);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    objTicket = null;
                    objlease = null;
                    
                }
            }
           
            return View(objmodel);
        }
        /// <summary>
        /// Added by suroj kumar pradhan on 14-mar-2021 to bind Tehsil
        /// </summary>
        /// <param name="Districtid"></param>
        void Tehislbindedit(int Districtid)
        {
            objraise = new List<PreferredBidder>();
            objticket = new PreferredBidder();
            try
            {
                objticket.Action = "Tehsil";
                objticket.DistrictId = Districtid;
                objraise = _objIticketmodel.GetTehsilListByDistrict(objticket);

                ViewBag.DistrictlistEdit = new SelectList(objraise, "TehsilId", "TehsilName");
            }
            catch(Exception ex)
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
        /// Added by suroj kumar pradhan on 14-mar-2021 to bind Village against tehsil id
        /// </summary>
        /// <param name="Tid"></param>
        void villagebindedit(int Tid)
        {
            objraise = new List<PreferredBidder>();
            PreferredBidder objticket = new PreferredBidder();
            try
            {
                objticket.Action = "Village";
            objticket.TehsilId = Tid;
            objraise = _objIticketmodel.GetVillageListByTehsil(objticket);
            ViewBag.VillagelistEdit = new SelectList(objraise, "VillageId", "VillageName");
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
        /// Added by suroj kumar pradhan on 16-mar-2021 to Bind Leasetype
        /// </summary>
        void Leasetype()
        {
            PreferredBidder objmodel = new PreferredBidder();
            List<PreferredBidder> objTicket = new List<PreferredBidder>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.userid = Convert.ToInt16(profile.UserId);//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                objTicket = _objIticketmodel.FetchLeaseType(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.LeaseList = new SelectList(objTicket, "LeaseTypeID", "LeaseTypeName");

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

        }
        /// <summary>
        /// Added by suroj on 1-apr-2021 to Mineral coal bind
        /// </summary>
        void MineralNonCoal()
        {
            PreferredBidder objmodel = new PreferredBidder();
            List<PreferredBidder> objTicket = new List<PreferredBidder>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                
                objmodel.userid = Convert.ToInt16(profile.UserId);//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                objTicket = _objIticketmodel.GetMineralNonCoal(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.Minerallist = new SelectList(objTicket, "MineralId", "MineralName");

                }
            }
            catch(Exception ex)
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
        /// Added by suroj on 1-apr-2021 to District Bind
        /// </summary>
        void DistrictBind()
        {
            PreferredBidder objmodel = new PreferredBidder();
            List<PreferredBidder> objTicket = new List<PreferredBidder>();
            try
            {
                objmodel.Stateid = 7;
                objmodel.Action = "D";
                objTicket = _objIticketmodel.GetDistrictListByState(objmodel);
                if (objTicket.Count > 0)
                {
                    ViewBag.Districtlist = new SelectList(objTicket, "DistrictId", "DistrictName");

                }
            }
            catch(Exception ex)
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
        /// Added by suroj on 3-apr-2021 to Tehsil Bind
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public JsonResult Tehsilbind(int sid)
        {
           objraise = new List<PreferredBidder>();
             objticket = new PreferredBidder();
            try
            {
                objticket.Action = "Tehsil";
                objticket.DistrictId = sid;
                objraise = _objIticketmodel.GetTehsilListByDistrict(objticket);
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
        /// Added by suroj on 3-apr-2021 to Village Bind
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public JsonResult Villagebind(int sid)
        {
             objraise = new List<PreferredBidder>();
             objticket = new PreferredBidder();
            try
            {
                objticket.Action = "Village";
                objticket.TehsilId = sid;
                objraise = _objIticketmodel.GetVillageListByTehsil(objticket);
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
        /// Added by suroj on 8-apr-2021 to save bidder Request
        /// </summary>
        /// <param name="model"></param>
        /// <param name="ParticipantRadio"></param>
        /// <param name="GovRadio"></param>
        /// <param name="ParticipantName"></param>
        /// <param name="btnValue"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult PreferredBidder(PreferredBidder model, List<string> ParticipantRadio, List<string> GovRadio, List<string> ParticipantName, string btnValue)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

            PreferredBidder objmodel = new PreferredBidder();
            List<PreferredBidder> objTicket = new List<PreferredBidder>();
            try
            {
                #region"Server side validation"
            if (string.IsNullOrEmpty(model.AuctionNo) )
            {
                ModelState.AddModelError("AuctionNo", "Auction No is required");
            }
            else if (Convert.ToInt16(model.AuctionType) == 0)
            {
                ModelState.AddModelError("AuctionType", "Auction Type is required");
            }
            else if (string.IsNullOrEmpty(model.PeriodFrom))
            {
                ModelState.AddModelError("PeriodFrom", "NIT Date is required");
            }
            else if (string.IsNullOrEmpty(model.PeriodTo))
            {
                ModelState.AddModelError("PeriodTo", "Auction Date is required");
            }
            else if (string.IsNullOrEmpty(model.BidStart))
            {
                ModelState.AddModelError("BidStart", "Starting Bid Amount is required");
            }
            else if (string.IsNullOrEmpty(model.BidFinal))
            {
                ModelState.AddModelError("BidFinal", "Final Bid Amount is required");
            }
            else if (string.IsNullOrEmpty(model.AreaInHect))
            {
                ModelState.AddModelError("AreaInHect", "Total Area is required");
            }
            else if (string.IsNullOrEmpty(model.BidUnitId))
            {
                ModelState.AddModelError("BidUnitId", "Bid Unit is required");
            }
            else if (string.IsNullOrEmpty(model.Location))
            {
                ModelState.AddModelError("Location", "Location is required");
            }
            else if (string.IsNullOrEmpty(model.BlockName))
            {
                ModelState.AddModelError("BlockName", "BlockName is required");
            }
            else if (Convert.ToInt16(model.LeaseType) == 0)
            {
                ModelState.AddModelError("LeaseType", "LeaseType is required");
            }
            else if (Convert.ToInt16(model.MineralId) == 0)
            {
                ModelState.AddModelError("MineralId", "Mineral Name is required");
            }
            else if (Convert.ToInt16(model.DistrictId) == 0)
            {
                ModelState.AddModelError("DistrictId", "DistrictId is required");
            }
                #endregion
                if (ModelState.IsValid)
                {
                    //DataTable dataTable = new DataTable("Participant");
                    //dataTable.Columns.Add("Id");
                    //dataTable.Columns.Add("Name");
                    //dataTable.Columns.Add("IsSelected");
                    //if (ParticipantName != null && btnValue != "Reject")
                    //{
                    //    if (GovRadio != null && GovRadio.Count > 0)
                    //    {
                    //        for (int i = 0; i < GovRadio.Count(); i++)
                    //        {
                    //            dataTable.Rows.Add(i + 1, ParticipantName[i], GovRadio[i]);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        for (int i = 0; i < ParticipantName.Count(); i++)
                    //        {
                    //            dataTable.Rows.Add(i + 1, ParticipantName[i], ParticipantName[i] == ParticipantRadio[0] ? 1 : 0);
                    //        }
                    //    }
                    //}
                    //model.ParticipatesTable = dataTable;
                    string uniqueFileName = null; string filePath = null;
                    if (model.BidSheetFile != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "BidSheetFile");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.BidSheetFile.FileName;
                        filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                            model.BidSheetFile.CopyTo(fileStream);
                        model.BidSheetFilePath = filePath;
                        model.BidSheetFileName = uniqueFileName;
                    }

                    LeaseApplicationModel LeaseModel = new LeaseApplicationModel();
                    LeaseModel.AuctionNo = model.AuctionNo;
                    LeaseModel.AuctionType = model.AuctionType;
                    LeaseModel.PeriodFrom = model.PeriodFrom; //NIT Date
                    LeaseModel.PeriodTo = model.PeriodTo;     //Auction Date
                    LeaseModel.BidStart = model.BidStart;     //Starting Bid amount
                    LeaseModel.BidFinal = model.BidFinal;     //Final Bid amount
                    LeaseModel.AreaInHect = model.AreaInHect; //Toatl Area in Heact
                    LeaseModel.BidUnitId = model.BidUnitId;
                    LeaseModel.Location = model.Location;
                    LeaseModel.BlockName = model.BlockName;
                    LeaseModel.LeaseType = model.LeaseType;
                    LeaseModel.MineralID = model.MineralId;
                    LeaseModel.DistrictID = model.DistrictId;
                    LeaseModel.TehsilID = model.TehsilId;
                    LeaseModel.VillageID = model.VillageId;
                    LeaseModel.BidSheetFileName = model.BidSheetFileName;   // File Name
                    LeaseModel.BidSheetFilePath = model.BidSheetFilePath;   // File Path
                    LeaseModel.Participant_List = model.Participant_List;   //Participate List 
                    LeaseModel.UserId = profile.UserId;                     // User Login Id
                    LeaseModel.Password = "Dgm@123";
                    LeaseModel.Enc_Password = ComputeSha256Hash(LeaseModel.Password);


                    LeaseModel.LeaseTypeId = Convert.ToInt16(model.LeaseType);
                    LeaseModel.FOR = btnValue;
                    LeaseModel.Remarks = model.Remarks;
                    LeaseModel.LesseeLOI = model.LesseeLOI;


                 
                    string Result = string.Empty;
                    MessageEF objMessage = new MessageEF();
                    objMessage = _objIticketmodel.Add(LeaseModel);



                    if (string.IsNullOrEmpty(objMessage.Satus))
                    {
                        TempData["AckMsg"] = "Something went wrong.";

                    }
                    else if (objMessage.Msg == "Record Exist")
                    {
                        TempData["AckMsg"] = "Same Auction No alerty exist.Please enter another Auction No and try again!";

                    }
                    else if (btnValue == "Approve")
                    {
                        TempData["AckApprove"] = "Preferred Bidder Approved Successfully.";
                        return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
                    }
                    else
                    {
                        TempData["AckMsg"] = "Proposal for Preferred Bidder Submitted Successfully.";

                        int? idd = null;
                        return RedirectToAction("PreferredBidder", "LeaseApplication", new { id = idd });
                    }
                    
                }
                //else
                //{
                //     objTicket = new List<PreferredBidder>();

                //     objmodel = new PreferredBidder();
                //    try
                //    {
                //        objTicket = new List<PreferredBidder>();
                //        UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                //        objmodel.userid = Convert.ToInt16(profile.UserId);//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                //        objTicket = _objIticketmodel.GetAuctionType(objmodel);

                //        if (objTicket.Count > 0)
                //        {
                //            ViewBag.AuctionList = new SelectList(objTicket, "Auctiontypeid", "Type");

                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        throw ex;
                //    }
                //    finally
                //    {
                //        objTicket = null;

                //    }
                //    Leasetype();
                //    MineralNonCoal();
                //    DistrictBind();
                //    return View(objmodel);
                //}

                return View();
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

        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i <= bytes.Length - 1; i++)
                    builder.Append(bytes[i].ToString("x2"));

                return builder.ToString();
            }
        }

        /// <summary>
        /// Added by suroj on 11-apr-2021 to validate Auction No
        /// </summary>
        /// <param name="AuctionNo"></param>
        /// <returns></returns>
        public JsonResult ValidateAuctionNo(string AuctionNo)
        {

            LeaseApplicationModel objticket = new LeaseApplicationModel();
            try
            {
                objticket.AuctionNo = AuctionNo;
                int response = _objIticketmodel.CheckAuctionNo(objticket);
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                objticket = null;
            }
        }
        /// <summary>
        /// Added by suroj on 14-apr-2021 to show preferred bidder list
        /// </summary>
        /// <returns></returns>
        public ActionResult PreferredBidderRequest()
        {
            
           
            LeaseApplicationModel objticket = new LeaseApplicationModel();
            List<LeaseApplicationModel> lst = new List<LeaseApplicationModel>();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                ViewBag.usertype = profile.UserType;//ConfigurationManager.MySettings["MySettings:Usertype"];
                objticket.UserId = Convert.ToInt16(profile.UserId);//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                lst = _objIticketmodel.GetPreferredBidderRequest(objticket);
                ViewBag.ViewList = lst;
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objticket = null;
            }
        }
        /// <summary>
        /// Added by suroj on 17-apr-2021 to download files
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
        /// Added by suroj first installment label data fetch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Submission(int id)
        {
            LeaseApplicationModel objmodel = new LeaseApplicationModel();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = Convert.ToInt16(profile.UserId);// Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                objmodel.LesseeLOI = id;
                objmodel = _objIticketmodel.GetFirstinstallment(objmodel);
                if (objmodel.DateOfLOI != "")
                {
                    objmodel.DateOfLOI = Convert.ToDateTime(objmodel.DateOfLOI).ToString("dd/MM/yyyy");
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
            }
        }

        /// <summary>
        /// Added by suroj first installment data submit
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalPayable"></param>
        /// <param name="PaymentMode"></param>
        /// <param name="PaymentBank"></param>
        /// <param name="TransactionalID"></param>
        /// <param name="ChallanNumber"></param>
        /// <param name="ChallanDate"></param>
        /// <param name="PMode"></param>
        /// <param name="NetBanking_mode"></param>
        /// <param name="DocId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Submission(LeaseApplicationModel model, string totalPayable, string PaymentMode, string PaymentBank, string TransactionalID, string ChallanNumber,
            DateTime? ChallanDate, string PMode, string NetBanking_mode, List<int> DocId)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                string uniqueFileName = string.Empty;
                string filePath = string.Empty;
                if (model.MLA != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "MLApplication");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.MLA.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.MLA.CopyTo(fileStream);
                    
                    model.MLApplication = uniqueFileName;
                }
                model.MLA = null;

                //when STATUS=102
                if (model.WorkingPermissionFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\WorkingPermission");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.WorkingPermissionFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.WorkingPermissionFile.CopyTo(fileStream);

                    model.WorkingPermission = uniqueFileName;
                }
                model.WorkingPermissionFile = null;
                //when STATUS=102
                if (model.MDPAFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\MDPA");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.MDPAFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.MDPAFile.CopyTo(fileStream);

                    model.MDPA = uniqueFileName;
                }
                model.MDPAFile = null;
                if (model.LeaseDeedAgreementFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\LeaseDeedAgreement");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.LeaseDeedAgreementFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.LeaseDeedAgreementFile.CopyTo(fileStream);

                    model.LeaseDeedAgreement = uniqueFileName;
                }
                model.LeaseDeedAgreementFile = null;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserId = Convert.ToInt16(profile.UserId);//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);

                objMessage = _objIticketmodel.AddPayment(model);
                objMessage.Satus = "1";
                if (objMessage.Satus=="1" && model.SpMode== "FirstInstallment")
                {
                    TempData["LOIAckMessage"] = "First Installment Done successfully.";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

                }
                if (objMessage.Satus == "1" && model.SpMode == "DGMForward")
                {
                    try
                    {
                        MineralConcessionApp.Areas.MajorMineral.Controllers.DSCResponseController objDSCResponse = new DSCResponseController(_objIticketmodel, hostingEnvironment, configuration);
                        objDSCResponse.getDSCResponse(model.DSCResponse, "LOI-DGMForward-ToGov", Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]));
                        //_objIticketmodel.getDSCResponse(model.DSCResponse, "LOI-DGMForward-ToGov", Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]); // Response, For which purpose DSC Used , Return ID

                    }
                    catch (Exception)
                    {
                    }
                    TempData["LOIAckMessage"] = "Preferred Bidder Order Approved.";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

                }
                if (objMessage.Satus == "1" && model.SpMode == "GovApprove")
                {
                    TempData["LOIAckMessage"] = "Issuance of LOI Holder Approved.";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

                }
                if (objMessage.Satus == "1" && model.SpMode == "GovReject")
                {
                    TempData["LOIAckMessage"] = "Issuance of LOI Holder Rejected.";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

                }
                else if (objMessage.Satus == "1" && model.SpMode == "Forward")
                {
                    MineralConcessionApp.Areas.MajorMineral.Controllers.DSCResponseController objDSCResponse = new DSCResponseController(_objIticketmodel, hostingEnvironment, configuration);
                    objDSCResponse.getDSCResponse(model.DSCResponse, "LOI-DGMForward-ToHolder", Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]));

                    TempData["LOIAckMessage"] = "Request Forwarded successfully";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
                }
                else if (objMessage.Satus == "1" && model.SpMode == "Issuance Forwarding")
                {


                    TempData["LOIAckMessage"] = "Issuance Forwarded successfully";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
                }
                else if (objMessage.Satus == "1" && model.SpMode == "Issuance Approval Approve")
                {


                    TempData["LOIAckMessage"] = "Issuance Approval successfully";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
                }
                else if (objMessage.Satus == "1" && model.SpMode == "Issuance Approval Reject")
                {


                    TempData["LOIAckMessage"] = "Issuance Reject successfully";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
                }
                else if (objMessage.Satus == "1" && model.SpMode == "Issuance")
                {


                    TempData["LOIAckMessage"] = "Issuance of Successful Bidder Order successfully";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
                }
                else if (objMessage.Satus == "1" && model.SpMode == "MDPA")
                {


                    TempData["LOIAckMessage"] = "Your request submitted successfully";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
                }
                else if (objMessage.Satus == "1" && model.SpMode == "ThirdInstallment")
                {


                    TempData["LOIAckMessage"] = "Your ThirdInstallment submitted successfully";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
                }
                else if (objMessage.Satus == "1" && model.SpMode == "LeaseDeed")
                {


                    TempData["LOIAckMessage"] = "Your request submitted successfully";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                objMessage = null;
            }
            return View();
        }


        /// <summary>
        /// Added by suroj on 16-apr-2021 to load second installment page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Secondpayment(int id)
        {
            LeaseApplicationModel objmodel = new LeaseApplicationModel();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                objmodel.UserId = Convert.ToInt16(profile.UserId);// Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                objmodel.LesseeLOI = id;
                objmodel = _objIticketmodel.GetFirstinstallment(objmodel);
                objmodel.DateOfLOI = Convert.ToDateTime(objmodel.DateOfLOI).ToString("dd/MM/yyyy");
                ViewBag.DocList = objmodel.doclist;
                return View(objmodel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
            }

        }
        /// <summary>
        /// Added by suroj kumar pradhan on 20-mar-2021 to save second installment 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalPayable"></param>
        /// <param name="PaymentMode"></param>
        /// <param name="PaymentBank"></param>
        /// <param name="TransactionalID"></param>
        /// <param name="ChallanNumber"></param>
        /// <param name="ChallanDate"></param>
        /// <param name="PMode"></param>
        /// <param name="NetBanking_mode"></param>
        /// <param name="DocId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Secondpayment(LeaseApplicationModel model, string totalPayable, string PaymentMode, string PaymentBank, string TransactionalID, string ChallanNumber,
            DateTime? ChallanDate, string PMode, string NetBanking_mode, List<int> DocId)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                string uniqueFileName = string.Empty;
                string filePath = string.Empty;
                if (model.IBM_ReceivingFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "IBMReceivingCopy");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.IBM_ReceivingFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.IBM_ReceivingFile.CopyTo(fileStream);

                    model.IBM_ReceivingCopy = uniqueFileName;
                }
                model.IBM_ReceivingFile = null;
                if (model.BankGaurrantyFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "IBMReceivingCopy");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.BankGaurrantyFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.BankGaurrantyFile.CopyTo(fileStream);

                    model.BankGaurrantyLetter = uniqueFileName;
                }
                model.BankGaurrantyFile = null;

                if (model.MPSOMLetterFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\MPSOM");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.MPSOMLetterFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.MPSOMLetterFile.CopyTo(fileStream);

                    model.MPSOMLetter = uniqueFileName;
                }
                model.MPSOMLetterFile = null;
                if (model.ProposedProductionLetterFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\ProposedProduction");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProposedProductionLetterFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.ProposedProductionLetterFile.CopyTo(fileStream);

                    model.ProposedProductionLetter = uniqueFileName;
                }
                model.ProposedProductionLetterFile = null;


                #region Environmental Clearances Letter File Upload
                if (model.ECLetterFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\ECLetter");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ECLetterFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.ECLetterFile.CopyTo(fileStream);

                    model.ECLetter = uniqueFileName;
                }
                model.ECLetterFile = null;
                #endregion


                #region CTE Approval Letter File Upload
                if (model.CTELetterFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\CTELetter");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CTELetterFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.CTELetterFile.CopyTo(fileStream);

                    model.CTELetter = uniqueFileName;
                }
                model.CTELetterFile = null;
                #endregion


                #region CTO Approval Letter File Upload
                if (model.CTOLetterFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\CTOLetter");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CTOLetterFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.CTOLetterFile.CopyTo(fileStream);

                    model.CTOLetter = uniqueFileName;
                }
                model.CTOLetterFile = null;
                #endregion


                #region FC Approval Letter File Upload
                if (model.FCLetterFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\FCLetter");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FCLetterFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.FCLetterFile.CopyTo(fileStream);

                    model.FCLetter = uniqueFileName;
                }
                model.FCLetterFile = null;
                #endregion


                #region FC Approval Letter File Upload
                if (model.FCLetterFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\FCLetter");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FCLetterFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.FCLetterFile.CopyTo(fileStream);

                    model.FCLetter = uniqueFileName;
                }
                model.FCLetterFile = null;
                #endregion


                #region DGPS SURVEY REPORT File Upload
                if (model.DGPSLetterFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\DGPSReport");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.DGPSLetterFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.DGPSLetterFile.CopyTo(fileStream);

                    model.DGPSLetter = uniqueFileName;
                }
                model.DGPSLetterFile = null;
                #endregion

                #region Land File Upload
                if (model.LandLetterFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\LandReport");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.LandLetterFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.LandLetterFile.CopyTo(fileStream);

                    model.LandLetter = uniqueFileName;
                }
                model.LandLetterFile = null;
                #endregion


                #region RevenueReport
                if (model.RevenueLetterFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\RevenueReport");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.RevenueLetterFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.RevenueLetterFile.CopyTo(fileStream);

                    model.RevenueLetter = uniqueFileName;
                }
                model.RevenueLetterFile = null;
                #endregion


                #region Gram Panchayat Proposal File Upload
                if (model.GramPanchayatLetterFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "LesseeLOI\\GramPanchayatReport");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.GramPanchayatLetterFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        model.GramPanchayatLetterFile.CopyTo(fileStream);

                    model.GramPanchayatLetter = uniqueFileName;
                }
                model.GramPanchayatLetterFile = null;
                #endregion
                model.MLA = null;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                model.UserId = profile.UserId;//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
               
                objMessage = _objIticketmodel.AddPayment(model);
                if (objMessage.Satus == "1" && model.SpMode == "Step1")
                {
                    TempData["LOIAckMessage"] = "Second Installment Done successfully.";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

                }
                if (objMessage.Satus == "1" && model.SpMode == "Step2")
                {
                    TempData["LOIAckMessage"] = "Submitted Cleances Done successfully.";
                    return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMessage = null;
            }
            return View();
        }

        /// <summary>
        /// Added by suroj on 23-apr-2021 to get Production Agreement data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ProductionAgreement(int id)
        {
            LeaseApplicationModel objmodel = new LeaseApplicationModel();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                objmodel.UserId = Convert.ToInt16(profile.UserId);//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                objmodel.LesseeLOI = id;
                objmodel = _objIticketmodel.GetFirstinstallment(objmodel);
                objmodel.DateOfLOI = Convert.ToDateTime(objmodel.DateOfLOI).ToString("dd/MM/yyyy");
                ViewBag.DocList = objmodel.doclist;
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
        /// Added by suroj kumar pradhan on 15-mar-2021 to load Third installment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ThirdInstalment(int id)
        {
            LeaseApplicationModel objmodel = new LeaseApplicationModel();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = Convert.ToInt16(profile.UserId);// Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
            objmodel.LesseeLOI = id;
            objmodel = _objIticketmodel.GetFirstinstallment(objmodel);
            objmodel.DateOfLOI = Convert.ToDateTime(objmodel.DateOfLOI).ToString("dd/MM/yyyy");
            ViewBag.DocList = objmodel.doclist;
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
        /// Added by suroj kumar pradhan on 15-mar-2021 to load preferred bidder Timeline
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetTimeline(int id)
        {
            DataTable _dt = new DataTable();
            PreferredBidder objmodel = new PreferredBidder();
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                objmodel.userid = Convert.ToInt16(profile.UserId);// Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                objmodel.LesseeLOI = id;
                _dt = _objIticketmodel.GetTimeline(objmodel);
                objmodel.ParticipatesTable = _dt;
                return View(objmodel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
                _dt = null;
            }
        }
    }
}