// ***********************************************************************
//  Class Name               : ViewTenderModel
//  Desciption               : View Website Tender Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Oct 2021
// ***********************************************************************

namespace HomeEF
{
    public class ViewTenderModel
    {
        public int? INT_CREATED_BY { get; set; }
        public int? INT_TENDER_ID { get; set; }
        public string VCH_TENDER_NO { get; set; }
        public string DTM_TENDER_DATE { get; set; }
        public string VCH_DOCUMENT { get; set; }
        public string VCH_SUBJECT { get; set; }
        public string BIT_STATUS { get; set; }
        public string DTM_TENDER_OPEN_DATE { get; set; }
        public string DTM_TENDER_OPEN_TIME { get; set; }
        public string DTM_TENDER_CLOSE_DATE { get; set; }
        public string DTM_TENDER_CLOSE_TIME { get; set; }
        public string DTM_TENDER_OPEN_DATETIME { get; set; }
        public string DTM_TENDER_CLOSE_DATETIME { get; set; }
        public string DTM_FROM_DATE { get; set; }
        public string DTM_TO_DATE { get; set; }
        public string DTM_FROM_DAY { get; set; }
        public string DTM_FROM_YEAR { get; set; }
    }
}
