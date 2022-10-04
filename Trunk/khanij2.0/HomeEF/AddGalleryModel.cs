// ***********************************************************************
//  Class Name               : AddGalleryModel
//  Desciption               : Add,Edit,Update Gallery Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;

namespace HomeEF
{
    public class AddGalleryModel
    {
        public int? INT_GALLERY_ID { get; set; }
        public int? INT_CONTENT_TYPE { get; set; }
        public string VCH_THUMBNAIL_IMG_PATH { get; set; }
        public string VCH_IMG_PATH { get; set; }
        public string VCH_THUMBNAIL_VIDEOIMG_PATH { get; set; }
        public string VCH_VIDEO_PATH { get; set; }
        public string VCH_VIDEO_URL { get; set; }
        public string VCH_GALLERY_DESC { get; set; }
        public string THUMBNAIL_PATH { get; set; }
        public string LARGE_PATH { get; set; }
        public int? INT_SEQUENCE { get; set; }
        public bool? BIT_STATUS { get; set; }
        public int? INT_CREATED_BY { get; set; }
        public IFormFile ThumbnailImgFile { get; set; }
        public IFormFile ImgFile { get; set; }
        public IFormFile ThumbnailVideoImgFile { get; set; }
        public IFormFile VideoFile { get; set; }
       
    }
}
