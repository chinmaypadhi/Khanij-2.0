// ***********************************************************************
//  Class Name               : GlobalLinkModel
//  Desciption               : Add,Publish Website Global Link Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 Nov 2021
// ***********************************************************************
using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.GlobalLink
{
    public class GlobalLinkModel:IGlobalLinkModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public GlobalLinkModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Website Global Link Details
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public MessageEF Add(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("GlobalLink/Add", JsonConvert.SerializeObject(objAddGlobalLinkModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Website Top Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public AddGlobalLinkModel TopMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            try
            {
                AddGlobalLinkModel objGloballink = new AddGlobalLinkModel();
                objGloballink = JsonConvert.DeserializeObject<AddGlobalLinkModel>(_objIHttpWebClients.PostRequest("GlobalLink/TopMenu", JsonConvert.SerializeObject(objAddGlobalLinkModel)));
                return objGloballink;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Website Main Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public AddGlobalLinkModel MainMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            try
            {
                AddGlobalLinkModel objGloballink = new AddGlobalLinkModel();
                objGloballink = JsonConvert.DeserializeObject<AddGlobalLinkModel>(_objIHttpWebClients.PostRequest("GlobalLink/MainMenu", JsonConvert.SerializeObject(objAddGlobalLinkModel)));
                return objGloballink;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Website Footer Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public AddGlobalLinkModel FooterMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            try
            {
                AddGlobalLinkModel objGloballink = new AddGlobalLinkModel();
                objGloballink = JsonConvert.DeserializeObject<AddGlobalLinkModel>(_objIHttpWebClients.PostRequest("GlobalLink/FooterMenu", JsonConvert.SerializeObject(objAddGlobalLinkModel)));
                return objGloballink;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Global Link Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public List<AddGlobalLinkModel> GetPageList(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            try
            {
                List<AddGlobalLinkModel> objlistPage= new List<AddGlobalLinkModel>();
                objlistPage = JsonConvert.DeserializeObject<List<AddGlobalLinkModel>>(_objIHttpWebClients.PostRequest("GlobalLink/GetPageList", JsonConvert.SerializeObject(objAddGlobalLinkModel)));
                return objlistPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
    }
}
