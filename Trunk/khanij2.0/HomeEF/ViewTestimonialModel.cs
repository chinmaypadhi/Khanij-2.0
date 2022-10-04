// ***********************************************************************
//  Class Name               : ViewTestimonialModel
//  Desciption               : View,delete Website Testimonial Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 Oct 2021
// ***********************************************************************

namespace HomeEF
{
    public class ViewTestimonialModel
    {
        public int? INT_TESTIMONIAL_ID { get; set; }
        public string VCH_TESTIMONIAL_MSG { get; set; }
        public string VCH_TESTIMONIAL_NAME { get; set; }
        public string VCH_TESTIMONIAL_DESG { get; set; }
        public string VCH_TESTIMONIAL_LOCATION { get; set; }
        public string VCH_IMG_PATH { get; set; }
        public int? INT_CREATED_BY { get; set; }
        public string BIT_STATUS { get; set; }
        public string VCH_IMG_NAME { get; set; }
    }
}
