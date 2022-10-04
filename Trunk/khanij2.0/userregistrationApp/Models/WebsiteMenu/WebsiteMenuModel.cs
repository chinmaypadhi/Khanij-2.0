using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationApp.Models.WebsiteMenu;
using userregistrationEF;

namespace userregistrationApp.Models.WebsiteMenu
{
    public class WebsiteMenuModel: IWebsiteMenuModel
    {
        AddGlobalLinkModel objAddGloballinkModel = new AddGlobalLinkModel();
        AddPageModel objAddPageModel = new AddPageModel();
        List<AddPageModel> objAddPageModellist = new List<AddPageModel>();
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        private readonly IStringLocalizer<CommonResources> _sharedLocalizer;
        public WebsiteMenuModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients, IStringLocalizer<CommonResources> stringLocalizer)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
            _sharedLocalizer = stringLocalizer;
        }

        /// <summary>
        /// Bind Website Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public AddGlobalLinkModel WebsiteMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            try
            {
                AddGlobalLinkModel objGloballink = new AddGlobalLinkModel();
                objGloballink = JsonConvert.DeserializeObject<AddGlobalLinkModel>(_objIHttpWebClients.PostRequest("GlobalLink/WebsiteMenu", JsonConvert.SerializeObject(objAddGlobalLinkModel)));
                return objGloballink;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Bind Website Child Menu Details 
        /// </summary>
        /// <param name="objAddPageModel"></param>
        /// <returns></returns>
        public List<AddPageModel> WebsiteChildMenu(AddPageModel objAddPageModel)
        {
            try
            {
                List<AddPageModel> objAddPageModellist = new List<AddPageModel>();
                objAddPageModellist = JsonConvert.DeserializeObject<List<AddPageModel>>(_objIHttpWebClients.PostRequest("GlobalLink/WebsiteChildMenu", JsonConvert.SerializeObject(objAddPageModel)));
                return objAddPageModellist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region GlobalLink
        /// <summary>
        /// Get Top menu list
        /// </summary>
        /// <returns></returns>
        public string GetTopmenulist()
        {
            string Topmenu = "";
            objAddGloballinkModel =WebsiteMenu(objAddGloballinkModel);
            Topmenu = Getmenulist(objAddGloballinkModel.VCH_TOPMENU_ID, objAddGloballinkModel.VCH_TOPMENU_URL, null);
            return Topmenu;
        }

        /// <summary>
        /// Get Main menu list
        /// </summary>
        /// <returns></returns>
        public string GetMainmenulist()
        {
            string Mainmenu = "";
            objAddGloballinkModel =WebsiteMenu(objAddGloballinkModel);
            Mainmenu = Getmenulist(objAddGloballinkModel.VCH_MAINMENU_ID, objAddGloballinkModel.VCH_MAINMENU_URL, "Main");
            return Mainmenu;
        }

        /// <summary>
        /// Get Footer menu list
        /// </summary>
        /// <returns></returns>
        public string GetFootermenulist()
        {
            string Footermenu = "";
            objAddGloballinkModel =WebsiteMenu(objAddGloballinkModel);
            Footermenu = Getmenulist(objAddGloballinkModel.VCH_FOOTERMENU_ID, objAddGloballinkModel.VCH_FOOTERMENU_URL, null);
            return Footermenu;
        }

        /// <summary>
        /// Bind Menu list details in Website view
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="url"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string Getmenulist(string menu, string url, string type)
        {
            string s = "";
            if (menu != null)
            {
                string[] ValuemultiArray = menu.Split(new Char[] { ',' });
                string[] UrlmultiArray = url.Split(new Char[] { ',', '-', '\n', '\t', '[', ']', '"' });
                int colLA = 0;
                for (int i = 0; i < ValuemultiArray.Count(); i++)
                {
                    if (ValuemultiArray[i].Trim() != "")
                    {
                        for (int j = 0; j < UrlmultiArray.Count(); j++)
                        {
                            int k = 1;
                            j = colLA;
                            if (UrlmultiArray[j].Trim() != "")
                            {
                                if (type == "Main")
                                {
                                    if (ValuemultiArray[i].Contains("About Us"))
                                    {
                                        objAddPageModel.VCH_ACTION = "ABOUTUS";
                                        objAddPageModellist = WebsiteChildMenu(objAddPageModel);
                                        if (objAddPageModellist.Count > 0)
                                        {
                                            s += "<li class='nav-item dropdown about'>";
                                            s += "<a class='nav-link dropdown-toggle' href='#' id='A1' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>" + _sharedLocalizer[ValuemultiArray[i]] + "</a>";
                                            s += "<div class='dropdown-menu' aria-labelledby='navbarDropdown'>";
                                            for (var childmenu = 0; childmenu < objAddPageModellist.Count; childmenu++)
                                            {
                                                if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 1 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 1)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 0 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 0)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "' target='_blank'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 1 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 0)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "' target='_blank'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 0 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 1)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else
                                                {
                                                    s += "<a class='dropdown-item introduction' href='/" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                            }
                                            s += "</div>";
                                            s += "</li>";
                                        }
                                    }
                                    else if (ValuemultiArray[i].Contains("Registration"))
                                    {
                                        objAddPageModel.VCH_ACTION = "REGISTRATION";
                                        objAddPageModellist = WebsiteChildMenu(objAddPageModel);
                                        if (objAddPageModellist.Count > 0)
                                        {
                                            s += "<li class='nav-item dropdown reg-app'>";
                                            s += "<a class='nav-link dropdown-toggle' href='#' id='A2' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>" + ValuemultiArray[i] + "</a>";
                                            s += "<div class='dropdown-menu' aria-labelledby='navbarDropdown'>";
                                            for (var childmenu = 0; childmenu < objAddPageModellist.Count; childmenu++)
                                            {
                                                if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 1 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 1)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 0 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 0)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "' target='_blank'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 1 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 0)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "' target='_blank'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else if (Convert.ToInt32(objAddPageModellist[childmenu].BIT_LINK_TYPE) == 0 && Convert.ToInt32(objAddPageModellist[childmenu].BIT_WINDOW_STATUS) == 1)
                                                {
                                                    s += "<a class='dropdown-item introduction' href='" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                                else
                                                {
                                                    s += "<a class='dropdown-item introduction' href='/" + objAddPageModellist[childmenu].VCH_URL + "'>" + _sharedLocalizer[objAddPageModellist[childmenu].VCH_PAGE_NAME] + "</a>";
                                                }
                                            }
                                            s += "</div>";
                                            s += "</li>";
                                        }
                                    }
                                    else
                                    {
                                        s += "<li class='nav-item'>";
                                        s += "<a class='nav-link' href='" + UrlmultiArray[j] + "'>" + _sharedLocalizer[ValuemultiArray[i]] + "</a>";
                                        s += "</li>";
                                    }
                                }
                                else
                                {
                                    s += "<li>";
                                    s += "<a href='" + UrlmultiArray[j] + "'>" + _sharedLocalizer[ValuemultiArray[i]] + "</a>";
                                    s += "</li>";
                                }
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
        #endregion
    }
}
