

using EpassEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Net.ConnectCode.Barcode;
using System.IO;
using EpassApp.Web;
using System.Drawing;
using System.Drawing.Imaging;
using EpassApp.Areas.Epass.Models.ePassConfiguration;
using Newtonsoft.Json;

namespace EpassApp.Areas.Epass.Controllers
{
    [Area("EPass")]
    public class ePassConfigurationController : Controller
    {
        //private Ie _objPurchaser;

        /// <summary>
        /// Added by suroj on 11-jul-2021 Dependency Injection For Etransitpass Controller
        /// </summary>
        //private IeTransitpass _objIticketmodel;
        //private readonly IHostingEnvironment hostingEnvironment;
        //private readonly KhanijSecurity.KhanijIDataProtection protector;

        //int userid = 194;//387;
        //string usertype = "Lessee";// "Licensee";

        //int Tpoffline = 1;
        ePassConfigurationEF objepassEF = new ePassConfigurationEF();
        MessageEF objobjmodel = new MessageEF();
        private IePassConfigurationModel _objIticketmodel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly KhanijSecurity.KhanijIDataProtection protector;
        //public IActionResult ePassConfiguration()
        //{
        //    return View();
        //}
        public ePassConfigurationController(IePassConfigurationModel objePassConfiguration, IHostingEnvironment hostingEnvironment, KhanijSecurity.KhanijIDataProtection khanijIDataProtection)
        {
            protector = khanijIDataProtection;
            _objIticketmodel = objePassConfiguration;
            this.hostingEnvironment = hostingEnvironment;
        }
        #region Get All Data in Page Load and Data for Edit Page
        public ActionResult PassConfiguration(int? id=0)
       
