using System;
using System.Collections.Generic;
using System.Text;

namespace EstablishmentEf
{
   public  class ClassIIIAppraisalEF
    {
        public string Satus { get; set; }
       public int? AppraisalId {get;set;}
       public int? Department  {get;set;}
        public string Deptname { get; set; }
        public int? Designation {get;set;}
        public string designationname { get; set; }
        public int? Personname { get; set; }
        public string ApplicantName { get; set; }
       public string Paygrade { get; set; }
       public string description { get; set; }
       public string Naturebehavior { get; set; }
       public string Character { get; set; }
       public string Relationcolleague { get; set; }
       public string Punctuality_work { get; set; }
       public string Accuracytyping { get; set; }
       public string Allegiance { get; set; }
       public string Arrangementfiles { get; set; }
       public string importantwork { get; set; }
       public string Promotion { get; set; }
       public string workdetails { get; set; }
       public string Grade { get; set; }
       public string VchReviewingWorkDetails { get; set; }
       public string ReviewingGrade { get; set; }
       public DateTime?  Reviewingdate { get; set; }
       public int? Reviewingby { get; set; }
       public string VchAcceptingWorkDetails { get; set; }
       public string AcceptingGrade { get; set; }
       public DateTime? Acceptingdate { get; set; }
       public int? Acceptingby { get; set; }
       public int? intCreatedBy { get; set; }
       public DateTime? dateCreatedOn { get; set; }
       public int? intUpdatedBy { get; set; }
       public DateTime? dateUpdatedOn { get; set; }
       public bool? bitDeleted { get; set; }
       public string FinancialYear { get; set; }

    }
}
