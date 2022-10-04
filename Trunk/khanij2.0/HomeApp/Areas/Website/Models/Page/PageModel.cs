// ***********************************************************************
//  Class Name               : PageModel
//  Desciption               : Add,Select,Update,Delete Website Page Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 28 Oct 2021
// ***********************************************************************
using HomeApp.Models.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using Newtonsoft.Json;

namespace HomeApp.Areas.Website.Models.Page
{
    public class PageModel : IPageModel
    {
        /// <summary>
        /// Global Declarations
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        public PageModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
        public MessageEF Add(AddPageModel addPageModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Page/Add", JsonConvert.SerializeObject(addPageModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        public MessageEF Update(AddPageModel addPageModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Page/Update", JsonConvert.SerializeObject(addPageModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Edit Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        public AddPageModel Edit(AddPageModel addPageModel)
        {
            try
            {
                addPageModel = JsonConvert.DeserializeObject<AddPageModel>(_objIHttpWebClients.PostRequest("Page/Edit", JsonConvert.SerializeObject(addPageModel)));
                return addPageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To View Page Details
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        public async Task<List<ViewPageModel>> View(ViewPageModel viewPageModel)
        {
            try
            {
                List<ViewPageModel> objlistPage = new List<ViewPageModel>();
                objlistPage = JsonConvert.DeserializeObject<List<ViewPageModel>>(await _objIHttpWebClients.AwaitPostRequest("Page/View", JsonConvert.SerializeObject(viewPageModel)));
                return objlistPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To View Page in Archive 
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        public List<ViewPageModel> ViewArchive(ViewPageModel viewPageModel)
        {
            try
            {
                List<ViewPageModel> objlistPage = new List<ViewPageModel>();
                objlistPage = JsonConvert.DeserializeObject<List<ViewPageModel>>(_objIHttpWebClients.PostRequest("Page/ViewArchive", JsonConvert.SerializeObject(viewPageModel)));
                return objlistPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To Archive Page
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        public MessageEF Archive(ViewPageModel viewPageModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Page/Archive", JsonConvert.SerializeObject(viewPageModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Page Details
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        public MessageEF Delete(ViewPageModel viewPageModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Page/Delete", JsonConvert.SerializeObject(viewPageModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Active Again from Archive
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        public MessageEF Active(ViewPageModel viewPageModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Page/Active", JsonConvert.SerializeObject(viewPageModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Get Plugin Type List
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        public async Task<List<AddPageModel>> PlugnTypeList(AddPageModel addPageModel)
        {
            try
            {
                List<AddPageModel> objPluginTypeLsit = new List<AddPageModel>();
                objPluginTypeLsit = JsonConvert.DeserializeObject<List<AddPageModel>>(await _objIHttpWebClients.AwaitPostRequest("Page/GetPluginTypeList", JsonConvert.SerializeObject(addPageModel)));
                return objPluginTypeLsit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