        {
            ePassConfigurationEF _ePassConfigurationModel = new ePassConfigurationEF();
            ePassConfigurationEF model = new ePassConfigurationEF();
            List<ePassConfigurationModel> ListePassConfigurationMode = new List<ePassConfigurationModel>();
            try
            {
                // Getting DIstrict Name
                var x = _objIticketmodel.GetDistrict(_ePassConfigurationModel);
                if (x != null)
                {
                    ViewBag.District = x.Select(c => new SelectListItem
                    {
                        Text = c.DistrictName,
                        Value = c.DistrictID.ToString(),
                    }).ToList();
                   
                }
                else
                {
                    ViewBag.District = Enumerable.Empty<SelectListItem>();
                }

                // Getting User Type
                var y = _objIticketmodel.GetUserType(_ePassConfigurationModel);

                ePassConfigurationEF objParam = new ePassConfigurationEF() { UserType = "ALL", UserTypeID = 9 };
                if (y != null)
                {
                    y.Insert(0,objParam);
                    ViewBag.UserType = y.Select(c => new SelectListItem
                    {
                        Text = c.UserType,
                        Value = c.UserTypeID.ToString(),
                    }).ToList();

                }
                else
                {
                    ViewBag.UserType = Enumerable.Empty<SelectListItem>();
                }
                // Getting Mineral Type
                var z = _objIticketmodel.GetMineralType(_ePassConfigurationModel);

                ePassConfigurationEF objParamVal = new ePassConfigurationEF() { MineralType = "ALL", MineralTypeID = 9 };
                {
                    
                };
                if (z != null)
                {


                    z.Insert(0,objParamVal);
                    ViewBag.MineralType = z.Select(c => new SelectListItem
                    {
                        Text = c.MineralType,
                        Value = c.MineralTypeID.ToString(),
                    }).ToList();

                }
                else
                {
                    ViewBag.MineralType = Enumerable.Empty<SelectListItem>();
                }
                // Getting Transportation Mode
                var b = _objIticketmodel.GetTransportationMode(_ePassConfigurationModel);
                //ePassConfigurationEF objParamValTM = new ePassConfigurationEF() { TransportationMode = "ALL", TransportationModeId = "9" };
                if (b != null)
                {
                    //b.Insert(0,objParamValTM);
                    ViewBag.TransportationMode = b.Select(c => new SelectListItem
                    {
                        Text = c.TransportationMode,
                        Value = c.TransportationModeId.ToString(),
                    }).ToList();

                }
                else
                {
                    ViewBag.TransportationMode = Enumerable.Empty<SelectListItem>();
                }
                // GettingAllow Consignee Data
                var c = _objIticketmodel.GetAllowConsignee(_ePassConfigurationModel);
                if (c != null)
                {
                    ViewBag.GetAllowConsignee = c.Select(c => new SelectListItem
                    {
                        Text = c.AllowConsigneeType,
                        Value = c.AllowConsigneeTypeid.ToString(),
                    }).ToList();

                }
                else
                {
                    ViewBag.GetAllowConsignee = Enumerable.Empty<SelectListItem>();
                }
                // Getting Data for Editable Mode
                if (id > 0)
                {
                    _ePassConfigurationModel.id = id;
                    objepassEF = _objIticketmodel.EditViewConfig(_ePassConfigurationModel);
                    //ePassConfigurationEF objParamValtry = new ePassConfigurationEF();
                    ViewBag.radioStatus = objepassEF.PassConfigTypeID;
                    if (objepassEF.TransportationModeId != null)
                    {
                        List<IdentificationDoc> thisList = new List<IdentificationDoc>();
                        foreach (string sr in objepassEF.TransportationModeId.Split(','))
                        {
                            thisList.Add(new IdentificationDoc { id = Convert.ToInt32(sr) });
                        }
                        objepassEF.DocumentList = thisList;

                        ////drop
                        //List<transactionMode> thisList1 = new List<transactionMode>();
                        //foreach(var person in ViewBag.TransportationMode)
                        // {

                        //    transactionMode ob = new transactionMode() {Value= person.Value,Text=person.Text };

                        //    thisList1.Add(ob);
                        //}
                       

                        //objepassEF.transactionMode = thisList1;
                    }

                    var p = _objIticketmodel.GetUserName(objepassEF);
                    if (p != null)
                    {
                        ViewBag.UserName = p.Select(p => new SelectListItem
                        {
                            Text = p.UserName,
                            Value = p.Userid.ToString(),
                        }).ToList();

                    }
                    else
                    {
                        ViewBag.UserName = Enumerable.Empty<SelectListItem>();
                    }
                    var Q = _objIticketmodel.GetMineralName(objepassEF);

                    if (Q != null)
                    {

                        ViewBag.MineralName = Q.Select(Q => new SelectListItem
                        {
                            Text = Q.MineralName,
                            Value = Q.MineralID.ToString(),
                        }).ToList();

                    }
                    else
                    {
                        ViewBag.MineralName = Enumerable.Empty<SelectListItem>();
                    }
                    ViewBag.Button = "Update";


                  
                }
                else
                {
                    ViewBag.UserName = Enumerable.Empty<SelectListItem>();
                    ViewBag.MineralName = Enumerable.Empty<SelectListItem>();
                    objepassEF.TripCloseID = 1;
                    objepassEF.RouteFetchID = 2;
                    objepassEF.PassConfigTypeID = 1;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
           
            return View(objepassEF);
        }
        #endregion
        #region Get Licensee/Lessee Name through DistrictID and User Type
        public JsonResult GetUserName(int Districtid, int UserTypeID)
        {
            ePassConfigurationEF _ePassConfigurationModel = new ePassConfigurationEF();
            List<ePassConfigurationModel> ListePassConfigurationMode = new List<ePassConfigurationModel>();
            try
            {
                _ePassConfigurationModel.DistrictID = Districtid;
                _ePassConfigurationModel.UserTypeID = UserTypeID;

                var x = _objIticketmodel.GetUserName(_ePassConfigurationModel);
                return Json(x);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _ePassConfigurationModel = null;
                ListePassConfigurationMode = null;
            }
        }
        #endregion
        #region Get Mineral Name
        public JsonResult GetMineralName(int MineralTypeID, int UserTypeID, int Userid)
        {
            ePassConfigurationEF _ePassConfigurationModel = new ePassConfigurationEF();
            List<ePassConfigurationModel> ListePassConfigurationMode = new List<ePassConfigurationModel>();
            try
            {
                _ePassConfigurationModel.MineralTypeID = MineralTypeID;
                _ePassConfigurationModel.UserTypeID = UserTypeID;
                _ePassConfigurationModel.Userid = Userid;

                var x = _objIticketmodel.GetMineralName(_ePassConfigurationModel);
                return Json(x);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _ePassConfigurationModel = null;
                ListePassConfigurationMode = null;
            }
        }
        #endregion

        #region Add/Update Configuration
        [HttpPost]
        //[IgnoreAntiforgeryToken]
        public IActionResult PassConfiguration(ePassConfigurationEF objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy = profile.UserId;
            //objmodel.UserLoginId = profile.UserLoginId;
            if (submit == "Submit")
            {
                objobjmodel = _objIticketmodel.AddPassConfiguration(objmodel);
            }
            else
            {
                objobjmodel = _objIticketmodel.UpdatePassConfiguration(objmodel);

            }
            if (objobjmodel.Satus == "1")
            {
                //objmodel = new ePassConfigurationModel();
                TempData["SuccMessage"] = "Data Saved Sucessfully";
                //ViewBag.msg = "Data Saved Sucessfully";
               return RedirectToAction("PassConfiguration");
            }
           else if (objobjmodel.Satus == "2")
            {
                //TempData["msg"] = "Data updated Sucessfully";
                TempData["SuccMessage"] = "Data updated Sucessfully";
                return RedirectToAction("passconfigurationView", "ePassConfiguration", new { Area = "EPass" });

            }
            else
            {
                ViewBag.msg = "Data not Save Sucessfully";
                return View();

            }

        }
        #endregion

        #region Delete Configuration
       
        //[IgnoreAntiforgeryToken]
        public IActionResult Delete(int? id = 0)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
          
            ePassConfigurationEF objmodel = new ePassConfigurationEF();
            objmodel.CreatedBy = profile.UserId;
            objmodel.id = id;
            objobjmodel = _objIticketmodel.DeletePassConfiguration(objmodel);
          
            if (objobjmodel.Satus == "3")
            {
                //objmodel = new ePassConfigurationModel();
                TempData["SuccMessage"] = "Data Deleted Sucessfully";
                //ViewBag.msg = "Data Saved Sucessfully";
                return RedirectToAction("PassConfigurationView");
            }
            return RedirectToAction("PassConfigurationView");

        }
        #endregion

        #region View
        public IActionResult PassConfigurationView()
        {
            if (TempData["SuccMessage"] != null)
            {
                ViewBag.msg = TempData["SuccMessage"].ToString();
            }
            List<ePassConfigurationEF> mineralModels = _objIticketmodel.View(objepassEF);
            return View(mineralModels);
        }
        #endregion


    }
}
