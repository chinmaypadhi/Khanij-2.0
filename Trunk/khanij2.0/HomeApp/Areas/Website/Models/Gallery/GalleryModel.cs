using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Gallery
{
  
    public class GalleryModel :IGalleryModel
    {
        /// <summary>
        /// Global Decalration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor Decalaration
        /// </summary>
        /// <param name="httpWebClients"></param>
        public GalleryModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
        /// <summary>
        /// Add Website Gallery Details
        /// </summary>
        /// <param name="obAddGalleryModel"></param>
        /// <returns></returns>
        public MessageEF Add(AddGalleryModel obAddGalleryModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Gallery/Add", JsonConvert.SerializeObject(obAddGalleryModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Website Gallery Details 
        /// </summary>
        /// <param name="obAddGalleryModel"></param>
        /// <returns></returns>
        public MessageEF Update(AddGalleryModel obAddGalleryModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Gallery/Update", JsonConvert.SerializeObject(obAddGalleryModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Website Gallery Details
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public AddGalleryModel Edit(AddGalleryModel obAddGalleryModel)
        {
            try
            {
                obAddGalleryModel = JsonConvert.DeserializeObject<AddGalleryModel>(_objIHttpWebClients.PostRequest("Gallery/Edit", JsonConvert.SerializeObject(obAddGalleryModel)));
                return obAddGalleryModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public List<ViewGalleryModel> View(ViewGalleryModel objViewGalleryModel)
        {
            try
            {
                List<ViewGalleryModel> objlistBanner = new List<ViewGalleryModel>();
                objlistBanner = JsonConvert.DeserializeObject<List<ViewGalleryModel>>(_objIHttpWebClients.PostRequest("Gallery/View", JsonConvert.SerializeObject(objViewGalleryModel)));
                return objlistBanner;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Gallery Archive Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public List<ViewGalleryModel> ViewArchive(ViewGalleryModel objViewGalleryModel)
        {
            try
            {
                List<ViewGalleryModel> objlistBanner = new List<ViewGalleryModel>();
                objlistBanner = JsonConvert.DeserializeObject<List<ViewGalleryModel>>(_objIHttpWebClients.PostRequest("Gallery/ViewArchive", JsonConvert.SerializeObject(objViewGalleryModel)));
                return objlistBanner;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public MessageEF Delete(ViewGalleryModel objViewGalleryModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Gallery/Delete", JsonConvert.SerializeObject(objViewGalleryModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Archive Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public MessageEF Archive(ViewGalleryModel objViewGalleryModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Gallery/Archive", JsonConvert.SerializeObject(objViewGalleryModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Publish Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public MessageEF Publish(ViewGalleryModel objViewGalleryModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Gallery/Publish", JsonConvert.SerializeObject(objViewGalleryModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Unpublish Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public MessageEF Unpublish(ViewGalleryModel objViewGalleryModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Gallery/Unpublish", JsonConvert.SerializeObject(objViewGalleryModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Active Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public MessageEF Active(ViewGalleryModel objViewGalleryModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Gallery/Active", JsonConvert.SerializeObject(objViewGalleryModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Website Gallery Status Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public MessageEF UpdateStatus(AddGalleryModel obAddGalleryModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Gallery/UpdateStatus", JsonConvert.SerializeObject(obAddGalleryModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Website Gallery Type List Details 
        /// </summary>
        /// <param name="obAddGalleryModel"></param>
        /// <returns></returns>
        public AddGalleryModel GetSequence(AddGalleryModel obAddGalleryModel)
        {
            try
            {
                AddGalleryModel objsequence = new AddGalleryModel();
                objsequence = JsonConvert.DeserializeObject<AddGalleryModel>(_objIHttpWebClients.PostRequest("Gallery/GetSequence", JsonConvert.SerializeObject(obAddGalleryModel)));
                return objsequence;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public List<ViewGalleryModel> ViewWebsiteGallery(ViewGalleryModel objViewGalleryModel)
        {
            try
            {
                List<ViewGalleryModel> objlistBanner = new List<ViewGalleryModel>();
                objlistBanner = JsonConvert.DeserializeObject<List<ViewGalleryModel>>(_objIHttpWebClients.PostRequest("Gallery/ViewWebsiteGallery", JsonConvert.SerializeObject(objViewGalleryModel)));
                return objlistBanner;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
