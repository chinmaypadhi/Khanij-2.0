// ***********************************************************************
//  Interface Name           : ITestimonialModel
//  Desciption               : Add,Select,Update,Delete Website Testimonial Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 Oct 2021
// ***********************************************************************
using HomeEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Testimonial
{
    public interface ITestimonialModel
    {
        /// <summary>
        /// Add Website Testimonial Details 
        /// </summary>
        /// <param name="objAddTestimonialModel"></param>
        /// <returns></returns>
        MessageEF Add(AddTestimonialModel objAddTestimonialModel);
        /// <summary>
        /// Update Website Testimonial Details 
        /// </summary>
        /// <param name="objAddTestimonialModel"></param>
        /// <returns></returns>
        MessageEF Update(AddTestimonialModel objAddTestimonialModel);
        /// <summary>
        /// Edit Website Testimonial Details
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        AddTestimonialModel Edit(AddTestimonialModel objAddTestimonialModel);
        /// <summary>
        /// Select Website Testimonial Details 
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        List<ViewTestimonialModel> View(ViewTestimonialModel objViewTestimonialModel);
        /// <summary>
        /// Delete Website Testimonial Details 
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        MessageEF Delete(ViewTestimonialModel objViewTestimonialModel);
        /// <summary>
        /// Select Publish Website Testimonial Details 
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        List<ViewTestimonialModel> ViewPublishTestimonial(ViewTestimonialModel objViewTestimonialModel);
    }
}
