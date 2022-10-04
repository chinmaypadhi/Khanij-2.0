// ***********************************************************************
//  Controller Name          : GlobalLinkController
//  Desciption               : Add,Publish Website Global LInk Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 Nov 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApp.Areas.Website.Models.GlobalLink;
using HomeApp.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class GlobalLinkController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        IGlobalLinkModel _objIGlobalLinkModel;
        MessageEF objobjmodel = new MessageEF();
        AddGlobalLinkModel objAddmodel = new AddGlobalLinkModel();
        List<AddGlobalLinkModel> objlistmodel = new List<AddGlobalLinkModel>();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIGlobalLinkModel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        public GlobalLinkController(IGlobalLinkModel objIGlobalLinkModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objIGlobalLinkModel = objIGlobalLinkModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP Get Method of Add Global Link Details in view
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            try
            {
                ViewData["Pagetable"]= Getpagelist();
                ViewData["Topmenutable"] = Gettopmenulist();
                ViewData["Mainmenutable"] = Getmainmenulist();
                ViewData["Footermenutable"] = Getfootermenulist();
                ViewBag.Button = "Submit";
                return View(objAddmodel);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objAddmodel = null;
            }
        }
        /// <summary>
        /// To publish menu list in view
        /// </summary>
        /// <param name="Topmenu"></param>
        /// <param name="Mainmenu"></param>
        /// <param name="Footermenu"></param>
        /// <returns></returns>
        public JsonResult Publish(string Topmenu, string Mainmenu, string Footermenu)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objAddmodel.INT_CREATED_BY = profile.UserId;
            string[] multiArray = Topmenu.Split(new Char[] { '.', '-', '\n', '\t', '[', ']', '"' });
            string abc = Topmenu.Remove(0, 1);
            Topmenu = abc.Remove(abc.Length - 1, 1);
            Topmenu = Topmenu.Replace('"', ' ').Trim();
            string[] multiArray1 = Mainmenu.Split(new Char[] { '.', '-', '\n', '\t', '[', ']', '"' });
            string def = Mainmenu.Remove(0, 1);
            Mainmenu = def.Remove(def.Length - 1, 1);
            Mainmenu = Mainmenu.Replace('"', ' ').Trim();
            string[] multiArray2 = Footermenu.Split(new Char[] { '.', '-', '\n', '\t', '[', ']', '"' });
            string ghi = Footermenu.Remove(0, 1);
            Footermenu = ghi.Remove(ghi.Length - 1, 1);
            Footermenu = Footermenu.Replace('"', ' ').Trim();
            objAddmodel.VCH_TOPMENU_ID = Topmenu;
            objAddmodel.VCH_MAINMENU_ID = Mainmenu;
            objAddmodel.VCH_FOOTERMENU_ID = Footermenu;
            try
            {
                objobjmodel = _objIGlobalLinkModel.Add(objAddmodel);
                return Json(objobjmodel.Satus);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objobjmodel = null;
                objAddmodel = null;
            }
        }
        /// <summary>
        /// Bind Page list details in view
        /// </summary>
        /// <returns></returns>
        public string Getpagelist()
        {
            try
            {
                string s = "";
                objlistmodel = _objIGlobalLinkModel.GetPageList(objAddmodel);
                foreach (AddGlobalLinkModel item in objlistmodel)
                {
                    s += "<div class='form-check'>";
                    s += "<input class='form-check-input' type='checkbox' id='" + item.INT_PAGE_ID + "' value='" + item.INT_PAGE_ID + "'>";
                    s += "<label class='form-check-label' for='" + item.INT_PAGE_ID + "'>";
                    s += item.VCH_PAGE_NAME;
                    s += "</label>";
                    s += "</input>";
                    s += "</div>";
                }
                return s;
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
        /// Bind Top menu list details in view
        /// </summary>
        /// <returns></returns>
        public string Gettopmenulist()
        {
            try
            {
                string arr = ""; string Id = "";
                objAddmodel = _objIGlobalLinkModel.TopMenu(objAddmodel);
                arr = objAddmodel.VCH_TOPMENU_ID;
                Id = objAddmodel.INT_TOPMENU_ID;
                return Getmenulist(arr, Id);
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
        /// Bind Main menu list details in view
        /// </summary>
        /// <returns></returns>
        public string Getmainmenulist()
        {
            try
            {
                string arr = ""; string Id = "";
                objAddmodel = _objIGlobalLinkModel.MainMenu(objAddmodel);
                arr = objAddmodel.VCH_MAINMENU_ID;
                Id = objAddmodel.INT_MAINMENU_ID;              
                return Getmenulist(arr, Id);
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
        /// Bind Footer menu list details in view
        /// </summary>
        /// <returns></returns>
        public string Getfootermenulist()
        {
            try
            {
                string arr = ""; string Id = "";
                objAddmodel = _objIGlobalLinkModel.FooterMenu(objAddmodel);
                arr = objAddmodel.VCH_FOOTERMENU_ID;
                Id = objAddmodel.INT_FOOTERMENU_ID;
                return Getmenulist(arr, Id);
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
        /// To add menu list details in veiw
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult Addmenulist(string Page, string Id)
        {
            try
            {
                string s = ""; string arr = Page; string id = Id;
                if (!string.IsNullOrEmpty(arr.ToString()))
                {
                    string[] ValuemultiArray = arr.Split(new Char[] { ',', '.', '-', '\n', '\t', '[', ']', '"' });
                    string[] IdmultiArray = id.Split(new Char[] { ',', '.', '-', '\n', '\t', '[', ']', '"' });
                    int colLA = 0;
                    for (int i = 0; i < ValuemultiArray.Count(); i++)
                    {
                        if (ValuemultiArray[i].Trim() != "")
                        {
                            for (int j = 0; j < IdmultiArray.Count(); j++)
                            {
                                int k = 1;
                                j = colLA;
                                if (IdmultiArray[j].Trim() != "")
                                {
                                    s += "<li class='draggable' draggable='true' value='" + IdmultiArray[j] + "'>";
                                    s += "<div>";
                                    s += "<span>" + ValuemultiArray[i] + "</span>";
                                    s += "<span class='icon-times-solid spanMenu'></Span>";
                                    s += "</div>";
                                    s += "</li>";

                                }
                                if (k == 1)
                                    break;
                            }
                        }
                        colLA++;
                    }
                }
                return Json(s);
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
        /// To bind menu list details in view
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string Getmenulist(string arr,string Id)
        {
            string s = "";
            if (arr != null)
            {
                string[] ValuemultiArray = arr.Split(new Char[] { ',' });
                string[] IdmultiArray = Id.Split(new Char[] { ',', '.', '-', '\n', '\t', '[', ']', '"' });
                int colLA = 0;
                for (int i = 0; i < ValuemultiArray.Count(); i++)
                {
                    if (ValuemultiArray[i].Trim() != "")
                    {
                        for (int j = 0; j < IdmultiArray.Count(); j++)
                        {
                            int k = 1;
                            j = colLA;
                            if (IdmultiArray[j].Trim() != "")
                            {
                                s += "<li class='draggable' draggable='true' value='" + IdmultiArray[j] + "'>";
                                s += "<div>";
                                s += "<span>" + ValuemultiArray[i] + "</span>";
                                s += "<span class='icon-times-solid spanMenu'></Span>";
                                s += "</div>";
                                s += "</li>";
                            }
                            if (k == 1)
                                break;
                        }
                    }
                    colLA++;
                }
            }
            return s;
        }
    }
}
