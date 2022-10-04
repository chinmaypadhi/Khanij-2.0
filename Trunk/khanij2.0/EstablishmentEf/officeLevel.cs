using System;
using System.Collections.Generic;
using System.Text;

namespace EstablishmentEf
{
   public  class officeLevelEF
    {
        public string Status { get; set; }
        public int IntOfficeTypeId           {get;set;}
        public string VchOfficeTypeName      {get;set;}
        public bool bitSatus                 {get;set;}                                            
        public int intCreatedBy              {get;set;}
        public DateTime  dateCreatedOn       {get;set;}
        public bool BitdeletedFlage          {get;set;}
    }
}
