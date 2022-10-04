// ***********************************************************************
//  Controller Name          : AssessmentController
//  Desciption               : View Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 15 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using StarratingApp.Areas.Starrating.Models.Assessment;
using StarratingEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.Data;
using StarratingApp.Areas.Starrating.Models.Create;

namespace StarratingApp.Areas.Starrating.Controllers
{
    [Area("Starrating")]
    public class AssessmentController : Controller
    {
        #region Gobal variable and object declaration
        /// <summary>
        /// Gobal variable and object declaration
        /// </summary>
        private readonly IAssessmentModel _objAssessmentModel;
        private readonly ICreateModel _objCreateModel;
        AssessmentListmaster objmodel;
        #endregion
        #region constructor declaration
        /// <summary>
        /// constructor declaration
        /// </summary>
        /// <param name="objAssessmentModel"></param>
        public AssessmentController(IAssessmentModel objAssessmentModel, ICreateModel objCreateModel)
        {
            _objAssessmentModel = objAssessmentModel;
            _objCreateModel = objCreateModel;
        }
        #endregion
        #region ViewList
        /// <summary>
        /// GET method of ViewList
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewListMI()
        {
            List<AssessmentListmaster> lstAssessmentListmaster = new List<AssessmentListmaster>();
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                BindDropdowns();
                lstAssessmentListmaster = _objAssessmentModel.View(objmodel);
                ViewBag.ViewList = lstAssessmentListmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
                lstAssessmentListmaster = null;
            }
        }
        /// <summary>
        /// POST method of ViewList
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="Show1"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewListMI(AssessmentListmaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objAssessmentModel.View(objmodel);
                BindDropdowns();
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
        /// GET method of DD ViewList
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewListDD()
        {
            List<AssessmentListmaster> lstAssessmentListmaster = new List<AssessmentListmaster>();
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                BindDropdowns();
                lstAssessmentListmaster = _objAssessmentModel.View(objmodel);
                ViewBag.ViewList = lstAssessmentListmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
                lstAssessmentListmaster = null;
            }
        }
        /// <summary>
        /// POST method of DD ViewList
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="Show1"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewListDD(AssessmentListmaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objAssessmentModel.View(objmodel);
                BindDropdowns();
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
                lstfy = _objAssessmentModel.GetFYList(objmodel);
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
        /// <summary>
        /// Bind Modal Popup Ticket Details
        /// </summary>
        /// <param name="LesseeCode"></param>
        /// <returns></returns>
        public JsonResult GetTicketlist(string LesseeCode)
        {
            objmodel = new AssessmentListmaster();
            List<AssessmentListmaster> lstfy = new List<AssessmentListmaster>();
            try
            {
                objmodel.Lessee_Code = LesseeCode;
                lstfy = _objAssessmentModel.View(objmodel);
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
        /// <summary>
        /// Bind Modal Popup Lessee All Details
        /// </summary>
        /// <param name="LesseeCode"></param>
        /// <returns></returns>
        public JsonResult GetLesseeDetails(int AssessmentId)
        {
            SR_Assesment_Master SR_AM = new SR_Assesment_Master();
            List<AssessmentListmaster> lstfy = new List<AssessmentListmaster>();
            try
            {
                SR_AM.Assesment_Id = AssessmentId;
                SR_AM = _objCreateModel.Edit(SR_AM);
                return Json(SR_AM);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                SR_AM = null;
                lstfy = null;
            }
        }
        /// <summary>
        /// Bind Mineral,Coordinates,Leasr Area Table details
        /// </summary>
        /// <param name="AssessmentId"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public JsonResult GetTableDataDetails(int AssessmentId, string Type)
        {
            List<SR_Lease_Area_Mineral> SR_LAMMlist = new List<SR_Lease_Area_Mineral>();
            List<SR_Lease_Area_Master> SR_LAMlist = new List<SR_Lease_Area_Master>();
            List<SR_Coordinate_Master> SR_CMlist = new List<SR_Coordinate_Master>();
            SR_Lease_Area_Mineral SR_LAMM = new SR_Lease_Area_Mineral();
            SR_Lease_Area_Master SR_LAM = new SR_Lease_Area_Master();
            SR_Coordinate_Master SR_CM = new SR_Coordinate_Master();
            SR_LAMM.Assesment_Id = AssessmentId; SR_LAM.Assesment_Id = AssessmentId; SR_CM.Assesment_Id = AssessmentId;
            try
            {
                if (Type == "Mineral")
                {
                    SR_LAMMlist = _objCreateModel.GetLeaseTypeList(SR_LAMM);
                    return Json(SR_LAMMlist);
                }
                else if (Type == "Coordinates")
                {
                    SR_CMlist = _objCreateModel.GetCoordinateList(SR_CM);
                    return Json(SR_CMlist);
                }
                else
                {
                    SR_LAMlist = _objCreateModel.GetLeaseAreaList(SR_LAM);
                    return Json(SR_LAMlist);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                SR_LAMMlist = null;
                SR_LAMlist = null;
                SR_CMlist = null;
            }
          
        }
        #endregion
        #region DGM ViewList
        /// <summary>
        /// GET method of ViewListDGM
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewListDGM()
        {
            objmodel = new AssessmentListmaster();
            List<AssessmentListmaster> lstAssessmentListmaster = new List<AssessmentListmaster>();
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                BindDropdowns();
                lstAssessmentListmaster = _objAssessmentModel.View(objmodel);
                ViewBag.ViewList = lstAssessmentListmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
                lstAssessmentListmaster = null;
            }
        }
        /// <summary>
        /// POST method of ViewListDGM
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="Show1"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewListDGM(AssessmentListmaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objAssessmentModel.View(objmodel);
                BindDropdowns();
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
        #endregion
        #region Global Methods Declaration
        /// <summary>
        /// To bind State Dropdown
        /// </summary>
        public void BindDropdowns()
        {
            objmodel = new AssessmentListmaster();
            try
            {
                List<AssessmentListmaster> listStateResult = new List<AssessmentListmaster>();
                listStateResult = _objAssessmentModel.GetStateList(objmodel);
                ViewBag.State = new SelectList(listStateResult, "StateId", "StateName", objmodel.StateId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// To bind District Dropdown based on StateId
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public JsonResult GetDistrictdetailsByRegionId(int? StateId)
        {
            objmodel = new AssessmentListmaster();
            try
            {
                objmodel.StateId = StateId;
                List<AssessmentListmaster> lstdistrictModels = new List<AssessmentListmaster>();
                lstdistrictModels = _objAssessmentModel.GetDistrictList(objmodel);
                return Json(lstdistrictModels);
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
        /// To bind Tehsil Dropdown based on DistrictId
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>
        public JsonResult GetTehsildetailsByDistrictId(int? DistrictId)
        {
            objmodel = new AssessmentListmaster();
            try
            {
                objmodel.DistrictId = DistrictId;
                List<AssessmentListmaster> lsttehsilModels = new List<AssessmentListmaster>();
                lsttehsilModels = _objAssessmentModel.GetTehsilList(objmodel);
                return Json(lsttehsilModels);
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
        /// To bind Village Dropdown based on TehsilID
        /// </summary>
        /// <param name="TehsilID"></param>
        /// <returns></returns>
        public JsonResult GetVillagedetailsByTehsilId(int? TehsilID)
        {
            objmodel = new AssessmentListmaster();
            try
            {
                objmodel.TehsilID = TehsilID;
                List<AssessmentListmaster> lstvillageModels = new List<AssessmentListmaster>();
                lstvillageModels = _objAssessmentModel.GetVillageList(objmodel);
                return Json(lstvillageModels);
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
        #endregion
    }
}
