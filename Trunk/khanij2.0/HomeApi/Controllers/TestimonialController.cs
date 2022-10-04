// ***********************************************************************
//  Controller Name          : TestimonialController
//  Desciption               : Add,Select,Update,Delete Website Testimonial Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 Oct 2021
// ***********************************************************************
using HomeApi.Model.Testimonial;
using HomeEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Controllers
{
    //[Route("api/{controller}/{action}")]
    //[ApiController]
    [Route("api/[controller]/{action}")]
    [ApiController]
    [Authorize]
    public class TestimonialController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public ITestimonialProvider _objITestimonialProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public TestimonialController(ITestimonialProvider objITestimonialProvider)
        {
            _objITestimonialProvider = objITestimonialProvider;
        }
        /// <summary>
        /// Add Website Testimonial Details in view
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>     
        [HttpPost]      
        public MessageEF Add(AddTestimonialModel objAddNotificationModel)
        {
            return _objITestimonialProvider.AddTestimonial(objAddNotificationModel);
        }
        /// <summary>
        /// Edit Website Testimonial Details in view
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public AddTestimonialModel Edit(AddTestimonialModel objAddNotificationModel)
        {
            return _objITestimonialProvider.EditTestimonial(objAddNotificationModel);
        }
        /// <summary>
        /// Select Website Testimonial Details in view
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewTestimonialModel>>> View(ViewTestimonialModel objViewTestimonialModel)
        {
            return await _objITestimonialProvider.ViewTestimonial(objViewTestimonialModel);
        }
        /// <summary>
        /// Delete Website Testimonial Details in view
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(ViewTestimonialModel objViewTestimonialModel)
        {
            return _objITestimonialProvider.DeleteTestimonial(objViewTestimonialModel);
        }
        /// <summary>
        /// Update Website Testimonial Details in view
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(AddTestimonialModel objAddNotificationModel)
        {
            return _objITestimonialProvider.UpdateTestimonial(objAddNotificationModel);
        }
        /// <summary>
        /// Select Publish Website Testimonial Details in view
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewTestimonialModel>>> ViewPublishTestimonial(ViewTestimonialModel objViewTestimonialModel)
        {
            return await _objITestimonialProvider.ViewPublishTestimonial(objViewTestimonialModel);
        }
    }
}
