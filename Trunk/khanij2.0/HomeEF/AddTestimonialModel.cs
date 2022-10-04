// ***********************************************************************
//  Class Name               : AddTestimonialModel
//  Desciption               : Add,Edit,Update Website Testimonial Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 Oct 2021
// ***********************************************************************

using Microsoft.AspNetCore.Http;

namespace HomeEF
{
    public class AddTestimonialModel
    {
        public int? INT_TESTIMONIAL_ID { get; set; }
        public string VCH_TESTIMONIAL_MSG { get; set; }
        public string VCH_TESTIMONIAL_NAME { get; set; }
        public string VCH_TESTIMONIAL_DESG { get; set; }
        public string VCH_TESTIMONIAL_LOCATION { get; set; }
        public string VCH_IMG_PATH { get; set; }
        public int? INT_CREATED_BY { get; set; }
        public bool BIT_STATUS { get; set; }
        public IFormFile Photo { get; set; }
    }
}
