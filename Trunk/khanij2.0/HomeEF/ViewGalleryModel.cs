// ***********************************************************************
//  Class Name               : ViewGalleryModel
//  Desciption               : View,Delete Gallery Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Oct 2021
// ***********************************************************************

namespace HomeEF
{
    public class ViewGalleryModel
    {
        public int? INT_GALLERY_ID { get; set; }
        public int? INT_SEQUENCE { get; set; }
        public int? INT_CREATED_BY { get; set; }
        public string VCH_CONTENT_TYPE { get; set; }
        public string VCH_THUMBNAIL_IMG_PATH { get; set; }
        public string VCH_IMG_PATH { get; set; }
        public string VCH_THUMBNAIL_VIDEOIMG_PATH { get; set; }
        public string VCH_VIDEO_PATH { get; set; }
        public string VCH_VIDEO_URL { get; set; }
        public string VCH_GALLERY_DESC { get; set; }
        public string THUMBNAIL_PATH { get; set; }
        public string LARGE_PATH { get; set; }      
        public string BIT_STATUS { get; set; }
        public string GALLERY_ID { get; set; }
    }
}
