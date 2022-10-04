// ***********************************************************************
//  Class Name               : ViewNotificationModel
//  Desciption               : View Website Notification Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 07 Oct 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class ViewNotificationModel
    {
        public int? INT_CREATED_BY { get; set; }
        public int? INT_NOTIFICATION_ID { get; set; }
        public int? INT_NOTIFICATION_TYPE_ID { get; set; }
        public string VCH_NOTIFICATION_NAME { get; set; }
        public string VCH_NOTIFICATION_SUB { get; set; }
        public string VCH_UPLOAD_FILE { get; set; }
        public string BIT_STATUS { get; set; }
        public string DTM_PUBLISHED_ON { get; set; }
        public string DTM_CREATED_ON { get; set; }
        public string DTM_FROM_DATE { get; set; }
        public string DTM_TO_DATE { get; set; }
        public string DTM_PUBLISHED_DAY { get; set; }
        public string DTM_PUBLISHED_YEAR { get; set; }
    }
}
