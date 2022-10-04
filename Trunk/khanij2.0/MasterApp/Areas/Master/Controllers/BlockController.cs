// ***********************************************************************
//  Controller Name          : BlockController
//  Description              : Add,View,Edit,Update,Delete Block Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Block;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class BlockController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        IBlockModel _objIBlockModel;
        MessageEF objobjmodel = new MessageEF();
        BlockMaster objmodel = new BlockMaster();
        List<BlockMaster> objlistmodel = new List<BlockMaster>();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objCheckPostmasterModel"></param>
        public BlockController(IBlockModel objIBlockModel)
        {
            _objIBlockModel = objIBlockModel;
        }
        /// <summary>
        /// Get method of Add
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            try
            {
                if (!string.IsNullOrEmpty(id) &&  id != "0")
                {
                    objmodel.BlockId = Convert.ToInt32(id);
                    objmodel = _objIBlockModel.Edit(objmodel);
                    ViewBag.State = GetState(objmodel.BlockId);
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    objmodel.IsActive = true;
                    ViewBag.State = GetState(null);
                    ViewBag.Button = "Submit";
                    return View(objmodel);
                }
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
        /// Post method of Add
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(BlockMaster objmodel, string submit)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = profile.UserId;
                objmodel.UserLoginID = profile.UserLoginId;
                if (string.IsNullOrEmpty(objmodel.StateId.ToString()))
                {
                    ModelState.AddModelError("StateId", "Please Select State");
                }
                if (string.IsNullOrEmpty(objmodel.DistrictId.ToString()))
                {
                    ModelState.AddModelError("DistrictID", "Please Select District");
                }
                if (string.IsNullOrEmpty(objmodel.BlockName))
                {
                    ModelState.AddModelError("BlockName", "Block Name is required");
                }
                if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        objobjmodel = _objIBlockModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = _objIBlockModel.Update(objmodel);
                    }
                    TempData["Message"] = objobjmodel.Satus;
                    if (submit == "Submit")
                    {
                        objmodel.IsActive = true;
                        return RedirectToAction("Add", "Block", new { Area = "master" });
                    }
                    else
                    {
                        return RedirectToAction("Viewlist", "Block", new { Area = "master" });
                    }
                }
                else
                {
                    if (objmodel.BlockId != 0 || objmodel.BlockId != null)
                    {
                        objmodel = _objIBlockModel.Edit(objmodel);
                        ViewBag.State = GetState(objmodel.BlockId);
                        ViewBag.Button = "Update";
                        return View(objmodel);
                    }
                    else
                    {
                        objmodel.IsActive = true;
                        ViewBag.State = GetState(null);
                        ViewBag.Button = "Submit";
                        return View(objmodel);
                    }
                }
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
        /// Bind Block details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult ViewList(BlockMaster objmodel)
        {
            try
            {
                objlistmodel = _objIBlockModel.View(objmodel);
                return View(objlistmodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objlistmodel = null;
                objmodel = null;
            }
        }
        /// <summary>
        /// To delete Block details in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = (int)profile.UserId;
                objmodel.UserLoginID = profile.UserLoginId;
                objmodel.BlockId = Convert.ToInt32(id);
                objobjmodel = _objIBlockModel.Delete(objmodel);
                TempData["Message"] = objobjmodel.Satus;
                return RedirectToAction("ViewList");
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
        /// Bind State List details in view
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        private SelectList GetState(int? StateId)
        {
            try
            {
                objlistmodel = _objIBlockModel.GetStateList(objmodel);
                return new SelectList(objlistmodel, "StateId", "StateName", StateId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objlistmodel = null;
            }
        }
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDistrictByStateId(int? StateId)
        {
            try
            {
                objmodel.StateId = StateId;
                objlistmodel = _objIBlockModel.GetDistrictList(objmodel);
                return Json(objlistmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                objlistmodel = null;
            }
        }
    }
}
