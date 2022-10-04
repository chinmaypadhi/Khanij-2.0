// ***********************************************************************
//  Controller Name          : WeighBridge Independent
//  Desciption               : Add,View,Forward Independent Weighbridge///
//  Created By               : Ranjan Kumar Behera
//  Created On               : 16 March 2022
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Areas.WeightBridge.Models;
using userregistrationApp.Web;
using userregistrationEF;
using userregistrationApp.ActionFilter;

namespace userregistrationApp.Areas.WeightBridge.Controllers
{
    [Area("WeightBridge")]
    public class WeighBridgeTagController : Controller
    {
        readonly IWeighBridgeTag objIWeighBridgeTag;
        ViewWeighBridgeTagModel objViewWeighBridgeTag=new ViewWeighBridgeTagModel();
        List<ViewWeighBridgeTagModel> objvieweighbridgetaglist = new List<ViewWeighBridgeTagModel>();
        AddWeighBridgeTagModel objAddWeighBridgeTag = new AddWeighBridgeTagModel();
        MessageEF objmsg = new MessageEF();
        public WeighBridgeTagController(IWeighBridgeTag objIWeighBridgeTag)
        {
            this.objIWeighBridgeTag = objIWeighBridgeTag;
        }
        /// <summary>
        /// For loading usertype dropdown
        /// </summary>
        /// <returns></returns>
        public List<ViewWeighBridgeTagModel> ViewUserType()
        {
            List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
            //objlist = objIWeighBridge.ViewUserType(objViewWeighBridgeTag);
            objlist.Add(new ViewWeighBridgeTagModel() { UserTypeID = 7, UserType = "Lessee" });
            objlist.Add(new ViewWeighBridgeTagModel() { UserTypeID = 10, UserType = "Licensee" });
            objlist.Add(new ViewWeighBridgeTagModel() { UserTypeID = 8, UserType = "End User" });
            objlist.Add(new ViewWeighBridgeTagModel() { UserTypeID = 1030, UserType = "Independent WeighBridge Owner" });
            return objlist;
        }
        /// <summary>
        /// For loading district dropdown
        /// </summary>
        /// <returns></returns>
        public JsonResult ViewDistrictByUserType(int UserTypeID)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
            objViewWeighBridgeTag.UserTypeID = UserTypeID;
            objViewWeighBridgeTag.UserID = profile.UserId;
            objlist = objIWeighBridgeTag.ViewDistrict(objViewWeighBridgeTag);
            return Json(objlist);
        }
        /// <summary>
        /// For loading ALL USERS TO DROPDOWN BY DISTRICT DROPDOWN
        /// </summary>
        /// <param name="DistrictID"></param>
        /// <returns></returns>
        public JsonResult ViewUserByDistrict(int? DistrictID, int UserTypeID)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
            objViewWeighBridgeTag.DistrictID = DistrictID;
            objViewWeighBridgeTag.UserTypeID = UserTypeID;
            objViewWeighBridgeTag.UserID = profile.UserId;
            objlist = objIWeighBridgeTag.ViewUserByDistrict(objViewWeighBridgeTag);
            return Json(objlist);
        }
        /// <summary>
        /// for loading all weighbridge in dropdown by selecting user dropdown
        /// </summary>
        /// <param name="TagUserID"></param>
        /// <returns></returns>
        public JsonResult ViewWeighBridgeByUser(int? TagUserID)
        {
            List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
            objViewWeighBridgeTag.TagUserID = TagUserID;
            objlist = objIWeighBridgeTag.ViewWeighBridgeByUser(objViewWeighBridgeTag);
            return Json(objlist);
        }
        /// <summary>
        /// created json for loading details on take action click
        /// </summary>
        /// <param name="TagUserID"></param>
        /// <returns></returns>
        public JsonResult WeighBridgeByUser(int? TagUserID)
        {
            List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
            objViewWeighBridgeTag.UserID = TagUserID;
            objlist = objIWeighBridgeTag.ViewWeighBridgeTag(objViewWeighBridgeTag);
            objViewWeighBridgeTag = objlist.FirstOrDefault();
            return Json(objViewWeighBridgeTag);
        }
        /// <summary>
        /// For loading weighbridge tag history by ID
        /// </summary>
        /// <param name="weighbridgeTagID"></param>
        /// <returns></returns>
        public JsonResult GetHistoryByWBTagID(string weighbridgeTagID)
        {
            ViewWeighBridgeTagModel obj = new ViewWeighBridgeTagModel();
            obj.WeighBridgeTagID = Convert.ToInt32(weighbridgeTagID);
            List<ViewWeighBridgeTagModel> list = new List<ViewWeighBridgeTagModel>();
            list = objIWeighBridgeTag.ViewWeighBridgeTagHistory(obj);
            return Json(list);
        }
        /// <summary>
        /// Add weighbridge tag
        /// </summary>
        /// <returns></returns>
        public IActionResult WBTag()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.UserType = profile.UserType;
            ViewBag.ApplicantName = profile.ApplicantName;
            ViewBag.DistrictName = profile.DistrictName;
            ViewBag.submit = "SAVE";
            ViewBag.cancel = "RESET";
            TempData["UserType"] = ViewUserType();
            return View(objAddWeighBridgeTag);
        }
        /// <summary>
        /// Post of weighbridge tag add
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult WBTagSave(AddWeighBridgeTagModel obj, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.UserID = profile.UserId;
            if(ModelState.IsValid)
            {
                if (submit == "SAVE")
                {
                    objmsg = objIWeighBridgeTag.WBTagCheck(obj);
                    if(objmsg.Satus=="1")
                    {
                        TempData["Status"] = "0";
                        TempData["Message"] = "This weighbridge is already tagged..";
                        ViewBag.ApplicantName = profile.ApplicantName;
                        ViewBag.DistrictName = profile.DistrictName;
                        ViewBag.submit = "SAVE";
                        ViewBag.cancel = "RESET";
                        TempData["UserType"] = ViewUserType();
                        //for clearing usertype dropdown
                        obj.UserTypeID = null;
                        return View("WBTag", obj);
                    }
                    else
                    {
                        objmsg = objIWeighBridgeTag.WBTagSave(obj);
                        if (objmsg.Satus == "1")
                        {
                            TempData["Status"] = "1";
                            TempData["Message"] = "Weighbridge tag saved";
                        }
                        else if (objmsg.Satus == "2")
                        {
                            TempData["Status"] = "0";
                            TempData["Message"] = "Unable to tag weighbridge. The weighbridge validity expired";
                        }
                        else
                        {
                            TempData["Status"] = "0";
                            TempData["Message"] = "Unable to tag weighbridge. Please try after sometime";
                        }
                    }
                }
                else
                {
                    objmsg = objIWeighBridgeTag.WBTagEdit(obj);
                    if (objmsg.Satus != "0")
                    {
                        TempData["Status"] = "1";
                        TempData["Message"] = "Weighbridge Tag Updated Successfully";
                    }
                    else
                    {
                        TempData["Status"] = "0";
                        TempData["Message"] = "Unable to update weighbridge tag. Please try after sometime";
                    }
                }
                return RedirectToAction("WBTagView");
            }
            else
            {
                TempData["Status"] = "0";
                TempData["Message"] = "Please fill all information marked with red.";
                ViewBag.ApplicantName = profile.ApplicantName;
                ViewBag.DistrictName = profile.DistrictName;
                ViewBag.submit = submit;
                if (submit == "SAVE")
                {
                    ViewBag.cancel = "RESET";
                }
                else
                {
                    ViewBag.cancel = "CANCEL";
                }
                TempData["UserType"] = ViewUserType();
                return View("WBTag", obj);
            }
        }
        /// <summary>
        /// View all weighbridge tag by logged user
        /// </summary>
        /// <returns></returns>
        public IActionResult WBTagView()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objViewWeighBridgeTag.UserID = profile.UserId;
            ViewBag.UserType = profile.UserType;
            ViewData["WBTagList"] = objIWeighBridgeTag.ViewWeighBridgeTag(objViewWeighBridgeTag);
            return View();
        }
        /// <summary>
        /// Post of weighbridge tag forward
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult WBTagForward(int? WeighBridgeTagID)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objViewWeighBridgeTag.UserID = profile.UserId;
            objViewWeighBridgeTag.WeighBridgeTagID = WeighBridgeTagID;
            objmsg = objIWeighBridgeTag.WBTagForward(objViewWeighBridgeTag);
            if(objmsg.Satus!="0")
            {
                TempData["Status"] = "1";
                TempData["Message"] = "WeighBridge Tag Forwarded Successfully";
            }
            else
            {
                TempData["Status"] = "0";
                TempData["Message"] = "Unable to Forward. Please try after sometime";
            }
            return RedirectToAction("WBTagView");
        }
        /// <summary>
        /// VIew screen of weighbridge tag approval to be used by DD/MO
        /// </summary>
        /// <returns></returns>
        public IActionResult WBTagApprove()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objViewWeighBridgeTag.DistrictName = profile.DistrictName;
            ViewBag.DistrictName = profile.DistrictName;
            ViewBag.ApplicantName = profile.ApplicantName;
            if (profile.UserTypeId == 5)
            {
                ViewData["WBTagList"] = objIWeighBridgeTag.ViewWeighBridgeTagApproval(objViewWeighBridgeTag);
            }
            else
            {
                ViewData["WBTagList"] = objvieweighbridgetaglist;
            }
            return View();
        }
        /// <summary>
        /// Post of weighbridge tag approve
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Approve(ViewWeighBridgeTagModel obj)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.ApprovedBy = profile.UserId;
            if (ModelState.IsValid)
            {
                if(obj.ApproveType == "2")  //changed Approve to 2
                {
                    objmsg = objIWeighBridgeTag.WBTagApprove(obj);
                    if (objmsg.Satus == "1")
                    {
                        TempData["Status"] = "1";
                        TempData["Message"] = "WeighBridge Tag Approved Successfully";
                    }
                    else
                    {
                        TempData["Status"] = "0";
                        TempData["Message"] = "Unable to Approve. Please try after sometime";
                    }
                }
                else
                {
                    objmsg = objIWeighBridgeTag.WBTagReject(obj);
                    if (objmsg.Satus == "1")
                    {

                        TempData["Status"] = "1";
                        TempData["Message"] = "WeighBridge Tag Rejected";
                    }
                    else
                    {
                        TempData["Status"] = "0";
                        TempData["Message"] = "Unable to Reject. Please try after sometime";
                    }
                }
            }
            return RedirectToAction("WBTagApprove");
        }
        /// <summary>
        /// Getting and setting details of WbTag for edit mode
        /// </summary>
        /// <param name="WBTagID"></param>
        /// <returns></returns>
        /// 
        [SkipEncryptedTask]
        public IActionResult ViewByTagID(string WBTagID)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.UserType = profile.UserType;
            ViewBag.ApplicantName = profile.ApplicantName;
            ViewBag.DistrictName = profile.DistrictName;
            ViewBag.submit = "UPDATE";
            ViewBag.cancel = "CANCEL";
            TempData["UserType"] = ViewUserType();
            objViewWeighBridgeTag.WeighBridgeTagID = Convert.ToInt32(WBTagID);
            objAddWeighBridgeTag = objIWeighBridgeTag.WBTagByTagID(objViewWeighBridgeTag);
            return View("WBTag", objAddWeighBridgeTag);
        }
        /// <summary>
        /// View screen of all tag request
        /// </summary>
        /// <returns></returns>
        public IActionResult TagRequest()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objViewWeighBridgeTag.UserID = profile.UserId;
            ViewData["WBTagList"] = objIWeighBridgeTag.ViewWeighBridgeTagRequest(objViewWeighBridgeTag);
            return View();
        }
        /// <summary>
        /// approve of all tag request
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult TagApprove(ViewWeighBridgeTagModel obj)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.ApprovedBy = profile.UserId;
            if (ModelState.IsValid)
            {
                objmsg = objIWeighBridgeTag.WBTagRequest(obj);
                if (objmsg.Satus == "1")
                {
                    TempData["Status"] = "1";
                    if(obj.ApproveType== "2")
                    {
                        TempData["Message"] = "WeighBridge Tag Request Approved Successfully";
                    }
                    else if (obj.ApproveType == "3")
                    {
                        TempData["Message"] = "WeighBridge Tag Request Rejected Successfully";
                    }
                }
                else
                {
                    TempData["Status"] = "0";
                    TempData["Message"] = "Unable to Approve. Please try after sometime";
                }
            }
            return RedirectToAction("TagRequest");
        }
        [HttpPost]
        public IActionResult viewActionList(ViewWeighBridgeTagModel obj)
        {
            
            return Json(objIWeighBridgeTag.ViewWeighBridgeActionList(obj));
        }

    }
}
