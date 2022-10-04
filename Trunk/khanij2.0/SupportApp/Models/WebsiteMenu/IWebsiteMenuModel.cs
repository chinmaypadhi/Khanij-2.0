using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportEF;

namespace SupportApp.Models.WebsiteMenu
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
        /// <summary>
        /// Bind Top menu list details in view
        /// </summary>
        /// <returns></returns>
        string GetTopmenulist();
        /// <summary>
        /// Bind Main menu list details in view
        /// </summary>
        /// <returns></returns>
        string GetMainmenulist();
        /// <summary>
        /// Bid Footer menu list details in view
        /// </summary>
        /// <returns></returns>
        string GetFootermenulist();
        /// <summary>
        /// Bind menu list details in view
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="url"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        string Getmenulist(string menu, string url, string type);
        /// <summary>
        /// To add Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        MessageEF Add(AddFeedbackModel addFeedbackModel);
    }
}
