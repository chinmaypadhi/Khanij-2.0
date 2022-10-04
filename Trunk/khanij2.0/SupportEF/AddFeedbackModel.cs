using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportEF
{
    public class AddFeedbackModel
    {
        public int? FEEDBACK_ID { get; set; }
        public string FULL_NAME { get; set; }
        public string MAIL_ID { get; set; }
        public string FEEDBACK { get; set; }
        public int? CREATED_BY { get; set; }
        public bool BIT_STATUS { get; set; }
    }
}
