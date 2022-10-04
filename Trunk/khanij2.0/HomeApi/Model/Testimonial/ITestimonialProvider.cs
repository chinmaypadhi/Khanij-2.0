// ***********************************************************************
//  Interface Name           : ITestimonialProvider
//  Desciption               : Add,Select,Update,Delete Website Testimonial Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 Oct 2021
// ***********************************************************************
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Model.Testimonial
{
    public interface ITestimonialProvider
    {
        /// <summary>
        /// Add Website Testimonial Details 
        /// </summary>
        /// <param name="objAddTestimonialModel"></param>
        /// <returns></returns>
        MessageEF AddTestimonial(AddTestimonialModel objAddTestimonialModel);
        /// <summary>
        /// Select Website Testimonial Details 
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        Task<List<ViewTestimonialModel>> ViewTestimonial(ViewTestimonialModel objViewTestimonialModel);
        /// <summary>
        /// Edit Website Testimonial Details
        /// </summary>
        /// <param name="objAddTestimonialModel"></param>
        /// <returns></returns>
        AddTestimonialModel EditTestimonial(AddTestimonialModel objAddTestimonialModel);
        /// <summary>
        /// Delete Website Testimonial Details 
        /// </summary>
        /// <param name="objAddTestimonialModel"></param>
        /// <returns></returns>
        MessageEF DeleteTestimonial(ViewTestimonialModel objViewTestimonialModel);
        /// <summary>
        /// Update Website Testimonial Details 
        /// </summary>
        /// <param name="objAddTestimonialModel"></param>
        /// <returns></returns>
        MessageEF UpdateTestimonial(AddTestimonialModel objAddTestimonialModel);
        /// <summary>
        /// Select Published Website Testimonial Details 
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        Task<List<ViewTestimonialModel>> ViewPublishTestimonial(ViewTestimonialModel objViewTestimonialModel);
    }
}
