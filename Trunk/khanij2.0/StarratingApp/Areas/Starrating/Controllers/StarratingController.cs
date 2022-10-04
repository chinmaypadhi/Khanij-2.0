// ***********************************************************************
//  Controller Name          : StarratingController
//  Desciption               : Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 16 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using StarratingApp.Areas.Starrating.Models.Assessment;
using StarratingApp.Areas.Starrating.Models.Create;
using StarratingEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StarratingApp.Web;

namespace StarratingApp.Areas.Starrating.Controllers
{
    [Area("Starrating")]
    public class StarratingController : Controller
    {
        #region Global Variable,Object Declaration
        /// <summary>
        /// Global Variable,Object Declaration
        /// </summary>
        private readonly IAssessmentModel _objAssessmentTemplateModel;
        private readonly ICreateModel _objCreateModel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        MessageEF objobjmodel = new MessageEF();
        AssessmentListmaster objmodel;
        AllModel objallModel;
        SR_Assesment_Master SR_AM;
        SR_FileMaster SR_FM;
        SR_Coordinate_Master SR_CM;
        SR_Lease_Area_Master SR_LAM;
        SR_Lease_Area_Mineral SR_LAMM;
        SR_Systematic_Sustainable SR_SS;
        SR_Additional_MappFile SR_MF;
        SR_Protection_Environment SR_PE;
        SR_Health_Saftey SR_HS;
        SR_Statutory_Compliance SR_SC;
        string filePath = null;
        #endregion
        #region Constructor Declaration
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objAssessmentTemplateModel"></param>
        /// <param name="objCreateModel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        public StarratingController(IAssessmentModel objAssessmentTemplateModel, ICreateModel objCreateModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objAssessmentTemplateModel = objAssessmentTemplateModel;
            _objCreateModel = objCreateModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        #endregion
        #region Index
        /// <summary>
        /// GET method of Index view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            objmodel = new AssessmentListmaster();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = profile.UserId;            
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                objmodel = _objAssessmentTemplateModel.ViewAssessmentTemplate(objmodel);
                objmodel.Count = objmodel.LesseePercent==0 ? 0 : 1;
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
        /// POST method of Index view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="Show1"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Index(AssessmentListmaster objmodel, string Show1)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                objmodel = _objAssessmentTemplateModel.ViewAssessmentTemplate(objmodel);
                objmodel.Count = (objmodel.Lessee_Code != "" && objmodel.Lessee_Code != null) ? 1 : 0;
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
        /// To bind Financial Year list in view
        /// </summary>
        /// <returns></returns>
        public JsonResult GetFinancialYearlist()
        {
            objmodel = new AssessmentListmaster();
            List<AssessmentListmaster> lstfy = new List<AssessmentListmaster>();
            try
            {
                lstfy = _objAssessmentTemplateModel.GetFYList(objmodel);
                return Json(lstfy);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                lstfy = null;
            }
        }
        #endregion
        #region Global Methods Declaration
        /// <summary>
        /// To Bind the Dropdowns State,Mineral,LeaseAreaType Data in View
        /// </summary>
        /// <param name="objallModel"></param>
        public AllModel Binddropdowns()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            SR_AM = new SR_Assesment_Master();
            UserLoginSession lesseedata = new UserLoginSession();
            objallModel = new AllModel();
            AllModel allmodel = new AllModel();
            objmodel = new AssessmentListmaster();
            List<AssessmentListmaster> listStateResult = new List<AssessmentListmaster>();
            List<SR_Assesment_Master> listMineralResult = new List<SR_Assesment_Master>();
            List<SR_Assesment_Master> listLeaseAreaTypeResult = new List<SR_Assesment_Master>();
            SR_AM.User_Id = profile.UserId; lesseedata.UserName = profile.UserName; objallModel.User_Id = profile.UserId;
            try
            {
                #region State
                listStateResult = _objAssessmentTemplateModel.GetStateList(objmodel);
                ViewData["State"] = listStateResult;
                #endregion
                #region Mineral        
                listMineralResult = _objCreateModel.GetMineralList(SR_AM);
                ViewData["Mineral"] = listMineralResult;
                #endregion
                #region LeaseAreaType           
                listLeaseAreaTypeResult = _objCreateModel.GetLeaseAreaType(SR_AM);
                ViewData["LeaseAreaType"] = listLeaseAreaTypeResult;
                #endregion
                #region GetAssessmentCount
                allmodel = _objCreateModel.GetAssessmentCount(objallModel);
                SR_AM.Reporting_Year = allmodel.Reporting_Year;
                objallModel.CountAssesment = allmodel.CountAssesment;
                #endregion
                #region Lesseedetails               
                lesseedata = _objCreateModel.GetUserMaster(lesseedata);
                SR_AM.Lessee_Code = lesseedata.UserName;
                SR_AM.StateId = Convert.ToInt32(lesseedata.StateId);
                SR_AM.DistrictId = Convert.ToInt32(lesseedata.DistrictId);
                SR_AM.Company_Name = lesseedata.ApplicantName;
                SR_AM.Address = lesseedata.Address;
                SR_AM.Contact_Mail = lesseedata.EMailId;
                SR_AM.Mobile_No = lesseedata.MobileNo;
                SR_AM.Contact_No = lesseedata.MobileNo;
                SR_AM.Contact_Person = lesseedata.ApplicantName;
                SR_AM.Contact_Address = lesseedata.Address;
                SR_AM.Email_Id = lesseedata.EMailId;
                SR_AM.Lessee_Type_Id = (string)lesseedata.UserTypeId.ToString();
                @ViewBag.ApplicantName = lesseedata.ApplicantName;
                #endregion
                #region GetTehsilVillage
                lesseedata = _objCreateModel.GetTehsilVillage(lesseedata);
                SR_AM.TehsilID = Convert.ToInt32(lesseedata.TehsilId);
                SR_AM.VillageID = Convert.ToInt32(lesseedata.VillageId);
                #endregion
                #region GetMineralId
                allmodel.SR_AM = _objCreateModel.GetMineralId(SR_AM);
                SR_AM.Mineral_Id = allmodel.SR_AM.Mineral_Id;
                #endregion
                #region GetLeasePeriod
                allmodel.SR_AM = _objCreateModel.GetLeasePeriod(SR_AM);
                SR_AM.Lease_Period_From = allmodel.SR_AM.Lease_Period_From;
                SR_AM.Lease_Period_To = allmodel.SR_AM.Lease_Period_To;
                #endregion
                #region GetApprovedPlan
                allmodel.SR_AM = _objCreateModel.GetApprovedPlan(SR_AM);
                SR_AM.Approved_Plan_Validity_From = allmodel.SR_AM.Approved_Plan_Validity_From;
                SR_AM.Approved_Plan_Validity_To = allmodel.SR_AM.Approved_Plan_Validity_To;
                SR_AM.Approved_Plan_Quantity = allmodel.SR_AM.Approved_Plan_Quantity;
                #endregion
                #region GetEnvironmentClearanceValidity           
                allmodel.SR_AM = _objCreateModel.GetEnvironmentClearanceValidity(SR_AM);
                SR_AM.Environment_Clearance_Validity_From = allmodel.SR_AM.Environment_Clearance_Validity_From;
                SR_AM.Environment_Clearance_Validity_To = allmodel.SR_AM.Environment_Clearance_Validity_To;
                SR_AM.Environment_Clearance_Quantity = allmodel.SR_AM.Environment_Clearance_Quantity;
                #endregion
                #region GetForestClearanceValidityUpto
                allmodel.SR_AM = _objCreateModel.GetForestClearanceValidityUpto(SR_AM);
                SR_AM.Forest_Clearance_Validity_Upto = allmodel.SR_AM.Forest_Clearance_Validity_Upto;
                #endregion
                objallModel.SR_AM = SR_AM;
                return objallModel;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                listStateResult = null;
                listMineralResult = null;
                listLeaseAreaTypeResult = null;
                allmodel = null;
            }
        }
        /// <summary>
        /// To Bind the Other Files Data in View
        /// </summary>
        /// <param name="AssessmentId"></param>
        /// <param name="Action"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public string GetOtherFiles(int AssessmentId, string Action, string Type)
        {
            string tblAssesmentFile = "";
            List<SR_Additional_MappFile> fmOtherList = new List<SR_Additional_MappFile>();
            SR_MF = new SR_Additional_MappFile();
            try
            {
                SR_MF.AssesmentID = AssessmentId;
                SR_MF.Action = Action;
                fmOtherList = _objCreateModel.GetOtherFiles(SR_MF);
                if (fmOtherList.Count > 0)
                {
                    int I = 0;
                    int mOtherID = 0;
                    int mOtherID2 = 0;
                    foreach (var item in fmOtherList)
                    {
                        tblAssesmentFile = tblAssesmentFile + "<tr>";
                        tblAssesmentFile = tblAssesmentFile + "<td>";
                        mOtherID = item.OtherID;
                        if (mOtherID2 != mOtherID && Type == "")
                        {
                            tblAssesmentFile = tblAssesmentFile + item.OtherName + "&nbsp; &nbsp;";
                            mOtherID2 = mOtherID;
                        }
                        if (Type != "")
                        {
                            tblAssesmentFile = tblAssesmentFile + Type + "&nbsp; &nbsp;";
                        }
                        tblAssesmentFile = tblAssesmentFile + "</td>";
                        tblAssesmentFile = tblAssesmentFile + "<td>";
                        if (I != fmOtherList.Count)
                        {
                            tblAssesmentFile = tblAssesmentFile + "<a href='../../../Upload/SR_UploadedFiles/" + item.FileName + item.FileExtension + "' target='_blank'><i class='icon-download-solid' aria-hidden='true'></i></a><br/>";
                        }
                        else
                        {
                            tblAssesmentFile = tblAssesmentFile + "<a href='../../../Upload/SR_UploadedFiles/" + item.FileName + item.FileExtension + "' target='_blank'><i class='icon-download-solid' aria-hidden='true'></i></a>";
                        }
                        tblAssesmentFile = tblAssesmentFile + "</td>";
                        tblAssesmentFile = tblAssesmentFile + "</tr>";
                        I++;
                    }
                }

            }
            catch (Exception)
            {

                ////throw;
            }
            finally
            {
                SR_MF = null;
                fmOtherList = null;
            }
            return tblAssesmentFile;
        }
        /// <summary>
        /// To Bind the Info Files Data in View
        /// </summary>
        /// <param name="AssessmentId"></param>
        /// <param name="Action"></param>
        /// <param name="ItemId"></param>
        /// <returns></returns>
        public string GetInfoFiles(int AssessmentId, string Action, int ItemId)
        {
            string lblProtectionEnvironmentFile = "";
            List<SR_FileMaster> fmPEPDWList = new List<SR_FileMaster>();
            SR_FM = new SR_FileMaster();
            try
            {
                SR_FM.Assessment_ID = AssessmentId;
                SR_FM.Action = Action;
                SR_FM.FileMasterID = ItemId;
                fmPEPDWList = _objCreateModel.GetInfoFiles(SR_FM);
                if (fmPEPDWList.Count > 0)
                {
                    int I = 0;
                    foreach (var itmPEPDW in fmPEPDWList)
                    {
                        if (I != fmPEPDWList.Count)
                        {
                            lblProtectionEnvironmentFile = lblProtectionEnvironmentFile + "<a href='../../../Upload/SR_UploadedFiles/" + itmPEPDW.FileName + itmPEPDW.FileExtension + "' target='_blank'><i class='icon-download-solid' aria-hidden='true'></i></a><br/>";
                        }
                        else
                        {
                            lblProtectionEnvironmentFile = lblProtectionEnvironmentFile + "<a href='../../../Upload/SR_UploadedFiles/" + itmPEPDW.FileName + itmPEPDW.FileExtension + "' target='_blank'><i class='icon-download-solid' aria-hidden='true'></i></a>";
                        }
                        I++;
                    }
                }
            }
            catch (Exception)
            {

                ////throw;
            }
            finally
            {
                SR_FM = null;
                fmPEPDWList = null;
            }
            return lblProtectionEnvironmentFile;
        }
        /// <summary>
        /// To Bind Coordinate,Lease Area,Mineral Data in View
        /// </summary>
        /// <param name="Assessment_ID"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public string Tables(int Assessment_ID, string Type)
        {
            string tbl = "";
            List<SR_Coordinate_Master> latlong = new List<SR_Coordinate_Master>();
            List<SR_Lease_Area_Master> LeasArea = new List<SR_Lease_Area_Master>();
            List<SR_Lease_Area_Mineral> LeasAreaMineral = new List<SR_Lease_Area_Mineral>();
            SR_CM = new SR_Coordinate_Master();
            SR_LAM = new SR_Lease_Area_Master();
            SR_LAMM = new SR_Lease_Area_Mineral();
            try
            {
                #region Coordinate Table with Area
                if (Type == "CoordinateList")
                {
                    SR_CM.Assesment_Id = Assessment_ID;
                    latlong = _objCreateModel.GetCoordinateList(SR_CM);
                    tbl = "<table id='MiningPlanTable' class='table table-sm border'>";
                    tbl = tbl + "<thead>";
                    tbl = tbl + "<tr>";
                    tbl = tbl + "<td colspan ='3'>";
                    tbl = tbl + "<label class='col-form-label pt-0 font-weight-bolder'>Lease Boundary Coordinates <small>(Latitudes & Longitudes)</small></label>";
                    tbl = tbl + "</td>";
                    tbl = tbl + "</tr>";
                    tbl = tbl + "</thead>";
                    tbl = tbl + "<tbody id = 'mPlanTableBody'>";
                    int i = 1;
                    foreach (var item in latlong)
                    {
                        tbl = tbl + "<tr>";
                        tbl = tbl + "<td>";
                        tbl = tbl + "<input type='number' class='form-control addMultiple' name='Latitude' onblur='checkInput()' placeholder='Latitudes' value='" + String.Format("{0:0.0000}", item.Latitude) + "' readonly/>";
                        tbl = tbl + "</td>";
                        tbl = tbl + "<td>";
                        tbl = tbl + "<input type = 'number' class='form-control addMultiple' name='Longitude' onblur='checkInput()' placeholder='Longitudes' value='" + String.Format("{0:0.0000}", item.Longitude) + "' readonly/>";
                        tbl = tbl + "</td>";
                        tbl = tbl + "<td style = 'border-color: black; visibility: hidden; display: none'></td >";
                        tbl = tbl + "</tr>";
                        i++;
                    }

                    tbl = tbl + "</tbody >";
                    tbl = tbl + "</table >";
                }
                #endregion
                #region Lease Area Table with Area
                if (Type == "LeaseAreaList")
                {
                    SR_LAM.Assesment_Id = Assessment_ID;
                    LeasArea = _objCreateModel.GetLeaseAreaList(SR_LAM);
                    string tbl2 = "";
                    tbl2 = "<table id='LeaseAreaTable' class='table table-sm border'>";
                    tbl2 = tbl2 + "<thead>";
                    tbl2 = tbl2 + "<tr>";
                    tbl2 = tbl2 + "<td colspan ='3'>";
                    tbl2 = tbl2 + "<label class='col-form-label pt-0 font-weight-bolder'>Total Lease Area <small>(in hectare)</small></label>";
                    tbl2 = tbl2 + "</td>";
                    tbl2 = tbl2 + "</tr>";
                    tbl2 = tbl2 + "</thead>";
                    tbl2 = tbl2 + "<tbody>";
                    int colLA = 1;
                    foreach (var item in LeasArea)
                    {
                        tbl2 = tbl2 + "<tr>";
                        tbl2 = tbl2 + "<td>";
                        tbl2 = tbl2 + "<select id='opLeaseAreaType' name='LEASEAREAID' class='form-control disable' readonly>";
                        tbl2 = tbl2 + "<option value='0'>--select--</option>";
                        List<SR_Assesment_Master> AreaType = new List<SR_Assesment_Master>();
                        AreaType = _objCreateModel.GetLeaseAreaType(SR_AM);
                        foreach (var item2 in AreaType)
                        {
                            if (item2.LeaseArea_TypeID == item.Area_Type_Id)
                            {
                                tbl2 = tbl2 + "<option value='" + item2.LeaseArea_TypeID + "' selected='selected'>" + item2.LeaseArea_Type + "</option>";
                            }
                            else
                            {
                                tbl2 = tbl2 + "<option value='" + item2.LeaseArea_TypeID + "'>" + item2.LeaseArea_Type + "</option>";
                            }
                        }
                        tbl2 = tbl2 + "</select>";
                        tbl2 = tbl2 + "</td>";
                        tbl2 = tbl2 + "<td>";
                        tbl2 = tbl2 + "<input class='form-control addMultiple' name='LEASEAREANAME' onblur='checkInput()' value='" +string.Format("{0:0.00}", item.Area_In_Hectare) + "' readonly/>";
                        tbl2 = tbl2 + "</td>";
                        tbl2 = tbl2 + "<td style='border-color: black; visibility: hidden; display: none'></td>";
                        tbl2 = tbl2 + "</tbody>";
                        tbl2 = tbl2 + "</tr>";
                        colLA++;
                    }
                    tbl2 = tbl2 + "</table>";
                    tbl = tbl2;
                }
                #endregion
                #region Mineral Table with Area
                if (Type == "MineralList")
                {
                    SR_LAMM.Assesment_Id = Assessment_ID;
                    LeasAreaMineral = _objCreateModel.GetLeaseTypeList(SR_LAMM);
                    string tbl3 = "";
                    tbl3 = "<table id='LeaseAreaMineralTable' class='table table-sm border'>";
                    tbl3 = tbl3 + "<thead>";
                    tbl3 = tbl3 + "<tr>";
                    tbl3 = tbl3 + "<td colspan ='3'>";
                    tbl3 = tbl3 + "<label class='col-form-label pt-0 font-weight-bolder'>Total Resource Available Lease Area <small>(Mineral Wise tones)</small></label>";
                    tbl3 = tbl3 + "</td>";
                    tbl3 = tbl3 + "</tr>";
                    tbl3 = tbl3 + "</thead>";
                    tbl3 = tbl3 + "<tbody>";
                    int colLAM = 1;
                    foreach (var item in LeasAreaMineral)
                    {
                        tbl3 = tbl3 + "<tr>";
                        tbl3 = tbl3 + "<td>";
                        tbl3 = tbl3 + "<select id='opLeaseAreaMineral' name='LeaseAreaMineralID' class='form-control disable' readonly>";
                        tbl3 = tbl3 + "<option value='0'>--select--</option>";
                        List<SR_Assesment_Master> MineralMaster = new List<SR_Assesment_Master>();
                        MineralMaster = _objCreateModel.GetMineralList(objallModel.SR_AM);
                        foreach (var item3 in MineralMaster)
                        {
                            if (item3.Mineral_Id == item.MineralID)
                            {
                                tbl3 = tbl3 + "<option value='" + item3.Mineral_Id + "' selected='selected'>" + item3.MineralName + "</option>";
                            }
                            else
                            {
                                tbl3 = tbl3 + "<option value='" + item3.Mineral_Id + "'>" + item3.MineralName + "</option>";
                            }
                        }
                        tbl3 = tbl3 + "</select>";
                        tbl3 = tbl3 + "</td>";
                        tbl3 = tbl3 + "<td>";
                        tbl3 = tbl3 + "<input class='form-control addMultiple' name='LEASEAREAMINERAL' onblur='checkInput()' value='" + string.Format("{0:0.00}", item.LeaseArea) + "' readonly/>";
                        tbl3 = tbl3 + "</td>";
                        tbl3 = tbl3 + "<td style='border-color: black; visibility: hidden; display: none'></td>";
                        tbl3 = tbl3 + "</tbody>";
                        tbl3 = tbl3 + "</tr>";
                        colLAM++;
                    }
                    tbl3 = tbl3 + "</table>";
                    tbl = tbl3;
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SR_CM = null;
                SR_LAM = null;
                SR_LAMM = null;
                latlong = null;
                LeasArea = null;
                LeasAreaMineral = null;
            }
            return tbl;
        }
        /// <summary>
        /// GET method to Bind Details of Lessee,MI,DD,DGM Data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AllModel GETEdit(int id)
        {
            SR_FM = new SR_FileMaster(); SR_AM = new SR_Assesment_Master();
            SR_PE = new SR_Protection_Environment(); SR_SS = new SR_Systematic_Sustainable();
            SR_HS = new SR_Health_Saftey(); SR_SC = new SR_Statutory_Compliance();
            SR_LAMM = new SR_Lease_Area_Mineral();
            SR_LAM = new SR_Lease_Area_Master();
            objallModel = new AllModel();
            SR_CM = new SR_Coordinate_Master();
            ViewBag.Date = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {
                //Binddropdowns();
                if (id != 0)
                {
                    SR_AM.Assesment_Id = id; SR_PE.Assesment_Id = id; SR_SS.Assesment_Id = id; SR_HS.Assesment_Id = id; SR_SC.Assesment_Id = id; SR_LAMM.Assesment_Id = id;
                    SR_LAM.Assesment_Id = id; SR_CM.Assesment_Id = id;
                    objallModel.SR_AM = _objCreateModel.Edit(SR_AM);
                    ViewBag.tableText = _objCreateModel.GetCoordinateList(SR_CM);
                    ViewBag.tableLA = _objCreateModel.GetLeaseAreaList(SR_LAM);
                    ViewBag.LAMineralTable = _objCreateModel.GetLeaseTypeList(SR_LAMM);
                    #region Module 1 Systamatic Sustainable
                    var SRSSList = _objCreateModel.EditSS(SR_SS);
                    int iss = 0;
                    foreach (var item in SRSSList)
                    {
                        if (iss == 0)
                        {
                            objallModel.SR_SS1 = item;
                        }
                        else if (iss == 1)
                        {
                            objallModel.SR_SS2 = item;
                        }
                        else if (iss == 2)
                        {
                            objallModel.SR_SS3 = item;
                        }
                        else if (iss == 3)
                        {
                            objallModel.SR_SS4 = item;
                        }
                        else if (iss == 4)
                        {
                            objallModel.SR_SS5 = item;
                        }
                        else if (iss == 5)
                        {
                            objallModel.SR_SS6 = item;
                        }
                        else if (iss == 6)
                        {
                            objallModel.SR_SS7 = item;
                        }
                        iss++;
                    }
                    #endregion
                    #region Module 2 Protection Environment
                    var SRPEList = _objCreateModel.EditPE(SR_PE);
                    int ipe = 1;
                    foreach (var item in SRPEList)
                    {
                        if (ipe == 1)
                        {
                            objallModel.SR_PE1 = item;
                            //#region Compliance reporting of environmental parameters (air,water,etc)
                            //ViewBag.filecompliancereportingSPCB = GetInfoFiles(id, "Q", item.Id);
                            //#endregion
                        }
                        else if (ipe == 2)
                        {
                            objallModel.SR_PE2 = item;
                            //#region Compliance reporting of environmental parameters (as per EC condition)
                            //ViewBag.filecompliancereportingMoef = GetInfoFiles(id, "Q", item.Id);
                            //#endregion
                        }
                        else if (ipe == 3)
                        {
                            objallModel.SR_PE3 = item;
                        }
                        else if (ipe == 4)
                        {
                            objallModel.SR_PE4 = item;
                            //#region Total Plantation/ compensatory aforestation done as per approved Document (EC/FC) and Survival rate of plants
                            //ViewBag.fileducumentplants = GetInfoFiles(id, "Q", item.Id);
                            //#endregion
                        }
                        else if (ipe == 5)
                        {
                            objallModel.SR_PE5 = item;
                        }
                        ipe++;
                    }
                    #endregion
                    #region Module 3 Health Safety
                    var SRHSList = _objCreateModel.EditHS(SR_HS);
                    int ihs = 0;
                    foreach (var item in SRHSList)
                    {
                        if (ihs == 0)
                        {
                            objallModel.SR_HS1 = item;
                        }
                        else if (ihs == 1)
                        {
                            objallModel.SR_HS2 = item;
                        }
                        else if (ihs == 2)
                        {
                            objallModel.SR_HS3 = item;
                            //#region Health Safety Uploaded file of Provision of drinking                        
                            //ViewBag.fileprovisionofdrinking = GetInfoFiles(id, "E", item.Id);
                            //#endregion
                        }
                        else if (ihs == 3)
                        {
                            objallModel.SR_HS4 = item;
                            //#region Health Safety Uploaded file of Provision of basic amenities                         
                            //ViewBag.fileprovisionofbasic = GetInfoFiles(id, "E", item.Id);
                            //#endregion
                        }
                        else if (ihs == 4)
                        {
                            objallModel.SR_HS5 = item;
                        }
                        else if (ihs == 5)
                        {
                            objallModel.SR_HS6 = item;
                        }
                        else if (ihs == 6)
                        {
                            objallModel.SR_HS7 = item;
                        }
                        else if (ihs == 7)
                        {
                            objallModel.SR_HS8 = item;
                        }

                        ihs++;
                    }
                    #endregion
                    #region Module 3 STATUTORY COMPLIANCE
                    var SRSCList = _objCreateModel.EditSC(SR_SC);
                    int isc = 1;
                    foreach (var item in SRSCList)
                    {
                        if (isc == 1)
                        {
                            objallModel.SR_SC1 = item;
                        }
                        else if (isc == 2)
                        {
                            objallModel.SR_SC2 = item;
                        }
                        else if (isc == 3)
                        {
                            objallModel.SR_SC3 = item;
                            //#region Statutory Compliance Uploaded file of MinesManager
                            //ViewBag.fileappminesmanager = GetInfoFiles(id, "G", item.Id);
                            //#endregion
                        }
                        else if (isc == 4)
                        {
                            objallModel.SR_SC4 = item;
                            #region Statutory Compliance Uploaded file of Foreman
                            ViewBag.fileappforeman = GetInfoFiles(id, "G", item.Id);
                            #endregion
                        }
                        else if (isc == 5)
                        {
                            objallModel.SR_SC5 = item;
                            //#region Statutory Compliance Uploaded file of Mining mate
                            //ViewBag.fileappminingmate = GetInfoFiles(id, "G", item.Id);
                            //#endregion
                        }
                        else if (isc == 6)
                        {
                            objallModel.SR_SC6 = item;
                            //#region Statutory Compliance Uploaded file of blaster
                            //ViewBag.fileappblaster = GetInfoFiles(id, "G", item.Id);
                            //#endregion
                        }
                        else if (isc == 7)
                        {
                            objallModel.SR_SC7 = item;
                            //#region Statutory Compliance Uploaded file of Authenticatedlease
                            //ViewBag.fileauthenticatedlease = GetInfoFiles(id, "G", item.Id);
                            //#endregion
                        }
                        else if (isc == 8)
                        {
                            objallModel.SR_SC8 = item;
                            //#region Statutory Compliance Uploaded file of Erection of dgps
                            //ViewBag.fileerectionofdgps = GetInfoFiles(id, "G", item.Id);
                            //#endregion
                        }
                        isc++;
                    }
                    #endregion
                    ViewBag.Button = "Update";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objallModel;
        }
        /// <summary>
        /// POST method to submit details of Lessee,MI,DD,DGM Data to controller action
        /// </summary>
        /// <param name="id"></param>
        /// <param name="submit"></param>
        /// <param name="objallModel"></param>
        /// <returns></returns>
        public int POSTEdit(int id, string submit, AllModel objallModel)
        {
            int Out = 0;
            SR_FM = new SR_FileMaster(); SR_AM = new SR_Assesment_Master();
            SR_PE = new SR_Protection_Environment(); SR_SS = new SR_Systematic_Sustainable();
            SR_HS = new SR_Health_Saftey(); SR_SC = new SR_Statutory_Compliance();
            if (id > 0 && submit == "Update")
            {
                try
                {
                    objallModel.Mode = SR_FM.Action = "2";
                    objallModel.Assessment_ID = SR_FM.Assessment_ID = id;
                    #region Module 1  Systematic_Sustainable
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == 0)
                        {
                            objallModel.SR_SS = objallModel.SR_SS1;
                        }
                        else if (i == 1)
                        {
                            objallModel.SR_SS = objallModel.SR_SS2;
                        }
                        else if (i == 2)
                        {
                            objallModel.SR_SS = objallModel.SR_SS3;
                        }
                        else if (i == 3)
                        {
                            objallModel.SR_SS = objallModel.SR_SS4;
                        }
                        else if (i == 4)
                        {
                            objallModel.SR_SS = objallModel.SR_SS5;
                        }
                        else if (i == 5)
                        {
                            objallModel.SR_SS = objallModel.SR_SS6;
                        }
                        else if (i == 6)
                        {
                            objallModel.SR_SS = objallModel.SR_SS7;
                        }
                        objobjmodel = _objCreateModel.AddSystSust(objallModel);
                    }
                    #endregion
                    #region Module 2 Protection_Environment                          
                    for (int i = 0; i < 4; i++)
                    {
                        if (i == 0)
                        {
                            SR_FM.SR_PE = objallModel.SR_PE1;
                        }
                        else if (i == 1)
                        {
                            SR_FM.SR_PE = objallModel.SR_PE2;
                        }
                        else if (i == 2)
                        {
                            SR_FM.SR_PE = objallModel.SR_PE4;
                        }
                        else if (i == 3)
                        {
                            SR_FM.SR_PE = objallModel.SR_PE5;
                        }
                        objobjmodel = _objCreateModel.AddPE(SR_FM);
                    }
                    #endregion
                    #region Module 3  Health_Saftey DataTable
                    for (int i = 0; i < 8; i++)
                    {
                        if (i == 0)
                        {
                            SR_FM.SR_HS = objallModel.SR_HS1;
                        }
                        else if (i == 1)
                        {
                            SR_FM.SR_HS = objallModel.SR_HS2;
                        }
                        else if (i == 2)
                        {
                            SR_FM.SR_HS = objallModel.SR_HS3;
                        }
                        else if (i == 3)
                        {
                            SR_FM.SR_HS = objallModel.SR_HS4;
                        }
                        else if (i == 4)
                        {
                            SR_FM.SR_HS = objallModel.SR_HS5;
                        }
                        else if (i == 5)
                        {
                            SR_FM.SR_HS = objallModel.SR_HS6;
                        }
                        else if (i == 6)
                        {
                            SR_FM.SR_HS = objallModel.SR_HS7;
                        }
                        else if (i == 7)
                        {
                            SR_FM.SR_HS = objallModel.SR_HS8;
                        }
                        objobjmodel = _objCreateModel.AddHS(SR_FM);
                    }
                    #endregion
                    #region Module 4 Statutory_Compliance
                    for (int i = 0; i < 8; i++)
                    {
                        if (i == 0)
                        {
                            SR_FM.SR_SC = objallModel.SR_SC1;
                        }
                        else if (i == 1)
                        {
                            SR_FM.SR_SC = objallModel.SR_SC2;
                        }
                        else if (i == 2)
                        {
                            SR_FM.SR_SC = objallModel.SR_SC3;
                        }
                        else if (i == 3)
                        {
                            SR_FM.SR_SC = objallModel.SR_SC4;
                        }
                        else if (i == 4)
                        {
                            SR_FM.SR_SC = objallModel.SR_SC5;
                        }
                        else if (i == 5)
                        {
                            SR_FM.SR_SC = objallModel.SR_SC6;
                        }
                        else if (i == 6)
                        {
                            SR_FM.SR_SC = objallModel.SR_SC7;
                        }
                        else if (i == 7)
                        {
                            SR_FM.SR_SC = objallModel.SR_SC8;
                        }
                        objobjmodel = _objCreateModel.AddSC(SR_FM);
                    }
                    #endregion
                    Out = Convert.ToInt32(objobjmodel.Satus);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    SR_FM = null; SR_AM = null;
                    SR_PE = null; SR_SS = null;
                    SR_HS = null; SR_SC = null;
                    objallModel = null;
                }
            }
            return Out;
        }
        #endregion
        #region CreateLesseeAssessment
        /// <summary>
        /// Create Lessee Assessment GET
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewBag.Date = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {
                Binddropdowns();
                ViewBag.Button = "Submit";
                return View(objallModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Create Lessee Assessment POST
        /// </summary>
        /// <param name="objallModel"></param>
        /// <param name="submit"></param>
        /// <param name="collection"></param>
        /// <param name="filedgms"></param>
        /// <param name="fileblastlicense"></param>
        /// <param name="fileec"></param>
        /// <param name="fileairconsent"></param>
        /// <param name="filewaterconsent"></param>
        /// <param name="fileother"></param>
        /// <param name="filecompliancereportingSPCB"></param>
        /// <param name="filecompliancereportingMoef"></param>
        /// <param name="fileducumentplants"></param>
        /// <param name="fileprovisionofdrinking"></param>
        /// <param name="fileprovisionofbasic"></param>
        /// <param name="fileappminesmanager"></param>
        /// <param name="fileappforeman"></param>
        /// <param name="fileappminingmate"></param>
        /// <param name="fileappblaster"></param>
        /// <param name="fileauthenticatedlease"></param>
        /// <param name="fileerectionofdgps"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Create(AllModel objallModel, string submit, IFormCollection collection, List<IFormFile> filedgms, List<IFormFile> fileblastlicense,
           List<IFormFile> fileec, List<IFormFile> fileairconsent, List<IFormFile> filewaterconsent, List<IFormFile> fileother,
           List<IFormFile> filecompliancereportingSPCB, List<IFormFile> filecompliancereportingMoef, List<IFormFile> fileducumentplants,
           List<IFormFile> fileprovisionofdrinking, List<IFormFile> fileprovisionofbasic, List<IFormFile> fileappminesmanager, List<IFormFile> fileappforeman,
           List<IFormFile> fileappminingmate, List<IFormFile> fileappblaster, List<IFormFile> fileauthenticatedlease, List<IFormFile> fileerectionofdgps)
        {
            SR_FM = new SR_FileMaster(); SR_AM = new SR_Assesment_Master();
            SR_PE = new SR_Protection_Environment(); SR_SS = new SR_Systematic_Sustainable();
            SR_HS = new SR_Health_Saftey(); SR_SC = new SR_Statutory_Compliance();
            SR_CM = new SR_Coordinate_Master(); ;
            SR_LAM = new SR_Lease_Area_Master();
            SR_LAMM = new SR_Lease_Area_Mineral();
            if (submit == "Submit")
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("CIMSConnectionString")))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    using (var transaction = connection.BeginTransaction())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;
                        try
                        {
                            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                            SR_AM = objallModel.SR_AM;
                            SR_AM.User_Id = profile.UserId;
                            objobjmodel = _objCreateModel.Add(SR_AM);
                            objallModel.Assessment_ID = Convert.ToInt32(objobjmodel.Satus);
                            SR_FM.Assessment_ID = Convert.ToInt32(objobjmodel.Satus);
                            SR_FM.Action = "1";
                            #region Validation
                            if (string.IsNullOrEmpty(objallModel.SR_AM.Khasra_No))
                            {
                                ModelState.AddModelError("SR_AM.Khasra_No", "Khasra Number field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.StateId)))
                            {
                                ModelState.AddModelError("SR_AM.StateId", "State field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.DistrictId)))
                            {
                                ModelState.AddModelError("SR_AM.DistrictId", "District field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.TehsilID)))
                            {
                                ModelState.AddModelError("SR_AM.TehsilID", "Tehsil field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.VillageID)))
                            {
                                ModelState.AddModelError("SR_AM.VillageID", "Village field is required");
                            }
                            if (string.IsNullOrEmpty(objallModel.SR_AM.Lease_Period_From))
                            {
                                ModelState.AddModelError("SR_AM.Lease_Period_From", "Lease Period From field is required");
                            }
                            if (string.IsNullOrEmpty(objallModel.SR_AM.Lease_Period_To))
                            {
                                ModelState.AddModelError("SR_AM.Lease_Period_To", "Lease Period To field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.Mineral_Id)))
                            {
                                ModelState.AddModelError("SR_AM.Mineral_Id", "Mineral field is required");
                            }
                            if (objallModel.SR_AM.Lessee_Type_Id == null || objallModel.SR_AM.Lessee_Type_Id == "")
                            {
                                ModelState.AddModelError("SR_AM.Lessee_Type_Id", "Type of Lessee field is required");
                            }
                            if (string.IsNullOrEmpty(objallModel.SR_AM.Director_Name))
                            {
                                ModelState.AddModelError("SR_AM.Director_Name", "Director Name field is required");
                            }
                            if (string.IsNullOrEmpty(objallModel.SR_AM.Mining_Method_Id))
                            {
                                ModelState.AddModelError("SR_AM.Mining_Method_Id", "Mining Method field is required");
                            }
                            if (string.IsNullOrEmpty(objallModel.SR_AM.Lease_Status_Id))
                            {
                                ModelState.AddModelError("SR_AM.Lease_Status_Id", "Status of the lease on date of filing field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.Working_Days)))
                            {
                                ModelState.AddModelError("SR_AM.Working_Days", "No. of working days during Reporting Year field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.Discontunuance_Days)))
                            {
                                ModelState.AddModelError("SR_AM.Discontunuance_Days", "No. of days of temporary discontinuance during Reporting Year field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.Suspension_Days)))
                            {
                                ModelState.AddModelError("SR_AM.Suspension_Days", "No.of days under suspension during Reporting Year field is required");
                            }
                            if (string.IsNullOrEmpty(objallModel.SR_AM.Approved_Plan_Validity_From))
                            {
                                ModelState.AddModelError("SR_AM.Approved_Plan_Validity_From", "Validity from field is required");
                            }
                            if (string.IsNullOrEmpty(objallModel.SR_AM.Approved_Plan_Validity_To))
                            {
                                ModelState.AddModelError("SR_AM.Approved_Plan_Validity_To", "Validity to field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.Approved_Plan_Quantity)))
                            {
                                ModelState.AddModelError("SR_AM.Approved_Plan_Quantity", "Approved Plan Quantity field is required");
                            }
                            if (string.IsNullOrEmpty(objallModel.SR_AM.Environment_Clearance_Validity_From))
                            {
                                ModelState.AddModelError("SR_AM.Environment_Clearance_Validity_From", "Environment Clearance Validity From field is required");
                            }
                            if (string.IsNullOrEmpty(objallModel.SR_AM.Environment_Clearance_Validity_To))
                            {
                                ModelState.AddModelError("SR_AM.Environment_Clearance_Validity_To", "Environment Clearance Validity To field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.Environment_Clearance_Quantity)))
                            {
                                ModelState.AddModelError("SR_AM.Environment_Clearance_Quantity", "Environment Clearance Quantity field is required");
                            }
                            if (string.IsNullOrEmpty(objallModel.SR_AM.SPCB_Validity_Upto))
                            {
                                ModelState.AddModelError("SR_AM.SPCB_Validity_Upto", "SPCB Validity Upto field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.SPCB_Quantity)))
                            {
                                ModelState.AddModelError("SR_AM.SPCB_Quantity", "SPCB Quantity field is required");
                            }
                            if (string.IsNullOrEmpty(objallModel.SR_AM.Forest_Clearance_Validity_Upto))
                            {
                                ModelState.AddModelError("SR_AM.Forest_Clearance_Validity_Upto", "Forest Clearance Validity Upto field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.Royalty_Paid)))
                            {
                                ModelState.AddModelError("SR_AM.Royalty_Paid", "Royalty Paid field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.Dead_Rent_Paid)))
                            {
                                ModelState.AddModelError("SR_AM.Dead_Rent_Paid", "Dead Rent Paid field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_AM.Contribution_To_DMF)))
                            {
                                ModelState.AddModelError("SR_AM.Contribution_To_DMF", "Contribution To DMF field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_SS1.Systematic_Sustainable_Sub_Type)))
                            {
                                ModelState.AddModelError("SR_SS1.Systematic_Sustainable_Sub_Type", "Approved Quantity field is required");
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(objallModel.SR_SS1.Details)))
                            {
                                ModelState.AddModelError("SR_SS1.Details", "Details field is required");
                            }
                            if (objallModel.SR_SS1.Points_Obtained == 0)
                            {
                                ModelState.AddModelError("SR_SS1.Points_Obtained", "Lessee Mark field is required");
                            }
                            if (objallModel.SR_SS2.Points_Obtained == 0)
                            {
                                ModelState.AddModelError("SR_SS2.Points_Obtained", "Lessee Mark field is required");
                            }
                            if (objallModel.SR_SS3.Points_Obtained == 0)
                            {
                                ModelState.AddModelError("SR_SS3.Points_Obtained", "Lessee Mark field is required");
                            }
                            if (objallModel.SR_SS4.Points_Obtained == 0)
                            {
                                ModelState.AddModelError("SR_SS4.Points_Obtained", "Crusher Plant Covered Lessee Mark field is required");
                            }
                            if (objallModel.SR_SS5.Points_Obtained == 0)
                            {
                                ModelState.AddModelError("SR_SS5.Points_Obtained", "Transportation of mineral in covered vehicles Lessee Mark field is required");
                            }
                            if (objallModel.SR_SS6.Points_Obtained == 0)
                            {
                                ModelState.AddModelError("SR_SS6.Points_Obtained", "Water sprinkling Lessee Mark field is required");
                            }
                            if (objallModel.SR_SS7.Points_Obtained == 0)
                            {
                                ModelState.AddModelError("SR_SS7.Points_Obtained", "Wet drilling Lessee Mark field is required");
                            }
                            if (objallModel.SR_PE1.Points_Obtained == 0)
                            {
                                ModelState.AddModelError("SR_PE1.Points_Obtained", "Lessee Mark field is required");
                            }
                            if (objallModel.SR_PE2.Points_Obtained == 0)
                            {
                                ModelState.AddModelError("SR_PE2.Points_Obtained", "Lessee Mark field is required");
                            }
                            if (objallModel.SR_PE4.Points_Obtained == 0)
                            {
                                ModelState.AddModelError("SR_PE4.Points_Obtained", "Lessee Mark field is required");
                            }
                            if (objallModel.SR_PE5.Points_Obtained == 0)
                            {
                                ModelState.AddModelError("SR_PE5.Points_Obtained", "Lessee Mark field is required");
                            }
                            #endregion
                            if (ModelState.IsValid)
                            {
                                #region Addmore
                                string[] Latitudes = collection["Latitude"].ToString().Split(char.Parse(","));
                                string[] Longitudes = collection["Longitude"].ToString().Split(char.Parse(","));
                                string[] LEASEAREAIDs = collection["LEASEAREAID"].ToString().Split(char.Parse(","));
                                string[] LEASEAREANAMEs = collection["LEASEAREANAME"].ToString().Split(char.Parse(","));
                                string[] LeaseAreaMineralIDs = collection["LeaseAreaMineralID"].ToString().Split(char.Parse(","));
                                string[] LEASEAREAMINERALs = collection["LEASEAREAMINERAL"].ToString().Split(char.Parse(","));
                                for (int i = 0; i < Latitudes.Length; i++)
                                {
                                    if (string.IsNullOrEmpty(Latitudes[i].ToString()) == false)
                                    {
                                        SR_CM.Latitude = (float)Convert.ToDouble(Latitudes[i]);
                                        SR_CM.Longitude = (float)Convert.ToDouble(Longitudes[i]);
                                        objallModel.SR_CM = SR_CM;
                                        objobjmodel = _objCreateModel.AddMore(objallModel);
                                    }
                                }
                                objallModel.SR_CM = objobjmodel.Satus == "1" ? null : objallModel.SR_CM;
                                for (int i = 0; i < LEASEAREAIDs.Length; i++)
                                {
                                    if (string.IsNullOrEmpty(Latitudes[i].ToString()) == false)
                                    {
                                        SR_LAM.Area_Type_Id = Convert.ToInt32(LEASEAREAIDs[i]);
                                        SR_LAM.Area_In_Hectare = (float)Convert.ToDouble(LEASEAREANAMEs[i]);
                                        objallModel.SR_LAM = SR_LAM;
                                        objobjmodel = _objCreateModel.AddMore(objallModel);
                                    }
                                }
                                objallModel.SR_LAM = objobjmodel.Satus == "1" ? null : objallModel.SR_LAM;
                                for (int i = 0; i < LeaseAreaMineralIDs.Length; i++)
                                {
                                    if (string.IsNullOrEmpty(LEASEAREAMINERALs[i].ToString()) == false)
                                    {
                                        SR_LAMM.MineralID = Convert.ToInt32(LeaseAreaMineralIDs[i]);
                                        SR_LAMM.LeaseArea = (float)Convert.ToDouble(LEASEAREANAMEs[i]);
                                        objallModel.SR_LAMM = SR_LAMM;
                                        objobjmodel = _objCreateModel.AddMore(objallModel);
                                    }
                                }
                                objallModel.SR_LAMM = objobjmodel.Satus == "1" ? null : objallModel.SR_LAMM;
                                #endregion
                                #region FileUpload
                                SR_FM.IsFileUpload = true;
                                if (filedgms != null)
                                {
                                    foreach (IFormFile file in filedgms)
                                    {
                                        string mFileAdd = "_DGMS";
                                        var FDate = DateTime.Now;
                                        var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                        if (!Directory.Exists(uploadsFolder))
                                            Directory.CreateDirectory(uploadsFolder);
                                        DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                        di.Attributes = FileAttributes.Normal;
                                        SR_FM.FileName = file.FileName;
                                        SR_FM.FileExtension = file.FileName;
                                        SR_FM.mFile = mFileAdd;
                                        SR_FM.SPName = "SP_CRUD_SR_MapFile_DGMS";
                                        var InputFileName = Path.GetFileName(file.FileName);
                                        var FileType = Path.GetExtension(file.FileName);
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                        filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                                            file.CopyTo(fileStream);
                                    }
                                }
                                if (fileblastlicense != null)
                                {
                                    foreach (IFormFile file in fileblastlicense)
                                    {
                                        string mFileAdd = "_BL";
                                        var FDate = DateTime.Now;
                                        var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                        if (!Directory.Exists(uploadsFolder))
                                            Directory.CreateDirectory(uploadsFolder);
                                        DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                        di.Attributes = FileAttributes.Normal;
                                        SR_FM.FileName = file.FileName;
                                        SR_FM.FileExtension = file.FileName;
                                        SR_FM.mFile = mFileAdd;
                                        SR_FM.SPName = "SP_CRUD_SR_MapFile_BlastingLicense";
                                        var InputFileName = Path.GetFileName(file.FileName);
                                        var FileType = Path.GetExtension(file.FileName);
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                        filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                                            file.CopyTo(fileStream);
                                    }
                                }
                                if (fileec != null)
                                {
                                    foreach (IFormFile file in fileec)
                                    {
                                        string mFileAdd = "_EC";
                                        var FDate = DateTime.Now;
                                        var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                        if (!Directory.Exists(uploadsFolder))
                                            Directory.CreateDirectory(uploadsFolder);
                                        DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                        di.Attributes = FileAttributes.Normal;
                                        SR_FM.FileName = file.FileName;
                                        SR_FM.FileExtension = file.FileName;
                                        SR_FM.mFile = mFileAdd;
                                        SR_FM.SPName = "SP_CRUD_SR_MapFile_EC";
                                        var InputFileName = Path.GetFileName(file.FileName);
                                        var FileType = Path.GetExtension(file.FileName);
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                        filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                                            file.CopyTo(fileStream);
                                    }
                                }
                                if (fileairconsent != null)
                                {
                                    foreach (IFormFile file in fileairconsent)
                                    {
                                        string mFileAdd = "_AirConsent";
                                        var FDate = DateTime.Now;
                                        var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                        if (!Directory.Exists(uploadsFolder))
                                            Directory.CreateDirectory(uploadsFolder);
                                        DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                        di.Attributes = FileAttributes.Normal;
                                        SR_FM.FileName = file.FileName;
                                        SR_FM.FileExtension = file.FileName;
                                        SR_FM.mFile = mFileAdd;
                                        SR_FM.SPName = "SP_CRUD_SR_MapFile_AirConsent";
                                        var InputFileName = Path.GetFileName(file.FileName);
                                        var FileType = Path.GetExtension(file.FileName);
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                        filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                                            file.CopyTo(fileStream);
                                    }
                                }
                                if (filewaterconsent != null)
                                {
                                    foreach (IFormFile file in filewaterconsent)
                                    {
                                        string mFileAdd = "_WaterConsent";
                                        var FDate = DateTime.Now;
                                        var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                        if (!Directory.Exists(uploadsFolder))
                                            Directory.CreateDirectory(uploadsFolder);
                                        DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                        di.Attributes = FileAttributes.Normal;
                                        SR_FM.FileName = file.FileName;
                                        SR_FM.FileExtension = file.FileName;
                                        SR_FM.mFile = mFileAdd;
                                        SR_FM.SPName = "SP_CRUD_SR_MapFile_WaterConsent";
                                        var InputFileName = Path.GetFileName(file.FileName);
                                        var FileType = Path.GetExtension(file.FileName);
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                        filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                                            file.CopyTo(fileStream);
                                    }
                                }
                                if (fileother != null)
                                {
                                    foreach (IFormFile file in fileother)
                                    {
                                        string mFileAdd = "_Other";
                                        var FDate = DateTime.Now;
                                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                        if (!Directory.Exists(uploadsFolder))
                                            Directory.CreateDirectory(uploadsFolder);
                                        DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                        di.Attributes = FileAttributes.Normal;
                                        SR_FM.FileName = file.FileName;
                                        SR_FM.FileExtension = file.FileName;
                                        SR_FM.HasObtainOther = objallModel.HasObtainOther;
                                        SR_FM.mFile = mFileAdd;
                                        SR_FM.SPName = "SP_CRUD_SR_MapFile_Other_Assesment";
                                        var InputFileName = Path.GetFileName(file.FileName);
                                        var FileType = Path.GetExtension(file.FileName);
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                        var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + objobjmodel.Satus + mFileAdd;
                                        filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                                            file.CopyTo(fileStream);
                                    }
                                }
                                #endregion
                                #region Module 1  Systematic_Sustainable DataTable
                                objallModel.Mode = "1";
                                for (int i = 0; i < 7; i++)
                                {
                                    if (i == 0)
                                    {
                                        objallModel.SR_SS = objallModel.SR_SS1;
                                    }
                                    if (i == 1)
                                    {
                                        objallModel.SR_SS = objallModel.SR_SS2;
                                    }
                                    if (i == 2)
                                    {
                                        objallModel.SR_SS = objallModel.SR_SS3;
                                    }
                                    if (i == 3)
                                    {
                                        objallModel.SR_SS = objallModel.SR_SS4;
                                    }
                                    if (i == 4)
                                    {
                                        objallModel.SR_SS = objallModel.SR_SS5;
                                    }
                                    if (i == 5)
                                    {
                                        objallModel.SR_SS = objallModel.SR_SS6;
                                    }
                                    if (i == 6)
                                    {
                                        objallModel.SR_SS = objallModel.SR_SS7;
                                    }
                                    objobjmodel = _objCreateModel.AddSystSust(objallModel);
                                }
                                #endregion
                                #region Module 2 Protection_Environment DataTable                          
                                for (int i = 0; i < 5; i++)
                                {
                                    if (i == 0)
                                    {
                                        if (filecompliancereportingSPCB != null)
                                        {
                                            foreach (IFormFile file in filecompliancereportingSPCB)
                                            {
                                                string mFileAdd = "_ProtectionEnvironment";
                                                var FDate = DateTime.Now;
                                                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                                if (!Directory.Exists(uploadsFolder))
                                                    Directory.CreateDirectory(uploadsFolder);
                                                DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                                di.Attributes = FileAttributes.Normal;
                                                SR_FM.SR_PE = objallModel.SR_PE1;
                                                SR_FM.FileName = file.FileName;
                                                SR_FM.FileExtension = file.FileName;
                                                SR_FM.mFile = mFileAdd;
                                                SR_FM.IsFileUpload = true;
                                                SR_FM.SPName = "SP_CRUD_SR_MapFile_Protection_Environment";
                                                var InputFileName = Path.GetFileName(file.FileName);
                                                var FileType = Path.GetExtension(file.FileName);
                                                objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                                filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                    file.CopyTo(fileStream);
                                            }
                                        }
                                    }
                                    else if (i == 1)
                                    {
                                        if (filecompliancereportingMoef != null)
                                        {
                                            foreach (IFormFile file in filecompliancereportingMoef)
                                            {
                                                string mFileAdd = "_ProtectionEnvironment";
                                                var FDate = DateTime.Now;
                                                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                                if (!Directory.Exists(uploadsFolder))
                                                    Directory.CreateDirectory(uploadsFolder);
                                                DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                                di.Attributes = FileAttributes.Normal;
                                                SR_FM.SR_PE = objallModel.SR_PE2;
                                                SR_FM.FileName = file.FileName;
                                                SR_FM.FileExtension = file.FileName;
                                                SR_FM.mFile = mFileAdd;
                                                SR_FM.IsFileUpload = true;
                                                SR_FM.SPName = "SP_CRUD_SR_MapFile_Protection_Environment";
                                                var InputFileName = Path.GetFileName(file.FileName);
                                                var FileType = Path.GetExtension(file.FileName);
                                                objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                                filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                    file.CopyTo(fileStream);
                                            }
                                        }
                                    }
                                    else if (i == 2)
                                    {
                                        SR_FM.SR_PE = objallModel.SR_PE3;
                                        SR_FM.IsFileUpload = false;
                                        SR_FM.mFile = "_ProtectionEnvironment";
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                    }
                                    else if (i == 3)
                                    {
                                        if (fileducumentplants != null)
                                        {
                                            foreach (IFormFile file in fileducumentplants)
                                            {
                                                string mFileAdd = "_ProtectionEnvironment";
                                                var FDate = DateTime.Now;
                                                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                                if (!Directory.Exists(uploadsFolder))
                                                    Directory.CreateDirectory(uploadsFolder);
                                                DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                                di.Attributes = FileAttributes.Normal;
                                                SR_FM.SR_PE = objallModel.SR_PE4;
                                                SR_FM.FileName = file.FileName;
                                                SR_FM.FileExtension = file.FileName;
                                                SR_FM.mFile = mFileAdd;
                                                SR_FM.IsFileUpload = true;
                                                SR_FM.SPName = "SP_CRUD_SR_MapFile_Protection_Environment";
                                                var InputFileName = Path.GetFileName(file.FileName);
                                                var FileType = Path.GetExtension(file.FileName);
                                                objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                                filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                    file.CopyTo(fileStream);
                                            }
                                        }
                                    }
                                    else if (i == 4)
                                    {
                                        SR_FM.SR_PE = objallModel.SR_PE5;
                                        SR_FM.IsFileUpload = false;
                                        SR_FM.mFile = "_ProtectionEnvironment";
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                    }
                                }
                                #endregion
                                #region Module 3  Health_Saftey DataTable

                                for (int i = 0; i < 8; i++)
                                {
                                    string mFileAdd = "_HealthSafety";
                                    SR_FM.mFile = mFileAdd;
                                    if (i == 0)
                                    {
                                        SR_FM.SR_HS = objallModel.SR_HS1;
                                        SR_FM.IsFileUpload = false;
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                    }
                                    if (i == 1)
                                    {
                                        SR_FM.SR_HS = objallModel.SR_HS2;
                                        SR_FM.IsFileUpload = false;
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                    }
                                    if (i == 2)
                                    {
                                        SR_FM.SR_HS = objallModel.SR_HS3;
                                        SR_FM.IsFileUpload = false;
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                    }
                                    if (i == 3)
                                    {
                                        SR_FM.SR_HS = objallModel.SR_HS4;
                                        if (fileprovisionofdrinking != null)
                                        {
                                            foreach (IFormFile file in fileprovisionofdrinking)
                                            {
                                                var FDate = DateTime.Now;
                                                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                                if (!Directory.Exists(uploadsFolder))
                                                    Directory.CreateDirectory(uploadsFolder);
                                                DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                                di.Attributes = FileAttributes.Normal;
                                                SR_FM.FileName = file.FileName;
                                                SR_FM.FileExtension = file.FileName;
                                                SR_FM.SPName = "SP_CRUD_SR_MapFile_Health_Safety";
                                                SR_FM.IsFileUpload = true;
                                                var InputFileName = Path.GetFileName(file.FileName);
                                                var FileType = Path.GetExtension(file.FileName);
                                                objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                                filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                    file.CopyTo(fileStream);
                                            }
                                        }
                                    }
                                    if (i == 4)
                                    {
                                        SR_FM.SR_HS = objallModel.SR_HS5;
                                        if (fileprovisionofbasic != null)
                                        {
                                            foreach (IFormFile file in fileprovisionofbasic)
                                            {
                                                var FDate = DateTime.Now;
                                                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                                if (!Directory.Exists(uploadsFolder))
                                                    Directory.CreateDirectory(uploadsFolder);
                                                DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                                di.Attributes = FileAttributes.Normal;
                                                SR_FM.FileName = file.FileName;
                                                SR_FM.FileExtension = file.FileName;
                                                SR_FM.SPName = "SP_CRUD_SR_MapFile_Health_Safety";
                                                SR_FM.IsFileUpload = true;
                                                var InputFileName = Path.GetFileName(file.FileName);
                                                var FileType = Path.GetExtension(file.FileName);
                                                objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                                filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                    file.CopyTo(fileStream);
                                            }
                                        }
                                    }
                                    if (i == 5)
                                    {
                                        SR_FM.SR_HS = objallModel.SR_HS6;
                                        SR_FM.IsFileUpload = false;
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                    }
                                    if (i == 6)
                                    {
                                        SR_FM.SR_HS = objallModel.SR_HS7;
                                        SR_FM.IsFileUpload = false;
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                    }
                                    if (i == 7)
                                    {
                                        SR_FM.SR_HS = objallModel.SR_HS8;
                                        SR_FM.IsFileUpload = false;
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                    }

                                }
                                #endregion
                                #region Module 4 Statutory_Compliance
                                for (int i = 0; i < 8; i++)
                                {
                                    if (i == 0)
                                    {
                                        SR_FM.SR_SC = objallModel.SR_SC1;
                                        SR_FM.IsFileUpload = false;
                                        SR_FM.mFile = "_StatutoryCompliance";
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                    }
                                    if (i == 1)
                                    {
                                        SR_FM.SR_SC = objallModel.SR_SC2;
                                        SR_FM.IsFileUpload = false;
                                        SR_FM.mFile = "_StatutoryCompliance";
                                        objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                    }
                                    if (i == 2)
                                    {
                                        SR_FM.SR_SC = objallModel.SR_SC3;
                                        if (fileappminesmanager != null)
                                        {
                                            foreach (IFormFile file in fileappminesmanager)
                                            {
                                                string mFileAdd = "_StatutoryCompliance";
                                                var FDate = DateTime.Now;
                                                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                                if (!Directory.Exists(uploadsFolder))
                                                    Directory.CreateDirectory(uploadsFolder);
                                                DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                                di.Attributes = FileAttributes.Normal;
                                                SR_FM.FileName = file.FileName;
                                                SR_FM.FileExtension = file.FileName;
                                                SR_FM.mFile = mFileAdd;
                                                SR_FM.IsFileUpload = true;
                                                SR_FM.SPName = "SP_CRUD_SR_MapFile_Statutory_Compliance";
                                                var InputFileName = Path.GetFileName(file.FileName);
                                                var FileType = Path.GetExtension(file.FileName);
                                                objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                                filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                    file.CopyTo(fileStream);
                                            }
                                        }
                                    }
                                    if (i == 3)
                                    {
                                        SR_FM.SR_SC = objallModel.SR_SC4;
                                        if (fileappforeman != null)
                                        {
                                            foreach (IFormFile file in fileappforeman)
                                            {
                                                string mFileAdd = "_StatutoryCompliance";
                                                var FDate = DateTime.Now;
                                                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                                if (!Directory.Exists(uploadsFolder))
                                                    Directory.CreateDirectory(uploadsFolder);
                                                DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                                di.Attributes = FileAttributes.Normal;
                                                SR_FM.FileName = file.FileName;
                                                SR_FM.FileExtension = file.FileName;
                                                SR_FM.mFile = mFileAdd;
                                                SR_FM.IsFileUpload = true;
                                                SR_FM.SPName = "SP_CRUD_SR_MapFile_Statutory_Compliance";
                                                var InputFileName = Path.GetFileName(file.FileName);
                                                var FileType = Path.GetExtension(file.FileName);
                                                objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                                filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                    file.CopyTo(fileStream);
                                            }
                                        }
                                    }
                                    if (i == 4)
                                    {
                                        SR_FM.SR_SC = objallModel.SR_SC5;
                                        if (fileappminingmate != null)
                                        {
                                            foreach (IFormFile file in fileappminingmate)
                                            {
                                                string mFileAdd = "_StatutoryCompliance";
                                                var FDate = DateTime.Now;
                                                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                                if (!Directory.Exists(uploadsFolder))
                                                    Directory.CreateDirectory(uploadsFolder);
                                                DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                                di.Attributes = FileAttributes.Normal;
                                                SR_FM.FileName = file.FileName;
                                                SR_FM.FileExtension = file.FileName;
                                                SR_FM.mFile = mFileAdd;
                                                SR_FM.IsFileUpload = true;
                                                SR_FM.SPName = "SP_CRUD_SR_MapFile_Statutory_Compliance";
                                                var InputFileName = Path.GetFileName(file.FileName);
                                                var FileType = Path.GetExtension(file.FileName);
                                                objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                                filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                    file.CopyTo(fileStream);
                                            }
                                        }
                                    }
                                    if (i == 5)
                                    {
                                        SR_FM.SR_SC = objallModel.SR_SC6;
                                        if (fileappblaster != null)
                                        {
                                            foreach (IFormFile file in fileappblaster)
                                            {
                                                string mFileAdd = "_StatutoryCompliance";
                                                var FDate = DateTime.Now;
                                                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                                if (!Directory.Exists(uploadsFolder))
                                                    Directory.CreateDirectory(uploadsFolder);
                                                DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                                di.Attributes = FileAttributes.Normal;
                                                SR_FM.FileName = file.FileName;
                                                SR_FM.FileExtension = file.FileName;
                                                SR_FM.mFile = mFileAdd;
                                                SR_FM.IsFileUpload = true;
                                                SR_FM.SPName = "SP_CRUD_SR_MapFile_Statutory_Compliance";
                                                var InputFileName = Path.GetFileName(file.FileName);
                                                var FileType = Path.GetExtension(file.FileName);
                                                objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                                filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                    file.CopyTo(fileStream);
                                            }
                                        }
                                    }
                                    if (i == 6)
                                    {
                                        SR_FM.SR_SC = objallModel.SR_SC7;
                                        if (fileauthenticatedlease != null)
                                        {
                                            foreach (IFormFile file in fileauthenticatedlease)
                                            {
                                                string mFileAdd = "_StatutoryCompliance";
                                                var FDate = DateTime.Now;
                                                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                                if (!Directory.Exists(uploadsFolder))
                                                    Directory.CreateDirectory(uploadsFolder);
                                                DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                                di.Attributes = FileAttributes.Normal;
                                                SR_FM.FileName = file.FileName;
                                                SR_FM.FileExtension = file.FileName;
                                                SR_FM.mFile = mFileAdd;
                                                SR_FM.IsFileUpload = true;
                                                SR_FM.SPName = "SP_CRUD_SR_MapFile_Statutory_Compliance";
                                                var InputFileName = Path.GetFileName(file.FileName);
                                                var FileType = Path.GetExtension(file.FileName);
                                                objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                                filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                    file.CopyTo(fileStream);
                                            }
                                        }
                                    }
                                    if (i == 7)
                                    {
                                        SR_FM.SR_SC = objallModel.SR_SC8;
                                        if (fileerectionofdgps != null)
                                        {
                                            foreach (IFormFile file in fileerectionofdgps)
                                            {
                                                string mFileAdd = "_StatutoryCompliance";
                                                var FDate = DateTime.Now;
                                                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + SR_FM.Assessment_ID + mFileAdd;
                                                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));
                                                if (!Directory.Exists(uploadsFolder))
                                                    Directory.CreateDirectory(uploadsFolder);
                                                DirectoryInfo di = new DirectoryInfo(uploadsFolder);
                                                di.Attributes = FileAttributes.Normal;
                                                SR_FM.FileName = file.FileName;
                                                SR_FM.FileExtension = file.FileName;
                                                SR_FM.mFile = mFileAdd;
                                                SR_FM.IsFileUpload = true;
                                                SR_FM.SPName = "SP_CRUD_SR_MapFile_Statutory_Compliance";
                                                var InputFileName = Path.GetFileName(file.FileName);
                                                var FileType = Path.GetExtension(file.FileName);
                                                objobjmodel = _objCreateModel.FileUpload(SR_FM);
                                                filePath = Path.Combine(uploadsFolder, objobjmodel.Msg);
                                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                    file.CopyTo(fileStream);
                                            }
                                        }
                                    }
                                }
                                #endregion
                                transaction.Commit();
                                TempData["msg"] = objobjmodel.Satus;
                            }
                            else
                            {
                                ViewBag.Date = DateTime.Now.ToString("dd/MM/yyyy");
                                Binddropdowns();
                                ViewBag.Button = "Submit";
                                return View(objallModel);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                        finally
                        {
                            collection = null; filedgms = null; fileblastlicense = null;
                            fileec = null; fileairconsent = null; filewaterconsent = null; fileother = null;
                            filecompliancereportingSPCB = null; filecompliancereportingMoef = null; fileducumentplants = null;
                            fileprovisionofdrinking = null; fileprovisionofbasic = null; fileappminesmanager = null; fileappforeman = null;
                            fileappminingmate = null; fileappblaster = null; fileauthenticatedlease = null; fileerectionofdgps = null;
                            SR_FM = null; SR_AM = null;
                            SR_PE = null; SR_SS = null;
                            SR_HS = null; SR_SC = null;
                            objallModel = null;
                            SR_CM = null;
                            SR_LAM = null;
                            SR_LAMM = null;
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
        #endregion
        #region EditLesseeAssessment
        /// <summary>
        /// Edit Lessee Assessment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditLE(int id = 0)
        {
            AllModel objmodel = new AllModel();
            try
            {
                objmodel = GETEdit(id);
                return View(objmodel);
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
        /// <summary>
        /// MI Assessment Review
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditMI(int id = 0)
        {
            AllModel objmodel = new AllModel();
            try
            {
                objmodel = GETEdit(id);
                return View(objmodel);
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
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult EditMI(int id, string submit, AllModel objallModel)
        {
            try
            {
                #region Validation
                if (objallModel.SR_SS1.First_Point==0)
                {
                    ModelState.AddModelError("SR_SS1.First_Point", "Mining Inspector Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS1.First_Remark))
                {
                    ModelState.AddModelError("SR_SS1.First_Remark", "Mining Inspector Remark field is required");
                }
                if (objallModel.SR_SS2.First_Point == 0)
                {
                    ModelState.AddModelError("SR_SS2.First_Point", "Mining Inspector Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS2.First_Remark))
                {
                    ModelState.AddModelError("SR_SS2.First_Remark", "Mining Inspector Remark field is required");
                }
                if (objallModel.SR_SS3.First_Point == 0)
                {
                    ModelState.AddModelError("SR_SS3.First_Point", "Mining Inspector Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS3.First_Remark))
                {
                    ModelState.AddModelError("SR_SS3.First_Remark", "Mining Inspector Remark field is required");
                }
                if (objallModel.SR_SS4.First_Point == 0)
                {
                    ModelState.AddModelError("SR_SS4.First_Point", "Mining Inspector Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS4.First_Remark))
                {
                    ModelState.AddModelError("SR_SS4.First_Remark", "Mining Inspector Remark field is required");
                }
                if (objallModel.SR_SS5.First_Point == 0)
                {
                    ModelState.AddModelError("SR_SS5.First_Point", "Mining Inspector Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS5.First_Remark))
                {
                    ModelState.AddModelError("SR_SS5.First_Remark", "Mining Inspector Remark field is required");
                }
                if (objallModel.SR_SS6.First_Point == 0)
                {
                    ModelState.AddModelError("SR_SS6.First_Point", "Mining Inspector Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS6.First_Remark))
                {
                    ModelState.AddModelError("SR_SS6.First_Remark", "Mining Inspector Remark field is required");
                }
                if (objallModel.SR_SS7.First_Point == 0)
                {
                    ModelState.AddModelError("SR_SS7.First_Point", "Mining Inspector Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS7.First_Remark))
                {
                    ModelState.AddModelError("SR_SS7.First_Remark", "Mining Inspector Remark field is required");
                }
                if (objallModel.SR_PE1.First_Point == 0)
                {
                    ModelState.AddModelError("SR_PE1.First_Point", "Mining Inspector Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE1.First_Remark))
                {
                    ModelState.AddModelError("SR_PE1.First_Remark", "Mining Inspector Remark field is required");
                }
                if (objallModel.SR_PE2.First_Point == 0)
                {
                    ModelState.AddModelError("SR_PE2.First_Point", "Mining Inspector Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE2.First_Remark))
                {
                    ModelState.AddModelError("SR_PE2.First_Remark", "Mining Inspector Remark field is required");
                }
                if (objallModel.SR_PE4.First_Point == 0)
                {
                    ModelState.AddModelError("SR_PE4.First_Point", "Mining Inspector Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE4.First_Remark))
                {
                    ModelState.AddModelError("SR_PE4.First_Remark", "Mining Inspector Remark field is required");
                }
                if (objallModel.SR_PE5.First_Point == 0)
                {
                    ModelState.AddModelError("SR_PE5.First_Point", "Mining Inspector Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE5.First_Remark))
                {
                    ModelState.AddModelError("SR_PE5.First_Remark", "Mining Inspector Remark field is required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    TempData["Msg"] = POSTEdit(id, submit, objallModel);
                    return RedirectToAction("ViewList", "Assessment", new { Area = "Starrating" });
                }
                else
                {
                    objallModel = GETEdit(id);
                    return View(objallModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objallModel = null;
            }
        }
        /// <summary>
        /// MI Assessment Review
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditDD(int id = 0)
        {
            AllModel objmodel = new AllModel();
            try
            {
                objmodel = GETEdit(id);
                return View(objmodel);
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
        /// <summary>
        /// DD Assessment Review
        /// </summary>
        /// <param name="id"></param>
        /// <param name="submit"></param>
        /// <param name="objallModel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult EditDD(int id, string submit, AllModel objallModel)
        {
            try
            {
                #region Validation
                if (objallModel.SR_SS1.Second_Point == 0)
                {
                    ModelState.AddModelError("SR_SS1.Second_Point", "DD/MO Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS1.Second_Remark))
                {
                    ModelState.AddModelError("SR_SS1.Second_Remark", "DD/MO Remark field is required");
                }
                if (objallModel.SR_SS2.Second_Point == 0)
                {
                    ModelState.AddModelError("SR_SS2.Second_Point", "DD/MO Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS2.Second_Remark))
                {
                    ModelState.AddModelError("SR_SS2.Second_Remark", "DD/MO Remark field is required");
                }
                if (objallModel.SR_SS3.Second_Point == 0)
                {
                    ModelState.AddModelError("SR_SS3.Second_Point", "DD/MO Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS3.Second_Remark))
                {
                    ModelState.AddModelError("SR_SS3.Second_Remark", "DD/MO Remark field is required");
                }
                if (objallModel.SR_SS4.Second_Point == 0)
                {
                    ModelState.AddModelError("SR_SS4.Second_Point", "DD/MO Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS4.Second_Remark))
                {
                    ModelState.AddModelError("SR_SS4.Second_Remark", "DD/MO Remark field is required");
                }
                if (objallModel.SR_SS5.Second_Point == 0)
                {
                    ModelState.AddModelError("SR_SS5.Second_Point", "DD/MO Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS5.Second_Remark))
                {
                    ModelState.AddModelError("SR_SS5.Second_Remark", "DD/MO Remark field is required");
                }
                if (objallModel.SR_SS6.Second_Point == 0)
                {
                    ModelState.AddModelError("SR_SS6.Second_Point", "DD/MO Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS6.Second_Remark))
                {
                    ModelState.AddModelError("SR_SS6.Second_Remark", "DD/MO Remark field is required");
                }
                if (objallModel.SR_SS7.Second_Point == 0)
                {
                    ModelState.AddModelError("SR_SS7.Second_Point", "DD/MO Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS7.Second_Remark))
                {
                    ModelState.AddModelError("SR_SS7.Second_Remark", "DD/MO Remark field is required");
                }
                if (objallModel.SR_PE1.Second_Point == 0)
                {
                    ModelState.AddModelError("SR_PE1.Second_Point", "DD/MO Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE1.Second_Remark))
                {
                    ModelState.AddModelError("SR_PE1.Second_Remark", "DD/MO Remark field is required");
                }
                if (objallModel.SR_PE2.Second_Point == 0)
                {
                    ModelState.AddModelError("SR_PE2.Second_Point", "DD/MO Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE2.Second_Remark))
                {
                    ModelState.AddModelError("SR_PE2.Second_Remark", "DD/MO Remark field is required");
                }
                if (objallModel.SR_PE4.Second_Point == 0)
                {
                    ModelState.AddModelError("SR_PE4.Second_Point", "DD/MO Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE4.Second_Remark))
                {
                    ModelState.AddModelError("SR_PE4.Second_Remark", "DD/MO Remark field is required");
                }
                if (objallModel.SR_PE5.Second_Point == 0)
                {
                    ModelState.AddModelError("SR_PE5.Second_Point", "DD/MO Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE5.Second_Remark))
                {
                    ModelState.AddModelError("SR_PE5.Second_Remark", "DD/MO Remark field is required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    TempData["Msg"] = POSTEdit(id, submit, objallModel);
                    return RedirectToAction("ViewList", "Assessment", new { Area = "Starrating" });
                }
                else
                {
                    objallModel = GETEdit(id);
                    return View(objallModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objallModel = null;
            }
        }
        /// <summary>
        /// DGM Assessment Review
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditDGM(int id = 0)
        {
            AllModel objmodel = new AllModel();
            try
            {
                objmodel = GETEdit(id);
                return View(objmodel);
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
        /// <summary>
        /// DGM Assessment Review
        /// </summary>
        /// <param name="id"></param>
        /// <param name="submit"></param>
        /// <param name="objallModel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult EditDGM(int id, string submit, AllModel objallModel)
        {
            try
            {
                #region Validation
                if (objallModel.SR_SS1.Third_Point == 0)
                {
                    ModelState.AddModelError("SR_SS1.Third_Point", "DGM Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS1.Third_Remark))
                {
                    ModelState.AddModelError("SR_SS1.Third_Remark", "DGM Remark field is required");
                }
                if (objallModel.SR_SS2.Third_Point == 0)
                {
                    ModelState.AddModelError("SR_SS2.Third_Point", "DGM Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS2.Third_Remark))
                {
                    ModelState.AddModelError("SR_SS2.Third_Remark", "DGM Remark field is required");
                }
                if (objallModel.SR_SS3.Third_Point == 0)
                {
                    ModelState.AddModelError("SR_SS3.Third_Point", "DGM Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS3.Third_Remark))
                {
                    ModelState.AddModelError("SR_SS3.Third_Remark", "DGM Remark field is required");
                }
                if (objallModel.SR_SS4.Third_Point == 0)
                {
                    ModelState.AddModelError("SR_SS4.Third_Point", "DGM Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS4.Third_Remark))
                {
                    ModelState.AddModelError("SR_SS4.Third_Remark", "DGM Remark field is required");
                }
                if (objallModel.SR_SS5.Third_Point == 0)
                {
                    ModelState.AddModelError("SR_SS5.Third_Point", "DGM Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS5.Third_Remark))
                {
                    ModelState.AddModelError("SR_SS5.Third_Remark", "DGM Remark field is required");
                }
                if (objallModel.SR_SS6.Third_Point == 0)
                {
                    ModelState.AddModelError("SR_SS6.Third_Point", "DGM Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS6.Third_Remark))
                {
                    ModelState.AddModelError("SR_SS6.Third_Remark", "DGM Remark field is required");
                }
                if (objallModel.SR_SS7.Third_Point == 0)
                {
                    ModelState.AddModelError("SR_SS7.Third_Point", "DGM Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_SS7.Third_Remark))
                {
                    ModelState.AddModelError("SR_SS7.Third_Remark", "DGM Remark field is required");
                }
                if (objallModel.SR_PE1.Third_Point == 0)
                {
                    ModelState.AddModelError("SR_PE1.Third_Point", "DGM Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE1.Third_Remark))
                {
                    ModelState.AddModelError("SR_PE1.Third_Remark", "DGM Remark field is required");
                }
                if (objallModel.SR_PE2.Third_Point == 0)
                {
                    ModelState.AddModelError("SR_PE2.Third_Point", "DGM Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE2.Third_Remark))
                {
                    ModelState.AddModelError("SR_PE2.Third_Remark", "DGM Remark field is required");
                }
                if (objallModel.SR_PE4.Third_Point == 0)
                {
                    ModelState.AddModelError("SR_PE4.Third_Point", "DGM Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE4.Third_Remark))
                {
                    ModelState.AddModelError("SR_PE4.Third_Remark", "DGM Remark field is required");
                }
                if (objallModel.SR_PE5.Third_Point == 0)
                {
                    ModelState.AddModelError("SR_PE5.Third_Point", "DGM Mark field is required");
                }
                if (string.IsNullOrEmpty(objallModel.SR_PE5.Third_Remark))
                {
                    ModelState.AddModelError("SR_PE5.Third_Remark", "DGM Remark field is required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    TempData["Msg"] = POSTEdit(id, submit, objallModel);
                    return RedirectToAction("ViewList", "Assessment", new { Area = "Starrating" });
                }
                else
                {
                    objallModel = GETEdit(id);
                    return View(objallModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objallModel = null;
            }
        }
        /// <summary>
        /// To bind File Upload Data in view
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUploadData(int AssessmentId, string Action, int FMId)
        {
            List<SR_Additional_MappFile> fmOtherList = new List<SR_Additional_MappFile>();
            List<SR_FileMaster> fmPEPDWList = new List<SR_FileMaster>();
            SR_MF = new SR_Additional_MappFile();
            SR_FM = new SR_FileMaster();
            try
            {
                if (FMId == 0)
                {
                    SR_MF.AssesmentID = AssessmentId;
                    SR_MF.Action = Action;
                    fmOtherList = _objCreateModel.GetOtherFiles(SR_MF);
                    return Json(fmOtherList);
                }
                else
                {
                    SR_FM.Assessment_ID = AssessmentId;
                    SR_FM.Action = Action;
                    SR_FM.FileMasterID = FMId;
                    fmPEPDWList = _objCreateModel.GetInfoFiles(SR_FM);
                    return Json(fmPEPDWList);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                fmOtherList = null;
            }
        }
        #endregion
    }
}

