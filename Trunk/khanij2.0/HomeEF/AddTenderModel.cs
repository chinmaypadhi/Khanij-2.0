// ***********************************************************************
//  Class Name               : AddTenderModel
//  Desciption               : Add Website Tender Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Oct 2021
// ***********************************************************************
using System;
using Microsoft.AspNetCore.Http;

namespace HomeEF
{
    public class AddTenderModel
    {
        public int? INT_TENDER_ID { get; set; }
        public string VCH_SUBJECT { get; set; }
        public string VCH_DOCUMENT { get; set; }
        public int? INT_CREATED_BY { get; set; }
        public bool BIT_STATUS { get; set; }
        public string VCH_TENDER_NO { get; set; }
        public string DTM_TENDER_OPEN_DATE { get; set; }
        public string DTM_TENDER_OPEN_TIME { get; set; }
        public string DTM_TENDER_CLOSE_DATE { get; set; }
        public string DTM_TENDER_CLOSE_TIME { get; set; }
        public IFormFile Tenderfile { get; set; }
    }
}
