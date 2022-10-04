// ***********************************************************************
//  Class Name               : BannerModel
//  Desciption               : Add,View,Edit,Update,Delete Website Banner Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 22 Oct 2021
// ***********************************************************************
using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Banner
{
    public class BannerModel : IBannerModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public BannerModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Website Banner Details
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        public MessageEF Add(AddBannerModel objAddBannerModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Banner/Add", JsonConvert.SerializeObject(objAddBannerModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Website Banner Details 
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        public MessageEF Update(AddBannerModel objAddBannerModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Banner/Update", JsonConvert.SerializeObject(objAddBannerModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Website Banner Details
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public AddBannerModel Edit(AddBannerModel objAddBannerModel)
        {
            try
            {
                objAddBannerModel = JsonConvert.DeserializeObject<AddBannerModel>(_objIHttpWebClients.PostRequest("Banner/Edit", JsonConvert.SerializeObject(objAddBannerModel)));
                return objAddBannerModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public List<ViewBannerModel> View(ViewBannerModel objViewBannerModel)
        {
            try
            {
                List<ViewBannerModel> objlistBanner = new List<ViewBannerModel>();
                objlistBanner = JsonConvert.DeserializeObject<List<ViewBannerModel>>(_objIHttpWebClients.PostRequest("Banner/View", JsonConvert.SerializeObject(objViewBannerModel)));
                return objlistBanner;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Banner Archive Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public List<ViewBannerModel> ViewArchive(ViewBannerModel objViewBannerModel)
        {
            try
            {
                List<ViewBannerModel> objlistBanner = new List<ViewBannerModel>();
                objlistBanner = JsonConvert.DeserializeObject<List<ViewBannerModel>>(_objIHttpWebClients.PostRequest("Banner/ViewArchive", JsonConvert.SerializeObject(objViewBannerModel)));
                return objlistBanner;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public MessageEF Delete(ViewBannerModel objViewBannerModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Banner/Delete", JsonConvert.SerializeObject(objViewBannerModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Archive Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public MessageEF Archive(ViewBannerModel objViewBannerModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Banner/Archive", JsonConvert.SerializeObject(objViewBannerModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Publish Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public MessageEF Publish(ViewBannerModel objViewBannerModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Banner/Publish", JsonConvert.SerializeObject(objViewBannerModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Unpublish Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public MessageEF Unpublish(ViewBannerModel objViewBannerModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Banner/Unpublish", JsonConvert.SerializeObject(objViewBannerModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Active Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public MessageEF Active(ViewBannerModel objViewBannerModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Banner/Active", JsonConvert.SerializeObject(objViewBannerModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Website Banner Status Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public MessageEF UpdateStatus(AddBannerModel objAddBannerModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Banner/UpdateStatus", JsonConvert.SerializeObject(objAddBannerModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Website Banner Type List Details 
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        public AddBannerModel GetSequence(AddBannerModel objAddBannerModel)
        {
            try
            {
                AddBannerModel objsequence = new AddBannerModel();
                objsequence = JsonConvert.DeserializeObject<AddBannerModel>(_objIHttpWebClients.PostRequest("Banner/GetSequence", JsonConvert.SerializeObject(objAddBannerModel)));
                return objsequence;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public List<ViewBannerModel> ViewWebsiteBanner(ViewBannerModel objViewBannerModel)
        {
            try
            {
                List<ViewBannerModel> objlistBanner = new List<ViewBannerModel>();
                objlistBanner = JsonConvert.DeserializeObject<List<ViewBannerModel>>(_objIHttpWebClients.PostRequest("Banner/ViewWebsiteBanner", JsonConvert.SerializeObject(objViewBannerModel)));
                return objlistBanner;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Test(ViewBannerModel objViewBannerModel)
        {
            try
            {
                return _objIHttpWebClients.PostRequest("Values/GetValues", JsonConvert.SerializeObject(objViewBannerModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
