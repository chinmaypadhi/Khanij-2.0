// ***********************************************************************
//  Class Name               : AddPageModel
//  Desciption               : Add,Select,Update,Delete Website Page Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 28 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class AddPageModel
    {
        public int? INT_PAGE_ID { get; set; }
        public string VCH_PAGE_NAME { get; set; }
        public string VCH_PAGE_NAME_ALIAS { get; set; }
        public string VCH_PAGE_TITLE { get; set; }
        public string VCH_PAGE_SNIPPET { get; set; }
        public string VCH_META_TITLE { get; set; }
        public string VCH_META_KEYWORD { get; set; }
        public string VCH_META_DESCIPTION { get; set; }
        public string VCH_META_IMAGE_NAME { get; set; }
        public string VCH_FEATURE_IMAGE_NAME { get; set; }
        public bool BIT_LINK_TYPE { get; set; }
        public string VCH_URL { get; set; }
        public bool BIT_WINDOW_STATUS { get; set; }
        public string VCH_ACTION { get; set; }
        public int INT_PAGE_TYPE { get; set; }
        public int INT_PLUGIN_TYPE { get; set; }
        public string VCH_PLUGIN_NAME { get; set; }
        public string VCH_PAGE_CONTENT { get; set; }
        public bool BIT_STATUS { get; set; }
        public int? INT_CREATED_BY { get; set; }
        public IFormFile META_IMG_FILE { get; set; }
        public IFormFile FEATURE_IMAGE_FILE { get; set; }

    }
}
