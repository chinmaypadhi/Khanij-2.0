// ***********************************************************************
//  Class Name               : TestimonialModel
//  Desciption               : Add,Select,Update,Delete Website Testimonial Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 Oct 2021
// ***********************************************************************
using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Testimonial
{
    public class TestimonialModel:ITestimonialModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public TestimonialModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Website Testimonial Details
        /// </summary>
        /// <param name="objAddTestimonialModel"></param>
        /// <returns></returns>
        public MessageEF Add(AddTestimonialModel objAddTestimonialModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Testimonial/Add", JsonConvert.SerializeObject(objAddTestimonialModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Website Testimonial Details 
        /// </summary>
        /// <param name="objAddTestimonialModel"></param>
        /// <returns></returns>
        public MessageEF Update(AddTestimonialModel objAddTestimonialModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Testimonial/Update", JsonConvert.SerializeObject(objAddTestimonialModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Website Testimonial Details
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        public AddTestimonialModel Edit(AddTestimonialModel objAddTestimonialModel)
        {
            try
            {
                objAddTestimonialModel = JsonConvert.DeserializeObject<AddTestimonialModel>(_objIHttpWebClients.PostRequest("Testimonial/Edit", JsonConvert.SerializeObject(objAddTestimonialModel)));
                return objAddTestimonialModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Testimonial Details 
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        public List<ViewTestimonialModel> View(ViewTestimonialModel objViewTestimonialModel)
        {
            try
            {
                List<ViewTestimonialModel> objlistNotification = new List<ViewTestimonialModel>();
                objlistNotification = JsonConvert.DeserializeObject<List<ViewTestimonialModel>>(_objIHttpWebClients.PostRequest("Testimonial/View", JsonConvert.SerializeObject(objViewTestimonialModel)));
                return objlistNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Website Testimonial Details 
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        public MessageEF Delete(ViewTestimonialModel objViewTestimonialModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Testimonial/Delete", JsonConvert.SerializeObject(objViewTestimonialModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Testimonial Details 
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        public List<ViewTestimonialModel> ViewPublishTestimonial(ViewTestimonialModel objViewTestimonialModel)
        {
            try
            {
                List<ViewTestimonialModel> objlistNotification = new List<ViewTestimonialModel>();
                objlistNotification = JsonConvert.DeserializeObject<List<ViewTestimonialModel>>(_objIHttpWebClients.PostRequest("Testimonial/ViewPublishTestimonial", JsonConvert.SerializeObject(objViewTestimonialModel)));
                return objlistNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
