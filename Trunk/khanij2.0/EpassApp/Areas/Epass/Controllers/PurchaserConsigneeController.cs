// ***********************************************************************
//  Controller Name          : PurchaserConsignee
//  Desciption               : Add purchaser Consignee against Permit
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 25 June 2021
// ***********************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EpassApp.Areas.Epass.Models.PurchaserConsignee;
using EpassEF;
using Microsoft.AspNetCore.Mvc.Rendering;
using EpassEF.ViewModel;
using EpassApp.Web;
namespace EpassApp.Areas.Epass.Controllers
{
    [Area("EPass")]

    public class PurchaserConsigneeController : Controller
    {
        int userid;//387;//194
        string userType;//"Licensee";//"Lessee";

        //private IPurchaserConsigneeProvider objPurchaser = null;

        //Shesansu Added DI
        private IPurchaserConsigneeProvider _objPurchaser ;

        public PurchaserConsigneeController(IPurchaserConsigneeProvider objPurchaser)
        {
                       _objPurchaser =objPurchaser;

        }



        public IActionResult ViewPermit()
        {
            return View();
        }
        /// <summary>
        /// Added by suroj on 25-jun-2021 to load permit details
        /// </summary>
        /// <returns></returns>
        //public IActionResult GetOpenEpermitDetails()
        //{
        //    PurchaserConsigneeProvider objPurchaser = new PurchaserConsigneeProvider();
        //    PurchaserConsigneeOpenEpermitModel objPermitModel = new PurchaserConsigneeOpenEpermitModel();
        //    try
        //    {

        //        objPermitModel.ActionCode = "GET_OPEN_EPERMIT";
        //        objPermitModel.UserId = userid;
        //        ViewBag.Purchaser = objPurchaser.GetOpenEpermitDetails(objPermitModel);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        throw;
        //    }
        //    finally
        //    {
        //        objPurchaser = null;
        //        objPermitModel = null;
        //    }
        //    return View();
        //}

        //Modified by shesansu to include DI and ViewModel
        public IActionResult GetOpenEpermitDetails()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;

            PurchaserConsigneeOpenEpermitModel objPermitModel = new PurchaserConsigneeOpenEpermitModel();  //object of actual DM         
            List<PurchaserConsigneeViewModel> objPermitModelVM = new List<PurchaserConsigneeViewModel>(); // object of VM 

            try
            {

                objPermitModel.ActionCode = "GET_OPEN_EPERMIT";
                objPermitModel.UserId = userid;

                //ViewBag.Purchaser = _objPurchaser.GetOpenEpermitDetails(objPermitModel);

                List<PurchaserConsigneeOpenEpermitModel> objPermitModelList = _objPurchaser.GetOpenEpermitDetails(objPermitModel);//Service called and stored the data in DM

                foreach (PurchaserConsigneeOpenEpermitModel objPermitModelData in objPermitModelList) //Loop throuch each record
                {
                    PurchaserConsigneeViewModel innerobjPermitModelVM = new PurchaserConsigneeViewModel(); //created object of VM to set the value

                    innerobjPermitModelVM.MINERALGRADE = objPermitModelData.MINERALGRADE;
                    innerobjPermitModelVM.MINERALNAME= objPermitModelData.MINERALNAME;
                    innerobjPermitModelVM.MINERALNATURE = objPermitModelData.MINERALNATURE;
                    innerobjPermitModelVM.MineralType = objPermitModelData.MineralType;
                    innerobjPermitModelVM.PAYABLEROYALTY = objPermitModelData.PAYABLEROYALTY;
                    innerobjPermitModelVM.BULKPERMITNO = objPermitModelData.BULKPERMITNO;
                    innerobjPermitModelVM.BULKPERMITID = objPermitModelData.BULKPERMITID;
                    innerobjPermitModelVM.PAYMENTMODE = objPermitModelData.PAYMENTMODE;
                    innerobjPermitModelVM.TOTALQTY = objPermitModelData.TOTALQTY;
                    innerobjPermitModelVM.UNIT = objPermitModelData.UNIT;
                    innerobjPermitModelVM.PENDINGQTY = objPermitModelData.PENDINGQTY;
                    innerobjPermitModelVM.BlockedQty = objPermitModelData.BlockedQty;
                    innerobjPermitModelVM.DISPATCHEDQTY = objPermitModelData.DISPATCHEDQTY;
                    innerobjPermitModelVM.PermitAdjustedQty = objPermitModelData.PermitAdjustedQty;
                    innerobjPermitModelVM.UserWiseId = objPermitModelData.UserWiseId;
                    objPermitModelVM.Add(innerobjPermitModelVM);
                }                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                _objPurchaser = null;
                objPermitModel = null;
            }
            return View(objPermitModelVM);
        }
        /// <summary>
        /// Added by Suroj on 26-jun-2021 to view Purchase consignee details
        /// </summary>
        /// <param name="BULKPERMITID"></param>
        /// <param name="Type"></param>
        /// <returns></returns>

