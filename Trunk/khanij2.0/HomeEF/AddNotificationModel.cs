// ***********************************************************************
//  Class Name               : AddNotificationModel
//  Desciption               : Add Website Notification Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 07 Oct 2021
// ***********************************************************************
using System;
using Microsoft.AspNetCore.Http;

namespace HomeEF
{
    public class AddNotificationModel
    {    
        public int? INT_NOTIFICATION_ID { get; set; }
        public string VCH_NOTIFICATION_SUB { get; set; }
        public int?INT_NOTIFICATION_TYPE_ID { get; set; }
        public string VCH_NOTIFICATION_NAME { get; set; }
        public string VCH_UPLOAD_FILE { get; set; }
        public string DTM_PUBLISHED_ON { get; set; }
        public int? INT_CREATED_BY { get; set; }
        public bool BIT_STATUS { get; set; }
        public IFormFile Notificationfile { get; set; }
    }
}
