// ***********************************************************************
//  Class Name               : ViewBannerModel
//  Desciption               : View,Delete Website Banner Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 22 Oct 2021
// ***********************************************************************

namespace HomeEF
{
    public class ViewBannerModel
    {
        public int? INT_CREATED_BY { get; set; }
        public int? INT_BANNER_ID { get; set; }
        public string VCH_BANNER_NAME { get; set; }
        public string VCH_DESCRIPTION { get; set; }
        public string VCH_BANNER_URL { get; set; }
        public string VCH_DESKTOP_DOCUMENT { get; set; }
        public string VCH_MOBILE_DOCUMENT { get; set; }
        public int INT_SEQUENCE { get; set; }
        public string BIT_STATUS { get; set; }
        public string VCH_DESKTOP_DOCUMENT_NAME { get; set; }
        public string VCH_MOBILE_DOCUMENT_NAME { get; set; }
    }
}
