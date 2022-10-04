using System;
using System.Collections.Generic;
using System.Text;

namespace EstablishmentEf
{
   public class SectionEF
    {
        public int IntSectionId       {get;set;}
        public string VchSectionName  {get;set;}
        public bool bitSatus          {get;set;}
        public bool  BitdeletedFlage  {get;set;}
        public int intCreatedBy       {get;set;}
        public DateTime dateCreatedOn { get; set; }
        public string Status { get; set; }
    }

    public class SectionOfficerTaggingEF
    {
        public int Check { get; set; }
        public int IntId { get; set; }
        public int IntSectionId { get; set; }
        public int intSectionOfficerId { get; set; }
        public int intSectionOfficerId2 { get; set; }
        public bool bitStatus { get; set; }
        public bool Bitdeleted { get; set; }
        public int intCreatedBy { get; set; }

    }
    public class SectionOfficerTaggingQueryEF
    {
        public int Check { get; set; }
        public int IntId { get; set; }
        public string  Section { get; set; }
        public string SectionOfficer { get; set; }
        public string SectionOfficer2 { get; set; }
        public bool bitStatus { get; set; }

    }
    public class SectionDropDown
    {
        public int Check { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public int? Id { get; set; }
    }
}