        public IActionResult PurchaserConsigneeByPermitId(int? BULKPERMITID, string Type)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;


            List<PurchaserConsigneeByPermitIdViewModel> objPermitIdVM = new List<PurchaserConsigneeByPermitIdViewModel>(); // object of VM 
            if (TempData.ContainsKey("Bulkid"))
            {
                BULKPERMITID = Convert.ToInt16(TempData["Bulkid"]);
            }
            if (BULKPERMITID == null)
            {
                return RedirectToAction("GetOpenEpermitDetails");
            }
            else
            {
                TempData["BulkpermitId"] = BULKPERMITID.Value;

                PurchaserConsigneeModelView PC = new PurchaserConsigneeModelView();
                //PurchaserConsigneeProvider objPurchaser = new PurchaserConsigneeProvider();
                PC.BulkPermitId = BULKPERMITID;
                if (Type == "" || Type == null)
                {
                    PC.Type = "0";
                }
                else
                {
                    PC.Type = Type;
                }
                PC.UserId = userid;
                PC.UserType = userType;
                //ViewBag.Consignee = _objPurchaser.PurchaserConsigneeByPermitId(PC);
                List<PurchaserConsigneeModelView> objPermitByIdlList = _objPurchaser.PurchaserConsigneeByPermitId(PC);

                foreach (PurchaserConsigneeModelView objPermitByIdlData in objPermitByIdlList) //Loop throuch each record
                {
                    PurchaserConsigneeByPermitIdViewModel innerobjPermitByIdVM = new PurchaserConsigneeByPermitIdViewModel(); //created object of VM to set the value

                    innerobjPermitByIdVM.BulkPermitId = objPermitByIdlData.BulkPermitId;
                    innerobjPermitByIdVM.BulkPermitNo = objPermitByIdlData.BulkPermitNo;
                    innerobjPermitByIdVM.CheckPostName = objPermitByIdlData.CheckPostName;
                    innerobjPermitByIdVM.Destination = objPermitByIdlData.Destination;
                    innerobjPermitByIdVM.PurchaserConsigneeName = objPermitByIdlData.PurchaserConsigneeName;
                    innerobjPermitByIdVM.PCId = objPermitByIdlData.PCId;
                    innerobjPermitByIdVM.RCR_RTP_BY = objPermitByIdlData.RCR_RTP_BY;
                    innerobjPermitByIdVM.RouteName = objPermitByIdlData.RouteName;
                    innerobjPermitByIdVM.TransportationMode = objPermitByIdlData.TransportationMode;
                    objPermitIdVM.Add(innerobjPermitByIdVM);
                }
                   
                TempData.Keep("BulkpermitId");
            }
            return View(objPermitIdVM);

        }

        /// <summary>
        /// Add purchaser Consignee
        /// </summary>
        /// <returns></returns>
        public IActionResult AddPurchaserConsignee(int id, int PCID = 0)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;

            ViewBag.userid = userid;
            ViewBag.userType = userType;
            //if (PCID != 0)
            //{
            //    PurchaserConsigneeModel PC = new PurchaserConsigneeModel();
            //    //PurchaserConsigneeProvider objPurchaser = new PurchaserConsigneeProvider();
            //    objPurchaser = new PurchaserConsigneeProvider();
            //    PC.PCId = PCID;
            //    PC.BulkPermitId = id;
            //    PC.UserId = userid;
            //    var editdata = objPurchaser.GetGridData(PC);
            //    return View(editdata);
            //}
            //else
            //{

            EmpDropDown objEmpDropDown = new EmpDropDown();
            PurchaserConsigneePermitModel PC = new PurchaserConsigneePermitModel();
            //PurchaserConsigneeProvider objPurchaser = new PurchaserConsigneeProvider();
            //_objPurchaser = new PurchaserConsigneeProvider(); //commented by shesansu
            ViewBag.PurchaserConsigneeId = Enumerable.Empty<SelectListItem>();
            ViewBag.RouteId = Enumerable.Empty<SelectListItem>();


            #region state
            ViewBag.State = Enumerable.Empty<SelectListItem>();
            objEmpDropDown.Action = "State";
            var State = _objPurchaser.Dropdown(objEmpDropDown);

            ViewBag.State = State.ToList().Select(c => new SelectListItem
            {
                Text = c.Text,
                Value = c.value.ToString(),

            }).ToList();

            #endregion

            #region district
            ViewBag.District = Enumerable.Empty<SelectListItem>();

            objEmpDropDown.Action = "District";
            objEmpDropDown.Stateid = 23;
            var District = _objPurchaser.Dropdown(objEmpDropDown);

            ViewBag.District = District.ToList().Select(c => new SelectListItem
            {
                Text = c.Text,
                Value = c.value.ToString(),

            }).ToList();
            #endregion

            #region transportMode
            ViewBag.TransportationModeId = Enumerable.Empty<SelectListItem>();
            PC.UserId = userid;
            var TransportationModeId = _objPurchaser.GetTransportationModeList(PC);
            ViewBag.TransportationModeId = TransportationModeId.ToList().Select(c => new SelectListItem
            {

                Text = c.TransportationMode,
                Value = c.TransportationModeId.ToString(),

            }).ToList();

            #endregion


            PC.BulkPermitId = id;
            PC.PCId = PCID;

            PC.Check = 8;//5
            PC = _objPurchaser.getGridBulkPermitMasterDataByBulkPermitId(PC);
           
            //comment by dinesh not req 07may22
            ////PC.BulkPermitId = PC.RPTPBulkPermitId;
            PC.BulkPermitId = id;  // temp add dinesh 

            ViewBag.Otheroption = PC.OthersOption;
            PC.PartyCode = "";
            PC.PartyMobile = "";
            PC.PartyName = "";
            PC.Destination = "";
            TempData["BulkpermitId"] = id;

            ViewBag.model = PC;



            var LState = _objPurchaser.GetStateDistrictList();

            ViewBag.LState = LState.ToList().Select(c => new SelectListItem
            {
                Text = c.DistrictName,
                Value = c.DistrictID.ToString(),

            }).ToList();
            return View(PC);
            //}
        }
        [HttpPost]
        public JsonResult District(int Stateid)
        {
            //_objPurchaser = new PurchaserConsigneeProvider();
            EmpDropDown objEmpDropDown = new EmpDropDown();
            objEmpDropDown.Action = "District";
            objEmpDropDown.Stateid = Stateid;
            var District = _objPurchaser.Dropdown(objEmpDropDown);

            return Json(District);
        }

        [HttpPost]
        public JsonResult Route(int DistrictId)
        {
            //_objPurchaser = new PurchaserConsigneeProvider();
            EmpDropDown objEmpDropDown = new EmpDropDown();
            objEmpDropDown.Action = "Route";
            objEmpDropDown.Stateid = DistrictId;
            var Route = _objPurchaser.Dropdown(objEmpDropDown);

            return Json(Route);
        }

        [HttpPost]
        public JsonResult GetEndUserLisenseeDetails(int? LicenseeDistrictId, int? ApplicationType_Id, int? BulkPermitId)
         {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;

            //_objPurchaser = new PurchaserConsigneeProvider();
            PurchaseConsignee objEmpDropDown = new PurchaseConsignee();
            objEmpDropDown.LoginUserId = userid;
            objEmpDropDown.BulkPermitId = BulkPermitId;
            objEmpDropDown.LicenseeDistrictId = LicenseeDistrictId;
            objEmpDropDown.ApplicationType_Id = ApplicationType_Id;
            objEmpDropDown.chk = 5;

            var District = _objPurchaser.GetEndUserLisenseeDetails(objEmpDropDown);

            return Json(District);
        }
        /// <summary>
        /// For Bind the destination
        /// Store Proceddure : exec uspGetBulkPermitMasterDataByBulkPermitId,@Check=2
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TT"></param>
        /// <param name="BL"></param>
        /// <param name="BE"></param>
        /// <param name="BLT"></param>
        /// <returns></returns>
        public JsonResult GetDataByPurchaserConsigneeId(int? Id, string TT, int? BL, int? BE, int? BLT)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;

            //_objPurchaser = new PurchaserConsigneeProvider();
            PurchaserConsigneePermitModel obj = new PurchaserConsigneePermitModel();
            obj.PurchaserConsigneeId = Id;
            obj.BindedLicensee = BL;
            obj.BindedEnduser = BE;
            obj.BindedLicenseeType = BLT;
            obj.EndUserType = 1;
            obj.Check = 2;
            obj.UserId = userid;

            var Destination = _objPurchaser.getDestinationByPurchaseConsigneeId(obj);

            return Json(Destination);
        }

        public JsonResult GetLicenseeTypeList(PurchaserConsigneePermitModel objpurchase, int Bulkpermitid)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;

            //_objPurchaser = new PurchaserConsigneeProvider();
            PurchaserConsigneePermitModel obj = new PurchaserConsigneePermitModel();
            obj.BulkPermitId = Bulkpermitid;
            obj.UserId = userid;

            var Destination = _objPurchaser.GetLicenseeTypeLists(obj);

            return Json(Destination);
        }
        /// <summary>
        /// Get Capitative status of Lessee
        /// </summary>
        /// <returns></returns>
        public string GetCaptiveMineStatusOfLessee()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;

            try
            {
                //_objPurchaser = new PurchaserConsigneeProvider();
                PurchaserConsigneePermitModel obj = new PurchaserConsigneePermitModel();
                obj.UserId = userid;
                string Destination = _objPurchaser.GetCaptiveMineStatusOfLessee(obj);
                return Destination;
            }
            catch (Exception e)
            {
                return null;
            }
            //finally
            //{

            //    _objPurchaser = null;
            //}

        }
        /// <summary>
        /// get licensee details
        /// </summary>
        /// <param name="LicenseeDistrictId"></param>
        /// <param name="ApplicationType_Id"></param>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        public JsonResult GetEndUserLisensee(int? LicenseeDistrictId, int? ApplicationType_Id, int? BulkPermitId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;

            List<PurchaseConsignee> objpurchase1 = new List<PurchaseConsignee>();
            string lessecmpat = GetCaptiveMineStatusOfLessee();
            PurchaserConsigneeProvider objPurchaser = new PurchaserConsigneeProvider();
            PurchaserConsigneePermitModel obj = new PurchaserConsigneePermitModel();
            obj.BulkPermitId = Convert.ToInt16(BulkPermitId);
            obj.Districtid = Convert.ToInt16(LicenseeDistrictId);
            obj.Applicationid = Convert.ToInt16(ApplicationType_Id);
            obj.lesseecompstatus = Convert.ToString(lessecmpat);
            obj.UserId = userid;
            var Destination = _objPurchaser.GetEndUserLisensee(obj);
            //var Destination="";
            return Json(Destination);

        }
        /// <summary>
        /// Despatch by through other users licensee type bind against district
        /// </summary>
        /// <param name="MineralName"></param>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        public JsonResult GetEndUserLisenseeTypeForWasheryDetails(string MineralName, int BulkPermitId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;

            List<PurchaseConsignee> objpurchase1 = new List<PurchaseConsignee>();
            string lessecmpat = GetCaptiveMineStatusOfLessee();
            PurchaserConsigneeProvider objPurchaser = new PurchaserConsigneeProvider();
            PurchaserConsigneePermitModel obj = new PurchaserConsigneePermitModel();
            obj.BulkPermitId = Convert.ToInt16(BulkPermitId);

            obj.MineralName = Convert.ToString(MineralName);
            obj.UserId = userid;
            var Destination = _objPurchaser.GetEndUserLisenseeTypeForWasheryDetails(obj);
            //var Destination="";
            return Json(Destination);

        }

        /// <summary>
        /// Despatch by through other users licensee type bind against district
        /// </summary>
        /// <param name="MineralName"></param>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        public JsonResult GetEndUserLisenseeWasheryDetails(int? LicenseeDistrictId, int? ApplicationType_Id, int? BulkPermitId, int? LicenseeId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;

            List<PurchaseConsignee> objpurchase1 = new List<PurchaseConsignee>();
            string lessecmpat = GetCaptiveMineStatusOfLessee();
            PurchaserConsigneeProvider objPurchaser = new PurchaserConsigneeProvider();
            PurchaserConsigneePermitModel obj = new PurchaserConsigneePermitModel();
            obj.BulkPermitId = Convert.ToInt16(BulkPermitId);
            obj.Applicationid = Convert.ToInt16(ApplicationType_Id);
            obj.LicenseeDistrictId = Convert.ToInt16(LicenseeDistrictId);
            obj.LicenseeId = Convert.ToInt16(LicenseeId);
            obj.UserId = userid;
            obj.lesseecompstatus = lessecmpat;
            var Destination = _objPurchaser.GetEndUserLisenseeWasheryDetails(obj);
            //var Destination="";
            return Json(Destination);

        }
        /// <summary>
        /// Added by suroj for save data in Purchase consignee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(PurchaserConsigneeModel model, List<string> MineralIdList)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                userid = (int)profile.UserId;
                userType = profile.UserType;

                string checkpostid = string.Empty;

                TempData["Bulkid"] = model.BulkPermitId;
                //_objPurchaser = new PurchaserConsigneeProvider();
                model.UserId = userid;
                if (MineralIdList[0] != null)
                {
                    if (MineralIdList.Count > 0)
                    {
                        for (int i = 0; i < MineralIdList.Count; i++)
                        {
                            checkpostid += MineralIdList[i].ToString();
                            checkpostid += ",";
                        }
                    }
                }
                model.CheckPostCount = MineralIdList.Count;
                model.CheckPostName = checkpostid;
                string result = _objPurchaser.AddData(model);
                TempData.Keep("Bulkid");
                
               
                if (result == "1")
                {

                    TempData["AckMsg"] = "Purchaser Consignee inserted successfully";
                    string Type = string.Empty;
                    int? BULKPERMITID = Convert.ToInt16(TempData["Bulkid"]);
                    return RedirectToAction("PurchaserConsigneeByPermitId", "PurchaserConsignee", new
                    {
                        BULKPERMITID = BULKPERMITID,
                        Type
                    });
                }
                return View();
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {

               // _objPurchaser = null;

            }
        }
        /// <summary>
        /// Added by suroj on 30-jun-2021 to delete a record in Purchase consignee
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <param name="bulkid"></param>
        /// <returns></returns>
        public IActionResult Delete(PurchaserConsigneeModel model, int? id, int bulkid)

        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                userid = (int)profile.UserId;
                userType = profile.UserType;

                model.PCId = Convert.ToInt32(id);
                model.UserId = userid;
                model.BulkPermitId = bulkid;
                //_objPurchaser = new PurchaserConsigneeProvider();
                string result = _objPurchaser.DeleteData(model);

                if (result == "1")
                {

                    TempData["AckMsg"] = "Purchaser Consignee deleted successfully";
                    string Type = string.Empty;
                    return RedirectToAction("PurchaserConsigneeByPermitId", "PurchaserConsignee", new
                    {
                        BULKPERMITID = bulkid,
                        Type
                    });
                }
                return View();
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {

               // _objPurchaser = null;

            }

        }

        [HttpPost]
        public JsonResult GetOtherEndUserLisenseeDetails(int? LicenseeDistrictId, int? ApplicationType_Id, int? BulkPermitId, string OtherUserType)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;

            _objPurchaser = new PurchaserConsigneeProvider();
            PurchaseConsignee objEmpDropDown = new PurchaseConsignee();
            objEmpDropDown.LoginUserId = userid;
            objEmpDropDown.BulkPermitId = BulkPermitId;
            objEmpDropDown.LicenseeDistrictId = LicenseeDistrictId;
            objEmpDropDown.ApplicationType_Id = ApplicationType_Id;
            objEmpDropDown.Other_user = OtherUserType;


            var District = _objPurchaser.GetOtherEndUserLisenseeDetails(objEmpDropDown);

            return Json(District);
        }
        /// <summary>
        /// Added by suroj on 01-jul-2021 to bind checklist for other consignee
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Getcheckpost(string SearchTerm)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            userid = (int)profile.UserId;
            userType = profile.UserType;

            _objPurchaser = new PurchaserConsigneeProvider();
            var Checkpost = _objPurchaser.Getcheckpost();
            if (Checkpost != null)
            {
                var modifiedData = Checkpost.Select(x => new
                {
                    id = x.CheckPostId,
                    text = x.CheckPostName
                });
                return Json(modifiedData);

            }
            else
            {
                return Json("");
            }
        }

    }
}

