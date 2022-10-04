// ***********************************************************************
//  Class Name               : AddFeedbackModel
//  Desciption               : Add,Select,Update,Delete Website Feedback Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 21 Oct 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class AddFeedbackModel
    {
        public int ? FEEDBACK_ID { get; set; }
        public string FULL_NAME { get; set; }
        public string MAIL_ID { get; set; }
        public string FEEDBACK { get; set; }
        public int? CREATED_BY { get; set; }
        public bool BIT_STATUS { get; set; }

    }
}
