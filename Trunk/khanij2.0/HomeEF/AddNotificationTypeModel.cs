// ***********************************************************************
//  Class Name               : AddNotificationTypeModel
//  Desciption               : Add Website Notification Type Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Oct 2021
// ***********************************************************************

namespace HomeEF
{
    public class AddNotificationTypeModel
    {
        public int? INT_NOTIFICATION_TYPE_ID { get; set; }
        public string VCH_NOTIFICATION_NAME { get; set; }
        public string VCH_NOTIFICATION_DESC { get; set; }
        public bool? BIT_STATUS { get; set; }
        public int? INT_CREATED_BY { get; set; }
    }
}
