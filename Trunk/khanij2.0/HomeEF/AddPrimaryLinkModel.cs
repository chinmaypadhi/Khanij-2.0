// ***********************************************************************
//  Class Name               : AddPrimaryLinkModel
//  Desciption               : Add Primary Link Model Details 
//  Created By               : Prakash Chandra Biswal 
//  Created On               : 2 Nov 2021
// ***********************************************************************

namespace HomeEF
{
   public class AddPrimaryLinkModel
    {
        public string INT_ABOUTUS_ID { get; set; }
        public string VCH_ABOUTUS_ID { get; set; }
        public string INT_REGISTRATION_ID { get; set; }
        public string VCH_REGISTRATION_ID { get; set; }
        public string INT_STATISTICAL_REPORT_ID { get; set; }
        public string VCH_STATISTICAL_REPORT_ID { get; set; }
        public string VCH_PAGE_NAME { get; set; }
        public int? INT_PAGE_ID { get; set; }
        public int? INT_CREATED_BY { get; set; }
        public  int? GLOBAL_LINK_ID { get; set; }
    }
}
