using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Models.WebsiteMenu
{
    public interface IWebsiteMenuModel
    {
        /// <summary>
        /// Bind Website Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        AddGlobalLinkModel WebsiteMenu(AddGlobalLinkModel objAddGlobalLinkModel);

        /// <summary>
        /// Bind Website Child Menu Details 
        /// </summary>
        /// <param name="objAddPageModel"></param>
        /// <returns></returns>
        List<AddPageModel> WebsiteChildMenu(AddPageModel objAddPageModel);
        string GetTopmenulist();
        string GetMainmenulist();
        string GetFootermenulist();
        string Getmenulist(string menu, string url, string type);
    }
}
