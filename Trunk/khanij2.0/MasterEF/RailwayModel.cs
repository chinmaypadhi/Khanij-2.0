using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class RailwayModel
    {
        public int? RailwayID { get; set; } 
        public string RailwayName { get; set; } 
        public string RailwaySlidingName { get; set; } 
        public string RailwaySlidingType { get; set; } 
        public string RailwayAuthorityName { get; set; } 
        public string Address { get; set; }
 
        public int? TehsilID { get; set; }
        public string TehsilName { get; set; }
 
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }

   
        public int? RailwayZoneID { get; set; }
        public string RailwayZoneName { get; set; }
 
        public string ContactNo { get; set; } 
        public string MailID { get; set; }

        public string ActiveStatus { get; set; }
        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public string Status { get; set; }
        public int? CreatedBy { get; set; }
    }
}
