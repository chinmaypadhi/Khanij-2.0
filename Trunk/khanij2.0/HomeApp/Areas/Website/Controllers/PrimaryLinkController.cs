using HomeEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApp.Areas.Website.Models.PrimaryLink;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class PrimaryLinkController : Controller
    {
        /// <summary>
        /// Global Decalration
        /// </summary>
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        IPrimaryLinkModel _objIprimaryLinkModel;
        MessageEF objobjmodel = new MessageEF();
        AddPrimaryLinkModel objAddmodel = new AddPrimaryLinkModel();
        List<AddPrimaryLinkModel> objlistmodel = new List<AddPrimaryLinkModel>();
        /// <summary>
        /// Constructor depedency injection
        /// </summary>
        /// <param name="primaryLinkModel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        public PrimaryLinkController(IPrimaryLinkModel primaryLinkModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _objIprimaryLinkModel = primaryLinkModel;
        }
        /// <summary>
        /// To add Primary Links
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            try
            {
                ViewData["Pagetable"] = Getpagelist();
                ViewData["Aboutus"] = GetAboutUsList();
                ViewData["Registrations"] = GetRegistrationsList();
                ViewData["StatisticalReport"] = GetStatisticalReport();
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
        /// To Bind Pages List 
        /// </summary>
        /// <returns></returns>
        public string Getpagelist()
        {
            try
            {
                string s = "";
                objlistmodel = _objIprimaryLinkModel.GetPageList(objAddmodel);
                foreach (AddPrimaryLinkModel item in objlistmodel)
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
        /// To Bind about us list 
        /// </summary>
        /// <returns></returns>
        public string GetAboutUsList()
        {
            try
            {
                string arr = ""; string Id = "";
                objAddmodel = _objIprimaryLinkModel.AboutUs(objAddmodel);
                arr = objAddmodel.VCH_ABOUTUS_ID;
                Id = objAddmodel.INT_ABOUTUS_ID;
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
        /// To bind Registation and Application List
        /// </summary>
        /// <returns></returns>
        public string GetRegistrationsList()
        {
            try
            {
                string arr = ""; string Id = "";
                objAddmodel = _objIprimaryLinkModel.Registrations(objAddmodel);
                arr = objAddmodel.VCH_REGISTRATION_ID;
                Id = objAddmodel.INT_REGISTRATION_ID;
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
        /// To Bind Statistical Reports
        /// </summary>
        /// <returns></returns>
        public string GetStatisticalReport()
        {
            try
            {
                string arr = ""; string Id = "";
                objAddmodel = _objIprimaryLinkModel.StatisticalReports(objAddmodel);
                arr = objAddmodel.VCH_STATISTICAL_REPORT_ID;
                Id = objAddmodel.INT_STATISTICAL_REPORT_ID;
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
        /// To Bind Global Links in dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetGlobalLinkList()
        {
            try
            {
                objlistmodel = await _objIprimaryLinkModel.GetGlobalLinkList(objAddmodel);
                return Json(objlistmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlistmodel = null;
                objAddmodel = null;
            }
        }
        /// <summary>
        /// TO add selected page under Global Links    
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string Getmenulist(string arr, string Id)
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
        /// <summary>
        /// TO add selected page under Global Links    
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
        /// To Bind Primary Links in view
        /// </summary>
        /// <param name="Topmenu"></param>
        /// <param name="Mainmenu"></param>
        /// <param name="Footermenu"></param>
        /// <returns></returns>
        public JsonResult Publish(string Topmenu, string Mainmenu, string Footermenu)
        {
            //UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objAddmodel.INT_CREATED_BY = 1;
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
            objAddmodel.VCH_ABOUTUS_ID = Topmenu;
            objAddmodel.VCH_REGISTRATION_ID = Mainmenu;
            objAddmodel.VCH_STATISTICAL_REPORT_ID = Footermenu;
            try
            {
                objobjmodel = _objIprimaryLinkModel.Add(objAddmodel);
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
    }
}
